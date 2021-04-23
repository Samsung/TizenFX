using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("internal/Animation/AnimatablePropertyComponentRegistration")]
    public class InternalAnimatablePropertyComponentRegistrationTest
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
        [Description("AnimatablePropertyComponentRegistration constructor")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void AnimatablePropertyComponentRegistrationConstructor()
        {
            tlog.Debug(tag, $"AnimatablePropertyComponentRegistrationConstructor START");

            var ani = new Animatable();
            Assert.IsNotNull(ani, "should be not null");
            Assert.IsInstanceOf<Animatable>(ani, "should be an instance of Animatable class!");

            var registered = new TypeRegistration((global::System.IntPtr)ani.SwigCPtr, false);
            var testingTarget = new AnimatablePropertyComponentRegistration(registered, "Animatable", 28000000, 28000000, (uint)28000000);
            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<AnimatablePropertyComponentRegistration>(testingTarget, "should be an instance of testing target class!");

            testingTarget.Dispose();
            registered.Dispose();
            ani.Dispose();
            tlog.Debug(tag, $"AnimatablePropertyComponentRegistrationConstructor END (OK)");
        }
    }
}
