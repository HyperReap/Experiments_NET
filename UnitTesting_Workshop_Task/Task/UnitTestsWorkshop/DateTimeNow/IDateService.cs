using System;

namespace UnitTestsWorkshop.DateTimeNow
{
    /// <summary>
    /// Custom provide of current time. Uniform resolution of DateTime in UTC
    /// </summary>
    public interface IDateService
    {
        /// <summary>
        /// Gets current time in UTC
        /// </summary>
        DateTime UtcNow { get; }
    }
}