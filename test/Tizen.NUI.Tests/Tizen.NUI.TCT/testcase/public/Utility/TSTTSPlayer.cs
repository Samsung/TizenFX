using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("public/Utility/TTSPlayer")]
    class PublicTTSPlayerTest
    {
        private const string tag = "NUITEST";
        private bool flagStateChanged = false;
        private string image_path = Tizen.Applications.Application.Current.DirectoryInfo.Resource + "picture.png";

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
        [Description("TTSPlayer constructor. With TTSPlayer handler.")]
        [Property("SPEC", "Tizen.NUI.TTSPlayer.TTSPlayer C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TTSPlayerConstructorWithTTSPlayerHandler()
        {
            tlog.Debug(tag, $"TTSPlayerConstructorWithTTSPlayerHandler START");

            using (TTSPlayer player = TTSPlayer.Get())
            {
                var testingTarget = new TTSPlayer(player);
                Assert.IsNotNull(testingTarget, "Can't create success object TTSPlayer");
                Assert.IsInstanceOf<TTSPlayer>(testingTarget, "Should be an instance of TTSPlayer type.");

                testingTarget.Dispose();
            }
 
            tlog.Debug(tag, $"TTSPlayerConstructorWithTTSPlayerHandler END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TTSPlayer StateChanged.")]
        [Property("SPEC", "Tizen.NUI.TTSPlayer.StateChanged A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TTSPlayerStateChanged()
        {
            tlog.Debug(tag, $"TTSPlayerStateChanged START");

            using (TTSPlayer player = TTSPlayer.Get())
            {
                var testingTarget = new TTSPlayer(player);
                Assert.IsNotNull(testingTarget, "Can't create success object TTSPlayer");
                Assert.IsInstanceOf<TTSPlayer>(testingTarget, "Should be an instance of TTSPlayer type.");

                testingTarget.StateChanged += StateChangedEvent;
                testingTarget.StateChanged -= StateChangedEvent;

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"TTSPlayerStateChanged END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TTSPlayer StateChangedSignal.")]
        [Property("SPEC", "Tizen.NUI.TTSPlayer.StateChangedSignal M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TTSPlayerStateChangedSignal()
        {
            tlog.Debug(tag, $"TTSPlayerStateChangedSignal START");

            using (TTSPlayer player = TTSPlayer.Get())
            {
                var testingTarget = new TTSPlayer(player);
                Assert.IsNotNull(testingTarget, "Can't create success object TTSPlayer");
                Assert.IsInstanceOf<TTSPlayer>(testingTarget, "Should be an instance of TTSPlayer type.");

                var result = testingTarget.StateChangedSignal();
                Assert.IsNotNull(result, "Can't create success object StateChangedSignalType");
                Assert.IsInstanceOf<StateChangedSignalType>(result, "Should be an instance of StateChangedSignalType type.");

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"TTSPlayerStateChangedSignal END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TTSPlayer Assign.")]
        [Property("SPEC", "Tizen.NUI.TTSPlayer.Assign M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TTSPlayerAssign()
        {
            tlog.Debug(tag, $"TTSPlayerAssign START");

            using (TTSPlayer player = new TTSPlayer())
            {
                using (TTSPlayer rhs = TTSPlayer.Get(TTSPlayer.TTSMode.ScreenReader))
                {
                    var testingTarget = player.Assign(rhs);
                    Assert.IsNotNull(testingTarget, "Can't create success object TTSPlayer");
                    Assert.IsInstanceOf<TTSPlayer>(testingTarget, "Should be an instance of TTSPlayer type.");

                    testingTarget.Dispose();
                }
            }

            tlog.Debug(tag, $"TTSPlayerAssign END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("StateChangedEventArgs PrevState.")]
        [Property("SPEC", "Tizen.NUI.StateChangedEventArgs.PrevState A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TTSPlayerStateChangedEventArgsPrevState()
        {
            tlog.Debug(tag, $"TTSPlayerStateChangedEventArgsPrevState START");

            var testingTarget = new TTSPlayer.StateChangedEventArgs();
            Assert.IsNotNull(testingTarget, "Can't create success object StateChangedEventArgs");
            Assert.IsInstanceOf<TTSPlayer.StateChangedEventArgs>(testingTarget, "Should be an instance of StateChangedEventArgs type.");

            testingTarget.PrevState = TTSPlayer.TTSState.Ready;
            Assert.AreEqual(TTSPlayer.TTSState.Ready, testingTarget.PrevState);

            tlog.Debug(tag, $"TTSPlayerStateChangedEventArgsPrevState END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("StateChangedEventArgs NextState.")]
        [Property("SPEC", "Tizen.NUI.StateChangedEventArgs.NextState A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TTSPlayerStateChangedEventArgsNextState()
        {
            tlog.Debug(tag, $"TTSPlayerStateChangedEventArgsNextState START");

            var testingTarget = new TTSPlayer.StateChangedEventArgs();
            Assert.IsNotNull(testingTarget, "Can't create success object StateChangedEventArgs");
            Assert.IsInstanceOf<TTSPlayer.StateChangedEventArgs>(testingTarget, "Should be an instance of StateChangedEventArgs type.");

            testingTarget.NextState = TTSPlayer.TTSState.Playing;
            Assert.AreEqual(TTSPlayer.TTSState.Playing, testingTarget.NextState);

            tlog.Debug(tag, $"TTSPlayerStateChangedEventArgsNextState END (OK)");
        }

        private void StateChangedEvent(object sender, TTSPlayer.StateChangedEventArgs args)
        {
            flagStateChanged = true;
        }
    }
}
