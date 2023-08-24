using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("public/Common/Matrix")]
    public class PublicMatrixTest
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
        [Description("Matrix constructor, with bool")]
        [Property("SPEC", "Tizen.NUI.Matrix.Matrix C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void MatrixConstructorwithbool()
        {
            tlog.Debug(tag, $"MatrixConstructorwithbool START");

            Matrix testingTarget = new Matrix(false);
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<Matrix>(testingTarget, "Should be an Instance of Matrix!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"MatrixConstructorwithbool END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Matrix constructor, with Rotation")]
        [Property("SPEC", "Tizen.NUI.Matrix.Matrix C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void MatrixConstructorwithRotation()
        {
            tlog.Debug(tag, $"MatrixConstructorwithRotation START");

            Rotation obj = new Rotation();
            Matrix testingTarget = new Matrix(obj);
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<Matrix>(testingTarget, "Should be an Instance of Matrix!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"MatrixConstructorwithRotation END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Matrix constructor, with Matrix")]
        [Property("SPEC", "Tizen.NUI.Matrix.Matrix C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void MatrixConstructorwithMatrix()
        {
            tlog.Debug(tag, $"MatrixConstructorwithMatrix START");

            Matrix matrix = new Matrix();
            matrix.SetXAxis(new Vector3(1.0f, 2.0f, 3.0f));
            matrix.SetYAxis(new Vector3(1.0f, 2.0f, 3.0f));
            matrix.SetZAxis(new Vector3(1.0f, 2.0f, 3.0f));

            var testingTarget = new Matrix(matrix);
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<Matrix>(testingTarget, "Should be an Instance of Matrix!");

            try
            {
                testingTarget.Invert();
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"MatrixConstructorwithMatrix END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Matrix constructor, with array")]
        [Property("SPEC", "Tizen.NUI.Matrix.Matrix C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void MatrixConstructorwithArray()
        {
            tlog.Debug(tag, $"MatrixConstructorwithArray START");

            var array = new float[3] { 1.0f, 3.0f, 5.0f };
            var testingTarget = new Matrix(array);
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<Matrix>(testingTarget, "Should be an Instance of Matrix!");

            try
            {
                testingTarget.OrthoNormalize();
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message);
                Assert.Fail("Caught Exception : Failed!");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"MatrixConstructorwithArray END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Matrix GetYAxis.")]
        [Property("SPEC", "Tizen.NUI.Matrix.GetYAxis M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void MatrixGetYAxis()
        {
            tlog.Debug(tag, $"MatrixGetYAxis START");

            var testingTarget = new Matrix();
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<Matrix>(testingTarget, "Should be an Instance of Matrix!");

            try
            {
                testingTarget.GetYAxis();
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            tlog.Debug(tag, $"MatrixGetYAxis END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Matrix GetZAxis.")]
        [Property("SPEC", "Tizen.NUI.Matrix.GetZAxis M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void MatrixGetZAxis()
        {
            tlog.Debug(tag, $"MatrixGetZAxis START");

            var testingTarget = new Matrix();
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<Matrix>(testingTarget, "Should be an Instance of Matrix!");

            try
            {
                testingTarget.GetZAxis();
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            tlog.Debug(tag, $"MatrixGetZAxis END (OK)");
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
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<Matrix>(testingTarget, "Should be an Instance of Matrix!");

            try
            {
                Vector3 axis = new Vector3(1.0f, 2.0f, 3.0f);
                testingTarget.SetXAxis(axis);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
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
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<Matrix>(testingTarget, "Should be an Instance of Matrix!");

            try
            {
                Vector3 axis = new Vector3(1.0f, 2.0f, 3.0f);
                testingTarget.SetYAxis(axis);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
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
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<Matrix>(testingTarget, "Should be an Instance of Matrix!");

            try
            {
                Vector3 axis = new Vector3(1.0f, 2.0f, 3.0f);
                testingTarget.SetZAxis(axis);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            tlog.Debug(tag, $"MatrixSetZAxis END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Matrix GetTranslation.")]
        [Property("SPEC", "Tizen.NUI.Matrix.GetTranslation M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void MatrixGetTranslation()
        {
            tlog.Debug(tag, $"MatrixGetTranslation START");

            var testingTarget = new Matrix();
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<Matrix>(testingTarget, "Should be an Instance of Matrix!");

            try
            {
                testingTarget.GetTranslation();
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            tlog.Debug(tag, $"MatrixGetTranslation END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Matrix GetTranslation3.")]
        [Property("SPEC", "Tizen.NUI.Matrix.GetTranslation3 M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void MatrixGetTranslation3()
        {
            tlog.Debug(tag, $"MatrixGetTranslation3 START");

            var testingTarget = new Matrix();
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<Matrix>(testingTarget, "Should be an Instance of Matrix!");

            try
            {
                testingTarget.GetTranslation3();
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            tlog.Debug(tag, $"MatrixGetTranslation3 END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Matrix SetTranslation.")]
        [Property("SPEC", "Tizen.NUI.Matrix.SetTranslation vector4 M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void MatrixSetTranslationwithVector4()
        {
            tlog.Debug(tag, $"MatrixSetTranslationwithVector4 START");

            var testingTarget = new Matrix();
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<Matrix>(testingTarget, "Should be an Instance of Matrix!");

            try
            {
                Vector4 translation = new Vector4(0.3f, 0.5f, 0.8f, 1.0f);
                testingTarget.SetTranslation(translation);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            tlog.Debug(tag, $"MatrixSetTranslationwithVector4 END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Matrix SetTranslation.")]
        [Property("SPEC", "Tizen.NUI.Matrix.SetTranslation vector3 M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void MatrixSetTranslationwithVector3()
        {
            tlog.Debug(tag, $"MatrixSetTranslationwithVector3 START");

            var testingTarget = new Matrix();
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<Matrix>(testingTarget, "Should be an Instance of Matrix!");

            try
            {
                Vector3 vector = new Vector3(1.0f, 2.0f, 3.0f);
                testingTarget.SetTranslation(vector);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            tlog.Debug(tag, $"MatrixSetTranslationwithVector3 END (OK)");
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

            var testingTarget = Matrix.IDENTITY;
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<Matrix>(testingTarget, "Should be an Instance of Matrix!");

            tlog.Debug(tag, $"MatrixIDENTITY END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Matrix Multiply, (Matrix result, Matrix lhs, Matrix rhs)")]
        [Property("SPEC", "Tizen.NUI.Matrix.Multiply M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void MatrixMultiply()
        {
            tlog.Debug(tag, $"MatrixMultiply START");

            Matrix lhs = new Matrix();
            using (Vector3 vec = new Vector3(1.0f, 2.0f, 3.0f))
            {
                lhs.SetXAxis(vec);
                lhs.SetYAxis(vec);
                lhs.SetZAxis(vec);
            }

            Matrix rhs = new Matrix();
            using (Vector3 vec = new Vector3(2.0f, 3.0f, 4.0f))
            {
                rhs.SetXAxis(vec);
                rhs.SetYAxis(vec);
                rhs.SetZAxis(vec);
            }

            try
            {
                Matrix result = new Matrix();
                Matrix.Multiply(result, lhs, rhs);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message);
                Assert.Fail("Caught Exception : Failed!");
            }

            tlog.Debug(tag, $"MatrixMultiply END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Matrix Multiply, (Matrix result, Matrix lhs, Rotation rhs)")]
        [Property("SPEC", "Tizen.NUI.Matrix.Multiply M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void MatrixMultiplyWithRotation()
        {
            tlog.Debug(tag, $"MatrixMultiplyWithRotation START");

            Matrix lhs = new Matrix();
            using (Vector3 vec = new Vector3(1.0f, 2.0f, 3.0f))
            {
                lhs.SetXAxis(vec);
                lhs.SetYAxis(vec);
                lhs.SetZAxis(vec);
            }

            try
            {
                Matrix result = new Matrix();
                Rotation rhs = new Rotation(new Radian(6.0f), new Vector3(1.0f, 2.0f, 3.0f));
                Matrix.Multiply(result, lhs, rhs);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message);
                Assert.Fail("Caught Exception : Failed!");
            }

            tlog.Debug(tag, $"MatrixMultiplyWithRotation END (OK)");
        }
    }
}
