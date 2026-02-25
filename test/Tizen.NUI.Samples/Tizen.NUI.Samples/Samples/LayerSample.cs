using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;

namespace Tizen.NUI.Samples
{
    public class LayerSample : IExample
    {
        private Window _window;
        private Layer[] _layers = new Layer[3];
        private Layer _overlayLayer;
        private Animation _blurAnimation;
        private bool[] _isLayerViewportSet = new bool[3];

        private View _hoverView;
        private View[] _layerViews = new View[3];
        private View _blurView;
        private Constraint[] _constraints = new Constraint[4];

        private const int c_leftMargin = 160;
        private const int c_topMargin = 50;
        private const int c_rightMargin = 160;
        private const int c_bottomMargin = 50;

        private const int c_diffPerLayer = 30;

        public void Activate()
        {
            _window = NUIApplication.GetDefaultWindow();

            _hoverView = new View()
            {
                BackgroundColor = Color.Black,
                SizeWidth = 4,
                SizeHeight = 4,
                PositionX = 200,
                PositionY = 200,
            };

            _layers[0] = CreateFirstLayer();
            _window.AddLayer(_layers[0]);
            _layers[1] = CreateSecondLayer();
            _window.AddLayer(_layers[1]);
            _layers[2] = CreateThirdLayer();
            _window.AddLayer(_layers[2]);

            _isLayerViewportSet[0] = false;
            _isLayerViewportSet[1] = false;
            _isLayerViewportSet[2] = false;

            _overlayLayer = CreateOverlayLayer();
            _overlayLayer.Add(_hoverView);
            _window.AddLayer(_overlayLayer);

            // Apply constraints after all views are created
            ApplyConstraints();

            _window.KeyEvent += WindowKeyEvent;
            _window.Resized += WindowResized;
        }

        public void Deactivate()
        {
            // Dispose constraints
            if (_constraints != null)
            {
                for (int i = 0; i < _constraints.Length; i++)
                {
                    if (_constraints[i] != null)
                    {
                        _constraints[i].Remove();
                        _constraints[i].Dispose();
                        _constraints[i] = null;
                    }
                }
            }

            if (_layers != null)
            {
                for (int i = 0; i < _layers.Length; i++)
                {
                    if (_layers[i] != null)
                    {
                        _window.RemoveLayer(_layers[i]);
                        _layers[i].Dispose();
                        _layers[i] = null;
                    }
                }
            }
            if (_overlayLayer != null)
            {
                _window.RemoveLayer(_overlayLayer);
                _overlayLayer.Dispose();
                _overlayLayer = null;
            }

            if (_hoverView != null)
            {
                _hoverView.Unparent();
                _hoverView.Dispose();
                _hoverView = null;
            }

            if (_blurAnimation != null)
            {
                _blurAnimation.Stop();
                _blurAnimation.Dispose();
                _blurAnimation = null;
            }

            if (_window != null)
            {
                _window.KeyEvent -= WindowKeyEvent;
                _window.Resized -= WindowResized;
                _window = null;
            }
        }

        private void WindowResized(object sender, Window.ResizedEventArgs e)
        {
            Tizen.Log.Error("NUI", $"Window resized : {e.WindowSize.Width}, {e.WindowSize.Height}\n");

            for(int layerIndex=0; layerIndex<3; layerIndex++)
            {
                if (_isLayerViewportSet[layerIndex])
                {
                    _layers[layerIndex].Viewport = new Rectangle(c_leftMargin - layerIndex * c_diffPerLayer, c_topMargin + layerIndex * c_diffPerLayer, e.WindowSize.Width - c_rightMargin - c_leftMargin + layerIndex * c_diffPerLayer * 2, e.WindowSize.Height - c_bottomMargin - c_topMargin - layerIndex * c_diffPerLayer * 2);
                    Tizen.Log.Error("NUI", $"Viewport {layerIndex} : {_layers[layerIndex].Viewport.X} {_layers[layerIndex].Viewport.Y} {_layers[layerIndex].Viewport.Width} {_layers[layerIndex].Viewport.Height}\n");
                }
            }
        }

        private void WindowKeyEvent(object sender, Window.KeyEventArgs e)
        {
            Tizen.Log.Error("NUI", $"Window key event : {e.Key.KeyPressedName} {e.Key.State}\n");
            if (e.Key.State == Key.StateType.Down)
            {
                int layerIndex = -1;
                if (e.Key.KeyPressedName == "1")
                {
                    layerIndex = 0;
                }
                if (e.Key.KeyPressedName == "2")
                {
                    layerIndex = 1;
                }
                if (e.Key.KeyPressedName == "3")
                {
                    layerIndex = 2;
                }
                if (layerIndex >= 0 && _layers[layerIndex] != null && _window != null)
                {
                    if (_isLayerViewportSet[layerIndex] == false)
                    {
                        Tizen.Log.Error("NUI", $"Set viewport to layer[{layerIndex}]\n");
                        _layers[layerIndex].Viewport = new Rectangle(c_leftMargin - layerIndex * c_diffPerLayer, c_topMargin + layerIndex * c_diffPerLayer, _window.WindowSize.Width - c_rightMargin - c_leftMargin + layerIndex * c_diffPerLayer * 2, _window.WindowSize.Height - c_bottomMargin - c_topMargin - layerIndex * c_diffPerLayer * 2);
                        _isLayerViewportSet[layerIndex] = true;
                        
                        Tizen.Log.Error("NUI", $"Viewport {layerIndex} : {_layers[layerIndex].Viewport.X} {_layers[layerIndex].Viewport.Y} {_layers[layerIndex].Viewport.Width} {_layers[layerIndex].Viewport.Height}\n");
                    }
                    else
                    {
                        Tizen.Log.Error("NUI", $"Unset viewport from layer[{layerIndex}]\n");
                        _layers[layerIndex].Viewport = null;
                        _isLayerViewportSet[layerIndex] = false;
                        Tizen.Log.Error("NUI", $"Viewport {layerIndex} : {_layers[layerIndex].Viewport.X} {_layers[layerIndex].Viewport.Y} {_layers[layerIndex].Viewport.Width} {_layers[layerIndex].Viewport.Height}\n");
                    }
                }
            }
        }

        #region Layer Creation
        private Layer CreateFirstLayer()
        {
            Layer layer = new Layer() {
                Opacity = 1.0f,
                Name = "FirstLayer",
            };
            var rootView = new View() {
                Layout = new AbsoluteLayout(),
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.MatchParent,
                BackgroundColor = new Color(1.0f, 0.0f, 0.0f, 0.1f),
                Name = "1-root",
            };
            _layerViews[0] = new View() {
                BackgroundColor = Color.Red,
                Size = new Size(200, 200),
                Position = new Position(50, 50),
                Name = "1-view",
            };

            using var value = new PropertyValue(50.0f);
            _layerViews[0].RegisterProperty("uOffsetFromHoverX", value);
            _layerViews[0].RegisterProperty("uOffsetFromHoverY", value);

            rootView.Add(_layerViews[0]);
            layer.Add(rootView);

            return layer;
        }

        private Layer CreateSecondLayer()
        {
            Layer layer = new Layer() {
                Opacity = 0.5f,
                Name = "SecondLayer",
            };

            var rootView = new View() {
                Layout = new AbsoluteLayout(),
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.MatchParent,
                BackgroundColor = new Color(0.0f, 1.0f, 0.0f, 0.1f),
                Name = "2-root",
            };
            _layerViews[1] = new View() {
                BackgroundColor = Color.Blue,
                Size = new Size(200, 200),
                Position = new Position(150, 60),
                Name = "2-view",
            };

            using var value = new PropertyValue(150.0f);
            _layerViews[1].RegisterProperty("uOffsetFromHoverX", value);
            value.Set(60.0f);
            _layerViews[1].RegisterProperty("uOffsetFromHoverY", value);

            rootView.Add(_layerViews[1]);
            layer.Add(rootView);

            return layer;
        }

        private Layer CreateThirdLayer()
        {
            Layer layer = new Layer() {
                Opacity = 0.5f,
                Name = "ThirdLayer",
            };

            var rootView = new View() {
                Layout = new AbsoluteLayout(),
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.MatchParent,
                BackgroundColor = new Color(0.0f, 0.0f, 1.0f, 0.1f),
                Name = "3-root",
            };
            _layerViews[2] = new View() {
                BackgroundColor = Color.Green,
                Size = new Size(200, 200),
                Position = new Position(70, 150),
                Name = "3-view",
            };
            using var value = new PropertyValue(70.0f);
            _layerViews[2].RegisterProperty("uOffsetFromHoverX", value);
            value.Set(150.0f);
            _layerViews[2].RegisterProperty("uOffsetFromHoverY", value);

            rootView.Add(_layerViews[2]);
            layer.Add(rootView);

            return layer;
        }

        private Layer CreateOverlayLayer()
        {
            Layer layer = new Layer() {
                Name = "OverlayLayer",
            };
            layer.SetTouchConsumed(true);
            layer.SetHoverConsumed(true);

            var rootView = new View() {
                Layout = new AbsoluteLayout(),
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.MatchParent,
                BorderlineColor = Color.Purple,
                BorderlineWidth = 10.0f,
                BorderlineOffset = -1.0f,
                Name = "overlay-root",
            };
            layer.Add(rootView);

            rootView.HoverEvent += (o, e) =>
            {
                if(_hoverView != null)
                {
                    using var localPosition = e.Hover.GetLocalPosition(0u);
                    _hoverView.PositionX = localPosition.X;
                    _hoverView.PositionY = localPosition.Y;
                }
                return true;
            };

            var textLabel = new TextLabel("Overlay Layer") {
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
                PointSize = 20.0f,
                TextColor = Color.White,
                BackgroundColor = Color.Black,

                ParentOrigin = ParentOrigin.CenterLeft,

                Name = "OverlayTextLabel",
            };
            rootView.Add(textLabel);

            _blurView = new View() {
                Size = new Size(200, 200),
                Position = new Position(100, 100),
                BackgroundColor = new Color(0.0f, 0.0f, 0.0f, 0.5f),

                BorderlineColor = Color.Red,
                BorderlineWidth = 2.0f,

                CornerRadius = new Vector4(40, 40, 40, 40),

                Name = "OverlayBlurView",
            };
            using var value = new PropertyValue(100.0f);
            _blurView.RegisterProperty("uOffsetFromHoverX", value);
            _blurView.RegisterProperty("uOffsetFromHoverY", value);

            _blurAnimation?.Stop();
            _blurAnimation?.Dispose();
            _blurAnimation = new Animation(2000);
            _blurAnimation.Looping = true;
            var backgroundBlurEffect = RenderEffect.CreateBackgroundBlurEffect(50.0f);
            backgroundBlurEffect.AddBlurOpacityAnimation(_blurAnimation, null, null, 1.0f, 0.0f);
            _blurView.SetRenderEffect(backgroundBlurEffect);
            //_blurAnimation.Play();

            rootView.Add(_blurView);

            return layer;
        }
        #endregion

        #region Constraint Implementation
        private UIVector3 OnConstraintPosition(UIVector3 current, uint id, in PropertyInputContainer container)
        {
            // Get hoverView position from container
            float hoverViewX = container.GetFloat(0u);
            float hoverViewY = container.GetFloat(1u);

            // Get custom offset of each view
            float offsetX = container.GetFloat(2u);
            float offsetY = container.GetFloat(3u);

            // Calculate new position for the constrained view to follow hoverView
            UIVector3 result = new UIVector3((hoverViewX - 200.0f) + offsetX, (hoverViewY - 200.0f) + offsetY, 0.0f);

            return result;
        }

        private void ApplyConstraints()
        {
            if (_hoverView != null)
            {
                // Apply constraints to all 4 views to follow _hoverView
                for (int i = 0; i < 3; i++)
                {
                    if (_layerViews[i] != null)
                    {
                        // Create constraint for each layer view
                        _constraints[i] = Constraint.GenerateConstraint(_layerViews[i], "Position", new Constraint.ConstraintVector3FunctionCallbackType(OnConstraintPosition));
                        _constraints[i].AddSource(_hoverView, "PositionX");
                        _constraints[i].AddSource(_hoverView, "PositionY");
                        _constraints[i].AddLocalSource(_layerViews[i].GetPropertyIndex("uOffsetFromHoverX"));
                        _constraints[i].AddLocalSource(_layerViews[i].GetPropertyIndex("uOffsetFromHoverY"));
                        _constraints[i].Apply();
                    }
                }

                // Apply constraint to blurView
                if (_blurView != null)
                {
                    _constraints[3] = Constraint.GenerateConstraint(_blurView, "Position", new Constraint.ConstraintVector3FunctionCallbackType(OnConstraintPosition));
                    _constraints[3].AddSource(_hoverView, "PositionX");
                    _constraints[3].AddSource(_hoverView, "PositionY");
                    _constraints[3].AddLocalSource(_blurView.GetPropertyIndex("uOffsetFromHoverX"));
                    _constraints[3].AddLocalSource(_blurView.GetPropertyIndex("uOffsetFromHoverY"));
                    _constraints[3].Apply();
                }
            }
        }
        #endregion
    }
}
