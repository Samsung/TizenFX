using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("internal/Common/EnumHelper")]
    public class InternalEnumHelperTest
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
        [Description("EnumHelper GetValue.")]
        [Property("SPEC", "Tizen.NUI.EnumHelper.GetValue M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void EnumHelperGetValue()
        {
            tlog.Debug(tag, $"EnumHelperGetValue START");

            var result = EnumHelper.GetValue<VerticalAlignmentType>("Bottom");
            tlog.Debug(tag, "GetValue : " + result);

            tlog.Debug(tag, $"EnumHelperGetValue END (OK)");
        }

        [Test]
        [Category("P2")]
        [Description("EnumHelper GetValue.")]
        [Property("SPEC", "Tizen.NUI.EnumHelper.GetValue M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void EnumHelperGetValueArgumentException()
        {
            tlog.Debug(tag, $"EnumHelperGetValueArgumentException START");

            try
            {
                EnumHelper.GetValue<VerticalAlignmentType>("Right");
            }
            catch (ArgumentException)
            {
                tlog.Debug(tag, $"EnumHelperGetValueArgumentException END (OK)");
                Assert.Pass("Caught ArgumentException : Passed!");
            }
        }
    }
}
