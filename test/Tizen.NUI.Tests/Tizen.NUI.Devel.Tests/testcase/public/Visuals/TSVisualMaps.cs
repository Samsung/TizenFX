using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("public/Visuals/VisualMaps")]
    public class PublicVisualMapsTest
    {
        private const string tag = "NUITEST";
        private static bool flagComposingPropertyMap;
        internal class MyVisualMap : VisualMap
        {
            protected override void ComposingPropertyMap()
            {
                flagComposingPropertyMap = true;
                base.ComposingPropertyMap();
            }
        }

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
        [Description("VisualMap constructor.")]
        [Property("SPEC", "Tizen.NUI.VisualMap.VisualMap C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void VisualMapConstructor()
        {
            tlog.Debug(tag, $"VisualMapConstructor START");

            var testingTarget = new VisualMap();
            Assert.IsNotNull(testingTarget, "Can't create success object VisualMap");
            Assert.IsInstanceOf<VisualMap>(testingTarget, "Should be an instance of VisualMap type.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"VisualMapConstructor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("VisualMap VisualSize.")]
        [Property("SPEC", "Tizen.NUI.VisualMap.Size A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void VisualMapSize()
        {
            tlog.Debug(tag, $"VisualMapSize START");

            var testingTarget = new VisualMap();
            Assert.IsNotNull(testingTarget, "Can't create success object VisualMap");
            Assert.IsInstanceOf<VisualMap>(testingTarget, "Should be an instance of VisualMap type.");

            using (Vector2 vector2 = new Vector2(1.0f, 1.0f))
            {
                testingTarget.Size = vector2;
                Assert.AreEqual(1.0f, testingTarget.Size.Width, "Retrieved VisualSize.Width should be equal to set value");
                Assert.AreEqual(1.0f, testingTarget.Size.Height, "Retrieved VisualSize.Height should be equal to set value");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"VisualMapSize END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("VisualMap MixColor.")]
        [Property("SPEC", "Tizen.NUI.VisualMap.MixColor A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void VisualMapMixColor()
        {
            tlog.Debug(tag, $"VisualMapMixColor START");

            var testingTarget = new VisualMap();
            Assert.IsNotNull(testingTarget, "Can't create success object VisualMap");
            Assert.IsInstanceOf<VisualMap>(testingTarget, "Should be an instance of VisualMap type.");

            using (Color color = new Color(0.5f, 1.0f, 0.6f, 1.0f))
            {
                testingTarget.MixColor = color;
                Assert.AreEqual(0.5f, testingTarget.MixColor.R, "Retrieved VisualSize.MixColor.R should be equal to set value");
                Assert.AreEqual(1.0f, testingTarget.MixColor.G, "Retrieved VisualSize.MixColor.G should be equal to set value");
                Assert.AreEqual(0.6f, testingTarget.MixColor.B, "Retrieved VisualSize.MixColor.B should be equal to set value");
                Assert.AreEqual(1.0f, testingTarget.MixColor.A, "Retrieved VisualSize.MixColor.A should be equal to set value");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"VisualMapMixColor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("VisualMap Opacity.")]
        [Property("SPEC", "Tizen.NUI.VisualMap.Opacity A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void VisualMapOpacity()
        {
            tlog.Debug(tag, $"VisualMapOpacity START");

            var testingTarget = new VisualMap();
            Assert.IsNotNull(testingTarget, "Can't create success object VisualMap");
            Assert.IsInstanceOf<VisualMap>(testingTarget, "Should be an instance of VisualMap type.");

            testingTarget.Opacity = 0.5f;
            Assert.AreEqual(0.5f, testingTarget.Opacity, "Retrieved VisualSize.Opacity should be equal to set value");

            testingTarget.Dispose();
            tlog.Debug(tag, $"VisualMapOpacity END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("VisualMap PremultipliedAlpha.")]
        [Property("SPEC", "Tizen.NUI.VisualMap.PremultipliedAlpha A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void VisualMapPremultipliedAlpha()
        {
            tlog.Debug(tag, $"VisualMapPremultipliedAlpha START");

            var testingTarget = new VisualMap();
            Assert.IsNotNull(testingTarget, "Can't create success object VisualMap");
            Assert.IsInstanceOf<VisualMap>(testingTarget, "Should be an instance of VisualMap type.");

            testingTarget.PremultipliedAlpha = true;
            Assert.IsTrue(testingTarget.PremultipliedAlpha, "Retrieved VisualSize.PremultipliedAlpha should be equal to set value");

            testingTarget.Dispose();
            tlog.Debug(tag, $"VisualMapPremultipliedAlpha END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("VisualMap RelativePosition.")]
        [Property("SPEC", "Tizen.NUI.VisualMap.RelativePosition A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void VisualMapRelativePosition()
        {
            tlog.Debug(tag, $"VisualMapRelativePosition START");

            var testingTarget = new VisualMap();
            Assert.IsNotNull(testingTarget, "Can't create success object VisualMap");
            Assert.IsInstanceOf<VisualMap>(testingTarget, "Should be an instance of VisualMap type.");

            testingTarget.RelativePosition = new RelativeVector2(0.5f, 0.5f);
            Assert.AreEqual(0.5f, testingTarget.RelativePosition.X, "Retrieved VisualSize.RelativePosition.X should be equal to set value");
            Assert.AreEqual(0.5f, testingTarget.RelativePosition.Y, "Retrieved VisualSize.RelativePosition.Y should be equal to set value");

            testingTarget.Dispose();
            tlog.Debug(tag, $"VisualMapRelativePosition END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("VisualMap RelativeSize.")]
        [Property("SPEC", "Tizen.NUI.VisualMap.RelativeSize A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void VisualMapRelativeSize()
        {
            tlog.Debug(tag, $"VisualMapRelativeSize START");

            var testingTarget = new VisualMap();
            Assert.IsNotNull(testingTarget, "Can't create success object VisualMap");
            Assert.IsInstanceOf<VisualMap>(testingTarget, "Should be an instance of VisualMap type.");

            testingTarget.RelativeSize = new RelativeVector2(0.5f, 0.5f);
            Assert.AreEqual(0.5f, testingTarget.RelativeSize.X, "Retrieved VisualSize.RelativeSize.X should be equal to set value");
            Assert.AreEqual(0.5f, testingTarget.RelativeSize.Y, "Retrieved VisualSize.RelativeSize.Y should be equal to set value");

            testingTarget.Dispose();
            tlog.Debug(tag, $"VisualMapRelativeSize END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("VisualMap Shader.")]
        [Property("SPEC", "Tizen.NUI.VisualMap.Shader A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void VisualMapShader()
        {
            tlog.Debug(tag, $"VisualMapShader START");

            using (PropertyMap propertyMap = new PropertyMap())
            {
                propertyMap.Insert(Visual.ShaderProperty.FragmentShader, new PropertyValue("Foobar"));

                var testingTarget = new VisualMap();
                Assert.IsNotNull(testingTarget, "Can't create success object VisualMap");
                Assert.IsInstanceOf<VisualMap>(testingTarget, "Should be an instance of VisualMap type.");

                testingTarget.Shader = propertyMap;

                string str = "";
                (testingTarget.Shader.Find(Visual.ShaderProperty.FragmentShader)).Get(out str);
                Assert.AreEqual("Foobar", str, "Retrieved PremultipliedAlpha should be equal to set value");

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"VisualMapShader END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("VisualMap Offset.")]
        [Property("SPEC", "Tizen.NUI.VisualMap.Position A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void VisualMapPosition()
        {
            tlog.Debug(tag, $"VisualMapPosition START");

            var testingTarget = new VisualMap();
            Assert.IsNotNull(testingTarget, "Can't create success object VisualMap");
            Assert.IsInstanceOf<VisualMap>(testingTarget, "Should be an instance of VisualMap type.");

            using (Vector2 vector2 = new Vector2(1.0f, 1.0f))
            {
                testingTarget.Position = vector2;
                Assert.AreEqual(1.0f, testingTarget.Position.X, "Retrieved Offset.X should be equal to set value");
                Assert.AreEqual(1.0f, testingTarget.Position.Y, "Retrieved Offset.Y should be equal to set value");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"VisualMapPosition END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("VisualMap PositionPolicy.")]
        [Property("SPEC", "Tizen.NUI.VisualMap.PositionPolicy A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void VisualMapPositionPolicy()
        {
            tlog.Debug(tag, $"VisualMapPositionPolicy START");

            var testingTarget = new VisualMap();
            Assert.IsNotNull(testingTarget, "Can't create success object VisualMap");
            Assert.IsInstanceOf<VisualMap>(testingTarget, "Should be an instance of VisualMap type.");

            Assert.AreEqual(VisualTransformPolicyType.Relative, testingTarget.PositionPolicy, "Retrieved PositionPolicy should be equal to set value");

            testingTarget.PositionPolicy = VisualTransformPolicyType.Absolute;
            Assert.AreEqual(VisualTransformPolicyType.Absolute, testingTarget.PositionPolicy, "Retrieved PositionPolicy should be equal to set value");

            testingTarget.PositionPolicy = VisualTransformPolicyType.Relative;
            Assert.AreEqual(VisualTransformPolicyType.Relative, testingTarget.PositionPolicy, "Retrieved PositionPolicy should be equal to set value");

            // default
            try
            {
                testingTarget.PositionPolicy = (VisualTransformPolicyType)3;
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"VisualMapPositionPolicy END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("VisualMap PositionPolicyX.")]
        [Property("SPEC", "Tizen.NUI.VisualMap.PositionPolicyX A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void VisualMapPositionPolicyX()
        {
            tlog.Debug(tag, $"VisualMapPositionPolicyX START");

            var testingTarget = new VisualMap();
            Assert.IsNotNull(testingTarget, "Can't create success object VisualMap");
            Assert.IsInstanceOf<VisualMap>(testingTarget, "Should be an instance of VisualMap type.");

            Assert.AreEqual(VisualTransformPolicyType.Relative, testingTarget.PositionPolicyX, "Retrieved PositionPolicyX should be equal to set value");

            testingTarget.PositionPolicyX = VisualTransformPolicyType.Absolute;
            Assert.AreEqual(VisualTransformPolicyType.Absolute, testingTarget.PositionPolicyX, "Retrieved PositionPolicyX should be equal to set value");

            testingTarget.PositionPolicyX = VisualTransformPolicyType.Relative;
            Assert.AreEqual(VisualTransformPolicyType.Relative, testingTarget.PositionPolicyX, "Retrieved PositionPolicyX should be equal to set value");

            // default
            try
            {
                testingTarget.PositionPolicyX = (VisualTransformPolicyType)3;
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"VisualMapPositionPolicyX END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("VisualMap PositionPolicyY.")]
        [Property("SPEC", "Tizen.NUI.VisualMap.PositionPolicyY A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void VisualMapPositionPolicyY()
        {
            tlog.Debug(tag, $"VisualMapPositionPolicyY START");

            var testingTarget = new VisualMap();
            Assert.IsNotNull(testingTarget, "Can't create success object VisualMap");
            Assert.IsInstanceOf<VisualMap>(testingTarget, "Should be an instance of VisualMap type.");

            Assert.AreEqual(VisualTransformPolicyType.Relative, testingTarget.PositionPolicyY, "Retrieved PositionPolicyY should be equal to set value");

            testingTarget.PositionPolicyY = VisualTransformPolicyType.Absolute;
            Assert.AreEqual(VisualTransformPolicyType.Absolute, testingTarget.PositionPolicyY, "Retrieved PositionPolicyY should be equal to set value");

            testingTarget.PositionPolicyY = VisualTransformPolicyType.Relative;
            Assert.AreEqual(VisualTransformPolicyType.Relative, testingTarget.PositionPolicyY, "Retrieved PositionPolicyY should be equal to set value");

            // default
            try
            {
                testingTarget.PositionPolicyY = (VisualTransformPolicyType)3;
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"VisualMapPositionPolicyY END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("VisualMap SizePolicy.")]
        [Property("SPEC", "Tizen.NUI.VisualMap.SizePolicy A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void VisualMapSizePolicy()
        {
            tlog.Debug(tag, $"VisualMapSizePolicy START");

            var testingTarget = new VisualMap();
            Assert.IsNotNull(testingTarget, "Can't create success object VisualMap");
            Assert.IsInstanceOf<VisualMap>(testingTarget, "Should be an instance of VisualMap type.");

            Assert.AreEqual(VisualTransformPolicyType.Relative, testingTarget.SizePolicy, "Retrieved SizePolicy should be equal to set value");

            testingTarget.SizePolicy = VisualTransformPolicyType.Absolute;
            Assert.AreEqual(VisualTransformPolicyType.Absolute, testingTarget.SizePolicy, "Retrieved SizePolicy should be equal to set value");

            testingTarget.SizePolicy = VisualTransformPolicyType.Relative;
            Assert.AreEqual(VisualTransformPolicyType.Relative, testingTarget.SizePolicy, "Retrieved SizePolicy should be equal to set value");

            // default
            try
            {
                testingTarget.SizePolicy = (VisualTransformPolicyType)3;
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"VisualMapSizePolicy END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("VisualMap SizePolicyWidth.")]
        [Property("SPEC", "Tizen.NUI.VisualMap.SizePolicyWidth A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void VisualMapSizePolicyWidth()
        {
            tlog.Debug(tag, $"VisualMapSizePolicyWidth START");

            var testingTarget = new VisualMap();
            Assert.IsNotNull(testingTarget, "Can't create success object VisualMap");
            Assert.IsInstanceOf<VisualMap>(testingTarget, "Should be an instance of VisualMap type.");

            Assert.AreEqual(VisualTransformPolicyType.Relative, testingTarget.SizePolicyWidth, "Retrieved SizePolicyWidth should be equal to set value");

            testingTarget.SizePolicyWidth = VisualTransformPolicyType.Absolute;
            Assert.AreEqual(VisualTransformPolicyType.Absolute, testingTarget.SizePolicyWidth, "Retrieved SizePolicyWidth should be equal to set value");

            testingTarget.SizePolicyWidth = VisualTransformPolicyType.Relative;
            Assert.AreEqual(VisualTransformPolicyType.Relative, testingTarget.SizePolicyWidth, "Retrieved SizePolicyWidth should be equal to set value");

            // default
            try
            {
                testingTarget.SizePolicyWidth = (VisualTransformPolicyType)3;
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"VisualMapSizePolicyWidth END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("VisualMap SizePolicyHeight.")]
        [Property("SPEC", "Tizen.NUI.VisualMap.SizePolicyHeight A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void VisualMapSizePolicyHeight()
        {
            tlog.Debug(tag, $"VisualMapSizePolicyHeight START");

            var testingTarget = new VisualMap();
            Assert.IsNotNull(testingTarget, "Can't create success object VisualMap");
            Assert.IsInstanceOf<VisualMap>(testingTarget, "Should be an instance of VisualMap type.");

            Assert.AreEqual(VisualTransformPolicyType.Relative, testingTarget.SizePolicyHeight, "Retrieved SizePolicyHeight should be equal to set value");

            testingTarget.SizePolicyHeight = VisualTransformPolicyType.Absolute;
            Assert.AreEqual(VisualTransformPolicyType.Absolute, testingTarget.SizePolicyHeight, "Retrieved SizePolicyHeight should be equal to set value");

            testingTarget.SizePolicyHeight = VisualTransformPolicyType.Relative;
            Assert.AreEqual(VisualTransformPolicyType.Relative, testingTarget.SizePolicyHeight, "Retrieved SizePolicyHeight should be equal to set value");

            // default
            try
            {
                testingTarget.SizePolicyHeight = (VisualTransformPolicyType)3;
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"VisualMapSizePolicyHeight END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("VisualMap Origin.")]
        [Property("SPEC", "Tizen.NUI.VisualMap.Origin A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@.samsung.com")]
        public void VisualMapOrigin()
        {
            tlog.Debug(tag, $"VisualMapOrigin START");

            var testingTarget = new VisualMap();
            Assert.IsNotNull(testingTarget, "Can't create success object VisualMap");
            Assert.IsInstanceOf<VisualMap>(testingTarget, "Should be an instance of VisualMap type.");

            testingTarget.Origin = Visual.AlignType.Center;
            Assert.AreEqual(Visual.AlignType.Center, testingTarget.Origin, "Retrieved Origin should be equal to set value");

            testingTarget.Dispose();
            tlog.Debug(tag, $"VisualMapOrigin END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("VisualMap AnchorPoint.")]
        [Property("SPEC", "Tizen.NUI.VisualMap.AnchorPoint A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void VisualMapAnchorPoint()
        {
            tlog.Debug(tag, $"VisualMapAnchorPoint START");

            var testingTarget = new VisualMap();
            Assert.IsNotNull(testingTarget, "Can't create success object VisualMap");
            Assert.IsInstanceOf<VisualMap>(testingTarget, "Should be an instance of VisualMap type.");

            testingTarget.AnchorPoint = Visual.AlignType.Center;
            Assert.AreEqual(Visual.AlignType.Center, testingTarget.AnchorPoint, "Retrieved PivotPoint should be equal to set value");

            testingTarget.Dispose();
            tlog.Debug(tag, $"VisualMapAnchorPoint END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("VisualMap DepthIndex.")]
        [Property("SPEC", "Tizen.NUI.VisualMap.DepthIndex A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void VisualMapDepthIndex()
        {
            tlog.Debug(tag, $"VisualMapDepthIndex START");

            var testingTarget = new VisualMap();
            Assert.IsNotNull(testingTarget, "Can't create success object VisualMap");
            Assert.IsInstanceOf<VisualMap>(testingTarget, "Should be an instance of VisualMap type.");

            testingTarget.DepthIndex = 1;
            Assert.AreEqual(1, testingTarget.DepthIndex, "Retrieved DepthIndex should be equal to set value");

            testingTarget.Dispose();
            tlog.Debug(tag, $"VisualMapDepthIndex END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("VisualMap OutputTransformMap.")]
        [Property("SPEC", "Tizen.NUI.VisualMap.OutputTransformMap A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void VisualMapOutputTransformMap()
        {
            tlog.Debug(tag, $"VisualMapOutputTransformMap START");

            var testingTarget = new VisualMap();
            Assert.IsNotNull(testingTarget, "Can't create success object VisualMap");
            Assert.IsInstanceOf<VisualMap>(testingTarget, "Should be an instance of VisualMap type.");

            using (Vector2 vector2 = new Vector2(1.0f, 1.0f))
            {
                testingTarget.Size = vector2;
                testingTarget.Position = vector2;
                testingTarget.PositionPolicy = VisualTransformPolicyType.Absolute;
                testingTarget.SizePolicy = VisualTransformPolicyType.Absolute;
                testingTarget.Origin = Visual.AlignType.Center;
                testingTarget.AnchorPoint = Visual.AlignType.Center;

                var result = testingTarget.OutputTransformMap;
                Assert.IsNotNull(result, "Can't create success object VisualMap");
                Assert.IsInstanceOf<PropertyMap>(result, "Should be an instance of PropertyMap type.");

                result.Find((int)VisualTransformPropertyType.Size).Get(vector2);
                Assert.AreEqual(1.0f, vector2.X, "Retrieved VisualSize.X should be equal to set value");
                Assert.AreEqual(1.0f, vector2.Y, "Retrieved VisualSize.Y should be equal to set value");
                result.Find((int)VisualTransformPropertyType.Offset).Get(vector2);
                Assert.AreEqual(1.0f, vector2.X, "Retrieved Offset.X should be equal to set value");
                Assert.AreEqual(1.0f, vector2.Y, "Retrieved Offset.Y should be equal to set value");
                result.Find((int)VisualTransformPropertyType.OffsetPolicy).Get(vector2);
                Assert.AreEqual(1.0f, vector2.X, "Retrieved OffsetPolicy.X should be equal to set value");
                Assert.AreEqual(1.0f, vector2.Y, "Retrieved OffsetPolicy.Y should be equal to set value");
                result.Find((int)VisualTransformPropertyType.SizePolicy).Get(vector2);
                Assert.AreEqual(1.0f, vector2.X, "Retrieved SizePolicy.X should be equal to set value");
                Assert.AreEqual(1.0f, vector2.Y, "Retrieved SizePolicy.Y should be equal to set value");

                int type = 0;
                result.Find((int)VisualTransformPropertyType.Origin).Get(out type);
                Assert.AreEqual((int)Visual.AlignType.Center, type, "Retrieved Origin should be equal to set value");
                result.Find((int)VisualTransformPropertyType.AnchorPoint).Get(out type);
                Assert.AreEqual((int)Visual.AlignType.Center, type, "Retrieved AnchorPoint should be equal to set value");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"VisualMapOutputTransformMap END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("VisualMap OutputVisualMap.")]
        [Property("SPEC", "Tizen.NUI.VisualMap.OutputVisualMap A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void VisualMapOutputVisualMap()
        {
            tlog.Debug(tag, $"VisualMapOutputVisualMap START");

            var testingTarget = new VisualMap();
            Assert.IsNotNull(testingTarget, "Can't create success object VisualMap");
            Assert.IsInstanceOf<VisualMap>(testingTarget, "Should be an instance of VisualMap type.");

            var result = testingTarget.OutputVisualMap;
            Assert.IsNotNull(result, "Should not be null");

            testingTarget.Dispose();
            tlog.Debug(tag, $"VisualMapOutputVisualMap END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("VisualMap VisualFittingMode.")]
        [Property("SPEC", "Tizen.NUI.VisualMap.VisualFittingMode A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void VisualMapVisualFittingMode()
        {
            tlog.Debug(tag, $"VisualMapVisualFittingMode START");

            var testingTarget = new VisualMap();
            Assert.IsNotNull(testingTarget, "Can't create success object VisualMap");
            Assert.IsInstanceOf<VisualMap>(testingTarget, "Should be an instance of VisualMap type.");

            testingTarget.VisualFittingMode = VisualFittingModeType.Fill;
            Assert.AreEqual(VisualFittingModeType.Fill, testingTarget.VisualFittingMode, "Retrieved VisualFittingMode should be equal to set value");

            testingTarget.VisualFittingMode = VisualFittingModeType.FitKeepAspectRatio;
            Assert.AreEqual(VisualFittingModeType.FitKeepAspectRatio, testingTarget.VisualFittingMode, "Retrieved VisualFittingMode should be equal to set value");

            testingTarget.Dispose();
            tlog.Debug(tag, $"VisualMapVisualFittingMode END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("VisualMap VisualFittingMode.")]
        [Property("SPEC", "Tizen.NUI.VisualMap.VisualFittingMode A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void VisualMapVisualFittingModeWithNullMode()
        {
            tlog.Debug(tag, $"VisualMapVisualFittingModeWithNullMode START");

            TextVisual tVisual = new TextVisual();
            Assert.AreEqual(VisualFittingModeType.FitKeepAspectRatio, tVisual.VisualFittingMode, "should be equal!");

            BorderVisual bvisual = new BorderVisual();
            Assert.AreEqual(VisualFittingModeType.Fill, bvisual.VisualFittingMode, "should be equal!");

            tVisual.Dispose();
            bvisual.Dispose();
            tlog.Debug(tag, $"VisualMapVisualFittingModeWithNullMode END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("VisualMap CornerRadius.")]
        [Property("SPEC", "Tizen.NUI.VisualMap.CornerRadius A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void VisualMapCornerRadius()
        {
            tlog.Debug(tag, $"VisualMapCornerRadius START");

            var testingTarget = new VisualMap();
            Assert.IsNotNull(testingTarget, "Can't create success object VisualMap");
            Assert.IsInstanceOf<VisualMap>(testingTarget, "Should be an instance of VisualMap type.");

            testingTarget.CornerRadius = new Vector4(1.0f, 1.0f, 1.0f, 1.0f);

            Assert.AreEqual(1.0f, testingTarget.CornerRadius.X);
            Assert.AreEqual(1.0f, testingTarget.CornerRadius.Y);
            Assert.AreEqual(1.0f, testingTarget.CornerRadius.Z);
            Assert.AreEqual(1.0f, testingTarget.CornerRadius.W);

            testingTarget.Dispose();
            tlog.Debug(tag, $"VisualMapCornerRadius END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("VisualMap ComposingPropertyMap.")]
        [Property("SPEC", "Tizen.NUI.VisualMap.ComposingPropertyMap M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void VisualMapComposingPropertyMap()
        {
            tlog.Debug(tag, $"VisualMapComposingPropertyMap START");

            flagComposingPropertyMap = false;
            Assert.False(flagComposingPropertyMap, "flagComposingPropertyMap should false initial");

            var testingTarget = new MyVisualMap();
            Assert.IsInstanceOf<VisualMap>(testingTarget, "Should be an instance of VisualMap type.");

            testingTarget.VisualFittingMode = VisualFittingModeType.Fill;
            testingTarget.CornerRadius = new Vector4(0.8f, 0.8f, 0.8f, 0.8f);

            PropertyMap propertyMap = testingTarget.OutputVisualMap;
            Assert.AreEqual(2, propertyMap.Count(), "Retrieved PropertyMap count should be 0");
            Assert.True(flagComposingPropertyMap, "ComposingPropertyMap overrided method not invoked.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"VisualMapComposingPropertyMap END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("VisualMap BorderlineWidth.")]
        [Property("SPEC", "Tizen.NUI.VisualMap.BorderlineWidth A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void VisualMapBorderlineWidth()
        {
            tlog.Debug(tag, $"VisualMapBorderlineWidth START");

            var testingTarget = new VisualMap();
            Assert.IsNotNull(testingTarget, "Can't create success object VisualMap");
            Assert.IsInstanceOf<VisualMap>(testingTarget, "Should be an instance of VisualMap type.");

            testingTarget.BorderlineWidth = 0.3f;
            Assert.AreEqual(0.3f, testingTarget.BorderlineWidth, "should be equal!");

            testingTarget.BorderlineColor = new Vector4(1.0f, 1.0f, 1.0f, 0.0f);
            Assert.AreEqual(1.0f, testingTarget.BorderlineColor.R, "should be equal!");

            testingTarget.BorderlineOffset = 0.2f;
            Assert.AreEqual(0.2f, testingTarget.BorderlineOffset, "should be equal!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"VisualMapBorderlineWidth END (OK)");
        }
    }
}
