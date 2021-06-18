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
    [Description("public/Common/RelativeVector4")]
    public class PublicRelativeVector4Test
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
        [Description("RelativeVector4 constructor.")]
        [Property("SPEC", "Tizen.NUI.RelativeVector4.RelativeVector4 C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void RelativeVector4Constructor()
        {
            tlog.Debug(tag, $"RelativeVector4Constructor START");

            var testingTarget = new RelativeVector4();
            Assert.IsNotNull(testingTarget, "Can't create success object RelativeVector4");
            Assert.IsInstanceOf<RelativeVector4>(testingTarget, "Should return Vector4 instance.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"RelativeVector4Constructor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("RelativeVector4 constructor. With Float.")]
        [Property("SPEC", "Tizen.NUI.RelativeVector4.RelativeVector4 C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("COVPARAM", "Single,Single,Single,Single")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void RelativeVector4ConstructorWithFloat()
        {
            tlog.Debug(tag, $"RelativeVector4ConstructorWithFloat START");

            var testingTarget = new RelativeVector4(0.5f, 0.6f, 0.7f, 0.8f);
            Assert.IsNotNull(testingTarget, "Can't create success object RelativeVector4");
            Assert.IsInstanceOf<RelativeVector4>(testingTarget, "Should return Vector4 instance.");
            
            Assert.AreEqual(0.5f, testingTarget.X, "Retrieved vector.X should be equal to set value");
            Assert.AreEqual(0.6f, testingTarget.Y, "Retrieved vector.Y should be equal to set value");
            Assert.AreEqual(0.7f, testingTarget.Z, "Retrieved vector.Z should be equal to set value");
            Assert.AreEqual(0.8f, testingTarget.W, "Retrieved vector.W should be equal to set value");

            testingTarget.Dispose();
            tlog.Debug(tag, $"RelativeVector4ConstructorWithFloat END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("RelativeVector4 constructor. With RelativeVector2.")]
        [Property("SPEC", "Tizen.NUI.RelativeVector4.RelativeVector4 C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("COVPARAM", "RelativeVector2")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void RelativeVector4ConstructorWithRelativeVector2()
        {
            tlog.Debug(tag, $"RelativeVector4ConstructorWithRelativeVector2 START");

            using (RelativeVector2 vector = new RelativeVector2(0.5f, 0.6f))
            {
                var testingTarget = new RelativeVector4(vector);
                Assert.IsNotNull(testingTarget, "Can't create success object RelativeVector4");
                Assert.IsInstanceOf<RelativeVector4>(testingTarget, "Should return Vector4 instance.");

                Assert.AreEqual(0.5f, testingTarget.X, "Retrieved vector.X should be equal to set value");
                Assert.AreEqual(0.6f, testingTarget.Y, "Retrieved vector.Y should be equal to set value");
                Assert.AreEqual(0.0f, testingTarget.Z, "Retrieved vector.Z should be equal to set value");
                Assert.AreEqual(0.0f, testingTarget.W, "Retrieved vector.W should be equal to set value");

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"RelativeVector4ConstructorWithRelativeVector2 END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("RelativeVector4 constructor. With RelativeVector3.")]
        [Property("SPEC", "Tizen.NUI.RelativeVector4.RelativeVector4 C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("COVPARAM", "RelativeVector3")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void RelativeVector4ConstructorWithRelativeVector3()
        {
            tlog.Debug(tag, $"RelativeVector4ConstructorWithRelativeVector3 START");

            using (RelativeVector3 vector = new RelativeVector3(0.5f, 0.6f, 0.7f))
            {
                var testingTarget = new RelativeVector4(vector);
                Assert.IsNotNull(testingTarget, "Can't create success object RelativeVector4");
                Assert.IsInstanceOf<RelativeVector4>(testingTarget, "Should return Vector4 instance.");
                
                Assert.AreEqual(0.5f, testingTarget.X, "Retrieved vector.X should be equal to set value");
                Assert.AreEqual(0.6f, testingTarget.Y, "Retrieved vector.Y should be equal to set value");
                Assert.AreEqual(0.7f, testingTarget.Z, "Retrieved vector.Z should be equal to set value");
                Assert.AreEqual(0.0f, testingTarget.W, "Retrieved vector.W should be equal to set value");

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"RelativeVector4ConstructorWithRelativeVector3 END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("RelativeVector4 this[uint index].")]
        [Property("SPEC", "Tizen.NUI.RelativeVector4.this[uint] A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void RelativeVector4GetVauleBySubscriptIndex()
        {
            tlog.Debug(tag, $"RelativeVector4GetVauleBySubscriptIndex START");

            var testingTarget = new RelativeVector4(0.5f, 0.6f, 0.7f, 0.8f);
            Assert.IsNotNull(testingTarget, "Can't create success object RelativeVector4");
            Assert.IsInstanceOf<RelativeVector4>(testingTarget, "Should return Vector4 instance.");

            Assert.AreEqual(0.5f, testingTarget[0], "this[0] should return 100.0f");
            Assert.AreEqual(0.6f, testingTarget[1], "this[1] should return 200.0f");
            Assert.AreEqual(0.7f, testingTarget[2], "this[2] should return 300.0f");
            Assert.AreEqual(0.8f, testingTarget[3], "this[3] should return 400.0f");

            testingTarget.Dispose();
            tlog.Debug(tag, $"RelativeVector4GetVauleBySubscriptIndex END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("RelativeVector4 EqualTo.")]
        [Property("SPEC", "Tizen.NUI.RelativeVector4.EqualTo M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void RelativeVector4EqualTo()
        {
            tlog.Debug(tag, $"RelativeVector4EqualTo START");

            var testingTarget = new RelativeVector4(1.0f, 0.5f, 0.4f, 0.3f);
            Assert.IsNotNull(testingTarget, "Can't create success object RelativeVector4");
            Assert.IsInstanceOf<RelativeVector4>(testingTarget, "Should return Vector4 instance.");

            using (RelativeVector4 vector = new RelativeVector4(1.0f, 0.5f, 0.4f, 0.3f))
            {
                Assert.IsTrue((testingTarget.EqualTo(vector)), "Should be equal");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"RelativeVector4EqualTo END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("RelativeVector4 NotEqualTo.")]
        [Property("SPEC", "Tizen.NUI.RelativeVector4.NotEqualTo M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void RelativeVector4NotEqualTo()
        {
            tlog.Debug(tag, $"RelativeVector4NotEqualTo START");

            var testingTarget = new RelativeVector4(1.0f, 0.5f, 0.4f, 0.3f);
            Assert.IsNotNull(testingTarget, "Can't create success object RelativeVector4");
            Assert.IsInstanceOf<RelativeVector4>(testingTarget, "Should return Vector4 instance.");

            using (RelativeVector4 vector = new RelativeVector4(1.0f, 0.5f, 0.6f, 0.7f))
            {
                Assert.IsTrue((testingTarget.NotEqualTo(vector)), "Should be equal");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"RelativeVector4NotEqualTo END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("RelativeVector4 X.")]
        [Property("SPEC", "Tizen.NUI.RelativeVector4.X A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        [Obsolete]
        public void RelativeVector4GetX()
        {
            tlog.Debug(tag, $"RelativeVector4GetX START");

            var testingTarget = new RelativeVector4(0.5f, 0.6f, 0.7f, 0.8f);
            Assert.IsNotNull(testingTarget, "Can't create success object RelativeVector4");
            Assert.IsInstanceOf<RelativeVector4>(testingTarget, "Should return Vector4 instance.");

            testingTarget.X = 0.6f;
            Assert.AreEqual(0.6f, testingTarget.X, "Should be equal!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"RelativeVector4GetX END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("RelativeVector4 Y.")]
        [Property("SPEC", "Tizen.NUI.RelativeVector4.Y A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        [Obsolete]
        public void RelativeVector4GetY()
        {
            tlog.Debug(tag, $"RelativeVector4GetY START");

            var testingTarget = new RelativeVector4(0.5f, 0.6f, 0.7f, 0.8f);
            Assert.IsNotNull(testingTarget, "Can't create success object RelativeVector4");
            Assert.IsInstanceOf<RelativeVector4>(testingTarget, "Should return Vector4 instance.");

            testingTarget.Y = 1.0f;
            Assert.AreEqual(1.0f, testingTarget.Y, "Should be equal!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"RelativeVector4GetY END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("RelativeVector4 Z.")]
        [Property("SPEC", "Tizen.NUI.RelativeVector4.Z A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        [Obsolete]
        public void RelativeVector4GetZ()
        {
            tlog.Debug(tag, $"RelativeVector4GetZ START");

            var testingTarget = new RelativeVector4(0.5f, 0.6f, 0.7f, 0.8f);
            Assert.IsNotNull(testingTarget, "Can't create success object RelativeVector4");
            Assert.IsInstanceOf<RelativeVector4>(testingTarget, "Should return Vector4 instance.");

            testingTarget.Z = 1.0f;
            Assert.AreEqual(1.0f, testingTarget.Z, "Should be equal!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"RelativeVector4GetZ END (OK)");
        }


        [Test]
        [Category("P1")]
        [Description("RelativeVector4 W.")]
        [Property("SPEC", "Tizen.NUI.RelativeVector4.W A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        [Obsolete]
        public void RelativeVector4GetW()
        {
            tlog.Debug(tag, $"RelativeVector4GetW START");

            var testingTarget = new RelativeVector4(0.5f, 0.6f, 0.7f, 0.8f);
            Assert.IsNotNull(testingTarget, "Can't create success object RelativeVector4");
            Assert.IsInstanceOf<RelativeVector4>(testingTarget, "Should return Vector4 instance.");

            testingTarget.W = 1.0f;
            Assert.AreEqual(1.0f, testingTarget.W, "Should be equal!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"RelativeVector4GetW END (OK)");
        }


        [Test]
        [Category("P1")]
        [Description("RelativeVector4 Addition.")]
        [Property("SPEC", "Tizen.NUI.RelativeVector4.+ M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void RelativeVector4Addition()
        {
            tlog.Debug(tag, $"RelativeVector4Addition START");

            var testingTarget = new RelativeVector4(0.5f, 0.6f, 0.7f, 0.8f);
            Assert.IsNotNull(testingTarget, "Can't create success object RelativeVector4");
            Assert.IsInstanceOf<RelativeVector4>(testingTarget, "Should return Vector4 instance.");

            using (RelativeVector4 vector = new RelativeVector4(0.4f, 0.3f, 0.2f, 0.1f))
            {
                var result = testingTarget + vector;
                Assert.Less(Math.Abs(0.9f - result.X), 0.0001f, "The X of the vector is not correct here!");
                Assert.Less(Math.Abs(0.9f - result.Y), 0.0001f, "The Y of the vector is not correct here!");
                Assert.Less(Math.Abs(0.9f - result.Z), 0.0001f, "The Z of the vector is not correct here!");
                Assert.Less(Math.Abs(0.9f - result.W), 0.0001f, "The W of the vector is not correct here!");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"RelativeVector4Addition END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("RelativeVector4 Subtraction.")]
        [Property("SPEC", "Tizen.NUI.RelativeVector4.- M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void RelativeVector4Subtraction()
        {
            tlog.Debug(tag, $"RelativeVector4Subtraction START");

            var testingTarget = new RelativeVector4(0.5f, 0.6f, 0.7f, 0.8f);
            Assert.IsNotNull(testingTarget, "Can't create success object RelativeVector4");
            Assert.IsInstanceOf<RelativeVector4>(testingTarget, "Should return Vector4 instance.");

            using (RelativeVector4 vector = new RelativeVector4(0.4f, 0.3f, 0.2f, 0.1f))
            {
                var result = testingTarget - vector;
                Assert.Less(Math.Abs(0.1f - result.X), 0.0001f, "The X of the vector is not correct here!");
                Assert.Less(Math.Abs(0.3f - result.Y), 0.0001f, "The Y of the vector is not correct here!");
                Assert.Less(Math.Abs(0.5f - result.Z), 0.0001f, "The Z of the vector is not correct here!");
                Assert.Less(Math.Abs(0.7f - result.W), 0.0001f, "The W of the vector is not correct here!");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"RelativeVector4Subtraction END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("RelativeVector4 Multiply. By RelativeVector4.")]
        [Property("SPEC", "Tizen.NUI.RelativeVector4.* M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "RelativeVector4,RelativeVector4")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void RelativeVector4MultiplyByRelativeVector4()
        {
            tlog.Debug(tag, $"RelativeVector4MultiplyByRelativeVector4 START");

            var testingTarget = new RelativeVector4(0.5f, 0.6f, 0.7f, 0.8f);
            Assert.IsNotNull(testingTarget, "Can't create success object RelativeVector4");
            Assert.IsInstanceOf<RelativeVector4>(testingTarget, "Should return Vector4 instance.");

            using (RelativeVector4 vector = new RelativeVector4(0.4f, 0.3f, 0.2f, 0.1f))
            {
                var result = testingTarget * vector;
                Assert.Less(Math.Abs(0.2f - result.X), 0.0001f, "The X of the vector is not correct here!");
                Assert.Less(Math.Abs(0.18f - result.Y), 0.0001f, "The Y of the vector is not correct here!");
                Assert.Less(Math.Abs(0.14f - result.Z), 0.0001f, "The Z of the vector is not correct here!");
                Assert.Less(Math.Abs(0.08f - result.W), 0.0001f, "The W of the vector is not correct here!");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"RelativeVector4MultiplyByRelativeVector4 END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("RelativeVector4 Multiply. By Float.")]
        [Property("SPEC", "Tizen.NUI.RelativeVector4.* M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "RelativeVector4,Single")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void RelativeVector4MultiplyByFloat()
        {
            tlog.Debug(tag, $"RelativeVector4MultiplyByFloat START");

            var testingTarget = new RelativeVector4(0.5f, 0.6f, 0.7f, 0.8f);
            Assert.IsNotNull(testingTarget, "Can't create success object RelativeVector4");
            Assert.IsInstanceOf<RelativeVector4>(testingTarget, "Should return Vector4 instance.");

            var result = testingTarget * 0.5f;
            Assert.Less(Math.Abs(0.25f - result.X), 0.0001f, "The X of the vector is not correct here!");
            Assert.Less(Math.Abs(0.3f - result.Y), 0.0001f, "The Y of the vector is not correct here!");
            Assert.Less(Math.Abs(0.35f - result.Z), 0.0001f, "The Z of the vector is not correct here!");
            Assert.Less(Math.Abs(0.4f - result.W), 0.0001f, "The W of the vector is not correct here!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"RelativeVector4MultiplyByFloat END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("RelativeVector4 Division. With RelativeVector4.")]
        [Property("SPEC", "Tizen.NUI.RelativeVector4./ M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "Vector4,Vector4")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void RelativeVector4DivisionByRelativeVector4()
        {
            tlog.Debug(tag, $"RelativeVector4DivisionByRelativeVector4 START");

            var testingTarget = new RelativeVector4(0.05f, 0.06f, 0.07f, 0.08f);
            Assert.IsNotNull(testingTarget, "Can't create success object RelativeVector4");
            Assert.IsInstanceOf<RelativeVector4>(testingTarget, "Should return Vector4 instance.");

            using (RelativeVector4 vector = new RelativeVector4(0.2f, 0.2f, 0.2f, 0.1f))
            {
                var result = testingTarget / vector;
                Assert.Less(Math.Abs(0.25f - result.X), 0.0001f, "The X of the vector is not correct here!");
                Assert.Less(Math.Abs(0.3f - result.Y), 0.0001f, "The Y of the vector is not correct here!");
                Assert.Less(Math.Abs(0.35f - result.Z), 0.0001f, "The Z of the vector is not correct here!");
                Assert.Less(Math.Abs(0.8f - result.W), 0.0001f, "The W of the vector is not correct here!");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"RelativeVector4DivisionByRelativeVector4 END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("RelativeVector4 Division. By Float.")]
        [Property("SPEC", "Tizen.NUI.RelativeVector4./ M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "Vector4,Single")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void RelativeVector4DivisionByFloat()
        {
            tlog.Debug(tag, $"RelativeVector4DivisionByFloat START");

            var testingTarget = new RelativeVector4(0.5f, 0.6f, 0.7f, 0.8f);
            Assert.IsNotNull(testingTarget, "Can't create success object RelativeVector4");
            Assert.IsInstanceOf<RelativeVector4>(testingTarget, "Should return Vector4 instance.");

            var result = testingTarget / 2.0f;
            Assert.Less(Math.Abs(0.25f - result.X), 0.0001f, "The X of the vector is not correct here!");
            Assert.Less(Math.Abs(0.3f - result.Y), 0.0001f, "The Y of the vector is not correct here!");
            Assert.Less(Math.Abs(0.35f - result.Z), 0.0001f, "The Z of the vector is not correct here!");
            Assert.Less(Math.Abs(0.4f - result.W), 0.0001f, "The W of the vector is not correct here!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"RelativeVector4DivisionByFloat END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("RelativeVector4 Equals.")]
        [Property("SPEC", "Tizen.NUI.RelativeVector4.Equals M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void RelativeVector4Equals()
        {
            tlog.Debug(tag, $"RelativeVector4Equals START");

            var testingTarget = new RelativeVector4(0.02f, 0.02f, 0.02f, 0.02f);
            Assert.IsNotNull(testingTarget, "Can't create success object RelativeVector4");
            Assert.IsInstanceOf<RelativeVector4>(testingTarget, "Should return Vector4 instance.");

            using (RelativeVector4 vector = new RelativeVector4(0.02f, 0.02f, 0.02f, 0.02f))
            {
                var result = testingTarget.Equals(vector);
                Assert.IsTrue(result, "Should be true here!");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"RelativeVector4Equals END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("RelativeVector4 implicit. Vector4 to RelativeVector4.")]
        [Property("SPEC", "Tizen.NUI.RelativeVector4.implicit M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "Vector4")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void RelativeVector4ImplicitToRelativeVector4()
        {
            tlog.Debug(tag, $"RelativeVector4ImplicitToRelativeVector4 START");

            RelativeVector4 testingTarget = null;

            using (Vector4 vector = new Vector4(0.5f, 0.6f, 0.7f, 0.8f))
            {
                testingTarget = vector;
                Assert.AreEqual(testingTarget.X, vector.X, "The value of X is not correct.");
                Assert.AreEqual(testingTarget.Y, vector.Y, "The value of Y is not correct.");
                Assert.AreEqual(testingTarget.Z, vector.Z, "The value of Z is not correct.");
                Assert.AreEqual(testingTarget.W, vector.W, "The value of W is not correct.");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"RelativeVector4ImplicitToRelativeVector4 END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("RelativeVector4 implicit. RelativeVector4 to Vector4.")]
        [Property("SPEC", "Tizen.NUI.RelativeVector4.implicit M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "RelativeVector4")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void RelativeVector4ImplicitToVector4()
        {
            tlog.Debug(tag, $"RelativeVector4ImplicitToVector4 START");

            Vector4 testingTarget = null;
            using (RelativeVector4 vector = new RelativeVector4(0.5f, 0.6f, 0.7f, 0.8f))
            {
                testingTarget = vector;
                Assert.AreEqual(vector.X, testingTarget.X, "The value of X is not correct.");
                Assert.AreEqual(vector.Y, testingTarget.Y, "The value of Y is not correct.");
                Assert.AreEqual(vector.Z, testingTarget.Z, "The value of Z is not correct.");
                Assert.AreEqual(vector.W, testingTarget.W, "The value of W is not correct.");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"RelativeVector4ImplicitToVector4 END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("RelativeVector4 Dispose.")]
        [Property("SPEC", "Tizen.NUI.RelativeVector4.Dispose M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR MCST")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void RelativeVector4Dispose()
        {
            tlog.Debug(tag, $"RelativeVector4Dispose START");

             var testingTarget = new RelativeVector4(10.0f, 20.0f, 30.0f, 40.0f);
            Assert.IsNotNull(testingTarget, "Can't create success object RelativeVector4");
            Assert.IsInstanceOf<RelativeVector4>(testingTarget, "Should return Vector4 instance.");

            try
            {
                testingTarget.Dispose();
            }
            catch (Exception e)
            {
                Assert.Fail("Caught Exception" + e.ToString());
            }

            tlog.Debug(tag, $"RelativeVector4Dispose END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("RelativeVector4 GetHashCode.")]
        [Property("SPEC", "Tizen.NUI.RelativeVector4.GetHashCode M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void RelativeVector4GetHashCode()
        {
            tlog.Debug(tag, $"RelativeVector4GetHashCode START");

            var testingTarget = new RelativeVector4(10.0f, 20.0f, 30.0f, 40.0f);
            Assert.IsNotNull(testingTarget, "Can't create success object RelativeVector4");
            Assert.IsInstanceOf<RelativeVector4>(testingTarget, "Should be an instance of RelativeVector4 type.");

            var result = testingTarget.GetHashCode();
            Assert.IsTrue(result >= Int32.MinValue && result <= Int32.MaxValue, "The value of hash is out of Integer range");

            testingTarget.Dispose();
            tlog.Debug(tag, $"RelativeVector4GetHashCode END (OK)");
        }
    }
}
