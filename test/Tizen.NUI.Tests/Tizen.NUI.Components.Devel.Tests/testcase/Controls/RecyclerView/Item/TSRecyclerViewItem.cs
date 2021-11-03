using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Binding;

namespace Tizen.NUI.Components.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("Controls/RecyclerView/Item/RecyclerViewItem")]
    class TSRecyclerViewItem
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
        [Description("RecyclerViewItem constructor.")]
        [Property("SPEC", "Tizen.NUI.Components.RecyclerViewItem C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "huayong.xu@samsung.com")]
        public void RecyclerViewItemConstructor()
        {
            tlog.Debug(tag, $"RecyclerViewItem START");

            var testingTarget = new RecyclerViewItem();

            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<RecyclerViewItem>(testingTarget, "should be an instance of testing target class!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"RecyclerViewItem END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("RecyclerViewItem constructor.")]
        [Property("SPEC", "Tizen.NUI.Components.RecyclerViewItem C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "huayong.xu@samsung.com")]
        public void RecyclerViewItemConstructorWithStyle()
        {
            tlog.Debug(tag, $"RecyclerViewItem START");

            var testingTarget = new RecyclerViewItem("Tizen.NUI.Components.RecyclerViewItem");

            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<RecyclerViewItem>(testingTarget, "should be an instance of testing target class!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"RecyclerViewItem END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("RecyclerViewItem constructor.")]
        [Property("SPEC", "Tizen.NUI.Components.RecyclerViewItem C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "huayong.xu@samsung.com")]
        public void RecyclerViewItemConstructorWithItemStyle()
        {
            tlog.Debug(tag, $"RecyclerViewItem START");

            var style = new RecyclerViewItemStyle()
            {
                BackgroundColor = new Selector<Color>()
                {
                    Normal = new Color(1, 1, 1, 1),
                    Pressed = new Color(0.85f, 0.85f, 0.85f, 1),
                    Disabled = new Color(0.70f, 0.70f, 0.70f, 1),
                    Selected = new Color(0.701f, 0.898f, 0.937f, 1),
                },
            };
            var testingTarget = new RecyclerViewItem(style);

            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<RecyclerViewItem>(testingTarget, "should be an instance of testing target class!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"RecyclerViewItem END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("RecyclerViewItem IsSelectable.")]
        [Property("SPEC", "Tizen.NUI.Components.RecyclerViewItem.IsSelectable A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "huayong.xu@samsung.com")]
        public void RecyclerViewItemIsSelectable()
        {
            tlog.Debug(tag, $"RecyclerViewItem START");

            var testingTarget = new RecyclerViewItem("Tizen.NUI.Components.RecyclerViewItem");

            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<RecyclerViewItem>(testingTarget, "should be an instance of testing target class!");

            testingTarget.IsSelectable = true;
            Assert.IsTrue(testingTarget.IsSelectable, "should be selectable.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"RecyclerViewItem END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("RecyclerViewItem IsSelected.")]
        [Property("SPEC", "Tizen.NUI.Components.RecyclerViewItem.IsSelected A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "huayong.xu@samsung.com")]
        public void RecyclerViewItemIsSelected()
        {
            tlog.Debug(tag, $"RecyclerViewItem START");

            var testingTarget = new RecyclerViewItem("Tizen.NUI.Components.RecyclerViewItem");

            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<RecyclerViewItem>(testingTarget, "should be an instance of testing target class!");

            testingTarget.IsSelected = true;
            Assert.IsTrue(testingTarget.IsSelected, "should be selected.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"RecyclerViewItem END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("RecyclerViewItem IsEnabled.")]
        [Property("SPEC", "Tizen.NUI.Components.RecyclerViewItem.IsEnabled A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "huayong.xu@samsung.com")]
        public void RecyclerViewItemIsEnabled()
        {
            tlog.Debug(tag, $"RecyclerViewItem START");

            var testingTarget = new RecyclerViewItem("Tizen.NUI.Components.RecyclerViewItem");

            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<RecyclerViewItem>(testingTarget, "should be an instance of testing target class!");

            testingTarget.IsEnabled = true;
            Assert.IsTrue(testingTarget.IsEnabled, "should be enabled.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"RecyclerViewItem END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("RecyclerViewItem Index.")]
        [Property("SPEC", "Tizen.NUI.Components.RecyclerViewItem.Index A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "huayong.xu@samsung.com")]
        public void RecyclerViewItemIndex()
        {
            tlog.Debug(tag, $"RecyclerViewItem START");

            var testingTarget = new RecyclerViewItem("Tizen.NUI.Components.RecyclerViewItem");

            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<RecyclerViewItem>(testingTarget, "should be an instance of testing target class!");

            testingTarget.Index = 0;
            Assert.AreEqual(testingTarget.Index, 0, "should be equal to 0.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"RecyclerViewItem END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("RecyclerViewItem Template.")]
        [Property("SPEC", "Tizen.NUI.Components.RecyclerViewItem.Template A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "huayong.xu@samsung.com")]
        public void RecyclerViewItemTemplate()
        {
            tlog.Debug(tag, $"RecyclerViewItem START");

            var testingTarget = new RecyclerViewItem("Tizen.NUI.Components.RecyclerViewItem");

            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<RecyclerViewItem>(testingTarget, "should be an instance of testing target class!");

            testingTarget.Template = new DataTemplate(() =>
            {
                var rand = new Random();
                DefaultLinearItem item = new DefaultLinearItem();
                //Set Width Specification as MatchParent to fit the Item width with parent View.
                item.WidthSpecification = LayoutParamPolicies.MatchParent;

                //Decorate Label
                item.Label.SetBinding(TextLabel.TextProperty, "ViewLabel");
                item.Label.HorizontalAlignment = HorizontalAlignment.Begin;

                //Decorate SubLabel
                if ((rand.Next() % 2) == 0)
                {
                    item.SubLabel.SetBinding(TextLabel.TextProperty, "Name");
                    item.SubLabel.HorizontalAlignment = HorizontalAlignment.Begin;
                }

                return item;
            });
            Assert.IsNotNull(testingTarget.Template, "should not be null.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"RecyclerViewItem END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("RecyclerViewItem IsRealized.")]
        [Property("SPEC", "Tizen.NUI.Components.RecyclerViewItem.IsRealized A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "huayong.xu@samsung.com")]
        public void RecyclerViewItemIsRealized()
        {
            tlog.Debug(tag, $"RecyclerViewItem START");

            var testingTarget = new RecyclerViewItem("Tizen.NUI.Components.RecyclerViewItem");

            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<RecyclerViewItem>(testingTarget, "should be an instance of testing target class!");

            testingTarget.IsRealized = true;
            Assert.IsTrue(testingTarget.IsRealized, "should be realized.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"RecyclerViewItem END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("RecyclerViewItem IsHeader.")]
        [Property("SPEC", "Tizen.NUI.Components.RecyclerViewItem.IsHeader A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "huayong.xu@samsung.com")]
        public void RecyclerViewItemIsHeader()
        {
            tlog.Debug(tag, $"RecyclerViewItem START");

            var testingTarget = new RecyclerViewItem("Tizen.NUI.Components.RecyclerViewItem");

            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<RecyclerViewItem>(testingTarget, "should be an instance of testing target class!");

            testingTarget.IsHeader = true;
            Assert.IsTrue(testingTarget.IsHeader, "should be header.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"RecyclerViewItem END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("RecyclerViewItem IsFooter.")]
        [Property("SPEC", "Tizen.NUI.Components.RecyclerViewItem.IsFooter A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "huayong.xu@samsung.com")]
        public void RecyclerViewItemIsFooter()
        {
            tlog.Debug(tag, $"RecyclerViewItem START");

            var testingTarget = new RecyclerViewItem("Tizen.NUI.Components.RecyclerViewItem");

            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<RecyclerViewItem>(testingTarget, "should be an instance of testing target class!");

            testingTarget.IsFooter = true;
            Assert.IsTrue(testingTarget.IsFooter, "should be footer.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"RecyclerViewItem END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("RecyclerViewItem IsPressed.")]
        [Property("SPEC", "Tizen.NUI.Components.RecyclerViewItem.IsPressed A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "huayong.xu@samsung.com")]
        public void RecyclerViewItemIsPressed()
        {
            tlog.Debug(tag, $"RecyclerViewItem START");

            var testingTarget = new RecyclerViewItem("Tizen.NUI.Components.RecyclerViewItem");

            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<RecyclerViewItem>(testingTarget, "should be an instance of testing target class!");

            testingTarget.IsPressed = true;
            Assert.IsTrue(testingTarget.IsPressed, "should be pressed.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"RecyclerViewItem END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("RecyclerViewItem OnKey.")]
        [Property("SPEC", "Tizen.NUI.Components.RecyclerViewItem.OnKey M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "huayong.xu@samsung.com")]
        public void RecyclerViewItemOnKey()
        {
            tlog.Debug(tag, $"RecyclerViewItem START");

            var testingTarget = new RecyclerViewItem("Tizen.NUI.Components.RecyclerViewItem");

            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<RecyclerViewItem>(testingTarget, "should be an instance of testing target class!");

            var key = new Key()
            {
                State = Key.StateType.Up,
                KeyPressedName = "Return"
            };
            Assert.IsFalse(testingTarget.OnKey(key), "should not be processed.");

            key = new Key()
            {
                State = Key.StateType.Down,
                KeyPressedName = "Return"
            };
            Assert.IsFalse(testingTarget.OnKey(key), "should not be processed.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"RecyclerViewItem END (OK)");
        }
    }
}
