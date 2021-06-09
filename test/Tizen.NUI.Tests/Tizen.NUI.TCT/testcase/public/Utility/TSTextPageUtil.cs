using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tizen.NUI.Utility;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("public/Utility/TextPageUtil")]
    class PublicTextPageUtilTest
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
        [Description("TextPageUtil SetText.")]
        [Property("SPEC", "Tizen.NUI.TextPageUtil.SetText M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TextPageUtilSetText()
        {
            tlog.Debug(tag, $"TextPageUtilSetText START");

            TextPageUtil testingTarget = new TextPageUtil();
            Assert.IsNotNull(testingTarget, "Can't create success object TextPageUtil");
            Assert.IsInstanceOf<TextPageUtil>(testingTarget, "Should be an instance of TextPageUtil type.");

            using (TextLabel label = new TextLabel())
            {
                label.EnableMarkup = true;
                label.Text = "PublicPageUtilTest";
                var result = testingTarget.SetText(label, "MyPageUtil");
                Assert.IsNotNull(result);
            }

            // label.EnableMarkup = false
            using (TextLabel label = new TextLabel())
            {
                label.EnableMarkup = false;
                label.Text = "PublicPageUtilTest";
                var result = testingTarget.SetText(label, "MyPageUtil");
                Assert.IsNotNull(result);
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"TextPageUtilSetText END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TextPageUtil GetText.")]
        [Property("SPEC", "Tizen.NUI.TextPageUtil.GetText M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TextPageUtilGetText()
        {
            tlog.Debug(tag, $"TextPageUtilGetText START");

            TextPageUtil testingTarget = new TextPageUtil();
            Assert.IsNotNull(testingTarget, "Can't create success object TextPageUtil");
            Assert.IsInstanceOf<TextPageUtil>(testingTarget, "Should be an instance of TextPageUtil type.");

            using (TextLabel label = new TextLabel())
            {
                label.EnableMarkup = true;
                label.Text = "PublicPageUtilTest";
                var result = testingTarget.SetText(label, "MyPageUtil");
                Assert.IsNotNull(result);

                /** if param is 0 will return */
                try
                {
                    testingTarget.GetText(0);
                }
                catch (Exception e)
                {
                    tlog.Debug(tag, e.Message.ToString());
                    Assert.Fail("Caught Exception: Failed!");
                }

                try
                {
                    testingTarget.GetText(1);
                }
                catch (Exception e)
                {
                    tlog.Debug(tag, e.Message.ToString());
                    Assert.Fail("Caught Exception: Failed!");
                }
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"TextPageUtilGetText END (OK)");
        }
    }
}
