
using System;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;
using System.Collections.Generic;

namespace Tizen.NUI.Samples
{
  public class WhiteboardDnDTest : IExample
  {
    // MainWindow
    private Window win;

    // DemoApp Window and Position
    private Window trayWindow = null;
    private Window [] SubWindows = new Window[5];
    private Rectangle allAppsWinPosition = new Rectangle(300, 207, 450, 500);
    private Rectangle myAppsWinPosition = new Rectangle(1000, 250, 450, 350);
    private Rectangle trayWinPosition = new Rectangle(300, 200, 400, 400);
    private Rectangle galleryWinPosition = new Rectangle(1100, 50, 400, 400);
    private Rectangle emailWinPosition = new Rectangle(1100, 550, 400, 400);
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
    private ImageView [] trayItem = new ImageView[8];

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
    //private float fontScale = 5;
    //for Emulator font scale
    private float fontScale = 1.5f;

    // <Angling UI Logic>
    private View originPoint = null;
    private double originPointX = 400;
    private double originPointY = 505;
    private View mousePoint = null;

    // Circle Center Position
    private double [] circlePositionX = new double[8]{1800, 1800, 1800, 1800, 550, 800, 1050, 1300};
    private double [] circlePositionY = new double[8]{300, 460, 620, 780, 100, 100, 100, 100};
    
    // Tray Items
    private View [] TrayPoint = new View[8];
    private float trayPointSize = 150.0f;
    private double circleRadius = 75.0f;

     // Window Center Position
    private View [] myAppsPoint = new View[5];
    private View [] myAppsMainView = new View[5];
    private double [] windowCenterX = new double[5]{-500, -500, -500, -500, -500};
    private double [] windowCenterY = new double[5]{-500, -500, -500, -500, -500};
    private double windowRadius = 175.0f;

    private int topTrayItemSize = 160;

    private double [] topItemPositionX = new double[4]{300, 500, 700, 900};
    private double [] topItemPositionY = new double[4]{200, 200, 200, 200};

    private bool enableTrayCircle = true;
    private bool enableMouseCircle = true;

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
      if (SubWindows[2] == null)
      {
        SubWindows[2] = new Window("GalleryWindow", galleryWinPosition, false);
        SubWindows[2].EnableBorderWindow();

        myAppsMainView[2] = new View()
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

        SubWindows[2].Add(myAppsMainView[2]);
        myAppsMainView[2].Add(title);
        myAppsMainView[2].Add(view);

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
      if (SubWindows[3] == null)
      {
        SubWindows[3] = new Window("EmailWindow", emailWinPosition, false);
        SubWindows[3].EnableBorderWindow();

        myAppsMainView[3] = new View()
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

        myAppsMainView[3].ClippingMode = ClippingModeType.ClipToBoundingBox;
        SubWindows[3].Add(myAppsMainView[3]);
        myAppsMainView[3].Add(title);

        var labelSender = new TextLabel() {
            Text = "sender : taehyub.kim@samsung.com",
            PointSize = 3 * fontScale,
            HorizontalAlignment = HorizontalAlignment.Begin,
            Padding = new Extents(10,0,10,0),
        };
        myAppsMainView[3].Add(labelSender);

        var labelReceiver = new TextLabel() {
            Text = "receiver : hyunju.shin@samsung.com",
            PointSize = 3 * fontScale,
            HorizontalAlignment = HorizontalAlignment.Begin,
            Padding = new Extents(10,0,10,0),
        };
        myAppsMainView[3].Add(labelReceiver);

        var labelTitle = new TextLabel() {
            Text = "title : DnD and Window Border!",
            PointSize = 3 * fontScale,
            HorizontalAlignment = HorizontalAlignment.Begin,
            Padding = new Extents(10,0,10,0),
        };
        myAppsMainView[3].Add(labelTitle);

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
        myAppsMainView[3].Add(menuView);

        inputContent = new TextEditor()
        {
          WidthSpecification = LayoutParamPolicies.MatchParent,
          HeightSpecification = 150,
          PointSize = 3 * fontScale,
          BorderlineWidth = 2.0f,
          BorderlineColor = new Color(1.0f, 0.4f, 0.0f, 1.0f),
          CornerRadius = new Vector4(0.1f, 0.1f, 0.1f, 0.1f),
          CornerRadiusPolicy = VisualTransformPolicyType.Relative,
          Margin = 10,
          LineWrapMode = LineWrapMode.Mixed,
        };
        myAppsMainView[3].Add(inputContent); 
      }
      else
      {
        SubWindows[3].Minimize(false);
      }
    }
    void CreateFacebook()
    {
      if (SubWindows[4] == null)
      {
        SubWindows[4] = new Window("FacebookWindow", facebookWinPosition, false);
        SubWindows[4].EnableBorderWindow();

        myAppsMainView[4] = new View()
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

        SubWindows[4].Add(myAppsMainView[4]);
        myAppsMainView[4].Add(title);

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
        myAppsMainView[4].Add(profileView);

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
        myAppsMainView[4].Add(content);
        textLongPressed = new LongPressGestureDetector();
        textLongPressed.Attach(content);
        textLongPressed.Detected += (s, e) =>
        {
          if(e.LongPressGesture.State == Gesture.StateType.Started)
          {
            originPointX = e.LongPressGesture.ScreenPoint.X + SubWindows[4].WindowPosition.X;
            originPointY = e.LongPressGesture.ScreenPoint.Y + SubWindows[4].WindowPosition.Y;
            Tizen.Log.Error("WhiteboardDnDDemo", "KTH Facebook Angling UI Text: " + originPointX + " " + originPointY);
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

/*
        content.TouchEvent += (s, e) =>
        {
          if (e.Touch.GetState(0) == PointStateType.Stationary && e.Touch.GetPointCount() == 2)
          {
            originPointX = e.Touch.GetScreenPosition(0).X + SubWindows[4].WindowPosition.X;
            originPointY = e.Touch.GetScreenPosition(0).Y + SubWindows[4].WindowPosition.Y;
            Tizen.Log.Error("WhiteboardDnDDemo", "KTH Facebook Angling UI Text !!!: " + originPointX + " " + originPointY);
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
          
          return true;
        };
*/

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
        myAppsMainView[4].Add(attachImageView);

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
            Tizen.Log.Error("WhiteboardDnDDemo", "KTH Facebook Angling UI Text: " + originPointX + " " + originPointY);
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
            Tizen.Log.Error("WhiteboardDnDDemo", "KTH Facebook Angling UI Text: " + originPointX + " " + originPointY);
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
        myAppsMainView[4].Add(menuView);

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
      else
      {
        SubWindows[4].Minimize(false);
      }
    }

    void CreateAllApps()
    {
      if (SubWindows[0] == null)
      {
        Tizen.Log.Error("WhiteboardDnDDemo", "KTH Create AllApps 1");
        SubWindows[0] = new Window("AllApps", allAppsWinPosition, false);
        SubWindows[0].EnableBorderWindow();

        myAppsMainView[0] = new View()
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

        SubWindows[0].Add(myAppsMainView[0]);
        myAppsMainView[0].Add(title);
        myAppsMainView[0].Add(view);

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
              Tizen.Log.Error("WhiteboardDnDDemo", "KTH AllApps Item Longpressed " + itemView.Name);
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
      else
      {
        Tizen.Log.Error("WhiteboardDnDDemo", "KTH Create AllApps 2");
        SubWindows[0].Minimize(false);
      }
    }

    bool IsDroppedInWindow(Window window, Position position)
    {
      int winLeft = window.WindowPosition.X;
      int winRight = window.WindowPosition.X + window.WindowSize.Width;
      int winTop = window.WindowPosition.Y;
      int winBottom = window.WindowPosition.Y + window.WindowSize.Height;

      Tizen.Log.Error("WhiteboardDnDDemo", "KTH IsDroppedInWindow " + position.X + " " + position.Y + " " + winLeft + " " + winTop + " " + winRight + " " + winBottom);

      if (position.X > winLeft && position.Y > winTop && position.X < winRight && position.Y < winBottom)
        return true;
      else
        return false;
    }

    int GetDemoAppID(Position position)
    {
      
      if (IsDroppedInWindow(SubWindows[1], position))
        return 1;

      /*
      else if(IsDroppedInWindow(SubWindows[1], position))
        return 2;
      else if(IsDroppedInWindow(trayWindow, position))
        return 3;
      else if(IsDroppedInWindow(SubWindows[2], position))
        return 4;
      else if(IsDroppedInWindow(SubWindows[3], position))
        return 5;
      else if(IsDroppedInWindow(SubWindows[4], position))
        return 6;
        */
      else
        return 0;
    }

    void changeTrayItemBackground(int itemID, bool isPressed)
    {
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
          trayItem[itemID].ResourceUrl = Tizen.Applications.Application.Current.DirectoryInfo.SharedResource + "allappsp.png";
        else
          trayItem[itemID].ResourceUrl = Tizen.Applications.Application.Current.DirectoryInfo.SharedResource + "allapps.png";
      }
      else if(itemID == 4)
      {
        if (isPressed)
          trayItem[itemID].ResourceUrl = Tizen.Applications.Application.Current.DirectoryInfo.SharedResource + "homep.png";
        else
          trayItem[itemID].ResourceUrl = Tizen.Applications.Application.Current.DirectoryInfo.SharedResource + "home.png";
      }
      else if(itemID == 5)
      {
        if (isPressed)
          trayItem[itemID].ResourceUrl = Tizen.Applications.Application.Current.DirectoryInfo.SharedResource + "favoritep.png";
        else
          trayItem[itemID].ResourceUrl = Tizen.Applications.Application.Current.DirectoryInfo.SharedResource + "favorite.png";
      }
      else if(itemID == 6)
      {
        if (isPressed)
          trayItem[itemID].ResourceUrl = Tizen.Applications.Application.Current.DirectoryInfo.SharedResource + "painterp.png";
        else
          trayItem[itemID].ResourceUrl = Tizen.Applications.Application.Current.DirectoryInfo.SharedResource + "painter.png";
      }
      else if(itemID == 7)
      {
        if (isPressed)
          trayItem[itemID].ResourceUrl = Tizen.Applications.Application.Current.DirectoryInfo.SharedResource + "settingp.png";
        else
          trayItem[itemID].ResourceUrl = Tizen.Applications.Application.Current.DirectoryInfo.SharedResource + "setting.png";
      }
    }

    void OnRootViewDnDFunc(View targetView, DragEvent dragEvent)
    {
        //currently target view will not be used because of input issue
        //calculate each window's position and size for drop point
        //if facebook drag and drop activate auto selecting mode for tray app
        //if find auto selected app, ignore other window's dnd

        Tizen.Log.Error("WhiteboardDnDDemo", "KTH mime type : " + dragEvent.MimeType);
        
        if (dragEvent.DragType == DragType.Enter)
        {
          Tizen.Log.Error("WhiteboardDnDDemo", "KTH Enter " + dragEvent.Position.X + " " + dragEvent.Position.Y);
        }
        else if (dragEvent.DragType == DragType.Leave)
        {
          Tizen.Log.Error("WhiteboardDnDDemo", "KTH Leave " + dragEvent.Position.X + " " + dragEvent.Position.Y);
        }
        else if (dragEvent.DragType == DragType.Move)
        {
          Tizen.Log.Error("WhiteboardDnDDemo", "KTH Move " + dragEvent.Position.X + " " + dragEvent.Position.Y);

/*
          if (bAnglingUI) {
            Position currentPos =  new Position(dragEvent.Position.X + SubWindows[4].WindowPosition.X, dragEvent.Position.Y + SubWindows[4].WindowPosition.Y);

            double [] vec = new double[2];
            vec[0] = (double)(currentPos.X - originPointX);
            vec[1] = (double)(currentPos.Y - originPointY);

            //normalize
            double length = Math.Sqrt((vec[0] * vec[0] + vec[1] * vec[1]));
            vec[0] /= length;
            vec[1] /= length;

            for (int i = 0; i < 4; i++)
            {
              double [] h = new double[2];
              h[0] = circlePositionX - originPointX;
              h[1] = circlePositionY[i] - originPointY;
              double lf = (vec[0] * h[0]) + (vec[1] * h[1]);
              double result = (circleRadius * circleRadius) - ((h[0] * h[0]) +( h[1] * h[1])) + (lf * lf);

              if (result < 0.0)
              {
                Tizen.Log.Error("WhiteboardDnDDemo", "KTH MainWin Circle Collision: No");
                changeTrayItemBackground(i, false);
              }
              else
              {
                Tizen.Log.Error("WhiteboardDnDDemo", "KTH MainWin Circle Collision: Collision");
                changeTrayItemBackground(i, true);
              }
            }
          }*/
        }
        else if (dragEvent.DragType == DragType.Drop)
        {
          if (dragEvent.MimeType == "text/uri-list/allaps")
          {
              string[] itemData = dragEvent.Data.Split(',');
              Tizen.Log.Error("WhiteboardDnDDemo", "KTH Drop " + dragEvent.Position.X + " " + dragEvent.Position.Y + " " + itemData[0] + " " + itemData[1]);
              var itemView = CreateItem(itemData[0], itemData[1]);
              myAppsView.Add(itemView);
              itemView.SiblingOrder = 1;

              /*
              foreach (var item in myAppsView.Children)
              {
                  if (item == itemView) continue;

                  if ((item.Position2D.X < dragEvent.Position.X) && (item.Position2D.Y < dragEvent.Position.Y) &&
                      (item.Position2D.X + item.SizeWidth > dragEvent.Position.X) && (item.Position2D.Y + item.SizeHeight > dragEvent.Position.Y))
                  {
                      itemView.SiblingOrder = item.SiblingOrder;
                      break;
                  }
              }
              myAppsView.Layout?.RequestLayout();
              */
          }
          else if (dragEvent.MimeType == "text/uri-list/fbimage")
          {
            if (SubWindows[2] == null )
            {
              CreateGallery();
            }

            if (galleryView)
            {
              Tizen.Log.Error("WhiteboardDnDDemo", "KTH Gallery Add : ", dragEvent.Data);
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
      if (SubWindows[1] == null)
      {
        SubWindows[1] = new Window("MyAppsWindow", myAppsWinPosition, false);
        SubWindows[1].EnableBorderWindow();

        myAppsMainView[1] = new View()
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

        myAppsMainView[1].Add(title);

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

        SubWindows[1].Add(myAppsMainView[1]);
        myAppsMainView[1].Add(myAppsView);

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
      else
      {
        SubWindows[1].Minimize(false);
      }
    }

    void CreateTrayApps()
    {
      if (trayWindow == null)
      {
        trayWindow = new Window("TrayWindow", new Rectangle(1700, 167, 200, 750), false);
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
          ResourceUrl = Tizen.Applications.Application.Current.DirectoryInfo.SharedResource + "memo.png"          
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
          ResourceUrl = Tizen.Applications.Application.Current.DirectoryInfo.SharedResource + "allapps.png",
        };
        mainView.Add(trayItem[3]);
        

        trayItem[3].TouchEvent += (s, e) =>
        {
          if (e.Touch.GetState(0) == PointStateType.Up)
          {
            CreateAllApps();
            trayItem[3].ResourceUrl = Tizen.Applications.Application.Current.DirectoryInfo.SharedResource + "allapps.png";
          }
          else if (e.Touch.GetState(0) == PointStateType.Down)
          {
            trayItem[3].ResourceUrl = Tizen.Applications.Application.Current.DirectoryInfo.SharedResource + "allappsp.png";
          }
          return true;
        };
      }
      else
      {
        trayWindow.Minimize(false);
      }
    }

    void CreateTopTrayItems(Window win)
    {
        trayItem[4] = new ImageView()
        {
          Position = new Position((float)circlePositionX[4] - (topTrayItemSize/2.0f), (float)circlePositionY[4]  - (topTrayItemSize/2.0f)), 
          Size = new Size(topTrayItemSize, topTrayItemSize),
          ResourceUrl = Tizen.Applications.Application.Current.DirectoryInfo.SharedResource + "home.png",
        };
        
        trayItem[4].TouchEvent += (s, e) =>
        {
          if (e.Touch.GetState(0) == PointStateType.Up)
          {
            trayItem[4].ResourceUrl = Tizen.Applications.Application.Current.DirectoryInfo.SharedResource + "home.png";
            enableTrayCircle = !enableTrayCircle;
            for(int i = 0; i < 8; i++)
            {
              if (enableTrayCircle)
                TrayPoint[i].Show();
              else
                TrayPoint[i].Hide();
            }
            for(int i = 0; i < 5; i++)
            {
              if (enableTrayCircle)
                myAppsPoint[i].Show();
              else
                myAppsPoint[i].Hide();
            }
          }
          else if (e.Touch.GetState(0) == PointStateType.Down)
          {
            trayItem[4].ResourceUrl = Tizen.Applications.Application.Current.DirectoryInfo.SharedResource + "homep.png";
          }
          return true;
        };

        trayItem[5] = new ImageView()
        {
          Position = new Position((float)circlePositionX[5] - (topTrayItemSize/2.0f), (float)circlePositionY[5] - (topTrayItemSize/2.0f)), 
          Size = new Size(topTrayItemSize, topTrayItemSize),
          ResourceUrl = Tizen.Applications.Application.Current.DirectoryInfo.SharedResource + "favorite.png",
        };
        
        trayItem[5].TouchEvent += (s, e) =>
        {
          if (e.Touch.GetState(0) == PointStateType.Up)
          {
            trayItem[5].ResourceUrl = Tizen.Applications.Application.Current.DirectoryInfo.SharedResource + "favorite.png";
            enableMouseCircle = !enableMouseCircle;
            if (enableMouseCircle)
            {
              originPoint.Show();
              mousePoint.Show();
            }
            else
            {
              originPoint.Hide();
              mousePoint.Hide();
            }
          }
          else if (e.Touch.GetState(0) == PointStateType.Down)
          {
            trayItem[5].ResourceUrl = Tizen.Applications.Application.Current.DirectoryInfo.SharedResource + "favoritep.png";
          }
          return true;
        };

        trayItem[6] = new ImageView()
        {
          Position = new Position((float)circlePositionX[6] -  (topTrayItemSize/2.0f), (float)circlePositionY[6] - (topTrayItemSize/2.0f)), 
          Size = new Size(topTrayItemSize, topTrayItemSize),
          ResourceUrl = Tizen.Applications.Application.Current.DirectoryInfo.SharedResource + "painter.png",
        };
        
        trayItem[6].TouchEvent += (s, e) =>
        {
          if (e.Touch.GetState(0) == PointStateType.Up)
          {
            trayItem[6].ResourceUrl = Tizen.Applications.Application.Current.DirectoryInfo.SharedResource + "painter.png";
          }
          else if (e.Touch.GetState(0) == PointStateType.Down)
          {
            trayItem[6].ResourceUrl = Tizen.Applications.Application.Current.DirectoryInfo.SharedResource + "painterp.png";
          }
          return true;
        };

        trayItem[7] = new ImageView()
        {
          Position = new Position((float)circlePositionX[7] - (topTrayItemSize/2.0f), (float)circlePositionY[7]- (topTrayItemSize/2.0f)), 
          Size = new Size(topTrayItemSize, topTrayItemSize),
          ResourceUrl = Tizen.Applications.Application.Current.DirectoryInfo.SharedResource + "setting.png",
        };
        
        trayItem[7].TouchEvent += (s, e) =>
        {
          if (e.Touch.GetState(0) == PointStateType.Up)
          {
            trayItem[7].ResourceUrl = Tizen.Applications.Application.Current.DirectoryInfo.SharedResource + "settingp.png";
          }
          else if (e.Touch.GetState(0) == PointStateType.Down)
          {
            trayItem[7].ResourceUrl = Tizen.Applications.Application.Current.DirectoryInfo.SharedResource + "setting.png";
          }
          return true;
        };

        win.Add(trayItem[4]);
        win.Add(trayItem[5]);
        win.Add(trayItem[6]);
        win.Add(trayItem[7]);
    }

    void Initialize()
    {
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
          BackgroundColor = Color.Red,
          CornerRadius = new Vector4(0.5f, 0.5f, 0.5f, 0.5f),
          CornerRadiusPolicy = VisualTransformPolicyType.Relative,
        };
        win.Add(originPoint);

        for (int i = 0;  i < 8; i++)
        {            
          TrayPoint[i] = new View()
          {
            Position = new Position((float)circlePositionX[i] - (trayPointSize/2), (float)circlePositionY[i] - (trayPointSize/2)),
            Size = new Size(trayPointSize, trayPointSize),
            BackgroundColor = Color.Orange,
            CornerRadius = new Vector4(0.5f, 0.5f, 0.5f, 0.5f),
            CornerRadiusPolicy = VisualTransformPolicyType.Relative,
          };
          win.Add(TrayPoint[i]);
        }
        //Create Top Tray Items
        CreateTopTrayItems(win);

        mousePoint = new View()
        {
          Position = new Position(-100, -100),
          Size = new Size(30, 30),
          BackgroundColor = Color.Blue,
          CornerRadius = new Vector4(0.5f, 0.5f, 0.5f, 0.5f),
          CornerRadiusPolicy = VisualTransformPolicyType.Relative,
        };
        win.Add(mousePoint);

        for (int i=0; i < 5; i++)
        {
          myAppsPoint[i] = new View()
          {
            Position = new Position((float)windowCenterX[i], (float)windowCenterY[i]),
            Size = new Size((float)windowRadius * 2.0f, (float)windowRadius * 2.0f),
            BackgroundColor = Color.Orange,
            CornerRadius = new Vector4(0.5f, 0.5f, 0.5f, 0.5f),
            CornerRadiusPolicy = VisualTransformPolicyType.Relative,
          };
          win.Add(myAppsPoint[i]);
        }

        win.TouchEvent += (s, e) =>
        {
          if (e.Touch.GetState(0) == PointStateType.Down)
          {
             Tizen.Log.Error("WhiteboardDnDDemo", "KTH MainWin Touch Down: " + e.Touch.GetScreenPosition(0).X + " " + e.Touch.GetScreenPosition(0).Y);
             Position currentPos =  new Position(e.Touch.GetScreenPosition(0).X, e.Touch.GetScreenPosition(0).Y);
             originPoint.PositionX = currentPos.X - 15.0f;
             originPoint.PositionY = currentPos.Y - 15.0f;
             
             originPointX = currentPos.X;
             originPointY = currentPos.Y;
          }
          else if (e.Touch.GetState(0) == PointStateType.Motion)
          {
             Tizen.Log.Error("WhiteboardDnDDemo", "KTH MainWin Touch Motion: " + e.Touch.GetScreenPosition(0).X + " " + e.Touch.GetScreenPosition(0).Y);
             Position currentPos =  new Position(e.Touch.GetScreenPosition(0).X, e.Touch.GetScreenPosition(0).Y);
             mousePoint.PositionX = currentPos.X - 15.0f;
             mousePoint.PositionY = currentPos.Y - 15.0f;

             double [] vec = new double[2];
             vec[0] = (double)(currentPos.X - originPointX);
             vec[1] = (double)(currentPos.Y - originPointY);

             //normalize
             double length = Math.Sqrt((vec[0] * vec[0] + vec[1] * vec[1]));
             vec[0] /= length;
             vec[1] /= length;

             for (int i = 0; i < 8; i++)
             {
               double [] h = new double[2];
               h[0] = circlePositionX[i] - originPointX;
               h[1] = circlePositionY[i] - originPointY;
               double lf = (vec[0] * h[0]) + (vec[1] * h[1]);
               double result = (circleRadius * circleRadius) - ((h[0] * h[0]) +( h[1] * h[1])) + (lf * lf);

               if (result < 0.0)
               {
                 Tizen.Log.Error("WhiteboardDnDDemo", "KTH MainWin Circle Collision: No");
                 TrayPoint[i].BackgroundColor = Color.Orange;
                 changeTrayItemBackground(i, false);
               }
               else
               {
                 Tizen.Log.Error("WhiteboardDnDDemo", "KTH MainWin Circle Collision: Collision");
                 TrayPoint[i].BackgroundColor = Color.Green;
                 changeTrayItemBackground(i, true);
               }
             }

             //MyApps Point
             for (int i=0; i<5; i++)
             {
                if (SubWindows[i])
                {
                    myAppsPoint[i].PositionX = SubWindows[i].WindowPosition.X + (SubWindows[i].WindowSize.Width / 2) - (myAppsPoint[i].Size.Width / 2);
                    myAppsPoint[i].PositionY = SubWindows[i].WindowPosition.Y + (SubWindows[i].WindowSize.Height / 2)- (myAppsPoint[i].Size.Height / 2);

                    windowCenterX[i] = SubWindows[i].WindowPosition.X + (SubWindows[i].WindowSize.Width / 2);
                    windowCenterY[i] = SubWindows[i].WindowPosition.Y + (SubWindows[i].WindowSize.Height / 2);
                    double [] h = new double[2];
                    h[0] = windowCenterX[i] - originPointX;
                    h[1] = windowCenterY[i] - originPointY;
                    double lf = (vec[0] * h[0]) + (vec[1] * h[1]);
                    double result = (windowRadius * windowRadius) - ((h[0] * h[0]) +( h[1] * h[1])) + (lf * lf);

                    if (result < 0.0)
                    {
                      Tizen.Log.Error("WhiteboardDnDDemo", "KTH MainWin Window Collision: No");
                      myAppsPoint[i].BackgroundColor = Color.Orange;
                      myAppsMainView[i].BackgroundColor = Color.White;
                      //changeTrayItemBackground(i, false);
                    }
                    else
                    {
                      Tizen.Log.Error("WhiteboardDnDDemo", "KTH MainWin Window Collision: Collision");
                      myAppsPoint[i].BackgroundColor = Color.Green;
                      myAppsMainView[i].BackgroundColor = new Color(0.984f, 0.862f, 0.784f, 1.0f);
                      //changeTrayItemBackground(i, true);
                    }
                }
             }
             
          }
          else if (e.Touch.GetState(0) == PointStateType.Up)
          {
            Tizen.Log.Error("WhiteboardDnDDemo", "KTH MainWin Touch Up: " + e.Touch.GetScreenPosition(0).X + " " + e.Touch.GetScreenPosition(0).Y);
            for (int i = 0; i < 8; i++)
             {
                 TrayPoint[i].BackgroundColor = Color.Orange;
                 changeTrayItemBackground(i, false);
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
