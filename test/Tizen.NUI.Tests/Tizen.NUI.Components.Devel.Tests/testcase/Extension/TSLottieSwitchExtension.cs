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
    }
}
