using System;

namespace UnitTestsWorkshop.ParallelJob
{
    /// <summary>
    /// Service representation, which observes file changes 
    /// and reports them using file changed event.
    /// </summary>
    public interface IDataFileWatcher
    {
        event EventHandler FileChanged;
    }
}