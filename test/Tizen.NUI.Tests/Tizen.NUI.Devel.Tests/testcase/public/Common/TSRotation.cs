using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("public/Common/Rotation")]
    public class PublicRotationTest
    {
        private const string tag = "NUITEST";

        private Vector3 MyCross(Vector3 vector1, Vector3 vector2)
        {
            return new Vector3((vector1.Y * vector2.Z) - (vector1.Z * vector2.Y),
                  (vector1.Z * vector2.X) - (vector1.X * vector2.Z),
                  (vector1.X * vector2.Y) - (vector1.Y * vector2.X));
        }

        private float MyDot(Vector3 vector1, Vector3 vector2)
        {
            return vector1.X * vector2.X + vector1.Y * vector2.Y + vector1.Z * vector2.Z; ;
        }

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
        [Description("Rotation Addition.")]
        [Property("SPEC", "Tizen.NUI.Rotation.+ M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void RotationAddition()
        {
            tlog.Debug(tag, $"RotationAddition START");

            var testingTarget = new Rotation(new Radian(new Degree(180.0f)), new Vector3(1.0f, 0.0f, 0.0f));
            Assert.IsNotNull(testingTarget, "Can't create success object Rotation");
            Assert.IsInstanceOf<Rotation>(testingTarget, "Should return Rotation instance.");

            using (Rotation rotation = new Rotation(new Radian(new Degree(180.0f)), new Vector3(1.0f, 0.0f, 0.0f)))
            {
                var result = testingTarget + rotation;

                Radian radian = new Radian(0.0f);
                Vector3  axis = new Vector3();
                result.GetAxisAngle(axis, radian);

                Assert.AreEqual(2.0f, axis.X, "Addition function does not work, Vector3.X value is not correct");
                Assert.AreEqual(0.0f, axis.Y, "Addition function does not work, Vector3.Y value is not correct");
                Assert.AreEqual(0.0f, axis.Z, "Addition function does not work, Vector3.Z value is not correct");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"RotationAddition END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Rotation Subtraction.")]
        [Property("SPEC", "Tizen.NUI.Rotation.- M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void RotationSubtraction()
        {
            tlog.Debug(tag, $"RotationSubtraction START");

            var testingTarget = new Rotation(new Radian(new Degree(180.0f)), new Vector3(0.0f, 1.0f, 0.0f));
            Assert.IsNotNull(testingTarget, "Can't create success object Rotation");
            Assert.IsInstanceOf<Rotation>(testingTarget, "Should return Rotation instance.");

            using (Rotation rotation = new Rotation(new Radian(new Degree(180.0f)), new Vector3(0.0f, 1.0f, 0.0f)))
            {
                var result = testingTarget - rotation;

                Radian radian = new Radian(0.0f);
                Vector3 axis = new Vector3();
                result.GetAxisAngle(axis, radian);

                Assert.AreEqual(0.0f, axis.X, "Subtraction function does not work, Vector3.X value is not correct");
                Assert.AreEqual(0.0f, axis.Y, "Subtraction function does not work, Vector3.Y value is not correct");
                Assert.AreEqual(0.0f, axis.Z, "Subtraction function does not work, Vector3.Z value is not correct");
            }

            testingTarget.Dispose();    
            tlog.Debug(tag, $"RotationSubtraction END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Rotation UnaryNegation.")]
        [Property("SPEC", "Tizen.NUI.Rotation.UnaryNegation M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void RotationUnaryNegation()
        {
            tlog.Debug(tag, $"RotationUnaryNegation START");

            Rotation testingTarget = null;
            using (Rotation rotation = new Rotation(new Radian(new Degree(180.0f)), new Vector3(0.0f, 1.0f, 0.0f)))
            {
                testingTarget = -rotation;

                Radian radian = new Radian(0.0f);
                Vector3  axis = new Vector3();
                testingTarget.GetAxisAngle(axis, radian);

                Assert.AreEqual(0.0f, axis.X, "UnaryNegation function does not work, Vector3.X value is not correct");
                Assert.AreEqual(-1.0f, axis.Y, "UnaryNegation function does not work, Vector3.Y value is not correct");
                Assert.AreEqual(0.0f, axis.Z, "UnaryNegation function does not work, Vector3.Z value is not correct");

            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"RotationUnaryNegation END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Rotation Multiply. By Rotation.")]
        [Property("SPEC", "Tizen.NUI.Rotation.* M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "Rotation, Rotation")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void RotationMultiplyByRotation()
        {
            tlog.Debug(tag, $"RotationMultiplyByRotation START");

            using (Vector3 vector = new Vector3(0.0f, 0.0f, 0.0f))
            {
                Rotation rotation = new Rotation(new Radian(MyDot(vector, vector)), MyCross(vector, vector));

                Radian radian = new Radian(0.0f);
                Vector3  axis = new Vector3();
                rotation.GetAxisAngle(axis, radian);

                var testingTarget = new Rotation(new Radian(0.0f), vector);
                Assert.IsNotNull(testingTarget, "Can't create success object Rotation");
                Assert.IsInstanceOf<Rotation>(testingTarget, "Should return Rotation instance.");

                using (Rotation multiplier = new Rotation(new Radian(0.0f), vector))
                {
                    var result = testingTarget * multiplier;

                    Radian radian2 = new Radian(0.0f);
                    Vector3 axis2 = new Vector3();
                    result.GetAxisAngle(axis2, radian2);

                    Assert.AreEqual(float.Parse(axis2.X.ToString("F2")), float.Parse(axis.X.ToString("F2")), "Vector3 got from Multiply is not correct, X value is not correct");
                    Assert.AreEqual(float.Parse(axis2.Y.ToString("F2")), float.Parse(axis.Y.ToString("F2")), "Vector3 got from Multiply is not correct, Y value is not correct");
                    Assert.AreEqual(float.Parse(axis2.Z.ToString("F2")), float.Parse(axis.Z.ToString("F2")), "Vector3 got from Multiply is not correct, Z value is not correct");
                }

                rotation.Dispose();
                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"RotationMultiplyByRotation END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Rotation Multiply. By Vector3.")]
        [Property("SPEC", "Tizen.NUI.Rotation.* M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void RotationMultiplyByVector3()
        {
            tlog.Debug(tag, $"RotationMultiplyByVector3 START");

            using (Vector3 vector = new Vector3(0.0f, 0.0f, 0.0f))
            {
                using (Rotation rotation = new Rotation(new Radian(0.0f), Vector3.Zero))
                {
                    Rotation rotation1 = rotation;
                    rotation1.Invert();
                    Rotation rotation2 = new Rotation(new Radian(0.0f), vector);

                    var result = (rotation * rotation2) * rotation1;

                    Radian radian = new Radian(0.0f);
                    Vector3 axis = new Vector3();
                    result.GetAxisAngle(axis, radian);

                    var testingTarget = rotation * vector;
                    Assert.IsNotNull(testingTarget, "Can't create success object Vector3");
                    Assert.IsInstanceOf<Vector3>(testingTarget, "Should return Vector3 instance.");

                    Assert.AreEqual(testingTarget.X, float.Parse(axis.X.ToString("F2")), "Vector3 got from Multiply is not correct, X value is not correct");
                    Assert.AreEqual(testingTarget.Y, float.Parse(axis.Y.ToString("F2")), "Vector3 got from Multiply is not correct, Y value is not correct");
                    Assert.AreEqual(testingTarget.Z, float.Parse(axis.Z.ToString("F2")), "Vector3 got from Multiply is not correct, Z value is not correct");

                    rotation1.Dispose();
                    rotation2.Dispose();
                }
            }       

            tlog.Debug(tag, $"RotationMultiplyByVector3 END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Rotation Multiply. By Float.")]
        [Property("SPEC", "Tizen.NUI.Rotation.* M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void RotationMultiplyByFloat()
        {
            tlog.Debug(tag, $"RotationMultiplyByFloat START");

            var testingTarget = new Rotation(new Radian(new Degree(180)), new Vector3(1.0f, 0.0f, 0.0f));
            Assert.IsNotNull(testingTarget, "Can't create success object Rotation");
            Assert.IsInstanceOf<Rotation>(testingTarget, "Should return Rotation instance.");

            var result = testingTarget * 2.0f;
            
            Radian radian = new Radian(0.0f);
            Vector3  axis = new Vector3();
            result.GetAxisAngle(axis, radian);
            
            Assert.AreEqual(2.0f, float.Parse(axis.X.ToString("F2")), "Vector3 got from Multiply is not correct, X value is not correct");
            Assert.AreEqual(0.0f, float.Parse(axis.Y.ToString("F2")), "Vector3 got from Multiply is not correct, Y value is not correct");
            Assert.AreEqual(0.0f, float.Parse(axis.Z.ToString("F2")), "Vector3 got from Multiply is not correct, Z value is not correct");

            testingTarget.Dispose();
            tlog.Debug(tag, $"RotationMultiplyByFloat END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Rotation Division. By Rotation.")]
        [Property("SPEC", "Tizen.NUI.Rotation./ M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void RotationDivisionByRotation()
        {
            tlog.Debug(tag, $"RotationDivisionByRotation START");

            var testingTarget = new Rotation(new Radian(2.35551f), new Vector3(0.0f, 0.0f, 1.00027f));
            Assert.IsNotNull(testingTarget, "Can't create success object Rotation");
            Assert.IsInstanceOf<Rotation>(testingTarget, "Should return Rotation instance.");

            using (Rotation rotation = new Rotation(new Radian(3.14159f), new Vector3(0.609f, 0.0f, 0.793f)))
            {
                var result = testingTarget / rotation;

                Radian radian = new Radian(0.0f);
                Vector3 axis = new Vector3();
                result.GetAxisAngle(axis, radian);

                Assert.AreEqual(-0.34f, float.Parse(axis.X.ToString("F2")), "Should be equal!");
                Assert.AreEqual(-0.83f, float.Parse(axis.Y.ToString("F2")), "Should be equal!");
                Assert.AreEqual(-0.45f, float.Parse(axis.Z.ToString("F2")), "Should be equal!");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"RotationDivisionByRotation END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Rotation Division.")]
        [Property("SPEC", "Tizen.NUI.Rotation./ M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void RotationDivisionByFloat()
        {
            tlog.Debug(tag, $"RotationDivisionByFloat START");

            var testingTarget = new Rotation(new Radian(new Degree(180.0f)), new Vector3(0.0f, 1.0f, 0.0f));
            Assert.IsNotNull(testingTarget, "Can't create success object Rotation");
            Assert.IsInstanceOf<Rotation>(testingTarget, "Should return Rotation instance.");

            var result = testingTarget / 2.0f;
            Radian radian = new Radian(0.0f);
            Vector3  axis = new Vector3();

            result.GetAxisAngle(axis, radian);
            Assert.AreEqual(0.0f, axis.X, "Division function does not work, Vector3.X value is not correct");
            Assert.AreEqual(0.5f, axis.Y, "Division function does not work, Vector3.Y value is not correct");
            Assert.AreEqual(0.0f, axis.Z, "Division function does not work, Vector3.Z value is not correct");

            testingTarget.Dispose();
            tlog.Debug(tag, $"RotationDivisionByFloat END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Rotation constructor.")]
        [Property("SPEC", "Tizen.NUI.Rotation.Rotation C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void RotationConstructor()
        {
            tlog.Debug(tag, $"RotationConstructor START");

            var testingTarget = new Rotation();
            Assert.IsNotNull(testingTarget, "Can't create success object Rotation");
            Assert.IsInstanceOf<Rotation>(testingTarget, "Should return Rotation instance.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"RotationConstructor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Rotation constructor. With Radian and Vector3.")]
        [Property("SPEC", "Tizen.NUI.Rotation.Rotation C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void RotationConstructorWithRadianAndVector3()
        {
            tlog.Debug(tag, $"RotationConstructorWithRadianAndVector3 START");

            var testingTarget = new Rotation(new Radian(6.0f), new Vector3(1.0f, 2.0f, 3.0f));
            Assert.IsNotNull(testingTarget, "Can't create success object Rotation");
            Assert.IsInstanceOf<Rotation>(testingTarget, "Should return Rotation instance.");

            Radian radian = new Radian(0.0f);
            Vector3  axis = new Vector3();
            testingTarget.GetAxisAngle(axis, radian);

            Assert.AreEqual(0.27f, float.Parse(axis.X.ToString("F2")), "Vector3 parameter got from constructor is not correct, X value is not correct");
            Assert.AreEqual(0.53f, float.Parse(axis.Y.ToString("F2")), "Vector3 parameter got from constructor is not correct, Y value is not correct");
            Assert.AreEqual(0.80f, float.Parse(axis.Z.ToString("F2")), "Vector3 parameter got from constructor is not correct, Z value is not correct");

            testingTarget.Dispose();
            tlog.Debug(tag, $"RotationConstructorWithRadianAndVector3 END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Rotation IDENTITY.")]
        [Property("SPEC", "Tizen.NUI.Rotation.IDENTITY A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void RotationIDENTITY()
        {
            tlog.Debug(tag, $"RotationIDENTITY START");

            Rotation rotation = new Rotation(new Radian(0.0f), new Vector3(1.0f, 1.0f, 1.0f));
            Radian radian = new Radian(0.0f);
            Vector3  axis = new Vector3();
            rotation.GetAxisAngle(axis, radian);
            
            var testingTarget = Rotation.IDENTITY;
            Assert.IsNotNull(testingTarget, "Can't create success object Rotation");
            Assert.IsInstanceOf<Rotation>(testingTarget, "Should return Rotation instance.");

            Radian radian2 = new Radian(0.0f);
            Vector3  axis2 = new Vector3();
            testingTarget.GetAxisAngle(axis2, radian2);

            Assert.AreEqual(float.Parse(axis2.X.ToString("F2")), float.Parse(axis.X.ToString("F2")), "Vector3 got from IDENTITY is not correct, X value is not correct");
            Assert.AreEqual(float.Parse(axis2.X.ToString("F2")), float.Parse(axis.Y.ToString("F2")), "Vector3 got from IDENTITY is not correct, Y value is not correct");
            Assert.AreEqual(float.Parse(axis2.X.ToString("F2")), float.Parse(axis.Z.ToString("F2")), "Vector3 got from IDENTITY is not correct, Z value is not correct");

            rotation.Dispose();
            testingTarget.Dispose();
            tlog.Debug(tag, $"RotationIDENTITY END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Rotation IsIdentity.")]
        [Property("SPEC", "Tizen.NUI.Rotation.IsIdentity M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void RotationIsIdentity()
        {
            tlog.Debug(tag, $"RotationIsIdentity START");

            using (Rotation testingTarget = Rotation.IDENTITY)
            {
                Assert.IsTrue(testingTarget.IsIdentity(), "IsIdentity should return true!");
            }

            using (Rotation testingTarget = new Rotation(new Radian(90.0f), new Vector3(0.1f, 0.0f, 0.0f)))
            {
                Assert.IsFalse(testingTarget.IsIdentity(), "IsIdentity should return false!");
            }

            tlog.Debug(tag, $"RotationIsIdentity END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Rotation GetAxisAngle.")]
        [Property("SPEC", "Tizen.NUI.Rotation.GetAxisAngle M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void RotationGetAxisAngle()
        {
            tlog.Debug(tag, $"RotationGetAxisAngle START");

            var testingTarget = new Rotation(new Radian(6.0f), new Vector3(1.0f, 2.0f, 3.0f));
            Assert.IsNotNull(testingTarget, "Can't create success object Rotation");
            Assert.IsInstanceOf<Rotation>(testingTarget, "Should return Rotation instance.");

            Radian radian = new Radian(0.0f);
            Vector3  axis = new Vector3();
            testingTarget.GetAxisAngle(axis, radian);

            Assert.AreEqual(0.27f, float.Parse(axis.X.ToString("F2")), "Vector3 got from GetAxisAngle is not correct, X value is not correct");
            Assert.AreEqual(0.53f, float.Parse(axis.Y.ToString("F2")), "Vector3 got from GetAxisAngle is not correct, Y value is not correct");
            Assert.AreEqual(0.80f, float.Parse(axis.Z.ToString("F2")), "Vector3 got from GetAxisAngle is not correct, Z value is not correct");

            testingTarget.Dispose();
            tlog.Debug(tag, $"RotationGetAxisAngle END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Rotation Length.")]
        [Property("SPEC", "Tizen.NUI.Rotation.Length M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void RotationLength()
        {
            tlog.Debug(tag, $"RotationLength START");

            var testingTarget = new Rotation(new Radian(new Degree(90)), new Vector3(1.0f, 2.0f, 3.0f));
            Assert.IsNotNull(testingTarget, "Can't create success object Rotation");
            Assert.IsInstanceOf<Rotation>(testingTarget, "Should return Rotation instance.");

            double a = Math.Sqrt(0.707f * 0.707f + 0.189f * 0.189f + 0.378f * 0.378f + 0.567f * 0.567f);
            
            var result = testingTarget.Length();
            Assert.AreEqual(float.Parse(a.ToString("F2")), float.Parse(result.ToString("F2")), "Length function return incorrect value");

            testingTarget.Dispose();
            tlog.Debug(tag, $"RotationLength END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Rotation LengthSquared.")]
        [Property("SPEC", "Tizen.NUI.Rotation.LengthSquared M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void RotationLengthSquared()
        {
            tlog.Debug(tag, $"RotationLengthSquared START");

            var testingTarget = new Rotation(new Radian(new Degree(90)), new Vector3(1.0f, 2.0f, 3.0f));
            Assert.IsNotNull(testingTarget, "Can't create success object Rotation");
            Assert.IsInstanceOf<Rotation>(testingTarget, "Should return Rotation instance.");

            double a = 0.707f * 0.707f + 0.189f * 0.189f + 0.378f * 0.378f + 0.567f * 0.567f;
            
            var result = testingTarget.LengthSquared();
            Assert.AreEqual(float.Parse(a.ToString("F2")), float.Parse(result.ToString("F2")), "LengthSquared function return incorrect value");

            testingTarget.Dispose();
            tlog.Debug(tag, $"RotationLengthSquared END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Rotation Normalize.")]
        [Property("SPEC", "Tizen.NUI.Rotation.Normalize M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void RotationNormalize()
        {
            tlog.Debug(tag, $"RotationNormalize START");

            var testingTarget = new Rotation(new Radian(6.0f), new Vector3(1.0f, 2.0f, 3.0f));
            Assert.IsNotNull(testingTarget, "Can't create success object Rotation");
            Assert.IsInstanceOf<Rotation>(testingTarget, "Should return Rotation instance.");

            testingTarget.Normalize();

            Radian radian = new Radian(0.0f);
            Vector3  axis = new Vector3();
            testingTarget.GetAxisAngle(axis, radian);

            Assert.AreEqual(0.27f, float.Parse(axis.X.ToString("F2")), "Vector3 got from Normalize is not correct, X value is not correct");
            Assert.AreEqual(0.53f, float.Parse(axis.Y.ToString("F2")), "Vector3 got from Normalize is not correct, Y value is not correct");
            Assert.AreEqual(0.80f, float.Parse(axis.Z.ToString("F2")), "Vector3 got from Normalize is not correct, Z value is not correct");

            testingTarget.Dispose();
            tlog.Debug(tag, $"RotationNormalize END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Rotation Normalized.")]
        [Property("SPEC", "Tizen.NUI.Rotation.Normalized M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void RotationNormalized()
        {
            tlog.Debug(tag, $"RotationNormalized START");

            Rotation rotation = new Rotation(new Radian(6.0f), new Vector3(1.0f, 2.0f, 3.0f));
            
            Radian radian = new Radian(0.0f);
            Vector3  axis = new Vector3();
            rotation.GetAxisAngle(axis, radian);
            
            Assert.AreEqual(0.27f, float.Parse(axis.X.ToString("F2")), "X value is not correct");
            Assert.AreEqual(0.53f, float.Parse(axis.Y.ToString("F2")), "Y value is not correct");
            Assert.AreEqual(0.80f, float.Parse(axis.Z.ToString("F2")), "Z value is not correct");
            
            var testingTarget = rotation * 5.0f;
            Assert.IsNotNull(testingTarget, "Can't create success object Rotation");
            Assert.IsInstanceOf<Rotation>(testingTarget, "Should return Rotation instance.");

            var result = testingTarget.Normalized();
            Radian radian2 = new Radian(0.0f);
            Vector3  axis2 = new Vector3();
            result.GetAxisAngle(axis2, radian2);

            Assert.AreEqual(0.27f, float.Parse(axis2.X.ToString("F2")), "X value got from Normalized is not correct");
            Assert.AreEqual(0.53f, float.Parse(axis2.Y.ToString("F2")), "Y value got from Normalized is not correct");
            Assert.AreEqual(0.80f, float.Parse(axis2.Z.ToString("F2")), "Z value got from Normalized is not correct");

            rotation.Dispose();
            testingTarget.Dispose();
            tlog.Debug(tag, $"RotationNormalized END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Rotation Conjugate.")]
        [Property("SPEC", "Tizen.NUI.Rotation.Conjugate M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void RotationConjugate()
        {
            tlog.Debug(tag, $"RotationConjugate START");

            var testingTarget = new Rotation(new Radian(6.0f), new Vector3(1.0f, 2.0f, 3.0f));
            Assert.IsNotNull(testingTarget, "Can't create success object Rotation");
            Assert.IsInstanceOf<Rotation>(testingTarget, "Should return Rotation instance.");

            Radian radian = new Radian(0.0f);
            Vector3  axis = new Vector3();
            testingTarget.GetAxisAngle(axis, radian);

            Assert.AreEqual(0.27f, float.Parse(axis.X.ToString("F2")), "X value is not correct");
            Assert.AreEqual(0.53f, float.Parse(axis.Y.ToString("F2")), "Y value is not correct");
            Assert.AreEqual(0.80f, float.Parse(axis.Z.ToString("F2")), "Z value is not correct");
            
            testingTarget.Conjugate();
            
            Radian radian2 = new Radian(0.0f);
            Vector3  axis2 = new Vector3();
            testingTarget.GetAxisAngle(axis2, radian2);

            Assert.AreEqual(-0.27f, float.Parse(axis2.X.ToString("F2")), "X value got from Conjugate is not correct");
            Assert.AreEqual(-0.53f, float.Parse(axis2.Y.ToString("F2")), "Y value got from Conjugate is not correct");
            Assert.AreEqual(-0.80f, float.Parse(axis2.Z.ToString("F2")), "Z value got from Conjugate is not correct");

            testingTarget.Dispose();
            tlog.Debug(tag, $"RotationConjugate END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Rotation Invert.")]
        [Property("SPEC", "Tizen.NUI.Rotation.Invert M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void RotationInvert()
        {
            tlog.Debug(tag, $"RotationInvert START");

            var testingTarget = new Rotation(new Radian(0.0f), new Vector3(0.0f, 0.0f, 0.0f)); //radian: 2.355f z: -1.0f
            Assert.IsNotNull(testingTarget, "Can't create success object Rotation");
            Assert.IsInstanceOf<Rotation>(testingTarget, "Should return Rotation instance.");

            Rotation testingTargetConjugate = testingTarget;

            testingTargetConjugate.Conjugate();
            testingTargetConjugate *= 1.0f / testingTarget.LengthSquared();

            Radian radian = new Radian(0.0f);
            Vector3  axis = new Vector3();
            testingTargetConjugate.GetAxisAngle(axis, radian);

            Rotation testingTargetInvert = testingTarget;
            testingTargetInvert.Invert();

            Radian radian2 = new Radian(0.0f);
            Vector3  axis2 = new Vector3();
            testingTargetInvert.GetAxisAngle(axis2, radian2);

            Assert.AreEqual(float.Parse(axis2.X.ToString("F2")), float.Parse(axis.X.ToString("F2")), "Invert function does not work, X value is not correct");
            Assert.AreEqual(float.Parse(axis2.Y.ToString("F2")), float.Parse(axis.Y.ToString("F2")), "Invert function does not work, Y value is not correct");
            Assert.AreEqual(float.Parse(axis2.Z.ToString("F2")), float.Parse(axis.Z.ToString("F2")), "Invert function does not work, Z value is not correct");

            testingTarget.Dispose();
            tlog.Debug(tag, $"RotationInvert END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Rotation Log.")]
        [Property("SPEC", "Tizen.NUI.Rotation.Log M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void RotationLog()
        {
            tlog.Debug(tag, $"RotationLog START");

            using (Rotation rotation = new Rotation(new Radian(2.29f), new Vector3(0.0f, 0.0f, 0.0f)))
            {
                Rotation normalize = rotation;
                normalize.Normalize();
                Radian radian = new Radian(0.0f);
                Vector3 axis = new Vector3();
                normalize.GetAxisAngle(axis, radian);

                using (Rotation testingTarget = normalize.Log())
                {
                    using (Rotation exp = testingTarget.Exp())
                    {
                        Radian radian2 = new Radian(0.0f);
                        Vector3 axis2 = new Vector3();
                        exp.GetAxisAngle(axis2, radian2);

                        Assert.AreEqual(float.Parse(axis.X.ToString("F2")), float.Parse(axis2.X.ToString("F2")), "Log function does not wrok, X value is not correct");
                        Assert.AreEqual(float.Parse(axis.Y.ToString("F2")), float.Parse(axis2.Y.ToString("F2")), "Log function does not wrok, Y value is not correct");
                        Assert.AreEqual(float.Parse(axis.Z.ToString("F2")), float.Parse(axis2.Z.ToString("F2")), "Log function does not wrok, Z value is not correct");
                    }
                }
            }

            tlog.Debug(tag, $"RotationLog END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Rotation Exp.")]
        [Property("SPEC", "Tizen.NUI.Rotation.Exp M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void RotationExp()
        {
            tlog.Debug(tag, $"Rotation START");

            using (Rotation rotation = new Rotation(new Radian(2.29f), new Vector3(0.0f, 0.0f, 0.0f)))
            {
                Rotation normalize = rotation;
                normalize.Normalize();
                Radian radian = new Radian(0.0f);
                Vector3 axis = new Vector3();
                normalize.GetAxisAngle(axis, radian);

                using (Rotation log = normalize.Log())
                {
                    using (Rotation testingTarget = log.Exp())
                    {
                        Radian radian2 = new Radian(0.0f);
                        Vector3 axis2 = new Vector3();
                        testingTarget.GetAxisAngle(axis2, radian2);

                        Assert.AreEqual(float.Parse(axis.X.ToString("F2")), float.Parse(axis2.X.ToString("F2")), "Log function does not wrok, X value is not correct");
                        Assert.AreEqual(float.Parse(axis.Y.ToString("F2")), float.Parse(axis2.Y.ToString("F2")), "Log function does not wrok, Y value is not correct");
                        Assert.AreEqual(float.Parse(axis.Z.ToString("F2")), float.Parse(axis2.Z.ToString("F2")), "Log function does not wrok, Z value is not correct");
                    }
                }
            }

            tlog.Debug(tag, $"Rotation END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Rotation Dot.")]
        [Property("SPEC", "Tizen.NUI.Rotation.Dot M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void RotationDot()
        {
            tlog.Debug(tag, $"RotationDot START");

            Rotation rotation1 = new Rotation(new Radian(1.339f), new Vector3(0.072f, 0.713f, 0.695f));
            Rotation rotation2 = new Rotation(new Radian(1.599f), new Vector3(0.853f, 0.479f, -0.200f));

            float val = 0.784f * 0.697f + MyDot(new Vector3(0.045f, 0.443f, 0.432f), new Vector3(0.612f, 0.344f, -0.144f));
            
            var result = Rotation.Dot(rotation1, rotation2);

            Assert.AreEqual(float.Parse(result.ToString("F2")), float.Parse(val.ToString("F2")), "Dot function does not wrok");

            rotation1.Dispose();
            rotation2.Dispose();
            tlog.Debug(tag, $"RotationDot END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Rotation Lerp.")]
        [Property("SPEC", "Tizen.NUI.Rotation.Lerp M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void RotationLerp()
        {
            tlog.Debug(tag, $"RotationLerp START");

            Rotation rotation1 = new Rotation(new Radian(new Degree(-80.0f)), new Vector3(0.0f, 0.0f, 1.0f));
            Rotation rotation2 = new Rotation(new Radian(new Degree(80.0f)), new Vector3(0.0f, 0.0f, 1.0f));
            
            Radian radian = new Radian(0.0f);
            Vector3  axis = new Vector3();
            rotation2.GetAxisAngle(axis, radian);

            var testingTarget  = Rotation.Lerp(rotation1, rotation2, 1.0f);
            Assert.IsNotNull(testingTarget, "Can't create success object Rotation");
            Assert.IsInstanceOf<Rotation>(testingTarget, "Should return Rotation instance.");

            Radian radian2 = new Radian(0.0f);
            Vector3  axis2 = new Vector3();
            testingTarget.GetAxisAngle(axis2, radian2);

            Assert.AreEqual(float.Parse(axis.X.ToString("F2")), float.Parse(axis2.X.ToString("F2")), "Lerp function does not wrok, X value is not correct");
            Assert.AreEqual(float.Parse(axis.Y.ToString("F2")), float.Parse(axis2.Y.ToString("F2")), "Lerp function does not wrok, Y value is not correct");
            Assert.AreEqual(float.Parse(axis.Z.ToString("F2")), float.Parse(axis2.Z.ToString("F2")), "Lerp function does not wrok, Z value is not correct");

            rotation1.Dispose();
            rotation2.Dispose();
            testingTarget.Dispose();
            tlog.Debug(tag, $"RotationLerp END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Rotation Slerp.")]
        [Property("SPEC", "Tizen.NUI.Rotation.Slerp M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void RotationSlerp()
        {
            tlog.Debug(tag, $"RotationSlerp START");

            Rotation rotation1 = new Rotation(new Radian(new Degree(120.0f)), new Vector3(0.0f, 0.0f, 1.0f));
            Rotation rotation2 = new Rotation(new Radian(new Degree(130.0f)), new Vector3(0.0f, 0.0f, 1.0f));
            
            Radian radia = new Radian(0.0f);
            Vector3 axis = new Vector3();
            rotation2.GetAxisAngle(axis, radia);
            
            var testingTarget = Rotation.Slerp(rotation1, rotation2, 1.0f);
            Assert.IsNotNull(testingTarget, "Can't create success object Rotation");
            Assert.IsInstanceOf<Rotation>(testingTarget, "Should return Rotation instance.");

            Radian radia2 = new Radian(0.0f);
            Vector3 axis2 = new Vector3();
            testingTarget.GetAxisAngle(axis2, radia2);
            
            Assert.AreEqual(float.Parse(axis.X.ToString("F2")), float.Parse(axis2.X.ToString("F2")), "Slerp function does not wrok, X value is not correct");
            Assert.AreEqual(float.Parse(axis.Y.ToString("F2")), float.Parse(axis2.Y.ToString("F2")), "Slerp function does not wrok, Y value is not correct");
            Assert.AreEqual(float.Parse(axis.Z.ToString("F2")), float.Parse(axis2.Z.ToString("F2")), "Slerp function does not wrok, Z value is not correct");

            rotation1.Dispose();
            rotation2.Dispose();
            testingTarget.Dispose();
            tlog.Debug(tag, $"RotationSlerp END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Rotation SlerpNoInvert.")]
        [Property("SPEC", "Tizen.NUI.Rotation.SlerpNoInvert M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void RotationSlerpNoInvert()
        {
            tlog.Debug(tag, $"RotationSlerpNoInvert START");

            Rotation rotation1 = new Rotation(new Radian(new Degree(120.0f)), new Vector3(0.0f, 0.0f, 1.0f));
            Radian radian1 = new Radian(0.0f);
            Vector3  axis1 = new Vector3();
            rotation1.GetAxisAngle(axis1, radian1);
            
            Rotation rotation2 = new Rotation(new Radian(new Degree(130.0f)), new Vector3(0.0f, 0.0f, 1.0f));
            Radian radian2 = new Radian(0.0f);
            Vector3  axis2 = new Vector3();
            rotation2.GetAxisAngle(axis2, radian2);
            
            var testingTarget = Rotation.SlerpNoInvert(rotation1, rotation2, 0.0f);
            Radian radian3 = new Radian(0.0f);
            Vector3  axis3 = new Vector3();
            testingTarget.GetAxisAngle(axis3, radian3);
            Assert.AreEqual(axis1.X, axis3.X, "SlerpNoInvert function does not wrok, X value is not correct");
            Assert.AreEqual(axis1.Y, axis3.Y, "SlerpNoInvert function does not wrok, Y value is not correct");
            Assert.AreEqual(axis1.Z, axis3.Z, "SlerpNoInvert function does not wrok, Z value is not correct");

            testingTarget = Rotation.SlerpNoInvert(rotation1, rotation2, 1.0f);
            testingTarget.GetAxisAngle(axis3, radian3);
            Assert.AreEqual(axis2.X, axis3.X, "SlerpNoInvert function does not wrok, X value is not correct");
            Assert.AreEqual(axis2.Y, axis3.Y, "SlerpNoInvert function does not wrok, Y value is not correct");
            Assert.AreEqual(axis2.Z, axis3.Z, "SlerpNoInvert function does not wrok, Z value is not correct");

            rotation1.Dispose();
            rotation2.Dispose();
            testingTarget.Dispose();
            tlog.Debug(tag, $"RotationSlerpNoInvert END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Rotation Squad.")]
        [Property("SPEC", "Tizen.NUI.Rotation.Squad M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void RotationSquad()
        {
            tlog.Debug(tag, $"RotationSquad START");

            Rotation start = new Rotation(new Radian(new Degree(45.0f)), new Vector3(0.0f, 0.0f, 1.0f));
            Rotation   end = new Rotation(new Radian(new Degree(30.0f)), new Vector3(0.0f, 1.0f, 3.0f));
            Rotation ctrl1 = new Rotation(new Radian(new Degree(40.0f)), new Vector3(0.0f, 1.0f, 2.0f));
            Rotation ctrl2 = new Rotation(new Radian(new Degree(35.0f)), new Vector3(0.0f, 2.0f, 3.0f));
            
            var testingTarget  = Rotation.Squad(start, end, ctrl1, ctrl2, 0.0f);
            Assert.IsNotNull(testingTarget, "Can't create success object Rotation");
            Assert.IsInstanceOf<Rotation>(testingTarget, "Should return Rotation instance.");

            Radian radian1 = new Radian(0.0f);
            Vector3  axis1 = new Vector3();
            start.GetAxisAngle(axis1, radian1);

            Radian radian2 = new Radian(0.0f);
            Vector3  axis2 = new Vector3();
            end.GetAxisAngle(axis2, radian2);

            Radian radian3 = new Radian(0.0f);
            Vector3  axis3 = new Vector3();
            testingTarget.GetAxisAngle(axis3, radian3);

            Assert.AreEqual(axis3.X, axis1.X, "Squad function does not wrok, X value is not correct");
            Assert.AreEqual(axis3.Y, axis1.Y, "Squad function does not wrok, Y value is not correct");
            Assert.AreEqual(axis3.Z, axis1.Z, "Squad function does not wrok, Z value is not correct");
            
            testingTarget = Rotation.Squad(start, end, ctrl1, ctrl2, 1.0f);

            testingTarget.GetAxisAngle(axis3, radian3);
            
            Assert.AreEqual(axis3.X, axis2.X, "Squad function does not wrok, X value is not correct");
            Assert.AreEqual(axis3.Y, axis2.Y, "Squad function does not wrok, Y value is not correct");
            Assert.AreEqual(axis3.Z, axis2.Z, "Squad function does not wrok, Z value is not correct");

            testingTarget.Dispose();
            tlog.Debug(tag, $"RotationSquad END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Rotation AngleBetween.")]
        [Property("SPEC", "Tizen.NUI.Rotation.AngleBetween M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void RotationAngleBetween()
        {
            tlog.Debug(tag, $"RotationAngleBetween START");

            using (Radian radian1 = new Radian(new Degree(80.0f)))
            {
                Rotation rotation1 = new Rotation(radian1, Vector3.YAxis);
                using (Radian radian2 = new Radian(new Degree(90.0f)))
                {
                    Rotation rotation2 = new Rotation(radian2, Vector3.YAxis);

                    float value1 = Rotation.AngleBetween(rotation1, rotation2);
                    float value2 = (90.0f - 80.0f) * 3.14f / 180.0f;
                    Assert.AreEqual(float.Parse(value1.ToString("F2")), float.Parse(value2.ToString("F2")), "AngleBetween function does not work.");

                    rotation2.Dispose();
                }

                rotation1.Dispose();
            }

            tlog.Debug(tag, $"RotationAngleBetween END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Rotation Dispose.")]
        [Property("SPEC", "Tizen.NUI.Rotation.Dispose M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR MCST")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void RotationDispose()
        {
            tlog.Debug(tag, $"RotationDispose START");

            try
            {
                using (Radian radian = new Radian(new Degree(80.0f)))
                {
                    var testingTarget = new Rotation(radian, Vector3.YAxis);
                    Assert.IsNotNull(testingTarget, "Can't create success object Rotation");
                    Assert.IsInstanceOf<Rotation>(testingTarget, "Should return Rotation instance.");

                    testingTarget.Dispose();
                }   
            }
            catch (Exception e)
            {
                Assert.Fail("Caught Exception" + e.ToString());
            }

            tlog.Debug(tag, $"RotationDispose END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Rotation Rotate.")]
        [Property("SPEC", "Tizen.NUI.Rotate. M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void RotationRotate()
        {
            tlog.Debug(tag, $"RotationRotate START");

            var testingTarget = new Rotation(new Radian(new Degree(180.0f)), new Vector3(1.0f, 0.0f, 0.0f));
            Assert.IsNotNull(testingTarget, "Can't create success object Rotation");
            Assert.IsInstanceOf<Rotation>(testingTarget, "Should return Rotation instance.");

            using (Vector3 vec = new Vector3(0.0f, 1.0f, 0.0f))
            {
                var result = testingTarget.Rotate(vec);
                Assert.IsNotNull(result, "Can't create success object Vector3");
                Assert.IsInstanceOf<Vector3>(result, "Should return Vector3 instance.");
            }
            
            testingTarget.Dispose();
            tlog.Debug(tag, $"RotationRotate END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Rotation Rotate.")]
        [Property("SPEC", "Tizen.NUI.Rotate. M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void RotationRotateWithVector4()
        {
            tlog.Debug(tag, $"RotationRotateWithVector4 START");

            var testingTarget = new Rotation(new Radian(new Degree(180.0f)), new Vector3(0.0f, 1.0f, 0.0f));
            Assert.IsNotNull(testingTarget, "Can't create success object Rotation");
            Assert.IsInstanceOf<Rotation>(testingTarget, "Should return Rotation instance.");

            using (Vector4 vec = new Vector4(1.0f, 0.0f, 0.0f, 0.0f))
            {
                var result = testingTarget.Rotate(vec);
                Assert.IsNotNull(result, "Can't create success object Vector4");
                Assert.IsInstanceOf<Vector4>(result, "Should return Vector4 instance.");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"RotationRotateWithVector4 END (OK)");
        }
    }
}
