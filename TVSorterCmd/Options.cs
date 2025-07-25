﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Options.cs" company="TVSorter">
//   2012 - Andrew Jackson
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using CommandLine;
using CommandLine.Text;

namespace TVSorter;

/// <summary>
///     Class containing the command line options.
/// </summary>
internal class Options
{
    /// <summary>
    ///     Gets or sets a value indicating whether to copy the episodes.
    /// </summary>
    [Option(
        'c',
        "copy",
        Default = false,
        HelpText = "Copies the files in the source directory.",
        Required = false,
        SetName = "sort")]
    public bool Copy { get; set; }

    /// <summary>
    ///     Gets or sets a value indicating whether to move the episodes.
    /// </summary>
    [Option(
        'm',
        "move",
        Default = false,
        HelpText = "Moves the files in the source directory.",
        Required = false,
        SetName = "sort")]
    public bool Move { get; set; }

    /// <summary>
    ///     Gets or sets a value indicating whether to update all the shows.
    /// </summary>
    [Option(
        'u',
        "update-all",
        Default = false,
        HelpText = "Updates the episode data for all shows.",
        Required = false,
        SetName = "update")]
    public bool UpdateAll { get; set; }

    /// <summary>
    ///     Gets or sets the name of the show to update.
    /// </summary>
    [Option(
        'd',
        "update-show",
        HelpText = "[show name] Updates the specified show",
        SetName = "update")]
    public string UpdateShow { get; set; }

    /// <summary>
    ///     Gets or sets a value indicating whether to scan for files.
    /// </summary>
    [Option(
        's',
        "scan",
        HelpText = "Scans for new episodes and displays the results. Does not move or copy any files.",
        SetName = "scan")]
    public bool Scan { get; set; }

    /// <summary>
    ///     Gets the usage string.
    /// </summary>
    /// <returns>The usage string for the system.</returns>
    public string GetUsage()
    {
        var help = new HelpText
        {
            Heading = new HeadingInfo("TVSorter", Version.CurrentVersion),
            Copyright = new CopyrightInfo("TVSorter", 2012),
            AdditionalNewLineAfterOption = true,
            AddDashesToOption = true,
        };
        help.AddPostOptionsLine(help);
        return help;
    }
}
