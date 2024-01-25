using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;
using System.Reflection;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("internal/Common/Extensions")]
    public class InternalExtensionsTest
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
        [Description("Extensions GetValueString.")]
        [Property("SPEC", "Tizen.NUI.Extensions.GetValueString M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ExtensionsGetValueString()
        {
            tlog.Debug(tag, $"ExtensionsGetValueString START");

            using (View view = new View())
            {
                view.Name = "view";
                global::System.Reflection.PropertyInfo propertyInfo = view.GetType().GetProperty("Name");

                var result = propertyInfo.GetValueString(view, propertyInfo.PropertyType);
                tlog.Debug(tag, "GetValueString : " + result);
            }

            tlog.Debug(tag, $"ExtensionsGetValueString END (OK)");
        }
    }
}
