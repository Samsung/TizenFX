using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("public/Xaml/MarkupExtensions/ThemeResourcePathExtension")]
    public class PublicThemeResourcePathExtensionTest
    {
        private const string tag = "NUITEST";
        private string filePath = Tizen.Applications.Application.Current.DirectoryInfo.Resource + "Test_Theme.xaml";

        internal class IServiceProviderImpl : IServiceProvider
        {
            public object GetService(Type serviceType) { return null; }
        }

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
        [Description("ThemeResourcePathExtension constructor.")]
        [Property("SPEC", "Tizen.NUI.ThemeResourcePathExtension.ThemeResourcePathExtension C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ThemeResourcePathExtensionConstructor()
        {
            tlog.Debug(tag, $"ThemeResourcePathExtensionConstructor START");

            var testingTarget = new Tizen.NUI.Xaml.ThemeResourcePathExtension();
            Assert.IsNotNull(testingTarget, "Can't create success object ThemeResourcePathExtension.");
            Assert.IsInstanceOf<Tizen.NUI.Xaml.ThemeResourcePathExtension>(testingTarget, "Should return ThemeResourcePathExtension instance.");

            testingTarget.FilePath = filePath;
            tlog.Error(tag, "FilePath : " + testingTarget.FilePath);

            var result = testingTarget.ProvideValue(new IServiceProviderImpl());
            tlog.Error(tag, "ProviderValue : " + result);

            testingTarget = null;
            tlog.Debug(tag, $"ThemeResourcePathExtensionConstructor END (OK)");
        }
    }
}
