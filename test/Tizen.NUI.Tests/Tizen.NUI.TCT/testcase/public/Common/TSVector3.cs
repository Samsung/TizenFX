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
    [Description("public/Common/Vector3")]
    public class PublicVector3Test
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
        [Description("Vector3 constructor.")]
        [Property("SPEC", "Tizen.NUI.Vector3.Vector3 C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void Vector3Constructor()
        {
            tlog.Debug(tag, $"Vector3Constructor START");

            var testingTarget = new Vector3();
            Assert.IsNotNull(testingTarget, "Can't create success object Vector3");
            Assert.IsInstanceOf<Vector3>(testingTarget, "Should return Vector3 instance.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"Vector3Constructor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Vector3 constructor. With Float.")]
        [Property("SPEC", "Tizen.NUI.Vector3.Vector3 C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("COVPARAM", "Single, Single, Single")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void Vector3ConstructorWithFloat()
        {
            tlog.Debug(tag, $"Vector3ConstructorWithFloat START");

            var testingTarget = new Vector3(100.0f, 200.0f, 300.0f);
            Assert.IsNotNull(testingTarget, "Can't create success object Vector3");
            Assert.IsInstanceOf<Vector3>(testingTarget, "Should return Vector3 instance.");

            Assert.AreEqual(100.0f, testingTarget.X, "Retrieved vector.X should be equal to set value");
            Assert.AreEqual(200.0f, testingTarget.Y, "Retrieved vector.Y should be equal to set value");
            Assert.AreEqual(300.0f, testingTarget.Z, "Retrieved vector.Z should be equal to set value");

            testingTarget.Dispose();
            tlog.Debug(tag, $"Vector3ConstructorWithFloat END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Vector3 constructor. With array.")]
        [Property("SPEC", "Tizen.NUI.Vector3.Vector3 C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("COVPARAM", "Single[]")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void Vector3ConstructorWithArray()
        {
            tlog.Debug(tag, $"Vector3ConstructorWithArray START");

            float[] array = new float[3] { 100.0f, 200.0f, 300.0f };

            var testingTarget = new Vector3(array);
            Assert.IsNotNull(testingTarget, "Can't create success object Vector3");
            Assert.IsInstanceOf<Vector3>(testingTarget, "Should return Vector3 instance.");
            
            Assert.AreEqual(100.0f, testingTarget.X, "Retrieved vector.X should be equal to set value");
            Assert.AreEqual(200.0f, testingTarget.Y, "Retrieved vector.Y should be equal to set value");
            Assert.AreEqual(300.0f, testingTarget.Z, "Retrieved vector.Z should be equal to set value");

            testingTarget.Dispose();
            tlog.Debug(tag, $"Vector3ConstructorWithArray END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Vector3 constructor. With Vector2.")]
        [Property("SPEC", "Tizen.NUI.Vector3.Vector3 C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("COVPARAM", "Vector2")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void Vector3ConstructorWithVector2()
        {
            tlog.Debug(tag, $"Vector3ConstructorWithVector2 START");

            using (Vector2 vec2 = new Vector2(100.0f, 200.0f))
            {
                var testingTarget = new Vector3(vec2);
                Assert.IsNotNull(testingTarget, "Can't create success object Vector3");
                Assert.IsInstanceOf<Vector3>(testingTarget, "Should return Vector3 instance.");

                Assert.AreEqual(100.0f, testingTarget.X, "Retrieved vector.X should be equal to set value");
                Assert.AreEqual(200.0f, testingTarget.Y, "Retrieved vector.Y should be equal to set value");
                Assert.AreEqual(0.0f, testingTarget.Z, "Retrieved vector.Z should be equal to set value");

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"Vector3ConstructorWithVector2 END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Vector3 constructor. With Vector4.")]
        [Property("SPEC", "Tizen.NUI.Vector3.Vector3 C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("COVPARAM", "Vector4")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void Vector3ConstructorWithVector4()
        {
            tlog.Debug(tag, $"Vector3ConstructorWithVector4 START");

            using (Vector4 vec4 = new Vector4(100.0f, 200.0f, 300.0f, 400.0f))
            {
                var testingTarget = new Vector3(vec4);
                Assert.IsNotNull(testingTarget, "Can't create success object Vector3");
                Assert.IsInstanceOf<Vector3>(testingTarget, "Should return Vector3 instance.");

                Assert.AreEqual(100.0f, testingTarget.X, "Retrieved vector.X should be equal to set value");
                Assert.AreEqual(200.0f, testingTarget.Y, "Retrieved vector.Y should be equal to set value");
                Assert.AreEqual(300.0f, testingTarget.Z, "Retrieved vector.Z should be equal to set value");

                testingTarget.Dispose();
            }
                
            tlog.Debug(tag, $"Vector3ConstructorWithVector4 END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Vector3 this[uint index].")]
        [Property("SPEC", "Tizen.NUI.Vector3.this[uint] A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void Vector3GetVauleBySubscriptIndex()
        {
            tlog.Debug(tag, $"Vector3GetVauleBySubscriptIndex START");

            var testingTarget = new Vector3(100.0f, 200.0f, 300.0f);
            Assert.IsNotNull(testingTarget, "Can't create success object Vector3");
            Assert.IsInstanceOf<Vector3>(testingTarget, "Should be an instance of Vector3 type.");

            Assert.AreEqual(100.0f, testingTarget[0], "The value of index[0] is not correct!");
            Assert.AreEqual(200.0f, testingTarget[1], "The value of index[1] is not correct!");
            Assert.AreEqual(300.0f, testingTarget[2], "The value of index[2] is not correct!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"Vector3GetVauleBySubscriptIndex END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Vector3 One.")]
        [Property("SPEC", "Tizen.NUI.Vector3.One A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void Vector3One()
        {
            tlog.Debug(tag, $"Vector3One START");

            var testingTarget = Vector3.One;
            Assert.IsNotNull(testingTarget, "Can't create success object Vector3");
            Assert.IsInstanceOf<Vector3>(testingTarget, "Should be an instance of Vector3 type.");

            Assert.AreEqual(1.0f, testingTarget.X, "The value of Vector3.One.X is not correct!");
            Assert.AreEqual(1.0f, testingTarget.Y, "The value of Vector3.One.Y is not correct!");
            Assert.AreEqual(1.0f, testingTarget.Z, "The value of Vector3.One.Z is not correct!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"Vector3One END (OK)");
        }


        [Test]
        [Category("P1")]
        [Description("Vector3 XAxis.")]
        [Property("SPEC", "Tizen.NUI.Vector3.XAxis A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void Vector3XAxis()
        {
            tlog.Debug(tag, $"Vector3XAxis START");

            var testingTarget = Vector3.XAxis;
            Assert.IsNotNull(testingTarget, "Can't create success object Vector3");
            Assert.IsInstanceOf<Vector3>(testingTarget, "Should be an instance of Vector3 type.");

            Assert.AreEqual(1.0f, testingTarget.X, "The value of Vector3.XAxis.X is not correct!");
            Assert.AreEqual(0.0f, testingTarget.Y, "The value of Vector3.XAxis.Y is not correct!");
            Assert.AreEqual(0.0f, testingTarget.Z, "The value of Vector3.XAxis.Z is not correct!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"Vector3XAxis END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Vector3 YAxis.")]
        [Property("SPEC", "Tizen.NUI.Vector3.YAxis A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void Vector3YAxis()
        {
            tlog.Debug(tag, $"Vector3YAxis START");

            var testingTarget = Vector3.YAxis;
            Assert.IsNotNull(testingTarget, "Can't create success object Vector3");
            Assert.IsInstanceOf<Vector3>(testingTarget, "Should be an instance of Vector3 type.");

            Assert.AreEqual(0.0f, testingTarget.X, "The value of Vector3.YAxis.X is not correct!");
            Assert.AreEqual(1.0f, testingTarget.Y, "The value of Vector3.YAxis.Y is not correct!");
            Assert.AreEqual(0.0f, testingTarget.Z, "The value of Vector3.YAxis.Z is not correct!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"Vector3YAxis END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Vector3 ZAxis.")]
        [Property("SPEC", "Tizen.NUI.Vector3.ZAxis A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void Vector3ZAxis()
        {
            tlog.Debug(tag, $"Vector3ZAxis START");

            var testingTarget = Vector3.ZAxis;
            Assert.IsNotNull(testingTarget, "Can't create success object Vector3");
            Assert.IsInstanceOf<Vector3>(testingTarget, "Should be an instance of Vector3 type.");

            Assert.AreEqual(0.0f, testingTarget.X, "The value of Vector3.ZAxis.X is not correct!");
            Assert.AreEqual(0.0f, testingTarget.Y, "The value of Vector3.ZAxis.Y is not correct!");
            Assert.AreEqual(1.0f, testingTarget.Z, "The value of Vector3.ZAxis.Z is not correct!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"Vector3ZAxis END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Vector3 NegativeXAxis.")]
        [Property("SPEC", "Tizen.NUI.Vector3.NegativeXAxis A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void Vector3NegativeXAxis()
        {
            tlog.Debug(tag, $"Vector3NegativeXAxis START");

            var testingTarget = Vector3.NegativeXAxis;
            Assert.IsNotNull(testingTarget, "Can't create success object Vector3");
            Assert.IsInstanceOf<Vector3>(testingTarget, "Should be an instance of Vector3 type.");

            Assert.AreEqual(-1.0f, testingTarget.X, "The value of Vector3.NegativeXAxis.X is not correct!");
            Assert.AreEqual(0.0f, testingTarget.Y, "The value of Vector3.NegativeXAxis.Y is not correct!");
            Assert.AreEqual(0.0f, testingTarget.Z, "The value of Vector3.NegativeXAxis.Z is not correct!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"Vector3NegativeXAxis END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Vector3 NegativeYAxis.")]
        [Property("SPEC", "Tizen.NUI.Vector3.NegativeYAxis A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void Vector3NegativeYAxis()
        {
            tlog.Debug(tag, $"Vector3NegativeYAxis START");

            var testingTarget = Vector3.NegativeYAxis;
            Assert.IsNotNull(testingTarget, "Can't create success object Vector3");
            Assert.IsInstanceOf<Vector3>(testingTarget, "Should be an instance of Vector3 type.");

            Assert.AreEqual(0.0f, testingTarget.X, "The value of Vector3.NegativeYAxis.X is not correct!");
            Assert.AreEqual(-1.0f, testingTarget.Y, "The value of Vector3.NegativeYAxis.Y is not correct!");
            Assert.AreEqual(0.0f, testingTarget.Z, "The value of Vector3.NegativeYAxis.Z is not correct!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"Vector3NegativeYAxis END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Vector3 NegativeZAxis.")]
        [Property("SPEC", "Tizen.NUI.Vector3.NegativeZAxis A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void Vector3NegativeZAxis()
        {
            tlog.Debug(tag, $"Vector3NegativeZAxis START");

            var testingTarget = Vector3.NegativeZAxis;
            Assert.IsNotNull(testingTarget, "Can't create success object Vector3");
            Assert.IsInstanceOf<Vector3>(testingTarget, "Should be an instance of Vector3 type.");

            Assert.AreEqual(0.0f, testingTarget.X, "The value of Vector3.NegativeZAxis.X is not correct!");
            Assert.AreEqual(0.0f, testingTarget.Y, "The value of Vector3.NegativeZAxis.Y is not correct!");
            Assert.AreEqual(-1.0f, testingTarget.Z, "The value of Vector3.NegativeZAxis.Z is not correct!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"Vector3NegativeZAxis END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Vector3 Zero.")]
        [Property("SPEC", "Tizen.NUI.Vector3.Zero A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void Vector3Zero()
        {
            tlog.Debug(tag, $"Vector3Zero START");

            var testingTarget = Vector3.Zero;
            Assert.IsNotNull(testingTarget, "Can't create success object Vector3");
            Assert.IsInstanceOf<Vector3>(testingTarget, "Should be an instance of Vector3 type.");

            Assert.AreEqual(0.0f, testingTarget.X, "The value of Vector3.Zero.X is not correct!");
            Assert.AreEqual(0.0f, testingTarget.Y, "The value of Vector3.Zero.Y is not correct!");
            Assert.AreEqual(0.0f, testingTarget.Z, "The value of Vector3.Zero.Z is not correct!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"Vector3Zero END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Vector3 Length.")]
        [Property("SPEC", "Tizen.NUI.Vector3.Length M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void Vector3Length()
        {
            tlog.Debug(tag, $"Vector3Length START");

            using (Vector3 vector = new Vector3(0.0f, 0.0f, 0.0f))
            {
                Assert.AreEqual(0.0f, vector.Length(), "The length of vector is not correct!");
            }

            using (Vector3 vector = new Vector3(1.0f, 2.0f, 3.0f))
            {
                Assert.AreEqual((float)Math.Sqrt(14.0f), vector.Length(), "The length of vector is not correct here!");
            }
            
            tlog.Debug(tag, $"Vector3Length END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Vector3 LengthSquared.")]
        [Property("SPEC", "Tizen.NUI.Vector3.LengthSquared M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void Vector3LengthSquared()
        {
            tlog.Debug(tag, $"Vector3LengthSquared START");

            using (Vector3 vector = new Vector3(0.0f, 0.0f, 0.0f))
            {
                Assert.AreEqual(0.0f, vector.LengthSquared(), "The length of vector is not correct!");
            }

            using (Vector3 vector = new Vector3(1.0f, 2.0f, 3.0f))
            {
                Assert.AreEqual(14.0f, vector.LengthSquared(), "The length of vector is not correct here!");
            }

            tlog.Debug(tag, $"Vector3LengthSquared END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Vector3 Normalize.")]
        [Property("SPEC", "Tizen.NUI.Vector3.Normalize M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MCST")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void Vector3Normalize()
        {
            tlog.Debug(tag, $"Vector3Normalize START");

            using (Vector3 vector = new Vector3((float)Math.Cosh(0.0f) * 10.0f, (float)Math.Cosh(1.0f) * 10.0f, (float)Math.Cosh(2.0f) * 10.0f))
            {
                vector.Normalize();
                Assert.Less(Math.Abs(1.0f - vector.LengthSquared()), 0.001f, "The value of LengthSquared is wrong");
            }

            using (Vector3 vector = new Vector3(0.0f, 0.0f, 0.0f))
            {
                vector.Normalize();
                Assert.Less(Math.Abs(0.0f - vector.LengthSquared()), 0.00001f, "Should be return 0.0f");
            }

            tlog.Debug(tag, $"Vector3Normalize END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Vector3 Clamp.")]
        [Property("SPEC", "Tizen.NUI.Vector3.Clamp M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MCST")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void Vector3Clamp()
        {
            tlog.Debug(tag, $"Vector3Clamp START");

            var testingTarget = new Vector3(2.0f, 0.8f, 8.0f);
            Assert.IsNotNull(testingTarget, "Can't create success object Vector3");
            Assert.IsInstanceOf<Vector3>(testingTarget, "Should be an instance of Vector3 type.");

            testingTarget.Clamp(new Vector3(1.0f, 4.0f, 0.0f), new Vector3(9.0f, 6.0f, 6.0f));
            Assert.AreEqual(2.0f, testingTarget.X, "2.0 > 1.0(min) && 2.0 < 9.0(max), so the value should be 2.0f");
            Assert.AreEqual(4.0f, testingTarget.Y, "0.8 < 4.0(min), so the value should be 4.0f");
            Assert.AreEqual(6.0f, testingTarget.Z, "8.0 > 6.0(max), so the value should be 6.0f");

            testingTarget.Dispose();
            tlog.Debug(tag, $"Vector3Clamp END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Vector3 GetVectorXY.")]
        [Property("SPEC", "Tizen.NUI.Vector3.GetVectorXY M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void Vector3GetVectorXY()
        {
            tlog.Debug(tag, $"Vector3GetVectorXY START");

            var testingTarget = new Vector3(10.0f, 20.0f, 30.0f);
            Assert.IsNotNull(testingTarget, "Can't create success object Vector3");
            Assert.IsInstanceOf<Vector3>(testingTarget, "Should be an instance of Vector3 type.");

            Assert.AreEqual(10.0f, testingTarget.GetVectorXY().X, "The X value of the vector is not correct!");
            Assert.AreEqual(20.0f, testingTarget.GetVectorXY().Y, "The Y value of the vector is not correct!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"Vector3GetVectorXY END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Vector3 GetVectorYZ.")]
        [Property("SPEC", "Tizen.NUI.Vector3.GetVectorYZ M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void Vector3GetVectorYZ()
        {
            tlog.Debug(tag, $"Vector3GetVectorYZ START");

            var testingTarget = new Vector3(10.0f, 20.0f, 30.0f);
            Assert.IsNotNull(testingTarget, "Can't create success object Vector3");
            Assert.IsInstanceOf<Vector3>(testingTarget, "Should be an instance of Vector3 type.");

            Assert.AreEqual(30.0f, testingTarget.GetVectorYZ().Y, "The Y value of the vector is not correct!");
            Assert.AreEqual(20.0f, testingTarget.GetVectorYZ().X, "The X value of the vector is not correct!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"Vector3GetVectorYZ END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Vector3 Width.")]
        [Property("SPEC", "Tizen.NUI.Vector3.Width A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        [Obsolete]
        public void Vector3Width()
        {
            tlog.Debug(tag, $"Vector3Width START");

            var testingTarget = new Vector3(10.0f, 20.0f, 30.0f);
            Assert.IsNotNull(testingTarget, "Can't create success object Vector3");
            Assert.IsInstanceOf<Vector3>(testingTarget, "Should be an instance of Vector3 type.");

            Assert.AreEqual(10.0f, testingTarget.Width, "The Width value of the vector is not correct!");
            
            testingTarget.Width = 100.0f;
            Assert.AreEqual(100.0f, testingTarget.Width, "The Width value of the vector is not correct here.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"Vector3Width END (OK)");
        }


        [Test]
        [Category("P1")]
        [Description("Vector3 Height.")]
        [Property("SPEC", "Tizen.NUI.Vector3.Height A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        [Obsolete]
        public void Vector3Height()
        {
            tlog.Debug(tag, $"Vector3Height START");

            Vector3 testingTarget = new Vector3(10.0f, 20.0f, 30.0f);
            Assert.IsNotNull(testingTarget, "Can't create success object Vector3");
            Assert.IsInstanceOf<Vector3>(testingTarget, "Should be an instance of Vector3 type.");

            Assert.AreEqual(20.0f, testingTarget.Height, "The Height value of the vector is not correct!");

            testingTarget.Height = 100.0f;
            Assert.AreEqual(100.0f, testingTarget.Height, "The Height value of the vector is not correct here.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"Vector3Height END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Vector3 Depth.")]
        [Property("SPEC", "Tizen.NUI.Vector3.Depth A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        [Obsolete]
        public void Vector3Depth()
        {
            tlog.Debug(tag, $"Vector3Depth START");

            var testingTarget = new Vector3(10.0f, 20.0f, 30.0f);
            Assert.IsNotNull(testingTarget, "Can't create success object Vector3");
            Assert.IsInstanceOf<Vector3>(testingTarget, "Should be an instance of Vector3 type.");

            Assert.AreEqual(30.0f, testingTarget.Depth, "The Depth value of the vector is not correct!");
            
            testingTarget.Depth = 100.0f;
            Assert.AreEqual(100.0f, testingTarget.Depth, "The Depth value of the vector is not correct here.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"Vector3Depth END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Vector3 R.")]
        [Property("SPEC", "Tizen.NUI.Vector3.R A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void Vector3GetR()
        {
            tlog.Debug(tag, $"Vector3GetR START");

            var testingTarget = new Vector3(10.0f, 20.0f, 30.0f);
            Assert.IsNotNull(testingTarget, "Can't create success object Vector3");
            Assert.IsInstanceOf<Vector3>(testingTarget, "Should be an instance of Vector3 type.");

            Assert.AreEqual(10.0f, testingTarget.R, "The R value of the vector is not correct!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"Vector3GetR END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Vector3 G.")]
        [Property("SPEC", "Tizen.NUI.Vector3.G A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void Vector3GetG()
        {
            tlog.Debug(tag, $"Vector3GetG START");

            var testingTarget = new Vector3(10.0f, 20.0f, 30.0f);
            Assert.IsNotNull(testingTarget, "Can't create success object Vector3");
            Assert.IsInstanceOf<Vector3>(testingTarget, "Should be an instance of Vector3 type.");

            Assert.AreEqual(20.0f, testingTarget.G, "The G value of the vector is not correct!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"Vector3GetG END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Vector3 B.")]
        [Property("SPEC", "Tizen.NUI.Vector3.B A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void Vector3GetB()
        {
            tlog.Debug(tag, $"Vector3GetB START");

            var testingTarget = new Vector3(10.0f, 20.0f, 30.0f);
            Assert.IsNotNull(testingTarget, "Can't create success object Vector3");
            Assert.IsInstanceOf<Vector3>(testingTarget, "Should be an instance of Vector3 type.");

            Assert.AreEqual(30.0f, testingTarget.B, "The B value of the vector is not correct!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"Vector3GetB END (OK)");
        }
        [Test]
        [Category("P1")]
        [Description("Vector3 X.")]
        [Property("SPEC", "Tizen.NUI.Vector3.X A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void Vector3GetX()
        {
            tlog.Debug(tag, $"Vector3GetX START");

            var testingTarget = new Vector3(10.0f, 20.0f, 30.0f);
            Assert.IsNotNull(testingTarget, "Can't create success object Vector3");
            Assert.IsInstanceOf<Vector3>(testingTarget, "Should be an instance of Vector3 type.");

            Assert.AreEqual(10.0f, testingTarget.X, "The X value of the vector is not correct!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"Vector3GetX END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Vector3 Y.")]
        [Property("SPEC", "Tizen.NUI.Vector3.Y A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void Vector3GetY()
        {
            tlog.Debug(tag, $"Vector3GetY START");

            var testingTarget = new Vector3(10.0f, 20.0f, 30.0f);
            Assert.IsNotNull(testingTarget, "Can't create success object Vector3");
            Assert.IsInstanceOf<Vector3>(testingTarget, "Should be an instance of Vector3 type.");

            Assert.AreEqual(20.0f, testingTarget.Y, "The Y value of the vector is not correct!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"Vector3GetY END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Vector3 Z.")]
        [Property("SPEC", "Tizen.NUI.Vector3.Z A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void Vector3GetZ()
        {
            tlog.Debug(tag, $"Vector3GetZ START");

            var testingTarget = new Vector3(10.0f, 20.0f, 30.0f);
            Assert.IsNotNull(testingTarget, "Can't create success object Vector3");
            Assert.IsInstanceOf<Vector3>(testingTarget, "Should be an instance of Vector3 type.");

            Assert.AreEqual(30.0f, testingTarget.Z, "The Z value of the vector is not correct!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"Vector3GetZ END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Vector3 operator +.")]
        [Property("SPEC", "Tizen.NUI.Vector3.+ M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void Vector3Addition()
        {
            tlog.Debug(tag, $"Vector3Addition START");

            var testingTarget = new Vector3(10.0f, 20.0f, 30.0f);
            Assert.IsNotNull(testingTarget, "Can't create success object Vector3");
            Assert.IsInstanceOf<Vector3>(testingTarget, "Should be an instance of Vector3 type.");

            using (Vector3 vector = new Vector3(1.0f, 2.0f, 3.0f))
            {
                var result = testingTarget + vector;
                Assert.AreEqual(11.0f, result.X, "The X value of the vector is not correct!");
                Assert.AreEqual(22.0f, result.Y, "The Y value of the vector is not correct!");
                Assert.AreEqual(33.0f, result.Z, "The Z value of the vector is not correct!");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"Vector3Addition END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Vector3 operator -.")]
        [Property("SPEC", "Tizen.NUI.Vector3.- M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void Vector3Subtraction()
        {
            tlog.Debug(tag, $"Vector3Subtraction START");

            var testingTarget = new Vector3(10.0f, 20.0f, 30.0f);
            Assert.IsNotNull(testingTarget, "Can't create success object Vector3");
            Assert.IsInstanceOf<Vector3>(testingTarget, "Should be an instance of Vector3 type.");

            using (Vector3 vector = new Vector3(1.0f, 2.0f, 3.0f))
            {
                var result = testingTarget - vector;
                Assert.AreEqual(9.0f, result.X, "The X value of the vector is not correct!");
                Assert.AreEqual(18.0f, result.Y, "The Y value of the vector is not correct!");
                Assert.AreEqual(27.0f, result.Z, "The Z value of the vector is not correct!");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"Vector3Subtraction END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Vector3 operator -.")]
        [Property("SPEC", "Tizen.NUI.Vector3.UnaryNegation M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void Vector3UnaryNegation()
        {
            tlog.Debug(tag, $"Vector3UnaryNegation START");

            var testingTarget = new Vector3(10.0f, 20.0f, 30.0f);
            Assert.IsNotNull(testingTarget, "Can't create success object Vector3");
            Assert.IsInstanceOf<Vector3>(testingTarget, "Should be an instance of Vector3 type.");

            var result = -testingTarget;
            Assert.AreEqual(-10.0f, result.X, "The X value of the vector is not correct!");
            Assert.AreEqual(-20.0f, result.Y, "The Y value of the vector is not correct!");
            Assert.AreEqual(-30.0f, result.Z, "The Z value of the vector is not correct!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"Vector3UnaryNegation END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Vector3 operator *. By Vector3.")]
        [Property("SPEC", "Tizen.NUI.Vector3.* M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "Vector3, Vector3")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void Vector3MultiplyByVector3()
        {
            tlog.Debug(tag, $"Vector3MultiplyByVector3 START");

            var testingTarget = new Vector3(10.0f, 20.0f, 30.0f);
            Assert.IsNotNull(testingTarget, "Can't create success object Vector3");
            Assert.IsInstanceOf<Vector3>(testingTarget, "Should be an instance of Vector3 type.");

            using (Vector3 vector = new Vector3(1.0f, 2.0f, 3.0f))
            {
                var result = testingTarget * vector;
                Assert.AreEqual(10.0f, result.X, "The X value of the vector is not correct!");
                Assert.AreEqual(40.0f, result.Y, "The Y value of the vector is not correct!");
                Assert.AreEqual(90.0f, result.Z, "The Z value of the vector is not correct!");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"Vector3MultiplyByVector3 END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Vector3 operator *. By Float.")]
        [Property("SPEC", "Tizen.NUI.Vector3.* M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "Vector3, Single")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void Vector3MultiplyByFloat()
        {
            tlog.Debug(tag, $"Vector3MultiplyByFloat START");

            var testingTarget = new Vector3(10.0f, 20.0f, 30.0f);
            Assert.IsNotNull(testingTarget, "Can't create success object Vector3");
            Assert.IsInstanceOf<Vector3>(testingTarget, "Should be an instance of Vector3 type.");

            var result = testingTarget * 10.0f;
            Assert.AreEqual(100.0f, result.X, "The X value of the vector is not correct!");
            Assert.AreEqual(200.0f, result.Y, "The Y value of the vector is not correct!");
            Assert.AreEqual(300.0f, result.Z, "The Z value of the vector is not correct!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"Vector3MultiplyByFloat END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Vector3 operator /. By Vector3.")]
        [Property("SPEC", "Tizen.NUI.Vector3./ M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "Vector3, Vector3")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void Vector3DivisionByVector3()
        {
            tlog.Debug(tag, $"Vector3DivisionByVector3 START");

            var testingTarget = new Vector3(10.0f, 20.0f, 30.0f);
            Assert.IsNotNull(testingTarget, "Can't create success object Vector3");
            Assert.IsInstanceOf<Vector3>(testingTarget, "Should be an instance of Vector3 type.");

            using (Vector3 vector = new Vector3(1.0f, 2.0f, 3.0f))
            {
                var result = testingTarget / vector;
                Assert.AreEqual(10.0f, result.X, "The X value of the vector is not correct!");
                Assert.AreEqual(10.0f, result.Y, "The Y value of the vector is not correct!");
                Assert.AreEqual(10.0f, result.Z, "The Z value of the vector is not correct!");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"Vector3DivisionByVector3 END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Vector3 operator /. By Float.")]
        [Property("SPEC", "Tizen.NUI.Vector3./ M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "Vector3, Single")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void Vector3DivisionByFloat()
        {
            tlog.Debug(tag, $"Vector3DivisionByFloat START");

            var testingTarget = new Vector3(10.0f, 20.0f, 30.0f);
            Assert.IsNotNull(testingTarget, "Can't create success object Vector3");
            Assert.IsInstanceOf<Vector3>(testingTarget, "Should be an instance of Vector3 type.");

            var result = testingTarget / 10.0f;
            Assert.AreEqual(1.0f, result.X, "The X value of the vector is not correct!");
            Assert.AreEqual(2.0f, result.Y, "The Y value of the vector is not correct!");
            Assert.AreEqual(3.0f, result.Z, "The Z value of the vector is not correct!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"Vector3DivisionByFloat END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Vector3 Equals.")]
        [Property("SPEC", "Tizen.NUI.Vector3.Equals M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void Vector3Equals()
        {
            tlog.Debug(tag, $"Vector3Equals START");

            var testingTarget = new Vector3(1.0f, 1.0f, 1.0f);
            Assert.IsNotNull(testingTarget, "Can't create success object Vector3");
            Assert.IsInstanceOf<Vector3>(testingTarget, "Should be an instance of Vector3 type.");

            using (Vector3 vector = new Vector3(1.0f, 1.0f, 1.0f))
            {
                var result = testingTarget.Equals(vector);
                Assert.IsTrue(result, "Should be true here!");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"Vector3Equals END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Vector3 Dispose.")]
        [Property("SPEC", "Tizen.NUI.Vector3.Dispose M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR MCST")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void Vector3Dispose()
        {
            tlog.Debug(tag, $"Vector3Dispose START");

            var testingTarget = new Vector3(10.0f, 20.0f, 30.0f);
            Assert.IsNotNull(testingTarget, "Can't create success object Vector3");
            Assert.IsInstanceOf<Vector3>(testingTarget, "Should be an instance of Vector3 type.");

            try
            {
                testingTarget.Dispose();
            }
            catch (Exception e)
            {
                Assert.Fail("Caught Exception" + e.ToString());
            }

            tlog.Debug(tag, $"Vector3Dispose END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Vector3 GetHashCode.")]
        [Property("SPEC", "Tizen.NUI.Vector3.GetHashCode M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void Vector3GetHashCode()
        {
            tlog.Debug(tag, $"Vector3GetHashCode START");

            var testingTarget = new Vector3(10.0f, 20.0f, 30.0f);
            Assert.IsNotNull(testingTarget, "Can't create success object Vector3");
            Assert.IsInstanceOf<Vector3>(testingTarget, "Should be an instance of Vector3 type.");

            var result = testingTarget.GetHashCode();
            Assert.IsTrue(result >= Int32.MinValue && result <= Int32.MaxValue, "The value of hash is out of Integer range");

            testingTarget.Dispose();
            tlog.Debug(tag, $"Vector3GetHashCode END (OK)");
        }
    }
}
