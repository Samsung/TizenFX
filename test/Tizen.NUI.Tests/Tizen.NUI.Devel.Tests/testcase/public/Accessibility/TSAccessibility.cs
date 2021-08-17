using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("public/Accessibility/Accessibility")]
    public class PublicAccessibilityTest
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
        [Description("Accessibility constructor.")]
        [Property("SPEC", "Tizen.NUI.Accessibility.Accessibility C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void AccessibilityConstructor()
        {
            tlog.Debug(tag, $"AccessibilityConstructor START");

            var testingTarget = Accessibility.Accessibility.Instance; ;
            Assert.IsNotNull(testingTarget, "Can't create success object Accessibility");
            Assert.IsInstanceOf<Accessibility.Accessibility>(testingTarget, "Should be an instance of Accessibility type.");

            tlog.Debug(tag, $"AccessibilityConstructor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Accessibility GetStatus.")]
        [Property("SPEC", "Tizen.NUI.Accessibility.GetStatus M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void AccessibilityGetStatus()
        {
            tlog.Debug(tag, $"AccessibilityGetStatus START");

            try
            {
                var result = Accessibility.Accessibility.GetStatus();
                tlog.Debug(tag, "Status : " + result);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            tlog.Debug(tag, $"AccessibilityGetStatus END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Accessibility Say.")]
        [Property("SPEC", "Tizen.NUI.Accessibility.Say M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void AccessibilitySay()
        {
            tlog.Debug(tag, $"AccessibilitySay START");

            var testingTarget = Accessibility.Accessibility.Instance; ;
            Assert.IsNotNull(testingTarget, "Can't create success object Accessibility");
            Assert.IsInstanceOf<Accessibility.Accessibility>(testingTarget, "Should be an instance of Accessibility type.");

            var result = testingTarget.Say("Hi,Bixby! Please help to order a sandwich.", true);
            tlog.Debug(tag, "Status : " + result);

            tlog.Debug(tag, $"AccessibilitySay END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Accessibility PauseResume.")]
        [Property("SPEC", "Tizen.NUI.Accessibility.PauseResume M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void AccessibilityPauseResume()
        {
            tlog.Debug(tag, $"AccessibilityPauseResume START");

            var testingTarget = Accessibility.Accessibility.Instance; ;
            Assert.IsNotNull(testingTarget, "Can't create success object Accessibility");
            Assert.IsInstanceOf<Accessibility.Accessibility>(testingTarget, "Should be an instance of Accessibility type.");

            try
            {
                testingTarget.PauseResume(true);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed");
            }

            tlog.Debug(tag, $"AccessibilityPauseResume END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Accessibility StopReading.")]
        [Property("SPEC", "Tizen.NUI.Accessibility.StopReading M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void AccessibilityStopReading()
        {
            tlog.Debug(tag, $"AccessibilityStopReading START");

            var testingTarget = Accessibility.Accessibility.Instance; ;
            Assert.IsNotNull(testingTarget, "Can't create success object Accessibility");
            Assert.IsInstanceOf<Accessibility.Accessibility>(testingTarget, "Should be an instance of Accessibility type.");

            try
            {
                testingTarget.StopReading(true);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed");
            }

            tlog.Debug(tag, $"AccessibilityStopReading END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Accessibility SuppressScreenReader.")]
        [Property("SPEC", "Tizen.NUI.Accessibility.SuppressScreenReader M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void AccessibilitySuppressScreenReader()
        {
            tlog.Debug(tag, $"AccessibilitySuppressScreenReader START");

            var testingTarget = Accessibility.Accessibility.Instance; ;
            Assert.IsNotNull(testingTarget, "Can't create success object Accessibility");
            Assert.IsInstanceOf<Accessibility.Accessibility>(testingTarget, "Should be an instance of Accessibility type.");

            try
            {
                testingTarget.SuppressScreenReader(false);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed");
            }

            tlog.Debug(tag, $"AccessibilitySuppressScreenReader END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Accessibility BridgeEnableAutoInit.")]
        [Property("SPEC", "Tizen.NUI.Accessibility.BridgeEnableAutoInit M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void AccessibilityBridgeEnableAutoInit()
        {
            tlog.Debug(tag, $"AccessibilityBridgeEnableAutoInit START");

            try
            {
                Accessibility.Accessibility.BridgeEnableAutoInit();
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed");
            }

            tlog.Debug(tag, $"AccessibilityBridgeEnableAutoInit END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Accessibility BridgeDisableAutoInit.")]
        [Property("SPEC", "Tizen.NUI.Accessibility.BridgeDisableAutoInit M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void AccessibilityBridgeDisableAutoInit()
        {
            tlog.Debug(tag, $"AccessibilityBridgeDisableAutoInit START");

            try
            {
                Accessibility.Accessibility.BridgeDisableAutoInit();
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed");
            }

            tlog.Debug(tag, $"AccessibilityBridgeDisableAutoInit END (OK)");
        }

        //[Test]
        //[Category("P1")]
        //[Description("Accessibility SetHighlightFrameView.")]
        //[Property("SPEC", "Tizen.NUI.Accessibility.SetHighlightFrameView M")]
        //[Property("SPEC_URL", "-")]
        //[Property("CRITERIA", "MR")]
        //[Property("AUTHOR", "guowei.wang@samsung.com")]
        //public void AccessibilitySetHighlightFrameView()
        //{
        //    tlog.Debug(tag, $"AccessibilitySetHighlightFrameView START");

        //    var testingTarget = Accessibility.Accessibility.Instance; ;
        //    Assert.IsNotNull(testingTarget, "Can't create success object Accessibility");
        //    Assert.IsInstanceOf<Accessibility.Accessibility>(testingTarget, "Should be an instance of Accessibility type.");

        //    using (View view = new View())
        //    {
        //        view.Size = new Size(100, 50);
        //        view.Color = Color.Cyan;

        //        NUIApplication.GetDefaultWindow().Add(view);

        //        try
        //        {
        //            testingTarget.SetHighlightFrameView(view);
                    
        //            var result = testingTarget.GetHighlightFrameView();
        //            tlog.Debug(tag, "HighlightFrameView : " + result);
        //            tlog.Debug(tag, "ClearCurrentlyHighlightedView : " + testingTarget.ClearCurrentlyHighlightedView());
        //        }
        //        catch (Exception e)
        //        {
        //            tlog.Debug(tag, e.Message.ToString());
        //            Assert.Fail("Caught Exception : Failed");
        //        }

        //        NUIApplication.GetDefaultWindow().Remove(view);
        //    };

        //    tlog.Debug(tag, $"AccessibilitySetHighlightFrameView END (OK)");
        //}

        [Test]
        [Category("P1")]
        [Description("Accessibility SayFinished.")]
        [Property("SPEC", "Tizen.NUI.Accessibility.SayFinished A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void AccessibilitySayFinished()
        {
            tlog.Debug(tag, $"AccessibilitySayFinished START");

            var testingTarget = Accessibility.Accessibility.Instance;
            Assert.IsNotNull(testingTarget, "Can't create success object Accessibility");
            Assert.IsInstanceOf<Accessibility.Accessibility>(testingTarget, "Should be an instance of Accessibility type.");

            testingTarget.SayFinished += OnSayFinished;
            testingTarget.SayFinished -= OnSayFinished;

            tlog.Debug(tag, $"AccessibilitySayFinished END (OK)");
        }

        private void OnSayFinished(object sender, Accessibility.SayFinishedEventArgs e)
        {
            tlog.Debug(tag, "State : " + e.State);
        }
    }
}
