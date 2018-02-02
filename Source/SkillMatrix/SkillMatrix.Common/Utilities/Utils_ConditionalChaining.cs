using System;
using System.Linq;

namespace SkillMatrix.Common
{
    public static partial class Utilities
    {

        public static TValue NotNull<TValue>(this TValue o1, params TValue[] on)
        {
            return (TValue)(((object)o1) ?? @on.FirstOrDefault(o => o != null));
        }

        public static T With<T>(this T obj, Action<T> action)
        {
            action(obj);
            return obj;
        }

        public static T WhenNull<T>(this T obj, Action<T> trueAction, Action falseAction = null)
        {
            return obj.When(obj == null, trueAction, o => { if (falseAction != null) falseAction(); });
        }

        public static T WhenNull<T>(this T obj, Action<T> trueAction, Action<T> falseAction)
        {
            return obj.When(obj == null, trueAction, o => { if (falseAction != null) falseAction(obj); });
        }

        public static T WhenNotNull<T>(this T obj, Action<T> trueAction, Action falseAction = null)
        {
            return obj.When(obj != null, trueAction, o => { if (falseAction != null) falseAction(); });
        }

        public static T WhenNotNull<T>(this T obj, Action<T> trueAction, Action<T> falseAction)
            where T : class
        {
            return obj.When(obj != null, trueAction, o => { if (falseAction != null) falseAction(obj); });
        }

        public static T When<T>(this T obj, bool condition, Action<T> trueAction, Action<T> falseAction = null)
        {
            if (condition)
            {
                if (trueAction != null) trueAction(obj);
            }
            else
            {
                if (falseAction != null) falseAction(obj);
            }
            return obj;
        }

        public static T When<T>(this T obj, bool condition, Action trueAction, Action falseAction = null)
        {
            if (condition)
            {
                if (trueAction != null) trueAction();
            }
            else
            {
                if (falseAction != null) falseAction();
            }
            return obj;
        }

        /// <summary>
        /// Safe evaluation - when obj is null, method returns default value for evaluation function, otherwise evaluates.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TProperty"></typeparam>
        /// <param name="obj"></param>
        /// <param name="expr"></param>
        /// <returns></returns>
        public static TProperty SafeEval<T, TProperty>(this T obj, Func<T, TProperty> expr)
            where T : class
        {
            return obj == null ? default(TProperty) : expr(obj);
        }
         
    }
}