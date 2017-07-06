﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright company="TVSorter" file="Program.cs">
//   2012 - Andrew Jackson
// </copyright>
// <summary>
//   TVSorterCmd's program.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace TVSorter
{
    #region Using Directives

    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;

    using CommandLine;

    using Files;
    using Model;
    using Repostitory;
    using Ninject;
    using TheTvdbDotNet.Ninject;
    #endregion

    /// <summary>
    /// Entry point class for the TVSorter Command Line application.
    /// </summary>
    internal static class Program
    {
        #region Public Methods and Operators

        /// <summary>
        /// The program's entry point.
        /// </summary>
        /// <param name="args">
        /// The command line arguments.
        /// </param>
        public static void Main(string[] args)
        {
            // If program already running, quit.
            if (System.Diagnostics.Process.GetProcessesByName(
                System.IO.Path.GetFileNameWithoutExtension(
                System.Reflection.Assembly.GetEntryAssembly().Location)).Count() > 1)
            {
                System.Diagnostics.Process.GetCurrentProcess().Kill();
            }

            Logger.LogMessage += (sender, e) =>
                {
                    if (e.Type == LogType.Error)
                    {
                        Console.Error.WriteLine(e.LogMessage);
                    }
                    else
                    {
                        Console.WriteLine(e.LogMessage);
                    }
                };

            Options options = new Options();
            if (!Parser.Default.ParseArgumentsStrict(args, options))
            {
                Environment.Exit(1);
            }

            IKernel kernel = new StandardKernel(
                new LibraryModule(),
                new TheTvdbDotNetModule("D4DCAEBFCA5A6BC1"));
            var tvshowRepository = kernel.Get<ITvShowRepository>();
            var fileSearch = kernel.Get<IFileSearch>();

            if (options.UpdateAll)
            {
                List<TvShow> shows = tvshowRepository.GetTvShows().Where(x => !x.Locked).ToList();
                tvshowRepository.UpdateShows(shows);
            }

            if (options.UpdateShow != null)
            {
                var show =
                    tvshowRepository.GetTvShows().FirstOrDefault(
                        x => x.Name.Equals(options.UpdateShow, StringComparison.InvariantCultureIgnoreCase));
                if (show != null)
                {
                    tvshowRepository.Update(show);
                }
                else
                {
                    Console.Error.WriteLine("Unrecognised show: " + options.UpdateShow);
                }
            }

            if (options.Copy || options.Move || options.Scan)
            {
                fileSearch.Search(null);
                foreach (FileResult result in fileSearch.Results)
                {
                    result.Checked = true;
                }

                if (options.Copy)
                {
                    fileSearch.Copy();
                }
                else if (options.Move)
                {
                    fileSearch.Move();
                }
                else if (options.Scan)
                {
                    Console.WriteLine();
                    Console.WriteLine("* indicates incomplete match.\n");
                    Console.WriteLine(
                        "{0} {1} {2} {3} {4}",
                        "File Name".FormatLength(19),
                        "Show Name".FormatLength(19),
                        "Season".FormatLength(7),
                        "Episode".FormatLength(7),
                        "Episode Name".FormatLength(22));

                    foreach (var result in fileSearch.Results)
                    {
                        if (!result.Incomplete && result.Episode != null)
                        {
                            Console.WriteLine(
                                "{0} {1} {2} {3} {4}",
                                result.InputFile.Name.FormatLength(19),
                                result.ShowName.FormatLength(19),
                                result.Episode.SeasonNumber.ToString(CultureInfo.InvariantCulture).FormatLength(7),
                                result.Episode.EpisodeNumber.ToString(CultureInfo.InvariantCulture).FormatLength(7),
                                result.Episode.Name.FormatLength(22));
                        }
                        else
                        {
                            Console.WriteLine(
                                "* {0} {1} {2} {3} {4}",
                                result.InputFile.Name.FormatLength(17),
                                result.ShowName.FormatLength(20),
                                (result.Episode != null ? result.Episode.SeasonNumber.ToString(CultureInfo.InvariantCulture) : string.Empty).FormatLength(7),
                                (result.Episode != null ? result.Episode.EpisodeNumber.ToString(CultureInfo.InvariantCulture) : string.Empty).FormatLength(7),
                                (result.Episode != null ? result.Episode.Name : string.Empty).FormatLength(22));
                        }
                    }
                }
            }
        }

        #endregion
    }
}