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
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Constants;

namespace VisualViewTest
{
    // An example of Visual View control.
    class Example : NUIApplication
    {
        private VisualView _visualView = null;
        private const string resources = "/home/owner/apps_rw/NUISamples.TizenTV/res";
        private Window _window;

        public Example() : base()
        {
        }

        public Example(string stylesheet) : base(stylesheet)
        {
        }

        public Example(string stylesheet, WindowMode windowMode) : base(stylesheet, windowMode)
        {
        }

        protected override void OnCreate()
        {
            base.OnCreate();
            Initialize();
        }

        private ImageVisual imageVisualMap1;
        private TextVisual textVisualMap1;
        private NPatchVisual npatchImageVisualMap1;
        private BorderVisual borderVisualMap1;
        private int cnt;

        public void Initialize()
        {
            Window window = Window.Instance;

            /* Create a visual view. */
            _visualView = new VisualView();
            _visualView.ParentOrigin = ParentOrigin.TopLeft;
            _visualView.PivotPoint = PivotPoint.TopLeft;
            _visualView.Size2D = new Size2D((int)window.Size.Width, (int)window.Size.Height);

            /* color visual */
            ColorVisual colorVisualMap1 = new ColorVisual();
            colorVisualMap1.Color = Color.Green;
            _visualView.Background = colorVisualMap1.OutputVisualMap;

            window.Add(_visualView);

            /* image visual 1. */
            imageVisualMap1 = new ImageVisual();
            imageVisualMap1.URL = resources + "/images/image-1.jpg";
            imageVisualMap1.Size = new Vector2(200.0f, 200.0f);
            imageVisualMap1.Position = new Vector2(10.0f, 10.0f);
            imageVisualMap1.PositionPolicy = VisualTransformPolicyType.Absolute;
            Console.WriteLine("PositionPolicy:{0}",imageVisualMap1.PositionPolicy);
            imageVisualMap1.SizePolicy = VisualTransformPolicyType.Absolute;
            Console.WriteLine("SizePolicy:{0}",imageVisualMap1.SizePolicy);
            imageVisualMap1.Origin = Visual.AlignType.TopBegin;
            imageVisualMap1.AnchorPoint = Visual.AlignType.TopBegin;
            _visualView.AddVisual("imageVisual1", imageVisualMap1);
            imageVisualMap1.URL = resources + "/images/image-3.jpg";

            /* image visual 2. */
            ImageVisual imageVisualMap2 = new ImageVisual();
            imageVisualMap2.URL = resources + "/images/image-2.jpg";
            imageVisualMap2.Size = new Vector2(250.0f, 200.0f);
            imageVisualMap2.Position = new Vector2(220.0f, 10.0f);
            imageVisualMap2.PositionPolicy = VisualTransformPolicyType.Absolute;
            imageVisualMap2.SizePolicy = VisualTransformPolicyType.Absolute;
            imageVisualMap2.Origin = Visual.AlignType.TopBegin;
            imageVisualMap2.AnchorPoint = Visual.AlignType.TopBegin;
            _visualView.AddVisual("imageVisual2", imageVisualMap2);

            /* text visual. */
            textVisualMap1 = new TextVisual();
            textVisualMap1.Text = "Hello Goodbye";
            textVisualMap1.PointSize = 20.0f;

            textVisualMap1.Size = new Vector2(900.0f, 250.0f);
            textVisualMap1.Position = new Vector2(10.0f, 220.0f);
            textVisualMap1.PositionPolicy = VisualTransformPolicyType.Absolute;
            textVisualMap1.SizePolicy = VisualTransformPolicyType.Absolute;
            textVisualMap1.Origin = Visual.AlignType.TopBegin;
            textVisualMap1.AnchorPoint = Visual.AlignType.TopBegin;
            _visualView.AddVisual("textVisual1", textVisualMap1);

            /* border visual */
            borderVisualMap1 = new BorderVisual();
            borderVisualMap1.Color = Color.Red;
            borderVisualMap1.BorderSize = 5.0f;

            borderVisualMap1.Size = new Vector2(100.0f, 100.0f);
            borderVisualMap1.Position = new Vector2(10.0f, 380.0f);
            borderVisualMap1.PositionPolicy = VisualTransformPolicyType.Absolute;
            borderVisualMap1.SizePolicy = VisualTransformPolicyType.Absolute;
            borderVisualMap1.Origin = Visual.AlignType.TopBegin;
            borderVisualMap1.AnchorPoint = Visual.AlignType.TopBegin;
            _visualView.AddVisual("borderVisual1", borderVisualMap1);

            /* gradient visual */
            GradientVisual gradientVisualMap1 = new GradientVisual();
            PropertyArray stopPosition = new PropertyArray();
            stopPosition.Add(new PropertyValue(0.0f));
            stopPosition.Add(new PropertyValue(0.3f));
            stopPosition.Add(new PropertyValue(0.6f));
            stopPosition.Add(new PropertyValue(0.8f));
            stopPosition.Add(new PropertyValue(1.0f));
            gradientVisualMap1.StopOffset = stopPosition;
            PropertyArray stopColor = new PropertyArray();
            stopColor.Add(new PropertyValue(new Vector4(129.0f, 198.0f, 193.0f, 255.0f) / 255.0f));
            stopColor.Add(new PropertyValue(new Vector4(196.0f, 198.0f, 71.0f, 122.0f) / 255.0f));
            stopColor.Add(new PropertyValue(new Vector4(214.0f, 37.0f, 139.0f, 191.0f) / 255.0f));
            stopColor.Add(new PropertyValue(new Vector4(129.0f, 198.0f, 193.0f, 150.0f) / 255.0f));
            stopColor.Add(new PropertyValue(Color.Yellow));
            gradientVisualMap1.StopColor = stopColor;
            gradientVisualMap1.StartPosition = new Vector2(0.5f, 0.5f);
            gradientVisualMap1.EndPosition = new Vector2(-0.5f, -0.5f);
            gradientVisualMap1.Center = new Vector2(0.5f, 0.5f);
            gradientVisualMap1.Radius = 1.414f;

            gradientVisualMap1.Size = new Vector2(100.0f, 100.0f);
            gradientVisualMap1.Position = new Vector2(120.0f, 380.0f);
            gradientVisualMap1.PositionPolicy = VisualTransformPolicyType.Absolute;
            gradientVisualMap1.SizePolicy = VisualTransformPolicyType.Absolute;
            gradientVisualMap1.Origin = Visual.AlignType.TopBegin;
            gradientVisualMap1.AnchorPoint = Visual.AlignType.TopBegin;
            _visualView.AddVisual("gradientVisual1", gradientVisualMap1);

            /* primitive visual: Cone */
            PrimitiveVisual primitiveVisualMap1 = new PrimitiveVisual();
            primitiveVisualMap1.Shape = PrimitiveVisualShapeType.Cone;
            primitiveVisualMap1.BevelPercentage = 0.3f;
            primitiveVisualMap1.BevelSmoothness = 0.0f;
            primitiveVisualMap1.ScaleDimensions = new Vector3(1.0f, 1.0f, 0.3f);
            primitiveVisualMap1.MixColor = new Vector4((245.0f / 255.0f), (188.0f / 255.0f), (73.0f / 255.0f), 1.0f);

            primitiveVisualMap1.Size = new Vector2(100.0f, 100.0f);
            primitiveVisualMap1.Position = new Vector2(230.0f, 380.0f);
            primitiveVisualMap1.PositionPolicy = VisualTransformPolicyType.Absolute;
            primitiveVisualMap1.SizePolicy = VisualTransformPolicyType.Absolute;
            primitiveVisualMap1.Origin = Visual.AlignType.TopBegin;
            primitiveVisualMap1.AnchorPoint = Visual.AlignType.TopBegin;
            _visualView.AddVisual("primitiveVisual1", primitiveVisualMap1);

            /* primitive visual: Sphere */
            PrimitiveVisual primitiveVisualMap2 = new PrimitiveVisual();
            primitiveVisualMap2.Shape = PrimitiveVisualShapeType.Sphere;
            primitiveVisualMap2.BevelPercentage = 0.3f;
            primitiveVisualMap2.BevelSmoothness = 0.0f;
            primitiveVisualMap2.ScaleDimensions = new Vector3(1.0f, 1.0f, 0.3f);
            primitiveVisualMap2.MixColor = new Vector4((245.0f / 255.0f), (188.0f / 255.0f), (73.0f / 255.0f), 1.0f);

            primitiveVisualMap2.Size = new Vector2(100.0f, 100.0f);
            primitiveVisualMap2.Position = new Vector2(340.0f, 380.0f);
            primitiveVisualMap2.PositionPolicy = VisualTransformPolicyType.Absolute;
            primitiveVisualMap2.SizePolicy = VisualTransformPolicyType.Absolute;
            primitiveVisualMap2.Origin = Visual.AlignType.TopBegin;
            primitiveVisualMap2.AnchorPoint = Visual.AlignType.TopBegin;
            _visualView.AddVisual("primitiveVisual2", primitiveVisualMap2);

            /* primitive visual: Cylinder */
            PrimitiveVisual primitiveVisualMap3 = new PrimitiveVisual();
            primitiveVisualMap3.Shape = PrimitiveVisualShapeType.Cylinder;
            primitiveVisualMap3.BevelPercentage = 0.3f;
            primitiveVisualMap3.BevelSmoothness = 0.0f;
            primitiveVisualMap3.ScaleDimensions = new Vector3(1.0f, 1.0f, 0.3f);
            primitiveVisualMap3.MixColor = new Vector4((245.0f / 255.0f), (188.0f / 255.0f), (73.0f / 255.0f), 1.0f);

            primitiveVisualMap3.Size = new Vector2(100.0f, 100.0f);
            primitiveVisualMap3.Position = new Vector2(10.0f, 490.0f);
            primitiveVisualMap3.PositionPolicy = VisualTransformPolicyType.Absolute;
            primitiveVisualMap3.SizePolicy = VisualTransformPolicyType.Absolute;
            primitiveVisualMap3.Origin = Visual.AlignType.TopBegin;
            primitiveVisualMap3.AnchorPoint = Visual.AlignType.TopBegin;
            _visualView.AddVisual("primitiveVisual3", primitiveVisualMap3);

            /* primitive visual: ConicalFrustrum */
            PrimitiveVisual primitiveVisualMap4 = new PrimitiveVisual();
            primitiveVisualMap4.Shape = PrimitiveVisualShapeType.ConicalFrustrum;
            primitiveVisualMap4.BevelPercentage = 0.3f;
            primitiveVisualMap4.BevelSmoothness = 0.0f;
            primitiveVisualMap4.ScaleDimensions = new Vector3(1.0f, 1.0f, 0.3f);
            primitiveVisualMap4.MixColor = new Vector4((245.0f / 255.0f), (188.0f / 255.0f), (73.0f / 255.0f), 1.0f);

            primitiveVisualMap4.Size = new Vector2(100.0f, 100.0f);
            primitiveVisualMap4.Position = new Vector2(120.0f, 490.0f);
            primitiveVisualMap4.PositionPolicy = VisualTransformPolicyType.Absolute;
            primitiveVisualMap4.SizePolicy = VisualTransformPolicyType.Absolute;
            primitiveVisualMap4.Origin = Visual.AlignType.TopBegin;
            primitiveVisualMap4.AnchorPoint = Visual.AlignType.TopBegin;
            _visualView.AddVisual("primitiveVisual4", primitiveVisualMap4);

            /* primitive visual: Cube */
            PrimitiveVisual primitiveVisualMap5 = new PrimitiveVisual();
            primitiveVisualMap5.Shape = PrimitiveVisualShapeType.Cube;
            primitiveVisualMap5.BevelPercentage = 0.3f;
            primitiveVisualMap5.BevelSmoothness = 0.0f;
            primitiveVisualMap5.ScaleDimensions = new Vector3(1.0f, 1.0f, 0.3f);
            primitiveVisualMap5.MixColor = new Vector4((245.0f / 255.0f), (188.0f / 255.0f), (73.0f / 255.0f), 1.0f);

            primitiveVisualMap5.Size = new Vector2(100.0f, 100.0f);
            primitiveVisualMap5.Position = new Vector2(230.0f, 490.0f);
            primitiveVisualMap5.PositionPolicy = VisualTransformPolicyType.Absolute;
            primitiveVisualMap5.SizePolicy = VisualTransformPolicyType.Absolute;
            primitiveVisualMap5.Origin = Visual.AlignType.TopBegin;
            primitiveVisualMap5.AnchorPoint = Visual.AlignType.TopBegin;
            _visualView.AddVisual("primitiveVisual5", primitiveVisualMap5);

            /* mesh visual nothing show. */
            MeshVisual meshVisualMap1 = new MeshVisual();
            meshVisualMap1.ObjectURL = resources + "/models/Dino.obj";
            meshVisualMap1.MaterialtURL = resources + "/models/Dino.mtl";
            meshVisualMap1.TexturesPath = resources + "/images/";
            meshVisualMap1.ShadingMode = MeshVisualShadingModeValue.TexturedWithSpecularLighting;

            meshVisualMap1.Size = new Size2D(400, 400);
            meshVisualMap1.Position = new Position2D(-50, 600);
            meshVisualMap1.PositionPolicy = VisualTransformPolicyType.Absolute;
            meshVisualMap1.SizePolicy = VisualTransformPolicyType.Absolute;
            meshVisualMap1.Origin = Visual.AlignType.TopBegin;
            meshVisualMap1.AnchorPoint = Visual.AlignType.TopBegin;
            _visualView.AddVisual("meshVisual1", meshVisualMap1);

            /* n-patch image visual 1. */
            npatchImageVisualMap1 = new NPatchVisual();
            npatchImageVisualMap1.URL = resources + "/images/gallery-4.jpg";
            npatchImageVisualMap1.Size = new Size2D(400, 400);
            npatchImageVisualMap1.Position = new Position2D(300, 600);
            npatchImageVisualMap1.PositionPolicyX = VisualTransformPolicyType.Absolute;
            npatchImageVisualMap1.PositionPolicyY = VisualTransformPolicyType.Absolute;
            npatchImageVisualMap1.SizePolicyWidth = VisualTransformPolicyType.Absolute;
            npatchImageVisualMap1.SizePolicyHeight = VisualTransformPolicyType.Absolute;
            npatchImageVisualMap1.Origin = Visual.AlignType.TopBegin;
            npatchImageVisualMap1.AnchorPoint = Visual.AlignType.TopBegin;
            npatchImageVisualMap1.Border = new Rectangle(100, 100, 100, 100);
            _visualView.AddVisual("npatchImageVisual1", npatchImageVisualMap1);

            _window = Window.Instance;
            _window.FocusChanged += (sender, ee) =>
            {
                cnt++;
                Tizen.Log.Debug("NUI", "[WindowFocusTest] WindowFocusChanged event comes! focus gained=" + ee.FocusGained);
                imageVisualMap1.Size += new Size2D(50, 50);
                imageVisualMap1.Position += new Vector2(20.0f, 20.0f);

                textVisualMap1.Text = "Hello Goodbye" + cnt;
                textVisualMap1.PointSize = 10.0f + (float)(cnt);

                npatchImageVisualMap1.URL = resources + "/images/gallery-" + (cnt % 5) + ".jpg";

                borderVisualMap1.BorderSize = 1.0f + (float)cnt;
            };

            Tizen.Log.Debug("NUI", "[WindowFocusTest] is focus acceptable=" + _window.IsFocusAcceptable());
            _window.SetAcceptFocus(false);
            Tizen.Log.Debug("NUI", "[WindowFocusTest] set focus acceptable=false!!!");
            Tizen.Log.Debug("NUI", "[WindowFocusTest] is focus acceptable=" + _window.IsFocusAcceptable());
            _window.SetAcceptFocus(true);
            Tizen.Log.Debug("NUI", "[WindowFocusTest] set focus acceptable=true!!!");
            Tizen.Log.Debug("NUI", "[WindowFocusTest] is focus acceptable=" + _window.IsFocusAcceptable());


        }

        [STAThread]
        static void _Main(string[] args)
        {
            Example example = new Example();
            example.Run(args);
        }
    }
}