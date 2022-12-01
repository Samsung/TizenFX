using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("public/Common/Matrix3")]
    public class PublicMatrix3Test
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
        [Description("Matrix3 constructor")]
        [Property("SPEC", "Tizen.NUI.Matrix3.Matrix3 C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void Matrix3Constructor()
        {
            tlog.Debug(tag, $"Matrix3Constructor START");

            Matrix matrix = new Matrix();
            using (Vector3 vec = new Vector3(1.0f, 2.0f, 3.0f))
            {
                matrix.SetXAxis(vec);
                matrix.SetYAxis(vec);
                matrix.SetZAxis(vec);
            }

            var testingTarget = new Matrix3(matrix);
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<Matrix3>(testingTarget, "Should be an Instance of Matrix3!");

            try
            {
                testingTarget.Invert();
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message);
                Assert.Fail("Caught Exception : Failed!");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"Matrix3Constructor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Matrix3 constructor, with Matrix3")]
        [Property("SPEC", "Tizen.NUI.Matrix3.Matrix3 C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void Matrix3ConstructorWithMatrix3()
        {
            tlog.Debug(tag, $"Matrix3ConstructorWithMatrix3 START");

            Matrix matrix = new Matrix();
            using (Vector3 vec = new Vector3(1.0f, 2.0f, 3.0f))
            {
                matrix.SetXAxis(vec);
                matrix.SetYAxis(vec);
                matrix.SetZAxis(vec);
            }

            Matrix3 m3 = new Matrix3(matrix);
            var testingTarget = new Matrix3(m3);
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<Matrix3>(testingTarget, "Should be an Instance of Matrix3!");

            try
            {
                testingTarget.Transpose();
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message);
                Assert.Fail("Caught Exception : Failed!");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"Matrix3ConstructorWithMatrix3 END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Matrix3 constructor, with float")]
        [Property("SPEC", "Tizen.NUI.Matrix3.Matrix3 C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void Matrix3ConstructorWithFloat()
        {
            tlog.Debug(tag, $"Matrix3ConstructorWithFloat START");

            var testingTarget = new Matrix3(1.0f, 2.0f, 3.0f, 2.0f, 3.0f, 4.0f, 3.0f, 4.0f, 5.0f);
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<Matrix3>(testingTarget, "Should be an Instance of Matrix3!");

            try
            {
                testingTarget.Scale(0.8f);
                var result = testingTarget.Magnitude();
                tlog.Debug(tag, "Magnitude result : " + result);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message);
                Assert.Fail("Caught Exception : Failed!");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"Matrix3ConstructorWithFloat END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Matrix3 IDENTITY.")]
        [Property("SPEC", "Tizen.NUI.Matrix3.IDENTITY A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void Matrix3IDENTITY()
        {
            tlog.Debug(tag, $"Matrix3IDENTITY START");

            var testingTarget = Matrix3.IDENTITY;
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<Matrix3>(testingTarget, "Should be an Instance of Matrix3!");

            tlog.Debug(tag, $"Matrix3IDENTITY END (OK)");
        }
    }
}
