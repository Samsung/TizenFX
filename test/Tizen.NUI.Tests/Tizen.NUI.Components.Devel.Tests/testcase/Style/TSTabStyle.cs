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
    [Description("Style/TabStyle")]
    public class TabStyleTest
    {
        private const string tag = "NUITEST";

        internal class MyTabStyle : TabStyle
        {
            public MyTabStyle() : base()
            { }

            public override void CopyFrom(BindableObject bindableObject)
            {
                base.CopyFrom(bindableObject);
            }
        }

        internal class MyBindableObject : BindableObject
        { }

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
        [Description("TabStyle constructor.")]
        [Property("SPEC", "Tizen.NUI.Components.TabStyle.TabStyle C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TabStyleConstructor()
        {
            tlog.Debug(tag, $"TabStyleConstructor START");

            var testingTarget = new TabStyle();
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<TabStyle>(testingTarget, "Should return TabStyle instance.");

            tlog.Debug(tag, $"TabStyleConstructor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TabStyle constructor.")]
        [Property("SPEC", "Tizen.NUI.Components.TabStyle.TabStyle C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TabStyleConstructorWithTabStyle()
        {
            tlog.Debug(tag, $"TabStyleConstructorWithTabStyle START");

            TabStyle style = new TabStyle();

            var testingTarget = new TabStyle(style);
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<TabStyle>(testingTarget, "Should return TabStyle instance.");

            tlog.Debug(tag, $"ScrollBarStyleConstructorWithScrollBarStyle END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TabStyle UnderLine.")]
        [Property("SPEC", "Tizen.NUI.Components.TabStyle.UnderLine A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TabStyleUnderLine()
        {
            tlog.Debug(tag, $"TabStyleUnderLine START");

            var testingTarget = new TabStyle();
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<TabStyle>(testingTarget, "Should return TabStyle instance.");

            ViewStyle underline = new ViewStyle()
            { 
                Size = new Size(2, 18),
            };

            testingTarget.UnderLine = underline;
            tlog.Debug(tag, "UnderLine : " + testingTarget.UnderLine);

            tlog.Debug(tag, $"TabStyleUnderLine END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TabStyle Text.")]
        [Property("SPEC", "Tizen.NUI.Components.TabStyle.Text A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TabStyleText()
        {
            tlog.Debug(tag, $"TabStyleText START");

            var testingTarget = new TabStyle();
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<TabStyle>(testingTarget, "Should return TabStyle instance.");

            TextLabelStyle text = new TextLabelStyle()
            {
                Size = new Size(2, 18),
                PointSize = 15.0f
            };

            testingTarget.Text = text;
            tlog.Debug(tag, "Text : " + testingTarget.Text);

            tlog.Debug(tag, $"TabStyleText END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TabStyle UseTextNaturalSize.")]
        [Property("SPEC", "Tizen.NUI.Components.TabStyle.UseTextNaturalSize A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TabStyleUseTextNaturalSize()
        {
            tlog.Debug(tag, $"TabStyleUseTextNaturalSize START");

            var testingTarget = new TabStyle();
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<TabStyle>(testingTarget, "Should return TabStyle instance.");

            testingTarget.UseTextNaturalSize = true;
            tlog.Debug(tag, "UseTextNaturalSize : " + testingTarget.UseTextNaturalSize);

            testingTarget.UseTextNaturalSize = false;
            tlog.Debug(tag, "UseTextNaturalSize : " + testingTarget.UseTextNaturalSize);

            tlog.Debug(tag, $"TabStyleUseTextNaturalSize END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TabStyle ItemSpace.")]
        [Property("SPEC", "Tizen.NUI.Components.TabStyle.ItemSpace A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TabStyleItemSpace()
        {
            tlog.Debug(tag, $"TabStyleItemSpace START");

            var testingTarget = new TabStyle();
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<TabStyle>(testingTarget, "Should return TabStyle instance.");

            testingTarget.ItemSpace = 5;
            tlog.Debug(tag, "ItemSpace : " + testingTarget.ItemSpace);

            tlog.Debug(tag, $"TabStyleItemSpace END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TabStyle ItemPadding.")]
        [Property("SPEC", "Tizen.NUI.Components.TabStyle.ItemPadding A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TabStyleItemPadding()
        {
            tlog.Debug(tag, $"TabStyleItemPadding START");

            var testingTarget = new TabStyle();
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<TabStyle>(testingTarget, "Should return TabStyle instance.");

            testingTarget.ItemPadding = new Extents(4, 4, 4, 4);
            tlog.Debug(tag, "ItemPadding : " + testingTarget.ItemPadding);

            tlog.Debug(tag, $"TabStyleItemPadding END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TabStyle CopyFrom.")]
        [Property("SPEC", "Tizen.NUI.Components.TabStyle.CopyFrom M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TabStyleCopyFrom()
        {
            tlog.Debug(tag, $"TabStyleCopyFrom START");

            var testingTarget = new MyTabStyle();
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<TabStyle>(testingTarget, "Should return TabStyle instance.");

            TabStyle style = new TabStyle()
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

            tlog.Debug(tag, $"TabStyleCopyFrom END (OK)");
        }
    }
}
