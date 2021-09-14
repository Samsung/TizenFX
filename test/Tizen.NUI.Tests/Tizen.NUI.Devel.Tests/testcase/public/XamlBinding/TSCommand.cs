using NUnit.Framework;
using System;
using Tizen.NUI.Binding;
using Tizen.NUI.Xaml;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("public/XamlBinding/Command")]
    internal class PublicCommandTest
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
        [Description("Command Command")]
        [Property("SPEC", "Tizen.NUI.Binding.Command.Command C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("COVPARAM", "Action")]
        public void CommandConstructor()
        {
            tlog.Debug(tag, $"CommandConstructor START");
            Command t2 = new Command(() => { });
            Assert.IsNotNull(t2, "null Command");
            Assert.IsInstanceOf<Command>(t2, "Should return Command instance.");
            tlog.Debug(tag, $"CommandConstructor END");
        }

        [Test]
        [Category("P2")]
        [Description("Command Command")]
        [Property("SPEC", "Tizen.NUI.Binding.Command.Command C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("COVPARAM", "Action<object>")]
        public void CommandConstructor2()
        {
            tlog.Debug(tag, $"CommandConstructor2 START");
            Assert.Throws<ArgumentNullException>(() => new Command((Action<object>)null));
            tlog.Debug(tag, $"CommandConstructor2 END");
        }

        [Test]
        [Category("P1")]
        [Description("Command Command")]
        [Property("SPEC", "Tizen.NUI.Binding.Command.Command C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("COVPARAM", "Action<object>")]
        public void CommandConstructor3()
        {
            tlog.Debug(tag, $"CommandConstructor3 START");
            Command t2 = new Command((obj) => { });
            Assert.IsNotNull(t2, "null Command");
            Assert.IsInstanceOf<Command>(t2, "Should return Command instance.");
            tlog.Debug(tag, $"CommandConstructor3 END");
        }

        [Test]
        [Category("P2")]
        [Description("Command Command")]
        [Property("SPEC", "Tizen.NUI.Binding.Command.Command C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("COVPARAM", "Action")]
        public void CommandConstructor4()
        {
            tlog.Debug(tag, $"CommandConstructor4 START");
            Assert.Throws<ArgumentNullException>(() => new Command((Action)null));
            tlog.Debug(tag, $"CommandConstructor4 END");
        }

        [Test]
        [Category("P1")]
        [Description("Command Command")]
        [Property("SPEC", "Tizen.NUI.Binding.Command.Command C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("COVPARAM", "Action<object>,Func<object,bool>")]
        public void CommandConstructor5()
        {
            tlog.Debug(tag, $"CommandConstructor5 START");
            Command t2 = new Command((obj) => { }, (obj) => { return true; });
            Assert.IsNotNull(t2, "null Command");
            Assert.IsInstanceOf<Command>(t2, "Should return Command instance.");
            tlog.Debug(tag, $"CommandConstructor5 END");
        }

        [Test]
        [Category("P2")]
        [Description("Command Command")]
        [Property("SPEC", "Tizen.NUI.Binding.Command.Command C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("COVPARAM", "Action<object>,Func<object,bool>")]
        public void CommandConstructor6()
        {
            tlog.Debug(tag, $"CommandConstructor6 START");
            Assert.Throws<ArgumentNullException>(() => new Command((obj) => { }, (Func<object, bool>)null));
            tlog.Debug(tag, $"CommandConstructor6 END");
        }

        [Test]
        [Category("P1")]
        [Description("Command Command")]
        [Property("SPEC", "Tizen.NUI.Binding.Command.Command C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("COVPARAM", "Action,Func<bool>")]
        public void CommandConstructor7()
        {
            tlog.Debug(tag, $"CommandConstructor7 START");
            Command t2 = new Command(() => { }, () => { return true; });
            Assert.IsNotNull(t2, "null Command");
            Assert.IsInstanceOf<Command>(t2, "Should return Command instance.");
            tlog.Debug(tag, $"CommandConstructor7 END");
        }

        [Test]
        [Category("P2")]
        [Description("Command Command")]
        [Property("SPEC", "Tizen.NUI.Binding.Command.Command C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("COVPARAM", "Action,Func<bool>")]
        public void CommandConstructor8()
        {
            tlog.Debug(tag, $"CommandConstructor8 START");
            Assert.Throws<ArgumentNullException>(() => new Command((Action)null, ()=> { return true; }));
            tlog.Debug(tag, $"CommandConstructor8 END");
        }

        [Test]
        [Category("P2")]
        [Description("Command Command")]
        [Property("SPEC", "Tizen.NUI.Binding.Command.Command C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("COVPARAM", "Action,Func<bool>")]
        public void CommandConstructor9()
        {
            tlog.Debug(tag, $"CommandConstructor9 START");
            Assert.Throws<ArgumentNullException>(() => new Command(() => { }, (Func<bool>)null));
            tlog.Debug(tag, $"CommandConstructor9 END");
        }

        [Test]
        [Category("P1")]
        [Description("Command  CanExecute")]
        [Property("SPEC", "Tizen.NUI.Binding.Command.CanExecute M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        public void CanExecuteTest()
        {
            tlog.Debug(tag, $"CanExecuteTest START");
            try
            {
                Command t2 = new Command((obj)=> { }, (obj) => { return true; });
                Assert.IsNotNull(t2, "null Command");
                bool ret = t2.CanExecute("para");
                Assert.IsTrue(ret, "Should be true");
            }
            catch (Exception e)
            {
                Assert.Fail("Caught Exception" + e.ToString());
            }
            tlog.Debug(tag, $"CanExecuteTest END");
        }

        [Test]
        [Category("P1")]
        [Description("Command  CanExecute")]
        [Property("SPEC", "Tizen.NUI.Binding.Command.CanExecute M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        public void CanExecuteTest2()
        {
            tlog.Debug(tag, $"CanExecuteTest2 START");
            try
            {
                Command t2 = new Command((obj) => { }, (obj) => { return true; });
                Assert.IsNotNull(t2, "null Command");
                bool ret = t2.CanExecute("para"); //default return true
                Assert.IsTrue(ret, "Should be true"); 
            }
            catch (Exception e)
            {
                Assert.Fail("Caught Exception" + e.ToString());
            }
            tlog.Debug(tag, $"CanExecuteTest2 END");
        }

        [Test]
        [Category("P1")]
        [Description("Command  CanExecute")]
        [Property("SPEC", "Tizen.NUI.Binding.Command.Execute M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MCST")]
        public void ExecuteTest()
        {
            tlog.Debug(tag, $"ExecuteTest START");
            try
            {
                Command t2 = new Command((obj) => { }, (obj) => { return true; });
                Assert.IsNotNull(t2, "null Command");
                t2.Execute("para");
                Assert.True(true, "Should go here");
            }
            catch (Exception e)
            {
                Assert.Fail("Caught Exception" + e.ToString());
            }
            tlog.Debug(tag, $"ExecuteTest END");
        }

        [Test]
        [Category("P1")]
        [Description("Command  CanExecute")]
        [Property("SPEC", "Tizen.NUI.Binding.Command.ChangeCanExecute M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MCST")]
        public void ChangeCanExecuteTest()
        {
            tlog.Debug(tag, $"ChangeCanExecuteTest START");
            try
            {
                Command t2 = new Command((obj) => { }, (obj) => { return true; });
                Assert.IsNotNull(t2, "null Command");
                t2.ChangeCanExecute();
                Assert.True(true, "Should go here");
            }
            catch (Exception e)
            {
                Assert.Fail("Caught Exception" + e.ToString());
            }
            tlog.Debug(tag, $"ChangeCanExecuteTest END");
        }

        [Test]
        [Category("P1")]
        [Description("Command Command")]
        [Property("SPEC", "Tizen.NUI.Binding.Command<T>.Command C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("COVPARAM", "Action<T>")]
        public void CommandConstructor10()
        {
            tlog.Debug(tag, $"CommandConstructor10 START");
            Command t2 = new Command<object>((obj) => { });
            Assert.IsNotNull(t2, "null Command");
            Assert.IsInstanceOf<Command>(t2, "Should return Command instance.");
            tlog.Debug(tag, $"CommandConstructor10 END");
        }

        [Test]
        [Category("P1")]
        [Description("Command Command")]
        [Property("SPEC", "Tizen.NUI.Binding.Command<T>.Command C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("COVPARAM", "Action<T>,Func<T,bool>")]
        public void CommandConstructor11()
        {
            tlog.Debug(tag, $"CommandConstructor11 START");
            Command t2 = new Command<object>((obj) => { }, (obj) => { return true; });
            Assert.IsNotNull(t2, "null Command");
            Assert.IsInstanceOf<Command>(t2, "Should return Command instance.");
            tlog.Debug(tag, $"CommandConstructor11 END");
        }

        [Test]
        [Category("P2")]
        [Description("Command Command")]
        [Property("SPEC", "Tizen.NUI.Binding.Command<T>.Command C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("COVPARAM", "Action<T>")]
        public void CommandConstructor12()
        {
            tlog.Debug(tag, $"CommandConstructor12 START");
            Assert.Throws<ArgumentNullException>(() => new Command<object>((Action<object>)null));
            tlog.Debug(tag, $"CommandConstructor12 END");
        }

        [Test]
        [Category("P2")]
        [Description("Command Command")]
        [Property("SPEC", "Tizen.NUI.Binding.Command.Command C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("COVPARAM", "Action<T>,Func<T,bool>")]
        public void CommandConstructor13()
        {
            tlog.Debug(tag, $"CommandConstructor13 START");
            Assert.Throws<ArgumentNullException>(() => new Command<object>((obj) => { }, (Func<object, bool>)null));
            tlog.Debug(tag, $"CommandConstructor13 END");
        }

        [Test]
        [Category("P2")]
        [Description("Command Command")]
        [Property("SPEC", "Tizen.NUI.Binding.Command.Command C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("COVPARAM", "Action<T>,Func<T,bool>")]
        public void CommandConstructor14()
        {
            tlog.Debug(tag, $"CommandConstructor14 START");
            Assert.Throws<ArgumentNullException>(() => new Command<object>((Action<object>)null, (Func<object, bool>)null));
            tlog.Debug(tag, $"CommandConstructor14 END");
        }
    }
}