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
        private ExpandMarkupsVisitor e1;

        [SetUp]
        public void Init()
        {
            tlog.Info(tag, "Init() is called!");
            HydrationContext context = new HydrationContext();

            e1 = new ExpandMarkupsVisitor(context);
        }

        [TearDown]
        public void Destroy()
        {
            e1 = null;
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

            ExpandMarkupsVisitor expandMarkupsVisitor = new ExpandMarkupsVisitor(context);

            tlog.Debug(tag, $"ExpandMarkupsVisitorConstructor END (OK)");
            Assert.Pass("ExpandMarkupsVisitorConstructor");
        }

        [Test]
        [Category("P1")]
        [Description("ExpandMarkupsVisitor Skips")]
        [Property("SPEC", "Tizen.NUI.ExpandMarkupsVisitor.Skips A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        public void ExpandMarkupsVisitorSkips()
        {
            tlog.Debug(tag, $"ExpandMarkupsVisitorSkips START");

            try
            {
                IList<XmlName> l1 = ExpandMarkupsVisitor.Skips;
            }
            catch (Exception e)
            {
                Tizen.Log.Error(tag, "Caught Exception" + e.ToString());
                Assert.Fail("Caught Exception" + e.ToString());
            }

            tlog.Debug(tag, $"ExpandMarkupsVisitorSkips END (OK)");
            Assert.Pass("ExpandMarkupsVisitorSkips");
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
                TreeVisitingMode t1 = e1.VisitingMode;
            }
            catch (Exception e)
            {
                Tizen.Log.Error(tag, "Caught Exception" + e.ToString());
                Assert.Fail("Caught Exception" + e.ToString());
            }

            tlog.Debug(tag, $"ExpandMarkupsVisitorVisitingMode END (OK)");
            Assert.Pass("ExpandMarkupsVisitorVisitingMode");
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
                bool b1 = e1.StopOnDataTemplate;
            }
            catch (Exception e)
            {
                Tizen.Log.Error(tag, "Caught Exception" + e.ToString());
                Assert.Fail("Caught Exception" + e.ToString());
            }

            tlog.Debug(tag, $"ExpandMarkupsVisitorStopOnDataTemplate END (OK)");
            Assert.Pass("ExpandMarkupsVisitorStopOnDataTemplate");
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
                bool b1 = e1.StopOnResourceDictionary;
            }
            catch (Exception e)
            {
                Tizen.Log.Error(tag, "Caught Exception" + e.ToString());
                Assert.Fail("Caught Exception" + e.ToString());
            }

            tlog.Debug(tag, $"ExpandMarkupsVisitorStopOnResourceDictionary END (OK)");
            Assert.Pass("ExpandMarkupsVisitorStopOnResourceDictionary");
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
                bool b1 = e1.VisitNodeOnDataTemplate;
            }
            catch (Exception e)
            {
                Tizen.Log.Error(tag, "Caught Exception" + e.ToString());
                Assert.Fail("Caught Exception" + e.ToString());
            }

            tlog.Debug(tag, $"ExpandMarkupsVisitorVisitNodeOnDataTemplate END (OK)");
            Assert.Pass("ExpandMarkupsVisitorVisitNodeOnDataTemplate");
        }

        internal class INodeImplement : INode
        {
            public global::System.Collections.Generic.List<string> IgnorablePrefixes { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

            public global::System.Xml.IXmlNamespaceResolver NamespaceResolver => throw new NotImplementedException();

            public INode Parent { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

            public void Accept(IXamlNodeVisitor visitor, INode parentNode)
            {
                throw new NotImplementedException();
            }

            public INode Clone()
            {
                throw new NotImplementedException();
            }
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
                INodeImplement node = new INodeImplement();
                INodeImplement nodeParent = new INodeImplement();
                bool b1 = e1.SkipChildren(node, nodeParent);
            }
            catch (Exception e)
            {
                Tizen.Log.Error(tag, "Caught Exception" + e.ToString());
                Assert.Fail("Caught Exception" + e.ToString());
            }

            tlog.Debug(tag, $"ExpandMarkupsVisitorSkipChildren END (OK)");
            Assert.Pass("ExpandMarkupsVisitorSkipChildren");
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

        //[Test]
        //[Category("P1")]
        //[Description("ExpandMarkupsVisitor IsResourceDictionary")]
        //[Property("SPEC", "Tizen.NUI.ExpandMarkupsVisitor.IsResourceDictionary M")]
        //[Property("SPEC_URL", "-")]
        //[Property("CRITERIA", "MR")]
        //public void ExpandMarkupsVisitorIsResourceDictionary()
        //{
        //    tlog.Debug(tag, $"ExpandMarkupsVisitorIsResourceDictionary START");

        //    try
        //    {
        //        IList<XmlType> list = null;
        //        XmlType xmlType = new XmlType("myNameSpace", "myName", list);

        //        IXmlNamespaceResolverImplement i1 = new IXmlNamespaceResolverImplement();
        //        ElementNode n1 = new ElementNode(xmlType, "myNameSpace", i1);

        //        bool b1 = e1.IsResourceDictionary(n1);
        //    }
        //    catch (Exception e)
        //    {
        //        Tizen.Log.Error(tag, "Caught Exception" + e.ToString());
        //        Assert.Fail("Caught Exception" + e.ToString());
        //    }

        //    tlog.Debug(tag, $"ExpandMarkupsVisitorIsResourceDictionary END (OK)");
        //    Assert.Pass("ExpandMarkupsVisitorIsResourceDictionary");
        //}

        //[Test]
        //[Category("P1")]
        //[Description("ExpandMarkupsVisitor Visit")]
        //[Property("SPEC", "Tizen.NUI.ExpandMarkupsVisitor.Visit M")]
        //[Property("SPEC_URL", "-")]
        //[Property("CRITERIA", "MR")]
        //public void ExpandMarkupsVisitorVisit()
        //{
        //    tlog.Debug(tag, $"ExpandMarkupsVisitorVisit START");

        //    try
        //    {
        //        IXmlNamespaceResolverImplement i1 = new IXmlNamespaceResolverImplement();
        //        MarkupNode markupnode = new MarkupNode("markup", i1);
        //        INodeImplement parentNode = new INodeImplement();
        //        e1.Visit(markupnode, parentNode);
        //    }
        //    catch (Exception e)
        //    {
        //        Tizen.Log.Error(tag, "Caught Exception" + e.ToString());
        //        Assert.Fail("Caught Exception" + e.ToString());
        //    }

        //    tlog.Debug(tag, $"ExpandMarkupsVisitorVisit END (OK)");
        //    Assert.Pass("ExpandMarkupsVisitorVisit");
        //}

        //public class IServiceProviderImplement : IServiceProvider
        //{
        //    public object GetService(Type serviceType)
        //    {
        //        throw new NotImplementedException();
        //    }
        //}

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
        //        IServiceProviderImplement serviceProviderImplement = new IServiceProviderImplement();

        //        string s1 = new string('a', 4);
        //        markupExpansionParser.Parse("matchString", ref s1, serviceProviderImplement);
        //    }
        //    catch (Exception e)
        //    {
        //        tlog.Debug(tag, e.Message.ToString());
        //        tlog.Debug(tag, $"ExpandMarkupsVisitorParse END (OK)");
        //        Assert.Pass("Caught Exception : passed!");
        //    }
        //}
    }
}