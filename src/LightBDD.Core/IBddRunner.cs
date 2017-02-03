﻿namespace LightBDD
{
    //TODO: move all root types to LightBDD.Framework (create interfaces in core if needed). Move IBddRunner<T> to core directories. Update namespace.
    /// <summary>
    /// The base runner interface describing runner that can execute scenarios within specified context.
    /// See also: <seealso cref="IBddRunner"/>.
    /// </summary>
    /// <typeparam name="TContext">The context type that would be used in scenario execution.</typeparam>
    public interface IBddRunner<TContext> { }

    /// <summary>
    /// Class used to indicate that IBddRunner will execute scenarios without any additional context.
    /// </summary>
    public sealed class NoContext { }

    /// <summary>
    /// Main LightBDD runner interface that should be used in all LightBDD tests.
    /// The interface describes the runner with no context - please browse "LightBDD.Runners.*" packages for contextual runners.
    /// <param>The runner instance can be obtained by installing package from "LightBDD.Integration.*" group and deriving test class from <c>FeatureFixture</c> class offered by integration package.</param>
    /// <param>When additional packages from "LightBDD.Scenarios.*" group are installed, a set of extension methods will be available to execute tests with this runner.</param>
    /// <param>When additional packages from "LightBDD.Runners.*" group are installed, a set of extension methods will be available for further customization of the runner.</param>
    /// </summary>
    public interface IBddRunner : IBddRunner<NoContext> { }
}
