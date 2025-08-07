using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;
using System;
using System.Threading;

namespace Tizen.NUI.Samples
{
    public class FlushApplicationMessageSample : IExample
    {
        private View root;
        private TextLabel textLabel;
        private NUIApplication application;

        public void SetCurrentApplication(Tizen.NUI.NUIApplication application)
        {
            Tizen.Log.Error("NUITEST", $"SetCurrentApplication {application}\n");
            this.application = application;
        }

        public Tizen.NUI.NUIApplication GetCurrentApplication()
        {
            Tizen.Log.Error("NUITEST", $"GetCurrentApplication {application}\n");
            return application;
        }

        private delegate void FuncDelegate();
        private FuncDelegate FuncDelegater = null;

        private void Func()
        {
            Tizen.Log.Error("NUITEST", "Idle callback comes!\n");
            FuncDelegater = null;
        }
        private void Func2()
        {
            Tizen.Log.Error("NUITEST", "Idle callback comes! Register idle once again!\n");
            FuncDelegater = Func;
            GetCurrentApplication()?.AddIdle(FuncDelegater);
        }

        public void Activate()
        {
            Window window = NUIApplication.GetDefaultWindow();

            root = new View()
            {
                Size = window.Size,
                BackgroundColor = new Color(0.8f, 0.8f, 0.8f, 0.6f),
                ParentOrigin = ParentOrigin.Center,
                PivotPoint = PivotPoint.Center,
                PositionUsesPivotPoint = true,
            };
            window.Add(root);

            textLabel = new TextLabel()
            {
                Text = "SceneOn",
            };

            root.Add(textLabel);
            Tizen.Log.Error("NUITEST", "SceneOn\n");

            textLabel.Text = "Sleep 5 seconds";

            GetCurrentApplication()?.FlushUpdateMessages();
            Tizen.Log.Error("NUITEST", "FlushUpdateMessages\n");

            Tizen.Log.Error("NUITEST", "Sleep 5 seconds\n");
            Thread.Sleep(5000); /// sleep 5 seconds
            Tizen.Log.Error("NUITEST", "Sleep done\n");

            textLabel.Text = "Sleep done!\n";

            window.KeyEvent += WinKeyEvent;
        }

        public void Deactivate()
        {
            if (root != null)
            {
                Window window = NUIApplication.GetDefaultWindow();
                window.Remove(root);
                window.KeyEvent -= WinKeyEvent;
                root.Dispose();

                if (FuncDelegater != null)
                {
                    GetCurrentApplication()?.RemoveIdle(FuncDelegater);
                }
            }
        }

        private void WinKeyEvent(object sender, Window.KeyEventArgs e)
        {
            if (e.Key.State == Key.StateType.Down)
            {
                if (e.Key.KeyPressedName == "1")
                {
                    Tizen.Log.Error("NUITEST", "Add idle callback\n");
                    if (FuncDelegater == null)
                    {
                        FuncDelegater = Func;
                    }

                    GetCurrentApplication()?.AddIdle(FuncDelegater);
                }
                else if (e.Key.KeyPressedName == "2")
                {
                    Tizen.Log.Error("NUITEST", "Add idle callback, and remove immediately\n");
                    if (FuncDelegater == null)
                    {
                        FuncDelegater = Func;
                    }

                    GetCurrentApplication()?.AddIdle(FuncDelegater);
                    GetCurrentApplication()?.RemoveIdle(FuncDelegater);
                    GetCurrentApplication()?.AddIdle(FuncDelegater);
                    GetCurrentApplication()?.RemoveIdle(FuncDelegater);
                    FuncDelegater = null;
                }
                else if (e.Key.KeyPressedName == "3")
                {
                    Tizen.Log.Error("NUITEST", "Add idle callback during idle callback execute\n");
                    if (FuncDelegater == null)
                    {
                        FuncDelegater = Func2;
                    }

                    GetCurrentApplication()?.AddIdle(FuncDelegater);
                }
                else if (e.Key.KeyPressedName == "4")
                {
                    Tizen.Log.Error("NUITEST", "Add multiple idle callback times\n");
                    if (FuncDelegater == null)
                    {
                        FuncDelegater = Func;
                    }

                    GetCurrentApplication()?.AddIdle(FuncDelegater);
                    GetCurrentApplication()?.AddIdle(FuncDelegater);
                    GetCurrentApplication()?.RemoveIdle(FuncDelegater);
                    GetCurrentApplication()?.AddIdle(FuncDelegater);

                    FuncDelegater = Func2;
                    GetCurrentApplication()?.AddIdle(FuncDelegater);
                }
                else if (e.Key.KeyPressedName == "5")
                {
                    Tizen.Log.Error("NUITEST", "Self dispose after add idle callback\n");
                    if (FuncDelegater == null)
                    {
                        FuncDelegater = Func;
                    }

                    GetCurrentApplication()?.AddIdle(FuncDelegater);
                    GetCurrentApplication()?.Dispose();
                }
            }
        }
    }
}
