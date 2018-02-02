using System.Collections.Generic;
using System.Linq;

namespace SkillMatrix.Common.Extensions
{
    public static class StringExtensions
    {
        /// <summary>
        ///     Removes dashes ("-") from the given object value represented as a string and returns an empty string ("")
        ///     when the instance type could not be represented as a string.
        ///     <para>
        ///         Note: This will return the type name of given isntance if the runtime type of the given isntance is not a
        ///         string!
        ///     </para>
        /// </summary>
        /// <param name="value">The object instance to undash when represented as its string value.</param>
        /// <returns></returns>
        public static string UnDash(this object value)
        {
            return (value as string ?? string.Empty).UnDash();
        }

        /// <summary>
        ///     Removes dashes ("-") from the given string value.
        /// </summary>
        /// <param name="value">The string value that optionally contains dashes.</param>
        /// <returns></returns>
        public static string UnDash(this string value)
        {
            return (value ?? string.Empty).Replace("-", string.Empty);
        }

        public static decimal ToDicimal(this string value)
        {
            decimal result;
            return !string.IsNullOrEmpty(value) && decimal.TryParse(value, out result) ? result : 0;
        }

        /// <summary>
        ///     Returns a <see cref="string" /> containing all values separated by the given <see cref="string" />.
        /// </summary>
        /// <typeparam name="T">The type.</typeparam>
        /// <param name="values">The values.</param>
        /// <param name="separator">The separator.</param>
        /// <returns>
        ///     A <see cref="System.String" /> containing all values separated by the given <see cref="string" />.
        /// </returns>
        public static string ToString<T>(this IEnumerable<T> values, string separator)
        {
            if (values == null) return string.Empty;

            var valueArray = values.ToArray();

            return string.Join(separator, values.Select(v => v.ToString()).ToArray());
        }


        /// <summary>
        ///     Shortens the given <see cref="string" />.
        /// </summary>
        /// <param name="value">The <see cref="string" /> to shorten.</param>
        /// <param name="maxlength">The maximum length of the <see cref="string" />.</param>
        /// <returns>The shortened <see cref="string" />.</returns>
        public static string Trim(this string value, int maxlength)
        {
            if (string.IsNullOrEmpty(value) || maxlength > value.Length) return value;

            return value.Substring(0, maxlength - 4) + " ...";
        }
    }
}