
using global::System;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using NUnit.Framework;
using System.Threading.Tasks;

namespace Tizen.NUI.Samples
{
    using tlog = Tizen.Log;
    public class AddFrameRenderedCallbackTest : IExample
    {
        const string tag = "NUITEST";

        public void Activate()
        {
            test();
        }
        public void Deactivate()
        {
        }

        Window win;
        Window.FrameCallbackType cb;
        void test()
        {
            win = NUIApplication.GetDefaultWindow();
            win.TouchEvent += WinTouchEvent;
            View view = new View();
            view.Size = new Size(100, 100);
            view.BackgroundColor = Color.Blue;
            win.Add(view);

            cb = testCallback;
            win.AddFrameRenderedCallback(cb, 0);
            win.AddFramePresentedCallback(cb, 0);

            Timer timer = new Timer(5000);
            timer.Tick += testOnTick;
            timer.Start();
        }

        private void WinTouchEvent(object sender, Window.TouchEventArgs e)
        {
            win.AddFrameRenderedCallback(cb, cnt++);
            Console.WriteLine($"testOnTick() AddFrameRenderedCallback() send id={cnt}");
            win.AddFramePresentedCallback(cb, cnt++);
            Console.WriteLine($"testOnTick() AddFramePresentedCallback() send id={cnt}");
        }

        int cnt;
        bool testOnTick(object o, Timer.TickEventArgs e)
        {
            win.AddFrameRenderedCallback(cb, cnt++);
            Console.WriteLine($"testOnTick() AddFrameRenderedCallback() send id={cnt}");
            win.AddFramePresentedCallback(cb, cnt++);
            Console.WriteLine($"testOnTick() AddFramePresentedCallback() send id={cnt}");
            return true;
        }

        void testCallback(int id)
        {
            Console.WriteLine($"testCallback() id={id}");
        }


        [Test]
        public async Task Test_AddFrameRenderedCallback()
        {
            var isCalled = false;
            Tizen.NUI.Window.FrameCallbackType callback = (int id) =>
            {
                isCalled = true;
            };

            win.AddFrameRenderedCallback(callback, 0);

            await Task.Delay(500);

            Assert.IsTrue(isCalled, "isCalled should be true");
        }
        [Test]
        public async Task Test_AddFramePresentedCallback()
        {
            var isCalled = false;
            Tizen.NUI.Window.FrameCallbackType callback = (int id) =>
            {
                isCalled = true;
            };

            win.AddFramePresentedCallback(callback, 0);

            await Task.Delay(500);

            Assert.IsTrue(isCalled, "isCalled should be true");
        }

        [Test]
        public void Test_AddFrameRenderedCallbackNegative()
        {
            try
            {
                win.AddFrameRenderedCallback(null, 0);
            }
            catch (Exception ex)
            {
                if (ex is ArgumentNullException)
                {
                    Assert.Pass();
                }
                else
                {
                    Assert.Fail("ArgumentNullException should occur");
                }
            }
        }

        [Test]
        public void Test_AddFramePresentedCallbackNegative()
        {
            try
            {
                win.AddFramePresentedCallback(null, 0);
            }
            catch (Exception ex)
            {
                if (ex is ArgumentNullException)
                {
                    Assert.Pass();
                }
                else
                {
                    Assert.Fail("ArgumentNullException should occur");
                }
            }
        }
        [Test]
        public async Task Test_AddFrameRenderedCallbackId()
        {
            var checkId = -1;
            Tizen.NUI.Window.FrameCallbackType callback = (int id) =>
            {
                checkId = id;
            };

            var testId = 9;
            win.AddFrameRenderedCallback(callback, testId);

            await Task.Delay(500);

            Assert.AreEqual(testId, checkId, "should be same");
        }

        [Test]
        public async Task Test_AddFramePresentedCallbackId()
        {
            var checkId = -1;
            Tizen.NUI.Window.FrameCallbackType callback = (int id) =>
            {
                checkId = id;
            };

            var testId = 7;
            win.AddFramePresentedCallback(callback, testId);

            await Task.Delay(500);

            Assert.AreEqual(testId, checkId, "should be same");
        }
    }
}
