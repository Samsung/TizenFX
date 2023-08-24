using NUnit.Framework;
using System;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Binding;
using Tizen.NUI.Binding.Internals;
using Tizen.NUI.Xaml;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("public/XamlBinding/Registrar")]
    internal class PublicRegistrarTest
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
        [Description("Registrar Effects ")]
        [Property("SPEC", "Tizen.NUI.Binding.Registrar.Effects  A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        public void EffectsTest()
        {
            tlog.Debug(tag, $"EffectsTest START");
            
            try
            {
                var ret = Registrar.Effects;
                Assert.IsNotNull(ret, "null Effects");
                Assert.AreEqual(0, ret.Count, "Should be equal");
            }
            catch (Exception e)
            {
                Assert.Fail("Caught Exception" + e.ToString());
            }
            
            tlog.Debug(tag, $"EffectsTest END");
        }

        [Test]
        [Category("P1")]
        [Description("Registrar ExtraAssemblies")]
        [Property("SPEC", "Tizen.NUI.Binding.Registrar.ExtraAssemblies  A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        public void ExtraAssembliesTest()
        {
            tlog.Debug(tag, $"ExtraAssemblies START");

            try
            {
                Registrar.ExtraAssemblies = null;
                Assert.IsNull(Registrar.ExtraAssemblies, "null ExtraAssemblies");
            }
            catch (Exception e)
            {
                Assert.Fail("Caught Exception" + e.ToString());
            }

            tlog.Debug(tag, $"ExtraAssemblies END");
        }

        [Test]
        [Category("P1")]
        [Description("Registrar Register")]
        [Property("SPEC", "Tizen.NUI.Binding.Registrar<TRegistrable>.Register M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MCST")]
        public void RegisterTest()
        {
            tlog.Debug(tag, $"RegisterTest START");
            try
            {
                var re = new Registrar<View>();
                re.Register(typeof(View), typeof(View));
                var ret = re.GetHandlerType(typeof(View));
                Assert.AreEqual(typeof(View), ret, "Should be equal");
                var ret2 = re.GetHandlerType(typeof(Element));
                Assert.IsNull(ret2, "Should be null");

                var ret3 = re.GetHandlerTypeForObject(new View());
                Assert.AreEqual(typeof(View), ret, "Should be equal");
            }
            catch(Exception e)
            {
                Assert.Fail("Caught Exception" + e.ToString());
            }
            tlog.Debug(tag, $"RegisterTest END");
        }

        [Test]
        [Category("P2")]
        [Description("Registrar Register")]
        [Property("SPEC", "Tizen.NUI.Binding.Registrar<TRegistrable>.Register M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MCST")]
        public void RegisterTest2()
        {
            tlog.Debug(tag, $"RegisterTest2 START");
            var re = new Registrar<View>();
            Assert.Throws<ArgumentNullException>(() => re.GetHandlerTypeForObject(null));
            tlog.Debug(tag, $"RegisterTest2 END");
        }

        [Test]
        [Category("P1")]
        [Description("Registrar GetHandler")]
        [Property("SPEC", "Tizen.NUI.Binding.Registrar<TRegistrable>.GetHandler M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MCST")]
        public void GetHandlerTest()
        {
            tlog.Debug(tag, $"GetHandlerTest START");
            try
            {
                var re = new Registrar<View>();
                re.Register(typeof(View), typeof(View));
                var ret = re.GetHandler(typeof(View));
                Assert.IsNotNull(ret, "Should not be null");
            }
            catch (Exception e)
            {
                Assert.Fail("Caught Exception" + e.ToString());
            }
            tlog.Debug(tag, $"GetHandlerTest END");
        }

        [Test]
        [Category("P2")]
        [Description("Registrar GetHandler")]
        [Property("SPEC", "Tizen.NUI.Binding.Registrar<TRegistrable>.GetHandler M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MCST")]
        public void GetHandlerTest2()
        {
            tlog.Debug(tag, $"GetHandlerTest2 START");
            try
            {
                var re = new Registrar<View>();
                re.Register(typeof(View), typeof(View));

                var ret = re.GetHandler(typeof(View), new object[] { "" });
                //Assert.IsNull(ret, "Should be null");
            }
            catch (MissingMethodException e)
            {
                Assert.True(true, "Caught Exception" + e.ToString());
            }
            tlog.Debug(tag, $"GetHandlerTest2 END");
        }

        [Test]
        [Category("P1")]
        [Description("Registrar GetHandler")]
        [Property("SPEC", "Tizen.NUI.Binding.Registrar<TRegistrable>.GetHandler M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MCST")]
        public void GetHandlerTest3()
        {
            tlog.Debug(tag, $"GetHandlerTest3 START");
            try
            {
                var re = new Registrar<View>();
                re.Register(typeof(View), typeof(View));

                var ret = re.GetHandler<View>(typeof(View));
            }
            catch (Exception e)
            {
                Assert.Fail("Caught Exception" + e.ToString());
            }
            tlog.Debug(tag, $"GetHandlerTest3 END");
        }

        [Test]
        [Category("P1")]
        [Description("Registrar GetHandler")]
        [Property("SPEC", "Tizen.NUI.Binding.Registrar<TRegistrable>.GetHandler M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MCST")]
        public void GetHandlerTest4()
        {
            tlog.Debug(tag, $"GetHandlerTest4 START");
            try
            {
                var re = new Registrar<View>();
                re.Register(typeof(View), typeof(View));

                var ret = re.GetHandler<View>(typeof(View), new object[] { "" });
                //Assert.IsNull(ret, "Should be null");
            }
            catch (MissingMethodException e)
            {
                Assert.True(true, "Caught Exception" + e.ToString());
            }
            tlog.Debug(tag, $"GetHandlerTest4 END");
        }


        [Test]
        [Category("P1")]
        [Description("Registrar GetHandler")]
        [Property("SPEC", "Tizen.NUI.Binding.Registrar<TRegistrable>.GetHandlerForObject<TOut> M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MCST")]
        public void GetHandlerForObjectTest()
        {
            tlog.Debug(tag, $"GetHandlerForObjectTest START");
            try
            {
                var re = new Registrar<View>();
                var ret = re.GetHandlerForObject<View>(new View());
                Assert.IsNull(ret, "Should be null");

                ret = re.GetHandlerForObject<View>(new View(), new object[] { "" });
                Assert.IsNull(ret, "Should be null");
            }
            catch (Exception e)
            {
                Assert.Fail("Caught Exception" + e.ToString());
            }
            tlog.Debug(tag, $"GetHandlerForObjectTest END");
        }

        [Test]
        [Category("P2")]
        [Description("Registrar GetHandler")]
        [Property("SPEC", "Tizen.NUI.Binding.Registrar<TRegistrable>.GetHandlerForObject<TOut> M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MCST")]
        public void GetHandlerForObjectTest2()
        {
            tlog.Debug(tag, $"GetHandlerForObjectTest2 START");
            try
            {
            var re = new Registrar<View>();
            var ret =  re.GetHandlerForObject<View>(new View());
            }
            catch(Exception e)
            {
                Assert.Fail("Caught Exception" + e.ToString());
            }
            tlog.Debug(tag, $"GetHandlerForObjectTest2 END");
        }

        [Test]
        [Category("P2")]
        [Description("Registrar GetHandler")]
        [Property("SPEC", "Tizen.NUI.Binding.Registrar<TRegistrable>.GetHandlerForObject<TOut> M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MCST")]
        public void GetHandlerForObjectTest3()
        {
            tlog.Debug(tag, $"GetHandlerForObjectTest3 START");
            try{
                var re = new Registrar<View>();
                var ret = re.GetHandlerForObject<View>(new View(), new object[] { "" });
            }
            catch(Exception e)
            {
                Assert.Fail("Caught Exception" + e.ToString());
            }
            tlog.Debug(tag, $"GetHandlerForObjectTest3 END");
        }
    }
}