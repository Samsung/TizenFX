
using System;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;
using System.Collections.Generic;

namespace Tizen.NUI.Samples
{
  public class WhiteboardDnDTest : IExample
  {
    private Window win;
    private Window allAppsWindow = null;
    private Window myAppsWindow = null;
    private Window trayWindow = null;
    private Window galleryWindow = null;
    private Window emailWindow = null;
    private Window facebookWindow = null;
    private View shadowView = null;
    private View myAppsView = null;
    private ImageView galleryView = null;
    private TextEditor inputContent = null;
    private int startAppFlag = 0;

    private LongPressGestureDetector [] itemLongPressed = new LongPressGestureDetector[10];
    private LongPressGestureDetector textLongPressed = null;
    private LongPressGestureDetector itemLongPressed1 = null;
    private LongPressGestureDetector itemLongPressed2 = null;
    

    private static readonly string imagePath = Tizen.Applications.Application.Current.DirectoryInfo.Resource + "/images/Dali/";

    private string [] itemNameArr = new string [] {
                               "facebook", "netflix", "spoti",
                               "chrome", "instagram", "pinterest",
                               "hbo", "linkedin", "youtube"};

    private float fontScale = 5;
    DragAndDrop dnd;

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
      if (galleryWindow == null)
      {
        galleryWindow = new Window("GalleryWindow", new Rectangle(1250, 100, 400, 400), false);
        galleryWindow.EnableBorderWindow();

        var mainView = new View()
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

        galleryWindow.Add(mainView);
        mainView.Add(title);
        mainView.Add(view);

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
        galleryWindow.Minimize(false);
      }
    }

    void CreateEmail()
    {
      if (emailWindow == null)
      {
        emailWindow = new Window("EmailWindow", new Rectangle(1250, 100, 400, 400), false);
        emailWindow.EnableBorderWindow();

        var mainView = new View()
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
        };

        var title = new TextLabel() {
            Text = "E-mail",
            PointSize = 4 * fontScale,
            HorizontalAlignment = HorizontalAlignment.Center,
            Padding = new Extents(35,0,20,0),
        };

        emailWindow.Add(mainView);
        mainView.Add(title);

        var labelSender = new TextLabel() {
            Text = "sender : taehyub.kim@samsung.com",
            PointSize = 3 * fontScale,
            HorizontalAlignment = HorizontalAlignment.Begin,
            Padding = new Extents(10,0,10,0),
        };
        mainView.Add(labelSender);

        var labelReceiver = new TextLabel() {
            Text = "receiver : hyunju.shin@samsung.com",
            PointSize = 3 * fontScale,
            HorizontalAlignment = HorizontalAlignment.Begin,
            Padding = new Extents(10,0,10,0),
        };
        mainView.Add(labelReceiver);

        var labelTitle = new TextLabel() {
            Text = "title : DnD and Window Border!",
            PointSize = 3 * fontScale,
            HorizontalAlignment = HorizontalAlignment.Begin,
            Padding = new Extents(10,0,10,0),
        };
        mainView.Add(labelTitle);

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
        mainView.Add(menuView);

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
        mainView.Add(inputContent); 
      }
      else
      {
        emailWindow.Minimize(false);
      }
    }
    void CreateFacebook()
    {
      if (facebookWindow == null)
      {
        facebookWindow = new Window("FacebookWindow", new Rectangle(1250, 100, 400, 400), false);
        facebookWindow.EnableBorderWindow();

        var mainView = new View()
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
        };

        var title = new TextLabel() {
            Text = "Facebook",
            PointSize = 4 * fontScale,
            HorizontalAlignment = HorizontalAlignment.Center,
            Padding = new Extents(35,0,20,0),
        };

        facebookWindow.Add(mainView);
        mainView.Add(title);

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
        mainView.Add(profileView);

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
        mainView.Add(content);
        textLongPressed = new LongPressGestureDetector();
        textLongPressed.Attach(content);
        textLongPressed.Detected += (s, e) =>
        {
          if(e.LongPressGesture.State == Gesture.StateType.Started)
          {
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
        mainView.Add(attachImageView);

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
        mainView.Add(menuView);

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
        facebookWindow.Minimize(false);
      }
    }

    void CreateAllApps()
    {
      if (allAppsWindow == null)
      {
        allAppsWindow = new Window("subwin1", new Rectangle(100, 207, 550, 500), false);
        allAppsWindow.EnableBorderWindow();

        var mainView = new View()
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

        allAppsWindow.Add(mainView);
        mainView.Add(title);
        mainView.Add(view);

        for(int i = 0;  i < 9; i++)
        {
          var itemView = CreateItem(Tizen.Applications.Application.Current.DirectoryInfo.SharedResource + itemNameArr[i] + ".png", itemNameArr[i]);
          itemView.Name = itemNameArr[i];

          itemLongPressed[i] = new LongPressGestureDetector();
          itemLongPressed[i].Attach(itemView);
          itemLongPressed[i].Detected += (s, e) =>
          {
            if(e.LongPressGesture.State == Gesture.StateType.Started)
            {
              Tizen.Log.Error("WhiteboardDnDDemo", "KTH StartDragAndDrop with LongPress!!! " + itemView.Name);
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
        allAppsWindow.Minimize(false);
      }
    }

    // allAppsWindow
    // myAppsWindow
    // trayWindow
    // galleryWindow
    // emailWindow
    // facebookWindow
    // Start DnD ID?
    // Data Type Text or Image
    // if Drop Position == Window then add window's app

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
      
      if (IsDroppedInWindow(myAppsWindow, position))
        return 1;

      /*
      else if(IsDroppedInWindow(myAppsWindow, position))
        return 2;
      else if(IsDroppedInWindow(trayWindow, position))
        return 3;
      else if(IsDroppedInWindow(galleryWindow, position))
        return 4;
      else if(IsDroppedInWindow(emailWindow, position))
        return 5;
      else if(IsDroppedInWindow(facebookWindow, position))
        return 6;
        */
      else
        return 0;
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
        }
        else if (dragEvent.DragType == DragType.Drop)
        {
          int demoAppID = GetDemoAppID(dragEvent.Position);
          Tizen.Log.Error("WhiteboardDnDDemo", "KTH Drop Window : " + demoAppID);

          if (dragEvent.MimeType == "text/uri-list/allaps")
          {
              string[] itemData = dragEvent.Data.Split(',');
              Tizen.Log.Error("WhiteboardDnDDemo", "KTH Drop " + dragEvent.Position.X + " " + dragEvent.Position.Y + " " + itemData[0] + " " + itemData[1]);
              var itemView = CreateItem(itemData[0], itemData[1]);
              myAppsView.Add(itemView);
          }
          else if (dragEvent.MimeType == "text/uri-list/fbimage")
          {
            if (galleryView)
            {
              galleryView.ResourceUrl = dragEvent.Data;
            }
          }
          else if (dragEvent.MimeType == "text/uri-list/fbtext")
          {
            if (inputContent)
            {
              inputContent.Text = dragEvent.Data;
            }
          }
        }
    }

    void CreateMyApps()
    {
      if (myAppsWindow == null)
      {
        myAppsWindow = new Window("subwin1", new Rectangle(800, 250, 600, 350), false);
        myAppsWindow.EnableBorderWindow();

        var mainView = new View()
        {
         Layout = new LinearLayout()
         {
           LinearOrientation = LinearLayout.Orientation.Vertical,
           //HorizontalAlignment = HorizontalAlignment.Center,
           //VerticalAlignment = VerticalAlignment.Center,
         },
         WidthSpecification = LayoutParamPolicies.MatchParent,
         HeightSpecification = LayoutParamPolicies.MatchParent,
         BackgroundColor = Color.White,
         CornerRadius = new Vector4(0.03f, 0.03f, 0.03f, 0.03f),
         CornerRadiusPolicy = VisualTransformPolicyType.Relative,
        };

        var title = new TextLabel() {
            Text = "My apps",
            PointSize = 4 * fontScale,
            HorizontalAlignment = HorizontalAlignment.Center,
            Padding = new Extents(35,0,20,0),
        };

        mainView.Add(title);

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

        myAppsWindow.Add(mainView);
        mainView.Add(myAppsView);

        var faceBookItem = CreateItem(Tizen.Applications.Application.Current.DirectoryInfo.SharedResource + "facebook.png", "facebook");
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
        myAppsWindow.Minimize(false);
      }
    }

    void CreateTrayApps()
    {
      if (trayWindow == null)
      {
        trayWindow = new Window("TrayWindow", new Rectangle(1700, 167, 200, 750), false);
        //myAppsWindow.EnableBorderWindow();
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
        };

        trayWindow.Add(mainView);

        var galleryItem = new ImageView()
        {
          Size = new Size(160, 160),
          ResourceUrl = Tizen.Applications.Application.Current.DirectoryInfo.SharedResource + "gallery.png",
        };
        mainView.Add(galleryItem);
        galleryItem.TouchEvent += (s, e) =>
        {
          if (e.Touch.GetState(0) == PointStateType.Up)
          {
            CreateGallery();
            galleryItem.ResourceUrl = Tizen.Applications.Application.Current.DirectoryInfo.SharedResource + "gallery.png";
          }
          else if (e.Touch.GetState(0) == PointStateType.Down)
          {
            galleryItem.ResourceUrl = Tizen.Applications.Application.Current.DirectoryInfo.SharedResource + "galleryp.png";
          }
          return true;
        };

        var emailItem = new ImageView()
        {
          Size = new Size(160, 160),
          ResourceUrl = Tizen.Applications.Application.Current.DirectoryInfo.SharedResource + "email.png",
        };
        mainView.Add(emailItem);
        emailItem.TouchEvent += (s, e) =>
        {
          if (e.Touch.GetState(0) == PointStateType.Up)
          {
            CreateEmail();
            emailItem.ResourceUrl = Tizen.Applications.Application.Current.DirectoryInfo.SharedResource + "email.png";
          }
          else if (e.Touch.GetState(0) == PointStateType.Down)
          {
            emailItem.ResourceUrl = Tizen.Applications.Application.Current.DirectoryInfo.SharedResource + "emailp.png";
          }
          return true;
        };

        var memoItem = new ImageView()
        {
          Size = new Size(160, 160),
          ResourceUrl = Tizen.Applications.Application.Current.DirectoryInfo.SharedResource + "memo.png"          
        };
        mainView.Add(memoItem);
        memoItem.TouchEvent += (s, e) =>
        {
          if (e.Touch.GetState(0) == PointStateType.Up)
          {
            CreateMyApps();
            memoItem.ResourceUrl = Tizen.Applications.Application.Current.DirectoryInfo.SharedResource + "memo.png";
          }
          else if (e.Touch.GetState(0) == PointStateType.Down)
          {
            memoItem.ResourceUrl = Tizen.Applications.Application.Current.DirectoryInfo.SharedResource + "memop.png";
          }
          return true;
        };

        var allAppsItem = new ImageView()
        {
          Size = new Size(160, 160),
          ResourceUrl = Tizen.Applications.Application.Current.DirectoryInfo.SharedResource + "allapps.png",
        };
        mainView.Add(allAppsItem);
        

        allAppsItem.TouchEvent += (s, e) =>
        {
          if (e.Touch.GetState(0) == PointStateType.Up)
          {
            CreateAllApps();
            allAppsItem.ResourceUrl = Tizen.Applications.Application.Current.DirectoryInfo.SharedResource + "allapps.png";
          }
          else if (e.Touch.GetState(0) == PointStateType.Down)
          {
            allAppsItem.ResourceUrl = Tizen.Applications.Application.Current.DirectoryInfo.SharedResource + "allappsp.png";
          }
          return true;
        };
      }
      else
      {
        trayWindow.Minimize(false);
      }
    }

    private void OnMainViewTouch(object sender, Window.TouchEventArgs e)
    {
      Tizen.Log.Error("WhiteboardDnDDemo", "KTH Main Window Move ");
      Vector2 position = e.Touch.GetScreenPosition(0);
      if (e.Touch.GetState(0) == PointStateType.Motion)
      {
      //  Tizen.Log.Error("WhiteboardDnDDemo", "KTH Main Window Move " + position.X + " " + position.Y);
      }
    }

    private bool OnHoverEvent(object source, View.HoverEventArgs e)
    {
        Tizen.Log.Error("WhiteboardDnDDemo", "KTH HoverEvent"); 
        return false;
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
          }
        };
        win.Add(root);
        dnd.AddListener(root, OnRootViewDnDFunc);
        CreateTrayApps();
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
