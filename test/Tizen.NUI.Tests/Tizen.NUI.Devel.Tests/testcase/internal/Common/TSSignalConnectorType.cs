using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("internal/Common/SignalConnectorType")]
    public class InternalSignalConnectorTypeTest
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
        [Description("SignalConnectorType constructor.")]
        [Property("SPEC", "Tizen.NUI.SignalConnectorType.SignalConnectorType C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void SignalConnectorTypeConstructor()
        {
            tlog.Debug(tag, $"SignalConnectorTypeConstructor START");

            using (View view = new View())
            {
                using (TypeRegistration typeRegistration = new TypeRegistration(view.SwigCPtr.Handle, false))
                {
                    using (ImageView imageView = new ImageView())
                    {
                        SWIGTYPE_p_f_p_Dali__BaseObject_p_Dali__ConnectionTrackerInterface_r_q_const__std__string_p_Dali__FunctorDelegate__bool func = new SWIGTYPE_p_f_p_Dali__BaseObject_p_Dali__ConnectionTrackerInterface_r_q_const__std__string_p_Dali__FunctorDelegate__bool(imageView.SwigCPtr.Handle);
                        var testingTarget = new SignalConnectorType(typeRegistration, "View", func);
                        Assert.IsNotNull(testingTarget, "Should be not null!");
                        Assert.IsInstanceOf<SignalConnectorType>(testingTarget, "Should be an Instance of SignalConnectorType!");

                        testingTarget.Dispose();
                    }
                }
            }

            tlog.Debug(tag, $"SignalConnectorTypeConstructor END (OK)");
        }
    }
}
