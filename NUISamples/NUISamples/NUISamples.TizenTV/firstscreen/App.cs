using Tizen.NUI;
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using Tizen.NUI.Constants;

namespace FirstScreen
{
    public class FirstScreenApp : NUIApplication
    {
        //private Application _application;                  // Reference to Dali Application.
        private Stage _stage;                              // Reference to Dali stage.
        private Size2D _stageSize;                        // Reference to Dali stage size.

        private View _topContainer;                        // Top Container added to the Stage will contain Poster ScrollContainers.
        private View _bottomContainer;                     // Bottom Container added to the Stage will contain Menu ScrollContainer.
        private int _currentPostersContainerID;            // Current Poster Container ID visible on the Top Container / Stage.
        private int _totalPostersContainers;               // Number of Poster ScrollContainers to be added on Top Container.
        private List<ScrollContainer> _postersContainer;   // List collection of Poster ScrollContainers used on the Top Container in this demo application.
        private ScrollContainer _menuContainer;            // Menu ScrollContainer used on the Bottom Container in this demo application.
        private Layer _bottomClipLayer;                    // Clip layer (Dali Clip Layer instance) used for Bottom Container.
        private Layer _topClipLayer;                       // Clip layer (Dali Clip Layer instance) used for Top Container.

        private FocusEffect _focusEffect;                  // FocusEffect is used to apply Focus animation effect on any supplied item/image.
        private string _imagePath;                         // Contains the physical location of all images used in the demo application.

        private ImageView _keyboardFocusIndicator;         // Reference to the ImageView (Keyboard Focus indicator) applied to the focused item on ScrollContainer.
        private ImageView _launcherSeparator;              // Reference to the ImageView used for launcher separation (Launcher consists of three image icons on left of Menu ScrollContainer).
        private ImageView[] launcherIcon;                  // ImageViews used for launcher Icons.
        private Animation _showBottomContainerAnimation;   // Animation used to show/unhide Bottom Container (Menu ScrollContainer) when it is focused.
        private Animation _hideBottomContainerAnimation;   // Animation used to hide Bottom Container (Menu ScrollContainer) when it is focused.
        private Animation _showAnimation;                  // Animation used to move Poster scrollContainer from bottom to top and make it non-transparent.
        private Animation _hideAnimation;                  // Animation used to make the unused specified Poster scrollContainer transparent.
        private ScrollContainer _hideScrollContainer;      // The unused Poster scrollContainer which needs to be transparent.
        FocusManager _keyboardFocusManager;        // Reference to Dali KeyboardFocusManager.

        protected override void OnCreate()
        {
            base.OnCreate();
            OnInitialize();
        }


        // Create Items for Poster ScrollContainer
        private void CreatePosters()
        {
            for (int j = 0; j < _totalPostersContainers; j++)
            {
                View posterContainer = _postersContainer[j].Container;
                for (int i = 0; i < Constants.PostersItemsCount; i++)
                {
                    if (j % _totalPostersContainers == 0)
                    {
                        View item = new ImageView(_imagePath + "/poster" + j + "/" + (i % 14) + ".jpg");
                        item.Name = ("poster-item-" + _postersContainer[j].ItemCount);
                        _postersContainer[j].Add(item);
                    }
                    else
                    {
                        View item = new ImageView(_imagePath + "/poster" + j + "/" + (i % 6) + ".jpg");
                        item.Name = ("poster-item-" + _postersContainer[j].ItemCount);
                        _postersContainer[j].Add(item);
                    }
                }

                if (j == 0)
                {
                    Show(_postersContainer[j]);
                }
                else
                {
                    Hide(_postersContainer[j]);
                }

                _postersContainer[j].SetFocused(false);
            }

            _currentPostersContainerID = 0;
        }

        // Create Items for Menu ScrollContainer
        private void CreateMenu()
        {
            View menuContainer = _menuContainer.Container;
            menuContainer.Position = new Position(Constants.LauncherWidth, 0.0f, 0.0f);

            for (int i = 0; i < Constants.MenuItemsCount; i++)
            {
                View menuItem = new ImageView(_imagePath + "/menu/" + i % 7 + ".png");
                menuItem.Name = ("menu-item-" + _menuContainer.ItemCount);
                _menuContainer.Add(menuItem);
            }
        }

        private View OnKeyboardPreFocusChangeSignal(object source, FocusManager.PreFocusChangeEventArgs e)
        {
            if (!e.CurrentView && !e.ProposedView)
            {
                return _menuContainer;
            }

            Actor actor = _menuContainer.Container;

            if (e.Direction == View.FocusDirection.Up)
            {
                // Move the Focus to Poster ScrollContainer and hide Bottom Container (Menu ScrollContainer)
                if (_menuContainer.IsFocused)
                {
                    actor = _postersContainer[_currentPostersContainerID].GetCurrentFocusedActor();
                    _menuContainer.SetFocused(false);
                    _postersContainer[_currentPostersContainerID].SetFocused(true);
                    HideBottomContainer();

                    // Also apply Focus animation on Focused item on Poster ScrollContainer
                    FocusAnimation(_postersContainer[_currentPostersContainerID], FocusEffectDirection.BottomToTop);
                }
            }
            else if (e.Direction == View.FocusDirection.Down)
            {
                // Show Bottom Container (Menu ScrollContainer) and move the Focus to it
                if (!_menuContainer.IsFocused)
                {
                    ShowBottomContainer();
                    actor = _menuContainer.GetCurrentFocusedActor();
                    _postersContainer[_currentPostersContainerID].SetFocused(false);
                    _menuContainer.SetFocused(true);

                    // Also apply Focus animation on Focused item on Menu ScrollContainer
                    FocusAnimation(_menuContainer, FocusEffectDirection.TopToBottom);
                }
            }
            else
            {
                actor = e.ProposedView;
            }

            if (e.Direction == View.FocusDirection.Left)
            {
                if (_menuContainer.IsFocused)
                {
                    int id = _menuContainer.FocusedItemID % _totalPostersContainers;
                    if (id != _currentPostersContainerID)
                    {
                        Hide(_postersContainer[_currentPostersContainerID]);
                        _currentPostersContainerID = id;

                        Show(_postersContainer[_currentPostersContainerID]);
                    }
                }
            }
            else if (e.Direction == View.FocusDirection.Right)
            {
                if (_menuContainer.IsFocused)
                {
                    int id = _menuContainer.FocusedItemID % _totalPostersContainers;
                    if (id != _currentPostersContainerID)
                    {
                        Hide(_postersContainer[_currentPostersContainerID]);
                        _currentPostersContainerID = id;
                        Show(_postersContainer[_currentPostersContainerID]);
                    }
                }
            }

            return (Tizen.NUI.View)actor;
        }

        // Perform Focus animation Effect on the current Focused Item on ScrollContainer.
        private void FocusAnimation(ScrollContainer scrollContainer, FocusEffectDirection direction)
        {
            _focusEffect.FocusAnimation(scrollContainer.GetCurrentFocusedActor(), scrollContainer.ItemSize, 1000, direction);
        }

        // Perform Show animation on ScrollContainer (used only for Poster Container)
        private void Show(ScrollContainer scrollContainer)
        {
            scrollContainer.Add(scrollContainer.Container);

            _hideScrollContainer = null;

            // This animation will move Poster scrollContainer from bottom to top and make it non-transparent.
            _showAnimation = new Animation(350);
            _showAnimation.AnimateTo(scrollContainer.Container, "ColorAlpha", 1.0f);

            scrollContainer.Container.PositionY = scrollContainer.Container.Position.Y + 200.0f;
            float targetPositionY = scrollContainer.Container.Position.Y - 200.0f;

            _showAnimation.AnimateTo(scrollContainer.Container, "PositionY", targetPositionY, new AlphaFunction(AlphaFunction.BuiltinFunctions.EaseOutSine));

            _showAnimation.Play();
        }

        // Perform Hide animation on ScrollContainer (used only for Poster Container)
        private void Hide(ScrollContainer scrollContainer)
        {
            if (_hideAnimation)
            {
                _hideAnimation.Clear();
                _hideAnimation.Reset();
            }

            int duration = 350;
            _hideAnimation = new Animation(duration);
            _hideAnimation.Duration = duration;
            _hideAnimation.AnimateTo(scrollContainer.Container, "ColorAlpha", 0.0f, 0, (int)((float)duration * 0.75f), new AlphaFunction(AlphaFunction.BuiltinFunctions.EaseOutSine));
            _hideAnimation.Finished += OnHideAnimationFinished;
            _hideScrollContainer = scrollContainer;
            _hideAnimation.Play();
        }

        // This removes all the items from the specified unused Poster ScrollContainer (hence Stage) to improve performance.
        private void OnHideAnimationFinished(object source, EventArgs e)
        {
            if (_hideScrollContainer)
            {
                _hideScrollContainer.Remove(_hideScrollContainer.Container);
            }
        }

        // Hide Bottom Container (Menu ScrollContainer) when it is not focused
        private void HideBottomContainer()
        {
            _topClipLayer.ClippingBox = new Rectangle(0,
                                                        Convert.ToInt32(_stageSize.Height * Constants.TopContainerPositionFactor),
                                                        Convert.ToInt32((_stageSize.Width)),
                                                        Convert.ToInt32((_stageSize.Height * Constants.TopClipLayerExpandHeightFactor)));  // X, Y, Width, Height


            _hideBottomContainerAnimation.AnimateTo(_bottomContainer, "Position", new Position(0.0f, _stageSize.Height * Constants.BottomContainerHidePositionFactor, 0.0f),
                    new AlphaFunction(AlphaFunction.BuiltinFunctions.EaseOutSine));

            _hideBottomContainerAnimation.Play();
        }

        // Show (unhide) Bottom Container (Menu ScrollContainer) when it is focused
        private void ShowBottomContainer()
        {
            _topClipLayer.ClippingBox = new Rectangle(0,
                                                        Convert.ToInt32(_stageSize.Height * Constants.TopContainerPositionFactor),
                                                        Convert.ToInt32((_stageSize.Width)),
                                                        Convert.ToInt32((_stageSize.Height * Constants.TopClipLayerHeightFactor)));  // X, Y, Width, Height

            _showBottomContainerAnimation.AnimateTo(_bottomContainer, "Position", new Position(0.0f, _stageSize.Height * Constants.BottomContainerShowPositionFactor, 0.0f),
                            new AlphaFunction(AlphaFunction.BuiltinFunctions.EaseOutSine));
            _showBottomContainerAnimation.Play();
        }

        // First screen demo Application initialisation
        private void OnInitialize()
        {
            Tizen.Log.Debug("NUI", "OnInitialize() is called!");
            Tizen.NUI.InternalSetting.DefaultParentOriginAsTopLeft = false;
            _hideScrollContainer = null;
            _stage = Stage.Instance;
            _stageSize = _stage.Size;
            _totalPostersContainers = Constants.TotalPostersContainers;
            _imagePath = Constants.ImageResourcePath;

            _postersContainer = new List<ScrollContainer>();
            _menuContainer = new ScrollContainer();

            _hideBottomContainerAnimation = new Animation(250);
            _showBottomContainerAnimation = new Animation(250);

            // Create a Top Container for poster items
            _topContainer = new View();
            _topContainer.Size = new Size(_stageSize.Width, _stageSize.Height * Constants.TopContainerHeightFactor, 0);
            _topContainer.Position = new Position(0.0f, _stageSize.Height * Constants.TopContainerPositionFactor, 0.0f);
            _topContainer.ParentOrigin = ParentOrigin.TopLeft;
            _topContainer.AnchorPoint = AnchorPoint.TopLeft;

            // Add a background to Top container
            PropertyMap visual = new PropertyMap();
            visual.Insert(Visual.Property.Type, new PropertyValue((int)Visual.Type.Image));
            visual.Insert(ImageVisualProperty.URL, new PropertyValue(_imagePath + "/focuseffect/background.png"));
            _topContainer.Background = visual;
            _topContainer.Name = "TopControl";

            // Create a Bottom Container
            _bottomContainer = new View();
            _bottomContainer.Size = new Size(_stageSize.Width, _stageSize.Height * Constants.BottomContainerHeightFactor, 0);
            _bottomContainer.Position = new Position(0.0f, _stageSize.Height * Constants.BottomContainerHidePositionFactor, 0.0f);
            _bottomContainer.ParentOrigin = ParentOrigin.TopLeft;
            _bottomContainer.AnchorPoint = AnchorPoint.TopLeft;

            // Add a background to Bottom Container
            visual = new PropertyMap();
            visual.Insert(Visual.Property.Type, new PropertyValue((int)Visual.Type.Image));
            visual.Insert(ImageVisualProperty.URL, new PropertyValue(_imagePath + "/focuseffect/background.png"));
            _bottomContainer.Background = visual;
            _bottomContainer.Name = "BottomControl";

            // Add both Top and Bottom Containers to Stage
            _stage.GetDefaultLayer().Add(_topContainer);
            _stage.GetDefaultLayer().Add(_bottomContainer);

            // Add a clip layer to Top Container
            _topClipLayer = new Layer();
            _topClipLayer.AnchorPoint = AnchorPoint.BottomCenter;
            _topClipLayer.ParentOrigin = ParentOrigin.BottomCenter;
            _topClipLayer.ClippingEnable = true;
            _topClipLayer.ClippingBox = new Rectangle(0,
                                                        Convert.ToInt32(_stageSize.Height * Constants.TopContainerPositionFactor),
                                                        Convert.ToInt32((_stageSize.Width)),
                                                        Convert.ToInt32((_stageSize.Height * Constants.TopClipLayerHeightFactor)));  // X, Y, Width, Height
            _topContainer.Add(_topClipLayer);

            // Create a SpotLight for items / images of both Poster and Menu ScrollContainers
            ImageView spotLight = new ImageView(_imagePath + "/focuseffect/highlight_spot.png");
            spotLight.WidthResizePolicy = ResizePolicyType.UseNaturalSize;
            spotLight.HeightResizePolicy = ResizePolicyType.UseNaturalSize;
            spotLight.ParentOrigin = ParentOrigin.Center;
            spotLight.AnchorPoint = AnchorPoint.Center;
            spotLight.Name = "spotLight";

            // Create a shadowBorder for items / images of Poster ScrollContainers
            ImageView shadowBorder = new ImageView(_imagePath + "/focuseffect/thumbnail_shadow.9.png");
            shadowBorder.ParentOrigin = ParentOrigin.Center;
            shadowBorder.AnchorPoint = AnchorPoint.Center;
            shadowBorder.WidthResizePolicy = ResizePolicyType.SizeFixedOffsetFromParent;
            shadowBorder.HeightResizePolicy = ResizePolicyType.SizeFixedOffsetFromParent;
            shadowBorder.SizeModeFactor = (new Vector3(32.0f, 41.0f, 0.0f));
            shadowBorder.Name = "poster shadowBorder";

            // Create Poster Containers and add them to Top Clip layer
            for (int i = 0; i < _totalPostersContainers; i++)
            {
                _postersContainer.Add(new ScrollContainer());
                _postersContainer[i].Container.Name = "poster" + i;
                if (i == 0)
                {
                    _postersContainer[i].ItemSize = new Size((_stageSize.Width * Constants.Poster0ItemWidthFactor) - Constants.PostersContainerPadding,
                                                                _stageSize.Height * Constants.PostersItemHeightFactor, 0.0f);
                }
                else
                {
                    _postersContainer[i].ItemSize = new Size((_stageSize.Width * Constants.Poster1ItemWidthFactor) - Constants.PostersContainerPadding,
                                                                _stageSize.Height * Constants.PostersItemHeightFactor, 0.0f);
                }

                _postersContainer[i].Gap = Constants.PostersContainerPadding;
                _postersContainer[i].MarginX = Constants.PostersContainerMargin;
                _postersContainer[i].OffsetYFator = Constants.PostersContainerOffsetYFactor;
                _postersContainer[i].Width = _stageSize.Width;
                _postersContainer[i].Height = _stageSize.Height * Constants.PostersContainerHeightFactor;
                _postersContainer[i].ShadowBorder = shadowBorder;
                _postersContainer[i].ShadowBorder.Position = new Position(0.0f, 4.0f, 0.0f);
                _postersContainer[i].SpotLight = spotLight;
                _topClipLayer.Add(_postersContainer[i]);
            }

            // Add a clip layer to Bottom Container
            _bottomClipLayer = new Layer();
            _bottomClipLayer.AnchorPoint = AnchorPoint.BottomCenter;
            _bottomClipLayer.ParentOrigin = ParentOrigin.BottomCenter;
            _bottomClipLayer.ClippingEnable = true;
            _bottomClipLayer.ClippingBox = new Rectangle(Convert.ToInt32(Constants.LauncherWidth),
                                                           Convert.ToInt32(_stageSize.Height * Constants.BottomContainerShowPositionFactor),
                                                           Convert.ToInt32((_stageSize.Width)),
                                                           Convert.ToInt32((_stageSize.Height - (_stageSize.Height * Constants.BottomClipLayerHeightFactor))));  // X, Y, Width, Height
            _bottomContainer.Add(_bottomClipLayer);

            // Add Launcher items to Bottom Container. Launcher is used to display three images on left of Menu ScrollContainer
            launcherIcon = new ImageView[Convert.ToInt32(Constants.LauncherItemsCount)];
            for (int launcherIndex = 0; launcherIndex < Constants.LauncherItemsCount; launcherIndex++)
            {
                launcherIcon[launcherIndex] = new ImageView(_imagePath + "/focuseffect/" + launcherIndex + "-normal.png");
                launcherIcon[launcherIndex].Name = "launcherIcon" + launcherIndex;
                launcherIcon[launcherIndex].WidthResizePolicy = ResizePolicyType.UseNaturalSize;
                launcherIcon[launcherIndex].HeightResizePolicy = ResizePolicyType.UseNaturalSize;
                launcherIcon[launcherIndex].ParentOrigin = ParentOrigin.CenterLeft;
                launcherIcon[launcherIndex].AnchorPoint = AnchorPoint.CenterLeft;
                launcherIcon[launcherIndex].Position = new Position(Constants.LauncherIconWidth * launcherIndex + Constants.LauncherLeftMargin, 0.0f, 0.0f);
                _bottomContainer.Add(launcherIcon[launcherIndex]);
            }

            // Add a shadow seperator image between last Launcher icon and Menu ScrollContainer
            _launcherSeparator = new ImageView(_imagePath + "/focuseffect/focus_launcher_shadow_n.png");
            _launcherSeparator.Name = "launcherSeparator";
            _launcherSeparator.WidthResizePolicy = ResizePolicyType.UseNaturalSize;
            _launcherSeparator.HeightResizePolicy = ResizePolicyType.FillToParent;
            _launcherSeparator.ParentOrigin = ParentOrigin.CenterLeft;
            _launcherSeparator.AnchorPoint = AnchorPoint.CenterLeft;
            _launcherSeparator.Position = new Position(Constants.LauncherIconWidth * Constants.LauncherItemsCount + Constants.LauncherLeftMargin, 0.0f, 0.0f);
            _bottomContainer.Add(_launcherSeparator);

            // Create Menu Container and add it to Bottom Clip Layer
            Size menuItemSize = new Size((_stageSize.Width * Constants.MenuItemWidthFactor) - Constants.MenuContainerPadding,
                                        _stageSize.Height * Constants.MenuItemHeightFactor, 0.0f);
            _menuContainer.Container.Name = "menu";
            _menuContainer.ItemSize = menuItemSize;
            _menuContainer.Gap = Constants.MenuContainerPadding;
            _menuContainer.MarginX = Constants.MenuContainerMargin;
            _menuContainer.OffsetYFator = Constants.MenuContainerOffsetYFactor;
            _menuContainer.OffsetX = Constants.LauncherWidth;
            _menuContainer.Width = _stageSize.Width - Constants.LauncherWidth;
            _menuContainer.Height = _stageSize.Height * Constants.MenuContainerHeightFactor;
            _menuContainer.ShadowBorder = new ImageView(_imagePath + "/focuseffect/focus_launcher_shadow.9.png");
            _menuContainer.ShadowBorder.Name = "_menuContainer.ShadowBorder";
            _menuContainer.ShadowBorder.Size = new Size(_menuContainer.ItemSize.Width + 40.0f, _menuContainer.ItemSize.Height + 50.0f, 0.0f);
            _menuContainer.ShadowBorder.Position = new Position(0.0f, 5.0f, 0.0f);
            _menuContainer.ShadowBorder.ParentOrigin = ParentOrigin.Center;
            _menuContainer.ShadowBorder.AnchorPoint = AnchorPoint.Center;
            //_menuContainer.ShadowBorder.MixColor = Color.Red;
            _menuContainer.SpotLight = spotLight;
            _bottomClipLayer.Add(_menuContainer);

            CreatePosters(); // Create Items for Poster ScrollContainer
            CreateMenu();    // Create Items for Menu ScrollContainer

            // Initialize PreFocusChange event of KeyboardFocusManager
            _keyboardFocusManager = FocusManager.Instance;
            _keyboardFocusManager.PreFocusChange += OnKeyboardPreFocusChangeSignal;

            _keyboardFocusIndicator = new ImageView(_imagePath + "/focuseffect/highlight_stroke.9.png");
            _keyboardFocusIndicator.ParentOrigin = ParentOrigin.Center;
            _keyboardFocusIndicator.AnchorPoint = AnchorPoint.Center;
            _keyboardFocusIndicator.WidthResizePolicy = ResizePolicyType.FillToParent;
            _keyboardFocusIndicator.HeightResizePolicy = ResizePolicyType.FillToParent;

            _keyboardFocusManager.FocusIndicator = (_keyboardFocusIndicator);

            _keyboardFocusManager.SetAsFocusGroup(_menuContainer, true);
            _keyboardFocusManager.SetAsFocusGroup(_postersContainer[0], true);
            _keyboardFocusManager.SetAsFocusGroup(_postersContainer[1], true);
            _keyboardFocusManager.FocusGroupLoop = (true);

            _focusEffect = new FocusEffect();

            // Move Fcous to Bottom Container (Menu ScrollContainer)
            ShowBottomContainer();
            _menuContainer.SetFocused(true);

#if true
            //test.
            TextLabel _dateOfTest = new TextLabel();
            _dateOfTest.WidthResizePolicy = ResizePolicyType.FillToParent;
            _dateOfTest.HeightResizePolicy = ResizePolicyType.SizeRelativeToParent;
            _dateOfTest.AnchorPoint = AnchorPoint.TopCenter;
            _dateOfTest.ParentOrigin = ParentOrigin.TopCenter;
            _dateOfTest.SizeModeFactor = new Vector3(0.0f, 0.1f, 0.0f);
            _dateOfTest.BackgroundColor = new Color(43.0f / 255.0f, 145.0f / 255.0f, 175.0f / 255.0f, 1.0f);
            _dateOfTest.TextColor = Color.White;
            _dateOfTest.Text = "  Common Interface Define Verification Test of 2017-02-10 #1";
            _dateOfTest.HorizontalAlignment = HorizontalAlignment.HorizontalAlignBegin;
            _dateOfTest.VerticalAlignment = VerticalAlignment.VerticalAlignCenter;
            _dateOfTest.PointSize = 12.0f;
            _dateOfTest.UnderlineEnabled = true;
            _stage.GetDefaultLayer().Add(_dateOfTest);
            Tizen.Log.Debug("NUI", "### 1) ColorMode = " + _dateOfTest.ColorMode);
            _dateOfTest.ColorMode = ColorMode.UseParentColor;
            Tizen.Log.Debug("NUI", "### 2) ColorMode = " + _dateOfTest.ColorMode);
            _dateOfTest.ColorMode = ColorMode.UseOwnMultiplyParentColor;
            Tizen.Log.Debug("NUI", "### 3) ColorMode = " + _dateOfTest.ColorMode);
            Tizen.Log.Debug("NUI", "### 1) DrawModeType = " + _dateOfTest.DrawMode);
            _dateOfTest.DrawMode = DrawModeType.Overlay2D;
            Tizen.Log.Debug("NUI", "### 2) DrawModeType = " + _dateOfTest.DrawMode);

#endif

        }
        
        [STAThread]
        static void _Main(string[] args)
        {
            Tizen.Log.Debug("NUI", "Main() is called! ");
            
            FirstScreenApp app = new FirstScreenApp();
            app.Run(args);
        }

    }
}
