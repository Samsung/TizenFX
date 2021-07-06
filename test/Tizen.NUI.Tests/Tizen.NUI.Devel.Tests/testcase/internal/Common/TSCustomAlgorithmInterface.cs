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

        [Test]
        [Category("P1")]
        [Description("CustomAlgorithmInterface getCPtr.")]
        [Property("SPEC", "Tizen.NUI.CustomAlgorithmInterface.getCPtr M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void CustomAlgorithmInterfaceGetCPtr()
        {
            tlog.Debug(tag, $"CustomAlgorithmInterfaceGetCPtr START");

            var testingTarget = new CustomAlgorithmInterface();
            Assert.IsNotNull(testingTarget, "Can't create success object CustomAlgorithmInterface");
            Assert.IsInstanceOf<CustomAlgorithmInterface>(testingTarget, "Should be an instance of CustomAlgorithmInterface type.");

            try
            {
                CustomAlgorithmInterface.getCPtr(testingTarget);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            testingTarget.Dispose();

            tlog.Debug(tag, $"CustomAlgorithmInterfaceGetCPtr END (OK)");
        }

        //[Test]
        //[Category("P1")]
        //[Description("CustomAlgorithmInterface GetNextFocusableView.")]
        //[Property("SPEC", "Tizen.NUI.CustomAlgorithmInterface.GetNextFocusableView M")]
        //[Property("SPEC_URL", "-")]
        //[Property("CRITERIA", "MR")]
        //[Property("AUTHOR", "guowei.wang@samsung.com")]
        //public void CustomAlgorithmGetNextFocusableView()
        //{
        //    tlog.Debug(tag, $"CustomAlgorithmGetNextFocusableView START");

        //    var testingTarget = new MyCustomAlgorithmInterface();
        //    Assert.IsNotNull(testingTarget, "Can't create success object CustomAlgorithmInterface");
        //    Assert.IsInstanceOf<CustomAlgorithmInterface>(testingTarget, "Should be an instance of CustomAlgorithmInterface type.");

        //    using (View current = new View())
        //    {
        //        current.Size = new Size(2.0f, 4.0f);
        //        current.Position = new Position(0.0f, 0.0f);

        //        using (View proposed = new View())
        //        {
        //            proposed.Size = new Size(3.0f, 4.0f);
        //            proposed.Position = new Position(0.0f, 4.0f);

        //            try
        //            {
        //                testingTarget.GetNextFocusableView(current, proposed, View.FocusDirection.Down);
        //            }
        //            catch (Exception e)
        //            {
        //                tlog.Debug(tag, e.Message.ToString());
        //                Assert.Fail("Caught Exception : Failed!");
        //            }
        //        }
        //    }

        //    testingTarget.Dispose();
        //    tlog.Debug(tag, $"CustomAlgorithmGetNextFocusableView END (OK)");
        //}
    }
}
