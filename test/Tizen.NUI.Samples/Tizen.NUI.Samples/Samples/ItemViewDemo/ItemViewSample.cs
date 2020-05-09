using System;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;

namespace Tizen.NUI.Samples
{
    public class ZItemViewSample : IExample
    {
        private const float MIN_SWIPE_DISTANCE = 15.0f;
        private const float MIN_SWIPE_SPEED = 5.0f;
        private const float SCROLL_TO_ITEM_ANIMATION_TIME = 5.0f;
        private const float DEPTH_LAYOUT_ITEM_SIZE_FACTOR_PORTRAIT = 1.0f;
        private const float DEPTH_LAYOUT_ITEM_SIZE_FACTOR_LANDSCAPE = 0.8f;
        private const float DEPTH_LAYOUT_COLUMNS = 3.0f;
        private const int BUTTON_BORDER = -10;
        private const float ITEM_BORDER_SIZE = 2.0f;
        private const int ITEM_COUNT = 300;

        private string APPLICATION_TITLE = "ItemView";
        private string SPIRAL_LABEL = "Spiral";
        private string GRID_LABEL = "Grid";
        private string DEPTH_LABEL = "Depth";

        private string TOOLBAR_IMAGE = CommonResource.GetDaliResourcePath() + "ItemViewDemo/top-bar.png";
        private string EDIT_IMAGE = CommonResource.GetDaliResourcePath() + "ItemViewDemo/icon-edit.png";
        private string EDIT_IMAGE_SELECTED = CommonResource.GetDaliResourcePath() + "ItemViewDemo/icon-edit-selected.png";
        private string DELETE_IMAGE = CommonResource.GetDaliResourcePath() + "ItemViewDemo/icon-delete.png";
        private string DELETE_IMAGE_SELECTED = CommonResource.GetDaliResourcePath() + "ItemViewDemo/icon-delete-selected.png";
        private string REPLACE_IMAGE = CommonResource.GetDaliResourcePath() + "ItemViewDemo/icon-replace.png";
        private string REPLACE_IMAGE_SELECTED = CommonResource.GetDaliResourcePath() + "ItemViewDemo/icon-replace-selected.png";
        private string INSERT_IMAGE = CommonResource.GetDaliResourcePath() + "ItemViewDemo/icon-insert.png";
        private string INSERT_IMAGE_SELECTED = CommonResource.GetDaliResourcePath() + "ItemViewDemo/icon-insert-selected.png.png";
        private string SELECTED_IMAGE = CommonResource.GetDaliResourcePath() + "ItemViewDemo/item-select-check.png";

        private string SPIRAL_LAYOUT_IMAGE = CommonResource.GetDaliResourcePath() + "ItemViewDemo/icon-item-view-layout-spiral.png";
        private string SPIRAL_LAYOUT_IMAGE_SELECTED = CommonResource.GetDaliResourcePath() + "ItemViewDemo/icon-item-view-layout-spiral-selected.png";
        private string GRID_LAYOUT_IMAGE = CommonResource.GetDaliResourcePath() +  "ItemViewDemo/icon-item-view-layout-grid.png";
        private string GRID_LAYOUT_IMAGE_SELECTED = CommonResource.GetDaliResourcePath() +  "ItemViewDemo/icon-item-view-layout-grid-selected.png";
        private string DEPTH_LAYOUT_IMAGE = CommonResource.GetDaliResourcePath() +  "ItemViewDemo/icon-item-view-layout-depth.png";
        private string DEPTH_LAYOUT_IMAGE_SELECTED = CommonResource.GetDaliResourcePath() +  "ItemViewDemo/icon-item-view-layout-depth-selected.png";

        private ItemView mItemView;
        private ItemFactoryWrapper mItemFactoryWrapper;
        private PropertyMap mGridLayout;
        private PropertyMap mDepthLayout;
        private PropertyMap mSpiralLayout;
        private PropertyArray mLayout;
        private int mCurrentLayout = (int)AllImagesLayouts.SPIRAL_LAYOUT;
        private Mode mMode = Mode.MODE_NORMAL;

        private LongPressGestureDetector mLongPressGestureDetector;
        private TapGestureDetector mTapDetector;

        private Button mLayoutButton;
        private Button mEditButton;
        private Button mDeleteButton;
        private Button mInsertButton;
        private Button mReplaceButton;
        private TextLabel mTitle;
        private ImageView mToolBarBackground;

        private Layer mToolBarLayer;
        private View mContentView;

        private int mDurationSeconds = 250;

        public static Vector3 DepthLayoutItemSizeFunctionPortrait(float layoutWidth)
        {
            float width = (layoutWidth / (DEPTH_LAYOUT_COLUMNS + 1.0f)) * DEPTH_LAYOUT_ITEM_SIZE_FACTOR_PORTRAIT;

            // 1x1 aspect ratio
            return new Vector3(width, width, width);
        }

        public static Vector3 DepthLayoutItemSizeFunctionLandscape(float layoutWidth)
        {
            float width = (layoutWidth / (DEPTH_LAYOUT_COLUMNS + 1.0f)) * DEPTH_LAYOUT_ITEM_SIZE_FACTOR_LANDSCAPE;

            // 1x1 aspect ratio
            return new Vector3(width, width, width);
        }

        private void SetTitle(string title)
        {
            if(mTitle != null)
            {
                mTitle.Text = title;
            }
        }

        public void CreateGridLayout()
        {
            mGridLayout = new PropertyMap();
            mGridLayout.Insert((int)DefaultItemLayoutProperty.TYPE, new PropertyValue((int)DefaultItemLayoutType.GRID));
        }

        public void CreateDepthLayout()
        {
            mDepthLayout = new PropertyMap();
            mDepthLayout.Insert((int)DefaultItemLayoutProperty.TYPE, new PropertyValue((int)DefaultItemLayoutType.DEPTH));
        }

        public void CreateSpiralLayout()
        {
            mSpiralLayout = new PropertyMap();
            mSpiralLayout.Insert((int)DefaultItemLayoutProperty.TYPE, new PropertyValue((int)DefaultItemLayoutType.SPIRAL));
        }

        void SetLayoutImage()
        {
            if (mLayoutButton)
            {
                switch (mCurrentLayout)
                {
                    case (int)AllImagesLayouts.SPIRAL_LAYOUT:
                        {
                            var style = mLayoutButton.Style;
                            style.BackgroundImage = new Selector<string>() { Normal = SPIRAL_LAYOUT_IMAGE, Selected = SPIRAL_LAYOUT_IMAGE_SELECTED };
                            mLayoutButton.ApplyStyle(style);
                            break;
                        }

                    case (int)AllImagesLayouts.GRID_LAYOUT:
                        {
                            var style = mLayoutButton.Style;
                            style.BackgroundImage = new Selector<string>() { Normal = GRID_LAYOUT_IMAGE, Selected = GRID_LAYOUT_IMAGE_SELECTED };
                            mLayoutButton.ApplyStyle(style);
                            break;
                        }

                    case (int)AllImagesLayouts.DEPTH_LAYOUT:
                        {
                            var style = mLayoutButton.Style;
                            style.BackgroundImage = new Selector<string>() { Normal = DEPTH_LAYOUT_IMAGE, Selected = DEPTH_LAYOUT_IMAGE_SELECTED };
                            mLayoutButton.ApplyStyle(style);
                            break;
                        }
                    default:
                        break;
                }
            }
        }

        void ChangeLayout()
        {
            Animation animation = new Animation(mDurationSeconds);
            animation.Finished += AnimationFinished;
            animation.AnimateTo(mItemView, "Opacity", 0.0f);
            animation.Play();
        }

        void AnimationFinished(object sender, EventArgs e)
        {
            SetLayout(mCurrentLayout);
            Animation animation = new Animation(mDurationSeconds);
            animation.AnimateTo(mItemView, "Opacity", 1.0f);
            animation.Play();
        }

        private PropertyMap CreateImageVisual(string url)
        {
            PropertyMap temp = new PropertyMap();
            temp.Insert(Visual.Property.Type, new PropertyValue((int)Visual.Type.Image));
            temp.Insert(ImageVisualProperty.URL, new PropertyValue(url));
            return temp;
        }

        public void Activate()
        {
            Window window = NUIApplication.GetDefaultWindow();
            window.GetDefaultLayer().Behavior = Layer.LayerBehavior.Layer3D;
            window.BackgroundColor = Color.Black;
            CreateContentView();
            //CreateToolBarView();
            CreateToolBarLayer();

            CreateLayoutButton();
            CreateEditButton();
            CreateInsertButton();
            CreateReplaceButton();
            CreateDeleteButton();

            CreateGridLayout();
            CreateDepthLayout();
            CreateSpiralLayout();

            mLayout = new PropertyArray();
            mLayout.PushBack(new PropertyValue(mSpiralLayout));
            mLayout.PushBack(new PropertyValue(mDepthLayout));
            mLayout.PushBack(new PropertyValue(mGridLayout));


            mItemFactoryWrapper = new ItemFactoryWrapper();
            mItemFactoryWrapper.GetNumberDelegate = GetNumberOfItems;
            mItemFactoryWrapper.NewItemDelegate = NewItemView;

            mItemView = new ItemView(mItemFactoryWrapper);
            mItemView.PositionUsesPivotPoint = true;
            mItemView.ParentOrigin = Position.ParentOriginCenter;
            mItemView.PivotPoint = Position.PivotPointCenter;
            window.Add(mItemView);

            window.GetDefaultLayer().Behavior = Layer.LayerBehavior.Layer3D;

            mItemView.Layout = mLayout;
            mItemView.SetMinimumSwipeDistance(MIN_SWIPE_DISTANCE);
            mItemView.SetMinimumSwipeSpeed(MIN_SWIPE_SPEED);

            SetLayout((int)mCurrentLayout);
            SetLayoutTitle();
            SetLayoutImage();

            mLongPressGestureDetector = new LongPressGestureDetector();
            mLongPressGestureDetector.Attach(mItemView);
            mLongPressGestureDetector.Detected += OnLongPressGestureDetected;
        }

        private void OnLongPressGestureDetected(object source, LongPressGestureDetector.DetectedEventArgs e)
        {
            switch (e.LongPressGesture.State)
            {
                case Gesture.StateType.Started:
                    {
                        Size2D windowSize = NUIApplication.GetDefaultWindow().Size;
                        ItemRange range = new ItemRange(0, 0);
                        mItemView.GetItemsRange(range);

                        uint item = (e.LongPressGesture.ScreenPoint.Y < 0.5f * (float)windowSize.Height) ? range.begin : range.end;

                        mItemView.ScrollToItem(item, SCROLL_TO_ITEM_ANIMATION_TIME);

                        break;
                    }
                case Gesture.StateType.Finished:
                    {
                        PropertyMap attributes = new PropertyMap();
                        mItemView.DoAction("stopScrolling", attributes);
                        break;
                    }
                default:
                    {
                        break;
                    }
            }
        }

        void SetLayout(int layoutId)
        {
            Window window = NUIApplication.GetDefaultWindow();
            switch (mCurrentLayout)
            {
                case (int)AllImagesLayouts.SPIRAL_LAYOUT:
                case (int)AllImagesLayouts.DEPTH_LAYOUT:
                    {
                        window.GetDefaultLayer().Behavior = Layer.LayerBehavior.Layer3D;
                        break;
                    }
                case (int)AllImagesLayouts.GRID_LAYOUT:
                    {
                        window.GetDefaultLayer().Behavior = Layer.LayerBehavior.LayerUI;
                        break;
                    }
            }

            Size2D windowSize = window.Size;

            if (layoutId == (int)AllImagesLayouts.DEPTH_LAYOUT)
            {
                mDepthLayout.Insert((int)DefaultItemLayoutProperty.ITEM_SIZE, new PropertyValue(DepthLayoutItemSizeFunctionPortrait(800)));
                mLayout.Clear();
                mLayout.PushBack(new PropertyValue(mSpiralLayout));
                mLayout.PushBack(new PropertyValue(mDepthLayout));
                mLayout.PushBack(new PropertyValue(mGridLayout));
                mItemView.Layout = mLayout;
            }

            // Enable anchoring for depth layout only
            mItemView.SetAnchoring(layoutId == (int)AllImagesLayouts.DEPTH_LAYOUT);

            // Activate the layout
            mItemView.ActivateLayout((uint)layoutId, new Vector3(800, 800, 800), 0.0f);
        }



        public uint GetNumberOfItems()
        {
            return ITEM_COUNT;
        }

        public View NewItemView(uint itemId)
        {
            // Create an image view for this item
            string imagePath = CommonResource.GetDaliResourcePath() + "ItemViewDemo/gallery/gallery-medium-";
            uint id = itemId % 53;
            imagePath += id.ToString();
            imagePath += ".jpg";
            PropertyMap propertyMap = new PropertyMap();
            propertyMap.Insert(Visual.Property.Type, new PropertyValue((int)Visual.Type.Image));
            propertyMap.Insert(ImageVisualProperty.URL, new PropertyValue(imagePath));
            propertyMap.Insert(ImageVisualProperty.FittingMode, new PropertyValue((int)VisualFittingModeType.FitKeepAspectRatio));
            ImageView actor = new ImageView();
            actor.Image = propertyMap;
            actor.PositionZ = 0.0f;
            actor.Position = new Position(1000.0f, 0, -1000.0f);

            // Add a border image child actor
            ImageView borderActor = new ImageView();
            borderActor.ParentOrigin = ParentOrigin.Center;
            borderActor.PivotPoint = PivotPoint.Center;
            borderActor.PositionUsesPivotPoint = true;
            borderActor.HeightResizePolicy = ResizePolicyType.SizeFixedOffsetFromParent;
            borderActor.WidthResizePolicy = ResizePolicyType.SizeFixedOffsetFromParent;
            borderActor.SetSizeModeFactor(new Vector3(2.0f * ITEM_BORDER_SIZE, 2.0f * ITEM_BORDER_SIZE, 0.0f));
            borderActor.SetColorMode(ColorMode.UseParentColor);

            PropertyMap borderProperty = new PropertyMap();
            borderProperty.Insert(Visual.Property.Type, new PropertyValue((int)Visual.Type.Border));
            borderProperty.Insert(BorderVisualProperty.Color, new PropertyValue(Color.White));
            borderProperty.Insert(BorderVisualProperty.Size, new PropertyValue(ITEM_BORDER_SIZE));
            borderProperty.Insert(BorderVisualProperty.AntiAliasing, new PropertyValue(true));
            borderActor.Image = borderProperty;

            actor.Add(borderActor);

            Size spiralItemSize = new Size(30, 30, 0);
            // Add a checkbox child actor; invisible until edit-mode is enabled
            ImageView checkBox = new ImageView();
            checkBox.Name = "CheckBox";
            checkBox.SetColorMode(ColorMode.UseParentColor);
            checkBox.ParentOrigin = ParentOrigin.TopRight;
            checkBox.PivotPoint = PivotPoint.TopRight;
            checkBox.Size = spiralItemSize;
            checkBox.PositionZ = 0.1f;

            PropertyMap solidColorProperty = new PropertyMap();
            solidColorProperty.Insert(Visual.Property.Type, new PropertyValue((int)Visual.Type.Color));
            solidColorProperty.Insert(ColorVisualProperty.MixColor, new PropertyValue(new Color(0.0f, 0.0f, 0.0f, 0.6f)));
            checkBox.Image = solidColorProperty;

            if (Mode.MODE_REMOVE_MANY != mMode &&
                Mode.MODE_INSERT_MANY != mMode &&
                Mode.MODE_REPLACE_MANY != mMode)
            {
                checkBox.Hide();
            }
            borderActor.Add(checkBox);

            ImageView tick = new ImageView(SELECTED_IMAGE);
            tick.Name = "Tick";
            tick.ParentOrigin = ParentOrigin.TopRight;
            tick.PivotPoint = PivotPoint.TopRight;
            tick.Size = spiralItemSize;
            tick.Hide();
            checkBox.Add(tick);

            if (mTapDetector)
            {
                mTapDetector.Attach(actor);
            }
            return actor;
        }

        public void Deactivate()
        {
            if (mLayoutButton != null)
            {
                mLayoutButton.GetParent().Remove(mLayoutButton);
                mLayoutButton.Dispose();
            }

            if (mEditButton != null)
            {
                mEditButton.GetParent().Remove(mEditButton);
                mEditButton.Dispose();
            }

            if (mReplaceButton != null)
            {
                mReplaceButton.GetParent().Remove(mReplaceButton);
                mReplaceButton.Dispose();
            }

            if (mInsertButton != null)
            {
                mInsertButton.GetParent().Remove(mInsertButton);
                mInsertButton.Dispose();
            }

            if (mDeleteButton != null)
            {
                mDeleteButton.GetParent().Remove(mDeleteButton);
                mDeleteButton.Dispose();
            }

            if (mTitle != null)
            {
                mTitle.GetParent().Remove(mTitle);
                mTitle.Dispose();
            }

            if (mToolBarBackground != null)
            {
                mToolBarBackground.GetParent().Remove(mToolBarBackground);
                mToolBarBackground.Dispose();
            }

            if (mItemView != null)
            {
                mItemView.GetParent().Remove(mItemView);
                mItemView.Dispose();
            }

            if (mContentView != null)
            {
                NUIApplication.GetDefaultWindow().Remove(mContentView);
                mContentView.Dispose();
            }

            if (mToolBarLayer != null)
            {
                NUIApplication.GetDefaultWindow().RemoveLayer(mToolBarLayer);
                mToolBarLayer.Dispose();
            }

            NUIApplication.GetDefaultWindow().GetDefaultLayer().Behavior = Layer.LayerBehavior.Layer2D;
        }

        public void CreateContentView()
        {
            mContentView = new View();
            mContentView.ParentOrigin = ParentOrigin.Center;
            mContentView.PivotPoint = PivotPoint.Center;
            mContentView.PositionUsesPivotPoint = true;
            mContentView.WidthResizePolicy = ResizePolicyType.FillToParent;
            mContentView.HeightResizePolicy = ResizePolicyType.FillToParent;
            NUIApplication.GetDefaultWindow().Add(mContentView);

            mContentView.LowerToBottom();
        }


        private void CreateToolBarLayer()
        {
            mToolBarLayer = new Layer();
            mToolBarLayer.Name = "TOOLBAR";
            mToolBarLayer.SetAnchorPoint(PivotPoint.TopCenter);
            mToolBarLayer.SetParentOrigin(ParentOrigin.TopCenter);
            mToolBarLayer.SetResizePolicy(ResizePolicyType.FillToParent, DimensionType.Width);
            mToolBarLayer.SetSize(0, 80);
            NUIApplication.GetDefaultWindow().AddLayer(mToolBarLayer);

            mToolBarLayer.RaiseToTop();

            mToolBarBackground = new ImageView();
            mToolBarBackground.ParentOrigin = ParentOrigin.TopLeft;
            mToolBarBackground.PivotPoint = PivotPoint.TopLeft;
            mToolBarBackground.PositionUsesPivotPoint = true;
            mToolBarBackground.WidthResizePolicy = ResizePolicyType.FillToParent;
            mToolBarBackground.HeightResizePolicy = ResizePolicyType.FillToParent;
            mToolBarBackground.ResourceUrl = TOOLBAR_IMAGE;
            mToolBarLayer.Add(mToolBarBackground);

            mTitle = new TextLabel();
            mTitle.ParentOrigin = ParentOrigin.TopLeft;
            mTitle.PivotPoint = PivotPoint.TopLeft;
            mTitle.PositionUsesPivotPoint = true;
            mTitle.PointSize = 10.0f;
            mTitle.WidthResizePolicy = ResizePolicyType.FillToParent;
            mTitle.HeightResizePolicy = ResizePolicyType.FillToParent;
            mTitle.Text = APPLICATION_TITLE;
            mTitle.VerticalAlignment = VerticalAlignment.Center;
            mTitle.HorizontalAlignment = HorizontalAlignment.Center;
            mToolBarLayer.Add(mTitle);
        }

        private void CreateLayoutButton()
        {
            mLayoutButton = new Button();
            var style = mLayoutButton.Style;
            style.BackgroundImage = new Selector<string>() { Normal = SPIRAL_LAYOUT_IMAGE, Selected = SPIRAL_LAYOUT_IMAGE_SELECTED };
            mLayoutButton.ApplyStyle(style);
            mLayoutButton.IsSelectable = true;
            mLayoutButton.Size2D = new Size2D(34, 34);
            mLayoutButton.ParentOrigin = ParentOrigin.TopRight;
            mLayoutButton.PivotPoint = PivotPoint.TopRight;
            mLayoutButton.Position2D = new Position2D(0, 25);
            mLayoutButton.PositionUsesPivotPoint = true;
            mLayoutButton.LeaveRequired = true;
            mLayoutButton.ClickEvent += (obj, e) =>
            {
                mCurrentLayout = (mCurrentLayout + 1) % (int)mItemView.GetLayoutCount();
                ChangeLayout();

                SetLayoutTitle();
                SetLayoutImage();
            };
            mToolBarLayer.Add(mLayoutButton);
        }

        public void CreateEditButton()
        {
            mEditButton = new Button();
            var style = mEditButton.Style;
            style.BackgroundImage = new Selector<string>() { Normal = EDIT_IMAGE, Selected = EDIT_IMAGE_SELECTED };
            mEditButton.ApplyStyle(style);
            mEditButton.IsSelectable = true;
            mEditButton.Size2D = new Size2D(34, 34);
            mEditButton.ParentOrigin = ParentOrigin.TopLeft;
            mEditButton.PivotPoint = PivotPoint.TopLeft;
            mEditButton.Position2D = new Position2D(5, 25);
            mEditButton.PositionUsesPivotPoint = true;
            mEditButton.LeaveRequired = true;
            mEditButton.ClickEvent += (obj, e) =>
            {
                SwitchToNextMode();
            };
            mToolBarLayer.Add(mEditButton);
        }

        private void SetLayoutTitle()
        {
            if (Mode.MODE_NORMAL == mMode)
            {
                string title = APPLICATION_TITLE;
                switch (mCurrentLayout)
                {
                    case (int)AllImagesLayouts.SPIRAL_LAYOUT:
                        title = title + ": " + SPIRAL_LABEL;
                        break;
                    case (int)AllImagesLayouts.GRID_LAYOUT:
                        title = title + ": " + GRID_LABEL;
                        break;
                    case (int)AllImagesLayouts.DEPTH_LAYOUT:
                        title = title + ": " + DEPTH_LABEL;
                        break;
                    default:
                        break;
                }
                SetTitle(title);
            }
        }

        private void CreateDeleteButton()
        {
            mDeleteButton = new Button();
            var style = mDeleteButton.Style;
            style.BackgroundImage = new Selector<string>() { Normal = DELETE_IMAGE, Selected = DELETE_IMAGE_SELECTED };
            mDeleteButton.ApplyStyle(style);
            mDeleteButton.IsSelectable = true;
            mDeleteButton.ParentOrigin = ParentOrigin.BottomRight;
            mDeleteButton.PivotPoint = PivotPoint.BottomRight;
            mDeleteButton.PositionUsesPivotPoint = true;
            mDeleteButton.Position2D = new Position2D(BUTTON_BORDER, BUTTON_BORDER);
            mDeleteButton.DrawMode = DrawModeType.Overlay2D;
            mDeleteButton.Size2D = new Size2D(50, 50);
            mDeleteButton.LeaveRequired = true;
            mDeleteButton.Hide();
            mDeleteButton.ClickEvent += (obj, e) =>
            {
                ItemIdContainer removeList = new ItemIdContainer();
                for (uint i = 0; i < mItemView.GetChildCount(); ++i)
                {
                    View child = mItemView.GetChildAt(i);
                    if (child != null)
                    {
                        View tick = child.FindChildByName("Tick");

                        if (tick != null && tick.Visibility)
                        {
                            removeList.Add(mItemView.GetItemId(child));
                        }
                    }
                }

                if (removeList.Count != 0)
                {
                    mItemView.RemoveItems(removeList, 0.5f);
                }
            };
            NUIApplication.GetDefaultWindow().Add(mDeleteButton);
        }

        private void CreateInsertButton()
        {
            mInsertButton = new Button();
            var style = mInsertButton.Style;
            style.BackgroundImage = new Selector<string>() { Normal = INSERT_IMAGE, Selected = INSERT_IMAGE_SELECTED };
            mInsertButton.ApplyStyle(style);
            mInsertButton.IsSelectable = true;
            mInsertButton.ParentOrigin = ParentOrigin.BottomRight;
            mInsertButton.PivotPoint = PivotPoint.BottomRight;
            mInsertButton.PositionUsesPivotPoint = true;
            mInsertButton.Position2D = new Position2D(BUTTON_BORDER, BUTTON_BORDER);
            mInsertButton.DrawMode = DrawModeType.Overlay2D;
            mInsertButton.Size2D = new Size2D(50, 50);
            mInsertButton.LeaveRequired = true;
            mInsertButton.Hide();
            mInsertButton.ClickEvent += (obj, e) =>
            {
                ItemContainer insertList = new ItemContainer();
                Random random = new Random();
                for (uint i = 0; i < mItemView.GetChildCount(); ++i)
                {
                    View child = mItemView.GetChildAt(i);
                    if (child != null)
                    {
                        View tick = child.FindChildByName("Tick");

                        if (tick != null && tick.Visibility)
                        {
                            insertList.Add(new Item(mItemView.GetItemId(child), NewItemView((uint)random.Next(52))));
                        }
                    }
                }
                if (insertList.Count != 0)
                {
                    mItemView.InsertItems(insertList, 0.5f);
                }
            };
            NUIApplication.GetDefaultWindow().Add(mInsertButton);
        }

        private void CreateReplaceButton()
        {
            mReplaceButton = new Button();
            var style = mReplaceButton.Style;
            style.BackgroundImage = new Selector<string>() { Normal = REPLACE_IMAGE, Selected = REPLACE_IMAGE_SELECTED };
            mReplaceButton.ApplyStyle(style);
            mReplaceButton.IsSelectable = true;
            mReplaceButton.ParentOrigin = ParentOrigin.BottomRight;
            mReplaceButton.PivotPoint = PivotPoint.BottomRight;
            mReplaceButton.PositionUsesPivotPoint = true;
            mReplaceButton.Position = new Position(BUTTON_BORDER, BUTTON_BORDER);
            mReplaceButton.DrawMode = DrawModeType.Overlay2D;
            mReplaceButton.Size = new Size(50, 50);
            mReplaceButton.LeaveRequired = true;
            mReplaceButton.Hide();
            mReplaceButton.ClickEvent += (obj, e) =>
            {
                ItemContainer replaceList = new ItemContainer();
                Random random = new Random();
                for (uint i = 0; i < mItemView.GetChildCount(); ++i)
                {
                    View child = mItemView.GetChildAt(i);
                    if (child != null)
                    {
                        View tick = child.FindChildByName("Tick");

                        if (tick != null && tick.Visibility)
                        {
                            replaceList.Add(new Item(mItemView.GetItemId(child), NewItemView((uint)random.Next(52))));
                        }
                    }
                }

                if (replaceList.Count != 0)
                {
                    mItemView.ReplaceItems(replaceList, 0.5f);
                }
            };
            NUIApplication.GetDefaultWindow().Add(mReplaceButton);
        }

        void SwitchToNextMode()
        {
            switch (mMode)
            {
                case Mode.MODE_REMOVE:
                    {
                        ExitRemoveMode();
                        mMode = Mode.MODE_REMOVE_MANY;
                        EnterRemoveManyMode();
                        break;
                    }

                case Mode.MODE_REMOVE_MANY:
                    {
                        ExitRemoveManyMode();
                        mMode = Mode.MODE_INSERT;
                        EnterInsertMode();
                        break;
                    }

                case Mode.MODE_INSERT:
                    {
                        ExitInsertMode();
                        mMode = Mode.MODE_INSERT_MANY;
                        EnterInsertManyMode();
                        break;
                    }

                case Mode.MODE_INSERT_MANY:
                    {
                        ExitInsertManyMode();
                        mMode = Mode.MODE_REPLACE;
                        EnterReplaceMode();
                        break;
                    }

                case Mode.MODE_REPLACE:
                    {
                        ExitReplaceMode();
                        mMode = Mode.MODE_REPLACE_MANY;
                        EnterReplaceManyMode();
                        break;
                    }

                case Mode.MODE_REPLACE_MANY:
                    {
                        ExitReplaceManyMode();
                        mMode = Mode.MODE_NORMAL;
                        SetLayoutTitle();
                        break;
                    }

                case Mode.MODE_NORMAL:
                default:
                    {
                        mMode = Mode.MODE_REMOVE;
                        EnterRemoveMode();
                        break;
                    }
            }
        }

        void EnterRemoveMode()
        {
            SetTitle("Edit: Remove");
            mTapDetector = new TapGestureDetector();

            for (uint i = 0; i < mItemView.GetChildCount(); ++i)
            {
                if (mItemView.GetChildAt(i) != null)
                {
                    mTapDetector.Attach(mItemView.GetChildAt(i));
                }
            }

            mTapDetector.Detected += (obj, e) =>
            {
                View item = e.View;
                if (item != null)
                {
                    mItemView.RemoveItem(mItemView.GetItemId(item), 0.5f);
                }
            };
        }

        void ExitRemoveMode()
        {
            mTapDetector.DetachAll();
            mTapDetector.Reset();
        }

        void EnterRemoveManyMode()
        {
            SetTitle("Edit: Remove Many");
            mDeleteButton.Show();

            mTapDetector = new TapGestureDetector();

            for (uint i = 0; i < mItemView.GetChildCount(); ++i)
            {
                View child = mItemView.GetChildAt(i);
                if (child != null)
                {
                    View box = child.FindChildByName("CheckBox");
                    if (box)
                    {
                        mTapDetector.Attach(child);
                        box.Show();
                    }
                }
            }

            mTapDetector.Detected += (obj, e) =>
            {
                View view = e.View;
                if (view != null)
                {
                    Console.WriteLine("haha");
                }
                else
                {
                    Console.WriteLine("hehe");
                }
                View tick = view.FindChildByName("Tick");
                if (tick)
                {
                    if (tick.Visibility)
                    {
                        tick.Hide();
                    }
                    else
                    {
                        tick.Show();
                    }
                }
            };
        }

        void ExitRemoveManyMode()
        {
            for (uint i = 0; i < mItemView.GetChildCount(); ++i)
            {
                View child = mItemView.GetChildAt(i);
                if (child != null)
                {
                    View box = child.FindChildByName("CheckBox");

                    if (box)
                    {
                        box.Hide();

                        View tick = box.FindChildByName("Tick");
                        if (tick)
                        {
                            tick.Hide();
                        }
                    }
                }
            }
            mTapDetector.Reset();
            mDeleteButton.Hide();
        }

        void EnterInsertMode()
        {
            SetTitle("Edit: Insert");
            mTapDetector = new TapGestureDetector();

            for (uint i = 0; i < mItemView.GetChildCount(); ++i)
            {
                if (mItemView.GetChildAt(i) != null)
                {
                    mTapDetector.Attach(mItemView.GetChildAt(i));
                }

            }
            mTapDetector.Detected += (obj, e) =>
            {
                if (e.View != null)
                {
                    uint id = mItemView.GetItemId(e.View);
                    Random random = new Random();

                    View newActor = NewItemView((uint)random.Next(52));

                    mItemView.InsertItem(new Item(id, newActor), 0.5f);
                }
                else
                {
                    Tizen.Log.Fatal("NUI", "e.View is null when EnterInsertMode!");
                }
            };
        }

        void ExitInsertMode()
        {
            mTapDetector.DetachAll();
            mTapDetector.Reset();
        }
        void EnterInsertManyMode()
        {
            SetTitle("Edit: Insert Many");
            mInsertButton.Show();

            mTapDetector = new TapGestureDetector();

            for (uint i = 0; i < mItemView.GetChildCount(); ++i)
            {
                View child = mItemView.GetChildAt(i);
                if (child != null)
                {
                    View box = child.FindChildByName("CheckBox");

                    if (box)
                    {
                        mTapDetector.Attach(child);
                        box.Show();
                    }
                }
            }
            mTapDetector.Detected += (obj, e) =>
            {
                View tick = (e.View).FindChildByName("Tick");
                if (tick)
                {
                    if (tick.Visibility)
                    {
                        tick.Hide();
                    }
                    else
                    {
                        tick.Show();
                    }
                }
            };
        }

        void ExitInsertManyMode()
        {
            for (uint i = 0; i < mItemView.GetChildCount(); ++i)
            {
                View child = mItemView.GetChildAt(i);
                if (child != null)
                {
                    View box = child.FindChildByName("CheckBox");

                    if (box)
                    {
                        box.Hide();

                        View tick = box.FindChildByName("Tick");
                        if (tick)
                        {
                            tick.Hide();
                        }
                    }
                }
            }
            mTapDetector.Reset();
            mInsertButton.Hide();
        }

        void EnterReplaceMode()
        {
            SetTitle("Edit: Replace");
            mTapDetector = new TapGestureDetector();

            for (uint i = 0; i < mItemView.GetChildCount(); ++i)
            {
                if (mItemView.GetChildAt(i) != null)
                {
                    mTapDetector.Attach(mItemView.GetChildAt(i));
                }
            }

            mTapDetector.Detected += (obj, e) =>
            {
                Random random = new Random();
                mItemView.ReplaceItem(new Item(mItemView.GetItemId(e.View), NewItemView((uint)random.Next(52))), 0.5f);
            };
        }

        void ExitReplaceMode()
        {
            mTapDetector.DetachAll();
            mTapDetector.Reset();
        }


        void EnterReplaceManyMode()
        {
            SetTitle("Edit: Replace Many");
            mReplaceButton.Show();

            mTapDetector = new TapGestureDetector();

            for (uint i = 0; i < mItemView.GetChildCount(); ++i)
            {
                View child = mItemView.GetChildAt(i);
                View box = child.FindChildByName("CheckBox");

                if (box)
                {
                    mTapDetector.Attach(child);
                    box.Show();
                }
            }

            mTapDetector.Detected += (obj, e) =>
            {
                View tick = (e.View).FindChildByName("Tick");
                if (tick)
                {
                    if (tick.Visibility)
                    {
                        tick.Hide();
                    }
                    else
                    {
                        tick.Show();
                    }
                }
            };
        }
        void ExitReplaceManyMode()
        {
            for (uint i = 0; i < mItemView.GetChildCount(); ++i)
            {
                View child = mItemView.GetChildAt(i);
                View box = child.FindChildByName("CheckBox");

                if (box)
                {
                    box.Hide();

                    View tick = box.FindChildByName("Tick");
                    if (tick)
                    {
                        tick.Hide();
                    }
                }
            }
            mTapDetector.Reset();
            mReplaceButton.Hide();
        }

    }
}
