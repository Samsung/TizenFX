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
        [Description("KeyValue OriginalKey")]
        [Property("SPEC", "Tizen.NUI.KeyValue.OriginalKey A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void KeyValueOriginalKey()
        {
            tlog.Debug(tag, $"KeyValueOriginalKey START");
            KeyValue a1 = new KeyValue();
            a1.OriginalKey = 10;

            a1.Dispose();
            tlog.Debug(tag, $"KeyValueOriginalKey END (OK)");
            Assert.Pass("KeyValueOriginalKey");
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
            KeyValue a1 = new KeyValue
            {
                IntegerKey = 10
            };

            int? b1 = a1.IntegerKey;

            a1.Dispose();
            tlog.Debug(tag, $"KeyValueIntegerKey END (OK)");
            Assert.Pass("KeyValueIntegerKey");
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
            KeyValue a1 = new KeyValue
            {
                StringKey = "keyvalue"
            };

            string b1 = a1.StringKey;

            a1.Dispose();
            tlog.Debug(tag, $"KeyValueStringKey END (OK)");
            Assert.Pass("KeyValueStringKey");
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

            PropertyValue p1 = new PropertyValue();
            KeyValue a1 = new KeyValue
            {
                PropertyValue = p1
            };

            p1 = a1.PropertyValue;

            a1.Dispose();
            tlog.Debug(tag, $"KeyValuePropertyValue END (OK)");
            Assert.Pass("KeyValuePropertyValue");
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

            KeyValue a1 = new KeyValue
            {
                IntergerValue = 10
            };

            int b1 = a1.IntergerValue;

            a1.Dispose();
            tlog.Debug(tag, $"KeyValueIntergerValue END (OK)");
            Assert.Pass("KeyValueIntergerValue");
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

            KeyValue a1 = new KeyValue
            {
                BooleanValue = true
            };

            bool b1 = a1.BooleanValue;

            a1.Dispose();
            tlog.Debug(tag, $"KeyValueBooleanValue END (OK)");
            Assert.Pass("KeyValueBooleanValue");
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

            KeyValue a1 = new KeyValue
            {
                SingleValue = 10
            };

            float b1 = a1.SingleValue;

            a1.Dispose();
            tlog.Debug(tag, $"KeyValueSingleValue END (OK)");
            Assert.Pass("KeyValueSingleValue");
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

            KeyValue a1 = new KeyValue
            {
                StringValue = "stringvalue"
            };

            string b1 = a1.StringValue;

            a1.Dispose();
            tlog.Debug(tag, $"KeyValueStringValue END (OK)");
            Assert.Pass("KeyValueStringValue");
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

            Vector2 b1 = new Vector2(1, 1);
            KeyValue a1 = new KeyValue
            {
                Vector2Value = b1
            };

            b1 = a1.Vector2Value;

            b1.Dispose();
            a1.Dispose();
            tlog.Debug(tag, $"KeyValueVector2Value END (OK)");
            Assert.Pass("KeyValueVector2Value");
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

            Vector3 b1 = new Vector3(1, 1, 1);
            KeyValue a1 = new KeyValue
            {
                Vector3Value = b1
            };

            b1 = a1.Vector3Value;

            b1.Dispose();
            a1.Dispose();
            tlog.Debug(tag, $"KeyValueVector3Value END (OK)");
            Assert.Pass("KeyValueVector3Value");
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

            Vector4 b1 = new Vector4(1, 1, 1, 0);
            KeyValue a1 = new KeyValue
            {
                Vector4Value = b1
            };

            b1 = a1.Vector4Value;

            b1.Dispose();
            a1.Dispose();
            tlog.Debug(tag, $"KeyValueVector4Value END (OK)");
            Assert.Pass("KeyValueVector4Value");
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

            Position b1 = new Position(1, 1, 0);
            KeyValue a1 = new KeyValue
            {
                PositionValue = b1
            };

            b1 = a1.PositionValue;

            b1.Dispose();
            a1.Dispose();
            tlog.Debug(tag, $"KeyValuePositionValue END (OK)");
            Assert.Pass("KeyValuePositionValue");
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

            Position2D b1 = new Position2D(1, 1);
            KeyValue a1 = new KeyValue
            {
                Position2DValue = b1
            };

            b1 = a1.Position2DValue;

            b1.Dispose();
            a1.Dispose();
            tlog.Debug(tag, $"KeyValuePosition2DValue END (OK)");
            Assert.Pass("KeyValuePosition2DValue");
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

            Size b1 = new Size(1, 1, 0);
            KeyValue a1 = new KeyValue
            {
                SizeValue = b1
            };

            b1 = a1.SizeValue;

            b1.Dispose();
            a1.Dispose();
            tlog.Debug(tag, $"KeyValueSizeValue END (OK)");
            Assert.Pass("KeyValueSizeValue");
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

            Size2D b1 = new Size2D(0, 0);
            KeyValue a1 = new KeyValue
            {
                Size2DValue = b1
            };

            b1 = a1.Size2DValue;

            b1.Dispose();
            a1.Dispose();
            tlog.Debug(tag, $"KeyValueSize2DValue END (OK)");
            Assert.Pass("KeyValueSize2DValue");
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

            Color b1 = new Color(0, 0, 0, 0);
            KeyValue a1 = new KeyValue
            {
                ColorValue = b1
            };

            b1 = a1.ColorValue;

            b1.Dispose();
            a1.Dispose();
            tlog.Debug(tag, $"KeyValueColorValue END (OK)");
            Assert.Pass("KeyValueColorValue");
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

            Rectangle b1 = new Rectangle(0, 0, 0, 0);
            KeyValue a1 = new KeyValue
            {
                RectangleValue = b1
            };

            b1 = a1.RectangleValue;

            b1.Dispose();
            a1.Dispose();
            tlog.Debug(tag, $"KeyValueRectangleValue END (OK)");
            Assert.Pass("KeyValueRectangleValue");
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

            Rotation b1 = new Rotation();
            KeyValue a1 = new KeyValue
            {
                RotationValue = b1
            };

            b1 = a1.RotationValue;

            b1.Dispose();
            a1.Dispose();
            tlog.Debug(tag, $"KeyValueRotationValue END (OK)");
            Assert.Pass("KeyValueRotationValue");
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

            RelativeVector2 b1 = new RelativeVector2(0, 0);
            KeyValue a1 = new KeyValue
            {
                RelativeVector2Value = b1
            };

            b1 = a1.RelativeVector2Value;

            b1.Dispose();
            a1.Dispose();
            tlog.Debug(tag, $"KeyValueRelativeVector2Value END (OK)");
            Assert.Pass("KeyValueRelativeVector2Value");
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

            RelativeVector3 b1 = new RelativeVector3(0, 0, 0);
            KeyValue a1 = new KeyValue
            {
                RelativeVector3Value = b1
            };

            b1 = a1.RelativeVector3Value;

            b1.Dispose();
            a1.Dispose();
            tlog.Debug(tag, $"KeyValueRelativeVector3Value END (OK)");
            Assert.Pass("KeyValueRelativeVector3Value");
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

            RelativeVector4 b1 = new RelativeVector4(0, 0, 0, 0);
            KeyValue a1 = new KeyValue
            {
                RelativeVector4Value = b1
            };

            b1 = a1.RelativeVector4Value;

            b1.Dispose();
            a1.Dispose();
            tlog.Debug(tag, $"KeyValueRelativeVector4Value END (OK)");
            Assert.Pass("KeyValueRelativeVector4Value");
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

            Extents b1 = new Extents(0, 0, 0, 0);
            KeyValue a1 = new KeyValue
            {
                ExtentsValue = b1
            };

            b1 = a1.ExtentsValue;

            b1.Dispose();
            a1.Dispose();
            tlog.Debug(tag, $"KeyValueExtentsValue END (OK)");
            Assert.Pass("KeyValueExtentsValue");
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

            PropertyArray b1 = new PropertyArray();
            KeyValue a1 = new KeyValue
            {
                PropertyArrayValue = b1
            };

            b1 = a1.PropertyArrayValue;

            b1.Dispose();
            a1.Dispose();
            tlog.Debug(tag, $"KeyValuePropertyArrayValue END (OK)");
            Assert.Pass("KeyValuePropertyArrayValue");
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

            PropertyMap b1 = new PropertyMap();
            KeyValue a1 = new KeyValue
            {
                PropertyMapValue = b1
            };

            b1 = a1.PropertyMapValue;

            b1.Dispose();
            a1.Dispose();
            tlog.Debug(tag, $"KeyValuePropertyMapValue END (OK)");
            Assert.Pass("KeyValuePropertyMapValue");
        }
    }

}