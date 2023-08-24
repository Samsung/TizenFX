using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Components.Devel.Tests
{
    using static Tizen.NUI.Components.Tab;
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("Controls/Tab")]
    public class TabTest
    {
        private const string tag = "NUITEST";

        [Obsolete]
        internal class MyTab : Tab
        {
            public MyTab() : base()
            { }

            public void MyOnUpdate()
            {
                base.OnUpdate();
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
        [Description("Tab contructor.")]
        [Property("SPEC", "Tizen.NUI.Components.Tab.Tab C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        [Obsolete]
        public void TabContructor()
        {
            tlog.Debug(tag, $"TabContructor START");

            var testingTarget = new Tab();
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<Tab>(testingTarget, "Should return Tab instance.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"TabContructor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Tab contructor.")]
        [Property("SPEC", "Tizen.NUI.Components.Tab.Tab C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        [Obsolete]
        public void TabContructorWithTabStyle()
        {
            tlog.Debug(tag, $"TabContructorWithTabStyle START");

            TabStyle style = new TabStyle()
            { 
                Size = new Size(100, 200),
            };

            var testingTarget = new Tab(style);
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<Tab>(testingTarget, "Should return Tab instance.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"TabContructorWithTabStyle END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Tab Underline.")]
        [Property("SPEC", "Tizen.NUI.Components.Tab.Underline A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        [Obsolete]
        public void TabUnderline()
        {
            tlog.Debug(tag, $"TabUnderline START");

            using (View view = new View() { Size = new Size(2, 20) })
            {
                var testingTarget = new Tab();
                Assert.IsNotNull(testingTarget, "null handle");
                Assert.IsInstanceOf<Tab>(testingTarget, "Should return Tab instance.");

                testingTarget.Underline = view;
                tlog.Debug(tag, "Underline : " + testingTarget.Underline);

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"TabUnderline END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Tab SelectedItemIndex.")]
        [Property("SPEC", "Tizen.NUI.Components.Tab.SelectedItemIndex A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        [Obsolete]
        public void TabSelectedItemIndex()
        {
            tlog.Debug(tag, $"TabSelectedItemIndex START");

            var testingTarget = new Tab();
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<Tab>(testingTarget, "Should return Tab instance.");

            testingTarget.SelectedItemIndex = 1;
            tlog.Debug(tag, "SelectedItemIndex : " + testingTarget.SelectedItemIndex);

            testingTarget.Dispose();
            tlog.Debug(tag, $"TabSelectedItemIndex END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Tab UseTextNaturalSize.")]
        [Property("SPEC", "Tizen.NUI.Components.Tab.UseTextNaturalSize A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        [Obsolete]
        public void TabUseTextNaturalSize()
        {
            tlog.Debug(tag, $"TabUseTextNaturalSize START");

            var testingTarget = new Tab();
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<Tab>(testingTarget, "Should return Tab instance.");

            testingTarget.UseTextNaturalSize = true;
            tlog.Debug(tag, "UseTextNaturalSize : " + testingTarget.UseTextNaturalSize);

            testingTarget.UseTextNaturalSize = false;
            tlog.Debug(tag, "UseTextNaturalSize : " + testingTarget.UseTextNaturalSize);

            testingTarget.Dispose();
            tlog.Debug(tag, $"TabUseTextNaturalSize END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Tab ItemSpace.")]
        [Property("SPEC", "Tizen.NUI.Components.Tab.ItemSpace A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        [Obsolete]
        public void TabItemSpace()
        {
            tlog.Debug(tag, $"TabItemSpace START");

            var testingTarget = new Tab();
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<Tab>(testingTarget, "Should return Tab instance.");

            testingTarget.ItemSpace = 10;
            tlog.Debug(tag, "ItemSpace : " + testingTarget.ItemSpace);

            testingTarget.Dispose();
            tlog.Debug(tag, $"TabItemSpace END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Tab Space.")]
        [Property("SPEC", "Tizen.NUI.Components.Tab.Space A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        [Obsolete]
        public void TabSpace()
        {
            tlog.Debug(tag, $"TabSpace START");

            var testingTarget = new Tab();
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<Tab>(testingTarget, "Should return Tab instance.");

            testingTarget.Space = new Extents(4, 4, 4, 4);
            tlog.Debug(tag, "Space : " + testingTarget.Space);

            testingTarget.Dispose();
            tlog.Debug(tag, $"TabSpace END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Tab ItemPadding.")]
        [Property("SPEC", "Tizen.NUI.Components.Tab.ItemPadding A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        [Obsolete]
        public void TabItemPadding()
        {
            tlog.Debug(tag, $"TabItemPadding START");

            var testingTarget = new Tab();
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<Tab>(testingTarget, "Should return Tab instance.");

            testingTarget.ItemPadding = new Extents(4, 4, 4, 4);
            tlog.Debug(tag, "ItemPadding : " + testingTarget.ItemPadding);

            testingTarget.Dispose();
            tlog.Debug(tag, $"TabItemPadding END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Tab UnderLineSize.")]
        [Property("SPEC", "Tizen.NUI.Components.Tab.UnderLineSize A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        [Obsolete]
        public void TabUnderLineSize()
        {
            tlog.Debug(tag, $"TabUnderLineSize START");

            var testingTarget = new Tab();
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<Tab>(testingTarget, "Should return Tab instance.");

            testingTarget.UnderLineSize = new Size(10, 20);
            tlog.Debug(tag, "UnderLineSize : " + testingTarget.UnderLineSize);

            testingTarget.Dispose();
            tlog.Debug(tag, $"TabUnderLineSize END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Tab UnderLineBackgroundColor.")]
        [Property("SPEC", "Tizen.NUI.Components.Tab.UnderLineBackgroundColor A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        [Obsolete]
        public void TabUnderLineBackgroundColor()
        {
            tlog.Debug(tag, $"TabUnderLineBackgroundColor START");

            var testingTarget = new Tab();
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<Tab>(testingTarget, "Should return Tab instance.");

            testingTarget.UnderLineBackgroundColor = Color.Red;
            tlog.Debug(tag, "UnderLineBackgroundColor : " + testingTarget.UnderLineBackgroundColor);

            testingTarget.Dispose();
            tlog.Debug(tag, $"TabUnderLineBackgroundColor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Tab PointSize.")]
        [Property("SPEC", "Tizen.NUI.Components.Tab.PointSize A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        [Obsolete]
        public void TabPointSize()
        {
            tlog.Debug(tag, $"TabPointSize START");

            var testingTarget = new Tab();
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<Tab>(testingTarget, "Should return Tab instance.");

            testingTarget.PointSize = 0.3f;
            tlog.Debug(tag, "PointSize : " + testingTarget.PointSize);

            testingTarget.Dispose();
            tlog.Debug(tag, $"TabPointSize END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Tab FontFamily.")]
        [Property("SPEC", "Tizen.NUI.Components.Tab.FontFamily A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        [Obsolete]
        public void TabFontFamily()
        {
            tlog.Debug(tag, $"TabFontFamily START");

            var testingTarget = new Tab();
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<Tab>(testingTarget, "Should return Tab instance.");

            testingTarget.FontFamily = "BreezeSans";
            tlog.Debug(tag, "FontFamily : " + testingTarget.FontFamily);

            testingTarget.Dispose();
            tlog.Debug(tag, $"TabFontFamily END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Tab TextColor.")]
        [Property("SPEC", "Tizen.NUI.Components.Tab.TextColor A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        [Obsolete]
        public void TabTextColor()
        {
            tlog.Debug(tag, $"TabTextColor START");

            var testingTarget = new Tab();
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<Tab>(testingTarget, "Should return Tab instance.");

            testingTarget.TextColor = Color.Green;
            tlog.Debug(tag, "TextColor : " + testingTarget.TextColor);

            testingTarget.Dispose();
            tlog.Debug(tag, $"TabTextColor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Tab TextColorSelector.")]
        [Property("SPEC", "Tizen.NUI.Components.Tab.TextColorSelector A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        [Obsolete]
        public void TabTextColorSelector()
        {
            tlog.Debug(tag, $"TabTextColorSelector START");

            var testingTarget = new Tab();
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<Tab>(testingTarget, "Should return Tab instance.");

            var textColorSelector = new ColorSelector();
            textColorSelector.Add(ControlState.All, Color.Cyan);
            testingTarget.TextColorSelector = textColorSelector;
            tlog.Debug(tag, "TextColorSelector : " + testingTarget.TextColorSelector);

            testingTarget.Dispose();
            tlog.Debug(tag, $"TabTextColorSelector END (OK)");
        }

        [Test]
        [Category("P2")]
        [Description("Tab TextColorSelector.")]
        [Property("SPEC", "Tizen.NUI.Components.Tab.TextColorSelector A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        [Obsolete]
        public void TabTextColorSelectorNullReferenceException()
        {
            tlog.Debug(tag, $"TabTextColorSelectorNullReferenceException START");

            var testingTarget = new Tab();
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<Tab>(testingTarget, "Should return Tab instance.");

            try
            {
                ColorSelector textColorSelector = null;
                testingTarget.TextColorSelector = textColorSelector;
            }
            catch (NullReferenceException)
            {
                testingTarget.Dispose();
                tlog.Debug(tag, $"TabTextColorSelectorNullReferenceException END (OK)");
                Assert.Pass("Caught NullReferenceException :  Passed!");
            }
        }

        [Test]
        [Category("P1")]
        [Description("Tab AddItem.")]
        [Property("SPEC", "Tizen.NUI.Components.Tab.AddItem M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        [Obsolete]
        public void TabAddItem()
        {
            tlog.Debug(tag, $"TabAddItem START");

            var testingTarget = new Tab();
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<Tab>(testingTarget, "Should return Tab instance.");

            try
            {
                TabItemData item1 = new TabItemData();
                testingTarget.AddItem(item1);
                TabItemData item2 = new TabItemData();
                testingTarget.InsertItem(item2, 1);

                testingTarget.SelectedItemIndex = 1;

                try
                {
                    testingTarget.DeleteItem(0);
                }
                catch (Exception e)
                {
                    tlog.Debug(tag, e.Message.ToString());
                    Assert.Fail("Caught Exception : Failed!");
                }
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }
            
            testingTarget.Dispose();
            tlog.Debug(tag, $"TabAddItem END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Tab Style.")]
        [Property("SPEC", "Tizen.NUI.Components.Tab.Style M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        [Obsolete]
        public void TabStyle()
        {
            tlog.Debug(tag, $"TabStyle START");

            var testingTarget = new Tab();
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<Tab>(testingTarget, "Should return Tab instance.");

            var result = testingTarget.Style;
            tlog.Debug(tag, "Style : " + result);

            testingTarget.Dispose();
            tlog.Debug(tag, $"TabStyle END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Tab OnUpdate.")]
        [Property("SPEC", "Tizen.NUI.Components.Tab.OnUpdate M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        [Obsolete]
        public void TabOnUpdate()
        {
            tlog.Debug(tag, $"TabOnUpdate START");

            var testingTarget = new MyTab()
            {
                LayoutDirection = ViewLayoutDirectionType.RTL,
                UseTextNaturalSize = true,
            };
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<Tab>(testingTarget, "Should return Tab instance.");

            try
            {
                testingTarget.MyOnUpdate();
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"TabOnUpdate END (OK)");
        }
    }
}
