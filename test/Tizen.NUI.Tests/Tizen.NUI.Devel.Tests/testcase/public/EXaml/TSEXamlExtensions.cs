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
    [Description("public/EXaml/EXamlExtensions")]
    public class PublicEXamlExtensionsTest
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
        [Description("EXamlExtensions LoadFromEXamlPath.")]
        [Property("SPEC", "Tizen.NUI.EXamlExtensions.LoadFromEXamlPath M")]
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
                    var testingTarget = Tizen.NUI.EXaml.EXamlExtensions.LoadFromEXamlPath(view, path);
                }
                catch (Exception e)
                {
                    tlog.Debug(tag, e.Message.ToString());
                    Assert.Fail("Caught Exception: Failed!");
                }
            }

            tlog.Debug(tag, $"EXamlExtensionsLoadFromEXamlPath END (OK)");
        }

        [Test]
        [Category("P2")]
        [Description("EXamlExtensions LoadFromEXamlPath. Path is null.")]
        [Property("SPEC", "Tizen.NUI.EXamlExtensions.LoadFromEXamlPath M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void EXamlExtensionsLoadFromEXamlPathWithNullPath()
        {
            tlog.Debug(tag, $"EXamlExtensionsLoadFromEXamlPathWithNullPath START");

            using (View view = new View())
            {
                string str = null;
                try
                {
                    Tizen.NUI.EXaml.EXamlExtensions.LoadFromEXamlPath(view, str);
                }
                catch (Exception e)
                {
                    tlog.Debug(tag, e.Message.ToString());
                    tlog.Debug(tag, $"EXamlExtensionsLoadFromEXamlPathWithNullPath END (OK)");
                    Assert.Pass("Caught Exception: Passed!");
                }
            }
        }

        [Test]
        [Category("P1")]
        [Description("EXamlExtensions LoadFromEXamlPath. With callingType")]
        [Property("SPEC", "Tizen.NUI.EXamlExtensions.LoadFromEXamlPath M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void EXamlExtensionsLoadFromEXamlPathWithType()
        {
            tlog.Debug(tag, $"EXamlExtensionsLoadFromEXamlPathWithType START");

            using (View view = new View())
            {
                try
                {
                    var testingTarget = Tizen.NUI.EXaml.EXamlExtensions.LoadFromEXamlPath(view, GetType());
                }
                catch (Exception e)
                {
                    tlog.Debug(tag, e.Message.ToString());
                    Assert.Fail("Caught Exception: Failed!");
                }
            }

            tlog.Debug(tag, $"EXamlExtensionsLoadFromEXamlPathWithType END (OK)");
        }

        [Test]
        [Category("P2")]
        [Description("EXamlExtensions LoadFromEXamlPath. Type is null.")]
        [Property("SPEC", "Tizen.NUI.EXamlExtensions.LoadFromEXamlPath M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void EXamlExtensionsLoadFromEXamlPathWithNullType()
        {
            tlog.Debug(tag, $"EXamlExtensionsLoadFromEXamlPathWithNullType START");

            using (View view = new View())
            {
                Type type = null;
                var testingTarget = Tizen.NUI.EXaml.EXamlExtensions.LoadFromEXamlPath(view, type);
            }

            tlog.Debug(tag, $"EXamlExtensionsLoadFromEXamlPathWithNullType END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("EXamlExtensions LoadFromEXaml.")]
        [Property("SPEC", "Tizen.NUI.EXamlExtensions.LoadFromEXaml M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void EXamlExtensionsLoadFromEXaml()
        {
            tlog.Debug(tag, $"EXamlExtensionsLoadFromEXaml START");

            using (View view = new View())
            {
                try
                {
                    var testingTarget = Tizen.NUI.EXaml.EXamlExtensions.LoadFromEXaml(view, eXamlString);
                    Assert.IsNotNull(testingTarget, "Can't create success object View");
                    Assert.IsInstanceOf<View>(testingTarget, "Should be an instance of View type.");
                }
                catch (Exception e)
                {
                    tlog.Debug(tag, e.Message.ToString());
                    Assert.Fail("Caught Exception: Failed!");
                }
            }

            tlog.Debug(tag, $"EXamlExtensionsLoadFromEXaml END (OK)");
        }

        [Test]
        [Category("P2")]
        [Description("EXamlExtensions LoadFromEXaml. String is null.")]
        [Property("SPEC", "Tizen.NUI.ControlState.Create M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void EXamlExtensionsLoadFromEXamlWithNullString()
        {
            tlog.Debug(tag, $"EXamlExtensionsLoadFromEXamlWithNullString START");

            using (View view = new View())
            {
                var testingTarget = Tizen.NUI.EXaml.EXamlExtensions.LoadFromEXaml(view, null);
                Assert.IsNotNull(testingTarget, "Can't create success object View");
                Assert.IsInstanceOf<View>(testingTarget, "Should be an instance of View type.");
            }

            tlog.Debug(tag, $"EXamlExtensionsLoadFromEXamlWithNullString END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Extensions LoadFromXamlPath.")]
        [Property("SPEC", "Tizen.NUI.EXaml.EXamlExtensions.LoadFromEXamlByRelativePath M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "TXaml,Type")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void LoadFromEXamlByRelativePath2()
        {
            tlog.Debug(tag, $"LoadFromEXamlByRelativePath2 START");

            try
            {
                var testcase = new TotalSample(true);
                Assert.True(true, "Should go here!");
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                tlog.Debug(tag, e.StackTrace);
                Assert.Fail("Caught Exception: Failed!");
            }

            tlog.Debug(tag, $"LoadFromEXamlByRelativePath2 END");
        }
    }
}
