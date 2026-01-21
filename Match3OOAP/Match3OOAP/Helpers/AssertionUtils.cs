using System;
using System.Collections.Generic;

namespace Match3OOAP.Helpers
{
    public static class AssertionUtils
    {
        public static void AssertNotNull<T>(this T value) where T : class
        {
            if (value == null)
            {
                throw new ArgumentNullException(typeof(T).Name); 
            }
        }
        
        public static void AssertItemsNotNull<T>(this IEnumerable<T> values) where T : class
        {
            foreach (T value in values)
            {
                AssertNotNull(value);
            }
        }
    }
}