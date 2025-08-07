using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;
using global::System;
using global::System.Collections.Generic;
using global::System.ComponentModel;
using global::System.Reflection;

namespace Tizen.NUI.Samples
{
    public class SemiParticleSystem : IExample
    {
        public class ParticleSystem : IDisposable
        {
            private class Particle : IDisposable
            {
                private static readonly Random s_random = new Random();

                private bool _disposed;
                private View _rootView;
                private View _view;
                private PropertyNotification _culledNotification;

                private Vector2 _initialPosition;
                private Vector2 _initialSize;
                private float _finalOpacity;
                private float _blurRadius;
                private Animation _animation;

                private uint _totalDurationMs;
                private float _rootLayerWidth;

                public Particle(View rootView, float rootLayerWidth, uint totalDurationMs)
                {
                    _rootView = rootView;
                    _rootLayerWidth = rootLayerWidth;
                    _totalDurationMs = totalDurationMs;

                    // Generate random position of view
                    GenerateRandomValues();
                    GenerateView();
                    GenerateAnimation();
                }

                ~Particle() => Dispose(false);

                public void Dispose()
                {
                    Dispose(true);
                }

                protected virtual void Dispose(bool disposing)
                {
                    if(_disposed)
                    {
                        return;
                    }
                    if(disposing)
                    {
                        _view?.Dispose();
                        _view = null;

                        if (_animation != null)
                        {
                            //_animation.Finished -= OnFinished;
                            _animation.Clear();
                            _animation.Dispose();
                            _animation = null;
                        }

                        _initialPosition?.Dispose();
                        _initialSize?.Dispose();

                        _rootView = null;
                    }
                    _disposed = true;
                }

                private void OnFinished(object o, EventArgs e)
                {
                    // Play again
                    if(_view != null)
                    {
                        GenerateRandomValues();
                        GenerateView();
                        GenerateAnimation();
                        _animation.Play();
                    }
                }

                private void GenerateAnimation()
                {
                    if(_animation == null)
                    {
                        _animation = new Animation((int)_totalDurationMs);
                        _animation.Finished += OnFinished;
                    }
                    else
                    {
                        _animation.Clear();
                    }

                    _animation.AnimateTo(_view, "PositionX", _initialPosition.X * 10.0f);
                    _animation.AnimateTo(_view, "PositionY", _initialPosition.Y * 10.0f);
                    _animation.AnimateTo(_view, "SizeWidth", _initialSize.X * 2.0f, 0, (int)_totalDurationMs / 10, new AlphaFunction(AlphaFunction.BuiltinFunctions.EaseOut));
                    _animation.AnimateTo(_view, "SizeWidth", 0.0f, 0, (int)_totalDurationMs);
                    _animation.AnimateTo(_view, "SizeHeight", _initialSize.X * 2.0f, 0, (int)_totalDurationMs / 10, new AlphaFunction(AlphaFunction.BuiltinFunctions.EaseOut));
                    _animation.AnimateTo(_view, "SizeHeight", 0.0f, 0, (int)_totalDurationMs);
                    _animation.AnimateTo(_view, "Opacity", _finalOpacity, 0, (int)_totalDurationMs / 10);

                    _animation.Play();
                }
                private void GenerateView()
                {
                    if(_view == null)
                    {
                        _view = new View()
                        {
                            PositionX = _initialPosition.X,
                            PositionY = _initialPosition.Y,
                            SizeWidth = _initialSize.X,
                            SizeHeight = _initialSize.Y,
                            BoxShadow = new Shadow(_blurRadius, Color.White),
                            Opacity = 0.0f,
                            CornerRadius = 0.5f,
                            CornerRadiusPolicy = VisualTransformPolicyType.Relative,
                        };
                    }
                    else
                    {
                        _view.PositionX = _initialPosition.X;
                        _view.PositionY = _initialPosition.Y;
                        _view.SizeWidth = _initialSize.X;
                        _view.SizeHeight = _initialSize.Y;
                        _view.Opacity = 0.0f;
                    }

                    _rootView?.Add(_view);

                    if(_culledNotification == null)
                    {
                        _culledNotification = _view.AddPropertyNotification("Culled", PropertyCondition.GreaterThan(0.5f));
                        _culledNotification.SetNotifyMode(PropertyNotification.NotifyMode.NotifyOnTrue);
                        _culledNotification.Notified += (o, e) => {
                            // Automatically unparent for reduce rendering process.
                            //_view?.Unparent();
                            _animation?.Stop();
                        };

                        //Tizen.Log.Error("NUI", $"{_view.GetRendererCount()}");

                        // Deprecated API used!
                        var renderer = _view.GetRendererAt(0u);
                        renderer.BlendFactorSrcRgb = (int)BlendFactorType.SrcAlpha;
                        renderer.BlendFactorSrcAlpha = (int)BlendFactorType.SrcAlpha;
                        renderer.BlendFactorDestRgb = (int)BlendFactorType.One;
                        renderer.BlendFactorDestAlpha = (int)BlendFactorType.OneMinusSrcAlpha;
                    }
                }

                private void GenerateRandomValues()
                {
                    double positoinFactor = (double)_rootLayerWidth * 0.1;
                    double sizeFactor = (double)_rootLayerWidth * 0.03;

                    double radius = s_random.NextDouble() * positoinFactor + positoinFactor;
                    double angle = s_random.NextDouble() * 2.0 * Math.PI;
                    double size = s_random.NextDouble() * sizeFactor;

                    _initialPosition = new Vector2((float)(radius * Math.Cos(angle)), (float)(radius * Math.Sin(angle)));
                    _initialSize =  new Vector2((float)size, (float)size);

                    _blurRadius = (float)(size * s_random.NextDouble()) * 0.9f + 0.2f;
                    _finalOpacity = (float)(s_random.NextDouble() * 0.5 + 0.5);
                }
            };

            private static Lazy<ParticleSystem> _instance = new();
            private bool _disposed;
            private Window _window;
            private Layer _rootLayer;
            private View _root;

            private List<Particle> _particleList;
            private Timer _timer;
            private uint _particleCount;
            private uint _emitIntervalMs;
            private float _rootLayerWidth;

            private Animation _rootRotateAnimation;

            public uint ParticleCount
            {
                get
                {
                    return _particleCount;
                }
                set
                {
                    _particleCount = value;
                    if (_particleList != null)
                    {
                        while (_particleList.Count > _particleCount)
                        {
                            Particle particle = _particleList[_particleList.Count - 1];
                            particle?.Dispose();
                            _particleList.RemoveAt(_particleList.Count - 1);
                        }
                    }
                    if (_timer != null)
                    {
                        if (_particleList.Count < _particleCount)
                        {
                            _timer.Start();
                        }
                    }
                }
            }

            public uint ParticleEmitDurationMs
            {
                get
                {
                    return _emitIntervalMs;
                }
                set
                {
                    _emitIntervalMs = value;
                    if (_timer  != null)
                    {
                        _timer.Interval = _emitIntervalMs;
                    }
                }
            }

            public static ParticleSystem Instance => _instance.Value;

            public ParticleSystem()
            {
                ParticleCount = 100;
                ParticleEmitDurationMs = 100;

                _root = new View()
                {
                    PivotPoint = PivotPoint.Center,
                    ParentOrigin = ParentOrigin.Center,
                };
            }

            ~ParticleSystem() => Dispose(false);

            public void SetRootWindow(Window window)
            {
                _window = window;
                _rootLayer = window.GetDefaultLayer();

                _rootLayer.Add(_root);

                _rootLayerWidth = window.WindowSize.Width;

                _window.Resized += OnWindowResized;
            }

            public void Start()
            {
                if (_particleList == null)
                {
                    _particleList = new();
                }
                if (_timer == null)
                {
                    _timer = new Timer(_emitIntervalMs);
                    _timer.Tick += OnTick;
                }
                if (_rootRotateAnimation == null)
                {
                    _rootRotateAnimation = new Animation((int)((_emitIntervalMs * _particleCount) * 7.3f));
                    _rootRotateAnimation.AnimateBy(_root, "Orientation", new Rotation(new Radian(new Degree(360.0f)), Vector3.ZAxis), new AlphaFunction(AlphaFunction.BuiltinFunctions.EaseInOut));
                    _rootRotateAnimation.LoopingMode = Animation.LoopingModes.AutoReverse;
                    _rootRotateAnimation.Looping = true;
                }

                _timer.Start();
                _rootRotateAnimation.Play();
            }

            public void Stop()
            {
                _timer?.Stop();
                _rootRotateAnimation?.Stop();
            }

            public void Dispose()
            {
                Dispose(true);
            }

            protected virtual void Dispose(bool disposing)
            {
                if(_disposed)
                {
                    return;
                }
                if(disposing)
                {
                    Stop();

                    _root?.Dispose();
                    
                    if (_timer != null)
                    {
                        _timer.Tick -= OnTick;
                        _timer.Dispose();
                    }
                    if (_particleList != null)
                    {
                        foreach (Particle particle in _particleList)
                        {
                            particle?.Dispose();
                        };
                        _particleList = null;
                    }

                    if (_window != null)
                    {
                        _window.Resized -= OnWindowResized;
                    }

                    _window = null;
                    _rootLayer = null;
                }
                _disposed = true;
                _instance = new();
            }

            private void OnWindowResized(object o, Window.ResizedEventArgs e)
            {
                _rootLayerWidth = (float)e.WindowSize.Width;
            }

            private bool OnTick(object o, EventArgs e)
            {
                if (_particleList.Count < _particleCount)
                {
                    Particle particle = new Particle(_root, _rootLayerWidth, _particleCount * _emitIntervalMs);
                    _particleList.Add(particle);
                }
                return _particleList.Count < _particleCount;
            }
        }
        private View root;

        public void Activate()
        {
            Window window = NUIApplication.GetDefaultWindow();
            window.WindowSize = new Size2D(1920, 1080);

            root = new View()
            {
                BackgroundColor = new Color(0.3f, 0.6f, 0.8f, 1.0f),
                ParentOrigin = ParentOrigin.Center,
                PivotPoint = PivotPoint.Center,
                PositionUsesPivotPoint = true,
                WidthResizePolicy = ResizePolicyType.FillToParent,
                HeightResizePolicy = ResizePolicyType.FillToParent,

                InnerShadow = new InnerShadow(new UIExtents(-100.0f, -100.0f, -100.0f, 300.0f), 300.0f, new Color(0.1f, 0.3f, 0.5f, 1.0f)),
            };
            window.Add(root);

            ParticleSystem.Instance.SetRootWindow(window);
            ParticleSystem.Instance.Start();
        }

        public void Deactivate()
        {
            if (root != null)
            {
                root.Dispose();
            }
            ParticleSystem.Instance.Dispose();
        }
    }
}
