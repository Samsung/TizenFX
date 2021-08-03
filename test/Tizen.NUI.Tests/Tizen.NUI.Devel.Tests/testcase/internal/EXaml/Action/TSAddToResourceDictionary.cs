using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("internal/EXaml/Action/AddToResourceDictionary")]
    public class InternalAddToResourceDictionaryTest
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
        [Description("AddToResourceDictionary constructor.")]
        [Property("SPEC", "Tizen.NUI.EXaml.AddToResourceDictionary.AddToResourceDictionary C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void EXamlAddToResourceDictionaryConstructor()
        {
            tlog.Debug(tag, $"EXamlAddToResourceDictionaryConstructor START");

            var testingTarget = new Tizen.NUI.EXaml.AddToResourceDictionary(new Tizen.NUI.EXaml.GlobalDataList(), 1, "dictionary", null);
            Assert.IsNotNull(testingTarget, "Can't create success object AddToResourceDictionary");
            Assert.IsInstanceOf<Tizen.NUI.EXaml.AddToResourceDictionary>(testingTarget, "Should be an instance of AddToResourceDictionary type.");

            tlog.Debug(tag, $"EXamlAddToResourceDictionaryConstructor END (OK)");
        }
    }
}
