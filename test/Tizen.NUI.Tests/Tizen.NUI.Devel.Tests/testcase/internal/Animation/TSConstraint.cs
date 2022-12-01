using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("internal/Animation/Constraint")]
    public class InternalAnimationConstraintTest
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
        [Description("Constraint constructor")]
        [Property("SPEC", "Tizen.NUI.Constraint.Constraint C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ConstraintConstructor()
        {
            tlog.Debug(tag, $"ConstraintConstructor START");

            using (Animatable ani = new Animatable())
            {
                var testingTarget = new Constraint((global::System.IntPtr)ani.SwigCPtr, false);
                Assert.IsNotNull(testingTarget, "should be not null");
                Assert.IsInstanceOf<Constraint>(testingTarget, "should be an instance of testing target class!");

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"ConstraintConstructor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Constraint Apply")]
        [Property("SPEC", "Tizen.NUI.Constraint.Apply M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ConstraintApply()
        {
            tlog.Debug(tag, $"ConstraintApply START");

            using (Animatable ani = new Animatable())
            {
                var testingTarget = new Constraint((global::System.IntPtr)ani.SwigCPtr, false);
                Assert.IsNotNull(testingTarget, "should be not null");
                Assert.IsInstanceOf<Constraint>(testingTarget, "should be an instance of testing target class!");

                try
                {
                    testingTarget.Apply();
                }
                catch (Exception e)
                {
                    Assert.Fail("Caught Exception" + e.ToString());
                }

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"ConstraintApply END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Constraint Remove")]
        [Property("SPEC", "Tizen.NUI.Constraint.Remove M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ConstraintRemove()
        {
            tlog.Debug(tag, $"ConstraintRemove START");

            using (Animatable ani = new Animatable())
            {
                var testingTarget = new Constraint((global::System.IntPtr)ani.SwigCPtr, false);
                Assert.IsNotNull(testingTarget, "should be not null");
                Assert.IsInstanceOf<Constraint>(testingTarget, "should be an instance of testing target class!");

                try
                {
                    testingTarget.Remove();
                }
                catch (Exception e)
                {
                    Assert.Fail("Caught Exception" + e.ToString());
                }

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"ConstraintRemove END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Constraint RemoveAction")]
        [Property("SPEC", "Tizen.NUI.Constraint.Remove A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ConstraintRemoveAction()
        {
            tlog.Debug(tag, $"ConstraintRemoveAction START");

            using (Animatable ani = new Animatable())
            {
                var testingTarget = new Constraint((global::System.IntPtr)ani.SwigCPtr, false);
                Assert.IsNotNull(testingTarget, "should be not null");
                Assert.IsInstanceOf<Constraint>(testingTarget, "should be an instance of testing target class!");

                tlog.Info(tag, "Default RemoveAction: " + testingTarget.RemoveAction);
                                                                                    
                testingTarget.RemoveAction = Tizen.NUI.Constraint.RemoveActionType.Discard;     // // set(private?)
                tlog.Info(tag, "RemoveAction : " + testingTarget.RemoveAction);

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"ConstraintRemoveAction END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Constraint GetTargetObject")]
        [Property("SPEC", "Tizen.NUI.Constraint.GetTargetObject M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ConstraintGetTargetObject()
        {
            tlog.Debug(tag, $"ConstraintGetTargetObject START");

            using (Animatable ani = new Animatable())
            {
                var testingTarget = new Constraint((global::System.IntPtr)ani.SwigCPtr, false);
                Assert.IsNotNull(testingTarget, "should be not null");
                Assert.IsInstanceOf<Constraint>(testingTarget, "should be an instance of testing target class!");

                try
                {
                    var result = testingTarget.GetTargetObject();
                    Assert.IsNotNull(result, "should be not null");
                    Assert.IsInstanceOf<BaseHandle>(result, "should be an instance of BaseHandle class!");
                }
                catch (Exception e)
                {
                    Assert.Fail("Caught Exception" + e.ToString());
                }

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"ConstraintGetTargetObject END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Constraint GetTargetPropert")]
        [Property("SPEC", "Tizen.NUI.Constraint.GetTargetPropert M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ConstraintGetTargetPropert()
        {
            tlog.Debug(tag, $"ConstraintGetTargetPropert START");

            using (Animatable ani = new Animatable())
            {
                var testingTarget = new Constraint((global::System.IntPtr)ani.SwigCPtr, false);
                Assert.IsNotNull(testingTarget, "should be not null");
                Assert.IsInstanceOf<Constraint>(testingTarget, "should be an instance of testing target class!");

                var result = testingTarget.GetTargetPropert();
                tlog.Debug(tag, "GetTargetPropert : " + result);

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"ConstraintGetTargetPropert END (OK)");
        }
    }
}