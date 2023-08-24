using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Components.Devel.Tests
{
    using static Tizen.NUI.BaseComponents.View;
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("PreloadStyle/OverlayAnimationButtonStyle")]
    public class OverlayAnimationButtonStyleTest
    {
        private const string tag = "NUITEST";
        private string image_path = Tizen.Applications.Application.Current.DirectoryInfo.Resource + "picture.png";

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
        [Description("OverlayAnimationButtonStyle constructor.")]
        [Property("SPEC", "Tizen.NUI.Components.OverlayAnimationButtonStyle.OverlayAnimationButtonStyle C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void OverlayAnimationButtonStyleConstructor()
        {
            tlog.Debug(tag, $"OverlayAnimationButtonStyleConstructor START");

            var testingTarget = new OverlayAnimationButtonStyle();
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<OverlayAnimationButtonStyle>(testingTarget, "Should return OverlayAnimationButtonStyle instance.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"OverlayAnimationButtonStyleConstructor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("OverlayAnimationButtonStyle CreateExtension.")]
        [Property("SPEC", "Tizen.NUI.Components.OverlayAnimationButtonStyle.CreateExtension M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void OverlayAnimationButtonStyleCreateExtension()
        {
            tlog.Debug(tag, $"OverlayAnimationButtonStyleCreateExtension START");

            var testingTarget = new OverlayAnimationButtonStyle();
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<OverlayAnimationButtonStyle>(testingTarget, "Should return OverlayAnimationButtonStyle instance.");

            try
            {
                testingTarget.CreateExtension();
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"OverlayAnimationButtonStyleCreateExtension END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("OverlayAnimationButtonExtension constructor.")]
        [Property("SPEC", "Tizen.NUI.Components.OverlayAnimationButtonExtension.OverlayAnimationButtonExtension C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void OverlayAnimationButtonExtensionConstructor()
        {
            tlog.Debug(tag, $"OverlayAnimationButtonExtensionConstructor START");

            var testingTarget = new OverlayAnimationButtonExtension();
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<OverlayAnimationButtonExtension>(testingTarget, "Should return OverlayAnimationButtonExtension instance.");

            try
            {
                using (Button button = new Button() { Size = new Size(80, 50) })
                {
                    using (ImageView view = new ImageView(image_path))
                    {
                        testingTarget.OnCreateOverlayImage(button, view);
                    }
                }
                    
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            tlog.Debug(tag, $"OverlayAnimationButtonExtensionConstructor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("OverlayAnimationButtonExtension OnControlStateChanged.")]
        [Property("SPEC", "Tizen.NUI.Components.OverlayAnimationButtonExtension.OnControlStateChanged C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void OverlayAnimationButtonExtensionOnControlStateChanged()
        {
            tlog.Debug(tag, $"OverlayAnimationButtonExtensionOnControlStateChanged START");

            var testingTarget = new OverlayAnimationButtonExtension();
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<OverlayAnimationButtonExtension>(testingTarget, "Should return OverlayAnimationButtonExtension instance.");

            using (Button button = new Button() { Size = new Size(80, 50) })
            {
                ControlStateChangedEventArgs args = new ControlStateChangedEventArgs(ControlState.Pressed, ControlState.Selected);

                try
                {
                    using (ImageView view = new ImageView(image_path))
                    {
                        testingTarget.OnCreateOverlayImage(button, view);
                        testingTarget.OnControlStateChanged(button, args);
                        testingTarget.OnDispose(button);
                    }
                }
                catch (Exception e)
                {
                    tlog.Debug(tag, e.Message.ToString());
                    Assert.Fail("Caught Exception : Failed!");
                }
            }

            tlog.Debug(tag, $"OverlayAnimationButtonExtensionOnControlStateChanged END (OK)");
        }
    }
}
