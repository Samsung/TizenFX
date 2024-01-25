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
    [Description("public/Layouting/ILayoutParent")]
    public class PublicILayoutParentTest
    {
        private const string tag = "NUITEST";
        private static bool flagOnILayoutParentAdd;
        private static bool flagOnILayoutParentRemove;

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

        internal class MyILayoutParent : ILayoutParent
        {
            public MyILayoutParent() : base()
            { }

            public void Add(LayoutItem layoutItem)
            {
                flagOnILayoutParentAdd = true;
            }

            public void Remove(LayoutItem layoutItem)
            {
                flagOnILayoutParentRemove = true;
            }
        }

        [Test]
        [Category("P1")]
        [Description("ILayoutParent Add")]
        [Property("SPEC", "Tizen.NUI.ILayoutParent.Add M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ILayoutParentAdd()
        {
            tlog.Debug(tag, $"ILayoutParentAdd START");

            flagOnILayoutParentAdd = false;
            Assert.False(flagOnILayoutParentAdd, "flagOnILayoutParentAdd should be false initial");

            var testingTarget = new MyILayoutParent();
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<ILayoutParent>(testingTarget, "Should be an instance of ILayoutParent type.");

            using (LayoutItem layoutItem = new LayoutItem())
            {
                testingTarget.Add(layoutItem);
                Assert.IsTrue(flagOnILayoutParentAdd);
            }
            
            tlog.Debug(tag, $"ILayoutParentAdd END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ILayoutParent Remove")]
        [Property("SPEC", "Tizen.NUI.ILayoutParent.Remove M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ILayoutParentRemove()
        {
            tlog.Debug(tag, $"ILayoutParentRemove START");

            flagOnILayoutParentAdd = false;
            Assert.False(flagOnILayoutParentAdd, "flagOnILayoutParentAdd should be false initial");

            flagOnILayoutParentRemove = false;
            Assert.False(flagOnILayoutParentRemove, "flagOnILayoutParentRemove should be false initial");

            var testingTarget = new MyILayoutParent();
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<ILayoutParent>(testingTarget, "Should be an instance of ILayoutParent type.");

            using (LayoutItem layoutItem = new LayoutItem())
            {
                testingTarget.Add(layoutItem);
                Assert.IsTrue(flagOnILayoutParentAdd);

                testingTarget.Remove(layoutItem);
                Assert.IsTrue(flagOnILayoutParentRemove);
            }

            tlog.Debug(tag, $"ILayoutParentRemove END (OK)");
        }
    }
}
