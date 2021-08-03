using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Xml;
using Tizen.NUI.Xaml;

namespace Tizen.NUI.Devel.Tests
{
    using Tizen.NUI.Binding.Internals;
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("internal/Xaml/CreateValuesVisitor")]
    public class InternalXamlCreateValuesVisitorTest
    {
        private const string tag = "NUITEST";
        private CreateValuesVisitor c1;

        [SetUp]
        public void Init()
        {
            tlog.Info(tag, "Init() is called!");
            HydrationContext context = new HydrationContext();
            c1 = new CreateValuesVisitor(context);
        }

        [TearDown]
        public void Destroy()
        {
            c1 = null;
            tlog.Info(tag, "Destroy() is called!");
        }

        [Test]
        [Category("P1")]
        [Description("CreateValuesVisitor CreateValuesVisitor")]
        [Property("SPEC", "Tizen.NUI.CreateValuesVisitor.CreateValuesVisitor C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        public void CreateValuesVisitorConstructor()
        {
            tlog.Debug(tag, $"ApplyPropertiesVisitorConstructor START");

            HydrationContext context = new HydrationContext();

            CreateValuesVisitor createValuesVisitor = new CreateValuesVisitor(context);

            tlog.Debug(tag, $"CreateValuesVisitorConstructor END (OK)");
            Assert.Pass("CreateValuesVisitorConstructor");
        }

        [Test]
        [Category("P1")]
        [Description("CreateValuesVisitor VisitingMode")]
        [Property("SPEC", "Tizen.NUI.CreateValuesVisitor.VisitingMode A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        public void CreateValuesVisitorVisitingMode()
        {
            tlog.Debug(tag, $"CreateValuesVisitorVisitingMode START");

            try
            {
                TreeVisitingMode t1 = c1.VisitingMode;
            }
            catch (Exception e)
            {
                Tizen.Log.Error(tag, "Caught Exception" + e.ToString());
                Assert.Fail("Caught Exception" + e.ToString());
            }

            tlog.Debug(tag, $"CreateValuesVisitorVisitingMode END (OK)");
            Assert.Pass("CreateValuesVisitorVisitingMode");
        }

        [Test]
        [Category("P1")]
        [Description("CreateValuesVisitor StopOnDataTemplate")]
        [Property("SPEC", "Tizen.NUI.CreateValuesVisitor.StopOnDataTemplate A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        public void CreateValuesVisitorStopOnDataTemplate()
        {
            tlog.Debug(tag, $"CreateValuesVisitorStopOnDataTemplate START");

            try
            {
                bool b1 = c1.StopOnDataTemplate;
            }
            catch (Exception e)
            {
                Tizen.Log.Error(tag, "Caught Exception" + e.ToString());
                Assert.Fail("Caught Exception" + e.ToString());
            }

            tlog.Debug(tag, $"CreateValuesVisitorStopOnDataTemplate END (OK)");
            Assert.Pass("CreateValuesVisitorStopOnDataTemplate");
        }

        [Test]
        [Category("P1")]
        [Description("CreateValuesVisitor StopOnResourceDictionary ")]
        [Property("SPEC", "Tizen.NUI.CreateValuesVisitor.StopOnResourceDictionary  A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        public void CreateValuesVisitorStopOnResourceDictionary()
        {
            tlog.Debug(tag, $"CreateValuesVisitorStopOnResourceDictionary START");

            try
            {
                bool b1 = c1.StopOnResourceDictionary;
            }
            catch (Exception e)
            {
                Tizen.Log.Error(tag, "Caught Exception" + e.ToString());
                Assert.Fail("Caught Exception" + e.ToString());
            }

            tlog.Debug(tag, $"CreateValuesVisitorStopOnResourceDictionary END (OK)");
            Assert.Pass("CreateValuesVisitorStopOnResourceDictionary");
        }

        [Test]
        [Category("P1")]
        [Description("CreateValuesVisitor VisitNodeOnDataTemplate  ")]
        [Property("SPEC", "Tizen.NUI.CreateValuesVisitor.VisitNodeOnDataTemplate   A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        public void CreateValuesVisitorVisitNodeOnDataTemplate()
        {
            tlog.Debug(tag, $"CreateValuesVisitorVisitNodeOnDataTemplate START");

            try
            {
                bool b1 = c1.VisitNodeOnDataTemplate;
            }
            catch (Exception e)
            {
                Tizen.Log.Error(tag, "Caught Exception" + e.ToString());
                Assert.Fail("Caught Exception" + e.ToString());
            }

            tlog.Debug(tag, $"CreateValuesVisitorVisitNodeOnDataTemplate END (OK)");
            Assert.Pass("CreateValuesVisitorVisitNodeOnDataTemplate");
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
        [Description("CreateValuesVisitor SkipChildren")]
        [Property("SPEC", "Tizen.NUI.CreateValuesVisitor.SkipChildren M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        public void CreateValuesVisitorSkipChildren()
        {
            tlog.Debug(tag, $"CreateValuesVisitorSkipChildren START");

            try
            {
                INodeImplement node = new INodeImplement();
                INodeImplement nodeParent = new INodeImplement();
                bool b1 = c1.SkipChildren(node, nodeParent);
            }
            catch (Exception e)
            {
                Tizen.Log.Error(tag, "Caught Exception" + e.ToString());
                Assert.Fail("Caught Exception" + e.ToString());
            }

            tlog.Debug(tag, $"CreateValuesVisitorSkipChildren END (OK)");
            Assert.Pass("CreateValuesVisitorSkipChildren");
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
        //[Description("CreateValuesVisitor IsResourceDictionary")]
        //[Property("SPEC", "Tizen.NUI.CreateValuesVisitor.IsResourceDictionary M")]
        //[Property("SPEC_URL", "-")]
        //[Property("CRITERIA", "MR")]
        //public void CreateValuesVisitorIsResourceDictionary()
        //{
        //    tlog.Debug(tag, $"CreateValuesVisitorIsResourceDictionary START");

        //    try
        //    {
        //        IList<XmlType> list = null;
        //        XmlType xmlType = new XmlType("myNameSpace", "myName", list);

        //        IXmlNamespaceResolverImplement i1 = new IXmlNamespaceResolverImplement();
        //        ElementNode n1 = new ElementNode(xmlType, "myNameSpace", i1);

        //        bool b1 = c1.IsResourceDictionary(n1);
        //    }
        //    catch (Exception e)
        //    {
        //        tlog.Debug(tag, e.Message.ToString());
        //        tlog.Debug(tag, $"CreateValuesVisitorIsResourceDictionary END (OK)");
        //        Assert.Pass("Caught Exception : passed!");
        //    }
        //}

        //public class RootNodeImplement : RootNode
        //{
        //    public RootNodeImplement(XmlType xmlType, IXmlNamespaceResolver nsResolver) : base(xmlType, nsResolver)
        //    {
        //    }
        //}

        //[Test]
        //[Category("P1")]
        //[Description("CreateValuesVisitor Visit")]
        //[Property("SPEC", "Tizen.NUI.CreateValuesVisitor.Visit M")]
        //[Property("SPEC_URL", "-")]
        //[Property("CRITERIA", "MR")]
        //public void CreateValuesVisitorVisit1()
        //{
        //    tlog.Debug(tag, $"CreateValuesVisitorVisit START");

        //    try
        //    {
        //        object o1 = new object();
        //        IXmlNamespaceResolverImplement i1 = new IXmlNamespaceResolverImplement();
        //        ValueNode node = new ValueNode(o1, i1);
        //        INodeImplement parentNode = new INodeImplement();
        //        c1.Visit(node, parentNode);
        //    }
        //    catch (Exception e)
        //    {
        //        Tizen.Log.Error(tag, "Caught Exception" + e.ToString());
        //        Assert.Fail("Caught Exception" + e.ToString());
        //    }

        //    tlog.Debug(tag, $"CreateValuesVisitorVisit END (OK)");
        //    Assert.Pass("CreateValuesVisitorVisit");
        //}

        //[Test]
        //[Category("P1")]
        //[Description("CreateValuesVisitor Visit")]
        //[Property("SPEC", "Tizen.NUI.CreateValuesVisitor.Visit M")]
        //[Property("SPEC_URL", "-")]
        //[Property("CRITERIA", "MR")]
        //public void CreateValuesVisitorVisit2()
        //{
        //    tlog.Debug(tag, $"CreateValuesVisitorVisit START");

        //    try
        //    {
        //        INodeImplement parentNode = new INodeImplement();

        //        IXmlNamespaceResolverImplement i1 = new IXmlNamespaceResolverImplement();
        //        IList<XmlType> list = null;
        //        XmlType xmlType = new XmlType("myNameSpace", "myName", list);

        //        ElementNode n1 = new ElementNode(xmlType, "myNameSpace", i1);

        //        c1.Visit(n1, parentNode);
        //    }
        //    catch (Exception e)
        //    {
        //        tlog.Debug(tag, e.Message.ToString());
        //        tlog.Debug(tag, $"CreateValuesVisitorVisit END (OK)");
        //        Assert.Pass("Caught Exception : passed!");
        //    }
        //}

        //[Test]
        //[Category("P1")]
        //[Description("CreateValuesVisitor Visit")]
        //[Property("SPEC", "Tizen.NUI.CreateValuesVisitor.Visit M")]
        //[Property("SPEC_URL", "-")]
        //[Property("CRITERIA", "MR")]
        //public void CreateValuesVisitorVisit3()
        //{
        //    tlog.Debug(tag, $"CreateValuesVisitorVisit START");

        //    try
        //    {
        //        INodeImplement parentNode = new INodeImplement();
        //        IXmlNamespaceResolverImplement i1 = new IXmlNamespaceResolverImplement();
        //        IList<XmlType> list = null;
        //        XmlType xmlType = new XmlType("myNameSpace", "myName", list);
        //        RootNodeImplement rootNode = new RootNodeImplement(xmlType, i1);
        //        c1.Visit(rootNode, parentNode);
        //    }
        //    catch (Exception e)
        //    {
        //        tlog.Debug(tag, e.Message.ToString());
        //        tlog.Debug(tag, $"CreateValuesVisitorVisit END (OK)");
        //        Assert.Pass("Caught Exception : passed!");
        //    }

        //}

        //public class IElementNodeImplement : IElementNode
        //{
        //    public Dictionary<XmlName, INode> Properties => throw new NotImplementedException();

        //    public List<XmlName> SkipProperties => throw new NotImplementedException();

        //    public INameScope Namescope => throw new NotImplementedException();

        //    public XmlType XmlType => throw new NotImplementedException();

        //    public string NamespaceURI => throw new NotImplementedException();

        //    public List<INode> CollectionItems => throw new NotImplementedException();

        //    public List<string> IgnorablePrefixes { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        //    public IXmlNamespaceResolver NamespaceResolver => throw new NotImplementedException();

        //    public INode Parent { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        //    public void Accept(IXamlNodeVisitor visitor, INode parentNode)
        //    {
        //        throw new NotImplementedException();
        //    }

        //    public INode Clone()
        //    {
        //        throw new NotImplementedException();
        //    }
        //}

        //[Test]
        //[Category("P1")]
        //[Description("CreateValuesVisitor CreateFromParameterizedConstructor")]
        //[Property("SPEC", "Tizen.NUI.CreateValuesVisitor.CreateFromParameterizedConstructor M")]
        //[Property("SPEC_URL", "-")]
        //[Property("CRITERIA", "MR")]
        //public void CreateValuesVisitorCreateFromParameterizedConstructor()
        //{
        //    tlog.Debug(tag, $"CreateValuesVisitorCreateFromParameterizedConstructor START");

        //    try
        //    {
        //        Type type = typeof(string);
        //        IElementNodeImplement i1 = new IElementNodeImplement();
        //        c1.CreateFromParameterizedConstructor(type, i1);
        //    }
        //    catch (Exception e)
        //    {
        //        Tizen.Log.Error(tag, "Caught Exception" + e.ToString());
        //        Assert.Fail("Caught Exception" + e.ToString());
        //    }

        //    tlog.Debug(tag, $"CreateValuesVisitorCreateFromParameterizedConstructor END (OK)");
        //    Assert.Pass("CreateValuesVisitorCreateFromParameterizedConstructor");
        //}

        //[Test]
        //[Category("P1")]
        //[Description("CreateValuesVisitor CreateFromFactory")]
        //[Property("SPEC", "Tizen.NUI.CreateValuesVisitor.CreateFromFactory M")]
        //[Property("SPEC_URL", "-")]
        //[Property("CRITERIA", "MR")]
        //public void CreateValuesVisitorCreateFromFactory()
        //{
        //    tlog.Debug(tag, $"CreateValuesVisitorCreateFromFactory START");

        //    try
        //    {
        //        Type type = typeof(string);
        //        IElementNodeImplement i1 = new IElementNodeImplement();
        //        c1.CreateFromFactory(type, i1);
        //    }
        //    catch (Exception e)
        //    {
        //        tlog.Debug(tag, e.Message.ToString());
        //        tlog.Debug(tag, $"CreateValuesVisitorCreateFromFactory END (OK)");
        //        Assert.Pass("Caught Exception : passed!");
        //    }
        //}

        //[Test]
        //[Category("P1")]
        //[Description("CreateValuesVisitor CreateArgumentsArray")]
        //[Property("SPEC", "Tizen.NUI.CreateValuesVisitor.CreateArgumentsArray M")]
        //[Property("SPEC_URL", "-")]
        //[Property("CRITERIA", "MR")]
        //public void CreateValuesVisitorCreateArgumentsArray()
        //{
        //    tlog.Debug(tag, $"CreateValuesVisitorCreateArgumentsArray START");

        //    try
        //    {
        //        IElementNodeImplement i1 = new IElementNodeImplement();
        //        c1.CreateArgumentsArray(i1);
        //    }
        //    catch (Exception e)
        //    {
        //        tlog.Debug(tag, e.Message.ToString());
        //        tlog.Debug(tag, $"CreateValuesVisitorCreateArgumentsArray END (OK)");
        //        Assert.Pass("Caught Exception : passed!");
        //    }
        //}
    }
}