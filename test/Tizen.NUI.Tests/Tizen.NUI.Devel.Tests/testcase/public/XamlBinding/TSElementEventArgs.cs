using NUnit.Framework;
using System;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Binding;
using Tizen.NUI.Xaml;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("public/XamlBinding/ElementEventArgs")]
    internal class PublicElementEventArgsTest
    {
        private const string tag = "NUITEST";

        [SetUp]
        public void Init()
        {
            tlog.Info(tag, "Init() is called!");
        }

        [TearDown]
        public void Destroy()
        {
            tlog.Info(tag, "Destroy() is called!");
        }

        [Test]
        [Category("P1")]
        [Description("ElementEventArgs ElementEventArgs")]
        [Property("SPEC", "Tizen.NUI.Binding.ElementEventArgs.ElementEventArgs C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        public void ElementEventArgsConstructor()
        {
            tlog.Debug(tag, $"ElementEventArgsConstructor START");
            
            try
            {
                View view = new View();
                ElementEventArgs t2 = new ElementEventArgs(view);
                Assert.IsNotNull(t2, "null ElementEventArgs");
                Assert.IsInstanceOf<ElementEventArgs>(t2, "Should return ElementEventArgs instance.");
            }
            catch (Exception e)
            {
                Assert.Fail("Caught Exception" + e.ToString());
            }
            
            tlog.Debug(tag, $"ElementEventArgsConstructor END");
        }

        [Test]
        [Category("P2")]
        [Description("ElementEventArgs ElementEventArgs")]
        [Property("SPEC", "Tizen.NUI.Binding.ElementEventArgs.ElementEventArgs C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        public void ElementEventArgsConstructor2()
        {
            tlog.Debug(tag, $"ElementEventArgsConstructor2 START");
            Assert.Throws<ArgumentNullException>(() => new ElementEventArgs(null));
            tlog.Debug(tag, $"ElementEventArgsConstructor2 END");
        }

        [Test]
        [Category("P1")]
        [Description("ElementEventArgs  Element")]
        [Property("SPEC", "Tizen.NUI.Binding.ElementEventArgs.Element  A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        public void ElementTest1()
        {
            tlog.Debug(tag, $"ElementTest1 START");
            try
            {
                View view = new View();
                ElementEventArgs t2 = new ElementEventArgs(view);
                Assert.IsNotNull(t2, "null ElementEventArgs");
                Element elm = view as Element;
                Assert.AreEqual(elm, t2.Element, "Should be equal");
            }
            catch (Exception e)
            {
                Assert.Fail("Caught Exception" + e.ToString());
            }
            tlog.Debug(tag, $"ElementTest1 END");
        }

    }
}