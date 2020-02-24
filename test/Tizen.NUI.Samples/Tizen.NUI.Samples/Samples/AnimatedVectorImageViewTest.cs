using System;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Samples
{
    public class AnimatedVectorImageViewTest : IExample
    {
        Window win;
        AnimatedVectorImageView avi, avi2, avi3, avi4, avi5, avi6;
        public void Activate()
        {
            Tizen.Log.Fatal("NUITEST", $"###Activate()");
            win = Window.Instance;
            win.BackgroundColor = Color.Green;
            win.KeyEvent += Win_KeyEvent;

            avi = new AnimatedVectorImageView();
            avi.ResourceURL = Tizen.Applications.Application.Current.DirectoryInfo.Resource + "images/marker.json";
            avi.RepeatCount = -1;
            avi.BackgroundColor = Color.White;
            avi.Position2D = new Position2D(50, 10);
            avi.Size2D = new Size2D(500, 500);
            Window.Instance.GetDefaultLayer().Add(avi);
            avi.Play();

            avi2 = new AnimatedVectorImageView();
            avi2.ResourceURL = Tizen.Applications.Application.Current.DirectoryInfo.Resource + "images/marker.json";
            avi2.RepeatCount = -1;
            avi2.BackgroundColor = Color.White;
            avi2.Position2D = new Position2D(600, 10);
            avi2.Size2D = new Size2D(500, 500);
            avi2.SetMinMaxFrameByMarker("first");
            Window.Instance.GetDefaultLayer().Add(avi2);
            avi2.Play();

            avi3 = new AnimatedVectorImageView();
            avi3.ResourceURL = Tizen.Applications.Application.Current.DirectoryInfo.Resource + "images/marker.json";
            avi3.RepeatCount = -1;
            avi3.BackgroundColor = Color.White;
            avi3.Position2D = new Position2D(1150, 10);
            avi3.Size2D = new Size2D(500, 500);
            avi3.SetMinMaxFrameByMarker("second", "third");
            Window.Instance.GetDefaultLayer().Add(avi3);
            avi3.Play();

            avi4 = new AnimatedVectorImageView();
            avi4.ResourceURL = Tizen.Applications.Application.Current.DirectoryInfo.Resource + "images/marker.json";
            avi4.RepeatCount = -1;
            avi4.BackgroundColor = Color.White;
            avi4.Position2D = new Position2D(50, 550);
            avi4.Size2D = new Size2D(500, 500);
            avi4.SetMinMaxFrameByMarker("second");
            Window.Instance.GetDefaultLayer().Add(avi4);
            avi4.Play();

            avi5 = new AnimatedVectorImageView();
            avi5.ResourceURL = Tizen.Applications.Application.Current.DirectoryInfo.Resource + "images/marker.json";
            avi5.RepeatCount = -1;
            avi5.BackgroundColor = Color.White;
            avi5.Position2D = new Position2D(600, 550);
            avi5.Size2D = new Size2D(500, 500);
            avi5.SetMinMaxFrameByMarker("third");
            Window.Instance.GetDefaultLayer().Add(avi5);
            avi5.Play();

            avi6 = new AnimatedVectorImageView();
            avi6.ResourceURL = Tizen.Applications.Application.Current.DirectoryInfo.Resource + "images/marker.json";
            avi6.RepeatCount = -1;
            avi6.BackgroundColor = Color.White;
            avi6.Position2D = new Position2D(1150, 550);
            avi6.Size2D = new Size2D(500, 500);
            avi6.SetMinMaxFrameByMarker("third", "first");
            Window.Instance.GetDefaultLayer().Add(avi6);
            avi6.Play();

        }
        public void Deactivate()
        {
            win.KeyEvent -= Win_KeyEvent;

            Window.Instance.GetDefaultLayer().Remove(avi);
            Window.Instance.GetDefaultLayer().Remove(avi2);
            Window.Instance.GetDefaultLayer().Remove(avi3);
            Window.Instance.GetDefaultLayer().Remove(avi4);
            Window.Instance.GetDefaultLayer().Remove(avi5);
            Window.Instance.GetDefaultLayer().Remove(avi6);
        }

        private void Win_KeyEvent(object sender, Window.KeyEventArgs e)
        {
            if (e.Key.State == Key.StateType.Down)
            {
                if (e.Key.KeyPressedName == "1")
                {
                    var l = avi.GetContentInfo();
                    foreach (var iter in l)
                    {
                        Tizen.Log.Fatal("NUITEST", $"content [{iter.Item1}, {iter.Item2}, {iter.Item3}]");
                    }
                }
                else if (e.Key.KeyPressedName == "2")
                {
                    avi2.SetMinAndMaxFrame(0, 1000);
                }
                else if (e.Key.KeyPressedName == "3")
                {
                    avi3.SetMinMaxFrameByMarker("first", "second");
                }
                else if (e.Key.KeyPressedName == "4")
                {
                    avi6.SetMinMaxFrameByMarker("second", "third");
                }
                else if (e.Key.KeyPressedName == "5")
                {
                    avi6.SetMinMaxFrameByMarker("first", "second");
                }
                else if (e.Key.KeyPressedName == "6")
                {
                    avi6.SetMinMaxFrame(0, 1000);
                }
                else if (e.Key.KeyPressedName == "7")
                {
                    avi.Stop(AnimatedVectorImageView.EndActions.Discard);
                    avi2.Stop(AnimatedVectorImageView.EndActions.Discard);
                    avi3.Stop(AnimatedVectorImageView.EndActions.Discard);
                    avi4.Stop(AnimatedVectorImageView.EndActions.Discard);
                    avi5.Stop(AnimatedVectorImageView.EndActions.Discard);
                    avi6.Stop(AnimatedVectorImageView.EndActions.Discard);
                }
                else if (e.Key.KeyPressedName == "8")
                {
                    avi.Stop(AnimatedVectorImageView.EndActions.StopFinal);
                    avi2.Stop(AnimatedVectorImageView.EndActions.StopFinal);
                    avi3.Stop(AnimatedVectorImageView.EndActions.StopFinal);
                    avi4.Stop(AnimatedVectorImageView.EndActions.StopFinal);
                    avi5.Stop(AnimatedVectorImageView.EndActions.StopFinal);
                    avi6.Stop(AnimatedVectorImageView.EndActions.StopFinal);
                }
                else if (e.Key.KeyPressedName == "9")
                {
                    avi.Play();
                    avi2.Play();
                    avi3.Play();
                    avi4.Play();
                    avi5.Play();
                    avi6.Play();
                }
                else if (e.Key.KeyPressedName == "0")
                {
                    Tizen.Log.Fatal("NUITEST", $"get MinMaxFrame() !");
                    var temp = avi.GetMinMaxFrame();
                    Tizen.Log.Fatal("NUITEST", $"avi min={temp.Item1}, max={temp.Item2}");
                    temp = avi2.GetMinMaxFrame();
                    Tizen.Log.Fatal("NUITEST", $"avi2 min={temp.Item1}, max={temp.Item2}");
                    temp = avi3.GetMinMaxFrame();
                    Tizen.Log.Fatal("NUITEST", $"avi3 min={temp.Item1}, max={temp.Item2}");
                    temp = avi4.GetMinMaxFrame();
                    Tizen.Log.Fatal("NUITEST", $"avi4 min={temp.Item1}, max={temp.Item2}");
                    temp = avi5.GetMinMaxFrame();
                    Tizen.Log.Fatal("NUITEST", $"avi5 min={temp.Item1}, max={temp.Item2}");
                    temp = avi6.GetMinMaxFrame();
                    Tizen.Log.Fatal("NUITEST", $"avi6 min={temp.Item1}, max={temp.Item2}");
                }
            }
        }
    }
}
