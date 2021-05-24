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
    [Description("public/Common/RelativeVector3")]
    public class PublicRelativeVector3Test
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
        [Description("RelativeVector3 constructor.")]
        [Property("SPEC", "Tizen.NUI.RelativeVector3.RelativeVector3 C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void RelativeVector3Constructor()
        {
            tlog.Debug(tag, $"RelativeVector3Constructor START");

            var testingTarget = new RelativeVector3();
            Assert.IsNotNull(testingTarget, "Can't create success object RelativeVector3");
            Assert.IsInstanceOf<RelativeVector3>(testingTarget, "Should return Vector3 instance.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"RelativeVector3Constructor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("RelativeVector3 constructor. With Float.")]
        [Property("SPEC", "Tizen.NUI.RelativeVector3.RelativeVector3 C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("COVPARAM", "Single, Single, Single")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void RelativeVector3ConstructorWithFloat()
        {
            tlog.Debug(tag, $"RelativeVector3ConstructorWithFloat START");

            var testingTarget = new RelativeVector3(0.5f, 0.6f, 0.7f);
            Assert.IsNotNull(testingTarget, "Can't create success object RelativeVector3");
            Assert.IsInstanceOf<RelativeVector3>(testingTarget, "Should return Vector3 instance.");
            
            Assert.AreEqual(0.5f, testingTarget.X, "Retrieved vector.X should be equal to set value");
            Assert.AreEqual(0.6f, testingTarget.Y, "Retrieved vector.Y should be equal to set value");
            Assert.AreEqual(0.7f, testingTarget.Z, "Retrieved vector.Z should be equal to set value");

            testingTarget.Dispose();
            tlog.Debug(tag, $"RelativeVector3ConstructorWithFloat END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("RelativeVector3 constructor. With RelativeVector2.")]
        [Property("SPEC", "Tizen.NUI.RelativeVector3.RelativeVector3 C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("COVPARAM", "RelativeVector2")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void RelativeVector3ConstructorWithRelativeVector2()
        {
            tlog.Debug(tag, $"RelativeVector3ConstructorWithRelativeVector2 START");

            using (RelativeVector2 vec2 = new RelativeVector2(0.5f, 0.6f))
            {
                var testingTarget = new RelativeVector3(vec2);
                Assert.IsNotNull(testingTarget, "Can't create success object RelativeVector3");
                Assert.IsInstanceOf<RelativeVector3>(testingTarget, "Should return Vector3 instance.");

                Assert.AreEqual(0.5f, testingTarget.X, "Retrieved vector.X should be equal to set value");
                Assert.AreEqual(0.6f, testingTarget.Y, "Retrieved vector.Y should be equal to set value");
                Assert.AreEqual(0.0f, testingTarget.Z, "Retrieved vector.Z should be equal to set value");

                testingTarget.Dispose();
            }
 
            tlog.Debug(tag, $"RelativeVector3ConstructorWithRelativeVector2 END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("RelativeVector3 constructor. With RelativeVector4.")]
        [Property("SPEC", "Tizen.NUI.RelativeVector3.RelativeVector3 C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("COVPARAM", "RelativeVector4")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void RelativeVector3ConstructorWithRelativeVector4()
        {
            tlog.Debug(tag, $"RelativeVector3ConstructorWithRelativeVector4 START");

            using (RelativeVector4 vec4 = new RelativeVector4(0.5f, 0.6f, 0.7f, 0.8f))
            {
                var testingTarget = new RelativeVector3(vec4);
                Assert.IsNotNull(testingTarget, "Can't create success object RelativeVector3");
                Assert.IsInstanceOf<RelativeVector3>(testingTarget, "Should return Vector3 instance.");

                Assert.AreEqual(0.5f, testingTarget.X, "Retrieved vector.X should be equal to set value");
                Assert.AreEqual(0.6f, testingTarget.Y, "Retrieved vector.Y should be equal to set value");
                Assert.AreEqual(0.7f, testingTarget.Z, "Retrieved vector.Z should be equal to set value");

                testingTarget.Dispose();
            }
                
            tlog.Debug(tag, $"RelativeVector3ConstructorWithRelativeVector4 END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("RelativeVector3 this[uint index].")]
        [Property("SPEC", "Tizen.NUI.RelativeVector3.this[uint] A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void RelativeVector3GetVauleBySubscriptIndex()
        {
            tlog.Debug(tag, $"RelativeVector3GetVauleBySubscriptIndex START");

            var testingTarget = new RelativeVector3(0.5f, 0.6f, 0.7f);
            Assert.IsNotNull(testingTarget, "Can't create success object RelativeVector3");
            Assert.IsInstanceOf<RelativeVector3>(testingTarget, "Should be an instance of RelativeVector3 type.");

            Assert.AreEqual(0.5f, testingTarget[0], "The value of index[0] is not correct!");
            Assert.AreEqual(0.6f, testingTarget[1], "The value of index[1] is not correct!");
            Assert.AreEqual(0.7f, testingTarget[2], "The value of index[2] is not correct!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"RelativeVector3GetVauleBySubscriptIndex END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("RelativeVector3 EqualTo.")]
        [Property("SPEC", "Tizen.NUI.RelativeVector3.EqualTo M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void RelativeVector3EqualTo()
        {
            tlog.Debug(tag, $"RelativeVector3EqualTo START");

            var testingTarget = new RelativeVector3(1.0f, 0.5f, 0.4f);
            Assert.IsNotNull(testingTarget, "Can't create success object RelativeVector3");
            Assert.IsInstanceOf<RelativeVector3>(testingTarget, "Should be an instance of RelativeVector3 type.");

            using (RelativeVector3 vector = new RelativeVector3(1.0f, 0.5f, 0.4f))
            {
                Assert.IsTrue((testingTarget.EqualTo(vector)), "Should be equal");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"RelativeVector3EqualTo END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("RelativeVector3 NotEqualTo.")]
        [Property("SPEC", "Tizen.NUI.RelativeVector3.NotEqualTo M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void RelativeVector3NotEqualTo()
        {
            tlog.Debug(tag, $"RelativeVector3NotEqualTo START");

            var testingTarget = new RelativeVector3(1.0f, 0.5f, 0.4f);
            Assert.IsNotNull(testingTarget, "Can't create success object RelativeVector3");
            Assert.IsInstanceOf<RelativeVector3>(testingTarget, "Should be an instance of RelativeVector3 type.");

            using (RelativeVector3 vector = new RelativeVector3(1.0f, 0.5f, 0.6f))
            {
                Assert.IsTrue((testingTarget.NotEqualTo(vector)), "Should be equal");

            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"RelativeVector3NotEqualTo END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("RelativeVector3 X.")]
        [Property("SPEC", "Tizen.NUI.RelativeVector3.X A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void RelativeVector3GetX()
        {
            tlog.Debug(tag, $"RelativeVector3GetX START");

            var testingTarget = new RelativeVector3(0.5f, 0.6f, 0.7f);
            Assert.IsNotNull(testingTarget, "Can't create success object RelativeVector3");
            Assert.IsInstanceOf<RelativeVector3>(testingTarget, "Should be an instance of RelativeVector3 type.");

            Assert.AreEqual(0.5f, testingTarget.X, "The X value of the vector is not correct!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"RelativeVector3GetX END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("RelativeVector3 Y.")]
        [Property("SPEC", "Tizen.NUI.RelativeVector3.Y A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void RelativeVector3GetY()
        {
            tlog.Debug(tag, $"RelativeVector3GetY START");

            var testingTarget = new RelativeVector3(0.5f, 0.6f, 0.7f);
            Assert.IsNotNull(testingTarget, "Can't create success object RelativeVector3");
            Assert.IsInstanceOf<RelativeVector3>(testingTarget, "Should be an instance of RelativeVector3 type.");

            Assert.AreEqual(0.6f, testingTarget.Y, "The Y value of the vector is not correct!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"RelativeVector3GetY END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("RelativeVector3 Z.")]
        [Property("SPEC", "Tizen.NUI.RelativeVector3.Z A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void RelativeVector3GetZ()
        {
            tlog.Debug(tag, $"RelativeVector3GetZ START");

            var testingTarget = new RelativeVector3(0.5f, 0.6f, 0.7f);
            Assert.IsNotNull(testingTarget, "Can't create success object RelativeVector3");
            Assert.IsInstanceOf<RelativeVector3>(testingTarget, "Should be an instance of RelativeVector3 type.");

            Assert.AreEqual(0.7f, testingTarget.Z, "The Z value of the vector is not correct!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"RelativeVector3GetZ END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("RelativeVector3 operator +.")]
        [Property("SPEC", "Tizen.NUI.RelativeVector3.+ M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void RelativeVector3Addition()
        {
            tlog.Debug(tag, $"RelativeVector3Addition START");

            var testingTarget = new RelativeVector3(0.5f, 0.6f, 0.7f);
            Assert.IsNotNull(testingTarget, "Can't create success object RelativeVector3");
            Assert.IsInstanceOf<RelativeVector3>(testingTarget, "Should be an instance of RelativeVector3 type.");

            using (RelativeVector3 vector = new RelativeVector3(0.4f, 0.3f, 0.2f))
            {
                var result = testingTarget + vector;
                Assert.Less(Math.Abs(0.9f - result.X), 0.0001f, "The X of the vector is not correct here!");
                Assert.Less(Math.Abs(0.9f - result.Y), 0.0001f, "The Y of the vector is not correct here!");
                Assert.Less(Math.Abs(0.9f - result.Z), 0.0001f, "The Z of the vector is not correct here!");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"RelativeVector3Addition END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("RelativeVector3 operator -.")]
        [Property("SPEC", "Tizen.NUI.RelativeVector3.- M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void RelativeVector3Subtraction()
        {
            tlog.Debug(tag, $"RelativeVector3Subtraction START");

            var testingTarget = new RelativeVector3(0.5f, 0.6f, 0.7f);
            Assert.IsNotNull(testingTarget, "Can't create success object RelativeVector3");
            Assert.IsInstanceOf<RelativeVector3>(testingTarget, "Should be an instance of RelativeVector3 type.");

            using (RelativeVector3 vector = new RelativeVector3(0.4f, 0.3f, 0.2f))
            {
                var result = testingTarget - vector;
                Assert.Less(Math.Abs(0.1f - result.X), 0.0001f, "The X of the vector is not correct here!");
                Assert.Less(Math.Abs(0.3f - result.Y), 0.0001f, "The Y of the vector is not correct here!");
                Assert.Less(Math.Abs(0.5f - result.Z), 0.0001f, "The Z of the vector is not correct here!");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"RelativeVector3Subtraction END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("RelativeVector3 operator *. By RelativeVector3.")]
        [Property("SPEC", "Tizen.NUI.RelativeVector3.* M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "RelativeVector3, RelativeVector3")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void RelativeVector3MultiplyByRelativeVector3()
        {
            tlog.Debug(tag, $"RelativeVector3MultiplyByRelativeVector3 START");

            var testingTarget = new RelativeVector3(0.5f, 0.6f, 0.7f);
            Assert.IsNotNull(testingTarget, "Can't create success object RelativeVector3");
            Assert.IsInstanceOf<RelativeVector3>(testingTarget, "Should be an instance of RelativeVector3 type.");

            using (RelativeVector3 vector = new RelativeVector3(0.4f, 0.3f, 0.2f))
            {
                var result = testingTarget * vector;
                Assert.Less(Math.Abs(0.2f - result.X), 0.0001f, "The X of the vector is not correct here!");
                Assert.Less(Math.Abs(0.18f - result.Y), 0.0001f, "The Y of the vector is not correct here!");
                Assert.Less(Math.Abs(0.14f - result.Z), 0.0001f, "The Z of the vector is not correct here!");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"RelativeVector3MultiplyByRelativeVector3 END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("RelativeVector3 operator *. By Float.")]
        [Property("SPEC", "Tizen.NUI.RelativeVector3.* M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "RelativeVector3, Single")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void RelativeVector3MultiplyByFloat()
        {
            tlog.Debug(tag, $"RelativeVector3MultiplyByFloat START");

            var testingTarget = new RelativeVector3(0.5f, 0.6f, 0.7f);
            Assert.IsNotNull(testingTarget, "Can't create success object RelativeVector3");
            Assert.IsInstanceOf<RelativeVector3>(testingTarget, "Should be an instance of RelativeVector3 type.");

            var result = testingTarget * 0.2f;
            Assert.Less(Math.Abs(0.1f - result.X), 0.0001f, "The X of the vector is not correct here!");
            Assert.Less(Math.Abs(0.12f - result.Y), 0.0001f, "The Y of the vector is not correct here!");
            Assert.Less(Math.Abs(0.14f - result.Z), 0.0001f, "The Z of the vector is not correct here!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"RelativeVector3MultiplyByFloat END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("RelativeVector3 operator /. By RelativeVector3.")]
        [Property("SPEC", "Tizen.NUI.RelativeVector3./ M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "RelativeVector3, RelativeVector3")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void RelativeVector3DivisionByRelativeVector3()
        {
            tlog.Debug(tag, $"RelativeVector3DivisionByRelativeVector3 START");

            var testingTarget = new RelativeVector3(0.5f, 0.6f, 0.7f);
            Assert.IsNotNull(testingTarget, "Can't create success object RelativeVector3");
            Assert.IsInstanceOf<RelativeVector3>(testingTarget, "Should be an instance of RelativeVector3 type.");

            using (RelativeVector3 vector = new RelativeVector3(1.0f, 0.6f, 0.7f))
            {
                var result = testingTarget / vector;
                Assert.Less(Math.Abs(0.5f - result.X), 0.0001f, "The X of the vector is not correct here!");
                Assert.Less(Math.Abs(1.0f - result.Y), 0.0001f, "The Y of the vector is not correct here!");
                Assert.Less(Math.Abs(1.0f - result.Z), 0.0001f, "The Z of the vector is not correct here!");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"RelativeVector3DivisionByRelativeVector3 END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("RelativeVector3 operator /. By Float.")]
        [Property("SPEC", "Tizen.NUI.RelativeVector3./ M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "RelativeVector3, Single")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void RelativeVector3DivisionByFloat()
        {
            tlog.Debug(tag, $"RelativeVector3DivisionByFloat START");

            var testingTarget = new RelativeVector3(0.5f, 0.6f, 0.7f);
            Assert.IsNotNull(testingTarget, "Can't create success object RelativeVector3");
            Assert.IsInstanceOf<RelativeVector3>(testingTarget, "Should be an instance of RelativeVector3 type.");

            var result = testingTarget / 10.0f;
            Assert.Less(Math.Abs(0.05f - result.X), 0.0001f, "The X of the vector is not correct here!");
            Assert.Less(Math.Abs(0.06f - result.Y), 0.0001f, "The Y of the vector is not correct here!");
            Assert.Less(Math.Abs(0.07f - result.Z), 0.0001f, "The Z of the vector is not correct here!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"RelativeVector3DivisionByFloat END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("RelativeVector3 Equals.")]
        [Property("SPEC", "Tizen.NUI.RelativeVector3.Equals M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void RelativeVector3Equals()
        {
            tlog.Debug(tag, $"RelativeVector3Equals START");

            var testingTarget = new RelativeVector3(0.02f, 0.02f, 0.02f);
            Assert.IsNotNull(testingTarget, "Can't create success object RelativeVector3");
            Assert.IsInstanceOf<RelativeVector3>(testingTarget, "Should be an instance of RelativeVector3 type.");

            using (RelativeVector3 vector = new RelativeVector3(0.02f, 0.02f, 0.02f))
            {
                var result = testingTarget.Equals(vector);
                Assert.IsTrue(result, "Should be true here!");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"RelativeVector3Equals END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("RelativeVector3 implicit. Convert Vector3 to RelativeVector3.")]
        [Property("SPEC", "Tizen.NUI.RelativeVector3.implicit M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "Vector3")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void RelativeVector3ImplicitToRelativeVector3()
        {
            tlog.Debug(tag, $"RelativeVector3ImplicitToRelativeVector3 START");

            RelativeVector3 testingTarget = null;
            using (Vector3 vector = new Vector3(0.5f, 0.6f, 0.7f))
            {
                testingTarget = vector;
                Assert.AreEqual(testingTarget.X, vector.X, "The value of X is not correct.");
                Assert.AreEqual(testingTarget.Y, vector.Y, "The value of Y is not correct.");
                Assert.AreEqual(testingTarget.Z, vector.Z, "The value of Z is not correct.");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"RelativeVector3ImplicitToRelativeVector3 END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("RelativeVector3 implicit. Convert RelativeVector3 to Vector3.")]
        [Property("SPEC", "Tizen.NUI.RelativeVector3.implicit M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void RelativeVector3ImplicitToVector3()
        {
            tlog.Debug(tag, $"RelativeVector3ImplicitToVector3 START");

            Vector3 testingTarget = null;
            using (RelativeVector3 relativeVector3 = new RelativeVector3(0.5f, 0.6f, 0.7f))
            {
                testingTarget = relativeVector3;
                Assert.AreEqual(relativeVector3.X, testingTarget.X, "The value of X is not correct.");
                Assert.AreEqual(relativeVector3.Y, testingTarget.Y, "The value of Y is not correct.");
                Assert.AreEqual(relativeVector3.Z, testingTarget.Z, "The value of Z is not correct.");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"RelativeVector3ImplicitToVector3 END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("RelativeVector3 Dispose.")]
        [Property("SPEC", "Tizen.NUI.RelativeVector3.Dispose M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR MCST")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void RelativeVector3Dispose()
        {
            tlog.Debug(tag, $"RelativeVector3Dispose START");

            RelativeVector3 testingTarget = new RelativeVector3(0.5f, 0.6f, 0.7f);
            Assert.IsNotNull(testingTarget, "Can't create success object RelativeVector3");
            Assert.IsInstanceOf<RelativeVector3>(testingTarget, "Should be an instance of RelativeVector3 type.");
            try
            {
                testingTarget.Dispose();
            }
            catch (Exception e)
            {
                Assert.Fail("Caught Exception" + e.ToString());
            }

            tlog.Debug(tag, $"RelativeVector3Dispose END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("RelativeVector3 GetHashCode.")]
        [Property("SPEC", "Tizen.NUI.RelativeVector3.GetHashCode M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void RelativeVector3GetHashCode()
        {
            tlog.Debug(tag, $"RelativeVector3GetHashCode START");

            var testingTarget = new RelativeVector3(0.5f, 0.6f, 0.7f);
            Assert.IsNotNull(testingTarget, "Can't create success object RelativeVector3");
            Assert.IsInstanceOf<RelativeVector3>(testingTarget, "Should be an instance of RelativeVector3 type.");

            var result = testingTarget.GetHashCode();
            Assert.IsTrue(result >= Int32.MinValue && result <= Int32.MaxValue, "The value of hash is out of Integer range");

            testingTarget.Dispose();
            tlog.Debug(tag, $"RelativeVector3GetHashCode END (OK)");
        }
    }
}
