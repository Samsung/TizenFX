using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("internal/Common/NUIEventType")]
    public class NUIEventTypeTests
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
        [Description("NUIEventType constructor.")]
        [Property("SPEC", "Tizen.NUI.NUIEventType.NUIEventType C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void NUIEventType_INIT()
        {
            tlog.Debug(tag, $"NUIEventTypeConstructor START");
			
            var nuiEventType = new NUIEventType("TimeTick");

            Assert.IsNotNull(nuiEventType, "Can't create success object NUIEventType");
            Assert.IsInstanceOf<NUIEventType>(nuiEventType, "Should be an instance of NUIEventType type.");
			
			tlog.Debug(tag, $"NUIEventTypeConstructor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("NUIEventType TimeTick.")]
        [Property("SPEC", "Tizen.NUI.NUIEventType.TimeTick A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TimeTick_GET_VALUE()
        {
            tlog.Debug(tag, $"NUIEventTypeTimeTick START");
			
            var nuiEventType = NUIEventType.TimeTick;
            Assert.IsInstanceOf<NUIEventType>(nuiEventType, "Should be an instance of NUIEventType type.");
            Assert.AreEqual(NUIEventType.TimeTick, nuiEventType, "Should be equal!");
			
			tlog.Debug(tag, $"NUIEventTypeTimeTick END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("NUIEventType AmbientTick.")]
        [Property("SPEC", "Tizen.NUI.NUIEventType.AmbientTick A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void NUIEventTypeAmbientTick()
        {
            tlog.Debug(tag, $"NUIEventTypeAmbientTick START");
			
            var nuiEventType = NUIEventType.AmbientTick;
            Assert.IsInstanceOf<NUIEventType>(nuiEventType, "Should be an instance of NUIEventType type.");
            Assert.AreEqual(NUIEventType.AmbientTick, nuiEventType, "Should be equal!");
			
			tlog.Debug(tag, $"NUIEventTypeAmbientTick END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("NUIEventType AmbientChanged.")]
        [Property("SPEC", "Tizen.NUI.NUIEventType.AmbientChanged A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void NUIEventTypeAmbientChanged()
        {
            tlog.Debug(tag, $"NUIEventTypeAmbientChanged START");
			
            var nuiEventType = NUIEventType.AmbientChanged;
            Assert.IsInstanceOf<NUIEventType>(nuiEventType, "Should be an instance of NUIEventType type.");
            Assert.AreEqual(NUIEventType.AmbientChanged, nuiEventType, "Should be equal!");
			
			tlog.Debug(tag, $"NUIEventTypeAmbientChanged END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("NUIEventType implicit string.")]
        [Property("SPEC", "Tizen.NUI.NUIEventType.implicit M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "string")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void NUIEventTypeImplicit()
        {
            tlog.Debug(tag, $"NUIEventTypeImplicit START");
			
            NUIEventType nuiEventType = "TimeTick";
            Assert.IsInstanceOf<NUIEventType>(nuiEventType, "Should be an instance of NUIEventType type.");
			
			tlog.Debug(tag, $"NUIEventTypeImplicit END (OK)");
        }
    }
}
