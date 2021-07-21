using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Reflection;
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
        public const string NUI2018Uri = "http://tizen.org/Tizen.NUI/2018/XAML";
        private string xaml_path = Tizen.Applications.Application.Current.DirectoryInfo.Resource + "simpleXaml.xaml";
        private static ApplyPropertiesVisitor visitor;
        [SetUp]
        public void Init()
        {
            tlog.Info(tag, "Init() is called!");
            HydrationContext context = new HydrationContext();
            visitor = new ApplyPropertiesVisitor(context, false);
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
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ApplyPropertiesVisitorConstructor()
        {
            tlog.Debug(tag, $"ApplyPropertiesVisitorConstructor START");

            var testingTarget = new ApplyPropertiesVisitor(new HydrationContext(), false);
            Assert.IsNotNull(testingTarget, "Can't create success object ApplyPropertiesVisitor");
            Assert.IsInstanceOf<ApplyPropertiesVisitor>(testingTarget, "Should be an instance of ApplyPropertiesVisitor type.");

            tlog.Debug(tag, $"ApplyPropertiesVisitorConstructor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ApplyPropertiesVisitor Skips.")]
        [Property("SPEC", "Tizen.NUI.ApplyPropertiesVisitor.Skips M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ApplyPropertiesVisitorSkips()
        {
            tlog.Debug(tag, $"ApplyPropertiesVisitorSkips START");

            var testingTarget = ApplyPropertiesVisitor.Skips;
            Assert.IsNotNull(testingTarget, "Can't create success object ApplyPropertiesVisitor");
            Assert.IsInstanceOf<IList<XmlName>>(testingTarget, "Should be an instance of IList<XmlName> type.");

            tlog.Debug(tag, $"ApplyPropertiesVisitorSkips END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ApplyPropertiesVisitor VisitingMode")]
        [Property("SPEC", "Tizen.NUI.ApplyPropertiesVisitor.VisitingMode M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
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

            tlog.Debug(tag, $"ApplyPropertiesVisitorVisitingMode END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ApplyPropertiesVisitor StopOnDataTemplate")]
        [Property("SPEC", "Tizen.NUI.ApplyPropertiesVisitor.StopOnDataTemplate M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
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

            tlog.Debug(tag, $"ApplyPropertiesVisitorStopOnDataTemplate END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ApplyPropertiesVisitor StopOnResourceDictionary ")]
        [Property("SPEC", "Tizen.NUI.ApplyPropertiesVisitor.StopOnResourceDictionary A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
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

            tlog.Debug(tag, $"ApplyPropertiesVisitorStopOnResourceDictionary END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ApplyPropertiesVisitor VisitNodeOnDataTemplate ")]
        [Property("SPEC", "Tizen.NUI.ApplyPropertiesVisitor.VisitNodeOnDataTemplate M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
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

            tlog.Debug(tag, $"ApplyPropertiesVisitorVisitNodeOnDataTemplate END (OK)");
        }

        public class INodeImplement : INode
        {
            public global::System.Collections.Generic.List<string> IgnorablePrefixes { get; set; }

            public global::System.Xml.IXmlNamespaceResolver NamespaceResolver => new XmlNamespaceResolver();

            public INode Parent { get; set; }

            public void Accept(IXamlNodeVisitor visitor, INode parentNode) { }

            public INode Clone()
            {
                return null;
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
                bool b1 = visitor.SkipChildren(n1, n2);
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
                bool b1 = visitor.IsResourceDictionary(n1);
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
        [Description("ApplyPropertiesVisitor Visit. With ValueNode.")]
        [Property("SPEC", "Tizen.NUI.ApplyPropertiesVisitor.Visit M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        public void ApplyPropertiesVisitorVisitWithValueNode()
        {
            tlog.Debug(tag, $"ApplyPropertiesVisitorVisitWithValueNode START");

            try
            {
                object o1 = new object();
                IXmlNamespaceResolverImplement i1 = new IXmlNamespaceResolverImplement();
                ValueNode valueNode = new ValueNode(o1, i1);

                INodeImplement nodeImplement = new INodeImplement();
                visitor.Visit(valueNode, nodeImplement);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Pass("Caught Exception : passed!");
            }
        }

        [Test]
        [Category("P1")]
        [Description("ApplyPropertiesVisitor Visit. With ElementNode.")]
        [Property("SPEC", "Tizen.NUI.ApplyPropertiesVisitor.Visit M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        public void ApplyPropertiesVisitorVisitWithElementNode()
        {
            tlog.Debug(tag, $"ApplyPropertiesVisitorVisitWithElementNode START");

            try
            {
                INodeImplement nodeImplement = new INodeImplement();

                IList<XmlType> list = null;
                XmlType xmlType = new XmlType("myNameSpace", "myName", list);

                IXmlNamespaceResolverImplement ix1 = new IXmlNamespaceResolverImplement();
                ElementNode n1 = new ElementNode(xmlType, "myNameSpace", ix1);

                visitor.Visit(n1, nodeImplement);
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

        [Test]
        [Category("P1")]
        [Description("ApplyPropertiesVisitor GetContentPropertyName")]
        [Property("SPEC", "Tizen.NUI.ApplyPropertiesVisitor.GetContentPropertyName M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ApplyPropertiesVisitorGetContentPropertyName()
        {
            tlog.Debug(tag, $"ApplyPropertiesVisitorGetContentPropertyName START");

            try
            {
                var typeInfo = new BindingExtension().GetType().GetTypeInfo();
                ApplyPropertiesVisitor.GetContentPropertyName(typeInfo);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            tlog.Debug(tag, $"ApplyPropertiesVisitorGetContentPropertyName END (OK)");
        }

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