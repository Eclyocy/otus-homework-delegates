using System.Collections;

namespace Delegates.Extensions
{
    /// <summary>
    /// Extensions for <see cref="IEnumerable"/> collections.
    /// </summary>
    public static class CollectionExtensions
    {
        /// <summary>
        /// Returns the maximum element of the <paramref name="collection"/>.
        /// Uses <paramref name="convertToNumber"/> delegate to convert collection elements to numbers.
        /// </summary>
        /// <returns>
        /// The maximum element of the collection, or null for an empty collection.
        /// </returns>
        /// <typeparam name="T">Type of collection elements.</typeparam>
        /// <exception cref="ArgumentNullException">Thrown in case the collection is null.</exception>
        public static T? GetMax<T>(
            this IEnumerable<T> collection,
            Func<T, float> convertToNumber)
            where T : class
        {
            ArgumentNullException.ThrowIfNull(collection);

            if (!collection.Any())
            {
                return null;
            }

            T? maxItem = null;

            float maxItemNumber = float.MinValue;
            foreach (T item in collection)
            {
                float itemNumber = convertToNumber(item);

                if (itemNumber > maxItemNumber)
                {
                    maxItemNumber = itemNumber;
                    maxItem = item;
                }
            }

            return maxItem;
        }
    }
}
