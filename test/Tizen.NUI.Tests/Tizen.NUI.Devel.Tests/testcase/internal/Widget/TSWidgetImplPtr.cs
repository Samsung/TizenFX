using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("Internal/Widget/WidgetImplPtr")]
    public class InternalWidgetImplPtrTest
    {
        private const string tag = "NUITEST";

        internal class MyWidgetImplPtr : WidgetImplPtr
        {
            public MyWidgetImplPtr() : base()
            { }
        }

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
        [Description("WidgetImplPtr Constructor.")]
        [Property("SPEC", "Tizen.NUI.WidgetImplPtr.WidgetImplPtr C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void WidgetImplPtrConstructorWithIntPtr()
        {
            tlog.Debug(tag, $"WidgetImplPtrConstructorWithIntPtr START");

            Widget widget = new Widget();

            var testingTarget = new WidgetImplPtr(widget.GetIntPtr());
            Assert.IsNotNull(testingTarget, "Can't create success object WidgetImplPtr");
            Assert.IsInstanceOf<WidgetImplPtr>(testingTarget, "Should be an instance of WidgetImplPtr type.");

            widget.Dispose();
            widget = null;
            tlog.Debug(tag, $"WidgetImplPtrConstructorWithIntPtr END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("WidgetImplPtr Constructor.")]
        [Property("SPEC", "Tizen.NUI.WidgetImplPtr.WidgetImplPtr C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void WidgetImplPtrConstructor()
        {
            tlog.Debug(tag, $"WidgetImplPtrConstructor START");

            Widget widget = new Widget();

            var testingTarget = new MyWidgetImplPtr();
            Assert.IsNotNull(testingTarget, "Can't create success object WidgetImplPtr");
            Assert.IsInstanceOf<WidgetImplPtr>(testingTarget, "Should be an instance of WidgetImplPtr type.");

            widget.Dispose();
            widget = null;
            tlog.Debug(tag, $"WidgetImplPtrConstructor END (OK)");
        }
    }
}
