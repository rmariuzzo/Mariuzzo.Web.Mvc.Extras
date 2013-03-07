using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace Mariuzzo.Web.Mvc.Extras
{
    /// <summary>
    /// The <code>ExpressionHelper</code> class provides helper methods to get the model name from an expression.
    /// </summary>
    public class ExpressionHelper
    {
        /// <summary>
        /// Gets the model name from a lambda expression.
        /// </summary>
        /// <typeparam name="TModel">The model type.</typeparam>
        /// <param name="expression">The expression.</param>
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
        /// Return a list of properties for an expression.
        /// </summary>
        /// <param name="expression">The expression.</param>
        /// <returns>A list of properties.</returns>
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
