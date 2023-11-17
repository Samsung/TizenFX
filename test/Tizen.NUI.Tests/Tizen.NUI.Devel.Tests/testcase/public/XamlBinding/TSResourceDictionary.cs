using NUnit.Framework;
using System;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Binding;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("public/XamlBinding/ResourceDictionary")]
    internal class PublicResourceDictionaryTest
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
        [Description("ResourceDictionary MergedWith")]
        [Property("SPEC", "Tizen.NUI.Binding.ResourceDictionary.MergedWith A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Obsolete]
        public void ResourceDictionaryMergedWith()
        {
            tlog.Debug(tag, $"ResourceDictionaryMergedWith START");
            
            try
            {
                var testingTarget = new ResourceDictionary();
                Assert.IsNotNull(testingTarget, "null ResourceDictionary");

#pragma warning disable Reflection // The code contains reflection
                testingTarget.MergedWith = typeof(ResourceDictionary);
#pragma warning restore Reflection // The code contains reflection
#pragma warning disable Reflection // The code contains reflection
                testingTarget.MergedWith = typeof(ResourceDictionary); //Asign again
#pragma warning restore Reflection // The code contains reflection
                Assert.IsNotNull(testingTarget.MergedWith, "Should not be null");
            }
            catch (Exception e)
            {
                Assert.Fail("Caught Exception" + e.ToString());
            }
            
            tlog.Debug(tag, $"ResourceDictionaryMergedWith END");
        }

        [Test]
        [Category("P2")]
        [Description("ResourceDictionary Source")]
        [Property("SPEC", "Tizen.NUI.Binding.ResourceDictionary.Source A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        public void ResourceDictionarySource()
        {
            tlog.Debug(tag, $"ResourceDictionarySource START");

            try
            {
                var testingTarget = new ResourceDictionary();
                Assert.IsNotNull(testingTarget, "null ResourceDictionary");

                testingTarget.Source = new Uri("http://www.contoso.com/");
            }
            catch (InvalidOperationException)
            {
                tlog.Debug(tag, $"ResourceDictionarySource END");
                Assert.Pass("Caught InvalidOperationException : Passed!");
            }
        }

        [Test]
        [Category("P1")]
        [Description("ResourceDictionary SetAndLoadSource")]
        [Property("SPEC", "Tizen.NUI.Binding.ResourceDictionary.SetAndLoadSource M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MCST")]
        public void ResourceDictionarySetAndLoadSourceTest()
        {
            tlog.Debug(tag, $"ResourceDictionarySetAndLoadSourceTest START");

            try
            {
                var testingTarget = new ResourceDictionary();
                Assert.IsNotNull(testingTarget, "null ResourceDictionary");

#pragma warning disable Reflection // The code contains reflection
                testingTarget.SetAndLoadSource(new Uri("http://www.contoso.com/"), "layout/MyResourceDictionary.xaml", typeof(UIElement).Assembly, null);
#pragma warning restore Reflection // The code contains reflection
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            tlog.Debug(tag, $"ResourceDictionarySetAndLoadSourceTest END");
        }

        [Test]
        [Category("P2")]
        [Description("ResourceDictionary SetAndLoadSource")]
        [Property("SPEC", "Tizen.NUI.Binding.ResourceDictionary.SetAndLoadSource M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MCST")]
        [Obsolete]
        public void ResourceDictionarySetAndLoadSourceArgumentException()
        {
            tlog.Debug(tag, $"ResourceDictionarySetAndLoadSourceArgumentException START");

            var testingTarget = new ResourceDictionary();
            Assert.IsNotNull(testingTarget, "null ResourceDictionary");

#pragma warning disable Reflection // The code contains reflection
            testingTarget.MergedWith = typeof(ResourceDictionary);
#pragma warning restore Reflection // The code contains reflection

#pragma warning disable Reflection // The code contains reflection
            Assert.Throws<ArgumentException>(() => testingTarget.SetAndLoadSource(new Uri("http://www.contoso.com/"), "X", typeof(View).Assembly, null));
#pragma warning restore Reflection // The code contains reflection

            tlog.Debug(tag, $"ResourceDictionarySetAndLoadSourceArgumentException END");
        }

        [Test]
        [Category("P1")]
        [Description("ResourceDictionary MergedDictionaries")]
        [Property("SPEC", "Tizen.NUI.Binding.ResourceDictionary.MergedDictionaries  A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        public void ResourceDictionaryMergedDictionaries()
        {
            tlog.Debug(tag, $"ResourceDictionaryMergedDictionaries START");

            try
            {
                var testingTarget = new ResourceDictionary();
                Assert.IsNotNull(testingTarget, "null ResourceDictionary");

                Assert.IsNotNull(testingTarget.MergedDictionaries, "Should be equal");
            }
            catch (Exception e)
            {
                Assert.Fail("Caught Exception" + e.ToString());
            }

            tlog.Debug(tag, $"ResourceDictionaryMergedDictionaries END");
        }

        [Test]
        [Category("P1")]
        [Description("ResourceDictionary Clear")]
        [Property("SPEC", "Tizen.NUI.Binding.ResourceDictionary.Clear  M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MCST")]
        public void ResourceDictionaryClear()
        {
            tlog.Debug(tag, $"ResourceDictionaryClear START");

            try
            {
                var testingTarget = new ResourceDictionary();
                Assert.IsNotNull(testingTarget, "null ResourceDictionary");

                testingTarget.Clear();
                Assert.AreEqual(0, testingTarget.Count, "Should be equal");
            }
            catch (Exception e)
            {
                Assert.Fail("Caught Exception" + e.ToString());
            }

            tlog.Debug(tag, $"ResourceDictionaryClear END");
        }

        [Test]
        [Category("P1")]
        [Description("ResourceDictionary Add")]
        [Property("SPEC", "Tizen.NUI.Binding.ResourceDictionary.Add  M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MCST")]
        public void ResourceDictionaryAdd()
        {
            tlog.Debug(tag, $"ResourceDictionaryAdd START");

            try
            {
                var testingTarget = new ResourceDictionary();
                Assert.IsNotNull(testingTarget, "null ResourceDictionary");

                testingTarget.Add("AA", "AA");
                var ret = testingTarget.ContainsKey("AA");
                Assert.AreEqual(true, ret, "Should be equal");

                var ret2 = testingTarget["AA"];
                Assert.AreEqual("AA", ret2, "Should be equal");

                Assert.AreEqual(1, testingTarget.Keys.Count, "Should be equal");
                Assert.AreEqual(1, testingTarget.Values.Count, "Should be equal");
                Assert.IsNotNull(testingTarget.GetEnumerator(), "null Enumerator");
                
                object obj;
                testingTarget.TryGetValue("AA", out obj);
                Assert.AreEqual("AA", obj as string, "Should be equal");

                var ret3 = testingTarget.Remove("AA");
                Assert.True(ret3, "Should be true");
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            tlog.Debug(tag, $"ResourceDictionaryAdd END");
        }

        [Test]
        [Category("P1")]
        [Description("ResourceDictionary Add")]
        [Property("SPEC", "Tizen.NUI.Binding.ResourceDictionary.Add  M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MCST")]
        public void ResourceDictionaryAddResourceDictionary()
        {
            tlog.Debug(tag, $"ResourceDictionaryAddResourceDictionary START");

            try
            {
                ResourceDictionary dic = new ResourceDictionary();
                dic.Add("AA", "AA");
                
                var testingTarget = new ResourceDictionary();
                Assert.IsNotNull(testingTarget, "null ResourceDictionary");

                testingTarget.Add(dic);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }
            
            tlog.Debug(tag, $"ResourceDictionaryAddResourceDictionary END");
        }

        [Test]
        [Category("P2")]
        [Description("ResourceDictionary Add")]
        [Property("SPEC", "Tizen.NUI.Binding.ResourceDictionary.Add  M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MCST")]
        public void ResourceDictionaryAddKeyIsPresent()
        {
            tlog.Debug(tag, $"ResourceDictionaryAddKeyIsPresent START");

            try
            {
                var testingTarget = new ResourceDictionary();
                Assert.IsNotNull(testingTarget, "null ResourceDictionary");

                testingTarget.Add("AA", "AA");
                testingTarget.Add("AA", "BB");
            }
            catch (ArgumentException)
            {
                tlog.Debug(tag, $"ResourceDictionaryAddKeyIsPresent END");
                Assert.Pass("Caught ArgumentException : Passed!");
            }
        }

        [Test]
        [Category("P2")]
        [Description("RDSourceTypeConverter ConvertFromInvariantString")]
        [Property("SPEC", "Tizen.NUI.Binding.ResourceDictionary.RDSourceTypeConverter.ConvertFromInvariantString  M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MCST")]
        public void RDSourceTypeConverterConvertFromInvariantString()
        {
            tlog.Debug(tag, $"RDSourceTypeConverterConvertFromInvariantString START");

            var testingTarget = new ResourceDictionary.RDSourceTypeConverter();
            Assert.Throws<NotImplementedException>(() => testingTarget.ConvertFromInvariantString("Test"));

            tlog.Debug(tag, $"RDSourceTypeConverterConvertFromInvariantString END");
        }

        [Test]
        [Category("P1")]
        [Description("RDSourceTypeConverter GetResourcePath")]
        [Property("SPEC", "Tizen.NUI.Binding.ResourceDictionary.RDSourceTypeConverter.GetResourcePath  M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        public void RDSourceTypeConverterGetResourcePath()
        {
            tlog.Debug(tag, $"RDSourceTypeConverterGetResourcePath START");

            try
            {
                var ret = ResourceDictionary.RDSourceTypeConverter.GetResourcePath(new Uri("https://user:password@www.contoso.com:80/Home/Index.htm?q1=v1&q2=v2#FragmentName"), "");

                Assert.IsNotNull(ret, "Should not be null");
            }
            catch (ArgumentException e)
            {
                Assert.True(true, "Caught Exception" + e.ToString());
            }

            tlog.Debug(tag, $"RDSourceTypeConverterGetResourcePath END");
        }
    }
}