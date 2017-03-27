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

namespace VisualViewTest
{
    // An example of Visual View control.
    class Example : NUIApplication
    {
        private VisualView _visualView = null;
        private const string resources = "/home/owner/apps_rw/NUISamples.TizenTV/res";

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

        public void Initialize()
        {
            Stage stage = Stage.Instance;

            /* Create a visual view. */
            _visualView = new VisualView();
            _visualView.ParentOrigin = ParentOrigin.TopLeft;
            _visualView.AnchorPoint = AnchorPoint.TopLeft;
            _visualView.Size = new Size(stage.Size.Width, stage.Size.Height, 0.0f);

            /* color visual */
            ColorVisualMap colorVisualMap1 = new ColorVisualMap();
            colorVisualMap1.MixColor = Color.Green;
            _visualView.Background = colorVisualMap1.OutputVisualMap;
            stage.GetDefaultLayer().Add(_visualView);

            /* image visual 1. */
            ImageVisualMap imageVisualMap1 = new ImageVisualMap();
            imageVisualMap1.URL = resources + "/images/image-1.jpg";
            imageVisualMap1.VisualSize = new Vector2(200.0f, 200.0f);
            imageVisualMap1.Offset = new Vector2(10.0f, 10.0f);
            imageVisualMap1.OffsetPolicy = new Vector2(1, 1);
            imageVisualMap1.SizePolicy = new Vector2(1, 1);
            imageVisualMap1.Origin = AlignType.TopBegin;
            imageVisualMap1.AnchorPoint = AlignType.TopBegin;
            _visualView.AddVisual("imageVisual1", imageVisualMap1);

            /* image visual 2. */
            ImageVisualMap imageVisualMap2 = new ImageVisualMap();
            imageVisualMap2.URL = resources + "/images/image-2.jpg";
            imageVisualMap2.VisualSize = new Vector2(250.0f, 200.0f);
            imageVisualMap2.Offset = new Vector2(220.0f, 10.0f);
            imageVisualMap2.OffsetPolicy = new Vector2(1, 1);
            imageVisualMap2.SizePolicy = new Vector2(1, 1);
            imageVisualMap2.Origin = AlignType.TopBegin;
            imageVisualMap2.AnchorPoint = AlignType.TopBegin;
            _visualView.AddVisual("imageVisual2", imageVisualMap2);

            /* Modify imageVisual2, we just need do this. */
            //imageVisualMap2.URL = "./examples/images/image-3.jpg";
            //_visualView.AddVisual("imageVisual2", imageVisualMap2); //update a visual with same visual name.

            //_visualView.RemoveVisual( "imageVisual1" );
            //_visualView.RemoveVisual( imageVisualMap1 );

            //_visualView.RemoveAll(); //Delete all visuals of visual view.

            /* text visual. */
            TextVisualMap textVisualMap1 = new TextVisualMap();
            textVisualMap1.Text = "Hello Goodbye";
            textVisualMap1.PointSize = 20.0f;

            textVisualMap1.VisualSize = new Vector2(900.0f, 250.0f);
            textVisualMap1.Offset = new Vector2(10.0f, 220.0f);
            textVisualMap1.OffsetPolicy = new Vector2(1, 1);
            textVisualMap1.SizePolicy = new Vector2(1, 1);
            textVisualMap1.Origin = AlignType.TopBegin;
            textVisualMap1.AnchorPoint = AlignType.TopBegin;
            _visualView.AddVisual("textVisual1", textVisualMap1);

            /* border visual */
            BorderVisualMap borderVisualMap1 = new BorderVisualMap();
            borderVisualMap1.Color = Color.Red;
            borderVisualMap1.Size = 5.0f;

            borderVisualMap1.VisualSize = new Vector2(100.0f, 100.0f);
            borderVisualMap1.Offset = new Vector2(10.0f, 380.0f);
            borderVisualMap1.OffsetPolicy = new Vector2(1, 1);
            borderVisualMap1.SizePolicy = new Vector2(1, 1);
            borderVisualMap1.Origin = AlignType.TopBegin;
            borderVisualMap1.AnchorPoint = AlignType.TopBegin;
            _visualView.AddVisual("borderVisual1", borderVisualMap1);

            /* gradient visual */
            GradientVisualMap gradientVisualMap1 = new GradientVisualMap();
            PropertyArray stopOffset = new PropertyArray();
            stopOffset.Add(new PropertyValue(0.0f));
            stopOffset.Add(new PropertyValue(0.3f));
            stopOffset.Add(new PropertyValue(0.6f));
            stopOffset.Add(new PropertyValue(0.8f));
            stopOffset.Add(new PropertyValue(1.0f));
            gradientVisualMap1.StopOffset = stopOffset;
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

            gradientVisualMap1.VisualSize = new Vector2(100.0f, 100.0f);
            gradientVisualMap1.Offset = new Vector2(120.0f, 380.0f);
            gradientVisualMap1.OffsetPolicy = new Vector2(1, 1);
            gradientVisualMap1.SizePolicy = new Vector2(1, 1);
            gradientVisualMap1.Origin = AlignType.TopBegin;
            gradientVisualMap1.AnchorPoint = AlignType.TopBegin;
            _visualView.AddVisual("gradientVisual1", gradientVisualMap1);

            /* primitive visual: Cone */
            PrimitiveVisualMap primitiveVisualMap1 = new PrimitiveVisualMap();
            primitiveVisualMap1.Shape = PrimitiveVisualShapeType.Cone;
            primitiveVisualMap1.BevelPercentage = 0.3f;
            primitiveVisualMap1.BevelSmoothness = 0.0f;
            primitiveVisualMap1.ScaleDimensions = new Vector3(1.0f, 1.0f, 0.3f);
            primitiveVisualMap1.MixColor = new Vector4((245.0f / 255.0f), (188.0f / 255.0f), (73.0f / 255.0f), 1.0f);

            primitiveVisualMap1.VisualSize = new Vector2(100.0f, 100.0f);
            primitiveVisualMap1.Offset = new Vector2(230.0f, 380.0f);
            primitiveVisualMap1.OffsetPolicy = new Vector2(1, 1);
            primitiveVisualMap1.SizePolicy = new Vector2(1, 1);
            primitiveVisualMap1.Origin = AlignType.TopBegin;
            primitiveVisualMap1.AnchorPoint = AlignType.TopBegin;
            _visualView.AddVisual("primitiveVisual1", primitiveVisualMap1);

            /* primitive visual: Sphere */
            PrimitiveVisualMap primitiveVisualMap2 = new PrimitiveVisualMap();
            primitiveVisualMap2.Shape = PrimitiveVisualShapeType.Sphere;
            primitiveVisualMap2.BevelPercentage = 0.3f;
            primitiveVisualMap2.BevelSmoothness = 0.0f;
            primitiveVisualMap2.ScaleDimensions = new Vector3(1.0f, 1.0f, 0.3f);
            primitiveVisualMap2.MixColor = new Vector4((245.0f / 255.0f), (188.0f / 255.0f), (73.0f / 255.0f), 1.0f);

            primitiveVisualMap2.VisualSize = new Vector2(100.0f, 100.0f);
            primitiveVisualMap2.Offset = new Vector2(340.0f, 380.0f);
            primitiveVisualMap2.OffsetPolicy = new Vector2(1, 1);
            primitiveVisualMap2.SizePolicy = new Vector2(1, 1);
            primitiveVisualMap2.Origin = AlignType.TopBegin;
            primitiveVisualMap2.AnchorPoint = AlignType.TopBegin;
            _visualView.AddVisual("primitiveVisual2", primitiveVisualMap2);

            /* primitive visual: Cylinder */
            PrimitiveVisualMap primitiveVisualMap3 = new PrimitiveVisualMap();
            primitiveVisualMap3.Shape = PrimitiveVisualShapeType.Cylinder;
            primitiveVisualMap3.BevelPercentage = 0.3f;
            primitiveVisualMap3.BevelSmoothness = 0.0f;
            primitiveVisualMap3.ScaleDimensions = new Vector3(1.0f, 1.0f, 0.3f);
            primitiveVisualMap3.MixColor = new Vector4((245.0f / 255.0f), (188.0f / 255.0f), (73.0f / 255.0f), 1.0f);

            primitiveVisualMap3.VisualSize = new Vector2(100.0f, 100.0f);
            primitiveVisualMap3.Offset = new Vector2(10.0f, 490.0f);
            primitiveVisualMap3.OffsetPolicy = new Vector2(1, 1);
            primitiveVisualMap3.SizePolicy = new Vector2(1, 1);
            primitiveVisualMap3.Origin = AlignType.TopBegin;
            primitiveVisualMap3.AnchorPoint = AlignType.TopBegin;
            _visualView.AddVisual("primitiveVisual3", primitiveVisualMap3);

            /* primitive visual: ConicalFrustrum */
            PrimitiveVisualMap primitiveVisualMap4 = new PrimitiveVisualMap();
            primitiveVisualMap4.Shape = PrimitiveVisualShapeType.ConicalFrustrum;
            primitiveVisualMap4.BevelPercentage = 0.3f;
            primitiveVisualMap4.BevelSmoothness = 0.0f;
            primitiveVisualMap4.ScaleDimensions = new Vector3(1.0f, 1.0f, 0.3f);
            primitiveVisualMap4.MixColor = new Vector4((245.0f / 255.0f), (188.0f / 255.0f), (73.0f / 255.0f), 1.0f);

            primitiveVisualMap4.VisualSize = new Vector2(100.0f, 100.0f);
            primitiveVisualMap4.Offset = new Vector2(120.0f, 490.0f);
            primitiveVisualMap4.OffsetPolicy = new Vector2(1, 1);
            primitiveVisualMap4.SizePolicy = new Vector2(1, 1);
            primitiveVisualMap4.Origin = AlignType.TopBegin;
            primitiveVisualMap4.AnchorPoint = AlignType.TopBegin;
            _visualView.AddVisual("primitiveVisual4", primitiveVisualMap4);

            /* primitive visual: Cube */
            PrimitiveVisualMap primitiveVisualMap5 = new PrimitiveVisualMap();
            primitiveVisualMap5.Shape = PrimitiveVisualShapeType.Cube;
            primitiveVisualMap5.BevelPercentage = 0.3f;
            primitiveVisualMap5.BevelSmoothness = 0.0f;
            primitiveVisualMap5.ScaleDimensions = new Vector3(1.0f, 1.0f, 0.3f);
            primitiveVisualMap5.MixColor = new Vector4((245.0f / 255.0f), (188.0f / 255.0f), (73.0f / 255.0f), 1.0f);

            primitiveVisualMap5.VisualSize = new Vector2(100.0f, 100.0f);
            primitiveVisualMap5.Offset = new Vector2(230.0f, 490.0f);
            primitiveVisualMap5.OffsetPolicy = new Vector2(1, 1);
            primitiveVisualMap5.SizePolicy = new Vector2(1, 1);
            primitiveVisualMap5.Origin = AlignType.TopBegin;
            primitiveVisualMap5.AnchorPoint = AlignType.TopBegin;
            _visualView.AddVisual("primitiveVisual5", primitiveVisualMap5);

            /* mesh visual nothing show. */
            MeshVisualMap meshVisualMap1 = new MeshVisualMap();
            meshVisualMap1.ObjectURL = resources + "/models/Dino.obj";
            meshVisualMap1.MaterialtURL = resources + "/models/Dino.mtl";
            meshVisualMap1.TexturesPath = resources + "/images/";
            meshVisualMap1.ShadingMode = MeshVisualShadingModeValue.TexturedWithSpecularLighting;

            meshVisualMap1.VisualSize = new Vector2(200.0f, 200.0f);
            meshVisualMap1.Offset = new Vector2(10.0f, 600.0f);
            meshVisualMap1.OffsetPolicy = new Vector2(1, 1);
            meshVisualMap1.SizePolicy = new Vector2(1, 1);
            meshVisualMap1.Origin = AlignType.TopBegin;
            meshVisualMap1.AnchorPoint = AlignType.TopBegin;
            _visualView.AddVisual("meshVisual1", meshVisualMap1);
        }

        [STAThread]
        static void _Main(string[] args)
        {
            Example example = new Example();
            example.Run(args);
        }
    }
}