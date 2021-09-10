using NUnit.Framework;
using NUnit.Framework.TUnit;
using System;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("public/Input/KeyValue")]
    internal class PublicKeyValueTest
    {
        private const string tag = "NUITEST";
        private KeyValue keyValue = null;
 
        [SetUp]
        public void Init()
        {
            tlog.Info(tag, "Init() is called!");
            keyValue = new KeyValue();
        }

        [TearDown]
        public void Destroy()
        {
            keyValue.Dispose();
            tlog.Info(tag, "Destroy() is called!");
        }

        [Test]
        [Category("P1")]
        [Description("KeyValue OriginalKey")]
        [Property("SPEC", "Tizen.NUI.KeyValue.OriginalKey A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void KeyValueOriginalKey()
        {
            tlog.Debug(tag, $"KeyValueOriginalKey START");

            keyValue.OriginalKey = 10;

            tlog.Debug(tag, $"KeyValueOriginalKey END (OK)");
        }

        [Test]
        [Category("P2")]
        [Description("KeyValue OriginalKey")]
        [Property("SPEC", "Tizen.NUI.KeyValue.OriginalKey A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void KeyValueOriginalKeyWithNull()
        {
            tlog.Debug(tag, $"KeyValueOriginalKeyWithNull START");

            try
            {
                keyValue.OriginalKey = null;
            }
            catch (ArgumentNullException)
            {
                tlog.Debug(tag, $"KeyValueOriginalKeyWithNull END (OK)");
                Assert.Pass("Caught ArgumentNullException :  Passed!");
            }
        }

        [Test]
        [Category("P1")]
        [Description("KeyValue IntegerKey")]
        [Property("SPEC", "Tizen.NUI.KeyValue.IntegerKey A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void KeyValueIntegerKey()
        {
            tlog.Debug(tag, $"KeyValueIntegerKey START");
            
            keyValue.IntegerKey = 10;
            tlog.Debug(tag, "IntegerKey : " + keyValue.IntegerKey);

            tlog.Debug(tag, $"KeyValueIntegerKey END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("KeyValue StringKey")]
        [Property("SPEC", "Tizen.NUI.KeyValue.StringKey A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void KeyValueStringKey()
        {
            tlog.Debug(tag, $"KeyValueStringKey START");

            keyValue.StringKey = "keyvalue";
            tlog.Debug(tag, "IntegerKey : " + keyValue.StringKey);

            tlog.Debug(tag, $"KeyValueStringKey END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("KeyValue PropertyValue")]
        [Property("SPEC", "Tizen.NUI.KeyValue.PropertyValue A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void KeyValuePropertyValue()
        {
            tlog.Debug(tag, $"KeyValuePropertyValue START");

            using (PropertyValue pValue = new PropertyValue())
            {
                keyValue.PropertyValue = pValue;
                tlog.Debug(tag, "PropertyValue : " + keyValue.PropertyValue);
            }

            tlog.Debug(tag, $"KeyValuePropertyValue END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("KeyValue IntergerValue")]
        [Property("SPEC", "Tizen.NUI.KeyValue.IntergerValue A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void KeyValueIntergerValue()
        {
            tlog.Debug(tag, $"KeyValueIntergerValue START");

            keyValue.IntergerValue = 10;
            tlog.Debug(tag, "IntergerValue : " + keyValue.IntergerValue);

            tlog.Debug(tag, $"KeyValueIntergerValue END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("KeyValue BooleanValue")]
        [Property("SPEC", "Tizen.NUI.KeyValue.BooleanValue A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void KeyValueBooleanValue()
        {
            tlog.Debug(tag, $"KeyValueBooleanValue START");

            keyValue.BooleanValue = true;
            tlog.Debug(tag, "BooleanValue : " + keyValue.BooleanValue);

            var strVal = keyValue.StringValue;
            Assert.AreEqual("error to get StringValue", strVal, "Should be equal!");

            tlog.Debug(tag, $"KeyValueBooleanValue END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("KeyValue SingleValue")]
        [Property("SPEC", "Tizen.NUI.KeyValue.SingleValue A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void KeyValueSingleValue()
        {
            tlog.Debug(tag, $"KeyValueSingleValue START");

            keyValue.SingleValue = 10;
            tlog.Debug(tag, "SingleValue : " + keyValue.SingleValue);

            tlog.Debug(tag, $"KeyValueSingleValue END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("KeyValue StringValue")]
        [Property("SPEC", "Tizen.NUI.KeyValue.StringValue A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void KeyValueStringValue()
        {
            tlog.Debug(tag, $"KeyValueStringValue START");

            keyValue.StringValue = "stringvalue";
            tlog.Debug(tag, "SingleValue : " + keyValue.StringValue);

            tlog.Debug(tag, $"KeyValueStringValue END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("KeyValue Vector2Value")]
        [Property("SPEC", "Tizen.NUI.KeyValue.Vector2Value A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void KeyValueVector2Value()
        {
            tlog.Debug(tag, $"KeyValueVector2Value START");

            using (Vector2 vec2 = new Vector2(1, 1))
            {
                keyValue.Vector2Value = vec2;
                tlog.Debug(tag, "Vector2Value : " + keyValue.Vector2Value);
            }

            tlog.Debug(tag, $"KeyValueVector2Value END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("KeyValue Vector3Value")]
        [Property("SPEC", "Tizen.NUI.KeyValue.Vector3Value A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void KeyValueVector3Value()
        {
            tlog.Debug(tag, $"KeyValueVector3Value START");

            using (Vector3 vec3 = new Vector3(1, 1, 1))
            {
                keyValue.Vector3Value = vec3;
                tlog.Debug(tag, "Vector2Value : " + keyValue.Vector3Value);
            }

            tlog.Debug(tag, $"KeyValueVector3Value END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("KeyValue Vector4Value")]
        [Property("SPEC", "Tizen.NUI.KeyValue.Vector4Value A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void KeyValueVector4Value()
        {
            tlog.Debug(tag, $"KeyValueVector4Value START");

            using (Vector4 vec4 = new Vector4(1, 1, 1, 0))
            {
                keyValue.Vector4Value = vec4;
                tlog.Debug(tag, "Vector4Value : " + keyValue.Vector4Value);
            }

            tlog.Debug(tag, $"KeyValueVector4Value END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("KeyValue PositionValue")]
        [Property("SPEC", "Tizen.NUI.KeyValue.PositionValue A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void KeyValuePositionValue()
        {
            tlog.Debug(tag, $"KeyValuePositionValue START");

            using (Position pos = new Position(1, 1, 0))
            {
                keyValue.PositionValue = pos;
                tlog.Debug(tag, "PositionValue : " + keyValue.PositionValue);
            }

            tlog.Debug(tag, $"KeyValuePositionValue END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("KeyValue Position2DValue")]
        [Property("SPEC", "Tizen.NUI.KeyValue.Position2DValue A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void KeyValuePosition2DValue()
        {
            tlog.Debug(tag, $"KeyValuePosition2DValue START");

            using (Position2D pos2d = new Position2D(1, 1))
            {
                keyValue.Position2DValue = pos2d;
                tlog.Debug(tag, "Position2DValue : " + keyValue.Position2DValue.X);
            }

            tlog.Debug(tag, $"KeyValuePosition2DValue END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("KeyValue SizeValue")]
        [Property("SPEC", "Tizen.NUI.KeyValue.SizeValue A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void KeyValueSizeValue()
        {
            tlog.Debug(tag, $"KeyValueSizeValue START");

            using (Size size = new Size(1, 1, 0))
            {
                keyValue.SizeValue = size;
                tlog.Debug(tag, "SizeValue : " + keyValue.SizeValue);
            }

            tlog.Debug(tag, $"KeyValueSizeValue END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("KeyValue Size2DValue")]
        [Property("SPEC", "Tizen.NUI.KeyValue.Size2DValue A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void KeyValueSize2DValue()
        {
            tlog.Debug(tag, $"KeyValueSize2DValue START");

            using (Size2D size2d = new Size2D(0, 0))
            {
                keyValue.Size2DValue = size2d;
                tlog.Debug(tag, "Size2DValue : " + keyValue.Size2DValue);
            }

            tlog.Debug(tag, $"KeyValueSize2DValue END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("KeyValue ColorValue")]
        [Property("SPEC", "Tizen.NUI.KeyValue.ColorValue A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void KeyValueColorValue()
        {
            tlog.Debug(tag, $"KeyValueColorValue START");

            using (Color color = new Color(0, 0, 0, 0))
            {
                keyValue.ColorValue = color;
                tlog.Debug(tag, "ColorValue : " + keyValue.ColorValue);
            }

            tlog.Debug(tag, $"KeyValueColorValue END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("KeyValue RectangleValue")]
        [Property("SPEC", "Tizen.NUI.KeyValue.RectangleValue A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void KeyValueRectangleValue()
        {
            tlog.Debug(tag, $"KeyValueRectangleValue START");

            using (Rectangle rec = new Rectangle(0, 0, 0, 0))
            {
                keyValue.RectangleValue = rec;
                tlog.Debug(tag, "RectangleValue : " + keyValue.RectangleValue);
            }

            tlog.Debug(tag, $"KeyValueRectangleValue END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("KeyValue RotationValue")]
        [Property("SPEC", "Tizen.NUI.KeyValue.RotationValue A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void KeyValueRotationValue()
        {
            tlog.Debug(tag, $"KeyValueRotationValue START");

            using (Rotation rotation = new Rotation())
            {
                keyValue.RotationValue = rotation;
                tlog.Debug(tag, "RotationValue : " + keyValue.RotationValue);
            }

            tlog.Debug(tag, $"KeyValueRotationValue END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("KeyValue RelativeVector2Value")]
        [Property("SPEC", "Tizen.NUI.KeyValue.RelativeVector2Value A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void KeyValueRelativeVector2Value()
        {
            tlog.Debug(tag, $"KeyValueRelativeVector2Value START");

            using (RelativeVector2 rVec2 = new RelativeVector2(0, 0))
            {
                keyValue.RelativeVector2Value = rVec2;
                tlog.Debug(tag, "RelativeVector2Value : " + keyValue.RelativeVector2Value);
            }

            tlog.Debug(tag, $"KeyValueRelativeVector2Value END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("KeyValue RelativeVector3Value")]
        [Property("SPEC", "Tizen.NUI.KeyValue.RelativeVector3Value A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void KeyValueRelativeVector3Value()
        {
            tlog.Debug(tag, $"KeyValueRelativeVector3Value START");

            using (RelativeVector3 rVec3 = new RelativeVector3(0, 0, 0))
            {
                keyValue.RelativeVector3Value = rVec3;
                tlog.Debug(tag, "RelativeVector3Value : " + keyValue.RelativeVector3Value);
            }

            tlog.Debug(tag, $"KeyValueRelativeVector3Value END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("KeyValue RelativeVector4Value")]
        [Property("SPEC", "Tizen.NUI.KeyValue.RelativeVector4Value A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void KeyValueRelativeVector4Value()
        {
            tlog.Debug(tag, $"KeyValueRelativeVector4Value START");

            using (RelativeVector4 rVec4 = new RelativeVector4(0, 0, 0, 0))
            {
                keyValue.RelativeVector4Value = rVec4;
                tlog.Debug(tag, "RelativeVector4Value : " + keyValue.RelativeVector4Value);
            }

            tlog.Debug(tag, $"KeyValueRelativeVector4Value END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("KeyValue ExtentsValue")]
        [Property("SPEC", "Tizen.NUI.KeyValue.ExtentsValue A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void KeyValueExtentsValue()
        {
            tlog.Debug(tag, $"KeyValueExtentsValue START");

            using (Extents ext = new Extents(0, 0, 0, 0))
            {
                keyValue.ExtentsValue = ext;
                tlog.Debug(tag, "ExtentsValue : " + keyValue.ExtentsValue);
            }

            tlog.Debug(tag, $"KeyValueExtentsValue END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("KeyValue PropertyArrayValue")]
        [Property("SPEC", "Tizen.NUI.KeyValue.PropertyArrayValue A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void KeyValuePropertyArrayValue()
        {
            tlog.Debug(tag, $"KeyValuePropertyArrayValue START");

            using (PropertyArray pArr = new PropertyArray())
            {
                keyValue.PropertyArrayValue = pArr;
                tlog.Debug(tag, "PropertyArrayValue : " + keyValue.PropertyArrayValue);
            }

            tlog.Debug(tag, $"KeyValuePropertyArrayValue END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("KeyValue PropertyMapValue")]
        [Property("SPEC", "Tizen.NUI.KeyValue.PropertyMapValue A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void KeyValuePropertyMapValue()
        {
            tlog.Debug(tag, $"KeyValuePropertyMapValue START");

            using (PropertyMap pMap = new PropertyMap())
            {
                keyValue.PropertyMapValue = pMap;
                tlog.Debug(tag, "PropertyMapValue : " + keyValue.PropertyMapValue);
            }

            tlog.Debug(tag, $"KeyValuePropertyMapValue END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("KeyValue IntergerValue")]
        [Property("SPEC", "Tizen.NUI.KeyValue.IntergerValue A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void KeyValueIntergerValueGetError()
        {
            tlog.Debug(tag, $"KeyValueIntergerValueGetError START");

            keyValue.Value = "IntergerValue";

            var result = keyValue.IntergerValue;
            Assert.AreEqual(-1, result, "Should be equal!");

            var sigVal = keyValue.SingleValue;
            Assert.AreEqual(-1, sigVal, "Should be equal!");

            var boolVal = keyValue.BooleanValue;
            Assert.AreEqual(false, boolVal, "Should be equal!");

            var v2Value = keyValue.Vector2Value;
            Assert.AreEqual(0, v2Value.X, "Should be equal!");
            Assert.AreEqual(0, v2Value.Y, "Should be equal!");

            var v3Value = keyValue.Vector3Value;
            Assert.AreEqual(0, v3Value.X, "Should be equal!");
            Assert.AreEqual(0, v3Value.Y, "Should be equal!");
            Assert.AreEqual(0, v3Value.Z, "Should be equal!");

            var v4Value = keyValue.Vector4Value;
            Assert.AreEqual(0, v4Value.X, "Should be equal!");
            Assert.AreEqual(0, v4Value.Y, "Should be equal!");
            Assert.AreEqual(0, v4Value.Z, "Should be equal!");
            Assert.AreEqual(0, v4Value.W, "Should be equal!");

            var pos = keyValue.PositionValue;
            Assert.AreEqual(0, pos.X, "Should be equal!");
            Assert.AreEqual(0, pos.Y, "Should be equal!");
            Assert.AreEqual(0, pos.Z, "Should be equal!");

            var size = keyValue.SizeValue;
            Assert.AreEqual(0, size.Width, "Should be equal!");
            Assert.AreEqual(0, size.Height, "Should be equal!");
            Assert.AreEqual(0, size.Depth, "Should be equal!");

            var size2d = keyValue.Size2DValue;
            Assert.AreEqual(0, size2d.Width, "Should be equal!");
            Assert.AreEqual(0, size2d.Height, "Should be equal!");

            var colorVal = keyValue.ColorValue;
            Assert.AreEqual(0, colorVal.R, "Should be equal!");
            Assert.AreEqual(0, colorVal.G, "Should be equal!");
            Assert.AreEqual(0, colorVal.B, "Should be equal!");
            Assert.AreEqual(0, colorVal.A, "Should be equal!");

            var recVal = keyValue.RectangleValue;
            Assert.AreEqual(0, recVal.X, "Should be equal!");
            Assert.AreEqual(0, recVal.Y, "Should be equal!");
            Assert.AreEqual(0, recVal.Width, "Should be equal!");
            Assert.AreEqual(0, recVal.Height, "Should be equal!");

            var relativeV2 = keyValue.RelativeVector2Value;
            Assert.AreEqual(0, relativeV2.X, "Should be equal!");
            Assert.AreEqual(0, relativeV2.Y, "Should be equal!");

            var relativeV3 = keyValue.RelativeVector3Value;
            Assert.AreEqual(0, relativeV3.X, "Should be equal!");
            Assert.AreEqual(0, relativeV3.Y, "Should be equal!");
            Assert.AreEqual(0, relativeV3.Z, "Should be equal!");

            var relativeV4 = keyValue.RelativeVector4Value;
            Assert.AreEqual(0, relativeV4.X, "Should be equal!");
            Assert.AreEqual(0, relativeV4.Y, "Should be equal!");
            Assert.AreEqual(0, relativeV4.Z, "Should be equal!");
            Assert.AreEqual(0, relativeV4.W, "Should be equal!");

            var extVal = keyValue.ExtentsValue;
            Assert.AreEqual(0, extVal.Start, "Should be equal!");
            Assert.AreEqual(0, extVal.End, "Should be equal!");
            Assert.AreEqual(0, extVal.Top, "Should be equal!");
            Assert.AreEqual(0, extVal.Bottom, "Should be equal!");

            var propertyArr = keyValue.PropertyArrayValue;
            Assert.IsNotNull(propertyArr, "Can't create success object PropertyArray");
            Assert.IsInstanceOf<PropertyArray>(propertyArr, "Should be an instance of PropertyArray type.");

            var propertyMap = keyValue.PropertyMapValue;
            Assert.IsNotNull(propertyMap, "Can't create success object PropertyMap");
            Assert.IsInstanceOf<PropertyMap>(propertyMap, "Should be an instance of PropertyMap type.");

            tlog.Debug(tag, $"KeyValueIntergerValueGetError END (OK)");
        }
    }
}