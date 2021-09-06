using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("Internal/Transition/FadeItem")]
    public class InternalFadeItemTest
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
        [Description("FadeItem constructor.")]
        [Property("SPEC", "Tizen.NUI.FadeItem.FadeItem C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void FadeItemConstructor()
        {
            tlog.Debug(tag, $"FadeItemConstructor START");

            using (View view = new View())
            {
                using (TimePeriod timePeriod = new TimePeriod(300))
                {
                    using (AlphaFunction alphaFunction = new AlphaFunction(AlphaFunction.BuiltinFunctions.Default))
                    {
                        var testingTarget = new FadeItem(view, 0.3f, false, timePeriod, alphaFunction);
                        Assert.IsNotNull(testingTarget, "Should be not null!");
                        Assert.IsInstanceOf<FadeItem>(testingTarget, "Should be an Instance of FadeItem!");

                        testingTarget.Dispose();
                    }
                }
            }
                
            tlog.Debug(tag, $"FadeItemConstructor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("FadeItem constructor.")]
        [Property("SPEC", "Tizen.NUI.FadeItem.FadeItem C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void FadeItemConstructorWithFadeItem()
        {
            tlog.Debug(tag, $"FadeItemConstructorWithFadeItem START");

            using (View view = new View())
            {
                using (TimePeriod timePeriod = new TimePeriod(300))
                {
                    using (AlphaFunction alphaFunction = new AlphaFunction(AlphaFunction.BuiltinFunctions.Default))
                    {
                        using (FadeItem item = new FadeItem(view, 0.3f, false, timePeriod, alphaFunction))
                        {
                            var testingTarget = new FadeItem(item);
                            Assert.IsNotNull(testingTarget, "Should be not null!");
                            Assert.IsInstanceOf<FadeItem>(testingTarget, "Should be an Instance of FadeItem!");

                            testingTarget.Dispose();
                            // disposed
                            testingTarget.Dispose();
                        }  
                    }
                }
            }

            tlog.Debug(tag, $"FadeItemConstructorWithFadeItem END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("FadeItem Assign.")]
        [Property("SPEC", "Tizen.NUI.FadeItem.Assign M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void FadeItemAssign()
        {
            tlog.Debug(tag, $"FadeItemAssign START");

            using (View view = new View())
            {
                using (TimePeriod timePeriod = new TimePeriod(300))
                {
                    using (AlphaFunction alphaFunction = new AlphaFunction(AlphaFunction.BuiltinFunctions.Default))
                    {
                        using (FadeItem item = new FadeItem(view, 0.3f, false, timePeriod, alphaFunction))
                        {
                            var testingTarget = item.Assign(item);
                            Assert.IsNotNull(testingTarget, "Should be not null!");
                            Assert.IsInstanceOf<FadeItem>(testingTarget, "Should be an Instance of FadeItem!");

                            testingTarget.Dispose();
                        }
                    }
                }
            }

            tlog.Debug(tag, $"FadeItemAssign END (OK)");
        }
    }
}
