using NUnit.Framework;
using System;
using System.Reflection;
using Tizen.NUI.Xaml;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("public/xaml/XamlResourceIdAttribute ")]
    public class PublicXamlResourceIdAttributeTest
    {
        private const string tag = "NUITEST";
        private XamlResourceIdAttribute resourceId;
        [SetUp]
        public void Init()
        {
            tlog.Info(tag, "Init() is called!");
            resourceId = new XamlResourceIdAttribute("myId", "myPath", typeof(string));
        }

        [TearDown]
        public void Destroy()
        {
            resourceId = null;
            tlog.Info(tag, "Destroy() is called!");
        }

        [Test]
        [Category("P1")]
        [Description("XamlResourceIdAttribute ResourceId")]
        [Property("SPEC", "Tizen.NUI.XamlResourceIdAttribute.ResourceId A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        public void XamlResourceIdAttributeResourceId()
        {
            tlog.Debug(tag, $"XamlResourceIdAttributeResourceId START");

            try
            {
                var id = resourceId.ResourceId;
                resourceId.ResourceId = id;
                Assert.AreEqual(id, resourceId.ResourceId, "Should be equal");
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            tlog.Debug(tag, $"XamlResourceIdAttributeResourceId END");
        }

        [Test]
        [Category("P1")]
        [Description("XamlResourceIdAttribute Path")]
        [Property("SPEC", "Tizen.NUI.XamlResourceIdAttribute.Path A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        public void XamlResourceIdAttributePath()
        {
            tlog.Debug(tag, $"XamlResourceIdAttributePath START");

            try
            {
                var path = resourceId.Path;
                resourceId.Path = path;
                Assert.AreEqual(path, resourceId.Path, "Should be equal");
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            tlog.Debug(tag, $"XamlResourceIdAttributePath END");
        }

        [Test]
        [Category("P1")]
        [Description("XamlResourceIdAttribute Type")]
        [Property("SPEC", "Tizen.NUI.XamlResourceIdAttribute.Type A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        public void XamlResourceIdAttributeType()
        {
            tlog.Debug(tag, $"XamlResourceIdAttributeType START");

            try
            {
                var type = resourceId.Type;
                resourceId.Type = type;
                Assert.AreEqual(type, resourceId.Type, "Should be equal");
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            tlog.Debug(tag, $"XamlResourceIdAttributeType END");
            Assert.Pass("XamlResourceIdAttributeType");
        }

        [Test]
        [Category("P1")]
        [Description("XamlResourceIdAttribute GetResourceIdForType")]
        [Property("SPEC", "Tizen.NUI.XamlResourceIdAttribute.GetResourceIdForType M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        public void XamlResourceIdAttributeGetResourceIdForType()
        {
            tlog.Debug(tag, $"XamlResourceIdAttributeGetResourceIdForType START");

            try
            {
                XamlResourceIdAttribute.GetResourceIdForType(typeof(string));
            }
            catch (Exception e)
            {
                Tizen.Log.Error(tag, "Caught Exception" + e.ToString());
                Assert.Fail("Caught Exception" + e.ToString());
            }

            tlog.Debug(tag, $"XamlResourceIdAttributeGetResourceIdForType END");
        }

        [Test]
        [Category("P1")]
        [Description("XamlResourceIdAttribute GetPathForType")]
        [Property("SPEC", "Tizen.NUI.XamlResourceIdAttribute.GetPathForType M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        public void XamlResourceIdAttributeGetPathForType()
        {
            tlog.Debug(tag, $"XamlResourceIdAttributeGetPathForType START");

            try
            {
                XamlResourceIdAttribute.GetPathForType(typeof(string));
            }
            catch (Exception e)
            {
                Tizen.Log.Error(tag, "Caught Exception" + e.ToString());
                Assert.Fail("Caught Exception" + e.ToString());
            }

            tlog.Debug(tag, $"XamlResourceIdAttributeGetPathForType END");
        }
    }
}