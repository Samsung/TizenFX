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
    [Description("internal/XamlBinding/VectorTypeConverter")]
    public class InternalVectorTypeConverterTest
    {
        private const string tag = "NUITEST";
        private string selfpath = Tizen.Applications.Application.Current.DirectoryInfo.Resource + "Test_Theme.xaml";

        internal class Vector2TypeConverterImpl : Vector2TypeConverter
        {
            public Vector2TypeConverterImpl()
            { }
        }

        internal class Vector3TypeConverterImpl : Vector3TypeConverter
        {
            public Vector3TypeConverterImpl()
            { }
        }


        internal class Vector4TypeConverterImpl : Vector4TypeConverter
        {
            public Vector4TypeConverterImpl()
            { }
        }

        internal class RelativeVector2TypeConverterImpl : RelativeVector2TypeConverter
        {
            public RelativeVector2TypeConverterImpl()
            { }
        }

        internal class RelativeVector3TypeConverterImpl : RelativeVector3TypeConverter
        {
            public RelativeVector3TypeConverterImpl()
            { }
        }

        internal class RelativeVector4TypeConverterImpl : RelativeVector4TypeConverter
        {
            public RelativeVector4TypeConverterImpl()
            { }
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
        [Description("Vector2TypeConverter ConvertFromInvariantString")]
        [Property("SPEC", "Tizen.NUI.Vector2TypeConverter.ConvertFromInvariantString M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        public void Vector2TypeConverterConvertFromInvariantString()
        {
            tlog.Debug(tag, $"Vector2TypeConverterConvertFromInvariantString START");

            var testingTarget = new Vector2TypeConverterImpl();
            Assert.IsNotNull(testingTarget, "Can't create success object Vector2TypeConverter.");
            Assert.IsInstanceOf<Vector2TypeConverter>(testingTarget, "Should return Vector2TypeConverter instance.");

            var result = testingTarget.ConvertFromInvariantString("100");
            tlog.Debug(tag, "ConvertFromInvariantString : " + result);

            tlog.Debug(tag, $"Vector2TypeConverterConvertFromInvariantString END");
        }

        [Test]
        [Category("P2")]
        [Description("Vector2TypeConverter ConvertFromInvariantString")]
        [Property("SPEC", "Tizen.NUI.Vector2TypeConverter.ConvertFromInvariantString M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        public void Vector2TypeConverterConvertFromInvariantStringNullPath()
        {
            tlog.Debug(tag, $"Vector2TypeConverterConvertFromInvariantStringNullPath START");

            var testingTarget = new Vector2TypeConverterImpl();
            Assert.IsNotNull(testingTarget, "Can't create success object Vector2TypeConverter.");
            Assert.IsInstanceOf<Vector2TypeConverter>(testingTarget, "Should return Vector2TypeConverter instance.");

            try
            {
                string str = null;
                var result = testingTarget.ConvertFromInvariantString(str);
            }
            catch (InvalidOperationException)
            {
                tlog.Debug(tag, $"Vector2TypeConverterConvertFromInvariantStringNullPath END");
                Assert.Pass("Caught InvalidOperationException : Passed!");
            }
        }

        [Test]
        [Category("P1")]
        [Description("Vector2TypeConverter ConvertToString")]
        [Property("SPEC", "Tizen.NUI.Vector2TypeConverter.ConvertToString M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        public void Vector2TypeConverterConvertToString()
        {
            tlog.Debug(tag, $"Vector2TypeConverterConvertToString START");

            var testingTarget = new Vector2TypeConverterImpl();
            Assert.IsNotNull(testingTarget, "Can't create success object Vector2TypeConverter.");
            Assert.IsInstanceOf<Vector2TypeConverter>(testingTarget, "Should return Vector2TypeConverter instance.");

            var result = testingTarget.ConvertToString(0.3f);
            tlog.Debug(tag, "ConvertToString : " + result);

            tlog.Debug(tag, $"Vector2TypeConverterConvertToString END");
        }

        [Test]
        [Category("P1")]
        [Description("Vector2TypeConverter FromString")]
        [Property("SPEC", "Tizen.NUI.Vector2TypeConverter.FromString M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        public void Vector2TypeConverterFromString()
        {
            tlog.Debug(tag, $"Vector2TypeConverterFromString START");

            // length is 2
            var result = Vector2TypeConverter.FromString("100, 50");
            tlog.Debug(tag, "FromString : " + result);

            // length is 1
            result = Vector2TypeConverter.FromString("100");
            tlog.Debug(tag, "FromString : " + result);

            tlog.Debug(tag, $"Vector2TypeConverterFromString END");
        }

        [Test]
        [Category("P2")]
        [Description("Vector2TypeConverter InvalidOperationException")]
        [Property("SPEC", "Tizen.NUI.Vector2TypeConverter.FromString M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        public void Vector2TypeConverterFromStringInvalidOperationException()
        {
            tlog.Debug(tag, $"Vector2TypeConverterFromStringInvalidOperationException START");

            try
            {
                // length is 3
                Vector2TypeConverter.FromString("100, 50, 0.0f");
            }
            catch (InvalidOperationException)
            {
                tlog.Debug(tag, $"Vector2TypeConverterFromStringInvalidOperationException END");
                Assert.Pass("Caught InvalidOperationException : Passed!");
            }
        }

        [Test]
        [Category("P1")]
        [Description("Vector2TypeConverter ToString")]
        [Property("SPEC", "Tizen.NUI.Vector2TypeConverter.ToString M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        public void Vector2TypeConverterToString()
        {
            tlog.Debug(tag, $"Vector2TypeConverterToString START");

            using (Vector2 vec = new Vector2(100, 50))
            { 
                var result = Vector2TypeConverter.ToString(vec);
                tlog.Debug(tag, "ToString : " + result);
            }

            Vector2 val = null;
            Assert.AreEqual(null, Vector2TypeConverter.ToString(val), "should be equal!");

            tlog.Debug(tag, $"Vector2TypeConverterToString END");
        }

        [Test]
        [Category("P1")]
        [Description("Vector3TypeConverter ConvertFromInvariantString")]
        [Property("SPEC", "Tizen.NUI.Vector3TypeConverter.ConvertFromInvariantString M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        public void Vector3TypeConverterConvertFromInvariantString()
        {
            tlog.Debug(tag, $"Vector3TypeConverterConvertFromInvariantString START");

            var testingTarget = new Vector3TypeConverterImpl();
            Assert.IsNotNull(testingTarget, "Can't create success object Vector3TypeConverter.");
            Assert.IsInstanceOf<Vector3TypeConverter>(testingTarget, "Should return Vector3TypeConverter instance.");

            // length is 3
            var result = testingTarget.ConvertFromInvariantString("100, 50, 30");
            tlog.Debug(tag, "ConvertFromInvariantString : " + result);

            // length is 2
            result = testingTarget.ConvertFromInvariantString("100, 50");
            tlog.Debug(tag, "ConvertFromInvariantString : " + result);

            // length is 1
            result = testingTarget.ConvertFromInvariantString("100");
            tlog.Debug(tag, "ConvertFromInvariantString : " + result);

            try
            {
                // lenght is 4
                result = testingTarget.ConvertFromInvariantString("100, 50, 30, 0.3f");
            }
            catch (InvalidOperationException)
            {
                tlog.Debug(tag, $"Vector3TypeConverterConvertFromInvariantString END");
                Assert.Pass("Caught InvalidOperationException : Passed!");
            }
        }

        [Test]
        [Category("P1")]
        [Description("Vector3TypeConverter ConvertToString")]
        [Property("SPEC", "Tizen.NUI.Vector3TypeConverter.ConvertToString M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        public void Vector3TypeConverterConvertToString()
        {
            tlog.Debug(tag, $"Vector3TypeConverterConvertToString START");

            var testingTarget = new Vector3TypeConverterImpl();
            Assert.IsNotNull(testingTarget, "Can't create success object Vector3TypeConverter.");
            Assert.IsInstanceOf<Vector3TypeConverter>(testingTarget, "Should return Vector3TypeConverter instance.");

            // null
            var result = testingTarget.ConvertToString(0.3f);
            tlog.Debug(tag, "ConvertToString : " + result);

            using (Vector3 vec = new Vector3(0.1f, 0.3f, 0.5f))
            {
                result = testingTarget.ConvertToString(vec);
                tlog.Debug(tag, "ConvertToString : " + result);
            }

            tlog.Debug(tag, $"Vector3TypeConverterConvertToString END");
        }

        [Test]
        [Category("P1")]
        [Description("Vector4TypeConverter ConvertFromInvariantString")]
        [Property("SPEC", "Tizen.NUI.Vector4TypeConverter.ConvertFromInvariantString M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        public void Vector4TypeConverterConvertFromInvariantString()
        {
            tlog.Debug(tag, $"Vector4TypeConverterConvertFromInvariantString START");

            var testingTarget = new Vector4TypeConverterImpl();
            Assert.IsNotNull(testingTarget, "Can't create success object Vector4TypeConverter.");
            Assert.IsInstanceOf<Vector4TypeConverter>(testingTarget, "Should return Vector4TypeConverter instance.");

            // length is 4
            var result = testingTarget.ConvertFromInvariantString("100, 50, 30, 10");
            tlog.Debug(tag, "ConvertFromInvariantString : " + result);

            // length is 3
            result = testingTarget.ConvertFromInvariantString("100, 50, 30");
            tlog.Debug(tag, "ConvertFromInvariantString : " + result);

            // length is 2
            result = testingTarget.ConvertFromInvariantString("100, 50");
            tlog.Debug(tag, "ConvertFromInvariantString : " + result);

            // length is 1
            result = testingTarget.ConvertFromInvariantString("100");
            tlog.Debug(tag, "ConvertFromInvariantString : " + result);

            try
            {
                // lenght is 5
                result = testingTarget.ConvertFromInvariantString("100, 50, 30, 10, 0.3f");
            }
            catch (InvalidOperationException)
            {
                tlog.Debug(tag, $"Vector4TypeConverterConvertFromInvariantString END");
                Assert.Pass("Caught InvalidOperationException : Passed!");
            }
        }

        [Test]
        [Category("P1")]
        [Description("Vector4TypeConverter ConvertToString")]
        [Property("SPEC", "Tizen.NUI.Vector4TypeConverter.ConvertToString M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        public void Vector4TypeConverterConvertToString()
        {
            tlog.Debug(tag, $"Vector4TypeConverterConvertToString START");

            var testingTarget = new Vector4TypeConverterImpl();
            Assert.IsNotNull(testingTarget, "Can't create success object Vector4TypeConverter.");
            Assert.IsInstanceOf<Vector4TypeConverter>(testingTarget, "Should return Vector4TypeConverter instance.");

            // null
            var result = testingTarget.ConvertToString(0.3f);
            tlog.Debug(tag, "ConvertToString : " + result);

            using (Vector4 vec = new Vector4(0.1f, 0.3f, 0.5f, 0.0f))
            {
                result = testingTarget.ConvertToString(vec);
                tlog.Debug(tag, "ConvertToString : " + result);
            }

            tlog.Debug(tag, $"Vector4TypeConverterConvertToString END");
        }

        [Test]
        [Category("P1")]
        [Description("RelativeVector2TypeConverter ConvertFromInvariantString")]
        [Property("SPEC", "Tizen.NUI.RelativeVector2TypeConverter.ConvertFromInvariantString M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        public void RelativeVector2TypeConverterConvertFromInvariantString()
        {
            tlog.Debug(tag, $"RelativeVector2TypeConverterConvertFromInvariantString START");

            var testingTarget = new RelativeVector2TypeConverterImpl();
            Assert.IsNotNull(testingTarget, "Can't create success object RelativeVector2TypeConverter.");
            Assert.IsInstanceOf<RelativeVector2TypeConverter>(testingTarget, "Should return RelativeVector2TypeConverter instance.");

            // length is 2
            var result = testingTarget.ConvertFromInvariantString("100, 50");
            tlog.Debug(tag, "ConvertFromInvariantString : " + result);

            // length is 1
            result = testingTarget.ConvertFromInvariantString("100");
            tlog.Debug(tag, "ConvertFromInvariantString : " + result);

            try
            {
                // lenght is 3
                result = testingTarget.ConvertFromInvariantString("100, 50, 30");
            }
            catch (InvalidOperationException)
            {
                tlog.Debug(tag, $"RelativeVector2TypeConverterConvertFromInvariantString END");
                Assert.Pass("Caught InvalidOperationException : Passed!");
            }
        }

        [Test]
        [Category("P1")]
        [Description("RelativeVector2TypeConverter ConvertToString")]
        [Property("SPEC", "Tizen.NUI.RelativeVector2TypeConverter.ConvertToString M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        public void RelativeVector2TypeConverterConvertToString()
        {
            tlog.Debug(tag, $"RelativeVector2TypeConverterConvertToString START");

            var testingTarget = new RelativeVector2TypeConverterImpl();
            Assert.IsNotNull(testingTarget, "Can't create success object RelativeVector2TypeConverter.");
            Assert.IsInstanceOf<RelativeVector2TypeConverter>(testingTarget, "Should return RelativeVector2TypeConverter instance.");

            // null
            var result = testingTarget.ConvertToString(0.3f);
            tlog.Debug(tag, "ConvertToString : " + result);

            using (RelativeVector2 vec = new RelativeVector2(0.1f, 0.3f))
            {
                result = testingTarget.ConvertToString(vec);
                tlog.Debug(tag, "ConvertToString : " + result);
            }

            tlog.Debug(tag, $"RelativeVector2TypeConverterConvertToString END");
        }

        [Test]
        [Category("P1")]
        [Description("RelativeVector3TypeConverter ConvertFromInvariantString")]
        [Property("SPEC", "Tizen.NUI.RelativeVector3TypeConverter.ConvertFromInvariantString M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        public void RelativeVector3TypeConverterConvertFromInvariantString()
        {
            tlog.Debug(tag, $"RelativeVector3TypeConverterConvertFromInvariantString START");

            var testingTarget = new RelativeVector3TypeConverterImpl();
            Assert.IsNotNull(testingTarget, "Can't create success object RelativeVector3TypeConverter.");
            Assert.IsInstanceOf<RelativeVector3TypeConverter>(testingTarget, "Should return RelativeVector3TypeConverter instance.");

            // length is 3
            var result = testingTarget.ConvertFromInvariantString("100, 50, 30");
            tlog.Debug(tag, "ConvertFromInvariantString : " + result);

            // length is 2
            result = testingTarget.ConvertFromInvariantString("100, 50");
            tlog.Debug(tag, "ConvertFromInvariantString : " + result);

            // length is 1
            result = testingTarget.ConvertFromInvariantString("100");
            tlog.Debug(tag, "ConvertFromInvariantString : " + result);

            try
            {
                // lenght is 4
                result = testingTarget.ConvertFromInvariantString("100, 50, 30, 10");
            }
            catch (InvalidOperationException)
            {
                tlog.Debug(tag, $"RelativeVector3TypeConverterConvertFromInvariantString END");
                Assert.Pass("Caught InvalidOperationException : Passed!");
            }
        }

        [Test]
        [Category("P1")]
        [Description("RelativeVector3TypeConverter ConvertToString")]
        [Property("SPEC", "Tizen.NUI.RelativeVector3TypeConverter.ConvertToString M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        public void RelativeVector3TypeConverterConvertToString()
        {
            tlog.Debug(tag, $"RelativeVector3TypeConverterConvertToString START");

            var testingTarget = new RelativeVector3TypeConverterImpl();
            Assert.IsNotNull(testingTarget, "Can't create success object RelativeVector3TypeConverter.");
            Assert.IsInstanceOf<RelativeVector3TypeConverter>(testingTarget, "Should return RelativeVector3TypeConverter instance.");

            // null
            var result = testingTarget.ConvertToString(0.3f);
            tlog.Debug(tag, "ConvertToString : " + result);

            using (RelativeVector3 vec = new RelativeVector3(0.1f, 0.3f, 0.5f))
            {
                result = testingTarget.ConvertToString(vec);
                tlog.Debug(tag, "ConvertToString : " + result);
            }

            tlog.Debug(tag, $"RelativeVector3TypeConverterConvertToString END");
        }

        [Test]
        [Category("P1")]
        [Description("RelativeVector4TypeConverter ConvertFromInvariantString")]
        [Property("SPEC", "Tizen.NUI.RelativeVector4TypeConverter.ConvertFromInvariantString M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        public void RelativeVector4TypeConverterConvertFromInvariantString()
        {
            tlog.Debug(tag, $"RelativeVector4TypeConverterConvertFromInvariantString START");

            var testingTarget = new RelativeVector4TypeConverterImpl();
            Assert.IsNotNull(testingTarget, "Can't create success object RelativeVector4TypeConverter.");
            Assert.IsInstanceOf<RelativeVector4TypeConverter>(testingTarget, "Should return RelativeVector4TypeConverter instance.");

            // length is 4
            var result = testingTarget.ConvertFromInvariantString("100, 50, 30, 10");
            tlog.Debug(tag, "ConvertFromInvariantString : " + result);

            // length is 3
            result = testingTarget.ConvertFromInvariantString("100, 50, 30");
            tlog.Debug(tag, "ConvertFromInvariantString : " + result);

            // length is 2
            result = testingTarget.ConvertFromInvariantString("100, 50");
            tlog.Debug(tag, "ConvertFromInvariantString : " + result);

            // length is 1
            result = testingTarget.ConvertFromInvariantString("100");
            tlog.Debug(tag, "ConvertFromInvariantString : " + result);

            try
            {
                // lenght is 5
                result = testingTarget.ConvertFromInvariantString("100, 50, 30, 10, 0.3f");
            }
            catch (InvalidOperationException)
            {
                tlog.Debug(tag, $"RelativeVector4TypeConverterConvertFromInvariantString END");
                Assert.Pass("Caught InvalidOperationException : Passed!");
            }
        }

        [Test]
        [Category("P1")]
        [Description("RelativeVector4TypeConverter ConvertToString")]
        [Property("SPEC", "Tizen.NUI.RelativeVector4TypeConverter.ConvertToString M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        public void RelativeVector4TypeConverterConvertToString()
        {
            tlog.Debug(tag, $"RelativeVector4TypeConverterConvertToString START");

            var testingTarget = new RelativeVector4TypeConverterImpl();
            Assert.IsNotNull(testingTarget, "Can't create success object RelativeVector4TypeConverter.");
            Assert.IsInstanceOf<RelativeVector4TypeConverter>(testingTarget, "Should return RelativeVector4TypeConverter instance.");

            // null
            var result = testingTarget.ConvertToString(0.3f);
            tlog.Debug(tag, "ConvertToString : " + result);

            using (RelativeVector4 vec = new RelativeVector4(0.1f, 0.3f, 0.5f, 0.0f))
            {
                result = testingTarget.ConvertToString(vec);
                tlog.Debug(tag, "ConvertToString : " + result);
            }

            tlog.Debug(tag, $"RelativeVector4TypeConverterConvertToString END");
        }
    }
}
