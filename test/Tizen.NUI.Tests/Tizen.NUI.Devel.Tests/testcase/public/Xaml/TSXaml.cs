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
    [Description("public/Xaml")]
    public class PublicXamlTest
    {
        private const string tag = "NUITEST";
        private string path = Tizen.Applications.Application.Current.DirectoryInfo.Resource + "index.xml";
        private string eXamlString = "<?xml?><?xml-stylesheet?>";

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
        [Description("EXamlExtensions LoadFromXamlPath.")]
        [Property("SPEC", "Tizen.NUI.XamlExtensions.LoadFromXamlPath M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void EXamlExtensionsLoadFromEXamlPath()
        {
            tlog.Debug(tag, $"EXamlExtensionsLoadFromEXamlPath START");

            using (View view = new View())
            {
                try
                {
                    var testcase = new TotalSample();
                }
                catch (Exception e)
                {
                    tlog.Debug(tag, e.Message.ToString());
                    Assert.Fail("Caught Exception: Failed!");
                }
            }

            tlog.Debug(tag, $"EXamlExtensionsLoadFromEXamlPath END (OK)");
        }
    }
}
