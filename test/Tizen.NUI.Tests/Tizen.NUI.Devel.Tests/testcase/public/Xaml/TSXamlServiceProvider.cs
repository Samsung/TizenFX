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
    internal class PublicXamlServiceProviderTest
    {
        private const string tag = "NUITEST";
        public XamlServiceProvider x1;
        [SetUp]
        public void Init()
        {
            tlog.Info(tag, "Init() is called!");
            x1 = new XamlServiceProvider();
        }

        [TearDown]
        public void Destroy()
        {
            x1 = null;
            tlog.Info(tag, "Destroy() is called!");
        }

        internal class INodeImplement : INode
        {
            public List<string> IgnorablePrefixes { get; set; }
            public IXmlNamespaceResolver NamespaceResolver => new XmlNamespaceResolver();
            public INode Parent { get; set; }
            public void Accept(IXamlNodeVisitor visitor, INode parentNode) { }
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
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void XamlServiceProviderConstructor()
        {
            tlog.Debug(tag, $"XamlServiceProviderConstructor START");

            var testingTarget = new XamlServiceProvider();
            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<XamlServiceProvider>(testingTarget, "should be an instance of XamlServiceProvider class!");

            tlog.Debug(tag, $"XamlServiceProviderConstructor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("XamlServiceProvider XamlServiceProvider. With parameters.")]
        [Property("SPEC", "Tizen.NUI.XamlServiceProvider.XamlServiceProvider C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void XamlServiceProviderConstructorWithParameters()
        {
            tlog.Debug(tag, $"XamlServiceProviderConstructorWithParameters START");

            HydrationContext hydrationContext = new HydrationContext();
            INodeImplement nodeImplement = new INodeImplement();

            try
            {
                var testingTarget = new XamlServiceProvider(nodeImplement, hydrationContext);
                Assert.IsNotNull(testingTarget, "should be not null");
                Assert.IsInstanceOf<XamlServiceProvider>(testingTarget, "should be an instance of XamlServiceProvider class!");
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            tlog.Debug(tag, $"XamlServiceProviderConstructorWithParameters END (OK)");
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
                IProvideValueTarget i1 = x1.IProvideValueTarget;
                x1.IProvideValueTarget = i1;
            }
            catch (Exception e)
            {
                Tizen.Log.Error(tag, "Caught Exception" + e.ToString());
                Assert.Fail("Caught Exception" + e.ToString());
            }

            tlog.Debug(tag, $"XamlServiceProviderIProvideValueTarget END (OK)");
            Assert.Pass("XamlServiceProviderIProvideValueTarget");
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
                IXamlTypeResolver i1 = x1.IXamlTypeResolver;
                x1.IXamlTypeResolver = i1;
            }
            catch (Exception e)
            {
                Tizen.Log.Error(tag, "Caught Exception" + e.ToString());
                Assert.Fail("Caught Exception" + e.ToString());
            }

            tlog.Debug(tag, $"XamlServiceProviderIXamlTypeResolver END (OK)");
            Assert.Pass("XamlServiceProviderIXamlTypeResolver");
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
                IRootObjectProvider i1 = x1.IRootObjectProvider;
                x1.IRootObjectProvider = i1;
            }
            catch (Exception e)
            {
                Tizen.Log.Error(tag, "Caught Exception" + e.ToString());
                Assert.Fail("Caught Exception" + e.ToString());
            }

            tlog.Debug(tag, $"XamlServiceProviderIRootObjectProvider END (OK)");
            Assert.Pass("XamlServiceProviderIRootObjectProvider");
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
                IXmlLineInfoProvider i1 = x1.IXmlLineInfoProvider;
                x1.IXmlLineInfoProvider = i1;
            }
            catch (Exception e)
            {
                Tizen.Log.Error(tag, "Caught Exception" + e.ToString());
                Assert.Fail("Caught Exception" + e.ToString());
            }

            tlog.Debug(tag, $"XamlServiceProviderIXmlLineInfoProvider END (OK)");
            Assert.Pass("XamlServiceProviderIXmlLineInfoProvider");
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
                INameScopeProvider i1 = x1.INameScopeProvider;
                x1.INameScopeProvider = i1;
            }
            catch (Exception e)
            {
                Tizen.Log.Error(tag, "Caught Exception" + e.ToString());
                Assert.Fail("Caught Exception" + e.ToString());
            }

            tlog.Debug(tag, $"XamlServiceProviderINameScopeProvider END (OK)");
            Assert.Pass("XamlServiceProviderINameScopeProvider");
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
                IValueConverterProvider i1 = x1.IValueConverterProvider;
                x1.IValueConverterProvider = i1;
            }
            catch (Exception e)
            {
                Tizen.Log.Error(tag, "Caught Exception" + e.ToString());
                Assert.Fail("Caught Exception" + e.ToString());
            }

            tlog.Debug(tag, $"XamlServiceProviderIValueConverterProvider END (OK)");
            Assert.Pass("XamlServiceProviderIValueConverterProvider");
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
                x1.GetService(typeof(string));
            }
            catch (Exception e)
            {
                Tizen.Log.Error(tag, "Caught Exception" + e.ToString());
                Assert.Fail("Caught Exception" + e.ToString());
            }

            tlog.Debug(tag, $"XamlServiceProviderGetService END (OK)");
            Assert.Pass("XamlServiceProviderGetService");
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
                object o1 = new object();
                x1.Add(typeof(string), o1);
            }
            catch (Exception e)
            {
                Tizen.Log.Error(tag, "Caught Exception" + e.ToString());
                Assert.Fail("Caught Exception" + e.ToString());
            }

            tlog.Debug(tag, $"XamlServiceProviderAdd END (OK)");
            Assert.Pass("XamlServiceProviderAdd");
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
                INodeImplement node = new INodeImplement();
                HydrationContext hydrationContext = new HydrationContext();
                object o2 = new object();

                XamlValueTargetProvider xamlValueTargetProvider = new XamlValueTargetProvider(o1, node, hydrationContext, o2);

            }
            catch (Exception e)
            {
                Tizen.Log.Error(tag, "Caught Exception" + e.ToString());
                Assert.Fail("Caught Exception" + e.ToString());
            }

            tlog.Debug(tag, $"XamlServiceProviderXamlValueTargetProvider END (OK)");
            Assert.Pass("XamlServiceProviderXamlValueTargetProvider");
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
                INodeImplement node = new INodeImplement();
                HydrationContext hydrationContext = new HydrationContext();
                object o2 = new object();

                XamlValueTargetProvider xamlValueTargetProvider = new XamlValueTargetProvider(o1, node, hydrationContext, o2);
                object object1 = xamlValueTargetProvider.TargetObject;
            }
            catch (Exception e)
            {
                Tizen.Log.Error(tag, "Caught Exception" + e.ToString());
                Assert.Fail("Caught Exception" + e.ToString());
            }

            tlog.Debug(tag, $"XamlServiceProviderTargetObject END (OK)");
            Assert.Pass("XamlServiceProviderTargetObject");
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
                INodeImplement node = new INodeImplement();
                HydrationContext hydrationContext = new HydrationContext();
                object o2 = new object();

                XamlValueTargetProvider xamlValueTargetProvider = new XamlValueTargetProvider(o1, node, hydrationContext, o2);
                object object1 = xamlValueTargetProvider.TargetProperty;
                xamlValueTargetProvider.TargetProperty = object1;
            }
            catch (Exception e)
            {
                Tizen.Log.Error(tag, "Caught Exception" + e.ToString());
                Assert.Fail("Caught Exception" + e.ToString());
            }

            tlog.Debug(tag, $"XamlServiceProviderTargetProperty END (OK)");
            Assert.Pass("XamlServiceProviderTargetProperty");
        }

        [Test]
        [Category("P1")]
        [Description("XamlServiceProvider SimpleValueTargetProvider")]
        [Property("SPEC", "Tizen.NUI.XamlServiceProvider.SimpleValueTargetProvider M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Obsolete]
        public void XamlServiceProviderSimpleValueTargetProvider1()
        {
            tlog.Debug(tag, $"XamlServiceProviderTargetProperty START");

            try
            {
                object o11 = new object();
                object o12 = new object();
                object[] o1 = { o11, o12, };
                SimpleValueTargetProvider simpleValueTargetProvider1 = new SimpleValueTargetProvider(o1);
            }
            catch (Exception e)
            {
                Tizen.Log.Error(tag, "Caught Exception" + e.ToString());
                Assert.Fail("Caught Exception" + e.ToString());
            }

            tlog.Debug(tag, $"XamlServiceProviderTargetProperty END (OK)");
            Assert.Pass("XamlServiceProviderTargetProperty");
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
                SimpleValueTargetProvider simpleValueTargetProvider2 = new SimpleValueTargetProvider(o1, targetObject);
            }
            catch (Exception e)
            {
                Tizen.Log.Error(tag, "Caught Exception" + e.ToString());
                Assert.Fail("Caught Exception" + e.ToString());
            }

            tlog.Debug(tag, $"XamlServiceProviderTargetProperty END (OK)");
            Assert.Pass("XamlServiceProviderTargetProperty");
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
                SimpleValueTargetProvider simpleValueTargetProvider = new SimpleValueTargetProvider(o1, targetObject);
                simpleValueTargetProvider.FindByName("mystring");
            }
            catch (Exception e)
            {
                Tizen.Log.Error(tag, "Caught Exception" + e.ToString());
                Assert.Fail("Caught Exception" + e.ToString());
            }

            tlog.Debug(tag, $"XamlServiceProviderFindByName END (OK)");
            Assert.Pass("XamlServiceProviderFindByName");
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
                object o2 = x1.RootObject;
            }
            catch (Exception e)
            {
                Tizen.Log.Error(tag, "Caught Exception" + e.ToString());
                Assert.Fail("Caught Exception" + e.ToString());
            }

            tlog.Debug(tag, $"XamlServiceProviderRootObject END (OK)");
            Assert.Pass("XamlServiceProviderRootObject");
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
            }
            catch (Exception e)
            {
                Tizen.Log.Error(tag, "Caught Exception" + e.ToString());
                Assert.Fail("Caught Exception" + e.ToString());
            }

            tlog.Debug(tag, $"XamlServiceProviderXmlLineInfoProvider END (OK)");
            Assert.Pass("XamlServiceProviderXmlLineInfoProvider");
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

                IXmlLineInfo i1 = x1.XmlLineInfo;
            }
            catch (Exception e)
            {
                Tizen.Log.Error(tag, "Caught Exception" + e.ToString());
                Assert.Fail("Caught Exception" + e.ToString());
            }

            tlog.Debug(tag, $"XamlServiceProviderXmlLineInfo END (OK)");
            Assert.Pass("XamlServiceProviderXmlLineInfo");
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
            }
            catch (Exception e)
            {
                Tizen.Log.Error(tag, "Caught Exception" + e.ToString());
                Assert.Fail("Caught Exception" + e.ToString());
            }

            tlog.Debug(tag, $"XamlServiceProviderReferenceProvider END (OK)");
            Assert.Pass("XamlServiceProviderReferenceProvider");
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
                referenceProvider.FindByName("myName");
            }
            catch (Exception e)
            {
                Tizen.Log.Error(tag, "Caught Exception" + e.ToString());
                Assert.Fail("Caught Exception" + e.ToString());
            }

            tlog.Debug(tag, $"XamlServiceProviderReferenceProviderFindByName END (OK)");
            Assert.Pass("XamlServiceProviderReferenceProviderFindByName");
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
                INameScope i1 = n1.NameScope;
                n1.NameScope = i1;
            }
            catch (Exception e)
            {
                Tizen.Log.Error(tag, "Caught Exception" + e.ToString());
                Assert.Fail("Caught Exception" + e.ToString());
            }

            tlog.Debug(tag, $"XamlServiceProviderNameScope END (OK)");
            Assert.Pass("XamlServiceProviderNameScope");
        }

        [Test]
        [Category("P1")]
        [Description("XamlServiceProvider GetNamespacesInScope")]
        [Property("SPEC", "Tizen.NUI.XamlServiceProvider.GetNamespacesInScope M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        public void XamlServiceProviderGetNamespacesInScope()
        {
            tlog.Debug(tag, $"XamlServiceProviderGetNamespacesInScope START");

            try
            {
                XmlNamespaceResolver xmlNamespaceResolver = new XmlNamespaceResolver();
                XmlNamespaceScope xmlNamespaceScope = new XmlNamespaceScope();
                xmlNamespaceResolver.GetNamespacesInScope(xmlNamespaceScope);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                tlog.Debug(tag, $"XamlServiceProviderGetNamespacesInScope END (OK)");
                Assert.Pass("Caught Exception : passed!");
            }
        }

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
                xmlNamespaceResolver.LookupNamespace("myPrefix");
            }
            catch (Exception e)
            {
                Tizen.Log.Error(tag, "Caught Exception" + e.ToString());
                Assert.Fail("Caught Exception" + e.ToString());
            }

            tlog.Debug(tag, $"XamlServiceProviderLookupNamespace END (OK)");
            Assert.Pass("XamlServiceProviderLookupNamespace");
        }

        [Test]
        [Category("P1")]
        [Description("XamlServiceProvider LookupPrefix")]
        [Property("SPEC", "Tizen.NUI.XamlServiceProvider.LookupPrefix M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        public void XamlServiceProviderLookupPrefix()
        {
            tlog.Debug(tag, $"XamlServiceProviderLookupPrefix START");

            try
            {
                XmlNamespaceResolver xmlNamespaceResolver = new XmlNamespaceResolver();
                xmlNamespaceResolver.LookupPrefix("mynameSpaceName");
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                tlog.Debug(tag, $"XamlServiceProviderLookupPrefix END (OK)");
                Assert.Pass("Caught Exception : passed!");
            }
        }

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
                xmlNamespaceResolver.Add("myPrefix", "myNs");
            }
            catch (Exception e)
            {
                Tizen.Log.Error(tag, "Caught Exception" + e.ToString());
                Assert.Fail("Caught Exception" + e.ToString());
            }

            tlog.Debug(tag, $"XamlServiceProviderXmlNamespaceResolverAdd END (OK)");
            Assert.Pass("XamlServiceProviderXmlNamespaceResolverAdd");
        }
    }
}