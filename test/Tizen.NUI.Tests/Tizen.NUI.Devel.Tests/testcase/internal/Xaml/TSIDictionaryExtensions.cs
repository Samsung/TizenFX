using NUnit.Framework;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("internal/Xaml/IDictionaryExtensions")]
    public class InternalXamlIDictionaryExtensionsTest
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

        //[Test]
        //[Category("P1")]
        //[Description("HydrationContext Values")]
        //[Property("SPEC", "Tizen.NUI.HydrationContext.Values A")]
        //[Property("SPEC_URL", "-")]
        //[Property("CRITERIA", "PRW")]
        //public void IDictionaryExtensionsAddRange()
        //{
        //    tlog.Debug(tag, $"HydrationContextValues START");

        //    try
        //    {
        //        IDictionary<string, string> dic = new Dictionary<string, string>();
        //        IEnumerable<KeyValuePair<string, string>> keyValuePairs = new IEnumerable<KeyValuePair<string, string>>();
        //        IDictionaryExtensions.AddRange<string, string>(dic, keyValuePairs);
        //    }
        //    catch (Exception e)
        //    {
        //        Tizen.Log.Error(tag, "Caught Exception" + e.ToString());
        //        Assert.Fail("Caught Exception" + e.ToString());
        //    }

        //    tlog.Debug(tag, $"HydrationContextValues END (OK)");
        //    Assert.Pass("HydrationContextValues");
        //}
    }
}