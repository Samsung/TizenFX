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
            {  }
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
        [Description("SwitchExtension OnCreateTrack.")]
        [Property("SPEC", "Tizen.NUI.Components.SwitchExtension.OnCreateTrack M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void SlidingSwitchExtensionOnSelectedChanged()
        {
            tlog.Debug(tag, $"SlidingSwitchExtensionOnSelectedChanged START");

            var testingTarget = new SwitchExtensionImpl();
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<SwitchExtension>(testingTarget, "Should return SwitchExtension instance.");

            using (Switch button = new Switch() { IsEnabled = true, IsSelected = true } )
            {
                var result = testingTarget.OnCreateTrack(button, new ImageView(image_path));
                tlog.Debug(tag, "OnCreateTrack : " + result);

                result = testingTarget.OnCreateThumb(button, new ImageView(image_path));
                tlog.Debug(tag, "OnCreateThumb : " + result);
            }

            tlog.Debug(tag, $"SlidingSwitchExtensionOnSelectedChanged END (OK)");
        }
    }
}
