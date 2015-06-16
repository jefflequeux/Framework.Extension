using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JFL.Framework.Extension
{
    /// <summary>
    /// Random Singleton
    /// </summary>
    public static class RandomManager
    {
        /// <summary>
        /// Random instance
        /// </summary>
        private static Random instance = null;

        /// <summary>
        /// Gets the instance.
        /// </summary>
        public static Random Instance
        {
            get
            {
                if (instance == null)
                    instance = new Random(DateTime.Now.Millisecond);
                return instance;
            }
        }
    }
}