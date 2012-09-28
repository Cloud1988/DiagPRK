using Spring.Context;
using Spring.Context.Support;

namespace DiagPRK.Spring
{
    public static class SpringContext
    {
        #region Copied from SpringControllerfactory

        private static IApplicationContext _context;

        /// <summary>
        /// Gets the application context.
        /// </summary>
        /// <value>The application context.</value>
        private static IApplicationContext ApplicationContext
        {
            get
            {
                if (_context == null || _context.Name != _applicationContextName)
                {
                    if (string.IsNullOrEmpty(_applicationContextName))
                    {
                        _context = ContextRegistry.GetContext();
                    }
                    else
                    {
                        _context = ContextRegistry.GetContext(_applicationContextName);
                    }
                }

                return _context;
            }
        }

        /// <summary>
        /// Gets or sets the name of the application context.
        /// </summary>
        /// <remarks>
        /// Defaults to using the root (default) Application Context.
        /// </remarks>
        /// <value>The name of the application context.</value>
        private static string _applicationContextName;

        #endregion

        public static object GetObject(string name)
        {
            return ApplicationContext.GetObject(name);
        }

        public static T GetObject<T>(string name)
        {
            return (T)ApplicationContext.GetObject(name);
        }

        public static T GetObject<T>()
        {
            return (T)ApplicationContext.GetObject(typeof(T).Name);
        }
    }
}