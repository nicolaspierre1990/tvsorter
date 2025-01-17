﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright company="TVSorter" file="TvShow.cs">
//   2012 - Andrew Jackson
// </copyright>
// <summary>
//   The tv show.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using TVSorter.Wrappers;

namespace TVSorter.Model;

/// <summary>
///     The tv show.
/// </summary>
public class TvShow : IEquatable<TvShow>
{
    /// <summary>
    ///     Gets or sets AlternateNames.
    /// </summary>
    public List<string> AlternateNames { get; set; }

    /// <summary>
    ///     Gets or sets Banner.
    /// </summary>
    public string Banner { get; set; }

    /// <summary>
    ///     Gets or sets CustomFormat.
    /// </summary>
    public string CustomFormat { get; set; }

    /// <summary>
    ///     Gets the episodes of the show.
    /// </summary>
    public List<Episode> Episodes { get; set; }

    /// <summary>
    ///     Gets or sets FolderName.
    /// </summary>
    public string FolderName { get; set; }

    /// <summary>
    ///     Gets or sets LastUpdated.
    /// </summary>
    public DateTime LastUpdated { get; set; }

    /// <summary>
    ///     Gets or sets a value indicating whether Locked.
    /// </summary>
    public bool Locked { get; set; }

    /// <summary>
    ///     Gets or sets Name.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    ///     Gets or sets the TVDB ID.
    /// </summary>
    public int TvdbId { get; set; }

    /// <summary>
    ///     Gets or sets a value indicating whether to Use Custom Format.
    /// </summary>
    public bool UseCustomFormat { get; set; }

    /// <summary>
    ///     Gets or sets a value indicating whether to use DVD Order.
    /// </summary>
    public bool UseDvdOrder { get; set; }

    /// <summary>
    ///     Gets or sets a value indicating whether to use a custom destination.
    /// </summary>
    public bool UseCustomDestination { get; set; }

    /// <summary>
    ///     Gets or sets the custom output destination directory to use.
    /// </summary>
    public string CustomDestinationDir { get; set; }

    /// <summary>
    ///     Indicates whether the current object is equal to another object of the same type.
    /// </summary>
    /// <returns>
    ///     true if the current object is equal to the <paramref name="other" /> parameter; otherwise, false.
    /// </returns>
    /// <param name="other">
    ///     An object to compare with this object.
    /// </param>
    public bool Equals(TvShow other)
    {
        if (other is null)
        {
            return false;
        }

        return ReferenceEquals(this, other) || Equals(other.TvdbId, TvdbId);
    }

    /// <summary>
    ///     Determines whether the specified <see cref="T:System.Object" /> is equal to the current
    ///     <see cref="T:System.Object" /> .
    /// </summary>
    /// <returns>
    ///     true if the specified <see cref="T:System.Object" /> is equal to the current <see cref="T:System.Object" /> ;
    ///     otherwise, false.
    /// </returns>
    /// <param name="obj">
    ///     The <see cref="T:System.Object" /> to compare with the current <see cref="T:System.Object" /> .
    /// </param>
    /// <filterpriority>2</filterpriority>
    public override bool Equals(object obj)
    {
        if (obj is null)
        {
            return false;
        }

        if (ReferenceEquals(this, obj))
        {
            return true;
        }

        if (obj is not TvShow)
        {
            return false;
        }

        return Equals((TvShow)obj);
    }

    /// <summary>
    ///     Serves as a hash function for a particular type.
    /// </summary>
    /// <returns>
    ///     A hash code for the current <see cref="T:System.Object" /> .
    /// </returns>
    /// <filterpriority>2</filterpriority>
    public override int GetHashCode() => TvdbId.GetHashCode();

    /// <summary>
    ///     Gets all the possible names of this show.
    /// </summary>
    /// <returns>The possible names of the show.</returns>
    internal IEnumerable<string> GetShowNames() => GetNames(new[] { Name, FolderName }.Concat(AlternateNames)).Distinct();

    /// <summary>
    ///     Gets the custom destination directory for the show.
    /// </summary>
    /// <returns>The IDirectoryInfo the show's custom directory.</returns>
    internal IDirectoryInfo GetCustomDestinationDirectory() =>
        // TODO: This needs to be able to return a substituted one for the tests
        new DirectoryInfoWrap(CustomDestinationDir);

    /// <summary>
    ///     Initialises the show with default values.
    /// </summary>
    internal void InitialiseDefaultData()
    {
        AlternateNames = [];
        Banner = string.Empty;
        CustomFormat = string.Empty;
        LastUpdated = DateTime.MinValue;
        Locked = false;
        UseCustomFormat = false;
        UseDvdOrder = false;
        UseCustomDestination = false;
        CustomDestinationDir = string.Empty;
    }

    /// <summary>
    ///     Gets the names from the specified collection of names.
    /// </summary>
    /// <param name="names">
    ///     The names to convert.
    /// </param>
    /// <returns>
    ///     The complete list of names including string processing.
    /// </returns>
    private static IEnumerable<string> GetNames(IEnumerable<string> names)
    {
        foreach (var name in names.Where(name => name != null))
        {
            yield return name;
            yield return name.GetFileSafeName();
            yield return name.RemoveSpacerChars();
            yield return name.RemoveSpecialChars();
            yield return name.AlphaNumericOnly();
        }
    }
}
