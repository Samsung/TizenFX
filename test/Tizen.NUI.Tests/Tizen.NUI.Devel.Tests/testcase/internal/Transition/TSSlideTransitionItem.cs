﻿using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;
using System.Collections.Generic;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("public/Transition/SlideTransitionItem")]
    public class InternalSlideTransitionItemTest
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
        [Description("SlideTransitionItem constructor.")]
        [Property("SPEC", "Tizen.NUI.SlideTransitionItem.SlideTransitionItem C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        [Obsolete]
        public void SlideTransitionItemConstructor()
        {
            tlog.Debug(tag, $"SlideTransitionItemConstructor START");

            using (View view = new View() { Size = new Size(100, 200) })
            {
                using (Vector2 direction = new Vector2(50, 80))
                {
                    using (TimePeriod timePeriod = new TimePeriod(300))
                    {
                        using (AlphaFunction alphaFunction = new AlphaFunction(AlphaFunction.BuiltinFunctions.Default))
                        {
                            var testingTarget = new SlideTransitionItem(view, direction, true, timePeriod, alphaFunction);
                            Assert.IsNotNull(testingTarget, "Can't create success object SlideTransitionItem.");
                            Assert.IsInstanceOf<SlideTransitionItem>(testingTarget, "Should return SlideTransitionItem instance.");

                            testingTarget.Dispose();
                        }
                    }
                }
            }

            tlog.Debug(tag, $"SlideTransitionItemConstructor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("SlideTransitionItem Assign.")]
        [Property("SPEC", "Tizen.NUI.SlideTransitionItem.Assign M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void SlideTransitionItemAssign()
        {
            tlog.Debug(tag, $"SlideTransitionItemAssign START");

            using (View view = new View())
            {
                var testingTarget = new SlideTransitionItem(view.SwigCPtr.Handle, false);
                Assert.IsNotNull(testingTarget, "Should be not null!");
                Assert.IsInstanceOf<SlideTransitionItem>(testingTarget, "Should be an Instance of SlideTransitionItem!");

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

            tlog.Debug(tag, $"SlideTransitionItemAssign END (OK)");
        }
    }
}
