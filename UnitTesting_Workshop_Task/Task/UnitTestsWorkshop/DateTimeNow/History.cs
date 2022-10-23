using System;
using System.Collections.Generic;
using System.Threading;

namespace UnitTestsWorkshop.DateTimeNow
{
    internal class History
    {
        // only to simulate some unexpected delay
        private readonly Random randomDelay = new Random(); 

        private DateTime lastInsert = DateTime.UtcNow;

        private readonly Dictionary<DateTime, string> posts = new Dictionary<DateTime, string>();

        /// <summary>
        /// Gets number of currently posted messages.
        /// </summary>
        internal int PostsCount
        {
            get { return this.posts.Count; }
        }

        /// <summary>
        /// Stores message into the history. Remembers the moment the item was posted on.
        /// This method is not thread safe. Message is remembered only,
        /// if distance from previous post is atleast 2 seconds.
        /// </summary>
        internal void Post(string message)
        {
            WaitForRandomDelay();
            var current = DateTime.UtcNow;
            if (!LastInsertIsOlderThan2Seconds(current)) 
                return;
            
            this.lastInsert = current;
            RememberMessage(message, current);
        }

        /// <summary>
        /// Simulates resource delay, e.g. connection latency to service etc.
        /// Used only to simulate the problem
        /// </summary>
        private void WaitForRandomDelay()
        {
            int milisecondsDelay = this.randomDelay.Next(4000);
            Thread.Sleep(milisecondsDelay);
        }

        private void RememberMessage(string message, DateTime current)
        {
            this.posts.Add(current, message);
        }

        private bool LastInsertIsOlderThan2Seconds(DateTime current)
        {
            return current.AddSeconds(-2) >= this.lastInsert;
        }

        public override string ToString()
        {
            return string.Format("History:lastInsert={0},PostsCount={1}", this.lastInsert, this.PostsCount);
        }
    }
}
