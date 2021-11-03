using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Components.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("Controls/FlexibleView/LinearLayoutManager")]
    class TSFlexibleViewViewHolder
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
        [Description("FlexibleViewViewHolder constructor.")]
        [Property("SPEC", "Tizen.NUI.Components.FlexibleViewViewHolder C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "huayong.xu@samsung.com")]
        public void FlexibleViewViewHolderConstructor()
        {
            tlog.Debug(tag, $"FlexibleViewViewHolderConstructor START");

            var v = new View()
            {
                Size = new Size(100, 100),
            };
            var testingTarget = new FlexibleViewViewHolder(v);

            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<FlexibleViewViewHolder>(testingTarget, "should be an instance of testing target class!");

            tlog.Debug(tag, $"FlexibleViewViewHolderConstructor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("FlexibleViewViewHolder ItemView.")]
        [Property("SPEC", "Tizen.NUI.Components.FlexibleViewViewHolder.ItemView A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "huayong.xu@samsung.com")]
        public void FlexibleViewViewHolderItemView()
        {
            tlog.Debug(tag, $"FlexibleViewViewHolderItemView START");

            var v = new View()
            {
                Size = new Size(100, 100),
            };
            var testingTarget = new FlexibleViewViewHolder(v);
            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<FlexibleViewViewHolder>(testingTarget, "should be an instance of testing target class!");
            Assert.IsNotNull(testingTarget.ItemView, "should not be null.");

            tlog.Debug(tag, $"FlexibleViewViewHolderItemView END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("FlexibleViewViewHolder Left.")]
        [Property("SPEC", "Tizen.NUI.Components.FlexibleViewViewHolder.Left A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "huayong.xu@samsung.com")]
        public void FlexibleViewViewHolderLeft()
        {
            tlog.Debug(tag, $"FlexibleViewViewHolderLeft START");

            var v = new View()
            {
                Size = new Size(100, 100),
            };
            var testingTarget = new FlexibleViewViewHolder(v);
            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<FlexibleViewViewHolder>(testingTarget, "should be an instance of testing target class!");
            Assert.AreEqual(testingTarget.Left, 0, "should be equal.");

            tlog.Debug(tag, $"FlexibleViewViewHolderLeft END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("FlexibleViewViewHolder Right.")]
        [Property("SPEC", "Tizen.NUI.Components.FlexibleViewViewHolder.Right A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "huayong.xu@samsung.com")]
        public void FlexibleViewViewHolderRight()
        {
            tlog.Debug(tag, $"FlexibleViewViewHolderRight START");

            var v = new View()
            {
                Size = new Size(100, 100),
            };
            var testingTarget = new FlexibleViewViewHolder(v);
            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<FlexibleViewViewHolder>(testingTarget, "should be an instance of testing target class!");
            Assert.AreEqual(testingTarget.Right, 100, "should be equal.");

            tlog.Debug(tag, $"FlexibleViewViewHolderRight END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("FlexibleViewViewHolder Top.")]
        [Property("SPEC", "Tizen.NUI.Components.FlexibleViewViewHolder.Top A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "huayong.xu@samsung.com")]
        public void FlexibleViewViewHolderTop()
        {
            tlog.Debug(tag, $"FlexibleViewViewHolderTop START");

            var v = new View()
            {
                Size = new Size(100, 100),
            };
            var testingTarget = new FlexibleViewViewHolder(v);
            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<FlexibleViewViewHolder>(testingTarget, "should be an instance of testing target class!");
            Assert.AreEqual(testingTarget.Top, 0, "should be equal.");

            tlog.Debug(tag, $"FlexibleViewViewHolderTop END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("FlexibleViewViewHolder Bottom.")]
        [Property("SPEC", "Tizen.NUI.Components.FlexibleViewViewHolder.Bottom A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "huayong.xu@samsung.com")]
        public void FlexibleViewViewHolderBottom()
        {
            tlog.Debug(tag, $"FlexibleViewViewHolderBottom START");

            var v = new View()
            {
                Size = new Size(100, 100),
            };
            var testingTarget = new FlexibleViewViewHolder(v);
            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<FlexibleViewViewHolder>(testingTarget, "should be an instance of testing target class!");
            Assert.AreEqual(testingTarget.Bottom, 100, "should be equal.");

            tlog.Debug(tag, $"FlexibleViewViewHolderBottom END (OK)");
        }
    }
}
