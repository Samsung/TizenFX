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
    [Description("public/Layouting/LayoutTransition")]
    public class TSLayoutTransition
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
        [Description("TransitionComponents SetDuration.")]
        [Property("SPEC", "Tizen.NUI.TransitionComponents.SetDuration M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TransitionComponentsSetDuration()
        {
            tlog.Debug(tag, $"TransitionComponentsSetDuration START");

            var testingTarget = new TransitionComponents();
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<TransitionComponents>(testingTarget, "Should return TransitionComponents instance.");

            testingTarget.SetDuration(300);
            Assert.AreEqual(300, testingTarget.GetDuration(), "should be equal!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"TransitionComponentsSetDuration END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TransitionComponents GetDuration.")]
        [Property("SPEC", "Tizen.NUI.TransitionComponents.GetDuration M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TransitionComponentsGetDuration()
        {
            tlog.Debug(tag, $"TransitionComponentsGetDuration START");

            var testingTarget = new TransitionComponents();
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<TransitionComponents>(testingTarget, "Should return TransitionComponents instance.");

            Assert.AreEqual(100, testingTarget.GetDuration(), "should be equal!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"TransitionComponentsGetDuration END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TransitionComponents SetDelay.")]
        [Property("SPEC", "Tizen.NUI.TransitionComponents.SetDelay M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TransitionComponentsSetDelay()
        {
            tlog.Debug(tag, $"TransitionComponentsSetDelay START");

            var testingTarget = new TransitionComponents();
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<TransitionComponents>(testingTarget, "Should return TransitionComponents instance.");

            testingTarget.SetDelay(300);
            Assert.AreEqual(300, testingTarget.GetDelay(), "should be equal!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"TransitionComponentsSetDelay END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TransitionComponents GetDelay.")]
        [Property("SPEC", "Tizen.NUI.TransitionComponents.GetDelay M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TransitionComponentsGetDelay()
        {
            tlog.Debug(tag, $"TransitionComponentsGetDelay START");

            var testingTarget = new TransitionComponents();
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<TransitionComponents>(testingTarget, "Should return TransitionComponents instance.");

            Assert.AreEqual(0, testingTarget.GetDelay(), "should be equal!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"TransitionComponentsGetDelay END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TransitionComponents SetAlphaFunction.")]
        [Property("SPEC", "Tizen.NUI.TransitionComponents.SetAlphaFunction M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TransitionComponentsSetAlphaFunction()
        {
            tlog.Debug(tag, $"TransitionComponentsSetAlphaFunction START");

            var testingTarget = new TransitionComponents();
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<TransitionComponents>(testingTarget, "Should return TransitionComponents instance.");

            testingTarget.SetAlphaFunction(new AlphaFunction(AlphaFunction.BuiltinFunctions.EaseIn));
            var result = testingTarget.GetAlphaFunction().GetBuiltinFunction();
            Assert.AreEqual(AlphaFunction.BuiltinFunctions.EaseIn, result, "should be equal!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"TransitionComponentsSetAlphaFunction END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TransitionComponents GetAlphaFunction.")]
        [Property("SPEC", "Tizen.NUI.TransitionComponents.GetAlphaFunction M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TransitionComponentsGetAlphaFunction()
        {
            tlog.Debug(tag, $"TransitionComponentsGetAlphaFunction START");

            var testingTarget = new TransitionComponents();
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<TransitionComponents>(testingTarget, "Should return TransitionComponents instance.");

            var result = testingTarget.GetAlphaFunction().GetBuiltinFunction();
            Assert.AreEqual(AlphaFunction.BuiltinFunctions.Linear, result, "should be equal!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"TransitionComponentsGetAlphaFunction END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("LayoutTransition constructor")]
        [Property("SPEC", "Tizen.NUI.LayoutTransition.LayoutTransition C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void LayoutTransitionConstructor()
        {
            tlog.Debug(tag, $"LayoutTransitionConstructor START");

            var testingTarget = new LayoutTransition();
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<LayoutTransition>(testingTarget, "Should return LayoutTransition instance.");

            tlog.Debug(tag, $"LayoutTransitionConstructor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("LayoutTransition constructor. With parameters")]
        [Property("SPEC", "Tizen.NUI.LayoutTransition.LayoutTransition C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("COVPARAM", "TransitionCondition, AnimatableProperties, object, TransitionComponents")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void LayoutTransitionContructorWithParameters()
        {
            tlog.Debug(tag, $"LayoutTransitionContructorWithParameters START");

            TransitionComponents transitionComponents = new TransitionComponents();

            var testingTarget = new LayoutTransition(TransitionCondition.Unspecified,
                                                        AnimatableProperties.Position,
                                                        0.0f,
                                                        transitionComponents
                                                        );

            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<LayoutTransition>(testingTarget, "Should return LayoutTransition instance.");

            transitionComponents.Dispose();
            tlog.Debug(tag, $"LayoutTransitionContructorWithParameters END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("LayoutTransition Condition")]
        [Property("SPEC", "Tizen.NUI.LayoutTransition.Condition A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void LayoutTransitionCondition()
        {
            tlog.Debug(tag, $"LayoutTransitionCondition START");

            var testingTarget = new LayoutTransition();
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<LayoutTransition>(testingTarget, "Should return LayoutTransition instance.");

            Assert.AreEqual(testingTarget.Condition, TransitionCondition.Unspecified, "Should be value set.");

            testingTarget.Condition = TransitionCondition.LayoutChanged;
            Assert.AreEqual(testingTarget.Condition, TransitionCondition.LayoutChanged, "Should be value set.");

            testingTarget.Condition = TransitionCondition.Add;
            Assert.AreEqual(testingTarget.Condition, TransitionCondition.Add, "Should be value set.");

            testingTarget.Condition = TransitionCondition.Remove;
            Assert.AreEqual(testingTarget.Condition, TransitionCondition.Remove, "Should be value set.");

            testingTarget.Condition = TransitionCondition.ChangeOnAdd;
            Assert.AreEqual(testingTarget.Condition, TransitionCondition.ChangeOnAdd, "Should be value set.");

            testingTarget.Condition = TransitionCondition.ChangeOnRemove;
            Assert.AreEqual(testingTarget.Condition, TransitionCondition.ChangeOnRemove, "Should be value set.");

            tlog.Debug(tag, $"LayoutTransitionCondition END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("LayoutTransition AnimatableProperty")]
        [Property("SPEC", "Tizen.NUI.LayoutTransition.AnimatableProperty A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang")]
        public void LayoutTransitionAnimatableProperty()
        {
            tlog.Debug(tag, $"LayoutTransitionAnimatableProperty START");

            var testingTarget = new LayoutTransition();
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<LayoutTransition>(testingTarget, "Should return LayoutTransition instance.");

            testingTarget.AnimatableProperty = AnimatableProperties.Position;
            Assert.AreEqual(testingTarget.AnimatableProperty, AnimatableProperties.Position, "Should be value set.");

            testingTarget.AnimatableProperty = AnimatableProperties.Size;
            Assert.AreEqual(testingTarget.AnimatableProperty, AnimatableProperties.Size, "Should be value set.");

            testingTarget.AnimatableProperty = AnimatableProperties.Opacity;
            Assert.AreEqual(testingTarget.AnimatableProperty, AnimatableProperties.Opacity, "Should be value set.");

            tlog.Debug(tag, $"LayoutTransitionAnimatableProperty END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("LayoutTransition Animator")]
        [Property("SPEC", "Tizen.NUI.LayoutTransition.Animator A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void LayoutTransitionAnimator()
        {
            tlog.Debug(tag, $"LayoutTransitionAnimator START");

            AlphaFunction alphaFunction = new AlphaFunction(AlphaFunction.BuiltinFunctions.Linear);
            TransitionComponents transitionComponents = new TransitionComponents(0, 64, alphaFunction);

            var testingTarget = new LayoutTransition();
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<LayoutTransition>(testingTarget, "Should return LayoutTransition instance.");

            testingTarget.Animator = transitionComponents;
            Assert.AreEqual(testingTarget.Animator.GetDuration(), transitionComponents.GetDuration(), "Should be value set.");
            Assert.AreEqual(testingTarget.Animator.GetDelay(), transitionComponents.GetDelay(), "Should be value set.");

            tlog.Debug(tag, $"LayoutTransitionAnimator END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("LayoutTransition TargetValue")]
        [Property("SPEC", "Tizen.NUI.LayoutTransition.TargetValue A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void LayoutTransitionTargetValue()
        {
            tlog.Debug(tag, $"LayoutTransitionTargetValue START");

            var testingTarget = new LayoutTransition();
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<LayoutTransition>(testingTarget, "Should return LayoutTransition instance.");

            testingTarget.TargetValue = 1.0f;
            Assert.AreEqual(testingTarget.TargetValue, 1.0f, "Should be value set.");

            tlog.Debug(tag, $"LayoutTransitionTargetValue END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("LayoutTransitionsHelper AddTransitionForCondition")]
        [Property("SPEC", "Tizen.NUI.LayoutTransitionsHelper.AddTransitionForCondition A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void LayoutTransitionsHelperAddTransitionForCondition()
        {
            tlog.Debug(tag, $"LayoutTransitionsHelperAddTransitionForCondition START");

            Dictionary<TransitionCondition, TransitionList> targetTransitionList = new Dictionary<TransitionCondition, TransitionList>();

            TransitionList transitionList = new TransitionList();

            var addTransition = new LayoutTransition(TransitionCondition.Add,
                                                     AnimatableProperties.Position,
                                                     0.3f,
                                                     new TransitionComponents()
                                                    );
            transitionList.Add(addTransition);

            var layoutChangedTransition = new LayoutTransition(TransitionCondition.LayoutChanged,
                                                     AnimatableProperties.Opacity,
                                                     0.2f,
                                                     new TransitionComponents()
                                                    );
            transitionList.Add(layoutChangedTransition);


            targetTransitionList.Add(TransitionCondition.Add, transitionList);
            targetTransitionList.Add(TransitionCondition.LayoutChanged, transitionList);

            /** 
             * conditionNotInDictionary = false
             */
            LayoutTransitionsHelper.AddTransitionForCondition(targetTransitionList,
                TransitionCondition.LayoutChanged,
                addTransition,
                true);

            /** 
             * conditionNotInDictionary = true
             * replaced
             */
            LayoutTransitionsHelper.AddTransitionForCondition(targetTransitionList,
                TransitionCondition.Add,
                addTransition,
                false);

            /** 
             * conditionNotInDictionary = true
             * new entry
             */
            LayoutTransitionsHelper.AddTransitionForCondition(targetTransitionList,
                TransitionCondition.ChangeOnAdd,
                addTransition,
                false);

            tlog.Debug(tag, $"LayoutTransitionsHelperAddTransitionForCondition END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("LayoutTransitionsHelper GetTransitionsListForCondition")]
        [Property("SPEC", "Tizen.NUI.LayoutTransitionsHelper.GetTransitionsListForCondition A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void LayoutTransitionsHelperGetTransitionsListForCondition()
        {
            tlog.Debug(tag, $"LayoutTransitionsHelperGetTransitionsListForCondition START");

            TransitionList transitionList = new TransitionList();

            LayoutTransition addTransition = new LayoutTransition(TransitionCondition.Add,
                                                     AnimatableProperties.Position,
                                                     0.3f,
                                                     new TransitionComponents()
                                                    );

            LayoutTransition removeTransition = new LayoutTransition(TransitionCondition.Remove,
                                                             AnimatableProperties.Position,
                                                             0.0f,
                                                             new TransitionComponents()
                                                            );

            Dictionary<TransitionCondition, TransitionList> targetTransitionList = new Dictionary<TransitionCondition, TransitionList>();

            targetTransitionList.Add(TransitionCondition.Unspecified, transitionList);
            targetTransitionList.Add(TransitionCondition.LayoutChanged, transitionList);

            TransitionList transitionsForCondition = new TransitionList();

            var result = LayoutTransitionsHelper.GetTransitionsListForCondition(targetTransitionList,
                                                                   TransitionCondition.LayoutChanged,
                                                                   transitionsForCondition);
            Assert.AreEqual(true, result, "should be equal!");

            result = LayoutTransitionsHelper.GetTransitionsListForCondition(targetTransitionList,
                                                                   TransitionCondition.Add,
                                                                   transitionsForCondition);
            Assert.AreEqual(false, result, "should be equal!");

            tlog.Debug(tag, $"LayoutTransitionsHelperGetTransitionsListForCondition END (OK)");
        }
    }
}
