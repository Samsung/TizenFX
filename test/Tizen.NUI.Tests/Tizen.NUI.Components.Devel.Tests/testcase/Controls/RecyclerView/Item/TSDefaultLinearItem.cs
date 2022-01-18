using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Components.Devel.Tests
{
    using tlog = Tizen.Log;

    class TestDefaultLinearItem : DefaultLinearItem
    {
        public void LayoutTest()
        {
            base.LayoutChild();
        }
    }

    [TestFixture]
    [Description("Controls/RecyclerView/Item/DefaultLinearItem")]
    class TSDefaultLinearItem
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
        [Description("DefaultLinearItem constructor.")]
        [Property("SPEC", "Tizen.NUI.Components.DefaultLinearItem C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "huayong.xu@samsung.com")]
        public void DefaultLinearItemConstructor()
        {
            tlog.Debug(tag, $"DefaultGridItem START");

            var testingTarget = new DefaultLinearItem();

            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<DefaultLinearItem>(testingTarget, "should be an instance of testing target class!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"DefaultGridItem END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("DefaultLinearItem constructor.")]
        [Property("SPEC", "Tizen.NUI.Components.DefaultLinearItem C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "huayong.xu@samsung.com")]
        public void DefaultLinearItemConstructorWithStyle()
        {
            tlog.Debug(tag, $"DefaultLinearItem START");

            var testingTarget = new DefaultLinearItem("Tizen.NUI.Components.DefaultLinearItem");

            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<DefaultLinearItem>(testingTarget, "should be an instance of testing target class!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"DefaultLinearItem END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("DefaultLinearItem constructor.")]
        [Property("SPEC", "Tizen.NUI.Components.DefaultLinearItem C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "huayong.xu@samsung.com")]
        public void DefaultLinearItemConstructorWithItemStyle()
        {
            tlog.Debug(tag, $"DefaultLinearItem START");

            var style = new DefaultLinearItemStyle()
            {
                SizeHeight = 108,
                Padding = new Extents(64, 64, 18, 17),
                Margin = new Extents(0, 0, 0, 0),
                Icon = new ViewStyle()
                {
                    Margin = new Extents(0, 32, 0, 0)
                },
            };
            var testingTarget = new DefaultLinearItem(style);

            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<DefaultLinearItem>(testingTarget, "should be an instance of testing target class!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"DefaultLinearItem END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("DefaultLinearItem Icon.")]
        [Property("SPEC", "Tizen.NUI.Components.DefaultLinearItem.Icon A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "huayong.xu@samsung.com")]
        public void DefaultLinearItemIcon()
        {
            tlog.Debug(tag, $"DefaultLinearItem START");

            var testingTarget = new DefaultLinearItem("Tizen.NUI.Components.DefaultLinearItem");

            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<DefaultLinearItem>(testingTarget, "should be an instance of testing target class!");

            testingTarget.Icon = new View()
            {
                Size = new Size(100, 100),
            };
            Assert.IsNotNull(testingTarget.Icon, "should be not null");

            testingTarget.Dispose();
            tlog.Debug(tag, $"DefaultLinearItem END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("DefaultLinearItem Label.")]
        [Property("SPEC", "Tizen.NUI.Components.DefaultLinearItem.Label A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "huayong.xu@samsung.com")]
        public void DefaultLinearItemLabel()
        {
            tlog.Debug(tag, $"DefaultLinearItem START");

            var testingTarget = new DefaultLinearItem("Tizen.NUI.Components.DefaultLinearItem");

            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<DefaultLinearItem>(testingTarget, "should be an instance of testing target class!");

            testingTarget.Label = new TextLabel()
            {
                Text = "test",
            };
            Assert.IsNotNull(testingTarget.Label, "should be not null");

            testingTarget.Dispose();
            tlog.Debug(tag, $"DefaultLinearItem END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("DefaultLinearItem Text.")]
        [Property("SPEC", "Tizen.NUI.Components.DefaultLinearItem.Text A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "huayong.xu@samsung.com")]
        public void DefaultLinearItemText()
        {
            tlog.Debug(tag, $"DefaultLinearItem START");

            var testingTarget = new DefaultLinearItem("Tizen.NUI.Components.DefaultLinearItem");

            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<DefaultLinearItem>(testingTarget, "should be an instance of testing target class!");

            testingTarget.Text = "test";
            Assert.AreEqual(testingTarget.Text, "test", "should be equal.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"DefaultLinearItem END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("DefaultLinearItem SubLabel.")]
        [Property("SPEC", "Tizen.NUI.Components.DefaultLinearItem.SubLabel A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "huayong.xu@samsung.com")]
        public void DefaultLinearItemSubLabel()
        {
            tlog.Debug(tag, $"DefaultLinearItem START");

            var testingTarget = new DefaultLinearItem("Tizen.NUI.Components.DefaultLinearItem");

            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<DefaultLinearItem>(testingTarget, "should be an instance of testing target class!");

            testingTarget.SubLabel = new TextLabel()
            {
                Text = "test",
            };
            Assert.IsNotNull(testingTarget.SubLabel, "should be not null");

            testingTarget.Dispose();
            tlog.Debug(tag, $"DefaultLinearItem END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("DefaultLinearItem SubText.")]
        [Property("SPEC", "Tizen.NUI.Components.DefaultLinearItem.SubText A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "huayong.xu@samsung.com")]
        public void DefaultLinearSubText()
        {
            tlog.Debug(tag, $"DefaultLinearItem START");

            var testingTarget = new DefaultLinearItem("Tizen.NUI.Components.DefaultLinearItem");

            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<DefaultLinearItem>(testingTarget, "should be an instance of testing target class!");

            testingTarget.SubText = "test";
            Assert.AreEqual(testingTarget.SubText, "test", "should be equal.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"DefaultLinearItem END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("DefaultLinearItem Extra.")]
        [Property("SPEC", "Tizen.NUI.Components.DefaultLinearItem.Extra A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "huayong.xu@samsung.com")]
        public void DefaultLinearItemExtra()
        {
            tlog.Debug(tag, $"DefaultLinearItem START");

            var testingTarget = new DefaultLinearItem("Tizen.NUI.Components.DefaultLinearItem");

            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<DefaultLinearItem>(testingTarget, "should be an instance of testing target class!");

            testingTarget.Extra = new View()
            {
                Size = new Size(100, 100),
            };
            Assert.IsNotNull(testingTarget.Extra, "should be not null");

            testingTarget.Dispose();
            tlog.Debug(tag, $"DefaultLinearItem END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("DefaultLinearItem Extra.")]
        [Property("SPEC", "Tizen.NUI.Components.DefaultLinearItem.Extra A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "huayong.xu@samsung.com")]
        public async Task DefaultLinearItemExtraNull()
        {
            tlog.Debug(tag, $"DefaultLinearItem START");

            TaskCompletionSource<bool> tcs = new TaskCompletionSource<bool>(false);
            EventHandler onAddedToWindow = (s, e) => { tcs.TrySetResult(true); };

            var testingTarget = new DefaultLinearItem("Tizen.NUI.Components.DefaultLinearItem");

            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<DefaultLinearItem>(testingTarget, "should be an instance of testing target class!");

            testingTarget.SubLabel = new TextLabel()
            {
                Text = "test",
            };
            Assert.IsNotNull(testingTarget.SubLabel, "should be not null");

            Assert.IsNotNull(testingTarget.Extra, "should be not null");
            testingTarget.Extra.Size = new Size(100, 100);
            testingTarget.Extra.AddedToWindow += onAddedToWindow;

            Window.Instance.Add(testingTarget.Extra);

            var result = await tcs.Task;
            Assert.IsTrue(result, "Relayout event should be invoked");

            testingTarget.Dispose();
            tlog.Debug(tag, $"DefaultLinearItem END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("DefaultLinearItem Seperator.")]
        [Property("SPEC", "Tizen.NUI.Components.DefaultLinearItem.Seperator A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "huayong.xu@samsung.com")]
        public void DefaultLinearItemSeperator()
        {
            tlog.Debug(tag, $"DefaultLinearItem START");

            var testingTarget = new DefaultLinearItem("Tizen.NUI.Components.DefaultLinearItem");

            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<DefaultLinearItem>(testingTarget, "should be an instance of testing target class!");

            Assert.IsNotNull(testingTarget.Seperator, "should not be null");

            testingTarget.Dispose();
            tlog.Debug(tag, $"DefaultLinearItem END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("DefaultLinearItem LayoutChild.")]
        [Property("SPEC", "Tizen.NUI.Components.DefaultLinearItem.LayoutChild M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "huayong.xu@samsung.com")]
        public void DefaultLinearItemLayoutChild()
        {
            tlog.Debug(tag, $"DefaultGridItem START");

            var testingTarget = new TestDefaultLinearItem();

            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<DefaultLinearItem>(testingTarget, "should be an instance of testing target class!");

            testingTarget.Extra = new View()
            {
                Size = new Size(100, 100),
            };
            Assert.IsNotNull(testingTarget.Extra, "should be not null");
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
            Assert.IsNotNull(testingTarget.Label, "DefaultLinearItem Label should not be null.");
            testingTarget.SubLabel = new TextLabel()
            {
                Text = "test",
            };
            Assert.IsNotNull(testingTarget.SubLabel, "should be not null");
            testingTarget.LayoutTest();

            testingTarget.Dispose();
            tlog.Debug(tag, $"DefaultGridItem END (OK)");
        }
    }
}
