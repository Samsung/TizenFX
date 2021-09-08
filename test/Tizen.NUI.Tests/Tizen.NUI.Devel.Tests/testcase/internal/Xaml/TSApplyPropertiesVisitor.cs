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
    }
}