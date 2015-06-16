using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JFL.Framework.Extension
{
    /// <summary>
    /// Extensions for <see cref="System.Boolean"/>
    /// </summary>
    public static class BoolExtension
    {
        /// <summary>
        /// Toogle bool
        /// </summary>
        /// <param name="source">The boolean</param>
        /// <returns>The inverted boolean</returns>
        /// <example>
        /// bool variavel = true;
        /// variavel = variavel.toggle(); // false
        /// </example>
        public static bool toggle(this bool source)
        {
            return !source;
        }

        /// <summary>
        /// return true is bool is true, false otherwise
        /// </summary>
        /// <param name="source">The boolean</param>
        /// <returns>true is bool is true, false otherwise</returns>
        /// <example>
        /// if ((input == 42).IsTrue())
        /// {
        /// // handle the case when input is 42
        /// }
        /// </example>
        public static bool IsTrue(this bool value)
        {
            return value;
        }

        /// <summary>
        /// return true is bool is false, false otherwise
        /// </summary>
        /// <param name="source">The boolean</param>
        /// <returns>true is bool is false, false otherwise</returns>
        /// <example>
        /// if ((input == 42).IsFalse())
        /// {
        /// // handle the case when input is different than 42
        /// }
        /// </example>
        public static bool IsFalse(this bool value)
        {
            return !value;
        }
    }
}
