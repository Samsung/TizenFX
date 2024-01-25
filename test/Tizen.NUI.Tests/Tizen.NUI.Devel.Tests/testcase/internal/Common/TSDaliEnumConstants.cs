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
        [Description("DaliEnumConstants Property.")]
        [Property("SPEC", "Tizen.NUI.DaliEnumConstants.Property A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void DaliEnumConstantsProperty()
        {
            tlog.Debug(tag, $"DaliEnumConstantsProperty START");

            var Content = Tizen.NUI.Constants.Tooltip.Property.Content;
            tlog.Debug(tag, "Content  : " + Content);

            var Layout = Tizen.NUI.Constants.Tooltip.Property.Layout;
            tlog.Debug(tag, "Layout  : " + Layout);

            var WaitTime = Tizen.NUI.Constants.Tooltip.Property.WaitTime;
            tlog.Debug(tag, "WaitTime   : " + WaitTime);

            var Background = Tizen.NUI.Constants.Tooltip.Property.Background;
            tlog.Debug(tag, "Background   : " + Background);

            var Tail = Tizen.NUI.Constants.Tooltip.Property.Tail;
            tlog.Debug(tag, "Tail    : " + Tail);

            var Position = Tizen.NUI.Constants.Tooltip.Property.Position;
            tlog.Debug(tag, "Position    : " + Position);

            var HoverPointOffset = Tizen.NUI.Constants.Tooltip.Property.HoverPointOffset;
            tlog.Debug(tag, "HoverPointOffset     : " + HoverPointOffset);

            var MovementThreshold = Tizen.NUI.Constants.Tooltip.Property.MovementThreshold;
            tlog.Debug(tag, "MovementThreshold : " + MovementThreshold);

            var DisappearOnMovement = Tizen.NUI.Constants.Tooltip.Property.DisappearOnMovement;
            tlog.Debug(tag, "DisappearOnMovement  : " + DisappearOnMovement);

            tlog.Debug(tag, $"DaliEnumConstantsBackgroundProperty END (OK)");
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
