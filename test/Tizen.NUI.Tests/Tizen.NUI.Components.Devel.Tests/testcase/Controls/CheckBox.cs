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
    [Description("Controls/CheckBox")]
    class CheckBoxText
    {
        private const string tag = "NUITEST";

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
        [Description("CheckBox ItemGroup.")]
        [Property("SPEC", "Tizen.NUI.Components.CheckBox.ItemGroup A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void CheckBoxItemGroup()
        {
            tlog.Debug(tag, $"CheckBoxItemGroup START");

            CheckBox cb = new CheckBox()
            {
                Size = new Size(48, 48),
                IsEnabled = true,
                IsSelectable = true,
                IsSelected = true,
            };
            Assert.IsNotNull(cb, "null handle");
            Assert.IsInstanceOf<CheckBox>(cb, "Should return CheckBox instance.");

            CheckBoxGroup cbGroup = new CheckBoxGroup();
            cbGroup.Add(cb);

            var testingTarget = cb.ItemGroup;
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<CheckBoxGroup>(testingTarget, "Should return CheckBoxGroup instance.");

            cb.Dispose();
            tlog.Debug(tag, $"CheckBoxItemGroup END (OK)");
        }
    }
}
