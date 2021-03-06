using System.Collections.Generic;
using LightBDD.Core.Metadata;

namespace LightBDD.Core.Results
{
    /// <summary>
    /// Interface describing step test result.
    /// </summary>
    public interface IStepResult
    {
        /// <summary>
        /// Returns step details.
        /// </summary>
        IStepInfo Info { get; }
        /// <summary>
        /// Returns step execution status.
        /// </summary>
        ExecutionStatus Status { get; }
        /// <summary>
        /// Returns status details that contains reason for bypassed, ignored or failed steps.
        /// It may be null if no additional details are provided.
        /// </summary>
        string StatusDetails { get; }
        /// <summary>
        /// Returns step execution time.
        /// </summary>
        ExecutionTime ExecutionTime { get; }
        /// <summary>
        /// Returns step comments or empty collection if no comments were made.
        /// </summary>
        IEnumerable<string> Comments { get; }
    }
}