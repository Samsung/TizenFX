using System;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.UIComponents;

namespace RefCountMemoryLeakTest2
{
    class Program : NUIApplication
    {
        const string X = "NUI1";
        protected override void OnCreate()
        {
            base.OnCreate();
            Initialize();
        }

        View parent1, child1, child2;
        
        void Initialize()
        {
            Window.Instance.KeyEvent += OnKeyEvent;
            Window.Instance.BackgroundColor = Color.Green;
        }

        public void OnKeyEvent(object sender, Window.KeyEventArgs e)
        {
            if (e.Key.State == Key.StateType.Down && (e.Key.KeyPressedName == "XF86Back" || e.Key.KeyPressedName == "Escape"))
            {
                Exit();
            }
            else if (e.Key.State == Key.StateType.Down && e.Key.KeyPressedName == "Return")
            {
            }
            else if (e.Key.State == Key.StateType.Down && e.Key.KeyPressedName == "Left")
            {
            }
            else if (e.Key.State == Key.StateType.Down && e.Key.KeyPressedName == "Up")
            {
            }
            else if (e.Key.State == Key.StateType.Down && e.Key.KeyPressedName == "Right")
            {
            }
            ////////////////////////////////////////////////////////////////////////
            else if (e.Key.State == Key.StateType.Down && e.Key.KeyPressedName == "1")
            {
                Tizen.Log.Fatal(X, $"########## 1 pressed! ################");
                Tizen.Log.Fatal(X, $"View.Parent property test!");
                Tizen.Log.Fatal(X, $"parent is a View and child is View");
                Tizen.Log.Fatal(X, $"####################################");

                Layer layer = Window.Instance.GetDefaultLayer();
                parent1 = new View();
                parent1.BackgroundColor = Color.Blue;
                parent1.Size2D = new Size2D(200, 200);
                layer.Add(parent1);

                View child = new View();
                child.BackgroundColor = Color.Blue;
                child.Size2D = new Size2D(200, 200);
                parent1.Add(child);

                Tizen.Log.Fatal(X, $"[Before test] layer(DefaultLayer) refcnt={layer?.GetObjectPtr()?.ReferenceCount()}");
                Tizen.Log.Fatal(X, $"[Before test] parent1 id={parent1.ID} refcnt={parent1?.GetObjectPtr()?.ReferenceCount()}");
                Tizen.Log.Fatal(X, $"[Before test] child id={child.ID} refcnt={child?.GetObjectPtr()?.ReferenceCount()}");

                View parent = child.Parent;

                Tizen.Log.Fatal(X, $"[After test] layer(DefaultLayer) refcnt={layer?.GetObjectPtr()?.ReferenceCount()}");
                Tizen.Log.Fatal(X, $"[After test] parent id={parent.ID} refcnt={parent?.GetObjectPtr()?.ReferenceCount()}");
                Tizen.Log.Fatal(X, $"[After test] child id={child.ID} refcnt={child?.GetObjectPtr()?.ReferenceCount()}");

                Tizen.Log.Fatal(X, $"############### END! #####################");
            }
            ////////////////////////////////////////////////////////////////////////
            else if (e.Key.State == Key.StateType.Down && e.Key.KeyPressedName == "2")
            {
                Tizen.Log.Fatal(X, $"########## 2 pressed! ################");
                Tizen.Log.Fatal(X, $"View.Parent property test!");
                Tizen.Log.Fatal(X, $"parent is DefaultLayer and child is View");
                Tizen.Log.Fatal(X, $"####################################");

                Layer layer = Window.Instance.GetDefaultLayer();
                View child = new View();
                child.BackgroundColor = Color.Blue;
                child.Size2D = new Size2D(200, 200);
                layer.Add(child);

                Tizen.Log.Fatal(X, $"[Before test] layer(DefaultLayer) refcnt={layer?.GetObjectPtr()?.ReferenceCount()}");
                Tizen.Log.Fatal(X, $"[Before test] child id={child.ID} refcnt={child?.GetObjectPtr()?.ReferenceCount()}");

                View parent = child.Parent;

                Tizen.Log.Fatal(X, $"[After test] parent(DefaultLayer) refcnt={parent?.GetObjectPtr()?.ReferenceCount()}");
                Tizen.Log.Fatal(X, $"[After test] child id={child.ID} refcnt={child?.GetObjectPtr()?.ReferenceCount()}");

                Tizen.Log.Fatal(X, $"############### END! #####################");
            }
            ////////////////////////////////////////////////////////////////////////
            else if (e.Key.State == Key.StateType.Down && e.Key.KeyPressedName == "3")
            {
                Tizen.Log.Fatal(X, $"########## 3 pressed! ################");
                Tizen.Log.Fatal(X, $"View.GetParent() test!");
                Tizen.Log.Fatal(X, $"parent is DefaultLayer and child is View");
                Tizen.Log.Fatal(X, $"####################################");

                Layer layer = Window.Instance.GetDefaultLayer();
                View child = new View();
                child.BackgroundColor = Color.Blue;
                child.Size2D = new Size2D(200, 200);
                layer.Add(child);

                Tizen.Log.Fatal(X, $"[Before test] layer(DefaultLayer) refcnt={layer?.GetObjectPtr()?.ReferenceCount()}");
                Tizen.Log.Fatal(X, $"[Before test] child id={child.ID} refcnt={child?.GetObjectPtr()?.ReferenceCount()}");

                Layer parent = child.GetParent() as Layer;

                Tizen.Log.Fatal(X, $"[After test] parent(DefaultLayer) refcnt={parent?.GetObjectPtr()?.ReferenceCount()}");
                Tizen.Log.Fatal(X, $"[After test] child id={child.ID} refcnt={child?.GetObjectPtr()?.ReferenceCount()}");

                Tizen.Log.Fatal(X, $"############### END! #####################");
            }
            ////////////////////////////////////////////////////////////////////////
            else if (e.Key.State == Key.StateType.Down && e.Key.KeyPressedName == "4")
            {
                Tizen.Log.Fatal(X, $"########## 4 pressed! ################");
                Tizen.Log.Fatal(X, $"FocusManager.GetCurrentFocusView() test!");
                Tizen.Log.Fatal(X, $"parent1 is a View and there are 2 children");
                Tizen.Log.Fatal(X, $"####################################");

                Layer layer = Window.Instance.GetDefaultLayer();
                parent1 = new View();
                parent1.BackgroundColor = Color.Yellow;
                parent1.Size2D = new Size2D(500, 500);
                parent1.Position2D = new Position2D(100, 100);
                layer.Add(parent1);

                child1 = new View();
                child1.BackgroundColor = Color.Red;
                child1.Size2D = new Size2D(100, 100);
                child1.Position2D = new Position2D(150, 150);
                child1.Focusable = true;
                parent1.Add(child1);

                child2 = new View();
                child2.BackgroundColor = Color.Red;
                child2.Size2D = new Size2D(100, 100);
                child2.Position2D = new Position2D(300, 150);
                child2.Focusable = true;
                parent1.Add(child2);

                child1.RightFocusableView = child2;
                child2.LeftFocusableView = child1;

                Tizen.Log.Fatal(X, $"[Before test] child1 id={child1.ID} refcnt={child1?.GetObjectPtr()?.ReferenceCount()}");
                Tizen.Log.Fatal(X, $"[Before test] child2 id={child2.ID} refcnt={child2?.GetObjectPtr()?.ReferenceCount()}");
                Tizen.Log.Fatal(X, $"[Before test] parent1 id={parent1.ID} refcnt={parent1?.GetObjectPtr()?.ReferenceCount()}");

                FocusManager.Instance.SetCurrentFocusView(child1);

                Tizen.Log.Fatal(X, $"please push Right, Left key on remocon");
                Tizen.Log.Fatal(X, $"and check the values with 8 key!");

                View currentFocused = FocusManager.Instance.GetCurrentFocusView();
                Tizen.Log.Fatal(X, $"[After test] currentFocused id={currentFocused.ID} refcnt={currentFocused?.GetObjectPtr()?.ReferenceCount()}");
            }
            else if (e.Key.State == Key.StateType.Down && e.Key.KeyPressedName == "5")
            {
                Tizen.Log.Fatal(X, $"########## 5 pressed! ################");
                Tizen.Log.Fatal(X, $"FocusManager.GetCurrentFocusView() test!");
                Tizen.Log.Fatal(X, $"this is After test!!!");
                Tizen.Log.Fatal(X, $"####################################");

                View currentFocused = FocusManager.Instance.GetCurrentFocusView();
                Tizen.Log.Fatal(X, $"[After test] currentFocused id={currentFocused.ID} refcnt={currentFocused?.GetObjectPtr()?.ReferenceCount()}");
                Tizen.Log.Fatal(X, $"[After test] parent1 id={parent1.ID} refcnt={parent1?.GetObjectPtr()?.ReferenceCount()}");
            }
            ////////////////////////////////////////////////////////////////////////
            else if (e.Key.State == Key.StateType.Down && e.Key.KeyPressedName == "6")
            {
                Tizen.Log.Fatal(X, $"########## 6 pressed! ################");
                Tizen.Log.Fatal(X, $"Parent TCT crash test! should not be crashed");
                Tizen.Log.Fatal(X, $"####################################");

                /* TEST CODE */
                View view = new View();
                View leftView = new View();
                Window.Instance.GetDefaultLayer().Add(view);
                Window.Instance.GetDefaultLayer().Add(leftView);
                view.LeftFocusableView = leftView;
                if(leftView == view.LeftFocusableView)
                {
                    Tizen.Log.Fatal(X, $"view and LeftView is same => good!");
                }
                else
                {
                    Tizen.Log.Fatal(X, $"view and LeftView is different => NG!");
                }
            }


        }

        static void _Main(string[] args)
        {
            var app = new Program();
            app.Run(args);
        }
    }
}

