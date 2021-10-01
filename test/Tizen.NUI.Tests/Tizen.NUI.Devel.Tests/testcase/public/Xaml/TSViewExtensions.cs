using NUnit.Framework;
using System;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Xaml;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("public/xaml/ViewExtensions")]
    public class PublicViewExtensionsTest
    {
        private const string tag = "NUITEST";

        string content = "<?xml version=\"1.0\" encoding=\"UTF-8\" ?>" +
                             "\r\n<View x:Class=\"Tizen.NUI.Devel.Tests.TotalSample\"" +
                             "\r\n        xmlns=\"http://tizen.org/Tizen.NUI/2018/XAML\"" +
                             "\r\n        xmlns:x=\"http://schemas.microsoft.com/winfx/2009/xaml\" >" +
                             "\r\n" +
                             "\r\n  <View Size=\"100,100\" Position=\"10,10\" Margin=\"1,2,3,4\" BackgroundColor=\"Red\" ParentOrigin=\"TopLeft\" PivotPoint=\"TopLeft\" PositionUsesPivotPoint=\"true\"/>" +
                             "\r\n  <TextLabel Size2D=\"100,100\" Position2D=\"10,110\" Text=\"text label\" PointSize=\"8\" TextColor=\"Red\" MultiLine=\"True\" LineWrapMode=\"Character\" WidthSpecification=\"-1\" HeightSpecification=\"-2\" />" +
                             "\r\n  <ImageView ResourceUrl=\"*Resource*/button_9patch.png\" Border=\"1,1,1,1\" Size=\"100,100\" Position=\"10,210\" PixelArea=\"0.1,0.0,0.4,0.6\" />" +
                             "\r\n</View>";

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
        [Category("P2")]
        [Description("Extensions LoadFromXaml")]
        [Property("SPEC", "Tizen.NUI.Xaml.Extensions.LoadFromXaml M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "string,Type")]
        public void ExtensionsLoadFromXaml1()
        {
            tlog.Debug(tag, $"ExtensionsLoadFromXaml1 START");

            try
            {
                Tizen.NUI.Xaml.Extensions.LoadFromXaml<string>("mystring", typeof(string)); //XamlParseException e.Message: Can't find type System.String in embedded resource
                Assert.True(true, "Should go here!");
            }
            catch (XamlParseException e)
            {
                Tizen.Log.Error(tag, "Caught Exception" + e.ToString());
                Assert.True(true, "Caught Exception" + e.ToString());
            }
            tlog.Debug(tag, $"ExtensionsLoadFromXaml1 END");
        }

        [Test]
        [Category("P1")]
        [Description("Extensions LoadFromXamlPath.")]
        [Property("SPEC", "Tizen.NUI.Xaml.Extensions.LoadFromXamlPath M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "TXaml,Type")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ExtensionsLoadFromXaml2()
        {
            tlog.Debug(tag, $"ExtensionsLoadFromXaml2 START");

            try
            {
                var testcase = new TotalSample();
                Assert.True(true, "Should go here!");
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                tlog.Debug(tag, e.StackTrace);
                Assert.Fail("Caught Exception: Failed!");
            }

            tlog.Debug(tag, $"ExtensionsLoadFromXaml2 END");
        }

        [Test]
        [Category("P1")]
        [Description("Extensions LoadFromXaml")]
        [Property("SPEC", "Tizen.NUI.Xaml.Extensions.LoadFromXaml M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "TXaml,string")]
        public void ExtensionsLoadFromXaml3()
        {
            tlog.Debug(tag, $"ExtensionsLoadFromXaml3 START");
            try
            {
                View view = new View();
                Tizen.NUI.Xaml.Extensions.LoadFromXaml<View>(view, content);
                Assert.True(true, "Should go here!");
            }
            catch (Exception e)
            {
                Assert.Fail("Caught Exception" + e.ToString());
            }

            tlog.Debug(tag, $"ExtensionsLoadFromXaml3 END");
        }

        [Test]
        [Category("P1")]
        [Description("Extensions LoadFromXaml.")]
        [Property("SPEC", "Tizen.NUI.Xaml.Extensions.LoadFromXaml M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "TXaml,Type")]
        public void ExtensionsLoadFromXaml4()
        {
            tlog.Debug(tag, $"ExtensionsLoadFromXaml4 START");

            try
            {
                var testcase = new XamlStyleSample();
                Assert.True(true, "Should go here!");
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                tlog.Debug(tag, e.StackTrace);
                Assert.Fail("Caught Exception: Failed!");
            }

            tlog.Debug(tag, $"ExtensionsLoadFromXaml4 END");
        }

        [Test]
        [Category("P2")]
        [Description("Extensions LoadFromXaml")]
        [Property("SPEC", "Tizen.NUI.Xaml.Extensions.LoadFromXaml M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "TXaml,string")]
        public void ExtensionsLoadFromXaml5()
        {
            tlog.Debug(tag, $"ExtensionsLoadFromXaml5 START");
            string content = "<?xml version=\"1.0\" encoding=\"UTF-8\" ?>" +
                             "\r\n<View x:Class=\"Tizen.NUI.Tests.TotalSample\"" +
                             "\r\n        xmlns=\"http://tizen.org/Tizen.NUI/2018/XAML\"" +
                             "\r\n        xmlns:x=\"http://schemas.microsoft.com/winfx/2009/xaml\" >" +
                             "\r\n" +
                             "\r\n  <View Size=\"100,100\" Position=\"10,10\" MarginX=\"1,2,3,4\" BackgroundColor=\"Red\" />" +
                             "\r\n</View>";
            try
            {
                View view = new View();
                Tizen.NUI.Xaml.Extensions.LoadFromXaml<View>(view, content); //MarginX don't exist
                Assert.True(true, "Should not go here");
            }
            catch (XamlParseException e)
            {
                tlog.Fatal(tag, "Caught Exception" + e.ToString());
                Assert.True(true, "Should throw exception");
            }

            tlog.Debug(tag, $"ExtensionsLoadFromXaml5 END");
        }

        [Test]
        [Category("P1")]
        [Description("Extensions LoadFromXaml.")]
        [Property("SPEC", "Tizen.NUI.Xaml.Extensions.LoadFromXaml M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "TXaml,Type")]
        public void ExtensionsLoadFromXaml6()
        {
            tlog.Debug(tag, $"ExtensionsLoadFromXaml6 START");

            try
            {
                var testcase = new BindingSample();
                Assert.True(true, "Should go here!");
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                tlog.Debug(tag, e.StackTrace);
                Assert.Fail("Caught Exception: Failed!");
            }

            tlog.Debug(tag, $"ExtensionsLoadFromXaml6 END");
        }

        [Test]
        [Category("P1")]
        [Description("Extensions LoadFromXaml.")]
        [Property("SPEC", "Tizen.NUI.Xaml.Extensions.LoadFromXaml M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "TXaml,Type")]
        public void ExtensionsLoadFromXaml7()
        {
            tlog.Debug(tag, $"ExtensionsLoadFromXaml7 START");

            try
            {
                var testcase = new ClockView();
                Assert.True(true, "Should go here!");
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                tlog.Debug(tag, e.StackTrace);
                Assert.Fail("Caught Exception: Failed!");
            }

            tlog.Debug(tag, $"ExtensionsLoadFromXaml7 END");
        }

        [Test]
        [Category("P1")]
        [Description("Extensions LoadFromXaml.")]
        [Property("SPEC", "Tizen.NUI.Xaml.Extensions.LoadFromXaml M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "TXaml,Type")]
        public void ExtensionsLoadFromXaml8()
        {
            tlog.Debug(tag, $"ExtensionsLoadFromXaml8 START");

            try
            {
                var testcase = new HslColorScrollView();
                Assert.True(true, "Should go here!");
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                tlog.Debug(tag, e.StackTrace);
                Assert.Fail("Caught Exception: Failed!");
            }

            tlog.Debug(tag, $"ExtensionsLoadFromXaml8 END");
        }

        [Test]
        [Category("P1")]
        [Description("Extensions LoadFromXaml.")]
        [Property("SPEC", "Tizen.NUI.Xaml.Extensions.LoadFromXaml M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "TXaml,Type")]
        public void ExtensionsLoadFromXaml9()
        {
            tlog.Debug(tag, $"ExtensionsLoadFromXaml9 START");

            try
            {
                var testcase = new StaticDateTimeView();
                Assert.True(true, "Should go here!");
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                tlog.Debug(tag, e.StackTrace);
                Assert.Fail("Caught Exception: Failed!");
            }

            tlog.Debug(tag, $"ExtensionsLoadFromXaml9 END");
        }

        [Test]
        [Category("P1")]
        [Description("Extensions LoadObject")]
        [Property("SPEC", "Tizen.NUI.Xaml.Extensions.LoadObject M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        public void ExtensionsLoadObject1()
        {
            tlog.Debug(tag, $"ExtensionsLoadObject1 START");
            try
            {
                string res = global::Tizen.Applications.Application.Current.DirectoryInfo.Resource;
                Tizen.NUI.Xaml.Extensions.LoadObject<View>(res + "/layout/BaseXamlSample.xaml");
                Assert.True(true, "Should go here");
            }
            catch (XamlParseException e)
            {
                tlog.Fatal(tag, "Caught Exception" + e.ToString());
                Assert.False(true, "Caught Exception" + e.ToString());
            }
            tlog.Debug(tag, $"ExtensionsLoadObject1 END");
        }

        [Test]
        [Category("P2")]
        [Description("Extensions LoadObject")]
        [Property("SPEC", "Tizen.NUI.Xaml.Extensions.LoadObject M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        public void ExtensionsLoadObject2()
        {
            tlog.Debug(tag, $"ExtensionsLoadObject2 START");
            string content = "<?xml version=\"1.0\" encoding=\"UTF-8\" ?>" +
                             "\r\n<View x:Class=\"Tizen.NUI.Tests.TotalSample\"" +
                             "\r\n        xmlns=\"http://tizen.org/Tizen.NUI/2018/XAML\"" +
                             "\r\n        xmlns:x=\"http://schemas.microsoft.com/winfx/2009/xaml\" >" +
                             "\r\n" +
                             "\r\n  <View Size=\"100,100\" Position=\"10,10\" Margin=\"1,2,3,4\" BackgroundColor=\"Red\" ParentOrigin=\"TopLeft\" PivotPoint=\"TopLeft\" PositionUsesPivotPoint=\"true\"/>" +
                             "\r\n</View>";
            try
            {
                Tizen.NUI.Xaml.Extensions.LoadObject<string>("mypath");
                Assert.Fail("Should not go here");
            }
            catch (XamlParseException e)
            {
                tlog.Fatal(tag, "Caught Exception" + e.ToString());
                Assert.True(true, "Caught Exception" + e.ToString());
            }
            tlog.Debug(tag, $"ExtensionsLoadObject2 END");
        }

        [Test]
        [Category("P1")]
        [Description("Extensions LoadFromXamlFile")]
        [Property("SPEC", "Tizen.NUI.Xaml.Extensions.LoadFromXamlFile M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        public void ExtensionsLoadFromXamlFile()
        {
            tlog.Debug(tag, $"ExtensionsLoadFromXamlFile START");
            try
            {
                View view = new View();
                Tizen.NUI.Xaml.Extensions.LoadFromXamlFile<View>(view, "BaseXamlSample");
                Assert.True(true, "Should go here");
            }
            catch (Exception e)
            {
                Assert.Fail("Caught Exception" + e.ToString());
            }

            tlog.Debug(tag, $"ExtensionsLoadFromXamlFile END");
        }

        [Test]
        [Category("P2")]
        [Description("Extensions LoadFromXamlFile")]
        [Property("SPEC", "Tizen.NUI.Xaml.Extensions.LoadFromXamlFile M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        public void ExtensionsLoadFromXamlFile2()
        {
            tlog.Debug(tag, $"ExtensionsLoadFromXamlFile2 START");
            try
            {
                Layer view = new Layer();
                Tizen.NUI.Xaml.Extensions.LoadFromXamlFile<Layer>(view, "BaseXamlSample2"); // new StringReader(null) will throw exception.
                Assert.Fail("Should not go here");
            }
            catch (ArgumentNullException e)
            {
                Assert.True(true, "Caught Exception" + e.ToString());
            }

            tlog.Debug(tag, $"ExtensionsLoadFromXamlFile2 END");
        }

        [Test]
        [Category("P1")]
        [Description("Extensions LoadFromXamlFile")]
        [Property("SPEC", "Tizen.NUI.Xaml.Extensions.LoadFromXamlFile M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        public void ExtensionsLoadFromXamlFile3()
        {
            tlog.Debug(tag, $"ExtensionsLoadFromXamlFile3 START");
            try
            {
                var view = new Layer();
                Tizen.NUI.Xaml.Extensions.LoadFromXamlFile<Layer>(view, "BaseXamlSample3");
                Assert.True(true, "Should go here");
            }
            catch (Exception e)
            {
                Assert.Fail("Caught Exception" + e.ToString());
            }

            tlog.Debug(tag, $"ExtensionsLoadFromXamlFile3 END");
        }
    }
}