Mariuzzo.Web.Mvc.Extras
=======================

Extra and maybe missing components for ASP.NET MVC.

What is inside the Extras?
--------------------------

# ExpressionHelper #

A better `ExpressionHelper` class that properly handles `UnaryExpression` (aka Convert expression).

## The Problem ##

The [`System.Web.Mvc.ExpressionHelper#GetExpressionText`](http://msdn.microsoft.com/en-us/library/ee428394.aspx) return an empty string for any [`Nullable`](http://msdn.microsoft.com/en-us/library/b3h38hb0.aspx) property. 

If you have the following `Foo` class:

    class Foo {
        public int? Id { get; set; }
    }

And then run: `System.Web.Mvc.ExpressionHelper.GetExpressionText((Foo f) => f.Id)` you will receive an empty string instead of: `Id`. The same goes for any inner property that are [`Nullable`](http://msdn.microsoft.com/en-us/library/b3h38hb0.aspx).

## Solution ##

The [`Mariuzzo.Web.Mvc.Extras.ExpressionHelper`](https://github.com/rmariuzzo/Mariuzzo.Web.Mvc.Extras/blob/master/Mariuzzo.Web.Mvc.Extras/ExpressionHelper.cs) provides a `GetExpressionText` method that handle that specific case.