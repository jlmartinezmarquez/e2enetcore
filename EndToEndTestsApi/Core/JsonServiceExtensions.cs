using System.Linq;
using System.Net;

namespace Core
{
    public static class JsonServiceExtensions
    {
        public static string SafeToString(this object s)
        {
            if (s == null)

                return string.Empty;

            return s.ToString();
        }

        public static string ToQueryString(this object instance, bool includeQueryStringOperator = true)
        {
            if (instance == null)
                return string.Empty;

            var properties = instance.GetType().GetProperties()
                .OrderBy(x => x.Name)
                .Where(p => p.GetValue(instance, null) != null)
                .Select(p => p.Name + "=" + WebUtility.UrlEncode(p.GetValue(instance, null).ToString()));

            var @join = string.Join("&", properties.ToArray());

            if (!includeQueryStringOperator)
                return @join;

            return "?" + @join;
        }
    }
}
