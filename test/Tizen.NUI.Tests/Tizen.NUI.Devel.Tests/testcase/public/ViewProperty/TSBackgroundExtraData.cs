using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;
using System.Collections.Generic;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("public/Utility/BackgroundExtraData")]
    public class PublicBackgroundExtraDataTest
    {
        private const string tag = "NUITEST";

        internal class MyBackgroundExtraData : BackgroundExtraData
        {
            public MyBackgroundExtraData() : base()
            { }

            public void OnDispose(bool disposing)
            {
                base.Dispose(disposing);
            }
        }

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
        [Description("BackgroundExtraData constructor. With BackgroundExtraData")]
        [Property("SPEC", "Tizen.NUI.BackgroundExtraData.BackgroundExtraData C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void BackgroundExtraDataConstructor()
        {
            tlog.Debug(tag, $"BackgroundExtraDataConstructor START");

            View view = new View();
            view.backgroundExtraData = new BackgroundExtraData()
            {
                BackgroundImageBorder = new Rectangle(5, 5, 5, 5),
                CornerRadius = new Vector4(1.0f, 2.0f, 3.0f, 4.0f),
                CornerRadiusPolicy = VisualTransformPolicyType.Relative,
                BorderlineWidth = 0.3f,
                BorderlineColor = Color.Red,
                BorderlineOffset = 1.5f
            };

            var testingTarget = new BackgroundExtraData(view.backgroundExtraData);
            Assert.AreEqual(0.3f, testingTarget.BorderlineWidth, "Should be equal!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"BackgroundExtraDataConstructor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("BackgroundExtraData Dispose.")]
        [Property("SPEC", "Tizen.NUI.BackgroundExtraData.Dispose M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void BackgroundExtraDataDispose()
        {
            tlog.Debug(tag, $"BackgroundExtraDataDispose START");
           
            var testingTarget = new MyBackgroundExtraData();

            try
            {
                testingTarget.OnDispose(true);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception: Failed!");
            }

            /** Instance is disposed */
            try
            {
                testingTarget.OnDispose(true);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception: Failed!");
            }

            tlog.Debug(tag, $"BackgroundExtraDataDispose END (OK)");
        }
    }
}
