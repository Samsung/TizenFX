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
    [Description("public/ViewProperty/ShadowBase.cs")]
    public class PublicShadowBaseTest
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
        [Description("ShadowBase ToPropertyValue.")]
        [Property("SPEC", "Tizen.NUI.ShadowBase.ToPropertyValue M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ShadowBaseToPropertyValue()
        {
            tlog.Debug(tag, $"ShadowBaseToPropertyValue START");

            var testingTarget = new MyShadow();
            Assert.IsNotNull(testingTarget, "Can't create success object Shadow");
            Assert.IsInstanceOf<Shadow>(testingTarget, "Should be an instance of Shadow type.");

            using (View view = new View())
            {
                view.CornerRadius = new Vector4(0.1f, 0.9f, 0.7f, 0.0f);

                var result = testingTarget.ToPropertyValue(view);
                Assert.IsNotNull(result, "Can't create success object PropertyValue");
                Assert.IsInstanceOf<PropertyValue>(result, "Should be an instance of PropertyValue type.");
            }

            tlog.Debug(tag, $"ShadowBaseToPropertyValue END (OK)");
        }
    }
}
