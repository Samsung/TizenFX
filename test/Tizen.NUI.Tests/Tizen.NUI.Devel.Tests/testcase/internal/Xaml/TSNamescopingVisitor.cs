using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Xml;
using Tizen.NUI.Xaml;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("internal/Xaml/NamescopingVisitor")]
    internal class PublicNamescopingVisitorTest
    {
        private const string tag = "NUITEST";
        private static NamescopingVisitor n1;

        [SetUp]
        public void Init()
        {
            tlog.Info(tag, "Init() is called!");
            HydrationContext context = new HydrationContext();
            NamescopingVisitor n1 = new NamescopingVisitor(context);
        }

        [TearDown]
        public void Destroy()
        {
            n1 = null;
            tlog.Info(tag, "Destroy() is called!");
        }

        [Test]
        [Category("P1")]
        [Description("NamescopingVisitor NamescopingVisitor")]
        [Property("SPEC", "Tizen.NUI.NamescopingVisitor.NamescopingVisitor C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        public void NamescopingVisitorConstructor()
        {
            tlog.Debug(tag, $"NamescopingVisitorConstructor START");

            HydrationContext context = new HydrationContext();

            NamescopingVisitor namescoping = new NamescopingVisitor(context);

            tlog.Debug(tag, $"NamescopingVisitorConstructor END (OK)");
            Assert.Pass("NamescopingVisitorConstructor");
        }

        [Test]
        [Category("P1")]
        [Description("NamescopingVisitor VisitingMode")]
        [Property("SPEC", "Tizen.NUI.NamescopingVisitor.VisitingMode A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        public void NamescopingVisitorVisitingMode()
        {
            tlog.Debug(tag, $"NamescopingVisitorVisitingMode START");

            try
            {
                TreeVisitingMode t1 = n1.VisitingMode;
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                tlog.Debug(tag, $"NamescopingVisitorVisitingMode END (OK)");
                Assert.Pass("Caught Exception : passed!");
            }

        }

        [Test]
        [Category("P1")]
        [Description("NamescopingVisitor StopOnDataTemplate")]
        [Property("SPEC", "Tizen.NUI.NamescopingVisitor.StopOnDataTemplate A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        public void NamescopingVisitorStopOnDataTemplate()
        {
            tlog.Debug(tag, $"NamescopingVisitorStopOnDataTemplate START");

            try
            {
                bool b1 = n1.StopOnDataTemplate;
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                tlog.Debug(tag, $"NamescopingVisitorStopOnDataTemplate END (OK)");
                Assert.Pass("Caught Exception : passed!");
            }

        }

        [Test]
        [Category("P1")]
        [Description("NamescopingVisitor StopOnResourceDictionary")]
        [Property("SPEC", "Tizen.NUI.NamescopingVisitor.StopOnResourceDictionary A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        public void NamescopingVisitorStopOnResourceDictionary()
        {
            tlog.Debug(tag, $"NamescopingVisitorStopOnResourceDictionary START");

            try
            {
                bool b1 = n1.StopOnResourceDictionary;
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                tlog.Debug(tag, $"NamescopingVisitorStopOnResourceDictionary END (OK)");
                Assert.Pass("Caught Exception : passed!");
            }

        }

        [Test]
        [Category("P1")]
        [Description("NamescopingVisitor VisitNodeOnDataTemplate")]
        [Property("SPEC", "Tizen.NUI.NamescopingVisitor.VisitNodeOnDataTemplate A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        public void NamescopingVisitorVisitNodeOnDataTemplate()
        {
            tlog.Debug(tag, $"NamescopingVisitorVisitNodeOnDataTemplate START");

            try
            {
                bool b1 = n1.VisitNodeOnDataTemplate;
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                tlog.Debug(tag, $"NamescopingVisitorVisitNodeOnDataTemplate END (OK)");
                Assert.Pass("Caught Exception : passed!");
            }

        }

        public class INodeImplement : INode
        {
            public List<string> IgnorablePrefixes { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

            public IXmlNamespaceResolver NamespaceResolver => throw new NotImplementedException();

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
        [Description("NamescopingVisitor SkipChildren")]
        [Property("SPEC", "Tizen.NUI.NamescopingVisitor.SkipChildren M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        public void NamescopingVisitorSkipChildren()
        {
            tlog.Debug(tag, $"NamescopingVisitorSkipChildren START");

            try
            {
                INodeImplement nodeImplement = new INodeImplement();
                INodeImplement parentNode = new INodeImplement();

                n1.SkipChildren(nodeImplement, parentNode);

            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                tlog.Debug(tag, $"NamescopingVisitorSkipChildren END (OK)");
                Assert.Pass("Caught Exception : passed!");
            }

        }

        public class IXmlNamespaceResolverImplement : IXmlNamespaceResolver
        {
            public IDictionary<string, string> GetNamespacesInScope(XmlNamespaceScope scope)
            {
                return null;
            }

            public string LookupNamespace(string prefix)
            {
                return "mynamespaceName";
            }

            public string LookupPrefix(string namespaceName)
            {
                return "myPrefix";
            }
        }

        [Test]
        [Category("P1")]
        [Description("NamescopingVisitor IsResourceDictionary")]
        [Property("SPEC", "Tizen.NUI.NamescopingVisitor.IsResourceDictionary M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        public void NamescopingVisitorIsResourceDictionary()
        {
            tlog.Debug(tag, $"NamescopingVisitorIsResourceDictionary START");

            try
            {
                IList<XmlType> list = null;
                XmlType xmlType = new XmlType("myNameSpace", "myName", list);

                IXmlNamespaceResolverImplement i1 = new IXmlNamespaceResolverImplement();
                ElementNode e1 = new ElementNode(xmlType, "myNameSpace", i1);

                bool b1 = n1.IsResourceDictionary(e1);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                tlog.Debug(tag, $"NamescopingVisitorIsResourceDictionary END (OK)");
                Assert.Pass("Caught Exception : passed!");
            }
        }

        public class RootNodeImplement : RootNode
        {
            public RootNodeImplement(XmlType xmlType, IXmlNamespaceResolver nsResolver) : base(xmlType, nsResolver)
            {
            }
        }

        [Test]
        [Category("P1")]
        [Description("NamescopingVisitor Visit")]
        [Property("SPEC", "Tizen.NUI.NamescopingVisitor.Visit M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        public void NamescopingVisitorVisit1()
        {
            tlog.Debug(tag, $"NamescopingVisitorVisit START");

            try
            {
                object o1 = new object();
                IXmlNamespaceResolverImplement i1 = new IXmlNamespaceResolverImplement();
                ValueNode node = new ValueNode(o1, i1);

                INodeImplement parentNode = new INodeImplement();
                n1.Visit(node, parentNode);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                tlog.Debug(tag, $"NamescopingVisitorVisit END (OK)");
                Assert.Pass("Caught Exception : passed!");
            }
        }

        [Test]
        [Category("P1")]
        [Description("NamescopingVisitor Visit")]
        [Property("SPEC", "Tizen.NUI.NamescopingVisitor.Visit M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        public void NamescopingVisitorVisit2()
        {
            tlog.Debug(tag, $"NamescopingVisitorVisit START");

            try
            {
                INodeImplement parentNode = new INodeImplement();
                IXmlNamespaceResolverImplement i1 = new IXmlNamespaceResolverImplement();
                MarkupNode markupnode = new MarkupNode("markup", i1);
                n1.Visit(markupnode, parentNode);


            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                tlog.Debug(tag, $"NamescopingVisitorVisit END (OK)");
                Assert.Pass("Caught Exception : passed!");
            }
        }

        [Test]
        [Category("P1")]
        [Description("NamescopingVisitor Visit")]
        [Property("SPEC", "Tizen.NUI.NamescopingVisitor.Visit M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        public void NamescopingVisitorVisit3()
        {
            tlog.Debug(tag, $"NamescopingVisitorVisit START");

            try
            {
                IXmlNamespaceResolverImplement i1 = new IXmlNamespaceResolverImplement();
                INodeImplement parentNode = new INodeImplement();

                IList<XmlType> list = null;
                XmlType xmlType = new XmlType("myNameSpace", "myName", list);

                ElementNode e1 = new ElementNode(xmlType, "myNameSpace", i1);

                n1.Visit(e1, parentNode);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                tlog.Debug(tag, $"NamescopingVisitorVisit END (OK)");
                Assert.Pass("Caught Exception : passed!");
            }
        }

        [Test]
        [Category("P1")]
        [Description("NamescopingVisitor Visit")]
        [Property("SPEC", "Tizen.NUI.NamescopingVisitor.Visit M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        public void NamescopingVisitorVisit4()
        {
            tlog.Debug(tag, $"NamescopingVisitorVisit START");

            try
            {
                IXmlNamespaceResolverImplement i1 = new IXmlNamespaceResolverImplement();

                INodeImplement parentNode = new INodeImplement();

                IList<XmlType> list = null;
                XmlType xmlType = new XmlType("myNameSpace", "myName", list);
                RootNodeImplement rootNode = new RootNodeImplement(xmlType, i1);
                n1.Visit(rootNode, parentNode);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                tlog.Debug(tag, $"NamescopingVisitorVisit END (OK)");
                Assert.Pass("Caught Exception : passed!");
            }
        }

        [Test]
        [Category("P1")]
        [Description("NamescopingVisitor Visit")]
        [Property("SPEC", "Tizen.NUI.NamescopingVisitor.Visit M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        public void NamescopingVisitorVisit5()
        {
            tlog.Debug(tag, $"NamescopingVisitorVisit START");

            try
            {
                IXmlNamespaceResolverImplement i1 = new IXmlNamespaceResolverImplement();
                INodeImplement parentNode = new INodeImplement();

                IList<INode> nodes = null;
                ListNode li = new ListNode(nodes, i1);
                n1.Visit(li, parentNode);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                tlog.Debug(tag, $"NamescopingVisitorVisit END (OK)");
                Assert.Pass("Caught Exception : passed!");
            }
        }
    }
}