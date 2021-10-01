using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("Internal/Utility/ItemLayout")]
    public class PublicItemLayoutTest
    {
        private const string tag = "NUITEST";

        internal class MyItemLayout : ItemLayout
        {
            public MyItemLayout(global::System.IntPtr cPtr, bool cMemoryOwn) : base(cPtr, cMemoryOwn)
            { }
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
        [Description("ItemLayout constructor.")]
        [Property("SPEC", "Tizen.NUI.ItemLayout.ItemLayout C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ItemLayoutConstructor()
        {
            tlog.Debug(tag, $"ItemLayoutConstructor START");

            using (View view = new View())
            {
                var testingTarget = new ItemLayout(view.SwigCPtr.Handle, false);
                Assert.IsNotNull(testingTarget, "Should be not null!");
                Assert.IsInstanceOf<ItemLayout>(testingTarget, "Should be an Instance of ItemLayout!");

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"ItemLayoutConstructor END (OK)");
        }
    }
}
