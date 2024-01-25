using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("internal/Common/PropertyRegistration")]
    public class InternalPropertyRegistrationTest
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
        [Description("PropertyRegistration constructor.")]
        [Property("SPEC", "Tizen.NUI.PropertyRegistration.PropertyRegistration C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PropertyRegistrationConstructor()
        {
            tlog.Debug(tag, $"PropertyRegistrationConstructor START");

            using (View view = new View())
            {

                TypeRegistration registration = new TypeRegistration(view.SwigCPtr.Handle, false);
                SWIGTYPE_p_f_p_Dali__BaseObject_int_r_q_const__Dali__Property__Value__void set = new SWIGTYPE_p_f_p_Dali__BaseObject_int_r_q_const__Dali__Property__Value__void(View.getCPtr(view).Handle);
                SWIGTYPE_p_f_p_Dali__BaseObject_Dali__Property__Index__Dali__Property__Value get = new SWIGTYPE_p_f_p_Dali__BaseObject_Dali__Property__Index__Dali__Property__Value(View.getCPtr(view).Handle);

                var testingTarget = new PropertyRegistration(registration, "mytest", 10000001, PropertyType.Float, set, get);
                Assert.IsNotNull(testingTarget, "null handle");
                Assert.IsInstanceOf<PropertyRegistration>(testingTarget, "Should return PropertyRegistration instance.");

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"PropertyRegistrationConstructor END (OK)");
        }
    }
}
