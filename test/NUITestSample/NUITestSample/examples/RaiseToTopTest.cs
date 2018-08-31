using System;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;

namespace MyRaiseToTopTest
{
    class Example : NUIApplication
    {
        TextLabel layer1Text, layer2Text, rootLayerText;
        Window window;
        View[] layer1Views = new View[3];
        View[] layer2Views = new View[3];
        View[] rootLayerViews = new View[3];
        Layer layer1, layer2, rootLayer;

        protected override void OnCreate()
        {
            base.OnCreate();
            Initialize();
        }
        public void Initialize()
        {
            window = Window.Instance;
            window.KeyEvent += OnWindowKeyEvent;
            window.BackgroundColor = Color.Yellow;

            const int viewSize = 80;
            const int startPos = 30;

            //rootLayer
            rootLayer = window.GetDefaultLayer();
            for(int i = 0; i < 3; i++)
            {
                rootLayerViews[i] = new View();
                rootLayerViews[i].Size2D = new Size2D(viewSize, viewSize);
                rootLayerViews[i].Position2D = new Position2D(1 + i*viewSize/3, startPos + i*viewSize/3);
                rootLayerViews[i].BackgroundColor = new Color( (255.0f - i*85.0f)/255.0f, 0.0f, 0.0f, 1.0f);
                rootLayer.Add(rootLayerViews[i]);
            }
            rootLayerText = new TextLabel(rootLayer.Name);
            rootLayerText.PointSize = 10;
            rootLayerText.Position2D = new Position2D(1, 1);
            rootLayerText.BackgroundColor = new Color(1.0f, 0.0f, 0.0f, 1.0f);
            rootLayer.Add(rootLayerText);

            //layer1
            layer1 = new Layer();
            layer1.Name = "Layer1";
            for(int i = 0; i < 3; i++)
            {
                layer1Views[i] = new View();
                layer1Views[i].Size2D = new Size2D(viewSize, viewSize);
                layer1Views[i].Position2D = new Position2D(startPos + i*viewSize/3, startPos + i*viewSize/3);
                layer1Views[i].BackgroundColor = new Color( 0.0f, (255.0f - i*85.0f)/255.0f, 0.0f, 1.0f);
                layer1.Add(layer1Views[i]);
            }
            layer1Text = new TextLabel(layer1.Name);
            layer1Text.PointSize = 10;
            layer1Text.Position2D = new Position2D(2, 1);
            layer1Text.BackgroundColor = new Color(0.0f, 1.0f, 0.0f, 1.0f);
            layer1.Add(layer1Text);
            window.AddLayer(layer1);

            //layer2
            layer2 = new Layer();
            layer2.Name = "Layer2";
            for(int i = 0; i < 3; i++)
            {
                layer2Views[i] = new View();
                layer2Views[i].Size2D = new Size2D(viewSize, viewSize);
                layer2Views[i].Position2D = new Position2D(startPos*2 + i*viewSize/3, startPos + i*viewSize/3);
                layer2Views[i].BackgroundColor = new Color( 0.0f, 0.0f, (255.0f - i*85.0f)/255.0f, 1.0f);
                layer2.Add(layer2Views[i]);
            }
            layer2Text = new TextLabel(layer2.Name);
            layer2Text.PointSize = 10;
            layer2Text.Position2D = new Position2D(3, 1);
            layer2Text.BackgroundColor = new Color(0.0f, 0.0f, 1.0f, 1.0f);
            layer2.Add(layer2Text);
            window.AddLayer(layer2);

        }

        int win_test;
        public void OnWindowKeyEvent(object sender, Window.KeyEventArgs e)
        {
            if (e.Key.State == Key.StateType.Down)
            {
                if (e.Key.KeyPressedName == "Up")
                {
                    layer1.Raise();
                }
                else if (e.Key.KeyPressedName == "Down")
                {
                    layer1.Lower();
                }
                else if (e.Key.KeyPressedName == "Right")
                {
                    layer1.RaiseToTop();
                }
                else if (e.Key.KeyPressedName == "Left")
                {
                    layer1.LowerToBottom();
                }
                else if (e.Key.KeyPressedName == "Return")
                {
                }
                else if (e.Key.KeyPressedName == "1")
                {
                    layer1Views[0].RaiseToTop();
                }
                else if (e.Key.KeyPressedName == "2")
                {
                    layer1Views[0].Raise();
                }
                else if (e.Key.KeyPressedName == "3")
                {
                    layer1Views[0].Lower();
                }
                else if (e.Key.KeyPressedName == "4")
                {
                    layer1Views[0].LowerToBottom();
                }
            }
        }

        [STAThread]
        static void _Main(string[] args)
        {
            Example example = new Example();
            example.Run(args);
        }
    }
}

