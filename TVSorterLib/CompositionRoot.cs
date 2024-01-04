using System.Reflection;
using Ninject;

namespace TVSorter;

public static class CompositionRoot
{
    private static IKernel kernel;

    /// <summary>
    /// Gets the version.
    /// </summary>
    public static string Version => Assembly.GetExecutingAssembly().GetName().Version.ToString();

    /// <summary>
    /// Gets this instance.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static T Get<T>() => kernel.Get<T>();

    /// <summary>
    /// Sets the kernel.
    /// </summary>
    /// <param name="kernel">The kernel.</param>
    public static void SetKernel(IKernel kernel) => CompositionRoot.kernel = kernel;
}
