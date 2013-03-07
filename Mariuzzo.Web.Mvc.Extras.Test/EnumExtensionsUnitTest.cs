using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Mariuzzo.Web.Mvc.Extras.Test
{
    [TestClass]
    public class EnumExtensionsUnitTest
    {
        [TestMethod]
        public void TestToSelectListItem()
        {
            var zero = Numbers.Zero.ToSelectListItem();
            Assert.IsNotNull(zero);
            Assert.IsNotNull(zero.Value);
            Assert.IsNotNull(zero.Text);
            Assert.AreEqual("Zero", zero.Text);
            Assert.AreEqual("Zero", zero.Value);
            Assert.AreEqual(Numbers.Zero, Enum.Parse(typeof(Numbers), zero.Value));

            var one = Numbers.One.ToSelectListItem();
            Assert.IsNotNull(one);
            Assert.IsNotNull(one.Value);
            Assert.IsNotNull(one.Text);
            Assert.AreEqual("Uno", one.Text);
            Assert.AreEqual("One", one.Value);
            Assert.AreEqual(Numbers.One, Enum.Parse(typeof(Numbers), one.Value));

            var two = Numbers.Two.ToSelectListItem();
            Assert.IsNotNull(two);
            Assert.IsNotNull(two.Value);
            Assert.IsNotNull(two.Text);
            Assert.AreEqual("Two", two.Text);
            Assert.AreEqual("Two", two.Value);
            Assert.AreEqual(Numbers.Two, Enum.Parse(typeof(Numbers), two.Value));
        }

        public enum Numbers
        {
            Zero,

            [System.ComponentModel.Description("Uno")]
            One = 1,

            Two = 2
        }
    }
}
