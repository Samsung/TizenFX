using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;
using System.Collections.Generic;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("public/Widget/WidgetViewManager")]
    public class PublicWidgetViewManagerTest
    {
        private const string tag = "NUITEST";
        private Widget widget = null;

        [SetUp]
        public void Init()
        {
            tlog.Info(tag, "Init() is called!");

            widget = new Widget();
            tlog.Debug(tag, "widget.Id : " + widget.Id);
        }

        [TearDown]
        public void Destroy()
        {
            widget.Dispose();
            widget = null;

            tlog.Info(tag, "Destroy() is called!");
        }

        [Test]
        [Category("P1")]
        [Description("WidgetViewManager constructor.")]
        [Property("SPEC", "Tizen.NUI.WidgetViewManager.WidgetViewManager C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void WidgetViewManagerConstructorWithIntPtr()
        {
            tlog.Debug(tag, $"WidgetViewManagerConstructorWithIntPtr START");

            var testingTarget = new WidgetViewManager(widget.GetIntPtr(), false);
            Assert.IsNotNull(testingTarget, "Can't create success object WidgetViewManager");
            Assert.IsInstanceOf<WidgetViewManager>(testingTarget, "Should be an instance of WidgetViewManager type.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"WidgetViewManagerConstructorWithIntPtr END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("WidgetViewManager constructor. With WidgetViewManager.")]
        [Property("SPEC", "Tizen.NUI.WidgetViewManager.WidgetViewManager C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void WidgetViewManagerConstructorWithWidgetViewManager()
        {
            tlog.Debug(tag, $"WidgetViewManagerConstructorWithWidgetViewManager START");

            WidgetViewManager manager = new WidgetViewManager(widget.GetIntPtr(), false);
            Assert.IsNotNull(manager, "Can't create success object WidgetViewManager");
            Assert.IsInstanceOf<WidgetViewManager>(manager, "Should be an instance of WidgetViewManager type.");

            var testingTarget = new WidgetViewManager(manager);
            Assert.IsNotNull(testingTarget, "Can't create success object WidgetViewManager");
            Assert.IsInstanceOf<WidgetViewManager>(testingTarget, "Should be an instance of WidgetViewManager type.");

            manager.Dispose();
            testingTarget.Dispose();
            tlog.Debug(tag, $"WidgetViewManagerConstructorWithWidgetViewManager END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("WidgetViewManager Instance.")]
        [Property("SPEC", "Tizen.NUI.WidgetViewManager.Instance A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void WidgetViewManagerInstance()
        {
            tlog.Debug(tag, $"WidgetViewManagerInstance START");

            try
            {
                tlog.Debug(tag, "WidgetViewManager.Instance : " + WidgetViewManager.Instance);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception: Failed!");
            }

            tlog.Debug(tag, $"WidgetViewManagerInstance END (OK)");
        }

        //[Test]
        //[Category("P1")]
        //[Description("WidgetViewManager AddWidget.")]
        //[Property("SPEC", "Tizen.NUI.WidgetViewManager.AddWidget M")]
        //[Property("SPEC_URL", "-")]
        //[Property("CRITERIA", "MR")]
        //[Property("AUTHOR", "guowei.wang@samsung.com")]
        //public void WidgetViewManagerAddWidget()
        //{
        //    tlog.Debug(tag, $"WidgetViewManagerAddWidget START");

        //    var testingTarget = new WidgetViewManager(widget.GetIntPtr(), false);
        //    Assert.IsNotNull(testingTarget, "Can't create success object WidgetViewManager");
        //    Assert.IsInstanceOf<WidgetViewManager>(testingTarget, "Should be an instance of WidgetViewManager type.");

        //    var result = testingTarget.AddWidget(widget.Id.ToString(), "widget", 100, 200, 50.0f);
        //    Assert.IsNotNull(result, "Can't create success object WidgetView");
        //    Assert.IsInstanceOf<WidgetView>(result, "Should be an instance of WidgetView type.");

        //    testingTarget.Dispose();
        //    tlog.Debug(tag, $"WidgetViewManagerAddWidget END (OK)");
        //}

        [Test]
        [Category("P1")]
        [Description("WidgetViewManager getCPtr.")]
        [Property("SPEC", "Tizen.NUI.WidgetViewManager.getCPtr A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void WidgetViewManagergetCPtr()
        {
            tlog.Debug(tag, $"WidgetViewManagergetCPtr START");

            var testingTarget = new WidgetViewManager(widget.GetIntPtr(), false);
            Assert.IsNotNull(testingTarget, "Can't create success object WidgetViewManager");
            Assert.IsInstanceOf<WidgetViewManager>(testingTarget, "Should be an instance of WidgetViewManager type.");

            try
            {

                WidgetViewManager.getCPtr(testingTarget);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception: Failed!");
            }

            tlog.Debug(tag, $"WidgetViewManagergetCPtr END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("WidgetViewManager DownCast.")]
        [Property("SPEC", "Tizen.NUI.WidgetViewManager.DownCast A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void WidgetViewManagerDownCast()
        {
            tlog.Debug(tag, $"WidgetViewManagerDownCast START");

            var testingTarget = new WidgetViewManager(widget.GetIntPtr(), false);
            Assert.IsNotNull(testingTarget, "Can't create success object WidgetViewManager");
            Assert.IsInstanceOf<WidgetViewManager>(testingTarget, "Should be an instance of WidgetViewManager type.");

            try
            {

                WidgetViewManager.DownCast(testingTarget);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception: Failed!");
            }

            tlog.Debug(tag, $"WidgetViewManagerDownCast END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("WidgetViewManager Assign.")]
        [Property("SPEC", "Tizen.NUI.WidgetViewManager.Assign A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void WidgetViewManagerAssign()
        {
            tlog.Debug(tag, $"WidgetViewManagerAssign START");

            var testingTarget = new WidgetViewManager(widget.GetIntPtr(), false);
            Assert.IsNotNull(testingTarget, "Can't create success object WidgetViewManager");
            Assert.IsInstanceOf<WidgetViewManager>(testingTarget, "Should be an instance of WidgetViewManager type.");

            try
            {
                WidgetViewManager.Instance.Assign(testingTarget);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception: Failed!");
            }

            tlog.Debug(tag, $"WidgetViewManagerAssign END (OK)");
        }
    }
}
