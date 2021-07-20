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
        [Description("CustomActorImpl constructor.")]
        [Property("SPEC", "Tizen.NUI.CustomActorImpl.CustomActorImpl C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void CustomActorImplConstructor()
        {
            tlog.Debug(tag, $"CustomActorImplConstructor START");

            using (ImageView view = new ImageView())
            {
                var testingTarget = new CustomActorImpl(view.SwigCPtr.Handle, false);
                Assert.IsNotNull(testingTarget, "Should be not null!");
                Assert.IsInstanceOf<CustomActorImpl>(testingTarget, "Should be an Instance of CustomActorImpl!");

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"CustomActorImplConstructor END (OK)");
        }
    }
}
