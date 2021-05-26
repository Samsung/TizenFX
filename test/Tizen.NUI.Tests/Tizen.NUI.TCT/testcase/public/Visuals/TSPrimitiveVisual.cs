using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("public/Visuals/PrimitiveVisual")]
    public class PublicPrimitiveVisualTest
    {
        private const string tag = "NUITEST";
        private static bool flagComposingPropertyMap;
        internal class MyPrimitiveVisual : PrimitiveVisual
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
        [Description("PrimitiveVisual constructor.")]
        [Property("SPEC", "Tizen.NUI.PrimitiveVisual.PrimitiveVisual C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PrimitiveVisualConstructor()
        {
            tlog.Debug(tag, $"PrimitiveVisualConstructor START");

            var testingTarget = new PrimitiveVisual();
            Assert.IsNotNull(testingTarget, "Can't create success object PrimitiveVisualMap");
            Assert.IsInstanceOf<PrimitiveVisual>(testingTarget, "Should be an instance of PrimitiveVisualMap type.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"PrimitiveVisualConstructor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("PrimitiveVisual Shape.")]
        [Property("SPEC", "Tizen.NUI.PrimitiveVisual.Shape A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PrimitiveVisualShape()
        {
            tlog.Debug(tag, $"PrimitiveVisualShape START");

            var testingTarget = new PrimitiveVisual();
            Assert.IsNotNull(testingTarget, "Can't create success object PrimitiveVisualMap");
            Assert.IsInstanceOf<PrimitiveVisual>(testingTarget, "Should be an instance of PrimitiveVisualMap type.");

            testingTarget.Shape = PrimitiveVisualShapeType.BevelledCube;
            Assert.AreEqual(PrimitiveVisualShapeType.BevelledCube, testingTarget.Shape, "Retrieved Shape should be equal to set value");

            testingTarget.Dispose();
            tlog.Debug(tag, $"PrimitiveVisualShape END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("PrimitiveVisual MixColor.")]
        [Property("SPEC", "Tizen.NUI.PrimitiveVisual.MixColor A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PrimitiveVisualMixColor()
        {
            tlog.Debug(tag, $"PrimitiveVisualMixColor START");

            var testingTarget = new PrimitiveVisual();
            Assert.IsNotNull(testingTarget, "Can't create success object PrimitiveVisualMap");
            Assert.IsInstanceOf<PrimitiveVisual>(testingTarget, "Should be an instance of PrimitiveVisualMap type.");

            Color color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
            testingTarget.MixColor = color;
            Assert.AreEqual(1.0f, testingTarget.MixColor.R, "Retrieved MixColor.R should be equal to set value");
            Assert.AreEqual(1.0f, testingTarget.MixColor.G, "Retrieved MixColor.G should be equal to set value");
            Assert.AreEqual(1.0f, testingTarget.MixColor.B, "Retrieved MixColor.B should be equal to set value");
            Assert.AreEqual(1.0f, testingTarget.MixColor.A, "Retrieved MixColor.A should be equal to set value");

            testingTarget.Dispose();
            tlog.Debug(tag, $"PrimitiveVisualMixColor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("PrimitiveVisual Slices.")]
        [Property("SPEC", "Tizen.NUI.PrimitiveVisual.Slices A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PrimitiveVisualSlices()
        {
            tlog.Debug(tag, $"PrimitiveVisualSlices START");

            var testingTarget = new PrimitiveVisual();
            Assert.IsNotNull(testingTarget, "Can't create success object PrimitiveVisualMap");
            Assert.IsInstanceOf<PrimitiveVisual>(testingTarget, "Should be an instance of PrimitiveVisualMap type.");

            testingTarget.Slices = 3;
            Assert.AreEqual(3, testingTarget.Slices, "Retrieved Slices should be equal to set value");

            testingTarget.Dispose();
            tlog.Debug(tag, $"PrimitiveVisualSlices END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("PrimitiveVisual Stacks.")]
        [Property("SPEC", "Tizen.NUI.PrimitiveVisual.Stacks A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PrimitiveVisualStacks()
        {
            tlog.Debug(tag, $"PrimitiveVisualStacks START");

            var testingTarget = new PrimitiveVisual();
            Assert.IsNotNull(testingTarget, "Can't create success object PrimitiveVisualMap");
            Assert.IsInstanceOf<PrimitiveVisual>(testingTarget, "Should be an instance of PrimitiveVisualMap type.");

            testingTarget.Stacks = 3;
            Assert.AreEqual(3, testingTarget.Stacks, "Retrieved Stacks should be equal to set value");

            testingTarget.Dispose();
            tlog.Debug(tag, $"PrimitiveVisualStacks END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("PrimitiveVisual ScaleTopRadius.")]
        [Property("SPEC", "Tizen.NUI.PrimitiveVisual.ScaleTopRadius A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PrimitiveVisualScaleTopRadius()
        {
            tlog.Debug(tag, $"PrimitiveVisualScaleTopRadius START");

            var testingTarget = new PrimitiveVisual();
            Assert.IsNotNull(testingTarget, "Can't create success object PrimitiveVisualMap");
            Assert.IsInstanceOf<PrimitiveVisual>(testingTarget, "Should be an instance of PrimitiveVisualMap type.");

            testingTarget.ScaleTopRadius = 1.0f;
            Assert.AreEqual(1.0f, testingTarget.ScaleTopRadius, "Retrieved ScaleTopRadius should be equal to set value");

            testingTarget.Dispose();
            tlog.Debug(tag, $"PrimitiveVisualScaleTopRadius END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("PrimitiveVisual ScaleBottomRadius.")]
        [Property("SPEC", "Tizen.NUI.PrimitiveVisual.ScaleBottomRadius A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PrimitiveVisualScaleBottomRadius()
        {
            tlog.Debug(tag, $"PrimitiveVisualScaleBottomRadius START");

            var testingTarget = new PrimitiveVisual();
            Assert.IsNotNull(testingTarget, "Can't create success object PrimitiveVisualMap");
            Assert.IsInstanceOf<PrimitiveVisual>(testingTarget, "Should be an instance of PrimitiveVisualMap type.");

            testingTarget.ScaleBottomRadius = 1.0f;
            Assert.AreEqual(1.0f, testingTarget.ScaleBottomRadius, "Retrieved ScaleBottomRadius should be equal to set value");

            testingTarget.Dispose();
            tlog.Debug(tag, $"PrimitiveVisualScaleBottomRadius END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("PrimitiveVisual ScaleHeight.")]
        [Property("SPEC", "Tizen.NUI.PrimitiveVisual.ScaleHeight A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PrimitiveVisualScaleHeight()
        {
            tlog.Debug(tag, $"PrimitiveVisualScaleHeight START");

            var testingTarget = new PrimitiveVisual();
            Assert.IsNotNull(testingTarget, "Can't create success object PrimitiveVisualMap");
            Assert.IsInstanceOf<PrimitiveVisual>(testingTarget, "Should be an instance of PrimitiveVisualMap type.");

            testingTarget.ScaleHeight = 1.0f;
            Assert.AreEqual(1.0f, testingTarget.ScaleHeight, "Retrieved ScaleHeight should be equal to set value");

            testingTarget.Dispose();
            tlog.Debug(tag, $"PrimitiveVisualScaleHeight END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("PrimitiveVisual ScaleRadius.")]
        [Property("SPEC", "Tizen.NUI.PrimitiveVisual.ScaleRadius A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PrimitiveVisualScaleRadius()
        {
            tlog.Debug(tag, $"PrimitiveVisualScaleRadius START");

            var testingTarget = new PrimitiveVisual();
            Assert.IsNotNull(testingTarget, "Can't create success object PrimitiveVisualMap");
            Assert.IsInstanceOf<PrimitiveVisual>(testingTarget, "Should be an instance of PrimitiveVisualMap type.");

            testingTarget.ScaleRadius = 1.0f;
            Assert.AreEqual(1.0f, testingTarget.ScaleRadius, "Retrieved ScaleRadius should be equal to set value");

            testingTarget.Dispose();
            tlog.Debug(tag, $"PrimitiveVisualScaleRadius END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("PrimitiveVisual ScaleDimensions.")]
        [Property("SPEC", "Tizen.NUI.PrimitiveVisual.ScaleDimensions A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PrimitiveVisualScaleDimensions()
        {
            tlog.Debug(tag, $"PrimitiveVisualScaleDimensions START");

            var testingTarget = new PrimitiveVisual();
            Assert.IsNotNull(testingTarget, "Can't create success object PrimitiveVisualMap");
            Assert.IsInstanceOf<PrimitiveVisual>(testingTarget, "Should be an instance of PrimitiveVisualMap type.");

            using (Vector3 vector3 = new Vector3(1.0f, 1.0f, 1.0f))
            {
                testingTarget.ScaleDimensions = vector3;
                Assert.AreEqual(1.0f, testingTarget.ScaleDimensions.X, "Retrieved ScaleDimensions.X should be equal to set value");
                Assert.AreEqual(1.0f, testingTarget.ScaleDimensions.Y, "Retrieved ScaleDimensions.Y should be equal to set value");
                Assert.AreEqual(1.0f, testingTarget.ScaleDimensions.Z, "Retrieved ScaleDimensions.Z should be equal to set value");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"PrimitiveVisualScaleDimensions END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("PrimitiveVisual BevelPercentage.")]
        [Property("SPEC", "Tizen.NUI.PrimitiveVisual.BevelPercentage A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PrimitiveVisualBevelPercentage()
        {
            tlog.Debug(tag, $"PrimitiveVisualBevelPercentage START");

            var testingTarget = new PrimitiveVisual();
            Assert.IsNotNull(testingTarget, "Can't create success object PrimitiveVisualMap");
            Assert.IsInstanceOf<PrimitiveVisual>(testingTarget, "Should be an instance of PrimitiveVisualMap type.");

            testingTarget.BevelPercentage = 1.0f;
            Assert.AreEqual(1.0f, testingTarget.BevelPercentage, "Retrieved BevelPercentage should be equal to set value");

            testingTarget.Dispose();
            tlog.Debug(tag, $"PrimitiveVisualBevelPercentage END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("PrimitiveVisual BevelSmoothness.")]
        [Property("SPEC", "Tizen.NUI.PrimitiveVisual.BevelSmoothness A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PrimitiveVisualBevelSmoothness()
        {
            tlog.Debug(tag, $"PrimitiveVisualBevelSmoothness START");

            var testingTarget = new PrimitiveVisual();
            Assert.IsNotNull(testingTarget, "Can't create success object PrimitiveVisualMap");
            Assert.IsInstanceOf<PrimitiveVisual>(testingTarget, "Should be an instance of PrimitiveVisualMap type.");

            testingTarget.BevelSmoothness = 1.0f;
            Assert.AreEqual(1.0f, testingTarget.BevelSmoothness, "Retrieved BevelSmoothness should be equal to set value");

            testingTarget.Dispose();
            tlog.Debug(tag, $"PrimitiveVisualBevelSmoothness END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("PrimitiveVisual LightPosition.")]
        [Property("SPEC", "Tizen.NUI.PrimitiveVisual.LightPosition A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PrimitiveVisualLightPosition()
        {
            tlog.Debug(tag, $"PrimitiveVisualLightPosition START");

            var testingTarget = new PrimitiveVisual();
            Assert.IsNotNull(testingTarget, "Can't create success object PrimitiveVisualMap");
            Assert.IsInstanceOf<PrimitiveVisual>(testingTarget, "Should be an instance of PrimitiveVisualMap type.");

            using (Vector3 vector3 = new Vector3(1.0f, 1.0f, 1.0f))
            {
                testingTarget.LightPosition = vector3;
                Assert.AreEqual(1.0f, testingTarget.LightPosition.X, "Retrieved LightPosition.X should be equal to set value");
                Assert.AreEqual(1.0f, testingTarget.LightPosition.Y, "Retrieved LightPosition.Y should be equal to set value");
                Assert.AreEqual(1.0f, testingTarget.LightPosition.Z, "Retrieved LightPosition.Z should be equal to set value");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"PrimitiveVisualLightPosition END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("PrimitiveVisual ComposingPropertyMap.")]
        [Property("SPEC", "Tizen.NUI.PrimitiveVisual.ComposingPropertyMap M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PrimitiveVisualComposingPropertyMap()
        {
            tlog.Debug(tag, $"PrimitiveVisualComposingPropertyMap START");

            flagComposingPropertyMap = false;
            Assert.False(flagComposingPropertyMap, "flagComposingPropertyMap should false initial");

            var testingTarget = new MyPrimitiveVisual()
            {
                Shape = PrimitiveVisualShapeType.BevelledCube,
                MixColor = new Color(1.0f, 1.0f, 1.0f, 1.0f),
                Slices = 3,
                Stacks = 3,
                ScaleTopRadius = 1.0f,
                ScaleBottomRadius = 1.0f,
                ScaleHeight = 1.0f,
                ScaleRadius = 1.0f,
                ScaleDimensions = new Vector3(1.0f, 1.0f, 1.0f),
                BevelPercentage = 0.3f,
                BevelSmoothness = 0.5f,
                LightPosition = new Vector3(1.0f, 1.0f, 1.0f),
            };
            Assert.IsInstanceOf<PrimitiveVisual>(testingTarget, "Should be an instance of PrimitiveVisual type.");
            PropertyMap propertyMap = testingTarget.OutputVisualMap;
            Assert.True(flagComposingPropertyMap, "ComposingPropertyMap overrided method not invoked.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"PrimitiveVisualComposingPropertyMap END (OK)");
        }
    }
}
