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
    [Description("public/Transition/Fade.cs")]
    public class PublicFadeTest
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
        [Description("Fade constructor.")]
        [Property("SPEC", "Tizen.NUI.Fade.Fade C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void FadeConstructor()
        {
            tlog.Debug(tag, $"FadeConstructor START");

            var testingTarget = new Fade();
            Assert.IsNotNull(testingTarget, "Can't create success object Fade");
            Assert.IsInstanceOf<Fade>(testingTarget, "Should be an instance of Fade type.");

            testingTarget.Dispose();

            tlog.Debug(tag, $"FadeConstructor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Fade Opacity.")]
        [Property("SPEC", "Tizen.NUI.Fade.Opacity A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void FadeOpacity()
        {
            tlog.Debug(tag, $"FadeOpacity START");

            var testingTarget = new Fade();
            Assert.IsNotNull(testingTarget, "Can't create success object Fade");
            Assert.IsInstanceOf<Fade>(testingTarget, "Should be an instance of Fade type.");

            testingTarget.Opacity = 0.3f;
            tlog.Debug(tag, testingTarget.Opacity.ToString());

            testingTarget.Dispose();
            tlog.Debug(tag, $"FadeOpacity END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Fade CreateTransition.")]
        [Property("SPEC", "Tizen.NUI.Fade.CreateTransition M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void FadeCreateTransition()
        {
            tlog.Debug(tag, $"FadeCreateTransition START");

            var testingTarget = new Fade();
            Assert.IsNotNull(testingTarget, "Can't create success object Fade");
            Assert.IsInstanceOf<Fade>(testingTarget, "Should be an instance of Fade type.");

            using (View view = new View())
            {
                try
                {
                    testingTarget.CreateTransition(view, false);
                }
                catch (Exception e)
                {
                    tlog.Debug(tag, e.Message.ToString());
                    Assert.Fail("Caught Exception : Falied!");
                }
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"FadeCreateTransition END (OK)");
        }
    }
}
