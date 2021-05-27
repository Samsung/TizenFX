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
    [Description("public/Common/RelativeVector2")]
    public class PublicRelativeVector2Test
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
        [Description("RelativeVector2 constructor.")]
        [Property("SPEC", "Tizen.NUI.RelativeVector2.RelativeVector2 C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void RelativeVector2Constructor()
        {
            tlog.Debug(tag, $"RelativeVector2Constructor START");

            var testingTarget = new RelativeVector2();
            Assert.IsNotNull(testingTarget, "Can't create success object RelativeVector2");
            Assert.IsInstanceOf<RelativeVector2>(testingTarget, "Should return RelativeVector2 instance.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"RelativeVector2Constructor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("RelativeVector2 constructor. With Float.")]
        [Property("SPEC", "Tizen.NUI.RelativeVector2.RelativeVector2 C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("COVPARAM", "Single, Single")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void RelativeVector2ConstructorWithFloat()
        {
            tlog.Debug(tag, $"RelativeVector2ConstructorWithFloat START");

            var testingTarget = new RelativeVector2(0.5f, 0.6f);
            Assert.IsNotNull(testingTarget, "Can't create success object RelativeVector2");
            Assert.IsInstanceOf<RelativeVector2>(testingTarget, "Should return Vector2 instance.");
            
            Assert.AreEqual(0.5f, testingTarget.X, "Retrieved vector.X should be equal to set value");
            Assert.AreEqual(0.6f, testingTarget.Y, "Retrieved vector.Y should be equal to set value");

            testingTarget.Dispose();
            tlog.Debug(tag, $"RelativeVector2ConstructorWithFloat END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("RelativeVector2 constructor. With RelativeVector3.")]
        [Property("SPEC", "Tizen.NUI.RelativeVector2.RelativeVector2 C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("COVPARAM", "RelativeVector3")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void RelativeVector2ConstructorWithRelativeVector3()
        {
            tlog.Debug(tag, $"RelativeVector2ConstructorWithRelativeVector3 START");

            using (RelativeVector3 vec3 = new RelativeVector3(0.5f, 0.6f, 0.7f))
            {
                var testingTarget = new RelativeVector2(vec3);
                Assert.IsNotNull(testingTarget, "Can't create success object RelativeVector2");
                Assert.IsInstanceOf<RelativeVector2>(testingTarget, "Should return RelativeVector2 instance.");
                
                Assert.AreEqual(0.5f, testingTarget.X, "Retrieved vector2.X should be equal to set value");
                Assert.AreEqual(0.6f, testingTarget.Y, "Retrieved vector2.Y should be equal to set value");

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"RelativeVector2ConstructorWithRelativeVector3 END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("RelativeVector2 constructor. With RelativeVector4.")]
        [Property("SPEC", "Tizen.NUI.RelativeVector2.RelativeVector2 C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("COVPARAM", "RelativeVector4")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void RelativeVector2ConstructorWithRelativeVector4()
        {
            tlog.Debug(tag, $"RelativeVector2ConstructorWithRelativeVector4 START");

            using (RelativeVector4 vec4 = new RelativeVector4(0.5f, 0.6f, 0.7f, 0.8f))
            {
                var testingTarget = new RelativeVector2(vec4);
                Assert.IsNotNull(testingTarget, "Can't create success object RelativeVector2");
                Assert.IsInstanceOf<RelativeVector2>(testingTarget, "Should return RelativeVector2 instance.");
                
                Assert.AreEqual(0.5f, testingTarget.X, "Retrieved vector.X should be equal to set value");
                Assert.AreEqual(0.6f, testingTarget.Y, "Retrieved vector.Y should be equal to set value");

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"RelativeVector2ConstructorWithRelativeVector4 END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("RelativeVector2 this[uint index].")]
        [Property("SPEC", "Tizen.NUI.RelativeVector2.this[uint] A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void RelativeVector2GetValueBySubscriptIndex()
        {
            tlog.Debug(tag, $"RelativeVector2GetValueBySubscriptIndex START");

            var testingTarget = new RelativeVector2(1.0f, 0.5f);
            Assert.IsNotNull(testingTarget, "Can't create success object RelativeVector2");
            Assert.IsInstanceOf<RelativeVector2>(testingTarget, "Should be an instance of RelativeVector2 type.");

            Assert.AreEqual(1.0f, testingTarget[0], "The value of index[0] is not correct!");
            Assert.AreEqual(0.5f, testingTarget[1], "The value of index[1] is not correct!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"RelativeVector2GetValueBySubscriptIndex END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("RelativeVector2 EqualTo.")]
        [Property("SPEC", "Tizen.NUI.RelativeVector2.EqualTo M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void RelativeVector2EqualTo()
        {
            tlog.Debug(tag, $"RelativeVector2EqualTo START");

            var testingTarget = new RelativeVector2(1.0f, 0.5f);
            Assert.IsNotNull(testingTarget, "Can't create success object RelativeVector2");
            Assert.IsInstanceOf<RelativeVector2>(testingTarget, "Should be an instance of RelativeVector2 type.");

            using (RelativeVector2 vector = new RelativeVector2(1.0f, 0.5f))
            {
                Assert.IsTrue((testingTarget.EqualTo(vector)), "Should be equal");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"RelativeVector2EqualTo END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("RelativeVector2 NotEqualTo.")]
        [Property("SPEC", "Tizen.NUI.RelativeVector2.NotEqualTo M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void RelativeVector2NotEqualTo()
        {
            tlog.Debug(tag, $"RelativeVector2NotEqualTo START");

            var testingTarget = new RelativeVector2(1.0f, 0.5f);
            Assert.IsNotNull(testingTarget, "Can't create success object RelativeVector2");
            Assert.IsInstanceOf<RelativeVector2>(testingTarget, "Should be an instance of RelativeVector2 type.");

            using (RelativeVector2 vector = new RelativeVector2(1.0f, 0.6f))
            {
                Assert.IsTrue((testingTarget.NotEqualTo(vector)), "Should be equal");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"RelativeVector2NotEqualTo END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("RelativeVector2 X.")]
        [Property("SPEC", "Tizen.NUI.RelativeVector2.X A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void RelativeVector2GetX()
        {
            tlog.Debug(tag, $"RelativeVector2GetX START");

            var testingTarget = new RelativeVector2(1.0f, 0.5f);
            Assert.IsNotNull(testingTarget, "Can't create success object RelativeVector2");
            Assert.IsInstanceOf<RelativeVector2>(testingTarget, "Should be an instance of RelativeVector2 type.");

            Assert.AreEqual(1.0f, testingTarget.X, "The X of the vector is not correct here!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"RelativeVector2GetX END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("RelativeVector2 Y.")]
        [Property("SPEC", "Tizen.NUI.RelativeVector2.Y A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void RelativeVector2GetY()
        {
            tlog.Debug(tag, $"RelativeVector2GetY START");

            var testingTarget = new RelativeVector2(1.0f, 0.5f);
            Assert.IsNotNull(testingTarget, "Can't create success object RelativeVector2");
            Assert.IsInstanceOf<RelativeVector2>(testingTarget, "Should be an instance of RelativeVector2 type.");

            Assert.AreEqual(0.5f, testingTarget.Y, "The Y of the vector is not correct here!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"RelativeVector2GetY END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("RelativeVector2 operator +.")]
        [Property("SPEC", "Tizen.NUI.RelativeVector2.+ M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void RelativeVector2Addition()
        {
            tlog.Debug(tag, $"RelativeVector2Addition START");

            var testingTarget = new RelativeVector2(0.5f, 0.6f);
            Assert.IsNotNull(testingTarget, "Can't create success object RelativeVector2");
            Assert.IsInstanceOf<RelativeVector2>(testingTarget, "Should be an instance of RelativeVector2 type.");

            using (RelativeVector2 vector = new RelativeVector2(0.4f, 0.2f))
            {
                var result = testingTarget + vector;
                Assert.AreEqual(0.9f, result.X, "The X of the vector is not correct here!");
                Assert.AreEqual(0.8f, result.Y, "The Y of the vector is not correct here!");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"RelativeVector2Addition END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("RelativeVector2 operator -.")]
        [Property("SPEC", "Tizen.NUI.RelativeVector2.- M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void RelativeVector2Subtraction()
        {
            tlog.Debug(tag, $"RelativeVector2Subtraction START");

            var testingTarget = new RelativeVector2(1.0f, 0.8f);
            Assert.IsNotNull(testingTarget, "Can't create success object RelativeVector2");
            Assert.IsInstanceOf<RelativeVector2>(testingTarget, "Should be an instance of RelativeVector2 type.");

            using (RelativeVector2 vector = new RelativeVector2(1.0f, 0.6f))
            {
                var result = testingTarget - vector;
                Assert.AreEqual(0.0f, result.X, "The X of the vector is not correct here!");
                Assert.Less(Math.Abs(0.2f - result.Y), 0.0001f, "The Y of the vector is not correct here!");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"RelativeVector2Subtraction END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("RelativeVector2 operator *. Multiply By RelativeVector2.")]
        [Property("SPEC", "Tizen.NUI.RelativeVector2.* M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void RelativeVector2MultiplyByRelativeVector2()
        {
            tlog.Debug(tag, $"RelativeVector2MultiplyByRelativeVector2 START");

            var testingTarget = new RelativeVector2(0.5f, 0.4f);
            Assert.IsNotNull(testingTarget, "Can't create success object RelativeVector2");
            Assert.IsInstanceOf<RelativeVector2>(testingTarget, "Should be an instance of RelativeVector2 type.");

            using (RelativeVector2 vector = new RelativeVector2(1.0f, 0.0f))
            {
                var result = testingTarget * vector;
                Assert.AreEqual(0.5f, result.X, "The X of the vector is not correct here!");
                Assert.AreEqual(0.0f, result.Y, "The Y of the vector is not correct here!");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"RelativeVector2MultiplyByRelativeVector2 END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("RelativeVector2 operator *. By Float.")]
        [Property("SPEC", "Tizen.NUI.RelativeVector2.* M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void RelativeVector2MultiplyByFloat()
        {
            tlog.Debug(tag, $"RelativeVector2MultiplyByFloat START");

            var testingTarget = new RelativeVector2(0.02f, 0.04f);
            Assert.IsNotNull(testingTarget, "Can't create success object RelativeVector2");
            Assert.IsInstanceOf<RelativeVector2>(testingTarget, "Should be an instance of RelativeVector2 type.");

            var result = testingTarget * 10.0f;
            Assert.Less(Math.Abs(0.2f - result.X), 0.0001f, "The X of the vector is not correct here!");
            Assert.Less(Math.Abs(0.4f - result.Y), 0.0001f, "The Y of the vector is not correct here!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"RelativeVector2MultiplyByFloat END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("RelativeVector2 operator /. By RelativeVector2.")]
        [Property("SPEC", "Tizen.NUI.RelativeVector2./ M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void RelativeVector2DivisionByRelativeVector2()
        {
            tlog.Debug(tag, $"RelativeVector2DivisionByRelativeVector2 START");

            var testingTarget = new RelativeVector2(0.5f, 0.04f);
            Assert.IsNotNull(testingTarget, "Can't create success object RelativeVector2");
            Assert.IsInstanceOf<RelativeVector2>(testingTarget, "Should be an instance of RelativeVector2 type.");

            using (RelativeVector2 vector = new RelativeVector2(1.0f, 0.5f))
            {
                var result = testingTarget / vector;
                Assert.AreEqual(0.5f, result.X, "The X of the vector is not correct here!");
                Assert.AreEqual(0.08f, result.Y, "The Y of the vector is not correct here!");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"RelativeVector2DivisionByRelativeVector2 END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("RelativeVector2 operator /. By Float.")]
        [Property("SPEC", "Tizen.NUI.RelativeVector2./ M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void RelativeVector2DivisionByFloat()
        {
            tlog.Debug(tag, $"RelativeVector2DivisionByFloat START");

            var testingTarget = new RelativeVector2(0.02f, 0.02f);
            Assert.IsNotNull(testingTarget, "Can't create success object RelativeVector2");
            Assert.IsInstanceOf<RelativeVector2>(testingTarget, "Should be an instance of RelativeVector2 type.");

            var result = testingTarget / 0.5f;
            Assert.AreEqual(0.04f, result.X, "The X of the vector is not correct here!");
            Assert.AreEqual(0.04f, result.Y, "The Y of the vector is not correct here!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"RelativeVector2DivisionByFloat END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("RelativeVector2 Equals.")]
        [Property("SPEC", "Tizen.NUI.RelativeVector2.Equals M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void RelativeVector2Equals()
        {
            tlog.Debug(tag, $"RelativeVector2Equals START");

            var testingTarget = new RelativeVector2(0.02f, 0.02f);
            Assert.IsNotNull(testingTarget, "Can't create success object RelativeVector2");
            Assert.IsInstanceOf<RelativeVector2>(testingTarget, "Should be an instance of RelativeVector2 type.");

            using (RelativeVector2 vector = new RelativeVector2(0.02f, 0.02f))
            {
                var result = testingTarget.Equals(vector);
                Assert.IsTrue(result, "Should be true here!");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"RelativeVector2Equals END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("RelativeVector2 implicit. Vector2 to RelativeVector2.")]
        [Property("SPEC", "Tizen.NUI.RelativeVector2.implicit M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "Vector2")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void RelativeVector2ImplicitToRelativeVector2()
        {
            tlog.Debug(tag, $"RelativeVector2ImplicitToRelativeVector2 START");

            RelativeVector2 testingTarget = null;
            using (Vector2 vector = new Vector2(1.0f, 0.5f))
            {
                testingTarget = vector;
                Assert.AreEqual(vector.X, testingTarget.X, "The value of X is not correct.");
                Assert.AreEqual(vector.Y, testingTarget.Y, "The value of Y is not correct.");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"RelativeVector2ImplicitToRelativeVector2 END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("RelativeVector2 implicit. RelativeVector2 To Vector2.")]
        [Property("SPEC", "Tizen.NUI.RelativeVector2.implicit M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "RelativeVector2")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void RelativeVector2ImplicitToVector2()
        {
            tlog.Debug(tag, $"RelativeVector2ImplicitToVector2 START");

            Vector2 testingTarget = null;
            using (RelativeVector2 relativeVector2 = new RelativeVector2(1.0f, 0.5f))
            {
                testingTarget = relativeVector2;
                Assert.AreEqual(relativeVector2.X, testingTarget.X, "The value of X is not correct.");
                Assert.AreEqual(relativeVector2.Y, testingTarget.Y, "The value of Y is not correct.");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"RelativeVector2ImplicitToVector2 END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("RelativeVector2 Dispose.")]
        [Property("SPEC", "Tizen.NUI.Vector2.Dispose M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR MCST")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void RelativeVector2Dispose()
        {
            tlog.Debug(tag, $"RelativeVector2Dispose START");

            var testingTarget = new RelativeVector2(1.0f, 0.0f);
            Assert.IsNotNull(testingTarget, "Can't create success object RelativeVector2");
            Assert.IsInstanceOf<RelativeVector2>(testingTarget, "Should be an instance of RelativeVector2 type.");
            try
            {
                testingTarget.Dispose();
            }
            catch (Exception e)
            {
                Assert.Fail("Caught Exception" + e.ToString());
            }

            tlog.Debug(tag, $"RelativeVector2Dispose END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("RelativeVector2 GetHashCode.")]
        [Property("SPEC", "Tizen.NUI.RelativeVector2.GetHashCode M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void RelativeVector2GetHashCode()
        {
            tlog.Debug(tag, $"RelativeVector2GetHashCode START");

            var testingTarget = new RelativeVector2(1.0f, 0.0f);
            Assert.IsNotNull(testingTarget, "Can't create success object RelativeVector2");
            Assert.IsInstanceOf<RelativeVector2>(testingTarget, "Should be an instance of RelativeVector2 type.");

            var result = testingTarget.GetHashCode();
            Assert.IsTrue(result >= Int32.MinValue && result <= Int32.MaxValue, "The value of hash is out of Integer range");

            testingTarget.Dispose();
            tlog.Debug(tag, $"RelativeVector2GetHashCode END (OK)");
        }
    }
}
