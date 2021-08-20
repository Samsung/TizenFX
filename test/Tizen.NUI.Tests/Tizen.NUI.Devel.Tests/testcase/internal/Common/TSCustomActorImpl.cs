using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("internal/Common/CustomActorImpl")]
    public class InternalCustomActorImplTest
    {
        private const string tag = "NUITEST";
        private View actor = null;

        internal class MyCustomActorImpl : CustomActorImpl
        {
            public MyCustomActorImpl(global::System.IntPtr cPtr, bool cMemoryOwn) : base(cPtr, cMemoryOwn)
            { 
            }
        }

        [SetUp]
        public void Init()
        {
            tlog.Info(tag, "Init() is called!");
            actor = new View() { Size = new Size(100, 200) };
        }

        [TearDown]
        public void Destroy()
        {
            actor.Dispose();
            tlog.Info(tag, "Destroy() is called!");
        }

        [Test]
        [Category("P1")]
        [Description("CustomActorImpl constructor.")]
        [Property("SPEC", "Tizen.NUI.CustomActorImpl.CustomActorImpl C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void CustomActorImplConstructor()
        {
            tlog.Debug(tag, $"CustomActorImplConstructor START");

            var testingTarget = new CustomActorImpl(actor.SwigCPtr.Handle, false);
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<CustomActorImpl>(testingTarget, "Should be an Instance of CustomActorImpl!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"CustomActorImplConstructor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("CustomActorImpl IsRelayoutEnabled.")]
        [Property("SPEC", "Tizen.NUI.CustomActorImpl.IsRelayoutEnabled M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void CustomActorImplIsRelayoutEnabled()
        {
            tlog.Debug(tag, $"CustomActorImplIsRelayoutEnabled START");

            var testingTarget = new CustomActorImpl(actor.SwigCPtr.Handle, false);
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<CustomActorImpl>(testingTarget, "Should be an Instance of CustomActorImpl!");

            var result = testingTarget.IsRelayoutEnabled();
            tlog.Debug(tag, "IsRelayoutEnabled : " + result);

            testingTarget.Dispose();
            tlog.Debug(tag, $"CustomActorImplIsRelayoutEnabled END (OK)");
        }
    }
}
