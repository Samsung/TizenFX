using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("internal/Common/LinearConstrainer")]
    public class InternalLinearConstrainerTest
    {
        private const string tag = "NUITEST";
        private string path = Tizen.Applications.Application.Current.DirectoryInfo.Resource + "lottie.json";

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
        [Description("LinearConstrainer constructor")]
        [Property("SPEC", "Tizen.NUI.LinearConstrainer.LinearConstrainer C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void LinearConstrainerConstructor()
        {
            tlog.Debug(tag, $"LinearConstrainerConstructor START");

            var testingTarget = new LinearConstrainer();
            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<LinearConstrainer>(testingTarget, "should be an instance of testing target class!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"LinearConstrainerConstructor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("LinearConstrainer constructor")]
        [Property("SPEC", "Tizen.NUI.LinearConstrainer.LinearConstrainer C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void LinearConstrainerConstructorWithLinearConstrainer()
        {
            tlog.Debug(tag, $"LinearConstrainerConstructorWithLinearConstrainer START");

            using (LinearConstrainer constrainer = new LinearConstrainer())
            {
                var testingTarget = new LinearConstrainer(constrainer);
                Assert.IsInstanceOf<LinearConstrainer>(testingTarget, "should be an instance of testing target class!");

                testingTarget?.Dispose();
            }

            tlog.Debug(tag, $"LinearConstrainerConstructorWithLinearConstrainer END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("LinearConstrainer Property")]
        [Property("SPEC", "Tizen.NUI.LinearConstrainer.Property A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void LinearConstrainerProperty()
        {
            tlog.Debug(tag, $"LinearConstrainerProperty START");

            var result = LinearConstrainer.Property.VALUE;
            tlog.Debug(tag, "VALUE : " + result);

            result = LinearConstrainer.Property.PROGRESS;
            tlog.Debug(tag, "PROGRESS : " + result);

            tlog.Debug(tag, $"LinearConstrainerProperty END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("LinearConstrainer DownCast")]
        [Property("SPEC", "Tizen.NUI.LinearConstrainer.DownCast M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void LinearConstrainerDownCast()
        {
            tlog.Debug(tag, $"LinearConstrainerDownCast START");

            using (Builder builder = new Builder())
            {
                builder.LoadFromFile(path);
                var testingTarget = builder.GetLinearConstrainer("Camera_003_render");
                Assert.IsNotNull(testingTarget, "should be not null");
                Assert.IsInstanceOf<LinearConstrainer>(testingTarget, "should be an instance of testing target class!");

                try
                {
                    LinearConstrainer.DownCast(testingTarget);
                }
                catch (Exception e)
                {
                    tlog.Debug(tag, e.Message.ToString());
                    Assert.Fail("Caught Exception : Failed!");
                }

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"LinearConstrainerDownCast END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("LinearConstrainer Assign")]
        [Property("SPEC", "Tizen.NUI.LinearConstrainer.Assign M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void LinearConstrainerAssign()
        {
            tlog.Debug(tag, $"LinearConstrainerAssign START");

            using (Builder builder = new Builder())
            {
                builder.LoadFromFile(path);
                var testingTarget = builder.GetLinearConstrainer("Camera_003_render");
                Assert.IsNotNull(testingTarget, "should be not null");
                Assert.IsInstanceOf<LinearConstrainer>(testingTarget, "should be an instance of testing target class!");

                try
                {
                    using (LinearConstrainer constrainer = new LinearConstrainer())
                    {
                        testingTarget.Assign(constrainer);
                    }
                }
                catch (Exception e)
                {
                    tlog.Debug(tag, e.Message.ToString());
                    Assert.Fail("Caught Exception : Failed!");
                }

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"LinearConstrainerAssign END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("LinearConstrainer Remove")]
        [Property("SPEC", "Tizen.NUI.LinearConstrainer.Remove M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void LinearConstrainerRemove()
        {
            tlog.Debug(tag, $"LinearConstrainerRemove START");

            var testingTarget = new LinearConstrainer();
            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<LinearConstrainer>(testingTarget, "should be an instance of testing target class!");

            try
            {
                using (Animatable ani = new Animatable())
                {
                    testingTarget.Remove(ani);
                }
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"LinearConstrainerRemove END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("LinearConstrainer Value")]
        [Property("SPEC", "Tizen.NUI.LinearConstrainer.Value A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void LinearConstrainerValue()
        {
            tlog.Debug(tag, $"LinearConstrainerValue START");

            var testingTarget = new LinearConstrainer();
            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<LinearConstrainer>(testingTarget, "should be an instance of testing target class!");

            try
            {
                using (PropertyArray arr = new PropertyArray())
                {
                    arr.PushBack(new PropertyValue(new Vector3(0.0f, 0.0f, 0.0f)));

                    testingTarget.Value = arr;
                    tlog.Debug(tag, "Value : " + testingTarget.Value);
                }
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"LinearConstrainerValue END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("LinearConstrainer Progress")]
        [Property("SPEC", "Tizen.NUI.LinearConstrainer.Progress A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void LinearConstrainerProgress()
        {
            tlog.Debug(tag, $"LinearConstrainerProgress START");

            var testingTarget = new LinearConstrainer();
            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<LinearConstrainer>(testingTarget, "should be an instance of testing target class!");

            try
            {
                using (PropertyArray arr = new PropertyArray())
                {
                    arr.PushBack(new PropertyValue(0.3f));

                    testingTarget.Progress = arr;
                    tlog.Debug(tag, "Progress : " + testingTarget.Progress);
                }
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"LinearConstrainerProgress END (OK)");
        }
    }
}
