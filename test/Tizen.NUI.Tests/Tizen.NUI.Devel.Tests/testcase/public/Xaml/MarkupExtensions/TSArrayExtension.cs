using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
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
        [Description("ArrayExtension ArrayExtension")]
        [Property("SPEC", "Tizen.NUI.Xaml.ArrayExtension.ArrayExtension C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        public void ArrayExtensionConstructor()
        {
            tlog.Debug(tag, $"ArrayExtensionConstructor START");

            ArrayExtension arrayExtension = new ArrayExtension();
            Assert.IsNotNull(arrayExtension, "null ArrayExtension");
            Assert.IsInstanceOf<ArrayExtension>(arrayExtension, "Should return ArrayExtension instance.");

            tlog.Debug(tag, $"ArrayExtensionConstructor END");
        }

        [Test]
        [Category("P1")]
        [Description("ArrayExtension Items")]
        [Property("SPEC", "Tizen.NUI.Xaml.ArrayExtension.Items A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        public void ArrayExtensionItems()
        {
            tlog.Debug(tag, $"ArrayExtensionItems START");

            try
            {
                Assert.IsNotNull(array, "null ArrayExtension");
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
        [Description("ArrayExtension Type")]
        [Property("SPEC", "Tizen.NUI.Xaml.ArrayExtension.Type A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        public void ArrayExtensionType()
        {
            tlog.Debug(tag, $"ArrayExtensionType START");

            try
            {
                Type t1 = array.Type;
                array.Type = t1;
                Assert.AreEqual(t1, array.Type, "Should be equal");
            }
            catch (Exception e)
            {
                Tizen.Log.Error(tag, "Caught Exception" + e.ToString());
                Assert.Fail("Caught Exception" + e.ToString());
            }

            tlog.Debug(tag, $"ArrayExtensionType END");
        }

        [Test]
        [Category("P1")]
        [Description("ArrayExtension ProvideValue")]
        [Property("SPEC", "Tizen.NUI.Xaml.ArrayExtension.ProvideValue A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        public void ArrayExtensionProvideValue()
        {
            tlog.Debug(tag, $"ArrayExtensionProvideValue START");

            try
            {
                IServiceProviderImpl serviceProviderimplement = new IServiceProviderImpl();
                Assert.IsNotNull(serviceProviderimplement, "null IServiceProviderimplement");
                Assert.IsInstanceOf<IServiceProviderImpl>(serviceProviderimplement, "Should return IServiceProviderImpl instance.");
                array.Items.Add("string");
                array.Type = typeof(string);

                array.ProvideValue(serviceProviderimplement);
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
        [Property("SPEC", "Tizen.NUI.Xaml.ArrayExtension.ProvideValue A")]
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