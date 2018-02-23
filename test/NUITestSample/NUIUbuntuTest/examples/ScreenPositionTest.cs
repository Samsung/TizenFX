using System;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;

namespace ScreenPositionTest
{
    class Test : NUIApplication
    {
        protected override void OnCreate()
        {
            base.OnCreate();
            StartTest();
        }
        const string TAG = "NUI";
        public class MyView
        {
            public TextLabel textLabelName;
            public TextLabel textLabelPosition;
            public TextLabel textLabelScreenPosition;
            public View myView;
            public MyView(string name, Size2D mySize, View parent, int textSize)
            {
                myView = new View();
                myView.Name = name;

                textLabelName = new TextLabel($"{name} size=({mySize.Width},{mySize.Height}) parent name={parent?.Name} ");
                textLabelName.PositionUsesPivotPoint = true;
                textLabelName.ParentOrigin = Tizen.NUI.ParentOrigin.TopLeft;
                textLabelName.PivotPoint = Tizen.NUI.PivotPoint.TopLeft;
                textLabelName.PixelSize = textSize;
                myView.Add(textLabelName);

                textLabelPosition = new TextLabel("Not Set");
                textLabelPosition.PositionUsesPivotPoint = true;
                textLabelPosition.ParentOrigin = Tizen.NUI.ParentOrigin.CenterLeft;
                textLabelPosition.PivotPoint = Tizen.NUI.PivotPoint.CenterLeft;
                textLabelPosition.PixelSize = textSize;
                myView.Add(textLabelPosition);

                textLabelScreenPosition = new TextLabel("Not Available");
                textLabelScreenPosition.PositionUsesPivotPoint = true;
                textLabelScreenPosition.ParentOrigin = Tizen.NUI.ParentOrigin.BottomLeft;
                textLabelScreenPosition.PivotPoint = Tizen.NUI.PivotPoint.BottomLeft;
                textLabelScreenPosition.PixelSize = textSize;
                myView.Add(textLabelScreenPosition);

                myView.Size2D = mySize;
                Random rand = new Random();
                float col = rand.Next(1, 255) / 255.0f;
                myView.BackgroundColor = new Color(col, 1 - col, col, 1.0f);

                if (parent == null)
                {
                    Window.Instance.Add(myView);
                }
                else
                {
                    parent.Add(myView);
                }

                myView.Focusable = true;
                Tizen.Log.Fatal(TAG, $"myView constructor! name={name}");
            }
            Position2D myPos;
            public Position2D MyPosition
            {
                set
                {
                    myPos = value;
                    myView.Position2D = myPos;
                }
                get
                {
                    return myPos;
                }
            }
            int updatedCnt = 0;
            public void UpdateMe()
            {
                textLabelPosition.Text = $"position=({(int)myView.Position2D.X},{(int)myView.Position2D.Y}) updated count={updatedCnt++}  ";
                textLabelScreenPosition.Text = $"screen position=({(int)myView.ScreenPosition.X},{(int)myView.ScreenPosition.Y})  ";
                //Tizen.Log.Fatal(TAG, $"### now UpdateMe()!");
            }
        }

        MyView myView1, myView2, myView3;
        TextLabel parent;
        Animation ani;
        Timer timer;
        void ScreenPositionTest()
        {
            parent = new TextLabel("This is parent view: Position(100,100) ParentOrigin & PivotPoint are all TopLeft, Push OK button! then Grid coordinate will be updated!");
            parent.PixelSize = 17;
            parent.Size2D = new Size2D(1000, 50);
            parent.Position2D = new Position2D(100, 100);
            parent.Name = "parent view";
            parent.BackgroundColor = Color.Yellow;
            Window.Instance.Add(parent);

            myView1 = new MyView("my view1", new Size2D(500, 100), parent, 20);
            myView1.MyPosition = new Position2D(100, 100);

            myView2 = new MyView("my view2", new Size2D(500, 100), myView1.myView, 20);
            myView2.MyPosition = new Position2D(100, 100);

            myView3 = new MyView("my view3", new Size2D(500, 100), myView2.myView, 20);
            myView3.MyPosition = new Position2D(100, 100);

            timer = new Timer(300);
            timer.Tick += Timer_Tick;
            timer.Start();

            ani = new Animation();
            ani.AnimateTo(myView1.myView, "Position", new Position(1000, 100, 0), 1000, 50000);
            ani.AnimateTo(myView2.myView, "Position", new Position(100, 1000, 0), 1000, 50000);
            ani.AnimateTo(myView3.myView, "Position", new Position(-800, 100, 0), 1000, 50000);
            ani.EndAction = Animation.EndActions.Discard;
            ani.Looping = true;
            ani.Play();
        }
        private bool Timer_Tick(object source, Timer.TickEventArgs e)
        {
            myView1.UpdateMe();
            myView2.UpdateMe();
            myView3.UpdateMe();
            return true;
        }

        public class MyGrid
        {
            public TextLabel textLabel;
            public View myGrid;
            public MyGrid(Position2D myPosition, Size2D mySize, View parent, int textSize)
            {
                myGrid = new View();
                myGrid.Position2D = myPosition;
                myGrid.Size2D = mySize;
                Random rand = new Random();
                float col = rand.Next(1, 255) / 255.0f;
                myGrid.BackgroundColor = new Color(col, 1 - col, col, 1.0f);

                textLabel = new TextLabel($"({myGrid.ScreenPosition?.X},{myGrid.ScreenPosition?.Y})");
                textLabel.PixelSize = textSize;
                textLabel.Position2D = new Position2D(10, 10);
                textLabel.Size2D = new Size2D(100, 100);
                myGrid.Add(textLabel);

                if (parent == null)
                {
                    Window.Instance.Add(myGrid);
                }
                else
                {
                    parent.Add(myGrid);
                }
            }
            public void UpdateMe()
            {
                textLabel.Text = $"({ myGrid.ScreenPosition.X},{ myGrid.ScreenPosition.Y})";
            }
        }

        MyGrid[] gridVertical = new MyGrid[20];
        MyGrid[] gridHorizontal = new MyGrid[11];
        void DrawGrid()
        {
            gridVertical[0] = new MyGrid(new Position2D(0, 0), new Size2D(2, 1100), null, 10);
            for (int i = 1; i < 20; i++)
            {
                gridVertical[i] = new MyGrid(new Position2D(100, 0), new Size2D(2, 1100), gridVertical[i - 1].myGrid, 10);
            }

            gridHorizontal[0] = new MyGrid(new Position2D(0, 0), new Size2D(2000, 2), null, 10);
            for (int i = 1; i < 11; i++)
            {
                gridHorizontal[i] = new MyGrid(new Position2D(0, 100), new Size2D(2000, 2), gridHorizontal[i - 1].myGrid, 10);
            }
        }

        TextLabel title;
        public void StartTest()
        {
            Window window = Window.Instance;
            window.BackgroundColor = Color.White;
            window.KeyEvent += OnWindowKeyEvent;

            title = new TextLabel("ScreenPosition Test");
            title.Position2D = new Position2D(10, 10);
            title.PixelSize = 40.0f;
            window.Add(title);

            DrawGrid();
            ScreenPositionTest();
        }

        public void OnWindowKeyEvent(object sender, Window.KeyEventArgs e)
        {
            Tizen.Log.Fatal("NUI", "e.Key.KeyPressedName=" + e.Key.KeyPressedName);

            if (e.Key.State == Key.StateType.Down)
            {
                if (e.Key.KeyPressedName == "Up")
                {
                }
                else if (e.Key.KeyPressedName == "Down")
                {
                }
                else if (e.Key.KeyPressedName == "Return")
                {
                    for (int i = 0; i < 20; i++)
                    {
                        gridVertical[i].UpdateMe();
                    }
                    for (int i = 0; i < 11; i++)
                    {
                        gridHorizontal[i].UpdateMe();
                    }
                }
                else if (e.Key.KeyPressedName == "XF86Exit" || e.Key.KeyPressedName == "XF86Back")
                {
                    Exit();
                }
            }
        }
    }
}