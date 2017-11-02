using System;
using Tizen.NUI;
using Tizen.NUI.UIComponents;
using Tizen.NUI.BaseComponents;

namespace WidgetViewTest
{
    class Example : NUIApplication
    {
        private PushButton _widgetButton;
        private PushButton _deletedButton;
        private WidgetView _widgetView;
        private WidgetViewManager _widgetViewManager;
        private View _container;
        private string _instanceID;

        protected override void OnCreate()
        {
            base.OnCreate();
            Initialize();
        }

        protected override void OnTerminate()
        {
            //This function is called when the app exit normally.
            base.OnTerminate();
        }

        public void Initialize()
        {
            Window window = Window.Instance;
            window.BackgroundColor = Color.White;

            Tizen.Log.Debug("NUI", "### DP1");
            Layer layer = new Layer();
            layer.Behavior = Layer.LayerBehavior.Layer3D;
            window.AddLayer(layer);
            Tizen.Log.Debug("NUI", "### DP2");
            _container = new View();
            _container.ParentOrigin = ParentOrigin.Center;
            _container.PivotPoint = PivotPoint.Center;
            _container.Size2D = new Size2D(400, 400);
            Tizen.Log.Debug("NUI", "### DP3");
            _widgetButton = new PushButton();
            _widgetButton.LabelText = "Widget";
            _widgetButton.ParentOrigin = ParentOrigin.BottomLeft;
            _widgetButton.PivotPoint = PivotPoint.BottomLeft;
            _widgetButton.PositionUsesAnchorPoint = true;
            _widgetButton.Size2D = new Size2D(200, 100);
            window.Add(_widgetButton);
            _widgetButton.Clicked += (obj, e) =>
            {
                _widgetView = _widgetViewManager.AddWidget("widget-efl.example", "", 450, 700, -1);
                //_widgetView.PositionUsesPivotPoint = true;
                //_widgetView.ParentOrigin = ParentOrigin.Center;
                _widgetView.PivotPoint = PivotPoint.TopLeft;
                _widgetView.PositionUsesAnchorPoint = true;
                _widgetView.BackgroundColor = Color.Yellow;
                _widgetView.WidgetAdded += (sender, eargs) =>
                {
                    _widgetButton.LabelText = "Quit";
                    window.Add(_widgetView);
                };
                _widgetView.WidgetDeleted += (sender, eargs) =>
                {
                    window.Remove(_widgetView);
                    _widgetButton.LabelText = "Button";
                };
                _instanceID = _widgetView.InstanceID;
                return false;
            };

            _deletedButton = new PushButton();
            _deletedButton.LabelText = "Buton";
            _deletedButton.ParentOrigin = ParentOrigin.BottomRight;
            _deletedButton.PivotPoint = PivotPoint.BottomRight;
            _deletedButton.PositionUsesAnchorPoint = true;
            _deletedButton.Size2D = new Size2D(200, 100);
            window.Add(_deletedButton);
            _deletedButton.Clicked += (obj, e) =>
            {
                OnTerminate();
                return true;
            };

            layer.Add(_container);
            Tizen.Log.Debug("NUI", "### widget view manager create start");
            _widgetViewManager = new WidgetViewManager(this, "org.tizen.example.NUISamples.TizenTV");
            if (!_widgetViewManager)
            {
                Tizen.Log.Fatal("NUI", "### Widget is not enabled!");
            }

            Tizen.Log.Debug("NUI", "### widget view manager create sucess");
        }

        [STAThread]
        static void _Main(string[] args)
        {
            Example example = new Example();
            example.Run(args);
        }
    }
}

