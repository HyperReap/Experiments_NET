using System;
using System.ComponentModel;
using System.IO;

namespace UnitTestsWorkshop.ParallelJob
{
    /// <summary>
    /// Detects data file changes done 
    /// by another application or this application instance and reports them.
    /// Raises events in GUI thread, so no Invoke is required.
    /// </summary>
    internal class DataFileWatcher : IDataFileWatcher
    {
        public event EventHandler FileChanged;
        private readonly FileSystemWatcher fileWatcher;

        private readonly string fullFileName;

        internal DataFileWatcher(string fullFileName)
        {
            this.fullFileName = fullFileName;
            this.fileWatcher = new FileSystemWatcher();
            this.fileWatcher.Path = Path.GetDirectoryName(fullFileName);
            this.fileWatcher.Filter = Path.GetFileName(fullFileName);
            this.fileWatcher.NotifyFilter = NotifyFilters.LastWrite | NotifyFilters.FileName |
                                       NotifyFilters.CreationTime | NotifyFilters.Size;
            this.fileWatcher.Changed += new FileSystemEventHandler(ConfigFileChanged);
        }

        /// <summary>
        /// Because file watcher is created before the main form,
        /// the synchronization object has to be assigned later.
        /// This lets to fire the file system watcher events in GUI thread. 
        /// </summary>
        public void AssignSynchronizer(ISynchronizeInvoke synchronizer)
        {
            this.fileWatcher.SynchronizingObject = synchronizer;
        }

        private void ConfigFileChanged(object sender, FileSystemEventArgs e)
        {
            if (FileChanged != null && fileWatcher.SynchronizingObject != null)
                FileChanged(this.fullFileName, new EventArgs());
        }
    }
}
