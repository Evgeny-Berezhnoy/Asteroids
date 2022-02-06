using System;
using System.Collections.Generic;

namespace ExtensionCompilation
{
    public static class Collections
    {
        #region Static methods

        public static T Random<T>(this IList<T> collection)
        {
            var random = new Random();

            return collection[random.Next(collection.Count)];
        }

        #endregion
    }
}