using System.Collections.Generic;
using System.Collections.ObjectModel;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;
using Tizen.NUI.Binding;
using Tizen.NUI;
using System.ComponentModel;
using System;

namespace NUIWindowBlur
{
  using log = Tizen.Log;
  class Gallery : INotifyPropertyChanged
  {
    string sourceDir = Tizen.Applications.Application.Current.DirectoryInfo.Resource + "gallery/gallery-medium-";
    private int index;
    private string name;
    private bool selected;

    public event PropertyChangedEventHandler PropertyChanged;

    private void OnPropertyyChanged(string propertyName)
    {

      PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public Gallery(int galleryIndex, string galleryName)
    {
      index = galleryIndex;
      name = galleryName;
    }

    public string Name
    {
      get
      {
        return name;
      }
      set
      {
        name = value;
        OnPropertyyChanged("Name");
        OnPropertyyChanged("ViewLabel");
      }
    }
    public string ViewLabel
    {
      get
      {
        return "[" + index + "] : " + name;
      }
    }

    public string ImageUrl
    {
      get
      {
        return sourceDir + (index % 20) + ".jpg";
      }
    }

    public bool Selected
    {
      get
      {
        return selected;
      }
      set
      {
        selected = value;
        OnPropertyyChanged("Selected");
      }
    }
  }

  class Album : ObservableCollection<Gallery>
  {
    private int index;
    private string name;
    private DateTime date;
    private bool selected;

    public Album(int albumIndex, string albumName, DateTime albumDate)
    {
      index = albumIndex;
      name = albumName;
      date = albumDate;
    }

    public string Title
    {
      get
      {
        return "[" + index + "] " + name;
      }
    }

    public string Date
    {
      get
      {
        return date.ToLongDateString();
      }
    }
    public bool Selected
    {
      get
      {
        return selected;
      }
      set
      {
        selected = value;
      }
    }
  }

  class GalleryViewModel : ObservableCollection<Gallery>
  {
    string[] namePool = {
        "Cat",
        "Boy",
        "Arm muscle",
        "Girl",
        "House",
        "Cafe",
        "Statue",
        "Sea",
        "hosepipe",
        "Police",
        "Rainbow",
        "Icicle",
        "Tower with the Moon",
        "Giraffe",
        "Camel",
        "Zebra",
        "Red Light",
        "Banana",
        "Lion",
        "Espresso",
    };
    public GalleryViewModel(int count)
    {
      CreateData(this, count);
    }

    public ObservableCollection<Gallery> CreateData(ObservableCollection<Gallery> result, int count)
    {
      for (int i = 0; i < count; i++)
      {
        result.Add(new Gallery(i, namePool[i % 20]));
      }
      return result;
    }
  }

  class AlbumViewModel : ObservableCollection<Album>
  {
    string[] namePool = {
        "Cat",
        "Boy",
        "Arm muscle",
        "Girl",
        "House",
        "Cafe",
        "Statue",
        "Sea",
        "hosepipe",
        "Police",
        "Rainbow",
        "Icicle",
        "Tower with the Moon",
        "Giraffe",
        "Camel",
        "Zebra",
        "Red Light",
        "Banana",
        "Lion",
        "Espresso",
    };

    (string name, DateTime date)[] titlePool = {
        ("House Move", new DateTime(2021, 2, 26)),
        ("Covid 19", new DateTime(2020, 1, 20)),
        ("Porto Trip", new DateTime(2019, 11, 23)),
        ("Granada Trip", new DateTime(2019, 11, 20)),
        ("Barcelona Trip", new DateTime(2019, 11, 17)),
        ("Developer's Day", new DateTime(2019, 11, 16)),
        ("Tokyo Trip", new DateTime(2019, 7, 5)),
        ("Otaru Trip", new DateTime(2019, 3, 2)),
        ("Sapporo Trip", new DateTime(2019, 2, 28)),
        ("Hakodate Trip", new DateTime(2019, 2, 26)),
        ("Friend's Wedding", new DateTime(2018, 11, 23)),
        ("Grandpa Birthday", new DateTime(2018, 9, 14)),
        ("Family Jeju Trip", new DateTime(2018, 7, 15)),
        ("HongKong Trip", new DateTime(2018, 3, 30)),
        ("Mom's Birthday", new DateTime(2017, 12, 21)),
        ("Buy new Car", new DateTime(2017, 10, 18)),
        ("Graduation", new DateTime(2017, 6, 30)),
    };

    public AlbumViewModel()
    {
      CreateData(this);
    }

    public ObservableCollection<Album> CreateData(ObservableCollection<Album> result)
    {
      for (int i = 0; i < titlePool.Length; i++)
      {
        (string name, DateTime date) = titlePool[i];
        Album cur = new Album(i, name, date);
        for (int j = 0; j < 20; j++)
        {
          cur.Add(new Gallery(j, namePool[j]));
        }
        result.Add(cur);
      }
      return result;
    }

  }

  class Program : NUIApplication
  {
    string tag = "NUITEST";
    private const string KEY_BACK = "XF86Back";
    private const string KEY_ESCAPE = "Escape";
    private const string KEY_NUM_1 = "1";
    private const string KEY_NUM_2 = "2";
    private const string KEY_NUM_3 = "3";
    private const string KEY_NUM_4 = "4";
    private const string KEY_NUM_5 = "5";
    private const string KEY_NUM_6 = "6";
    private const string KEY_NUM_7 = "7";
    private const string KEY_NUM_8 = "8";
    private const string KEY_NUM_9 = "9";
    private const string KEY_NUM_0 = "0";
    CollectionView colView;
    int itemCount = 500;
    string selectedItem;
    ObservableCollection<Gallery> gallerySource;
    Gallery moveMenu;

    //static string title = "NUI Auto TCT \n\n";
    private Window mainWindow = null;
    private Window windowForBackground = null;
    private Window windowForBehind = null;

    private static readonly string imagePath = Tizen.Applications.Application.Current.DirectoryInfo.Resource + "/images/";

    protected override void OnCreate()
    {
      base.OnCreate();
      Initialize();
    }

    public Program(WindowData windowData) : base(ThemeOptions.None, windowData)
    {
      log.Error("NUI", $"Application is created with default border\n");
    }

    class CustomBorder : DefaultBorder
    {
      private static readonly string ResourcePath = Tizen.Applications.Application.Current.DirectoryInfo.Resource;
      private static readonly string MinimalizeIcon = ResourcePath + "/images/minimalize.png";
      private static readonly string MaximalizeIcon = ResourcePath + "/images/maximalize.png";
      private static readonly string RestoreIcon = ResourcePath + "/images/smallwindow.png";
      private static readonly string CloseIcon = ResourcePath + "/images/close.png";
      private static readonly string LeftCornerIcon = ResourcePath + "/images/leftCorner.png";
      private static readonly string RightCornerIcon = ResourcePath + "/images/rightCorner.png";

      private int width = 500;
      private bool hide = false;
      private View borderView;
      private TextLabel title;

      private ImageView minimalizeIcon;
      private ImageView maximalizeIcon;
      private ImageView closeIcon;
      private ImageView leftCornerIcon;
      private ImageView rightCornerIcon;

      private Rectangle preWinPositonSize;

      public CustomBorder() : base()
      {
        BorderHeight = 50;
        OverlayMode = true;
        BorderLineThickness = 0;
      }

      public override bool CreateTopBorderView(View topView)
      {
        if (topView == null)
        {
          return false;
        }
        topView.Layout = new LinearLayout()
        {
          LinearOrientation = LinearLayout.Orientation.Horizontal,
          VerticalAlignment = VerticalAlignment.Center,
          HorizontalAlignment = HorizontalAlignment.Center,
          CellPadding = new Size2D(20, 20),
        };
        title = new TextLabel()
        {
          Text = "Gallery",
          HorizontalAlignment = HorizontalAlignment.Center,
          VerticalAlignment = VerticalAlignment.Center,
        };

        BorderWindow.EnableFloatingMode(true);
        topView.Add(title);
        return true;
      }

      public override bool CreateBottomBorderView(View bottomView)
      {
        if (bottomView == null)
        {
          return false;
        }
        bottomView.Layout = new RelativeLayout();

        minimalizeIcon = new ImageView()
        {
          ResourceUrl = MinimalizeIcon,
          AccessibilityHighlightable = true,
        };

        maximalizeIcon = new ImageView()
        {
          ResourceUrl = MaximalizeIcon,
          AccessibilityHighlightable = true,
        };

        closeIcon = new ImageView()
        {
          ResourceUrl = CloseIcon,
          AccessibilityHighlightable = true,
        };

        leftCornerIcon = new ImageView()
        {
          ResourceUrl = LeftCornerIcon,
          AccessibilityHighlightable = true,
        };

        rightCornerIcon = new ImageView()
        {
          ResourceUrl = RightCornerIcon,
          AccessibilityHighlightable = true,
        };

        RelativeLayout.SetRightTarget(minimalizeIcon, maximalizeIcon);
        RelativeLayout.SetRightRelativeOffset(minimalizeIcon, 0.0f);
        RelativeLayout.SetHorizontalAlignment(minimalizeIcon, RelativeLayout.Alignment.End);
        RelativeLayout.SetRightTarget(maximalizeIcon, closeIcon);
        RelativeLayout.SetRightRelativeOffset(maximalizeIcon, 0.0f);
        RelativeLayout.SetHorizontalAlignment(maximalizeIcon, RelativeLayout.Alignment.End);
        RelativeLayout.SetRightTarget(closeIcon, rightCornerIcon);
        RelativeLayout.SetRightRelativeOffset(closeIcon, 0.0f);
        RelativeLayout.SetHorizontalAlignment(closeIcon, RelativeLayout.Alignment.End);
        RelativeLayout.SetRightRelativeOffset(rightCornerIcon, 1.0f);
        RelativeLayout.SetHorizontalAlignment(rightCornerIcon, RelativeLayout.Alignment.End);
        bottomView.Add(leftCornerIcon);
        bottomView.Add(minimalizeIcon);
        bottomView.Add(maximalizeIcon);
        bottomView.Add(closeIcon);
        bottomView.Add(rightCornerIcon);


        minimalizeIcon.TouchEvent += OnMinimizeIconTouched;
        maximalizeIcon.TouchEvent += OnMaximizeIconTouched;
        closeIcon.TouchEvent += OnCloseIconTouched;
        leftCornerIcon.TouchEvent += OnLeftBottomCornerIconTouched;
        rightCornerIcon.TouchEvent += OnRightBottomCornerIconTouched;

        minimalizeIcon.AccessibilityActivated += (s, e) =>
        {
          MinimizeBorderWindow();
        };
        maximalizeIcon.AccessibilityActivated += (s, e) =>
        {
          MaximizeBorderWindow();
        };
        closeIcon.AccessibilityActivated += (s, e) =>
        {
          CloseBorderWindow();
        };

        minimalizeIcon.AccessibilityNameRequested += (s, e) =>
        {
          e.Name = "Minimize";
        };
        maximalizeIcon.AccessibilityNameRequested += (s, e) =>
        {
          e.Name = "Maximize";
        };
        closeIcon.AccessibilityNameRequested += (s, e) =>
        {
          e.Name = "Close";
        };
        leftCornerIcon.AccessibilityNameRequested += (s, e) =>
        {
          e.Name = "Resize";
        };
        rightCornerIcon.AccessibilityNameRequested += (s, e) =>
        {
          e.Name = "Resize";
        };

        minimalizeIcon.SetAccessibilityReadingInfoTypes(Tizen.NUI.BaseComponents.AccessibilityReadingInfoTypes.Name);
        maximalizeIcon.SetAccessibilityReadingInfoTypes(Tizen.NUI.BaseComponents.AccessibilityReadingInfoTypes.Name);
        closeIcon.SetAccessibilityReadingInfoTypes(Tizen.NUI.BaseComponents.AccessibilityReadingInfoTypes.Name);
        leftCornerIcon.SetAccessibilityReadingInfoTypes(Tizen.NUI.BaseComponents.AccessibilityReadingInfoTypes.Name);
        rightCornerIcon.SetAccessibilityReadingInfoTypes(Tizen.NUI.BaseComponents.AccessibilityReadingInfoTypes.Name);

        return true;
      }

      public override void CreateBorderView(View borderView)
      {
        this.borderView = borderView;
        borderView.CornerRadius = new Vector4(0.30f, 0.30f, 0.30f, 0.30f);
        borderView.CornerRadiusPolicy = VisualTransformPolicyType.Relative;
        borderView.BackgroundColor = new Color(1, 1, 1, 0.3f);
      }

      public override void OnCreated(View borderView)
      {
        base.OnCreated(borderView);
        UpdateIcons();
      }

      public override bool OnCloseIconTouched(object sender, View.TouchEventArgs e)
      {
        base.OnCloseIconTouched(sender, e);
        return true;
      }

      public override bool OnMinimizeIconTouched(object sender, View.TouchEventArgs e)
      {
        if (e.Touch.GetState(0) == PointStateType.Up)
        {
          if (BorderWindow.IsMaximized() == true)
          {
            BorderWindow.Maximize(false);
          }
          preWinPositonSize = BorderWindow.WindowPositionSize;
          BorderWindow.WindowPositionSize = new Rectangle(preWinPositonSize.X, preWinPositonSize.Y, 500, 0);
        }
        return true;
      }

      public override void OnRequestResize()
      {
        if (borderView != null)
        {
          borderView.BackgroundColor = new Color(0, 1, 0, 0.3f); // 보더의 배경을 변경할 수 있습니다.
        }
      }

      public override void OnResized(int width, int height)
      {
        if (borderView != null)
        {
          if (this.width > width && hide == false)
          {
            title.Hide();
            hide = true;
          }
          else if (this.width < width && hide == true)
          {
            title.Show();
            hide = false;
          }
          borderView.BackgroundColor = new Color(1, 1, 1, 0.3f); //  리사이즈가 끝나면 보더의 색깔은 원래대로 돌려놓습니다.
          base.OnResized(width, height);
          UpdateIcons();
        }
      }

      private void UpdateIcons()
      {
        if (BorderWindow != null && borderView != null)
        {
          if (BorderWindow.IsMaximized() == true)
          {
            if (maximalizeIcon != null)
            {
              maximalizeIcon.ResourceUrl = RestoreIcon;
            }
          }
          else
          {
            if (maximalizeIcon != null)
            {
              maximalizeIcon.ResourceUrl = MaximalizeIcon;
            }
          }
        }
      }
    }

    public void OnWindowForBehindKeyEvent(object sender, Window.KeyEventArgs e)
    {
      if (e.Key.State == Key.StateType.Down && (e.Key.KeyPressedName == "XF86Back" || e.Key.KeyPressedName == "Escape"))
      {
        Exit();
      }
    }

    void CreateWindowForBehindBlur()
    {
      if (windowForBehind == null)
      {
        CustomBorder customBorder = new CustomBorder();
        windowForBehind = new Window("windowForBehind", customBorder, new Rectangle(100, 700, 500, 200), false);
        windowForBackground.SetTransparency(false);
        windowForBehind.BackgroundColor = new Color(1.0f, 1.0f, 1.0f, 1.0f);
        windowForBehind.BlurInfo = new WindowBlurInfo(WindowBlurType.Behind, 60);

        windowForBehind.InterceptTouchEvent += (s, e) =>
        {
          log.Error(tag, $"windowForBehind.InterceptTouchEvent\n");
          if (e.Touch.GetState(0) == PointStateType.Down)
          {
            customBorder.OverlayBorderShow();
          }
          return false;
        };

        windowForBehind.KeyEvent += OnWindowForBehindKeyEvent;

        var viewContainer = new View()
        {
          PositionUsesPivotPoint = true,
          PivotPoint = PivotPoint.Center,
          ParentOrigin = ParentOrigin.Center,            
          Size = new Size(150, 180),
          Layout = new LinearLayout()
          {
            HorizontalAlignment = HorizontalAlignment.Center,
            VerticalAlignment = VerticalAlignment.Center,
            LinearOrientation = LinearLayout.Orientation.Vertical,
          },
          AccessibilityHighlightable = true,
        };
        windowForBehind.Add(viewContainer);

        var imageViewB = new ImageView()
        {
          Size = new Size(150, 150),
          ResourceUrl = imagePath + "behind.jpg",
          CornerRadius = 0.3f,
          CornerRadiusPolicy = VisualTransformPolicyType.Relative,
        };
        var textViewB = new TextLabel()
        {
          Text = "Behind Test",
        };

        viewContainer.Add(imageViewB);
        viewContainer.Add(textViewB);

      }
      else
      {
        windowForBehind.Minimize(false);
      }
    }

    private void OnwindowForBackgroundKeyEvent(object sender, Window.KeyEventArgs e)
    {
      if (e.Key.State == Key.StateType.Down)
      {
        log.Error(tag, $"key down! key={e.Key.KeyPressedName}");

        switch (e.Key.KeyPressedName)
        {
          case KEY_BACK:
          case KEY_ESCAPE:
            windowForBackground.Dispose();
            break;

          case KEY_NUM_1:
            WindowBlurInfo blurInfo = windowForBackground.BlurInfo;
            log.Fatal(tag, $"blur type={blurInfo.BlurType}");
            log.Fatal(tag, $"blur radius={blurInfo.BlurRadius}");
            log.Fatal(tag, $"background Corner Radius={blurInfo.BackgroundCornerRadius}");
            blurInfo.BlurType = WindowBlurType.Background;
            blurInfo.BlurRadius += 10;
            blurInfo.BackgroundCornerRadius += 10;
            windowForBackground.BlurInfo = blurInfo;
            break;

          case KEY_NUM_2:
            CreateWindowForBehindBlur();
            break;

          default:
            log.Debug(tag, $"no test!");
            break;
        }
      }
    }

    void CreateWindowForBackgroundBlur()
    {
      if (windowForBackground == null)
      {
        CustomBorder customBorder = new CustomBorder();
        windowForBackground = new Window("windowForBackground", customBorder, new Rectangle(600, 100, 520, 760), false);
        windowForBackground.SetTransparency(true);
        windowForBackground.BackgroundColor = new Color(0.0f, 0.0f, 0.0f, 0.0f);
        windowForBackground.BlurInfo = new WindowBlurInfo(WindowBlurType.Background, 60, 60);

        windowForBackground.KeyEvent += OnwindowForBackgroundKeyEvent;

        windowForBackground.InterceptTouchEvent += (s, e) =>
        {
          log.Error(tag, $"windowForBackground.InterceptTouchEvent\n");
          if (e.Touch.GetState(0) == PointStateType.Down)
          {
            customBorder.OverlayBorderShow();
          }
          return false;
        };

        InitwindowForBackground();
      }
      else
      {
        windowForBackground.Minimize(false);
      }
    }

    public void InitwindowForBackground()
    {
      moveMenu = new Gallery(10, "Move last item to 3rd");

      var myViewModelSource = gallerySource = new GalleryViewModel(itemCount);
      // Add test menu options.
      gallerySource.Insert(0, moveMenu);

      colView = new CollectionView()
      {
        ItemsSource = myViewModelSource,
        ItemsLayouter = new LinearLayouter(),
        ItemTemplate = new DataTemplate(() =>
        {
          var rand = new Random();
          DefaultLinearItem item = new DefaultLinearItem();
          //Set Width Specification as MatchParent to fit the Item width with parent View.
          item.WidthSpecification = LayoutParamPolicies.MatchParent;

          //Decorate Label
          item.Label.SetBinding(TextLabel.TextProperty, "ViewLabel");
          item.Label.HorizontalAlignment = HorizontalAlignment.Begin;

          //Decorate Icon
          item.Icon.SetBinding(ImageView.ResourceUrlProperty, "ImageUrl");
          item.Icon.WidthSpecification = 60;
          item.Icon.HeightSpecification = 60;

          return item;
        }),
        ScrollingDirection = ScrollableBase.Direction.Vertical,
        WidthSpecification = LayoutParamPolicies.MatchParent,
        HeightSpecification = LayoutParamPolicies.MatchParent,
      };

      windowForBackground.Add(colView);
    }


    public void SelectionEvt(object sender, SelectionChangedEventArgs ev)
    {
      //SingleSelection Only have 1 or nil object in the list.
      foreach (object item in ev.PreviousSelection)
      {
        if (item == null) break;
        Gallery unselItem = (Gallery)item;

        unselItem.Selected = false;
        selectedItem = null;
        //Tizen.Log.Debug("NUI", "LSH :: Unselected: {0}", unselItem.ViewLabel);
      }
      foreach (object item in ev.CurrentSelection)
      {
        if (item == null) break;
        Gallery selItem = (Gallery)item;
        //selItem.Selected = true;
        selectedItem = selItem.Name;

        // Check test menu options.
        if (selItem == moveMenu)
        {
          // Move last indexed item to index 3.
          gallerySource.Move(gallerySource.Count - 1, 3);
        }
      }
    }

    public void OnKeyEvent(object sender, Window.KeyEventArgs e)
    {
      if (e.Key.State == Key.StateType.Down && (e.Key.KeyPressedName == "XF86Back" || e.Key.KeyPressedName == "Escape"))
      {
        Exit();
      }
    }

    void Initialize()
    {
      mainWindow = NUIApplication.GetDefaultWindow();
      mainWindow.SetTransparency(true);
      mainWindow.BackgroundColor = new Color(0.0f, 0.0f, 0.0f, 0.0f);
      mainWindow.BlurInfo = new WindowBlurInfo(WindowBlurType.Background, 60, 10);

      mainWindow.KeyEvent += OnKeyEvent;

      var appFunctionList = new View()
      {
        PositionUsesPivotPoint = true,
        PivotPoint = PivotPoint.BottomCenter,
        ParentOrigin = ParentOrigin.BottomCenter,
        BackgroundColor = new Color(0.0f, 0.0f, 0.0f, 0.0f),
        Size = new Size(520, 200),
        CornerRadius = 0.3f,
        CornerRadiusPolicy = VisualTransformPolicyType.Relative,
        Layout = new LinearLayout()
        {
          HorizontalAlignment = HorizontalAlignment.Center,
          LinearOrientation = LinearLayout.Orientation.Horizontal,
          CellPadding = new Size(10, 10),
          Padding = new Extents(10, 10, 10, 10),
        }
      };
      mainWindow.Add(appFunctionList);

      var customBorder = new View()
      {
        Size = new Size(150, 180),
        Layout = new LinearLayout()
        {
          HorizontalAlignment = HorizontalAlignment.Center,
          VerticalAlignment = VerticalAlignment.Center,
          LinearOrientation = LinearLayout.Orientation.Vertical,
        },
        AccessibilityHighlightable = true,
      };

      var imageViewB = new ImageView()
      {
        Size = new Size(150, 150),
        ResourceUrl = imagePath + "Wing.jpg",
        CornerRadius = 0.3f,
        CornerRadiusPolicy = VisualTransformPolicyType.Relative,
      };
      var textViewB = new TextLabel()
      {
        Text = "Gallery",
      };

      customBorder.Add(imageViewB);
      customBorder.Add(textViewB);
      appFunctionList.Add(customBorder);
      customBorder.TouchEvent += (s, e) =>
      {
        if (e.Touch.GetState(0) == PointStateType.Up)
        {
          CreateWindowForBackgroundBlur();
        }
        return true;
      };
      customBorder.AccessibilityActivated += (s, e) =>
      {
        CreateWindowForBackgroundBlur();
      };
    }

    static void Main(string[] args)
    {
      WindowData newWindowData = new WindowData();
      newWindowData.BorderInterface = new DefaultBorder();
      newWindowData.WindowMode = WindowMode.Transparent;
      newWindowData.PositionSize = new Rectangle(100, 100, 520, 300);
      var app = new Program(newWindowData);
      app.Run(args);
    }
  }
}
