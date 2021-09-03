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
                var item = array.Items;         // empty
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
                tlog.Debug(tag, "Type : " + array.Type);
                array.ProvideValue(new IServiceProviderImpl());
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            tlog.Debug(tag, $"ArrayExtensionProvideValue END");
        }

        [Test]
        [Category("P2")]
        [Description("ArrayExtension ProvideValue")]
        [Property("SPEC", "Tizen.NUI.ArrayExtension.ProvideValue A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        public void ArrayExtensionProvideValueWithNullType()
        {
            tlog.Debug(tag, $"ArrayExtensionProvideValueWithNullType START");

            try
            {
                array.Type = null;
                array.ProvideValue(new IServiceProviderImpl());
            }
            catch (InvalidOperationException e)
            {
                tlog.Debug(tag, e.Message.ToString());
                tlog.Debug(tag, $"ArrayExtensionProvideValueWithNullType END");
                Assert.Pass("Caught InvalidOperationException : Passed!");
            }
        }
    }
}