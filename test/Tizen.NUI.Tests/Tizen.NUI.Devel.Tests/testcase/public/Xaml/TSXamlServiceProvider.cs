using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Xml;
using Tizen.NUI.Binding.Internals;
using Tizen.NUI.Xaml;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("public/xaml/XamlServiceProvider ")]
    public class PublicXamlServiceProviderTest
    {
        private const string tag = "NUITEST";
        private XamlServiceProvider provider;

        internal class INodeImpl : INode
        {
            public List<string> IgnorablePrefixes { get; set; }
            public IXmlNamespaceResolver NamespaceResolver { get; }
            public INode Parent { get; set; }
            public void Accept(IXamlNodeVisitor visitor, INode parentNode) { }
            public INode Clone() { return null; }
        }

        [SetUp]
        public void Init()
        {
            tlog.Info(tag, "Init() is called!");
            provider = new XamlServiceProvider();
        }

        [TearDown]
        public void Destroy()
        {
            provider = null;
            tlog.Info(tag, "Destroy() is called!");
        }

        private class INodeImplement : INode
        {
            public List<string> IgnorablePrefixes { get; set; }
            public IXmlNamespaceResolver NamespaceResolver { get; }
            public INode Parent { get; set; }

            public void Accept(IXamlNodeVisitor visitor, INode parentNode)
            {

            }
            public INode Clone()
            {
                return null;
            }
        }

        [Test]
        [Category("P1")]
        [Description("XamlServiceProvider XamlServiceProvider")]
        [Property("SPEC", "Tizen.NUI.XamlServiceProvider.XamlServiceProvider C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        public void XamlServiceProviderConstructor1()
        {
            tlog.Debug(tag, $"XamlServiceProviderConstructor START");

            XamlServiceProvider xamlServiceProvider1 = new XamlServiceProvider();
            Assert.IsNotNull(xamlServiceProvider1, "null XamlServiceProvider");
            Assert.IsInstanceOf<XamlServiceProvider>(xamlServiceProvider1, "Should return XamlServiceProvider instance.");
            tlog.Debug(tag, $"XamlServiceProviderConstructor END");
        }

        [Test]
        [Category("P1")]
        [Description("XamlServiceProvider IProvideValueTarget")]
        [Property("SPEC", "Tizen.NUI.XamlServiceProvider.IProvideValueTarget A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        public void XamlServiceProviderIProvideValueTarget()
        {
            tlog.Debug(tag, $"XamlServiceProviderIProvideValueTarget START");

            try
            {
                IProvideValueTarget i1 = provider.IProvideValueTarget;
                provider.IProvideValueTarget = i1;
                Assert.AreEqual(i1, provider.IProvideValueTarget, "Should be equal");
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            tlog.Debug(tag, $"XamlServiceProviderIProvideValueTarget END");
        }

        [Test]
        [Category("P1")]
        [Description("XamlServiceProvider IXamlTypeResolver")]
        [Property("SPEC", "Tizen.NUI.XamlServiceProvider.IXamlTypeResolver A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        public void XamlServiceProviderIXamlTypeResolver()
        {
            tlog.Debug(tag, $"XamlServiceProviderIXamlTypeResolver START");

            try
            {
                var value = provider.IXamlTypeResolver;
                provider.IXamlTypeResolver = value;
                Assert.AreEqual(value, provider.IXamlTypeResolver, "Should be equal");
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            tlog.Debug(tag, $"XamlServiceProviderIXamlTypeResolver END");
        }

        [Test]
        [Category("P1")]
        [Description("XamlServiceProvider IRootObjectProvider")]
        [Property("SPEC", "Tizen.NUI.XamlServiceProvider.IRootObjectProvider A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        public void XamlServiceProviderIRootObjectProvider()
        {
            tlog.Debug(tag, $"XamlServiceProviderIRootObjectProvider START");

            try
            {
                var value = provider.IRootObjectProvider;
                provider.IRootObjectProvider = value;
                Assert.AreEqual(value, provider.IRootObjectProvider, "Should be equal");
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            tlog.Debug(tag, $"XamlServiceProviderIRootObjectProvider END");
        }

        [Test]
        [Category("P1")]
        [Description("XamlServiceProvider IXmlLineInfoProvider")]
        [Property("SPEC", "Tizen.NUI.XamlServiceProvider.IXmlLineInfoProvider A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        public void XamlServiceProviderIXmlLineInfoProvider()
        {
            tlog.Debug(tag, $"XamlServiceProviderIXmlLineInfoProvider START");

            try
            {
                var value = provider.IXmlLineInfoProvider;
                provider.IXmlLineInfoProvider = value;
                Assert.AreEqual(value, provider.IXmlLineInfoProvider, "Should be equal");
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            tlog.Debug(tag, $"XamlServiceProviderIXmlLineInfoProvider END");
        }

        [Test]
        [Category("P1")]
        [Description("XamlServiceProvider INameScopeProvider")]
        [Property("SPEC", "Tizen.NUI.XamlServiceProvider.INameScopeProvider A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        public void XamlServiceProviderINameScopeProvider()
        {
            tlog.Debug(tag, $"XamlServiceProviderINameScopeProvider START");

            try
            {
                var value = provider.INameScopeProvider;
                provider.INameScopeProvider = value;
                Assert.AreEqual(value, provider.INameScopeProvider, "Should be equal");
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            tlog.Debug(tag, $"XamlServiceProviderINameScopeProvider END");
        }

        [Test]
        [Category("P1")]
        [Description("XamlServiceProvider IValueConverterProvider")]
        [Property("SPEC", "Tizen.NUI.XamlServiceProvider.IValueConverterProvider A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        public void XamlServiceProviderIValueConverterProvider()
        {
            tlog.Debug(tag, $"XamlServiceProviderIValueConverterProvider START");

            try
            {
                var value = provider.IValueConverterProvider;
                provider.IValueConverterProvider = value;
                Assert.AreEqual(value, provider.IValueConverterProvider, "Should be equal");
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            tlog.Debug(tag, $"XamlServiceProviderIValueConverterProvider END");
        }

        [Test]
        [Category("P1")]
        [Description("XamlServiceProvider GetService")]
        [Property("SPEC", "Tizen.NUI.XamlServiceProvider.GetService M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        public void XamlServiceProviderGetService()
        {
            tlog.Debug(tag, $"XamlServiceProviderGetService START");

            try
            {
                provider.GetService(typeof(string));
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            tlog.Debug(tag, $"XamlServiceProviderGetService END");
        }

        [Test]
        [Category("P1")]
        [Description("XamlServiceProvider Add")]
        [Property("SPEC", "Tizen.NUI.XamlServiceProvider.Add M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        public void XamlServiceProviderAdd()
        {
            tlog.Debug(tag, $"XamlServiceProviderAdd START");

            try
            {
                provider.Add(typeof(string), new object());
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            tlog.Debug(tag, $"XamlServiceProviderAdd END");
        }

        [Test]
        [Category("P1")]
        [Description("XamlServiceProvider XamlValueTargetProvider")]
        [Property("SPEC", "Tizen.NUI.XamlServiceProvider.XamlValueTargetProvider M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        public void XamlServiceProviderXamlValueTargetProvider()
        {
            tlog.Debug(tag, $"XamlServiceProviderXamlValueTargetProvider START");

            try
            {
                object o1 = new object();
                INodeImpl node = new INodeImpl();
                HydrationContext hydrationContext = new HydrationContext();
                object o2 = new object();

                var testingTarget = new XamlValueTargetProvider(o1, node, hydrationContext, o2);
                Assert.IsNotNull(testingTarget, "null XamlValueTargetProvider");
                Assert.IsInstanceOf<XamlValueTargetProvider>(testingTarget, "Should return XamlValueTargetProvider instance.");
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            tlog.Debug(tag, $"XamlServiceProviderXamlValueTargetProvider END");
        }

        [Test]
        [Category("P1")]
        [Description("XamlServiceProvider TargetObject")]
        [Property("SPEC", "Tizen.NUI.XamlServiceProvider.TargetObject A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        public void XamlServiceProviderTargetObject()
        {
            tlog.Debug(tag, $"XamlServiceProviderTargetObject START");

            try
            {
                object o1 = new object();
                INodeImpl node = new INodeImpl();
                HydrationContext hydrationContext = new HydrationContext();
                object o2 = new object();

                var testingTarget = new XamlValueTargetProvider(o1, node, hydrationContext, o2);
                Assert.IsNotNull(testingTarget, "null XamlValueTargetProvider");
                Assert.IsInstanceOf<XamlValueTargetProvider>(testingTarget, "Should return XamlValueTargetProvider instance.");

                object object1 = testingTarget.TargetObject;
                Assert.AreEqual(o1, object1, "Should be equal");
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            tlog.Debug(tag, $"XamlServiceProviderTargetObject END");
        }

        [Test]
        [Category("P1")]
        [Description("XamlServiceProvider TargetProperty")]
        [Property("SPEC", "Tizen.NUI.XamlServiceProvider.TargetProperty A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        public void XamlServiceProviderTargetProperty()
        {
            tlog.Debug(tag, $"XamlServiceProviderTargetProperty START");

            try
            {
                object o1 = new object();
                INodeImpl node = new INodeImpl();
                HydrationContext hydrationContext = new HydrationContext();
                object o2 = new object();

                var testingTarget = new XamlValueTargetProvider(o1, node, hydrationContext, o2);
                Assert.IsNotNull(testingTarget, "null XamlValueTargetProvider");
                Assert.IsInstanceOf<XamlValueTargetProvider>(testingTarget, "Should return XamlValueTargetProvider instance.");

                object object1 = testingTarget.TargetProperty;
                testingTarget.TargetProperty = object1;
                Assert.AreEqual(object1, testingTarget.TargetProperty, "Should be equal");
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            tlog.Debug(tag, $"XamlServiceProviderTargetProperty END");
        }

        [Test]
        [Category("P1")]
        [Description("XamlServiceProvider SimpleValueTargetProvider")]
        [Property("SPEC", "Tizen.NUI.XamlServiceProvider.SimpleValueTargetProvider M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        public void XamlServiceProviderSimpleValueTargetProvider1()
        {
            tlog.Debug(tag, $"XamlServiceProviderTargetProperty START");

            try
            {
                object o11 = new object();
                object o12 = new object();
                object[] o1 = { o11, o12, };

                var testingTarget = new SimpleValueTargetProvider(o1);
                Assert.IsNotNull(testingTarget, "null SimpleValueTargetProvider");
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            tlog.Debug(tag, $"XamlServiceProviderTargetProperty END");
        }

        [Test]
        [Category("P1")]
        [Description("XamlServiceProvider SimpleValueTargetProvider")]
        [Property("SPEC", "Tizen.NUI.XamlServiceProvider.SimpleValueTargetProvider M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        public void XamlServiceProviderSimpleValueTargetProvider2()
        {
            tlog.Debug(tag, $"XamlServiceProviderTargetProperty START");

            try
            {
                object o11 = new object();
                object o12 = new object();
                object[] o1 = { o11, o12, };

                object targetObject = new object();
                var testingTarget = new SimpleValueTargetProvider(o1, targetObject);
                Assert.IsNotNull(testingTarget, "null SimpleValueTargetProvider");
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            tlog.Debug(tag, $"XamlServiceProviderTargetProperty END");
        }

        [Test]
        [Category("P1")]
        [Description("XamlServiceProvider FindByName")]
        [Property("SPEC", "Tizen.NUI.XamlServiceProvider.FindByName M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        public void XamlServiceProviderFindByName()
        {
            tlog.Debug(tag, $"XamlServiceProviderFindByName START");

            try
            {
                object o11 = new object();
                object o12 = new object();
                object[] o1 = { o11, o12, };

                object targetObject = new object();
                var testingTarget = new SimpleValueTargetProvider(o1, targetObject);
                testingTarget.FindByName("mystring");
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            tlog.Debug(tag, $"XamlServiceProviderFindByName END");
        }
    }
}