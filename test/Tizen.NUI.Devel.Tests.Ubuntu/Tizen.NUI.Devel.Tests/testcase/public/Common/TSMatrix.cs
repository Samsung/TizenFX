using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("public/Common/Matrix")]
    public class MatrixTest
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
        [Description("Matrix constructor.")]
        [Property("SPEC", "Tizen.NUI.Matrix.Matrix C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void MatrixConstructor()
        {
            tlog.Debug(tag, $"MatrixConstructor START");

            var testingTarget = new Matrix();
            Assert.IsNotNull(testingTarget, "Can't create success object Matrix.");
            Assert.IsInstanceOf<Matrix>(testingTarget, "Should return Matrix instance.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"MatrixConstructor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Matrix constructor. With boolean.")]
        [Property("SPEC", "Tizen.NUI.Matrix.Matrix C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void MatrixConstructorWithBoolean()
        {
            tlog.Debug(tag, $"MatrixConstructorWithBoolean START");

            var testingTarget = new Matrix(true);
            Assert.IsNotNull(testingTarget, "Can't create success object Matrix.");
            Assert.IsInstanceOf<Matrix>(testingTarget, "Should return Matrix instance.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"MatrixConstructorWithBoolean END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Matrix constructor. With float array.")]
        [Property("SPEC", "Tizen.NUI.Matrix.Matrix C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void MatrixConstructorWithFloatArray()
        {
            tlog.Debug(tag, $"MatrixConstructorWithFloatArray START");

            float[] arr = new float[16]
            { 0.0f, 1.0f, 2.0f, 3.0f,
              0.1f, 1.1f, 2.1f, 3.1f,
              0.2f, 1.2f, 2.2f, 3.2f,
              0.3f, 1.3f, 2.3f, 3.3f};

            var testingTarget = new Matrix(arr);
            Assert.IsNotNull(testingTarget, "Can't create success object Matrix.");
            Assert.IsInstanceOf<Matrix>(testingTarget, "Should return Matrix instance.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"MatrixConstructorWithFloatArray END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Matrix constructor. With Rotation.")]
        [Property("SPEC", "Tizen.NUI.Matrix.Matrix C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void MatrixConstructorWithRotation()
        {
            tlog.Debug(tag, $"MatrixConstructorWithRotation START");

            using (Rotation rotation = new Rotation())
            {
                var testingTarget = new Matrix(rotation);
                Assert.IsNotNull(testingTarget, "Can't create success object Matrix.");
                Assert.IsInstanceOf<Matrix>(testingTarget, "Should return Matrix instance.");

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"MatrixConstructorWithRotation END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Matrix constructor. With Matrix.")]
        [Property("SPEC", "Tizen.NUI.Matrix.Matrix C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void MatrixConstructorWithMatrix()
        {
            tlog.Debug(tag, $"MatrixConstructorWithMatrix START");

            using (Matrix martrix = new Matrix(true))
            {
                var testingTarget = new Matrix(martrix);
                Assert.IsNotNull(testingTarget, "Can't create success object Matrix.");
                Assert.IsInstanceOf<Matrix>(testingTarget, "Should return Matrix instance.");

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"MatrixConstructorWithMatrix END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Matrix Assign.")]
        [Property("SPEC", "Tizen.NUI.Matrix.Assign M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void MatrixAssign()
        {
            tlog.Debug(tag, $"MatrixAssign START");

            using (Matrix martrix = new Matrix(true))
            {
                var testingTarget = martrix.Assign(martrix);
                Assert.IsNotNull(testingTarget, "Can't create success object Matrix.");
                Assert.IsInstanceOf<Matrix>(testingTarget, "Should return Matrix instance.");

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"MatrixAssign END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Matrix Identity.")]
        [Property("SPEC", "Tizen.NUI.Matrix.Identity A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void MatrixIdentity()
        {
            tlog.Debug(tag, $"MatrixIdentity START");

            try
            {
                var result = Matrix.Identity;
                tlog.Debug(tag, "Identity : " + result);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            tlog.Debug(tag, $"MatrixIdentity END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Matrix SetIdentity.")]
        [Property("SPEC", "Tizen.NUI.Matrix.SetIdentity M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void MatrixSetIdentity()
        {
            tlog.Debug(tag, $"MatrixSetIdentity START");

            var testingTarget = new Matrix();
            Assert.IsNotNull(testingTarget, "Can't create success object Matrix.");
            Assert.IsInstanceOf<Matrix>(testingTarget, "Should return Matrix instance.");

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
            tlog.Debug(tag, $"MatrixSetIdentity END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Matrix SetIdentityAndScale.")]
        [Property("SPEC", "Tizen.NUI.Matrix.SetIdentityAndScale M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void MatrixSetIdentityAndScale()
        {
            tlog.Debug(tag, $"MatrixSetIdentityAndScale START");

            var testingTarget = new Matrix();
            Assert.IsNotNull(testingTarget, "Can't create success object Matrix.");
            Assert.IsInstanceOf<Matrix>(testingTarget, "Should return Matrix instance.");

            try
            {
                using (Vector3 vector = new Vector3(1.0f, 2.0f, 3.0f))
                {
                    testingTarget.SetIdentityAndScale(vector);
                }
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"MatrixSetIdentityAndScale END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Matrix Invert.")]
        [Property("SPEC", "Tizen.NUI.Matrix.Invert M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void MatrixInvert()
        {
            tlog.Debug(tag, $"MatrixInvert START");

            // Initialize as invertable matrix
            float[] arr = new float[16]
            { 0.0f, 2.0f, 0.0f, 0.0f,
              1.0f, 0.0f, 0.0f, 0.0f,
              0.0f, 0.0f, 0.0f, 4.0f,
              0.0f, 0.0f, 3.0f, 0.0f};

            var testingTarget = new Matrix(arr);
            Assert.IsNotNull(testingTarget, "Can't create success object Matrix.");
            Assert.IsInstanceOf<Matrix>(testingTarget, "Should return Matrix instance.");

            try
            {
                var result = testingTarget.Invert();
                tlog.Debug(tag, "Invert : " + result);
                Assert.AreEqual(true, result, "Invert should be successed");
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"MatrixInvert END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Matrix Transpose.")]
        [Property("SPEC", "Tizen.NUI.Matrix.Transpose M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void MatrixTranspose()
        {
            tlog.Debug(tag, $"MatrixTranspose START");

            var testingTarget = new Matrix();
            Assert.IsNotNull(testingTarget, "Can't create success object Matrix.");
            Assert.IsInstanceOf<Matrix>(testingTarget, "Should return Matrix instance.");

            try
            {
                testingTarget.Transpose();
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"MatrixTranspose END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Matrix SetXAxis.")]
        [Property("SPEC", "Tizen.NUI.Matrix.SetXAxis M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void MatrixSetXAxis()
        {
            tlog.Debug(tag, $"MatrixSetXAxis START");

            var testingTarget = new Matrix();
            Assert.IsNotNull(testingTarget, "Can't create success object Matrix.");
            Assert.IsInstanceOf<Matrix>(testingTarget, "Should return Matrix instance.");


            using (Vector3 vector = new Vector3(1.0f, 2.0f, 3.0f))
            {
                testingTarget.SetXAxis(vector);

                using (var result = testingTarget.GetXAxis())
                {
                    Assert.AreEqual(1.0f, result.X, "Should be equal!");
                    Assert.AreEqual(2.0f, result.Y, "Should be equal!");
                    Assert.AreEqual(3.0f, result.Z, "Should be equal!");
                }
            }
            

            testingTarget.Dispose();
            tlog.Debug(tag, $"MatrixSetXAxis END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Matrix SetYAxis.")]
        [Property("SPEC", "Tizen.NUI.Matrix.SetYAxis M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void MatrixSetYAxis()
        {
            tlog.Debug(tag, $"MatrixSetYAxis START");

            var testingTarget = new Matrix();
            Assert.IsNotNull(testingTarget, "Can't create success object Matrix.");
            Assert.IsInstanceOf<Matrix>(testingTarget, "Should return Matrix instance.");


            using (Vector3 vector = new Vector3(1.0f, 2.0f, 3.0f))
            {
                testingTarget.SetYAxis(vector);

                using (var result = testingTarget.GetYAxis())
                {
                    Assert.AreEqual(1.0f, result.X, "Should be equal!");
                    Assert.AreEqual(2.0f, result.Y, "Should be equal!");
                    Assert.AreEqual(3.0f, result.Z, "Should be equal!");
                }
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"MatrixSetYAxis END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Matrix SetZAxis.")]
        [Property("SPEC", "Tizen.NUI.Matrix.SetZAxis M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void MatrixSetZAxis()
        {
            tlog.Debug(tag, $"MatrixSetZAxis START");

            var testingTarget = new Matrix();
            Assert.IsNotNull(testingTarget, "Can't create success object Matrix.");
            Assert.IsInstanceOf<Matrix>(testingTarget, "Should return Matrix instance.");


            using (Vector3 vector = new Vector3(1.0f, 2.0f, 3.0f))
            {
                testingTarget.SetZAxis(vector);

                using (var result = testingTarget.GetZAxis())
                {
                    Assert.AreEqual(1.0f, result.X, "Should be equal!");
                    Assert.AreEqual(2.0f, result.Y, "Should be equal!");
                    Assert.AreEqual(3.0f, result.Z, "Should be equal!");
                }
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"MatrixSetZAxis END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Matrix SetTranslation.")]
        [Property("SPEC", "Tizen.NUI.Matrix.SetTranslation M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void MatrixGetTranslation()
        {
            tlog.Debug(tag, $"MatrixGetTranslation START");

            var testingTarget = new Matrix();
            Assert.IsNotNull(testingTarget, "Can't create success object Matrix.");
            Assert.IsInstanceOf<Matrix>(testingTarget, "Should return Matrix instance.");

            using (Vector4 vector = new Vector4(1.0f, 2.0f, 3.0f, 4.0f))
            {
                testingTarget.SetTranslation(vector);

                using (var result = testingTarget.GetTranslation())
                {
                    Assert.AreEqual(1.0f, result.X, "Should be equal!");
                    Assert.AreEqual(2.0f, result.Y, "Should be equal!");
                    Assert.AreEqual(3.0f, result.Z, "Should be equal!");
                    Assert.AreEqual(4.0f, result.W, "Should be equal!");
                }
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"MatrixGetTranslation END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Matrix SetTranslation. With Vector3.")]
        [Property("SPEC", "Tizen.NUI.Matrix.SetTranslation M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void MatrixSetTranslationWithVector3()
        {
            tlog.Debug(tag, $"MatrixSetTranslationWithVector3 START");

            var testingTarget = new Matrix();
            Assert.IsNotNull(testingTarget, "Can't create success object Matrix.");
            Assert.IsInstanceOf<Matrix>(testingTarget, "Should return Matrix instance.");

            using (Vector3 vector = new Vector3(1.0f, 2.0f, 3.0f))
            {
                testingTarget.SetTranslation(vector);

                using (var result = testingTarget.GetTranslation3())
                {
                    Assert.AreEqual(1.0f, result.X, "Should be equal!");
                    Assert.AreEqual(2.0f, result.Y, "Should be equal!");
                    Assert.AreEqual(3.0f, result.Z, "Should be equal!");
                }
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"MatrixSetTranslationWithVector3 END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Matrix OrthoNormalize.")]
        [Property("SPEC", "Tizen.NUI.Matrix.OrthoNormalize M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void MatrixOrthoNormalize()
        {
            tlog.Debug(tag, $"MatrixOrthoNormalize START");

            var testingTarget = new Matrix();
            Assert.IsNotNull(testingTarget, "Can't create success object Matrix.");
            Assert.IsInstanceOf<Matrix>(testingTarget, "Should return Matrix instance.");

            try
            {
                testingTarget.OrthoNormalize();
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            tlog.Debug(tag, $"MatrixOrthoNormalize END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Matrix Multiply.")]
        [Property("SPEC", "Tizen.NUI.Matrix.Multiply M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void MatrixMultiply()
        {
            tlog.Debug(tag, $"MatrixMultiply START");

            var testingTarget = new Matrix();
            Assert.IsNotNull(testingTarget, "Can't create success object Matrix.");
            Assert.IsInstanceOf<Matrix>(testingTarget, "Should return Matrix instance.");

            using (Matrix lhs = new Matrix(true))
            {
                using (Matrix rhs = new Matrix(false))
                {
                    try
                    {
                        Matrix.Multiply(testingTarget, lhs, rhs);
                    }
                    catch (Exception e)
                    {
                        tlog.Debug(tag, e.Message.ToString());
                        Assert.Fail("Caught Exception : Failed!");
                    }
                }
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"MatrixMultiply END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Matrix MultiplyAssign.")]
        [Property("SPEC", "Tizen.NUI.Matrix.MultiplyAssign M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "eunkiki.hong@samsung.com")]
        public void MatrixMultiplyAssign()
        {
            tlog.Debug(tag, $"MatrixMultiplyAssign START");

            var testingTarget = new Matrix();
            Assert.IsNotNull(testingTarget, "Can't create success object Matrix.");
            Assert.IsInstanceOf<Matrix>(testingTarget, "Should return Matrix instance.");

            using (Matrix rhs = new Matrix(false))
            {
                try
                {
                    testingTarget.MultiplyAssign(rhs);
                }
                catch (Exception e)
                {
                    tlog.Debug(tag, e.Message.ToString());
                    Assert.Fail("Caught Exception : Failed!");
                }
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"MatrixMultiplyAssign END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Matrix Multiply. With Rotation.")]
        [Property("SPEC", "Tizen.NUI.Matrix.Multiply M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void MatrixMultiplyWithRotation()
        {
            tlog.Debug(tag, $"MatrixMultiplyWithRotation START");

            var testingTarget = new Matrix();
            Assert.IsNotNull(testingTarget, "Can't create success object Matrix.");
            Assert.IsInstanceOf<Matrix>(testingTarget, "Should return Matrix instance.");

            using (Matrix lhs = new Matrix(true))
            {
                using (Rotation rhs = new Rotation())
                {
                    try
                    {
                        Matrix.Multiply(testingTarget, lhs, rhs);
                    }
                    catch (Exception e)
                    {
                        tlog.Debug(tag, e.Message.ToString());
                        Assert.Fail("Caught Exception : Failed!");
                    }
                }
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"MatrixMultiplyWithRotation END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Matrix Multiply. With Vector4.")]
        [Property("SPEC", "Tizen.NUI.Matrix.Multiply M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void MatrixMultiplyWithVector4()
        {
            tlog.Debug(tag, $"MatrixMultiplyWithVector4 START");

            var testingTarget = new Matrix();
            Assert.IsNotNull(testingTarget, "Can't create success object Matrix.");
            Assert.IsInstanceOf<Matrix>(testingTarget, "Should return Matrix instance.");

            using (Vector4 vector = new Vector4(1.0f, 2.0f, 3.0f, 4.0f))
            {
                try
                {
                    var ret = testingTarget.Multiply(vector);
                    ret.Dispose();
                }
                catch (Exception e)
                {
                    tlog.Debug(tag, e.Message.ToString());
                    Assert.Fail("Caught Exception : Failed!");
                }
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"MatrixMultiplyWithVector4 END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Matrix EqualTo.")]
        [Property("SPEC", "Tizen.NUI.Matrix.EqualTo M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void MatrixEqualTo()
        {
            tlog.Debug(tag, $"MatrixEqualTo START");

            var testingTarget = new Matrix();
            Assert.IsNotNull(testingTarget, "Can't create success object Matrix.");
            Assert.IsInstanceOf<Matrix>(testingTarget, "Should return Matrix instance.");

            using (Matrix matrix = new Matrix(true))
            {
                var result = testingTarget.EqualTo(matrix);
                tlog.Debug(tag, "EqualTo : " + result);
                Assert.AreEqual(true, result, "EqualTo should be true");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"MatrixEqualTo END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Matrix NotEqualTo.")]
        [Property("SPEC", "Tizen.NUI.Matrix.NotEqualTo M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void MatrixNotEqualTo()
        {
            tlog.Debug(tag, $"MatrixNotEqualTo START");

            var testingTarget = new Matrix();
            Assert.IsNotNull(testingTarget, "Can't create success object Matrix.");
            Assert.IsInstanceOf<Matrix>(testingTarget, "Should return Matrix instance.");

            using (Matrix matrix = new Matrix(true))
            {
                var result = testingTarget.NotEqualTo(matrix);
                tlog.Debug(tag, "NotEqualTo : " + result);
                Assert.AreEqual(false, result, "NotEqualTo should be false");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"MatrixNotEqualTo END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Matrix SetTransformComponents.")]
        [Property("SPEC", "Tizen.NUI.Matrix.SetTransformComponents M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void MatrixSetTransformComponents()
        {
            tlog.Debug(tag, $"MatrixSetTransformComponents START");

            var testingTarget = new Matrix();
            Assert.IsNotNull(testingTarget, "Can't create success object Matrix.");
            Assert.IsInstanceOf<Matrix>(testingTarget, "Should return Matrix instance.");

            using (Vector3 scale = new Vector3(1.0f, 2.0f, 3.0f))
            {
                {
                    using (Rotation rotation = new Rotation())
                    {
                        using (Vector3 translation = new Vector3(3.0f, 2.0f, 1.0f))
                        {
                            try
                            {
                                testingTarget.SetTransformComponents(scale, rotation, translation);
                            }
                            catch (Exception e)
                            {
                                tlog.Debug(tag, e.Message.ToString());
                                Assert.Fail("Caught Exception : Failed!");
                            }
                        }
                    }
                }
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"MatrixSetTransformComponents END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Matrix SetInverseTransformComponents.")]
        [Property("SPEC", "Tizen.NUI.Matrix.SetInverseTransformComponents M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void MatrixSetInverseTransformComponents()
        {
            tlog.Debug(tag, $"MatrixSetInverseTransformComponents START");

            var testingTarget = new Matrix();
            Assert.IsNotNull(testingTarget, "Can't create success object Matrix.");
            Assert.IsInstanceOf<Matrix>(testingTarget, "Should return Matrix instance.");

            using (Vector3 scale = new Vector3(1.0f, 2.0f, 3.0f))
            {
                {
                    using (Rotation rotation = new Rotation())
                    {
                        using (Vector3 translation = new Vector3(3.0f, 2.0f, 1.0f))
                        {
                            try
                            {
                                testingTarget.SetInverseTransformComponents(scale, rotation, translation);
                            }
                            catch (Exception e)
                            {
                                tlog.Debug(tag, e.Message.ToString());
                                Assert.Fail("Caught Exception : Failed!");
                            }
                        }
                    }
                }
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"MatrixSetInverseTransformComponents END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Matrix SetInverseTransformComponents.")]
        [Property("SPEC", "Tizen.NUI.Matrix.SetInverseTransformComponents M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void MatrixSetInverseTransformComponentsWithVector3()
        {
            tlog.Debug(tag, $"MatrixSetInverseTransformComponentsWithVector3 START");

            var testingTarget = new Matrix();
            Assert.IsNotNull(testingTarget, "Can't create success object Matrix.");
            Assert.IsInstanceOf<Matrix>(testingTarget, "Should return Matrix instance.");

            using (Vector3 xAxis = new Vector3(1.0f, 2.0f, 3.0f))
            {
                {
                    using (Vector3 yAxis = new Vector3(3.0f, 4.0f, 5.0f))
                    {
                        using (Vector3 zAxis = new Vector3(5.0f, 6.0f, 7.0f))
                        {
                            using (Vector3 translation = new Vector3(7.0f, 8.0f, 9.0f))
                            {
                                try
                                {
                                    testingTarget.SetInverseTransformComponents(xAxis, yAxis, zAxis, translation);
                                }
                                catch (Exception e)
                                {
                                    tlog.Debug(tag, e.Message.ToString());
                                    Assert.Fail("Caught Exception : Failed!");
                                }
                            }
                        }
                    }
                }
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"MatrixSetInverseTransformComponentsWithVector3 END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Matrix GetTransformComponents.")]
        [Property("SPEC", "Tizen.NUI.Matrix.GetTransformComponents M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void MatrixGetTransformComponents()
        {
            tlog.Debug(tag, $"MatrixGetTransformComponents START");

            var testingTarget = new Matrix();
            Assert.IsNotNull(testingTarget, "Can't create success object Matrix.");
            Assert.IsInstanceOf<Matrix>(testingTarget, "Should return Matrix instance.");

            using (Vector3 position = new Vector3(1.0f, 2.0f, 3.0f))
            {
                {
                    using (Rotation rotation = new Rotation())
                    {
                        using (Vector3 scale = new Vector3(3.0f, 2.0f, 1.0f))
                        {
                            try
                            {
                                testingTarget.GetTransformComponents(position, rotation, scale);
                            }
                            catch (Exception e)
                            {
                                tlog.Debug(tag, e.Message.ToString());
                                Assert.Fail("Caught Exception : Failed!");
                            }
                        }
                    }
                }
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"MatrixGetTransformComponents END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Matrix ValueOfIndex with signle index.")]
        [Property("SPEC", "Tizen.NUI.Matrix.ValueOfIndex M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Eunki Hong, eunkiki.hong@samsung.com")]
        public void MatrixValueOfIndexSingleIndex()
        {
            /* TEST CODE */
            tlog.Debug(tag, $"MatrixValueOfIndexSingleIndex START");

            float[] arr = new float[16]
            { 0.0f, 1.0f, 2.0f, 3.0f,
              0.1f, 1.1f, 2.1f, 3.1f,
              0.2f, 1.2f, 2.2f, 3.2f,
              0.3f, 1.3f, 2.3f, 3.3f};

            Matrix testingTarget = new Matrix(arr);
            Assert.IsNotNull(testingTarget, "Can't create success object Matrix.");
            Assert.IsInstanceOf<Matrix>(testingTarget, "Should return Matrix instance.");

            for(uint index = 0; index < 16; ++index)
            {
                float expectResult = (index / 4) * 0.1f + (index % 4) * 1.0f;
                Assert.AreEqual(expectResult, testingTarget.ValueOfIndex(index), "The value of index is not correct!");
            }
            testingTarget.Dispose();
            tlog.Debug(tag, $"MatrixValueOfIndexSingleIndex END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Matrix ValueOfIndex with double index.")]
        [Property("SPEC", "Tizen.NUI.Matrix.ValueOfIndex M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Eunki Hong, eunkiki.hong@samsung.com")]
        public void MatrixValueOfIndexDoubleIndex()
        {
            /* TEST CODE */
            tlog.Debug(tag, $"MatrixValueOfIndexDoubleIndex START");
            float[] arr = new float[16]
            { 0.0f, 1.0f, 2.0f, 3.0f,
              0.1f, 1.1f, 2.1f, 3.1f,
              0.2f, 1.2f, 2.2f, 3.2f,
              0.3f, 1.3f, 2.3f, 3.3f};

            Matrix testingTarget = new Matrix(arr);
            Assert.IsNotNull(testingTarget, "Can't create success object Matrix.");
            Assert.IsInstanceOf<Matrix>(testingTarget, "Should return Matrix instance.");

            for(uint indexRow = 0; indexRow < 4; ++indexRow)
            {
                for(uint indexColumn = 0; indexColumn < 4; ++indexColumn)
                {
                    float expectResult = indexColumn * 0.1f + indexRow * 1.0f;
                    Assert.AreEqual(expectResult, testingTarget.ValueOfIndex(indexRow, indexColumn), "The value of index is not correct!");
                }
            }
            testingTarget.Dispose();
            tlog.Debug(tag, $"MatrixValueOfIndexDoubleIndex END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Matrix SetValueAtIndex with signle index.")]
        [Property("SPEC", "Tizen.NUI.Matrix.SetValueAtIndex M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Eunki Hong, eunkiki.hong@samsung.com")]
        public void MatrixSetValueAtIndexSingleIndex()
        {
            /* TEST CODE */
            tlog.Debug(tag, $"MatrixSetValueAtIndexSingleIndex START");
            Matrix testingTarget = new Matrix(true);
            Assert.IsNotNull(testingTarget, "Can't create success object Matrix.");
            Assert.IsInstanceOf<Matrix>(testingTarget, "Should return Matrix instance.");

            for(uint index = 0; index < 16; ++index)
            {
                float expectResult = (index / 4) * 0.1f + (index % 4) * 1.0f;
                testingTarget.SetValueAtIndex(index, expectResult);
                Assert.AreEqual(expectResult, testingTarget[index], "The value of index is not correct!");
            }
            testingTarget.Dispose();
            tlog.Debug(tag, $"MatrixSetValueAtIndexSingleIndex END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Matrix SetValueAtIndex with double index.")]
        [Property("SPEC", "Tizen.NUI.Matrix.SetValueAtIndex M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Eunki Hong, eunkiki.hong@samsung.com")]
        public void MatrixSetValueAtIndexDoubleIndex()
        {
            /* TEST CODE */
            tlog.Debug(tag, $"MatrixSetValueAtIndexDoubleIndex START");
            Matrix testingTarget = new Matrix(true);
            Assert.IsNotNull(testingTarget, "Can't create success object Matrix.");
            Assert.IsInstanceOf<Matrix>(testingTarget, "Should return Matrix instance.");

            for(uint indexRow = 0; indexRow < 4; ++indexRow)
            {
                for(uint indexColumn = 0; indexColumn < 4; ++indexColumn)
                {
                    float expectResult = indexColumn * 0.1f + indexRow * 1.0f;
                    testingTarget.SetValueAtIndex(indexRow, indexColumn, expectResult);
                    Assert.AreEqual(expectResult, testingTarget.ValueOfIndex(indexRow, indexColumn), "The value of index is not correct!");
                }
            }
            testingTarget.Dispose();
            tlog.Debug(tag, $"MatrixSetValueAtIndexDoubleIndex END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Test Tizen.NUI.Matrix.operator * with Matrix.")]
        [Property("SPEC", "Tizen.NUI.Matrix.operator *() A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Eunki Hong, eunkiki.hong@samsung.com")]
        public void MatrixMultiplyOperator()
        {
            /* TEST CODE */
            tlog.Debug(tag, $"MatrixMultiplyOperator START");
            Matrix testingTarget = new Matrix(true);
            Assert.IsNotNull(testingTarget, "Can't create success object Matrix.");
            Assert.IsInstanceOf<Matrix>(testingTarget, "Should return Matrix instance.");

            try
            {
                Matrix rhs = new Matrix(false);
                Matrix ret = testingTarget * rhs;
                rhs.Dispose();
                ret.Dispose();
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }
            testingTarget.Dispose();
            tlog.Debug(tag, $"MatrixMultiplyOperator END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Test Tizen.NUI.Matrix.operator * with Rotation.")]
        [Property("SPEC", "Tizen.NUI.Matrix.operator *() A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Eunki Hong, eunkiki.hong@samsung.com")]
        public void MatrixMultiplyOperatorWithRotation()
        {
            /* TEST CODE */
            tlog.Debug(tag, $"MatrixMultiplyOperatorWithRotation START");
            Matrix testingTarget = new Matrix(true);
            Assert.IsNotNull(testingTarget, "Can't create success object Matrix.");
            Assert.IsInstanceOf<Matrix>(testingTarget, "Should return Matrix instance.");

            try
            {
                Rotation lhs = new Rotation();
                Matrix ret = lhs * testingTarget;
                lhs.Dispose();
                ret.Dispose();
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }
            testingTarget.Dispose();
            tlog.Debug(tag, $"MatrixMultiplyOperatorWithRotation END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Test Tizen.NUI.Matrix.operator * with Vector4.")]
        [Property("SPEC", "Tizen.NUI.Matrix.operator *() A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Eunki Hong, eunkiki.hong@samsung.com")]
        public void MatrixMultiplyOperatorWithVector4()
        {
            /* TEST CODE */
            tlog.Debug(tag, $"MatrixMultiplyOperatorWithVector4 START");
            Matrix testingTarget = new Matrix(true);
            Assert.IsNotNull(testingTarget, "Can't create success object Matrix.");
            Assert.IsInstanceOf<Matrix>(testingTarget, "Should return Matrix instance.");

            try
            {
                Vector4 rhs = new Vector4();
                Vector4 ret = testingTarget * rhs;
                rhs.Dispose();
                ret.Dispose();
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }
            testingTarget.Dispose();
            tlog.Debug(tag, $"MatrixMultiplyOperatorWithVector4 END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Test this[uint index]. Check whether this[uint index] returns expected value or not.")]
        [Property("SPEC", "Tizen.NUI.Matrix.this[uint] A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Eunki Hong, eunkiki.hong@samsung.com")]
        public void this_SET_GET_VALUE()
        {
            /* TEST CODE */
            tlog.Debug(tag, $"Matrixthis_SET_GET_VALUE START");
            Matrix testingTarget = new Matrix(true);
            try
            {
                testingTarget[0] = 100.0f;
                testingTarget[1] = 200.0f;
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }
            Assert.AreEqual(100.0f, testingTarget[0], "The value of index[0] is not correct!");
            Assert.AreEqual(200.0f, testingTarget[1], "The value of index[1] is not correct!");
            testingTarget.Dispose();
            tlog.Debug(tag, $"Matrixthis_SET_GET_VALUE END (OK)");
        }
    }
}
