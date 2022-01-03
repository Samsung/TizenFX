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
    [Description("Controls/CheckBoxGroup")]
    public class CheckBoxGroupTest
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
        [Description("CheckBoxGroup contructor.")]
        [Property("SPEC", "Tizen.NUI.Components.CheckBoxGroup.CheckBoxGroup C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void CheckBoxGroupContructor()
        {
            tlog.Debug(tag, $"CheckBoxGroupContructor START");

            var testingTarget = new CheckBoxGroup();
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<CheckBoxGroup>(testingTarget, "Should return CheckBoxGroup instance.");

            tlog.Debug(tag, $"CheckBoxGroupContructor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("CheckBoxGroup SetIsGroupHolder.")]
        [Property("SPEC", "Tizen.NUI.Components.CheckBoxGroup.SetIsGroupHolder M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void CheckBoxGroupSetIsGroupHolder()
        {
            tlog.Debug(tag, $"CheckBoxSetIsGroupHolder START");

            View view = new View()
            {
                Size = new Size(100, 200),
                BackgroundColor = Color.Green,
            };

            CheckBoxGroup.SetIsGroupHolder(view, true);
            tlog.Debug(tag, "GetIsGroupHolder : " + CheckBoxGroup.GetIsGroupHolder(view));

            tlog.Debug(tag, "GetCheckBoxGroup : " + CheckBoxGroup.GetCheckBoxGroup(view));

            view.Dispose();
            tlog.Debug(tag, $"CheckBoxSetIsGroupHolder END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("CheckBoxGroup Add.")]
        [Property("SPEC", "Tizen.NUI.Components.CheckBoxGroup.Add M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void CheckBoxGroupAdd()
        {
            tlog.Debug(tag, $"CheckBoxGroupAdd START");

            var testingTarget = new CheckBoxGroup();
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<CheckBoxGroup>(testingTarget, "Should return CheckBoxGroup instance.");

            CheckBox cb = new CheckBox()
            { 
                Size = new Size(48, 48)
            };

            try
            {
                testingTarget.Add(cb);
                tlog.Debug(tag, "GetItem : " + testingTarget.GetItem(0));

                testingTarget.Remove(cb);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            tlog.Debug(tag, $"CheckBoxGroupAdd END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("CheckBoxGroup CheckAll.")]
        [Property("SPEC", "Tizen.NUI.Components.CheckBoxGroup.CheckAll M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void CheckBoxGroupCheckAll()
        {
            tlog.Debug(tag, $"CheckBoxGroupCheckAll START");

            var testingTarget = new CheckBoxGroup();
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<CheckBoxGroup>(testingTarget, "Should return CheckBoxGroup instance.");

            CheckBox cb1 = new CheckBox()
            {
                Size = new Size(48, 48),
                IsEnabled = true,
                IsSelectable = true,
                IsSelected = true,
            };

            CheckBox cb2 = new CheckBox()
            {
                Size = new Size(48, 48),
                IsEnabled = true,
                IsSelectable = true,
                IsSelected = false,
            };

            try
            {
                testingTarget.Add(cb1);
                testingTarget.Add(cb2);
                testingTarget.CheckAll(true);

                var result = testingTarget.IsCheckedAll();
                tlog.Debug(tag, "IsCheckedAll : " + result);

                tlog.Debug(tag, "GetCheckedItems : " + testingTarget.GetCheckedItems());
                tlog.Debug(tag, "GetCheckedIndices : " + testingTarget.GetCheckedIndices());
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            tlog.Debug(tag, $"CheckBoxGroupCheckAll END (OK)");
        }
    }
}
