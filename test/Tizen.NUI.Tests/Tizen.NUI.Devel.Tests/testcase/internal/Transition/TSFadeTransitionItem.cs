using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;
using System.Collections.Generic;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("public/Transition/FadeTransitionItem")]
    public class InternalFadeTransitionItemTest
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
        [Description("FadeTransitionItem constructor.")]
        [Property("SPEC", "Tizen.NUI.FadeTransitionItem.FadeTransitionItem C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        [Obsolete]
        public void FadeTransitionItemConstructor()
        {
            tlog.Debug(tag, $"FadeTransitionItemConstructor START");

            using (View view = new View() { Size = new Size(100, 200) })
            {
                using (TimePeriod timePeriod = new TimePeriod(300))
                {
                    using (AlphaFunction alphaFunction = new AlphaFunction(AlphaFunction.BuiltinFunctions.Default))
                    {
                        var testingTarget = new FadeTransitionItem(view, 0.8f, true, timePeriod, alphaFunction);
                        Assert.IsNotNull(testingTarget, "Can't create success object FadeTransitionItem.");
                        Assert.IsInstanceOf<FadeTransitionItem>(testingTarget, "Should return FadeTransitionItem instance.");

                        testingTarget.Dispose();
                    }
                }
            }

            tlog.Debug(tag, $"FadeTransitionItemConstructor END (OK)");
        }
    }
}
