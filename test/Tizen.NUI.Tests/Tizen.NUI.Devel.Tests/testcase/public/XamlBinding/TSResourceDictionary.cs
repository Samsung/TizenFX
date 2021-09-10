using NUnit.Framework;
using System;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Binding;
using Tizen.NUI.Xaml;

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
        public void MergedWithTest1()
        {
            tlog.Debug(tag, $"MergedWithTest1 START");
            
            try
            {
                ResourceDictionary t1 = new ResourceDictionary();
                Assert.IsNotNull(t1, "null ResourceDictionary");
                ResourceDictionary t2 = new ResourceDictionary();
                Assert.IsNotNull(t2, "null ResourceDictionary");
                t2.MergedWith = typeof(ResourceDictionary);
                t2.MergedWith = typeof(ResourceDictionary);

                t1.Source = null;
                Assert.IsNull(t1.Source, "Should be null");
            }
            catch (Exception e)
            {
                Assert.Fail("Caught Exception" + e.ToString());
            }
            
            tlog.Debug(tag, $"MergedWithTest1 END");
        }

        [Test]
        [Category("P1")]
        [Description("ResourceDictionary SetAndLoadSource")]
        [Property("SPEC", "Tizen.NUI.Binding.ResourceDictionary.SetAndLoadSource M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MCST")]
        public void SetAndLoadSourceTest()
        {
            tlog.Debug(tag, $"SetAndLoadSourceTest START");
            try
            {
                ResourceDictionary t1 = new ResourceDictionary();
                Assert.IsNotNull(t1, "null ResourceDictionary");
                //t1.SetAndLoadSource(new Uri("http://www.contoso.com/"), "X", typeof(View).Assembly, null);
                //Assert.True(true, "Should go here");
            }
            catch (Exception e)
            {
                Assert.Fail("Caught Exception" + e.ToString());
            }
            tlog.Debug(tag, $"SetAndLoadSourceTest END");
        }

        [Test]
        [Category("P2")]
        [Description("ResourceDictionary SetAndLoadSource")]
        [Property("SPEC", "Tizen.NUI.Binding.ResourceDictionary.SetAndLoadSource M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MCST")]
        public void SetAndLoadSourceTest2()
        {
            tlog.Debug(tag, $"SetAndLoadSourceTest2 START");
            ResourceDictionary t1 = new ResourceDictionary();
            Assert.IsNotNull(t1, "null ResourceDictionary");
            ResourceDictionary t2 = new ResourceDictionary();
            Assert.IsNotNull(t2, "null ResourceDictionary");
            t1.MergedWith = typeof(ResourceDictionary);
            //Assert.Throws<ArgumentException>(() => t1.SetAndLoadSource(new Uri("http://www.contoso.com/"), "X", typeof(View).Assembly, null));
            
            tlog.Debug(tag, $"SetAndLoadSourceTest2 END");
        }

        [Test]
        [Category("P1")]
        [Description("ResourceDictionary  MergedDictionaries")]
        [Property("SPEC", "Tizen.NUI.Binding.ResourceDictionary.MergedDictionaries  A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        public void MergedDictionariesTest1()
        {
            tlog.Debug(tag, $"MergedDictionariesTest1 START");
            try
            {
                ResourceDictionary t2 = new ResourceDictionary();
                Assert.IsNotNull(t2, "null ResourceDictionary");
                Assert.IsNotNull(t2.MergedDictionaries, "Should be equal");
            }
            catch (Exception e)
            {
                Assert.Fail("Caught Exception" + e.ToString());
            }
            tlog.Debug(tag, $"MergedDictionariesTest1 END");
        }

        [Test]
        [Category("P1")]
        [Description("ResourceDictionary  Clear")]
        [Property("SPEC", "Tizen.NUI.Binding.ResourceDictionary.Clear  M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MCST")]
        public void ClearTest1()
        {
            tlog.Debug(tag, $"ClearTest1 START");
            try
            {
                ResourceDictionary t2 = new ResourceDictionary();
                Assert.IsNotNull(t2, "null ResourceDictionary");
                t2.Clear();
                Assert.AreEqual(0, t2.Count, "Should be equal");
                Assert.True(true, "Should go here");
            }
            catch (Exception e)
            {
                Assert.Fail("Caught Exception" + e.ToString());
            }
            tlog.Debug(tag, $"ClearTest1 END");
        }

        [Test]
        [Category("P1")]
        [Description("ResourceDictionary  Add")]
        [Property("SPEC", "Tizen.NUI.Binding.ResourceDictionary.Add  M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MCST")]
        public void AddTest1()
        {
            tlog.Debug(tag, $"AddTest1 START");
            try
            {
                ResourceDictionary t2 = new ResourceDictionary();
                Assert.IsNotNull(t2, "null ResourceDictionary");
                t2.Add("AA", "AA");
                var ret = t2.ContainsKey("AA");
                Assert.AreEqual(true, ret, "Should be equal");
                var ret2 = t2["AA"];
                Assert.AreEqual("AA", ret2, "Should be equal");
                Assert.AreEqual(1, t2.Keys.Count, "Should be equal");
                Assert.AreEqual(1, t2.Values.Count, "Should be equal");
                Assert.IsNotNull(t2.GetEnumerator(), "null Enumerator");
                object ss;
                t2.TryGetValue("AA", out ss);
                Assert.AreEqual("AA", ss as string, "Should be equal");
                var ret3 = t2.Remove("AA");
                Assert.True(ret3, "Should be true");
            }
            catch (Exception e)
            {
                Assert.Fail("Caught Exception" + e.ToString());
            }
            tlog.Debug(tag, $"AddTest1 END");
        }

        [Test]
        [Category("P1")]
        [Description("ResourceDictionary  Add")]
        [Property("SPEC", "Tizen.NUI.Binding.ResourceDictionary.Add  M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MCST")]
        public void AddTest2()
        {
            tlog.Debug(tag, $"AddTest2 START");
            try
            {
                ResourceDictionary t1 = new ResourceDictionary();
                Assert.IsNotNull(t1, "null ResourceDictionary");
                t1.Add("AA", "AA");
                ResourceDictionary t2 = new ResourceDictionary();
                Assert.IsNotNull(t2, "null ResourceDictionary");
                t2.Add("BB", "BB");
                t2.Add(t1);

                Assert.True(true, "Should go here");
            }
            catch (Exception e)
            {
                Assert.Fail("Caught Exception" + e.ToString());
            }  
            tlog.Debug(tag, $"AddTest2 END");
        }

        [Test]
        [Category("P2")]
        [Description("ResourceDictionary  Add")]
        [Property("SPEC", "Tizen.NUI.Binding.ResourceDictionary.RDSourceTypeConverter.ConvertFromInvariantString  M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MCST")]
        public void ConvertFromInvariantStringTest()
        {
            tlog.Debug(tag, $"AddTest2 START");
            ResourceDictionary.RDSourceTypeConverter r = new ResourceDictionary.RDSourceTypeConverter();
            Assert.Throws<NotImplementedException>(() => r.ConvertFromInvariantString("Test"));
            tlog.Debug(tag, $"AddTest2 END");
        }
    }
}