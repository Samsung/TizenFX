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
using Tizen.NUI;
using Tizen.NUI.UIComponents;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Constants;

namespace ControlDashboard
{
    class Example : NUIApplication
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

        private TableView _contentContainer;
        private Timer _timer;
        private Window _window;
        private Popup _popup;
        private ProgressBar _progressBar;
        //private const string _resPath = "/home/owner/apps_rw/NUISamples.TizenTV/res";
        private const string _resPath = "./res";  //for ubuntu


        // List of items
        private Item[] mViewList = {
      new Item("PushButton", true),  new Item("DropDown", false),    new Item("Toggle", true),
      new Item("InputField", false),  new Item("AnimateGif", false),  new Item("Loading", false),
      new Item("ProgressBar", true), new Item("CheckBox", false),    new Item("RadioButton", true),
      new Item("Tooltip", true),     new Item("Popup", true),       new Item("Toast", true),
      new Item("ItemView", false),    new Item("CheckBox", true)
    };

        public Example() : base()
        {
        }

        public Example(string stylesheet) : base(stylesheet)
        {
        }

        public Example(string stylesheet, NUIApplication.WindowMode windowMode) : base(stylesheet, windowMode)
        {
        }

        protected override void OnCreate()
        {
            base.OnCreate();
            Initialize();
        }

        public void Initialize()
        {
            Tizen.Log.Debug("NUI", "Customized Application Initialize event handler");
            _window = Window.Instance;
            _window.BackgroundColor = Color.White;

            // Top label
            TextLabel topLabel = new TextLabel();
            topLabel.WidthResizePolicy = ResizePolicyType.FillToParent;
            topLabel.HeightResizePolicy = ResizePolicyType.SizeRelativeToParent;
            topLabel.PivotPoint = PivotPoint.TopCenter;
            topLabel.SetSizeModeFactor(new Vector3(0.0f, 0.1f, 0.0f));
            topLabel.BackgroundColor = new Color(43.0f / 255.0f, 145.0f / 255.0f, 175.0f / 255.0f, 1.0f);
            topLabel.TextColor = Color.White;
            topLabel.Text = " DALi Views";
            topLabel.HorizontalAlignment = HorizontalAlignment.Begin;
            topLabel.VerticalAlignment = VerticalAlignment.Center;
            topLabel.PointSize = 42.0f;
            _window.Add(topLabel);
            //StyleManager.Get().ApplyStyle(topLabel, _resPath + "/json/control-dashboard-theme.json", "TextFieldFontSize4");
            topLabel.SetStyleName("TextFieldFontSize4");

            // Grid container to contain items. Use tableView because FlexContainer support focus navigation just two direction ( up/down or left/right )
            _contentContainer = new TableView(6, 5);
            _contentContainer.WidthResizePolicy = ResizePolicyType.FillToParent;
            _contentContainer.HeightResizePolicy = ResizePolicyType.SizeRelativeToParent;
            _contentContainer.SetSizeModeFactor(new Vector3(0.0f, 0.9f, 0.0f));
            _contentContainer.PivotPoint = PivotPoint.BottomCenter;
            _contentContainer.Position = new Position(0, _window.Size.Height * 0.1f, 0);
            _contentContainer.SetRelativeHeight(0, 0.07f);
            _contentContainer.SetRelativeHeight(1, 0.26f);
            _contentContainer.SetRelativeHeight(2, 0.07f);
            _contentContainer.SetRelativeHeight(3, 0.26f);
            _contentContainer.SetRelativeHeight(4, 0.07f);
            _contentContainer.SetRelativeHeight(5, 0.26f);
            _contentContainer.Focusable = (true);
            _window.Add(_contentContainer);

            CreateContent();

            FocusManager.Instance.PreFocusChange += OnPreFocusChange;
        }

        // Callback for KeyboardFocusManager
        private View OnPreFocusChange(object source, FocusManager.PreFocusChangeEventArgs e)
        {
            if (!e.ProposedView && !e.CurrentView)
            {
                e.ProposedView = _contentContainer.GetChildAt(1);
            }
            return e.ProposedView;
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
            itemLabel.Size2D = new Size2D((int)(_window.Size.Width * 0.2f), (int)(_window.Size.Height * 0.05f));
            itemLabel.HorizontalAlignment = HorizontalAlignment.Begin;
            itemLabel.VerticalAlignment = VerticalAlignment.Bottom;
            //itemLabel.PointSize = 18.0f;
            _contentContainer.AddChild(itemLabel, new TableView.CellPosition(((uint)idx / 5) * 2, (uint)idx % 5));

            // If item is implemented in public, attach it on window
            if (item.isImplemented)
            {
                if (item.name.CompareTo("PushButton") == 0)
                {
                    PushButton pushButton = new PushButton();
                    pushButton.LabelText = "Push Button";
                    pushButton.WidthResizePolicy = ResizePolicyType.FillToParent;
                    pushButton.HeightResizePolicy = ResizePolicyType.FillToParent;
                    pushButton.UnselectedColor = new Vector4(1.0f, 0.0f, 0.0f, 1.0f);
                    pushButton.SelectedColor = new Vector4(0.0f, 1.0f, 0.0f, 1.0f);
                    pushButton.Clicked += (obj, e) =>
                    {
                        Button sender = obj as Button;
                        sender.LabelText = "Click Me";
                        sender.UnselectedColor = new Vector4(0.0f, 0.0f, 1.0f, 1.0f);
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
                    PropertyArray array = new PropertyArray();
                    array.Add(new PropertyValue(_resPath + "/images/star-highlight.png"));
                    array.Add(new PropertyValue(_resPath + "/images/star-mod.png"));
                    array.Add(new PropertyValue(_resPath + "/images/star-dim.png"));
                    toggleButton.StateVisuals = array;

                    PropertyArray tooltips = new PropertyArray();
                    tooltips.Add(new PropertyValue("State A"));
                    tooltips.Add(new PropertyValue("State B"));
                    tooltips.Add(new PropertyValue("State C"));
                    toggleButton.Tooltips = tooltips;

                    toggleButton.WidthResizePolicy = ResizePolicyType.FillToParent;
                    toggleButton.HeightResizePolicy = ResizePolicyType.FillToParent;
                    toggleButton.Clicked += (obj, e) =>
                    {
                        Tizen.Log.Debug("NUI", "Toggle button state changed.");
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
                    _progressBar = new ProgressBar();
                    _progressBar.WidthResizePolicy = ResizePolicyType.FillToParent;
                    _progressBar.HeightResizePolicy = ResizePolicyType.Fixed;
                    _progressBar.Size2D = new Size2D(0, 100);

                    _progressBar.ValueChanged += OnProgressBarValueChanged;

                    _timer = new Timer(100);
                    _timer.Tick += (obj, e) =>
                    {
                        float progress = (float)Math.Round(_progressBar.ProgressValue, 2);

                        if (progress == 1.0f)
                        {
                            _progressBar.ProgressValue = 0.0f;
                            _progressBar.SecondaryProgressValue = 0.01f;
                        }
                        else
                        {
                            _progressBar.ProgressValue = progress + 0.01f;
                            _progressBar.SecondaryProgressValue = progress + 0.21f;
                        }
                        return true;
                    };
                    _timer.Start();

                    _contentContainer.AddChild(_progressBar, new TableView.CellPosition(((uint)idx / 5) * 2 + 1, (uint)idx % 5));
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
                    tableView.WidthResizePolicy = ResizePolicyType.FillToParent;
                    tableView.HeightResizePolicy = ResizePolicyType.FillToParent;

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
                    tableView.WidthResizePolicy = ResizePolicyType.FillToParent;
                    tableView.HeightResizePolicy = ResizePolicyType.FillToParent;

                    // Create two push buttons and add them to a table view
                    PushButton buttonWithSimpleTooltip = new PushButton();
                    buttonWithSimpleTooltip.LabelText = "Tooltip with text only";
                    buttonWithSimpleTooltip.UnselectedColor = new Vector4(0.5f, 0.5f, 0.7f, 1.0f);
                    buttonWithSimpleTooltip.SelectedColor = new Vector4(0.7f, 0.5f, 0.7f, 1.0f);
                    buttonWithSimpleTooltip.WidthResizePolicy = ResizePolicyType.FillToParent;
                    tableView.AddChild(buttonWithSimpleTooltip, new TableView.CellPosition(0, 0));

                    PushButton buttonWithIconTooltip = new PushButton();
                    buttonWithIconTooltip.LabelText = "Tooltip with Text and Icon";
                    buttonWithIconTooltip.WidthResizePolicy = ResizePolicyType.FillToParent;
                    buttonWithIconTooltip.UnselectedColor = new Vector4(0.5f, 0.5f, 0.7f, 1.0f);
                    buttonWithIconTooltip.SelectedColor = new Vector4(0.7f, 0.5f, 0.7f, 1.0f);
                    tableView.AddChild(buttonWithIconTooltip, new TableView.CellPosition(1, 0));

                    // Add a simple text only tooltip to the first push button
                    buttonWithSimpleTooltip.TooltipText = "Simple Tooltip";

                    // Create a property map for a tooltip with one icon and one text
                    PropertyArray iconTooltipContent = new PropertyArray();

                    PropertyMap iconVisual = new PropertyMap();
                    iconVisual.Add(Visual.Property.Type, new PropertyValue((int)Visual.Type.Image))
                      .Add(ImageVisualProperty.URL, new PropertyValue(_resPath + "/images/star-highlight.png"));
                    iconTooltipContent.Add(new PropertyValue(iconVisual));

                    PropertyMap textVisual = new PropertyMap();
                    textVisual.Add(Visual.Property.Type, new PropertyValue((int)Visual.Type.Text))
                      .Add(TextVisualProperty.Text, new PropertyValue("Tooltip with Icon"));
                    iconTooltipContent.Add(new PropertyValue(textVisual));

                    PropertyMap iconTooltip = new PropertyMap();
                    iconTooltip.Add(Tizen.NUI.Constants.Tooltip.Property.Content, new PropertyValue(iconTooltipContent))
                      .Add(Tizen.NUI.Constants.Tooltip.Property.Tail, new PropertyValue(true));

                    // Add the tooltip with icon and text to the second push button
                    buttonWithIconTooltip.Tooltip = iconTooltip;

                    _contentContainer.AddChild(tableView, new TableView.CellPosition(((uint)idx / 5) * 2 + 1, (uint)idx % 5));
                }
                if (item.name.CompareTo("Popup") == 0)
                {
                    PushButton button = new PushButton();
                    button.LabelText = "Popup";
                    button.PivotPoint = PivotPoint.Center;
                    button.MaximumSize = new Size2D(150, 100);
                    _popup = CreatePopup();
                    _popup.SetTitle(CreateTitle("Popup"));

                    TextLabel text = new TextLabel("This will erase the file permanently. Are you sure?");
                    text.BackgroundColor = Color.White;
                    text.MultiLine = true;
                    text.WidthResizePolicy = ResizePolicyType.FillToParent;
                    text.HeightResizePolicy = ResizePolicyType.DimensionDependency;
                    text.SetPadding(new PaddingType(10.0f, 10.0f, 20.0f, 0.0f));
                    _popup.SetContent(text);
                    _popup.Focusable = (true);
                    _popup.SetDisplayState(Popup.DisplayStateType.Hidden);

                    button.Clicked += (obj, ee) =>
                    {
                        _window.Add(_popup);
                        _popup.SetDisplayState(Popup.DisplayStateType.Shown);
                        FocusManager.Instance.SetCurrentFocusView((_popup.FindChildByName("Footer")).FindChildByName("OKButton"));
                        return true;
                    };
                    _contentContainer.AddChild(button, new TableView.CellPosition(((uint)idx / 5) * 2 + 1, (uint)idx % 5));
                }
                if (item.name.CompareTo("Toast") == 0)
                {
                    PushButton button = new PushButton();
                    button.LabelText = "Toast";
                    button.PivotPoint = PivotPoint.Center;
                    button.Clicked += (obj, ee) =>
                    {
                        Popup toast = new Popup();
                        toast.SizeModeFactor = new Vector3(0.75f, 0.75f, 0.75f);
                        toast.WidthResizePolicy = ResizePolicyType.SizeRelativeToParent;
                        toast.HeightResizePolicy = ResizePolicyType.UseNaturalSize;
                        toast.ContextualMode = Popup.ContextualModeType.NonContextual;
                        toast.AnimationDuration = 0.65f;
                        toast.TailVisibility = false;

                        // Disable the dimmed backing.
                        toast.BackingEnabled = false;

                        // The toast popup should fade in (not zoom).
                        toast.AnimationMode = Popup.AnimationModeType.Fade;

                        // The toast popup should auto-hide.
                        toast.AutoHideDelay = 3000;

                        // Align to the bottom of the screen.
                        toast.ParentOrigin = new Position(0.5f, 0.94f, 0.5f);
                        toast.PivotPoint = PivotPoint.BottomCenter;

                        // Let events pass through the toast popup.
                        toast.TouchTransparent = true;

                        TextLabel text = new TextLabel("This is a Toast.\nIt will auto-hide itself");
                        text.TextColor = Color.White;
                        text.MultiLine = true;
                        text.HorizontalAlignment = HorizontalAlignment.Center;
                        toast.SetTitle(text);
                        _window.Add(toast);
                        toast.DisplayState = Popup.DisplayStateType.Shown;

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
                ImageView notSupportView = new ImageView(_resPath + "/images/not_yet_sign.png");
                notSupportView.Size2D = new Size2D((int)(_window.Size.Width * 0.2f), (int)(_window.Size.Height * 0.25f));
                notSupportView.Focusable = (true);
                _contentContainer.AddChild(notSupportView, new TableView.CellPosition(((uint)idx / 5) * 2 + 1, (uint)idx % 5));
            }
        }
        Popup CreatePopup()
        {
            Popup confirmationPopup = new Popup();

            View footer = new View();
            footer.Name = ("Footer");
            footer.WidthResizePolicy = ResizePolicyType.FillToParent;
            footer.HeightResizePolicy = ResizePolicyType.Fixed;
            footer.Size2D = new Size2D(0, 80);
            footer.PivotPoint = PivotPoint.Center;

            PushButton okButton = CreateOKButton();
            okButton.PivotPoint = PivotPoint.Center;
            okButton.WidthResizePolicy = ResizePolicyType.SizeFixedOffsetFromParent;
            okButton.HeightResizePolicy = ResizePolicyType.SizeFixedOffsetFromParent;
            okButton.SetSizeModeFactor(new Vector3(-20.0f, -20.0f, 0.0f));

            PushButton cancelButton = CreateCancelButton();
            cancelButton.PivotPoint = PivotPoint.Center;
            cancelButton.WidthResizePolicy = ResizePolicyType.SizeFixedOffsetFromParent;
            cancelButton.HeightResizePolicy = ResizePolicyType.SizeFixedOffsetFromParent;
            cancelButton.SetSizeModeFactor(new Vector3(-20.0f, -20.0f, 0.0f));

            TableView controlLayout = new TableView(1, 2);
            controlLayout.PivotPoint = PivotPoint.Center;
            controlLayout.WidthResizePolicy = ResizePolicyType.FillToParent;
            controlLayout.HeightResizePolicy = ResizePolicyType.FillToParent;
            controlLayout.SetCellPadding(new Size2D(10, 10));
            controlLayout.SetRelativeWidth(0, 0.5f);
            controlLayout.SetRelativeWidth(1, 0.5f);
            controlLayout.SetCellAlignment(new TableView.CellPosition(0, 0), HorizontalAlignmentType.Center, VerticalAlignmentType.Center);
            controlLayout.SetCellAlignment(new TableView.CellPosition(0, 1), HorizontalAlignmentType.Center, VerticalAlignmentType.Center);
            controlLayout.AddChild(okButton, new TableView.CellPosition(0, 0));
            controlLayout.AddChild(cancelButton, new TableView.CellPosition(0, 1));

            footer.Add(controlLayout);

            confirmationPopup.SetFooter(footer);
            return confirmationPopup;
        }
        View CreateTitle(string title)
        {
            TextLabel titleView = new TextLabel(title);
            titleView.TextColor = Color.White;
            titleView.MultiLine = true;
            titleView.HorizontalAlignment = HorizontalAlignment.Center;
            return titleView;
        }

        PushButton CreateOKButton()
        {
            PushButton okayButton = new PushButton();
            okayButton.Name = ("OKButton");
            okayButton.LabelText = "OK";
            okayButton.Focusable = (true);
            okayButton.Clicked += (obj, ee) =>
            {
                _popup.SetDisplayState(Popup.DisplayStateType.Hidden);
                return true;
            };
            return okayButton;
        }
        PushButton CreateCancelButton()
        {
            PushButton cancelButton = new PushButton();
            cancelButton.LabelText = "Cancel";
            cancelButton.Focusable = (true);
            cancelButton.Clicked += (obj, ee) =>
            {
                _popup.SetDisplayState(Popup.DisplayStateType.Hidden);
                return true;
            };
            return cancelButton;
        }

        void OnProgressBarValueChanged(object source, ProgressBar.ValueChangedEventArgs e)
        {
            PropertyMap labelVisual = new PropertyMap();
            labelVisual.Add(Visual.Property.Type, new PropertyValue((int)Visual.Type.Text))
              .Add(TextVisualProperty.Text, new PropertyValue(Math.Round(e.ProgressBar.ProgressValue, 2) + " / " + Math.Round(e.ProgressBar.SecondaryProgressValue, 2)))
              .Add(TextVisualProperty.PointSize, new PropertyValue(10.0f));
            e.ProgressBar.LabelVisual = labelVisual;
            return;
        }

        [STAThread]
        static void _Main(string[] args)
        {
            Tizen.Log.Debug("NUI", "Hello Mono World");

            Example example = new Example("/home/owner/apps_rw/NUISamples.TizenTV/res/json/control-dashboard-theme.json");
            
            example.Run(args);
        }
    }
}
