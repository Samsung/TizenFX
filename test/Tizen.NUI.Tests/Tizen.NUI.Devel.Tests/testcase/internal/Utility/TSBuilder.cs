using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("Internal/Utility/Builder")]
    public class InternalBuilderTest
    {
        private const string tag = "NUITEST";
        private string path = Tizen.Applications.Application.Current.DirectoryInfo.Resource + "lottie.json";

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
        [Description("Builder constructor.")]
        [Property("SPEC", "Tizen.NUI.Builder.Builder C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void BuilderConstructor()
        {
            tlog.Debug(tag, $"BuilderConstructor START");

            var testingTarget = new Builder();
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<Builder>(testingTarget, "Should be an Instance of Builder!");

            testingTarget.Dispose();
            testingTarget = null;
            tlog.Debug(tag, $"BuilderConstructor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Builder Quit.")]
        [Property("SPEC", "Tizen.NUI.Builder.Quit A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void BuilderQuit()
        {
            tlog.Debug(tag, $"BuilderQuit START");

            var testingTarget = new Builder();
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<Builder>(testingTarget, "Should be an Instance of Builder!");

            testingTarget.Quit += MyOnQuit;
            testingTarget.Quit -= MyOnQuit;

            testingTarget.Dispose();
            testingTarget = null;
            tlog.Debug(tag, $"BuilderQuit END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Builder AddConstants.")]
        [Property("SPEC", "Tizen.NUI.Builder.AddConstants M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void BuilderAddConstants()
        {
            tlog.Debug(tag, $"BuilderAddConstants START");

            var testingTarget = new Builder();
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<Builder>(testingTarget, "Should be an Instance of Builder!");

            using (PropertyMap map = new PropertyMap())
            {
                map.Add("Size", new PropertyValue(new Size(20, 30)));
                map.Add("Posision", new PropertyValue(new Position(100, 200)));

                try
                {
                    testingTarget.AddConstants(map);
                }
                catch (Exception e)
                {
                    tlog.Debug(tag, e.Message.ToString());
                    Assert.Fail("Caught Exception: Failed!");
                }
            }

            testingTarget.Dispose();
            testingTarget = null;
            tlog.Debug(tag, $"BuilderAddConstants END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Builder AddConstant.")]
        [Property("SPEC", "Tizen.NUI.Builder.AddConstant M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void BuilderAddConstant()
        {
            tlog.Debug(tag, $"BuilderAddConstant START");

            var testingTarget = new Builder();
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<Builder>(testingTarget, "Should be an Instance of Builder!");

            try
            {
                testingTarget.AddConstant("Size", new PropertyValue(new Size(20, 30)));
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception: Failed!");
            }

            testingTarget.Dispose();
            testingTarget = null;
            tlog.Debug(tag, $"BuilderAddConstant END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Builder GetConstants.")]
        [Property("SPEC", "Tizen.NUI.Builder.GetConstants M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void BuilderGetConstants()
        {
            tlog.Debug(tag, $"BuilderGetConstants START");

            var testingTarget = new Builder();
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<Builder>(testingTarget, "Should be an Instance of Builder!");

            using (PropertyMap map = new PropertyMap())
            {
                map.Add("Size", new PropertyValue(new Size(20, 30)));
                map.Add("Posision", new PropertyValue(new Position(100, 200)));

                testingTarget.AddConstants(map);

                var result = testingTarget.GetConstants();
                Assert.IsNotNull(result, "Should be not null!");
                Assert.IsInstanceOf<PropertyMap>(result, "Should be an Instance of PropertyMap!");
            }

            testingTarget.Dispose();
            testingTarget = null;
            tlog.Debug(tag, $"BuilderGetConstants END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Builder GetConstan.")]
        [Property("SPEC", "Tizen.NUI.Builder.GetConstan M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void BuilderGetConstan()
        {
            tlog.Debug(tag, $"BuilderGetConstan START");

            var testingTarget = new Builder();
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<Builder>(testingTarget, "Should be an Instance of Builder!");

            testingTarget.AddConstant("Opacity", new PropertyValue(0.5f));

            var result = testingTarget.GetConstant("Opacity");
            Assert.IsNotNull(result, "Should be not null!");
            Assert.IsInstanceOf<PropertyValue>(result, "Should be an Instance of PropertyValue!");

            testingTarget.Dispose();
            testingTarget = null;
            tlog.Debug(tag, $"BuilderGetConstan END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Builder LoadFromFile.")]
        [Property("SPEC", "Tizen.NUI.Builder.LoadFromFile M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void BuilderLoadFromFile()
        {
            tlog.Debug(tag, $"BuilderLoadFromFile START");

            var testingTarget = new Builder();
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<Builder>(testingTarget, "Should be an Instance of Builder!");

            try
            {
                testingTarget.LoadFromFile(path);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception: Failed!");
            }

            testingTarget.Dispose();
            testingTarget = null;
            tlog.Debug(tag, $"BuilderLoadFromFile END (OK)");
        }

        [Test]
        [Category("P2")]
        [Description("Builder LoadFromFile. Parse failed.")]
        [Property("SPEC", "Tizen.NUI.Builder.LoadFromFile M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void BuilderLoadFromFileParseFailed()
        {
            tlog.Debug(tag, $"BuilderLoadFromFileParseFailed START");

            var testingTarget = new Builder();
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<Builder>(testingTarget, "Should be an Instance of Builder!");

            try
            {
                testingTarget.LoadFromFile(Tizen.Applications.Application.Current.DirectoryInfo.Resource + "index.xml");
            }
            catch (InvalidOperationException e)
            {
                tlog.Debug(tag, e.Message.ToString());
                testingTarget.Dispose();
                testingTarget = null;
                tlog.Debug(tag, $"BuilderLoadFromFileParseFailed END (OK)");
                Assert.Pass("Caught InvalidOperationException: Passed!");
            }
        }

        [Test]
        [Category("P1")]
        [Description("Builder LoadFromString.")]
        [Property("SPEC", "Tizen.NUI.Builder.LoadFromString M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void BuilderLoadFromString()
        {
            tlog.Debug(tag, $"BuilderLoadFromString START");

            var testingTarget = new Builder();
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<Builder>(testingTarget, "Should be an Instance of Builder!");

            try
            {
                testingTarget.LoadFromString("{\"sites\": [{ \"name\":\"caurse\" , \"url\":\"www.runoob.com\" }]}", Builder.UIFormat.JSON);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception: Failed!");
            }

            testingTarget.Dispose();
            testingTarget = null;
            tlog.Debug(tag, $"BuilderLoadFromString END (OK)");
        }

        //[Test]
        //[Category("P1")]
        //[Description("Builder Create.")]
        //[Property("SPEC", "Tizen.NUI.Builder.Create M")]
        //[Property("SPEC_URL", "-")]
        //[Property("CRITERIA", "MR")]
        //[Property("AUTHOR", "guowei.wang@samsung.com")]
        //public void BuilderCreate()
        //{
        //    tlog.Debug(tag, $"BuilderCreate START");

        //    var testingTarget = new Builder();
        //    Assert.IsNotNull(testingTarget, "Should be not null!");
        //    Assert.IsInstanceOf<Builder>(testingTarget, "Should be an Instance of Builder!");

        //    try
        //    {
        //        testingTarget.Create("{\"View\" : [\"Size\" : \"\"]}");
        //    }
        //    catch (Exception e)
        //    {
        //        tlog.Debug(tag, e.Message.ToString());
        //        Assert.Fail("Caught Exception: Failed!");
        //    }

        //    testingTarget.Dispose();
        //    testingTarget = null;
        //    tlog.Debug(tag, $"BuilderCreate END (OK)");
        //}

        private void MyOnQuit(object sender, EventArgs e)
        { 

        }
    }
}
