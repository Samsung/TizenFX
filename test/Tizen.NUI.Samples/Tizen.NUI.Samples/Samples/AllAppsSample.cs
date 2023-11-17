
using System;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;
using System.Collections.Generic;


namespace Tizen.NUI.Samples
{
  public class AllApps : IExample
  {
    private Window win;
    private Window subWindowOne = null;
    private Window subWindowTwo = null;

    private static readonly string imagePath = Tizen.Applications.Application.Current.DirectoryInfo.Resource + "/images/Dali/";

    private string [] itemNameArr = new string [] {
                               "igtv", "netflix", "spoti",
                               "google chrome", "instagram", "pinterest",
                               "hbo", "linkedin", "youtube"
                               };

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

      var child = new ImageView() {
        WidthSpecification = 120,
        HeightSpecification = 90,
        ResourceUrl = file,
        Margin = 2,
      };

      var itemName = new TextLabel() {
        Text = name,
        PointSize = 3,
        HorizontalAlignment = HorizontalAlignment.Center,
        Margin = 5,
      };

      itemView.Add(child);
      itemView.Add(itemName);

      GridLayout.SetHorizontalStretch(itemView, GridLayout.StretchFlags.Expand);
      GridLayout.SetVerticalStretch(itemView, GridLayout.StretchFlags.Expand);
      GridLayout.SetHorizontalAlignment(itemView, GridLayout.Alignment.Center);
      GridLayout.SetVerticalAlignment(itemView, GridLayout.Alignment.Center);

      return itemView;
    }

    void CreateSubWindowOne()
    {
      if (subWindowOne == null)
      {
        subWindowOne = new Window("subwin1", null, new Rectangle(1300, 250, 550, 500), false);

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
            PointSize = 4,
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

        subWindowOne.Add(mainView);
        mainView.Add(title);
        mainView.Add(view);

        for(int i = 0;  i < 9; i++)
        {
          var itemView = CreateItem(Tizen.Applications.Application.Current.DirectoryInfo.SharedResource + itemNameArr[i] + ".png", itemNameArr[i]);
          itemView.Name = itemNameArr[i];
          view.Add(itemView);
        }
      }
      else
      {
        subWindowOne.Minimize(false);
      }
    }
    void CreateSubWindowTwo()
    {
      if (subWindowTwo == null)
      {
        subWindowTwo = new Window("subwin1", null, new Rectangle(60, 600, 600, 250), false);

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
            Text = "My apps",
            PointSize = 4,
            HorizontalAlignment = HorizontalAlignment.Center,
            Padding = new Extents(35,0,20,0),
        };

        mainView.Add(title);

        // Create My Apps Items
        var view = new View()
        {
          Layout = new GridLayout()
          {
            Columns = 3,
            Rows = 1,
          },
          WidthSpecification = LayoutParamPolicies.MatchParent,
          HeightSpecification = LayoutParamPolicies.MatchParent,
        };

        subWindowTwo.Add(mainView);
        mainView.Add(view);

        var itemView = CreateItem(Tizen.Applications.Application.Current.DirectoryInfo.SharedResource + "spoti.png", "spotify");
        view.Add(itemView);
        var itemView2 = CreateItem(Tizen.Applications.Application.Current.DirectoryInfo.SharedResource + "instagram.png", "instagram");
        view.Add(itemView2);
      }
      else
      {
        subWindowTwo.Minimize(false);
      }
    }

    void Initialize()
    {
        win = NUIApplication.GetDefaultWindow();
        var root = new ImageView()
        {
          WidthResizePolicy = ResizePolicyType.FillToParent,
          HeightResizePolicy = ResizePolicyType.FillToParent,
          ResourceUrl = imagePath + "download2.jpeg",
          Layout = new LinearLayout()
          {
              HorizontalAlignment = HorizontalAlignment.Center,
              LinearOrientation = LinearLayout.Orientation.Horizontal,
              CellPadding = new Size(10, 10),
          }


        };
        win.Add(root);

        var imageViewA = new ImageView()
        {
          PositionUsesPivotPoint = true,
          PivotPoint = PivotPoint.BottomLeft,
          ParentOrigin = ParentOrigin.BottomLeft,
          Size = new Size(150, 150),
          ResourceUrl = imagePath + "background.jpg",
          CornerRadius = 0.3f,
          CornerRadiusPolicy = VisualTransformPolicyType.Relative,
        };
        root.Add(imageViewA);
        imageViewA.TouchEvent += (s, e) =>
        {
          if (e.Touch.GetState(0) == PointStateType.Up)
          {
            CreateSubWindowOne();
          }
          return true;
        };

        var imageViewB = new ImageView()
        {
          PositionUsesPivotPoint = true,
          PivotPoint = PivotPoint.BottomLeft,
          ParentOrigin = ParentOrigin.BottomLeft,
          Size = new Size(150, 150),
          ResourceUrl = imagePath+"netflex.png",
          CornerRadius = 0.3f,
          CornerRadiusPolicy = VisualTransformPolicyType.Relative,
        };
        root.Add(imageViewB);
        imageViewB.TouchEvent += (s, e) =>
        {
          if (e.Touch.GetState(0) == PointStateType.Up)
          {
            CreateSubWindowTwo();
          }
          return true;
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
