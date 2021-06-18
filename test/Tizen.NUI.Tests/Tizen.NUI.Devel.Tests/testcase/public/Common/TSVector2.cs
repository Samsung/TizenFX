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
    [Description("public/Common/Vector2")]
    public class PublicVector2Test
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
        [Description("Vector2 constructor.")]
        [Property("SPEC", "Tizen.NUI.Vector2.Vector2 C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void Vector2Constructor()
        {
            tlog.Debug(tag, $"Vector2Constructor START");

            var testingTarget = new Vector2();
            Assert.IsNotNull(testingTarget, "Can't create success object Vector2");
            Assert.IsInstanceOf<Vector2>(testingTarget, "Should return Vector2 instance.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"Vector2Constructor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Vector2 constructor. With Float.")]
        [Property("SPEC", "Tizen.NUI.Vector2.Vector2 C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("COVPARAM", "Single, Single")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void Vector2ConstructorWithFloat()
        {
            tlog.Debug(tag, $"Vector2ConstructorWithFloat START");

            var testingTarget = new Vector2(100.0f, 200.0f);
            Assert.IsNotNull(testingTarget, "Can't create success object Vector2");
            Assert.IsInstanceOf<Vector2>(testingTarget, "Should return Vector2 instance.");
            
            Assert.AreEqual(100.0f, testingTarget.X, "Retrieved vector.X should be equal to set value");
            Assert.AreEqual(200.0f, testingTarget.Y, "Retrieved vector.Y should be equal to set value");

            testingTarget.Dispose();
            tlog.Debug(tag, $"Vector2ConstructorWithFloat END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Vector2 constructor. With array.")]
        [Property("SPEC", "Tizen.NUI.Vector2.Vector2 C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("COVPARAM", "Single[]")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void Vector2ConstructorWithArray()
        {
            tlog.Debug(tag, $"Vector2ConstructorWithArray START");

            float[] array = new float[2] { 100.0f, 200.0f };

            var testingTarget = new Vector2(array);
            Assert.IsNotNull(testingTarget, "Can't create success object Vector2");
            Assert.IsInstanceOf<Vector2>(testingTarget, "Should return Vector2 instance.");
            
            Assert.AreEqual(100.0f, testingTarget.X, "Retrieved vector.X should be equal to set value");
            Assert.AreEqual(200.0f, testingTarget.Y, "Retrieved vector.Y should be equal to set value");

            testingTarget.Dispose();
            tlog.Debug(tag, $"Vector2ConstructorWithArray END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Vector2 constructor. With Vector3.")]
        [Property("SPEC", "Tizen.NUI.Vector2.Vector2 C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("COVPARAM", "Vector3")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void Vector2ConstructorWithVector3()
        {
            tlog.Debug(tag, $"Vector2ConstructorWithVector3 START");

            using (Vector3 vec3 = new Vector3(100.0f, 200.0f, 300.0f))
            {
                var testingTarget = new Vector2(vec3);
                Assert.IsNotNull(testingTarget, "Can't create success object Vector2");
                Assert.IsInstanceOf<Vector2>(testingTarget, "Should return Vector2 instance.");

                Assert.AreEqual(100.0f, testingTarget.X, "Retrieved vector.X should be equal to set value");
                Assert.AreEqual(200.0f, testingTarget.Y, "Retrieved vector.Y should be equal to set value");

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"Vector2ConstructorWithVector3 END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Vector2 constructor. With Vector4.")]
        [Property("SPEC", "Tizen.NUI.Vector2.Vector2 C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("COVPARAM", "Vector4")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void Vector2ConstructorWithVector4()
        {
            tlog.Debug(tag, $"Vector2ConstructorWithVector4 START");

            using (Vector4 vec4 = new Vector4(100.0f, 200.0f, 300.0f, 400.0f))
            {
                var testingTarget = new Vector2(vec4);
                Assert.IsNotNull(testingTarget, "Can't create success object Vector2");
                Assert.IsInstanceOf<Vector2>(testingTarget, "Should return Vector2 instance.");

                Assert.AreEqual(100.0f, testingTarget.X, "Retrieved vector.X should be equal to set value");
                Assert.AreEqual(200.0f, testingTarget.Y, "Retrieved vector.Y should be equal to set value");

                testingTarget.Dispose();
            }
                
            tlog.Debug(tag, $"Vector2ConstructorWithVector4 END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Vector2 this[uint index].")]
        [Property("SPEC", "Tizen.NUI.Vector2.this[uint] A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void Vector2GetValueBySubscriptIndex()
        {
            tlog.Debug(tag, $"Vector2GetValueBySubscriptIndex START");

            var testingTarget = new Vector2(100.0f, 200.0f);
            Assert.IsNotNull(testingTarget, "Can't create success object Vector2");
            Assert.IsInstanceOf<Vector2>(testingTarget, "Should be an instance of Vector2 type.");

            Assert.AreEqual(100.0f, testingTarget[0], "The value of index[0] is not correct!");
            Assert.AreEqual(200.0f, testingTarget[1], "The value of index[1] is not correct!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"Vector2GetValueBySubscriptIndex END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Vector2 One.")]
        [Property("SPEC", "Tizen.NUI.Vector2.One A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void Vector2One()
        {
            tlog.Debug(tag, $"Vector2One START");

            var testingTarget = Vector2.One;
            Assert.IsNotNull(testingTarget, "Can't create success object Vector2");
            Assert.IsInstanceOf<Vector2>(testingTarget, "Should be an instance of Vector2 type.");

            Assert.AreEqual(1.0f, testingTarget.X, "The value of Vector2.One.X is not correct!");
            Assert.AreEqual(1.0f, testingTarget.Y, "The value of Vector2.One.Y is not correct!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"Vector2One END (OK)");
        }


        [Test]
        [Category("P1")]
        [Description("Vector2 XAxis.")]
        [Property("SPEC", "Tizen.NUI.Vector2.XAxis A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void Vector2XAxis()
        {
            tlog.Debug(tag, $"Vector2XAxis START");

            var testingTarget = Vector2.XAxis;
            Assert.IsNotNull(testingTarget, "Can't create success object Vector2");
            Assert.IsInstanceOf<Vector2>(testingTarget, "Should be an instance of Vector2 type.");

            Assert.AreEqual(1.0f, testingTarget.X, "The value of Vector2.XAxis.Y is not correct!");
            Assert.AreEqual(0.0f, testingTarget.Y, "The value of Vector2.XAxis.Y is not correct!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"Vector2XAxis END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Vector2 YAxis.")]
        [Property("SPEC", "Tizen.NUI.Vector2.YAxis A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void Vector2YAxis()
        {
            tlog.Debug(tag, $"Vector2YAxis START");

            var testingTarget = Vector2.YAxis;
            Assert.IsNotNull(testingTarget, "Can't create success object Vector2");
            Assert.IsInstanceOf<Vector2>(testingTarget, "Should be an instance of Vector2 type.");

            Assert.AreEqual(0.0f, testingTarget.X, "The value of Vector2.YAxis.X is not correct!");
            Assert.AreEqual(1.0f, testingTarget.Y, "The value of Vector2.YAxis.Y is not correct!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"Vector2YAxis END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Vector2 NegativeXAxis.")]
        [Property("SPEC", "Tizen.NUI.Vector2.NegativeXAxis A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void Vector2NegativeXAxis()
        {
            tlog.Debug(tag, $"Vector2NegativeXAxis START");

            var testingTarget = Vector2.NegativeXAxis;
            Assert.IsNotNull(testingTarget, "Can't create success object Vector2");
            Assert.IsInstanceOf<Vector2>(testingTarget, "Should be an instance of Vector2 type.");
            
            Assert.AreEqual(-1.0f, testingTarget.X, "The value of Vector2.NegativeXAxis.X is not correct!");
            Assert.AreEqual(0.0f, testingTarget.Y, "The value of Vector2.NegativeXAxis.Y is not correct!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"Vector2NegativeXAxis END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Vector2 NegativeYAxis.")]
        [Property("SPEC", "Tizen.NUI.Vector2.NegativeYAxis A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void Vector2NegativeYAxis()
        {
            tlog.Debug(tag, $"Vector2NegativeYAxis START");

            var testingTarget = Vector2.NegativeYAxis;
            Assert.IsNotNull(testingTarget, "Can't create success object Vector2");
            Assert.IsInstanceOf<Vector2>(testingTarget, "Should be an instance of Vector2 type.");

            Assert.AreEqual(0.0f, testingTarget.X, "The value of Vector2.NegativeYAxis.X is not correct!");
            Assert.AreEqual(-1.0f, testingTarget.Y, "The value of Vector2.NegativeYAxis.Y is not correct!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"Vector2NegativeYAxis END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Vector2 Zero.")]
        [Property("SPEC", "Tizen.NUI.Vector2.Zero A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void Vector2Zero()
        {
            tlog.Debug(tag, $"Vector2Zero START");

            var testingTarget = Vector2.Zero;
            Assert.IsNotNull(testingTarget, "Can't create success object Vector2");
            Assert.IsInstanceOf<Vector2>(testingTarget, "Should be an instance of Vector2 type.");

            Assert.AreEqual(0.0f, testingTarget.X, "The value of Vector2.Zero.X is not correct!");
            Assert.AreEqual(0.0f, testingTarget.Y, "The value of Vector2.Zero.Y is not correct!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"Vector2Zero END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Vector2 Length.")]
        [Property("SPEC", "Tizen.NUI.Vector2.Length M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void Vector2Length()
        {
            tlog.Debug(tag, $"Vector2Length START");

            using (Vector2 vector = new Vector2(0.0f, 0.0f))
            {
                Assert.AreEqual(0.0f, vector.Length(), "The length of vector should be zero!");
            }

            using (Vector2 vector = new Vector2(1.0f, 2.0f))
            {
                Assert.AreEqual((float)Math.Sqrt(5.0f), vector.Length(), "The length of vector2 is not correct!");
            }

            tlog.Debug(tag, $"Vector2Length END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Vector2 LengthSquared.")]
        [Property("SPEC", "Tizen.NUI.Vector2.LengthSquared M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void Vector2LengthSquared()
        {
            tlog.Debug(tag, $"Vector2LengthSquared START");

            using (Vector2 vector = new Vector2(0.0f, 0.0f))
            {
                Assert.AreEqual(0.0f, vector.LengthSquared(), "The length of vector is not correct!");
            }

            using (Vector2 vector = new Vector2(1.0f, 2.0f))
            {
                Assert.AreEqual(5.0f, vector.LengthSquared(), "The length of vector2 is not correct here!");
            }

            tlog.Debug(tag, $"Vector2LengthSquared END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Vector2 Normalize.")]
        [Property("SPEC", "Tizen.NUI.Vector2.Normalize M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR MCST")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void Vector2Normalize()
        {
            tlog.Debug(tag, $"Vector2Normalize START");

            var testingTarget = new Vector2((float)Math.Cosh(0.0f) * 10.0f, (float)Math.Cosh(1.0f) * 10.0f);
            Assert.IsNotNull(testingTarget, "Can't create success object Vector2");
            Assert.IsInstanceOf<Vector2>(testingTarget, "Should be an instance of Vector2 type.");

            try
            {
                testingTarget.Normalize();
                Assert.Less(Math.Abs(1.0f - testingTarget.LengthSquared()), 0.001f, "The value of LengthSquared is wrong");
            }
            catch (Exception e)
            {
                tlog.Error(tag, "Caught Exception" + e.ToString());
                LogUtils.Write(LogUtils.DEBUG, LogUtils.TAG, "Caught Exception" + e.ToString());
                Assert.Fail("Caught Exception" + e.ToString());
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"Vector2Normalize END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Vector2 Clamp.")]
        [Property("SPEC", "Tizen.NUI.Vector2.Clamp M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR MCST")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void Vector2Clamp()
        {
            tlog.Debug(tag, $"Vector2Clamp START");

            var testingTarget = new Vector2(2.0f, 0.8f);
            Assert.IsNotNull(testingTarget, "Can't create success object Vector2");
            Assert.IsInstanceOf<Vector2>(testingTarget, "Should be an instance of Vector2 type.");

            try
            {
                testingTarget.Clamp(new Vector2(1.0f, 4.0f), new Vector2(9.0f, 6.0f));
                Assert.AreEqual(2.0f, testingTarget.X, "2.0 > 1.0(min) && 2.0 < 9.0(max), so the value should be 2.0f");
                Assert.AreEqual(4.0f, testingTarget.Y, "0.8 < 4.0(min), so the value should be 4.0f");
            }
            catch (Exception e)
            {
                tlog.Error(tag, "Caught Exception" + e.ToString());
                LogUtils.Write(LogUtils.DEBUG, LogUtils.TAG, "Caught Exception" + e.ToString());
                Assert.Fail("Caught Exception" + e.ToString());
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"Vector2Clamp END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Vector2 Width.")]
        [Property("SPEC", "Tizen.NUI.Vector2.Width A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        [Obsolete]
        public void Vector2Width()
        {
            tlog.Debug(tag, $"Vector2Height START");

            var testingTarget = new Vector2(20.0f, 30.0f);
            Assert.IsNotNull(testingTarget, "Can't create success object Vector2");
            Assert.IsInstanceOf<Vector2>(testingTarget, "Should be an instance of Vector2 type.");

            Assert.AreEqual(20.0f, testingTarget.Width, "The Width of the vector is not correct here!");
            testingTarget.Width = 100.0f;
            Assert.AreEqual(100.0f, testingTarget.Width, "The Width of the vector is not correct.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"Vector2Height END (OK)");
        }


        [Test]
        [Category("P1")]
        [Description("Vector2 Height.")]
        [Property("SPEC", "Tizen.NUI.Vector2.Height A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        [Obsolete]
        public void Vector2Height()
        {
            tlog.Debug(tag, $"Vector2Height START");

            Vector2 testingTarget = new Vector2(30.0f, 20.0f);
            Assert.IsNotNull(testingTarget, "Can't create success object Vector2");
            Assert.IsInstanceOf<Vector2>(testingTarget, "Should be an instance of Vector2 type.");

            Assert.AreEqual(20.0f, testingTarget.Height, "The Height of the vector is not correct here!");
            
            testingTarget.Height = 100.0f;
            Assert.AreEqual(100.0f, testingTarget.Height, "The Height of the vector is not correct.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"Vector2Height END (OK)");
        }
        [Test]
        [Category("P1")]
        [Description("Vector2 X.")]
        [Property("SPEC", "Tizen.NUI.Vector2.X A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void Vector2GetX()
        {
            tlog.Debug(tag, $"Vector2GetX START");

            var testingTarget = new Vector2(20.0f, 30.0f);
            Assert.IsNotNull(testingTarget, "Can't create success object Vector2");
            Assert.IsInstanceOf<Vector2>(testingTarget, "Should be an instance of Vector2 type.");

            Assert.AreEqual(20.0f, testingTarget.X, "The X of the vector is not correct here!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"Vector2GetX END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Vector2 Y.")]
        [Property("SPEC", "Tizen.NUI.Vector2.Y A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void Vector2GetY()
        {
            tlog.Debug(tag, $"Vector2GetY START");

            var testingTarget = new Vector2(30.0f, 20.0f);
            Assert.IsNotNull(testingTarget, "Can't create success object Vector2");
            Assert.IsInstanceOf<Vector2>(testingTarget, "Should be an instance of Vector2 type.");

            Assert.AreEqual(20.0f, testingTarget.Y, "The Y of the vector is not correct here!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"Vector2GetY END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Vector2 operator +.")]
        [Property("SPEC", "Tizen.NUI.Vector2.+ M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void Vector2Addition()
        {
            tlog.Debug(tag, $"Vector2Addition START");

            var testingTarget = new Vector2(0.0f, 2.0f);
            Assert.IsNotNull(testingTarget, "Can't create success object Vector2");
            Assert.IsInstanceOf<Vector2>(testingTarget, "Should be an instance of Vector2 type.");

            using (Vector2 vector = new Vector2(1.0f, 2.0f))
            {
                var result = testingTarget + vector;
                Assert.AreEqual(1.0f, result.X, "The X of the vector is not correct here!");
                Assert.AreEqual(4.0f, result.Y, "The Y of the vector is not correct here!");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"Vector2Addition END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Vector2 operator -.")]
        [Property("SPEC", "Tizen.NUI.Vector2.- M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void Vector2Subtraction()
        {
            tlog.Debug(tag, $"Vector2Subtraction START");

            var testingTarget = new Vector2(10.0f, 20.0f);
            Assert.IsNotNull(testingTarget, "Can't create success object Vector2");
            Assert.IsInstanceOf<Vector2>(testingTarget, "Should be an instance of Vector2 type.");

            using (Vector2 vector = new Vector2(1.0f, 2.0f))
            {
                var result = testingTarget - vector;
                Assert.AreEqual(9.0f, result.X, "The X of the vector is not correct here!");
                Assert.AreEqual(18.0f, result.Y, "The Y of the vector is not correct here!");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"Vector2Subtraction END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Vector2 operator -.")]
        [Property("SPEC", "Tizen.NUI.Vector2.UnaryNegation M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void Vector2UnaryNegation()
        {
            tlog.Debug(tag, $"Vector2UnaryNegation START");

            var testingTarget = new Vector2(10.0f, 20.0f);
            Assert.IsNotNull(testingTarget, "Can't create success object Vector2");
            Assert.IsInstanceOf<Vector2>(testingTarget, "Should be an instance of Vector2 type.");

            var result = -testingTarget;
            Assert.AreEqual(-10.0f, result.X, "The X of the vector is not correct here!");
            Assert.AreEqual(-20.0f, result.Y, "The Y of the vector is not correct here!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"Vector2UnaryNegation END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Vector2 operator *. By Vector2.")]
        [Property("SPEC", "Tizen.NUI.Vector2.* M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "Vector2, Vector2")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void Vector2MultiplyByVector2()
        {
            tlog.Debug(tag, $"Vector2MultiplyByVector2 START");

            var testingTarget = new Vector2(10.0f, 20.0f);
            Assert.IsNotNull(testingTarget, "Can't create success object Vector2");
            Assert.IsInstanceOf<Vector2>(testingTarget, "Should be an instance of Vector2 type.");

            using (Vector2 vector = new Vector2(1.0f, 2.0f))
            {
                var result = testingTarget * vector;
                Assert.AreEqual(10.0f, result.X, "The X of the vector is not correct here!");
                Assert.AreEqual(40.0f, result.Y, "The Y of the vector is not correct here!");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"Vector2MultiplyByVector2 END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Vector2 operator *. By Float.")]
        [Property("SPEC", "Tizen.NUI.Vector2.* M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "Vector2, Single")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void Vector2MultiplyByFloat()
        {
            tlog.Debug(tag, $"Vector2MultiplyByFloat START");

            var testingTarget = new Vector2(10.0f, 20.0f);
            Assert.IsNotNull(testingTarget, "Can't create success object Vector2");
            Assert.IsInstanceOf<Vector2>(testingTarget, "Should be an instance of Vector2 type.");

            var result = testingTarget * 10.0f;
            Assert.AreEqual(100.0f, result.X, "The X of the vector is not correct here!");
            Assert.AreEqual(200.0f, result.Y, "The Y of the vector is not correct here!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"Vector2MultiplyByFloat END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Vector2 operator /. By Vector2.")]
        [Property("SPEC", "Tizen.NUI.Vector2./ M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "Vector2, Vector2")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void Vector2DivisionByVector2()
        {
            tlog.Debug(tag, $"Vector2DivisionByVector2 START");

            var testingTarget = new Vector2(10.0f, 20.0f);
            Assert.IsNotNull(testingTarget, "Can't create success object Vector2");
            Assert.IsInstanceOf<Vector2>(testingTarget, "Should be an instance of Vector2 type.");

            using (Vector2 vector = new Vector2(1.0f, 2.0f))
            {
                var result = testingTarget / vector;
                Assert.AreEqual(10.0f, result.X, "The X of the vector is not correct here!");
                Assert.AreEqual(10.0f, result.Y, "The Y of the vector is not correct here!");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"Vector2DivisionByVector2 END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Vector2 operator /. By Float.")]
        [Property("SPEC", "Tizen.NUI.Vector2./ M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "Vector2, Single")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void Vector2DivisionByFloat()
        {
            tlog.Debug(tag, $"Vector2DivisionByFloat START");

            var testingTarget = new Vector2(10.0f, 20.0f);
            Assert.IsNotNull(testingTarget, "Can't create success object Vector2");
            Assert.IsInstanceOf<Vector2>(testingTarget, "Should be an instance of Vector2 type.");

            var result = testingTarget / 10.0f;
            Assert.AreEqual(1.0f, result.X, "The X of the vector is not correct here!");
            Assert.AreEqual(2.0f, result.Y, "The Y of the vector is not correct here!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"Vector2DivisionByFloat END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Vector2 Equals.")]
        [Property("SPEC", "Tizen.NUI.Vector2.Equals M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void Vector2Equals()
        {
            tlog.Debug(tag, $"Vector2Equals START");

            var testingTarget = new Vector2(1.0f, 1.0f);
            Assert.IsNotNull(testingTarget, "Can't create success object Vector2");
            Assert.IsInstanceOf<Vector2>(testingTarget, "Should be an instance of Vector2 type.");

            using (Vector2 vector = new Vector2(1.0f, 1.0f))
            {
                var result = testingTarget.Equals(vector);
                Assert.IsTrue(result, "Should be true here!");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"Vector2Equals END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Vector2 Dispose.")]
        [Property("SPEC", "Tizen.NUI.Vector2.Dispose M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR MCST")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void Vector2Dispose()
        {
            tlog.Debug(tag, $"Vector2Dispose START");

            var testingTarget = new Vector2(10.0f, 20.0f);
            Assert.IsNotNull(testingTarget, "Can't create success object Vector2");
            Assert.IsInstanceOf<Vector2>(testingTarget, "Should be an instance of Vector2 type.");

            try
            {
                testingTarget.Dispose();
            }
            catch (Exception e)
            {
                Assert.Fail("Caught Exception" + e.ToString());
            }

            tlog.Debug(tag, $"Vector2Dispose END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Vector2 GetHashCode.")]
        [Property("SPEC", "Tizen.NUI.Vector2.GetHashCode M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void Vector2GetHashCode()
        {
            tlog.Debug(tag, $"Vector2GetHashCode START");

            var testingTarget = new Vector2(10.0f, 20.0f);
            Assert.IsNotNull(testingTarget, "Can't create success object Vector2");
            Assert.IsInstanceOf<Vector2>(testingTarget, "Should be an instance of Vector2 type.");

            var result = testingTarget.GetHashCode();
            Assert.IsTrue(result >= Int32.MinValue && result <= Int32.MaxValue, "The value of hash is out of Integer range");

            testingTarget.Dispose();
            tlog.Debug(tag, $"Vector2GetHashCode END (OK)");
        }
    }
}
