using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("internal/Common/ArgumentHelper")]
    public class InternalArgumentHelperTest
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
        [Description("ArgumentHelper RequireNotNull.")]
        [Property("SPEC", "Tizen.NUI.Any.ArgumentHelper.RequireNotNull M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ArgumentHelperRequireNotNull()
        {
            tlog.Debug(tag, $"ArgumentHelperRequireNotNull START");

            try
            {
                ArgumentHelper.RequireNotNull(null, "type");
            }
            catch (ArgumentException e)
            {
                tlog.Debug(tag, e.Message.ToString());
                tlog.Debug(tag, $"ArgumentHelperRequireNotNull END (OK)");
                Assert.Pass("Caught ArgumentHelperRequireNotNull: Passed!");
            }
        }
    }
}
