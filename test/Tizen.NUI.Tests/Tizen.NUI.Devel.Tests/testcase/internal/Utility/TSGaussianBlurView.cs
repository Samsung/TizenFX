using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("Internal/Utility/GaussianBlurView")]
    public class InternalGaussianBlurViewTest
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
        [Description("GaussianBlurView constructor.")]
        [Property("SPEC", "Tizen.NUI.GaussianBlurView.GaussianBlurView C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void GaussianBlurViewConstructor()
        {
            tlog.Debug(tag, $"GaussianBlurViewConstructor START");

            var testingTarget = new GaussianBlurView();
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<GaussianBlurView>(testingTarget, "Should be an Instance of GaussianBlurView!");

            testingTarget.Finished += OnFinished;
            testingTarget.Finished -= OnFinished;

            testingTarget.Dispose();
            // disposed
            testingTarget.Dispose();
            tlog.Debug(tag, $"GaussianBlurViewConstructor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("GaussianBlurView constructor.")]
        [Property("SPEC", "Tizen.NUI.GaussianBlurView.GaussianBlurView C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void GaussianBlurViewConstructorWithPixelFormat()
        {
            tlog.Debug(tag, $"GaussianBlurViewConstructorWithPixelFormat START");

            var testingTarget = new GaussianBlurView(3, 0.3f, PixelFormat.BGR8888, 1.0f, 1.0f, false);
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<GaussianBlurView>(testingTarget, "Should be an Instance of GaussianBlurView!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"GaussianBlurViewConstructorWithPixelFormat END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("GaussianBlurView constructor.")]
        [Property("SPEC", "Tizen.NUI.GaussianBlurView.GaussianBlurView C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void GaussianBlurViewConstructorWithGaussianBlurView()
        {
            tlog.Debug(tag, $"GaussianBlurViewConstructorWithGaussianBlurView START");

            using (GaussianBlurView view = new GaussianBlurView())
            {
                var testingTarget = new GaussianBlurView(view);
                Assert.IsNotNull(testingTarget, "Should be not null!");
                Assert.IsInstanceOf<GaussianBlurView>(testingTarget, "Should be an Instance of GaussianBlurView!");

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"GaussianBlurViewConstructorWithGaussianBlurView END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("GaussianBlurView BlurStrength.")]
        [Property("SPEC", "Tizen.NUI.GaussianBlurView.BlurStrength A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void GaussianBlurViewBlurStrength()
        {
            tlog.Debug(tag, $"GaussianBlurViewBlurStrength START");

            using (View view = new View() { Size = new Size(100, 50) })
            {
                var testingTarget = new GaussianBlurView(view.SwigCPtr.Handle, false);
                Assert.IsNotNull(testingTarget, "Should be not null!");
                Assert.IsInstanceOf<GaussianBlurView>(testingTarget, "Should be an Instance of Builder!");

                testingTarget.BlurStrength = 0.3f;
                tlog.Debug(tag, "BlurStrength : " + testingTarget.BlurStrength);

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"GaussianBlurViewBlurStrength END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("GaussianBlurView Activate.")]
        [Property("SPEC", "Tizen.NUI.GaussianBlurView.Activate M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void GaussianBlurViewActivate()
        {
            tlog.Debug(tag, $"GaussianBlurViewActivate START");

            var testingTarget = new GaussianBlurView();
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<GaussianBlurView>(testingTarget, "Should be an Instance of GaussianBlurView!");

            try
            {
                testingTarget.Activate();
                testingTarget.Deactivate();
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }
            
            testingTarget.Dispose();
            tlog.Debug(tag, $"GaussianBlurViewActivate END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("GaussianBlurView SetBackgroundColor.")]
        [Property("SPEC", "Tizen.NUI.GaussianBlurView.SetBackgroundColor M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void GaussianBlurViewSetBackgroundColor()
        {
            tlog.Debug(tag, $"GaussianBlurViewSetBackgroundColor START");

            var testingTarget = new GaussianBlurView();
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<GaussianBlurView>(testingTarget, "Should be an Instance of GaussianBlurView!");

            using (Vector4 color = new Vector4(1.0f, 1.0f, 1.0f, 1.0f))
            {
                testingTarget.SetBackgroundColor(color);
                var result = testingTarget.GetBackgroundColor();
                tlog.Debug(tag, "BackgroundColor.X" + result.X);
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"GaussianBlurViewSetBackgroundColor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("GaussianBlurView ActivateOnce.")]
        [Property("SPEC", "Tizen.NUI.GaussianBlurView.ActivateOnce M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void GaussianBlurViewActivateOnce()
        {
            tlog.Debug(tag, $"GaussianBlurViewActivateOnce START");

            var testingTarget = new GaussianBlurView();
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<GaussianBlurView>(testingTarget, "Should be an Instance of GaussianBlurView!");

            NUIApplication.GetDefaultWindow().Add(testingTarget);

            try
            {
                testingTarget.ActivateOnce();
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            NUIApplication.GetDefaultWindow().Remove(testingTarget);

            testingTarget.Dispose();
            tlog.Debug(tag, $"GaussianBlurViewActivateOnce END (OK)");
        }

        private void OnFinished(object source, EventArgs e) { }
    }
}
