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
    [Description("public/Common/Vector4")]
    public class PublicVector4Test
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
        [Description("Vector4 constructor.")]
        [Property("SPEC", "Tizen.NUI.Vector4.Vector4 C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void Vector4Constructor()
        {
            tlog.Debug(tag, $"Vector4Constructor START");

            var testingTarget = new Vector4();
            Assert.IsNotNull(testingTarget, "Can't create success object Vector4");
            Assert.IsInstanceOf<Vector4>(testingTarget, "Should return Vector4 instance.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"Vector4Constructor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Vector4 constructor. With Vector4.")]
        [Property("SPEC", "Tizen.NUI.Vector4.Vector4 C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("COVPARAM", "Single,Single,Single,Single")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void Vector4ConstructorWithFloat()
        {
            tlog.Debug(tag, $"Vector4ConstructorWithFloat START");

            var testingTarget = new Vector4(100.0f, 200.0f, 300.0f, 400.0f);
            Assert.IsNotNull(testingTarget, "Can't create success object Vector4");
            Assert.IsInstanceOf<Vector4>(testingTarget, "Should return Vector4 instance.");

            Assert.AreEqual(100.0f, testingTarget.X, "Retrieved vector.X should be equal to set value");
            Assert.AreEqual(200.0f, testingTarget.Y, "Retrieved vector.Y should be equal to set value");
            Assert.AreEqual(300.0f, testingTarget.Z, "Retrieved vector.Z should be equal to set value");
            Assert.AreEqual(400.0f, testingTarget.W, "Retrieved vector.W should be equal to set value");

            testingTarget.Dispose();
            tlog.Debug(tag, $"Vector4ConstructorWithFloat END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Vector4 constructor. With Float.")]
        [Property("SPEC", "Tizen.NUI.Vector4.Vector4 C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("COVPARAM", "Single[]")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void Vector4ConstructorWithArray()
        {
            tlog.Debug(tag, $"Vector4ConstructorWithArray START");

            float[] array = new float[4] { 100.0f, 200.0f, 300.0f, 400.0f };

            var testingTarget = new Vector4(array);
            Assert.IsNotNull(testingTarget, "Can't create success object Vector4");
            Assert.IsInstanceOf<Vector4>(testingTarget, "Should return Vector4 instance.");

            Assert.AreEqual(100.0f, testingTarget.X, "Retrieved vector.X should be equal to set value");
            Assert.AreEqual(200.0f, testingTarget.Y, "Retrieved vector.Y should be equal to set value");
            Assert.AreEqual(300.0f, testingTarget.Z, "Retrieved vector.Z should be equal to set value");
            Assert.AreEqual(400.0f, testingTarget.W, "Retrieved vector.W should be equal to set value");

            testingTarget.Dispose();
            tlog.Debug(tag, $"Vector4ConstructorWithArray END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Vector4 constructor. With Vector2.")]
        [Property("SPEC", "Tizen.NUI.Vector4.Vector4 C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("COVPARAM", "Vector2")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void Vector4ConstructorWithVetcor2()
        {
            tlog.Debug(tag, $"Vector4ConstructorWithVetcor2 START");

            using (Vector2 vector = new Vector2(100.0f, 200.0f))
            {
                var testingTarget = new Vector4(vector);
                Assert.IsNotNull(testingTarget, "Can't create success object Vector4");
                Assert.IsInstanceOf<Vector4>(testingTarget, "Should return Vector4 instance.");

                Assert.AreEqual(100.0f, testingTarget.X, "Retrieved vector.X should be equal to set value");
                Assert.AreEqual(200.0f, testingTarget.Y, "Retrieved vector.Y should be equal to set value");
                Assert.AreEqual(0.0f, testingTarget.Z, "Retrieved vector.Z should be equal to set value");
                Assert.AreEqual(0.0f, testingTarget.W, "Retrieved vector.W should be equal to set value");

                testingTarget.Dispose();
            }
 
            tlog.Debug(tag, $"Vector4ConstructorWithVetcor2 END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Vector4 constructor. With Vector3.")]
        [Property("SPEC", "Tizen.NUI.Vector4.Vector4 C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("COVPARAM", "Vector3")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void Vector4ConstructorWithVector3()
        {
            tlog.Debug(tag, $"Vector4ConstructorWithVector3 START");

            using (Vector3 vector = new Vector3(100.0f, 200.0f, 300.0f))
            {
                var testingTarget = new Vector4(vector);
                Assert.IsNotNull(testingTarget, "Can't create success object Vector4");
                Assert.IsInstanceOf<Vector4>(testingTarget, "Should return Vector4 instance.");

                Assert.AreEqual(100.0f, testingTarget.X, "Retrieved vector.X should be equal to set value");
                Assert.AreEqual(200.0f, testingTarget.Y, "Retrieved vector.Y should be equal to set value");
                Assert.AreEqual(300.0f, testingTarget.Z, "Retrieved vector.Z should be equal to set value");
                Assert.AreEqual(0.0f, testingTarget.W, "Retrieved vector.W should be equal to set value");

                testingTarget.Dispose();
            }
            
            tlog.Debug(tag, $"Vector4ConstructorWithVector3 END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Vector4 this[uint index].")]
        [Property("SPEC", "Tizen.NUI.Vector4.this[uint] A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void Vector4GetVauleBySubscriptIndex()
        {
            tlog.Debug(tag, $"Vector4GetVauleBySubscriptIndex START");

            Vector4 testingTarget = new Vector4(100.0f, 200.0f, 300.0f, 400.0f);
            Assert.IsNotNull(testingTarget, "Can't create success object Vector4");
            Assert.IsInstanceOf<Vector4>(testingTarget, "Should be an instance of Vector4 type.");

            Assert.AreEqual(100.0f, testingTarget[0], "this[0] should return 100.0f");
            Assert.AreEqual(200.0f, testingTarget[1], "this[1] should return 200.0f");
            Assert.AreEqual(300.0f, testingTarget[2], "this[2] should return 300.0f");
            Assert.AreEqual(400.0f, testingTarget[3], "this[3] should return 400.0f");

            testingTarget.Dispose();
            tlog.Debug(tag, $"Vector4GetVauleBySubscriptIndex END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Vector4 One.")]
        [Property("SPEC", "Tizen.NUI.Vector4.One A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void Vector4One()
        {
            tlog.Debug(tag, $"Vector4One START");

            var testingTarget = Vector4.One;
            Assert.IsNotNull(testingTarget, "Can't create success object Vector4");
            Assert.IsInstanceOf<Vector4>(testingTarget, "Should be an instance of Vector4 type.");

            Assert.AreEqual(1.0f, testingTarget.X, "Vector4.One.X should return 1.0f");
            Assert.AreEqual(1.0f, testingTarget.Y, "Vector4.One.Y should return 1.0f");
            Assert.AreEqual(1.0f, testingTarget.Z, "Vector4.One.Z should return 1.0f");
            Assert.AreEqual(1.0f, testingTarget.W, "Vector4.One.W should return 1.0f");

            testingTarget.Dispose();
            tlog.Debug(tag, $"Vector4One END (OK)");
        }


        [Test]
        [Category("P1")]
        [Description("Vector4 XAxis.")]
        [Property("SPEC", "Tizen.NUI.Vector4.XAxis A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void Vector4XAxis()
        {
            tlog.Debug(tag, $"Vector4XAxis START");

            var testingTarget = Vector4.XAxis;
            Assert.IsNotNull(testingTarget, "Can't create success object Vector4");
            Assert.IsInstanceOf<Vector4>(testingTarget, "Should be an instance of Vector4 type.");

            Assert.AreEqual(1.0f, testingTarget.X, "Vector4.XAxis.X should return 1.0f");
            Assert.AreEqual(0.0f, testingTarget.Y, "Vector4.XAxis.Y should return 0.0f");
            Assert.AreEqual(0.0f, testingTarget.Z, "Vector4.XAxis.Z should return 0.0f");
            Assert.AreEqual(0.0f, testingTarget.W, "Vector4.XAxis.W should return 0.0f");

            testingTarget.Dispose();
            tlog.Debug(tag, $"Vector4XAxis END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Vector4 YAxis.")]
        [Property("SPEC", "Tizen.NUI.Vector4.YAxis A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void Vector4YAxis()
        {
            tlog.Debug(tag, $"Vector4YAxis START");

            var testingTarget = Vector4.YAxis;
            Assert.IsNotNull(testingTarget, "Can't create success object Vector4");
            Assert.IsInstanceOf<Vector4>(testingTarget, "Should be an instance of Vector4 type.");

            Assert.AreEqual(0.0f, testingTarget.X, "Vector4.YAxis.X should return 0.0f");
            Assert.AreEqual(1.0f, testingTarget.Y, "Vector4.YAxis.Y should return 1.0f");
            Assert.AreEqual(0.0f, testingTarget.Z, "Vector4.YAxis.Z should return 0.0f");
            Assert.AreEqual(0.0f, testingTarget.W, "Vector4.YAxis.W should return 0.0f");

            testingTarget.Dispose();
            tlog.Debug(tag, $"Vector4YAxis END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Vector4 ZAxis.")]
        [Property("SPEC", "Tizen.NUI.Vector4.ZAxis A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void Vector4ZAxis()
        {
            tlog.Debug(tag, $"Vector4ZAxis START");

            var testingTarget = Vector4.ZAxis;
            Assert.IsNotNull(testingTarget, "Can't create success object Vector4");
            Assert.IsInstanceOf<Vector4>(testingTarget, "Should be an instance of Vector4 type.");

            Assert.AreEqual(0.0f, testingTarget.X, "Vector4.ZAxis.X should return 0.0f");
            Assert.AreEqual(0.0f, testingTarget.Y, "Vector4.ZAxis.Y should return 0.0f");
            Assert.AreEqual(1.0f, testingTarget.Z, "Vector4.ZAxis.Z should return 1.0f");
            Assert.AreEqual(0.0f, testingTarget.W, "Vector4.ZAxis.W should return 0.0f");

            testingTarget.Dispose();
            tlog.Debug(tag, $"Vector4ZAxis END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Vector4 Zero.")]
        [Property("SPEC", "Tizen.NUI.Vector4.Zero A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void Vector4Zero()
        {
            tlog.Debug(tag, $"Vector4Zero START");

            var testingTarget = Vector4.Zero;
            Assert.IsNotNull(testingTarget, "Can't create success object Vector4");
            Assert.IsInstanceOf<Vector4>(testingTarget, "Should be an instance of Vector4 type.");

            Assert.AreEqual(0.0f, testingTarget.X, "Vector4.Zero.X should return 0.0f");
            Assert.AreEqual(0.0f, testingTarget.Y, "Vector4.Zero.Y should return 0.0f");
            Assert.AreEqual(0.0f, testingTarget.Z, "Vector4.Zero.Z should return 0.0f");
            Assert.AreEqual(0.0f, testingTarget.W, "Vector4.Zero.W should return 0.0f");

            testingTarget.Dispose();
            tlog.Debug(tag, $"Vector4Zero END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Vector4 Length.")]
        [Property("SPEC", "Tizen.NUI.Vector4.Length M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void Vector4Length()
        {
            tlog.Debug(tag, $"Vector4Length START");

            using (Vector4 testingTarget = new Vector4(0.0f, 0.0f, 0.0f, 0.0f))
            {
                Assert.AreEqual(0.0f, testingTarget.Length(), "Length == sqrt(0.0*0.0 + 0.0*0.0 + 0.0*0.0)");
            }

            using (Vector4 testingTarget = new Vector4(1.0f, 2.0f, 3.0f, 4.0f))
            {
                Assert.AreEqual((float)Math.Sqrt(14.0f), testingTarget.Length(), "Length == sqrt(1.0*1.0 + 2.0*2.0 + 3.0*3.0)");
            }

            tlog.Debug(tag, $"Vector4Length END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Vector4 LengthSquared.")]
        [Property("SPEC", "Tizen.NUI.Vector4.LengthSquared M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void Vector4LengthSquared()
        {
            tlog.Debug(tag, $"Vector4LengthSquared START");

            using (Vector4 testingTarget = new Vector4(0.0f, 0.0f, 0.0f, 0.0f))
            {
                Assert.AreEqual(0.0f, testingTarget.LengthSquared(), "LengthSquared == (0.0*0.0 + 0.0*0.0 + 0.0*0.0)");
            }

            using (Vector4 testingTarget = new Vector4(1.0f, 2.0f, 3.0f, 4.0f))
            {
                Assert.AreEqual(14.0f, testingTarget.LengthSquared(), "LengthSquared == (1.0*1.0 + 2.0*2.0 + 3.0*3.0)");
            }

            tlog.Debug(tag, $"Vector4LengthSquared END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Vector4 Normalize.")]
        [Property("SPEC", "Tizen.NUI.Vector4.Normalize M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR MCST")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void Vector4Normalize()
        {
            tlog.Debug(tag, $"Vector4Normalize START");

            var testingTarget = new Vector4(1.0f, 1.0f, 2.0f, 0.0f);
            Assert.IsNotNull(testingTarget, "Can't create success object Vector4");
            Assert.IsInstanceOf<Vector4>(testingTarget, "Should be an instance of Vector4 type.");

            testingTarget.Normalize();
            Assert.Less(Math.Abs(1.0f - testingTarget.LengthSquared()), 0.001f, "The value of LengthSquared is wrong");

            testingTarget.Dispose();
            tlog.Debug(tag, $"Vector4Normalize END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Vector4 Clamp.")]
        [Property("SPEC", "Tizen.NUI.Vector4.Clamp M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void Vector4Clamp()
        {
            tlog.Debug(tag, $"Vector4Clamp START");

            var testingTarget = new Vector4(2.0f, 0.8f, 0.0f, 8.0f);
            Assert.IsNotNull(testingTarget, "Can't create success object Vector4");
            Assert.IsInstanceOf<Vector4>(testingTarget, "Should be an instance of Vector4 type.");

            using (Vector4 min = new Vector4(1.0f, 4.0f, 1.5f, 0.0f))
            {
                using (Vector4 max = new Vector4(9.0f, 6.0f, 8.0f, 6.0f))
                {
                    testingTarget.Clamp(min, max);
                    Assert.AreEqual(2.0f, testingTarget.X, "2.0 > 1.0(min) && 2.0 < 9.0(max), so the value should be 2.0f");
                    Assert.AreEqual(4.0f, testingTarget.Y, "0.8 < 4.0(min), so the value should be 4.0f");
                    Assert.AreEqual(1.5f, testingTarget.Z, "0.0 < 1.5(min), so the value should be 1.5ff");
                    Assert.AreEqual(6.0f, testingTarget.W, "8.0 > 6.0(max), so the value should be 6.0f");
                }
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"Vector4Clamp END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Vector4 X.")]
        [Property("SPEC", "Tizen.NUI.Vector4.X A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        [Obsolete]
        public void Vector4GetX()
        {
            tlog.Debug(tag, $"Vector4GetX START");

            var testingTarget = new Vector4(10.0f, 20.0f, 30.0f, 40.0f);
            Assert.IsNotNull(testingTarget, "Can't create success object Vector4");
            Assert.IsInstanceOf<Vector4>(testingTarget, "Should be an instance of Vector4 type.");

            testingTarget.X = 20.0f;
            Assert.AreEqual(20.0f, testingTarget.X, "testingTarget.X should be 20.0f");

            testingTarget.Dispose();
            tlog.Debug(tag, $"Vector4GetX END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Vector4 R.")]
        [Property("SPEC", "Tizen.NUI.Vector4.R A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        [Obsolete]
        public void Vector4GetR()
        {
            tlog.Debug(tag, $"Vector4GetR START");

            var testingTarget = new Vector4(10.0f, 20.0f, 30.0f, 40.0f);
            Assert.IsNotNull(testingTarget, "Can't create success object Vector4");
            Assert.IsInstanceOf<Vector4>(testingTarget, "Should be an instance of Vector4 type.");

            testingTarget.R = 1.0f;
            Assert.AreEqual(1.0f, testingTarget.R, "testingTarget.R should be 20.0f");

            testingTarget.Dispose();
            tlog.Debug(tag, $"Vector4GetR END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Vector4 S.")]
        [Property("SPEC", "Tizen.NUI.Vector4.S A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        [Obsolete]
        public void Vector4GetS()
        {
            tlog.Debug(tag, $"Vector4GetS START");

            var testingTarget = new Vector4(10.0f, 20.0f, 30.0f, 40.0f);
            Assert.IsNotNull(testingTarget, "Can't create success object Vector4");
            Assert.IsInstanceOf<Vector4>(testingTarget, "Should be an instance of Vector4 type.");

            testingTarget.S = 1.0f;
            Assert.AreEqual(1.0f, testingTarget.S, "testingTarget.S should be 20.0f");

            testingTarget.Dispose();
            tlog.Debug(tag, $"Vector4GetS END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Vector4 Y.")]
        [Property("SPEC", "Tizen.NUI.Vector4.Y A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        [Obsolete]
        public void Vector4GetY()
        {
            tlog.Debug(tag, $"Vector4GetY START");

            var testingTarget = new Vector4(10.0f, 20.0f, 30.0f, 40.0f);
            Assert.IsNotNull(testingTarget, "Can't create success object Vector4");
            Assert.IsInstanceOf<Vector4>(testingTarget, "Should be an instance of Vector4 type.");

            testingTarget.Y = 1.0f;
            Assert.AreEqual(1.0f, testingTarget.Y, "testingTarget.Y should be 20.0f");

            testingTarget.Dispose();
            tlog.Debug(tag, $"Vector4GetY END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Vector4 G.")]
        [Property("SPEC", "Tizen.NUI.Vector4.G A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        [Obsolete]
        public void Vector4GetG()
        {
            tlog.Debug(tag, $"Vector4GetG START");

            var testingTarget = new Vector4(10.0f, 20.0f, 30.0f, 40.0f);
            Assert.IsNotNull(testingTarget, "Can't create success object Vector4");
            Assert.IsInstanceOf<Vector4>(testingTarget, "Should be an instance of Vector4 type.");

            testingTarget.G = 1.0f;
            Assert.AreEqual(1.0f, testingTarget.G, "testingTarget.G should be 20.0f");

            testingTarget.Dispose();
            tlog.Debug(tag, $"Vector4GetG END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Vector4 T.")]
        [Property("SPEC", "Tizen.NUI.Vector4.T A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        [Obsolete]
        public void Vector4GetT()
        {
            tlog.Debug(tag, $"Vector4GetT START");

            var testingTarget = new Vector4(10.0f, 20.0f, 30.0f, 40.0f);
            Assert.IsNotNull(testingTarget, "Can't create success object Vector4");
            Assert.IsInstanceOf<Vector4>(testingTarget, "Should be an instance of Vector4 type.");

            testingTarget.T = 1.0f;
            Assert.AreEqual(1.0f, testingTarget.T, "testingTarget.T should be 1.0f");

            testingTarget.Dispose();
            tlog.Debug(tag, $"Vector4GetT END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Vector4 Z.")]
        [Property("SPEC", "Tizen.NUI.Vector4.Z A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        [Obsolete]
        public void Vector4GetZ()
        {
            tlog.Debug(tag, $"Vector4GetZ START");

            var testingTarget = new Vector4(10.0f, 20.0f, 30.0f, 40.0f);
            Assert.IsNotNull(testingTarget, "Can't create success object Vector4");
            Assert.IsInstanceOf<Vector4>(testingTarget, "Should be an instance of Vector4 type.");

            testingTarget.Z = 1.0f;
            Assert.AreEqual(1.0f, testingTarget.Z, "testingTarget.Z should be 1.0f");

            testingTarget.Dispose();
            tlog.Debug(tag, $"Vector4GetZ END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Vector4 B.")]
        [Property("SPEC", "Tizen.NUI.Vector4.B A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        [Obsolete]
        public void Vector4GetB()
        {
            tlog.Debug(tag, $"Vector4GetB START");

            var testingTarget = new Vector4(10.0f, 20.0f, 30.0f, 40.0f);
            Assert.IsNotNull(testingTarget, "Can't create success object Vector4");
            Assert.IsInstanceOf<Vector4>(testingTarget, "Should be an instance of Vector4 type.");

            testingTarget.B = 1.0f;
            Assert.AreEqual(1.0f, testingTarget.B, "testingTarget.B should be 1.0f");

            testingTarget.Dispose();
            tlog.Debug(tag, $"Vector4GetB END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Vector4 P.")]
        [Property("SPEC", "Tizen.NUI.Vector4.P A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        [Obsolete]
        public void Vector4GetP()
        {
            tlog.Debug(tag, $"Vector4GetP START");

            var testingTarget = new Vector4(10.0f, 20.0f, 30.0f, 40.0f);
            Assert.IsNotNull(testingTarget, "Can't create success object Vector4");
            Assert.IsInstanceOf<Vector4>(testingTarget, "Should be an instance of Vector4 type.");

            testingTarget.P = 1.0f;
            Assert.AreEqual(1.0f, testingTarget.P, "testingTarget.P should be 1.0f");

            testingTarget.Dispose();
            tlog.Debug(tag, $"Vector4GetP END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Vector4 W.")]
        [Property("SPEC", "Tizen.NUI.Vector4.W A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        [Obsolete]
        public void Vector4GetW()
        {
            tlog.Debug(tag, $"Vector4GetW START");

            var testingTarget = new Vector4(10.0f, 20.0f, 30.0f, 40.0f);
            Assert.IsNotNull(testingTarget, "Can't create success object Vector4");
            Assert.IsInstanceOf<Vector4>(testingTarget, "Should be an instance of Vector4 type.");

            testingTarget.W = 1.0f;
            Assert.AreEqual(1.0f, testingTarget.W, "testingTarget.W should be 1.0f");

            testingTarget.Dispose();
            tlog.Debug(tag, $"Vector4GetW END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Vector4 A.")]
        [Property("SPEC", "Tizen.NUI.Vector4.A A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        [Obsolete]
        public void Vector4GetA()
        {
            tlog.Debug(tag, $"Vector4GetA START");

            var testingTarget = new Vector4(10.0f, 20.0f, 30.0f, 40.0f);
            Assert.IsNotNull(testingTarget, "Can't create success object Vector4");
            Assert.IsInstanceOf<Vector4>(testingTarget, "Should be an instance of Vector4 type.");

            testingTarget.A = 1.0f;
            Assert.AreEqual(1.0f, testingTarget.A, "testingTarget.A should be 1.0f");

            testingTarget.Dispose();
            tlog.Debug(tag, $"Vector4GetA END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Vector4 Q.")]
        [Property("SPEC", "Tizen.NUI.Vector4.Q A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        [Obsolete]
        public void Vector4GetQ()
        {
            tlog.Debug(tag, $"Vector4GetQ START");

            var testingTarget = new Vector4(10.0f, 20.0f, 30.0f, 40.0f);
            Assert.IsNotNull(testingTarget, "Can't create success object Vector4");
            Assert.IsInstanceOf<Vector4>(testingTarget, "Should be an instance of Vector4 type.");

            testingTarget.Q = 1.0f;
            Assert.AreEqual(1.0f, testingTarget.Q, "testingTarget.Q should be 1.0f");

            testingTarget.Dispose();
            tlog.Debug(tag, $"Vector4GetQ END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Vector4 Addition.")]
        [Property("SPEC", "Tizen.NUI.Vector4.+ M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void Vector4Addition()
        {
            tlog.Debug(tag, $"Vector4Addition START");

            var testingTarget = new Vector4(10.0f, 20.0f, 30.0f, 40.0f);
            Assert.IsNotNull(testingTarget, "Can't create success object Vector4");
            Assert.IsInstanceOf<Vector4>(testingTarget, "Should be an instance of Vector4 type.");

            using (Vector4 vector = new Vector4(1.0f, 2.0f, 3.0f, 4.0f))
            {
                Vector4 result = testingTarget + vector;
                Assert.AreEqual(11.0f, result.X, "vector.X == 10.0f + 1.0f");
                Assert.AreEqual(22.0f, result.Y, "vector.Y == 20.0f + 2.0f");
                Assert.AreEqual(33.0f, result.Z, "vector.Z == 30.0f + 3.0f");
                Assert.AreEqual(44.0f, result.W, "vector.W == 40.0f + 4.0f");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"Vector4Addition END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Vector4 Subtraction.")]
        [Property("SPEC", "Tizen.NUI.Vector4.- M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void Vector4Subtraction()
        {
            tlog.Debug(tag, $"Vector4Subtraction START");

            var testingTarget = new Vector4(10.0f, 20.0f, 30.0f, 40.0f);
            Assert.IsNotNull(testingTarget, "Can't create success object Vector4");
            Assert.IsInstanceOf<Vector4>(testingTarget, "Should be an instance of Vector4 type.");

            using (Vector4 vector = new Vector4(1.0f, 2.0f, 3.0f, 4.0f))
            {
                Vector4 result = testingTarget - vector;
                Assert.AreEqual(9.0f, result.X, "vector.X == 10.0f - 1.0f");
                Assert.AreEqual(18.0f, result.Y, "vector.Y == 20.0f - 2.0f");
                Assert.AreEqual(27.0f, result.Z, "vector.Z == 30.0f - 3.0f");
                Assert.AreEqual(36.0f, result.W, "vector.W == 40.0f - 4.0f");
            }
   
            testingTarget.Dispose();
            tlog.Debug(tag, $"Vector4Subtraction END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Vector4 UnaryNegation.")]
        [Property("SPEC", "Tizen.NUI.Vector4.UnaryNegation M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void Vector4UnaryNegation()
        {
            tlog.Debug(tag, $"Vector4UnaryNegation START");

            var testingTarget = new Vector4(10.0f, 20.0f, 30.0f, 40.0f);
            Assert.IsNotNull(testingTarget, "Can't create success object Vector4");
            Assert.IsInstanceOf<Vector4>(testingTarget, "Should be an instance of Vector4 type.");

            var result = -testingTarget;
            Assert.AreEqual(-10.0f, result.X, "vector.X == -10.0f");
            Assert.AreEqual(-20.0f, result.Y, "vector.Y == -20.0f");
            Assert.AreEqual(-30.0f, result.Z, "vector.Z == -30.0f");
            Assert.AreEqual(-40.0f, result.W, "vector.W == -40.0f");

            testingTarget.Dispose();
            tlog.Debug(tag, $"Vector4UnaryNegation END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Vector4 Multiply. By Vector4.")]
        [Property("SPEC", "Tizen.NUI.Vector4.* M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "Vector4,Vector4")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void Vector4MultiplyByVector4()
        {
            tlog.Debug(tag, $"Vector4MultiplyByVector4 START");

            var testingTarget = new Vector4(10.0f, 20.0f, 30.0f, 40.0f);
            Assert.IsNotNull(testingTarget, "Can't create success object Vector4");
            Assert.IsInstanceOf<Vector4>(testingTarget, "Should be an instance of Vector4 type.");

            using (Vector4 vector = new Vector4(1.0f, 2.0f, 3.0f, 4.0f))
            {
                var result = testingTarget * vector;
                Assert.AreEqual(10.0f, result.X, "vector.X == 10.0f * 1.0f");
                Assert.AreEqual(40.0f, result.Y, "vector.Y == 20.0f * 2.0f");
                Assert.AreEqual(90.0f, result.Z, "vector.Z == 30.0f * 3.0f");
                Assert.AreEqual(160.0f, result.W, "vector.W == 40.0f * 4.0f");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"Vector4MultiplyByVector4 END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Vector4 Multiply. By Float.")]
        [Property("SPEC", "Tizen.NUI.Vector4.* M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "Vector4,Single")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void Vector4MultiplyByFloat()
        {
            tlog.Debug(tag, $"Vector4MultiplyByFloat START");

            var testingTarget = new Vector4(10.0f, 20.0f, 30.0f, 40.0f);
            Assert.IsNotNull(testingTarget, "Can't create success object Vector4");
            Assert.IsInstanceOf<Vector4>(testingTarget, "Should be an instance of Vector4 type.");

            var result = testingTarget * 10.0f;
            Assert.AreEqual(100.0f, result.X, "vector.X == 10.0f * 10.0f");
            Assert.AreEqual(200.0f, result.Y, "vector.Y == 20.0f * 10.0f");
            Assert.AreEqual(300.0f, result.Z, "vector.Z == 30.0f * 10.0f");
            Assert.AreEqual(400.0f, result.W, "vector.W == 40.0f * 10.0f");

            testingTarget.Dispose();
            tlog.Debug(tag, $"Vector4MultiplyByFloat END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Vector4 Division. By Vector4.")]
        [Property("SPEC", "Tizen.NUI.Vector4./ M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "Vector4,Vector4")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void Vector4DivisionByVector4()
        {
            tlog.Debug(tag, $"Vector4DivisionByVector4 START");

            var testingTarget = new Vector4(10.0f, 20.0f, 30.0f, 40.0f);
            Assert.IsNotNull(testingTarget, "Can't create success object Vector4");
            Assert.IsInstanceOf<Vector4>(testingTarget, "Should be an instance of Vector4 type.");

            using (Vector4 vector = new Vector4(1.0f, 2.0f, 3.0f, 4.0f))
            {
                var result = testingTarget / vector;
                Assert.AreEqual(10.0f, result.X, "vector.X == 10.0f");
                Assert.AreEqual(10.0f, result.Y, "vector.Y == 10.0f");
                Assert.AreEqual(10.0f, result.Z, "vector.Z == 10.0f");
                Assert.AreEqual(10.0f, result.W, "vector.W == 10.0f");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"Vector4DivisionByVector4 END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Vector4 Division. By Float.")]
        [Property("SPEC", "Tizen.NUI.Vector4./ M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "Vector4,Single")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void Vector4DivisionByFloat()
        {
            tlog.Debug(tag, $"Vector4DivisionByFloat START");

            var testingTarget = new Vector4(10.0f, 20.0f, 30.0f, 40.0f);
            Assert.IsNotNull(testingTarget, "Can't create success object Vector4");
            Assert.IsInstanceOf<Vector4>(testingTarget, "Should be an instance of Vector4 type.");

            var result = testingTarget / 10.0f;
            Assert.AreEqual(1.0f, result.X, "vector.X == 10.0f / 10.0f");
            Assert.AreEqual(2.0f, result.Y, "vector.X == 20.0f / 10.0f");
            Assert.AreEqual(3.0f, result.Z, "vector.X == 30.0f / 10.0f");
            Assert.AreEqual(4.0f, result.W, "vector.X == 40.0f / 10.0f");

            testingTarget.Dispose();
            tlog.Debug(tag, $"Vector4DivisionByFloat END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Vector4 Equals.")]
        [Property("SPEC", "Tizen.NUI.Vector4.Equals M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void Vector4Equals()
        {
            tlog.Debug(tag, $"Vector4Equals START");

            var testingTarget = new Vector4(1.0f, 1.0f, 1.0f, 1.0f);
            Assert.IsNotNull(testingTarget, "Can't create success object Vector4");
            Assert.IsInstanceOf<Vector4>(testingTarget, "Should be an instance of Vector4 type.");

            using (Vector4 vector = new Vector4(1.0f, 1.0f, 1.0f, 1.0f))
            {
                var result = testingTarget.Equals(vector);
                Assert.IsTrue(result, "Should be true here!");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"Vector4Equals END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Vector4 Dispose.")]
        [Property("SPEC", "Tizen.NUI.Vector4.Dispose M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR MCST")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void Vector4Dispose()
        {
            tlog.Debug(tag, $"Vector4Dispose START");

            var testingTarget = new Vector4(10.0f, 20.0f, 30.0f, 40.0f);
            Assert.IsNotNull(testingTarget, "Can't create success object Vector4");
            Assert.IsInstanceOf<Vector4>(testingTarget, "Should be an instance of Vector4 type.");

            try
            {
                testingTarget.Dispose();
            }
            catch (Exception e)
            {
                Assert.Fail("Caught Exception" + e.ToString());
            }

            tlog.Debug(tag, $"Vector4Dispose END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Vector4 GetHashCode.")]
        [Property("SPEC", "Tizen.NUI.Vector4.GetHashCode M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void Vector4GetHashCode()
        {
            tlog.Debug(tag, $"Vector4GetHashCode START");

            var testingTarget = new Vector4(10.0f, 20.0f, 30.0f, 40.0f);
            Assert.IsNotNull(testingTarget, "Can't create success object Vector4");
            Assert.IsInstanceOf<Vector4>(testingTarget, "Should be an instance of Vector4 type.");

            var result = testingTarget.GetHashCode();
            Assert.IsTrue(result >= Int32.MinValue && result <= Int32.MaxValue, "The value of hash is out of Integer range");

            testingTarget.Dispose();
            tlog.Debug(tag, $"Vector4GetHashCode END (OK)");
        }
    }
}
