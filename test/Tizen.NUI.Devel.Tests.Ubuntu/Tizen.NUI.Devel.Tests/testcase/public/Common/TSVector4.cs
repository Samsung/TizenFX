using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("public/Common/Vector4")]
    public class Vector4Test
    {
        private const string tag = "NUITEST";

        private const float c_epsilon = 0.0001f;

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
        [Description("Vector4 constructor. With float")]
        [Property("SPEC", "Tizen.NUI.Matrix.Vector4 C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "Eunki Hong, eunkiki.hong@samsung.com")]
        public void Vector4ConstructorWithSingleFloat()
        {
            tlog.Debug(tag, $"Vector4ConstructorWithSingleFloat START");

            float testingValue = 1.0f;
            Vector4 testingTarget = testingValue;
            Assert.IsNotNull(testingTarget, "Can't create success object Vector4.");
            Assert.IsInstanceOf<Vector4>(testingTarget, "Should return Vector4 instance.");

            Assert.AreEqual(testingTarget.X, testingValue, c_epsilon, "Value should be equal");
            Assert.AreEqual(testingTarget.Y, testingValue, c_epsilon, "Value should be equal");
            Assert.AreEqual(testingTarget.Z, testingValue, c_epsilon, "Value should be equal");
            Assert.AreEqual(testingTarget.W, testingValue, c_epsilon, "Value should be equal");

            testingTarget.Dispose();
            tlog.Debug(tag, $"Vector4ConstructorWithSingleFloat END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Vector4 Length.")]
        [Property("SPEC", "Tizen.NUI.Vector4.Length M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Eunki Hong, eunkiki.hong@samsung.com")]
        public void Vector4LengthV2()
        {
            tlog.Debug(tag, $"Vector4LengthV2 START");

            var testingTarget = new Vector4(1.0f, 2.0f, 3.0f, 4.0f);
            Assert.IsNotNull(testingTarget, "Can't create success object Vector4.");
            Assert.IsInstanceOf<Vector4>(testingTarget, "Should return Vector4 instance.");

            float targetLengthSquared = 1.0f * 1.0f + 2.0f * 2.0f + 3.0f * 3.0f + 4.0f * 4.0f;

            Assert.AreEqual(testingTarget.Length(), (float)Math.Sqrt(targetLengthSquared), c_epsilon, "Value should be equal");

            testingTarget.Dispose();
            tlog.Debug(tag, $"Vector4LengthV2 END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Vector4 Length3.")]
        [Property("SPEC", "Tizen.NUI.Vector4.Length3 M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Eunki Hong, eunkiki.hong@samsung.com")]
        public void Vector4Length3()
        {
            tlog.Debug(tag, $"Vector4Length3 START");

            var testingTarget = new Vector4(1.0f, 2.0f, 3.0f, 4.0f);
            Assert.IsNotNull(testingTarget, "Can't create success object Vector4.");
            Assert.IsInstanceOf<Vector4>(testingTarget, "Should return Vector4 instance.");

            float targetLengthSquared = 1.0f * 1.0f + 2.0f * 2.0f + 3.0f * 3.0f;

            Assert.AreEqual(testingTarget.Length3(), (float)Math.Sqrt(targetLengthSquared), c_epsilon, "Value should be equal");

            testingTarget.Dispose();
            tlog.Debug(tag, $"Vector4Length3 END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Vector4 LengthSquared.")]
        [Property("SPEC", "Tizen.NUI.Vector4.LengthSquared M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Eunki Hong, eunkiki.hong@samsung.com")]
        public void Vector4LengthSquaredV2()
        {
            tlog.Debug(tag, $"Vector4LengthSquaredV2 START");

            var testingTarget = new Vector4(1.0f, 2.0f, 3.0f, 4.0f);
            Assert.IsNotNull(testingTarget, "Can't create success object Vector4.");
            Assert.IsInstanceOf<Vector4>(testingTarget, "Should return Vector4 instance.");

            float targetLengthSquared = 1.0f * 1.0f + 2.0f * 2.0f + 3.0f * 3.0f + 4.0f * 4.0f;

            Assert.AreEqual(testingTarget.LengthSquared(), targetLengthSquared, c_epsilon, "Value should be equal");

            testingTarget.Dispose();
            tlog.Debug(tag, $"Vector4LengthSquaredV2 END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Vector4 LengthSquared3.")]
        [Property("SPEC", "Tizen.NUI.Vector4.LengthSquared3 M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Eunki Hong, eunkiki.hong@samsung.com")]
        public void Vector4LengthSquared3()
        {
            tlog.Debug(tag, $"Vector4LengthSquared3 START");

            var testingTarget = new Vector4(1.0f, 2.0f, 3.0f, 4.0f);
            Assert.IsNotNull(testingTarget, "Can't create success object Vector4.");
            Assert.IsInstanceOf<Vector4>(testingTarget, "Should return Vector4 instance.");

            float targetLengthSquared = 1.0f * 1.0f + 2.0f * 2.0f + 3.0f * 3.0f;

            Assert.AreEqual(testingTarget.LengthSquared3(), targetLengthSquared, c_epsilon, "Value should be equal");

            testingTarget.Dispose();
            tlog.Debug(tag, $"Vector4LengthSquared3 END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Vector4 Normalize.")]
        [Property("SPEC", "Tizen.NUI.Vector4.Normalize M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Eunki Hong, eunkiki.hong@samsung.com")]
        public void Vector4NormalizeV2()
        {
            tlog.Debug(tag, $"Vector4NormalizeV2 START");

            var testingTarget = new Vector4(1.0f, 2.0f, 3.0f, 4.0f);
            Assert.IsNotNull(testingTarget, "Can't create success object Vector4.");
            Assert.IsInstanceOf<Vector4>(testingTarget, "Should return Vector4 instance.");

            float targetLengthSquared = 1.0f * 1.0f + 2.0f * 2.0f + 3.0f * 3.0f + 4.0f * 4.0f;
            float targetLength = (float)Math.Sqrt(targetLengthSquared);

            try
            {
                testingTarget.Normalize();
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            Assert.AreEqual(testingTarget.X, 1.0f / targetLength, c_epsilon, "Value should be equal");
            Assert.AreEqual(testingTarget.Y, 2.0f / targetLength, c_epsilon, "Value should be equal");
            Assert.AreEqual(testingTarget.Z, 3.0f / targetLength, c_epsilon, "Value should be equal");
            Assert.AreEqual(testingTarget.W, 4.0f / targetLength, c_epsilon, "Value should be equal");

            testingTarget.Dispose();
            tlog.Debug(tag, $"Vector4NormalizeV2 END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Vector4 Normalize3.")]
        [Property("SPEC", "Tizen.NUI.Vector4.Normalize3 M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Eunki Hong, eunkiki.hong@samsung.com")]
        public void Vector4Normalize3()
        {
            tlog.Debug(tag, $"Vector4Normalize3 START");

            var testingTarget = new Vector4(1.0f, 2.0f, 3.0f, 4.0f);
            Assert.IsNotNull(testingTarget, "Can't create success object Vector4.");
            Assert.IsInstanceOf<Vector4>(testingTarget, "Should return Vector4 instance.");

            float targetLengthSquared = 1.0f * 1.0f + 2.0f * 2.0f + 3.0f * 3.0f;
            float targetLength = (float)Math.Sqrt(targetLengthSquared);

            try
            {
                testingTarget.Normalize3();
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            Assert.AreEqual(testingTarget.X, 1.0f / targetLength, c_epsilon, "Value should be equal");
            Assert.AreEqual(testingTarget.Y, 2.0f / targetLength, c_epsilon, "Value should be equal");
            Assert.AreEqual(testingTarget.Z, 3.0f / targetLength, c_epsilon, "Value should be equal");
            Assert.AreEqual(testingTarget.W, 4.0f, c_epsilon, "Value should be equal");

            testingTarget.Dispose();
            tlog.Debug(tag, $"Vector4Normalize3 END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Vector4 Dot.")]
        [Property("SPEC", "Tizen.NUI.Vector4.Dot M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Eunki Hong, eunkiki.hong@samsung.com")]
        public void Vector4Dot()
        {
            tlog.Debug(tag, $"Vector4Dot START");

            var testingTarget1 = new Vector4(1.0f, 2.0f, 3.0f, 4.0f);
            var testingTarget2 = new Vector4(5.0f, 6.0f, 7.0f, 8.0f);
            Assert.IsNotNull(testingTarget1, "Can't create success object Vector4.");
            Assert.IsInstanceOf<Vector4>(testingTarget1, "Should return Vector4 instance.");
            Assert.IsNotNull(testingTarget2, "Can't create success object Vector4.");
            Assert.IsInstanceOf<Vector4>(testingTarget2, "Should return Vector4 instance.");

            float targetValue = 1.0f * 5.0f + 2.0f * 6.0f + 3.0f * 7.0f + 4.0f * 8.0f;

            Assert.AreEqual(testingTarget1.Dot(testingTarget2), targetValue, c_epsilon, "Value should be equal");
            Assert.AreEqual(testingTarget2.Dot(testingTarget1), targetValue, c_epsilon, "Value should be equal");

            testingTarget1.Dispose();
            testingTarget2.Dispose();
            tlog.Debug(tag, $"Vector4Dot END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Vector4 Dot. With Vector3")]
        [Property("SPEC", "Tizen.NUI.Vector4.Dot M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Eunki Hong, eunkiki.hong@samsung.com")]
        public void Vector4DotWithVector3()
        {
            tlog.Debug(tag, $"Vector4DotWithVector3 START");

            var testingTarget1 = new Vector4(1.0f, 2.0f, 3.0f, 4.0f);
            var testingTarget2 = new Vector3(5.0f, 6.0f, 7.0f);
            Assert.IsNotNull(testingTarget1, "Can't create success object Vector4.");
            Assert.IsInstanceOf<Vector4>(testingTarget1, "Should return Vector4 instance.");
            Assert.IsNotNull(testingTarget2, "Can't create success object Vector3.");
            Assert.IsInstanceOf<Vector3>(testingTarget2, "Should return Vector3 instance.");

            float targetValue = 1.0f * 5.0f + 2.0f * 6.0f + 3.0f * 7.0f;

            Assert.AreEqual(testingTarget1.Dot(testingTarget2), targetValue, c_epsilon, "Value should be equal");

            testingTarget1.Dispose();
            testingTarget2.Dispose();
            tlog.Debug(tag, $"Vector4DotWithVector3 END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Vector4 Dot3.")]
        [Property("SPEC", "Tizen.NUI.Vector4.Dot3 M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Eunki Hong, eunkiki.hong@samsung.com")]
        public void Vector4Dot3()
        {
            tlog.Debug(tag, $"Vector4Dot3 START");

            var testingTarget1 = new Vector4(1.0f, 2.0f, 3.0f, 4.0f);
            var testingTarget2 = new Vector4(5.0f, 6.0f, 7.0f, 8.0f);
            Assert.IsNotNull(testingTarget1, "Can't create success object Vector4.");
            Assert.IsInstanceOf<Vector4>(testingTarget1, "Should return Vector4 instance.");
            Assert.IsNotNull(testingTarget2, "Can't create success object Vector4.");
            Assert.IsInstanceOf<Vector4>(testingTarget2, "Should return Vector4 instance.");

            float targetValue = 1.0f * 5.0f + 2.0f * 6.0f + 3.0f * 7.0f;

            Assert.AreEqual(testingTarget1.Dot3(testingTarget2), targetValue, c_epsilon, "Value should be equal");
            Assert.AreEqual(testingTarget2.Dot3(testingTarget1), targetValue, c_epsilon, "Value should be equal");

            testingTarget1.Dispose();
            testingTarget2.Dispose();
            tlog.Debug(tag, $"Vector4Dot3 END (OK)");
        }
    }
}
