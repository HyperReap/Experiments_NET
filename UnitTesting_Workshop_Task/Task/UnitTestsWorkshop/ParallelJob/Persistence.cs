using System;
using System.Threading;

namespace UnitTestsWorkshop.ParallelJob
{
    /// <summary>
    /// Consumer of the FileWatch service
    /// </summary>
    internal class Persistence
    {
        private readonly IDataFileWatcher fileWatcher;

        public event EventHandler Reloaded;

        public Persistence(IDataFileWatcher fileWatcher)
        {
            this.fileWatcher = fileWatcher;
            this.fileWatcher.FileChanged += FileWatcher_FileChanged;
        }

        private void FileWatcher_FileChanged(object sender, EventArgs e)
        {
            // Here we simulate some reloading logic ...
            Thread.Sleep(1000);

            if (Reloaded != null)
                Reloaded(this, EventArgs.Empty); 
        }
    }
}
