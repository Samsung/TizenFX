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
    [Description("Controls/Extension/SlidingSwitchExtension")]
    public class SlidingSwitchExtensionTest
    {
        private const string tag = "NUITEST";
        private string image_path = Tizen.Applications.Application.Current.DirectoryInfo.Resource + "picture.png";

        internal class MySlidingSwitchExtension : SlidingSwitchExtension
        {
            public MySlidingSwitchExtension() : base()
            { }

            public void MyOnSelectedChanged(Switch button)
            {
                base.OnSelectedChanged(button);
            }

            public void MyDispose(bool disposing)
            {
                base.Dispose(disposing);
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
        [Description("SlidingSwitchExtension OnSelectedChanged.")]
        [Property("SPEC", "Tizen.NUI.Components.SlidingSwitchExtension.OnSelectedChanged M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void SlidingSwitchExtensionOnSelectedChanged()
        {
            tlog.Debug(tag, $"SlidingSwitchExtensionOnSelectedChanged START");

            var testingTarget = new MySlidingSwitchExtension();
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<MySlidingSwitchExtension>(testingTarget, "Should return SlidingSwitchExtension instance.");

            SwitchStyle style = new SwitchStyle()
            {
                Track = new ImageViewStyle()
                {
                    BackgroundImage = image_path,
                },
                Thumb = new ImageViewStyle()
                {
                    BackgroundImage = image_path,
                },
            };

            using (Switch button = new Switch(style) )
            {

                Window.Instance.Add(button);

                try
                {
                    testingTarget.MyOnSelectedChanged(button);
                }
                catch (Exception e)
                {
                    tlog.Debug(tag, e.Message.ToString());
                    Assert.Fail("Caught Exception : Failed!");
                }
            }

            testingTarget.MyDispose(true);
            tlog.Debug(tag, $"SlidingSwitchExtensionOnSelectedChanged END (OK)");
        }
    }
}
