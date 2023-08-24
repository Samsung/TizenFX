using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;
using System.Threading.Tasks;
using System.Resources;
using Tizen.NUI.Components.Devel.Tests.Properties;

namespace Tizen.NUI.Components.Devel.Tests.testcase.Controls
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("Controls/Button")]
    class ButtonTest
    {
        private const string tag = "NUITEST";
        private string image_path = Tizen.Applications.Application.Current.DirectoryInfo.Resource + "picture.png";

        [Obsolete]
        private void OnStateChangedEvent(object sender, Button.StateChangedEventArgs e) { }

        internal class MyButton : Button
        {
            public MyButton() : base()
            { }

            public override bool OnKey(Key key)
            {
                return base.OnKey(key);
            }

            public override void OnFocusGained()
            {
                base.OnFocusGained();
            }

            public override void OnFocusLost()
            {
                base.OnFocusLost();
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
        [Description("Button StateChangedEvent.")]
        [Property("SPEC", "Tizen.NUI.Components.Button.StateChangedEvent A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        [Obsolete]
        public void ButtonStateChangedEvent()
        {
            tlog.Debug(tag, $"ButtonStateChangedEvent START");

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

            testingTarget.StateChangedEvent += OnStateChangedEvent;
            testingTarget.StateChangedEvent -= OnStateChangedEvent;

            NUIApplication.GetDefaultWindow().GetDefaultLayer().Remove(testingTarget);

            testingTarget.Dispose();
            tlog.Debug(tag, $"ButtonStateChangedEvent END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Button OverlayImage.")]
        [Property("SPEC", "Tizen.NUI.Components.Button.OverlayImage A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ButtonOverlayImage()
        {
            tlog.Debug(tag, $"ButtonOverlayImage START");

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

            testingTarget.OverlayImage.Border = new Rectangle(5, 5, 5, 5);
            tlog.Debug(tag, "testingTarget.OverlayImage.Border : " + testingTarget.OverlayImage.Border);

            NUIApplication.GetDefaultWindow().GetDefaultLayer().Remove(testingTarget);

            testingTarget.Dispose();
            tlog.Debug(tag, $"ButtonOverlayImage END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Button TextLabel.")]
        [Property("SPEC", "Tizen.NUI.Components.Button.TextLabel A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ButtonTextLabel()
        {
            tlog.Debug(tag, $"ButtonTextLabel START");

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

            testingTarget.TextLabel.PointSize = 20.0f;
            tlog.Debug(tag, "testingTarget.TextLabel.PointSize : " + testingTarget.TextLabel.PointSize);

            NUIApplication.GetDefaultWindow().GetDefaultLayer().Remove(testingTarget);

            testingTarget.Dispose();
            tlog.Debug(tag, $"ButtonTextLabel END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Button TranslatableText.")]
        [Property("SPEC", "Tizen.NUI.Components.Button.TranslatableText A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ButtonTranslatableText()
        {
            tlog.Debug(tag, $"ButtonTranslatableText START");

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

            NUIApplication.MultilingualResourceManager = Resources.ResourceManager;

            if (NUIApplication.MultilingualResourceManager != null)
            {
                testingTarget.TranslatableText = "TranslatableText";
                tlog.Debug(tag, "testingTarget.TranslatableText : " + testingTarget.TranslatableText);
            }

            NUIApplication.GetDefaultWindow().GetDefaultLayer().Remove(testingTarget);

            testingTarget.Dispose();
            tlog.Debug(tag, $"ButtonTranslatableText END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Button IconSize.")]
        [Property("SPEC", "Tizen.NUI.Components.Button.IconSize A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ButtonIconSize()
        {
            tlog.Debug(tag, $"ButtonIconSize START");

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

            testingTarget.IconSize = new Size(100, 200);
            tlog.Debug(tag, "testingTarget.IconSize.Width : " + testingTarget.IconSize.Width);

            NUIApplication.GetDefaultWindow().GetDefaultLayer().Remove(testingTarget);

            testingTarget.Dispose();
            tlog.Debug(tag, $"ButtonIconSize END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Button OnKey.")]
        [Property("SPEC", "Tizen.NUI.Components.Button.OnKey M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        [Obsolete]
        public void ButtonOnKey()
        {
            tlog.Debug(tag, $"ButtonOnKey START");

            var testingTarget = new MyButton();
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<Button>(testingTarget, "Should return Button instance.");

            testingTarget.IsEnabled = true;
            testingTarget.IsSelected = true;

            Key key = null;
            var result = testingTarget.OnKey(key);
            Assert.AreEqual(false, result, "should be equal here!");

            key = new Key()
            {
                State = Key.StateType.Up,
                KeyPressedName = "Return"
            };
            result = testingTarget.OnKey(key);
            tlog.Debug(tag, "OnKey : " + result);

            testingTarget.Dispose();
            tlog.Debug(tag, $"ButtonOnKey END (OK)");
        }

        [Test]
        [Category("P2")]
        [Description("Button OnKey.")]
        [Property("SPEC", "Tizen.NUI.Components.Button.OnKey M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        [Obsolete]
        public void ButtonOnKeyIsSelectableAsFalse()
        {
            tlog.Debug(tag, $"ButtonOnKeyIsSelectableAsFalse START");

            var testingTarget = new MyButton();
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<Button>(testingTarget, "Should return Button instance.");

            testingTarget.IsEnabled = true;
            testingTarget.IsSelected = false;

            Key key = null;
            var result = testingTarget.OnKey(key);
            Assert.AreEqual(false, result, "should be equal here!");

            key = new Key()
            {
                State = Key.StateType.Up,
                KeyPressedName = "Return"
            };
            result = testingTarget.OnKey(key);
            tlog.Debug(tag, "OnKey : " + result);

            testingTarget.Dispose();
            tlog.Debug(tag, $"ButtonOnKeyIsSelectableAsFalse END (OK)");
        }

        [Test]
        [Category("P2")]
        [Description("Button OnKey.")]
        [Property("SPEC", "Tizen.NUI.Components.Button.OnKey M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        [Obsolete]
        public void ButtonOnKeyIsEnabledAsFalse()
        {
            tlog.Debug(tag, $"ButtonOnKeyIsEnabledAsFalse START");

            var testingTarget = new MyButton();
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<Button>(testingTarget, "Should return Button instance.");

            testingTarget.IsEnabled = false;
            testingTarget.IsSelected = false;

            Key key = null;
            var result = testingTarget.OnKey(key);
            Assert.AreEqual(false, result, "should be equal here!");

            key = new Key()
            {
                State = Key.StateType.Up,
                KeyPressedName = "Return"
            };
            result = testingTarget.OnKey(key);
            tlog.Debug(tag, "OnKey : " + result);

            testingTarget.Dispose();
            tlog.Debug(tag, $"ButtonOnKeyIsEnabledAsFalse END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Button OnFocusGained.")]
        [Property("SPEC", "Tizen.NUI.Components.Button.OnFocusGained M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        [Obsolete]
        public void ButtonOnFocusGained()
        {
            tlog.Debug(tag, $"ButtonOnFocusGained START");

            var testingTarget = new MyButton();
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<Button>(testingTarget, "Should return Button instance.");

            testingTarget.IsEnabled = true;
            testingTarget.IsSelected = true;
            testingTarget.Focusable = true;

            try
            {
                testingTarget.OnFocusGained();
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"ButtonOnFocusGained END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Button OnFocusLost.")]
        [Property("SPEC", "Tizen.NUI.Components.Button.OnFocusLost M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        [Obsolete]
        public void ButtonOnFocusLost()
        {
            tlog.Debug(tag, $"ButtonOnFocusLost START");

            var testingTarget = new MyButton();
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<Button>(testingTarget, "Should return Button instance.");

            testingTarget.IsEnabled = true;
            testingTarget.IsSelected = true;
            testingTarget.Focusable = true;

            try
            {
                testingTarget.OnFocusLost();
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"ButtonOnFocusLost END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Button ItemHorizontalAlignment.")]
        [Property("SPEC", "Tizen.NUI.Components.Button.ItemHorizontalAlignment A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        [Obsolete]
        public void ButtonItemHorizontalAlignment()
        {
            tlog.Debug(tag, $"ButtonItemHorizontalAlignment START");

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

            testingTarget.ItemHorizontalAlignment = HorizontalAlignment.Begin;
            tlog.Debug(tag, "ItemHorizontalAlignment" + testingTarget.ItemHorizontalAlignment);

            testingTarget.ItemVerticalAlignment = VerticalAlignment.Center;
            tlog.Debug(tag, "ItemVerticalAlignment" + testingTarget.ItemVerticalAlignment);

            testingTarget.Dispose();
            tlog.Debug(tag, $"ButtonItemHorizontalAlignment END (OK)");
        }
    }
}
