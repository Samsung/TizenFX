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
    public class InternalPruneIgnoredNodesVisitorTest
    {
        private const string tag = "NUITEST";
        private PruneIgnoredNodesVisitor visitor;

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
            visitor = new PruneIgnoredNodesVisitor();
        }

        [TearDown]
        public void Destroy()
        {
            visitor = null;
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
                var result = visitor.VisitingMode;
                tlog.Debug(tag, "VisitingMode : " + result);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            tlog.Debug(tag, $"PruneIgnoredNodesVisitorVisitingMode END");
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
                var result = visitor.StopOnDataTemplate;
                tlog.Debug(tag, "StopOnDataTemplate : " + result);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            tlog.Debug(tag, $"NamescopingVisitorStopOnDataTemplate END");
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
                var result = visitor.StopOnResourceDictionary;
                tlog.Debug(tag, "StopOnResourceDictionary : " + result);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            tlog.Debug(tag, $"NamescopingVisitorStopOnResourceDictionary END");
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
                var result = visitor.VisitNodeOnDataTemplate;
                tlog.Debug(tag, "VisitNodeOnDataTemplate : " + result);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            tlog.Debug(tag, $"NamescopingVisitorVisitNodeOnDataTemplate END");
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

            tlog.Debug(tag, $"NamescopingVisitorSkipChildren END");
        }
    }
}