using System;

namespace Match3OOAP.Helpers
{
    public static class AssertionUtils
    {
        public static void AssertNotNull<T>(this T value) where T : class
        {
            if (value == null)
            {
                throw new ArgumentNullException(nameof(value)); 
            }
        }
            
    }
}