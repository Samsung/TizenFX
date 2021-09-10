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

        //[Test]
        //[Category("P1")]
        //[Description("XamlServiceProvider XamlServiceProvider")]
        //[Property("SPEC", "Tizen.NUI.XamlServiceProvider.XamlServiceProvider C")]
        //[Property("SPEC_URL", "-")]
        //[Property("CRITERIA", "CONSTR")]
        //public void XamlServiceProviderConstructor2()
        //{
        //    tlog.Debug(tag, $"XamlServiceProviderConstructor START");

        //    HydrationContext hydrationContext = new HydrationContext();
        //    INodeImplement nodeImplement = new INodeImplement();
        //    XamlServiceProvider xamlServiceProvider2 = new XamlServiceProvider(nodeImplement, hydrationContext);
        //    Assert.IsNotNull(xamlServiceProvider2, "null XamlServiceProvider");
        //    Assert.IsInstanceOf<XamlServiceProvider>(xamlServiceProvider2, "Should return XamlServiceProvider instance.");
        //    tlog.Debug(tag, $"XamlServiceProviderConstructor END");
        //}

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

        public class IXmlNamespaceResolverImplement : IXmlNamespaceResolver
        {
            public IDictionary<string, string> GetNamespacesInScope(XmlNamespaceScope scope)
            {
                return null;
            }

            public string LookupNamespace(string prefix)
            {
                return "mySpace";
            }

            public string LookupPrefix(string namespaceName)
            {
                return "myPrefix";
            }
        }

        public class AssemblyImplement : Assembly
        {

        }

        [Test]
        [Category("P1")]
        [Description("XamlServiceProvider XamlTypeResolver")]
        [Property("SPEC", "Tizen.NUI.XamlServiceProvider.XamlTypeResolver M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        public void XamlServiceProviderXamlTypeResolver()
        {
            tlog.Debug(tag, $"XamlServiceProviderXamlTypeResolver START");

            try
            {
                IXmlNamespaceResolverImplement xmlNamespaceResolverImplement = new IXmlNamespaceResolverImplement();
                AssemblyImplement currentAssembly = new AssemblyImplement();
                XamlTypeResolver xamlTypeResolver = new XamlTypeResolver(xmlNamespaceResolverImplement, currentAssembly);
                Assert.IsNotNull(xamlTypeResolver, "null XamlTypeResolver");
            }
            catch (Exception e)
            {
                Tizen.Log.Error(tag, "Caught Exception" + e.ToString());
                Assert.Fail("Caught Exception" + e.ToString());
            }

            tlog.Debug(tag, $"XamlServiceProviderXamlTypeResolver END (OK)");
            Assert.Pass("XamlServiceProviderXamlTypeResolver");
        }

        [Test]
        [Category("P1")]
        [Description("XamlServiceProvider RootObject")]
        [Property("SPEC", "Tizen.NUI.XamlServiceProvider.RootObject A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        public void XamlServiceProviderRootObject()
        {
            tlog.Debug(tag, $"XamlServiceProviderRootObject START");

            try
            {
                object o1 = new object();
                XamlRootObjectProvider x1 = new XamlRootObjectProvider(o1);
                Assert.IsNotNull(x1, "null XamlRootObjectProvider");
                object o2 = x1.RootObject;
                Assert.IsNotNull(o2, "null object");
            }
            catch (Exception e)
            {
                Tizen.Log.Error(tag, "Caught Exception" + e.ToString());
                Assert.Fail("Caught Exception" + e.ToString());
            }

            tlog.Debug(tag, $"XamlServiceProviderRootObject END");
        }

        public class IXmlLineInfoImplement : IXmlLineInfo
        {
            public int LineNumber
            {
                get => 1;
                set { }
            }


            public int LinePosition => throw new NotImplementedException();

            public bool HasLineInfo()
            {
                return true;
            }
        }

        [Test]
        [Category("P1")]
        [Description("XamlServiceProvider XmlLineInfoProvider")]
        [Property("SPEC", "Tizen.NUI.XamlServiceProvider.XmlLineInfoProvider M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        public void XamlServiceProviderXmlLineInfoProvider()
        {
            tlog.Debug(tag, $"XamlServiceProviderXmlLineInfoProvider START");

            try
            {
                IXmlLineInfoImplement xmlLineInfo = new IXmlLineInfoImplement();
                XmlLineInfoProvider x1 = new XmlLineInfoProvider(xmlLineInfo);
                Assert.IsNotNull(x1, "null XmlLineInfoProvider");
            }
            catch (Exception e)
            {
                Tizen.Log.Error(tag, "Caught Exception" + e.ToString());
                Assert.Fail("Caught Exception" + e.ToString());
            }

            tlog.Debug(tag, $"XamlServiceProviderXmlLineInfoProvider END");
        }

        [Test]
        [Category("P1")]
        [Description("XamlServiceProvider XmlLineInfo")]
        [Property("SPEC", "Tizen.NUI.XamlServiceProvider.XmlLineInfo A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        public void XamlServiceProviderXmlLineInfo()
        {
            tlog.Debug(tag, $"XamlServiceProviderXmlLineInfo START");

            try
            {
                IXmlLineInfoImplement xmlLineInfo = new IXmlLineInfoImplement();
                XmlLineInfoProvider x1 = new XmlLineInfoProvider(xmlLineInfo);
                Assert.IsNotNull(x1, "null XmlLineInfoProvider");
                IXmlLineInfo i1 = x1.XmlLineInfo;
            }
            catch (Exception e)
            {
                Tizen.Log.Error(tag, "Caught Exception" + e.ToString());
                Assert.Fail("Caught Exception" + e.ToString());
            }

            tlog.Debug(tag, $"XamlServiceProviderXmlLineInfo END");
        }

        [Test]
        [Category("P1")]
        [Description("XamlServiceProvider ReferenceProvider")]
        [Property("SPEC", "Tizen.NUI.XamlServiceProvider.ReferenceProvider A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        public void XamlServiceProviderReferenceProvider()
        {
            tlog.Debug(tag, $"XamlServiceProviderReferenceProvider START");

            try
            {
                INodeImplement i1 = new INodeImplement();
                ReferenceProvider referenceProvider = new ReferenceProvider(i1);
                Assert.IsNotNull(referenceProvider, "null ReferenceProvider");
            }
            catch (Exception e)
            {
                Tizen.Log.Error(tag, "Caught Exception" + e.ToString());
                Assert.Fail("Caught Exception" + e.ToString());
            }

            tlog.Debug(tag, $"XamlServiceProviderReferenceProvider END");
        }

        [Test]
        [Category("P1")]
        [Description("XamlServiceProvider FindByName")]
        [Property("SPEC", "Tizen.NUI.XamlServiceProvider.FindByName M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        public void XamlServiceProviderReferenceProviderFindByName()
        {
            tlog.Debug(tag, $"XamlServiceProviderReferenceProviderFindByName START");

            try
            {
                INodeImplement i1 = new INodeImplement();
                ReferenceProvider referenceProvider = new ReferenceProvider(i1);
                Assert.IsNotNull(referenceProvider, "null ReferenceProvider");
                referenceProvider.FindByName("myName");
            }
            catch (Exception e)
            {
                Tizen.Log.Error(tag, "Caught Exception" + e.ToString());
                Assert.Fail("Caught Exception" + e.ToString());
            }

            tlog.Debug(tag, $"XamlServiceProviderReferenceProviderFindByName END");
        }

        [Test]
        [Category("P1")]
        [Description("XamlServiceProvider NameScope")]
        [Property("SPEC", "Tizen.NUI.XamlServiceProvider.NameScope A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        public void XamlServiceProviderNameScope()
        {
            tlog.Debug(tag, $"XamlServiceProviderNameScope START");

            try
            {
                NameScopeProvider n1 = new NameScopeProvider();
                Assert.IsNotNull(n1, "null NameScopeProvider");
                INameScope i1 = n1.NameScope;
                n1.NameScope = i1;
                Assert.AreEqual(i1, n1.NameScope, "Should be equal");
            }
            catch (Exception e)
            {
                Tizen.Log.Error(tag, "Caught Exception" + e.ToString());
                Assert.Fail("Caught Exception" + e.ToString());
            }

            tlog.Debug(tag, $"XamlServiceProviderNameScope END");
        }

        //[Test]
        //[Category("P1")]
        //[Description("XamlServiceProvider GetNamespacesInScope")]
        //[Property("SPEC", "Tizen.NUI.XamlServiceProvider.GetNamespacesInScope M")]
        //[Property("SPEC_URL", "-")]
        //[Property("CRITERIA", "MR")]
        //public void XamlServiceProviderGetNamespacesInScope()
        //{
        //    tlog.Debug(tag, $"XamlServiceProviderGetNamespacesInScope START");

        //    try
        //    {
        //        XmlNamespaceResolver xmlNamespaceResolver = new XmlNamespaceResolver();
        //        Assert.IsNotNull(xmlNamespaceResolver, "null XmlNamespaceResolver");
        //        XmlNamespaceScope xmlNamespaceScope = new XmlNamespaceScope();
        //        Assert.IsNotNull(xmlNamespaceScope, "null XmlNamespaceScope");
        //        xmlNamespaceResolver.GetNamespacesInScope(xmlNamespaceScope);
        //    }
        //    catch (Exception e)
        //    {
        //        Assert.Fail("Caught Exception" + e.ToString());
        //    }
        //    tlog.Debug(tag, $"XamlServiceProviderGetNamespacesInScope END");
        //}

        [Test]
        [Category("P1")]
        [Description("XamlServiceProvider LookupNamespace")]
        [Property("SPEC", "Tizen.NUI.XamlServiceProvider.LookupNamespace M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        public void XamlServiceProviderLookupNamespace()
        {
            tlog.Debug(tag, $"XamlServiceProviderLookupNamespace START");

            try
            {
                XmlNamespaceResolver xmlNamespaceResolver = new XmlNamespaceResolver();
                Assert.IsNotNull(xmlNamespaceResolver, "null XmlNamespaceResolver");
                xmlNamespaceResolver.LookupNamespace("myPrefix");
            }
            catch (Exception e)
            {
                Tizen.Log.Error(tag, "Caught Exception" + e.ToString());
                Assert.Fail("Caught Exception" + e.ToString());
            }

            tlog.Debug(tag, $"XamlServiceProviderLookupNamespace END");
        }

        //[Test]
        //[Category("P1")]
        //[Description("XamlServiceProvider LookupPrefix")]
        //[Property("SPEC", "Tizen.NUI.XamlServiceProvider.LookupPrefix M")]
        //[Property("SPEC_URL", "-")]
        //[Property("CRITERIA", "MR")]
        //public void XamlServiceProviderLookupPrefix()
        //{
        //    tlog.Debug(tag, $"XamlServiceProviderLookupPrefix START");

        //    try
        //    {
        //        XmlNamespaceResolver xmlNamespaceResolver = new XmlNamespaceResolver();
        //        Assert.IsNotNull(xmlNamespaceResolver, "null XmlNamespaceResolver");
        //        xmlNamespaceResolver.LookupPrefix("mynameSpaceName");
        //    }
        //    catch (Exception e)
        //    {
        //        Assert.Fail("Caught Exception" + e.ToString());
        //    }
        //    tlog.Debug(tag, $"XamlServiceProviderLookupPrefix END");
        //}

        [Test]
        [Category("P1")]
        [Description("XamlServiceProvider Add")]
        [Property("SPEC", "Tizen.NUI.XamlServiceProvider.Add M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        public void XamlServiceProviderXmlNamespaceResolverAdd()
        {
            tlog.Debug(tag, $"XamlServiceProviderXmlNamespaceResolverAdd START");

            try
            {
                XmlNamespaceResolver xmlNamespaceResolver = new XmlNamespaceResolver();
                Assert.IsNotNull(xmlNamespaceResolver, "null XmlNamespaceResolver");
                xmlNamespaceResolver.Add("myPrefix", "myNs");
            }
            catch (Exception e)
            {
                Tizen.Log.Error(tag, "Caught Exception" + e.ToString());
                Assert.Fail("Caught Exception" + e.ToString());
            }

            tlog.Debug(tag, $"XamlServiceProviderXmlNamespaceResolverAdd END");
        }
    }
}