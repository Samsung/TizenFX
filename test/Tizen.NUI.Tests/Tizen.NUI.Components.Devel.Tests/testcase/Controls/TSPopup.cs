using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;
using System.Collections.ObjectModel;

namespace Tizen.NUI.Components.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("Controls/Popup")]
    public class PopupTest
    {
        private const string tag = "NUITEST";
        private string image_path = Tizen.Applications.Application.Current.DirectoryInfo.Resource + "picture.png";

        internal class PopupImpl : Popup
        {
            public PopupImpl() : base()
            { }

            public void OnCreateViewStyle()
            {

                base.CreateViewStyle();
            }

            public void OnUpdateImpl()
            {
                base.OnUpdate();
            }

            public AccessibilityStates OnAccessibilityCalculateStates()
            {
                return base.AccessibilityCalculateStates();
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
        [Description("Popup constructor.")]
        [Property("SPEC", "Tizen.NUI.Components.Popup.Popup C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        [Obsolete]
        public void PopupConstructor()
        {
            tlog.Debug(tag, $"PopupConstructor START");

            var testingTarget = new Popup();
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<Popup>(testingTarget, "Should return Popup instance.");

            //Todo: this means that letting the Popup implicitly disposed. but explicit dispose causes BLOCK. this need be fixed!
            //testingTarget.Dispose();
            tlog.Debug(tag, $"PopupConstructor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Popup constructor.")]
        [Property("SPEC", "Tizen.NUI.Components.Popup.Popup C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        [Obsolete]
        public void PopupConstructorWithPopupStyle()
        {
            tlog.Debug(tag, $"PopupConstructorWithPopupStyle START");

            PopupStyle style = new PopupStyle()
            {
                Size = new Size(50, 100),
            };

            var testingTarget = new Popup(style);
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<Popup>(testingTarget, "Should return Popup instance.");

            //Todo: this means that letting the Popup implicitly disposed. but explicit dispose causes BLOCK. this need be fixed!
            //testingTarget.Dispose();
            tlog.Debug(tag, $"PopupConstructorWithPopupStyle END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Popup AddContentText.")]
        [Property("SPEC", "Tizen.NUI.Components.Popup.AddContentText M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        [Obsolete]
        public void PopupAddContentText()
        {
            tlog.Debug(tag, $"PopupAddContentText START");

            var testingTarget = new Popup();
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<Popup>(testingTarget, "Should return Popup instance.");

            testingTarget.MinimumSize = new Size(1032, 184);
            testingTarget.Size = new Size(1032, 400);
            testingTarget.Position = new Position(150, 100);

            testingTarget.TitleText = "Popup";
            tlog.Debug(tag, "TitleText : " + testingTarget.TitleText);

            testingTarget.TitlePointSize = 15.0f;
            tlog.Debug(tag, "TitlePointSize : " + testingTarget.TitlePointSize);

            testingTarget.TitleTextColor = Color.Blue;
            tlog.Debug(tag, "TitelTextColor : " + testingTarget.TitleTextColor);

            testingTarget.TitleTextHorizontalAlignment = HorizontalAlignment.Begin;
            tlog.Debug(tag, "TitleTextHorizontalAlignment : " + testingTarget.TitleTextHorizontalAlignment);

            testingTarget.TitleTextPosition = new Position(64, 52);
            tlog.Debug(tag, "TitleTextPosition : " + testingTarget.TitleTextPosition);

            testingTarget.TitleHeight = 20;
            tlog.Debug(tag, "TitleHeight : " + testingTarget.TitleHeight);

            testingTarget.Title.Padding = 0;

            testingTarget.ImageShadow = new ImageShadow(image_path);

            testingTarget.BackgroundImage = image_path;
            testingTarget.BackgroundImageBorder = new Rectangle(0, 0, 81, 81);

            testingTarget.AddButton("Ok");
            testingTarget.AddButton("Cancel");

            testingTarget.ButtonBackground = image_path;
            testingTarget.ButtonBackgroundBorder = new Rectangle(5, 5, 5, 5);
            testingTarget.ButtonOverLayBackgroundColorSelector = new Selector<Color>
            {
                Normal = new Color(1.0f, 1.0f, 1.0f, 0.5f),
                Pressed = new Color(0.0f, 0.0f, 0.0f, 0.5f)
            };
            testingTarget.ButtonImageShadow = new ImageShadow(image_path);
            testingTarget.Post(Window.Instance);

            var contentText = new TextLabel();
            contentText.Size = new Size(1032, 100);
            contentText.PointSize = 20;
            contentText.HorizontalAlignment = HorizontalAlignment.Begin;
            contentText.VerticalAlignment = VerticalAlignment.Center;
            contentText.Text = "Popup ButtonStyle!";
            contentText.TextColor = new Color(0, 0, 222, 1);
            testingTarget.AddContentText(contentText);

            testingTarget.Dismiss();

            testingTarget.Dispose();
            tlog.Debug(tag, $"PopupAddContentText END (OK)");
        }

        //Todo: this causes BLOCK, should be fixed.
        //[Test]
        [Category("P1")]
        [Description("Popup AddButton.")]
        [Property("SPEC", "Tizen.NUI.Components.Popup.AddButton M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        [Obsolete]
        public void PopupAddButton()
        {
            tlog.Debug(tag, $"PopupAddButton START");

            var testingTarget = new Popup();
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<Popup>(testingTarget, "Should return Popup instance.");

            try
            {
                testingTarget.AddButton("lb");

                ButtonStyle style = new ButtonStyle()
                {
                    Opacity = 0.8f,
                };
                testingTarget.AddButton("rb", style);

                var result = testingTarget.GetButton(0);
                tlog.Debug(tag, "GetButton : " + result);

                try
                {
                    testingTarget.RemoveButton(0);
                }
                catch (Exception e)
                {
                    tlog.Debug(tag, e.Message.ToString());
                    Assert.Fail("Caught Exception : Failed!");
                }
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"PopupAddButton END (OK)");
        }

        [Category("P1")]
        [Description("Popup ButtonCount.")]
        [Property("SPEC", "Tizen.NUI.Components.Popup.ButtonCount A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        [Obsolete]
        public void PopupButtonCount()
        {
            tlog.Debug(tag, $"PopupButtonCount START");

            var testingTarget = new Popup();
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<Popup>(testingTarget, "Should return Popup instance.");

            tlog.Debug(tag, "ButtonCount :" + testingTarget.ButtonCount);

            testingTarget.ButtonCount = 3;
            tlog.Debug(tag, "ButtonCount :" + testingTarget.ButtonCount);

            testingTarget.Dispose();
            tlog.Debug(tag, $"PopupButtonCount END (OK)");
        }

        [Category("P1")]
        [Description("Popup ButtonTextPointSize.")]
        [Property("SPEC", "Tizen.NUI.Components.Popup.ButtonTextPointSize A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        [Obsolete]
        public void PopupButtonTextPointSize()
        {
            tlog.Debug(tag, $"PopupButtonTextPointSize START");

            var testingTarget = new Popup();
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<Popup>(testingTarget, "Should return Popup instance.");

            testingTarget.ButtonTextPointSize = 15.0f;
            tlog.Debug(tag, "ButtonTextPointSize :" + testingTarget.ButtonTextPointSize);

            testingTarget.Dispose();
            tlog.Debug(tag, $"PopupButtonTextPointSize END (OK)");
        }

        [Category("P1")]
        [Description("Popup ButtonFontFamily.")]
        [Property("SPEC", "Tizen.NUI.Components.Popup.ButtonFontFamily A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        [Obsolete]
        public void PopupButtonFontFamily()
        {
            tlog.Debug(tag, $"PopupButtonFontFamily START");

            var testingTarget = new Popup();
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<Popup>(testingTarget, "Should return Popup instance.");

            testingTarget.ButtonFontFamily = "Samsung One UI";
            tlog.Debug(tag, "ButtonFontFamily :" + testingTarget.ButtonFontFamily);

            testingTarget.Dispose();
            tlog.Debug(tag, $"PopupButtonFontFamily END (OK)");
        }

        [Category("P1")]
        [Description("Popup ButtonTextColor.")]
        [Property("SPEC", "Tizen.NUI.Components.Popup.ButtonTextColor A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        [Obsolete]
        public void PopupButtonTextColor()
        {
            tlog.Debug(tag, $"PopupButtonTextColor START");

            var testingTarget = new Popup();
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<Popup>(testingTarget, "Should return Popup instance.");

            testingTarget.ButtonTextColor = Color.Yellow;
            tlog.Debug(tag, "ButtonTextColor :" + testingTarget.ButtonTextColor);

            testingTarget.Dispose();
            tlog.Debug(tag, $"PopupButtonTextColor END (OK)");
        }

        [Category("P1")]
        [Description("Popup ButtonTextAlignment.")]
        [Property("SPEC", "Tizen.NUI.Components.Popup.ButtonTextAlignment A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        [Obsolete]
        public void PopupButtonTextAlignment()
        {
            tlog.Debug(tag, $"PopupButtonTextAlignment START");

            var testingTarget = new Popup();
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<Popup>(testingTarget, "Should return Popup instance.");

            testingTarget.ButtonTextAlignment = HorizontalAlignment.Center;
            tlog.Debug(tag, "ButtonTextAlignment :" + testingTarget.ButtonTextAlignment);

            testingTarget.Dispose();
            tlog.Debug(tag, $"PopupButtonTextAlignment END (OK)");
        }

        [Category("P1")]
        [Description("Popup SetButtonText.")]
        [Property("SPEC", "Tizen.NUI.Components.Popup.SetButtonText M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        [Obsolete]
        public void PopupSetButtonText()
        {
            tlog.Debug(tag, $"PopupSetButtonText START");

            var testingTarget = new Popup();
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<Popup>(testingTarget, "Should return Popup instance.");

            testingTarget.SetButtonText(0, "PopupText");
            tlog.Debug(tag, "ButtonText :" + testingTarget.GetButton(0).Text);

            testingTarget.Dispose();
            tlog.Debug(tag, $"PopupSetButtonText END (OK)");
        }

        [Category("P1")]
        [Description("Popup OnFocusGained.")]
        [Property("SPEC", "Tizen.NUI.Components.Popup.OnFocusGained M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        [Obsolete]
        public void PopupOnFocusGained()
        {
            tlog.Debug(tag, $"PopupOnFocusGained START");

            var testingTarget = new Popup();
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<Popup>(testingTarget, "Should return Popup instance.");

            testingTarget.OnFocusGained();
            tlog.Debug(tag, "IsFocused :" + testingTarget.IsFocused);

            testingTarget.Dispose();
            tlog.Debug(tag, $"PopupOnFocusGained END (OK)");
        }

        [Category("P1")]
        [Description("Popup OnFocusGained.")]
        [Property("SPEC", "Tizen.NUI.Components.Popup.OnFocusGained M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        [Obsolete]
        public void PopupOnFocusLost()
        {
            tlog.Debug(tag, $"PopupOnFocusLost START");

            var testingTarget = new Popup();
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<Popup>(testingTarget, "Should return Popup instance.");

            testingTarget.OnFocusLost();
            tlog.Debug(tag, "IsFocused :" + testingTarget.IsFocused);

            testingTarget.Dispose();
            tlog.Debug(tag, $"PopupOnFocusLost END (OK)");
        }

        [Category("P1")]
        [Description("Popup CreateViewStyle.")]
        [Property("SPEC", "Tizen.NUI.Components.Popup.CreateViewStyle M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        [Obsolete]
        public void PopupCreateViewStyle()
        {
            tlog.Debug(tag, $"PopupCreateViewStyle START");

            var testingTarget = new PopupImpl();
            Assert.IsNotNull(testingTarget, "null handle");

            try
            {
                testingTarget.OnCreateViewStyle();
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"PopupCreateViewStyle END (OK)");
        }

        [Category("P1")]
        [Description("Popup OnUpdate.")]
        [Property("SPEC", "Tizen.NUI.Components.Popup.OnUpdate M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        [Obsolete]
        public void PopupOnUpdate()
        {
            tlog.Debug(tag, $"PopupOnUpdate START");

            var testingTarget = new PopupImpl();
            Assert.IsNotNull(testingTarget, "null handle");

            try
            {
                testingTarget.OnUpdateImpl();
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"PopupOnUpdate END (OK)");
        }

        [Category("P1")]
        [Description("Popup AccessibilityCalculateStates.")]
        [Property("SPEC", "Tizen.NUI.Components.Popup.AccessibilityCalculateStates M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        [Obsolete]
        public void PopupAccessibilityCalculateStates()
        {
            tlog.Debug(tag, $"PopupAccessibilityCalculateStates START");

            var testingTarget = new PopupImpl();
            Assert.IsNotNull(testingTarget, "null handle");

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
            tlog.Debug(tag, $"PopupAccessibilityCalculateStates END (OK)");
        }
    }
}
