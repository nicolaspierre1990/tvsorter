﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright company="TVSorter" file="LogMessageEventArgs.cs">
//   2012 - Andrew Jackson
// </copyright>
// <summary>
//   The log message event args.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;

namespace TVSorter;

/// <summary>
///     The log message event args.
/// </summary>
/// <remarks>
///     Initialises a new instance of the <see cref="LogMessageEventArgs" /> class. Initialises a new instance of the
///     <see cref="LogMessageEventArgs" /> class.
/// </remarks>
/// <param name="message">
///     The message.
/// </param>
/// <param name="time">
///     The time.
/// </param>
/// <param name="type"> The type of the log message.</param>
public class LogMessageEventArgs(string message, DateTime time, LogType type) : EventArgs
{

    /// <summary>
    ///     Gets the log message of the event.
    /// </summary>
    public string LogMessage { get; } = message;

    /// <summary>
    ///     Gets the time the event was raised.
    /// </summary>
    public DateTime LogTime { get; } = time;

    /// <summary>
    ///     Gets the type of the log message.
    /// </summary>
    public LogType Type { get; } = type;

    /// <summary>
    ///     Returns a <see cref="T:System.String" /> that represents the current <see cref="T:System.Object" /> .
    /// </summary>
    /// <returns>
    ///     A <see cref="T:System.String" /> that represents the current <see cref="T:System.Object" /> .
    /// </returns>
    /// <filterpriority>2</filterpriority>
    public override string ToString()
    {
        return string.Format("{0:HH:mm:ss}: {1}", LogTime, LogMessage);
    }
}
