using System;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using UnitTestsWorkshop.ParallelJob;

namespace Tests.ParallelJob
{
    [TestClass]
    public class ParallelJobTest
    {
        private readonly ManualResetEvent releaseWatch = new ManualResetEvent(false);
        private readonly Mock<IDataFileWatcher> stubFileWatch = new Mock<IDataFileWatcher>();

        /// <summary>
        /// do the next steps ot be able serialize otherwise paraller work
        /// of persistence refresh and dont relay on OS file changes
        /// </summary>
        [TestMethod]
        public void PersistenceFiresReloadEvent()
        {
            var persistence = new Persistence(this.stubFileWatch.Object);
            bool eventReceived = false;
            persistence.Reloaded += (sender, args) => { eventReceived = true; };

            //1. kick off the file changed event in background thread to let the persistence reload in parallel
            // thread is to simulate the event comming from unexpected thread in unexpected moment
            ThreadPool.QueueUserWorkItem(state => FireFileChanged());

            //2. wait till persistence is done with reload (extend the max time when debugging)
            // let the test thread wait here
            this.releaseWatch.WaitOne(10_000);

            //3. assert the results in secondary persistence
            Assert.IsTrue(eventReceived, "Persistence didnt notice file changes");
        }

        private void FireFileChanged()
        {
            this.stubFileWatch.Raise(fileWatch => fileWatch.FileChanged += null, EventArgs.Empty);
            // synchronize with the persistence to wait till the changes are done
            // release the test thread here
            this.releaseWatch.Set();
        }
    }
}
