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
        private static XamlResourceIdAttribute resourceIdAttribute;

        internal class AssemblyImplent : Assembly
        {
            public override object[] GetCustomAttributes(bool inherit)
            {
                return null;
            }
        }

        [SetUp]
        public void Init()
        {
            tlog.Info(tag, "Init() is called!");
            resourceIdAttribute = new XamlResourceIdAttribute("myId", "myPath", typeof(string));
        }

        [TearDown]
        public void Destroy()
        {
            resourceIdAttribute = null;
            tlog.Info(tag, "Destroy() is called!");
        }

        [Test]
        [Category("P1")]
        [Description("XamlResourceIdAttribute XamlResourceIdAttribute")]
        [Property("SPEC", "Tizen.NUI.XamlResourceIdAttribute.XamlResourceIdAttribute C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        public void XamlResourceIdAttributeConstructor()
        {
            tlog.Debug(tag, $"XamlResourceIdAttributeConstructor START");

            XamlResourceIdAttribute x1 = new XamlResourceIdAttribute("myId", "myPath", typeof(string));

            tlog.Debug(tag, $"XamlResourceIdAttributeConstructor END (OK)");
            Assert.Pass("XamlResourceIdAttributeConstructor");
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
                string s1 = resourceIdAttribute.ResourceId;
                resourceIdAttribute.ResourceId = s1;
            }
            catch (Exception e)
            {
                Tizen.Log.Error(tag, "Caught Exception" + e.ToString());
                Assert.Fail("Caught Exception" + e.ToString());
            }

            tlog.Debug(tag, $"XamlResourceIdAttributeResourceId END (OK)");
            Assert.Pass("XamlResourceIdAttributeResourceId");
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
                string s1 = resourceIdAttribute.Path;
                resourceIdAttribute.Path = s1;
            }
            catch (Exception e)
            {
                Tizen.Log.Error(tag, "Caught Exception" + e.ToString());
                Assert.Fail("Caught Exception" + e.ToString());
            }

            tlog.Debug(tag, $"XamlResourceIdAttributePath END (OK)");
            Assert.Pass("XamlResourceIdAttributePath");
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
                Type t1 = resourceIdAttribute.Type;
                resourceIdAttribute.Type = t1;
            }
            catch (Exception e)
            {
                Tizen.Log.Error(tag, "Caught Exception" + e.ToString());
                Assert.Fail("Caught Exception" + e.ToString());
            }

            tlog.Debug(tag, $"XamlResourceIdAttributeType END (OK)");
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

            tlog.Debug(tag, $"XamlResourceIdAttributeGetResourceIdForType END (OK)");
            Assert.Pass("XamlResourceIdAttributeGetResourceIdForType");
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

            tlog.Debug(tag, $"XamlResourceIdAttributeGetPathForType END (OK)");
            Assert.Pass("XamlResourceIdAttributeGetPathForType");
        }

        [Test]
        [Category("P1")]
        [Description("XamlResourceIdAttribute GetTypeForResourceId")]
        [Property("SPEC", "Tizen.NUI.XamlResourceIdAttribute.GetTypeForResourceId M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        public void XamlResourceIdAttributeGetTypeForResourceId()
        {
            tlog.Debug(tag, $"XamlResourceIdAttributeGetTypeForResourceId START");

            try
            {
                AssemblyImplent assembly = new AssemblyImplent();
                XamlResourceIdAttribute.GetTypeForResourceId(assembly, "myResourceId");
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                tlog.Debug(tag, $"XamlResourceIdAttributeGetTypeForResourceId END (OK)");
                Assert.Pass("Caught Exception : passed!");
            }
        }

        [Test]
        [Category("P1")]
        [Description("XamlResourceIdAttribute GetResourceIdForPath")]
        [Property("SPEC", "Tizen.NUI.XamlResourceIdAttribute.GetResourceIdForPath M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        public void XamlResourceIdAttributeGetResourceIdForPath()
        {
            tlog.Debug(tag, $"XamlResourceIdAttributeGetResourceIdForPath START");

            try
            {
                AssemblyImplent assembly = new AssemblyImplent();
                XamlResourceIdAttribute.GetResourceIdForPath(assembly, "myPath");
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                tlog.Debug(tag, $"XamlResourceIdAttributeGetResourceIdForPath END (OK)");
                Assert.Pass("Caught Exception : passed!");
            }
        }

        [Test]
        [Category("P1")]
        [Description("XamlResourceIdAttribute GetTypeForPath")]
        [Property("SPEC", "Tizen.NUI.XamlResourceIdAttribute.GetTypeForPath M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        public void XamlResourceIdAttributeGetTypeForPath()
        {
            tlog.Debug(tag, $"XamlResourceIdAttributeGetTypeForPath START");

            try
            {
                AssemblyImplent assembly = new AssemblyImplent();
                XamlResourceIdAttribute.GetTypeForPath(assembly, "myPath");
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                tlog.Debug(tag, $"XamlResourceIdAttributeGetTypeForPath END (OK)");
                Assert.Pass("Caught Exception : passed!");
            }
        }
    }
}