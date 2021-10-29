using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Binding;

namespace Tizen.NUI.Components.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("Style/ToastStyle")]
    public class ToastStyleTest
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
        [Description("ToastStyle constructor.")]
        [Property("SPEC", "Tizen.NUI.Components.ToastStyle.ToastStyle C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ToastStyleConstructor()
        {
            tlog.Debug(tag, $"ToastStyleConstructor START");

            var testingTarget = new ToastStyle();
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<ToastStyle>(testingTarget, "Should return ToastStyle instance.");

            tlog.Debug(tag, $"ToastStyleConstructor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ToastStyle constructor.")]
        [Property("SPEC", "Tizen.NUI.Components.ToastStyle.ToastStyle C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ToastStyleConstructorWithToastStyle()
        {
            tlog.Debug(tag, $"ToastStyleConstructorWithToastStyle START");

            ToastStyle style = new ToastStyle();

            var testingTarget = new ToastStyle(style);
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<ToastStyle>(testingTarget, "Should return ToastStyle instance.");

            tlog.Debug(tag, $"ToastStyleConstructorWithToastStyle END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ToastStyle Duration.")]
        [Property("SPEC", "Tizen.NUI.Components.ToastStyle.Duration A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ToastStyleDuration()
        {
            tlog.Debug(tag, $"ToastStyleDuration START");

            var testingTarget = new ToastStyle();
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<ToastStyle>(testingTarget, "Should return ToastStyle instance.");

            testingTarget.Duration = 500;
            tlog.Debug(tag, "Duration :" + testingTarget.Duration);

            tlog.Debug(tag, $"ToastStyleDuration END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ToastStyle Text.")]
        [Property("SPEC", "Tizen.NUI.Components.ToastStyle.Text A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ToastStyleText()
        {
            tlog.Debug(tag, $"ToastStyleText START");

            var testingTarget = new ToastStyle();
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<ToastStyle>(testingTarget, "Should return ToastStyle instance.");

            TextLabelStyle text = new TextLabelStyle()
            {
                Size = new Size(2, 18),
                PointSize = 15.0f
            };

            testingTarget.Text = text;
            tlog.Debug(tag, "Text : " + testingTarget.Text);

            tlog.Debug(tag, $"ToastStyleText END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ToastStyle CopyFrom.")]
        [Property("SPEC", "Tizen.NUI.Components.ToastStyle.CopyFrom M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ToastStyleCopyFrom()
        {
            tlog.Debug(tag, $"ToastStyleCopyFrom START");

            var testingTarget = new ToastStyle();
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<ToastStyle>(testingTarget, "Should return TabStyle instance.");

            ToastStyle style = new ToastStyle()
            {
                Size = new Size(10, 20),
            };

            try
            {
                testingTarget.CopyFrom(style);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            tlog.Debug(tag, $"ToastStyleCopyFrom END (OK)");
        }
    }
}
