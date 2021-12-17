
using Tizen.NUI;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;

namespace NUIDnDSource
{
    class Program : NUIApplication
    {
        ImageView sourceView;
        ImageView shadowView;
        ImageView targetViewA;
        ImageView targetViewB;
        DragAndDrop dnd;
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
            Window.Instance.TouchEvent += OnTouchEvent;

            TextLabel text = new TextLabel("DragSource Application");
            text.Position = new Position(0, 0);
            text.TextColor = Color.Black;
            text.PointSize = 10.0f;
            Window.Instance.GetDefaultLayer().Add(text);

            TextLabel text2 = new TextLabel("This sample demonstrates NUI DnD functionality and is the 'source' app for this sample.");
            text2.Position = new Position(0, 70);
            text2.Size = new Size(900, 150);
            text2.TextColor = Color.Black;
            text2.PointSize = 7.0f;
            text2.MultiLine = true;
            Window.Instance.GetDefaultLayer().Add(text2);

            // Create Source View
            sourceView = new ImageView(Tizen.Applications.Application.Current.DirectoryInfo.Resource + "dragsource.png");
            sourceView.Size = new Size(250, 250);
            sourceView.Position = new Position(300, 230);
            Window.Instance.GetDefaultLayer().Add(sourceView);

            TextLabel text3 = new TextLabel("This image can be dragged, Try dragging it to the area below.");
            text3.Position = new Position(0, 520);
            text3.Size = new Size(900, 150);
            text3.TextColor = Color.Black;
            text3.PointSize = 7.0f;
            text3.MultiLine = true;
            Window.Instance.GetDefaultLayer().Add(text3);
            
            TextLabel text4 = new TextLabel("Drop your image here");
            text4.Position = new Position(300, 940);
            text4.TextColor = Color.Black;
            text4.PointSize = 7.0f;
            Window.Instance.GetDefaultLayer().Add(text4);

            // Create Target View A
            targetViewA = new ImageView(Tizen.Applications.Application.Current.DirectoryInfo.Resource + "droptarget.png");
            targetViewA.Size = new Size(250, 250);
            targetViewA.Position = new Position(135, 650);
            Window.Instance.GetDefaultLayer().Add(targetViewA);

            // Add Drop Target A
            dnd.AddListener(targetViewA, OnSourceAppDnDFuncA);

            // Create Target View B
            targetViewB = new ImageView(Tizen.Applications.Application.Current.DirectoryInfo.Resource + "droptarget.png");
            targetViewB.Size = new Size(250, 250);
            targetViewB.Position = new Position(485, 650);
            Window.Instance.GetDefaultLayer().Add(targetViewB);

            // Add Drop Target B
            dnd.AddListener(targetViewB, OnSourceAppDnDFuncB);
        }

        public void OnSourceAppDnDFuncA(View targetView, DragEvent dragEvent)
        {
            if (dragEvent.DragType == DragType.Enter)
            {
              Tizen.Log.Debug("NUIDnDSource", "Source App Target A [Enter]");
            }
            else if (dragEvent.DragType == DragType.Leave)
            {
              Tizen.Log.Debug("NUIDnDSource", "Source App Target A [Leave]");
            }
            else if (dragEvent.DragType == DragType.Move)
            {
              Tizen.Log.Debug("NUIDnDSource", "Source App Target A [Move]: " + dragEvent.Position.X + " " + dragEvent.Position.Y);
            }
            else if (dragEvent.DragType == DragType.Drop)
            {
              Tizen.Log.Debug("NUIDnDSource", "Source App Target A [Drop] MimeType: " + dragEvent.MimeType + " Data: " + dragEvent.Data);
              targetViewA.ResourceUrl = dragEvent.Data;
            }
        }

        public void OnSourceAppDnDFuncB(View targetView, DragEvent dragEvent)
        {
            if (dragEvent.DragType == DragType.Enter)
            {
              Tizen.Log.Debug("NUIDnDSource", "Source App Target B [Enter]");
            }
            else if (dragEvent.DragType == DragType.Leave)
            {
              Tizen.Log.Debug("NUIDnDSource", "Source App Target B [Leave]");
            }
            else if (dragEvent.DragType == DragType.Move)
            {
              Tizen.Log.Debug("NUIDnDSource", "Source App Target B [Move]: " + dragEvent.Position.X + " " + dragEvent.Position.Y);
            }
            else if (dragEvent.DragType == DragType.Drop)
            {
              Tizen.Log.Debug("NUIDnDSource", "Source App Target B [Drop] MimeType: " + dragEvent.MimeType + " Data: " + dragEvent.Data);
              targetViewB.ResourceUrl = dragEvent.Data;
            }
        }

        public void OnKeyEvent(object sender, Window.KeyEventArgs e)
        {
            if (e.Key.State == Key.StateType.Down && (e.Key.KeyPressedName == "XF86Back" || e.Key.KeyPressedName == "Escape"))
            {
                Exit();
            }
        }

        private void OnTouchEvent(object source, Window.TouchEventArgs e)
        {
            if (e.Touch.GetState(0) == PointStateType.Down)
            {
                Tizen.Log.Debug("NUIDnDSource", "StartDragAndDrop");
                shadowView = new ImageView(Tizen.Applications.Application.Current.DirectoryInfo.SharedResource + "dragsource.png");
                DragData dragData;
                dragData.MimeType = "text/uri-list";
                dragData.Data = Tizen.Applications.Application.Current.DirectoryInfo.SharedResource + "dragsource.png";
                dnd.StartDragAndDrop(sourceView, shadowView, dragData);
            }
        }

        static void Main(string[] args)
        {
            var app = new Program();
            app.Run(args);
        }
    }
}
