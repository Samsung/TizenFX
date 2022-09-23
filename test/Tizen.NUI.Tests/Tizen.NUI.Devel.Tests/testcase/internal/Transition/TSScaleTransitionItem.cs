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
    [Description("public/Transition/ScaleTransitionItem")]
    public class InternalScaleTransitionItemTest
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
        [Description("ScaleTransitionItem constructor.")]
        [Property("SPEC", "Tizen.NUI.ScaleTransitionItem.ScaleTransitionItem C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        [Obsolete]
        public void ScaleTransitionItemConstructor()
        {
            tlog.Debug(tag, $"ScaleTransitionItemConstructor START");

            using (View view = new View() { Size = new Size(100, 200) })
            {
                using (TimePeriod timePeriod = new TimePeriod(300))
                {
                    using (AlphaFunction alphaFunction = new AlphaFunction(AlphaFunction.BuiltinFunctions.Default))
                    {
                        var testingTarget = new ScaleTransitionItem(view, 0.8f, true, timePeriod, alphaFunction);
                        Assert.IsNotNull(testingTarget, "Can't create success object ScaleTransitionItem.");
                        Assert.IsInstanceOf<ScaleTransitionItem>(testingTarget, "Should return ScaleTransitionItem instance.");

                        testingTarget.Dispose();
                    }
                }
            }

            tlog.Debug(tag, $"ScaleTransitionItemConstructor END (OK)");
        }
		
        [Test]
        [Category("P1")]
        [Description("ScaleTransitionItem constructor with Vector.")]
        [Property("SPEC", "Tizen.NUI.ScaleTransitionItem.with Vector C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        [Obsolete]
        public void ScaleTransitionItemConstructorwithVector()
        {
            tlog.Debug(tag, $"ScaleTransitionItemConstructorwithVector START");

            using (View view = new View() { Size = new Size(100, 200) })
            {
                using (TimePeriod timePeriod = new TimePeriod(300))
                {
                    using (AlphaFunction alphaFunction = new AlphaFunction(AlphaFunction.BuiltinFunctions.Default))
                    {
                        var testingTarget = new ScaleTransitionItem(view, new Vector2(0.0f, 0.0f), true, timePeriod, alphaFunction);
                        Assert.IsNotNull(testingTarget, "Can't create success object ScaleTransitionItem.");
                        Assert.IsInstanceOf<ScaleTransitionItem>(testingTarget, "Should return ScaleTransitionItem instance.");

                        testingTarget.Dispose();
                    }
                }
            }

            tlog.Debug(tag, $"ScaleTransitionItemConstructorwithVector END (OK)");
        }	
		
        [Test]
        [Category("P1")]
        [Description("ScaleTransitionItem Assign.")]
        [Property("SPEC", "Tizen.NUI.ScaleTransitionItem.Assign M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ScaleTransitionItemAssign()
        {
            tlog.Debug(tag, $"ScaleTransitionItemAssign START");

            using (View view = new View())
            {
                var testingTarget = new ScaleTransitionItem(view.SwigCPtr.Handle, false);
                Assert.IsNotNull(testingTarget, "Should be not null!");
                Assert.IsInstanceOf<ScaleTransitionItem>(testingTarget, "Should be an Instance of ScaleTransitionItem!");

                try
                {
                    testingTarget.Assign(testingTarget);
                }
                catch (Exception e)
                {
                    tlog.Debug(tag, e.Message.ToString());
                    Assert.Fail("Caught Exception: Failed!");
                }

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"ScaleTransitionItemAssign END (OK)");
        }
    }
}
