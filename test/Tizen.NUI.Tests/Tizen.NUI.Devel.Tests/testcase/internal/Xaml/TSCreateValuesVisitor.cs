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
    public class InternalCreateValuesVisitorTest
    {
        private const string tag = "NUITEST";
        private CreateValuesVisitor visitor;

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
            visitor = new CreateValuesVisitor(new HydrationContext());
        }

        [TearDown]
        public void Destroy()
        {
            visitor = null;
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
            Assert.IsNotNull(context, "null HydrationContext");
            CreateValuesVisitor createValuesVisitor = new CreateValuesVisitor(context);
            Assert.IsNotNull(createValuesVisitor, "null CreateValuesVisitor");

            tlog.Debug(tag, $"CreateValuesVisitorConstructor END");
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
                var result = visitor.VisitingMode;
                tlog.Debug(tag, "VisitingMode : " + result);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            tlog.Debug(tag, $"CreateValuesVisitorVisitingMode END");
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
                var result = visitor.StopOnDataTemplate;
                tlog.Debug(tag, "StopOnDataTemplate : " + result);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            tlog.Debug(tag, $"CreateValuesVisitorStopOnDataTemplate END");
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
                var result = visitor.StopOnResourceDictionary;
                tlog.Debug(tag, "StopOnResourceDictionary : " + result);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            tlog.Debug(tag, $"CreateValuesVisitorStopOnResourceDictionary END");
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
                var result = visitor.VisitNodeOnDataTemplate;
                tlog.Debug(tag, "VisitNodeOnDataTemplate : " + result);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            tlog.Debug(tag, $"CreateValuesVisitorVisitNodeOnDataTemplate END");
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

            tlog.Debug(tag, $"CreateValuesVisitorSkipChildren END");
        }
    }
}