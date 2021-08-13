using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("internal/Common/StringToVoidSignal")]
    public class InternalStringToVoidSignalTest
    {
        private const string tag = "NUITEST";

        private delegate bool dummyCallback(IntPtr signal);
        private bool OnDummyCallback(IntPtr data)
        {
            return false;
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
        [Description("StringToVoidSignal constructor.")]
        [Property("SPEC", "Tizen.NUI.StringToVoidSignal.StringToVoidSignal C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void StringToVoidSignalConstructor()
        {
            tlog.Debug(tag, $"StringToVoidSignalConstructor START");

            var testingTarget = new StringToVoidSignal();
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<StringToVoidSignal>(testingTarget, "Should be an Instance of StringToVoidSignal!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"StringToVoidSignalConstructor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("StringToVoidSignal Empty.")]
        [Property("SPEC", "Tizen.NUI.StringToVoidSignal.Empty M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void StringToVoidSignalEmpty()
        {
            tlog.Debug(tag, $"StringToVoidSignalEmpty START");
            
            using (TextLabel label = new TextLabel())
            {
                label.Text = "TextLabel";
                var testingTarget = new StringToVoidSignal(label.SwigCPtr.Handle, false);
                Assert.IsNotNull(testingTarget, "Should be not null!");
                Assert.IsInstanceOf<StringToVoidSignal>(testingTarget, "Should be an Instance of StringToVoidSignal!");

                try
                {
                    testingTarget.Empty();
                }
                catch (Exception e)
                {
                    tlog.Debug(tag, e.Message.ToString());
                    Assert.Fail("Caught Exception: Failed!");
                }

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"StringToVoidSignalEmpty END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("StringToVoidSignal GetConnectionCount.")]
        [Property("SPEC", "Tizen.NUI.StringToVoidSignal.GetConnectionCount M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void StringToVoidSignalGetConnectionCount()
        {
            tlog.Debug(tag, $"StringToVoidSignalGetConnectionCount START");

            using (TextLabel label = new TextLabel())
            {
                label.Text = "TextLabel";
                var testingTarget = new StringToVoidSignal(label.SwigCPtr.Handle, false);
                Assert.IsNotNull(testingTarget, "Should be not null!");
                Assert.IsInstanceOf<StringToVoidSignal>(testingTarget, "Should be an Instance of StringToVoidSignal!");

                try
                {
                    testingTarget.GetConnectionCount();
                }
                catch (Exception e)
                {
                    tlog.Debug(tag, e.Message.ToString());
                    Assert.Fail("Caught Exception: Failed!");
                }

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"StringToVoidSignalGetConnectionCount END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("StringToVoidSignal GetResult.")]
        [Property("SPEC", "Tizen.NUI.StringToVoidSignal.GetResult M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void StringToVoidSignalGetResult()
        {
            tlog.Debug(tag, $"StringToVoidSignalGetResult START");

            using (TextLabel label = new TextLabel())
            {
                label.Text = "TextLabel";
                try
                {
                    var result = StringToVoidSignal.GetResult(label.SwigCPtr.Handle);
                    tlog.Debug(tag, "GetResult : " + result);
                }
                catch (Exception e)
                {
                    tlog.Debug(tag, e.Message.ToString());
                    Assert.Fail("Cuaght Exception: Failed!");
                }
            }

            tlog.Debug(tag, $"StringToVoidSignalGetResult END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("StringToVoidSignal SetResult.")]
        [Property("SPEC", "Tizen.NUI.StringToVoidSignal.SetResult M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void StringToVoidSignalSetResult()
        {
            tlog.Debug(tag, $"StringToVoidSignalSetResult START");

            using (TextLabel label = new TextLabel())
            {
                label.Text = "";
                try
                {
                    StringToVoidSignal.SetResult(label.SwigCPtr.Handle, "TextLabel");
                    tlog.Debug(tag, "GetResult : " + StringToVoidSignal.GetResult(label.SwigCPtr.Handle));
                }
                catch (Exception e)
                {
                    tlog.Debug(tag, e.Message.ToString());
                    Assert.Fail("Cuaght Exception: Failed!");
                }
            }

            tlog.Debug(tag, $"StringToVoidSignalSetResult END (OK)");
        }
    }
}
