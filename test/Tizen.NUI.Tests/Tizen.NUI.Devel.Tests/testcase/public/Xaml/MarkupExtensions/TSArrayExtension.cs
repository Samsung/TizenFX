using NUnit.Framework;
using System;
using System.Collections;
using Tizen.NUI.Xaml;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("public/xaml/MarkupExtensions/ArrayExtension")]
    public class PublicArrayExtensionTest
    {
        private const string tag = "NUITEST";
        private static ArrayExtension a1;

        internal class IServiceProviderimplement : IServiceProvider
        {
            public object GetService(Type serviceType)
            {
                return null;
            }
        }

        [SetUp]
        public void Init()
        {
            tlog.Info(tag, "Init() is called!");
            a1 = new ArrayExtension();
        }

        [TearDown]
        public void Destroy()
        {
            a1 = null;
            tlog.Info(tag, "Destroy() is called!");
        }

        [Test]
        [Category("P1")]
        [Description("ArrayExtension ArrayExtension")]
        [Property("SPEC", "Tizen.NUI.ArrayExtension.ArrayExtension C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        public void ArrayExtensionConstructor()
        {
            tlog.Debug(tag, $"ArrayExtensionConstructor START");

            ArrayExtension arrayExtension = new ArrayExtension();

            tlog.Debug(tag, $"ArrayExtensionConstructor END (OK)");
            Assert.Pass("ArrayExtensionConstructor");
        }

        [Test]
        [Category("P1")]
        [Description("ArrayExtension Items")]
        [Property("SPEC", "Tizen.NUI.ArrayExtension.Items A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        public void ArrayExtensionItems()
        {
            tlog.Debug(tag, $"ArrayExtensionItems START");

            try
            {
                IList i1 = a1.Items;
            }
            catch (Exception e)
            {
                Tizen.Log.Error(tag, "Caught Exception" + e.ToString());
                Assert.Fail("Caught Exception" + e.ToString());
            }

            tlog.Debug(tag, $"ArrayExtensionItems END (OK)");
            Assert.Pass("ArrayExtensionItems");
        }

        [Test]
        [Category("P1")]
        [Description("ArrayExtension Type")]
        [Property("SPEC", "Tizen.NUI.ArrayExtension.Type A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        public void ArrayExtensionType()
        {
            tlog.Debug(tag, $"ArrayExtensionType START");

            try
            {
                Type t1 = a1.Type;
                a1.Type = t1;
            }
            catch (Exception e)
            {
                Tizen.Log.Error(tag, "Caught Exception" + e.ToString());
                Assert.Fail("Caught Exception" + e.ToString());
            }

            tlog.Debug(tag, $"ArrayExtensionType END (OK)");
            Assert.Pass("ArrayExtensionType");
        }

        [Test]
        [Category("P1")]
        [Description("ArrayExtension ProvideValue")]
        [Property("SPEC", "Tizen.NUI.ArrayExtension.ProvideValue A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        public void ArrayExtensionProvideValue()
        {
            tlog.Debug(tag, $"ArrayExtensionProvideValue START");

            try
            {
                IServiceProviderimplement serviceProviderimplement = new IServiceProviderimplement();
                a1.Type = typeof(string);

                a1.ProvideValue(serviceProviderimplement);
            }
            catch (Exception e)
            {
                Tizen.Log.Error(tag, "Caught Exception" + e.ToString());
                Assert.Fail("Caught Exception" + e.ToString());
            }

            tlog.Debug(tag, $"ArrayExtensionProvideValue END (OK)");
            Assert.Pass("ArrayExtensionProvideValue");
        }
    }
}