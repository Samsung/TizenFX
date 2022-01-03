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
    [Description("public/Transition/TransitionGroupItem ")]
    public class InternalTransitionGroupItemTest
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
        [Description("TransitionGroupItem constructor.")]
        [Property("SPEC", "Tizen.NUI.TransitionGroupItem.TransitionGroupItem C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        [Obsolete]
        public void TransitionGroupItemConstructor()
        {
            tlog.Debug(tag, $"TransitionGroupItemConstructor START");

            using (View view = new View() { Size = new Size(100, 200) })
            {
                using (TimePeriod timePeriod = new TimePeriod(300))
                {
                    using (AlphaFunction alphaFunction = new AlphaFunction(AlphaFunction.BuiltinFunctions.Default))
                    {
                        List<TransitionBase> list = new List<TransitionBase>();

                        using (TransitionBase tb = new TransitionBase())
                        {
                            tb.TimePeriod = new TimePeriod(300);
                            tb.AlphaFunction = new AlphaFunction(AlphaFunction.BuiltinFunctions.Bounce);

                            list.Add(tb);

                            var testingTarget = new TransitionGroupItem(view, list, true, true, true, true, timePeriod, alphaFunction);
                            Assert.IsNotNull(testingTarget, "Can't create success object TransitionGroupItem.");
                            Assert.IsInstanceOf<TransitionGroupItem>(testingTarget, "Should return TransitionGroupItem instance.");

                            tlog.Debug(tag, "TransitionCount : " + testingTarget.TransitionCount);

                            var result = testingTarget.GetTransitionAt(0);
                            tlog.Debug(tag, "GetTransitionAt : " + result);

                            testingTarget.Dispose();
                        }

                        list = null;
                    }
                }
            }

            tlog.Debug(tag, $"TransitionGroupItemConstructor END (OK)");
        }
    }
}
