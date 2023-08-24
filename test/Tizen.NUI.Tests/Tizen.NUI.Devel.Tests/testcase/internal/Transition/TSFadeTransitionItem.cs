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
		
        [Test]
        [Category("P1")]
        [Description("FadeTransitionItem constructor.")]
        [Property("SPEC", "Tizen.NUI.FadeTransitionItem.FadeTransitionItem C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        [Obsolete]
        public void FadeTransitionItemConstructorWithIntPtr()
        {
            tlog.Debug(tag, $"FadeTransitionItemConstructorWithIntPtr START");

            using (View view = new View() { Size = new Size(100, 200) })
            {
                using (FadeTransitionItem item = new FadeTransitionItem(view.SwigCPtr.Handle, false))
                {
                    var testingTarget = new FadeTransitionItem(item);
                    Assert.IsNotNull(testingTarget, "Can't create success object FadeTransitionItem.");
                    Assert.IsInstanceOf<FadeTransitionItem>(testingTarget, "Should return FadeTransitionItem instance.");

                    testingTarget.Dispose();
                }
            }

            tlog.Debug(tag, $"FadeTransitionItemConstructorWithIntPtr END (OK)");
        }


        [Test]
        [Category("P1")]
        [Description("FadeTransitionItem Assign.")]
        [Property("SPEC", "Tizen.NUI.FadeTransitionItem.Assign M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void FadeTransitionItemAssign()
        {
            tlog.Debug(tag, $"FadeTransitionItemAssign START");

            using (View view = new View())
            {
                using (TimePeriod timePeriod = new TimePeriod(300))
                {
                    using (AlphaFunction alphaFunction = new AlphaFunction(AlphaFunction.BuiltinFunctions.Default))
                    {
                        var testingTarget = new FadeTransitionItem(view, 0.8f, true, timePeriod, alphaFunction);
                        Assert.IsNotNull(testingTarget, "Should be not null!");
                        Assert.IsInstanceOf<FadeTransitionItem>(testingTarget, "Should be an Instance of FadeTransitionItem!");

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
				}
            }

            tlog.Debug(tag, $"FadeTransitionItemAssign END (OK)");
        }		
    }
}
