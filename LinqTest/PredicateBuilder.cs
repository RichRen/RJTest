using System;
using System.Linq.Expressions;

namespace LinqTest
{
    /// <summary>
    /// 谓词构建者。用于拼接谓词，或对谓词求“非”。
    /// </summary>
    public static class PredicateBuilder
    {
        private sealed class ParameterRebinder : ExpressionVisitor
        {
            private readonly ParameterExpression m_From;

            private readonly ParameterExpression m_To;

            public ParameterRebinder(ParameterExpression from, ParameterExpression to)
            {
                this.m_From = from;
                this.m_To = to;
            }

            protected override Expression VisitParameter(ParameterExpression node)
            {
                if (node == this.m_From)
                {
                    node = this.m_To;
                }
                return base.VisitParameter(node);
            }
        }

        /// <summary>
        /// 获取一个恒为“True”的谓词。通常用于用“与”的方式拼接谓词的起点。
        /// </summary>
        public static Expression<Func<T, bool>> True<T>()
        {
            return (T item) => true;
        }

        /// <summary>
        /// 获取一个恒为“False”的谓词。通常用于用“或”的方式拼接谓词的起点。
        /// </summary>
        public static Expression<Func<T, bool>> False<T>()
        {
            return (T item) => false;
        }

        /// <summary>
        /// 将两个谓词用“与”的方式拼接为一个新谓词。
        /// </summary>
        /// <exception cref="T:System.ArgumentNullException"></exception>
        public static Expression<Func<T, bool>> And<T>(this Expression<Func<T, bool>> first, Expression<Func<T, bool>> second)
        {
            if (first == null)
            {
                throw new ArgumentNullException("first");
            }
            if (second == null)
            {
                throw new ArgumentNullException("second");
            }
            return first.Compose(second, new Func<Expression, Expression, Expression>(Expression.And));
        }

        /// <summary>
        /// 将两个谓词用“或”的方式拼接为一个新谓词。
        /// </summary>
        /// <exception cref="T:System.ArgumentNullException"></exception>
        public static Expression<Func<T, bool>> Or<T>(this Expression<Func<T, bool>> first, Expression<Func<T, bool>> second)
        {
            if (first == null)
            {
                throw new ArgumentNullException("first");
            }
            if (second == null)
            {
                throw new ArgumentNullException("second");
            }
            return first.Compose(second, new Func<Expression, Expression, Expression>(Expression.Or));
        }

        /// <summary>
        /// 对指定谓词取“非”。
        /// </summary>
        /// <exception cref="T:System.ArgumentNullException"></exception>
        public static Expression<Func<T, bool>> Not<T>(this Expression<Func<T, bool>> predicate)
        {
            if (predicate == null)
            {
                throw new ArgumentNullException("predicate");
            }
            return Expression.Lambda<Func<T, bool>>(Expression.Not(predicate.Body), predicate.Parameters);
        }

        private static Expression<Func<T, bool>> Compose<T>(this Expression<Func<T, bool>> first, Expression<Func<T, bool>> second, Func<Expression, Expression, Expression> merge)
        {
            Expression arg = new PredicateBuilder.ParameterRebinder(second.Parameters[0], first.Parameters[0]).Visit(second.Body);
            return Expression.Lambda<Func<T, bool>>(merge(first.Body, arg), first.Parameters);
        }
    }
}
