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
                label.Size = new Size(200, 100);
                label.EnableMarkup = true;
                label.Text = "PublicPageUtilTest";
                var result = testingTarget.SetText(label, "1 My love 2 Just one last dance 3 As long as you love me 4 Because of you 5 God is a girl 6 Hero 7 Yesterday once more 8 Lonely 9 All rise 10 One love 11 Big big world 12 My heart will go on");
                Assert.IsNotNull(result);
            }

            // label.EnableMarkup = false
            using (TextLabel label = new TextLabel())
            {
                label.Size = new Size(200, 100);
                label.EnableMarkup = false;
                label.Text = "PublicPageUtilTest";
                var result = testingTarget.SetText(label, "1 My love 2 Just one last dance 3 As long as you love me 4 Because of you 5 God is a girl 6 Hero 7 Yesterday once more 8 Lonely 9 All rise 10 One love 11 Big big world 12 My heart will go on");
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
                label.Size = new Size(200, 100);
                label.EnableMarkup = true;
                label.Text = "PublicPageUtilTest";
                var result = testingTarget.SetText(label, "1 My love 2 Just one last dance 3 As long as you love me 4 Because of you 5 God is a girl 6 Hero 7 Yesterday once more 8 Lonely 9 All rise 10 One love 11 Big big world 12 My heart will go on");
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

        [Test]
        [Category("P1")]
        [Description("TextPageUtil GetText situation.")]
        [Property("SPEC", "Tizen.NUI.TextPageUtil.GetText situation M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TextPageUtilGetTextsituation()
        {
            tlog.Debug(tag, $"TextPageUtilGetTextsituation START");

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
                    testingTarget.GetText(-1);
                }
                catch (Exception e)
                {
                    tlog.Debug(tag, e.Message.ToString());
                    Assert.Fail("Caught Exception: Failed!");
                }
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"TextPageUtilGetTextsituation END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TextPageUtil PageData.")]
        [Property("SPEC", "Tizen.NUI.TextPageUtil.PageData A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TextPageUtilPageData()
        {
            tlog.Debug(tag, $"TextPageUtilPageData START");

            var testingTarget = new PageData();

            testingTarget.PreviousTag = "previous";
            tlog.Debug(tag, "PreviousTag : " + testingTarget.PreviousTag);

            testingTarget.EndTag = "end";
            tlog.Debug(tag, "EndTag : " + testingTarget.EndTag);

            testingTarget.StartOffset = 0;
            tlog.Debug(tag, "StartOffset : " + testingTarget.StartOffset);

            testingTarget.EndOffset = 2;
            tlog.Debug(tag, "EndOffset : " + testingTarget.EndOffset);

            tlog.Debug(tag, $"TextPageUtilPageData END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TextPageUtil TagData.")]
        [Property("SPEC", "Tizen.NUI.TextPageUtil.TagData A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TextPageUtilTagData()
        {
            tlog.Debug(tag, $"TextPageUtilTagData START");

            var testingTarget = new TagData();

            testingTarget.TagName = "tag";
            tlog.Debug(tag, "TagName : " + testingTarget.TagName);

            testingTarget.AttributeName = "size";
            tlog.Debug(tag, "AttributName : " + testingTarget.AttributeName);

            testingTarget.IsEndTag = true;
            tlog.Debug(tag, "IsEndTag" + testingTarget.IsEndTag);

            tlog.Debug(tag, $"TextPageUtilTagData END (OK)");
        }
    }
}
