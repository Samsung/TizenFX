
using System;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;
using System.Collections;

namespace Tizen.NUI.Samples
{

  public struct WindowPosInfo: IComparable
  { 
    public int id; 
    public double magnitude;
    public int type;
    public WindowPosInfo(int _id, double _magnitude, int _type)
    {
      id = _id;
      magnitude = _magnitude;
      type = _type;
    }
    public int CompareTo(Object Item)
    {
        WindowPosInfo item = (WindowPosInfo) Item;

        if (this.magnitude < item.magnitude)
            return -1;
         if (this.magnitude > item.magnitude)
            return 1;
         return 0;
    }
  }
  public class WhiteboardDnDTest : IExample
  {
    // MainWindow
    private Window win;

    // <Swipe Gesture Recognition>
    private Timer swipeTimer;
    private float preSwipeDx = 0;
    private float preSwipeDy = 0;
    private float swipeDx = 0;
    private float swipeDy = 0;
    private bool bSwipeStart = false;
    private int swipeCount = 0;
    private int swipeMoveCount = 0;
    private int swipeThreashold = 3;
    private int swipeMoveThreashold = 3;    
    private float swipeEndX = 0;
    private float swipeEndY = 0;
    private double vecLength = 0;
    private int header = 0;
    private int preHeader = 0;
    private int hilightItemIndex = -1;
    private int hilightItemType = -1;
    private int groupSize = 0;
    // </Swipe Gesture Recognition>

    //Launch Whiteboard
    int currentItemId = -1;
    bool currentItemIdPressed = false;
    //
    
    // DemoApp Window and Position
    private Window trayWindow = null;
    private Window [] SubWindows = new Window[5];
    private Rectangle allAppsWinPosition = new Rectangle(300, 207, 450, 500);
    private Rectangle myAppsWinPosition = new Rectangle(1000, 250, 450, 350);
    private Rectangle trayWinPosition = new Rectangle(300, 200, 400, 400);
    private Rectangle galleryWinPosition = new Rectangle(1100, 350, 400, 400);
    private Rectangle emailWinPosition = new Rectangle(1200, 550, 400, 400);
    private Rectangle facebookWinPosition = new Rectangle(350, 250, 400, 400);
    //    

    // DragAndDrop
    DragAndDrop dnd;
    private View shadowView = null;
    //

    // MyApps App View
    private View myAppsView = null;
    private View faceBookItem = null;
    // Gallery App View
    private ImageView galleryView = null;
    
    // TrayItem App View    
    private ImageView [] trayItem = new ImageView[5];

    // AllApps Item Longpressed Event
    private LongPressGestureDetector [] itemLongPressed = new LongPressGestureDetector[10];

    // Email App TextField
    private TextEditor inputContent = null;
    // Email Apps Item LongPressed Event
    private LongPressGestureDetector textLongPressed = null;
    private LongPressGestureDetector itemLongPressed1 = null;
    private LongPressGestureDetector itemLongPressed2 = null;    
    //

    // AllApps and MyApps Item Image Resources
    private string [] itemNameArr = new string [] {
                               "facebook", "netflix", "spoti",
                               "chrome", "instagram", "pinterest",
                               "hbo", "linkedin", "youtube"};

    //for TV font scale
    private float fontScale = 5;
    //for Emulator font scale
    //private float fontScale = 1.5f;

    // <Angling UI Logic>
    private ArrayList windowArray = new ArrayList();
    private View originPoint = null;
    private double originPointX = 400;
    private double originPointY = 505;
    private View mousePoint = null;

    // Circle Center Position
    private double [] circlePositionX = new double[5]{1800, 1800, 1800, 1800, 1800};
    private double [] circlePositionY = new double[5]{150, 360, 540, 720, 930};
    //private double [] circleSize = new double[5]{, 420,  630, 840, 1050};
    
    // Tray Items
    private View [] TrayPoint = new View[5];
    private float [] trayPointSize = new float[5]{240.0f, 180.0f, 180.0f, 180.0f, 240.0f};
    private double [] circleRadius = new double[5]{120.0f, 90.0f, 90.0f, 90.0f, 120.0f};

     // Window Center Position
    private View [] windowPoint = new View[5];
    private View [] windowMainView = new View[5];
    private double [] windowCenterX = new double[5]{-500, -500, -500, -500, -500};
    private double [] windowCenterY = new double[5]{-500, -500, -500, -500, -500};
    private double windowRadius = 250.0f;
    private float windowCenterOffsetY = 30;
    private bool enableTrayCircle = false;
    // </Angling UI Logic>

    View CreateItem(string file, string name)
    {
      var itemView = new View()
      {
        WidthSpecification = 150,
        HeightSpecification = 150,
        BackgroundImage = Tizen.Applications.Application.Current.DirectoryInfo.SharedResource + "frame.png",
        Layout = new LinearLayout()
        {
          LinearOrientation = LinearLayout.Orientation.Vertical,
          HorizontalAlignment = HorizontalAlignment.Center,
          VerticalAlignment = VerticalAlignment.Center,
        },
      };
      itemView.TouchEvent += (s, e) =>
      {
        if (e.Touch.GetState(0) == PointStateType.Up)
        {
          itemView.BackgroundImage = Tizen.Applications.Application.Current.DirectoryInfo.SharedResource + "frame.png";
        }
        else if (e.Touch.GetState(0) == PointStateType.Down)
        {
          itemView.BackgroundImage = Tizen.Applications.Application.Current.DirectoryInfo.SharedResource + "framep.png";
        }
        return true;
      };

      var child = new ImageView() {
        WidthSpecification = 120,
        HeightSpecification = 100,
        ResourceUrl = file,
        Margin = 2,
      };

      var itemName = new TextLabel() {
        Text = name,
        PointSize = 3 * fontScale,
        HorizontalAlignment = HorizontalAlignment.Center,
        Margin =  new Extents(0, 5, 0, 0),
      };

      itemView.Add(child);
      itemView.Add(itemName);

      GridLayout.SetHorizontalStretch(itemView, GridLayout.StretchFlags.Expand);
      GridLayout.SetVerticalStretch(itemView, GridLayout.StretchFlags.Expand);
      GridLayout.SetHorizontalAlignment(itemView, GridLayout.Alignment.Center);
      GridLayout.SetVerticalAlignment(itemView, GridLayout.Alignment.Center);

      return itemView;
    }

    void CreateGallery()
    {
      if (SubWindows[2])
      { 
        SubWindows[2].Destroy();
        SubWindows[2] = null;
      }

      if (SubWindows[2] == null)
      {
        SubWindows[2] = new Window("GalleryWindow", galleryWinPosition, false);
        SubWindows[2].EnableBorderWindow();

        windowMainView[2] = new View()
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
            Text = "Gallery",
            PointSize = 4 * fontScale,
            HorizontalAlignment = HorizontalAlignment.Center,
            Padding = new Extents(35,0,20,0),
        };

        var view = new View()
        {
          Layout = new GridLayout()
          {
            Columns = 1,
            Rows = 1,
          },
          WidthSpecification = LayoutParamPolicies.MatchParent,
          HeightSpecification = LayoutParamPolicies.MatchParent,
        };

        SubWindows[2].Add(windowMainView[2]);
        windowMainView[2].Add(title);
        windowMainView[2].Add(view);

        galleryView = new ImageView()
        {
          WidthSpecification = LayoutParamPolicies.MatchParent,
          HeightSpecification = LayoutParamPolicies.MatchParent,
          ResourceUrl = Tizen.Applications.Application.Current.DirectoryInfo.SharedResource + "maldives.png",
          CornerRadius = new Vector4(0.03f, 0.03f, 0.03f, 0.03f),
          CornerRadiusPolicy = VisualTransformPolicyType.Relative,
          Margin = 15,
          FittingMode = FittingModeType.ShrinkToFit,
        };
        view.Add(galleryView);
      }
      else
      {
        SubWindows[2].Minimize(false);
      }
    }

    void CreateEmail()
    {
      if (SubWindows[3])
      { 
        SubWindows[3].Destroy();
        SubWindows[3] = null;
      }

      if (SubWindows[3] == null)
      {
        SubWindows[3] = new Window("EmailWindow", emailWinPosition, false);
        SubWindows[3].EnableBorderWindow();

        windowMainView[3] = new View()
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

        windowMainView[3].ClippingMode = ClippingModeType.ClipToBoundingBox;
        SubWindows[3].Add(windowMainView[3]);
        windowMainView[3].Add(title);

        var labelSender = new TextLabel() {
            Text = "sender : taehyub.kim@samsung.com",
            PointSize = 3 * fontScale,
            HorizontalAlignment = HorizontalAlignment.Begin,
            Padding = new Extents(10,0,10,0),
        };
        windowMainView[3].Add(labelSender);

        var labelReceiver = new TextLabel() {
            Text = "receiver : hyunju.shin@samsung.com",
            PointSize = 3 * fontScale,
            HorizontalAlignment = HorizontalAlignment.Begin,
            Padding = new Extents(10,0,10,0),
        };
        windowMainView[3].Add(labelReceiver);

        var labelTitle = new TextLabel() {
            Text = "title : DnD and Window Border!",
            PointSize = 3 * fontScale,
            HorizontalAlignment = HorizontalAlignment.Begin,
            Padding = new Extents(10,0,10,0),
        };
        windowMainView[3].Add(labelTitle);

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
        windowMainView[3].Add(menuView);

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
        windowMainView[3].Add(inputContent); 
      }
    }
    void CreateFacebook()
    {
      if (SubWindows[4])
      { 
        SubWindows[4].Destroy();
        SubWindows[4] = null;
      }

      if (SubWindows[4] == null)
      {
        SubWindows[4] = new Window("FacebookWindow", facebookWinPosition, false);
        SubWindows[4].EnableBorderWindow();

        windowMainView[4] = new View()
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
            Text = "Facebook",
            PointSize = 4 * fontScale,
            HorizontalAlignment = HorizontalAlignment.Center,
            Padding = new Extents(35,0,20,0),
        };

        SubWindows[4].Add(windowMainView[4]);
        windowMainView[4].Add(title);

        var profileView = new View()
        {
          Layout = new LinearLayout()
          {
            LinearOrientation = LinearLayout.Orientation.Horizontal,
            HorizontalAlignment = HorizontalAlignment.Begin,
            VerticalAlignment = VerticalAlignment.Bottom,
          },
          WidthSpecification = LayoutParamPolicies.MatchParent,
          HeightSpecification = 60,
        };
        windowMainView[4].Add(profileView);

        var profileImage = new ImageView()
        {
          WidthSpecification = 40,
          HeightSpecification = 40,
          ResourceUrl = Tizen.Applications.Application.Current.DirectoryInfo.SharedResource + "fbprofile.png",
          CornerRadius = new Vector4(0.5f, 0.5f, 0.5f, 0.5f),
          CornerRadiusPolicy = VisualTransformPolicyType.Relative,
          Margin = new Extents(10, 0, 0, 0),
        };
        profileView.Add(profileImage);

        var labelSender = new TextLabel() {
            Text = "profile name",
            PointSize = 3 * fontScale,
            HorizontalAlignment = HorizontalAlignment.Begin,
            Padding = new Extents(10,0,10,0),
        };
        profileView.Add(labelSender);

        var content = new TextLabel() {
            Text = "Lorem ipsum dolor sit amet, consectetur adipiscing elit.Phasellus imperdiet bibendum eros eu faucibus. Maecenas malesuada tempor felis, ac aliquam libero interdum ut.",
            PointSize = 3 * fontScale,
            Padding = new Extents(10,0,10,0),
            MultiLine = true,
            WidthSpecification = LayoutParamPolicies.MatchParent,
            HeightSpecification = LayoutParamPolicies.WrapContent,
        };
        windowMainView[4].Add(content);
        textLongPressed = new LongPressGestureDetector();
        textLongPressed.Attach(content);
        textLongPressed.Detected += (s, e) =>
        {
          if(e.LongPressGesture.State == Gesture.StateType.Started)
          {
            originPointX = e.LongPressGesture.ScreenPoint.X + SubWindows[4].WindowPosition.X;
            originPointY = e.LongPressGesture.ScreenPoint.Y + SubWindows[4].WindowPosition.Y;
            shadowView = new TextLabel()
            {
              Text = "Lorem ipsum dolor sit amet, consectetur adipiscing elit.Phasellus imperdiet bibendum eros eu faucibus. Maecenas malesuada tempor felis, ac aliquam libero interdum ut.",
              PointSize = 1 * fontScale,
              MultiLine = true,
              WidthSpecification = LayoutParamPolicies.MatchParent,
              HeightSpecification = LayoutParamPolicies.WrapContent,
            };
            DragData dragData;
            dragData.MimeType = "text/uri-list/fbtext";
            dragData.Data = "Lorem ipsum dolor sit amet, consectetur adipiscing elit.Phasellus imperdiet bibendum eros eu faucibus. Maecenas malesuada tempor felis, ac aliquam libero interdum ut.";
            dnd.StartDragAndDrop(content, shadowView, dragData);
          }
        };

        var attachImageView = new View()
        {
          Layout = new LinearLayout()
          {
            LinearOrientation = LinearLayout.Orientation.Horizontal,
            HorizontalAlignment = HorizontalAlignment.Begin,
            VerticalAlignment = VerticalAlignment.Top,
          },
          WidthSpecification = LayoutParamPolicies.MatchParent,
          HeightSpecification = LayoutParamPolicies.MatchParent,
        };
        windowMainView[4].Add(attachImageView);

        var attachImage1 = new ImageView()
        {
          WidthSpecification = LayoutParamPolicies.MatchParent,
          HeightSpecification = 100,
          ResourceUrl = Tizen.Applications.Application.Current.DirectoryInfo.SharedResource + "fbmaldives.png",
          CornerRadius = new Vector4(0.03f, 0.03f, 0.03f, 0.03f),
          CornerRadiusPolicy = VisualTransformPolicyType.Relative,
          Margin = 10,
          FittingMode = FittingModeType.ShrinkToFit,
        };
        attachImageView.Add(attachImage1);
        var attachImage2 = new ImageView()
        {
          WidthSpecification = LayoutParamPolicies.MatchParent,
          HeightSpecification = 100,
          ResourceUrl = Tizen.Applications.Application.Current.DirectoryInfo.SharedResource + "fbfood.png",
          CornerRadius = new Vector4(0.03f, 0.03f, 0.03f, 0.03f),
          CornerRadiusPolicy = VisualTransformPolicyType.Relative,
          Margin = 10,
          FittingMode = FittingModeType.ShrinkToFit,
        };
        attachImageView.Add(attachImage2);

        itemLongPressed1 = new LongPressGestureDetector();
        itemLongPressed1.Attach(attachImage1);
        itemLongPressed1.Detected += (s, e) =>
        {
          if(e.LongPressGesture.State == Gesture.StateType.Started)
          {
            originPointX = e.LongPressGesture.ScreenPoint.X + SubWindows[4].WindowPosition.X;
            originPointY = e.LongPressGesture.ScreenPoint.Y + SubWindows[4].WindowPosition.Y;            
            shadowView = new ImageView()
            {
              ResourceUrl = Tizen.Applications.Application.Current.DirectoryInfo.SharedResource + "fbmaldives.png",
              FittingMode = FittingModeType.ShrinkToFit,
              CornerRadius = new Vector4(0.03f, 0.03f, 0.03f, 0.03f),
              CornerRadiusPolicy = VisualTransformPolicyType.Relative,
            };
            DragData dragData;
            dragData.MimeType = "text/uri-list/fbimage";
            dragData.Data = Tizen.Applications.Application.Current.DirectoryInfo.SharedResource + "fbmaldives.png";
            dnd.StartDragAndDrop(attachImage1, shadowView, dragData);
          }
        };

        itemLongPressed2 = new LongPressGestureDetector();
        itemLongPressed2.Attach(attachImage2);
        itemLongPressed2.Detected += (s, e) =>
        {
          if(e.LongPressGesture.State == Gesture.StateType.Started)
          {
            originPointX = e.LongPressGesture.ScreenPoint.X + SubWindows[4].WindowPosition.X;
            originPointY = e.LongPressGesture.ScreenPoint.Y + SubWindows[4].WindowPosition.Y;
            shadowView = new ImageView()
            {
              ResourceUrl = Tizen.Applications.Application.Current.DirectoryInfo.SharedResource + "fbfood.png",
              FittingMode = FittingModeType.ShrinkToFit,
              CornerRadius = new Vector4(0.03f, 0.03f, 0.03f, 0.03f),
              CornerRadiusPolicy = VisualTransformPolicyType.Relative,
            };
            DragData dragData;
            dragData.MimeType = "text/uri-list/fbimage";
            dragData.Data = Tizen.Applications.Application.Current.DirectoryInfo.SharedResource + "fbfood.png";
            dnd.StartDragAndDrop(attachImage1, shadowView, dragData);
          }
        };
                    
        var menuView = new View()
        {
          Layout = new LinearLayout()
          {
            LinearOrientation = LinearLayout.Orientation.Horizontal,
            HorizontalAlignment = HorizontalAlignment.Center,
            VerticalAlignment = VerticalAlignment.Center,
          },
          WidthSpecification = LayoutParamPolicies.MatchParent,
          HeightSpecification = LayoutParamPolicies.MatchParent,
        };
        windowMainView[4].Add(menuView);

        var menuIcon1 = new ImageView()
        {
          WidthSpecification = 50,
          HeightSpecification = 50,
          ResourceUrl = Tizen.Applications.Application.Current.DirectoryInfo.SharedResource + "fbimage.png",
          CornerRadius = new Vector4(0.1f, 0.1f, 0.1f, 0.1f),
          CornerRadiusPolicy = VisualTransformPolicyType.Relative,
          Margin = 10,
        };
        menuView.Add(menuIcon1);

        var menuIcon2 = new ImageView()
        {
          WidthSpecification = 50,
          HeightSpecification = 50,
          ResourceUrl = Tizen.Applications.Application.Current.DirectoryInfo.SharedResource + "fbfriend.png",
          CornerRadius = new Vector4(0.1f, 0.1f, 0.1f, 0.1f),
          CornerRadiusPolicy = VisualTransformPolicyType.Relative,
          Margin = 5,
        };
        menuView.Add(menuIcon2);

        var menuIcon3 = new ImageView()
        {
          WidthSpecification = 50,
          HeightSpecification = 50,
          ResourceUrl = Tizen.Applications.Application.Current.DirectoryInfo.SharedResource + "fbemoji.png",
          CornerRadius = new Vector4(0.1f, 0.1f, 0.1f, 0.1f),
          CornerRadiusPolicy = VisualTransformPolicyType.Relative,
          Margin = 5,
        };
        menuView.Add(menuIcon3);

        var menuIcon4 = new ImageView()
        {
          WidthSpecification = 50,
          HeightSpecification = 50,
          ResourceUrl = Tizen.Applications.Application.Current.DirectoryInfo.SharedResource + "fbmap.png",
          CornerRadius = new Vector4(0.1f, 0.1f, 0.1f, 0.1f),
          CornerRadiusPolicy = VisualTransformPolicyType.Relative,
          Margin = 5,
        };
        menuView.Add(menuIcon4);

        var menuIcon5 = new ImageView()
        {
          WidthSpecification = 50,
          HeightSpecification = 50,
          ResourceUrl = Tizen.Applications.Application.Current.DirectoryInfo.SharedResource + "fbsend.png",
          CornerRadius = new Vector4(0.1f, 0.1f, 0.1f, 0.1f),
          CornerRadiusPolicy = VisualTransformPolicyType.Relative,
          Margin = 5,
        };
        menuView.Add(menuIcon5);
      }
    }

    void CreateAllApps()
    {
      if (SubWindows[0])
      { 
        SubWindows[0].Destroy();
        SubWindows[0] = null;
      }
        
      if (SubWindows[0] == null)
      {
        SubWindows[0] = new Window("AllApps", allAppsWinPosition, false);
        SubWindows[0].EnableBorderWindow();

        windowMainView[0] = new View()
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
            Text = "All apps",
            PointSize = 4 * fontScale,
            HorizontalAlignment = HorizontalAlignment.Center,
            Padding = new Extents(35,0,20,0),
        };

        // Create All Apps Items
        var view = new View()
        {
          Layout = new GridLayout()
          {
            Columns = 3,
            Rows = 3,
          },
          WidthSpecification = LayoutParamPolicies.MatchParent,
          HeightSpecification = LayoutParamPolicies.MatchParent,
        };

        SubWindows[0].Add(windowMainView[0]);
        windowMainView[0].Add(title);
        windowMainView[0].Add(view);

        for(int i = 0;  i < 9; i++)
        {
          var itemView = CreateItem(Tizen.Applications.Application.Current.DirectoryInfo.SharedResource + itemNameArr[i] + ".png", itemNameArr[i]);
          itemView.Name = itemNameArr[i];

          if (itemLongPressed[i] == null)
          itemLongPressed[i] = new LongPressGestureDetector();
          itemLongPressed[i].Attach(itemView);
          itemLongPressed[i].Detected += (s, e) =>
          {
            if(e.LongPressGesture.State == Gesture.StateType.Started)
            {
              shadowView = CreateItem(Tizen.Applications.Application.Current.DirectoryInfo.SharedResource + itemView.Name + ".png", itemView.Name);
              DragData dragData;
              dragData.MimeType = "text/uri-list/allaps";
              dragData.Data = Tizen.Applications.Application.Current.DirectoryInfo.SharedResource + itemView.Name + ".png" + "," + itemView.Name;
              dnd.StartDragAndDrop(itemView, shadowView, dragData);
            }
          };
          view.Add(itemView);
        }
      }
    }

    void changeTrayItemBackground(int itemID, bool isPressed)
    {
      currentItemId = -1;
      currentItemIdPressed = false;

      if (itemID == 0)
      {
        if (isPressed)
          trayItem[itemID].ResourceUrl = Tizen.Applications.Application.Current.DirectoryInfo.SharedResource + "galleryp.png";
        else
          trayItem[itemID].ResourceUrl = Tizen.Applications.Application.Current.DirectoryInfo.SharedResource + "gallery.png";
      }
      else if(itemID == 1)
      {
        if (isPressed)
          trayItem[itemID].ResourceUrl = Tizen.Applications.Application.Current.DirectoryInfo.SharedResource + "emailp.png";
        else
          trayItem[itemID].ResourceUrl = Tizen.Applications.Application.Current.DirectoryInfo.SharedResource + "email.png";
      }
      else if(itemID == 2)
      {
        if (isPressed)
          trayItem[itemID].ResourceUrl = Tizen.Applications.Application.Current.DirectoryInfo.SharedResource + "memop.png";
        else
          trayItem[itemID].ResourceUrl = Tizen.Applications.Application.Current.DirectoryInfo.SharedResource + "memo.png";
      }
      else if(itemID == 3)
      {
        if (isPressed)
        {
          trayItem[itemID].ResourceUrl = Tizen.Applications.Application.Current.DirectoryInfo.SharedResource + "painterp.png";
          currentItemId = 3;
          currentItemIdPressed = true;
        }
        else
        {
          trayItem[itemID].ResourceUrl = Tizen.Applications.Application.Current.DirectoryInfo.SharedResource + "painter.png";
        }
      }
      else if(itemID == 4)
      {
        if (isPressed)
          trayItem[itemID].ResourceUrl = Tizen.Applications.Application.Current.DirectoryInfo.SharedResource + "allappsp.png";
        else
          trayItem[itemID].ResourceUrl = Tizen.Applications.Application.Current.DirectoryInfo.SharedResource + "allapps.png";
      }
    }

    void OnRootViewDnDFunc(View targetView, DragEvent dragEvent)
    {        
        
        if (dragEvent.DragType == DragType.Enter)
        {
          //Tizen.Log.Error("WhiteboardDnDDemo", "KTH Enter " + dragEvent.Position.X + " " + dragEvent.Position.Y);
        }
        else if (dragEvent.DragType == DragType.Leave)
        {
          //Tizen.Log.Error("WhiteboardDnDDemo", "KTH Leave " + dragEvent.Position.X + " " + dragEvent.Position.Y);
        }
        else if (dragEvent.DragType == DragType.Move)
        {
          //Tizen.Log.Error("WhiteboardDnDDemo", "KTH Move " + dragEvent.Position.X + " " + dragEvent.Position.Y);
        }
        else if (dragEvent.DragType == DragType.Drop)
        {
          if (dragEvent.MimeType == "text/uri-list/allaps")
          {
              string[] itemData = dragEvent.Data.Split(',');
              var itemView = CreateItem(itemData[0], itemData[1]);
              myAppsView.Add(itemView);
              itemView.SiblingOrder = 1;
          }
          else if (dragEvent.MimeType == "text/uri-list/fbimage")
          {
            if (SubWindows[2] == null )
            {
              CreateGallery();
            }

            if (galleryView)
            {
              galleryView.ResourceUrl = dragEvent.Data;
            }

          }
          else if (dragEvent.MimeType == "text/uri-list/fbtext")
          {
            if (SubWindows[3] == null)
            {
              CreateEmail();
            }
            if (inputContent)
            {
              inputContent.Text = dragEvent.Data;
            }
          }

          //Reset Angling UI
          for(int i = 0 ; i < 4; i++)
          {
            changeTrayItemBackground(i, false);
          }
        }
    }

    void CreateMyApps()
    {
      if (SubWindows[1])
      {
        SubWindows[1].Destroy();
        SubWindows[1] = null;
      }

      if (SubWindows[1] == null)
      {
        SubWindows[1] = new Window("MyAppsWindow", myAppsWinPosition, false);
        SubWindows[1].EnableBorderWindow();

        windowMainView[1] = new View()
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
            Text = "My apps",
            PointSize = 4 * fontScale,
            HorizontalAlignment = HorizontalAlignment.Center,
            Padding = new Extents(35,0,20,0),
        };

        windowMainView[1].Add(title);

        // Create My Apps Items
        myAppsView = new View()
        {
          Layout = new GridLayout()
          {
            Columns = 3,
            Rows = 1,
          },
          WidthSpecification = LayoutParamPolicies.MatchParent,
          HeightSpecification = LayoutParamPolicies.MatchParent,
        };

        SubWindows[1].Add(windowMainView[1]);
        windowMainView[1].Add(myAppsView);

        faceBookItem = CreateItem(Tizen.Applications.Application.Current.DirectoryInfo.SharedResource + "facebook.png", "facebook");
        myAppsView.Add(faceBookItem);
        faceBookItem.TouchEvent += (s, e) =>
        {
          if (e.Touch.GetState(0) == PointStateType.Up)
          {
            CreateFacebook();
          }
          return true;
        };

        var spotifyItem = CreateItem(Tizen.Applications.Application.Current.DirectoryInfo.SharedResource + "spoti.png", "spotify");
        myAppsView.Add(spotifyItem);
        
        var instagramItem = CreateItem(Tizen.Applications.Application.Current.DirectoryInfo.SharedResource + "instagram.png", "instagram");
        myAppsView.Add(instagramItem);
      }
    }

    void LaunchApp()
    {
        var appControl = new Tizen.Applications.AppControl();
        appControl.Operation = Tizen.Applications.AppControlOperations.Default;
        appControl.ApplicationId = "org.tizen.NUI_Whiteboard";
        Tizen.Applications.AppControl.SendLaunchRequest(appControl);
    }
    void CreateTrayApps()
    {
      if (trayWindow == null)
      {
        trayWindow = new Window("TrayWindow", new Rectangle(1700, 80, 200, 920), false);
        trayWindow.BackgroundColor = Color.Transparent;
        trayWindow.SetTransparency(true);
        
        var mainView = new View()
        {
         Layout = new LinearLayout()
         {
           LinearOrientation = LinearLayout.Orientation.Vertical,
           VerticalAlignment = VerticalAlignment.Center,
           HorizontalAlignment = HorizontalAlignment.Center,
         },
         WidthSpecification = LayoutParamPolicies.MatchParent,
         HeightSpecification = LayoutParamPolicies.MatchParent,
         BackgroundColor = new Color(1.0f, 1.0f, 1.0f, 0.5f),
         CornerRadius = new Vector4(0.03f, 0.03f, 0.03f, 0.03f),
         CornerRadiusPolicy = VisualTransformPolicyType.Relative,
         ClippingMode = ClippingModeType.ClipToBoundingBox,
        };

        trayWindow.Add(mainView);

        trayItem[0] = new ImageView()
        {
          Size = new Size(160, 160),
          ResourceUrl = Tizen.Applications.Application.Current.DirectoryInfo.SharedResource + "gallery.png",
          Margin = 10,
        };
        mainView.Add(trayItem[0]);
        trayItem[0].TouchEvent += (s, e) =>
        {
          if (e.Touch.GetState(0) == PointStateType.Up)
          {
            CreateGallery();
            trayItem[0].ResourceUrl = Tizen.Applications.Application.Current.DirectoryInfo.SharedResource + "gallery.png";
          }
          else if (e.Touch.GetState(0) == PointStateType.Down)
          {
            trayItem[0].ResourceUrl = Tizen.Applications.Application.Current.DirectoryInfo.SharedResource + "galleryp.png";
          }
          return true;
        };

        trayItem[1] = new ImageView()
        {
          Size = new Size(160, 160),
          ResourceUrl = Tizen.Applications.Application.Current.DirectoryInfo.SharedResource + "email.png",
          Margin = 10,
        };
        mainView.Add(trayItem[1]);
        trayItem[1].TouchEvent += (s, e) =>
        {
          if (e.Touch.GetState(0) == PointStateType.Up)
          {
            CreateEmail();
            trayItem[1].ResourceUrl = Tizen.Applications.Application.Current.DirectoryInfo.SharedResource + "email.png";
          }
          else if (e.Touch.GetState(0) == PointStateType.Down)
          {
            trayItem[1].ResourceUrl = Tizen.Applications.Application.Current.DirectoryInfo.SharedResource + "emailp.png";
          }
          return true;
        };

        trayItem[2] = new ImageView()
        {
          Size = new Size(160, 160),
          ResourceUrl = Tizen.Applications.Application.Current.DirectoryInfo.SharedResource + "memo.png",
          Margin = 10,
        };
        mainView.Add(trayItem[2]);
        trayItem[2].TouchEvent += (s, e) =>
        {
          if (e.Touch.GetState(0) == PointStateType.Up)
          {
            CreateMyApps();
            trayItem[2].ResourceUrl = Tizen.Applications.Application.Current.DirectoryInfo.SharedResource + "memo.png";
          }
          else if (e.Touch.GetState(0) == PointStateType.Down)
          {
            trayItem[2].ResourceUrl = Tizen.Applications.Application.Current.DirectoryInfo.SharedResource + "memop.png";
          }
          return true;
        };

        trayItem[3] = new ImageView()
        {
          Size = new Size(160, 160),
          ResourceUrl = Tizen.Applications.Application.Current.DirectoryInfo.SharedResource + "painter.png",
          Margin = 10,
        };
        mainView.Add(trayItem[3]);
        trayItem[3].TouchEvent += (s, e) =>
        {
          if (e.Touch.GetState(0) == PointStateType.Up)
          {
            trayItem[3].ResourceUrl = Tizen.Applications.Application.Current.DirectoryInfo.SharedResource + "painter.png";
            LaunchApp();
          }
          else if (e.Touch.GetState(0) == PointStateType.Down)
          {
            trayItem[3].ResourceUrl = Tizen.Applications.Application.Current.DirectoryInfo.SharedResource + "painterp.png";
          }
          return true;
        };

        trayItem[4] = new ImageView()
        {
          Size = new Size(160, 160),
          ResourceUrl = Tizen.Applications.Application.Current.DirectoryInfo.SharedResource + "allapps.png",
          Margin = 10,
        };
        mainView.Add(trayItem[4]);
        trayItem[4].TouchEvent += (s, e) =>
        {
          if (e.Touch.GetState(0) == PointStateType.Up)
          {
            CreateAllApps();
            trayItem[4].ResourceUrl = Tizen.Applications.Application.Current.DirectoryInfo.SharedResource + "allapps.png";
          }
          else if (e.Touch.GetState(0) == PointStateType.Down)
          {
            trayItem[4].ResourceUrl = Tizen.Applications.Application.Current.DirectoryInfo.SharedResource + "allappsp.png";
          }
          return true;
        };
      }
    }

    // Recognition Swipe Gesture
    private bool swipeTimerTick(object source, Timer.TickEventArgs e)
    {
        if (groupSize > 1)
        {
          if ((swipeDx - preSwipeDx) == 0 && (swipeDy - preSwipeDy) == 0)
          {
            swipeCount++;
          }
          else
          {
            swipeMoveCount++;
          }

          if (bSwipeStart && swipeCount > swipeThreashold)
          {
            bSwipeStart = false;
            swipeMoveCount = 0;
            swipeCount = 0;
            swipeEndX = swipeDx;
            swipeEndY = swipeDy;

            double vec1 = swipeEndX - originPointX;
            double vec2 = swipeEndY - originPointY;
            double curVecLength = Math.Sqrt(vec1 * vec1 + vec2 * vec2);

            if (curVecLength > vecLength)
            {
              header += 1;
              if (header >= groupSize)
              {
                header = groupSize - 1;
              }
            }
            else
            {
              header -= 1;
              if (header < 0)
                header = 0;
            }

            if (header > 0 && header < windowArray.Count)
            {
              WindowPosInfo checkWpi = (WindowPosInfo)windowArray[header];
              if (header == preHeader && checkWpi.type == hilightItemType && checkWpi.id != hilightItemIndex)
              {
                header = 0;
              }
            }
            // Update Highlihght
            for(int i=0; i < windowArray.Count; i++)
              {
                WindowPosInfo wpi = (WindowPosInfo)windowArray[i];

                if (header == i)
                {
                  if (wpi.type == 1)
                  {
                    windowMainView[wpi.id].BackgroundColor = new Color(0.984f, 0.862f, 0.784f, 1.0f);
                  }
                  else
                  {
                    changeTrayItemBackground(wpi.id, true);
                  }
                  hilightItemIndex = wpi.id;
                  hilightItemType = wpi.type;
                  preHeader = i;
                }
                else
                {
                  if (wpi.type == 1)
                    windowMainView[wpi.id].BackgroundColor = Color.White;
                  else
                    changeTrayItemBackground(wpi.id, false);
                }
              }
              
            vecLength = curVecLength;
          }
          else if(!bSwipeStart && swipeMoveCount > swipeMoveThreashold)
          {
            swipeMoveCount = 0;
            swipeCount = 0;
            bSwipeStart = true;      
          }
        }
        else
        {
          header = 0;
        }

        preSwipeDx = swipeDx;
        preSwipeDy = swipeDy;
        return true;
    }

    void Initialize()
    {
        //Initalize Timer
        swipeTimer = new Timer(20);
        swipeTimer.Tick += swipeTimerTick;
        swipeTimer.Start();

        //Initialize DnD
        dnd = DragAndDrop.Instance;

        win = NUIApplication.GetDefaultWindow();
        var root = new ImageView()
        {
          WidthResizePolicy = ResizePolicyType.FillToParent,
          HeightResizePolicy = ResizePolicyType.FillToParent,
          ResourceUrl = Tizen.Applications.Application.Current.DirectoryInfo.SharedResource + "background.png",
          Layout = new LinearLayout()
          {
              LinearAlignment = LinearLayout.Alignment.CenterHorizontal,
              LinearOrientation = LinearLayout.Orientation.Horizontal,
              CellPadding = new Size(10, 10),
          },
          ClippingMode = ClippingModeType.ClipToBoundingBox,
        };
        win.Add(root);
        dnd.AddListener(root, OnRootViewDnDFunc);
        CreateTrayApps();

        //Angling UI Logic
        originPoint = new View()
        {
          Position = new Position(-100, -100),
          Size = new Size(30, 30),
          BackgroundColor = new Color(1.0f, 1.0f, 1.0f, 0.5f),
          CornerRadius = new Vector4(0.5f, 0.5f, 0.5f, 0.5f),
          CornerRadiusPolicy = VisualTransformPolicyType.Relative,
        };
        win.Add(originPoint);

        for (int i = 0;  i < 5; i++)
        {            
          TrayPoint[i] = new View()
          {
            Position = new Position((float)circlePositionX[i] - (trayPointSize[i]/2), (float)circlePositionY[i] - (trayPointSize[i]/2)),
            Size = new Size(trayPointSize[i], trayPointSize[i]),
            BackgroundColor = Color.Orange,
            CornerRadius = new Vector4(0.5f, 0.5f, 0.5f, 0.5f),
            CornerRadiusPolicy = VisualTransformPolicyType.Relative,
          };
          win.Add(TrayPoint[i]);
          if (!enableTrayCircle)
            TrayPoint[i].Hide();
        }

        mousePoint = new View()
        {
          Position = new Position(-100, -100),
          Size = new Size(30, 30),
          BackgroundColor = new Color(1.0f, 1.0f, 1.0f, 0.5f),
          CornerRadius = new Vector4(0.5f, 0.5f, 0.5f, 0.5f),
          CornerRadiusPolicy = VisualTransformPolicyType.Relative,
        };
        win.Add(mousePoint);

        for (int i=0; i < 5; i++)
        {
          windowPoint[i] = new View()
          {
            Position = new Position((float)windowCenterX[i], (float)windowCenterY[i]),
            Size = new Size((float)windowRadius * 2.0f, (float)windowRadius * 2.0f),
            BackgroundColor = Color.Orange,
            CornerRadius = new Vector4(0.5f, 0.5f, 0.5f, 0.5f),
            CornerRadiusPolicy = VisualTransformPolicyType.Relative,
          };
          win.Add(windowPoint[i]);
          if (!enableTrayCircle)
            windowPoint[i].Hide();
        }

        win.TouchEvent += (s, e) =>
        {
          if (e.Touch.GetState(0) == PointStateType.Down)
          {
             Position currentPos =  new Position(e.Touch.GetScreenPosition(0).X, e.Touch.GetScreenPosition(0).Y);
             originPoint.PositionX = currentPos.X - 15.0f;
             originPoint.PositionY = currentPos.Y - 15.0f;
             
             originPointX = currentPos.X;
             originPointY = currentPos.Y;

             mousePoint.PositionX = currentPos.X - 15.0f;
             mousePoint.PositionY = currentPos.Y - 15.0f;

             originPoint.Show();
             mousePoint.Show();
          }
          else if (e.Touch.GetState(0) == PointStateType.Motion)
          {
             Position currentPos =  new Position(e.Touch.GetScreenPosition(0).X, e.Touch.GetScreenPosition(0).Y);
             mousePoint.PositionX = currentPos.X - 15.0f;
             mousePoint.PositionY = currentPos.Y - 15.0f;

             swipeDx = currentPos.X;
             swipeDy = currentPos.Y;

             double [] vec = new double[2];
             vec[0] = (double)(currentPos.X - originPointX);
             vec[1] = (double)(currentPos.Y - originPointY);

             //normalize
             double length = Math.Sqrt((vec[0] * vec[0] + vec[1] * vec[1]));
             vec[0] /= length;
             vec[1] /= length;

             // tray item angling
             windowArray.Clear();
             for (int i = 0; i < 5; i++)
             {
               double [] h = new double[2];
               h[0] = circlePositionX[i] - originPointX;
               h[1] = circlePositionY[i] - originPointY;
               double lf = (vec[0] * h[0]) + (vec[1] * h[1]);
               double result = (circleRadius[i] * circleRadius[i]) - ((h[0] * h[0]) +( h[1] * h[1])) + (lf * lf);

               if (result < 0.0)
               {
                 TrayPoint[i].BackgroundColor = Color.Orange;
                 changeTrayItemBackground(i, false);
               }
               else
               {
                 double vec1 = circlePositionX[i] - originPointX;
                 double vec2 = circlePositionY[i] - originPointY;

                 double dot = vec[0] * vec1 + vec[1] * vec2;
                 double det = vec[0] * vec2 - vec[1] * vec1;
                 double angle = Math.Atan2(det, dot);
                 double degree = angle * (180.0f / Math.PI);

                 if (degree > -60.0f && degree < 60.0f)
                 {
                   TrayPoint[i].BackgroundColor = Color.Green;
                   double vecLength = Math.Sqrt(vec1 * vec1 + vec2 * vec2);
                   windowArray.Add(new WindowPosInfo(i, vecLength, 0));
                 }
               }
             }

             // window angling
             for (int i=0; i < 5; i++)
             {
                if (SubWindows[i])
                {
                    windowPoint[i].PositionX = SubWindows[i].WindowPosition.X + (SubWindows[i].WindowSize.Width / 2) - (windowPoint[i].Size.Width / 2);
                    windowPoint[i].PositionY = SubWindows[i].WindowPosition.Y + (SubWindows[i].WindowSize.Height / 2)- (windowPoint[i].Size.Height / 2) + windowCenterOffsetY;

                    windowCenterX[i] = SubWindows[i].WindowPosition.X + (SubWindows[i].WindowSize.Width / 2);
                    windowCenterY[i] = SubWindows[i].WindowPosition.Y + (SubWindows[i].WindowSize.Height / 2) + windowCenterOffsetY;
                    double [] h = new double[2];
                    h[0] = windowCenterX[i] - originPointX;
                    h[1] = windowCenterY[i] - originPointY;
                    double lf = (vec[0] * h[0]) + (vec[1] * h[1]);
                    double result = (windowRadius * windowRadius) - ((h[0] * h[0]) +( h[1] * h[1])) + (lf * lf);

                    if (result < 0.0)
                    {
                      windowPoint[i].BackgroundColor = Color.Orange;
                      windowMainView[i].BackgroundColor = Color.White;
                    }
                    else
                    {
                       double vec1 = SubWindows[i].WindowPosition.X + (SubWindows[i].WindowSize.Width / 2) - originPointX;
                       double vec2 = SubWindows[i].WindowPosition.Y + (SubWindows[i].WindowSize.Height / 2) - originPointY;

                       double dot = vec[0] * vec1 + vec[1] * vec2;
                       double det = vec[0] * vec2 - vec[1] * vec1;
                       double angle = Math.Atan2(det, dot);
                       double degree = angle * (180.0f / Math.PI);

                       if (degree > -60.0f && degree < 60.0f)
                       {
                         windowPoint[i].BackgroundColor = Color.Green;
                         double vecLength = Math.Sqrt(vec1 * vec1 + vec2 * vec2);
                         windowArray.Add(new WindowPosInfo(i, vecLength, 1));
                       }
                    }
                }
             }

             windowArray.Sort();
             groupSize = windowArray.Count;

             if (header > 0 && header < windowArray.Count)
             {
              WindowPosInfo checkWpi = (WindowPosInfo)windowArray[header];
              if (header == preHeader && checkWpi.type == hilightItemType && checkWpi.id != hilightItemIndex)
              {
                header = 0;
              }
             }
             
             for(int i=0; i < windowArray.Count; i++)
             {
               WindowPosInfo wpi = (WindowPosInfo)windowArray[i];

               if (header == i)
               {
                 if (wpi.type == 1)
                   windowMainView[wpi.id].BackgroundColor = new Color(0.984f, 0.862f, 0.784f, 1.0f);
                 else
                   changeTrayItemBackground(wpi.id, true);
               }
               else
               {
                 if (wpi.type == 1)
                   windowMainView[wpi.id].BackgroundColor = Color.White;
                 else
                   changeTrayItemBackground(wpi.id, false);
               }
             }
          }
          else if (e.Touch.GetState(0) == PointStateType.Up)
          {
            if (currentItemId == 3 && currentItemIdPressed)
            {
              LaunchApp();
            }
            originPoint.Hide();
            mousePoint.Hide();
            for (int i = 0; i < 5; i++)
             {
                 TrayPoint[i].BackgroundColor = Color.Orange;
                 changeTrayItemBackground(i, false);
                 if (SubWindows[i] != null)
                   windowMainView[i].BackgroundColor = Color.White;
             }
          }
        };
    }

    public void Activate()
    {
      Initialize();
    }

    public void Deactivate()
    {
    }
  }
}
