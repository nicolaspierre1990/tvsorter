﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FileResultExtensions.cs" company="TVSorter">
//   2012 - Andrew Jackson
// </copyright>
// <summary>
//   Extension methods for the FileResult class.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using TVSorter.Files;
using TVSorter.Model;

namespace TVSorter;

/// <summary>
///     Extension methods for the FileResult class.
/// </summary>
public static class FileResultExtensions
{
    /// <summary>
    ///     Get the list view item that represents this file result.
    /// </summary>
    /// <param name="result">
    ///     The file result.
    /// </param>
    /// <param name="fileResultManager">
    ///     The file result manager.
    /// </param>
    /// <returns>
    ///     The ListViewItem.
    /// </returns>
    public static ListViewItem GetListViewItem(this FileResult result, IFileResultManager fileResultManager)
    {
        return new ListViewItem(
            new[]
            {
                result.InputFile.Name,
                result.Show == null ? result.ShowName : result.Show.Name,
                result.Episode == null
                    ? string.Empty
                    : result.Episode.SeasonNumber.ToString(CultureInfo.InvariantCulture),
                result.Episode == null
                    ? string.Empty
                    : result.Episode.EpisodeNumber.ToString(CultureInfo.InvariantCulture),
                result.Episode == null ? string.Empty : result.Episode.Name,
                fileResultManager.FormatOutputPath(result),
            }) { BackColor = result.Incomplete ? Color.Red : Color.White, Checked = result.Checked };
    }
}
