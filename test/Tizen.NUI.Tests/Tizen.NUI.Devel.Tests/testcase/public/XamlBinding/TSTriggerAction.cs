using NUnit.Framework;
using System;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Binding;
using Tizen.NUI.Xaml;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("public/XamlBinding/TriggerAction")]
    internal class PublicTriggerActionTest
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

        public class TriggerActionImpl<T> : TriggerAction<T> where T : BindableObject
        {
            Type type;

            protected override void Invoke(T sender)
            {
                type = AssociatedType;
            }
        }

        [Test]
        [Category("P1")]
        [Description("TriggerAction TriggerAction")]
        [Property("SPEC", "Tizen.NUI.Binding.TriggerAction.TriggerAction C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        public void TriggerActionConstructor()
        {
            tlog.Debug(tag, $"TriggerActionConstructor START");

            try
            {
                TriggerActionImpl<View> t2 = new TriggerActionImpl<View>();
                Assert.IsNotNull(t2, "null TriggerAction");
                Assert.IsInstanceOf<TriggerActionImpl<View>>(t2, "Should return TriggerActionImpl<View> instance.");
                t2.DoInvoke(null);
            }
            catch (Exception e)
            {
                Assert.Fail("Caught Exception" + e.ToString());
            }

            tlog.Debug(tag, $"TriggerActionConstructor END");
        }

    }
}