
using System;
using Tizen.NUI;

namespace FlexContainerTest
{
    public class SampleMain : NUIApplication
    {
        public readonly static string[] samples = new string[]
        {
            "AnimationSample",
            "BasicElement",
            "TextSample",
            "ImageViewSample",
            "EventSample",
            "FlexContainer",
            "FrameAnimationSample"
        };

        TextLabel[] label;
        FlexContainer container;
        View focusIndicator;
        int numOfSamples;
        PushButton pushButton1, pushButton2;
        private int _cnt;
        private Animation _ani;

        protected override void OnCreate()
        {
            base.OnCreate();

            Stage.Instance.BackgroundColor = new Color(0.1f, 0.8f, 0.1f, 1.0f);

            container = new FlexContainer();
            container.Size = new Size(Stage.Instance.Size.Width, Stage.Instance.Size.Height, 0);
            container.AnchorPoint = AnchorPoint.TopLeft;
            container.Padding = new Vector4(100, 100, 100, 100);

            container.FlexWrap = FlexContainer.WrapType.Wrap;
            container.FlexDirection = FlexContainer.FlexDirectionType.Column;

            Stage.Instance.GetDefaultLayer().Add(container);

            numOfSamples = samples.GetLength(0);
            Tizen.Log.Debug("NUI", "NUM = " + numOfSamples);
            label = new TextLabel[numOfSamples];
            for (int i = 0; i < numOfSamples; i++)
            {
                label[i] = new TextLabel();
                label[i].Focusable = true;
                label[i].BackgroundColor = Color.Red;
                //label[i].Size = new Size(100, 50, 0);
                label[i].Text = samples[i];
                label[i].FlexMargin = new Vector4(20, 20, 20, 20);
                label[i].PointSize = 10;
                label[i].Name = "label" + i.ToString();
                container.Add(label[i]);
            }

            //label[3].SetKeyInputFocus();  //removed
            FocusManager.Instance.SetCurrentFocusView(label[3]);

            FocusManager.Instance.PreFocusChange += Instance_PreFocusChange;
            FocusManager.Instance.FocusChanged += (sender, e) =>
            {
                Tizen.Log.Debug("NUI", "FocusChanged signal callback e.CurrentView.Name=" + e.CurrentView?.Name);
                Tizen.Log.Debug("NUI", "FocusChanged signal callback e.NextView.Name=" + e.NextView?.Name);
            };
            FocusManager.Instance.FocusedViewEnterKeyPressed += (sender, e) =>
            {
                Tizen.Log.Debug("NUI", "FocusedViewEnterKeyPressed signal callback e.View.Name=" + e.View?.Name);
            };

            pushButton1 = new PushButton();
            pushButton1.MinimumSize = new Size2D(400, 200);
            pushButton1.LabelText = "+PreFocusChange";
            pushButton1.ParentOrigin = ParentOrigin.TopLeft;
            pushButton1.AnchorPoint = AnchorPoint.TopLeft;
            pushButton1.Position2D = new Position2D(200, 800);
            pushButton1.Clicked += (sender, e) =>
            {
                Tizen.Log.Debug("NUI", "pushbutton1 clicked! add handler!");
                FocusManager.Instance.PreFocusChange += Instance_PreFocusChange;
                return true;
            };
            Stage.Instance.GetDefaultLayer().Add(pushButton1);

            pushButton2 = new PushButton();
            pushButton2.MinimumSize = new Size2D(400, 200);
            pushButton2.LabelText = "-PreFocusChange";
            pushButton2.ParentOrigin = ParentOrigin.TopLeft;
            pushButton2.AnchorPoint = AnchorPoint.TopLeft;
            pushButton2.Position2D = new Position2D(800, 800);
            pushButton2.Clicked += (sender, e) =>
            {
                Tizen.Log.Debug("NUI", "pushbutton2 clicked! add handler!");
                FocusManager.Instance.PreFocusChange -= Instance_PreFocusChange;
                return true;
            };
            Stage.Instance.GetDefaultLayer().Add(pushButton2);

            _ani = new Animation(2000);
            _ani.AnimateTo(pushButton1, "Opacity", 0.0f);
            _ani.AnimateTo(pushButton2, "Opacity", 0.0f);
            _ani.EndAction = Animation.EndActions.Discard;

        }



        private View Instance_PreFocusChange(object source, FocusManager.PreFocusChangeEventArgs e)
        {
            View nextView;
            Tizen.Log.Debug("NUI", "Instance_PreFocusChange = " + e.Direction.ToString());

            if (e.CurrentView == null) e.CurrentView = label[0];
            if (e.ProposedView == null) e.ProposedView = label[0];

            Tizen.Log.Debug("NUI", "currentView name=" + e.CurrentView.Name + "  nextView name=" + e.CurrentView.Name);

            int index = Array.FindIndex(label, x => x == e.CurrentView);


            Tizen.Log.Debug("NUI", "index = " + index);

            switch (e.Direction)
            {
                case View.FocusDirection.Up:
                    index = (index + numOfSamples - 1) % numOfSamples;
                    _ani.Play();
                    break;
                case View.FocusDirection.Down:
                    index = (index + 1) % numOfSamples;
                    Tizen.Log.Debug("NUI", "pushbutton1 Visible=" + pushButton1.Visible + "  pushbutton2 Visible=" + pushButton2.Visible);
                    break;
                case View.FocusDirection.Left:
                    pushButton1.Show();
                    pushButton2.Show();
                    break;
                case View.FocusDirection.Right:
                    pushButton1.Hide();
                    pushButton2.Hide();
                    break;
                default:
                    break;
            }

            Tizen.Log.Debug("NUI", "next index = " + index);
            nextView = label[index];

            if (e.CurrentView.HasKeyInputFocus())
            {
                //currentView?.ClearKeyInputFocus();  //removed
            }
            //nextView?.SetKeyInputFocus();  //removed


            return nextView;

        }

        static void _Main(string[] args)
        {

            SampleMain sample = new SampleMain();
            sample.Run(args);
        }
    }
}

