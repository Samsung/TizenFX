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
    }
}
