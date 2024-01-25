using NUnit.Framework;
using System;
using System.Collections.Generic;
using Tizen.NUI.Xaml;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("internal/Xaml/ValueNode")]
    public class InternalValueNodeTest
    {
        private const string tag = "NUITEST";

        [SetUp]
        public void Init()
        {
            tlog.Info(tag, "Init() is called!");
        }

        [TearDown]
        public void Destroy()
        {
            tlog.Info(tag, "Destroy() is called!");
        }

        [Test]
        [Category("P1")]
        [Description("ValueNode Clone")]
        [Property("SPEC", "Tizen.NUI.Xaml.ValueNode.Clone M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        public void ValueNodeCloneTest()
        {
            tlog.Debug(tag, $"ValueNodeCloneTest START");

            try
            {
                var node = new ValueNode("1", null, 1, 1);
                var ret = node.Clone();
                Assert.IsNotNull(ret, "Should not be equal");
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            tlog.Debug(tag, $"ValueNodeCloneTest END");
        }

        [Test]
        [Category("P1")]
        [Description("MarkupNode Clone")]
        [Property("SPEC", "Tizen.NUI.Xaml.MarkupNode.Clone M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        public void MarkupNodeCloneTest()
        {
            tlog.Debug(tag, $"MarkupNodeCloneTest START");

            try
            {
                var node = new MarkupNode("1", null, 1, 1);
                var ret = node.Clone();
                Assert.IsNotNull(ret, "Should not be equal");
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            tlog.Debug(tag, $"MarkupNodeCloneTest END");
        }

        [Test]
        [Category("P1")]
        [Description("ElementNode Clone")]
        [Property("SPEC", "Tizen.NUI.Xaml.ElementNode.Clone M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        public void ElementNodeCloneTest()
        {
            tlog.Debug(tag, $"ElementNodeCloneTest START");

            try
            {
                var node = new ElementNode(null, "1", null, 1, 1);
                node.Properties.Add(new XmlName("1", "View"), new ElementNode(null, "1", null, 1, 1));
                node.SkipProperties.Add(new XmlName("1", "View"));
                node.CollectionItems.Add(new ElementNode(null, "1", null, 1, 1));
                var ret = node.Clone();
                Assert.IsNotNull(ret, "Should not be equal");
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            tlog.Debug(tag, $"ElementNodeCloneTest END");
        }

        [Test]
        [Category("P1")]
        [Description("ListNode Clone")]
        [Property("SPEC", "Tizen.NUI.Xaml.ListNode.Clone M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        public void ListNodeCloneTest()
        {
            tlog.Debug(tag, $"ListNodeCloneTest START");

            try
            {
                List<INode> nodes = new List<INode>() { new ElementNode(null, "1", null, 1, 1) };
                var node = new ListNode(nodes, null, 1, 1);
                var ret = node.Clone();
                Assert.IsNotNull(ret, "Should not be equal");
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            tlog.Debug(tag, $"ListNodeCloneTest END");
        }

        [Test]
        [Category("P1")]
        [Description("ListNode Clone")]
        [Property("SPEC", "Tizen.NUI.Xaml.INodeExtensions.Clone M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        public void INodeExtensionsSkipPrefixTest()
        {
            tlog.Debug(tag, $"INodeExtensionsSkipPrefixTest START");

            try
            {
                var node = new ElementNode(null, "1", null, 1, 1);
                node.IgnorablePrefixes = new List<string>() { "1" };
                var ret = node.SkipPrefix("1");
                
                Assert.True(ret, "Should be true");
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            tlog.Debug(tag, $"INodeExtensionsSkipPrefixTest END");
        }
    }
}