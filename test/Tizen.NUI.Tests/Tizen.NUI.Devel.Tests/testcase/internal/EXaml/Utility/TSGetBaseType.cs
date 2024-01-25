using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("internal/EXaml/Utility/GetBaseType")]
    public class InternalGetBaseTypeTest
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
        [Description("GetBaseType GetBaseTypeByIndex.")]
        [Property("SPEC", "Tizen.NUI.EXaml.GetBaseType.GetBaseTypeByIndex C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void EXamlGetBaseTypeGetBaseTypeByIndex()
        {
            tlog.Debug(tag, $"EXamlGetBaseTypeGetBaseTypeByIndex START");

            try
            {
                var result = Tizen.NUI.EXaml.GetBaseType.GetBaseTypeByIndex(-3);
                tlog.Debug(tag, result.ToString());
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception :  Failed!");
            }

            tlog.Debug(tag, $"EXamlGetBaseTypeGetBaseTypeByIndex END (OK)");
        }
    }
}
