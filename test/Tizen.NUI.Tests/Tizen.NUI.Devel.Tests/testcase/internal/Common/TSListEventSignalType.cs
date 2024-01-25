using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("internal/Common/ListEventSignalType")]
    public class InternalListEventSignalTypeTest
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
        [Description("ListEventSignalType constructor.")]
        [Property("SPEC", "Tizen.NUI.ListEventSignalType.ListEventSignalType  C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ListEventSignalTypeConstructor()
        {
            tlog.Debug(tag, $"ListEventSignalTypeConstructor START");

            using (View view = new View())
            {
                var testingTarget = new ListEventSignalType (view.SwigCPtr.Handle, false);
                Assert.IsNotNull(testingTarget, "Should be not null!");
                Assert.IsInstanceOf<ListEventSignalType >(testingTarget, "Should be an Instance of ListEventSignalType !");

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"ListEventSignalTypeConstructor END (OK)");
        }
    }
}
