using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("internal/Common/DaliEnumConstants")]
    public class InternalDaliEnumConstantsTest
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
        [Description("DaliEnumConstants BackgroundProperty.")]
        [Property("SPEC", "Tizen.NUI.DaliEnumConstants.BackgroundProperty A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void DaliEnumConstantsBackgroundProperty()
        {
            tlog.Debug(tag, $"DaliEnumConstantsBackgroundProperty START");

            var visual = Tizen.NUI.Constants.Tooltip.BackgroundProperty.Visual;
            tlog.Debug(tag, "Visual : " + visual);

            var border = Tizen.NUI.Constants.Tooltip.BackgroundProperty.Border;
            tlog.Debug(tag, "Border : " + border);

            tlog.Debug(tag, $"DaliEnumConstantsBackgroundProperty END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("DaliEnumConstants TailProperty.")]
        [Property("SPEC", "Tizen.NUI.DaliEnumConstants.TailProperty A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void DaliEnumConstantsTailProperty()
        {
            tlog.Debug(tag, $"DaliEnumConstantsTailProperty START");

            var result = Tizen.NUI.Constants.Tooltip.TailProperty.Visibility;
            tlog.Debug(tag, "Visibility : " + result);

            result = Tizen.NUI.Constants.Tooltip.TailProperty.AboveVisual;
            tlog.Debug(tag, "AboveVisual : " + result);

            result = Tizen.NUI.Constants.Tooltip.TailProperty.BelowVisual;
            tlog.Debug(tag, "BelowVisual : " + result);

            tlog.Debug(tag, $"DaliEnumConstantsTailProperty END (OK)");
        }
    }
}
