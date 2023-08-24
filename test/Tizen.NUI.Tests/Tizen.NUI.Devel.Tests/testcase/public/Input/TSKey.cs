using NUnit.Framework;
using NUnit.Framework.TUnit;
using System;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("public/Input/Key")]
    internal class PublicKeyTest
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
        [Description("Create a Key object.")]
        [Property("SPEC", "Tizen.NUI.Key.Key C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void KeyConstructor()
        {
            tlog.Debug(tag, $"KeyConstructor START");
            Key a1 = new Key("keyName", "keyString", 97, 90, 100000, Key.StateType.Down);
            a1.Dispose();
            tlog.Debug(tag, $"KeyConstructor END (OK)");
            Assert.Pass("KeyConstructor");
        }

        [Test]
        [Category("P1")]
        [Description("Key LogicalKey")]
        [Property("SPEC", "Tizen.NUI.Key.LogicalKey A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void KeyLogicalKey()
        {
            tlog.Debug(tag, $"KeyLogicalKey START");
            Key a1 = new Key();
            string b1 = a1.LogicalKey;
            a1.Dispose();
            tlog.Debug(tag, $"KeyLogicalKey END (OK)");
            Assert.Pass("KeyLogicalKey");
        }

        [Test]
        [Category("P1")]
        [Description("Key KeyPressed")]
        [Property("SPEC", "Tizen.NUI.Key.KeyPressed A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void KeyKeyPressed()
        {
            tlog.Debug(tag, $"KeyKeyPressed START");
            Key a1 = new Key();
            string b1 = a1.KeyPressed;
            a1.Dispose();
            tlog.Debug(tag, $"KeyKeyPressed END (OK)");
            Assert.Pass("KeyKeyPressed");
        }

        [Test]
        [Category("P1")]
        [Description("Key KeyString")]
        [Property("SPEC", "Tizen.NUI.Key.KeyString A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void KeyKeyString()
        {
            tlog.Debug(tag, $"KeyKeyString START");
            Key a1 = new Key();
            string b1 = a1.KeyString;
            a1.Dispose();
            tlog.Debug(tag, $"KeyKeyString END (OK)");
            Assert.Pass("KeyKeyString");
        }

        [Test]
        [Category("P1")]
        [Description("Key KeyModifier")]
        [Property("SPEC", "Tizen.NUI.Key.KeyModifier A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void KeyKeyModifier()
        {
            tlog.Debug(tag, $"KeyKeyModifier START");
            Key a1 = new Key();
            int b1 = a1.KeyModifier;
            a1.Dispose();
            tlog.Debug(tag, $"KeyKeyModifier END (OK)");
            Assert.Pass("KeyKeyModifier");
        }

        [Test]
        [Category("P1")]
        [Description("Key Time")]
        [Property("SPEC", "Tizen.NUI.Key.Time A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void KeyTime()
        {
            tlog.Debug(tag, $"KeyTime START");
            Key a1 = new Key
            {
                Time = 1000
            };

            a1.Dispose();
            tlog.Debug(tag, $"KeyTime END (OK)");
            Assert.Pass("KeyTime");
        }

        [Test]
        [Category("P1")]
        [Description("Key GetKeyFromPtr")]
        [Property("SPEC", "Tizen.NUI.Key.GetKeyFromPtr M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void KeyGetKeyFromPtr()
        {
            tlog.Debug(tag, $"KeyGetKeyFromPtr START");
            Key a1 = new Key();

            Key b1 = Key.GetKeyFromPtr(a1.SwigCPtr.Handle);

            b1.Dispose();
            a1.Dispose();
            tlog.Debug(tag, $"KeyGetKeyFromPtr END (OK)");
            Assert.Pass("KeyGetKeyFromPtr");
        }
    }

}