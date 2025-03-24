﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TheTvdbDotNet
{
    public static class TvdbSeriesExtensions
    {
        public static Task<IEnumerable<BasicEpisode>> GetAllEpisodesAsync(
            this ITvdbSeries seriesRepository,
            int seriesId) =>
            GetAllEpisodesAsync(page => seriesRepository.GetEpisodesAsync(seriesId, page));

        private static async Task<IEnumerable<BasicEpisode>> GetAllEpisodesAsync(
            Func<string, Task<SeriesEpisodes>> getEpisodes)
        {
            var episodeData = await getEpisodes("1").ConfigureAwait(false);
            IEnumerable<BasicEpisode> episodes = episodeData.Data;
            if (HasMorePages(episodeData))
            {
                var remainingPages = GetRemainingPagesAsync(getEpisodes, episodeData.Links.Last.Value);
                episodes = episodes.Concat(await remainingPages.ConfigureAwait(false));
            }

            return episodes;
        }

        private static bool HasMorePages(SeriesEpisodes episodeData) =>
            episodeData.Links != null && episodeData.Links.Last.HasValue && episodeData.Links.Last.Value > 1;

        private static async Task<IEnumerable<BasicEpisode>> GetRemainingPagesAsync(
            Func<string, Task<SeriesEpisodes>> getEpisodes, int lastPage)
        {
            var remainingPagesTasks = Enumerable.Range(2, lastPage - 1)
                .Select(page => getEpisodes(page.ToString()));
            var remainingPages = await Task.WhenAll(remainingPagesTasks).ConfigureAwait(false);
            return remainingPages.SelectMany(x => x.Data);
        }
    }
}
