// --------------------------------------------------------------------------------------------------------------------
// <copyright company="TVSorter" file="ScanManagerTests.cs">
//   2012 - Andrew Jackson
// </copyright>
// <summary>
//   Tests for the  class.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using NSubstitute;
using TVSorter.Data;
using TVSorter.Files;
using TVSorter.Model;
using TVSorter.Repostitory;
using TVSorter.Wrappers;
using Xunit;

namespace TVSorter.Test;

/// <summary>
///     Tests for the <see cref="ScanManager" /> class.
/// </summary>
public class ScanManagerTests : ManagerTestBase
{
    /// <summary>
    ///     Sets up the tests in the fixture.
    /// </summary>
    public ScanManagerTests()
    {
        Setup();

        dataProvider = Substitute.For<IDataProvider>();
        tvShowRepository = new TvShowRepository(StorageProvider, dataProvider);
        scanManager = new ScanManager(StorageProvider, dataProvider, tvShowRepository);
    }

    /// <summary>
    ///     Gets or sets the data provider.
    /// </summary>
    private readonly IDataProvider dataProvider;

    /// <summary>
    ///     The scan manager that the tests will be performed on.
    /// </summary>
    private readonly ScanManager scanManager;

    /// <summary>
    ///     The TV show repository.
    /// </summary>
    private readonly ITvShowRepository tvShowRepository;

    /// <summary>
    /// This test will test several different output formats to ensure
    /// that the destination paths are correct.
    /// </summary>
    /// <param name="format">The format being tested.</param>
    /// <param name="expectedResult">The expected result.</param>
    [Theory(Skip = "Check values")]
    [InlineData(
        @"{FName}\Season {SNum(1)}\{SName(.)}.S{SNum(2)}E{ENum(2)}.{EName(.)}{Ext}",
        @"Alpha Folder\Season 1\Alpha.Show.S01E01.Episode.One.(1).avi")]
    [InlineData(
        @"{FName}\{Date(yyyy)}\{Date(MMM)}\{SName(.)}.S{SNum(2)}E{ENum(2)}.{Date(dd-MMM-yyyy)}.{EName(.)}{Ext}",
        @"Alpha Folder\2012\Jan\Alpha.Show.S01E01.01-Jan-2012.Episode.One.(1).avi")]
    [InlineData(@"{FName}", "Alpha Folder")]
    [InlineData(@"{SName( )} {SName(.)} {SName(_)}", "Alpha Show Alpha.Show Alpha_Show")]
    [InlineData(
        @"{EName( )} {EName(.)} {EName(_)}",
        "Episode One (1) Episode.One.(1) Episode_One_(1)")]
    [InlineData(@"{SNum(1)} {SNum(2)} {SNum(3)}",  "1 01 001")]
    [InlineData(@"{ENum(1)} {ENum(2)} {ENum(3)}", "1 01 001")]
    [InlineData(@"{Date(yyyy)} {Date(MM)} {Date(MMM)} {Date(dd)}",  "2012 01 Jan 01")]
    public void TestOutputFormat(string format, string expectedResult)
    {
        // Creat the result.
        var result = new FileResult
        {
            Checked = true,
            Show = TestShows.First(),
            InputFile = Substitute.For<IFileInfo>(),
        };
        result.Episode = result.Show.Episodes.First();
        result.Episodes = new List<Episode> { result.Episode };
        result.InputFile.Extension.Returns(".avi");

        var fileResultManager = new FileResultManager(StorageProvider);

        // Format the string.
        var fileResult = fileResultManager.FormatOutputPath(result, format);

        fileResult.Should().Be(expectedResult);
    }

    /// <summary>
    ///     Asserts the result matches the first show and its first episode.
    /// </summary>
    /// <param name="result">
    ///     The result to check.
    /// </param>
    private void MatchesShow1(FileResult result)
    {
        TestShows.First().Should().BeEquivalentTo(result.Show, "The result should be the first test show.");
        TestShows.First().Episodes.First().Should().BeEquivalentTo(result.Episode, "The result should match the show's first episode.");
    }

    /// <summary>
    ///     Tests that an alternate name is added to an existing show.
    /// </summary>
    [Fact]
    public void AddAlternateName()
    {
        var alpha = TestShows.First();

        // When the data provider is searched for ShowName, return Alpha.
        dataProvider.SearchShow("ShowName").Returns([alpha]);

        // Create the file to be searched.
        CreateTestFile(Root, "ShowName.S01E01.avi");

        // When the show is saved, alpha should contain ShowName as an alternate name.
        StorageProvider.When(x => x.SaveShow(alpha))
            .Do(x => Assert.Contains("ShowName", x.Arg<TvShow>().AlternateNames));

        var results = scanManager.Refresh(Root.FullName);

        // There should be one result matching Delta Episode 1.
        results.Should().HaveCount(1, "There should be one result.");
        results[0].Show.Should().BeEquivalentTo(alpha, "The show shuld be Alpha");

        // Check that the results were called.
        StorageProvider.Received(1).SaveShow(alpha);
    }

    /// <summary>
    ///     Tests the functionality to add unmatched shows.
    /// </summary>
    [Fact]
    public void AddUnmatchedShow()
    {
        // Create new show and episodes
        var delta = new TvShow { Name = "Delta", FolderName = "Delta", TvdbId = 4 };
        var episode1 = new Episode { EpisodeNumber = 1, SeasonNumber = 1, Name = "Episode 1", TvdbId = "41" };

        // Create a file for the search to return.
        CreateTestFile(Root, "Delta.S01E01.avi");

        // When the data provider searches for Delta return the delta show.
        dataProvider.SearchShow("Delta").Returns([delta]);

        // When the show is saved, get the new show. A new one will be created by
        // TvShow.FromSearchResult
        StorageProvider.When(x => x.SaveShow(Arg.Any<TvShow>())).Do(x => { delta = x.Arg<TvShow>(); });

        // Delta should be updated.When it is, add the episode.
        dataProvider.When(x => x.UpdateShow(delta)).Do(x => { delta.Episodes = [episode1]; });

        // Search the folder.
        var results = scanManager.Refresh(Root.FullName);

        // There should be one result matching Delta Episode 1.
        results.Should().HaveCount(1, "There should be one result.");
        results[0].Show.Should().BeEquivalentTo(delta, "The show shuld be Delta");
        results[0].Episode.Should().BeEquivalentTo(episode1, "The episode should be Episode 1");
    }

    /// <summary>
    ///     Tests the output format the dual episodes.
    /// </summary>
    [Fact]
    public void DualEpisodeFormatting()
    {
        // Creat the result.
        var result = new FileResult
        {
            Checked = true,
            Show = TestShows.First(),
            InputFile = Substitute.For<IFileInfo>(),
        };
        result.Episode = result.Show.Episodes.First();
        result.Episodes = new List<Episode> { result.Episode, result.Show.Episodes[1] };
        result.InputFile.Extension.Returns(".avi");

        var fileResultManager = new FileResultManager(StorageProvider);

        // Format the string.
        var output = fileResultManager.FormatOutputPath(result, "{SName(.)}.S{SNum(2)}E{ENum(2)}.{EName(.)}");
        "Alpha.Show.S01E01-02.Episode.One.(1-2)".Should().BeEquivalentTo(output, "The output format does not match what it should be.");
    }

    /// <summary>
    ///     Tests the scanner ability to detect dual episodes.
    /// </summary>
    [Fact]
    public void DualEpisodeScanning()
    {
        CreateTestFile(Root, "Alpha.S01E01-02.avi");

        var results = scanManager.Refresh(Root.FullName);

        results.Should().HaveCount(1, "There should be one result.");
        MatchesShow1(results[0]);
        results[0].Episodes.Count.Should().Be(2, "There should be 2 episode in the result.");
        TestShows.First().Episodes[1].Should().BeEquivalentTo(results[0].Episodes[1], "The second episode should be show's second epsiode.");
    }

    /// <summary>
    ///     Tests the precedence of the the regular expressions to ensure that the higher listed match is used in the case of
    ///     multiple matches.
    /// </summary>
    /// <param name="seasonEpisodeNumber">
    ///     The season and episode number string format.
    /// </param>
    [Theory]
    [InlineData("S01E01.2x2")]
    [InlineData("S1E1.2012-02-02")]
    [InlineData("1 - 1.2x2")]
    [InlineData("1x1.0202")]
    [InlineData("01x01.0202")]
    [InlineData("0101.s2.e2")]
    [InlineData("s1.e1.s2.e2")]
    [InlineData("2012.01.01.Feb.02.2012")]
    [InlineData("Jan.01.2012.2x2")]
    public void EpisodeFormatPrecedence(string seasonEpisodeNumber)
    {
        CreateTestFile(Root, "Alpha." + seasonEpisodeNumber + ".avi");

        var results = scanManager.Refresh(Root.FullName);

        results.Should().HaveCount(1, "There should be one result.");
        MatchesShow1(results[0]);
    }

    /// <summary>
    ///     Tests that the system is able to match to the correct show. Allows for variations on the name and alternate names.
    /// </summary>
    /// <param name="showName">
    ///     The show's name in the file name.
    /// </param>
    [Theory]
    [InlineData("Alpha")]
    [InlineData("Alpha.Folder")]
    [InlineData("ALPHA_FOLDER")]
    [InlineData("ALPHA-FOLDER")]
    [InlineData("Alt Name")]
    [InlineData("AlT.Name")]
    [InlineData("Alt_Name")]
    [InlineData("alt-name")]
    [InlineData("Alpha Show")]
    [InlineData("Alpha.Show")]
    [InlineData("Alpha_Show")]
    [InlineData("Alpha-Show")]
    public void MatchesShow(string showName)
    {
        CreateTestFile(Root, showName + ".S01E01.avi");

        var results = scanManager.Refresh(Root.FullName);

        results.Should().HaveCount(1, "There should be one result.");
        MatchesShow1(results[0]);
    }

    /// <summary>
    ///     Tests that the program doesn't return matches for files that don't have a season/episode number or date in them.
    /// </summary>
    [Fact]
    public void NotAnEpisode()
    {
        CreateTestFile(Root, "Alpha.avi");
        CreateTestFile(Root, "Alpha.S01E01.noext");

        var results = scanManager.Refresh(Root.FullName);

        results.Should().HaveCount(0, "There should be one result.");
    }

    /// <summary>
    ///     Tests the scanner is not scanning recursively when it shouldn't be.
    /// </summary>
    [Fact]
    public void NotRecursiveScanning()
    {
        var sub = CreateTestDirectory(Root, "Sub");
        CreateTestFile(sub[0], "Alpha.S01E01.avi");
        var results = scanManager.Refresh(Root.FullName);
        results.Should().HaveCount(0, "There should be one result.");
    }

    /// <summary>
    ///     Tests that the scanner works recursively.
    /// </summary>
    [Fact]
    public void RecursiveScanner()
    {
        var sub = CreateTestDirectory(Root, "Sub");
        CreateTestFile(sub[0], "Alpha.S01E01.avi");

        StorageProvider.Settings.RecurseSubdirectories = true;

        var results = scanManager.Refresh(Root.FullName);
        results.Should().HaveCount(1, "There should be one result.");
        MatchesShow1(results[0]);
    }

    /// <summary>
    ///     Tests the refresh file counts function.
    /// </summary>
    [Fact]
    public void RefreshFileCountsTest()
    {
        // Create the folder and files to test.
        var folders = CreateTestDirectory(Root, "Alpha Folder", "Beta Folder");
        CreateTestFile(folders[0], "Alpha.S01E01.avi", "Alpha.S01E01.Name.avi", "Alpha.S01E01-02.avi");
        TestShows.First(x => x.Name == "Beta Show").Episodes[0].FileCount = 1;

        // When save shows is called. Assert that each episode has the correct file count.
        StorageProvider.SaveShows(
            Arg.Do(
                new Action<IEnumerable<TvShow>>(
                    x =>
                    {
                        var shows = x.ToList();
                        shows[0].Episodes[0].FileCount.Should().Be(3);
                        shows[0].Episodes[1].FileCount.Should().Be(1);
                        shows[1].Episodes[0].FileCount.Should().Be(0);
                    })));

        // Refresh the file counts.
        scanManager.RefreshFileCounts(new[] { Root });

        // Ensure that the call was made. If it was the delegate above will not have been run.
        StorageProvider.Received(1).SaveShows(Arg.Any<IEnumerable<TvShow>>());
    }

    /// <summary>
    ///     Tests the Refresh method can find a show with lots of different formats.
    /// </summary>
    /// <param name="seasonEpisodeNumber">
    ///     The season and episode number string format.
    /// </param>
    [Theory]
    [InlineData("S01E01")]
    [InlineData("S1E1")]
    [InlineData("1 - 1")]
    [InlineData("1x1")]
    [InlineData("01x01")]
    [InlineData("0101")]
    [InlineData("s1.e1")]
    [InlineData("2012.01.01")]
    [InlineData("Jan.01.2012")]
    public void RefreshFindShow(string seasonEpisodeNumber)
    {
        CreateTestFile(Root, "Alpha." + seasonEpisodeNumber + ".avi");

        var results = scanManager.Refresh(Root.FullName);

        results.Should().HaveCount(1, "There should be one result.");
        MatchesShow1(results[0]);
    }

    /// <summary>
    ///     Tests the functionality to reset the show on a result. The show should rematch the episode to an episode in the new
    ///     show.
    /// </summary>
    [Fact]
    public void ResetShow()
    {
        CreateTestFile(Root, "Alpha.S01E01.avi");

        var results = scanManager.Refresh(Root.FullName);

        results.Should().HaveCount(1, "There should be one result.");
        MatchesShow1(results[0]);

        scanManager.ResetShow(results[0], TestShows.First(x => x.Name == "Beta Show"));
        "Beta Show".Should().BeEquivalentTo(results[0].Show.Name, "The show hasn't changed.");
        "211".Should().BeEquivalentTo(results[0].Episode.TvdbId, "The episode hasn't changed.");
    }

    /// <summary>
    ///     Tests the functionality to reset the show. In this case, the destination show doesn't have the same episode.
    /// </summary>
    [Fact]
    public void ResetShowNoEpisode()
    {
        CreateTestFile(Root, "Alpha.S02E02.avi");

        var results = scanManager.Refresh(Root.FullName);

        results.Should().HaveCount(1, "There should be one result.");
        scanManager.ResetShow(results[0], TestShows.First(x => x.Name == "Beta Show"));
        "Beta Show".Should().BeEquivalentTo(results[0].Show.Name, "The show hasn't changed.");
        results[0].Episode.Should().BeNull("The episode shouldn't have been matched.");
    }

    /// <summary>
    ///     Tests the functionality to reset the show. In this case, the destination show doesn't have the same episode.
    /// </summary>
    [Fact]
    public void ResetShowToNull()
    {
        CreateTestFile(Root, "Alpha.S02E02.avi");

        var results = scanManager.Refresh(Root.FullName);

        results.Should().HaveCount(1, "There should be one result.");
        scanManager.ResetShow(results[0], null);
        results[0].Show.Should().BeNull("The show hasn't changed.");
        results[0].Episode.Should().BeNull("The episode shouldn't have been matched.");
    }

    /// <summary>
    ///     Tests the search new shows function.
    /// </summary>
    [Fact]
    public void SearchShowTest()
    {
        var gamma = new TvShow { Name = "Gamma", TvdbId = 3, FolderName = "Gamma Folder" };
        var delta = new TvShow { Name = "Delta", TvdbId = 4, FolderName = "Delta Folder" };
        var delta2 = new TvShow { Name = "Delta2", TvdbId = 5, FolderName = "Delta2 Folder" };

        dataProvider.SearchShow("Gamma Folder").Returns([gamma]);
        dataProvider.SearchShow("Delta Folder").Returns([delta, delta2]);

        // Create the directories that will be searched.
        CreateTestDirectory(Root, "Alpha Folder", "Beta Folder", "Gamma Folder", "Delta Folder");

        var results = scanManager.SearchNewShows(new[] { Root });

        // Assert that dataProvider.SearchShow was not called for Alpha and Beta since they already exist in storage.
        dataProvider.DidNotReceive().SearchShow("Alpha Folder");
        dataProvider.DidNotReceive().SearchShow("Beta Folder");

        // Assert that other shows where only searched once.
        dataProvider.Received(1).SearchShow("Gamma Folder");
        dataProvider.Received(1).SearchShow("Delta Folder");

        // Ensure that there were only 2 calls in total.
        dataProvider.ReceivedWithAnyArgs(2).SearchShow(Arg.Any<string>());

        // Ensure that the Gamma show was saved as there was only one result.
        StorageProvider.Received(1).SaveShow(gamma);

        // Should only have the Delta show in the results.
        results.Count.Should().Be(1);
        results["Delta Folder"].Count.Should().Be(2);

        // Check that the results are the shows that the data provider returned.
        results["Delta Folder"][0].Should().Be(delta);
        results["Delta Folder"][1].Should().Be(delta2);
    }
}
