using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;
using System;

namespace Tizen.NUI.Samples
{
    public class BackgroundBlurEffectTest : IExample
    {
        static private string DEMO_IMAGE_DIR = Tizen.Applications.Application.Current.DirectoryInfo.Resource + "images/";
        static private string s_imagePath = DEMO_IMAGE_DIR + "Dali/DaliDemo/Logo-for-demo.png";
        private const int c_gridSizeN = 10;
        private const int c_gridSizeM = 10;

        private NUIApplication application;

        public void SetCurrentApplication(Tizen.NUI.NUIApplication application)
        {
            Tizen.Log.Error("NUITEST", $"SetCurrentApplication {application}\n");
            this.application = application;
        }

        public Tizen.NUI.NUIApplication GetCurrentApplication()
        {
            Tizen.Log.Error("NUITEST", $"GetCurrentApplication {application}\n");
            return application;
        }

        private Window _window;
        private View _root;
        public void Activate()
        {
            _window = NUIApplication.GetDefaultWindow();
            _root = new View()
            {
                WidthResizePolicy = ResizePolicyType.FillToParent,
                HeightResizePolicy = ResizePolicyType.FillToParent,
            };
            _window.Add(_root);

            BuildViewTree();

            _window.Resized += OnWindowResized;
        }

        private ImageView _background;
        private View _stopper;
        private View _blurViewContainer;
        private Animation _blurAnimation;
        private void BuildViewTree()
        {
            _background = new ImageView(s_imagePath)
            {
                WidthResizePolicy = ResizePolicyType.FillToParent,
                HeightResizePolicy = ResizePolicyType.FillToParent,
            };
            _stopper = new View();
            _blurViewContainer = new View()
            {
                ChildrenDepthIndexPolicy = View.ChildrenDepthIndexPolicyType.Equal,
            };
            _root.Add(_background);
            _root.Add(_stopper);
            _root.Add(_blurViewContainer);

            BuildBlurTree();
        }

        private void BuildBlurTree()
        {
            Random rand = new Random();
            _blurAnimation = new Animation();
            _blurAnimation.Looping = true;
            float viewWidth = (float)(_window.WindowSize.Width) / (float)(c_gridSizeM);
            float viewHeight = (float)(_window.WindowSize.Height) / (float)(c_gridSizeN);
            for (int i=0; i<c_gridSizeN; ++i)
            {
                for (int j=0; j<c_gridSizeM; ++j)
                {
                    var view = new View()
                    {
                        SizeWidth = viewWidth,
                        SizeHeight = viewHeight,
                        PositionX = j * viewWidth,
                        PositionY = i * viewHeight,
                        Scale = new Vector3(0.95f, 0.95f, 1.0f),

                        BackgroundColor = new Color((float)(rand.Next(128, 255)) / 255.0f, (float)(rand.Next(128, 255)) / 255.0f, (float)(rand.Next(128, 255)) / 255.0f, 0.2f),

                        BorderlineColor = new Color(1.0f, 1.0f, 1.0f, 0.5f),
                        BorderlineOffset = -1.0f,
                        BorderlineWidth = 4.0f,

                        CornerRadius = 0.15f,
                        CornerRadiusPolicy = VisualTransformPolicyType.Relative,

                        InnerShadow = new InnerShadow(new UIExtents(0, -30, 0, -30), 20.0f, new Color(0.0f, 0.0f, 0.0f, 0.8f)),
                        // BoxShadow = new Shadow(20.0f, ColorVisualCutoutPolicyType.CutoutViewWithCornerRadius, new Color(0.0f, 0.0f, 0.0f, 0.8f), new Vector2(10.0f, 10.0f)),
                    };

                    var backgroundBlurEffect = RenderEffect.CreateBackgroundBlurEffect((float)(rand.Next(50, 200)));
                    backgroundBlurEffect.SetSourceView(_root);
                    backgroundBlurEffect.SetStopperView(_stopper);

                    backgroundBlurEffect.AddBlurStrengthAnimation(_blurAnimation, null, new TimePeriod((i + j) * 100, 1000), 1.0f, 0.0f);
                    backgroundBlurEffect.AddBlurStrengthAnimation(_blurAnimation, null, new TimePeriod((i + j) * 100 + 1500, 1000), 0.0f, 1.0f);
                    view.SetRenderEffect(backgroundBlurEffect);
                    _blurViewContainer.Add(view);
                }
            }
            _blurAnimation.Duration += 1000;
            _blurAnimation.Play();
        }


        public void Deactivate()
        {
            if (_window != null)
            {
                _window.Resized -= OnWindowResized;
                if (_root != null)
                {
                    _window.Remove(_root);
                    _root.DisposeRecursively();
                    _root = null;
                }
                _window = null;
            }
            _blurViewContainer = null;
        }

        private bool _idleAdded;
        private void ResizeOnIdle()
        {
            _idleAdded = false;
            if (_blurViewContainer != null && _window != null)
            {
                float viewWidth = (float)(_window.WindowSize.Width) / (float)(c_gridSizeM);
                float viewHeight = (float)(_window.WindowSize.Height) / (float)(c_gridSizeN);
                for (int i=0; i<c_gridSizeN; ++i)
                {
                    for (int j=0; j<c_gridSizeM; ++j)
                    {
                        var view = _blurViewContainer.GetChildAt((uint)(i * c_gridSizeM + j));

                        view.SizeWidth = viewWidth;
                        view.SizeHeight = viewHeight;
                        view.PositionX = j * viewWidth;
                        view.PositionY = i * viewHeight;
                    }
                }
            }
        }

        private void ResizeRequest()
        {
            if (_window != null)
            {
                if (!_idleAdded)
                {
                    _idleAdded = true;
                    GetCurrentApplication()?.AddIdle(ResizeOnIdle);
                }
            }
        }

        private void OnWindowResized(object o, Window.ResizedEventArgs e)
        {
            ResizeRequest();
        }
    }
}
