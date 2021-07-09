using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("internal/Common/StringValuePair")]
    public class InternalStringValuePairTest
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
        [Description("StringValuePair constructor.")]
        [Property("SPEC", "Tizen.NUI.StringValuePair.StringValuePair C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void StringValuePairConstructor()
        {
            tlog.Debug(tag, $"StringValuePairConstructor START");

            var testingTarget = new StringValuePair();
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<StringValuePair>(testingTarget, "Should be an Instance of TouchPoint!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"StringValuePairConstructor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("StringValuePair constructor. With String.")]
        [Property("SPEC", "Tizen.NUI.StringValuePair.StringValuePair C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void StringValuePairConstructorWithString()
        {
            tlog.Debug(tag, $"StringValuePairConstructorWithString START");

            var testingTarget = new StringValuePair("opacity", new PropertyValue(0.3f));
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<StringValuePair>(testingTarget, "Should be an Instance of TouchPoint!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"StringValuePairConstructorWithString END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("StringValuePair constructor. With StringValuePair.")]
        [Property("SPEC", "Tizen.NUI.StringValuePair.StringValuePair C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void StringValuePairConstructorWithStringValuePair()
        {
            tlog.Debug(tag, $"StringValuePairConstructorWithStringValuePair START");

            using (StringValuePair pair = new StringValuePair("opacity", new PropertyValue(0.3f)))
            {
                var testingTarget = new StringValuePair(pair);
                Assert.IsNotNull(testingTarget, "Should be not null!");
                Assert.IsInstanceOf<StringValuePair>(testingTarget, "Should be an Instance of TouchPoint!");

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"StringValuePairConstructorWithStringValuePair END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("StringValuePair constructor. first.")]
        [Property("SPEC", "Tizen.NUI.StringValuePair.first A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void StringValuePairConstructorFirst()
        {
            tlog.Debug(tag, $"StringValuePairConstructorFirst START");

            using (StringValuePair pair = new StringValuePair("opacity", new PropertyValue(0.3f)))
            {
                var testingTarget = new StringValuePair(pair);
                Assert.IsNotNull(testingTarget, "Should be not null!");
                Assert.IsInstanceOf<StringValuePair>(testingTarget, "Should be an Instance of TouchPoint!");

                testingTarget.first = "direction";
                Assert.AreEqual("direction", testingTarget.first, "Should be equal!");

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"StringValuePairConstructorFirst END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("StringValuePair constructor. second.")]
        [Property("SPEC", "Tizen.NUI.StringValuePair.second A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void StringValuePairConstructorSecond()
        {
            tlog.Debug(tag, $"StringValuePairConstructorSecond START");

            using (StringValuePair pair = new StringValuePair("opacity", new PropertyValue(0.3f)))
            {
                var testingTarget = new StringValuePair(pair);
                Assert.IsNotNull(testingTarget, "Should be not null!");
                Assert.IsInstanceOf<StringValuePair>(testingTarget, "Should be an Instance of TouchPoint!");

                testingTarget.second = new PropertyValue("vertical");
                PropertyValue value = testingTarget.second;
                string result = "";
                value.Get(out result);
                Assert.AreEqual("vertical", result, "Should be equal!");

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"StringValuePairConstructorSecond END (OK)");
        }
    }
}
