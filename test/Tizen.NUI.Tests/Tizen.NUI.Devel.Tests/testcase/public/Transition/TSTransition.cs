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
    [Description("public/Transition/Transition.cs")]
    public class PublicTransitionTest
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
        [Description("Transition constructor.")]
        [Property("SPEC", "Tizen.NUI.Transition.Transition C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TransitionConstructor()
        {
            tlog.Debug(tag, $"TransitionConstructor START");

            var testingTarget = new Transition();
            Assert.IsNotNull(testingTarget, "Can't create success object Transition");
            Assert.IsInstanceOf<Transition>(testingTarget, "Should be an instance of Transition type.");

            testingTarget.Dispose();

            tlog.Debug(tag, $"TransitionConstructor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Transition CreateTransition.")]
        [Property("SPEC", "Tizen.NUI.Transition.CreateTransition M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TransitionCreateTransition()
        {
            tlog.Debug(tag, $"TransitionCreateTransition START");

            var testingTarget = new Transition();
            Assert.IsNotNull(testingTarget, "Can't create success object Transition");
            Assert.IsInstanceOf<Transition>(testingTarget, "Should be an instance of Transition type.");

            using (View source = new View())
            {
                source.Position = new Position(50, 100);
                
                using (View dest = new View())
                {
                    dest.Position = new Position(100, 150);

                    try
                    {
                        var result = testingTarget.CreateTransition(source, dest);
                        Assert.IsNotNull(result, "Can't create success object TransitionItem");
                        Assert.IsInstanceOf<TransitionItem>(result, "Should be an instance of TransitionItem type.");
                    }
                    catch (Exception e)
                    {
                        tlog.Debug(tag, e.Message.ToString());
                        Assert.Fail("Caught Exception: Failed!");
                    }
                }
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"TransitionCreateTransition END (OK)");
        }
    }
}
