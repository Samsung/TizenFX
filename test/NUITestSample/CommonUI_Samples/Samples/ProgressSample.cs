using Tizen.NUI.BaseComponents;
using Tizen.NUI.CommonUI;
using Tizen.FH.NUI.Controls;
using Tizen.NUI;

namespace NuiCommonUiSamples
{
    public class Progress : IExample
    {
        private Tizen.NUI.CommonUI.Button button1, button2;
        private Tizen.NUI.CommonUI.Progress progressBar1;
        private SampleLayout root;

        public void Activate()
        {
            Window.Instance.BackgroundColor = Color.White;
            Window window = Window.Instance;
            root = new SampleLayout();
            root.HeaderText = "Progress";

            button1 = new Tizen.NUI.CommonUI.Button("BasicButton");
            button1.BackgroundColor = Color.Green;
            button1.Position2D = new Position2D(300, 200);
            button1.Size2D = new Size2D(80, 80);
            button1.Text = "+";
            root.Add(button1);
            button1.Focusable = true;
            button1.ClickEvent += bar1Add;

            button2 = new Tizen.NUI.CommonUI.Button("BasicButton");
            button2.BackgroundColor = Color.Green;
            button2.Position2D = new Position2D(700, 200);
            button2.Size2D = new Size2D(80, 80);
            button2.Text = "-";
            root.Add(button2);
            button2.Focusable = true;
            button2.ClickEvent += bar1Minus;

            progressBar1 = new Tizen.NUI.CommonUI.Progress("Progressbar");
            progressBar1.Position2D = new Position2D(300, 100);
            progressBar1.Size2D = new Size2D(500, 4);
            progressBar1.MaxValue = 100;
            progressBar1.MinValue = 0;
            progressBar1.CurrentValue = 45;
            root.Add(progressBar1);

            window.Add(root);
            FocusManager.Instance.SetCurrentFocusView(button1);

        }

        private void bar1Add(object sender, global::System.EventArgs e)
        {
            progressBar1.CurrentValue++;
        }
        private void bar1Minus(object sender, global::System.EventArgs e)
        {
            progressBar1.CurrentValue--;
        }

        public void Deactivate()
        {
            if (root != null)
            {
                Window.Instance.Remove(root);
                root.Dispose();
            }
        }
    }
}
