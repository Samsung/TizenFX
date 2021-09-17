using NUnit.Framework;
using System;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Binding;
using Tizen.NUI.Xaml;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("public/XamlBinding/BindableObjectExtensions")]
    internal class PublicBindableObjectExtensionsTest
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
        [Description("BindableObjectExtensions  SetBinding")]
        [Property("SPEC", "Tizen.NUI.Binding.BindableObjectExtensions.SetBinding  M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MCST")]
        public void SetBindingTest1()
        {
            tlog.Debug(tag, $"SetBindingTest1 START");
            try
            {
                var view = new View();
                BindableObjectExtensions.SetBinding(view, View.FocusableProperty, "Focusable");
            }
            catch (Exception e)
            {
                Assert.Fail("Caught Exception" + e.ToString());
            }
            tlog.Debug(tag, $"SetBindingTest1 END");
        }

        [Test]
        [Category("P1")]
        [Description("BindableObjectExtensions  SetBinding")]
        [Property("SPEC", "Tizen.NUI.Binding.BindableObjectExtensions.SetBinding  M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MCST")]
        public void SetBindingTest2()
        {
            tlog.Debug(tag, $"SetBindingTest2 START");

            var view = new View();
            Assert.Throws<ArgumentNullException>(() => BindableObjectExtensions.SetBinding(null, View.FocusableProperty, "Focusable"));
            Assert.Throws<ArgumentNullException>(() => BindableObjectExtensions.SetBinding(view, null, "Focusable"));

            tlog.Debug(tag, $"SetBindingTest2 END");
        }
    }
}