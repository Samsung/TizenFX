using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("internal/Common/RefObject")]
    public class InternalRefObjectTest
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
        [Description("RefObject constructor.")]
        [Property("SPEC", "Tizen.NUI.RefObject.RefObject M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void RefObjectConstructor()
        {
            tlog.Debug(tag, $"RefObjectConstructor START");

            using (View view = new View() { Size = new Size(20, 30) })
            {
                var testingTarget = new RefObject(view.SwigCPtr.Handle, false);
                Assert.IsNotNull(testingTarget, "null handle");
                Assert.IsInstanceOf<RefObject>(testingTarget, "Should return RefObject instance.");
                
                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"RefObjectConstructor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("RefObject Reference.")]
        [Property("SPEC", "Tizen.NUI.RefObject.Reference C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void RefObjectReference()
        {
            tlog.Debug(tag, $"RefObjectReference START");

            using (View view = new View() { Size = new Size(20, 30) })
            {
                var testingTarget = new RefObject(view.SwigCPtr.Handle, false);
                Assert.IsNotNull(testingTarget, "null handle");
                Assert.IsInstanceOf<RefObject>(testingTarget, "Should return RefObject instance.");

                try
                {
                    testingTarget.Reference();
                    tlog.Debug(tag, "ReferenceCount : " + testingTarget.ReferenceCount());

                    testingTarget.Unreference();
                }
                catch (Exception e)
                {
                    tlog.Debug(tag, e.Message.ToString());
                    Assert.Fail("Caught Exception : Failed!");
                }

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"RefObjectReference END (OK)");
        }
    }
}
