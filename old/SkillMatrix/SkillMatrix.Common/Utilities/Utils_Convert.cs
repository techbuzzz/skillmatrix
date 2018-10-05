using System;
using System.Globalization;

namespace SkillMatrix.Common
{
    public partial class Utilities
    {
        public static DateTime? TryParseDateTime(this string value)
        {
            //if (value.IsNullOrEmpty()) return null;
            DateTime result;
            return DateTime.TryParse(value, out result) ? (DateTime?)result : null;
        }

        public static DateTime? TryParseExactInvariantDateTime(this string value, string format)
        {
            //if (value.IsNullOrEmpty()) return null;
            DateTime result;
            return DateTime.TryParseExact(value, format, System.Globalization.CultureInfo.InvariantCulture, DateTimeStyles.None,  out result) ? (DateTime?)result : null;
        }

        public static int TryParseInt32(this string value)
        {
            //if (value.IsNullOrEmpty()) return null;
            int result;
            return Int32.TryParse(value, out result) ? result : 0;
        }

        public static double? TryParseDouble(this string value)
        {
            //if (value.IsNullOrEmpty()) return null;
            double result;
            return Double.TryParse(value, out result) ? (double?)result : null;
        }

        public static decimal? TryParseDecimal(this string value)
        {
            //if (value.IsNullOrEmpty()) return null;
            decimal result;
            return Decimal.TryParse(value, out result) ? (decimal?)result : null;
        }


        public static TTarget ChangeType<TTarget>(this object value)
        {
            return (TTarget)Convert.ChangeType(value, typeof(TTarget));
        }

        /*public static TTarget SafeChangeType<TTarget>(this object value)
        {
            if (value == null) return default(TTarget);

            var ic = value as IConvertible;
            if (ic == null) { 
                if ( value.GetType() == typeof(TTarget)) {
                    return (TTarget)(object)value;
                }
                return default(TTarget);
            }

            return (TTarget) Convert.ChangeType(value, typeof (TTarget));
        }*/

        public static TTarget As<TSource, TTarget>(this TSource value)
    where TTarget : class
        {
            return value as TTarget;
        }

    }
}