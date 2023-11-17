using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("internal/Common/Any")]
    public class InternalAnyTest
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
        [Description("Any constructor.")]
        [Property("SPEC", "Tizen.NUI.Any.Any C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void AnyConstructor()
        {
            tlog.Debug(tag, $"AnyConstructor START");

            var testingTarget = new Any();
            Assert.IsNotNull(testingTarget, "Can't create success object Any");
            Assert.IsInstanceOf<Any>(testingTarget, "Should be an instance of Any type.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"AnyConstructor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Any constructor. With Any.")]
        [Property("SPEC", "Tizen.NUI.Any.Any C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void AnyConstructorWithAny()
        {
            tlog.Debug(tag, $"AnyConstructorWithAny START");

            using (Any any = new Any())
            {
                var testingTarget = new Any(any);
                Assert.IsNotNull(testingTarget, "Can't create success object Any");
                Assert.IsInstanceOf<Any>(testingTarget, "Should be an instance of Any type.");

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"AnyConstructorWithAny END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Any Assign.")]
        [Property("SPEC", "Tizen.NUI.Any.Assign M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void AnyAssign()
        {
            tlog.Debug(tag, $"AnyAssign START");

            using (Any any = new Any())
            {
                var testingTarget = new Any(any);
                Assert.IsNotNull(testingTarget, "Can't create success object Any");
                Assert.IsInstanceOf<Any>(testingTarget, "Should be an instance of Any type.");

                try
                {
                    any.Assign(testingTarget);
                }
                catch (Exception e)
                {
                    tlog.Debug(tag, e.Message.ToString());
                    Assert.Fail("Caught Exception: Failed!");
                }

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"AnyAssign END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Any GetType.")]
        [Property("SPEC", "Tizen.NUI.Any.GetType M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void AnyGetType()
        {
            tlog.Debug(tag, $"AnyGetType START");

            using (Any any = new Any())
            {
                var testingTarget = new Any(any);
                Assert.IsNotNull(testingTarget, "Can't create success object Any");
                Assert.IsInstanceOf<Any>(testingTarget, "Should be an instance of Any type.");

                try
                {
#pragma warning disable Reflection // The code contains reflection
                    testingTarget.GetType();
#pragma warning restore Reflection // The code contains reflection
                }
                catch (Exception e)
                {
                    tlog.Debug(tag, e.Message.ToString());
                    Assert.Fail("Caught Exception: Failed!");
                }

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"AnyGetType END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Any Empty.")]
        [Property("SPEC", "Tizen.NUI.Any.Empty M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void AnyEmpty()
        {
            tlog.Debug(tag, $"AnyEmpty START");

            using (Any any = new Any())
            {
                var testingTarget = new Any(any);
                Assert.IsNotNull(testingTarget, "Can't create success object Any");
                Assert.IsInstanceOf<Any>(testingTarget, "Should be an instance of Any type.");

                try
                {
                    var result = testingTarget.Empty();
                    tlog.Debug(tag, "result :" + result);
                }
                catch (Exception e)
                {
                    tlog.Debug(tag, e.Message.ToString());
                    Assert.Fail("Caught Exception: Failed!");
                }

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"AnyEmpty END (OK)");
        }
    }
}
