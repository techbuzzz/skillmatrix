using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Web;

namespace SkillMatrix.Common
{
    public static partial class Utilities
    {
        public static string ConcatenateIdentifiers(List<int> identifiers)
        {
            StringBuilder idsString = new StringBuilder();
            foreach (int id in identifiers)
            {
                idsString.AppendFormat(".{0}", id);
            }
            idsString.Append(".");
            return idsString.ToString();
        }

        public static List<int> SplitIdentifiers(string idsString)
        {
            List<int> result = new List<int>();
            if(!String.IsNullOrEmpty(idsString))
            {
                string[] ids = idsString.Split(new [] {'.'}, StringSplitOptions.RemoveEmptyEntries);
                foreach (string id in ids)
                {
                    result.Add(Int32.Parse(id));
                }
            }
            return result;
        }

        public static string ConcatenateIdentifiers(List<string> identifiers)
        {
            StringBuilder idsString = new StringBuilder();
            foreach (string id in identifiers)
            {
                idsString.AppendFormat(".{0}", id);
            }
            idsString.Append(".");
            return idsString.ToString();
        }
        

        public static string ConcatenateIdentifiers(List<int?> identifiers)
        {
            StringBuilder idsString = new StringBuilder();
            foreach (int? id in identifiers)
            {
                if (id.HasValue)
                {
                    idsString.AppendFormat(".{0}", id);
                }
            }
            idsString.Append(".");
            return idsString.ToString();
        }
       

        //public static Uri CombineUri(string baseUriString, params string[] relativeUriStrings)
        //{
        //    var relativeUri = new Uri(baseUriString);
        //    if(relativeUriStrings.Length == 0) return relativeUri;
        //    relativeUriStrings.Take(relativeUriStrings.Length-1).ForEach(uriString => relativeUri = new Uri(relativeUri, uriString.EndsWith("/") ? uriString : uriString + "/"));
        //    relativeUri = new Uri(relativeUri, relativeUriStrings.Last());
        //    return relativeUri;
        //}

        public static bool IsTrue(this byte b)
        {
            return b == 1;
        }

        public static bool IsTrue(this byte? b)
        {
            return b == 1;
        }

        public static byte AsByte(this bool b)
        {
            return (byte) (b ? 1 : 0);
        }

        public static P Map<T,P>(T value, params Tuple<T, P>[] map)
        {
            return map.Where(choice => Equals(choice.Item1, value)).Select(choice => choice.Item2).FirstOrDefault();
        }

        public static P Map<T, P>(T value, P defaultValue, params Tuple<T, P>[] map)
        {
            return map.Where(choice => Equals(choice.Item1, value)).Select(choice => choice.Item2).Take(1).Concat(new[] {defaultValue}).First();
        }

        public static P MapIgnoreCase<P>(string value, params Tuple<string, P>[] map)
        {
            return map.Where(choice => string.Equals(choice.Item1, value, StringComparison.InvariantCultureIgnoreCase)).Select(choice => choice.Item2).FirstOrDefault();
        }

        public static P MapIgnoreCase<P>(string value, P defaultValue, params Tuple<string, P>[] map)
        {
            return map.Where(choice => string.Equals(choice.Item1, value, StringComparison.InvariantCultureIgnoreCase))
                .Select(choice => choice.Item2).Take(1).Concat(new[] { defaultValue }).First();
        }

        public static IEnumerable<object> DynamicOfType<T>(
        this IQueryable<T> input, Type type)
        {
            var ofType = typeof(Queryable).GetMethod("OfType",
                             BindingFlags.Static | BindingFlags.Public);
            var ofTypeT = ofType.MakeGenericMethod(type);
            return (IEnumerable<object>)ofTypeT.Invoke(null, new object[] { input });
        }

     
        /// <summary>
        /// Replaces a parameter within an URL.
        /// If <c>null</c> is supplied as new value, the parameter gets removed.
        /// </summary>
        /// <param name="url">The URL.</param>
        /// <param name="param">The parameter.</param>
        /// <param name="value">The value of the parameter.</param>
        /// <returns>The new URL.</returns>
        public static string SetParameter(this string url, string param, string value)
        {
            int questionMarkIndex = url.IndexOf('?');
            NameValueCollection parameters;
            var result = new StringBuilder();

            if (questionMarkIndex == -1)
            {
                parameters = new NameValueCollection();
                result.Append(url);
            }
            else
            {
                parameters = HttpUtility.ParseQueryString(url.Substring(questionMarkIndex));
                result.Append(url.Substring(0, questionMarkIndex));
            }

            if (string.IsNullOrEmpty(value))
            {
                parameters.Remove(param);
            }
            else
            {
                parameters[param] = value;
            }

            if (parameters.Count > 0)
            {
                result.Append('?');

                foreach (string parameterName in parameters)
                {
                    result.AppendFormat("{0}={1}&", parameterName, parameters[parameterName]);
                }

                result.Remove(result.Length - 1, 1);
            }

            return result.ToString();
        }

        /// <summary>
        /// Get the current users IP address
        /// </summary>
        /// <returns></returns>
        public static string GetUsersIpAddress()
        {
            var context = HttpContext.Current;
            var serverName = context.Request.ServerVariables["SERVER_NAME"];
            if (serverName.ToLower().Contains("localhost"))
            {
                return serverName;
            }
            var ipList = context.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
            return !string.IsNullOrEmpty(ipList) ? ipList.Split(',')[0] : context.Request.ServerVariables["REMOTE_ADDR"];
        }
    }
}
