
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;
using System;

namespace Tizen.NUI.Samples
{
    using l = Tizen.Log;

    public class FindChildByIDTest : IExample
    {
        Window window;
        Layer layer1, layer2;
        View view1, view2;
        TextLabel text1, text2;
        uint layer1ID, layer2ID, view1ID, view2ID, text1ID, text2ID;
        const string t = "NUITEST";

        public void Activate()
        {
            window = NUIApplication.GetDefaultWindow();
            window.KeyEvent += WindowKeyEvent;
            window.TouchEvent += WindowTouchEvent;

            layer1 = new Layer();
            layer1.Name = "layerTest1";
            window.AddLayer(layer1);

            layer2 = new Layer();
            layer2.Name = "layerTest2";
            window.AddLayer(layer2);

            view1 = new View();
            view1.Name = "viewTest1";
            view1.Size = new Size(100, 100);
            view1.Position = new Position(10, 10);
            view1.BackgroundColor = Color.Blue;
            layer1.Add(view1);

            view2 = new View();
            view2.Name = "viewTest2";
            view2.Size = new Size(100, 100);
            view2.Position = new Position(100, 100);
            view2.BackgroundColor = Color.Blue;
            layer2.Add(view2);

            text1 = new TextLabel()
            {
                Name = "textTest1",
                Size = new Size(300, 100),
                Position = new Position(200, 200),
                Text = "text1",
                BackgroundColor = Color.Yellow,
            };
            view1.Add(text1);

            text2 = new TextLabel()
            {
                Name = "textTest2",
                Size = new Size(300, 100),
                Position = new Position(300, 300),
                Text = "text2",
                BackgroundColor = Color.Green,
            };
            view2.Add(text2);

            layer1ID = layer1.ID;
            layer2ID = layer2.ID;
            view1ID = view1.ID;
            view2ID = view2.ID;
            text1ID = text1.ID;
            text2ID = text2.ID;
        }

        bool toggle = false;
        private void WindowTouchEvent(object sender, Window.TouchEventArgs e)
        {
            if (e.Touch.GetState(0) == PointStateType.Down)
            {
                l.Fatal(t, $"======================");
                var ret = checkTest() ? "PASS" : "FAIL";
                l.Fatal(t, $"test result={ret}");
            }
        }

        private void WindowKeyEvent(object sender, Window.KeyEventArgs e)
        {
            if (e.Key.State == Key.StateType.Down)
            {
                if (e.Key.KeyPressedName == "Up")
                {
                    l.Fatal(t, $"======================");
                    var ret = checkTest() ? "PASS" : "FAIL";
                    l.Fatal(t, $"test result={ret}");
                }
            }
        }

        bool checkTest()
        {
            bool ret = true;
            toggle = !toggle;

            if (toggle)
            {
                var gotten = window.FindLayerByID(layer1ID);
                if (gotten)
                {
                    if (layer1ID == gotten.ID)
                    {
                        l.Fatal(t, $"Test#1: FindLayerByID({gotten.ID}) OK");
                        var gotten2 = gotten.FindChildById(text1ID);
                        if (gotten2.ID == text1ID)
                        {
                            l.Fatal(t, $"Test#1-1: FindChildById({gotten2.ID}) OK");
                        }
                        else
                        {
                            l.Fatal(t, $"Test#1-1: FindChildById({gotten2.ID}) ERROR");
                            ret = false;
                        }

                        gotten2 = gotten.FindChildById(view2ID);
                        if (gotten2 == null)
                        {
                            l.Fatal(t, $"Test#1-2: FindChildById() OK");
                        }
                        else
                        {
                            l.Fatal(t, $"Test#1-2: FindChildById() ERROR");
                            ret = false;
                        }
                    }
                    else
                    {
                        l.Fatal(t, $"Test#1: FindLayerByID({gotten.ID}) ERROR");
                        ret = false;
                    }
                }
                else
                {
                    l.Fatal(t, $"Test#1: FindLayerByID() ERROR, gotten Layer is NULL!");
                    ret = false;
                }
            }
            else
            {
                var gotten = window.FindLayerByID(layer2ID);
                if (gotten)
                {
                    if (layer2ID == gotten.ID)
                    {
                        l.Fatal(t, $"Test#2: FindLayerByID({gotten.ID}) OK");
                        var gotten2 = gotten.FindChildById(text2ID);
                        if (gotten2.ID == text2ID)
                        {
                            l.Fatal(t, $"Test#2-1: FindChildById({gotten2.ID}) OK");
                        }
                        else
                        {
                            l.Fatal(t, $"Test#2-1: FindChildById({gotten2.ID}) ERROR");
                            ret = false;
                        }

                        gotten2 = gotten.FindChildById(view1ID);
                        if (gotten2 == null)
                        {
                            l.Fatal(t, $"Test#2-2: FindChildById() OK");
                        }
                        else
                        {
                            l.Fatal(t, $"Test#2-2: FindChildById() ERROR");
                            ret = false;
                        }
                    }
                    else
                    {
                        l.Fatal(t, $"Test#2: FindLayerByID({gotten.ID}) ERROR");
                        ret = false;
                    }
                }
                else
                {
                    l.Fatal(t, $"Test#2: FindLayerByID() ERROR, gotten Layer is NULL!");
                    ret = false;
                }
            }
            return ret;
        }

        public void Deactivate()
        {
        }
    }
}
