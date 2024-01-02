using System.Reflection;
using Ninject;

namespace TVSorter;

public static class CompositionRoot
{
    private static IKernel kernel;

    public static string Version => Assembly.GetExecutingAssembly().GetName().Version.ToString();

    public static T Get<T>() => kernel.Get<T>();

    public static void SetKernel(IKernel kernel) => CompositionRoot.kernel = kernel;
}
