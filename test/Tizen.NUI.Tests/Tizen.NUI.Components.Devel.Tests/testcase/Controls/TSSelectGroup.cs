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
    [Description("Controls/SelectGroup")]
    public class SelectGroupTest
    {
        private const string tag = "NUITEST";

        internal class MySelectGroup : SelectGroup
        {
            public MySelectGroup() : base()
            {
            }

            public void MyAddSelection(SelectButton selection)
            {
                base.AddSelection(selection);
            }

            public void MyOnSelectedChanged(SelectButton selection)
            {
                base.OnSelectedChanged(selection);
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
        [Description("SelectGroup Count.")]
        [Property("SPEC", "Tizen.NUI.Components.SelectGroup.Count A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void SelectGroupCount()
        {
            tlog.Debug(tag, $"SelectGroupCount START");

            var testingTarget = new MySelectGroup();
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<SelectGroup>(testingTarget, "Should return SelectGroup instance.");

            tlog.Debug(tag, "Count : " + testingTarget.Count);

            SelectButton selection = new SelectButton();
            testingTarget.MyAddSelection(selection);
            tlog.Debug(tag, "Count : " + testingTarget.Count);

            var result = testingTarget.Contains(selection);
            tlog.Debug(tag, "Contains : " + result);

            using (View view = new View() { Size = new Size(100, 200) })
            {
                try
                {
                    testingTarget.AddAllToView(view);
                }
                catch (Exception e)
                {
                    tlog.Debug(tag, e.Message.ToString());
                    Assert.Fail("Caught Exception : Failed!");
                }
            }

            tlog.Debug(tag, $"SelectGroupCount END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("SelectGroup OnSelectedChanged.")]
        [Property("SPEC", "Tizen.NUI.Components.SelectGroup.OnSelectedChanged M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void SelectGroupOnSelectedChanged()
        {
            tlog.Debug(tag, $"SelectGroupOnSelectedChanged START");

            var testingTarget = new MySelectGroup();
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<SelectGroup>(testingTarget, "Should return SelectGroup instance.");

            SelectButton selection = new SelectButton();
            testingTarget.MyAddSelection(selection);

            try
            {
                testingTarget.MyOnSelectedChanged(selection);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            tlog.Debug(tag, $"SelectGroupOnSelectedChanged END (OK)");
        }
    }
}
