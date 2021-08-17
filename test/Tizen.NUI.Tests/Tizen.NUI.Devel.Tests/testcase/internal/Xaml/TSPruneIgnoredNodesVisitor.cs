using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Xml;
using Tizen.NUI.Xaml;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("internal/Xaml/PruneIgnoredNodesVisitor")]
    public class InternalXamlPruneIgnoredNodesVisitorTest
    {
        private const string tag = "NUITEST";
        private PruneIgnoredNodesVisitor p1;

        [SetUp]
        public void Init()
        {
            tlog.Info(tag, "Init() is called!");
            p1 = new PruneIgnoredNodesVisitor();
        }

        [TearDown]
        public void Destroy()
        {
            p1 = null;
            tlog.Info(tag, "Destroy() is called!");
        }

        [Test]
        [Category("P1")]
        [Description("PruneIgnoredNodesVisitor VisitingMode")]
        [Property("SPEC", "Tizen.NUI.PruneIgnoredNodesVisitor.VisitingMode A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        public void PruneIgnoredNodesVisitorVisitingMode()
        {
            tlog.Debug(tag, $"NamescopingVisitorVisitingMode START");

            try
            {
                TreeVisitingMode t1 = p1.VisitingMode;
            }
            catch (Exception e)
            {
                Tizen.Log.Error(tag, "Caught Exception" + e.ToString());
                Assert.Fail("Caught Exception" + e.ToString());
            }

            tlog.Debug(tag, $"PruneIgnoredNodesVisitorVisitingMode END (OK)");
            Assert.Pass("PruneIgnoredNodesVisitorVisitingMode");
        }

        [Test]
        [Category("P1")]
        [Description("PruneIgnoredNodesVisitor StopOnDataTemplate")]
        [Property("SPEC", "Tizen.NUI.PruneIgnoredNodesVisitor.StopOnDataTemplate A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        public void PruneIgnoredNodesVisitorStopOnDataTemplate()
        {
            tlog.Debug(tag, $"PruneIgnoredNodesVisitorStopOnDataTemplate START");

            try
            {
                bool b1 = p1.StopOnDataTemplate;
            }
            catch (Exception e)
            {
                Tizen.Log.Error(tag, "Caught Exception" + e.ToString());
                Assert.Fail("Caught Exception" + e.ToString());
            }

            tlog.Debug(tag, $"PruneIgnoredNodesVisitorStopOnDataTemplate END (OK)");
            Assert.Pass("PruneIgnoredNodesVisitorStopOnDataTemplate");
        }

        [Test]
        [Category("P1")]
        [Description("PruneIgnoredNodesVisitor StopOnResourceDictionary")]
        [Property("SPEC", "Tizen.NUI.PruneIgnoredNodesVisitor.StopOnResourceDictionary A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        public void PruneIgnoredNodesVisitorStopOnResourceDictionary()
        {
            tlog.Debug(tag, $"PruneIgnoredNodesVisitorStopOnResourceDictionary START");

            try
            {
                bool b1 = p1.StopOnResourceDictionary;
            }
            catch (Exception e)
            {
                Tizen.Log.Error(tag, "Caught Exception" + e.ToString());
                Assert.Fail("Caught Exception" + e.ToString());
            }

            tlog.Debug(tag, $"PruneIgnoredNodesVisitorStopOnResourceDictionary END (OK)");
            Assert.Pass("PruneIgnoredNodesVisitorStopOnResourceDictionary");
        }

        [Test]
        [Category("P1")]
        [Description("PruneIgnoredNodesVisitor VisitNodeOnDataTemplate")]
        [Property("SPEC", "Tizen.NUI.PruneIgnoredNodesVisitor.VisitNodeOnDataTemplate A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        public void PruneIgnoredNodesVisitorVisitNodeOnDataTemplate()
        {
            tlog.Debug(tag, $"PruneIgnoredNodesVisitorVisitNodeOnDataTemplate START");

            try
            {
                bool b1 = p1.VisitNodeOnDataTemplate;
            }
            catch (Exception e)
            {
                Tizen.Log.Error(tag, "Caught Exception" + e.ToString());
                Assert.Fail("Caught Exception" + e.ToString());
            }

            tlog.Debug(tag, $"PruneIgnoredNodesVisitorVisitNodeOnDataTemplate END (OK)");
            Assert.Pass("PruneIgnoredNodesVisitorVisitNodeOnDataTemplate");
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
        [Description("PruneIgnoredNodesVisitor SkipChildren")]
        [Property("SPEC", "Tizen.NUI.NamescopingVisitor.SkipChildren M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        public void PruneIgnoredNodesVisitorSkipChildren()
        {
            tlog.Debug(tag, $"PruneIgnoredNodesVisitorSkipChildren START");

            try
            {
                INodeImplement node = new INodeImplement();
                INodeImplement nodeParent = new INodeImplement();
                bool b1 = p1.SkipChildren(node, nodeParent);
            }
            catch (Exception e)
            {
                Tizen.Log.Error(tag, "Caught Exception" + e.ToString());
                Assert.Fail("Caught Exception" + e.ToString());
            }

            tlog.Debug(tag, $"PruneIgnoredNodesVisitorSkipChildren END (OK)");
            Assert.Pass("PruneIgnoredNodesVisitorSkipChildren");
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
        //[Description("NamescopingVisitor IsResourceDictionary")]
        //[Property("SPEC", "Tizen.NUI.NamescopingVisitor.IsResourceDictionary M")]
        //[Property("SPEC_URL", "-")]
        //[Property("CRITERIA", "MR")]
        //public void NamescopingVisitorIsResourceDictionary()
        //{
        //    tlog.Debug(tag, $"NamescopingVisitorIsResourceDictionary START");

        //    try
        //    {
        //        IList<XmlType> list = null;
        //        XmlType xmlType = new XmlType("myNameSpace", "myName", list);

        //        IXmlNamespaceResolverImplement i1 = new IXmlNamespaceResolverImplement();
        //        ElementNode n1 = new ElementNode(xmlType, "myNameSpace", i1);

        //        bool b1 = p1.IsResourceDictionary(n1);
        //    }
        //    catch (Exception e)
        //    {
        //        Tizen.Log.Error(tag, "Caught Exception" + e.ToString());
        //        Assert.Fail("Caught Exception" + e.ToString());
        //    }

        //    tlog.Debug(tag, $"NamescopingVisitorIsResourceDictionary END (OK)");
        //    Assert.Pass("NamescopingVisitorIsResourceDictionary");
        //}

        //public class RootNodeImplement : RootNode
        //{
        //    public RootNodeImplement(XmlType xmlType, IXmlNamespaceResolver nsResolver) : base(xmlType, nsResolver)
        //    {
        //    }
        //}

        //[Test]
        //[Category("P1")]
        //[Description("NamescopingVisitor Visit")]
        //[Property("SPEC", "Tizen.NUI.NamescopingVisitor.Visit M")]
        //[Property("SPEC_URL", "-")]
        //[Property("CRITERIA", "MR")]
        //public void NamescopingVisitorVisit1()
        //{
        //    tlog.Debug(tag, $"NamescopingVisitorVisit START");

        //    try
        //    {
        //        IList<XmlType> list = null;
        //        XmlType xmlType = new XmlType("myNameSpace", "myName", list);

        //        IXmlNamespaceResolverImplement i1 = new IXmlNamespaceResolverImplement();
        //        ElementNode n1 = new ElementNode(xmlType, "myNameSpace", i1);

        //        INodeImplement parentNode = new INodeImplement();
        //        p1.Visit(n1, parentNode);
        //    }
        //    catch (Exception e)
        //    {
        //        tlog.Debug(tag, e.Message.ToString());
        //        tlog.Debug(tag, $"NamescopingVisitorVisit END (OK)");
        //        Assert.Pass("Caught Exception : passed!");
        //    }
        //}

        //[Test]
        //[Category("P1")]
        //[Description("NamescopingVisitor Visit")]
        //[Property("SPEC", "Tizen.NUI.NamescopingVisitor.Visit M")]
        //[Property("SPEC_URL", "-")]
        //[Property("CRITERIA", "MR")]
        //public void NamescopingVisitorVisit2()
        //{
        //    tlog.Debug(tag, $"NamescopingVisitorVisit START");

        //    try
        //    {
        //        IList<XmlType> list = null;
        //        XmlType xmlType = new XmlType("myNameSpace", "myName", list);

        //        IXmlNamespaceResolverImplement i1 = new IXmlNamespaceResolverImplement();

        //        INodeImplement parentNode = new INodeImplement();

        //        RootNodeImplement rootNode = new RootNodeImplement(xmlType, i1);
        //        p1.Visit(rootNode, parentNode);
        //    }
        //    catch (Exception e)
        //    {
        //        tlog.Debug(tag, e.Message.ToString());
        //        tlog.Debug(tag, $"NamescopingVisitorVisit END (OK)");
        //        Assert.Pass("Caught Exception : passed!");
        //    }
        //}

        //[Test]
        //[Category("P1")]
        //[Description("NamescopingVisitor Visit")]
        //[Property("SPEC", "Tizen.NUI.NamescopingVisitor.Visit M")]
        //[Property("SPEC_URL", "-")]
        //[Property("CRITERIA", "MR")]
        //public void NamescopingVisitorVisit3()
        //{
        //    tlog.Debug(tag, $"NamescopingVisitorVisit START");

        //    try
        //    {
        //        IXmlNamespaceResolverImplement i1 = new IXmlNamespaceResolverImplement();

        //        INodeImplement parentNode = new INodeImplement();
        //        IList<INode> nodes = null;
        //        ListNode li = new ListNode(nodes, i1);
        //        p1.Visit(li, parentNode);
        //    }
        //    catch (Exception e)
        //    {
        //        tlog.Debug(tag, e.Message.ToString());
        //        tlog.Debug(tag, $"NamescopingVisitorVisit END (OK)");
        //        Assert.Pass("Caught Exception : passed!");
        //    }
        //}
    }
}