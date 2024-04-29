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
    [Description("Controls/Extension/SwitchExtension")]
    public class SwitchExtensionTest
    {
        private const string tag = "NUITEST";
        private string image_path = Tizen.Applications.Application.Current.DirectoryInfo.Resource + "picture.png";

        internal class SwitchExtensionImpl : SwitchExtension
        {
            public SwitchExtensionImpl() : base()
            { }

            public override void OnSelectedChanged(Switch switchButton)
            {
                base.OnSelectedChanged(switchButton);
            }

            public override void OnTrackOrThumbResized(Switch switchButton, ImageView track, ImageView thumb)
            {
                base.OnTrackOrThumbResized(switchButton, track, thumb);
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
        [Description("SwitchExtension ProcessThumb.")]
        [Property("SPEC", "Tizen.NUI.Components.SwitchExtension.ProcessThumb M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void SlidingSwitchExtensionProcessThumb()
        {
            tlog.Debug(tag, $"SlidingSwitchExtensionProcessThumb START");

            var testingTarget = new SwitchExtensionImpl();
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<SwitchExtension>(testingTarget, "Should return SwitchExtension instance.");

            using (Switch button = new Switch() { IsEnabled = true, IsSelected = true })
            {
                var thumb = new ImageView(image_path);
                var truck = new ImageView(image_path);
                testingTarget.OnSelectedChanged(button);
                testingTarget.OnTrackOrThumbResized(button, thumb, truck);

                var result = testingTarget.ProcessThumb(button, ref thumb);
                tlog.Debug(tag, "ProcessThumb : " + result);
            }

            tlog.Debug(tag, $"SlidingSwitchExtensionProcessThumb END (OK)");
        }
    }
}
