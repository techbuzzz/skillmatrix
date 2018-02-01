using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace SkillMatrix.Common
{
    public static partial class Utilities
    {

        public static string GetDisplayName(this Enum value)
        {
            var outString = string.Empty;
            if (value != null)
            {

                try
                {

                
                outString = value.ToString();
                Type enumType = value.GetType();
                var enumValue = Enum.GetName(enumType, value);
                var members = enumType.GetMember(enumValue);
                if (members.Length != 0)
                {
                    var member = members[0];
                    var attrs = member.GetCustomAttributes(typeof(DisplayAttribute), false);
                    outString = ((DisplayAttribute) attrs[0]).Name;

                    if (((DisplayAttribute) attrs[0]).ResourceType != null)
                    {
                        outString = ((DisplayAttribute) attrs[0]).GetName();
                    }
                }
                }
                catch (Exception e)
                {
                    // Enum value with undefined enum value
                }
            }
            return outString;

        }


        public static IEnumerable<T> GetEnumValues<T>()
        {
            return Enum.GetValues(typeof(T)).Cast<T>();
        }

        /// <summary>
        /// Extension method to return an enum value of type T for the given string.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        public static T ToEnum<T>(this string value)
        {
            return (T)Enum.Parse(typeof(T), value, true);
        }

        /// <summary>
        /// Extension method to return an enum value of type T for the given int.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        public static T ToEnum<T>(this int value)
        {
            var name = Enum.GetName(typeof(T), value);
            return name.ToEnum<T>();
        }


    }
}
