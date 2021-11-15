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
    [Description("Controls/Switch")]
    public class SwitchTest
    {
        private const string tag = "NUITEST";
        private string image_path = Tizen.Applications.Application.Current.DirectoryInfo.Resource + "picture.png";

        [Obsolete]
        private void OnSelectedEvent(object sender, Switch.SelectEventArgs e) { }

        private void OnSelectedChanged(object sender, SelectedChangedEventArgs e) { }

        internal class MySwitch : Switch
        {
            public MySwitch() : base()
            { }

            public void OnAccessibilityCalculateStates()
            {
                GetAccessibilityStates();
            }

            public void MyOnControlStateChanged(ControlStateChangedEventArgs controlStateChangedInfo)
            {
                base.OnControlStateChanged(controlStateChangedInfo);
            }
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
        [Description("Switch AccessibilityCalculateStates.")]
        [Property("SPEC", "Tizen.NUI.Components.Switch.AccessibilityCalculateStates M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void SwitchAccessibilityCalculateStates()
        {
            tlog.Debug(tag, $"SwitchAccessibilityCalculateStates START");

            var testingTarget = new MySwitch();
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<Switch>(testingTarget, "Should return Switch instance.");

            try
            {
                testingTarget.OnAccessibilityCalculateStates();
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"SwitchAccessibilityCalculateStates END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Switch Track.")]
        [Property("SPEC", "Tizen.NUI.Components.Switch.Track A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void SwitchTrack()
        {
            tlog.Debug(tag, $"SwitchTrack START");

            var testingTarget = new Switch();
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<Switch>(testingTarget, "Should return Switch instance.");

            testingTarget.Track = new ImageView(image_path);
            tlog.Debug(tag, "Track : " + testingTarget.Track);

            testingTarget.Thumb = new ImageView(image_path);
            tlog.Debug(tag, "Thumb : " + testingTarget.Thumb);

            testingTarget.Dispose();
            tlog.Debug(tag, $"SwitchTrack END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Switch OnKey.")]
        [Property("SPEC", "Tizen.NUI.Components.Switch.OnKey M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void SwitchOnKey()
        {
            tlog.Debug(tag, $"SwitchOnKey START");

            var testingTarget = new Switch();
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<Switch>(testingTarget, "Should return Switch instance.");

            try
            {
                using (Key key = new Key())
                {
                    testingTarget.OnKey(key);
                }
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }
               
            testingTarget.Dispose();
            tlog.Debug(tag, $"SwitchOnKey END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Switch OnKey.")]
        [Property("SPEC", "Tizen.NUI.Components.Switch.OnControlStateChanged M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        [Obsolete]
        public void SwitchOnControlStateChanged()
        {
            tlog.Debug(tag, $"SwitchOnControlStateChanged START");

            var testingTarget = new MySwitch();
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<Switch>(testingTarget, "Should return Switch instance.");

            testingTarget.IsSelectable = true;
            testingTarget.SelectedEvent += OnSelectedEvent;
            testingTarget.SelectedChanged += OnSelectedChanged;

            try
            {
                ControlStateChangedEventArgs args = new ControlStateChangedEventArgs(ControlState.Selected, ControlState.Normal);
                testingTarget.MyOnControlStateChanged(args);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            testingTarget.SelectedEvent -= OnSelectedEvent;
            testingTarget.SelectedChanged -= OnSelectedChanged;

            testingTarget.Dispose();
            tlog.Debug(tag, $"SwitchOnControlStateChanged END (OK)");
        }
    }
}
