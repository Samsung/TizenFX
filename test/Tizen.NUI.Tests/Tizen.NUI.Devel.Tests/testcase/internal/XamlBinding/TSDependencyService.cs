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
    [Description("internal/XamlBinding/DependencyService")]
    public class InternalDependencyServiceTest
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
        [Description("DependencyService Resolve")]
        [Property("SPEC", "Tizen.NUI.Binding.DependencyService.Resolve M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        public void DependencyServiceResolve()
        {
            tlog.Debug(tag, $"DependencyServiceResolve START");

            var mString = DependencyService.Resolve<string>(DependencyFetchTarget.NewInstance);
            tlog.Error(tag, "sting : " + mString);

            var mArray = DependencyService.Resolve<Array>(DependencyFetchTarget.GlobalInstance);
            tlog.Error(tag, "Array : " + mArray);

            var mElement = DependencyService.Resolve<Element>(DependencyFetchTarget.GlobalInstance);
            tlog.Error(tag, "Element : " + mElement);

            var mIList = DependencyService.Resolve<IList<string>>(DependencyFetchTarget.GlobalInstance);
            tlog.Error(tag, "IList : " + mIList);

            var mIEnumerable = DependencyService.Resolve<IEnumerable<float>>(DependencyFetchTarget.GlobalInstance);
            tlog.Error(tag, "IEnumerable : " + mIEnumerable);

            tlog.Debug(tag, $"DependencyServiceResolve END");
        }

        [Test]
        [Category("P1")]
        [Description("DependencyService Register")]
        [Property("SPEC", "Tizen.NUI.Binding.DependencyService.Register M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        public void Register()
        {
            tlog.Debug(tag, $"Register START");

            try
            {
                DependencyService.Register<string>();
            }
            catch(Exception e)
            {
                Assert.Fail("Catch exception: " + e.Message.ToString());
            }

            tlog.Debug(tag, $"Register END");
        }

        [Test]
        [Category("P1")]
        [Description("DependencyService Register")]
        [Property("SPEC", "Tizen.NUI.Binding.DependencyService.Initialize M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        public void Initialize()
        {
            tlog.Debug(tag, $"Initialize START");

            try
            {
                DependencyService.Initialize(new Assembly[] { typeof(View).Assembly });
            }
            catch (Exception e)
            {
                Assert.Fail("Catch exception: " + e.Message.ToString());
            }

            tlog.Debug(tag, $"Initialize END");
        }
    }
}
