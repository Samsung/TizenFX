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
    [Description("public/ApplicationAnimation/ApplicationTransitionManager")]
    public class PublicApplicationTransitionManagerTest
    {
        private const string tag = "NUITEST";
        private string imageurl = Tizen.Applications.Application.Current.DirectoryInfo.Resource + "picture.png";

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
        [Description("ApplicationTransitionManager Instance.")]
        [Property("SPEC", "Tizen.NUI.ApplicationTransitionManager.Instance A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ApplicationTransitionManagerInstance()
        {
            tlog.Debug(tag, $"ApplicationTransitionManagerInstance START");

            var testingTarget = ApplicationTransitionManager.Instance;
            Assert.IsNotNull(testingTarget, "Return a null object of FontClient");
            Assert.IsInstanceOf<ApplicationTransitionManager>(testingTarget, "Should be an instance of ApplicationTransitionManager type.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"ApplicationTransitionManagerInstance END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ApplicationTransitionManager SourceView.")]
        [Property("SPEC", "Tizen.NUI.ApplicationTransitionManager.SourceView A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ApplicationTransitionManagerSourceView()
        {
            tlog.Debug(tag, $"ApplicationTransitionManagerSourceView START");

            var testingTarget = ApplicationTransitionManager.Instance;
            Assert.IsNotNull(testingTarget, "Return a null object of FontClient");
            Assert.IsInstanceOf<ApplicationTransitionManager>(testingTarget, "Should be an instance of ApplicationTransitionManager type.");

            using (View view = new View() { Size = new Size(100, 200) })
            {
                testingTarget.SourceView = view;
                tlog.Debug(tag, "SourceView : " + testingTarget.SourceView);
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"ApplicationTransitionManagerSourceView END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ApplicationTransitionManager TransitionWindow.")]
        [Property("SPEC", "Tizen.NUI.ApplicationTransitionManager.TransitionWindow A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ApplicationTransitionManagerTransitionWindow()
        {
            tlog.Debug(tag, $"ApplicationTransitionManagerTransitionWindow START");

            var testingTarget = ApplicationTransitionManager.Instance;
            Assert.IsNotNull(testingTarget, "Return a null object of FontClient");
            Assert.IsInstanceOf<ApplicationTransitionManager>(testingTarget, "Should be an instance of ApplicationTransitionManager type.");

            // mainWindow == value
            testingTarget.TransitionWindow = Window.Instance;
            tlog.Debug(tag, "TransitionWindow : " + testingTarget.TransitionWindow);

            // null == value
            testingTarget.TransitionWindow = null;
            tlog.Debug(tag, "TransitionWindow : " + testingTarget.TransitionWindow);

            using (Rectangle rec = new Rectangle(20, 20, 20, 20))
            {
                using (Window win = new Window(rec, true))
                {
                    testingTarget.TransitionWindow = win;
                    tlog.Debug(tag, "TransitionWindow : " + testingTarget.TransitionWindow);
                }
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"ApplicationTransitionManagerTransitionWindow END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ApplicationTransitionManager ApplicationFrameType.")]
        [Property("SPEC", "Tizen.NUI.ApplicationTransitionManager.ApplicationFrameType A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ApplicationTransitionManagerApplicationFrameType()
        {
            tlog.Debug(tag, $"ApplicationTransitionManagerApplicationFrameType START");

            var testingTarget = ApplicationTransitionManager.Instance;
            Assert.IsNotNull(testingTarget, "Return a null object of FontClient");
            Assert.IsInstanceOf<ApplicationTransitionManager>(testingTarget, "Should be an instance of ApplicationTransitionManager type.");

            testingTarget.ApplicationFrameType = FrameType.FrameBroker;
            tlog.Debug(tag, "FrameType : " + testingTarget.ApplicationFrameType);

            using (TransitionBase appearing = new TransitionBase())
            {
                appearing.TimePeriod = new TimePeriod(300);
                appearing.AlphaFunction = new AlphaFunction(AlphaFunction.BuiltinFunctions.EaseIn);

                tlog.Debug(tag, "AppearingTransition : " + testingTarget.AppearingTransition);

                testingTarget.AppearingTransition = appearing;
                tlog.Debug(tag, "AppearingTransition : " + testingTarget.AppearingTransition);
            }

            using (TransitionBase disappearing = new TransitionBase())
            {
                disappearing.TimePeriod = new TimePeriod(300);
                disappearing.AlphaFunction = new AlphaFunction(AlphaFunction.BuiltinFunctions.EaseInOut);

                tlog.Debug(tag, "DisappearingTransition : " + testingTarget.DisappearingTransition);

                testingTarget.DisappearingTransition = disappearing;
                tlog.Debug(tag, "DisappearingTransition : " + testingTarget.DisappearingTransition);
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"ApplicationTransitionManagerApplicationFrameType END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ApplicationTransitionManager ApplicationFrameType.")]
        [Property("SPEC", "Tizen.NUI.ApplicationTransitionManager.ApplicationFrameType A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ApplicationTransitionManagerApplicationFrameTypeAsFrameProvider()
        {
            tlog.Debug(tag, $"ApplicationTransitionManagerApplicationFrameTypeAsFrameProvider START");

            var testingTarget = ApplicationTransitionManager.Instance;
            Assert.IsNotNull(testingTarget, "Return a null object of FontClient");
            Assert.IsInstanceOf<ApplicationTransitionManager>(testingTarget, "Should be an instance of ApplicationTransitionManager type.");

            testingTarget.ApplicationFrameType = FrameType.FrameProvider;
            tlog.Debug(tag, "FrameType : " + testingTarget.ApplicationFrameType);

            testingTarget.Dispose();
            tlog.Debug(tag, $"ApplicationTransitionManagerApplicationFrameTypeAsFrameProvider END (OK)");
        }
    }
}
