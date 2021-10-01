using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("internal/Common/CustomAlgorithmInterface")]
    public class InternalCustomAlgorithmInterfaceTest
    {
        private const string tag = "NUITEST";

        internal class MyCustomAlgorithmInterface : CustomAlgorithmInterface
        {
            public MyCustomAlgorithmInterface() : base()
            { }

            public override View GetNextFocusableView(View current, View proposed, View.FocusDirection direction)
            {
                return base.GetNextFocusableView(current, proposed, direction);
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
        [Description("CustomAlgorithmInterface constructor.")]
        [Property("SPEC", "Tizen.NUI.CustomAlgorithmInterface.CustomAlgorithmInterface C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void CustomAlgorithmInterfaceConstructor()
        {
            tlog.Debug(tag, $"CustomAlgorithmInterfaceConstructor START");

            var testingTarget = new CustomAlgorithmInterface();
            Assert.IsNotNull(testingTarget, "Can't create success object CustomAlgorithmInterface");
            Assert.IsInstanceOf<CustomAlgorithmInterface>(testingTarget, "Should be an instance of CustomAlgorithmInterface type.");

            testingTarget.Dispose();

            tlog.Debug(tag, $"CustomAlgorithmInterfaceConstructor END (OK)");
        }
    }
}
