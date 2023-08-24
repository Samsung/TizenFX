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
    }
}