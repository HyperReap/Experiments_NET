using System;

namespace UnitTestsWorkshop.DateTimeNow
{
    /// <summary>
    /// Uniform access to the current DateTime in Universal format.
    /// Allows to define custom time moments by unit tests.
    /// </summary>
    internal static class Moment
    {
        /// <summary>
        /// Gets current time in UTC provided by Service.
        /// </summary>
        internal static DateTime UtcNow 
        {
            get
            {
                return service.UtcNow;
            }
        }

        // provide default service.
        private static IDateService service = new NowService();

        internal static void AssignService(IDateService newService)
        {
            if (newService == null)
                throw new ArgumentException("newService");
          
            service = newService;
        }

        internal static void ResetService()
        {
            service = new NowService();
        }

        /// <summary>
        /// Because of dependency injection we have to provide default service
        /// </summary>
        private class NowService : IDateService
        {
            public DateTime UtcNow
            {
                get { return DateTime.UtcNow; }
            }
        }
    }
}