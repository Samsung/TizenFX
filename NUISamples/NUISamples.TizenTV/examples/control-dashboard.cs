/*
 * Copyright (c) 2017 Samsung Electronics Co., Ltd.
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 * http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 *
 */

using System;
using System.Runtime.InteropServices;
using Dali;

namespace MyCSharpExample
{
  class Example
  {
    // This is simple structure to contain Control name and implement state at once
    // name : control name
    // isImplemented : the state which the control is implemented in public or not
    private struct Item
    {
      public String name;
      public bool isImplemented;

      public Item(String name, bool isImplemented)
      {
        this.name = name;
        this.isImplemented = isImplemented;
      }
    }

    private Dali.Application _application;
    private TableView _contentContainer;
    private Stage _stage;
    private Popup _popup;

    // List of items
    private Item[] mViewList = {
      new Item("PushButton", true),  new Item("DropDown", false),    new Item("Toggle", true),
      new Item("InputField", false),  new Item("AnimateGif", false),  new Item("Loading", false),
      new Item("ProgressBar", false), new Item("CheckBox", false),    new Item("RadioButton", true),
      new Item("Tooltip", true),     new Item("Popup", true),       new Item("Toast", true),
      new Item("ItemView", false),    new Item("CheckBox", true)
    };

    public Example(Dali.Application application)
    {
      _application = application;
      _application.Initialized += OnInitialize;
    }

    public void OnInitialize(object source, NUIApplicationInitEventArgs e)
    {
      Console.WriteLine("Customized Application Initialize event handler");
      _stage = Stage.GetCurrent();
      _stage.BackgroundColor = Color.White;

      // Top label
      TextLabel topLabel = new TextLabel();
      topLabel.SetResizePolicy(ResizePolicyType.FILL_TO_PARENT, DimensionType.WIDTH);
      topLabel.SetResizePolicy(ResizePolicyType.SIZE_RELATIVE_TO_PARENT, DimensionType.HEIGHT);
      topLabel.AnchorPoint = NDalic.AnchorPointTopCenter;
      topLabel.ParentOrigin = NDalic.ParentOriginTopCenter;
      topLabel.SetSizeModeFactor(new Vector3( 0.0f, 0.1f, 0.0f ) );
      topLabel.BackgroundColor = new Color(43.0f / 255.0f, 145.0f / 255.0f, 175.0f / 255.0f, 1.0f);
      topLabel.TextColor = NDalic.WHITE;
      topLabel.Text = " DALi Views";
      topLabel.HorizontalAlignment = "BEGIN";
      topLabel.VerticalAlignment = "CENTER";
      topLabel.PointSize = 42.0f;
      _stage.Add(topLabel);

      // Grid container to contain items. Use tableView because FlexContainer support focus navigation just two direction ( up/down or left/right )
      _contentContainer = new TableView(6, 5);
      _contentContainer.SetResizePolicy(ResizePolicyType.FILL_TO_PARENT, DimensionType.WIDTH);
      _contentContainer.SetResizePolicy(ResizePolicyType.SIZE_RELATIVE_TO_PARENT, DimensionType.HEIGHT);
      _contentContainer.SetSizeModeFactor(new Vector3( 0.0f, 0.9f, 0.0f ) );
      _contentContainer.AnchorPoint = NDalic.AnchorPointBottomCenter;
      _contentContainer.ParentOrigin = NDalic.ParentOriginBottomCenter;
      _contentContainer.SetRelativeHeight(0, 0.07f);
      _contentContainer.SetRelativeHeight(1, 0.26f);
      _contentContainer.SetRelativeHeight(2, 0.07f);
      _contentContainer.SetRelativeHeight(3, 0.26f);
      _contentContainer.SetRelativeHeight(4, 0.07f);
      _contentContainer.SetRelativeHeight(5, 0.26f);
      _contentContainer.SetKeyboardFocusable(true);
      _stage.Add(_contentContainer);

      CreateContent();

      FocusManager.Instance.PreFocusChange += OnPreFocusChange;
    }

    // Callback for KeyboardFocusManager
    private Actor OnPreFocusChange(object source, FocusManager.PreFocusChangeEventArgs e)
    {
      if (!e.Proposed && !e.Current)
      {
        e.Proposed = _contentContainer.GetChildAt(1);
      }
      return e.Proposed;
    }

    private void CreateContent()
    {
      for (int i = 0; i < mViewList.Length; i++)
      {
        CreateItem(mViewList[i], i);
      }
    }

    private void CreateItem(Item item, int idx)
    {
      // Make label for item
      TextLabel itemLabel = new TextLabel("    " + item.name);
      itemLabel.Size = new Vector3(_stage.GetSize().Width * 0.2f, _stage.GetSize().Height * 0.05f, 0.0f);
      itemLabel.HorizontalAlignment = "BEGIN";
      itemLabel.VerticalAlignment = "BOTTOM";
      itemLabel.PointSize = 18.0f;
      _contentContainer.AddChild(itemLabel, new TableView.CellPosition(((uint)idx / 5) * 2, (uint)idx % 5));

      // If item is implemented in public, attach it on stage
      if (item.isImplemented)
      {
        if (item.name.CompareTo("PushButton") == 0)
        {
          PushButton pushButton = new PushButton();
          pushButton.LabelText = "Push Button";
          pushButton.SetResizePolicy(ResizePolicyType.FILL_TO_PARENT, DimensionType.WIDTH);
          pushButton.SetResizePolicy(ResizePolicyType.FILL_TO_PARENT, DimensionType.HEIGHT);
          pushButton.UnselectedColor = new Vector4(1.0f,0.0f,0.0f,1.0f);
          pushButton.SelectedColor = new Vector4(0.0f,1.0f,0.0f,1.0f);
          pushButton.Clicked += (obj, e) =>
          {
            e.Button.LabelText = "Click Me";
            e.Button.UnselectedColor = new Vector4(0.0f,0.0f,1.0f,1.0f);
            return true;
          };

          _contentContainer.AddChild(pushButton, new TableView.CellPosition(((uint)idx / 5) * 2 + 1, (uint)idx % 5));
        }
        if (item.name.CompareTo("DropDown") == 0)
        {

        }
        if (item.name.CompareTo("Toggle") == 0)
        {
          ToggleButton toggleButton = new ToggleButton();
          Dali.Property.Array array = new Dali.Property.Array();
          array.Add( new Dali.Property.Value("./images/star-highlight.png") );
          array.Add( new Dali.Property.Value("./images/star-mod.png") );
          array.Add( new Dali.Property.Value("./images/star-dim.png") );
          toggleButton.StateVisuals = array;

          Dali.Property.Array tooltips = new Dali.Property.Array();
          tooltips.Add( new Dali.Property.Value("State A") );
          tooltips.Add( new Dali.Property.Value("State B") );
          tooltips.Add( new Dali.Property.Value("State C") );
          toggleButton.Tooltips = tooltips;

          toggleButton.WidthResizePolicy  = "FILL_TO_PARENT";
          toggleButton.HeightResizePolicy = "FILL_TO_PARENT";
          toggleButton.Clicked += (obj, e) =>
          {
            Console.WriteLine("Toggle button state changed.");
            return true;
          };

          _contentContainer.AddChild(toggleButton, new TableView.CellPosition(((uint)idx / 5) * 2 + 1, (uint)idx % 5));
        }
        if (item.name.CompareTo("InputField") == 0)
        {

        }
        if (item.name.CompareTo("AnimateGif") == 0)
        {

        }
        if (item.name.CompareTo("Loading") == 0)
        {

        }
        if (item.name.CompareTo("ProgressBar") == 0)
        {

        }
        if (item.name.CompareTo("ScrollBar") == 0)
        {

        }
        if (item.name.CompareTo("CheckBox") == 0)
        {
          CheckBoxButton checkBoxButton = new CheckBoxButton();
          checkBoxButton.LabelText = "Yes";

          _contentContainer.AddChild(checkBoxButton, new TableView.CellPosition(((uint)idx / 5) * 2 + 1, (uint)idx % 5));
        }
        if (item.name.CompareTo("RadioButton") == 0)
        {
          TableView tableView = new TableView(2, 1);
          tableView.SetResizePolicy(ResizePolicyType.FILL_TO_PARENT, DimensionType.WIDTH);
          tableView.SetResizePolicy(ResizePolicyType.FILL_TO_PARENT, DimensionType.HEIGHT);

          RadioButton rButton = new RadioButton();
          rButton.LabelText = "Yes";
          rButton.Selected = true;
          tableView.AddChild(rButton, new TableView.CellPosition(0, 0));

          rButton = new RadioButton();
          rButton.LabelText = "No";

          tableView.AddChild(rButton, new TableView.CellPosition(1, 0));

          _contentContainer.AddChild(tableView, new TableView.CellPosition(((uint)idx / 5) * 2 + 1, (uint)idx % 5));
        }
        if (item.name.CompareTo("Tooltip") == 0)
        {
          TableView tableView = new TableView(2, 1);
          tableView.SetResizePolicy(ResizePolicyType.FILL_TO_PARENT, DimensionType.WIDTH);
          tableView.SetResizePolicy(ResizePolicyType.FILL_TO_PARENT, DimensionType.HEIGHT);

          // Create two push buttons and add them to a table view
          PushButton buttonWithSimpleTooltip = new PushButton();
          buttonWithSimpleTooltip.LabelText = "Tooltip with text only";
          buttonWithSimpleTooltip.UnselectedColor = new Vector4(0.5f,0.5f,0.7f,1.0f);
          buttonWithSimpleTooltip.SelectedColor = new Vector4(0.7f,0.5f,0.7f,1.0f);
          buttonWithSimpleTooltip.WidthResizePolicy = "FILL_TO_PARENT";
          tableView.AddChild(buttonWithSimpleTooltip, new TableView.CellPosition(0, 0));

          PushButton buttonWithIconTooltip = new PushButton();
          buttonWithIconTooltip.LabelText = "Tooltip with Text and Icon";
          buttonWithIconTooltip.WidthResizePolicy = "FILL_TO_PARENT";
          buttonWithIconTooltip.UnselectedColor = new Vector4(0.5f,0.5f,0.7f,1.0f);
          buttonWithIconTooltip.SelectedColor = new Vector4(0.7f,0.5f,0.7f,1.0f);
          tableView.AddChild(buttonWithIconTooltip, new TableView.CellPosition(1, 0));

          // Add a simple text only tooltip to the first push button
          buttonWithSimpleTooltip.TooltipText = "Simple Tooltip";

          // Create a property map for a tooltip with one icon and one text
          Property.Array iconTooltipContent = new Property.Array();

          Property.Map iconVisual = new Property.Map();
          iconVisual.Add( Dali.Constants.Visual.Property.Type, new Property.Value((int)Dali.Constants.Visual.Type.Image) )
            .Add( Dali.Constants.ImageVisualProperty.URL, new Property.Value("./images/star-highlight.png") );
          iconTooltipContent.Add(new Property.Value(iconVisual));

          Property.Map textVisual = new Property.Map();
          textVisual.Add( Dali.Constants.Visual.Property.Type, new Property.Value((int)Dali.Constants.Visual.Type.Text) )
            .Add( Dali.Constants.TextVisualProperty.Text, new Property.Value("Tooltip with Icon") );
          iconTooltipContent.Add(new Property.Value(textVisual));

          Property.Map iconTooltip = new Property.Map();
          iconTooltip.Add( Dali.Constants.Tooltip.Property.Content, new Property.Value(iconTooltipContent) )
            .Add( Dali.Constants.Tooltip.Property.Tail, new Property.Value(true) );

          // Add the tooltip with icon and text to the second push button
          buttonWithIconTooltip.Tooltip = iconTooltip;

          _contentContainer.AddChild(tableView, new TableView.CellPosition(((uint)idx / 5) * 2 + 1, (uint)idx % 5));
        }
        if (item.name.CompareTo("Popup") == 0)
        {
          PushButton button = new PushButton();
          button.LabelText = "Popup";
          button.ParentOrigin = NDalic.ParentOriginCenter;
          button.AnchorPoint = NDalic.AnchorPointCenter;
          button.MaximumSize = new Vector2(90.0f,50.0f);
          _popup = CreatePopup();
          _popup.SetTitle(CreateTitle("Popup"));

          TextLabel text = new TextLabel("This will erase the file permanently. Are you sure?");
          text.BackgroundColor = Color.White;
          text.MultiLine = true;
          text.SetResizePolicy(ResizePolicyType.FILL_TO_PARENT, DimensionType.WIDTH);
          text.SetResizePolicy(ResizePolicyType.DIMENSION_DEPENDENCY, DimensionType.HEIGHT);
          text.SetPadding(new PaddingType(10.0f, 10.0f, 20.0f, 0.0f));
          _popup.SetContent(text);
          _popup.SetKeyboardFocusable(true);
          _popup.SetDisplayState(Popup.DisplayStateType.HIDDEN);

          button.Clicked += (obj, ee) =>
          {
            _stage.Add(_popup);
            _popup.SetDisplayState(Popup.DisplayStateType.SHOWN);
            FocusManager.Instance.SetCurrentFocusActor((_popup.FindChildByName( "Footer" )).FindChildByName("OKButton"));
            return true;
          };
          _contentContainer.AddChild(button, new TableView.CellPosition(((uint)idx / 5) * 2 + 1, (uint)idx % 5));
        }
        if (item.name.CompareTo("Toast") == 0)
        {
          PushButton button = new PushButton();
          button.LabelText = "Toast";
          button.ParentOrigin = NDalic.ParentOriginCenter;
          button.AnchorPoint = NDalic.AnchorPointCenter;
          button.Clicked += (obj, ee) =>
          {
            TypeInfo typeInfo = new TypeInfo(TypeRegistry.Get().GetTypeInfo( "PopupToast" ));
            if( typeInfo )
            {
              BaseHandle baseHandle = typeInfo.CreateInstance();
              if( baseHandle )
              {
                Popup toast = Popup.DownCast( baseHandle );
                TextLabel text = new TextLabel("This is a Toast.\nIt will auto-hide itself");
                text.TextColor = Color.White;
                text.MultiLine = true;
                text.HorizontalAlignment = "center";
                toast.SetTitle( text);
                _stage.Add(toast);
                toast.SetDisplayState( Popup.DisplayStateType.SHOWN);
              }
            }
            return true;
          };
          _contentContainer.AddChild(button, new TableView.CellPosition(((uint)idx / 5) * 2 + 1, (uint)idx % 5));
        }
        if (item.name.CompareTo("ItemView") == 0)
        {

        }
      }
      else
      {
        ImageView notSupportView = new ImageView("images/not_yet_sign.png");
        notSupportView.Size = new Vector3(_stage.GetSize().Width * 0.2f, _stage.GetSize().Height * 0.25f, 0.0f);
        notSupportView.SetKeyboardFocusable(true);
        _contentContainer.AddChild(notSupportView, new TableView.CellPosition(((uint)idx / 5) * 2 + 1, (uint)idx % 5));
      }
    }
    Popup CreatePopup()
    {
      Popup confirmationPopup = new Popup();

      Actor footer = new Actor();
      footer.SetName("Footer");
      footer.SetResizePolicy(ResizePolicyType.FILL_TO_PARENT, DimensionType.WIDTH);
      footer.SetResizePolicy(ResizePolicyType.FIXED, DimensionType.HEIGHT);
      footer.SetSize(0.0f, 80.0f);
      footer.ParentOrigin = NDalic.ParentOriginCenter;
      footer.AnchorPoint = NDalic.AnchorPointCenter;

      PushButton okButton = CreateOKButton();
      okButton.ParentOrigin = NDalic.ParentOriginCenter;
      okButton.AnchorPoint = NDalic.AnchorPointCenter;
      okButton.SetResizePolicy(ResizePolicyType.SIZE_FIXED_OFFSET_FROM_PARENT, DimensionType.ALL_DIMENSIONS);
      okButton.SetSizeModeFactor(new Vector3(-20.0f, -20.0f, 0.0f));

      PushButton cancelButton = CreateCancelButton();
      cancelButton.ParentOrigin = NDalic.ParentOriginCenter;
      cancelButton.AnchorPoint = NDalic.AnchorPointCenter;
      cancelButton.SetResizePolicy(ResizePolicyType.SIZE_FIXED_OFFSET_FROM_PARENT, DimensionType.ALL_DIMENSIONS);
      cancelButton.SetSizeModeFactor(new Vector3(-20.0f, -20.0f, 0.0f));

      TableView controlLayout = new TableView(1, 2);
      controlLayout.ParentOrigin = NDalic.ParentOriginCenter;
      controlLayout.AnchorPoint = NDalic.AnchorPointCenter;
      controlLayout.SetResizePolicy(ResizePolicyType.FILL_TO_PARENT, DimensionType.ALL_DIMENSIONS);
      controlLayout.SetCellPadding(new Size(10.0f, 10.0f));
      controlLayout.SetRelativeWidth(0, 0.5f);
      controlLayout.SetRelativeWidth(1, 0.5f);
      controlLayout.SetCellAlignment(new TableView.CellPosition(0, 0), HorizontalAlignmentType.CENTER, VerticalAlignmentType.CENTER);
      controlLayout.SetCellAlignment(new TableView.CellPosition(0, 1), HorizontalAlignmentType.CENTER, VerticalAlignmentType.CENTER);
      controlLayout.AddChild(okButton, new TableView.CellPosition(0, 0));
      controlLayout.AddChild(cancelButton, new TableView.CellPosition(0, 1));

      footer.Add(controlLayout);

      confirmationPopup.SetFooter(footer);
      return confirmationPopup;
    }
    Actor CreateTitle(string title)
    {
      TextLabel titleActor = new TextLabel(title);
      titleActor.TextColor = Color.White;
      titleActor.MultiLine = true;
      titleActor.HorizontalAlignment = "center";
      return titleActor;
    }

    PushButton CreateOKButton()
    {
      PushButton okayButton = new PushButton();
      okayButton.SetName("OKButton");
      okayButton.LabelText = "OK";
      okayButton.SetKeyboardFocusable(true);
      okayButton.Clicked += (obj, ee) =>
      {
        _popup.SetDisplayState(Popup.DisplayStateType.HIDDEN);
        return true;
      };
      return okayButton;
    }
    PushButton CreateCancelButton()
    {
      PushButton cancelButton = new PushButton();
      cancelButton.LabelText = "Cancel";
      cancelButton.SetKeyboardFocusable(true);
      cancelButton.Clicked += (obj, ee) =>
      {
        _popup.SetDisplayState(Popup.DisplayStateType.HIDDEN);
        return true;
      };
      return cancelButton;
    }

    public void MainLoop()
    {
      _application.MainLoop();
    }

    /// <summary>
    /// The main entry point for the application.
    /// </summary>

    [STAThread]
      static void Main(string[] args)
      {
        Console.WriteLine("Hello Mono World");

        Example example = new Example(Application.NewApplication("json/control-dashboard.json"));
        example.MainLoop();
      }
  }
}
