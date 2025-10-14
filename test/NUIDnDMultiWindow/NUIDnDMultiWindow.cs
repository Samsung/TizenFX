
using Tizen.NUI;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;
using System.Collections.Generic;

namespace NUIDnDMultiWindow
{
    class Program : NUIApplication
    {
        DragAndDrop dnd;
        ImageView sourceView;
        ImageView shadowView;
        ImageView MainWindow_View;

        Window WindowA;
        ImageView WindowA_ViewA;
        ImageView WindowA_ViewB;

        Window WindowB;
        ImageView WindowB_ViewA;
        ImageView WindowB_ViewB;

        LongPressGestureDetector longPressed;
        protected override void OnCreate()
        {
            base.OnCreate();
            Initialize();
        }

        void Initialize()
        {
            // Create DnD Instance
            dnd = DragAndDrop.Instance;

            Window.Instance.KeyEvent += OnKeyEvent;
            Window.Instance.WindowSize = new Size(900, 1080);
            Window.Instance.BackgroundColor = Color.White;

            List<Window.WindowOrientation> list = new List<Window.WindowOrientation>();
            list.Add(Window.WindowOrientation.Landscape);
            list.Add(Window.WindowOrientation.LandscapeInverse);
            list.Add(Window.WindowOrientation.NoOrientationPreference);
            list.Add(Window.WindowOrientation.Portrait);
            list.Add(Window.WindowOrientation.PortraitInverse);

            Window.Instance.SetAvailableOrientations(list);

            TextLabel text = new TextLabel("Multi-Window Drag And Drop");
            text.Position = new Position(0, 0);
            text.TextColor = Color.Black;
            text.PointSize = 8.0f;
            Window.Instance.GetDefaultLayer().Add(text);

            TextLabel text2 = new TextLabel("Source View");
            text2.Position = new Position(330, 330);
            text2.Size = new Size(400, 150);
            text2.TextColor = Color.Black;
            text2.PointSize = 5.0f;
            text2.MultiLine = true;
            Window.Instance.GetDefaultLayer().Add(text2);

            TextLabel text3 = new TextLabel("MainWindow View");
            text3.Position = new Position(100, 700);
            text3.Size = new Size(400, 150);
            text3.TextColor = Color.Black;
            text3.PointSize = 5.0f;
            text3.MultiLine = true;
            Window.Instance.GetDefaultLayer().Add(text3);

            TextLabel text4 = new TextLabel("Window A");
            text4.Position = new Position(400, 650);
            text4.Size = new Size(400, 150);
            text4.TextColor = Color.Black;
            text4.PointSize = 5.0f;
            text4.MultiLine = true;
            Window.Instance.GetDefaultLayer().Add(text4);

            TextLabel text5 = new TextLabel("Window B");
            text5.Position = new Position(400, 1000);
            text5.Size = new Size(400, 150);
            text5.TextColor = Color.Black;
            text5.PointSize = 5.0f;
            text5.MultiLine = true;
            Window.Instance.GetDefaultLayer().Add(text5);

            // Create Source View
            sourceView = new ImageView(Tizen.Applications.Application.Current.DirectoryInfo.Resource + "dragsource.png");
            sourceView.Size = new Size(200, 200);
            sourceView.Position = new Position(330, 120);
            Window.Instance.GetDefaultLayer().Add(sourceView);

            longPressed = new LongPressGestureDetector();
            longPressed.Attach(sourceView);
            longPressed.Detected += (s, e) =>
            {
              if(e.LongPressGesture.State == Gesture.StateType.Started)
              {
                Tizen.Log.Debug("NUIDnDMultiWindow", "StartDragAndDrop");
                shadowView = new ImageView(Tizen.Applications.Application.Current.DirectoryInfo.SharedResource + "dragsource.png");
                shadowView.Size = new Size(150, 150);
                DragData dragData = new DragData();
                dragData.MimeType = "text/uri-list";
                dragData.Data = Tizen.Applications.Application.Current.DirectoryInfo.SharedResource + "dragsource.png";
                dnd.StartDragAndDrop(sourceView, shadowView, dragData, OnSourceApp_SourceFunc);
              }
            };

            // Create Target MainWindow_View
            MainWindow_View = new ImageView(Tizen.Applications.Application.Current.DirectoryInfo.Resource + "droptarget.png");
            MainWindow_View.Size = new Size(200, 200);
            MainWindow_View.Position = new Position(100, 500);
            Window.Instance.GetDefaultLayer().Add(MainWindow_View);

            // Add Drop Target MainWindow_View
            dnd.AddListener(MainWindow_View, OnSourceApp_TargetFunc);

            // Create Target Window A
            WindowA = new Window("WindowA", new Rectangle(400, 400, 370, 250), false)
            {
                BackgroundColor = Color.BlueViolet,
            };
            WindowA.Show();

            // Create Target WindowA_ViewA
            WindowA_ViewA = new ImageView(Tizen.Applications.Application.Current.DirectoryInfo.Resource + "droptarget.png");
            WindowA_ViewA.Size = new Size(150, 150);
            WindowA_ViewA.Position = new Position(20, 10);
            WindowA.GetDefaultLayer().Add(WindowA_ViewA);

            // Add Drop Target WindowA_ViewA
            dnd.AddListener(WindowA_ViewA, OnSourceApp_TargetFunc);

            // Create Target View WindowA_ViewB
            WindowA_ViewB = new ImageView(Tizen.Applications.Application.Current.DirectoryInfo.Resource + "droptarget.png");
            WindowA_ViewB.Size = new Size(150, 150);
            WindowA_ViewB.Position = new Position(180, 50);
            WindowA.GetDefaultLayer().Add(WindowA_ViewB);

            // Add Drop Target WindowA_ViewB
            dnd.AddListener(WindowA_ViewB, OnSourceApp_TargetFunc);

            // Create Target Window B
            WindowB = new Window("WindowB", new Rectangle(400, 750, 370, 250), false)
            {
                BackgroundColor = Color.LightGoldenRodYellow,
            };
            WindowB.Show();

            // Create Target WindowB_ViewA
            WindowB_ViewA = new ImageView(Tizen.Applications.Application.Current.DirectoryInfo.Resource + "droptarget.png");
            WindowB_ViewA.Size = new Size(150, 150);
            WindowB_ViewA.Position = new Position(20, 10);
            WindowB.GetDefaultLayer().Add(WindowB_ViewA);

            // Add Drop Target WindowB_ViewA
            dnd.AddListener(WindowB_ViewA, OnSourceApp_TargetFunc);

            // Create Target WindowB_ViewB
            WindowB_ViewB = new ImageView(Tizen.Applications.Application.Current.DirectoryInfo.Resource + "droptarget.png");
            WindowB_ViewB.Size = new Size(150, 150);
            WindowB_ViewB.Position = new Position(180, 50);
            WindowB.GetDefaultLayer().Add(WindowB_ViewB);

            // Add Drop Target WindowB_ViewB
            dnd.AddListener(WindowB_ViewB, OnSourceApp_TargetFunc);
        }

        public void OnSourceApp_SourceFunc(DragSourceEventType type)
        {
          if (type == DragSourceEventType.Start)
          {
            Tizen.Log.Debug("NUIDnDMultiWindow", "Source App DragSourceEventType: " + "Start");
          }
          else if (type == DragSourceEventType.Cancel)
          {
            Tizen.Log.Debug("NUIDnDMultiWindow", "Source App DragSourceEventType: " + "Cancel");
          }
          else if (type == DragSourceEventType.Accept)
          {
            Tizen.Log.Debug("NUIDnDMultiWindow", "Source App DragSourceEventType: " + "Accept");
          }
          else if (type == DragSourceEventType.Finish)
          {
            Tizen.Log.Debug("NUIDnDMultiWindow", "Source App DragSourceEventType: " + "Finish");
          }
        }

        public void OnSourceApp_TargetFunc(View targetView, DragEvent dragEvent)
        {
            if (dragEvent.DragType == DragType.Enter)
            {
              Tizen.Log.Debug("NUIDnDMultiWindow", "Source App Target A [Enter]");
            }
            else if (dragEvent.DragType == DragType.Leave)
            {
              Tizen.Log.Debug("NUIDnDMultiWindow", "Source App Target A [Leave]");
            }
            else if (dragEvent.DragType == DragType.Move)
            {
              Tizen.Log.Debug("NUIDnDMultiWindow", "Source App Target A [Move]: " + dragEvent.Position.X + " " + dragEvent.Position.Y);
            }
            else if (dragEvent.DragType == DragType.Drop)
            {
              Tizen.Log.Debug("NUIDnDMultiWindow", "Source App Target A [Drop] MimeType: " + dragEvent.MimeType + " Data: " + dragEvent.Data);
              ((ImageView)targetView).ResourceUrl = dragEvent.Data;
            }
        }

        public void OnKeyEvent(object sender, Window.KeyEventArgs e)
        {
            if (e.Key.State == Key.StateType.Down && (e.Key.KeyPressedName == "XF86Back" || e.Key.KeyPressedName == "Escape"))
            {
                Exit();
            }
        }

        static void Main(string[] args)
        {
            var app = new Program();
            app.Run(args);
        }
    }
}
