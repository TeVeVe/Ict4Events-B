using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace SharedClasses.Extensions
{
    public static class LINQExtensions
    {
        public static IEnumerable<TSource> Map<TSource>(this IEnumerable<TSource> source,
            Func<TSource, IEnumerable<TSource>> getChildrenFunction, Func<TSource, bool> selectorFunction)
        {
            // Add what we have to the stack
            IEnumerable<TSource> flattenedList = source.Where(selectorFunction);

            // Go through the input enumerable looking for children,
            // and add those if we have them
            return source.Aggregate(flattenedList,
                (current, element) =>
                    current.Concat(getChildrenFunction(element).Map(getChildrenFunction, selectorFunction)));
        }

        public static IEnumerable<TSource> Map<TSource>(this IEnumerable<TSource> source,
            Func<TSource, IEnumerable<TSource>> getChildrenFunction)
        {
            // Add what we have to the stack
            IEnumerable<TSource> flattenedList = source;

            // Go through the input enumerable looking for children,
            // and add those if we have them
            return source.Aggregate(flattenedList,
                (current, element) =>
                    current.Concat(getChildrenFunction(element).Map(getChildrenFunction)));
        }

        /// <summary>
        ///     Flattens a IEnumerable with the help of the getChildrenFunction parameter.
        /// </summary>
        /// <typeparam name="TSource">Desired item type of the returned IEnumerable.</typeparam>
        /// <param name="source">Source IEnumerable containing all the elements.</param>
        /// <param name="getChildrenFunction">Function that will return the children of an element.</param>
        /// <param name="selectorFunction">Function that will filter elements from the list.</param>
        /// <returns>A filtered collection with all the parents and children.</returns>
        public static IEnumerable<TSource> Map<TSource>(
            this IEnumerable source,
            Func<TSource, IEnumerable> getChildrenFunction,
            Func<TSource, bool> selectorFunction)
        {
            // Cast this list to desired type.
            IEnumerable<TSource> desiredType = source.Cast<TSource>();

            // Add what we have to the stack
            IEnumerable<TSource> flattenedList = desiredType.Where(selectorFunction);

            // Go through the input enumerable looking for children,
            // and add those if we have them
            return desiredType.Aggregate(flattenedList,
                (current, element) =>
                    current.Concat(getChildrenFunction(element).Map(getChildrenFunction, selectorFunction)));
        }

        /// <summary>
        ///     Flattens a IEnumerable with the help of the getChildrenFunction parameter.
        /// </summary>
        /// <typeparam name="TSource">Desired item type of the returned IEnumerable.</typeparam>
        /// <param name="source">Source IEnumerable containing all the elements.</param>
        /// <param name="getChildrenFunction">Function that will return the children of an element.</param>
        /// <returns>A collection with all the parents and children.</returns>
        public static IEnumerable<TSource> Map<TSource>(
            this IEnumerable source,
            Func<TSource, IEnumerable> getChildrenFunction)
        {
            // Cast this list to desired type.
            IEnumerable<TSource> desiredType = source.Cast<TSource>();

            // Add what we have to the stack
            IEnumerable<TSource> flattenedList = desiredType;

            // Go through the input enumerable looking for children,
            // and add those if we have them
            return desiredType.Aggregate(flattenedList,
                (current, element) =>
                    current.Concat(getChildrenFunction(element).Map(getChildrenFunction)));
        }
    }
}