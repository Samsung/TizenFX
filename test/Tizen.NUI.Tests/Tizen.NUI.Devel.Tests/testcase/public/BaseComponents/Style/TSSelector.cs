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
    [Description("public/BaseComponents/Style/Selector")]
    public class PublicSelectorTest
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
        [Description("Selector Add.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.Selector.Add M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void SelectorAddSelectorItem()
        {
            tlog.Debug(tag, $"SelectorAddSelectorItem START");

            Selector<Color> colors = new Selector<Color>();

            SelectorItem<Color> item = new SelectorItem<Color>();
            item.Value = Color.White;
            item.State = ControlState.All;

            colors.Add(item);
            // if item be added, remove if first
            colors.Add(item);

            colors.GetValue(ControlState.All, out Color color);
            tlog.Debug(tag, "color : " + color);

            tlog.Debug(tag, "Count :" + colors.Count);
            tlog.Debug(tag, "IsReadOnly :" + colors.IsReadOnly);

            var result = colors.Contains(item);
            Assert.AreEqual(true, result, "Should be equal!");

            try
            {
                colors.GetEnumerator();
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            result = colors.Remove(item);
            Assert.AreEqual(true, result, "Should be equal!");

            tlog.Debug(tag, $"SelectorAddSelectorItem END (OK)");
        }

        [Test]
        [Category("P2")]
        [Description("Selector Add.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.Selector.Add M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void SelectorAddNullSelectorItem()
        {
            tlog.Debug(tag, $"SelectorAddNullSelectorItem START");

            Selector<Color> colors = new Selector<Color>();

            SelectorItem<Color> item = null;

            try
            {
                colors.Add(item);
            }
            catch (ArgumentNullException)
            {
                tlog.Debug(tag, $"SelectorAddNullSelectorItem END (OK)");
                Assert.Pass("Caught ArgumentNullException :  Passed!");
            }
        }

        [Test]
        [Category("P2")]
        [Description("Selector Contains.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.Selector.Contains M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void SelectorContainsNullSelectorItem()
        {
            tlog.Debug(tag, $"SelectorContainsNullSelectorItem START");

            Selector<Color> colors = new Selector<Color>();

            SelectorItem<Color> item = null;

            try
            {
                colors.Contains(item);
            }
            catch (ArgumentNullException)
            {
                tlog.Debug(tag, $"SelectorContainsNullSelectorItem END (OK)");
                Assert.Pass("Caught ArgumentNullException :  Passed!");
            }
        }

        [Test]
        [Category("P1")]
        [Description("SelectorExtensions Add.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.SelectorExtensions.Add M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void SelectorExtensionsAdd()
        {
            tlog.Debug(tag, $"SelectorExtensionsAdd START");

            Selector<Color> colors = new Selector<Color>();

            IList<SelectorItem<Color>> list = new List<SelectorItem<Color>>();

            var item = new SelectorItem<Color>()
            {
                Value = Color.Cyan,
                State = ControlState.All
            };
            item.ToString();
            list.Add(item);

            try
            {
                SelectorExtensions.Add(list, ControlState.All, Color.White);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            tlog.Debug(tag, $"SelectorExtensionsAdd END (OK)");
        }

        [Test]
        [Category("P2")]
        [Description("SelectorExtensions Add.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.SelectorExtensions.Add M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void SelectorExtensionsAddWithNullList()
        {
            tlog.Debug(tag, $"SelectorExtensionsAddWithNullList START");

            Selector<Color> colors = new Selector<Color>();

            IList<SelectorItem<Color>> list = null;

            try
            {
                SelectorExtensions.Add(list, ControlState.All, Color.White);
            }
            catch (ArgumentNullException)
            {
                tlog.Debug(tag, $"SelectorExtensionsAddWithNullList END (OK)");
                Assert.Pass("Caught ArgumentNullException : Passed!");
            }
        }

        [Test]
        [Category("P1")]
        [Description("Selector GetHashCode.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.Selector.GetHashCode M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void SelectorGetHashCode()
        {
            tlog.Debug(tag, $"SelectorGetHashCode START");

            Selector<Color> colors = new Selector<Color>();

            SelectorItem<Color> item = new SelectorItem<Color>();
            item.Value = Color.White;
            item.State = ControlState.All;

            colors.Add(item);
            var result = colors.GetHashCode();
            tlog.Debug(tag, "HashCode : " + result);

            tlog.Debug(tag, $"SelectorGetHashCode END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Selector Equals.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.Selector.Equals M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void SelectorEquals()
        {
            tlog.Debug(tag, $"SelectorEquals START");

            Selector<Color> colors = new Selector<Color>();

            SelectorItem<Color> item = new SelectorItem<Color>();
            item.Value = Color.White;
            item.State = ControlState.All;

            colors.Add(item);
            Selector<Color> dummy1 = new Selector<Color>(Color.Cyan);
            Selector<string> dummy2 = new Selector<string>("mytest");

            var result = colors.Equals(dummy1);
            tlog.Debug(tag, "Equals : " + result);

            result = colors.Equals(dummy2);
            tlog.Debug(tag, "Equals : " + result);

            tlog.Debug(tag, $"SelectorEquals END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Selector ToString.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.Selector.ToString M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void SelectorToString()
        {
            tlog.Debug(tag, $"SelectorToString START");

            var testingTarget = new Selector<Color>(Color.Cyan);
            Assert.IsNotNull(testingTarget, "Can't create success object RenderTask.");
            Assert.IsInstanceOf<Selector<Color>>(testingTarget, "Should return Selector<Color> instance.");

            var result = testingTarget.ToString();
            tlog.Debug(tag, "ToString : " + result);

            tlog.Debug(tag, $"SelectorToString END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Selector CopyTo.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.Selector.CopyTo M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void SelectorCopyTo()
        {
            tlog.Debug(tag, $"SelectorCopyTo START");

            var testingTarget = new Selector<Color>(Color.Cyan);
            Assert.IsNotNull(testingTarget, "Can't create success object RenderTask.");
            Assert.IsInstanceOf<Selector<Color>>(testingTarget, "Should return Selector<Color> instance.");

            SelectorItem<Color>[] item = new SelectorItem<Color>[2];
            item[0] = new SelectorItem<Color>();
            item[0].Value = Color.Cyan;
            item[0].State = ControlState.All;

            item[1] = new SelectorItem<Color>();
            item[1].Value = Color.Yellow;
            item[1].State = ControlState.Normal;

            try
            {
                testingTarget.CopyTo(item, 0);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!"　);
            }

            tlog.Debug(tag, $"SelectorCopyTo END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Selector GetValue.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.Selector.GetValue M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void SelectorGetValue()
        {
            tlog.Debug(tag, $"SelectorGetValue START");

            var testingTarget = new Selector<Color>();
            Assert.IsNotNull(testingTarget, "Can't create success object RenderTask.");
            Assert.IsInstanceOf<Selector<Color>>(testingTarget, "Should return Selector<Color> instance.");

            SelectorItem<Color>[] item = new SelectorItem<Color>[2];
            item[0] = new SelectorItem<Color>();
            item[0].Value = Color.Cyan;
            item[0].State = ControlState.All;

            item[1] = new SelectorItem<Color>();
            item[1].Value = Color.Yellow;
            item[1].State = ControlState.Normal;

            testingTarget.CopyTo(item, 0);
            testingTarget.GetValue(ControlState.Normal, out Color color);
            tlog.Debug(tag, "color : " + color);

            tlog.Debug(tag, $"SelectorGetValue END (OK)");
        }
    }
}
