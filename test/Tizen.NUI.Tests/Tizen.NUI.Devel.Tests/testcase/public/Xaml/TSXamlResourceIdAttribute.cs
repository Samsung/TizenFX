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
		
		private class AssemblyImplent : Assembly
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
        [Description("XamlResourceIdAttribute XamlResourceIdAttribute")]
        [Property("SPEC", "Tizen.NUI.XamlResourceIdAttribute.XamlResourceIdAttribute C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        public void XamlResourceIdAttributeConstructor()
        {
            tlog.Debug(tag, $"XamlResourceIdAttributeConstructor START");

            XamlResourceIdAttribute x1 = new XamlResourceIdAttribute("myId", "myPath", typeof(string));
            Assert.IsNotNull(x1, "null XamlResourceIdAttribute");
            Assert.IsInstanceOf<XamlResourceIdAttribute>(x1, "Should return XamlResourceIdAttribute instance.");
            tlog.Debug(tag, $"XamlResourceIdAttributeConstructor END");
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
        [Description("XamlResourceIdAttribute GetResourceIdForPath")]
        [Property("SPEC", "Tizen.NUI.XamlResourceIdAttribute.GetResourceIdForPath M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        public void XamlResourceIdAttributeGetResourceIdForPath()
        {
            tlog.Debug(tag, $"XamlResourceIdAttributeGetResourceIdForPath START");

            try
            {
                var ret = XamlResourceIdAttribute.GetResourceIdForPath(typeof(UIElement).Assembly, "testcase.public.Xaml.TotalSample.ClockView.xaml");
                Assert.IsNotNull(ret, "Shouldn't be null");
            }
            catch (Exception e)
            {
                Tizen.Log.Error(tag, "Caught Exception" + e.ToString());
                Assert.Fail("Caught Exception" + e.ToString());
            }

            tlog.Debug(tag, $"XamlResourceIdAttributeGetResourceIdForPath END");
        }

        [Test]
        [Category("P1")]
        [Description("XamlResourceIdAttribute GetResourceIdForPath")]
        [Property("SPEC", "Tizen.NUI.XamlResourceIdAttribute.GetResourceIdForPath M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        public void XamlResourceIdAttributeGetResourceIdForPath2()
        {
            tlog.Debug(tag, $"XamlResourceIdAttributeGetResourceIdForPath2 START");

            try
            {
                var ret = XamlResourceIdAttribute.GetResourceIdForPath(typeof(UIElement).Assembly, "none.xaml");
                Assert.IsNull(ret, "Should be null");

            }
            catch (Exception e)
            {
                Tizen.Log.Error(tag, "Caught Exception" + e.ToString());
                Assert.Fail("Caught Exception" + e.ToString());
            }

            tlog.Debug(tag, $"XamlResourceIdAttributeGetResourceIdForPath2 END");
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
                var ret = XamlResourceIdAttribute.GetTypeForResourceId(typeof(UIElement).Assembly, "Tizen.NUI.Devel.Tests.testcase.public.Xaml.TotalSample.ClockView.xaml");
                Assert.IsNotNull(ret, "Shouldn't be null");
            }
            catch (Exception e)
            {
                Tizen.Log.Error(tag, "Caught Exception" + e.ToString());
                Assert.Fail("Caught Exception" + e.ToString());
            }

            tlog.Debug(tag, $"XamlResourceIdAttributeGetTypeForResourceId END");
        }

        [Test]
        [Category("P1")]
        [Description("XamlResourceIdAttribute GetTypeForResourceId")]
        [Property("SPEC", "Tizen.NUI.XamlResourceIdAttribute.GetTypeForResourceId M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        public void XamlResourceIdAttributeGetTypeForResourceId2()
        {
            tlog.Debug(tag, $"XamlResourceIdAttributeGetTypeForResourceId2 START");

            try
            {
                var ret = XamlResourceIdAttribute.GetTypeForResourceId(typeof(UIElement).Assembly, "none.xaml");
                Assert.IsNull(ret, "Should be null");
            }
            catch (Exception e)
            {
                Tizen.Log.Error(tag, "Caught Exception" + e.ToString());
                Assert.Fail("Caught Exception" + e.ToString());
            }

            tlog.Debug(tag, $"XamlResourceIdAttributeGetTypeForResourceId2 END");
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
                var ret = XamlResourceIdAttribute.GetPathForType(typeof(TotalSample));
                Assert.IsNotNull(ret, "Shouldn't be null");
            }
            catch (Exception e)
            {
                Tizen.Log.Error(tag, "Caught Exception" + e.ToString());
                Assert.Fail("Caught Exception" + e.ToString());
            }

            tlog.Debug(tag, $"XamlResourceIdAttributeGetPathForType END");
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
                var ret = XamlResourceIdAttribute.GetTypeForPath(typeof(UIElement).Assembly, "testcase.public.Xaml.TotalSample.ClockView.xaml");
                Assert.IsNotNull(ret, "Shouldn't be null");
            }
            catch (Exception e)
            {
                Tizen.Log.Error(tag, "Caught Exception" + e.ToString());
                Assert.Fail("Caught Exception" + e.ToString());
            }

            tlog.Debug(tag, $"XamlResourceIdAttributeGetTypeForPath END");
        }

        [Test]
        [Category("P1")]
        [Description("XamlResourceIdAttribute GetTypeForPath")]
        [Property("SPEC", "Tizen.NUI.XamlResourceIdAttribute.GetTypeForPath M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        public void XamlResourceIdAttributeGetTypeForPath2()
        {
            tlog.Debug(tag, $"XamlResourceIdAttributeGetTypeForPath2 START");

            try
            {
                var ret = XamlResourceIdAttribute.GetTypeForPath(typeof(UIElement).Assembly, "none.xaml");
                Assert.IsNull(ret, "Should be null");
            }
            catch (Exception e)
            {
                Tizen.Log.Error(tag, "Caught Exception" + e.ToString());
                Assert.Fail("Caught Exception" + e.ToString());
            }

            tlog.Debug(tag, $"XamlResourceIdAttributeGetTypeForPath2 END");
        }
    }
}