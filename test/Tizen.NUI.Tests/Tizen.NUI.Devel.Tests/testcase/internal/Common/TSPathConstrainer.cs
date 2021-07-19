using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("internal/Common/PathConstrainer")]
    public class InternalPathConstrainerTest
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
        [Description("PathConstrainer constructor.")]
        [Property("SPEC", "Tizen.NUI.PathConstrainer.PathConstrainer C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PathConstrainerConstructor()
        {
            tlog.Debug(tag, $"PathConstrainerConstructor START");

            var testingTarget = new PathConstrainer();
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<PathConstrainer>(testingTarget, "Should be an Instance of PathConstrainer!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"PathConstrainerConstructor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("PathConstrainer constructor. With PathConstrainer.")]
        [Property("SPEC", "Tizen.NUI.PathConstrainer.PathConstrainer C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PathConstrainerConstructorWithPathConstrainer()
        {
            tlog.Debug(tag, $"PathConstrainerConstructorWithPathConstrainer START");

            using (PathConstrainer constrainer = new PathConstrainer())
            {
                var testingTarget = new PathConstrainer(constrainer);
                Assert.IsNotNull(testingTarget, "Should be not null!");
                Assert.IsInstanceOf<PathConstrainer>(testingTarget, "Should be an Instance of PathConstrainer!");

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"PathConstrainerConstructorWithPathConstrainer END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("PathConstrainer DownCast.")]
        [Property("SPEC", "Tizen.NUI.PathConstrainer.DownCast M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PathConstrainerDownCast()
        {
            tlog.Debug(tag, $"PathConstrainerDownCast START");

            using (PathConstrainer constrainer = new PathConstrainer())
            {
                var testingTarget = PathConstrainer.DownCast(constrainer);
                Assert.IsNotNull(testingTarget, "Should be not null!");
                Assert.IsInstanceOf<PathConstrainer>(testingTarget, "Should be an Instance of PathConstrainer!");

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"PathConstrainerDownCast END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("PathConstrainer Assign.")]
        [Property("SPEC", "Tizen.NUI.PathConstrainer.Assign M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PathConstrainerAssign()
        {
            tlog.Debug(tag, $"PathConstrainerAssign START");

            using (PathConstrainer constrainer = new PathConstrainer())
            {
                var testingTarget = constrainer.Assign(constrainer);
                Assert.IsNotNull(testingTarget, "Should be not null!");
                Assert.IsInstanceOf<PathConstrainer>(testingTarget, "Should be an Instance of PathConstrainer!");

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"PathConstrainerAssign END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("PathConstrainer Forward.")]
        [Property("SPEC", "Tizen.NUI.PathConstrainer.Forward A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PathConstrainerForward()
        {
            tlog.Debug(tag, $"PathConstrainerForward START");

            var testingTarget = new PathConstrainer();
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<PathConstrainer>(testingTarget, "Should be an Instance of PathConstrainer!");

            using (Vector3 vector = new Vector3(0.1f, 0.2f, 0.3f))
            {
                testingTarget.Forward = vector;
                tlog.Debug(tag, "ForwardX : " + testingTarget.Forward.X);
            }
                
            tlog.Debug(tag, $"PathConstrainerForward END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("PathConstrainer Points.")]
        [Property("SPEC", "Tizen.NUI.PathConstrainer.Points A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PathConstrainerPoints()
        {
            tlog.Debug(tag, $"PathConstrainerPoints START");

            var testingTarget = new PathConstrainer();
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<PathConstrainer>(testingTarget, "Should be an Instance of PathConstrainer!");

            using (PropertyArray array = new PropertyArray())
            {
                array.PushBack(new PropertyValue(0.3f));
                testingTarget.Points = array;
                tlog.Debug(tag, "Points : " + testingTarget.Points);
            }

            tlog.Debug(tag, $"PathConstrainerPoints END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("PathConstrainer ControlPoints.")]
        [Property("SPEC", "Tizen.NUI.PathConstrainer.ControlPoints A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PathConstrainerControlPoints()
        {
            tlog.Debug(tag, $"PathConstrainerControlPoints START");

            var testingTarget = new PathConstrainer();
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<PathConstrainer>(testingTarget, "Should be an Instance of PathConstrainer!");

            using (PropertyArray array = new PropertyArray())
            {
                array.PushBack(new PropertyValue(0.3f));
                testingTarget.ControlPoints = array;
                tlog.Debug(tag, "ControlPoints : " + testingTarget.ControlPoints);
            }

            tlog.Debug(tag, $"PathConstrainerControlPoints END (OK)");
        }
    }
}
