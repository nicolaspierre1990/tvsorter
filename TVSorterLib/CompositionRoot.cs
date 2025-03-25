using System.Reflection;
using Ninject;

namespace TVSorter;

/// <summary>
/// Provides a centralized access point to the dependency injection container
/// and other application-wide resources.
/// </summary>
public static class CompositionRoot
{
    private static IKernel kernel;

    /// <summary>
    /// Gets the current version of the assembly.
    /// </summary>
    /// <value>A string representing the version number of the executing assembly.</value>
    public static string Version => Assembly.GetExecutingAssembly().GetName().Version.ToString();

    /// <summary>
    /// Resolves an instance of the specified type from the dependency injection container.
    /// </summary>
    /// <typeparam name="T">The type to resolve.</typeparam>
    /// <returns>An instance of the specified type.</returns>
    /// <exception cref="System.InvalidOperationException">Thrown when the kernel has not been set.</exception>
    public static T Get<T>() => kernel.Get<T>();

    /// <summary>
    /// Sets the dependency injection kernel to be used for resolving dependencies.
    /// </summary>
    /// <param name="kernel">The Ninject kernel instance to use.</param>
    public static void SetKernel(IKernel kernel) => CompositionRoot.kernel = kernel;
}
