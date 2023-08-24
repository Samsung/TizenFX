using Tizen.NUI.BaseComponents;
using Tizen.NUI.CommonUI;
using System;
using Tizen.NUI;

namespace NuiCommonUiSamples
{
    public class InputField : IExample
    {
        private const int COUNT = 2;
        private Tizen.FH.NUI.Controls.InputField[] inputFieldArr;
        private TextLabel guideText;
        private SampleLayout rootView;
        private int posY;
        private Tizen.NUI.CommonUI.Button button;

        public void Activate()
        {
            Window.Instance.BackgroundColor = Color.White;
            posY = 100;
            inputFieldArr = new Tizen.FH.NUI.Controls.InputField[COUNT];
            CreateRootView();
            CreateFamily();
            CreateGuideText();
            button = new Tizen.NUI.CommonUI.Button();
            button.PointSize = 14;
            button.Size2D = new Size2D(300, 80);
            button.BackgroundColor = Color.Green;
            button.Position2D = new Position2D(200, 0);
            button.Text = "LTR/RTL";
            button.ClickEvent += OnLayoutChanged;
            rootView.Add(button);
            Window.Instance.KeyEvent += OnWindowsKeyEvent;
        }
        private void OnLayoutChanged(object sender, global::System.EventArgs e)
        {
            for (int i = 0; i < COUNT; i++)
            {
                if (inputFieldArr[i].LayoutDirection == ViewLayoutDirectionType.LTR)
                {
                    inputFieldArr[i].LayoutDirection = ViewLayoutDirectionType.RTL;
                }
                else
                {
                    inputFieldArr[i].LayoutDirection = ViewLayoutDirectionType.LTR;
                }
            }
        }
        private void CreateRootView()
        {
            rootView = new SampleLayout();
            rootView.HeaderText = "InputField";
            rootView.Focusable = true;
            rootView.TouchEvent += OnRootViewTouchEvent;
        }

        private void CreateFamily()
        {
            inputFieldArr[0] = new Tizen.FH.NUI.Controls.InputField("DefaultInputField");
            inputFieldArr[0].Name = "DefaultInputField";
            inputFieldArr[0].Size2D = new Size2D(1080, 95);
            inputFieldArr[0].Position2D = new Position2D(0, posY);
            rootView.Add(inputFieldArr[0]);
            inputFieldArr[0].HintText = "DefaultInputField";
            inputFieldArr[0].CancelButtonClickEvent += OnCancelBtnClickEvent;
            inputFieldArr[0].KeyEvent += OnKeyEvent;

            inputFieldArr[0].FocusGained += (object sender, EventArgs e) =>
            {
                Tizen.Log.Fatal("NUI", "Field0 get focus");
            };

            inputFieldArr[0].FocusLost += (object sender, EventArgs e) =>
            {
                Tizen.Log.Fatal("NUI", "Field0 lost focus");
            };

            posY += 100;
            inputFieldArr[1] = new Tizen.FH.NUI.Controls.InputField("StyleBInputField");
            inputFieldArr[1].Name = "StyleBInputField";
            inputFieldArr[1].Size2D = new Size2D(1080, 95);
            inputFieldArr[1].Position2D = new Position2D(0, posY);
            rootView.Add(inputFieldArr[1]);
            inputFieldArr[1].HintText = "StyleBInputField";
            inputFieldArr[1].DeleteButtonClickEvent += OnDeleteBtnClickEvent;
            inputFieldArr[1].AddButtonClickEvent += OnAddBtnClickEvent;
            inputFieldArr[1].KeyEvent += OnKeyEvent;
        }

        private void CreateGuideText()
        {
            guideText = new TextLabel();
            guideText.Size2D = new Size2D(1080, 200);
            guideText.Position2D = new Position2D(0, 600);
            guideText.TextColor = Color.Blue;
            guideText.BackgroundColor = Color.White;
            guideText.PointSize = 15;
            guideText.MultiLine = true;
            rootView.Add(guideText);
            guideText.Text =
                "Tips: \n" +
                "User can input text after press on the InputBox; \n" +
                "User can press Cancel, Add and Delete button, do what they want in these button click callbacks; \n" +
                "User can do what they want in the key event; \n " +
                "In this sample, text color will change when inputted text's length change between 5~10, 10~15.  \n" +
                "User can exit the sample by press \"Esc\" key after touch on any area except the InputField.";
        }

        private void OnWindowsKeyEvent(object sender, Window.KeyEventArgs e)
        {
            if (e.Key.State == Key.StateType.Down)
            {
                if (e.Key.KeyPressedName == "Left")
                {
                    //inputField1.Text = "test";
                    for (int i = 0; i < COUNT; ++i)
                    {
                        inputFieldArr[i].StateEnabled = false;
                    }
                }
                else if (e.Key.KeyPressedName == "Right")
                {
                    //inputField1.Text = "";
                    for (int i = 0; i < COUNT; ++i)
                    {
                        inputFieldArr[i].StateEnabled = true;
                    }
                }
                else if (e.Key.KeyPressedName == "Up")
                {
                    for (int i = 0; i < COUNT; ++i)
                    {
                        inputFieldArr[i].Text = "abcdef";
                    }
                }
                else if (e.Key.KeyPressedName == "Down")
                {
                    for (int i = 0; i < COUNT; ++i)
                    {
                        inputFieldArr[i].Text = "";
                    }
                }
            }
        }

        private bool OnRootViewTouchEvent(object sender, View.TouchEventArgs e)
        {
            FocusManager.Instance.SetCurrentFocusView(rootView);
            return false;
        }

        private void OnKeyEvent(object sender, View.KeyEventArgs e)
        {
            if (e.Key.State == Key.StateType.Down)
            {
                Tizen.Log.Fatal("NUI", "OnKeyEvent Key is " + e.Key.KeyPressedName);

                Tizen.FH.NUI.Controls.InputField inputField = sender as Tizen.FH.NUI.Controls.InputField;
                if (inputField != null)
                {
                    if (inputField.Text.Length > 5 && inputField.Text.Length <= 10)
                    {
                        inputField.TextColor = Color.Yellow;
                    }
                    else if (inputField.Text.Length > 10 && inputField.Text.Length <= 15)
                    {
                        inputField.TextColor = Color.Red;
                    }
                    else
                    {
                        inputField.TextColor = Color.Black;
                    }
                }
            }
        }

        public void Deactivate()
        {
            Window window = Window.Instance;
            window.KeyEvent -= OnWindowsKeyEvent;

            for (int i = 0; i < COUNT; ++i)
            {
                if (inputFieldArr[i] != null)
                {
                    if (i % 2 == 0)
                    {
                        inputFieldArr[i].CancelButtonClickEvent -= OnCancelBtnClickEvent;
                    }
                    else
                    {
                        inputFieldArr[i].DeleteButtonClickEvent -= OnDeleteBtnClickEvent;
                        inputFieldArr[i].AddButtonClickEvent -= OnAddBtnClickEvent;
                    }
                    inputFieldArr[i].KeyEvent -= OnKeyEvent;
                    rootView.Remove(inputFieldArr[i]);
                    inputFieldArr[i].Dispose();
                    inputFieldArr[i] = null;
                }
            }
            inputFieldArr = null;

            if (guideText != null)
            {
                rootView.Remove(guideText);
                guideText.Dispose();
                guideText = null;
            }

            if (button != null)
            {
                rootView.Remove(button);
                button.Dispose();
                button = null;
            }

            if (rootView != null)
            {
                rootView.TouchEvent -= OnRootViewTouchEvent;
                rootView.Dispose();
                rootView = null;
            }
        }

        private void OnCancelBtnClickEvent(object sender, Tizen.FH.NUI.Controls.InputField.ButtonClickArgs args)
        {
            if (sender is Tizen.FH.NUI.Controls.InputField)
            {
                Tizen.FH.NUI.Controls.InputField inputfield = sender as Tizen.FH.NUI.Controls.InputField;
                Console.WriteLine("-------, name: " + inputfield.Name + ", args.State = " + args.State);
                inputfield.TextColor = Color.Black;
                inputfield.Text = "Click on the cancel button";
            }
        }

        private void OnDeleteBtnClickEvent(object sender, Tizen.FH.NUI.Controls.InputField.ButtonClickArgs args)
        {
            if (sender is Tizen.FH.NUI.Controls.InputField)
            {
                Tizen.FH.NUI.Controls.InputField inputfield = sender as Tizen.FH.NUI.Controls.InputField;
                Console.WriteLine("-------, name: " + inputfield.Name + ", args.State = " + args.State);
                inputfield.Text = "Click on the delete button";
            }
        }

        private void OnAddBtnClickEvent(object sender, Tizen.FH.NUI.Controls.InputField.ButtonClickArgs args)
        {
            if (sender is Tizen.FH.NUI.Controls.InputField)
            {
                Tizen.FH.NUI.Controls.InputField inputfield = sender as Tizen.FH.NUI.Controls.InputField;
                Console.WriteLine("-------, name: " + inputfield.Name + ", args.State = " + args.State);
                inputfield.Text = "Click on the add button";
            }
        }
    }
}
