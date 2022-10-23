using System;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using UnitTestsWorkshop.DateTimeNow;

namespace Tests.DateTimeNow
{
    [TestClass]
    public class DateTimeNowTests
    {
        private const int HISTORY_EXCEEDS_DELAY_SECONDS = 3;
        private readonly Mock<IDateService> dateMock = new Mock<IDateService>();
        private DateTime current = DateTime.UtcNow;
        private History history;
        
        [TestInitialize]
        public void TestSetUp()
        {
            // creating history before moq setup, sets initial time value to System.DateTime value
            this.history = new History();
            // move time for initial post - to simulate the time is still running
            this.current = DateTime.UtcNow.AddSeconds(HISTORY_EXCEEDS_DELAY_SECONDS); 
        }

        [TestCleanup()]
        public void TearDown()
        {
            // TearDown should set the service back to dont affect other tests.
        }

        // TODO time to time this test fails : Fix it
        [TestMethod]
        public void PostTwoMessagesImediately_RemembersOnlyOne()
        {
            this.history.Post(string.Empty); // message is not relevant in this example
            this.history.Post(string.Empty);
            int postedCount = this.history.PostsCount;
            Assert.AreEqual(1, postedCount, "Posting second message immediately after first one has to remember only one");
        }

        // TODO time to time this test fails : Fix it
        [TestMethod]
        public void InsertTwoItemsAfterTwoSeconds_InsertsBoth()
        {
            this.history.Post(string.Empty); // message is not relevant in this example.
            Thread.Sleep(1100 * HISTORY_EXCEEDS_DELAY_SECONDS);
            this.history.Post(string.Empty);
            int postedCount = this.history.PostsCount;
            Assert.AreEqual(2, postedCount, "Posting second message after more than two seconds has to remember both messages");
        }
    }
}
