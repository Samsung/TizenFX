using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("internal/Common/Alignment")]
    public class InternalAlignmentTest
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
        [Description("Alignment constructor.")]
        [Property("SPEC", "Tizen.NUI.Alignment.Alignment C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void AlignmentConstructor()
        {
            tlog.Debug(tag, $"AlignmentConstructor START");

            var testingTarget = new Alignment();
            Assert.IsNotNull(testingTarget, "Can't create success object Alignment");
            Assert.IsInstanceOf<Alignment>(testingTarget, "Should be an instance of Alignment type.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"AlignmentConstructor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Alignment constructor. With horizontal type.")]
        [Property("SPEC", "Tizen.NUI.Alignment.Alignment C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void AlignmentConstructorWithHorizontalType()
        {
            tlog.Debug(tag, $"AlignmentConstructorWithHorizontalType START");

            var testingTarget = new Alignment(Alignment.Type.HorizontalCenter);
            Assert.IsNotNull(testingTarget, "Can't create success object Alignment");
            Assert.IsInstanceOf<Alignment>(testingTarget, "Should be an instance of Alignment type.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"AlignmentConstructorWithHorizontalType END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Alignment constructor. With horizontal & vertical type.")]
        [Property("SPEC", "Tizen.NUI.Alignment.Alignment C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void AlignmentConstructorWithHorizontalAndVerticalType()
        {
            tlog.Debug(tag, $"AlignmentConstructorWithHorizontalAndVerticalType START");

            var testingTarget = new Alignment(Alignment.Type.HorizontalCenter, Alignment.Type.VerticalCenter);
            Assert.IsNotNull(testingTarget, "Can't create success object Alignment");
            Assert.IsInstanceOf<Alignment>(testingTarget, "Should be an instance of Alignment type.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"AlignmentConstructorWithHorizontalAndVerticalType END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Alignment constructor. With Alignment.")]
        [Property("SPEC", "Tizen.NUI.Alignment.Alignment C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void AlignmentConstructorWithAlignment()
        {
            tlog.Debug(tag, $"AlignmentConstructorWithAlignment START");

            using (Alignment alignMent = new Alignment(Alignment.Type.HorizontalRight))
            {
                var testingTarget = new Alignment(alignMent);
                Assert.IsNotNull(testingTarget, "Can't create success object Alignment");
                Assert.IsInstanceOf<Alignment>(testingTarget, "Should be an instance of Alignment type.");

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"AlignmentConstructorWithAlignment END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Alignment getCPtr.")]
        [Property("SPEC", "Tizen.NUI.Alignment.getCPtr M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void AlignmentGetCPtr()
        {
            tlog.Debug(tag, $"AlignmentGetCPtr START");

            var testingTarget = new Alignment(new ImageView().SwigCPtr.Handle, false);
            Assert.IsNotNull(testingTarget, "Can't create success object Alignment");
            Assert.IsInstanceOf<Alignment>(testingTarget, "Should be an instance of Alignment type.");

            try
            {
                Alignment.getCPtr(testingTarget);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"AlignmentGetCPtr END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Alignment.Padding constructor.")]
        [Property("SPEC", "Tizen.NUI.Alignment.Padding.Padding C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void AlignmentPadding()
        {
            tlog.Debug(tag, $"AlignmentPadding START");

            var testingTarget = new Alignment.Padding();
            Assert.IsNotNull(testingTarget, "Can't create success object Alignment");
            Assert.IsInstanceOf<Alignment.Padding>(testingTarget, "Should be an instance of Padding type.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"AlignmentPadding END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Alignment.Padding constructor. With floats.")]
        [Property("SPEC", "Tizen.NUI.Alignment.Padding.Padding C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void AlignmentPaddingConstructorWithFloats()
        {
            tlog.Debug(tag, $"AlignmentPaddingConstructorWithFloats START");

            var testingTarget = new Alignment.Padding(1.0f, 2.0f, 3.0f, 4.0f);
            Assert.IsNotNull(testingTarget, "Can't create success object Alignment");
            Assert.IsInstanceOf<Alignment.Padding>(testingTarget, "Should be an instance of Padding type.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"AlignmentPaddingConstructorWithFloats END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Alignment SetAlignmentType.")]
        [Property("SPEC", "Tizen.NUI.Alignment.SetAlignmentType M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void AlignmentSetAlignmentType()
        {
            tlog.Debug(tag, $"AlignmentSetAlignmentType START");

            var testingTarget = new Alignment(Alignment.Type.HorizontalCenter);
            Assert.IsNotNull(testingTarget, "Can't create success object Alignment");
            Assert.IsInstanceOf<Alignment>(testingTarget, "Should be an instance of Alignment type.");

            tlog.Debug(tag, "Alignment.Type : " + testingTarget.GetAlignmentType());

            testingTarget.SetAlignmentType(Alignment.Type.VerticalBottom);
            tlog.Debug(tag, "Alignment.Type : " + testingTarget.GetAlignmentType());

            testingTarget.Dispose();
            tlog.Debug(tag, $"AlignmentSetAlignmentType END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Alignment SetScaling.")]
        [Property("SPEC", "Tizen.NUI.Alignment.SetScaling M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void AlignmentSetScaling()
        {
            tlog.Debug(tag, $"AlignmentSetScaling START");

            var testingTarget = new Alignment(Alignment.Type.HorizontalCenter);
            Assert.IsNotNull(testingTarget, "Can't create success object Alignment");
            Assert.IsInstanceOf<Alignment>(testingTarget, "Should be an instance of Alignment type.");

            tlog.Debug(tag, "Alignment.Scaling : " + testingTarget.GetScaling());

            testingTarget.SetScaling(Alignment.Scaling.ScaleToFill);
            tlog.Debug(tag, "Alignment.Scaling : " + testingTarget.GetScaling());

            testingTarget.Dispose();
            tlog.Debug(tag, $"AlignmentSetScaling END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Alignment SetPadding.")]
        [Property("SPEC", "Tizen.NUI.Alignment.SetPadding M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void AlignmentSetPadding()
        {
            tlog.Debug(tag, $"AlignmentSetPadding START");

            var testingTarget = new Alignment(Alignment.Type.HorizontalCenter);
            Assert.IsNotNull(testingTarget, "Can't create success object Alignment");
            Assert.IsInstanceOf<Alignment>(testingTarget, "Should be an instance of Alignment type.");

            tlog.Debug(tag, "Alignment.Padding : " + testingTarget.GetPadding());

            using (Alignment.Padding padding = new Alignment.Padding(1.0f, 2.0f, 3.0f, 4.0f))
            {
                testingTarget.SetPadding(padding);
                tlog.Debug(tag, "Alignment.Padding : " + testingTarget.GetPadding());
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"AlignmentSetPadding END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Alignment.Padding getCPtr.")]
        [Property("SPEC", "Tizen.NUI.Alignment.Padding getCPtr M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void AlignmentPaddingGetCPtr()
        {
            tlog.Debug(tag, $"AlignmentPaddingGetCPtr START");

            var testingTarget = new Alignment.Padding();
            Assert.IsNotNull(testingTarget, "Can't create success object Alignment");
            Assert.IsInstanceOf<Alignment.Padding>(testingTarget, "Should be an instance of Padding type.");

            try
            {
                Alignment.Padding.getCPtr(testingTarget);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"AlignmentPaddingGetCPtr END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Alignment Assign.")]
        [Property("SPEC", "Tizen.NUI.Alignment.Assign M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void AlignmentAssign()
        {
            tlog.Debug(tag, $"AlignmentAssign START");

            var testingTarget = new Alignment();
            Assert.IsNotNull(testingTarget, "Can't create success object Alignment");
            Assert.IsInstanceOf<Alignment>(testingTarget, "Should be an instance of Alignment type.");

            try
            {
                testingTarget.Assign(testingTarget);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"AlignmentAssign END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Alignment DownCast.")]
        [Property("SPEC", "Tizen.NUI.Alignment.DownCast M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void AlignmentDownCast()
        {
            tlog.Debug(tag, $"AlignmentDownCast START");

            var testingTarget = new Alignment();
            Assert.IsNotNull(testingTarget, "Can't create success object Alignment");
            Assert.IsInstanceOf<Alignment>(testingTarget, "Should be an instance of Alignment type.");

            try
            {
                Alignment.DownCast(testingTarget);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"AlignmentDownCast END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Alignment.Padding left.")]
        [Property("SPEC", "Tizen.NUI.Alignment.Padding left A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void AlignmentPaddingLeft()
        {
            tlog.Debug(tag, $"AlignmentPaddingLeft START");

            var testingTarget = new Alignment.Padding(1.0f, 2.0f, 3.0f, 4.0f);
            Assert.IsNotNull(testingTarget, "Can't create success object Alignment");
            Assert.IsInstanceOf<Alignment.Padding>(testingTarget, "Should be an instance of Padding type.");

            Assert.AreEqual(1.0f, testingTarget.left, "Should be equal!");

            testingTarget.left = 4.0f;
            Assert.AreEqual(4.0f, testingTarget.left, "Should be equal!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"AlignmentPaddingLeft END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Alignment.Padding right.")]
        [Property("SPEC", "Tizen.NUI.Alignment.Padding right A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void AlignmentPaddingRight()
        {
            tlog.Debug(tag, $"AlignmentPaddingRight START");

            var testingTarget = new Alignment.Padding(1.0f, 2.0f, 3.0f, 4.0f);
            Assert.IsNotNull(testingTarget, "Can't create success object Alignment");
            Assert.IsInstanceOf<Alignment.Padding>(testingTarget, "Should be an instance of Padding type.");

            Assert.AreEqual(2.0f, testingTarget.right, "Should be equal!");

            testingTarget.right = 3.0f;
            Assert.AreEqual(3.0f, testingTarget.right, "Should be equal!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"AlignmentPaddingRight END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Alignment.Padding top.")]
        [Property("SPEC", "Tizen.NUI.Alignment.Padding top A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void AlignmentPaddingTop()
        {
            tlog.Debug(tag, $"AlignmentPaddingTop START");

            var testingTarget = new Alignment.Padding(1.0f, 2.0f, 3.0f, 4.0f);
            Assert.IsNotNull(testingTarget, "Can't create success object Alignment");
            Assert.IsInstanceOf<Alignment.Padding>(testingTarget, "Should be an instance of Padding type.");

            Assert.AreEqual(3.0f, testingTarget.top, "Should be equal!");

            testingTarget.top = 2.0f;
            Assert.AreEqual(2.0f, testingTarget.top, "Should be equal!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"AlignmentPaddingTop END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Alignment.Padding bottom.")]
        [Property("SPEC", "Tizen.NUI.Alignment.Padding bottom A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void AlignmentPaddingBottom()
        {
            tlog.Debug(tag, $"AlignmentPaddingBottom START");

            var testingTarget = new Alignment.Padding(1.0f, 2.0f, 3.0f, 4.0f);
            Assert.IsNotNull(testingTarget, "Can't create success object Alignment");
            Assert.IsInstanceOf<Alignment.Padding>(testingTarget, "Should be an instance of Padding type.");

            Assert.AreEqual(4.0f, testingTarget.bottom, "Should be equal!");

            testingTarget.bottom = 1.0f;
            Assert.AreEqual(1.0f, testingTarget.bottom, "Should be equal!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"AlignmentPaddingBottom END (OK)");
        }
    }
}
