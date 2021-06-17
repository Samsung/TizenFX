using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("public/Common/StyleManager")]
    public class PublicStyleManagerTest
    {
        private const string tag = "NUITEST";
        private bool flag = false;
        private string path = Tizen.Applications.Application.Current.DirectoryInfo.Resource + "Test_Style_Manager.json";

        [Obsolete]
        private void StyleManager_StyleChanged(object sender, StyleManager.StyleChangedEventArgs e)
        {
            flag = true;
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
        [Description("StyleManager constructor.")]
        [Property("SPEC", "Tizen.NUI.StyleManager.StyleManager C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        [Obsolete]
        public void StyleManagerConstructor()
        {
            tlog.Debug(tag, $"StyleManagerConstructor START");

            var testingTarget = new StyleManager();
            Assert.IsNotNull(testingTarget, "Can't create success object StyleManager");
            Assert.IsInstanceOf<StyleManager>(testingTarget, "Should be an instance of StyleManager type.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"StyleManagerConstructor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("StyleManager Get.")]
        [Property("SPEC", "Tizen.NUI.StyleManager.Get M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        [Obsolete]
        public void StyleManagerGet()
        {
            tlog.Debug(tag, $"StyleManagerGet START");

            var testingTarget = StyleManager.Get();
            Assert.IsNotNull(testingTarget, "The value of Get return should not be null");
            Assert.IsInstanceOf<StyleManager>(testingTarget, "Should be an instance of StyleManager type.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"StyleManagerGet END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("StyleManager Instance.")]
        [Property("SPEC", "Tizen.NUI.StyleManager.Instance A")]
        [Property("SPEC_URL", " - ")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        [Obsolete]
        public void StyleManagerInstance()
        {
            tlog.Debug(tag, $"StyleManagerInstance START");

            var testingTarget = StyleManager.Instance;
            Assert.IsNotNull(testingTarget, "The value of Get return should not be null");
            Assert.IsInstanceOf<StyleManager>(testingTarget, "Should be an instance of StyleManager type.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"StyleManagerInstance END (OK)");
        }
        [Test]
        [Category("P1")]
        [Description("StyleManager AddConstant.")]
        [Property("SPEC", "Tizen.NUI.StyleManager.AddConstant M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        [Obsolete]
        public void StyleManagerAddConstant()
        {
            tlog.Debug(tag, $"StyleManagerAddConstant START");

            var testingTarget = StyleManager.Get();
            Assert.IsNotNull(testingTarget, "The value of Get return should not be null");
            Assert.IsInstanceOf<StyleManager>(testingTarget, "Should be an instance of StyleManager type.");

            using (PropertyValue value = new PropertyValue(100))
            {
                testingTarget.AddConstant("key", value);

                PropertyValue result = new PropertyValue();
                testingTarget.GetConstant("key", result);

                int num1 = 0;
                int num2 = 0;
                value.Get(out num1);
                result.Get(out num2);
                Assert.IsTrue(num1 == num2, "The get value of StyleConstant should be equals to the set");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"StyleManagerAddConstant END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("StyleManager GetConstant.")]
        [Property("SPEC", "Tizen.NUI.StyleManager.GetConstant M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        [Obsolete]
        public void StyleManagerGetConstant()
        {
            tlog.Debug(tag, $"StyleManagerGetConstant START");

            var testingTarget = StyleManager.Get();
            Assert.IsNotNull(testingTarget, "The value of Get return should not be null");
            Assert.IsInstanceOf<StyleManager>(testingTarget, "Should be an instance of StyleManager type.");

            using (PropertyValue value = new PropertyValue(100))
            {
                testingTarget.AddConstant("key", value);

                PropertyValue result = new PropertyValue();
                testingTarget.GetConstant("key", result);

                int num1 = 0;
                int num2 = 0;
                value.Get(out num1);
                result.Get(out num2);
                Assert.IsTrue(num1 == num2, "The get value of StyleConstant should be equals to the set");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"StyleManagerGetConstant END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("StyleManager StyleChanged.")]
        [Property("SPEC", "Tizen.NUI.StyleManager.StyleChanged E")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "EVL")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        [Obsolete]
        public void StyleManagerStyleChanged()
        {
            tlog.Debug(tag, $"StyleManagerStyleChanged START");

            var testingTarget = StyleManager.Get();
            Assert.IsNotNull(testingTarget, "The value of Get return should not be null");
            Assert.IsInstanceOf<StyleManager>(testingTarget, "Should be an instance of StyleManager type.");

            testingTarget.StyleChanged += StyleManager_StyleChanged;
            testingTarget.ApplyTheme(path);

            Assert.IsTrue(flag, "StyleChanged is not be called");

            testingTarget.Dispose();
            tlog.Debug(tag, $"StyleManagerStyleChanged END (OK)");
        }
    }
}
