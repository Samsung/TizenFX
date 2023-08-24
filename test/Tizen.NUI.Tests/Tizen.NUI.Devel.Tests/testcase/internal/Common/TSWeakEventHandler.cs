using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("internal/Common/WeakEventHandler")]
    public class InternalWeakEventHandlerTest
    {
        private const string tag = "NUITEST";
        private void OnDummyCallback(object sender, EventArgs e) { }

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
        [Description("WeakEventHandler constructor.")]
        [Property("SPEC", "Tizen.NUI.WeakEventHandler.WeakEventHandler C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void WeakEventHandlerConstructor()
        {
            tlog.Debug(tag, $"WeakEventHandlerConstructor START");

            EventHandler<EventArgs> callback = OnDummyCallback;

            var testingTarget = new WeakEventHandler<EventArgs>(callback);
            Assert.IsNotNull(testingTarget, "Can't create success object WeakEventHandler");
            Assert.IsInstanceOf<WeakEventHandler<EventArgs>>(testingTarget, "Should be an instance of WeakEventHandler type.");

            using (View view = new View())
            {
                try
                {
                    testingTarget.Handler(view, new EventArgs());
                }
                catch (Exception e)
                {
                    tlog.Debug(tag, e.Message.ToString());
                    Assert.Fail("Caught Exception : Failed!");
                }
            }
                
            tlog.Debug(tag, $"WeakEventHandlerConstructor END (OK)");
        }
    }
}
