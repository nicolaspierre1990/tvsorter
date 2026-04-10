using System;
using Splat;

namespace TVSorter.Ui.Extensions;

/// <summary>
/// Provides extension methods for <see cref="IReadonlyDependencyResolver"/>.
/// </summary>
public static class IReadonlyDependencyResolverExtensions
{
    /// <summary>
    /// Resolves a required service of the specified type from the dependency resolver.
    /// </summary>
    /// <typeparam name="T">The type of the service to resolve.</typeparam>
    /// <param name="resolver">The dependency resolver to retrieve the service from.</param>
    /// <returns>The resolved service instance of type <typeparamref name="T"/>.</returns>
    /// <exception cref="InvalidOperationException">
    /// Thrown when no service of type <typeparamref name="T"/> is registered in the resolver.
    /// </exception>
    public static T GetRequiredService<T>(this IReadonlyDependencyResolver resolver)
        => resolver.GetService<T>() ?? throw new InvalidOperationException($"Service of type {typeof(T)} is not registered.");
}