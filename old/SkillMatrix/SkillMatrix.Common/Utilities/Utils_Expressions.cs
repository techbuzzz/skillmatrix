using System;
using System.Linq.Expressions;

namespace SkillMatrix.Common
{
    public static partial class Utilities
    {
        public static string ExpressionToFieldName<T, P>(Expression<Func<T, P>> sortColumn)
        {
            return (sortColumn.Body as MemberExpression ?? ((UnaryExpression)sortColumn.Body).Operand as MemberExpression).Member.Name;
        }

        public static Action Action(Action a) { return a; }
        public static Action<T1> Action<T1>(Action<T1> a) { return a; }
        public static Action<T1, T2> Action<T1, T2>(Action<T1, T2> a) { return a; }
        public static Action<T1, T2, T3> Action<T1, T2, T3>(Action<T1, T2, T3> a) { return a; }
        public static Action<T1, T2, T3, T4> Action<T1, T2, T3, T4>(Action<T1, T2, T3, T4> a) { return a; }
        public static Action<T1, T2, T3, T4, T5> Action<T1, T2, T3, T4, T5>(Action<T1, T2, T3, T4, T5> a) { return a; }
        public static Action<T1, T2, T3, T4, T5, T6> Action<T1, T2, T3, T4, T5, T6>(Action<T1, T2, T3, T4, T5, T6> a) { return a; }
        public static Action<T1, T2, T3, T4, T5, T6, T7> Action<T1, T2, T3, T4, T5, T6, T7>(Action<T1, T2, T3, T4, T5, T6, T7> a) { return a; }
        public static Action<T1, T2, T3, T4, T5, T6, T7, T8> Action<T1, T2, T3, T4, T5, T6, T7, T8>(Action<T1, T2, T3, T4, T5, T6, T7, T8> a) { return a; }
        public static Action<T1, T2, T3, T4, T5, T6, T7, T8, T9> Action<T1, T2, T3, T4, T5, T6, T7, T8, T9>(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9> a) { return a; }
        public static Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> a) { return a; }
        public static Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> a) { return a; }
        public static Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> a) { return a; }
        public static Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> a) { return a; }
        public static Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> a) { return a; }
        public static Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> a) { return a; }
        public static Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> a) { return a; }

        public static Func<T1> Func<T1>(Func<T1> a) { return a; }
        public static Func<T1, T2> Func<T1, T2>(Func<T1, T2> a) { return a; }
        public static Func<T1, T2, T3> Func<T1, T2, T3>(Func<T1, T2, T3> a) { return a; }
        public static Func<T1, T2, T3, T4> Func<T1, T2, T3, T4>(Func<T1, T2, T3, T4> a) { return a; }
        public static Func<T1, T2, T3, T4, T5> Func<T1, T2, T3, T4, T5>(Func<T1, T2, T3, T4, T5> a) { return a; }
        public static Func<T1, T2, T3, T4, T5, T6> Func<T1, T2, T3, T4, T5, T6>(Func<T1, T2, T3, T4, T5, T6> a) { return a; }
        public static Func<T1, T2, T3, T4, T5, T6, T7> Func<T1, T2, T3, T4, T5, T6, T7>(Func<T1, T2, T3, T4, T5, T6, T7> a) { return a; }
        public static Func<T1, T2, T3, T4, T5, T6, T7, T8> Func<T1, T2, T3, T4, T5, T6, T7, T8>(Func<T1, T2, T3, T4, T5, T6, T7, T8> a) { return a; }
        public static Func<T1, T2, T3, T4, T5, T6, T7, T8, T9> Func<T1, T2, T3, T4, T5, T6, T7, T8, T9>(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9> a) { return a; }
        public static Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> a) { return a; }
        public static Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> a) { return a; }
        public static Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> a) { return a; }
        public static Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> a) { return a; }
        public static Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> a) { return a; }
        public static Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> a) { return a; }
        public static Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> a) { return a; }
        public static Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17> Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17>(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17> a) { return a; }

        public static Expression<Func<T1>> Expr<T1>(Expression<Func<T1>> a) { return a; }
        public static Expression<Func<T1, T2>> Expr<T1, T2>(Expression<Func<T1, T2>> a) { return a; }
        public static Expression<Func<T1, T2, T3>> Expr<T1, T2, T3>(Expression<Func<T1, T2, T3>> a) { return a; }
        public static Expression<Func<T1, T2, T3, T4>> Expr<T1, T2, T3, T4>(Expression<Func<T1, T2, T3, T4>> a) { return a; }
        public static Expression<Func<T1, T2, T3, T4, T5>> Expr<T1, T2, T3, T4, T5>(Expression<Func<T1, T2, T3, T4, T5>> a) { return a; }
        public static Expression<Func<T1, T2, T3, T4, T5, T6>> Expr<T1, T2, T3, T4, T5, T6>(Expression<Func<T1, T2, T3, T4, T5, T6>> a) { return a; }
        public static Expression<Func<T1, T2, T3, T4, T5, T6, T7>> Expr<T1, T2, T3, T4, T5, T6, T7>(Expression<Func<T1, T2, T3, T4, T5, T6, T7>> a) { return a; }
        public static Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8>> Expr<T1, T2, T3, T4, T5, T6, T7, T8>(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8>> a) { return a; }
        public static Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9>> Expr<T1, T2, T3, T4, T5, T6, T7, T8, T9>(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9>> a) { return a; }
        public static Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>> Expr<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>> a) { return a; }
        public static Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>> Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>> a) { return a; }
        public static Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>> Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>> a) { return a; }
        public static Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>> Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>> a) { return a; }
        public static Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>> Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>> a) { return a; }
        public static Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>> Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>> a) { return a; }
        public static Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>> Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>> a) { return a; }
        public static Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17>> Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17>(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17>> a) { return a; }

         
    }
}