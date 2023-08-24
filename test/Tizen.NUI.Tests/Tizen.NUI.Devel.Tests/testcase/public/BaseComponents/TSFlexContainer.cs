using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;
using System.Collections.Generic;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("public/BaseComponents/FlexContainer")]
    public class PublicFlexContainerTest
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
        [Description("FlexContainer constructor.")]
        [Property("SPEC", "Tizen.NUI.FlexContainer.FlexContainer C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        [Obsolete]
        public void FlexContainerConstructor()
        {
            tlog.Debug(tag, $"FlexContainerConstructor START");

            var testingTarget = new FlexContainer();
            Assert.IsNotNull(testingTarget, "Can't create success object FlexContainer");
            Assert.IsInstanceOf<FlexContainer>(testingTarget, "Should be an instance of FlexContainer type.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"FlexContainerConstructor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("FlexContainer ContentDirection.")]
        [Property("SPEC", "Tizen.NUI.FlexContainer.ContentDirection A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        [Obsolete]
        public void FlexContainerContentDirection()
        {
            tlog.Debug(tag, $"FlexContainerContentDirection START");

            var testingTarget = new FlexContainer();
            Assert.IsNotNull(testingTarget, "Can't create success object FlexContainer");
            Assert.IsInstanceOf<FlexContainer>(testingTarget, "Should be an instance of FlexContainer type.");

            testingTarget.ContentDirection = FlexContainer.ContentDirectionType.Inherit;
            Assert.AreEqual(FlexContainer.ContentDirectionType.Inherit, testingTarget.ContentDirection, "Should be equal!");

            testingTarget.ContentDirection = FlexContainer.ContentDirectionType.LTR;
            Assert.AreEqual(FlexContainer.ContentDirectionType.LTR, testingTarget.ContentDirection, "Should be equal!");

            testingTarget.ContentDirection = FlexContainer.ContentDirectionType.RTL;
            Assert.AreEqual(FlexContainer.ContentDirectionType.RTL, testingTarget.ContentDirection, "Should be equal!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"FlexContainerContentDirection END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("FlexContainer FlexDirection.")]
        [Property("SPEC", "Tizen.NUI.FlexContainer.FlexDirection A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        [Obsolete]
        public void FlexContainerFlexDirection()
        {
            tlog.Debug(tag, $"FlexContainerFlexDirection START");

            var testingTarget = new FlexContainer();
            Assert.IsNotNull(testingTarget, "Can't create success object FlexContainer");
            Assert.IsInstanceOf<FlexContainer>(testingTarget, "Should be an instance of FlexContainer type.");

            testingTarget.FlexDirection = FlexContainer.FlexDirectionType.Column;
            Assert.AreEqual(FlexContainer.FlexDirectionType.Column, testingTarget.FlexDirection, "Should be equal!");

            testingTarget.FlexDirection = FlexContainer.FlexDirectionType.ColumnReverse;
            Assert.AreEqual(FlexContainer.FlexDirectionType.ColumnReverse, testingTarget.FlexDirection, "Should be equal!");

            testingTarget.FlexDirection = FlexContainer.FlexDirectionType.Row;
            Assert.AreEqual(FlexContainer.FlexDirectionType.Row, testingTarget.FlexDirection, "Should be equal!");

            testingTarget.FlexDirection = FlexContainer.FlexDirectionType.RowReverse;
            Assert.AreEqual(FlexContainer.FlexDirectionType.RowReverse, testingTarget.FlexDirection, "Should be equal!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"FlexContainerFlexDirection END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("FlexContainer FlexWrap.")]
        [Property("SPEC", "Tizen.NUI.FlexContainer.FlexWrap A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        [Obsolete]
        public void FlexContainerFlexWrap()
        {
            tlog.Debug(tag, $"FlexContainerFlexWrap START");

            var testingTarget = new FlexContainer();
            Assert.IsNotNull(testingTarget, "Can't create success object FlexContainer");
            Assert.IsInstanceOf<FlexContainer>(testingTarget, "Should be an instance of FlexContainer type.");

            testingTarget.FlexWrap = FlexContainer.WrapType.NoWrap;
            Assert.AreEqual(FlexContainer.WrapType.NoWrap, testingTarget.FlexWrap, "Should be equal!");

            testingTarget.FlexWrap = FlexContainer.WrapType.Wrap;
            Assert.AreEqual(FlexContainer.WrapType.Wrap, testingTarget.FlexWrap, "Should be equal!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"FlexContainerFlexWrap END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("FlexContainer JustifyContent.")]
        [Property("SPEC", "Tizen.NUI.FlexContainer.JustifyContent A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        [Obsolete]
        public void FlexContainerJustifyContent()
        {
            tlog.Debug(tag, $"FlexContainerJustifyContent START");

            var testingTarget = new FlexContainer();
            Assert.IsNotNull(testingTarget, "Can't create success object FlexContainer");
            Assert.IsInstanceOf<FlexContainer>(testingTarget, "Should be an instance of FlexContainer type.");

            testingTarget.JustifyContent = FlexContainer.Justification.JustifyCenter;
            Assert.AreEqual(FlexContainer.Justification.JustifyCenter, testingTarget.JustifyContent, "Should be equal!");

            testingTarget.JustifyContent = FlexContainer.Justification.JustifyFlexEnd;
            Assert.AreEqual(FlexContainer.Justification.JustifyFlexEnd, testingTarget.JustifyContent, "Should be equal!");

            testingTarget.JustifyContent = FlexContainer.Justification.JustifyFlexStart;
            Assert.AreEqual(FlexContainer.Justification.JustifyFlexStart, testingTarget.JustifyContent, "Should be equal!");

            testingTarget.JustifyContent = FlexContainer.Justification.JustifySpaceAround;
            Assert.AreEqual(FlexContainer.Justification.JustifySpaceAround, testingTarget.JustifyContent, "Should be equal!");

            testingTarget.JustifyContent = FlexContainer.Justification.JustifySpaceBetween;
            Assert.AreEqual(FlexContainer.Justification.JustifySpaceBetween, testingTarget.JustifyContent, "Should be equal!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"FlexContainerJustifyContent END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("FlexContainer AlignItems.")]
        [Property("SPEC", "Tizen.NUI.FlexContainer.AlignItems A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        [Obsolete]
        public void FlexContainerAlignItems()
        {
            tlog.Debug(tag, $"FlexContainerAlignItems START");

            var testingTarget = new FlexContainer();
            Assert.IsNotNull(testingTarget, "Can't create success object FlexContainer");
            Assert.IsInstanceOf<FlexContainer>(testingTarget, "Should be an instance of FlexContainer type.");

            testingTarget.AlignItems = FlexContainer.Alignment.AlignAuto;
            Assert.AreEqual(FlexContainer.Alignment.AlignAuto, testingTarget.AlignItems, "Should be equal!");

            testingTarget.AlignItems = FlexContainer.Alignment.AlignCenter;
            Assert.AreEqual(FlexContainer.Alignment.AlignCenter, testingTarget.AlignItems, "Should be equal!");

            testingTarget.AlignItems = FlexContainer.Alignment.AlignFlexEnd;
            Assert.AreEqual(FlexContainer.Alignment.AlignFlexEnd, testingTarget.AlignItems, "Should be equal!");

            testingTarget.AlignItems = FlexContainer.Alignment.AlignFlexStart;
            Assert.AreEqual(FlexContainer.Alignment.AlignFlexStart, testingTarget.AlignItems, "Should be equal!");

            testingTarget.AlignItems = FlexContainer.Alignment.AlignStretch;
            Assert.AreEqual(FlexContainer.Alignment.AlignStretch, testingTarget.AlignItems, "Should be equal!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"FlexContainerAlignItems END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("FlexContainer AlignContent.")]
        [Property("SPEC", "Tizen.NUI.FlexContainer.AlignContent A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        [Obsolete]
        public void FlexContainerAlignContent()
        {
            tlog.Debug(tag, $"FlexContainerAlignContent START");

            var testingTarget = new FlexContainer();
            Assert.IsNotNull(testingTarget, "Can't create success object FlexContainer");
            Assert.IsInstanceOf<FlexContainer>(testingTarget, "Should be an instance of FlexContainer type.");

            testingTarget.AlignContent = FlexContainer.Alignment.AlignAuto;
            Assert.AreEqual(FlexContainer.Alignment.AlignAuto, testingTarget.AlignContent, "Should be equal!");

            testingTarget.AlignContent = FlexContainer.Alignment.AlignCenter;
            Assert.AreEqual(FlexContainer.Alignment.AlignCenter, testingTarget.AlignContent, "Should be equal!");

            testingTarget.AlignContent = FlexContainer.Alignment.AlignFlexEnd;
            Assert.AreEqual(FlexContainer.Alignment.AlignFlexEnd, testingTarget.AlignContent, "Should be equal!");

            testingTarget.AlignContent = FlexContainer.Alignment.AlignFlexStart;
            Assert.AreEqual(FlexContainer.Alignment.AlignFlexStart, testingTarget.AlignContent, "Should be equal!");

            testingTarget.AlignContent = FlexContainer.Alignment.AlignStretch;
            Assert.AreEqual(FlexContainer.Alignment.AlignStretch, testingTarget.AlignContent, "Should be equal!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"FlexContainerAlignContent END (OK)");
        }
    }
}
