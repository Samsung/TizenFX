using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Components.Devel.Tests
{
    using tlog = Tizen.Log;

    class TestDefaultTitleItem : DefaultTitleItem
    {
        public void LayoutTest()
        {
            base.LayoutChild();
        }
    }

    [TestFixture]
    [Description("Controls/RecyclerView/Item/DefaultTitleItem")]
    class TSDefaultTitleItem
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
        [Description("DefaultTitleItem constructor.")]
        [Property("SPEC", "Tizen.NUI.Components.DefaultTitleItem C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "huayong.xu@samsung.com")]
        public void DefaultTitleItemConstructor()
        {
            tlog.Debug(tag, $"DefaultTitleItem START");

            var testingTarget = new DefaultTitleItem();

            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<DefaultTitleItem>(testingTarget, "should be an instance of testing target class!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"DefaultTitleItem END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("DefaultGridItem constructor.")]
        [Property("SPEC", "Tizen.NUI.Components.DefaultGridItem C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "huayong.xu@samsung.com")]
        public void DefaultTitleItemConstructorWithStyle()
        {
            tlog.Debug(tag, $"DefaultTitleItem START");

            var testingTarget = new DefaultTitleItem("Tizen.NUI.Components.DefaultTitleItem");

            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<DefaultTitleItem>(testingTarget, "should be an instance of testing target class!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"DefaultTitleItem END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("DefaultGridItem constructor.")]
        [Property("SPEC", "Tizen.NUI.Components.DefaultGridItem C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "huayong.xu@samsung.com")]
        public void DefaultTitleItemConstructorWithItemStyle()
        {
            tlog.Debug(tag, $"DefaultTitleItem START");

            var style = new DefaultTitleItemStyle()
            {
                SizeHeight = 60,
                Padding = new Extents(64, 64, 12, 12),
                Margin = new Extents(0, 0, 0, 0),
                BackgroundColor = new Selector<Color>()
                {
                    Normal = new Color("#EEEEF1"),
                },
                Label = new TextLabelStyle()
                {
                    PixelSize = 28,
                    Ellipsis = true,
                    TextColor = new Color("#001447"),
                    ThemeChangeSensitive = false
                },
                Icon = new ViewStyle()
                {
                    Margin = new Extents(40, 0, 0, 0)
                },
                Seperator = new ViewStyle()
                {
                    Margin = new Extents(0, 0, 0, 0),
                    BackgroundColor = new Color(0, 0, 0, 0),
                },
            };
            var testingTarget = new DefaultTitleItem(style);

            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<DefaultTitleItem>(testingTarget, "should be an instance of testing target class!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"DefaultTitleItem END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("DefaultTitleItem Icon.")]
        [Property("SPEC", "Tizen.NUI.Components.DefaultTitleItem.Icon A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "huayong.xu@samsung.com")]
        public void DefaultTitleItemIcon()
        {
            tlog.Debug(tag, $"DefaultTitleItem START");

            var testingTarget = new DefaultTitleItem("Tizen.NUI.Components.DefaultTitleItem");

            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<DefaultTitleItem>(testingTarget, "should be an instance of testing target class!");

            testingTarget.Icon = new View()
            {
                Size = new Size(100, 100),
            };
            Assert.IsNotNull(testingTarget.Icon, "should be not null");

            testingTarget.Dispose();
            tlog.Debug(tag, $"DefaultTitleItem END (OK)");
        }

        [Test]
        [Category("P2")]
        [Description("DefaultTitleItem Icon.")]
        [Property("SPEC", "Tizen.NUI.Components.DefaultTitleItem.Icon A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "huayong.xu@samsung.com")]
        public async Task DefaultTitleItemIconNull()
        {
            tlog.Debug(tag, $"DefaultTitleItem START");

            TaskCompletionSource<bool> tcs = new TaskCompletionSource<bool>(false);
            EventHandler onRelayout = (s, e) => { tcs.TrySetResult(true); };

            var testingTarget = new DefaultTitleItem("Tizen.NUI.Components.DefaultTitleItem");
            testingTarget.Relayout += onRelayout;

            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<DefaultTitleItem>(testingTarget, "should be an instance of testing target class!");

            testingTarget.Label = new TextLabel()
            {
                Text = "test",
            };
            Assert.IsNotNull(testingTarget.Label, "should be not null");

            Window.Instance.Add(testingTarget);
            var result = await tcs.Task;
            Assert.IsTrue(result, "Relayout event should be invoked");

            Assert.IsNotNull(testingTarget.Icon, "should be not null");

            if (testingTarget != null)
            {
                Window.Instance.Remove(testingTarget);
                testingTarget.Dispose();
                testingTarget = null;
            }
            tlog.Debug(tag, $"DefaultTitleItem END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("DefaultTitleItem Label.")]
        [Property("SPEC", "Tizen.NUI.Components.DefaultTitleItem.Label A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "huayong.xu@samsung.com")]
        public void DefaultTitleItemLabel()
        {
            tlog.Debug(tag, $"DefaultTitleItem START");

            var testingTarget = new DefaultTitleItem("Tizen.NUI.Components.DefaultTitleItem");

            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<DefaultTitleItem>(testingTarget, "should be an instance of testing target class!");

            testingTarget.Label = new TextLabel()
            {
                Text = "test",
            };
            Assert.IsNotNull(testingTarget.Label, "should be not null");

            testingTarget.Dispose();
            tlog.Debug(tag, $"DefaultTitleItem END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("DefaultTitleItem Text.")]
        [Property("SPEC", "Tizen.NUI.Components.DefaultTitleItem.Text A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "huayong.xu@samsung.com")]
        public void DefaultTitleItemText()
        {
            tlog.Debug(tag, $"DefaultTitleItem START");

            var testingTarget = new DefaultTitleItem("Tizen.NUI.Components.DefaultTitleItem");

            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<DefaultTitleItem>(testingTarget, "should be an instance of testing target class!");

            testingTarget.Text = "test";
            Assert.AreEqual(testingTarget.Text, "test", "should be equal.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"DefaultTitleItem END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("DefaultTitleItem Seperator.")]
        [Property("SPEC", "Tizen.NUI.Components.DefaultTitleItem.Seperator A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "huayong.xu@samsung.com")]
        public void DefaultTitleItemSeperator()
        {
            tlog.Debug(tag, $"DefaultTitleItem START");

            var testingTarget = new DefaultTitleItem("Tizen.NUI.Components.DefaultTitleItem");

            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<DefaultTitleItem>(testingTarget, "should be an instance of testing target class!");

            Assert.IsNotNull(testingTarget.Seperator, "should not be null");

            testingTarget.Dispose();
            tlog.Debug(tag, $"DefaultTitleItem END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("DefaultTitleItem LayoutChild.")]
        [Property("SPEC", "Tizen.NUI.Components.DefaultTitleItem.LayoutChild M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "huayong.xu@samsung.com")]
        public void DefaultTitleItemLayoutChild()
        {
            tlog.Debug(tag, $"DefaultGridItem START");

            var testingTarget = new TestDefaultTitleItem();

            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<DefaultTitleItem>(testingTarget, "should be an instance of testing target class!");

            testingTarget.Icon = new View()
            {
                Size = new Size(100, 100),
            };
            Assert.IsNotNull(testingTarget.Icon, "should be not null");
            testingTarget.Label = new TextLabel()
            {
                WidthSpecification = 170,
                HeightSpecification = 170,
            };
            Assert.IsNotNull(testingTarget.Label, "DefaultTitleItem Label should not be null.");
            testingTarget.LayoutTest();

            testingTarget.Dispose();
            tlog.Debug(tag, $"DefaultGridItem END (OK)");
        }
    }
}
