﻿using System;
using System.Linq.Expressions;
using System.Web.Mvc;

namespace Mariuzzo.Web.Mvc.Extras
{
    /// <summary>
    /// The <code>ModelStateDictionaryExtensions</code> class provides extension methods to <code>System.Web.Mvc.ModelStateDictionary</code>.
    /// </summary>
    public static class ModelStateDictionaryExtensions
    {
        /// <summary>
        /// Indicates if the expression is a valid field for the current model.
        /// </summary>
        /// <typeparam name="TModel">The type of the model.</typeparam>
        /// <param name="modelState">The model state.</param>
        /// <param name="expression">The expression tree representing a property to validate.</param>
        /// <returns><code>true</code> if the expression is a valid field for the current model, otherwise <code>false</code>.</returns>
        public static bool IsValidField<TModel>(this ModelStateDictionary modelState, Expression<Func<TModel, object>> expression)
        {
            if (expression == null)
            {
                throw new ArgumentNullException("expression");
            }
            return modelState.IsValidField(ExpressionHelper.GetExpressionText(expression));
        }

        /// <summary>
        /// Add a model error.
        /// </summary>
        /// <typeparam name="TModel">The type of the model.</typeparam>
        /// <param name="modelState">The model state.</param>
        /// <param name="expression">The expression tree representing a property to add an error in its state.</param>
        /// <param name="errorMessage">The error message to add.</param>
        public static void AddModelError<TModel>(this ModelStateDictionary modelState, Expression<Func<TModel, object>> expression, String errorMessage)
        {
            modelState.AddModelError(ExpressionHelper.GetExpressionText(expression), errorMessage);
        }

        /// <summary>
        /// Add a model error.
        /// </summary>
        /// <typeparam name="TModel">The type of the model.</typeparam>
        /// <param name="modelState">The model state.</param>
        /// <param name="expression">The expression tree representing a property to add an error in its state.</param>
        /// <param name="exception">The exception to add as an error message container.</param>
        public static void AddModelError<TModel>(this ModelStateDictionary modelState, Expression<Func<TModel, object>> expression, Exception exception)
        {
            modelState.AddModelError(ExpressionHelper.GetExpressionText(expression), exception);
        }

        /// <summary>
        /// Remove the element that has the specified tree expression from the model-state dictionary.
        /// </summary>
        /// <typeparam name="TModel">The type of the model.</typeparam>
        /// <param name="modelState">The model state.</param>
        /// <param name="expression">The expression tree representing a property.</param>
        public static bool Remove<TModel>(this ModelStateDictionary modelState, Expression<Func<TModel, object>> expression)
        {
            return modelState.Remove(ExpressionHelper.GetExpressionText(expression));
        }
    }
}
