using System;
using Tizen.NUI;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;

namespace WhiteboardEmail
{
    class Program : NUIApplication
    {
        View windowMainView;
        ImageView emailView;
        TextEditor inputContent;
        DragAndDrop dnd;
    
        float fontScale = 1.5f;
        protected override void OnCreate()
        {
            base.OnCreate();
            Initialize();
        }

        void Initialize()
        {
            // Create DnD Instance
            dnd = DragAndDrop.Instance;

            //fopu

            Window.Instance.KeyEvent += OnKeyEvent;
            Window.Instance.WindowPosition = new Position(900, 400); 
            Window.Instance.WindowSize = new Size(400, 400); 
            Window.Instance.BackgroundColor = Color.White;

            windowMainView = new View()
            {
               Layout = new LinearLayout()
               {
                  LinearOrientation = LinearLayout.Orientation.Vertical,
               },
               WidthSpecification = LayoutParamPolicies.MatchParent,
               HeightSpecification = LayoutParamPolicies.MatchParent,
               BackgroundColor = Color.White,
               CornerRadius = new Vector4(0.03f, 0.03f, 0.03f, 0.03f),
               CornerRadiusPolicy = VisualTransformPolicyType.Relative,
               ClippingMode = ClippingModeType.ClipToBoundingBox,
            };

            var title = new TextLabel() {
               Text = "E-mail",
               PointSize = 4 * fontScale,
               HorizontalAlignment = HorizontalAlignment.Center,
               Padding = new Extents(35,0,20,0),
            };

            Window.Instance.GetDefaultLayer().Add(windowMainView);
            windowMainView.Add(title);

            var labelSender = new TextLabel() {
            Text = "sender : taehyub.kim@samsung.com",
            PointSize = 3 * fontScale,
            HorizontalAlignment = HorizontalAlignment.Begin,
            Padding = new Extents(10,0,10,0),
            };

            windowMainView.Add(labelSender);

            var labelReceiver = new TextLabel() {
                Text = "receiver : hyunju.shin@samsung.com",
                PointSize = 3 * fontScale,
                HorizontalAlignment = HorizontalAlignment.Begin,
                Padding = new Extents(10,0,10,0),
            };
            windowMainView.Add(labelReceiver);

            var labelTitle = new TextLabel() {
                Text = "title : DnD and Window Border!",
                PointSize = 3 * fontScale,
                HorizontalAlignment = HorizontalAlignment.Begin,
                Padding = new Extents(10,0,10,0),
            };
            windowMainView.Add(labelTitle);

            var menuView = new View()
            {
              Layout = new LinearLayout()
              {
                LinearOrientation = LinearLayout.Orientation.Horizontal,
                HorizontalAlignment = HorizontalAlignment.End,
                VerticalAlignment = VerticalAlignment.Center,
              },
              WidthSpecification = LayoutParamPolicies.MatchParent,
              HeightSpecification = 40,
            };
            var menuImage = new ImageView()
            {
              ResourceUrl = Tizen.Applications.Application.Current.DirectoryInfo.SharedResource + "addimage.png",
              WidthSpecification = 30,
              HeightSpecification = 30,
              Margin = new Extents(0,10,0,0),
            };
            var menuFile = new ImageView()
            {
              ResourceUrl = Tizen.Applications.Application.Current.DirectoryInfo.SharedResource + "file.png",
              WidthSpecification = 30,
              HeightSpecification = 30,
              Margin = new Extents(0,10,0,0),
            };
            var menuOption = new ImageView()
            {
              ResourceUrl = Tizen.Applications.Application.Current.DirectoryInfo.SharedResource + "send.png",
              WidthSpecification = 30,
              HeightSpecification = 30,
              Margin = new Extents(0,10,0,0),
            };

            menuView.Add(menuImage);
            menuView.Add(menuFile);
            menuView.Add(menuOption);
            windowMainView.Add(menuView);

            inputContent = new TextEditor()
            {
              WidthSpecification = LayoutParamPolicies.MatchParent,
              HeightSpecification = 150,
              BackgroundColor = new Color(1.0f, 0.9f, 0.8f, 0.3f),
              PointSize = 3 * fontScale,
              BorderlineWidth = 2.0f,
              BorderlineColor = new Color(1.0f, 0.4f, 0.0f, 1.0f),
              CornerRadius = new Vector4(0.1f, 0.1f, 0.1f, 0.1f),
              CornerRadiusPolicy = VisualTransformPolicyType.Relative,
              Margin = 10,
              LineWrapMode = LineWrapMode.Mixed,
            };
            windowMainView.Add(inputContent); 

            // Add Drop Target A
            dnd.AddListener(windowMainView, OnTargetAppDnDFuncA);
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
              inputContent.Text = dragEvent.Data;
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
