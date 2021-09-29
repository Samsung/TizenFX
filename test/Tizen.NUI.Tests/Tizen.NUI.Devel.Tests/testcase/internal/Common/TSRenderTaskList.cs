using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("internal/Common/RenderTaskList")]
    public class InternalRenderTaskListTest
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
        [Description("RenderTaskList constructor.")]
        [Property("SPEC", "Tizen.NUI.RenderTaskList.RenderTaskList C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void RenderTaskListConstructor()
        {
            tlog.Debug(tag, $"RenderTaskListConstructor START");

            var testingTarget = new RenderTaskList();
            Assert.IsInstanceOf<RenderTaskList>(testingTarget, "Should return RenderTaskList instance.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"RenderTaskListConstructor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("RenderTaskList DownCast.")]
        [Property("SPEC", "Tizen.NUI.RenderTaskList.DownCast M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void RenderTaskListDownCast()
        {
            tlog.Debug(tag, $"RenderTaskListDownCast START");

            using (RenderTask task = new RenderTask())
            {
                try
                {
                    RenderTaskList.DownCast(task);
                }
                catch (Exception e)
                {
                    tlog.Debug(tag, e.Message.ToString());
                    Assert.Fail("Caught Exception : Failed!");
                }
            }

            tlog.Debug(tag, $"RenderTaskListDownCast END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("RenderTaskList Assign.")]
        [Property("SPEC", "Tizen.NUI.RenderTaskList.Assign M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void RenderTaskListAssign()
        {
            tlog.Debug(tag, $"RenderTaskListAssign START");

            using (Animatable ani = new Animatable())
            {
                using (RenderTaskList task = new RenderTaskList(ani.SwigCPtr.Handle, false))
                {
                    var testingTarget = task.Assign(task);
                    Assert.IsNotNull(testingTarget, "Can't create success object RenderTaskList.");
                    Assert.IsInstanceOf<RenderTaskList>(testingTarget, "Should return RenderTaskList instance.");

                    tlog.Debug(tag, "GetTaskCount :" + testingTarget.GetTaskCount());

                    testingTarget.Dispose();
                }
            }

            tlog.Debug(tag, $"RenderTaskListAssign END (OK)");
        }
    }
}
