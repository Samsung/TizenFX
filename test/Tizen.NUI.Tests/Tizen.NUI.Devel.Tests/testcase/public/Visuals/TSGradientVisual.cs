using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("public/Visuals/GradientVisual")]
    public class PublicGradientVisualTest
    {
        private const string tag = "NUITEST";
        private static bool flagComposingPropertyMap;
        internal class MyGradientVisual : GradientVisual
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
        [Description("GradientVisual constructor.")]
        [Property("SPEC", "Tizen.NUI.GradientVisual.GradientVisual C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void GradientVisualConstructor()
        {
            tlog.Debug(tag, $"GradientVisualConstructor START");

            var testingTarget = new GradientVisual();
            Assert.IsNotNull(testingTarget, "Can't create success object GradientVisual");
            Assert.IsInstanceOf<GradientVisual>(testingTarget, "Should be an instance of GradientVisual type.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"GradientVisualConstructor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("GradientVisual StartPosition.")]
        [Property("SPEC", "Tizen.NUI.GradientVisual.StartPosition A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void GradientVisualStartPosition()
        {
            tlog.Debug(tag, $"GradientVisualStartPosition START");

            var testingTarget = new GradientVisual();
            Assert.IsNotNull(testingTarget, "Can't create success object GradientVisual");
            Assert.IsInstanceOf<GradientVisual>(testingTarget, "Should be an instance of GradientVisual type.");

            using (Vector2 vector = new Vector2(1.0f, 1.0f))
            {
                testingTarget.StartPosition = vector;
                Assert.AreEqual(1.0f, testingTarget.StartPosition.X, "Retrieved StartPosition.X should be equal to set value");
                Assert.AreEqual(1.0f, testingTarget.StartPosition.Y, "Retrieved StartPosition.Y should be equal to set value");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"GradientVisualStartPosition END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("GradientVisual EndPosition.")]
        [Property("SPEC", "Tizen.NUI.GradientVisual.EndPosition A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void GradientVisualEndPosition()
        {
            tlog.Debug(tag, $"GradientVisualEndPosition START");

            var testingTarget = new GradientVisual();
            Assert.IsNotNull(testingTarget, "Can't create success object GradientVisual");
            Assert.IsInstanceOf<GradientVisual>(testingTarget, "Should be an instance of GradientVisual type.");

            using (Vector2 vector = new Vector2(1.0f, 1.0f)) 
            {
                testingTarget.EndPosition = vector;
                Assert.AreEqual(1.0f, testingTarget.EndPosition.X, "Retrieved EndPosition.X should be equal to set value");
                Assert.AreEqual(1.0f, testingTarget.EndPosition.Y, "Retrieved EndPosition.Y should be equal to set value");
            }
           
            testingTarget.Dispose();
            tlog.Debug(tag, $"GradientVisualEndPosition END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("GradientVisual Center.")]
        [Property("SPEC", "Tizen.NUI.GradientVisual.Center A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void GradientVisualCenter()
        {
            tlog.Debug(tag, $"GradientVisualCenter START");

            var testingTarget = new GradientVisual();
            Assert.IsNotNull(testingTarget, "Can't create success object GradientVisual");
            Assert.IsInstanceOf<GradientVisual>(testingTarget, "Should be an instance of GradientVisual type.");

            using (Vector2 vector = new Vector2(1.0f, 1.0f))
            {
                testingTarget.Center = vector;
                Assert.AreEqual(1.0f, testingTarget.Center.X, "Retrieved Center.X should be equal to set value");
                Assert.AreEqual(1.0f, testingTarget.Center.Y, "Retrieved Center.Y should be equal to set value");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"GradientVisualCenter END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("GradientVisual Radius.")]
        [Property("SPEC", "Tizen.NUI.GradientVisual.Radius A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void GradientVisualRadius()
        {
            tlog.Debug(tag, $"GradientVisualRadius START");

            var testingTarget = new GradientVisual();
            Assert.IsNotNull(testingTarget, "Can't create success object GradientVisual");
            Assert.IsInstanceOf<GradientVisual>(testingTarget, "Should be an instance of GradientVisual type.");

            testingTarget.Radius = 1.0f;
            Assert.AreEqual(1.0f, testingTarget.Radius, "Retrieved Radius should be equal to set value");

            testingTarget.Dispose();
            tlog.Debug(tag, $"GradientVisualRadius END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("GradientVisual StopOffset.")]
        [Property("SPEC", "Tizen.NUI.GradientVisual.StopOffset A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void GradientVisualStopOffset()
        {
            tlog.Debug(tag, $"GradientVisualStopOffset START");

            var testingTarget = new GradientVisual();
            Assert.IsNotNull(testingTarget, "Can't create success object GradientVisual");
            Assert.IsInstanceOf<GradientVisual>(testingTarget, "Should be an instance of GradientVisual type.");

            PropertyArray array = new PropertyArray();
            for (float i = 0; i < 5; i += 1.0f)
            {
                array.Add(new PropertyValue(i));
            }
            testingTarget.StopOffset = array;

            PropertyArray result = testingTarget.StopOffset;
            Assert.IsNotNull(result, "Should not be null");
            Assert.AreEqual(array.Count(), result.Count(), "Should be equals to the set count");

            float set_value = 0.0f;
            float get_value = 0.0f;
            for (uint i = 0; i < array.Count(); i++)
            {
                array[i].Get(out set_value);
                result[i].Get(out get_value);
                Assert.AreEqual(set_value, get_value, "index" + i + " should be equals to set value");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"GradientVisualStopOffset END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("GradientVisual StopColor.")]
        [Property("SPEC", "Tizen.NUI.GradientVisual.StopColor A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void GradientVisualStopColor()
        {
            tlog.Debug(tag, $"GradientVisualStopColor START");

            var testingTarget = new GradientVisual();
            Assert.IsNotNull(testingTarget, "Can't create success object GradientVisual");
            Assert.IsInstanceOf<GradientVisual>(testingTarget, "Should be an instance of GradientVisual type.");

            PropertyArray array = new PropertyArray();
            for (float i = 0; i < 5; i += 1.0f)
            {
                array.Add(new PropertyValue(i));
            }
            testingTarget.StopColor = array;

            PropertyArray result = testingTarget.StopColor;
            Assert.IsNotNull(result, "Should not be null");
            Assert.AreEqual(array.Count(), result.Count(), "Should be equals to the set count");

            float set_value = 0.0f;
            float get_value = 0.0f;
            for (uint i = 0; i < array.Count(); i++)
            {
                array[i].Get(out set_value);
                result[i].Get(out get_value);
                Assert.AreEqual(set_value, get_value, "index" + i + " should be equals to set value");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"GradientVisualStopColor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("GradientVisual Units.")]
        [Property("SPEC", "Tizen.NUI.GradientVisual.Units A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void GradientVisualUnits()
        {
            tlog.Debug(tag, $"GradientVisualUnits START");

            var testingTarget = new GradientVisual();
            Assert.IsNotNull(testingTarget, "Can't create success object GradientVisual");
            Assert.IsInstanceOf<GradientVisual>(testingTarget, "Should be an instance of GradientVisual type.");

            testingTarget.Units = GradientVisualUnitsType.ObjectBoundingBox;
            Assert.AreEqual(GradientVisualUnitsType.ObjectBoundingBox, testingTarget.Units, "Retrieved Units should be equal to set value");

            testingTarget.Dispose();
            tlog.Debug(tag, $"GradientVisualUnits END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("GradientVisual SpreadMethod.")]
        [Property("SPEC", "Tizen.NUI.GradientVisual.SpreadMethod A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void GradientVisualSpreadMethod()
        {
            tlog.Debug(tag, $"GradientVisualUnits START");

            var testingTarget = new GradientVisual();
            Assert.IsNotNull(testingTarget, "Can't create success object GradientVisual");
            Assert.IsInstanceOf<GradientVisual>(testingTarget, "Should be an instance of GradientVisual type.");

            testingTarget.SpreadMethod = GradientVisualSpreadMethodType.Pad;
            Assert.AreEqual(GradientVisualSpreadMethodType.Pad, testingTarget.SpreadMethod, "Retrieved SpreadMethod should be equal to set value");

            testingTarget.Dispose();
            tlog.Debug(tag, $"GradientVisualUnits END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("GradientVisual ComposingPropertyMap.")]
        [Property("SPEC", "Tizen.NUI.GradientVisual.ComposingPropertyMap M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void GradientVisualComposingPropertyMap()
        {
            tlog.Debug(tag, $"GradientVisualComposingPropertyMap START");

            flagComposingPropertyMap = false;
            Assert.False(flagComposingPropertyMap, "flagComposingPropertyMap should false initial");

            var testingTarget = new MyGradientVisual()
            {
                StartPosition = new Vector2(1.0f, 1.0f),
                EndPosition = new Vector2(1.0f, 1.0f),
                Center = new Vector2(1.0f, 1.0f),
                Radius = 2.0f,
                StopOffset = new PropertyArray(),
                Units = GradientVisualUnitsType.ObjectBoundingBox,
                SpreadMethod = GradientVisualSpreadMethodType.Pad,
                StopColor = new PropertyArray(),
            };
            Assert.IsInstanceOf<GradientVisual>(testingTarget, "Should be an instance of GradientVisual type.");
            PropertyMap propertyMap = testingTarget.OutputVisualMap;
            Assert.True(flagComposingPropertyMap, "ComposingPropertyMap overrided method not invoked.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"GradientVisualComposingPropertyMap END (OK)");
        }
    }
}
