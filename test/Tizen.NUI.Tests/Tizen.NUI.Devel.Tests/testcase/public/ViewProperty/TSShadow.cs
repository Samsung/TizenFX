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
    [Description("public/ViewProperty/Shadow.cs")]
    public class PublicShadowTest
    {
        private const string tag = "NUITEST";

        internal class MyShadow : Shadow
        {
            public MyShadow() : base()
            { }

            public void OnGetPropertyMap()
            {
                base.GetPropertyMap();
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
        [Description("Shadow constructor.")]
        [Property("SPEC", "Tizen.NUI.Shadow.Shadow C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ShadowConstructor()
        {
            tlog.Debug(tag, $"ShadowConstructor START");

            var testingTarget = new Shadow();
            Assert.IsNotNull(testingTarget, "Can't create success object Shadow");
            Assert.IsInstanceOf<Shadow>(testingTarget, "Should be an instance of Shadow type.");

            tlog.Debug(tag, $"ShadowConstructor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Shadow constructor. With custom value.")]
        [Property("SPEC", "Tizen.NUI.Shadow.Shadow C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ShadowConstructorWithCustomValue()
        {
            tlog.Debug(tag, $"ShadowConstructorWithCustomValue START");

            var testingTarget = new Shadow(1.5f, Color.CadetBlue, null, null);
            Assert.IsNotNull(testingTarget, "Can't create success object Shadow");
            Assert.IsInstanceOf<Shadow>(testingTarget, "Should be an instance of Shadow type.");

            tlog.Debug(tag, $"ShadowConstructorWithCustomValue END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Shadow constructor. Copy other.")]
        [Property("SPEC", "Tizen.NUI.Shadow.Shadow C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ShadowConstructorCopyOther()
        {
            tlog.Debug(tag, $"ShadowConstructorCopyOther START");

            var testingTarget = new Shadow(new Shadow());
            Assert.IsNotNull(testingTarget, "Can't create success object Shadow");
            Assert.IsInstanceOf<Shadow>(testingTarget, "Should be an instance of Shadow type.");

            tlog.Debug(tag, $"ShadowConstructorCopyOther END (OK)");
        }

        [Test]
        [Category("P2")]
        [Description("Shadow constructor. Copy null.")]
        [Property("SPEC", "Tizen.NUI.Shadow.Shadow C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ShadowConstructorCopyNull()
        {
            tlog.Debug(tag, $"ShadowConstructorCopyNull START");

            Shadow shadow = null;

            try
            {
                var testingTarget = new Shadow(shadow);
            }
            catch (ArgumentNullException e)
            {
                tlog.Debug(tag, $"ShadowConstructorCopyNull END (OK)");
                tlog.Debug(tag, e.Message.ToString());
                Assert.Pass("Caught ArgumentNullException: Passed!");
            }
        }

        [Test]
        [Category("P1")]
        [Description("Shadow constructor. From PropertyMap.")]
        [Property("SPEC", "Tizen.NUI.Shadow.Shadow C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ShadowConstructorFromPropertyMap()
        {
            tlog.Debug(tag, $"ShadowConstructorFromPropertyMap START");

            using (PropertyMap map = new PropertyMap())
            {
                map.Insert(Visual.Property.Transform, new PropertyValue(Interop.Visual.TransformGet()));
                map.Insert(ColorVisualProperty.MixColor, new PropertyValue(Color.Cyan));
                map.Insert(ColorVisualProperty.BlurRadius, new PropertyValue(0.3f));

                var testingTarget = new Shadow(map);
                Assert.AreEqual(0.3f, testingTarget.BlurRadius);
            }
            tlog.Debug(tag, $"ShadowConstructorFromPropertyMap END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Shadow Equals.")]
        [Property("SPEC", "Tizen.NUI.Shadow.Equals M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ShadowEquals()
        {
            tlog.Debug(tag, $"ShadowEquals START");

            var testingTarget = new Shadow();
            Assert.IsNotNull(testingTarget, "Can't create success object Shadow");
            Assert.IsInstanceOf<Shadow>(testingTarget, "Should be an instance of Shadow type.");

            var result = testingTarget.Equals(new Shadow());
            Assert.IsTrue(result);

            testingTarget.Offset = new Vector2(0.8f, 1.3f);
            result = testingTarget.Equals(new Shadow());
            Assert.IsFalse(result);
            Assert.IsTrue(testingTarget != new Shadow());

            tlog.Debug(tag, $"ShadowEquals END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Shadow GetHashCode.")]
        [Property("SPEC", "Tizen.NUI.Shadow.GetHashCode M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ShadowGetHashCode()
        {
            tlog.Debug(tag, $"ShadowGetHashCode START");

            var testingTarget = new Shadow();
            Assert.IsNotNull(testingTarget, "Can't create success object Shadow");
            Assert.IsInstanceOf<Shadow>(testingTarget, "Should be an instance of Shadow type.");

            testingTarget.Color = Color.Cyan;
            testingTarget.BlurRadius = 0.3f;

            var result = testingTarget.GetHashCode();
            Assert.IsNotNull(result);

            tlog.Debug(tag, $"ShadowGetHashCode END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Shadow Clone.")]
        [Property("SPEC", "Tizen.NUI.Shadow.Clone M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ShadowClone()
        {
            tlog.Debug(tag, $"ShadowClone START");

            var testingTarget = new Shadow();
            Assert.IsNotNull(testingTarget, "Can't create success object Shadow");
            Assert.IsInstanceOf<Shadow>(testingTarget, "Should be an instance of Shadow type.");

            var result = testingTarget.Clone();
            Assert.IsNotNull(result, "Can't create success object Shadow");
            Assert.IsInstanceOf<Shadow>(result, "Should be an instance of Shadow type.");

            tlog.Debug(tag, $"ShadowClone END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Shadow IsEmpty.")]
        [Property("SPEC", "Tizen.NUI.Shadow.IsEmpty M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ShadowIsEmpty()
        {
            tlog.Debug(tag, $"ShadowIsEmpty START");

            var testingTarget = new Shadow();
            Assert.IsNotNull(testingTarget, "Can't create success object Shadow");
            Assert.IsInstanceOf<Shadow>(testingTarget, "Should be an instance of Shadow type.");

            var result = testingTarget.IsEmpty();
            Assert.IsFalse(result);

            tlog.Debug(tag, $"ShadowIsEmpty END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Shadow GetPropertyMap.")]
        [Property("SPEC", "Tizen.NUI.Shadow.GetPropertyMap M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ShadowGetPropertyMap()
        {
            tlog.Debug(tag, $"ShadowGetPropertyMap START");

            var testingTarget = new MyShadow();
            Assert.IsNotNull(testingTarget, "Can't create success object Shadow");
            Assert.IsInstanceOf<Shadow>(testingTarget, "Should be an instance of Shadow type.");

            testingTarget.Offset = new Vector2(0.8f, 0.5f);
            testingTarget.Extents = new Vector2(1.2f, 1.3f);

            testingTarget.Color = Color.Cyan;
            testingTarget.BlurRadius = 0.3f;

            try
            {
                testingTarget.OnGetPropertyMap();
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception: Failed!");
            }

            tlog.Debug(tag, $"ShadowGetPropertyMap END (OK)");
        }
    }
}
