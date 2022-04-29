using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Components.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("Controls/Loading")]
    public class LoadingTest
    {
        private const string tag = "NUITEST";
        private string path = Tizen.Applications.Application.Current.DirectoryInfo.Resource + "picture.png";

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
        [Description("Loading ImageList.")]
        [Property("SPEC", "Tizen.NUI.Components.Loading.ImageList A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void LoadingImageList()
        {
            tlog.Debug(tag, $"LoadingImageList START");

            string[] imageArray = new string[36];
            for (int i = 0; i < 36; i++)
            {

                imageArray[i] = path;

            }

            var testingTarget = new Loading()
            {
                Size = new Size(100, 100),
                Margin = new Extents(200, 0, 0, 0),
                ImageArray = imageArray
            };
            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<Loading>(testingTarget, "should be an instance of testing target class!");

            var result = testingTarget.ImageList;
            tlog.Debug(tag, "Count : " + result.Count);

            testingTarget.Dispose();
            tlog.Debug(tag, $"LoadingImageList END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Loading Play.")]
        [Property("SPEC", "Tizen.NUI.Components.Loading.Play M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void LoadingPlay()
        {
            tlog.Debug(tag, $"LoadingPlay START");

            string[] imageArray = new string[36];
            for (int i = 0; i < 36; i++)
            {

                imageArray[i] = path;

            }

            var testingTarget = new Loading()
            {
                Size = new Size(100, 100),
                Margin = new Extents(200, 0, 0, 0),
                ImageArray = imageArray
            };
            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<Loading>(testingTarget, "should be an instance of testing target class!");

            try
            {
                testingTarget.Play();
                testingTarget.Pause();
                testingTarget.Play();
                testingTarget.Stop();
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"LoadingPlay END (OK)");
        }
    }
}
