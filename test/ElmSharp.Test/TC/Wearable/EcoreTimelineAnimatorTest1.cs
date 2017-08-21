using System;
using System.Collections.Generic;
using System.Text;
using ElmSharp;

namespace ElmSharp.Test.Wearable
{
    class EcoreTimelineAnimatorTest1 : WearableTestCase

    {
        public override string TestName => "Timeline Animator Test1";

        public override string TestDescription => "Ecore Timeline Animator Test1";

        EcoreTimelineAnimator timelineAnimator;

        int X1, Y1, X2, Y2;

        Tuple<string, AnimatorMotionMapper>[] mappers =
        {
            new Tuple<string, AnimatorMotionMapper>("Linear", new LinearMotionMapper()),
            new Tuple<string, AnimatorMotionMapper>("Accelerate", new AccelerateMotionMapper()),
            new Tuple<string, AnimatorMotionMapper>("Decelerate", new DecelerateMotionMapper()),
            new Tuple<string, AnimatorMotionMapper>("Sinusoida", new SinusoidalMotionMapper()),
            new Tuple<string, AnimatorMotionMapper>("Bounce", new BounceMotionMapper{ Bounces = 3, DecayFactor = 1.8 }),
            new Tuple<string, AnimatorMotionMapper>("Spring", new SpringMotionMapper{ Wobbles = 3, DecayFactor = 1.8 }),
            new Tuple<string, AnimatorMotionMapper>("AccelerateFactor", new AccelerateFactorMotionMapper{ PowerFactor = 1.5 }),
            new Tuple<string, AnimatorMotionMapper>("DecelerateFactor", new DecelerateFactorMotionMapper{ PowerFactor = 1.5 }),
            new Tuple<string, AnimatorMotionMapper>("SinusoidaFactor", new SinusoidalFactorMotionMapper{ PowerFactor = 1.5 }),
            new Tuple<string, AnimatorMotionMapper>("DivisorInterpolate", new DivisorInterpolatedMotionMapper{ Divisor = 1.0, Power = 2.0 }),
            new Tuple<string, AnimatorMotionMapper>("CubicBezier", new CubicBezierMotionMapper{ X1 = 0, X2 = 1, Y1 = 0, Y2 = 1})
        };

        int map_index = 0;

        Rectangle square;

        public override void Run(Window window)
        {
            Rect rect = window.GetInnerSquare();

            X1 = rect.X;
            Y1 = rect.Y;
            X2 = rect.X + rect.Width - rect.Width / 10;
            Y2 = rect.Y;

            square = new Rectangle(window)
            {
                Geometry = new Rect(X1, Y1, rect.Width / 10, rect.Height / 6),
                Color = Color.Red
            };
            square.Show();

            Button btn = new Button(window)
            {
                Geometry = new Rect(rect.X, rect.Y + rect.Height - rect.Height / 4, rect.Width, rect.Height / 4),
                Text = mappers[map_index].Item1
            };
            btn.Show();

            timelineAnimator = new EcoreTimelineAnimator(1.0, OnTimeline);

            btn.Clicked += Btn_Clicked;
            timelineAnimator.Finished += (s, e) =>
            {
                map_index = (map_index + 1) % mappers.Length;
                btn.IsEnabled = true;
            };
        }

        private void Btn_Clicked(object sender, EventArgs e)
        {
            timelineAnimator.Start();
            ((Button)sender).IsEnabled = false;
            Log.Debug(mappers[map_index].Item1);
        }

        void OnTimeline()
        {
            double o = mappers[map_index].Item2.Caculate(timelineAnimator.Position);
            int x = (int)((X2 * o) + (X1 * (1.0 - o)));
            int y = (int)((Y2 * o) + (Y1 * (1.0 - o)));

            square.Move(x, y);
        }
    }
}
