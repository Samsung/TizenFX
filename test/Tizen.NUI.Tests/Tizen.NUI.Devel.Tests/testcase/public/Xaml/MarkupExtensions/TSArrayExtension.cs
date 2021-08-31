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
        private ArrayExtension array;

        internal class IServiceProviderImpl : IServiceProvider
        {
            public object GetService(Type serviceType) { return null; }
        }

        [SetUp]
        public void Init()
        {
            tlog.Info(tag, "Init() is called!");
            array = new ArrayExtension();
        }

        [TearDown]
        public void Destroy()
        {
            array = null;
            tlog.Info(tag, "Destroy() is called!");
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
                var item = array.Items;
                tlog.Debug(tag, "Items : " + item);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            tlog.Debug(tag, $"ArrayExtensionItems END");
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
                var type = array.Type;
                array.Type = type;
                Assert.AreEqual(type, array.Type, "Should be equal");
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            tlog.Debug(tag, $"ArrayExtensionType END");
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
                array.Type = typeof(string);
                array.ProvideValue(new IServiceProviderImpl());
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            tlog.Debug(tag, $"ArrayExtensionProvideValue END");
        }
    }
}