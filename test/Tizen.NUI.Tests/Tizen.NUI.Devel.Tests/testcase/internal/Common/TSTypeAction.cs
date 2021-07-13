using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("internal/Common/TypeAction")]
    public class InternalTypeActionTest
    {
        private const string tag = "NUITEST";

        private delegate void dummyCallback();
        private void OnDummyCallback()
        { }

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
        [Description("TypeAction construcotr.")]
        [Property("SPEC", "Tizen.NUI.TypeAction.TypeAction C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TypeActionConstrucotr()
        {
            tlog.Debug(tag, $"TypeActionConstrucotr START");

            using (Animatable ani = new Animatable())
            {
                var registered = new TypeRegistration((global::System.IntPtr)ani.SwigCPtr, false);

                using (PropertyMap map = new PropertyMap())
                {
                    var f = new SWIGTYPE_p_f_p_Dali__BaseObject_r_q_const__std__string_r_q_const__Dali__Property__Map__bool(map.SwigCPtr.Handle);

                    var testingTarget = new TypeAction(registered, "ani", f);
                    Assert.IsNotNull(testingTarget, "Can't create success object TypeAction.");
                    Assert.IsInstanceOf<TypeAction>(testingTarget, "Should return TypeAction instance.");

                    testingTarget.Dispose();
                }
            }

            tlog.Debug(tag, $"TypeActionConstrucotr END (OK)");
        }
    }
}
