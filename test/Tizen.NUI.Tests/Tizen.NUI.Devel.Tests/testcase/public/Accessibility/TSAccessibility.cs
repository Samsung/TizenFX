﻿using global::System;
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
        [Description("Accessibility IsEnabled.")]
        [Property("SPEC", "Tizen.NUI.Accessibility.IsEnabled A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void AccessibilityIsEnabled()
        {
            tlog.Debug(tag, $"AccessibilityIsEnabled START");

            try
            {
                var result = Accessibility.Accessibility.IsEnabled;
                tlog.Debug(tag, "Status : " + result);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            tlog.Debug(tag, $"AccessibilityIsEnabled END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Accessibility IsScreenReaderEnabled.")]
        [Property("SPEC", "Tizen.NUI.Accessibility.IsScreenReaderEnabled A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void AccessibilityIsScreenReaderEnabled()
        {
            tlog.Debug(tag, $"AccessibilityIsScreenReaderEnabled START");

            try
            {
                var result = Accessibility.Accessibility.IsScreenReaderEnabled;
                tlog.Debug(tag, "IsScreenReaderEnabled : " + result);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            tlog.Debug(tag, $"AccessibilityIsScreenReaderEnabled END (OK)");
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

            var result = Accessibility.Accessibility.Say("Hi,Bixby! Please help to order a sandwich.", true);
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

            try
            {
                Accessibility.Accessibility.PauseResume(true);
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

            try
            {
                Accessibility.Accessibility.StopReading(true);
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

            try
            {
                Accessibility.Accessibility.SuppressScreenReader(false);
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

        [Test]
        [Category("P1")]
        [Description("Accessibility SetHighlightFrameView.")]
        [Property("SPEC", "Tizen.NUI.Accessibility.SetHighlightFrameView M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void AccessibilitySetHighlightFrameView()
        {
            tlog.Debug(tag, $"AccessibilitySetHighlightFrameView START");

            using (View view = new View())
            {
                view.Size = new Size(100, 50);
                view.Color = Color.Cyan;

                NUIApplication.GetDefaultWindow().Add(view);

                try
                {
                    Accessibility.Accessibility.SetHighlightFrameView(view);

                    var result = Accessibility.Accessibility.GetHighlightFrameView();
                    tlog.Debug(tag, "HighlightFrameView : " + result);
                    tlog.Debug(tag, "ClearCurrentlyHighlightedView : " + Accessibility.Accessibility.ClearCurrentlyHighlightedView());
                }
                catch (Exception e)
                {
                    tlog.Debug(tag, e.Message.ToString());
                    Assert.Fail("Caught Exception : Failed");
                }

                NUIApplication.GetDefaultWindow().Remove(view);
            };

            tlog.Debug(tag, $"AccessibilitySetHighlightFrameView END (OK)");
        }

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

            Accessibility.Accessibility.SayFinished += OnSayFinished;
            Accessibility.Accessibility.SayFinished -= OnSayFinished;

            tlog.Debug(tag, $"AccessibilitySayFinished END (OK)");
        }

        private void OnSayFinished(object sender, Accessibility.SayFinishedEventArgs e)
        {
            tlog.Debug(tag, "State : " + e.State);
        }
    }
}
