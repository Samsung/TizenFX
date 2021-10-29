using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Binding;

namespace Tizen.NUI.Components.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("Style/DialogPage")]
    public class DialogPageTest
    {
        private const string tag = "NUITEST";

        internal class MyDialogPage : DialogPage
        {
            public MyDialogPage() : base()
            { }

            public void OnDispose(DisposeTypes types)
            {
                base.Dispose(types);
            }
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
        [Description("DialogPage Dispose.")]
        [Property("SPEC", "Tizen.NUI.Components.DialogPage.Dispose M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void DialogPageDispose()
        {
            tlog.Debug(tag, $"DialogPageDispose START");

            var testingTarget = new MyDialogPage();
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<DialogPage>(testingTarget, "Should return DialogPage instance.");

            View content = new View() { BackgroundColor = Color.Black };
            testingTarget.Content = content;

            try
            {
                testingTarget.OnDispose(DisposeTypes.Explicit);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caugth Exception : Failed!");
            }
            
            tlog.Debug(tag, $"DialogPageDispose END (OK)");
        }
    }
}
