using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace Mariuzzo.Web.Mvc.Extras
{
    /// <summary>
    /// The <code>ExpressionHelper</code> class.
    /// </summary>
    public class ExpressionHelper
    {
        /// <summary>
        /// Return the text representation for an expression tree.
        /// </summary>
        /// <typeparam name="TModel"></typeparam>
        /// <param name="expression"></param>
        /// <returns></returns>
        public static string GetExpressionText<TModel>(Expression<Func<TModel, object>> expression)
        {
            var expr = (LambdaExpression)expression;
            if (expr.Body.NodeType == ExpressionType.Convert)
            {
                var ue = expression.Body as UnaryExpression;
                return String.Join(".", GetProperties(ue.Operand).Select(p => p.Name));
            }
            return System.Web.Mvc.ExpressionHelper.GetExpressionText(expr);
        }

        /// <summary>
        /// Return a list of properties for an expression tree.
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        private static IEnumerable<PropertyInfo> GetProperties(Expression expression)
        {
            var memberExpression = expression as MemberExpression;
            if (memberExpression == null) yield break;

            var property = memberExpression.Member as PropertyInfo;
            foreach (var propertyInfo in GetProperties(memberExpression.Expression))
            {
                yield return propertyInfo;
            }
            yield return property;
        }
    }
}
