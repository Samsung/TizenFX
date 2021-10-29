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

            testingTarget.Dispose();
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

            testingTarget.Dispose();
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

        [Test]
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
    }
}
