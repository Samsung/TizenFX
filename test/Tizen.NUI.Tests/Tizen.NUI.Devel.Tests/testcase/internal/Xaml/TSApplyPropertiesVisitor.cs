using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Xml;
using Tizen.NUI.Binding;
using Tizen.NUI.Xaml;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("internal/Xaml/ApplyPropertiesVisitor")]
    public class InternalApplyPropertiesVisitorTest
    {
        private const string tag = "NUITEST";
        private ApplyPropertiesVisitor visitor;

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
            visitor = new ApplyPropertiesVisitor(new HydrationContext(), false);
        }

        [TearDown]
        public void Destroy()
        {
            visitor = null;
            tlog.Info(tag, "Destroy() is called!");
        }
        [Test]
        [Category("P1")]
        [Description("ApplyPropertiesVisitor ApplyPropertiesVisitor")]
        [Property("SPEC", "Tizen.NUI.ApplyPropertiesVisitor.ApplyPropertiesVisitor C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        public void ApplyPropertiesVisitorConstructor()
        {
            tlog.Debug(tag, $"ApplyPropertiesVisitorConstructor START");

            HydrationContext context = new HydrationContext();
            Assert.IsNotNull(context, "null HydrationContext");

            ApplyPropertiesVisitor applyPropertiesVisitor = new ApplyPropertiesVisitor(context, false);
            Assert.IsNotNull(applyPropertiesVisitor, "null ApplyPropertiesVisitor");
            Assert.IsInstanceOf<ApplyPropertiesVisitor>(applyPropertiesVisitor, "Should return ApplyPropertiesVisitor instance.");

            tlog.Debug(tag, $"ApplyPropertiesVisitorConstructor END");
        }
		
        [Test]
        [Category("P1")]
        [Description("ApplyPropertiesVisitor VisitingMode")]
        [Property("SPEC", "Tizen.NUI.ApplyPropertiesVisitor.VisitingMode A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        public void ApplyPropertiesVisitorVisitingMode()
        {
            tlog.Debug(tag, $"ApplyPropertiesVisitorVisitingMode START");

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

            tlog.Debug(tag, $"ApplyPropertiesVisitorVisitingMode END");
        }

        [Test]
        [Category("P1")]
        [Description("ApplyPropertiesVisitor StopOnDataTemplate")]
        [Property("SPEC", "Tizen.NUI.ApplyPropertiesVisitor.StopOnDataTemplate A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        public void ApplyPropertiesVisitorStopOnDataTemplate()
        {
            tlog.Debug(tag, $"ApplyPropertiesVisitorStopOnDataTemplate START");

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

            tlog.Debug(tag, $"ApplyPropertiesVisitorStopOnDataTemplate END");
        }

        [Test]
        [Category("P1")]
        [Description("ApplyPropertiesVisitor StopOnResourceDictionary ")]
        [Property("SPEC", "Tizen.NUI.ApplyPropertiesVisitor.StopOnResourceDictionary A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        public void ApplyPropertiesVisitorStopOnResourceDictionary()
        {
            tlog.Debug(tag, $"ApplyPropertiesVisitorStopOnResourceDictionary START");

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

            tlog.Debug(tag, $"ApplyPropertiesVisitorStopOnResourceDictionary END");
        }

        [Test]
        [Category("P1")]
        [Description("ApplyPropertiesVisitor VisitNodeOnDataTemplate ")]
        [Property("SPEC", "Tizen.NUI.ApplyPropertiesVisitor.VisitNodeOnDataTemplate A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        public void ApplyPropertiesVisitorVisitNodeOnDataTemplate()
        {
            tlog.Debug(tag, $"ApplyPropertiesVisitorVisitNodeOnDataTemplate START");

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

            tlog.Debug(tag, $"ApplyPropertiesVisitorVisitNodeOnDataTemplate END");
        }

        [Test]
        [Category("P1")]
        [Description("ApplyPropertiesVisitor SkipChildren")]
        [Property("SPEC", "Tizen.NUI.ApplyPropertiesVisitor.SkipChildren M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        public void ApplyPropertiesVisitorSkipChildren()
        {
            tlog.Debug(tag, $"ApplyPropertiesVisitorSkipChildren START");

            try
            {
                var child = new INodeImpl();
                Assert.IsNotNull(child, "null INodeImpl object.");

                var parent = new INodeImpl();
                Assert.IsNotNull(parent, "null INodeImpl object.");

                var result = visitor.SkipChildren(child, parent);
                tlog.Debug(tag, "SkipChildren : " + result);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            tlog.Debug(tag, $"ApplyPropertiesVisitorSkipChildren END");
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
        [Description("ApplyPropertiesVisitor IsResourceDictionary")]
        [Property("SPEC", "Tizen.NUI.ApplyPropertiesVisitor.IsResourceDictionary M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        public void ApplyPropertiesVisitorIsResourceDictionary()
        {
            tlog.Debug(tag, $"ApplyPropertiesVisitorIsResourceDictionary START");

            try
            {
                HydrationContext context = new HydrationContext();
                IList<XmlType> list = new List<XmlType>();
                XmlType xmlType = new XmlType("myNameSpace", "myName", list);
                Assert.IsNotNull(xmlType, "null XmlType");
                IXmlNamespaceResolverImplement i1 = new IXmlNamespaceResolverImplement();
                Assert.IsNotNull(i1, "null IXmlNamespaceResolverImplement");
                ElementNode n1 = new ElementNode(xmlType, "myNameSpace", i1);
                Assert.IsNotNull(n1, "null ElementNode");
                context.Types[n1] = typeof(ResourceDictionary);
                ApplyPropertiesVisitor a2 = new ApplyPropertiesVisitor(context, false);
                Assert.IsNotNull(a2, "null ApplyPropertiesVisitor");
                bool b1 = a2.IsResourceDictionary(n1);
                Assert.True(b1, "Should be true");
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception" + e.ToString());
            }
            tlog.Debug(tag, $"ApplyPropertiesVisitorIsResourceDictionary END");

        }

        [Test]
        [Category("P1")]
        [Description("ApplyPropertiesVisitor Visit")]
        [Property("SPEC", "Tizen.NUI.ApplyPropertiesVisitor.Visit M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        public void ApplyPropertiesVisitorVisit1()
        {
            tlog.Debug(tag, $"ApplyPropertiesVisitorVisit1 START");

            try
            {
                HydrationContext context = new HydrationContext();
                object o1 = new object();
                IXmlNamespaceResolverImplement i1 = new IXmlNamespaceResolverImplement();
                Assert.IsNotNull(i1, "null IXmlNamespaceResolverImplement");
                ValueNode valueNode = new ValueNode(o1, i1);
                Assert.IsNotNull(valueNode, "null ValueNode");

                INodeImpl nodeImplement = new INodeImpl();
                Assert.IsNotNull(nodeImplement, "null INodeImplement");
                context.Values[valueNode] = o1;
                context.Values[nodeImplement] = o1;
                ApplyPropertiesVisitor a2 = new ApplyPropertiesVisitor(context, false);
                Assert.IsNotNull(a2, "null ApplyPropertiesVisitor");
                a2.Visit(valueNode, nodeImplement);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception" + e.ToString());
            }
            tlog.Debug(tag, $"ApplyPropertiesVisitorVisit1 END");
        }

        [Test]
        [Category("P1")]
        [Description("ApplyPropertiesVisitor Visit")]
        [Property("SPEC", "Tizen.NUI.ApplyPropertiesVisitor.Visit M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        public void ApplyPropertiesVisitorVisit2()
        {
            tlog.Debug(tag, $"ApplyPropertiesVisitorVisit2 START");

            try
            {
                HydrationContext context = new HydrationContext();
                object o1 = new object();
                INodeImpl nodeImplement = new INodeImpl();
                Assert.IsNotNull(nodeImplement, "null INodeImplement");

                IList<XmlType> list = null;
                XmlType xmlType = new XmlType("myNameSpace", "myName", list);
                Assert.IsNotNull(xmlType, "null XmlType");
                IXmlNamespaceResolverImplement ix1 = new IXmlNamespaceResolverImplement();
                Assert.IsNotNull(ix1, "null IXmlNamespaceResolverImplement");
                ElementNode n1 = new ElementNode(xmlType, "myNameSpace", ix1);
                Assert.IsNotNull(n1, "null ElementNode");
                context.Values[n1] = o1;
                context.Values[nodeImplement] = o1;
                ApplyPropertiesVisitor a2 = new ApplyPropertiesVisitor(context, false);
                Assert.IsNotNull(a2, "null ApplyPropertiesVisitor");
                a2.Visit(n1, nodeImplement);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception" + e.ToString());
            }
            tlog.Debug(tag, $"ApplyPropertiesVisitorVisit2 END");

        }

        [Test]
        [Category("P1")]
        [Description("ApplyPropertiesVisitor TryGetPropertyName")]
        [Property("SPEC", "Tizen.NUI.ApplyPropertiesVisitor.TryGetPropertyName M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        public void ApplyPropertiesVisitorTryGetPropertyName()
        {
            tlog.Debug(tag, $"ApplyPropertiesVisitorTryGetPropertyName START");

            try
            {
                INodeImpl n1 = new INodeImpl();
                Assert.IsNotNull(n1, "null INodeImplement");
                INodeImpl n2 = new INodeImpl();
                Assert.IsNotNull(n2, "null INodeImplement");
                XmlName xmlName = new XmlName();
                Assert.IsNotNull(xmlName, "null XmlName");
                ApplyPropertiesVisitor.TryGetPropertyName(n1, n2, out xmlName);
            }
            catch (Exception e)
            {
                Tizen.Log.Error(tag, "Caught Exception" + e.ToString());
                Assert.Fail("Caught Exception" + e.ToString());
            }

            tlog.Debug(tag, $"ApplyPropertiesVisitorTryGetPropertyName END");
        }

        [Test]
        [Category("P1")]
        [Description("ApplyPropertiesVisitor IsCollectionItem")]
        [Property("SPEC", "Tizen.NUI.ApplyPropertiesVisitor.IsCollectionItem M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        public void ApplyPropertiesVisitorIsCollectionItem()
        {
            tlog.Debug(tag, $"ApplyPropertiesVisitorIsCollectionItem START");

            try
            {
                INodeImpl n1 = new INodeImpl();
                Assert.IsNotNull(n1, "null INodeImplement");
                INodeImpl n2 = new INodeImpl();
                Assert.IsNotNull(n2, "null INodeImplement");

                ApplyPropertiesVisitor.IsCollectionItem(n1, n2);
            }
            catch (Exception e)
            {
                Tizen.Log.Error(tag, "Caught Exception" + e.ToString());
                Assert.Fail("Caught Exception" + e.ToString());
            }

            tlog.Debug(tag, $"ApplyPropertiesVisitorIsCollectionItem END");
        }

        //[Test]
        //[Category("P1")]
        //[Description("ApplyPropertiesVisitor GetContentPropertyName")]
        //[Property("SPEC", "Tizen.NUI.ApplyPropertiesVisitor.GetContentPropertyName M")]
        //[Property("SPEC_URL", "-")]
        //[Property("CRITERIA", "MR")]
        //public void ApplyPropertiesVisitorGetContentPropertyName()
        //{
        //    tlog.Debug(tag, $"ApplyPropertiesVisitorGetContentPropertyName START");

        //    try
        //    {
        //        System.Reflection.TypeInfo typeInfo = new System.Reflection.TypeInfo();
        //        ApplyPropertiesVisitor.GetContentPropertyName(typeInfo);
        //    }
        //    catch (Exception e)
        //    {
        //        Tizen.Log.Error(tag, "Caught Exception" + e.ToString());
        //        Assert.Fail("Caught Exception" + e.ToString());
        //    }

        //    tlog.Debug(tag, $"ApplyPropertiesVisitorGetContentPropertyName END");
        //    Assert.Pass("ApplyPropertiesVisitorGetContentPropertyName");
        //}

        public class IXmlLineInfoImplement : IXmlLineInfo
        {
            public int LineNumber => throw new NotImplementedException();

            public int LinePosition => throw new NotImplementedException();

            public bool HasLineInfo()
            {
                throw new NotImplementedException();
            }
        }

        //[Test]
        //[Category("P1")]
        //[Description("ApplyPropertiesVisitor SetPropertyValue")]
        //[Property("SPEC", "Tizen.NUI.ApplyPropertiesVisitor.SetPropertyValue M")]
        //[Property("SPEC_URL", "-")]
        //[Property("CRITERIA", "MR")]
        //public void ApplyPropertiesVisitorSetPropertyValue()
        //{
        //    tlog.Debug(tag, $"ApplyPropertiesVisitorSetPropertyValue START");

        //    try
        //    {
        //        object o1 = new object();
        //        XmlName xmlName = new XmlName();
        //        Assert.IsNotNull(xmlName, "null XmlName");
        //        object value = new object();
        //        object rootElement = new object();
        //        INodeImplement nodeImplement = new INodeImplement();
        //        Assert.IsNotNull(nodeImplement, "null INodeImplement");
        //        HydrationContext context = new HydrationContext();
        //        Assert.IsNotNull(context, "null HydrationContext");
        //        IXmlLineInfoImplement xmlLineInfoImplement = new IXmlLineInfoImplement();
        //        Assert.IsNotNull(xmlLineInfoImplement, "null IXmlLineInfoImplement");

        //        ApplyPropertiesVisitor.SetPropertyValue(o1, xmlName, value, rootElement, nodeImplement, context, xmlLineInfoImplement);
        //    }
        //    catch (Exception e)
        //    {
        //        tlog.Debug(tag, e.Message.ToString());
        //        Assert.Fail("Caught Exception" + e.ToString());
        //    }
        //    tlog.Debug(tag, $"ApplyPropertiesVisitorSetPropertyValue END");
        //}

        //[Test]
        //[Category("P1")]
        //[Description("ApplyPropertiesVisitor GetPropertyValue")]
        //[Property("SPEC", "Tizen.NUI.ApplyPropertiesVisitor.GetPropertyValue M")]
        //[Property("SPEC_URL", "-")]
        //[Property("CRITERIA", "MR")]
        //public void ApplyPropertiesVisitorGetPropertyValue()
        //{
        //    tlog.Debug(tag, $"ApplyPropertiesVisitorGetPropertyValue START");

        //    try
        //    {
        //        object o1 = new object();
        //        XmlName xmlName = new XmlName();
        //        Assert.IsNotNull(xmlName, "null XmlName");
        //        object value = new object();
        //        INodeImplement nodeImplement = new INodeImplement();
        //        Assert.IsNotNull(nodeImplement, "null INodeImplement");
        //        HydrationContext context = new HydrationContext();
        //        Assert.IsNotNull(context, "null HydrationContext");
        //        IXmlLineInfoImplement xmlLineInfoImplement = new IXmlLineInfoImplement();
        //        Assert.IsNotNull(xmlLineInfoImplement, "null IXmlLineInfoImplement");
        //        ApplyPropertiesVisitor.GetPropertyValue(o1, xmlName, context, xmlLineInfoImplement, out value);
        //    }
        //    catch (Exception e)
        //    {
        //        tlog.Debug(tag, e.Message.ToString());
        //        Assert.Fail("Caught Exception" + e.ToString());
        //    }
        //    tlog.Debug(tag, $"ApplyPropertiesVisitorGetPropertyValue END");
        //}
    }
}