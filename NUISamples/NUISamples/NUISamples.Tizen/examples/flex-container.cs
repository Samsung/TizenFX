
using System;
using Tizen.NUI;
using Tizen.NUI.UIComponents;
using Tizen.NUI.BaseComponents;

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

            Window.Instance.BackgroundColor = new Color(0.1f, 0.8f, 0.1f, 1.0f);

            container = new FlexContainer();
            container.Size2D = new Size2D(Window.Instance.Size.Width, Window.Instance.Size.Height);
            container.PivotPoint = PivotPoint.TopLeft;
            container.Padding = new Vector4(100, 100, 100, 100);

            container.FlexWrap = FlexContainer.WrapType.Wrap;
            container.FlexDirection = FlexContainer.FlexDirectionType.Column;

            Window.Instance.Add(container);

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
            //added
            FocusManager.Instance.FocusChanged += (sender, e) =>
            {
                if(e.CurrentView) Tizen.Log.Debug("NUI", "FocusManager FocusChanged signal callback! e.CurrentView.Name=" + e.CurrentView.Name);
                else Tizen.Log.Debug("NUI", "FocusManager FocusChanged signal callback! e.CurrentView is null!");
                if (e.NextView) Tizen.Log.Debug("NUI", "FocusManager FocusChanged signal callback! e.NextView.Name=" + e.NextView.Name);
                else Tizen.Log.Debug("NUI", "FocusManager FocusChanged signal callback! e.NextView is null!");
            };
            //added
            FocusManager.Instance.FocusedViewActivated += (sender, e) =>
            {
                if (e.View) Tizen.Log.Debug("NUI", "FocusManager FocusedViewEnterKeyPressed signal callback! e.View.Name=" + e.View.Name);
                else Tizen.Log.Debug("NUI", "FocusManager FocusChanged signal callback! e.View is null!");
            };

            //added
            Window.Instance.TouchEvent += (sender, e) =>
            {
                Tizen.Log.Debug("NUI", "Window Touch signal callback! To avoid crash, when losing key focus, set here again unless the NextView is null");
                FocusManager.Instance.SetCurrentFocusView(label[3]);
            };

            //added
            pushButton1 = new PushButton();
            pushButton1.MinimumSize = new Size2D(400, 200);
            pushButton1.LabelText = "+PreFocusChange";
            pushButton1.ParentOrigin = ParentOrigin.TopLeft;
            pushButton1.PivotPoint = PivotPoint.TopLeft;
            pushButton1.Position2D = new Position2D(200, 800);
            pushButton1.Clicked += (sender, e) =>
            {
                Tizen.Log.Debug("NUI", "pushbutton1 clicked! add handler!");
                _cnt++;
                FocusManager.Instance.PreFocusChange += Instance_PreFocusChange;
                _ani.Finished += _ani_Finished;
                pushButton1.LabelText = "Add Handler" + _cnt;
                pushButton2.LabelText = "Remove Handler" + _cnt;
                return true;
            };
            Window.Instance.Add(pushButton1);

            pushButton2 = new PushButton();
            pushButton2.MinimumSize = new Size2D(400, 200);
            pushButton2.LabelText = "-PreFocusChange";
            pushButton2.ParentOrigin = ParentOrigin.TopLeft;
            pushButton2.PivotPoint = PivotPoint.TopLeft;
            pushButton2.Position2D = new Position2D(800, 800);
            pushButton2.Clicked += (sender, e) =>
            {
                Tizen.Log.Debug("NUI", "pushbutton2 clicked! remove handler!");
                _cnt--;
                FocusManager.Instance.PreFocusChange -= Instance_PreFocusChange;
                _ani.Finished -= _ani_Finished;
                pushButton1.LabelText = "Add Handler" + _cnt;
                pushButton2.LabelText = "Remove Handler" + _cnt;
                return true;
            };
            Window.Instance.Add(pushButton2);

            //added
            _ani = new Animation(2000);
            _ani.AnimateTo(pushButton1, "Opacity", 0.0f);
            _ani.AnimateTo(pushButton2, "Opacity", 0.0f);
            _ani.EndAction = Animation.EndActions.Discard;
            _ani.Finished += _ani_Finished;

        }

        private void _ani_Finished(object sender, EventArgs e)
        {
            Tizen.Log.Debug("NUI", "_ani finished! _cnt=" + _cnt);
        }

        private View Instance_PreFocusChange(object source, FocusManager.PreFocusChangeEventArgs e)
        {
            View nextView;
            Tizen.Log.Debug("NUI", "Instance_PreFocusChange = " + e.Direction.ToString());

            //added
            if (e.CurrentView == null) e.CurrentView = label[0];
            if (e.ProposedView == null) e.ProposedView = label[0];

            int index = Array.FindIndex(label, x => x == e.CurrentView);

            Tizen.Log.Debug("NUI", "index = " + index);

            switch (e.Direction)
            {
                case View.FocusDirection.Up:
                    index = (index + numOfSamples - 2) % numOfSamples;  //changed
                    _ani.Play();
                    break;
                case View.FocusDirection.Down:
                    index = (index + 2) % numOfSamples; //changed
                    Tizen.Log.Debug("NUI", "pushbutton1 Visible=" + pushButton1.Visible + "  pushbutton2 Visible=" + pushButton2.Visible); //added
                    break;
                case View.FocusDirection.Left:
                    //added
                    pushButton1.Show();
                    pushButton2.Show();
                    break;
                case View.FocusDirection.Right:
                    //added
                    pushButton1.Hide();
                    pushButton2.Hide();
                    break;
                default:
                    break;
            }

            Tizen.Log.Debug("NUI", "next index = " + index);
            nextView = label[index];

            if (e.CurrentView.HasFocus())
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

