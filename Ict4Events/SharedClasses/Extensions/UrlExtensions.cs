using System;

namespace SharedClasses.Extensions
{
    public static class UrlExtensions
    {
        public static bool IsLocal(this Uri uri)
        {
            if (uri.OriginalString.StartsWith("http:\\", StringComparison.OrdinalIgnoreCase))
                return false;

            return uri.IsFile;
        }
    }
}