using System;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace SkillMatrix.Common
{
    public static partial class Utilities
    {
        public static Attribute GetCustomAttribute(Type type, Type attributeType, string field = null)
        {
            if (field != null)
            {
                var fi = type.GetField(field);
                var attrs =
                    fi.GetCustomAttributes(attributeType, true);
                return attrs.OfType<Attribute>().FirstOrDefault();
            }
            else
            {
                return type.GetCustomAttributes(attributeType, true).OfType<Attribute>().FirstOrDefault();
            }
        }

        public static TAttributeType GetCustomAttribute<TParam, TAttributeType>(Expression<Func<TParam, object>> expr = null)
            where TAttributeType : Attribute
        {
            return GetCustomAttribute(typeof(TParam), typeof(TAttributeType), expr != null ? ExpressionToFieldName(expr) : null) as TAttributeType;
        }

        public static TField GetPrivateFieldValue<TObj, TField>(TObj obj, string fieldName)
        {
            var field = typeof (TObj).GetField(fieldName, BindingFlags.NonPublic | BindingFlags.Instance);
            if (field == null)
                return default(TField);

            return (TField) field.GetValue(obj);
        }

        public static TField GetPrivateStaticFieldValue<TObj, TField>(string fieldName)
        {
            var field = typeof(TObj).GetField(fieldName, BindingFlags.NonPublic | BindingFlags.Static);
            if (field == null)
                return default(TField);

            return (TField)field.GetValue(null);
        }
        
    }
}