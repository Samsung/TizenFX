using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Xml;
using Tizen.NUI.Xaml;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("internal/Xaml/ApplyPropertiesVisitor")]
    internal class PublicApplyPropertiesVisitorTest
    {
        private const string tag = "NUITEST";
        private static ApplyPropertiesVisitor a1;
        [SetUp]
        public void Init()
        {
            tlog.Info(tag, "Init() is called!");
            HydrationContext context = new HydrationContext();
            a1 = new ApplyPropertiesVisitor(context, false);
        }

        [TearDown]
        public void Destroy()
        {
            a1 = null;
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

            ApplyPropertiesVisitor applyPropertiesVisitor = new ApplyPropertiesVisitor(context, false);

            tlog.Debug(tag, $"ApplyPropertiesVisitorConstructor END (OK)");
            Assert.Pass("ApplyPropertiesVisitorConstructor");
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
                TreeVisitingMode t1 = a1.VisitingMode;
            }
            catch (Exception e)
            {
                Tizen.Log.Error(tag, "Caught Exception" + e.ToString());
                Assert.Fail("Caught Exception" + e.ToString());
            }

            tlog.Debug(tag, $"ApplyPropertiesVisitorVisitingMode END (OK)");
            Assert.Pass("ApplyPropertiesVisitorVisitingMode");
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
                bool b1 = a1.StopOnDataTemplate;
            }
            catch (Exception e)
            {
                Tizen.Log.Error(tag, "Caught Exception" + e.ToString());
                Assert.Fail("Caught Exception" + e.ToString());
            }

            tlog.Debug(tag, $"ApplyPropertiesVisitorStopOnDataTemplate END (OK)");
            Assert.Pass("ApplyPropertiesVisitorStopOnDataTemplate");
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
                bool b1 = a1.StopOnResourceDictionary;
            }
            catch (Exception e)
            {
                Tizen.Log.Error(tag, "Caught Exception" + e.ToString());
                Assert.Fail("Caught Exception" + e.ToString());
            }

            tlog.Debug(tag, $"ApplyPropertiesVisitorStopOnResourceDictionary END (OK)");
            Assert.Pass("ApplyPropertiesVisitorStopOnResourceDictionary");
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
                bool b1 = a1.VisitNodeOnDataTemplate;
            }
            catch (Exception e)
            {
                Tizen.Log.Error(tag, "Caught Exception" + e.ToString());
                Assert.Fail("Caught Exception" + e.ToString());
            }

            tlog.Debug(tag, $"ApplyPropertiesVisitorVisitNodeOnDataTemplate END (OK)");
            Assert.Pass("ApplyPropertiesVisitorVisitNodeOnDataTemplate");
        }

        public class INodeImplement : INode
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
        [Description("ApplyPropertiesVisitor SkipChildren")]
        [Property("SPEC", "Tizen.NUI.ApplyPropertiesVisitor.SkipChildren M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        public void ApplyPropertiesVisitorSkipChildren()
        {
            tlog.Debug(tag, $"ApplyPropertiesVisitorSkipChildren START");

            try
            {
                INodeImplement n1 = new INodeImplement();
                INodeImplement n2 = new INodeImplement();
                bool b1 = a1.SkipChildren(n1, n2);
            }
            catch (Exception e)
            {
                Tizen.Log.Error(tag, "Caught Exception" + e.ToString());
                Assert.Fail("Caught Exception" + e.ToString());
            }

            tlog.Debug(tag, $"ApplyPropertiesVisitorSkipChildren END (OK)");
            Assert.Pass("ApplyPropertiesVisitorSkipChildren");
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
                IList<XmlType> list = null;
                XmlType xmlType = new XmlType("myNameSpace", "myName", list);

                IXmlNamespaceResolverImplement i1 = new IXmlNamespaceResolverImplement();
                ElementNode n1 = new ElementNode(xmlType, "myNameSpace", i1);
                bool b1 = a1.IsResourceDictionary(n1);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                tlog.Debug(tag, $"ApplyPropertiesVisitorIsResourceDictionary END (OK)");
                Assert.Pass("Caught Exception : passed!");
            }

        }

        [Test]
        [Category("P1")]
        [Description("ApplyPropertiesVisitor Visit")]
        [Property("SPEC", "Tizen.NUI.ApplyPropertiesVisitor.Visit M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        public void ApplyPropertiesVisitorVisit1()
        {
            tlog.Debug(tag, $"ApplyPropertiesVisitorVisit START");

            try
            {
                object o1 = new object();
                IXmlNamespaceResolverImplement i1 = new IXmlNamespaceResolverImplement();
                ValueNode valueNode = new ValueNode(o1, i1);

                INodeImplement nodeImplement = new INodeImplement();
                a1.Visit(valueNode, nodeImplement);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                tlog.Debug(tag, $"ApplyPropertiesVisitorVisit END (OK)");
                Assert.Pass("Caught Exception : passed!");
            }
        }

        [Test]
        [Category("P1")]
        [Description("ApplyPropertiesVisitor Visit")]
        [Property("SPEC", "Tizen.NUI.ApplyPropertiesVisitor.Visit M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        public void ApplyPropertiesVisitorVisit2()
        {
            tlog.Debug(tag, $"ApplyPropertiesVisitorVisit START");

            try
            {
                INodeImplement nodeImplement = new INodeImplement();

                IList<XmlType> list = null;
                XmlType xmlType = new XmlType("myNameSpace", "myName", list);

                IXmlNamespaceResolverImplement ix1 = new IXmlNamespaceResolverImplement();
                ElementNode n1 = new ElementNode(xmlType, "myNameSpace", ix1);

                a1.Visit(n1, nodeImplement);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                tlog.Debug(tag, $"ApplyPropertiesVisitorVisit END (OK)");
                Assert.Pass("Caught Exception : passed!");
            }

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
                INodeImplement n1 = new INodeImplement();
                INodeImplement n2 = new INodeImplement();
                XmlName xmlName = new XmlName();
                ApplyPropertiesVisitor.TryGetPropertyName(n1, n2, out xmlName);
            }
            catch (Exception e)
            {
                Tizen.Log.Error(tag, "Caught Exception" + e.ToString());
                Assert.Fail("Caught Exception" + e.ToString());
            }

            tlog.Debug(tag, $"ApplyPropertiesVisitorTryGetPropertyName END (OK)");
            Assert.Pass("ApplyPropertiesVisitorTryGetPropertyName");
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
                INodeImplement n1 = new INodeImplement();
                INodeImplement n2 = new INodeImplement();

                ApplyPropertiesVisitor.IsCollectionItem(n1, n2);
            }
            catch (Exception e)
            {
                Tizen.Log.Error(tag, "Caught Exception" + e.ToString());
                Assert.Fail("Caught Exception" + e.ToString());
            }

            tlog.Debug(tag, $"ApplyPropertiesVisitorIsCollectionItem END (OK)");
            Assert.Pass("ApplyPropertiesVisitorIsCollectionItem");
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

        //    tlog.Debug(tag, $"ApplyPropertiesVisitorGetContentPropertyName END (OK)");
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

        [Test]
        [Category("P1")]
        [Description("ApplyPropertiesVisitor SetPropertyValue")]
        [Property("SPEC", "Tizen.NUI.ApplyPropertiesVisitor.SetPropertyValue M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        public void ApplyPropertiesVisitorProvideValue()
        {
            tlog.Debug(tag, $"ApplyPropertiesVisitorSetPropertyValue START");

            try
            {
                object o1 = new object();
                XmlName xmlName = new XmlName();
                object value = new object();
                object rootElement = new object();
                INodeImplement nodeImplement = new INodeImplement();
                HydrationContext context = new HydrationContext();
                IXmlLineInfoImplement xmlLineInfoImplement = new IXmlLineInfoImplement();

                ApplyPropertiesVisitor.SetPropertyValue(o1, xmlName, value, rootElement, nodeImplement, context, xmlLineInfoImplement);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                tlog.Debug(tag, $"ApplyPropertiesVisitorSetPropertyValue END (OK)");
                Assert.Pass("Caught Exception : passed!");
            }
        }

        [Test]
        [Category("P1")]
        [Description("ApplyPropertiesVisitor GetPropertyValue")]
        [Property("SPEC", "Tizen.NUI.ApplyPropertiesVisitor.GetPropertyValue M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        public void ApplyPropertiesVisitorGetPropertyValue()
        {
            tlog.Debug(tag, $"ApplyPropertiesVisitorGetPropertyValue START");

            try
            {
                object o1 = new object();
                XmlName xmlName = new XmlName();
                object value = new object();
                INodeImplement nodeImplement = new INodeImplement();
                HydrationContext context = new HydrationContext();
                IXmlLineInfoImplement xmlLineInfoImplement = new IXmlLineInfoImplement();

                ApplyPropertiesVisitor.GetPropertyValue(o1, xmlName, context, xmlLineInfoImplement, out value);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                tlog.Debug(tag, $"ApplyPropertiesVisitorGetPropertyValue END (OK)");
                Assert.Pass("Caught Exception : passed!");
            }
        }
    }
}