using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("Internal/Utility/EnvironmentVariable")]
    public class InternalEnvironmentVariableTest
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
        [Description("EnvironmentVariable GetEnvironmentVariable .")]
        [Property("SPEC", "Tizen.NUI.EnvironmentVariable.GetEnvironmentVariable M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void EnvironmentVariableGetEnvironmentVariable()
        {
            tlog.Debug(tag, $"EnvironmentVariableGetEnvironmentVariable START");

            var testingTarget = EnvironmentVariable.GetEnvironmentVariable("path");
            tlog.Debug(tag, "path : " + testingTarget);

            tlog.Debug(tag, $"EnvironmentVariableGetEnvironmentVariable END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("EnvironmentVariable SetEnvironmentVariable .")]
        [Property("SPEC", "Tizen.NUI.EnvironmentVariable.SetEnvironmentVariable M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void EnvironmentVariableSetEnvironmentVariable()
        {
            tlog.Debug(tag, $"EnvironmentVariableSetEnvironmentVariable START");

            EnvironmentVariable.SetEnvironmentVariable("path", Tizen.Applications.Application.Current.DirectoryInfo.Resource);
            tlog.Debug(tag, "path : " + EnvironmentVariable.GetEnvironmentVariable("path"));

            tlog.Debug(tag, $"EnvironmentVariableSetEnvironmentVariable END (OK)");
        }
    }
}
