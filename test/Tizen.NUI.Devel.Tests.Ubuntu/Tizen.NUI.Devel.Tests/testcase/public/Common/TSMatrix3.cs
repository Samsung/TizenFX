using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("public/Common/Matrix3")]
    public class Matrix3Test
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
        [Description("Matrix3 Identity.")]
        [Property("SPEC", "Tizen.NUI.Matrix3.Identity A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void Matrix3Identity()
        {
            tlog.Debug(tag, $"Matrix3Identity START");

            try
            {
                var result = Matrix3.Identity;
                tlog.Debug(tag, "Identity : " + result);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            tlog.Debug(tag, $"Matrix3Identity END (OK)");
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
                Assert.AreEqual(false, result, "EqualTo should be false");
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
                Assert.AreEqual(true, result, "NotEqualTo should be true");
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
        [Description("Matrix3 Invert.")]
        [Property("SPEC", "Tizen.NUI.Matrix3.Invert M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void Matrix3Invert()
        {
            tlog.Debug(tag, $"Matrix3Invert START");

            // Initialize as invertable matrix
            var testingTarget = new Matrix3(1.0f, 0.0f, 0.0f, 0.0f, 2.0f, 0.0f, 0.0f, 0.0f, 3.0f);
            Assert.IsNotNull(testingTarget, "Can't create success object Matrix3.");
            Assert.IsInstanceOf<Matrix3>(testingTarget, "Should return Matrix3 instance.");

            var result = testingTarget.Invert();
            tlog.Debug(tag, "Invert :" + result);
            Assert.AreEqual(true, result, "Invert should be successed");

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

        [Test]
        [Category("P1")]
        [Description("Matrix3 MultiplyAssign.")]
        [Property("SPEC", "Tizen.NUI.Matrix3.MultiplyAssign M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "eunkiki.hong@samsung.com")]
        public void Matrix3MultiplyAssign()
        {
            tlog.Debug(tag, $"Matrix3MultiplyAssign START");

            var testingTarget = new Matrix3();
            Assert.IsNotNull(testingTarget, "Can't create success object Matrix3.");
            Assert.IsInstanceOf<Matrix3>(testingTarget, "Should return Matrix3 instance.");

            using (Matrix3 rhs = new Matrix3(0.0f, 0.1f, 0.2f, 1.0f, 1.1f, 1.2f, 2.0f, 2.1f, 2.2f))
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
            tlog.Debug(tag, $"Matrix3MultiplyAssign END (OK)");
        }


        [Test]
        [Category("P1")]
        [Description("Matrix ValueOfIndex with signle index.")]
        [Property("SPEC", "Tizen.NUI.Matrix.ValueOfIndex M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Eunki Hong, eunkiki.hong@samsung.com")]
        public void Matrix3ValueOfIndexSingleIndex()
        {
            /* TEST CODE */
            tlog.Debug(tag, $"Matrix3ValueOfIndexSingleIndex START");

            Matrix3 testingTarget = new Matrix3(0.0f, 1.0f, 2.0f, 0.1f, 1.1f, 2.1f, 0.2f, 1.2f, 2.2f);
            Assert.IsNotNull(testingTarget, "Can't create success object Matrix.");
            Assert.IsInstanceOf<Matrix3>(testingTarget, "Should return Matrix instance.");

            for(uint index = 0; index < 9; ++index)
            {
                float expectResult = (index / 3) * 0.1f + (index % 3) * 1.0f;
                Assert.AreEqual(expectResult, testingTarget.ValueOfIndex(index), "The value of index is not correct!");
            }
            testingTarget.Dispose();
            tlog.Debug(tag, $"Matrix3ValueOfIndexSingleIndex END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Matrix3 ValueOfIndex with double index.")]
        [Property("SPEC", "Tizen.NUI.Matrix3.ValueOfIndex M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Eunki Hong, eunkiki.hong@samsung.com")]
        public void Matrix3ValueOfIndexDoubleIndex()
        {
            /* TEST CODE */
            tlog.Debug(tag, $"Matrix3ValueOfIndexDoubleIndex START");

            Matrix3 testingTarget = new Matrix3(0.0f, 1.0f, 2.0f, 0.1f, 1.1f, 2.1f, 0.2f, 1.2f, 2.2f);
            Assert.IsNotNull(testingTarget, "Can't create success object Matrix.");
            Assert.IsInstanceOf<Matrix3>(testingTarget, "Should return Matrix instance.");

            for(uint indexRow = 0; indexRow < 3; ++indexRow)
            {
                for(uint indexColumn = 0; indexColumn < 3; ++indexColumn)
                {
                    float expectResult = indexColumn * 0.1f + indexRow * 1.0f;
                    Assert.AreEqual(expectResult, testingTarget.ValueOfIndex(indexRow, indexColumn), "The value of index is not correct!");
                }
            }
            testingTarget.Dispose();
            tlog.Debug(tag, $"Matrix3ValueOfIndexDoubleIndex END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Matrix3 SetValueAtIndex with signle index.")]
        [Property("SPEC", "Tizen.NUI.Matrix3.SetValueAtIndex M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Eunki Hong, eunkiki.hong@samsung.com")]
        public void Matrix3SetValueAtIndexSingleIndex()
        {
            /* TEST CODE */
            tlog.Debug(tag, $"Matrix3SetValueAtIndexSingleIndex START");
            Matrix3 testingTarget = new Matrix3();
            Assert.IsNotNull(testingTarget, "Can't create success object Matrix.");
            Assert.IsInstanceOf<Matrix3>(testingTarget, "Should return Matrix instance.");

            for(uint index = 0; index < 9; ++index)
            {
                float expectResult = (index / 3) * 0.1f + (index % 3) * 1.0f;
                testingTarget.SetValueAtIndex(index, expectResult);
                Assert.AreEqual(expectResult, testingTarget[index], "The value of index is not correct!");
            }
            testingTarget.Dispose();
            tlog.Debug(tag, $"Matrix3SetValueAtIndexSingleIndex END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Matrix3 SetValueAtIndex with double index.")]
        [Property("SPEC", "Tizen.NUI.Matrix3.SetValueAtIndex M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Eunki Hong, eunkiki.hong@samsung.com")]
        public void Matrix3SetValueAtIndexDoubleIndex()
        {
            /* TEST CODE */
            tlog.Debug(tag, $"Matrix3SetValueAtIndexDoubleIndex START");
            Matrix3 testingTarget = new Matrix3();
            Assert.IsNotNull(testingTarget, "Can't create success object Matrix.");
            Assert.IsInstanceOf<Matrix3>(testingTarget, "Should return Matrix instance.");

            for(uint indexRow = 0; indexRow < 3; ++indexRow)
            {
                for(uint indexColumn = 0; indexColumn < 3; ++indexColumn)
                {
                    float expectResult = indexColumn * 0.1f + indexRow * 1.0f;
                    testingTarget.SetValueAtIndex(indexRow, indexColumn, expectResult);
                    Assert.AreEqual(expectResult, testingTarget.ValueOfIndex(indexRow, indexColumn), "The value of index is not correct!");
                }
            }
            testingTarget.Dispose();
            tlog.Debug(tag, $"Matrix3SetValueAtIndexDoubleIndex END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Test Tizen.NUI.Matrix3.operator * with Matrix3.")]
        [Property("SPEC", "Tizen.NUI.Matrix3.operator *() A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Eunki Hong, eunkiki.hong@samsung.com")]
        public void Matrix3MultiplyOperator()
        {
            /* TEST CODE */
            tlog.Debug(tag, $"Matrix3MultiplyOperator START");
            Matrix3 testingTarget = new Matrix3();
            Assert.IsNotNull(testingTarget, "Can't create success object Matrix.");
            Assert.IsInstanceOf<Matrix3>(testingTarget, "Should return Matrix instance.");

            try
            {
                Matrix3 rhs = new Matrix3(1.0f, 0.0f, 0.0f, 0.0f, 2.0f, 0.0f, 0.0f, 0.0f, 3.0f);
                Matrix3 ret = testingTarget * rhs;
                rhs.Dispose();
                ret.Dispose();
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }
            testingTarget.Dispose();
            tlog.Debug(tag, $"Matrix3MultiplyOperator END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Test Tizen.NUI.Matrix3.operator * with Vector3.")]
        [Property("SPEC", "Tizen.NUI.Matrix3.operator *() A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Eunki Hong, eunkiki.hong@samsung.com")]
        public void Matrix3MultiplyOperatorWithVector3()
        {
            /* TEST CODE */
            tlog.Debug(tag, $"Matrix3MultiplyOperatorWithVector3 START");
            Matrix3 testingTarget = new Matrix3();
            Assert.IsNotNull(testingTarget, "Can't create success object Matrix.");
            Assert.IsInstanceOf<Matrix3>(testingTarget, "Should return Matrix instance.");

            try
            {
                Vector3 rhs = new Vector3();
                Vector3 ret = testingTarget * rhs;
                rhs.Dispose();
                ret.Dispose();
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }
            testingTarget.Dispose();
            tlog.Debug(tag, $"Matrix3MultiplyOperatorWithVector4 END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Test this[uint index]. Check whether this[uint index] returns expected value or not.")]
        [Property("SPEC", "Tizen.NUI.Matrix3.this[uint] A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Eunki Hong, eunkiki.hong@samsung.com")]
        public void this_SET_GET_VALUE()
        {
            /* TEST CODE */
            tlog.Debug(tag, $"Matrix3this_SET_GET_VALUE START");
            Matrix3 testingTarget = new Matrix3();
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
            tlog.Debug(tag, $"Matrix3this_SET_GET_VALUE END (OK)");
        }
    }
}
