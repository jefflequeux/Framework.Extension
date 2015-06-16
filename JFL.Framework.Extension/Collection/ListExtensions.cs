using System;
using System.Collections.Generic;

namespace JFL.Framework.Extension
{
    /// <summary>
    /// Extension methods for <see cref="System.Collections.Generic.List{T}"/>
    /// </summary>
    public static class ListExtensions
    {

        /// <summary>
        /// Sorts the name of the by property.
        /// </summary>
        /// <typeparam name="T">Given type</typeparam>
        /// <param name="list">The list.</param>
        /// <param name="propertyName">Name of the property.</param>
        /// <param name="direction">The direction.</param>
        /// <returns>List {``0}.</returns>
        public static List<T> SortByPropertyName<T>(this List<T> list, string propertyName, ListSorter.SortDirection direction) where T : class
        {
            return ListSorter.SortByPropertyName(list, propertyName, direction);
        }

        /// <summary>
        /// Moves the item matching the <paramref name="itemSelector"/> to the end of the <paramref name="list"/>.
        /// </summary>
        public static void MoveToEnd<T>(this List<T> list, Predicate<T> itemSelector)
        {
            Ensure.Argument.NotNull(list, "list");
            if (list.Count > 1)
                list.Move(itemSelector, list.Count - 1);
        }

        /// <summary>
        /// Moves the item matching the <paramref name="itemSelector"/> to the beginning of the <paramref name="list"/>.
        /// </summary>
        public static void MoveToBeginning<T>(this List<T> list, Predicate<T> itemSelector)
        {
            Ensure.Argument.NotNull(list, "list");
            list.Move(itemSelector, 0);
        }
        
        /// <summary>
        /// Moves the item matching the <paramref name="itemSelector"/> to the <paramref name="newIndex"/> in the <paramref name="list"/>.
        /// </summary>
        public static void Move<T>(this List<T> list, Predicate<T> itemSelector, int newIndex)
        {
            Ensure.Argument.NotNull(list, "list");
            Ensure.Argument.NotNull(itemSelector, "itemSelector");
            Ensure.Argument.Is(newIndex >= 0, "New index must be greater than or equal to zero.");
            
            var currentIndex = list.FindIndex(itemSelector);
            Ensure.That<ArgumentException>(currentIndex >= 0, "No item was found that matches the specified selector.");

            if (currentIndex == newIndex)
                return;

            // Copy the item
            var item = list[currentIndex];

            // Remove the item from the list
            list.RemoveAt(currentIndex);

            // Finally insert the item at the new index
            list.Insert(newIndex, item);
        }
    }
}
