using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("public/Common/PropertyValue")]
    class PublicPropertyValueTest
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
        [Description("PropertyValue constructor")]
        [Property("SPEC", "Tizen.NUI.PropertyValue.PropertyValue C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PropertyValueConstructor()
        {
            tlog.Debug(tag, $"PropertyValueConstructor START");

            var testingTarget = new PropertyValue();
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<PropertyValue>(testingTarget, "Should return PropertyValue instance.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"PropertyValueConstructor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("PropertyValue constructor with bool")]
        [Property("SPEC", "Tizen.NUI.PropertyValue.PropertyValue C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PropertyValueConstructorWithBool()
        {
            tlog.Debug(tag, $"PropertyValueConstructorWithBool START");

            var testingTarget = new PropertyValue(true);
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<PropertyValue>(testingTarget, "Should return PropertyValue instance.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"PropertyValueConstructorWithBool END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("PropertyValue constructor with int")]
        [Property("SPEC", "Tizen.NUI.PropertyValue.PropertyValue C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PropertyValueConstructorWithInt()
        {
            tlog.Debug(tag, $"PropertyValueConstructorWithInt START");

            var testingTarget = new PropertyValue(5);
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<PropertyValue>(testingTarget, "Should return PropertyValue instance.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"PropertyValueConstructorWithInt END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("PropertyValue constructor with float")]
        [Property("SPEC", "Tizen.NUI.PropertyValue.PropertyValue C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PropertyValueConstructorWithFoloat()
        {
            tlog.Debug(tag, $"PropertyValueConstructorWithFoloat START");

            var testingTarget = new PropertyValue(6.0f);
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<PropertyValue>(testingTarget, "Should return PropertyValue instance.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"PropertyValueConstructorWithFoloat END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("PropertyValue constructor with Vector2")]
        [Property("SPEC", "Tizen.NUI.PropertyValue.PropertyValue C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PropertyValueConstructorWithVector2()
        {
            tlog.Debug(tag, $"PropertyValueConstructorWithVector2 START");

            var testingTarget = new PropertyValue(new Vector2(1.0f, 2.0f));
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<PropertyValue>(testingTarget, "Should return PropertyValue instance.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"PropertyValueConstructorWithVector2 END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("PropertyValue constructor with Size")]
        [Property("SPEC", "Tizen.NUI.PropertyValue.PropertyValue C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PropertyValueConstructorWithSize()
        {
            tlog.Debug(tag, $"PropertyValueConstructorWithSize START");

            var testingTarget = new PropertyValue(new Size(1, 2));
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<PropertyValue>(testingTarget, "Should return PropertyValue instance.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"PropertyValueConstructorWithSize END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("PropertyValue constructor with Vector3")]
        [Property("SPEC", "Tizen.NUI.PropertyValue.PropertyValue C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PropertyValueConstructorWithVector3()
        {
            tlog.Debug(tag, $"PropertyValueConstructorWithVector3 START");

            var testingTarget = new PropertyValue(new Vector3(1.0f, 2.0f, 3.0f));
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<PropertyValue>(testingTarget, "Should return PropertyValue instance.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"PropertyValueConstructorWithVector3 END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("PropertyValue constructor with Position2D")]
        [Property("SPEC", "Tizen.NUI.PropertyValue.PropertyValue C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PropertyValueConstructorWithPosition2D()
        {
            tlog.Debug(tag, $"PropertyValueConstructorWithPosition2D START");

            var testingTarget = new PropertyValue(new Position2D(1, 2));
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<PropertyValue>(testingTarget, "Should return PropertyValue instance.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"PropertyValueConstructorWithPosition2D END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("PropertyValue constructor with Position")]
        [Property("SPEC", "Tizen.NUI.PropertyValue.PropertyValue C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PropertyValueConstructorWithPosition()
        {
            tlog.Debug(tag, $"PropertyValueConstructorWithPosition START");

            var testingTarget = new PropertyValue(new Position(1.0f, 2.0f, 3.0f));
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<PropertyValue>(testingTarget, "Should return PropertyValue instance.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"PropertyValueConstructorWithPosition END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("PropertyValue constructor with Vector4")]
        [Property("SPEC", "Tizen.NUI.PropertyValue.PropertyValue C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PropertyValueConstructorWithVector4()
        {
            tlog.Debug(tag, $"PropertyValueConstructorWithVector4 START");

            var testingTarget = new PropertyValue(new Vector4(1.0f, 2.0f, 3.0f, 4.0f));
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<PropertyValue>(testingTarget, "Should return PropertyValue instance.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"PropertyValueConstructorWithVector4 END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("PropertyValue constructor with Extents")]
        [Property("SPEC", "Tizen.NUI.PropertyValue.PropertyValue C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PropertyValueConstructorWithExtents()
        {
            tlog.Debug(tag, $"PropertyValueConstructorWithExtents START");

            var testingTarget = new PropertyValue(new Extents(1, 2, 3, 4));
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<PropertyValue>(testingTarget, "Should return PropertyValue instance.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"PropertyValueConstructorWithExtents END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("PropertyValue constructor with Color")]
        [Property("SPEC", "Tizen.NUI.PropertyValue.PropertyValue C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PropertyValueConstructorWithColor()
        {
            tlog.Debug(tag, $"PropertyValueConstructorWithColor START");

            var testingTarget = new PropertyValue(new Color(1.0f, 1.0f, 1.0f, 0.5f));
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<PropertyValue>(testingTarget, "Should return PropertyValue instance.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"PropertyValueConstructorWithColor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("PropertyValue constructor with Rectangle")]
        [Property("SPEC", "Tizen.NUI.PropertyValue.PropertyValue C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PropertyValueConstructorWithRectangle()
        {
            tlog.Debug(tag, $"PropertyValueConstructorWithRectangle START");

            var testingTarget = new PropertyValue(new Rectangle(1, 2, 100, 200));
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<PropertyValue>(testingTarget, "Should return PropertyValue instance.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"PropertyValueConstructorWithRectangle END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("PropertyValue constructor with Rotation")]
        [Property("SPEC", "Tizen.NUI.PropertyValue.PropertyValue C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PropertyValueConstructorWithRotation()
        {
            tlog.Debug(tag, $"PropertyValueConstructorWithRotation START");

            var dummy = new Rotation();
            Assert.IsNotNull(dummy, "Should be not null!");
            Assert.IsInstanceOf<Rotation>(dummy, "Should return Rotation instance.");

            var testingTarget = new PropertyValue(dummy);
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<PropertyValue>(testingTarget, "Should return PropertyValue instance.");

            testingTarget.Dispose();
            dummy.Dispose();
            tlog.Debug(tag, $"PropertyValueConstructorWithRotation END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("PropertyValue constructor with string")]
        [Property("SPEC", "Tizen.NUI.PropertyValue.PropertyValue C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PropertyValueConstructorWithString()
        {
            tlog.Debug(tag, $"PropertyValueConstructorWithString START");

            var testingTarget = new PropertyValue("DALI");
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<PropertyValue>(testingTarget, "Should return PropertyValue instance.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"PropertyValueConstructorWithString END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("PropertyValue constructor with PropertyArray")]
        [Property("SPEC", "Tizen.NUI.PropertyValue.PropertyValue C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PropertyValueConstructorWithPropertyArray()
        {
            tlog.Debug(tag, $"PropertyValueConstructorWithPropertyArray START");

            PropertyArray dummy_array = new PropertyArray();
            Assert.IsNotNull(dummy_array, "Should be not null!");
            Assert.IsInstanceOf<PropertyArray>(dummy_array, "Should return PropertyArray instance.");

            PropertyValue dummy_value1 = new PropertyValue(14.0f);
            Assert.IsNotNull(dummy_value1, "Should be not null!");
            Assert.IsInstanceOf<PropertyValue>(dummy_value1, "Should return PropertyValue instance.");

            PropertyValue dummy_value2 = new PropertyValue(15.0f);
            Assert.IsNotNull(dummy_value2, "Should be not null!");
            Assert.IsInstanceOf<PropertyValue>(dummy_value2, "Should return PropertyValue instance.");

            dummy_array.Add(dummy_value1);
            dummy_array.Add(dummy_value2);

            var testingTarget = new PropertyValue(dummy_array);
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<PropertyValue>(testingTarget, "Should return PropertyValue instance.");

            testingTarget.Dispose();
            dummy_value2.Dispose();
            dummy_value1.Dispose();
            dummy_array.Dispose();

            tlog.Debug(tag, $"PropertyValueConstructorWithPropertyArray END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("PropertyValue constructor with PropertyMap")]
        [Property("SPEC", "Tizen.NUI.PropertyValue.PropertyValue C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PropertyValueConstructorWithPropertyMap()
        {
            tlog.Debug(tag, $"PropertyValueConstructorWithPropertyMap START");

            var dummy = new PropertyMap();
            Assert.IsNotNull(dummy, "Should be not null!");
            Assert.IsInstanceOf<PropertyMap>(dummy, "Should return PropertyMap instance.");

            dummy.Add("hello", new PropertyValue(400.0f));
            dummy.Add("world", new PropertyValue(500.0f));

            var testingTarget = new PropertyValue(dummy);
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<PropertyValue>(testingTarget, "Should return PropertyValue instance.");

            testingTarget.Dispose();
            dummy.Dispose();
            tlog.Debug(tag, $"PropertyValueConstructorWithPropertyMap END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("PropertyValue constructor with PropertyType")]
        [Property("SPEC", "Tizen.NUI.PropertyValue.PropertyValue C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PropertyValueConstructorWithPropertyType()
        {
            tlog.Debug(tag, $"PropertyValueConstructorWithPropertyType START");

            var testingTarget = new PropertyValue(PropertyType.Float);
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<PropertyValue>(testingTarget, "Should return PropertyValue instance.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"PropertyValueConstructorWithPropertyType END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("PropertyValue constructor with PropertyValue")]
        [Property("SPEC", "Tizen.NUI.PropertyValue.PropertyValue C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PropertyValueConstructorWithPropertyValue()
        {
            tlog.Debug(tag, $"PropertyValueConstructorWithPropertyValue START");

            var dummy = new PropertyValue(5);
            Assert.IsNotNull(dummy, "Should be not null!");
            Assert.IsInstanceOf<PropertyValue>(dummy, "Should return PropertyValue instance.");

            var testingTarget = new PropertyValue(dummy);
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<PropertyValue>(testingTarget, "Should return PropertyValue instance.");

            testingTarget.Dispose();
            dummy.Dispose();
            tlog.Debug(tag, $"PropertyValueConstructorWithPropertyValue END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("PropertyValue CreateFromObject")]
        [Property("SPEC", "Tizen.NUI.PropertyValue.CreateFromObject M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PropertyValueCreateFromObject()
        {
            tlog.Debug(tag, $"PropertyValueCreateFromObject START");

            Position pos = new Position(10.0f, 20.0f, 30.0f);
            var testingTarget = PropertyValue.CreateFromObject(pos);
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<PropertyValue>(testingTarget, "Should be an Instance of PropertyValue!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"PropertyValueCreateFromObject END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("PropertyValue GetType")]
        [Property("SPEC", "Tizen.NUI.PropertyValue.GetType M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PropertyValueGetType()
        {
            tlog.Debug(tag, $"PropertyValueGetType START");

            var dummy = new PropertyValue(2);
            Assert.IsNotNull(dummy, "Should be not null!");
            Assert.IsInstanceOf<PropertyValue>(dummy, "should be an Instance of PropertyValue class.");

            var testingTarget = dummy.GetType();
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.AreEqual(PropertyType.Integer, testingTarget, "should be equal.");

            dummy.Dispose();
            tlog.Debug(tag, $"PropertyValueGetType END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("PropertyValue Get. Bool value")]
        [Property("SPEC", "Tizen.NUI.PropertyValue.Get M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PropertyValueGetBoolValue()
        {
            tlog.Debug(tag, $"PropertyValueGetBoolValue START");

            var testingTarget = new PropertyValue(false);
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<PropertyValue>(testingTarget, "should be an Instance of PropertyValue class.");

            bool result = true;
            testingTarget.Get(out result);
            Assert.IsTrue(false == result);

            testingTarget.Dispose();
            tlog.Debug(tag, $"PropertyValueGetBoolValue END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("PropertyValue Get. Float value")]
        [Property("SPEC", "Tizen.NUI.PropertyValue.Get M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PropertyValueGetFloatValue()
        {
            tlog.Debug(tag, $"PropertyValueGetFloatValue START");

            var testingTarget = new PropertyValue(12.0f);
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<PropertyValue>(testingTarget, "should be an Instance of PropertyValue class.");

            float result = 0.0f;
            testingTarget.Get(out result);
            Assert.IsTrue(12.0f == result);

            testingTarget.Dispose();
            tlog.Debug(tag, $"PropertyValueGetFloatValue END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("PropertyValue Get. Integer value")]
        [Property("SPEC", "Tizen.NUI.PropertyValue.Get M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PropertyValueGetIntegerValue()
        {
            tlog.Debug(tag, $"PropertyValueGetIntegerValue START");

            var testingTarget = new PropertyValue(20);
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<PropertyValue>(testingTarget, "should be an Instance of PropertyValue class.");

            int result = 0;
            testingTarget.Get(out result);
            Assert.IsTrue(20 == result);

            testingTarget.Dispose();
            tlog.Debug(tag, $"PropertyValueGetIntegerValue END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("PropertyValue Get. Rectangle value")]
        [Property("SPEC", "Tizen.NUI.PropertyValue.Get M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PropertyValueGetRectangleValue()
        {
            tlog.Debug(tag, $"PropertyValueGetRectangleValue START");

            var testingTarget = new PropertyValue(new Rectangle(1, 2, 3, 4));
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<PropertyValue>(testingTarget, "should be an Instance of PropertyValue class.");

            Rectangle rectangle = new Rectangle(0, 0, 0, 0);
            var result = testingTarget.Get(rectangle);
            Assert.IsTrue(result);

            Assert.AreEqual(1, rectangle.X, "should be eaqual.");
            Assert.AreEqual(2, rectangle.Y, "should be eaqual.");
            Assert.AreEqual(3, rectangle.Width, "should be eaqual.");
            Assert.AreEqual(4, rectangle.Height, "should be eaqual.");

            rectangle.Dispose();
            testingTarget.Dispose();
            tlog.Debug(tag, $"PropertyValueGetRectangleValue END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("PropertyValue Get. Size2D value")]
        [Property("SPEC", "Tizen.NUI.PropertyValue.Get M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PropertyValueGetSize2DValue()
        {
            tlog.Debug(tag, $"PropertyValueGetSize2DValue START");

            var testingTarget = new PropertyValue(new Size2D(1, 2));
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<PropertyValue>(testingTarget, "should be an Instance of PropertyValue class.");

            Size2D size = new Size2D(3, 4);
            var result = testingTarget.Get(size);
            Assert.IsTrue(result);

            Assert.AreEqual(1, size.Width, "Get function with Size2D parameter does not work, Size2D.Width is not right");
            Assert.AreEqual(2, size.Height, "Get function with Size2D parameter does not work, Size2D.Height is not right");

            size.Dispose();
            testingTarget.Dispose();
            tlog.Debug(tag, $"PropertyValueGetSize2DValue END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("PropertyValue Get. Position value")]
        [Property("SPEC", "Tizen.NUI.PropertyValue.Get M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PropertyValueGetPositionValue()
        {
            tlog.Debug(tag, $"PropertyValueGetPositionValue START");

            var testingTarget = new PropertyValue(new Position(1, 2, 3));
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<PropertyValue>(testingTarget, "Should be an Instance of PropertyValue class!");

            Position position = new Position(4, 5, 6);
            var result = testingTarget.Get(position);
            Assert.IsTrue(result);

            Assert.AreEqual(1, position.X, "should be eaqual.");
            Assert.AreEqual(2, position.Y, "should be eaqual.");
            Assert.AreEqual(3, position.Z, "should be eaqual.");

            position.Dispose();
            testingTarget.Dispose();
            tlog.Debug(tag, $"PropertyValueGetPositionValue END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("PropertyValue Get. Position2D value")]
        [Property("SPEC", "Tizen.NUI.PropertyValue.Get M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PropertyValueGetPosition2DValue()
        {
            tlog.Debug(tag, $"PropertyValueGetPosition2DValue START");

            var testingTarget = new PropertyValue(new Position2D(1, 2));
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<PropertyValue>(testingTarget, "Should be an Instance of PropertyValue class!");

            Position2D position = new Position2D(4, 5);
            var result = testingTarget.Get(position);
            Assert.IsTrue(result);

            Assert.AreEqual(1, position.X, "should be eaqual.");
            Assert.AreEqual(2, position.Y, "should be eaqual.");

            position.Dispose();
            testingTarget.Dispose();
            tlog.Debug(tag, $"PropertyValueGetPosition2DValue END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("PropertyValue Get. Vector2 value")]
        [Property("SPEC", "Tizen.NUI.PropertyValue.Get M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PropertyValueGetVector2Value()
        {
            tlog.Debug(tag, $"PropertyValueGetVector2Value START");

            var testingTarget = new PropertyValue();
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<PropertyValue>(testingTarget, "should be an Instance of PropertyValue class.");

            var dummy = new Vector2(1, 2);
            Assert.IsNotNull(dummy, "Should be not null!");
            Assert.IsInstanceOf<Vector2>(dummy, "should be an Instance of PropertyValue class.");

            testingTarget.Get(dummy);
            Assert.IsTrue(1 == dummy.X);
            Assert.IsTrue(2 == dummy.Y);

            tlog.Debug(tag, $"PropertyValueGetVector2Value END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("PropertyValue Get. Vector3 value")]
        [Property("SPEC", "Tizen.NUI.PropertyValue.Get M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PropertyValueGetVector3Value()
        {
            tlog.Debug(tag, $"PropertyValueGetVector3Value START");

            PropertyValue testingTarget = new PropertyValue(new Vector3(1, 2, 3));
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<PropertyValue>(testingTarget, "Should be an Instance of PropertyValue class!");

            Vector3 vector = new Vector3(3, 2, 1);
            var result = testingTarget.Get(vector);
            Assert.IsTrue(result);

            Assert.AreEqual(1, vector.X, "Get function with Vector3 parameter does not work, Vector.X is not right");
            Assert.AreEqual(2, vector.Y, "Get function with Vector3 parameter does not work, Vector.Y is not right");
            Assert.AreEqual(3, vector.Z, "Get function with Vector3 parameter does not work, Vector.Z is not right");

            vector.Dispose();
            testingTarget.Dispose();
            tlog.Debug(tag, $"PropertyValueGetVector3Value END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("PropertyValue Get. Vector4 value")]
        [Property("SPEC", "Tizen.NUI.PropertyValue.Get M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PropertyValueGetVector4Value()
        {
            tlog.Debug(tag, $"PropertyValueGetVector4Value START");

            var testingTarget = new PropertyValue(new Vector4(10, 20, 30, 40));
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<PropertyValue>(testingTarget, "Should be an Instance of PropertyValue class!");

            Vector4 vector = new Vector4(100, 200, 300, 400);
            var result = testingTarget.Get(vector);
            Assert.IsTrue(result);

            Assert.AreEqual(10, vector.X, "should be eaqual.");
            Assert.AreEqual(20, vector.Y, "should be eaqual.");
            Assert.AreEqual(30, vector.Z, "should be eaqual.");
            Assert.AreEqual(40, vector.W, "should be eaqual.");

            vector.Dispose();
            testingTarget.Dispose();
            tlog.Debug(tag, $"PropertyValueGetVector4Value END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("PropertyValue Get. Extents value")]
        [Property("SPEC", "Tizen.NUI.PropertyValue.Get M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PropertyValueGetExtentsValue()
        {
            tlog.Debug(tag, $"PropertyValueGetExtentsValue START");

            var testingTarget = new PropertyValue(new Extents(1, 2, 3, 4));
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<PropertyValue>(testingTarget, "Should be an Instance of PropertyValue class!");
            
            Extents extents = new Extents(0, 0, 0, 0);
            var result = testingTarget.Get(extents);
            Assert.IsTrue(result);

            Assert.AreEqual(1, extents.Start, "should be eaqual.");
            Assert.AreEqual(2, extents.End, "should be eaqual.");
            Assert.AreEqual(3, extents.Top, "should be eaqual.");
            Assert.AreEqual(4, extents.Bottom, "should be eaqual.");

            extents.Dispose();
            testingTarget.Dispose();
            tlog.Debug(tag, $"PropertyValueGetExtentsValue END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("PropertyValue Get. Color value")]
        [Property("SPEC", "Tizen.NUI.PropertyValue.Get M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PropertyValueGetColorValue()
        {
            tlog.Debug(tag, $"PropertyValueGetColorValue START");

            Color dummy = new Color(1.0f, 0.5f, 1.0f, 0.5f);
            var testingTarget = new PropertyValue(dummy);
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<PropertyValue>(testingTarget, "Should be an Instance of PropertyValue class!");

            Color color = new Color(0, 0, 0, 0);
            testingTarget.Get(color);
            Assert.AreEqual(1.0f, color.R, "Get function with Color parameter does not work, color.R is not right.");
            Assert.AreEqual(0.5f, color.G, "Get function with Color parameter does not work, color.G is not right.");
            Assert.AreEqual(1.0f, color.B, "Get function with Color parameter does not work, color.B is not right.");
            Assert.AreEqual(0.5f, color.A, "Get function with Color parameter does not work, color.A is not right.");

            color.Dispose();
            testingTarget.Dispose();
            dummy.Dispose();
            tlog.Debug(tag, $"PropertyValueGetColorValue END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("PropertyValue Get. Rotation value")]
        [Property("SPEC", "Tizen.NUI.PropertyValue.Get M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PropertyValueGetRotationValue()
        {
            tlog.Debug(tag, $"PropertyValueGetRotationValue START");

            var dummy = new Rotation(new Radian(6.0f), new Vector3(1.0f, 2.0f, 3.0f));
            Assert.IsNotNull(dummy, "Should be not null!");
            Assert.IsInstanceOf<Rotation>(dummy, "Should be an Instance of Rotation class!");

            var testingTarget = new PropertyValue(dummy);
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<PropertyValue>(testingTarget, "Should be an Instance of PropertyValue class!");

            Rotation rotation = new Rotation();
            var result = testingTarget.Get(rotation);
            Assert.IsTrue(result);

            Radian angle = new Radian(20.0f);
            Vector3 axis = new Vector3(0, 0, 0);
            rotation.GetAxisAngle(axis, angle);
            Assert.AreEqual(0.27f, float.Parse(axis.X.ToString("F2")), "shoule be eaqual.");
            Assert.AreEqual(0.53f, float.Parse(axis.Y.ToString("F2")), "shoule be eaqual.");
            Assert.AreEqual(0.80f, float.Parse(axis.Z.ToString("F2")), "shoule be eaqual.");

            testingTarget.Dispose();
            rotation.Dispose();
            dummy.Dispose();
            tlog.Debug(tag, $"PropertyValueGetRotationValue END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("PropertyValue Get. String value")]
        [Property("SPEC", "Tizen.NUI.PropertyValue.Get M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PropertyValueGetPropertyStringValue()
        {
            tlog.Debug(tag, $"PropertyValueGetPropertyStringValue START");

            var testingTarget = new PropertyValue("DALI");
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<PropertyValue>(testingTarget, "Should be an Instance of PropertyValue class!");

            string result = "";
            testingTarget.Get(out result);
            Assert.AreEqual("DALI", result, "should be eaqual.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"PropertyValueGetPropertyStringValue END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("PropertyValue Get. PropertyArray value")]
        [Property("SPEC", "Tizen.NUI.PropertyValue.Get M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PropertyValueGetPropertyArrayValue()
        {
            tlog.Debug(tag, $"PropertyValueGetPropertyArrayValue START");

            PropertyArray propertyArray = new PropertyArray();
            propertyArray.Add(new PropertyValue(3.0f));

            PropertyValue propertyValue = new PropertyValue(propertyArray);

            var testingTarget = new PropertyArray();
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<PropertyArray>(testingTarget, "Should be an Instance of PropertyArray class!");

            var result = propertyValue.Get(testingTarget);
            Assert.IsTrue(result);

            float temp = 0.0f;
            testingTarget[0].Get(out temp);
            Assert.AreEqual(3.0f, temp, "should be eaqual.");

            testingTarget.Dispose();
            propertyValue.Dispose();
            propertyArray.Dispose();
            tlog.Debug(tag, $"PropertyValueGetPropertyArrayValue END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("PropertyValue Get. PropertyMap value")]
        [Property("SPEC", "Tizen.NUI.PropertyValue.Get M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PropertyValueGetPropertyMapValue()
        {
            tlog.Debug(tag, $"PropertyValueGetPropertyMapValue START");

            var dummy = new PropertyMap();
            Assert.IsNotNull(dummy, "Should be not null!");
            Assert.IsInstanceOf<PropertyMap>(dummy, "Should be an Instance of PropertyMap class!");
            dummy.Add(2, new PropertyValue(400.0f));

            var testingTarget = new PropertyValue(dummy);
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<PropertyValue>(testingTarget, "Should be an Instance of PropertyValue class!");

            PropertyMap propertyMap = new PropertyMap();
            var result = testingTarget.Get(propertyMap);
            Assert.IsTrue(result);

            PropertyValue propertyValue = propertyMap[2];
            float temp = 0.0f;
            propertyValue.Get(out temp);
            Assert.AreEqual(400.0f, temp, "should be eaqual.");

            testingTarget.Dispose();
            dummy.Dispose();
            tlog.Debug(tag, $"PropertyValueGetPropertyMapValue END (OK)");
        }
    }
}
