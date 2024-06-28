
using global::System;
using Tizen.NUI.BaseComponents;
using System.Runtime.InteropServices;

namespace Tizen.NUI.Samples
{
    using tlog = Tizen.Log;

    public class VideoViewTest : IExample
    {
        // Make derieved class from Tizen.Multimedia.Player because protected Player(IntPtr handle, Action<int, string> errorHandler)
        // this constructor's access modifyer is protected, so there is no other way.
        public class myPlayer : Tizen.Multimedia.Player
        {
            public myPlayer() : base()
            {
                //Initialize();
            }

            public myPlayer(IntPtr p) : base(p, null)
            {
                //Initialize();
            }
        }

        Window win = null;
        myPlayer player = null;
        string resourcePath;
        const string tag = "NUITEST";
        View dummy = null;
        Animation animation;

        private const string KEY_NUM_1 = "1";
        private const string KEY_NUM_2 = "2";
        private const string KEY_NUM_3 = "3";
        private const string KEY_NUM_4 = "4";
        private const string KEY_NUM_5 = "5";
        private const string KEY_NUM_6 = "6";
        private const string KEY_NUM_7 = "7";
        private const string KEY_NUM_8 = "8";
        private const string KEY_NUM_9 = "9";
        private const string KEY_NUM_0 = "0";

        public void Activate()
        {
            win = NUIApplication.GetDefaultWindow();
            win.BackgroundColor = new Color(1, 1, 1, 0);
            win.KeyEvent += Win_KeyEvent;
            win.TouchEvent += Win_TouchEvent;

            dummy = new View();
            dummy.Size = new Size(200, 200);
            dummy.BackgroundColor = new Color(1, 1, 1, 0.5f);
            win.Add(dummy);

            resourcePath = Tizen.Applications.Application.Current.DirectoryInfo.Resource + "v.mp4";
            tlog.Fatal(tag, $"resourcePath: {resourcePath}");

            NUIVideoViewTest();
            //PlayerTest();
        }
        public void Deactivate()
        {
            win.KeyEvent -= Win_KeyEvent;
            win.TouchEvent -= Win_TouchEvent;

            tlog.Fatal(tag, $"Deactivate()!");

            if (dummy) { dummy.Unparent(); }
            if (videoView) { videoView.Unparent(); }

            // currently it is crashed when Dispose() is called. need to check.
            //videoView.Dispose();
            //videoView = null;
            //player.Unprepare();
            //player.Dispose();
            //player = null;
            tlog.Fatal(tag, $"Deactivate()! videoView dispsed");
        }

        int cnt;
        private void Win_TouchEvent(object sender, Window.TouchEventArgs e)
        {
            if (e.Touch.GetState(0) == PointStateType.Down)
            {
                if (++cnt % 2 == 1)
                {
                    if (player != null)
                    {
                        player.Pause();
                        tlog.Fatal(tag, $"player pause!");
                    }
                }
                else
                {
                    if (player != null)
                    {
                        player.Start();
                        tlog.Fatal(tag, $"player start!");
                    }
                }
            }
        }

        public async void PlayerTest()
        {
            player = new myPlayer();

            player.SetSource(new Tizen.Multimedia.MediaUriSource(resourcePath));

            player.Display = new Tizen.Multimedia.Display(win);

            await player.PrepareAsync().ConfigureAwait(false);
            tlog.Fatal(tag, $"await player.PrepareAsync();");

            player.Start();
            tlog.Fatal(tag, $"player.Start();");

            if (player.DisplaySettings.IsVisible == false)
            {
                player.DisplaySettings.IsVisible = true;
            }
            tlog.Fatal(tag, $"Display visible = {player.DisplaySettings.IsVisible}");

            player.DisplaySettings.Mode = Tizen.Multimedia.PlayerDisplayMode.FullScreen;
        }

        VideoView videoView;
        public void NUIVideoViewTest()
        {
            videoView = new VideoView(1);
            videoView.ResourceUrl = resourcePath;
            videoView.Looping = true;
            videoView.Size = new Size(300, 300);
            videoView.PositionUsesPivotPoint = true;
            videoView.ParentOrigin = ParentOrigin.Center;
            videoView.PivotPoint = PivotPoint.Center;
            videoView.Underlay = true;
            win.Add(videoView);

            animation = new Animation(1000);

//            try
//            {
//                var playerHandle = videoView.NativeHandle;
//                player = new myPlayer(playerHandle.DangerousGetHandle());
//            }
//            catch( Exception e)
//            {
//                if (e is global::System.ArgumentException)
//                {
//                    Tizen.Log.Fatal("NUI", $"[ERROR] could not get NativePlayerHandle!");
//                }
//            }
//            if (player != null)
//            {
//                player.Start();
//            }
        }

        private void Win_KeyEvent(object sender, Window.KeyEventArgs e)
        {
            switch (e.Key.KeyPressedName)
            {
                case "XF86Back":
                case "Escape":
                   tlog.Fatal(tag, $"key pressed name={e.Key.KeyPressedName}");
                   if (e.Key.KeyPressedName == "XF86Back")
                   {
                    Deactivate();
                   }
                   break;
                case KEY_NUM_0:
                   tlog.Fatal(tag, $"videoView Play!!");
                   videoView.Play();
                   break;

                case KEY_NUM_1:
                   tlog.Fatal(tag, $"Video is moving!!");
                   Vector3 targetSize = new Vector3(0.0f, 400.0f, 0.0f );
                   animation.Stop();
                   animation.Clear();
                   animation.AnimateTo(videoView, "Size", targetSize);
                   videoView.PlayAnimation(animation);

                   break;

                case KEY_NUM_2:
                   break;

                case KEY_NUM_3:
                   break;

                case KEY_NUM_4:
                   break;

                case KEY_NUM_5:
                   break;
            }
        }

    }
}
