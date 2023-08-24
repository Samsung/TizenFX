using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("internal/Common/CustomActor")]
    public class InternalCustomActorTest
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
        [Description("CustomActor constructor.")]
        [Property("SPEC", "Tizen.NUI.CustomActor.CustomActor C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void CustomActorConstructor()
        {
            tlog.Debug(tag, $"CustomActorConstructor START");

            var testingTarget = new CustomActor();
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<CustomActor>(testingTarget, "Should be an Instance of CustomActor!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"CustomActorConstructor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("CustomActor constructor. With CustomActorImpl.")]
        [Property("SPEC", "Tizen.NUI.CustomActor.CustomActor C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void CustomActorConstructorWithCustomActorImpl()
        {
            tlog.Debug(tag, $"CustomActorConstructorWithCustomActorImpl START");

            using (View view = new View())
            {
                using (CustomActor actor = new CustomActor(view.SwigCPtr.Handle, false))
                {
                    var testingTarget = new CustomActor(actor.GetImplementation());
                    Assert.IsNotNull(testingTarget, "Should be not null!");
                    Assert.IsInstanceOf<CustomActor>(testingTarget, "Should be an Instance of CustomActor!");

                    testingTarget.Dispose();
                }
            }

            tlog.Debug(tag, $"CustomActorConstructorWithCustomActorImpl END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("CustomActor constructor. With CustomActor.")]
        [Property("SPEC", "Tizen.NUI.CustomActor.CustomActor C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void CustomActorConstructorWithCustomActor()
        {
            tlog.Debug(tag, $"CustomActorConstructorWithCustomActor START");

            using (View view = new View())
            {
                using (CustomActor actor = new CustomActor(view.SwigCPtr.Handle, false))
                {
                    var testingTarget = new CustomActor(actor);
                    Assert.IsNotNull(testingTarget, "Should be not null!");
                    Assert.IsInstanceOf<CustomActor>(testingTarget, "Should be an Instance of CustomActor!");

                    testingTarget.Dispose();
                }
            }

            tlog.Debug(tag, $"CustomActorConstructorWithCustomActor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("CustomActor DownCast.")]
        [Property("SPEC", "Tizen.NUI.CustomActor.DownCast M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void CustomActorDownCast()
        {
            tlog.Debug(tag, $"CustomActorDownCast START");

            var testingTarget = new CustomActor();
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<CustomActor>(testingTarget, "Should be an Instance of CustomActor!");

            try
            {
                CustomActor.DownCast(testingTarget);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"CustomActorDownCast END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("CustomActor GetImplementation.")]
        [Property("SPEC", "Tizen.NUI.CustomActor.GetImplementation M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void CustomActoGetImplementation()
        {
            tlog.Debug(tag, $"CustomActoGetImplementation START");

            using (View view = new View())
            {
                var testingTarget = new CustomActor(view.SwigCPtr.Handle, false);
                Assert.IsNotNull(testingTarget, "Should be not null!");
                Assert.IsInstanceOf<CustomActor>(testingTarget, "Should be an Instance of CustomActor!");

                try
                {
                    testingTarget.GetImplementation();
                }
                catch (Exception e)
                {
                    tlog.Debug(tag, e.Message.ToString());
                    Assert.Fail("Caught Exception : Failed!");
                }

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"CustomActoGetImplementation END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("CustomActor Assign.")]
        [Property("SPEC", "Tizen.NUI.CustomActor.Assign M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void CustomActoAssign()
        {
            tlog.Debug(tag, $"CustomActoAssign START");

            var testingTarget = new CustomActor();
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<CustomActor>(testingTarget, "Should be an Instance of CustomActor!");

            using (View view = new View())
            {
                using (CustomActor actor = new CustomActor(view.SwigCPtr.Handle, false))
                {
                    try
                    {
                        testingTarget.Assign(actor);
                    }
                    catch (Exception e)
                    {
                        tlog.Debug(tag, e.Message.ToString());
                        Assert.Fail("Caught Exception : Failed!");
                    }
                }
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"CustomActoAssign END (OK)");
        }
    }
}
