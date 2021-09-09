using NUnit.Framework;
using System;
using Tizen.NUI.Xaml;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("public/xaml/TypeConversionAttribute")]
    public class PublicTypeConversionAttributeTest
    {
        private const string tag = "NUITEST";
        private TypeConversionAttribute conversionAttr;
        [SetUp]
        public void Init()
        {
            tlog.Info(tag, "Init() is called!");
            TypeConversionAttribute conversionAttr = new TypeConversionAttribute(typeof(string));
        }

        [TearDown]
        public void Destroy()
        {
            conversionAttr = null;
            tlog.Info(tag, "Destroy() is called!");
        }
    }
}