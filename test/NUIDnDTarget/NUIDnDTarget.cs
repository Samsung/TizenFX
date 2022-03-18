using System;
using Tizen.NUI;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;

namespace NUIDnDTarget
{
    class Program : NUIApplication
    {
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
            Window.Instance.WindowPosition = new Position(1020, 0); 
            Window.Instance.WindowSize = new Size(900, 1080); 
            Window.Instance.BackgroundColor = Color.White;

            TextLabel text = new TextLabel("DropTarget Application");
            text.Position = new Position(0, 0);
            text.TextColor = Color.Black;
            text.PointSize = 10.0f;
            Window.Instance.GetDefaultLayer().Add(text);

            TextLabel text2 = new TextLabel("This sample demonstrates NUI DnD functionality and is the 'target' app for this sample.");
            text2.Position = new Position(0, 70);
            text2.TextColor = Color.Black;
            text2.PointSize = 7.0f;
            text2.MultiLine = true;
            Window.Instance.GetDefaultLayer().Add(text2);

            // Create Target View A
            targetViewA = new ImageView(Tizen.Applications.Application.Current.DirectoryInfo.Resource + "droptarget.png");
            targetViewA.Size = new Size(300, 300);
            targetViewA.Position = new Position(100, 235);
            Window.Instance.GetDefaultLayer().Add(targetViewA);

            // Add Drop Target A
            dnd.AddListener(targetViewA, OnTargetAppDnDFuncA);

            // Create Target View B
            targetViewB = new ImageView(Tizen.Applications.Application.Current.DirectoryInfo.Resource + "droptarget.png");
            targetViewB.Size = new Size(300, 300);
            targetViewB.Position = new Position(100, 585);
            Window.Instance.GetDefaultLayer().Add(targetViewB);

            // Add Drop Target B
            dnd.AddListener(targetViewB, OnTargetAppDnDFuncB);

            TextLabel text3 = new TextLabel("Drop your image here.");
            text3.Position = new Position(500, 355);
            text3.TextColor = Color.Black;
            text3.PointSize = 7.0f;
            Window.Instance.GetDefaultLayer().Add(text3);
        }

        public void OnTargetAppDnDFuncA(View targetView, DragEvent dragEvent)
        {
            if (dragEvent.DragType == DragType.Enter)
            {
              Tizen.Log.Error("NUIDnDTarget", "Target App Target A [Enter]");
            }
            else if (dragEvent.DragType == DragType.Leave)
            {
              Tizen.Log.Error("NUIDnDTarget", "Target App Target A [Leave]");
            }
            else if (dragEvent.DragType == DragType.Move)
            {
              Tizen.Log.Error("NUIDnDTarget", "Target App Target A [Move]: " + dragEvent.Position.X + " " + dragEvent.Position.Y);
            }
            else if (dragEvent.DragType == DragType.Drop)
            {
              Tizen.Log.Error("NUIDnDTarget", "Target App Target A [Drop] MimeType: " +  dragEvent.MimeType + " Data: " + dragEvent.Data);
              targetViewA.ResourceUrl = dragEvent.Data;
            }
        }

        public void OnTargetAppDnDFuncB(View targetView, DragEvent dragEvent)
        {
            if (dragEvent.DragType == DragType.Enter)
            {
              Tizen.Log.Error("NUIDnDTarget", "Target App Target B [Enter]");
            }
            else if (dragEvent.DragType == DragType.Leave)
            {
              Tizen.Log.Error("NUIDnDTarget", "Target App Target B [Leave]");
            }
            else if (dragEvent.DragType == DragType.Move)
            {
              Tizen.Log.Error("NUIDnDTarget", "Target App Target B [Move]: " + dragEvent.Position.X + " " + dragEvent.Position.Y);
            }
            else if (dragEvent.DragType == DragType.Drop)
            {
              Tizen.Log.Error("NUIDnDTarget", "Target App Target B [Drop] MimeType: " +  dragEvent.MimeType + " Data: " + dragEvent.Data);
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

        static void Main(string[] args)
        {
            var app = new Program();
            app.Run(args);
        }
    }
}
