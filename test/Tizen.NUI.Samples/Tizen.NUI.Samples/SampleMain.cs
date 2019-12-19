using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Samples
{
    public class CommonResource
    {
        public static string GetDaliResourcePath()
        {
            return @"/opt/usr/globalapps/Tizen.NUI.Samples/res/images/Dali/";
        }

        public static string GetFHResourcePath()
        {
            return @"/opt/usr/globalapps/Tizen.NUI.Samples/res/images/FH3/";
        }

        public static string GetTVResourcePath()
        {
            return @"/opt/usr/globalapps/Tizen.NUI.Samples/res/images/VD/";
        }
    }

    public class SampleMain : NUIApplication, IExample
    {
        public void Activate()
        {
            defaultFocusIndicator = new View();
            defaultFocusIndicator.BackgroundColor = Color.Transparent;
            FocusManager.Instance.FocusIndicator = defaultFocusIndicator;

            Window.Instance.BackgroundColor = new Color(1.0f, 0.92f, 0.80f, 1.0f);
            Window.Instance.GetDefaultLayer().Add(container);
            FocusManager.Instance.SetCurrentFocusView(label[currentIndex]);
        }

        public void Deactivate()
        {
            Window.Instance.BackgroundColor = new Color(0.96f, 0.96f, 0.86f, 1.0f);
            View currentView = FocusManager.Instance.GetCurrentFocusView();
            currentIndex = Array.FindIndex(label, x => x == currentView);

            Window.Instance.GetDefaultLayer().Remove(container);
        }

        protected override void OnCreate()
        {
            base.OnCreate();
            container = new FlexContainer();
            container.Size2D = new Size2D(Window.Instance.Size.Width, Window.Instance.Size.Height);
            container.PivotPoint = PivotPoint.TopLeft;
            container.FlexWrap = FlexContainer.WrapType.Wrap;
            container.FlexDirection = (int)FlexContainer.FlexDirectionType.Column;

            var examples = from type in Assembly.GetEntryAssembly().GetTypes()
                           where typeof(IExample).GetTypeInfo().IsAssignableFrom(type) && type.Namespace == this.GetType().Namespace
                           && type != this.GetType() && type.GetTypeInfo().IsClass
                           orderby type.Name ascending
                           select type.Name;

            label = new MyTextView[examples.Count()];
            for (int i = 0; i < label.Length; i++)
            {
                label[i] = new MyTextView();
                label[i].Text = examples.ElementAt(i);
                label[i].Size = new Size(300, 40, 0);
                label[i].FlexMargin = new Vector4(20, 20, 40, 20);
                label[i].PointSize = 10;
                label[i].KeyEvent += SampleMain_KeyEvent;
                label[i].TouchEvent += SampleMain_TouchEvent;
                label[i].PivotPoint = PivotPoint.TopLeft;
                container.Add(label[i]);
            }

            label.First().UpFocusableView = label.Last();
            label.Last().DownFocusableView = label.First();

            Window.Instance.KeyEvent += Instance_Key;

            Activate();
            sampleStack.Push(this);
        }

        private bool SampleMain_TouchEvent(object source, View.TouchEventArgs e)
        {
            TextLabel textLabel = source as TextLabel;
            string sampleName = textLabel.Text;
            RunSample("Tizen.NUI.Samples", sampleName);
            return false; ;
        }

        public void ExitSample()
        {
            if (sampleStack.Count() == 1)
            {
                Exit();
                Environment.Exit(0);
                return;
            }

            IExample currentSample = sampleStack.Pop();

            currentSample.Deactivate();
            currentSample = null;

            FullGC();

            IExample nextSample = sampleStack.Peek();
            nextSample.Activate();
        }

        private void Instance_Key(object sender, Window.KeyEventArgs e)
        {
            if (e.Key.State == Key.StateType.Down && (e.Key.KeyPressedName == "BackSpace" || e.Key.KeyPressedName == "XF86Back" || e.Key.KeyPressedName == "Escape"))
            {
                ExitSample();
            }
        }
        public void RunSample(string @namespace, string sampleName)
        {
            object item = Activator.CreateInstance(global::System.Type.GetType(@namespace + "." + sampleName));
            if (item is IExample)
            {
                IExample currentSample = sampleStack.Peek();
                currentSample.Deactivate();

                FullGC();

                currentSample = item as IExample;
                sampleStack.Push(currentSample);

                currentSample.Activate();
            }
        }
        private void FullGC()
        {
            global::System.GC.Collect();
            global::System.GC.WaitForPendingFinalizers();
            global::System.GC.Collect();
        }
        private bool SampleMain_KeyEvent(object source, View.KeyEventArgs e)
        {
            TextLabel textLabel = source as TextLabel;

            if (e.Key.State == Key.StateType.Down)
            {
                if (e.Key.KeyPressedName == "Return")
                {
                    string sampleName = textLabel.Text;

                    RunSample("Tizen.NUI.Samples", sampleName);

                    return true;
                }
            }

            return false;
        }

        MyTextView[] label;
        FlexContainer container;
        View defaultFocusIndicator;
        int currentIndex = 0;
        Stack<IExample> sampleStack = new Stack<IExample>();
    }

    public class MyTextView : TextLabel
    {
        Animation focusInAni;
        Animation focusOutAni;

        public MyTextView()
        {
            this.Focusable = true;
            this.FocusGained += MyTextView_FocusGained;
            this.FocusLost += MyTextView_FocusLost;

            focusInAni = new Animation(400);
            focusOutAni = new Animation(400);

            focusInAni.AnimateTo(this, "Scale", new Vector3(1.2f, 1.2f, 1.0f));
            focusOutAni.AnimateTo(this, "Scale", new Vector3(1.0f, 1.0f, 1.0f));
        }

        private void MyTextView_FocusLost(object sender, EventArgs e)
        {
            focusOutAni.Play();
            this.BackgroundColor = Color.Transparent;
            this.TextColor = Color.Black;
        }

        private void MyTextView_FocusGained(object sender, EventArgs e)
        {
            focusInAni.Play();
            this.BackgroundColor = new Color(0.69f, 0.77f, 0.87f, 1.0f);
            this.TextColor = Color.Red;
        }
    }
}

