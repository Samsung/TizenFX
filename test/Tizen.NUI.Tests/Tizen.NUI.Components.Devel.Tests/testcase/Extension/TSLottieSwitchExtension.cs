using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components.Extension;

namespace Tizen.NUI.Components.Devel.Tests
{
    using static Tizen.NUI.BaseComponents.View;
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("Controls/Extension/LottieSwitchExtension")]
    public class LottieSwitchExtensionTest
    {
        private const string tag = "NUITEST";
        private string image_path = Tizen.Applications.Application.Current.DirectoryInfo.Resource + "picture.png";

        internal class LottieSwitchExtensionImpl : LottieSwitchExtension
        {
            public LottieSwitchExtensionImpl() : base()
            { }

            public override ImageView OnCreateIcon(Button button, ImageView icon)
            {
                return base.OnCreateIcon(button, icon);
            }

            public override void OnControlStateChanged(Button button, View.ControlStateChangedEventArgs args)
            {
                base.OnControlStateChanged(button, args);
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
        [Description("LottieSwitchExtension constructor.")]
        [Property("SPEC", "Tizen.NUI.Components.LottieSwitchExtension.LottieSwitchExtension C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void LottieSwitchExtensionConstructor()
        {
            tlog.Debug(tag, $"LottieSwitchExtensionConstructor START");

            var testingTarget = new LottieSwitchExtension();
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<LottieSwitchExtension>(testingTarget, "Should return LottieSwitchExtension instance.");

            tlog.Debug(tag, $"LottieSwitchExtensionConstructor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("LottieSwitchExtension OnCreateIcon.")]
        [Property("SPEC", "Tizen.NUI.Components.LottieSwitchExtension.OnCreateIcon M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void LottieSwitchExtensionOnCreateIcon()
        {
            tlog.Debug(tag, $"LottieSwitchExtensionOnCreateIcon START");

            var testingTarget = new LottieSwitchExtensionImpl();
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<LottieSwitchExtension>(testingTarget, "Should return LottieSwitchExtension instance.");

            LottieButtonStyle style = new LottieButtonStyle();
            Button button = new Button(style as ButtonStyle)
            {
                Size = new Size(100, 80),
            };

            ImageView icon = new ImageView()
            { 
                ResourceUrl = image_path,
            };

            var result = testingTarget.OnCreateIcon(button, icon);
            Assert.IsNotNull(result, "null handle");
            Assert.IsInstanceOf<ImageView>(result, "Should return LottieSwitchExtension instance.");

            icon.Dispose();
            button.Dispose();
            result.Dispose();
            tlog.Debug(tag, $"LottieSwitchExtensionOnCreateIcon END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("LottieSwitchExtension OnControlStateChanged.")]
        [Property("SPEC", "Tizen.NUI.Components.LottieSwitchExtension.OnControlStateChanged M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void LottieSwitchExtensionOnControlStateChanged()
        {
            tlog.Debug(tag, $"LottieSwitchExtensionOnControlStateChanged START");

            var testingTarget = new LottieSwitchExtensionImpl();
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<LottieSwitchExtension>(testingTarget, "Should return LottieSwitchExtension instance.");

            LottieButtonStyle style = new LottieButtonStyle();
            Button button = new Button(style as ButtonStyle)
            {
                Size = new Size(100, 80),
            };

            ControlStateChangedEventArgs args = new ControlStateChangedEventArgs(ControlState.Focused, ControlState.Selected);

            try
            {
                testingTarget.OnControlStateChanged(button, args);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            button.Dispose();
            tlog.Debug(tag, $"LottieSwitchExtensionOnControlStateChanged END (OK)");
        }
    }
}
