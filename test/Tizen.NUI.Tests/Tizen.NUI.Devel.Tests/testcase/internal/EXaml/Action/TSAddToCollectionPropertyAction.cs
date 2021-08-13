using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("internal/EXaml/Action/AddToCollectionPropertyAction")]
    public class InternalAddToCollectionPropertyActionTest
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
        [Description("AddToCollectionPropertyAction constructor.")]
        [Property("SPEC", "Tizen.NUI.EXaml.AddToCollectionPropertyAction.AddToCollectionPropertyAction C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void EXamlAddToCollectionPropertyActionConstructor()
        {
            tlog.Debug(tag, $"EXamlAddToCollectionPropertyActionConstructor START");

            var testingTarget = new Tizen.NUI.EXaml.AddToCollectionPropertyAction(new Tizen.NUI.EXaml.GlobalDataList(), null);
            Assert.IsNotNull(testingTarget, "Can't create success object AddToCollectionPropertyAction");
            Assert.IsInstanceOf<Tizen.NUI.EXaml.AddToCollectionPropertyAction>(testingTarget, "Should be an instance of AddToCollectionPropertyAction type.");

            tlog.Debug(tag, $"EXamlAddToCollectionPropertyActionConstructor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("AddToCollectionPropertyAction Init.")]
        [Property("SPEC", "Tizen.NUI.EXaml.AddToCollectionPropertyAction.Init M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void EXamlAddToCollectionPropertyActionInit()
        {
            tlog.Debug(tag, $"EXamlAddToCollectionPropertyActionInit START");

            var testingTarget = new Tizen.NUI.EXaml.AddToCollectionPropertyAction(new Tizen.NUI.EXaml.GlobalDataList(), null);
            Assert.IsNotNull(testingTarget, "Can't create success object AddToCollectionPropertyAction");
            Assert.IsInstanceOf<Tizen.NUI.EXaml.AddToCollectionPropertyAction>(testingTarget, "Should be an instance of AddToCollectionPropertyAction type.");

            try
            {
                testingTarget.Init();
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            tlog.Debug(tag, $"EXamlAddToCollectionPropertyActionInit END (OK)");
        }
    }
}
