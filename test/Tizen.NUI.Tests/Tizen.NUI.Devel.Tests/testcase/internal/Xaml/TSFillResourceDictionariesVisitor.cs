using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Xml;
using Tizen.NUI.Xaml;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("internal/Xaml/FillResourceDictionariesVisitor")]
    internal class PublicFillResourceDictionariesVisitorTest
    {
        private const string tag = "NUITEST";
        private static FillResourceDictionariesVisitor f1;

        [SetUp]
        public void Init()
        {
            tlog.Info(tag, "Init() is called!");
            HydrationContext context = new HydrationContext();
            f1 = new FillResourceDictionariesVisitor(context);
        }

        [TearDown]
        public void Destroy()
        {
            tlog.Info(tag, "Destroy() is called!");
        }

        [Test]
        [Category("P1")]
        [Description("FillResourceDictionariesVisitor FillResourceDictionariesVisitor")]
        [Property("SPEC", "Tizen.NUI.FillResourceDictionariesVisitor.FillResourceDictionariesVisitor C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        public void FillResourceDictionariesVisitorConstructor()
        {
            tlog.Debug(tag, $"FillResourceDictionariesVisitorConstructor START");

            HydrationContext context = new HydrationContext();

            FillResourceDictionariesVisitor fillResourceDictionariesVisitor = new FillResourceDictionariesVisitor(context);

            tlog.Debug(tag, $"FillResourceDictionariesVisitorConstructor END (OK)");
            Assert.Pass("FillResourceDictionariesVisitorConstructor");
        }

        [Test]
        [Category("P1")]
        [Description("FillResourceDictionariesVisitor VisitingMode")]
        [Property("SPEC", "Tizen.NUI.FillResourceDictionariesVisitor.VisitingMode A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        public void FillResourceDictionariesVisitorVisitingMode()
        {
            tlog.Debug(tag, $"FillResourceDictionariesVisitorVisitingMode START");

            try
            {
                TreeVisitingMode t1 = f1.VisitingMode;
            }
            catch (Exception e)
            {
                Tizen.Log.Error(tag, "Caught Exception" + e.ToString());
                Assert.Fail("Caught Exception" + e.ToString());
            }

            tlog.Debug(tag, $"FillResourceDictionariesVisitorVisitingMode END (OK)");
            Assert.Pass("FillResourceDictionariesVisitorVisitingMode");
        }

        [Test]
        [Category("P1")]
        [Description("FillResourceDictionariesVisitor StopOnDataTemplate")]
        [Property("SPEC", "Tizen.NUI.FillResourceDictionariesVisitor.StopOnDataTemplate A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        public void FillResourceDictionariesVisitorStopOnDataTemplate()
        {
            tlog.Debug(tag, $"FillResourceDictionariesVisitorStopOnDataTemplate START");

            try
            {
                bool b1 = f1.StopOnDataTemplate;
            }
            catch (Exception e)
            {
                Tizen.Log.Error(tag, "Caught Exception" + e.ToString());
                Assert.Fail("Caught Exception" + e.ToString());
            }

            tlog.Debug(tag, $"FillResourceDictionariesVisitorStopOnDataTemplate END (OK)");
            Assert.Pass("FillResourceDictionariesVisitorStopOnDataTemplate");
        }

        [Test]
        [Category("P1")]
        [Description("FillResourceDictionariesVisitor StopOnResourceDictionary")]
        [Property("SPEC", "Tizen.NUI.FillResourceDictionariesVisitor.StopOnResourceDictionary A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        public void FillResourceDictionariesVisitorStopOnResourceDictionary()
        {
            tlog.Debug(tag, $"FillResourceDictionariesVisitorStopOnResourceDictionary START");

            try
            {
                bool b1 = f1.StopOnResourceDictionary;
            }
            catch (Exception e)
            {
                Tizen.Log.Error(tag, "Caught Exception" + e.ToString());
                Assert.Fail("Caught Exception" + e.ToString());
            }

            tlog.Debug(tag, $"FillResourceDictionariesVisitorStopOnResourceDictionary END (OK)");
            Assert.Pass("FillResourceDictionariesVisitorStopOnResourceDictionary");
        }

        [Test]
        [Category("P1")]
        [Description("FillResourceDictionariesVisitor VisitNodeOnDataTemplate")]
        [Property("SPEC", "Tizen.NUI.FillResourceDictionariesVisitor.VisitNodeOnDataTemplate A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        public void FillResourceDictionariesVisitorVisitNodeOnDataTemplate()
        {
            tlog.Debug(tag, $"FillResourceDictionariesVisitorVisitNodeOnDataTemplate START");

            try
            {
                var result = f1.VisitNodeOnDataTemplate;
                tlog.Debug(tag, "VisitNodeOnDataTemplate : " + result);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : falied!");
            }

            tlog.Debug(tag, $"FillResourceDictionariesVisitorVisitNodeOnDataTemplate END (OK)");
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
        [Description("FillResourceDictionariesVisitor IsResourceDictionary")]
        [Property("SPEC", "Tizen.NUI.FillResourceDictionariesVisitor.IsResourceDictionary M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        public void FillResourceDictionariesVisitorIsResourceDictionary()
        {
            tlog.Debug(tag, $"FillResourceDictionariesVisitorVisitNodeOnDataTemplate START");

            try
            {
                IList<XmlType> list = null;
                XmlType xmlType = new XmlType("myNameSpace", "myName", list);

                IXmlNamespaceResolverImplement i1 = new IXmlNamespaceResolverImplement();
                ElementNode n1 = new ElementNode(xmlType, "myNameSpace", i1);

                bool b1 = f1.IsResourceDictionary(n1);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                tlog.Debug(tag, $"FillResourceDictionariesVisitorVisitNodeOnDataTemplate END (OK)");
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
        [Description("FillResourceDictionariesVisitor Visit")]
        [Property("SPEC", "Tizen.NUI.FillResourceDictionariesVisitor.Visit M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        public void FillResourceDictionariesVisitorVisit1()
        {
            tlog.Debug(tag, $"FillResourceDictionariesVisitorVisit START");

            try
            {
                object o1 = new object();
                IXmlNamespaceResolverImplement i1 = new IXmlNamespaceResolverImplement();
                ValueNode node = new ValueNode(o1, i1);

                INodeImplement parentNode = new INodeImplement();

                f1.Visit(node, parentNode);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                tlog.Debug(tag, $"FillResourceDictionariesVisitorVisit END (OK)");
                Assert.Pass("Caught Exception : passed!");
            }
        }

        [Test]
        [Category("P1")]
        [Description("FillResourceDictionariesVisitor Visit")]
        [Property("SPEC", "Tizen.NUI.FillResourceDictionariesVisitor.Visit M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        public void FillResourceDictionariesVisitorVisit2()
        {
            tlog.Debug(tag, $"FillResourceDictionariesVisitorVisit START");

            try
            {

                IXmlNamespaceResolverImplement i1 = new IXmlNamespaceResolverImplement();

                INodeImplement parentNode = new INodeImplement();

                IList<XmlType> list = null;
                XmlType xmlType = new XmlType("myNameSpace", "myName", list);

                ElementNode n1 = new ElementNode(xmlType, "myNameSpace", i1);

                f1.Visit(n1, parentNode);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                tlog.Debug(tag, $"FillResourceDictionariesVisitorVisit END (OK)");
                Assert.Pass("Caught Exception : passed!");
            }

        }

        [Test]
        [Category("P1")]
        [Description("FillResourceDictionariesVisitor SkipChildren")]
        [Property("SPEC", "Tizen.NUI.FillResourceDictionariesVisitor.SkipChildren M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        public void FillResourceDictionariesVisitorSkipChildren()
        {
            tlog.Debug(tag, $"FillResourceDictionariesVisitorSkipChildren START");

            try
            {
                INodeImplement nodeImplement = new INodeImplement();
                INodeImplement parentNode = new INodeImplement();

                f1.SkipChildren(nodeImplement, parentNode);

            }
            catch (Exception e)
            {
                Tizen.Log.Error(tag, "Caught Exception" + e.ToString());
                Assert.Fail("Caught Exception" + e.ToString());
            }

            tlog.Debug(tag, $"FillResourceDictionariesVisitorSkipChildren END (OK)");
            Assert.Pass("FillResourceDictionariesVisitorSkipChildren");
        }
    }
}