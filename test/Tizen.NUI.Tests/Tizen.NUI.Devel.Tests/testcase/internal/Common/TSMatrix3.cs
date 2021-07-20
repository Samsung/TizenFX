using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("internal/Common/Matrix3")]
    public class InternalMatrix3Test
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
        [Description("Matrix3 constructor.")]
        [Property("SPEC", "Tizen.NUI.Matrix3.Matrix3 C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void Matrix3Constructor()
        {
            tlog.Debug(tag, $"Matrix3Constructor START");

            var testingTarget = new Matrix3();
            Assert.IsNotNull(testingTarget, "Can't create success object Matrix3.");
            Assert.IsInstanceOf<Matrix3>(testingTarget, "Should return Matrix3 instance.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"Matrix3Constructor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Matrix3 constructor. With Martrix")]
        [Property("SPEC", "Tizen.NUI.Matrix3.Matrix3 C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void Matrix3ConstructorWithMartrix()
        {
            tlog.Debug(tag, $"Matrix3ConstructorWithMartrix START");

            using (Matrix matrix = new Matrix())
            {
                var testingTarget = new Matrix3(matrix);
                Assert.IsNotNull(testingTarget, "Can't create success object Matrix3.");
                Assert.IsInstanceOf<Matrix3>(testingTarget, "Should return Matrix3 instance.");

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"Matrix3ConstructorWithMartrix END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Matrix3 constructor. With Martrix3")]
        [Property("SPEC", "Tizen.NUI.Matrix3.Matrix3 C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void Matrix3ConstructorWithMartrix3()
        {
            tlog.Debug(tag, $"Matrix3ConstructorWithMartrix3 START");

            using (Matrix3 matrix = new Matrix3(0.0f, 0.1f, 0.2f, 1.0f, 1.1f, 1.2f, 2.0f, 2.1f, 2.2f))
            {
                var testingTarget = new Matrix3(matrix);
                Assert.IsNotNull(testingTarget, "Can't create success object Matrix3.");
                Assert.IsInstanceOf<Matrix3>(testingTarget, "Should return Matrix3 instance.");

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"Matrix3ConstructorWithMartrix3 END (OK)");
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

            try
            {
                var result = Matrix3.IDENTITY;
                tlog.Debug(tag, "IDENTITY : " + result);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            tlog.Debug(tag, $"Matrix3IDENTITY END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Matrix3 Assign.")]
        [Property("SPEC", "Tizen.NUI.Matrix3.Assign M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void Matrix3Assign()
        {
            tlog.Debug(tag, $"Matrix3Assign START");

            using (Matrix3 matrix = new Matrix3(0.0f, 0.1f, 0.2f, 1.0f, 1.1f, 1.2f, 2.0f, 2.1f, 2.2f))
            {
                var testingTarget = matrix.Assign(matrix);
                Assert.IsNotNull(testingTarget, "Can't create success object Matrix3.");
                Assert.IsInstanceOf<Matrix3>(testingTarget, "Should return Matrix3 instance.");

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"Matrix3Assign END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Matrix3 Assign. With Matrix.")]
        [Property("SPEC", "Tizen.NUI.Matrix3.Assign M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void Matrix3AssignWithMatrix()
        {
            tlog.Debug(tag, $"Matrix3AssignWithMatrix START");

            using (Matrix3 matrix3 = new Matrix3(0.0f, 0.1f, 0.2f, 1.0f, 1.1f, 1.2f, 2.0f, 2.1f, 2.2f))
            {
                using (Matrix matrix = new Matrix(true))
                {
                    var testingTarget = matrix3.Assign(matrix);
                    Assert.IsNotNull(testingTarget, "Can't create success object Matrix3.");
                    Assert.IsInstanceOf<Matrix3>(testingTarget, "Should return Matrix3 instance.");

                    testingTarget.Dispose();
                }
            }

            tlog.Debug(tag, $"Matrix3AssignWithMatrix END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Matrix3 EqualTo.")]
        [Property("SPEC", "Tizen.NUI.Matrix3.EqualTo M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void Matrix3EqualTo()
        {
            tlog.Debug(tag, $"Matrix3EqualTo START");

            var testingTarget = new Matrix3();
            Assert.IsNotNull(testingTarget, "Can't create success object Matrix.");
            Assert.IsInstanceOf<Matrix3>(testingTarget, "Should return Matrix instance.");

            using (Matrix3 matrix3 = new Matrix3(0.0f, 0.1f, 0.2f, 1.0f, 1.1f, 1.2f, 2.0f, 2.1f, 2.2f))
            {
                var result = testingTarget.EqualTo(matrix3);
                tlog.Debug(tag, "EqualTo : " + result);
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"MatrixEqualTo END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Matrix3 NotEqualTo.")]
        [Property("SPEC", "Tizen.NUI.Matrix3.NotEqualTo M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void Matrix3NotEqualTo()
        {
            tlog.Debug(tag, $"Matrix3NotEqualTo START");

            var testingTarget = new Matrix3();
            Assert.IsNotNull(testingTarget, "Can't create success object Matrix3.");
            Assert.IsInstanceOf<Matrix3>(testingTarget, "Should return Matrix3 instance.");

            using (Matrix3 matrix3 = new Matrix3(0.0f, 0.1f, 0.2f, 1.0f, 1.1f, 1.2f, 2.0f, 2.1f, 2.2f))
            {
                var result = testingTarget.NotEqualTo(matrix3);
                tlog.Debug(tag, "NotEqualTo : " + result);
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"Matrix3NotEqualTo END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Matrix3 SetIdentity.")]
        [Property("SPEC", "Tizen.NUI.Matrix3.SetIdentity M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void Matrix3SetIdentity()
        {
            tlog.Debug(tag, $"Matrix3SetIdentity START");

            var testingTarget = new Matrix3();
            Assert.IsNotNull(testingTarget, "Can't create success object Matrix3.");
            Assert.IsInstanceOf<Matrix3>(testingTarget, "Should return Matrix3 instance.");

            try
            {
                testingTarget.SetIdentity();
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"Matrix3SetIdentity END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Matrix3 AsFloat.")]
        [Property("SPEC", "Tizen.NUI.Matrix3.AsFloat M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void Matrix3AsFloat()
        {
            tlog.Debug(tag, $"Matrix3AsFloat START");

            var testingTarget = new Matrix3();
            Assert.IsNotNull(testingTarget, "Can't create success object Matrix3.");
            Assert.IsInstanceOf<Matrix3>(testingTarget, "Should return Matrix3 instance.");

            try
            {
                testingTarget.AsFloat();
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"Matrix3AsFloat END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Matrix3 Invert.")]
        [Property("SPEC", "Tizen.NUI.Matrix3.Invert M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void Matrix3Invert()
        {
            tlog.Debug(tag, $"Matrix3Invert START");

            var testingTarget = new Matrix3();
            Assert.IsNotNull(testingTarget, "Can't create success object Matrix3.");
            Assert.IsInstanceOf<Matrix3>(testingTarget, "Should return Matrix3 instance.");

            var result = testingTarget.Invert();
            tlog.Debug(tag, "Invert :" + result);

            testingTarget.Dispose();
            tlog.Debug(tag, $"Matrix3Invert END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Matrix3 Transpose.")]
        [Property("SPEC", "Tizen.NUI.Matrix3.Transpose M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void Matrix3Transpose()
        {
            tlog.Debug(tag, $"Matrix3Transpose START");

            var testingTarget = new Matrix3();
            Assert.IsNotNull(testingTarget, "Can't create success object Matrix3.");
            Assert.IsInstanceOf<Matrix3>(testingTarget, "Should return Matrix3 instance.");

            var result = testingTarget.Transpose();
            tlog.Debug(tag, "Transpose : " + result);

            testingTarget.Dispose();
            tlog.Debug(tag, $"Matrix3Transpose END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Matrix3 Scale.")]
        [Property("SPEC", "Tizen.NUI.Matrix3.Scale M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void Matrix3Scale()
        {
            tlog.Debug(tag, $"Matrix3Scale START");

            var testingTarget = new Matrix3();
            Assert.IsNotNull(testingTarget, "Can't create success object Matrix3.");
            Assert.IsInstanceOf<Matrix3>(testingTarget, "Should return Matrix3 instance.");

            try
            {
                testingTarget.Scale(0.3f);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"Matrix3Scale END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Matrix3 Magnitude.")]
        [Property("SPEC", "Tizen.NUI.Matrix3.Magnitude M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void Matrix3Magnitude()
        {
            tlog.Debug(tag, $"Matrix3Magnitude START");

            var testingTarget = new Matrix3();
            Assert.IsNotNull(testingTarget, "Can't create success object Matrix3.");
            Assert.IsInstanceOf<Matrix3>(testingTarget, "Should return Matrix3 instance.");

            var result = testingTarget.Magnitude();
            tlog.Debug(tag, "Magnitude : " + result);

            testingTarget.Dispose();
            tlog.Debug(tag, $"Matrix3Magnitude END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Matrix3 ScaledInverseTranspose.")]
        [Property("SPEC", "Tizen.NUI.Matrix3.ScaledInverseTranspose M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void Matrix3ScaledInverseTranspose()
        {
            tlog.Debug(tag, $"Matrix3ScaledInverseTranspose START");

            var testingTarget = new Matrix3();
            Assert.IsNotNull(testingTarget, "Can't create success object Matrix3.");
            Assert.IsInstanceOf<Matrix3>(testingTarget, "Should return Matrix3 instance.");

            var result = testingTarget.ScaledInverseTranspose();
            tlog.Debug(tag, "ScaledInverseTranspose : " + result);

            testingTarget.Dispose();
            tlog.Debug(tag, $"Matrix3ScaledInverseTranspose END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Matrix3 Multiply.")]
        [Property("SPEC", "Tizen.NUI.Matrix3.Multiply M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void Matrix3Multiply()
        {
            tlog.Debug(tag, $"Matrix3Multiply START");

            var testingTarget = new Matrix3();
            Assert.IsNotNull(testingTarget, "Can't create success object Matrix3.");
            Assert.IsInstanceOf<Matrix3>(testingTarget, "Should return Matrix3 instance.");

            using (Matrix3 lhs = new Matrix3())
            {
                using (Matrix3 rhs = new Matrix3(0.0f, 0.1f, 0.2f, 1.0f, 1.1f, 1.2f, 2.0f, 2.1f, 2.2f))
                {
                    try
                    {
                        Matrix3.Multiply(testingTarget, lhs, rhs);
                    }
                    catch (Exception e)
                    {
                        tlog.Debug(tag, e.Message.ToString());
                        Assert.Fail("Caught Exception : Failed!");
                    }
                }
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"Matrix3Multiply END (OK)");
        }
    }
}
