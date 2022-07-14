﻿using NUnit.Framework;
using System;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Xaml;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("internal/Xaml/ResourcesLoader")]
    public class InternalResourcesLoaderTest
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
        [Description("ResourcesLoader GetResource")]
        [Property("SPEC", "Tizen.NUI.Xaml.ResourcesLoader.GetResource M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        public void ResourcesLoaderGetResourceTest()
        {
            tlog.Debug(tag, $"ResourcesLoaderGetResourceTest START");

            try
            {
                var rl = new ResourcesLoader();
                var ret = rl.GetResource("layout/TotalSample.xaml", typeof(UIElement).Assembly, null, null);
                Assert.IsNotNull(ret, "Should not be null");
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            tlog.Debug(tag, $"ResourcesLoaderGetResourceTest END");
        }
    }
}