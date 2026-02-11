using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("public/Common/PropertyValue")]
    public class PropertyValueTest
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
        [Description("Set value test for PropertyValue.EqualTo")]
        [Property("SPEC", "Tizen.NUI.Common.PropertyValue.EqualTo")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "eunkiki.hong@samsung.com")]
        public void EqualTo_INT_VALUE()
        {
            /* TEST CODE */
            int expectValue = 3;
            PropertyValue v1 = new PropertyValue(expectValue);
            PropertyValue v2 = new PropertyValue(expectValue);

            int getValue = 0;
            Assert.AreEqual(true, v1.Get(out getValue), "v1 should have integer value");
            Assert.AreEqual(expectValue, getValue, "v1 should have expected value");
            Assert.AreEqual(true, v2.Get(out getValue), "v2 should have integer value");
            Assert.AreEqual(expectValue, getValue, "v2 should have expected value");

            Assert.AreEqual(true, v1.EqualTo(v2), "v1 and v2 should have same value");

            v1.Dispose();
            v2.Dispose();
        }

        [Test]
        [Category("P1")]
        [Description("Set value test for PropertyValue.EqualTo")]
        [Property("SPEC", "Tizen.NUI.Common.PropertyValue.EqualTo")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "eunkiki.hong@samsung.com")]
        public void EqualTo_FLOAT_VALUE()
        {
            /* TEST CODE */
            float expectValue = 3.0f;
            PropertyValue v1 = new PropertyValue(expectValue);
            PropertyValue v2 = new PropertyValue(expectValue);

            float getValue = 0;
            Assert.AreEqual(true, v1.Get(out getValue), "v1 should have float value");
            Assert.AreEqual(expectValue, getValue, "v1 should have expected value");
            Assert.AreEqual(true, v2.Get(out getValue), "v2 should have float value");
            Assert.AreEqual(expectValue, getValue, "v2 should have expected value");

            Assert.AreEqual(true, v1.EqualTo(v2), "v1 and v2 should have same value");

            v1.Dispose();
            v2.Dispose();
        }

        [Test]
        [Category("P1")]
        [Description("Set value test for PropertyValue.EqualTo")]
        [Property("SPEC", "Tizen.NUI.Common.PropertyValue.EqualTo")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "eunkiki.hong@samsung.com")]
        public void EqualTo_BOOL_VALUE()
        {
            /* TEST CODE */
            bool expectValue = true;
            PropertyValue v1 = new PropertyValue(expectValue);
            PropertyValue v2 = new PropertyValue(expectValue);

            bool getValue = false;
            Assert.AreEqual(true, v1.Get(out getValue), "v1 should have float value");
            Assert.AreEqual(expectValue, getValue, "v1 should have expected value");
            Assert.AreEqual(true, v2.Get(out getValue), "v2 should have float value");
            Assert.AreEqual(expectValue, getValue, "v2 should have expected value");

            Assert.AreEqual(true, v1.EqualTo(v2), "v1 and v2 should have same value");

            v1.Dispose();
            v2.Dispose();
        }

        [Test]
        [Category("P1")]
        [Description("Set value test for PropertyValue.EqualTo")]
        [Property("SPEC", "Tizen.NUI.Common.PropertyValue.EqualTo")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "eunkiki.hong@samsung.com")]
        public void EqualTo_STRING_VALUE()
        {
            /* TEST CODE */
            string expectValue = "Hello, World!";
            PropertyValue v1 = new PropertyValue(expectValue);
            PropertyValue v2 = new PropertyValue("Hello, World!");

            string getValue = "";
            Assert.AreEqual(true, v1.Get(out getValue), "v1 should have string value");
            Assert.AreEqual(expectValue, getValue, "v1 should have expected value");
            Assert.AreEqual(true, v2.Get(out getValue), "v2 should have string value");
            Assert.AreEqual(expectValue, getValue, "v2 should have expected value");

            Assert.AreEqual(true, v1.EqualTo(v2), "v1 and v2 should have same value");

            v1.Dispose();
            v2.Dispose();
        }

        [Test]
        [Category("P1")]
        [Description("Set value test for PropertyValue.EqualTo")]
        [Property("SPEC", "Tizen.NUI.Common.PropertyValue.EqualTo")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "eunkiki.hong@samsung.com")]
        public void EqualTo_VECTOR2_VALUE()
        {
            /* TEST CODE */
            Vector2 expectValue = new Vector2(1.0f, 2.0f);
            PropertyValue v1 = new PropertyValue(expectValue);
            PropertyValue v2 = new PropertyValue(expectValue);
            PropertyValue v3 = new PropertyValue(new Vector2(1.0f, 2.0f));

            Vector2 getValue = new Vector2();
            Assert.AreEqual(true, v1.Get(getValue), "v1 should have Vector2 value");
            Assert.AreEqual(expectValue, getValue, "v1 should have expected value");
            Assert.AreEqual(true, v2.Get(getValue), "v2 should have Vector2 value");
            Assert.AreEqual(expectValue, getValue, "v2 should have expected value");
            Assert.AreEqual(true, v3.Get(getValue), "v3 should have Vector2 value");
            Assert.AreEqual(expectValue, getValue, "v3 should have expected value");

            Assert.AreEqual(true, v1.EqualTo(v2), "v1 and v2 should have same value");
            Assert.AreEqual(true, v1.EqualTo(v3), "v1 and v3 should have same value");
            Assert.AreEqual(true, v2.EqualTo(v3), "v2 and v3 should have same value");

            v1.Dispose();
            v2.Dispose();
            v3.Dispose();
            
            expectValue.Dispose();
            getValue.Dispose();
        }

        [Test]
        [Category("P1")]
        [Description("Set value test for PropertyValue.EqualTo")]
        [Property("SPEC", "Tizen.NUI.Common.PropertyValue.EqualTo")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "eunkiki.hong@samsung.com")]
        public void EqualTo_VECTOR4_VALUE()
        {
            /* TEST CODE */
            Vector4 expectValue = new Vector4(1.0f, 2.0f, 3.0f, 4.0f);
            PropertyValue v1 = new PropertyValue(expectValue);
            PropertyValue v2 = new PropertyValue(expectValue);
            PropertyValue v3 = new PropertyValue(new Vector4(1.0f, 2.0f, 3.0f, 4.0f));

            Vector4 getValue = new Vector4();
            Assert.AreEqual(true, v1.Get(getValue), "v1 should have Vector4 value");
            Assert.AreEqual(expectValue, getValue, "v1 should have expected value");
            Assert.AreEqual(true, v2.Get(getValue), "v2 should have Vector4 value");
            Assert.AreEqual(expectValue, getValue, "v2 should have expected value");
            Assert.AreEqual(true, v3.Get(getValue), "v3 should have Vector4 value");
            Assert.AreEqual(expectValue, getValue, "v3 should have expected value");

            Assert.AreEqual(true, v1.EqualTo(v2), "v1 and v2 should have same value");
            Assert.AreEqual(true, v1.EqualTo(v3), "v1 and v3 should have same value");
            Assert.AreEqual(true, v2.EqualTo(v3), "v2 and v3 should have same value");

            v1.Dispose();
            v2.Dispose();
            v3.Dispose();

            expectValue.Dispose();
            getValue.Dispose();
        }

        [Test]
        [Category("P1")]
        [Description("Set value test for PropertyValue.NotEqualTo")]
        [Property("SPEC", "Tizen.NUI.Common.PropertyValue.NotEqualTo")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "eunkiki.hong@samsung.com")]
        public void NotEqualTo_INT_VALUE()
        {
            /* TEST CODE */
            int expectValue1 = 3;
            int expectValue2 = expectValue1 + 1;
            PropertyValue v1 = new PropertyValue(expectValue1);
            PropertyValue v2 = new PropertyValue(expectValue2);

            int getValue = 0;
            Assert.AreEqual(true, v1.Get(out getValue), "v1 should have integer value");
            Assert.AreEqual(expectValue1, getValue, "v1 should have expected1 value");
            Assert.AreEqual(true, v2.Get(out getValue), "v2 should have integer value");
            Assert.AreEqual(expectValue2, getValue, "v2 should have expected2 value");

            Assert.AreEqual(false, v1.EqualTo(v2), "v1 and v2 should not have same value");
            Assert.AreEqual(true, v1.NotEqualTo(v2), "v1 and v2 should not have same value");

            v1.Dispose();
            v2.Dispose();
        }

        [Test]
        [Category("P1")]
        [Description("PropertyValue Set. With boolean")]
        [Property("SPEC", "Tizen.NUI.PropertyValue.Set M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Eunki Hong, eunkiki.hong@samsung.com")]
        public void PropertyValueSet_BOOL_VALUE()
        {
            tlog.Debug(tag, $"PropertyValueSetBoolean START");

            using PropertyValue testingTarget = new PropertyValue();

            bool testingValue = true;
            Assert.IsNotNull(testingTarget, "Can't create success object PropertyValue.");
            Assert.IsInstanceOf<PropertyValue>(testingTarget, "Should return PropertyValue instance.");

            Assert.AreEqual(PropertyType.None, testingTarget.GetType(), "Type should be none");

            testingTarget.Set(testingValue);

            Assert.AreEqual(PropertyType.Boolean, testingTarget.GetType(), "Type should be boolean");
            Assert.AreEqual(true, testingTarget.Get(out bool resultValue), "boolean get failed");
            Assert.AreEqual(testingValue, resultValue, "testing value not match with result value");

            tlog.Debug(tag, $"PropertyValueSetBoolean END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("PropertyValue Set. With float")]
        [Property("SPEC", "Tizen.NUI.PropertyValue.Set M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Eunki Hong, eunkiki.hong@samsung.com")]
        public void PropertyValueSet_FLOAT_VALUE()
        {
            tlog.Debug(tag, $"PropertyValueSetFloat START");

            using PropertyValue testingTarget = new PropertyValue();

            float testingValue = 3.14f;
            Assert.IsNotNull(testingTarget, "Can't create success object PropertyValue.");
            Assert.IsInstanceOf<PropertyValue>(testingTarget, "Should return PropertyValue instance.");

            Assert.AreEqual(PropertyType.None, testingTarget.GetType(), "Type should be none");

            testingTarget.Set(testingValue);

            Assert.AreEqual(PropertyType.Float, testingTarget.GetType(), "Type should be float");
            Assert.AreEqual(true, testingTarget.Get(out float resultValue), "float get failed");
            Assert.AreEqual(testingValue, resultValue, "testing value not match with result value");

            tlog.Debug(tag, $"PropertyValueSetFloat END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("PropertyValue Set. With integer")]
        [Property("SPEC", "Tizen.NUI.PropertyValue.Set M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Eunki Hong, eunkiki.hong@samsung.com")]
        public void PropertyValueSet_INT_VALUE()
        {
            tlog.Debug(tag, $"PropertyValueSetInt START");

            using PropertyValue testingTarget = new PropertyValue();

            int testingValue = 42;
            Assert.IsNotNull(testingTarget, "Can't create success object PropertyValue.");
            Assert.IsInstanceOf<PropertyValue>(testingTarget, "Should return PropertyValue instance.");

            Assert.AreEqual(PropertyType.None, testingTarget.GetType(), "Type should be none");

            testingTarget.Set(testingValue);

            Assert.AreEqual(PropertyType.Integer, testingTarget.GetType(), "Type should be integer");
            Assert.AreEqual(true, testingTarget.Get(out int resultValue), "integer get failed");
            Assert.AreEqual(testingValue, resultValue, "testing value not match with result value");

            tlog.Debug(tag, $"PropertyValueSetInt END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("PropertyValue Set. With Vector2")]
        [Property("SPEC", "Tizen.NUI.PropertyValue.Set M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Eunki Hong, eunkiki.hong@samsung.com")]
        public void PropertyValueSet_VECTOR2_VALUE()
        {
            tlog.Debug(tag, $"PropertyValueSetVector2 START");

            using PropertyValue testingTarget = new PropertyValue();
            using Vector2 testingValue = new Vector2(1.0f, 2.0f);
            using Vector2 resultValue = new Vector2();

            Assert.IsNotNull(testingTarget, "Can't create success object PropertyValue.");
            Assert.IsInstanceOf<PropertyValue>(testingTarget, "Should return PropertyValue instance.");

            Assert.AreEqual(PropertyType.None, testingTarget.GetType(), "Type should be none");

            testingTarget.Set(testingValue);

            Assert.AreEqual(PropertyType.Vector2, testingTarget.GetType(), "Type should be vector2");
            Assert.AreEqual(true, testingTarget.Get(resultValue), "vector2 get failed");
            Assert.AreEqual(testingValue, resultValue, "testing value not match with result value");

            tlog.Debug(tag, $"PropertyValueSetVector2 END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("PropertyValue Set. With Vector3")]
        [Property("SPEC", "Tizen.NUI.PropertyValue.Set M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Eunki Hong, eunkiki.hong@samsung.com")]
        public void PropertyValueSet_VECTOR3_VALUE()
        {
            tlog.Debug(tag, $"PropertyValueSetVector3 START");

            using PropertyValue testingTarget = new PropertyValue();
            using Vector3 testingValue = new Vector3(1.0f, 2.0f, 3.0f);
            using Vector3 resultValue = new Vector3();

            Assert.IsNotNull(testingTarget, "Can't create success object PropertyValue.");
            Assert.IsInstanceOf<PropertyValue>(testingTarget, "Should return PropertyValue instance.");

            Assert.AreEqual(PropertyType.None, testingTarget.GetType(), "Type should be none");

            testingTarget.Set(testingValue);

            Assert.AreEqual(PropertyType.Vector3, testingTarget.GetType(), "Type should be vector3");
            Assert.AreEqual(true, testingTarget.Get(resultValue), "vector3 get failed");
            Assert.AreEqual(testingValue, resultValue, "testing value not match with result value");

            tlog.Debug(tag, $"PropertyValueSetVector3 END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("PropertyValue Set. With Vector4")]
        [Property("SPEC", "Tizen.NUI.PropertyValue.Set M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Eunki Hong, eunkiki.hong@samsung.com")]
        public void PropertyValueSet_VECTOR4_VALUE()
        {
            tlog.Debug(tag, $"PropertyValueSetVector4 START");

            using PropertyValue testingTarget = new PropertyValue();
            using Vector4 testingValue = new Vector4(1.0f, 2.0f, 3.0f, 4.0f);
            using Vector4 resultValue = new Vector4();

            Assert.IsNotNull(testingTarget, "Can't create success object PropertyValue.");
            Assert.IsInstanceOf<PropertyValue>(testingTarget, "Should return PropertyValue instance.");

            Assert.AreEqual(PropertyType.None, testingTarget.GetType(), "Type should be none");

            testingTarget.Set(testingValue);

            Assert.AreEqual(PropertyType.Vector4, testingTarget.GetType(), "Type should be vector4");
            Assert.AreEqual(true, testingTarget.Get(resultValue), "vector4 get failed");
            Assert.AreEqual(testingValue, resultValue, "testing value not match with result value");

            tlog.Debug(tag, $"PropertyValueSetVector4 END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("PropertyValue Set. With Matrix3")]
        [Property("SPEC", "Tizen.NUI.PropertyValue.Set M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Eunki Hong, eunkiki.hong@samsung.com")]
        public void PropertyValueSet_MATRIX3_VALUE()
        {
            tlog.Debug(tag, $"PropertyValueSetMatrix3 START");

            using PropertyValue testingTarget = new PropertyValue();
            using Matrix3 testingValue = new Matrix3(0.0f, 1.0f, 2.0f, 3.0f, 4.0f, 5.0f, 6.0f, 7.0f, 8.0f);
            using Matrix3 resultValue = new Matrix3();

            Assert.IsNotNull(testingTarget, "Can't create success object PropertyValue.");
            Assert.IsInstanceOf<PropertyValue>(testingTarget, "Should return PropertyValue instance.");

            Assert.AreEqual(PropertyType.None, testingTarget.GetType(), "Type should be none");

            testingTarget.Set(testingValue);

            Assert.AreEqual(PropertyType.Matrix3, testingTarget.GetType(), "Type should be matrix3");
            Assert.AreEqual(true, testingTarget.Get(resultValue), "matrix3 get failed");

            for(uint index = 0; index < 9; ++index)
            {
                float expectResult = (float)index;
                Assert.AreEqual(expectResult, resultValue.ValueOfIndex(index), "The value of index is not correct!");
            }

            tlog.Debug(tag, $"PropertyValueSetMatrix3 END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("PropertyValue Set. With Matrix")]
        [Property("SPEC", "Tizen.NUI.PropertyValue.Set M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Eunki Hong, eunkiki.hong@samsung.com")]
        public void PropertyValueSet_MATRIX_VALUE()
        {
            tlog.Debug(tag, $"PropertyValueSetMatrix START");

            float[] array = {1.0f, 0.0f, 0.0f, 0.0f, 0.0f, 2.0f, 0.0f, 0.0f, 0.0f, 0.0f, 3.0f, 0.0f, 0.0f, 0.0f, 0.0f, 4.0f};

            using PropertyValue testingTarget = new PropertyValue();
            using Matrix testingValue = new Matrix(array);
            using Matrix resultValue = new Matrix();

            Assert.IsNotNull(testingTarget, "Can't create success object PropertyValue.");
            Assert.IsInstanceOf<PropertyValue>(testingTarget, "Should return PropertyValue instance.");

            Assert.AreEqual(PropertyType.None, testingTarget.GetType(), "Type should be none");

            testingTarget.Set(testingValue);

            Assert.AreEqual(PropertyType.Matrix, testingTarget.GetType(), "Type should be matrix");
            Assert.AreEqual(true, testingTarget.Get(resultValue), "matrix get failed");

            for(uint index = 0; index < 16; ++index)
            {
                float expectResult = array[index];
                Assert.AreEqual(expectResult, resultValue.ValueOfIndex(index), "The value of index is not correct!");
            }

            tlog.Debug(tag, $"PropertyValueSetMatrix END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("PropertyValue Set. With Rectangle")]
        [Property("SPEC", "Tizen.NUI.PropertyValue.Set M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Eunki Hong, eunkiki.hong@samsung.com")]
        public void PropertyValueSet_RECTANGLE_VALUE()
        {
            tlog.Debug(tag, $"PropertyValueSetRectangle START");

            using PropertyValue testingTarget = new PropertyValue();
            using Rectangle testingValue = new Rectangle(10, 20, 100, 200);
            using Rectangle resultValue = new Rectangle();

            Assert.IsNotNull(testingTarget, "Can't create success object PropertyValue.");
            Assert.IsInstanceOf<PropertyValue>(testingTarget, "Should return PropertyValue instance.");

            Assert.AreEqual(PropertyType.None, testingTarget.GetType(), "Type should be none");

            testingTarget.Set(testingValue);

            Assert.AreEqual(PropertyType.Rectangle, testingTarget.GetType(), "Type should be rectangle");
            Assert.AreEqual(true, testingTarget.Get(resultValue), "rectangle get failed");
            Assert.AreEqual(testingValue.X, resultValue.X, "X value not match");
            Assert.AreEqual(testingValue.Y, resultValue.Y, "Y value not match");
            Assert.AreEqual(testingValue.Width, resultValue.Width, "Width value not match");
            Assert.AreEqual(testingValue.Height, resultValue.Height, "Height value not match");

            tlog.Debug(tag, $"PropertyValueSetRectangle END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("PropertyValue Set. With Quaternion")]
        [Property("SPEC", "Tizen.NUI.PropertyValue.Set M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Eunki Hong, eunkiki.hong@samsung.com")]
        public void PropertyValueSet_QUATERNION_VALUE()
        {
            tlog.Debug(tag, $"PropertyValueSetQuaternion START");

            using PropertyValue testingTarget = new PropertyValue();
            using Rotation testingValue = new Rotation(new Radian(1.0f), new Vector3(0.0f, 1.0f, 0.0f));
            using Rotation resultValue = new Rotation();

            Assert.IsNotNull(testingTarget, "Can't create success object PropertyValue.");
            Assert.IsInstanceOf<PropertyValue>(testingTarget, "Should return PropertyValue instance.");

            Assert.AreEqual(PropertyType.None, testingTarget.GetType(), "Type should be none");

            testingTarget.Set(testingValue);

            Assert.AreEqual(PropertyType.Rotation, testingTarget.GetType(), "Type should be rotation");
            Assert.AreEqual(true, testingTarget.Get(resultValue), "quaternion get failed");
            
            using Radian testingPitch = new Radian();
            using Radian testingYaw = new Radian();
            using Radian testingRoll = new Radian();

            using Radian resultPitch = new Radian();
            using Radian resultYaw = new Radian();
            using Radian resultRoll = new Radian();

            testingValue.GetEulerAngle(testingPitch, testingYaw, testingRoll);
            resultValue.GetEulerAngle(resultPitch, resultYaw, resultRoll);
            Assert.AreEqual(testingPitch.Value, resultPitch.Value, "Pitch value not match with result value");
            Assert.AreEqual(testingYaw.Value, resultYaw.Value, "Yae value not match with result value");
            Assert.AreEqual(testingRoll.Value, resultRoll.Value, "Roll value not match with result value");

            tlog.Debug(tag, $"PropertyValueSetQuaternion END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("PropertyValue Set. With string")]
        [Property("SPEC", "Tizen.NUI.PropertyValue.Set M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Eunki Hong, eunkiki.hong@samsung.com")]
        public void PropertyValueSet_STRING_VALUE()
        {
            tlog.Debug(tag, $"PropertyValueSetString START");

            using PropertyValue testingTarget = new PropertyValue();

            string testingValue = "Hello, Tizen.NUI!";
            Assert.IsNotNull(testingTarget, "Can't create success object PropertyValue.");
            Assert.IsInstanceOf<PropertyValue>(testingTarget, "Should return PropertyValue instance.");

            Assert.AreEqual(PropertyType.None, testingTarget.GetType(), "Type should be none");

            testingTarget.Set(testingValue);

            Assert.AreEqual(PropertyType.String, testingTarget.GetType(), "Type should be string");
            Assert.AreEqual(true, testingTarget.Get(out string resultValue), "string get failed");
            Assert.AreEqual(testingValue, resultValue, "testing value not match with result value");

            tlog.Debug(tag, $"PropertyValueSetString END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("PropertyValue Set. With Array")]
        [Property("SPEC", "Tizen.NUI.PropertyValue.Set M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Eunki Hong, eunkiki.hong@samsung.com")]
        public void PropertyValueSet_ARRAY_VALUE()
        {
            tlog.Debug(tag, $"PropertyValueSetArray START");

            using PropertyValue testingTarget = new PropertyValue();
            using PropertyArray testingValue = new PropertyArray();
            using PropertyArray resultValue = new PropertyArray();

            testingValue.Add(new PropertyValue(1));
            testingValue.Add(new PropertyValue(2));
            testingValue.Add(new PropertyValue(3));

            Assert.IsNotNull(testingTarget, "Can't create success object PropertyValue.");
            Assert.IsInstanceOf<PropertyValue>(testingTarget, "Should return PropertyValue instance.");

            Assert.AreEqual(PropertyType.None, testingTarget.GetType(), "Type should be none");

            testingTarget.Set(testingValue);

            Assert.AreEqual(PropertyType.Array, testingTarget.GetType(), "Type should be array");
            Assert.AreEqual(true, testingTarget.Get(resultValue), "array get failed");
            Assert.AreEqual(3, resultValue.Count(), "array count should be 3");

            tlog.Debug(tag, $"PropertyValueSetArray END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("PropertyValue Set. With Map")]
        [Property("SPEC", "Tizen.NUI.PropertyValue.Set M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Eunki Hong, eunkiki.hong@samsung.com")]
        public void PropertyValueSet_MAP_VALUE()
        {
            tlog.Debug(tag, $"PropertyValueSetMap START");

            using PropertyValue testingTarget = new PropertyValue();
            using PropertyMap testingValue = new PropertyMap();
            using PropertyMap resultValue = new PropertyMap();

            testingValue.Add("key1", 1);
            testingValue.Add("key2", 2.0f);
            testingValue.Add("key3", "value3");

            Assert.IsNotNull(testingTarget, "Can't create success object PropertyValue.");
            Assert.IsInstanceOf<PropertyValue>(testingTarget, "Should return PropertyValue instance.");

            Assert.AreEqual(PropertyType.None, testingTarget.GetType(), "Type should be none");

            testingTarget.Set(testingValue);

            Assert.AreEqual(PropertyType.Map, testingTarget.GetType(), "Type should be map");
            Assert.AreEqual(true, testingTarget.Get(resultValue), "map get failed");
            Assert.AreEqual(3, resultValue.Count(), "map count should be 3");

            tlog.Debug(tag, $"PropertyValueSetMap END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("PropertyValue Set. With Extents")]
        [Property("SPEC", "Tizen.NUI.PropertyValue.Set M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Eunki Hong, eunkiki.hong@samsung.com")]
        public void PropertyValueSet_EXTENTS_VALUE()
        {
            tlog.Debug(tag, $"PropertyValueSetExtents START");

            using PropertyValue testingTarget = new PropertyValue();
            using Extents testingValue = new Extents(1, 2, 3, 4);
            using Extents resultValue = new Extents();

            Assert.IsNotNull(testingTarget, "Can't create success object PropertyValue.");
            Assert.IsInstanceOf<PropertyValue>(testingTarget, "Should return PropertyValue instance.");

            Assert.AreEqual(PropertyType.None, testingTarget.GetType(), "Type should be none");

            testingTarget.Set(testingValue);

            Assert.AreEqual(PropertyType.Extents, testingTarget.GetType(), "Type should be extents");
            Assert.AreEqual(true, testingTarget.Get(resultValue), "extents get failed");
            Assert.AreEqual(testingValue.Start, resultValue.Start, "Start value not match with result value");
            Assert.AreEqual(testingValue.End, resultValue.End, "End value not match with result value");
            Assert.AreEqual(testingValue.Top, resultValue.Top, "Top value not match with result value");
            Assert.AreEqual(testingValue.Bottom, resultValue.Bottom, "Bottom value not match with result value");

            tlog.Debug(tag, $"PropertyValueSetExtents END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("PropertyValue Set. With UIVector2")]
        [Property("SPEC", "Tizen.NUI.PropertyValue.Set M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Eunki Hong, eunkiki.hong@samsung.com")]
        public void PropertyValueSet_UIVECTOR2_VALUE()
        {
            tlog.Debug(tag, $"PropertyValueSet_UIVECTOR2_VALUE START");

            using PropertyValue testingTarget = new PropertyValue();
            UIVector2 testingVector = new UIVector2(5.5f, 6.0f);
            using Vector2 resultValue = new Vector2();

            Assert.IsNotNull(testingTarget, "Can't create success object PropertyValue.");
            Assert.IsInstanceOf<PropertyValue>(testingTarget, "Should return PropertyValue instance.");

            Assert.AreEqual(PropertyType.None, testingTarget.GetType(), "Type should be none");

            testingTarget.Set(testingVector);

            Assert.AreEqual(PropertyType.Vector2, testingTarget.GetType(), "Type should be vector2");
            Assert.AreEqual(true, testingTarget.Get(resultValue), "vector2 get failed");
            Assert.AreEqual(testingVector.X, resultValue.X, "X value not match");
            Assert.AreEqual(testingVector.Y, resultValue.Y, "Y value not match");

            tlog.Debug(tag, $"PropertyValueSet_UIVECTOR2_VALUE END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("PropertyValue Set. With UIVector3")]
        [Property("SPEC", "Tizen.NUI.PropertyValue.Set M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Eunki Hong, eunkiki.hong@samsung.com")]
        public void PropertyValueSet_UIVECTOR3_VALUE()
        {
            tlog.Debug(tag, $"PropertyValueSet_UIVECTOR3_VALUE START");

            using PropertyValue testingTarget = new PropertyValue();
            UIVector3 testingVector = new UIVector3(5.5f, 6.0f);
            using Vector3 resultValue = new Vector3();

            Assert.IsNotNull(testingTarget, "Can't create success object PropertyValue.");
            Assert.IsInstanceOf<PropertyValue>(testingTarget, "Should return PropertyValue instance.");

            Assert.AreEqual(PropertyType.None, testingTarget.GetType(), "Type should be none");

            testingTarget.Set(testingVector);

            Assert.AreEqual(PropertyType.Vector3, testingTarget.GetType(), "Type should be vector3");
            Assert.AreEqual(true, testingTarget.Get(resultValue), "vector3 get failed");
            Assert.AreEqual(testingVector.X, resultValue.X, "X value not match");
            Assert.AreEqual(testingVector.Y, resultValue.Y, "Y value not match");
            Assert.AreEqual(testingVector.Z, resultValue.Z, "Z value not match");

            tlog.Debug(tag, $"PropertyValueSet_UIVECTOR3_VALUE END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("PropertyValue Set. With UIColor")]
        [Property("SPEC", "Tizen.NUI.PropertyValue.Set M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Eunki Hong, eunkiki.hong@samsung.com")]
        public void PropertyValueSet_UICOLOR_VALUE()
        {
            tlog.Debug(tag, $"PropertyValueSet_UICOLOR_VALUE START");

            using PropertyValue testingTarget = new PropertyValue();
            UIColor testingColor = new UIColor(0.0f, 1.0f, 0.0f, 0.5f);
            using Vector4 resultValue = new Vector4();

            Assert.IsNotNull(testingTarget, "Can't create success object PropertyValue.");
            Assert.IsInstanceOf<PropertyValue>(testingTarget, "Should return PropertyValue instance.");

            Assert.AreEqual(PropertyType.None, testingTarget.GetType(), "Type should be none");

            testingTarget.Set(testingColor);

            Assert.AreEqual(PropertyType.Vector4, testingTarget.GetType(), "Type should be vector4");
            Assert.AreEqual(true, testingTarget.Get(resultValue), "vector4 get failed");
            Assert.AreEqual(testingColor.R, resultValue.X, "X value not match");
            Assert.AreEqual(testingColor.G, resultValue.Y, "Y value not match");
            Assert.AreEqual(testingColor.B, resultValue.Z, "Z value not match");
            Assert.AreEqual(testingColor.A, resultValue.W, "W value not match");

            tlog.Debug(tag, $"PropertyValueSet_UICOLOR_VALUE END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("PropertyValue Set. With UICorner")]
        [Property("SPEC", "Tizen.NUI.PropertyValue.Set M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Eunki Hong, eunkiki.hong@samsung.com")]
        public void PropertyValueSet_UICORNER_VALUE()
        {
            tlog.Debug(tag, $"PropertyValueSet_UICORNER_VALUE START");

            using PropertyValue testingTarget = new PropertyValue();
            UICorner testingCorner = new UICorner(4.0f, 5.0f, 6.0f, 7.0f);
            using Vector4 resultValue = new Vector4();

            Assert.IsNotNull(testingTarget, "Can't create success object PropertyValue.");
            Assert.IsInstanceOf<PropertyValue>(testingTarget, "Should return PropertyValue instance.");

            Assert.AreEqual(PropertyType.None, testingTarget.GetType(), "Type should be none");

            testingTarget.Set(testingCorner);

            Assert.AreEqual(PropertyType.Vector4, testingTarget.GetType(), "Type should be vector4");
            Assert.AreEqual(true, testingTarget.Get(resultValue), "vector4 get failed");
            Assert.AreEqual(testingCorner.TopLeft, resultValue.X, "X value not match");
            Assert.AreEqual(testingCorner.TopRight, resultValue.Y, "Y value not match");
            Assert.AreEqual(testingCorner.BottomRight, resultValue.Z, "Z value not match");
            Assert.AreEqual(testingCorner.BottomLeft, resultValue.W, "W value not match");

            tlog.Debug(tag, $"PropertyValueSet_UICORNER_VALUE END (OK)");
        }
    }
}
