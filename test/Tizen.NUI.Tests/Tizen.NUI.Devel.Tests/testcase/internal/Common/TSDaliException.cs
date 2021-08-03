using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("internal/Common/DaliException")]
    public class TSDaliException
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
        [Description("DaliException constructor.")]
        [Property("SPEC", "Tizen.NUI.DaliException.DaliException C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void DaliExceptionConstructor()
        {
            tlog.Debug(tag, $"DaliExceptionConstructor START");

            var testingTarget = new DaliException("China", "Chinese speaking!");
            Assert.IsNotNull(testingTarget, "Can't create success object DaliException.");
            Assert.IsInstanceOf<DaliException>(testingTarget, "Should return DaliException instance.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"DaliExceptionConstructor END (OK)");
        }

        //[Test]
        //[Category("P1")]
        //[Description("DaliException location.")]
        //[Property("SPEC", "Tizen.NUI.DaliException.location A")]
        //[Property("SPEC_URL", "-")]
        //[Property("CRITERIA", "PRW")]
        //[Property("AUTHOR", "guowei.wang@samsung.com")]
        //public void DaliExceptionLocation()
        //{
        //    tlog.Debug(tag, $"DaliExceptionLocation START");

        //    var testingTarget = new DaliException("China", "Chinese speaking!");
        //    Assert.IsNotNull(testingTarget, "Can't create success object DaliException.");
        //    Assert.IsInstanceOf<DaliException>(testingTarget, "Should return DaliException instance.");

        //    testingTarget.location = "Korea";
        //    tlog.Debug(tag, "location : " + testingTarget.location);

        //    testingTarget.Dispose();
        //    tlog.Debug(tag, $"DaliExceptionLocation END (OK)");
        //}

        [Test]
        [Category("P1")]
        [Description("DaliException condition.")]
        [Property("SPEC", "Tizen.NUI.DaliException.DaliException A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void DaliExceptionCondition()
        {
            tlog.Debug(tag, $"DaliExceptionCondition START");

            var testingTarget = new DaliException("China", "Chinese speaking!");
            Assert.IsNotNull(testingTarget, "Can't create success object DaliException.");
            Assert.IsInstanceOf<DaliException>(testingTarget, "Should return DaliException instance.");

            testingTarget.condition= "Korea speaking!";
            tlog.Debug(tag, "condition : " + testingTarget.condition);

            testingTarget.Dispose();
            tlog.Debug(tag, $"DaliExceptionCondition END (OK)");
        }
    }
}
