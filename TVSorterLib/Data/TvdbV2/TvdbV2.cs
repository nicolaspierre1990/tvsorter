﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TheTvdbDotNet;
using TVSorter.Model;

namespace TVSorter.Data.TvdbV2;

public class TvdbV2(ITvdbSeries series, ITvdbSearch search, ITvdbUpdate update, IStreamWriter streamWriter) : IDataProvider
{
    private readonly ITvdbSearch search = search;
    private readonly ITvdbSeries series = series;
    private readonly IStreamWriter streamWriter = streamWriter;
    private readonly ITvdbUpdate update = update;

    /// <inheritdoc/>
    public List<TvShow> SearchShow(string name)
    {
        try
        {
            var series = search.SeriesSearchAsync(name).GetAwaiter().GetResult();
            return series.Data.Select(x => new TvShow { Name = x.SeriesName, TvdbId = x.Id, FolderName = name })
                .ToList();
        }
        catch (TvdbRequestException)
        {
            return [];
        }
    }

    public async Task<List<TvShow>> SearchShowAsync(string name, CancellationToken cancellationToken = default)
    {
        try
        {
            var series = await search.SeriesSearchAsync(name);
            return series.Data.Select(x => new TvShow { Name = x.SeriesName, TvdbId = x.Id, FolderName = name })
                .ToList();
        }
        catch (TvdbRequestException)
        {
            return [];
        }
    }

    public void UpdateShow(TvShow show)
    {
        var newSeries = series.GetSeriesAsync(show.TvdbId).GetAwaiter().GetResult();
        if (show.Banner != newSeries.Data.Banner)
        {
            show.Banner = newSeries.Data.Banner;
            var banner = series.GetBannerAsnyc(newSeries.Data).Result;
            var targetPath = $"Images{Path.DirectorySeparatorChar}{show.TvdbId}.jpg";
            streamWriter.WriteStream(banner, targetPath);
        }

        var newEpisodes = series.GetAllEpisodesAsync(show.TvdbId)
            .GetAwaiter()
            .GetResult()
            .Select(
                x => new Episode
                {
                    TvdbId = x.Id.ToString(),
                    ShowId = show.TvdbId,
                    EpisodeNumber =
                        show.UseDvdOrder && x.DvdEpisodeNumber.HasValue
                            ? x.DvdEpisodeNumber.Value
                            : x.AiredEpisodeNumber.Value,
                    SeasonNumber =
                        show.UseDvdOrder && x.DvdSeason.HasValue ? x.DvdSeason.Value : x.AiredSeason.Value,
                    FirstAir = x.FirstAired.ValidateTime() ? DateTime.Parse(x.FirstAired) : DateTime.Parse("1970-01-01"),
                    Name = x.EpisodeName ?? string.Empty,
                    Show = show,
                })
            .ToList();

        if (show.Episodes != null)
        {
            foreach (var episode in newEpisodes)
            {
                var currentEpisode = show.Episodes.FirstOrDefault(x => x.Equals(episode));
                if (currentEpisode != null)
                {
                    episode.FileCount = currentEpisode.FileCount;
                }
            }
        }

        show.Episodes = newEpisodes;
        show.LastUpdated = DateTime.UtcNow;
    }

    public async Task UpdateShowAsync(TvShow show, CancellationToken cancellationToken = default)
    {
        var newSeries = await series.GetSeriesAsync(show.TvdbId);
        if (show.Banner != newSeries.Data.Banner)
        {
            show.Banner = newSeries.Data.Banner;
            var banner = series.GetBannerAsnyc(newSeries.Data).Result;
            var targetPath = $"Images{Path.DirectorySeparatorChar}{show.TvdbId}.jpg";
            streamWriter.WriteStream(banner, targetPath);
        }

        var newEpisodesResult = await series.GetAllEpisodesAsync(show.TvdbId);
        var newEpisodes = newEpisodesResult.Select(
                x => new Episode
                {
                    TvdbId = x.Id.ToString(),
                    ShowId = show.TvdbId,
                    EpisodeNumber =
                        show.UseDvdOrder && x.DvdEpisodeNumber.HasValue
                            ? x.DvdEpisodeNumber.Value
                            : x.AiredEpisodeNumber.Value,
                    SeasonNumber =
                        show.UseDvdOrder && x.DvdSeason.HasValue ? x.DvdSeason.Value : x.AiredSeason.Value,
                    FirstAir = x.FirstAired.ValidateTime() ? DateTime.Parse(x.FirstAired) : DateTime.Parse("1970-01-01"),
                    Name = x.EpisodeName ?? string.Empty,
                    Show = show,
                })
            .ToList();

        if (show.Episodes != null)
        {
            foreach (var episode in newEpisodes)
            {
                var currentEpisode = show.Episodes.FirstOrDefault(x => x.Equals(episode));
                if (currentEpisode != null)
                {
                    episode.FileCount = currentEpisode.FileCount;
                }
            }
        }

        show.Episodes = newEpisodes;
        show.LastUpdated = DateTime.UtcNow;
    }

    public IEnumerable<TvShow> UpdateShows(IList<TvShow> shows)
    {
        var firstUpdate = shows.Min(x => x.LastUpdated);
        List<int> updateIds;

        // Only get the updates if the date is less than a month ago.
        if (firstUpdate > DateTime.Today.Subtract(TimeSpan.FromDays(30)))
        {
            updateIds = update.GetUpdatesAsync(firstUpdate).Result.Data.Select(x => x.Id).ToList();
        }
        else
        {
            updateIds = shows.Select(x => x.TvdbId).ToList();
        }

        foreach (var show in shows)
        {
            // Skip the show if it isn't in the updateIds list.
            if (!updateIds.Contains(show.TvdbId))
            {
                Logger.OnLogMessage(this, "No updates for {0}", LogType.Info, show.Name);

                // Update the last updated time anyway, it is still up to date at this time.
                show.LastUpdated = DateTime.UtcNow;
            }
            else
            {
                UpdateShow(show);
            }

            yield return show;
        }
    }

    public async Task<IEnumerable<TvShow>> UpdateShowsAsync(IList<TvShow> shows, CancellationToken cancellationToken = default)
    {
        var firstUpdate = shows.Min(x => x.LastUpdated);
        List<int> updateIds;

        // Only get the updates if the date is less than a month ago.
        if (firstUpdate > DateTime.Today.Subtract(TimeSpan.FromDays(30)))
        {
            updateIds = update.GetUpdatesAsync(firstUpdate).Result.Data.Select(x => x.Id).ToList();
        }
        else
        {
            updateIds = shows.Select(x => x.TvdbId).ToList();
        }

        foreach (var show in shows)
        {
            // Skip the show if it isn't in the updateIds list.
            if (!updateIds.Contains(show.TvdbId))
            {
                Logger.OnLogMessage(this, "No updates for {0}", LogType.Info, show.Name);

                // Update the last updated time anyway, it is still up to date at this time.
                show.LastUpdated = DateTime.UtcNow;
            }
            else
            {
                await UpdateShowAsync(show, cancellationToken);
            }
        }

        return shows;
    }
}
