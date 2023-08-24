using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("internal/Common/Object")]
    public class InternalObjectTest
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
        [Category("P2")]
        [Description("Object GetProperty.")]
        [Property("SPEC", "Tizen.NUI.Object.GetProperty M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ObjectGetProperty()
        {
            tlog.Debug(tag, $"ObjectGetProperty START");

            ScrollView scrollView = null;
            bool temp = false;
            try
            {
                Tizen.NUI.Object.GetProperty(scrollView.SwigCPtr, ScrollView.Property.AxisAutoLockEnabled).Get(out temp);
            }
            catch (NullReferenceException)
            {
                Assert.Pass("Caught NullReferenceException :  Passed!");
            }

            tlog.Debug(tag, $"ObjectGetProperty END (OK)");
        }

        [Test]
        [Category("P2")]
        [Description("Object SetProperty.")]
        [Property("SPEC", "Tizen.NUI.Object.SetProperty M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ObjectSetProperty()
        {
            tlog.Debug(tag, $"ObjectSetProperty START");

            ScrollView scrollView = null;

            try
            {
                Tizen.NUI.Object.SetProperty(scrollView.SwigCPtr, ScrollView.Property.AxisAutoLockEnabled, new Tizen.NUI.PropertyValue(true));
            }
            catch (NullReferenceException)
            {
                Assert.Pass("Caught NullReferenceException :  Passed!");
            }

            tlog.Debug(tag, $"ObjectSetProperty END (OK)");
        }
    }
}
