using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("internal/Common/Matrix")]
    public class InternalMatrixTest
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

            float[] arr = new float[3] { 0.1f, 0.4f, 0.2f };

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
        [Description("Matrix IDENTITY.")]
        [Property("SPEC", "Tizen.NUI.Matrix.IDENTITY A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void MatrixIDENTITY()
        {
            tlog.Debug(tag, $"MatrixIDENTITY START");

            try
            {
                var result = Matrix.IDENTITY;
                tlog.Debug(tag, "IDENTITY : " + result);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            tlog.Debug(tag, $"MatrixIDENTITY END (OK)");
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

            var testingTarget = new Matrix();
            Assert.IsNotNull(testingTarget, "Can't create success object Matrix.");
            Assert.IsInstanceOf<Matrix>(testingTarget, "Should return Matrix instance.");

            try
            {
                var result = testingTarget.Invert();
                tlog.Debug(tag, "Invert : " + result);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

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

                var result = testingTarget.GetXAxis();
                Assert.AreEqual(1.0f, result.X, "Should be equal!");
                Assert.AreEqual(2.0f, result.Y, "Should be equal!");
                Assert.AreEqual(3.0f, result.Z, "Should be equal!");
            }

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

                var result = testingTarget.GetYAxis();
                Assert.AreEqual(1.0f, result.X, "Should be equal!");
                Assert.AreEqual(2.0f, result.Y, "Should be equal!");
                Assert.AreEqual(3.0f, result.Z, "Should be equal!");
            }

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

                var result = testingTarget.GetZAxis();
                Assert.AreEqual(1.0f, result.X, "Should be equal!");
                Assert.AreEqual(2.0f, result.Y, "Should be equal!");
                Assert.AreEqual(3.0f, result.Z, "Should be equal!");
            }

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

                var result = testingTarget.GetTranslation();
                Assert.AreEqual(1.0f, result.X, "Should be equal!");
                Assert.AreEqual(2.0f, result.Y, "Should be equal!");
                Assert.AreEqual(3.0f, result.Z, "Should be equal!");
                Assert.AreEqual(4.0f, result.W, "Should be equal!");
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

                var result = testingTarget.GetTranslation3();
                Assert.AreEqual(1.0f, result.X, "Should be equal!");
                Assert.AreEqual(2.0f, result.Y, "Should be equal!");
                Assert.AreEqual(3.0f, result.Z, "Should be equal!");
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
        [Description("Matrix AsFloat.")]
        [Property("SPEC", "Tizen.NUI.Matrix.AsFloat M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void MatrixAsFloat()
        {
            tlog.Debug(tag, $"MatrixAsFloat START");

            var testingTarget = new Matrix();
            Assert.IsNotNull(testingTarget, "Can't create success object Matrix.");
            Assert.IsInstanceOf<Matrix>(testingTarget, "Should return Matrix instance.");

            try
            {
                testingTarget.AsFloat();
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            tlog.Debug(tag, $"MatrixAsFloat END (OK)");
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
                    testingTarget.Multiply(vector);
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
    }
}
