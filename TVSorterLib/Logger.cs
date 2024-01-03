// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Logger.cs" company="TVSorter">
//   2012 - Andrew Jackson
// </copyright>
// <summary>
//   Handles log messages from the library.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Concurrent;

namespace TVSorter;

/// <summary>
///     Handles log messages from the library.
/// </summary>
public static class Logger
{
    private static readonly ConcurrentQueue<(object sender, LogMessageEventArgs eventArgs)> _localCache = new();

    /// <summary>
    ///     Occurs when there is a log message.
    /// </summary>
    public static event EventHandler<LogMessageEventArgs> LogMessage;

    /// <summary>
    ///     Fires a log message.
    /// </summary>
    /// <param name="sender">
    ///     The sender of the message.
    /// </param>
    /// <param name="message">
    ///     The message.
    /// </param>
    /// <param name="type">
    ///     The type of the message.
    /// </param>
    /// <param name="args">
    ///     The string format args.
    /// </param>
    internal static void OnLogMessage(object sender, string message, LogType type, params object[] args)
    {
        message = string.Format(message, args);
        var eventArgs = new LogMessageEventArgs(message, DateTime.Now, type);

        if (LogMessage == null)
        {
            _localCache.Enqueue((sender, eventArgs));
        }
        else
        {
            if (!_localCache.IsEmpty)
            {
                while(_localCache.TryDequeue(out (object sender, LogMessageEventArgs eventArgs) cachedMessage))
                {
                    LogMessage?.Invoke(cachedMessage.sender, cachedMessage.eventArgs);
                }
            }

            LogMessage?.Invoke(sender, eventArgs);
        }
    }

    /// <summary>
    /// Reads the cached messages.
    /// </summary>
    public static void ReadCachedMessages()
    {
        if (!_localCache.IsEmpty)
        {
            while (_localCache.TryDequeue(out (object sender, LogMessageEventArgs eventArgs) cachedMessage))
            {
                LogMessage?.Invoke(cachedMessage.sender, cachedMessage.eventArgs);
            }
        }
    }
}
