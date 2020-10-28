
using Tizen.NUI.BaseComponents;
using Tizen.NUI.UIComponents;
using Tizen.NUI;

namespace NuiCommonUiSamples
{
    public class CubeTransitionEffect : IExample
    {
        static string DEMO_IMAGE_DIR = CommonResource.GetDaliResourcePath() + "CubeTransitionEffect/";

        string TOOLBAR_IMAGE = DEMO_IMAGE_DIR + "top-bar.png";
        string APPLICATION_TITLE_WAVE = "Cube Transition: Wave";
        string APPLICATION_TITLE_CROSS = "Cube Transition: Cross";
        string APPLICATION_TITLE_FOLD = "Cube Transition: Fold";
        string EFFECT_WAVE_IMAGE = DEMO_IMAGE_DIR + "icon-effect-wave.png";
        string EFFECT_WAVE_IMAGE_SELECTED = DEMO_IMAGE_DIR + "icon-effect-wave-selected.png";
        string EFFECT_CROSS_IMAGE = DEMO_IMAGE_DIR + "icon-effect-cross.png";
        string EFFECT_CROSS_IMAGE_SELECTED = DEMO_IMAGE_DIR + "icon-effect-cross-selected.png";
        string EFFECT_FOLD_IMAGE = DEMO_IMAGE_DIR + "icon-effect-fold.png";
        string EFFECT_FOLD_IMAGE_SELECTED = DEMO_IMAGE_DIR + "icon-effect-fold-selected.png";
        string SLIDE_SHOW_START_ICON = DEMO_IMAGE_DIR + "icon-play.png";
        string SLIDE_SHOW_START_ICON_SELECTED = DEMO_IMAGE_DIR + "icon-play-selected.png";
        string SLIDE_SHOW_STOP_ICON = DEMO_IMAGE_DIR + "icon-stop.png";
        string SLIDE_SHOW_STOP_ICON_SELECTED = DEMO_IMAGE_DIR + "icon-stop-selected.png";

        string[] IMAGES = new string[] {
          DEMO_IMAGE_DIR + "gallery-large-1.jpg",
          DEMO_IMAGE_DIR + "gallery-large-2.jpg",
          DEMO_IMAGE_DIR + "gallery-large-3.jpg",
          DEMO_IMAGE_DIR + "gallery-large-4.jpg",
          DEMO_IMAGE_DIR + "gallery-large-5.jpg",
          DEMO_IMAGE_DIR + "gallery-large-6.jpg",
          DEMO_IMAGE_DIR + "gallery-large-7.jpg",
          DEMO_IMAGE_DIR + "gallery-large-8.jpg",
          DEMO_IMAGE_DIR + "gallery-large-9.jpg",
          DEMO_IMAGE_DIR + "gallery-large-10.jpg",
          DEMO_IMAGE_DIR + "gallery-large-11.jpg",
          DEMO_IMAGE_DIR + "gallery-large-12.jpg",
          DEMO_IMAGE_DIR + "gallery-large-13.jpg",
          DEMO_IMAGE_DIR + "gallery-large-14.jpg",
          DEMO_IMAGE_DIR + "gallery-large-15.jpg",
          DEMO_IMAGE_DIR + "gallery-large-16.jpg",
          DEMO_IMAGE_DIR + "gallery-large-17.jpg",
          DEMO_IMAGE_DIR + "gallery-large-18.jpg",
          DEMO_IMAGE_DIR + "gallery-large-19.jpg",
          DEMO_IMAGE_DIR + "gallery-large-20.jpg",
          DEMO_IMAGE_DIR + "gallery-large-21.jpg",
        };

        const int NUM_IMAGES = 21;

        // the number of cubes: NUM_COLUMNS*NUM_ROWS
        // better choose the numbers that can divide viewAreaSize.x
        const int NUM_COLUMNS_WAVE = 16;
        const int NUM_COLUMNS_CROSS = 8;
        const int NUM_COLUMNS_FOLD = 8;
        // better choose the numbers that can divide viewAreaSize.y
        const int NUM_ROWS_WAVE = 20;
        const int NUM_ROWS_CROSS = 10;
        const int NUM_ROWS_FOLD = 10;
        //transition effect duration
        const float ANIMATION_DURATION_WAVE = 1.5f;
        const float ANIMATION_DURATION_CROSS = 1.0f;
        const float ANIMATION_DURATION_FOLD = 1.0f;
        //transition effect displacement
        const float CUBE_DISPLACEMENT_WAVE = 70.0f;
        const float CUBE_DISPLACEMENT_CROSS = 30.0f;

        // The duration of the current image staying on screen when slideshow is on
        const int VIEWINGTIME = 2000; // 2 seconds

        private View tool_bar;
        private TextLabel mTitle;
        private Layer content_layer;
        private View mContent;
        private ToggleButton toggle_button;
        private PushButton mSlideshowButton;

        private Texture mCurrentTexture;
        private Texture mNextTexture;
        private uint mIndex = 0;
        private bool mIsImageLoading = false;

        private PanGestureDetector mPanGestureDetector;

        private Tizen.NUI.CubeTransitionEffect mCubeWaveEffect;
        private Tizen.NUI.CubeTransitionEffect mCubeCrossEffect;
        private Tizen.NUI.CubeTransitionEffect mCubeFoldEffect;
        private Tizen.NUI.CubeTransitionEffect mCurrentEffect;

        private Timer mViewTimer;
        private bool mSlideshow = false;

        private Vector2 mPanPosition;
        private Vector2 mPanDisplacement;

        public void Activate()
        {
            Window.Instance.BackgroundColor = Color.Black;
            // tool bar
            tool_bar = new View();
            tool_bar.BackgroundColor = Color.White;
            tool_bar.Size2D = new Size2D(Window.Instance.WindowSize.Width, 100);
            tool_bar.PositionUsesPivotPoint = true;
            tool_bar.ParentOrigin = ParentOrigin.TopLeft;
            tool_bar.PivotPoint = PivotPoint.TopLeft;

            Window.Instance.GetDefaultLayer().Add(tool_bar);
            Window.Instance.GetDefaultLayer().RaiseToTop();

            // title of tool bar
            mTitle = new TextLabel();
            mTitle.Text = APPLICATION_TITLE_WAVE;
            mTitle.FontFamily = "SamsungOneUI 400C";
            mTitle.PointSize = 20;
            mTitle.Position2D = new Position2D(400, 42);
            mTitle.ParentOrigin = ParentOrigin.TopLeft;
            mTitle.PositionUsesPivotPoint = true;
            mTitle.PivotPoint = PivotPoint.TopLeft;
            tool_bar.Add(mTitle);

            // push button of tool bar
            mSlideshowButton = new PushButton();
            PropertyMap unselected_bg_map = new PropertyMap();
            unselected_bg_map.Add(Visual.Property.Type, new PropertyValue((int)Visual.Type.Image));
            unselected_bg_map.Add(ImageVisualProperty.URL, new PropertyValue(SLIDE_SHOW_START_ICON));
            mSlideshowButton.UnselectedBackgroundVisual = unselected_bg_map;

            PropertyMap selected_bg_map = new PropertyMap();
            selected_bg_map.Add(Visual.Property.Type, new PropertyValue((int)Visual.Type.Image));
            selected_bg_map.Add(ImageVisualProperty.URL, new PropertyValue(SLIDE_SHOW_START_ICON_SELECTED));
            mSlideshowButton.SelectedBackgroundVisual = selected_bg_map;

            mSlideshowButton.ParentOrigin = ParentOrigin.TopLeft;
            mSlideshowButton.PivotPoint = PivotPoint.TopLeft;
            mSlideshowButton.Position2D = new Position2D(800, 32);
            mSlideshowButton.Clicked += OnPushButtonClicked;

            mSlideshowButton.RaiseToTop();

            tool_bar.Add(mSlideshowButton);

            // toggle button of tool bar
            toggle_button = new ToggleButton();
            PropertyArray array = new PropertyArray();
            array.Add(new PropertyValue(EFFECT_WAVE_IMAGE));
            array.Add(new PropertyValue(EFFECT_CROSS_IMAGE));
            array.Add(new PropertyValue(EFFECT_FOLD_IMAGE));
            toggle_button.StateVisuals = array;

            toggle_button.ParentOrigin = ParentOrigin.TopLeft;
            toggle_button.PivotPoint = PivotPoint.TopLeft;
            toggle_button.CellHorizontalAlignment = HorizontalAlignmentType.Right;
            toggle_button.Position2D = new Position2D(900, 42);

            toggle_button.Clicked += OnToggleButtonClicked;

            tool_bar.Add(toggle_button);

            // load image
            mCurrentTexture = LoadStageFillingTexture(IMAGES[mIndex]);

            // content layer is 3D.
            content_layer = new Layer();
            content_layer.Behavior = Layer.LayerBehavior.Layer3D;
            Window.Instance.AddLayer(content_layer);

            //use small cubes
            mCubeWaveEffect = new CubeTransitionWaveEffect(NUM_ROWS_WAVE, NUM_COLUMNS_WAVE);
            mCubeWaveEffect.SetTransitionDuration(ANIMATION_DURATION_WAVE);
            mCubeWaveEffect.SetCubeDisplacement(CUBE_DISPLACEMENT_WAVE);
            mCubeWaveEffect.TransitionCompleted += OnCubeEffectCompleted;

            mCubeWaveEffect.Position2D = new Position2D(0, tool_bar.Size2D.Height);
            mCubeWaveEffect.Size2D = new Size2D(Window.Instance.WindowSize.Width, Window.Instance.WindowSize.Height - tool_bar.Size2D.Height);
            mCubeWaveEffect.PivotPoint = PivotPoint.TopLeft;
            mCubeWaveEffect.ParentOrigin = ParentOrigin.TopLeft;
            mCubeWaveEffect.SetCurrentTexture(mCurrentTexture);

            // use big cubes
            mCubeCrossEffect = new CubeTransitionCrossEffect(NUM_ROWS_CROSS, NUM_COLUMNS_CROSS);
            mCubeCrossEffect.SetTransitionDuration(ANIMATION_DURATION_CROSS);
            mCubeCrossEffect.SetCubeDisplacement(CUBE_DISPLACEMENT_CROSS);
            mCubeCrossEffect.TransitionCompleted += OnCubeEffectCompleted;

            mCubeCrossEffect.Position2D = new Position2D(0, tool_bar.Size2D.Height);
            mCubeCrossEffect.Size2D = new Size2D(Window.Instance.WindowSize.Width, Window.Instance.WindowSize.Height - tool_bar.Size2D.Height);
            mCubeCrossEffect.PivotPoint = PivotPoint.TopLeft;
            mCubeCrossEffect.ParentOrigin = ParentOrigin.TopLeft;
            mCubeCrossEffect.SetCurrentTexture(mCurrentTexture);

            mCubeFoldEffect = new CubeTransitionFoldEffect(NUM_ROWS_FOLD, NUM_COLUMNS_FOLD);
            mCubeFoldEffect.SetTransitionDuration(ANIMATION_DURATION_FOLD);
            mCubeFoldEffect.TransitionCompleted += OnCubeEffectCompleted;

            mCubeFoldEffect.Position2D = new Position2D(0, tool_bar.Size2D.Height);
            mCubeFoldEffect.Size2D = new Size2D(Window.Instance.WindowSize.Width, Window.Instance.WindowSize.Height - tool_bar.Size2D.Height);
            mCubeFoldEffect.PivotPoint = PivotPoint.TopLeft;
            mCubeFoldEffect.ParentOrigin = ParentOrigin.TopLeft;
            mCubeFoldEffect.SetCurrentTexture(mCurrentTexture);

            mViewTimer = new Timer(VIEWINGTIME);
            mViewTimer.Tick += OnTimerTick;

            // content
            mCurrentEffect = mCubeWaveEffect;

            mContent = new View();
            mContent.Size2D = new Size2D(Window.Instance.WindowSize.Width, Window.Instance.WindowSize.Height - tool_bar.Size2D.Height);
            mContent.ParentOrigin = ParentOrigin.TopLeft;
            mContent.PositionUsesPivotPoint = true;
            mContent.PivotPoint = PivotPoint.TopLeft;

            mContent.Add(mCurrentEffect);

            content_layer.Add(mContent);

            mPanGestureDetector = new PanGestureDetector();
            mPanGestureDetector.Detected += OnPanGesture;
            mPanGestureDetector.Attach(mContent);
        }

        public void Deactivate()
        {
            if (mTitle)
            {
                tool_bar.Remove(mTitle);
                mTitle.Dispose();
                mTitle = null;
            }

            if (mSlideshowButton)
            {
                tool_bar.Remove(mSlideshowButton);
                mSlideshowButton.Clicked -= OnPushButtonClicked;
                mSlideshowButton.Dispose();
                mSlideshowButton = null;
            }

            if (toggle_button)
            {
                tool_bar.Remove(toggle_button);
                toggle_button.Clicked -= OnToggleButtonClicked;
                toggle_button.Dispose();
                toggle_button = null;
            }

            if (tool_bar)
            {
                Window.Instance.GetDefaultLayer().Remove(tool_bar);
                tool_bar.Dispose();
                tool_bar = null;
            }

            if (mCubeWaveEffect)
            {
                mCubeWaveEffect.TransitionCompleted -= OnCubeEffectCompleted;
                mCubeWaveEffect.Dispose();
                mCubeWaveEffect = null;
            }

            if (mCubeCrossEffect)
            {
                mCubeCrossEffect.TransitionCompleted -= OnCubeEffectCompleted;
                mCubeCrossEffect.Dispose();
                mCubeCrossEffect = null;
            }

            if (mCubeFoldEffect)
            {
                mCubeFoldEffect.TransitionCompleted -= OnCubeEffectCompleted;
                mCubeFoldEffect.Dispose();
                mCubeFoldEffect = null;
            }

            if (mPanGestureDetector)
            {
                mPanGestureDetector.Detected -= OnPanGesture;
                mPanGestureDetector.Dispose();
                mPanGestureDetector = null;
            }

            if (mContent)
            {
                if (null != mCurrentEffect)
                {
                    mContent.Remove(mCurrentEffect);
                }

                content_layer.Remove(mContent);
                mContent.Dispose();
                mContent = null;
            }

            if (content_layer)
            {
                Window.Instance.RemoveLayer(content_layer);
                content_layer.Dispose();
                content_layer = null;
            }
        }

        private void OnPanGesture(object sender, PanGestureDetector.DetectedEventArgs gesture)
        {
            // does not response when the transition has not finished
            if (mIsImageLoading || mCubeWaveEffect.IsTransitioning() || mCubeCrossEffect.IsTransitioning() || mCubeFoldEffect.IsTransitioning() || mSlideshow)
            {
                return;
            }

            if (gesture.PanGesture.State == Gesture.StateType.Continuing)
            {
                if (gesture.PanGesture.Displacement.X < 0)
                {
                    mIndex = (mIndex + 1) % NUM_IMAGES;
                }
                else
                {
                    mIndex = (mIndex + NUM_IMAGES - 1) % NUM_IMAGES;
                }

                mPanPosition = gesture.PanGesture.Position;
                mPanDisplacement = gesture.PanGesture.Displacement;
                GoToNextImage();
            }
        }

        private void GoToNextImage()
        {
            mNextTexture = LoadStageFillingTexture(IMAGES[mIndex]);

            mCurrentEffect.SetTargetTexture(mNextTexture);
            mIsImageLoading = false;

            mCurrentEffect.StartTransition(mPanPosition, mPanDisplacement);

            mCurrentTexture = mNextTexture;
        }


        private bool OnTimerTick(object sender, Timer.TickEventArgs args)
        {
            if (mSlideshow)
            {
                mIndex = (mIndex + 1) % NUM_IMAGES;
                GoToNextImage();
            }

            return false;
        }

        private void OnCubeEffectCompleted(object sender, Tizen.NUI.CubeTransitionEffect.TransitionCompletedEventArgs args)
        {
            if (mSlideshow)
            {
                mViewTimer.Start();
            }
        }

        private Texture LoadStageFillingTexture(string filepath)
        {
            Size2D dimensions = new Size2D(Window.Instance.WindowSize.Width, Window.Instance.WindowSize.Height);
            PixelBuffer pb = ImageLoading.LoadImageFromFile(filepath, dimensions, FittingModeType.ScaleToFill);
            PixelData pd = PixelBuffer.Convert(pb);

            Texture texture = new Texture(TextureType.TEXTURE_2D, pd.GetPixelFormat(), pd.GetWidth(), pd.GetHeight());
            texture.Upload(pd);

            return texture;
        }

        private bool OnToggleButtonClicked(object sender, global::System.EventArgs args)
        {
            mContent.Remove(mCurrentEffect);
            if (mCurrentEffect == mCubeWaveEffect)
            {
                mCurrentEffect = mCubeCrossEffect;
                mTitle.Text = APPLICATION_TITLE_CROSS;
            }
            else if (mCurrentEffect == mCubeCrossEffect)
            {
                mCurrentEffect = mCubeFoldEffect;
                mTitle.Text = APPLICATION_TITLE_FOLD;
            }
            else
            {
                mCurrentEffect = mCubeWaveEffect;
                mTitle.Text = APPLICATION_TITLE_WAVE;
            }
            mContent.Add(mCurrentEffect);

            // Set the current image to cube transition effect
            // only need to set at beginning or change from another effect
            mCurrentEffect.SetCurrentTexture(mCurrentTexture);
            return true;
        }

        private bool OnPushButtonClicked(object sender, global::System.EventArgs args)
        {
            mSlideshow = !mSlideshow;
            if (mSlideshow)
            {
                mPanGestureDetector.Detach(mContent);

                PropertyMap unselected_bg_map = new PropertyMap();
                unselected_bg_map.Add(Visual.Property.Type, new PropertyValue((int)Visual.Type.Image));
                unselected_bg_map.Add(ImageVisualProperty.URL, new PropertyValue(SLIDE_SHOW_STOP_ICON));
                mSlideshowButton.UnselectedBackgroundVisual = unselected_bg_map;

                PropertyMap selected_bg_map = new PropertyMap();
                selected_bg_map.Add(Visual.Property.Type, new PropertyValue((int)Visual.Type.Image));
                selected_bg_map.Add(ImageVisualProperty.URL, new PropertyValue(SLIDE_SHOW_STOP_ICON_SELECTED));
                mSlideshowButton.SelectedBackgroundVisual = selected_bg_map;

                mPanPosition = new Vector2(Window.Instance.WindowSize.Width, Window.Instance.WindowSize.Width * 0.5f);
                mPanDisplacement = new Vector2(-10.0f, 0.0f);

                mViewTimer.Start();
            }
            else
            {
                mPanGestureDetector.Attach(mContent);

                PropertyMap unselected_bg_map = new PropertyMap();
                unselected_bg_map.Add(Visual.Property.Type, new PropertyValue((int)Visual.Type.Image));
                unselected_bg_map.Add(ImageVisualProperty.URL, new PropertyValue(SLIDE_SHOW_START_ICON));
                mSlideshowButton.UnselectedBackgroundVisual = unselected_bg_map;

                PropertyMap selected_bg_map = new PropertyMap();
                selected_bg_map.Add(Visual.Property.Type, new PropertyValue((int)Visual.Type.Image));
                selected_bg_map.Add(ImageVisualProperty.URL, new PropertyValue(SLIDE_SHOW_START_ICON_SELECTED));
                mSlideshowButton.SelectedBackgroundVisual = selected_bg_map;

                mViewTimer.Stop();
            }
            return true;
        }
    }
}
