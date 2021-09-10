using NUnit.Framework;
using System;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Binding;
using Tizen.NUI.Xaml;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("public/XamlBinding/BindablePropertyKey")]
    internal class PublicBindablePropertyKeyTest
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
        [Description("BindablePropertyKey BindablePropertyKey")]
        [Property("SPEC", "Tizen.NUI.Binding.BindablePropertyKey.BindablePropertyKey C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        public void BindablePropertyKeyConstructor()
        {
            tlog.Debug(tag, $"BindablePropertyKeyConstructor START");
            
            try
            {
                BindablePropertyKey t2 = new BindablePropertyKey(View.NameProperty);
                Assert.IsNotNull(t2, "null BindablePropertyKey");
                Assert.IsInstanceOf<BindablePropertyKey>(t2, "Should return BindablePropertyKey instance.");
            }
            catch (Exception e)
            {
                Assert.Fail("Caught Exception" + e.ToString());
            }
            
            tlog.Debug(tag, $"BindablePropertyKeyConstructor END");
        }

        [Test]
        [Category("P2")]
        [Description("BindablePropertyKey BindablePropertyKey")]
        [Property("SPEC", "Tizen.NUI.Binding.BindablePropertyKey.BindablePropertyKey C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        public void BindablePropertyKeyConstructor2()
        {
            tlog.Debug(tag, $"BindablePropertyKeyConstructor2 START");
            Assert.Throws<ArgumentNullException>(() => new BindablePropertyKey(null));
            tlog.Debug(tag, $"BindablePropertyKeyConstructor2 END");
        }

        [Test]
        [Category("P1")]
        [Description("BindablePropertyKey  BindableProperty")]
        [Property("SPEC", "Tizen.NUI.Binding.BindablePropertyKey.BindableProperty  A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        public void BindablePropertyTest1()
        {
            tlog.Debug(tag, $"BindablePropertyTest1 START");
            try
            {
                BindablePropertyKey t2 = new BindablePropertyKey(View.NameProperty);
                Assert.IsNotNull(t2, "null BindablePropertyKey");
                Assert.AreEqual(View.NameProperty, t2.BindableProperty, "Should be equal");
            }
            catch (Exception e)
            {
                Assert.Fail("Caught Exception" + e.ToString());
            }
            tlog.Debug(tag, $"BindablePropertyTest1 END");
        }

    }
}