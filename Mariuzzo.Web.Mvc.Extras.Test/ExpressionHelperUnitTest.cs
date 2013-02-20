using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Mariuzzo.Web.Mvc.Extras;
using Mariuzzo.Web.Mvc.Extras.Test.Sample;

namespace ASP.NET_MVC_Extras_Test
{
    [TestClass]
    public class ExpressionHelperUnitTest
    {
        [TestMethod]
        public void TestGetExpressionText()
        {
            var case1 = ExpressionHelper.GetExpressionText((Foo f) => f.DateTime);
            Assert.AreEqual("DateTime", case1);

            var case2 = ExpressionHelper.GetExpressionText((Foo f) => f.NullableDateTime);
            Assert.AreEqual("NullableDateTime", case2);

            var case3 = ExpressionHelper.GetExpressionText((Foo f) => f.Bar.Number);
            Assert.AreEqual("Bar.Number", case3);
        }
    }
}
