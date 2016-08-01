Mariuzzo.Web.Mvc.Extras
=======================

Extra missing components for ASP.NET MVC.

Installation
------------

To install [Mariuzzo.Web.Mvc.Extras](http://nuget.org/packages/Mariuzzo.Web.Mvc.Extras/), run the following command in the NuGet's [Package Manager Console](http://docs.nuget.org/docs/start-here/using-the-package-manager-console)

```shell
Install-Package Mariuzzo.Web.Mvc.Extras
```

Documentation
=============

ExpressionHelper
----------------

##### GetExpressionText

What is inside the Extras?
--------------------------

 - [ExpressionHelper](#expressionhelper).
 - [ModelStateDictionaryExtensions](#modelstatedictionaryextensions)

ExpressionHelper
----------------

A better `ExpressionHelper` class that properly handles `UnaryExpression` (aka Convert expression).

### How to use ###

On any code block just call the static methods: `Mariuzzo.Web.Mvc.Extras.ExpressionHelper.GetExpressionText(...)`.

### The Problem ###

The [`System.Web.Mvc.ExpressionHelper#GetExpressionText`](http://msdn.microsoft.com/en-us/library/ee428394.aspx) return an empty string for any [`Nullable`](http://msdn.microsoft.com/en-us/library/b3h38hb0.aspx) property. 

If you have the following `Foo` class:

```csharp
class Foo {
	public int? Id { get; set; }
}
```

And then run: `System.Web.Mvc.ExpressionHelper.GetExpressionText((Foo f) => f.Id)` you will receive an empty string instead of: `Id`. The same goes for any inner property that are [`Nullable`](http://msdn.microsoft.com/en-us/library/b3h38hb0.aspx).

### Solution ###

The [`Mariuzzo.Web.Mvc.Extras.ExpressionHelper`](https://github.com/rmariuzzo/Mariuzzo.Web.Mvc.Extras/blob/master/Mariuzzo.Web.Mvc.Extras/ExpressionHelper.cs) provides a `GetExpressionText` method that handle that specific case.

ModelStateDictionaryExtensions
------------------------------

Set of extension methods for [ModelStateDictionary](http://msdn.microsoft.com/en-us/library/system.web.mvc.modelstatedictionary.aspx) providing methods supporting Lambda Expression instead of _magic string_.

### How to use ###

On top of any of your Controllers just add: `using Mariuzzo.Web.Mvc.Extras;`.

### The Problem ###

What would happen to the following code if you rename the property `Bar` of your model?

```csharp
if (ModelState.IsValidField("Bar")
{
	...
}
```

If you forgot to also rename any of those _magic string_, I'm pretty sure you and your controllers will be in problem.

### Solution ###

The [`Mariuzzo.Web.Mvc.Extras.ModelStateDictionaryExtensions`](https://github.com/rmariuzzo/Mariuzzo.Web.Mvc.Extras/blob/master/Mariuzzo.Web.Mvc.Extras/ModelStateDictionaryExtensions.cs) extend the legacy [ModelStateDictionary](http://msdn.microsoft.com/en-us/library/system.web.mvc.modelstatedictionary.aspx) and provides the same methods, but instead of _magic strings_ it accepts Lambda Expression.

```csharp
if (ModelState.IsValidField((Foo f) => f.Bar))
{
	...
}
```
