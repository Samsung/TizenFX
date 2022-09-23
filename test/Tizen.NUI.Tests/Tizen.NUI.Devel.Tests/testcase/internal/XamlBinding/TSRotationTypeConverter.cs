using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;
using System.Reflection;
using System.Collections.Generic;
using Tizen.NUI.Binding;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("internal/XamlBinding/RotationTypeConverter")]
    public class InternalRotationTypeConverterTest
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
        [Description("RotationTypeConverter constructor")]
        [Property("SPEC", "Tizen.NUI.Binding.RotationTypeConverter.RotationTypeConverter C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        public void PositionTypeConverterConstructor()
        {
            tlog.Debug(tag, $"PositionTypeConverterConstructor START");

            try
            {
               var testingTarget = new RotationTypeConverter();
            }
            catch(Exception e)
            {
                Assert.Fail("Catch exception: " + e.Message.ToString() + ", Failed!");
            }
            
            tlog.Debug(tag, $"PositionTypeConverterConstructor END");
        }

        [Test]
        [Category("P1")]
        [Description("RotationTypeConverter ConvertToString")]
        [Property("SPEC", "Tizen.NUI.Binding.RotationTypeConverter.ConvertToString M")]
        [Property("SPEC_URL", "MR")]
        [Property("CRITERIA", "CONSTR")]
        public void RotationTypeConverterConvertFromInvariantString()
        {
            tlog.Debug(tag, $"RotationTypeConverterConvertFromInvariantString START");

            var testingTarget = new RotationTypeConverter();
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<RotationTypeConverter>(testingTarget, "Should be an Instance of RotationTypeConverter!");

            try
			{
				testingTarget.ConvertFromInvariantString("D:23, 0, 0, 1");
            }
			catch(Exception e)
            {
                Assert.Fail("Catch exception: " + e.Message.ToString() + ", Failed!");
            }
			
			try
			{
                using (Rotation obj = new Rotation())
                {
                    testingTarget.ConvertToString(obj);
                }
            }
			catch(Exception e)
            {
                Assert.Fail("Catch exception: " + e.Message.ToString() + ", Failed!");
            }
            
            tlog.Debug(tag, $"RotationTypeConverterConvertFromInvariantString END");
        }
    }
}
