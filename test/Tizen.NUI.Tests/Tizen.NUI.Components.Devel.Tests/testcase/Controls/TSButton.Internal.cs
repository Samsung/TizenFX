using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;
using System.Threading.Tasks;

namespace Tizen.NUI.Components.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("Controls/Button.Internal")]
    public class ButtonInternalTest
    {
        private const string tag = "NUITEST";
        private string image_path = Tizen.Applications.Application.Current.DirectoryInfo.Resource + "picture.png";

        internal class MyButton : Button
        {
            public MyButton() : base()
            { }

            public string MyAccessibilityGetName()
            {
                return base.AccessibilityGetName();
            }

            public bool MyAccessibilityShouldReportZeroChildren()
            {
                return base.AccessibilityShouldReportZeroChildren();
            }

            public bool MyHandleControlStateOnTouch(Touch touch)
            {
                return base.HandleControlStateOnTouch(touch);
            }

            public void MyOnRelayout(Vector2 size, RelayoutContainer container)
            {
                base.OnRelayout(size, container);
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
        [Description("Button HandleControlStateOnTouch.")]
        [Property("SPEC", "Tizen.NUI.Components.Button.HandleControlStateOnTouch M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ButtonHandleControlStateOnTouch()
        {
            tlog.Debug(tag, $"ButtonHandleControlStateOnTouch START");

            var testingTarget = new MyButton()
            {
                Text = "Button",
                Size = new Size(100, 200),
                BackgroundColor = Color.Green,
                IsEnabled = true,
            };
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<Button>(testingTarget, "Should return Button instance.");

            NUIApplication.GetDefaultWindow().GetDefaultLayer().Add(testingTarget);

            using (Touch touch = new Touch())
            {
                tlog.Debug(tag, "HandleControlStateOnTouch : " + testingTarget.MyHandleControlStateOnTouch(touch));
            }

            NUIApplication.GetDefaultWindow().GetDefaultLayer().Remove(testingTarget);

            testingTarget.Dispose();
            tlog.Debug(tag, $"ButtonHandleControlStateOnTouch END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Button AccessibilityGetName.")]
        [Property("SPEC", "Tizen.NUI.Components.Button.AccessibilityGetName M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ButtonAccessibilityGetName()
        {
            tlog.Debug(tag, $"ButtonAccessibilityGetName START");

            var testingTarget = new MyButton();
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<Button>(testingTarget, "Should return Button instance.");

            testingTarget.Text = "Button";
            tlog.Debug(tag, "AccessibilityGetName : " + testingTarget.MyAccessibilityGetName());
            tlog.Debug(tag, "AccessibilityShouldReportZeroChildren : " + testingTarget.MyAccessibilityShouldReportZeroChildren());

            testingTarget.Dispose();
            tlog.Debug(tag, $"ButtonAccessibilityGetName END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Button OnAccessibilityActivated.")]
        [Property("SPEC", "Tizen.NUI.Components.Button.OnAccessibilityActivated M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ButtonOnAccessibilityActivated()
        {
            tlog.Debug(tag, $"ButtonOnAccessibilityActivated START");

            var testingTarget = new Button();
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<Button>(testingTarget, "Should return Button instance.");

            try
            {
                testingTarget.OnAccessibilityActivated();
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"ButtonOnAccessibilityActivated END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Button OnRelayout.")]
        [Property("SPEC", "Tizen.NUI.Components.Button.OnRelayout M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public async Task ButtonOnRelayout()
        {
            tlog.Debug(tag, $"ButtonOnRelayout START");

            var testingTarget = new MyButton()
            {
                Text = "Button",
                Size = new Size(100, 200),
                BackgroundColor = Color.Green,
                IsEnabled = true,
                IconURL = image_path,
                IconPadding = 4,
                IconRelativeOrientation = Button.IconOrientation.Right
            };
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<Button>(testingTarget, "Should return Button instance.");

            NUIApplication.GetDefaultWindow().GetDefaultLayer().Add(testingTarget);

            testingTarget.Size = new Size(50, 80);
            testingTarget.BackgroundColor = Color.Blue;

            await Task.Delay(200);
            NUIApplication.GetDefaultWindow().GetDefaultLayer().Remove(testingTarget);

            testingTarget.Dispose();
            tlog.Debug(tag, $"ButtonOnRelayout END (OK)");
        }
    }
}
