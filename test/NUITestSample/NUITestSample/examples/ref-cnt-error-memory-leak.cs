using System;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.UIComponents;

namespace RefCountMemoryLeakTest
{
    class Program : NUIApplication
    {
        protected override void OnCreate()
        {
            base.OnCreate();
            Initialize();
        }

        View test1;
        View[] children = new View[10];

        void Initialize()
        {
            Window.Instance.KeyEvent += OnKeyEvent;
            Window.Instance.BackgroundColor = Color.Green;

            test1 = new View();
            test1.BackgroundColor = Color.Blue;
            test1.Size2D = new Size2D(100, 100);
            Window.Instance.Add(test1);
        }

        Animation animation1;
        public void OnKeyEvent(object sender, Window.KeyEventArgs e)
        {
            if (e.Key.State == Key.StateType.Down && (e.Key.KeyPressedName == "XF86Back" || e.Key.KeyPressedName == "Escape"))
            {
                Exit();
            }
            else if (e.Key.State == Key.StateType.Down && e.Key.KeyPressedName == "Return")
            {
                if(!test1)
                {
                    test1 = new View();
                    test1.BackgroundColor = Color.Blue;
                    test1.Size2D = new Size2D(100, 100);
                    Window.Instance.GetDefaultLayer().Add(test1);
                }

                if (test1)
                {
                    if(!animation1)
                    {
                        animation1 = new Animation(1000);
                        animation1.AnimateTo(test1, "Orientation", new Rotation(new Radian(new Degree(180.0f)), PositionAxis.X), 0, 500);
                        animation1.AnimateTo(test1, "Orientation", new Rotation(new Radian(new Degree(0.0f)), PositionAxis.X), 500, 1000);
                        Tizen.Log.Fatal("NUI1", $"@@@ new Animation()!");
                    }
                    animation1?.Play();
                }
            }
            else if (e.Key.State == Key.StateType.Down && e.Key.KeyPressedName == "Left")
            {
                //test1?.GetObjectPtr()?.Unreference();
                if(animation1)
                {
                    animation1.Finished += Animation1_Finished;
                    Tizen.Log.Fatal("NUI1", $"@@@ ADD finished!");
                }
            }
            else if (e.Key.State == Key.StateType.Down && e.Key.KeyPressedName == "Up")
            {
                test1?.Dispose();
                test1 = null;
            }
            else if (e.Key.State == Key.StateType.Down && e.Key.KeyPressedName == "Right")
            {
                animation1?.Dispose();
                animation1 = null;
            }
            else if (e.Key.State == Key.StateType.Down && e.Key.KeyPressedName == "1")
            {
                Tizen.Log.Fatal("NUI1", $"########## 1 pressed! ##########");

                Layer layer = Window.Instance.GetDefaultLayer();

                Tizen.Log.Fatal("NUI1", $"[1]Add! test1 id={test1.ID} test1's refcnt={test1?.GetObjectPtr()?.ReferenceCount()}");
                Tizen.Log.Fatal("NUI1", $"layer's refcnt={layer?.GetObjectPtr()?.ReferenceCount()}");
                layer?.Add(test1);
                Tizen.Log.Fatal("NUI1", $"[2]Add! test1 id={test1.ID} test1's refcnt={test1?.GetObjectPtr()?.ReferenceCount()}");
                Tizen.Log.Fatal("NUI1", $"layer's refcnt={layer?.GetObjectPtr()?.ReferenceCount()}");

                Tizen.Log.Fatal("NUI1", $"GetParent(): test1's refcnt={test1?.GetParent()?.GetObjectPtr()?.ReferenceCount()}, layer's refcnt={layer?.GetObjectPtr()?.ReferenceCount()}");
                layer?.Remove(test1);

                Tizen.Log.Fatal("NUI1", $"[3]Remove! test1 id={test1.ID} test1's refcnt={test1?.GetObjectPtr()?.ReferenceCount()}");
                Tizen.Log.Fatal("NUI1", $"layer's refcnt={layer?.GetObjectPtr()?.ReferenceCount()}");

                Tizen.Log.Fatal("NUI1", $"GetParent(): test1's refcnt={test1?.GetParent()?.GetObjectPtr()?.ReferenceCount()}, layer's refcnt={layer?.GetObjectPtr()?.ReferenceCount()}");

                Tizen.Log.Fatal("NUI1", $"#####################");
            }
            else if (e.Key.State == Key.StateType.Down && e.Key.KeyPressedName == "2")
            {
                Tizen.Log.Fatal("NUI1", $"########## 2 pressed! ##########");

                Layer layer = Window.Instance.GetDefaultLayer();

                Tizen.Log.Fatal("NUI1", $"[1]Add! test1 id={test1.ID} test1's refcnt={test1?.GetObjectPtr()?.ReferenceCount()}");
                Tizen.Log.Fatal("NUI1", $"layer's refcnt={layer?.GetObjectPtr()?.ReferenceCount()}");
                layer?.Add(test1);
                Tizen.Log.Fatal("NUI1", $"[2]Add! test1 id={test1.ID} test1's refcnt={test1?.GetObjectPtr()?.ReferenceCount()}");
                Tizen.Log.Fatal("NUI1", $"layer's refcnt={layer?.GetObjectPtr()?.ReferenceCount()}");

                Tizen.Log.Fatal("NUI1", $"test1's GetParent() refcnt={test1?.GetParent()?.GetObjectPtr()?.ReferenceCount()}, layer's refcnt={layer?.GetObjectPtr()?.ReferenceCount()}");
                for(int i=0; i<5; i++)
                {
                    children[i] = new ImageView();
                    children[i].Size2D = new Size2D(100, 100);
                    children[i].Position2D = new Position2D(100 + 50 * (i + 1), 100 + 50 * (i + 1));
                    children[i].BackgroundColor = Color.Red;
                    layer.Add(children[i]);
                    Tizen.Log.Fatal("NUI1", $"children[{i}]'s refcnt={children[i]?.GetParent()?.GetObjectPtr()?.ReferenceCount()}, layer's refcnt={layer?.GetObjectPtr()?.ReferenceCount()}");
                }

                for (int i = 5; i < 10; i++)
                {
                    children[i] = new View();
                    children[i].Size2D = new Size2D(100, 100);
                    children[i].Position2D = new Position2D(100 + 50 * (i + 1), 100 + 50 * (i + 1));
                    children[i].BackgroundColor = Color.Yellow;
                    test1.Add(children[i]);
                    Tizen.Log.Fatal("NUI1", $"children[{i}] refcnt={children[i]?.GetParent()?.GetObjectPtr()?.ReferenceCount()}, test1 refcnt={test1?.GetObjectPtr()?.ReferenceCount()}");
                }

                View temp;
                for(int i=0; i<8; i++)
                {
                    temp = layer.GetChildAt((uint)i);
                    Tizen.Log.Fatal("NUI1", $"temp(idx[{i}])={temp?.GetTypeName()}'s refcnt={temp?.GetParent()?.GetObjectPtr()?.ReferenceCount()}, layer's refcnt={layer?.GetObjectPtr()?.ReferenceCount()}");
                }

                for (int i = 0; i < 8; i++)
                {
                    temp = test1.GetChildAt((uint)i);
                    Tizen.Log.Fatal("NUI1", $"GetChildAt: temp(idx[{i}])={temp?.GetTypeName()}'s refcnt={temp?.GetParent()?.GetObjectPtr()?.ReferenceCount()}, test1's refcnt={test1?.GetObjectPtr()?.ReferenceCount()}");
                }

                layer?.Remove(test1);

                Tizen.Log.Fatal("NUI1", $"[3]Remove! test1 id={test1.ID} test1's refcnt={test1?.GetObjectPtr()?.ReferenceCount()}");
                Tizen.Log.Fatal("NUI1", $"layer's refcnt={layer?.GetObjectPtr()?.ReferenceCount()}");

                Tizen.Log.Fatal("NUI1", $"test1's GetParent() refcnt={test1?.GetParent()?.GetObjectPtr()?.ReferenceCount()}, layer's refcnt={layer?.GetObjectPtr()?.ReferenceCount()}");

                Tizen.Log.Fatal("NUI1", $"#####################");
            }
            else if (e.Key.State == Key.StateType.Down && e.Key.KeyPressedName == "3")
            {
                Tizen.Log.Fatal("NUI1", $"########## 3 pressed! ##########");

                Layer layer = Window.Instance.GetDefaultLayer();

                Tizen.Log.Fatal("NUI1", $"[1]Add! test1 id={test1.ID} test1's refcnt={test1?.GetObjectPtr()?.ReferenceCount()}");
                Tizen.Log.Fatal("NUI1", $"layer's refcnt={layer?.GetObjectPtr()?.ReferenceCount()}");
                layer?.Add(test1);
                Tizen.Log.Fatal("NUI1", $"[2]Add! test1 id={test1.ID} test1's refcnt={test1?.GetObjectPtr()?.ReferenceCount()}");
                Tizen.Log.Fatal("NUI1", $"layer's refcnt={layer?.GetObjectPtr()?.ReferenceCount()}");

                Tizen.Log.Fatal("NUI1", $"test1's GetParent() refcnt={test1?.GetParent()?.GetObjectPtr()?.ReferenceCount()}, layer's refcnt={layer?.GetObjectPtr()?.ReferenceCount()}");
                for (int i = 0; i < 5; i++)
                {
                    children[i] = new ImageView();
                    children[i].Size2D = new Size2D(100, 100);
                    children[i].Position2D = new Position2D(100 + 50 * (i + 1), 100 + 50 * (i + 1));
                    children[i].BackgroundColor = Color.Red;
                    layer.Add(children[i]);
                    Tizen.Log.Fatal("NUI1", $"children[{i}]:id({children[i].ID})'s refcnt={children[i]?.GetParent()?.GetObjectPtr()?.ReferenceCount()}, layer's refcnt={layer?.GetObjectPtr()?.ReferenceCount()}");
                }

                for (int i = 5; i < 10; i++)
                {
                    children[i] = new View();
                    children[i].Size2D = new Size2D(100, 100);
                    children[i].Position2D = new Position2D(100 + 50 * (i + 1), 100 + 50 * (i + 1));
                    children[i].BackgroundColor = Color.Yellow;
                    test1.Add(children[i]);
                    Tizen.Log.Fatal("NUI1", $"children[{i}] refcnt={children[i]?.GetParent()?.GetObjectPtr()?.ReferenceCount()}, test1 refcnt={test1?.GetObjectPtr()?.ReferenceCount()}");
                }

                View temp;
                for (int i = 1; i < children[9].ID + 1; i++)
                {
                    temp = layer.FindChildById((uint)i);
                    Tizen.Log.Fatal("NUI1", $"FindChildById: temp(id[{i}])={temp?.GetTypeName()}'s refcnt={temp?.GetParent()?.GetObjectPtr()?.ReferenceCount()}, layer's refcnt={layer?.GetObjectPtr()?.ReferenceCount()}");
                }

                for (int i = 0; i < 10; i++)
                {
                    children[i].Unparent();
                    children[i].Dispose();
                    children[i] = null;
                }

                layer?.Remove(test1);

                Tizen.Log.Fatal("NUI1", $"[3]Remove! test1 id={test1.ID} test1's refcnt={test1?.GetObjectPtr()?.ReferenceCount()}");
                Tizen.Log.Fatal("NUI1", $"layer's refcnt={layer?.GetObjectPtr()?.ReferenceCount()}");

                Tizen.Log.Fatal("NUI1", $"test1's GetParent() refcnt={test1?.GetParent()?.GetObjectPtr()?.ReferenceCount()}, layer's refcnt={layer?.GetObjectPtr()?.ReferenceCount()}");

                Tizen.Log.Fatal("NUI1", $"#####################");
            }
            else if (e.Key.State == Key.StateType.Down && e.Key.KeyPressedName == "4")
            {
                Tizen.Log.Fatal("NUI1", $"########## 4 pressed! ##########");

                Layer layer = Window.Instance.GetDefaultLayer();

                Tizen.Log.Fatal("NUI1", $"[1]Add! test1 id={test1.ID} test1's refcnt={test1?.GetObjectPtr()?.ReferenceCount()}");
                Tizen.Log.Fatal("NUI1", $"layer's refcnt={layer?.GetObjectPtr()?.ReferenceCount()}");
                layer?.Add(test1);
                Tizen.Log.Fatal("NUI1", $"[2]Add! test1 id={test1.ID} test1's refcnt={test1?.GetObjectPtr()?.ReferenceCount()}");
                Tizen.Log.Fatal("NUI1", $"layer's refcnt={layer?.GetObjectPtr()?.ReferenceCount()}");

                for (int i = 0; i < 5; i++)
                {
                    children[i] = new ImageView();
                    children[i].Size2D = new Size2D(100, 100);
                    children[i].Position2D = new Position2D(100 + 50 * (i + 1), 100 + 50 * (i + 1));
                    children[i].BackgroundColor = Color.Red;
                    children[i].Name = "TestView" + i;
                    test1.Add(children[i]);
                    Tizen.Log.Fatal("NUI1", $"children[{i}]:id({children[i].ID})'s refcnt={children[i]?.GetParent()?.GetObjectPtr()?.ReferenceCount()}, test1's refcnt={test1?.GetObjectPtr()?.ReferenceCount()}");
                }

                for (int i = 5; i < 10; i++)
                {
                    children[i] = new View();
                    children[i].Size2D = new Size2D(100, 100);
                    children[i].Position2D = new Position2D(100 + 50 * (i + 1), 100 + 50 * (i + 1));
                    children[i].BackgroundColor = Color.Yellow;
                    children[i].Name = "TestView" + i;
                    test1.Add(children[i]);
                    Tizen.Log.Fatal("NUI1", $"children[{i}] refcnt={children[i]?.GetParent()?.GetObjectPtr()?.ReferenceCount()}, test1 refcnt={test1?.GetObjectPtr()?.ReferenceCount()}");
                }

                View temp;
                for (int i = 0; i < 10; i++)
                {
                    temp = test1.FindChildByName("TestView" + i);
                    Tizen.Log.Fatal("NUI1", $"FindChildByName: temp(name:{temp.Name})={temp?.GetTypeName()}'s refcnt={temp?.GetParent()?.GetObjectPtr()?.ReferenceCount()}, test1's refcnt={test1?.GetObjectPtr()?.ReferenceCount()}");
                }

                for (int i = 0; i < 10; i++)
                {
                    children[i].Unparent();
                    children[i].Dispose();
                    children[i] = null;
                }

                layer?.Remove(test1);

                Tizen.Log.Fatal("NUI1", $"[3]Remove! test1 id={test1.ID} test1's refcnt={test1?.GetObjectPtr()?.ReferenceCount()}");
                Tizen.Log.Fatal("NUI1", $"layer's refcnt={layer?.GetObjectPtr()?.ReferenceCount()}");

                Tizen.Log.Fatal("NUI1", $"test1's GetParent() refcnt={test1?.GetParent()?.GetObjectPtr()?.ReferenceCount()}, layer's refcnt={layer?.GetObjectPtr()?.ReferenceCount()}");

                Tizen.Log.Fatal("NUI1", $"#####################");
            }


            Tizen.Log.Fatal("NUI1", $"@@@ test1 refcnt={test1?.GetObjectPtr()?.ReferenceCount()} , key={e.Key.KeyPressedName}");
            Tizen.Log.Fatal("NUI1", $"@@@ animation1 refcnt={animation1?.GetObjectPtr()?.ReferenceCount()}");
        }

        private void Animation1_Finished(object sender, EventArgs e)
        {
            Tizen.Log.Fatal("NUI1", $"@@@ ======== Finished! animation1 ref-cnt={animation1?.GetObjectPtr()?.ReferenceCount()}");
            Tizen.Log.Fatal("NUI1", $"@@@ test1 ref-cnt={test1?.GetObjectPtr()?.ReferenceCount()}");
            Tizen.Log.Fatal("NUI1", $"@@@ ==========================================");
        }

        static void ___Main(string[] args)
        {
            var app = new Program();
            app.Run(args);
        }
    }
}

