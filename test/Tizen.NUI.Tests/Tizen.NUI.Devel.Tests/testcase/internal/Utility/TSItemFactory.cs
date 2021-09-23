using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("Internal/Utility/ItemFactory")]
    public class InternalItemFactoryTest
    {
        private const string tag = "NUITEST";

        internal class MyItemFactory : ItemFactory
        {
            public MyItemFactory() : base()
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
        [Description("ItemFactory constructor.")]
        [Property("SPEC", "Tizen.NUI.ItemFactory.ItemFactory C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ItemFactoryConstructor()
        {
            tlog.Debug(tag, $"ItemFactoryConstructor START");

            var testingTarget = new ItemFactory();
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<ItemFactory>(testingTarget, "Should be an Instance of ItemFactory!");

            testingTarget.Dispose();

            tlog.Debug(tag, $"ItemFactoryConstructor END (OK)");
        }
    }
}
