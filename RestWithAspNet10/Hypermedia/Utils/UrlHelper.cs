using Microsoft.AspNetCore.Mvc;

namespace RestWithAspNet10.Hypermedia.Utils
{
    public static class UrlHelper
    {
        // Lock object to ensure thread safety
        private static readonly object _lock = new();

        public static string BuildBaseUrl(this IUrlHelper urlHelper, string routeName, string path)
        {
            lock (_lock)
            {
                // Generate the URL using the provided route name and path
                var url = urlHelper.Link(routeName, new { controller = path }) ?? string.Empty;
                return url.Replace("%2F", "/").TrimEnd('/');
            }
        }
    }
}