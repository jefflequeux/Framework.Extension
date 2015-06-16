using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JFL.Framework.Extension
{
    /// <summary>
    /// Class ListSorter
    /// </summary>
    public class ListSorter
    {
        /// <summary>
        /// Enumeration SortDirection
        /// </summary>
        public enum SortDirection 
        { 
            Ascending, 
            Decending 
        }

        /// <summary>
        /// Sorts the name of the by property.
        /// </summary>
        /// <typeparam name="T">Given type</typeparam>
        /// <param name="list">The list.</param>
        /// <param name="propertyName">Name of the property.</param>
        /// <param name="direction">The direction.</param>
        /// <returns>List {``0}.</returns>
        public static List<T> SortByPropertyName<T>(List<T> list, string propertyName, SortDirection direction) where T : class
        {
            return 
                direction == SortDirection.Ascending
                ? list.OrderBy(customer => ReflectionHelper.GetPropertyValue(customer, propertyName)).ToList()
                : list.OrderByDescending(customer => ReflectionHelper.GetPropertyValue(customer, propertyName)).ToList();
        }

        /// <summary>
        /// Class ReflectionHelper
        /// </summary>
        public static class ReflectionHelper
        {
            /// <summary>
            /// Gets the property value.
            /// </summary>
            /// <param name="obj">The object.</param>
            /// <param name="propertyName">Name of the property.</param>
            /// <returns>System Object.</returns>
            public static object GetPropertyValue(object obj, string propertyName)
            {
                return obj == null
                    ? null
                    : obj.GetType().GetProperty(propertyName).GetValue(obj, null);
            }
        }
    }
}