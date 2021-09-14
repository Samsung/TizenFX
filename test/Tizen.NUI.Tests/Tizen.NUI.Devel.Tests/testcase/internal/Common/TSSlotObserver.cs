using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("internal/Common/SlotObserver")]
    public class InternalSlotObserverTest
    {
        private const string tag = "NUITEST";
        private SWIGTYPE_p_Dali__CallbackBase callback;

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
        [Description("SlotObserver constructor.")]
        [Property("SPEC", "Tizen.NUI.SlotObserver.SlotObserver C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void SlotObserverConstructor()
        {
            tlog.Debug(tag, $"SlotObserverConstructor START");

            using (View view = new View() { Size = new Size(20, 30) })
            {
                var testingTarget = new SlotObserver(view.SwigCPtr.Handle, false);
                Assert.IsNotNull(testingTarget, "null handle");
                Assert.IsInstanceOf<SlotObserver>(testingTarget, "Should return SlotObserver instance.");

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"SlotObserverConstructor END (OK)");
        }
    }
}
