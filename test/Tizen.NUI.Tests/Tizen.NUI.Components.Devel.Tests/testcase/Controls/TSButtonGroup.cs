using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Components.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("Controls/ButtonGroup")]
    public class ButtonGroupTest
    {
        private const string tag = "NUITEST";
        private string image_path = Tizen.Applications.Application.Current.DirectoryInfo.Resource + "picture.png";

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
        [Description("ButtonGroup contructor.")]
        [Property("SPEC", "Tizen.NUI.Components.ButtonGroup.ButtonGroup C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ButtonGroupContructor()
        {
            tlog.Debug(tag, $"ButtonGroupContructor START");

            using (View view = new View() { Size = new Size(100, 200) })
            {
                var testingTarget = new ButtonGroup(view);
                Assert.IsNotNull(testingTarget, "null handle");
                Assert.IsInstanceOf<ButtonGroup>(testingTarget, "Should return ButtonGroup instance.");

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"ButtonGroupContructor END (OK)");
        }

        [Test]
        [Category("P2")]
        [Description("ButtonGroup contructor.")]
        [Property("SPEC", "Tizen.NUI.Components.ButtonGroup.ButtonGroup C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ButtonGroupContructorNullView()
        {
            tlog.Debug(tag, $"ButtonGroupContructorNullView START");

            View view = null;

            try
            {
                var testingTarget = new ButtonGroup(view);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Pass("Root view is null : Passed!");
            }
                
            tlog.Debug(tag, $"ButtonGroupContructorNullView END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ButtonGroup AddItem.")]
        [Property("SPEC", "Tizen.NUI.Components.ButtonGroup.AddItem M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ButtonGroupAddItem()
        {
            tlog.Debug(tag, $"ButtonGroupAddItem START");

            using (View view = new View() { Size = new Size(100, 200) })
            {
                var testingTarget = new ButtonGroup(view);
                Assert.IsNotNull(testingTarget, "null handle");
                Assert.IsInstanceOf<ButtonGroup>(testingTarget, "Should return ButtonGroup instance.");

                using (Button bt = new Button() { Size = new Size(20, 30) })
                {
                    try
                    {
                        testingTarget.AddItem(bt);
                        tlog.Debug(tag, "Count : " + testingTarget.Count);
                        tlog.Debug(tag, "Contains : " + testingTarget.Contains(bt));

                        var index = testingTarget.GetIndex(bt);
                        var result = testingTarget.GetItem(index);
                        tlog.Debug(tag, "Item : " + result);

                        try
                        {
                            testingTarget.RemoveItem(index);
                        }
                        catch (Exception e)
                        {
                            tlog.Debug(tag, e.Message.ToString());
                            Assert.Fail("Caught exception : Failed!");
                        }
                    }
                    catch (Exception e)
                    {
                        tlog.Debug(tag, e.Message.ToString());
                        Assert.Fail("Caught Exception : Failed!");
                    }
                }

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"ButtonGroupAddItem END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ButtonGroup Itemheight.")]
        [Property("SPEC", "Tizen.NUI.Components.ButtonGroup.Itemheight A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ButtonGroupItemheight()
        {
            tlog.Debug(tag, $"ButtonGroupItemheight START");

            using (View view = new View() { Size = new Size(100, 200) })
            {
                var testingTarget = new ButtonGroup(view);
                Assert.IsNotNull(testingTarget, "null handle");
                Assert.IsInstanceOf<ButtonGroup>(testingTarget, "Should return ButtonGroup instance.");

                testingTarget.Itemheight = 30.0f;
                tlog.Debug(tag, "Itemheight : " + testingTarget.Itemheight);

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"ButtonGroupItemheight END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ButtonGroup ItemPointSize.")]
        [Property("SPEC", "Tizen.NUI.Components.ButtonGroup.ItemPointSize A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ButtonGroupItemPointSize()
        {
            tlog.Debug(tag, $"ButtonGroupItemPointSize START");

            using (View view = new View() { Size = new Size(100, 200) })
            {
                var testingTarget = new ButtonGroup(view);
                Assert.IsNotNull(testingTarget, "null handle");
                Assert.IsInstanceOf<ButtonGroup>(testingTarget, "Should return ButtonGroup instance.");

                testingTarget.ItemPointSize = 15.0f;
                tlog.Debug(tag, "ItemPointSize : " + testingTarget.ItemPointSize);

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"ButtonGroupItemPointSize END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ButtonGroup ItemFontFamily.")]
        [Property("SPEC", "Tizen.NUI.Components.ButtonGroup.ItemFontFamily A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ButtonGroupItemFontFamily()
        {
            tlog.Debug(tag, $"ButtonGroupItemFontFamily START");

            using (View view = new View() { Size = new Size(100, 200) })
            {
                var testingTarget = new ButtonGroup(view);
                Assert.IsNotNull(testingTarget, "null handle");
                Assert.IsInstanceOf<ButtonGroup>(testingTarget, "Should return ButtonGroup instance.");

                testingTarget.ItemFontFamily = "SamsungOne 400";
                tlog.Debug(tag, "ItemFontFamily : " + testingTarget.ItemFontFamily);

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"ButtonGroupItemFontFamily END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ButtonGroup ItemTextColor.")]
        [Property("SPEC", "Tizen.NUI.Components.ButtonGroup.ItemTextColor A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ButtonGroupItemTextColor()
        {
            tlog.Debug(tag, $"ButtonGroupItemTextColor START");

            using (View view = new View() { Size = new Size(100, 200) })
            {
                var testingTarget = new ButtonGroup(view);
                Assert.IsNotNull(testingTarget, "null handle");
                Assert.IsInstanceOf<ButtonGroup>(testingTarget, "Should return ButtonGroup instance.");

                testingTarget.ItemTextColor = Color.Green;
                tlog.Debug(tag, "ItemTextColor : " + testingTarget.ItemTextColor);

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"ButtonGroupItemTextColor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ButtonGroup ItemTextAlignment.")]
        [Property("SPEC", "Tizen.NUI.Components.ButtonGroup.ItemTextAlignment A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ButtonGroupItemTextAlignment()
        {
            tlog.Debug(tag, $"ButtonGroupItemTextAlignment START");

            using (View view = new View() { Size = new Size(100, 200) })
            {
                var testingTarget = new ButtonGroup(view);
                Assert.IsNotNull(testingTarget, "null handle");
                Assert.IsInstanceOf<ButtonGroup>(testingTarget, "Should return ButtonGroup instance.");

                testingTarget.ItemTextAlignment = HorizontalAlignment.Center;
                tlog.Debug(tag, "ItemTextAlignment : " + testingTarget.ItemTextAlignment);

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"ButtonGroupItemTextAlignment END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ButtonGroup OverLayBackgroundColorSelector.")]
        [Property("SPEC", "Tizen.NUI.Components.ButtonGroup.OverLayBackgroundColorSelector A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ButtonGroupOverLayBackgroundColorSelector()
        {
            tlog.Debug(tag, $"ButtonGroupOverLayBackgroundColorSelector START");

            using (View view = new View() { Size = new Size(100, 200) })
            {
                var testingTarget = new ButtonGroup(view);
                Assert.IsNotNull(testingTarget, "null handle");
                Assert.IsInstanceOf<ButtonGroup>(testingTarget, "Should return ButtonGroup instance.");

                Selector<Color> color = new Selector<Color>(Color.Blue);
                testingTarget.OverLayBackgroundColorSelector = color;
                tlog.Debug(tag, "OverLayBackgroundColorSelector : " + testingTarget.OverLayBackgroundColorSelector);

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"ButtonGroupOverLayBackgroundColorSelector END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ButtonGroup ItemBackgroundImageUrl.")]
        [Property("SPEC", "Tizen.NUI.Components.ButtonGroup.ItemBackgroundImageUrl A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ButtonGroupItemBackgroundImageUrl()
        {
            tlog.Debug(tag, $"ButtonGroupItemBackgroundImageUrl");

            using (View view = new View() { Size = new Size(100, 200) })
            {
                var testingTarget = new ButtonGroup(view);
                Assert.IsNotNull(testingTarget, "null handle");
                Assert.IsInstanceOf<ButtonGroup>(testingTarget, "Should return ButtonGroup instance.");

                testingTarget.ItemBackgroundImageUrl = image_path;
                tlog.Debug(tag, "ItemBackgroundImageUrl : " + testingTarget.ItemBackgroundImageUrl);

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"ButtonGroupItemBackgroundImageUrl END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ButtonGroup ItemBackgroundBorder.")]
        [Property("SPEC", "Tizen.NUI.Components.ButtonGroup.ItemBackgroundBorder A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ButtonGroupItemBackgroundBorder()
        {
            tlog.Debug(tag, $"ButtonGroupItemBackgroundBorder");

            using (View view = new View() { Size = new Size(100, 200) })
            {
                var testingTarget = new ButtonGroup(view);
                Assert.IsNotNull(testingTarget, "null handle");
                Assert.IsInstanceOf<ButtonGroup>(testingTarget, "Should return ButtonGroup instance.");

                testingTarget.ItemBackgroundBorder = new Rectangle(10, 10, 10, 10);
                tlog.Debug(tag, "ItemBackgroundBorder : " + testingTarget.ItemBackgroundBorder);

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"ButtonGroupItemBackgroundBorder END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ButtonGroup ItemImageShadow.")]
        [Property("SPEC", "Tizen.NUI.Components.ButtonGroup.ItemImageShadow A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ButtonGroupItemImageShadow()
        {
            tlog.Debug(tag, $"ButtonGroupItemImageShadow");

            using (View view = new View() { Size = new Size(100, 200) })
            {
                var testingTarget = new ButtonGroup(view);
                Assert.IsNotNull(testingTarget, "null handle");
                Assert.IsInstanceOf<ButtonGroup>(testingTarget, "Should return ButtonGroup instance.");

                testingTarget.ItemImageShadow = new ImageShadow(image_path, new Rectangle(10, 10, 10, 10));
                tlog.Debug(tag, "ItemImageShadow : " + testingTarget.ItemImageShadow);

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"ButtonGroupItemImageShadow END (OK)");
        }
    }
}
