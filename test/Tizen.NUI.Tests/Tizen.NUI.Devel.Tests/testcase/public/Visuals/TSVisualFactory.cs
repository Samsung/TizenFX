using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("public/Visuals/VisualFactory")]
    public class PublicVisualFactoryTest
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
        [Description("VisualFactory constructor.")]
        [Property("SPEC", "Tizen.NUI.VisualFactory.VisualFactory C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void VisualFactoryConstructor()
        {
            tlog.Debug(tag, $"VisualFactoryConstructor START");

            var testingTarget = new VisualFactory();
            Assert.IsInstanceOf<VisualFactory>(testingTarget, "CreateVisual Should return VisualFactory instance.");

            testingTarget?.Dispose();
            tlog.Debug(tag, $"VisualFactoryConstructor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("VisualFactory CreateVisual.")]
        [Property("SPEC", "Tizen.NUI.VisualFactory.CreateVisual M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void VisualFactoryCreateVisual()
        {
            tlog.Debug(tag, $"VisualFactoryCreateVisual START");

            VisualFactory visualfactory = VisualFactory.Instance;

            using (PropertyMap propertyMap = new PropertyMap())
            {
                propertyMap.Insert(Visual.Property.Type, new PropertyValue((int)Visual.Type.Text));
                propertyMap.Insert(TextVisualProperty.Text, new PropertyValue("Hello Goodbye"));

                var testingTarget = visualfactory.CreateVisual(propertyMap);
                Assert.IsNotNull(testingTarget, "Can't create success object VisualBase");
                Assert.IsInstanceOf<VisualBase>(testingTarget, "CreateVisual Should return VisualBase instance.");

                testingTarget.Dispose();
            }

            visualfactory.Dispose();
            tlog.Debug(tag, $"VisualFactoryCreateVisual END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("VisualFactory Instance.")]
        [Property("SPEC", "Tizen.NUI.VisualFactory.Instance A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void VisualFactoryInstance()
        {
            tlog.Debug(tag, $"VisualFactoryInstance START");

            var testingTarget = VisualFactory.Instance;
            Assert.IsNotNull(testingTarget, "Can't create success object VisualFactory");
            Assert.IsInstanceOf<VisualFactory>(testingTarget, "Should return VisualFactory instance.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"VisualFactoryInstance END (OK)");
        }
    }
}
