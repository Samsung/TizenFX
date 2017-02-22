/*
 * Copyright (c) 2016 Samsung Electronics Co., Ltd.
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

        private Application _application;
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

        public Example(Application application)
        {
            _application = application;
            _application.Initialized += OnInitialize;
        }

        public void OnInitialize(object source, NUIApplicationInitEventArgs e)
        {
            Tizen.Log.Debug("NUI", "Customized Application Initialize event handler");
            _stage = Stage.Instance;
            _stage.BackgroundColor = Color.White;

            // Top label
            TextLabel topLabel = new TextLabel();
            topLabel.WidthResizePolicy = ResizePolicyType.FillToParent;
            topLabel.HeightResizePolicy = ResizePolicyType.SizeRelativeToParent;
            topLabel.AnchorPoint = AnchorPoint.TopCenter;
            topLabel.ParentOrigin = ParentOrigin.TopCenter;
            topLabel.SizeModeFactor = new Vector3(0.0f, 0.1f, 0.0f);
            topLabel.BackgroundColor = new Color(43.0f / 255.0f, 145.0f / 255.0f, 175.0f / 255.0f, 1.0f);
            topLabel.TextColor = Color.Yellow;
            topLabel.Text = " DALi Views Ver.0216-01";
            topLabel.HorizontalAlignment = "BEGIN";
            topLabel.VerticalAlignment = "CENTER";

            topLabel.FontFamily = "BreezeSans";
            PropertyMap _map = new PropertyMap();
            _map.Add("width", new PropertyValue("regular"));
            _map.Add("weight", new PropertyValue("bold"));
            _map.Add("slant", new PropertyValue("italic"));
            topLabel.FontStyle = _map;
            topLabel.PointSize = 15.0f;

            _stage.GetDefaultLayer().Add(topLabel);

            // Grid container to contain items. Use tableView because FlexContainer support focus navigation just two direction ( up/down or left/right )
            _contentContainer = new TableView(6, 5);
            _contentContainer.WidthResizePolicy = ResizePolicyType.FillToParent;
            _contentContainer.HeightResizePolicy = ResizePolicyType.SizeRelativeToParent;
            _contentContainer.SizeModeFactor = new Vector3(0.0f, 0.9f, 0.0f);
            _contentContainer.AnchorPoint = AnchorPoint.BottomCenter;
            _contentContainer.ParentOrigin = ParentOrigin.BottomCenter;
            _contentContainer.SetRelativeHeight(0, 0.07f);
            _contentContainer.SetRelativeHeight(1, 0.26f);
            _contentContainer.SetRelativeHeight(2, 0.07f);
            _contentContainer.SetRelativeHeight(3, 0.26f);
            _contentContainer.SetRelativeHeight(4, 0.07f);
            _contentContainer.SetRelativeHeight(5, 0.26f);
            _contentContainer.Focusable = true;
            _stage.GetDefaultLayer().Add(_contentContainer);

            CreateContent();

            FocusManager.Instance.PreFocusChange += OnPreFocusChange;

            View _testView = new View();
            Tizen.Log.Debug("NUI", "1) test view sizewidth = " + _testView.SizeWidth + "  sizeHeight= " + _testView.SizeHeight);
            _testView.Size = new Size(1.0f, 2.0f, 0.0f);
            Tizen.Log.Debug("NUI", "2) test view sizewidth = " + _testView.SizeWidth + "  sizeHeight= " + _testView.SizeHeight);
            _testView.WidthResizePolicy = ResizePolicyType.Fixed;
            _testView.HeightResizePolicy = ResizePolicyType.Fixed;
            _testView.Size = new Size(1.0f, 2.0f, 0.0f);
            Tizen.Log.Debug("NUI", "3) test view sizewidth = " + _testView.SizeWidth + "  sizeHeight= " + _testView.SizeHeight);

#if false
            Window _win = new Window(new RectInteger(100, 100, 500, 500), "win test", false);
            Window _win = _application.GetWindow();
            _win.Activate();
            _win.ShowIndicator(Window.IndicatorVisibleMode.VISIBLE);
            _win.SetIndicatorBgOpacity(Window.IndicatorBgOpacity.OPAQUE);
            Any _any = _win.GetNativeHandle();
#endif
        }

        // Callback for KeyboardFocusManager
        private View OnPreFocusChange(object source, FocusManager.PreFocusChangeEventArgs e)
        {
            if (!e.ProposedView && !e.CurrentView)
            {
                e.ProposedView = View.DownCast(_contentContainer.GetChildAt(1));
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
            itemLabel.Size = new Size(_stage.Size.Width * 0.2f, _stage.Size.Height * 0.05f, 0.0f);
            itemLabel.HorizontalAlignment = "BEGIN";
            itemLabel.VerticalAlignment = "BOTTOM";
            //itemLabel.PointSize = 10.0f;
            _contentContainer.AddChild(itemLabel, new TableView.CellPosition(((uint)idx / 5) * 2, (uint)idx % 5));

            // If item is implemented in public, attach it on stage
            if (item.isImplemented)
            {
                if (item.name.CompareTo("PushButton") == 0)
                {
                    PushButton pushButton = new PushButton();
                    pushButton.LabelText = "Push Button";
                    pushButton.WidthResizePolicy = ResizePolicyType.FillToParent;
                    pushButton.HeightResizePolicy = ResizePolicyType.FillToParent;
                    pushButton.UnselectedColor = new Color(1.0f, 0.0f, 0.0f, 1.0f);
                    pushButton.SelectedColor = new Color(0.0f, 1.0f, 0.0f, 1.0f);
                    pushButton.Clicked += (obj, e) =>
                    {
                        Button sender = (Button)(obj);
                        sender.LabelText = "Click Me";
                        sender.UnselectedColor = new Color(0.0f, 0.0f, 1.0f, 1.0f);
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
                    Tizen.NUI.PropertyArray array = new Tizen.NUI.PropertyArray();
                    array.Add(new Tizen.NUI.PropertyValue("/home/owner/apps_rw/NUISamples.TizenTV/res/images/star-highlight.png"));
                    array.Add(new Tizen.NUI.PropertyValue("/home/owner/apps_rw/NUISamples.TizenTV/res/images/star-mod.png"));
                    array.Add(new Tizen.NUI.PropertyValue("/home/owner/apps_rw/NUISamples.TizenTV/res/images/star-dim.png"));
                    toggleButton.StateVisuals = array;

                    Tizen.NUI.PropertyArray tooltips = new Tizen.NUI.PropertyArray();
                    tooltips.Add(new Tizen.NUI.PropertyValue("State A"));
                    tooltips.Add(new Tizen.NUI.PropertyValue("State B"));
                    tooltips.Add(new Tizen.NUI.PropertyValue("State C"));
                    toggleButton.Tooltips = tooltips;

                    toggleButton.WidthResizePolicy = ResizePolicyType.FillToParent;
                    toggleButton.HeightResizePolicy = ResizePolicyType.FillToParent;
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
                    buttonWithSimpleTooltip.UnselectedColor = new Color(0.5f, 0.5f, 0.7f, 1.0f);
                    buttonWithSimpleTooltip.SelectedColor = new Color(0.7f, 0.5f, 0.7f, 1.0f);
                    buttonWithSimpleTooltip.WidthResizePolicy = ResizePolicyType.FillToParent;
                    tableView.AddChild(buttonWithSimpleTooltip, new TableView.CellPosition(0, 0));

                    PushButton buttonWithIconTooltip = new PushButton();
                    buttonWithIconTooltip.LabelText = "Tooltip with Text and Icon";
                    buttonWithIconTooltip.WidthResizePolicy = ResizePolicyType.FillToParent;
                    buttonWithIconTooltip.UnselectedColor = new Color(0.5f, 0.5f, 0.7f, 1.0f);
                    buttonWithIconTooltip.SelectedColor = new Color(0.7f, 0.5f, 0.7f, 1.0f);
                    tableView.AddChild(buttonWithIconTooltip, new TableView.CellPosition(1, 0));

                    // Add a simple text only tooltip to the first push button
                    buttonWithSimpleTooltip.TooltipText = "Simple Tooltip";

                    // Create a property map for a tooltip with one icon and one text
                    PropertyArray iconTooltipContent = new PropertyArray();

                    PropertyMap iconVisual = new PropertyMap();
                    iconVisual.Add(Tizen.NUI.Constants.Visual.Property.Type, new PropertyValue((int)Tizen.NUI.Constants.Visual.Type.Image))
                      .Add(Tizen.NUI.Constants.ImageVisualProperty.URL, new PropertyValue("/home/owner/apps_rw/NUISamples.TizenTV/res/images/star-highlight.png"));
                    iconTooltipContent.Add(new PropertyValue(iconVisual));

                    PropertyMap textVisual = new PropertyMap();
                    textVisual.Add(Tizen.NUI.Constants.Visual.Property.Type, new PropertyValue((int)Tizen.NUI.Constants.Visual.Type.Text))
                      .Add(Tizen.NUI.Constants.TextVisualProperty.Text, new PropertyValue("Tooltip with Icon"));
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
                    button.ParentOrigin = ParentOrigin.Center;
                    button.AnchorPoint = AnchorPoint.Center;
                    //button.MaximumSize = new Vector2(90.0f,50.0f);
                    _popup = CreatePopup();
                    _popup.SetTitle(CreateTitle("Popup"));

                    TextLabel text = new TextLabel("This will erase the file permanently. Are you sure?");
                    text.MixColor = Color.White;
                    text.MultiLine = true;
                    text.WidthResizePolicy = ResizePolicyType.FillToParent;
                    text.HeightResizePolicy = ResizePolicyType.DimensionDependency;
                    text.Padding = new Vector4(10.0f, 10.0f, 20.0f, 0.0f);
                    _popup.SetContent(text);
                    _popup.Focusable = true;
                    _popup.SetDisplayState(Popup.DisplayStateType.Hidden);

                    button.Clicked += (obj, ee) =>
                    {
                        _stage.GetDefaultLayer().Add(_popup);
                        _popup.SetDisplayState(Popup.DisplayStateType.Shown);
                        FocusManager.Instance.SetCurrentFocusView(View.DownCast((_popup.FindChildByName("Footer")).FindChildByName("OKButton")));
                        return true;
                    };
                    _contentContainer.AddChild(button, new TableView.CellPosition(((uint)idx / 5) * 2 + 1, (uint)idx % 5));
                }
                if (item.name.CompareTo("Toast") == 0)
                {
                    PushButton button = new PushButton();
                    button.LabelText = "Toast";
                    button.ParentOrigin = ParentOrigin.Center;
                    button.AnchorPoint = AnchorPoint.Center;
                    button.Clicked += (obj, ee) =>
                    {
                        TypeInfo typeInfo = new TypeInfo(TypeRegistry.Get().GetTypeInfo("PopupToast"));
                        if (typeInfo)
                        {
                            BaseHandle baseHandle = typeInfo.CreateInstance();
                            if (baseHandle)
                            {
                                Popup toast = Popup.DownCast(baseHandle);
                                TextLabel text = new TextLabel("This is a Toast.\nIt will auto-hide itself");
                                text.TextColor = Color.White;
                                text.MultiLine = true;
                                text.HorizontalAlignment = "center";
                                toast.SetTitle(text);
                                _stage.GetDefaultLayer().Add(toast);
                                toast.SetDisplayState(Popup.DisplayStateType.Shown);
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
                ImageView notSupportView = new ImageView("/home/owner/apps_rw/NUISamples.TizenTV/res/images/not_yet_sign.png");
                notSupportView.Size = new Size(_stage.Size.Width * 0.2f, _stage.Size.Height * 0.25f, 0.0f);
                notSupportView.Focusable = true;
                _contentContainer.AddChild(notSupportView, new TableView.CellPosition(((uint)idx / 5) * 2 + 1, (uint)idx % 5));
            }
        }
        Popup CreatePopup()
        {
            Popup confirmationPopup = new Popup();

            Actor footer = new Actor();
            footer.Name = "Footer";
            footer.WidthResizePolicy = ResizePolicyType.FillToParent;
            footer.HeightResizePolicy = ResizePolicyType.Fixed;
            footer.Size = new Size(0.0f, 80.0f, 0.0f);
            footer.ParentOrigin = ParentOrigin.Center;
            footer.AnchorPoint = AnchorPoint.Center;

            PushButton okButton = CreateOKButton();
            okButton.ParentOrigin = ParentOrigin.Center;
            okButton.AnchorPoint = AnchorPoint.Center;
            okButton.WidthResizePolicy = ResizePolicyType.SizeFixedOffsetFromParent;
            okButton.HeightResizePolicy = ResizePolicyType.SizeFixedOffsetFromParent;
            okButton.SizeModeFactor = new Vector3(-20.0f, -20.0f, 0.0f);

            PushButton cancelButton = CreateCancelButton();
            cancelButton.ParentOrigin = ParentOrigin.Center;
            cancelButton.AnchorPoint = AnchorPoint.Center;
            cancelButton.WidthResizePolicy = ResizePolicyType.SizeFixedOffsetFromParent;
            cancelButton.HeightResizePolicy = ResizePolicyType.SizeFixedOffsetFromParent;
            cancelButton.SizeModeFactor = new Vector3(-20.0f, -20.0f, 0.0f);

            TableView controlLayout = new TableView(1, 2);
            controlLayout.ParentOrigin = ParentOrigin.Center;
            controlLayout.AnchorPoint = AnchorPoint.Center;
            controlLayout.WidthResizePolicy = ResizePolicyType.FillToParent;
            controlLayout.HeightResizePolicy = ResizePolicyType.FillToParent;
            controlLayout.SetCellPadding(new Size2D(10.0f, 10.0f));
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
            okayButton.Name = "OKButton";
            okayButton.LabelText = "OK";
            okayButton.Focusable = true;
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
            cancelButton.Focusable = true;
            cancelButton.Clicked += (obj, ee) =>
            {
                _popup.SetDisplayState(Popup.DisplayStateType.Hidden);
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
            Tizen.Log.Debug("NUI", "dali c# control-dashboard! main() is called!");

            Example example = new Example(Application.NewApplication("/home/owner/apps_rw/NUISamples.TizenTV/res/json/control-dashboard-theme.json"));
            example.MainLoop();
        }
    }
}
