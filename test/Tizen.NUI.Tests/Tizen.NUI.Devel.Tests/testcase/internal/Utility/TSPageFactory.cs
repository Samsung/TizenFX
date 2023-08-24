using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("Internal/Utility/PageFactory")]
    public class InternalPageFactoryTest
    {
        private const string tag = "NUITEST";

        internal class MyPageFactory : PageFactory
        {
            public MyPageFactory(global::System.IntPtr cPtr, bool cMemoryOwn) : base(cPtr, cMemoryOwn)
            { }
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
        [Description("PageFactory constructor.")]
        [Property("SPEC", "Tizen.NUI.PageFactory.PageFactory C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PageFactoryConstructor()
        {
            tlog.Debug(tag, $"PageFactoryConstructor START");

            using (View view = new View())
            {
                view.Size = new Size(20, 40);
                view.BackgroundColor = Color.Cyan;

                var testingTarget = new PageFactory(view.SwigCPtr.Handle, false);
                Assert.IsNotNull(testingTarget, "Should be not null!");
                Assert.IsInstanceOf<PageFactory>(testingTarget, "Should be an Instance of PageFactory!");

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"PageFactoryConstructor END (OK)");
        }
    }
}
