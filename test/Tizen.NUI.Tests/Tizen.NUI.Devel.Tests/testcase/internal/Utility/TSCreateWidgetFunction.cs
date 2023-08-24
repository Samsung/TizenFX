using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("Internal/Utility/CreateWidgetFunction")]
    public class InternalCreateWidgetFunctionTest
    {
        private const string tag = "NUITEST";

        internal class MyCreateWidgetFunction : CreateWidgetFunction
        {
            public MyCreateWidgetFunction() : base()
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
        [Description("CreateWidgetFunction constructor.")]
        [Property("SPEC", "Tizen.NUI.CreateWidgetFunction.CreateWidgetFunction C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void CreateWidgetFunctionConstructor()
        {
            tlog.Debug(tag, $"CreateWidgetFunctionConstructor START");

            var testingTarget = new MyCreateWidgetFunction();
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<CreateWidgetFunction>(testingTarget, "Should be an Instance of CreateWidgetFunction!");

            tlog.Debug(tag, $"CreateWidgetFunctionConstructor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("CreateWidgetFunction constructor. With IntPtr.")]
        [Property("SPEC", "Tizen.NUI.CreateWidgetFunction.CreateWidgetFunction C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void CreateWidgetFunctionConstructorWithIntPtr()
        {
            tlog.Debug(tag, $"CreateWidgetFunctionConstructorWithIntPtr START");

            using (View view = new View())
            {
                var testingTarget = new CreateWidgetFunction(view.SwigCPtr.Handle);
                Assert.IsNotNull(testingTarget, "Should be not null!");
                Assert.IsInstanceOf<CreateWidgetFunction>(testingTarget, "Should be an Instance of CreateWidgetFunction!");
            }

            tlog.Debug(tag, $"CreateWidgetFunctionConstructorWithIntPtr END (OK)");
        }
    }
}
