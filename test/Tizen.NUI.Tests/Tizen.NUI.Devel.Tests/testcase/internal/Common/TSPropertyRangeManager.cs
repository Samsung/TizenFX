using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("internal/Common/PropertyRangeManager")]
    public class InternalPropertyRangeManagerTest
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
        [Description("PropertyRangeManager constructor.")]
        [Property("SPEC", "Tizen.NUI.PropertyRangeManager.PropertyRangeManager C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PropertyRangeManagerConstructor()
        {
            tlog.Debug(tag, $"PropertyRangeManagerConstructor START");

            var testingTarget = new PropertyRangeManager();
            Assert.IsNotNull(testingTarget, "Can't create success object PropertyRangeManager.");
            Assert.IsInstanceOf<PropertyRangeManager>(testingTarget, "Should return PropertyRangeManager instance.");

            tlog.Debug(tag, $"PropertyRangeManagerConstructor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("PropertyRangeManager GetPropertyIndex.")]
        [Property("SPEC", "Tizen.NUI.PropertyRangeManager.GetPropertyIndex M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PropertyRangeManagerGetPropertyIndex()
        {
            tlog.Debug(tag, $"PropertyRangeManagerGetPropertyIndex START");

            var testingTarget = new PropertyRangeManager();
            Assert.IsNotNull(testingTarget, "Can't create success object PropertyRangeManager.");
            Assert.IsInstanceOf<PropertyRangeManager>(testingTarget, "Should return PropertyRangeManager instance.");

            using (Spin spin = new Spin())
            {
                spin.Name = "spin";

                var result = testingTarget.GetPropertyIndex(spin.Name, typeof(Spin), ScriptableProperty.ScriptableType.Default);
                tlog.Debug(tag, "PropertyIndex : " + result);
            }

            tlog.Debug(tag, $"PropertyRangeManagerGetPropertyIndex END (OK)");
        }

        [Test]
        [Category("P1 ")]
        [Description("PropertyRangeManager GetPropertyIndex. ScriptableType is not Default.")]
        [Property("SPEC", "Tizen.NUI.PropertyRangeManager.GetPropertyIndex M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PropertyRangeManagerGetPropertyIndexScriptableTypeNotDefault()
        {
            tlog.Debug(tag, $"PropertyRangeManagerGetPropertyIndexScriptableTypeNotDefault START");

            var testingTarget = new PropertyRangeManager();
            Assert.IsNotNull(testingTarget, "Can't create success object PropertyRangeManager.");
            Assert.IsInstanceOf<PropertyRangeManager>(testingTarget, "Should return PropertyRangeManager instance.");

            using (Spin spin = new Spin())
            {
                spin.Name = "spin";

                var result = testingTarget.GetPropertyIndex(spin.Name, typeof(Spin), (ScriptableProperty.ScriptableType)1);
                tlog.Debug(tag, "PropertyIndex : " + result);
            }

            tlog.Debug(tag, $"PropertyRangeManagerGetPropertyIndexScriptableTypeNotDefault END (OK)");
        }
    }
}
