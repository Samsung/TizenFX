using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Xml;
using Tizen.NUI.Xaml;
using static Tizen.NUI.Xaml.ExpandMarkupsVisitor;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("internal/Xaml/ExpandMarkupsVisitor")]
    public class InternalExpandMarkupsVisitorTest
    {
        private const string tag = "NUITEST";
        private ExpandMarkupsVisitor visitor;

        internal class INodeImpl : INode
        {
            public global::System.Collections.Generic.List<string> IgnorablePrefixes { get; set; }
            public global::System.Xml.IXmlNamespaceResolver NamespaceResolver => new INodeImpl().NamespaceResolver;
            public INode Parent { get; set; }
            public void Accept(IXamlNodeVisitor visitor, INode parentNode) { }
            public INode Clone() { return new INodeImpl(); }
        }

        [SetUp]
        public void Init()
        {
            tlog.Info(tag, "Init() is called!");
            visitor = new ExpandMarkupsVisitor(new HydrationContext());
        }

        [TearDown]
        public void Destroy()
        {
            visitor = null;
            tlog.Info(tag, "Destroy() is called!");
        }

        [Test]
        [Category("P1")]
        [Description("ExpandMarkupsVisitor ExpandMarkupsVisitor")]
        [Property("SPEC", "Tizen.NUI.ExpandMarkupsVisitor.ExpandMarkupsVisitor C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        public void ExpandMarkupsVisitorConstructor()
        {
            tlog.Debug(tag, $"ApplyPropertiesVisitorConstructor START");

            HydrationContext context = new HydrationContext();
            Assert.IsNotNull(context, "null HydrationContext");
            Assert.IsInstanceOf<HydrationContext>(context, "Should return HydrationContext instance.");

            ExpandMarkupsVisitor expandMarkupsVisitor = new ExpandMarkupsVisitor(context);
            Assert.IsNotNull(expandMarkupsVisitor, "null ExpandMarkupsVisitor");
            Assert.IsInstanceOf<ExpandMarkupsVisitor>(expandMarkupsVisitor, "Should return ExpandMarkupsVisitor instance.");

            tlog.Debug(tag, $"ExpandMarkupsVisitorConstructor END");
        }

        [Test]
        [Category("P1")]
        [Description("ExpandMarkupsVisitor VisitingMode")]
        [Property("SPEC", "Tizen.NUI.ExpandMarkupsVisitor.VisitingMode A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        public void ExpandMarkupsVisitorVisitingMode()
        {
            tlog.Debug(tag, $"ExpandMarkupsVisitorVisitingMode START");

            try
            {
                var result = visitor.VisitingMode;
                tlog.Debug(tag, "VisitingMode : " + result);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            tlog.Debug(tag, $"ExpandMarkupsVisitorVisitingMode END");
        }

        [Test]
        [Category("P1")]
        [Description("ExpandMarkupsVisitor StopOnDataTemplate")]
        [Property("SPEC", "Tizen.NUI.ExpandMarkupsVisitor.StopOnDataTemplate A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        public void ExpandMarkupsVisitorStopOnDataTemplate()
        {
            tlog.Debug(tag, $"ExpandMarkupsVisitorStopOnDataTemplate START");

            try
            {
                var result = visitor.StopOnDataTemplate;
                tlog.Debug(tag, "StopOnDataTemplate : " + result);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            tlog.Debug(tag, $"ExpandMarkupsVisitorStopOnDataTemplate END");
        }

        [Test]
        [Category("P1")]
        [Description("ExpandMarkupsVisitor StopOnResourceDictionary")]
        [Property("SPEC", "Tizen.NUI.ExpandMarkupsVisitor.StopOnResourceDictionary A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        public void ExpandMarkupsVisitorStopOnResourceDictionary()
        {
            tlog.Debug(tag, $"ExpandMarkupsVisitorStopOnResourceDictionary START");

            try
            {
                var result = visitor.StopOnResourceDictionary;
                tlog.Debug(tag, "StopOnResourceDictionary : " + result);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            tlog.Debug(tag, $"ExpandMarkupsVisitorStopOnResourceDictionary END");
        }

        [Test]
        [Category("P1")]
        [Description("ExpandMarkupsVisitor VisitNodeOnDataTemplate")]
        [Property("SPEC", "Tizen.NUI.ExpandMarkupsVisitor.VisitNodeOnDataTemplate A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        public void ExpandMarkupsVisitorVisitNodeOnDataTemplate()
        {
            tlog.Debug(tag, $"ExpandMarkupsVisitorVisitNodeOnDataTemplate START");

            try
            {
                var result = visitor.VisitNodeOnDataTemplate;
                tlog.Debug(tag, "VisitNodeOnDataTemplate : " + result);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            tlog.Debug(tag, $"ExpandMarkupsVisitorVisitNodeOnDataTemplate END");
        }

        [Test]
        [Category("P1")]
        [Description("ExpandMarkupsVisitor SkipChildren")]
        [Property("SPEC", "Tizen.NUI.ExpandMarkupsVisitor.SkipChildren M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        public void ExpandMarkupsVisitorSkipChildren()
        {
            tlog.Debug(tag, $"ExpandMarkupsVisitorSkipChildren START");

            try
            {
                var child = new INodeImpl();
                Assert.IsNotNull(child, "null INodeImpl");

                var parent = new INodeImpl();
                Assert.IsNotNull(parent, "null INodeImpl");

                var result = visitor.SkipChildren(child, parent);
                tlog.Debug(tag, "SkipChildren : " + result);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            tlog.Debug(tag, $"ExpandMarkupsVisitorSkipChildren END");
        }

        public class IXmlNamespaceResolverImplement : IXmlNamespaceResolver
        {
            public IDictionary<string, string> GetNamespacesInScope(XmlNamespaceScope scope)
            {
                throw new NotImplementedException();
            }

            public string LookupNamespace(string prefix)
            {
                throw new NotImplementedException();
            }

            public string LookupPrefix(string namespaceName)
            {
                throw new NotImplementedException();
            }
        }

        [Test]
        [Category("P1")]
        [Description("ExpandMarkupsVisitor IsResourceDictionary")]
        [Property("SPEC", "Tizen.NUI.ExpandMarkupsVisitor.IsResourceDictionary M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        public void ExpandMarkupsVisitorIsResourceDictionary()
        {
            tlog.Debug(tag, $"ExpandMarkupsVisitorIsResourceDictionary START");

            try
            {
                IList<XmlType> list = null;
                XmlType xmlType = new XmlType("myNameSpace", "myName", list);
                Assert.IsNotNull(xmlType, "null XmlType");

                IXmlNamespaceResolverImplement i1 = new IXmlNamespaceResolverImplement();
                Assert.IsNotNull(i1, "null IXmlNamespaceResolverImplement");
                ElementNode n1 = new ElementNode(xmlType, "myNameSpace", i1);
                Assert.IsNotNull(n1, "null ElementNode");

                bool b1 = visitor.IsResourceDictionary(n1);
            }
            catch (Exception e)
            {
                Tizen.Log.Error(tag, "Caught Exception" + e.ToString());
                Assert.Fail("Caught Exception" + e.ToString());
            }

            tlog.Debug(tag, $"ExpandMarkupsVisitorIsResourceDictionary END");
        }

        [Test]
        [Category("P1")]
        [Description("ExpandMarkupsVisitor Visit")]
        [Property("SPEC", "Tizen.NUI.ExpandMarkupsVisitor.Visit M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        public void ExpandMarkupsVisitorVisit()
        {
            tlog.Debug(tag, $"ExpandMarkupsVisitorVisit START");

            try
            {
                IXmlNamespaceResolverImplement i1 = new IXmlNamespaceResolverImplement();
                Assert.IsNotNull(i1, "null IXmlNamespaceResolverImplement");
                MarkupNode markupnode = new MarkupNode("markup", i1);
                Assert.IsNotNull(markupnode, "null MarkupNode");
                INodeImpl parentNode = new INodeImpl();
                Assert.IsNotNull(parentNode, "null INodeImplement");
                visitor.Visit(markupnode, parentNode);
            }
            catch (Exception e)
            {
                Tizen.Log.Error(tag, "Caught Exception" + e.ToString());
                Assert.Fail("Caught Exception" + e.ToString());
            }

            tlog.Debug(tag, $"ExpandMarkupsVisitorVisit END");
        }

        public class IServiceProviderImplement : IServiceProvider
        {
            public object GetService(Type serviceType)
            {
                throw new NotImplementedException();
            }
        }

        //[Test]
        //[Category("P1")]
        //[Description("ExpandMarkupsVisitor Parse")]
        //[Property("SPEC", "Tizen.NUI.ExpandMarkupsVisitor.MarkupExpansionParser.Parse M")]
        //[Property("SPEC_URL", "-")]
        //[Property("CRITERIA", "MR")]
        //public void ExpandMarkupsVisitorParse()
        //{
        //    tlog.Debug(tag, $"ExpandMarkupsVisitorParse START");

        //    try
        //    {
        //        MarkupExpansionParser markupExpansionParser = new MarkupExpansionParser();
        //        Assert.IsNotNull(markupExpansionParser, "null MarkupExpansionParser");
        //        IServiceProviderImplement serviceProviderImplement = new IServiceProviderImplement();
        //        Assert.IsNotNull(serviceProviderImplement, "null IServiceProviderImplement");

        //        string s1 = new string('a', 4);
        //        markupExpansionParser.Parse("matchString", ref s1, serviceProviderImplement);
        //    }
        //    catch (Exception e)
        //    {
        //        tlog.Debug(tag, e.Message.ToString());
        //        Assert.Fail("Caught Exception" + e.ToString());
        //    }
        //    tlog.Debug(tag, $"ExpandMarkupsVisitorParse END");
        //}
    }
}