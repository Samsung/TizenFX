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
    [Description("public/Common/NUIConstants")]
    public class PublicNUIConstantsTest
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
        [Description("NUIConstants .")]
        [Property("SPEC", "Tizen.NUI.Public.NUIConstants C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void publicCommonNUIConstantsStructs()
        {
            tlog.Debug(tag, $"publicCommonNUIConstantsStructs START");

            Assert.IsNotNull(Tizen.NUI.PivotPoint.Top, "PivotPoint.Top Should not be null");
            Assert.IsNotNull(Tizen.NUI.PivotPoint.Bottom, "PivotPoint.Bottom Should not be null");
            Assert.IsNotNull(Tizen.NUI.PivotPoint.Left, "PivotPoint.Left Should not be null");
            Assert.IsNotNull(Tizen.NUI.PivotPoint.Right, "PivotPoint.Right Should not be null");
            Assert.IsNotNull(Tizen.NUI.PivotPoint.Middle, "PivotPoint.Middle Should not be null");
            Assert.IsNotNull(Tizen.NUI.PivotPoint.TopRight, "PivotPoint.TopRight Should not be null");
            Assert.IsNotNull(Tizen.NUI.PivotPoint.BottomLeft, "PivotPoint.BottomLeft Should not be null");
            Assert.IsNotNull(Tizen.NUI.PivotPoint.BottomCenter, "PivotPoint.BottomLeft Should not be null");
            Assert.IsNotNull(Tizen.NUI.PivotPoint.BottomRight, "PivotPoint.BottomRight Should not be null");

            Assert.IsNotNull(Tizen.NUI.PositionAxis.X, "PositionAxis.X Should not be null");
            Assert.IsNotNull(Tizen.NUI.PositionAxis.Y, "PositionAxis.Y Should not be null");
            Assert.IsNotNull(Tizen.NUI.PositionAxis.Z, "PositionAxis.Z Should not be null");
            Assert.IsNotNull(Tizen.NUI.PositionAxis.NegativeX, "PositionAxis.NegativeX Should not be null");
            Assert.IsNotNull(Tizen.NUI.PositionAxis.NegativeY, "PositionAxis.NegativeY Should not be null");
            Assert.IsNotNull(Tizen.NUI.PositionAxis.NegativeZ, "PositionAxis.NegativeZ Should not be null");

#pragma warning disable CS0618 // Type or member is obsolete
            Assert.IsNotNull(Tizen.NUI.AnchorPoint.Top, "AnchorPoint.Top Should not be null");
#pragma warning restore CS0618 // Type or member is obsolete
#pragma warning disable CS0618 // Type or member is obsolete
            Assert.IsNotNull(Tizen.NUI.AnchorPoint.Bottom, "AnchorPoint.Bottom Should not be null");
#pragma warning restore CS0618 // Type or member is obsolete
#pragma warning disable CS0618 // Type or member is obsolete
            Assert.IsNotNull(Tizen.NUI.AnchorPoint.Left, "AnchorPoint.Left Should not be null");
#pragma warning restore CS0618 // Type or member is obsolete
#pragma warning disable CS0618 // Type or member is obsolete
            Assert.IsNotNull(Tizen.NUI.AnchorPoint.Right, "AnchorPoint.Right Should not be null");
#pragma warning restore CS0618 // Type or member is obsolete
#pragma warning disable CS0618 // Type or member is obsolete
            Assert.IsNotNull(Tizen.NUI.AnchorPoint.Middle, "AnchorPoint.Middle Should not be null");
#pragma warning restore CS0618 // Type or member is obsolete
#pragma warning disable CS0618 // Type or member is obsolete
            Assert.IsNotNull(Tizen.NUI.AnchorPoint.TopLeft, "AnchorPoint.TopLeft Should not be null");
#pragma warning restore CS0618 // Type or member is obsolete
#pragma warning disable CS0618 // Type or member is obsolete
            Assert.IsNotNull(Tizen.NUI.AnchorPoint.TopLeft, "AnchorPoint.TopLeft Should not be null");
#pragma warning restore CS0618 // Type or member is obsolete
#pragma warning disable CS0618 // Type or member is obsolete
            Assert.IsNotNull(Tizen.NUI.AnchorPoint.TopCenter, "AnchorPoint.TopCenter Should not be null");
#pragma warning restore CS0618 // Type or member is obsolete
#pragma warning disable CS0618 // Type or member is obsolete
            Assert.IsNotNull(Tizen.NUI.AnchorPoint.TopRight, "AnchorPoint.TopRight Should not be null");
#pragma warning restore CS0618 // Type or member is obsolete
#pragma warning disable CS0618 // Type or member is obsolete
            Assert.IsNotNull(Tizen.NUI.AnchorPoint.CenterLeft, "AnchorPoint.CenterLeft Should not be null");
#pragma warning restore CS0618 // Type or member is obsolete
#pragma warning disable CS0618 // Type or member is obsolete
            Assert.IsNotNull(Tizen.NUI.AnchorPoint.Center, "AnchorPoint.Center Should not be null");
#pragma warning restore CS0618 // Type or member is obsolete
#pragma warning disable CS0618 // Type or member is obsolete
            Assert.IsNotNull(Tizen.NUI.AnchorPoint.CenterRight, "AnchorPoint.CenterRight Should not be null");
#pragma warning restore CS0618 // Type or member is obsolete
#pragma warning disable CS0618 // Type or member is obsolete
            Assert.IsNotNull(Tizen.NUI.AnchorPoint.BottomLeft, "AnchorPoint.BottomLeft Should not be null");
#pragma warning restore CS0618 // Type or member is obsolete
#pragma warning disable CS0618 // Type or member is obsolete
            Assert.IsNotNull(Tizen.NUI.AnchorPoint.BottomCenter, "AnchorPoint.BottomCenter Should not be null");
#pragma warning restore CS0618 // Type or member is obsolete
#pragma warning disable CS0618 // Type or member is obsolete
            Assert.IsNotNull(Tizen.NUI.AnchorPoint.BottomRight, "AnchorPoint.BottomRight Should not be null");
#pragma warning restore CS0618 // Type or member is obsolete

            Assert.IsNotNull(Tizen.NUI.SlideTransitionDirection.Top, "SlideTransitionDirection.Top Should not be null");
            Assert.IsNotNull(Tizen.NUI.SlideTransitionDirection.Bottom, "SlideTransitionDirection.Bottom Should not be null");
            Assert.IsNotNull(Tizen.NUI.SlideTransitionDirection.Left, "SlideTransitionDirection.Left Should not be null");

            tlog.Debug(tag, $"publicCommonNUIConstantsStructs END (OK)");
        }
    }
}
