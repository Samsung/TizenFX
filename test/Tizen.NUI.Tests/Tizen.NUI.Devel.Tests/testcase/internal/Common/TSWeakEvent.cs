using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("internal/Common/WeakEvent")]
    public class InternalWeakEventTest
    {
        private const string tag = "NUITEST";

        private static event EventHandler<EventArgs> OnChanged;
        private void OnDummyCallback(object target, EventArgs data) { }

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
        [Description("WeakEvent Invoke.")]
        [Property("SPEC", "Tizen.NUI.WeakEvent.Invoke M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void WeakEventInvoke()
        {
            tlog.Debug(tag, $"WeakEventInvoke START");

            var testingTarget = new NUI.WeakEvent<EventHandler<EventArgs>>();
            Assert.IsNotNull(testingTarget, "Can't create success object WeakEvent");
            Assert.IsInstanceOf<NUI.WeakEvent<EventHandler<EventArgs>>>(testingTarget, "Should be an instance of WeakEvent type.");

            OnChanged += OnDummyCallback;
            testingTarget.Add(OnChanged);

            try
            {
                testingTarget.Invoke(null, new EventArgs());
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            testingTarget.Remove(OnChanged);
            OnChanged -= OnDummyCallback;
            tlog.Debug(tag, $"WeakEventInvoke START");
        }
    }
}
