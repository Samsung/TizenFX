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
    [Description("public/Layouting/LayoutLength")]
    public class PublicLayoutLengthTest
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
        [Description("LayoutLength int constructor")]
        [Property("SPEC", "Tizen.NUI.LayoutLength.LayoutLength C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("COVPARAM", "int")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void LayoutLengthConstructorWithInt()
        {
            tlog.Debug(tag, $"LayoutLengthConstructorWithInt START");

            var testingTarget = new LayoutLength(10);
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<LayoutLength>(testingTarget, "Should be an instance of LayoutLength type.");
            
            Assert.AreEqual(testingTarget.AsDecimal(), 10.0f, "Should be 10.0f.");

            tlog.Debug(tag, $"LayoutLengthConstructorWithInt END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("LayoutLength float constructor")]
        [Property("SPEC", "Tizen.NUI.LayoutLength.LayoutLength C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("COVPARAM", "Single")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void LayoutLengthConstructorWithFloat()
        {
            tlog.Debug(tag, $"LayoutLengthConstructorWithFloat START");

            var testingTarget = new LayoutLength(10.0f);
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<LayoutLength>(testingTarget, "Should be an instance of LayoutLength type.");
            
            Assert.AreEqual(testingTarget.AsDecimal(), 10.0f, "Should be 10.0f.");

            tlog.Debug(tag, $"LayoutLengthConstructorWithFloat END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("LayoutLength constructor. With LayoutLength instance")]
        [Property("SPEC", "Tizen.NUI.LayoutLength.LayoutLength C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("COVPARAM", "LayoutLength")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void LayoutLengthConstructorWithLayoutLength()
        {
            tlog.Debug(tag, $"LayoutLengthConstructorWithLayoutLength START");

            LayoutLength layoutLength = new LayoutLength(10.0f);

            var testingTarget = new LayoutLength(layoutLength);
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<LayoutLength>(testingTarget, "Should be an instance of LayoutLength type.");

            Assert.AreEqual(testingTarget.AsDecimal(), 10.0f, "Should be 10.0f.");

            tlog.Debug(tag, $"LayoutLengthConstructorWithLayoutLength END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("LayoutLength AsRoundedValue")]
        [Property("SPEC", "Tizen.NUI.LayoutLength.AsRoundedValue M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void LayoutLengthAsRoundedValue()
        {
            tlog.Debug(tag, $"LayoutLengthAsRoundedValue START");

            var testingTarget = new LayoutLength(10.1f);
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<LayoutLength>(testingTarget, "Should be an instance of LayoutLength type.");

            Assert.AreEqual(testingTarget.AsRoundedValue(), 10.0f, "Should be 10.0f.");

            tlog.Debug(tag, $"LayoutLengthAsRoundedValue END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("LayoutLength AsDecimal")]
        [Property("SPEC", "Tizen.NUI.LayoutLength.AsDecimal M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void LayoutLengthAsDecimal()
        {
            tlog.Debug(tag, $"LayoutLengthAsDecimal START");

            var testingTarget = new LayoutLength(10.1f);
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<LayoutLength>(testingTarget, "Should be an instance of LayoutLength type.");

            Assert.AreEqual(testingTarget.AsDecimal(), 10.1f, "Should be 10.0f.");

            tlog.Debug(tag, $"LayoutLengthAsDecimal END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("LayoutLength ==")]
        [Property("SPEC", "Tizen.NUI.LayoutLength.== M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void LayoutLengthEquality()
        {
            tlog.Debug(tag, $"LayoutLengthEquality START");

            var testingTarget = new LayoutLength(10.0f);
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<LayoutLength>(testingTarget, "Should be an instance of LayoutLength type.");

            Assert.IsTrue(testingTarget == new LayoutLength(10.0f), "Should be equal.");

            tlog.Debug(tag, $"LayoutLengthEquality END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("LayoutLength !=")]
        [Property("SPEC", "Tizen.NUI.LayoutLength.!= M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void LayoutLengthNotEquals()
        {
            tlog.Debug(tag, $"LayoutLengthNotEquals START");

            var testingTarget = new LayoutLength(10.0f);
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<LayoutLength>(testingTarget, "Should be an instance of LayoutLength type.");

            Assert.IsTrue(testingTarget != new LayoutLength(11.0f), "Should not be equal.");

            tlog.Debug(tag, $"LayoutLengthNotEquals END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("LayoutLength Equals. With Object")]
        [Property("SPEC", "Tizen.NUI.LayoutLength.Equals M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void LayoutLengthEqualsWithObject()
        {
            tlog.Debug(tag, $"LayoutLengthEqualsWithObject START");

            var testingTarget = new LayoutLength(10.0f);
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<LayoutLength>(testingTarget, "Should be an instance of LayoutLength type.");

            object obj = new LayoutLength(10.0f);
            Assert.IsTrue(testingTarget.Equals(obj), "Should be equal.");

            object obj2 = new Size(100, 150);
            Assert.IsFalse(testingTarget.Equals(obj2), "Should be equal.");

            tlog.Debug(tag, $"LayoutLengthEqualsWithObject END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("LayoutLength Equals. With LayoutLength")]
        [Property("SPEC", "Tizen.NUI.LayoutLength.Equals M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void LayoutLengthEqualsWithLayoutLength()
        {
            tlog.Debug(tag, $"LayoutLengthEqualsWithLayoutLength START");

            var testingTarget = new LayoutLength(10.0f);
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<LayoutLength>(testingTarget, "Should be an instance of LayoutLength type.");

            Assert.IsTrue(testingTarget.Equals(new LayoutLength(10.0f)), "Should be equal.");

            tlog.Debug(tag, $"LayoutLengthEqualsWithLayoutLength END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("LayoutLength GetHashCode")]
        [Property("SPEC", "Tizen.NUI.LayoutLength.GetHashCode M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void LayoutLengthGetHashCode()
        {
            tlog.Debug(tag, $"LayoutLengthGetHashCode START");

            var testingTarget = new LayoutLength(10.0f);
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<LayoutLength>(testingTarget, "Should be an instance of LayoutLength type.");

            Assert.AreEqual(testingTarget.GetHashCode(), 10, "Should be .");

            tlog.Debug(tag, $"LayoutLengthGetHashCode END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("LayoutLength addition operator. Addition with LayoutLength")]
        [Property("SPEC", "Tizen.NUI.LayoutLength.+ M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "LayoutLength, LayoutLength")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void LayoutLengthAdditionWithLayoutLength()
        {
            tlog.Debug(tag, $"LayoutLengthAdditionWithLayoutLength START");

            var testingTarget1 = new LayoutLength(10.0f);
            Assert.IsNotNull(testingTarget1, "null handle");
            Assert.IsInstanceOf<LayoutLength>(testingTarget1, "Should be an instance of LayoutLength type.");

            var testingTarget2 = new LayoutLength(10.0f);
            Assert.IsNotNull(testingTarget2, "null handle");
            Assert.IsInstanceOf<LayoutLength>(testingTarget2, "Should be an instance of LayoutLength type.");

            var result = testingTarget1 + testingTarget2;
            Assert.AreEqual(result.AsDecimal(), 20.0f, "Should be the sum.");

            tlog.Debug(tag, $"LayoutLengthAdditionWithLayoutLength END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("LayoutLength addition operator. Addition with int")]
        [Property("SPEC", "Tizen.NUI.LayoutLength.+ M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void LayoutLengthAdditionWithInt()
        {
            tlog.Debug(tag, $"LayoutLengthAdditionWithInt START");

            var testingTarget = new LayoutLength(10.0f);
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<LayoutLength>(testingTarget, "Should be an instance of LayoutLength type.");

            var result = testingTarget + 10;
            Assert.AreEqual(result.AsDecimal(), 20.0f, "Should be the sum.");

            tlog.Debug(tag, $"LayoutLengthAdditionWithInt END (OK)");
        }


        [Test]
        [Category("P1")]
        [Description("LayoutLength subtraction operator. Subtraction with LayoutLength")]
        [Property("SPEC", "Tizen.NUI.LayoutLength.- M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void LayoutLengthSubtractionWithLayoutLength()
        {
            tlog.Debug(tag, $"LayoutLengthSubtractionWithLayoutLength START");

            var testingTarget1 = new LayoutLength(10.0f);
            Assert.IsNotNull(testingTarget1, "null handle");
            Assert.IsInstanceOf<LayoutLength>(testingTarget1, "Should be an instance of LayoutLength type.");

            var testingTarget2 = new LayoutLength(5.0f);
            Assert.IsNotNull(testingTarget2, "null handle");
            Assert.IsInstanceOf<LayoutLength>(testingTarget2, "Should be an instance of LayoutLength type.");

            var result = testingTarget1 - testingTarget2;
            Assert.AreEqual(result.AsDecimal(), 5.0f, "Should be the substract of B from A.");

            tlog.Debug(tag, $"LayoutLengthSubtractionWithLayoutLength END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("LayoutLength subtraction operator. Subtraction with int")]
        [Property("SPEC", "Tizen.NUI.LayoutLength.- M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void LayoutLengthSubtractionWithInt()
        {
            tlog.Debug(tag, $"LayoutLengthSubtractionWithInt START");

            var testingTarget = new LayoutLength(10.0f);
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<LayoutLength>(testingTarget, "Should be an instance of LayoutLength type.");

            var result = testingTarget - 5;
            Assert.AreEqual(result.AsDecimal(), 5.0f, "Should be the substraction of 5.0f.");

            tlog.Debug(tag, $"LayoutLengthSubtractionWithInt END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("LayoutLength multiply operator. Multiply with LayoutLength")]
        [Property("SPEC", "Tizen.NUI.LayoutLength.* M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void LayoutLengthMultiplyWithLayoutLength()
        {
            tlog.Debug(tag, $"LayoutLengthMultiplyWithLayoutLength START");

            var testingTarget1 = new LayoutLength(10.0f);
            Assert.IsNotNull(testingTarget1, "null handle");
            Assert.IsInstanceOf<LayoutLength>(testingTarget1, "Should be an instance of LayoutLength type.");

            var testingTarget2 = new LayoutLength(2.0f);
            Assert.IsNotNull(testingTarget2, "null handle");
            Assert.IsInstanceOf<LayoutLength>(testingTarget2, "Should be an instance of LayoutLength type.");

            var result = testingTarget1 * testingTarget2;
            Assert.AreEqual(result.AsDecimal(), 20.0f, "Should be the multiplication of A x B.");

            tlog.Debug(tag, $"LayoutLengthMultiplyWithLayoutLength END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("LayoutLength multiply operator. Multiply with int")]
        [Property("SPEC", "Tizen.NUI.LayoutLength.* M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void LayoutLengthMultiplyWithInt()
        {
            tlog.Debug(tag, $"LayoutLengthMultiplyWithInt START");

            var testingTarget = new LayoutLength(10.0f);
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<LayoutLength>(testingTarget, "Should be an instance of LayoutLength type.");

            var result = testingTarget * 2;
            Assert.AreEqual(result.AsDecimal(), 20.0f, "Should be the multiplication of A x 2");

            tlog.Debug(tag, $"LayoutLengthMultiplyWithInt END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("LayoutLength division operator. Division with LayoutLength")]
        [Property("SPEC", "Tizen.NUI.LayoutLength./ M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void LayoutLengthDivisionWithLayoutLength()
        {
            tlog.Debug(tag, $"LayoutLengthDivisionWithLayoutLength START");

            var testingTarget1 = new LayoutLength(10.0f);
            Assert.IsNotNull(testingTarget1, "null handle");
            Assert.IsInstanceOf<LayoutLength>(testingTarget1, "Should be an instance of LayoutLength type.");

            var testingTarget2 = new LayoutLength(2.0f);
            Assert.IsNotNull(testingTarget2, "null handle");
            Assert.IsInstanceOf<LayoutLength>(testingTarget2, "Should be an instance of LayoutLength type.");

            var result = testingTarget1 / testingTarget2;
            Assert.AreEqual(result.AsDecimal(), 5.0f, "Should be the division of A by B.");

            tlog.Debug(tag, $"LayoutLengthDivisionWithLayoutLength END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("LayoutLength division operator. Division with int")]
        [Property("SPEC", "Tizen.NUI.LayoutLength./ M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void LayoutLengthDivisionWithInt()
        {
            tlog.Debug(tag, $"LayoutLengthDivisionWithInt START");

            var testingTarget = new LayoutLength(10.0f);
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<LayoutLength>(testingTarget, "Should be an instance of LayoutLength type.");

            var result = testingTarget / 2;
            Assert.AreEqual(result.AsDecimal(), 5.0f, "Should be the multiplication of A x 2");

            tlog.Debug(tag, $"LayoutLengthDivisionWithInt END (OK)");
        }
    }
}
