using System;
using Tizen.NUI;

namespace Tizen.TV.NUI.Examples
{
    public class AnimationSample
    {
        private Application application;
        private View view;
        private Animation toAnimation1;
        private Animation toAnimation2;
        private Animation byAnimation;
        private Animation pathAnimation;
        private Animation betweenAnimation;

        private AnimationSample(Application application)
        {
            this.application = application;
            this.application.Initialized += OnInitialize;
        }

        static void Main(string[] args)  //changed
        {
            AnimationSample animationSample = new AnimationSample(Application.NewApplication());
            animationSample.MainLoop();
        }

        private void MainLoop()
        {
            application.MainLoop();
        }

        private void OnInitialize(object source, EventArgs e)
        {
            view = new View();
            view.Size = new Size(200, 200, 0);
            view.Position = new Position(0, 0, 0);
            view.AnchorPoint = AnchorPoint.TopLeft;
            view.BackgroundColor = Color.Red;

            Stage.Instance.GetDefaultLayer().Add(view);

            toAnimation1 = new Animation(1000);
            toAnimation1.Looping = true;
            toAnimation1.DefaultAlphaFunction = new AlphaFunction(new Vector2(0.21f, 2), new Vector2(0.14f, 1));

            toAnimation2 = new Animation(1000);
            toAnimation2.Looping = true;

            byAnimation = new Animation(1000);
            byAnimation.AnimateBy(view, "PositionX", 100.0f);
            byAnimation.AnimateBy(view, "PositionY", 100.0f);

            Path path = new Path();
            path.AddPoint(new Position(100, 100, 0));
            path.AddPoint(new Position(600, 600, 0));  //added
            path.AddPoint(new Position(1100, 100, 0)); //changed
            path.GenerateControlPoints(0.5f); //added
            pathAnimation = new Animation(1000);
            pathAnimation.AnimatePath(view, path, new Vector3(0, 0, 0));

            KeyFrames keyFrames = new KeyFrames();
            keyFrames.Add(0.0f, new Vector3(10.0f, 10.0f, 10.0f));
            keyFrames.Add(0.7f, new Vector3(200.0f, 200.0f, 200.0f));
            keyFrames.Add(1.0f, new Vector3(100.0f, 100.0f, 100.0f));
            betweenAnimation = new Animation(1000);
            betweenAnimation.AnimateBetween(view, "Position", keyFrames); //activated

            view.KeyEvent += OnKeyPressed;
            view.Focusable = true;
            view.SetKeyInputFocus();
        }

        private void AllStop()
        {
            toAnimation1.Stop();
            toAnimation2.Stop();
            byAnimation.Stop();
            pathAnimation.Stop();
            betweenAnimation.Stop();
        }

        private bool OnKeyPressed(object source, View.KeyEventArgs e)
        {
            if (e.Key.State == Key.StateType.Down)
            {
                if (e.Key.KeyPressedName == "Right")
                {
                    AllStop();

                    toAnimation1.Clear();

                    toAnimation1.AnimateTo(view, "PositionX", view.PositionX + 100.0f);
                    toAnimation1.AnimateTo(view, "PositionY", view.PositionY + 100.0f);
                    toAnimation1.AnimateTo(view, "ColorAlpha", 0.5f);
                    toAnimation1.AnimateTo(view, "PositionX", view.PositionX + 200.0f, 1000, 2000);
                    toAnimation1.AnimateTo(view, "ColorAlpha", 1.0f, 1500, 2000);

                    toAnimation2.AnimateTo(view, "Scale", new Size(1.2f, 1.2f, 1.0f));
                    toAnimation2.AnimateTo(view, "Scale", new Size(0.7f, 0.7f, 1.0f), 1200, 2200);

                    toAnimation1.Play();
                    toAnimation2.Play();
                }
                else if (e.Key.KeyPressedName == "Left")
                {
                    AllStop();
                    byAnimation.Play();
                }
                else if (e.Key.KeyPressedName == "Up")
                {
                    AllStop();
                    pathAnimation.Play();
                }
                else if (e.Key.KeyPressedName == "Down")
                {
                    AllStop();
                    betweenAnimation.Play();
                }
            }

            return true;
        }
    }
}
