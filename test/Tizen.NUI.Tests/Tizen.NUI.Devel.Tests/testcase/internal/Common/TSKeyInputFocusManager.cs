using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("internal/Common/KeyInputFocusManager")]
    public class InternalKeyInputFocusManagerTest
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
        [Description("KeyInputFocusManager Get.")]
        [Property("SPEC", "Tizen.NUI.KeyInputFocusManager.Get M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void KeyInputFocusManagerGet()
        {
            tlog.Debug(tag, $"KeyInputFocusManagerGet START");

            var testingTarget = KeyInputFocusManager.Get();
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<KeyInputFocusManager>(testingTarget, "Should be an Instance of KeyInputFocusManager!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"KeyInputFocusManagerGet END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("KeyInputFocusManager SetFocus.")]
        [Property("SPEC", "Tizen.NUI.KeyInputFocusManager.SetFocus M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void KeyInputFocusManagerSetFocus()
        {
            tlog.Debug(tag, $"KeyInputFocusManagerSetFocus START");

            using (View view = new View() { Size = new Size(100, 50) })
            {
                var testingTarget = KeyInputFocusManager.Get();
                Assert.IsNotNull(testingTarget, "Should be not null!");
                Assert.IsInstanceOf<KeyInputFocusManager>(testingTarget, "Should be an Instance of KeyInputFocusManager!");

                testingTarget.SetFocus(view);
                var result = testingTarget.GetCurrentFocusControl();
                Assert.AreEqual(100, result.Size.Width, "Should be equal!");

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"KeyInputFocusManagerSetFocus END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("KeyInputFocusManager RemoveFocus.")]
        [Property("SPEC", "Tizen.NUI.KeyInputFocusManager.RemoveFocus M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void KeyInputFocusManagerRemoveFocus()
        {
            tlog.Debug(tag, $"KeyInputFocusManagerRemoveFocus START");

            using (View view = new View() { Size = new Size(100, 50) })
            {
                var testingTarget = KeyInputFocusManager.Get();
                Assert.IsNotNull(testingTarget, "Should be not null!");
                Assert.IsInstanceOf<KeyInputFocusManager>(testingTarget, "Should be an Instance of KeyInputFocusManager!");

                testingTarget.SetFocus(view);

                try
                {
                    testingTarget.RemoveFocus(view);
                }
                catch (Exception e)
                {
                    tlog.Debug(tag, e.Message.ToString());
                    Assert.Fail("Caught Exception : Failed!");
                }

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"KeyInputFocusManagerRemoveFocus END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("KeyInputFocusManager KeyInputFocusChangedSignal.")]
        [Property("SPEC", "Tizen.NUI.KeyInputFocusManager.KeyInputFocusChangedSignal M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void KeyInputFocusManagerKeyInputFocusChangedSignal()
        {
            tlog.Debug(tag, $"KeyInputFocusManagerKeyInputFocusChangedSignal START");

            using (View view = new View() { Size = new Size(100, 50) })
            {
                var testingTarget = KeyInputFocusManager.Get();
                Assert.IsNotNull(testingTarget, "Should be not null!");
                Assert.IsInstanceOf<KeyInputFocusManager>(testingTarget, "Should be an Instance of KeyInputFocusManager!");

                testingTarget.SetFocus(view);
                var signal = testingTarget.KeyInputFocusChangedSignal();
                Assert.IsNotNull(signal, "Should be not null!");
                Assert.IsInstanceOf<Tizen.NUI.SWIGTYPE_p_Dali__SignalT_void_fDali__Toolkit__Control_Dali__Toolkit__ControlF_t>(signal, "Should be an Instance of Tizen.NUI.SWIGTYPE_p_Dali__SignalT_void_fDali__Toolkit__Control_Dali__Toolkit__ControlF_t!");

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"KeyInputFocusManagerKeyInputFocusChangedSignal END (OK)");
        }
    }
}
