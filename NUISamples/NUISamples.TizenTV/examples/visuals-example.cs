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
using Tizen.NUI;
using Tizen.NUI.Constants;

namespace MyCSharpExample
{
    class VisualExample : NUIApplication
    {
        private TextLabel _title;

        public VisualExample() : base()
        {
        }

        public VisualExample(string stylesheet) : base(stylesheet)
        {
        }

        public VisualExample(string stylesheet, WindowMode windowMode) : base(stylesheet, windowMode)
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
            stage.BackgroundColor = Color.White;

            TableView contentLayout = new TableView(4, 1);
            contentLayout.Name = ("ContentLayout");
            contentLayout.WidthResizePolicy = ResizePolicyType.FillToParent;
            contentLayout.HeightResizePolicy = ResizePolicyType.FillToParent;
            contentLayout.ParentOrigin = ParentOrigin.Center;
            contentLayout.AnchorPoint = AnchorPoint.Center;
            
            contentLayout.SetCellPadding(new Size2D(0, 5));
            contentLayout.BackgroundColor = Color.Red;//new Color(0.949f, 0.949f, 0.949f, 1.0f);

            stage.GetDefaultLayer().Add(contentLayout);

            _title = new TextLabel("Visuals Example");
            _title.Name = "Title";
            _title.StyleName = "Title";
            _title.WidthResizePolicy = ResizePolicyType.FillToParent;
            _title.HeightResizePolicy = ResizePolicyType.UseNaturalSize;
            _title.HorizontalAlignment = "CENTER";
            _title.BackgroundColor = Color.Yellow;
            contentLayout.Add(_title);
            contentLayout.SetFitHeight(0);

            // Color Visual example
            View colorView = new View();
            colorView.WidthResizePolicy = ResizePolicyType.SizeRelativeToParent;
            colorView.HeightResizePolicy = ResizePolicyType.SizeRelativeToParent;
            PropertyMap colorVisual = new PropertyMap();
            colorVisual.Add( Visual.Property.Type, new PropertyValue( (int)Visual.Type.Color ))
                       .Add( ColorVisualProperty.MixColor, new PropertyValue( Color.Green ));
            colorView.Background = colorVisual;
            contentLayout.Add(colorView);

            // Image Visual example
            View imageView = new View();
            imageView.WidthResizePolicy = ResizePolicyType.UseNaturalSize;
            imageView.HeightResizePolicy = ResizePolicyType.UseNaturalSize;
            PropertyMap imageVisual = new PropertyMap();
            imageVisual.Add( Visual.Property.Type, new PropertyValue( (int)Visual.Type.Image ));
            imageVisual.Add(ImageVisualProperty.URL,  new PropertyValue("/home/owner/apps_rw/NUISamples.TizenTV/res/images/gallery-0.jpg"));
            imageView.Background = imageVisual;
            contentLayout.SetCellAlignment(new TableView.CellPosition(2, 0), HorizontalAlignmentType.Center, VerticalAlignmentType.Center);
            contentLayout.Add(imageView);
            for(int i =1; i<=5; i++)
            {
                PropertyMap imageVisual1 = new PropertyMap();
                imageVisual1.Add( Visual.Property.Type, new PropertyValue( (int)Visual.Type.Image ));
                imageVisual1.Add(ImageVisualProperty.URL,  new PropertyValue("/home/owner/apps_rw/NUISamples.TizenTV/res/images/gallery-" + i+".jpg" ));
                imageView.Background = imageVisual1;
            }

            // Primitive Visual example
            View primitiveView = new View();
            primitiveView.WidthResizePolicy = ResizePolicyType.SizeRelativeToParent;
            primitiveView.HeightResizePolicy = ResizePolicyType.SizeRelativeToParent;
            PropertyMap primitiveVisual = new PropertyMap();
            primitiveVisual.Add( Visual.Property.Type, new PropertyValue( (int)Visual.Type.Primitive ))
                           .Add( PrimitiveVisualProperty.Shape, new PropertyValue((int)PrimitiveVisualShapeType.BevelledCube))
                           .Add( PrimitiveVisualProperty.BevelPercentage, new PropertyValue(0.3f))
                           .Add( PrimitiveVisualProperty.BevelSmoothness, new PropertyValue(0.0f))
                           .Add( PrimitiveVisualProperty.ScaleDimensions, new PropertyValue(new Vector3(1.0f,1.0f,0.3f)))
                           .Add( PrimitiveVisualProperty.MixColor, new PropertyValue(new Vector4(0.7f, 0.5f, 0.05f, 1.0f)));
            primitiveView.Background = primitiveVisual;
            Radian rad = new Radian(new Degree(45.0f));
            primitiveView.Orientation = new Rotation(rad, Vector3.YAxis);
            contentLayout.Add(primitiveView);

            // Text Visual example
            View textView = new View();
            textView.WidthResizePolicy = ResizePolicyType.SizeRelativeToParent;
            textView.HeightResizePolicy = ResizePolicyType.SizeRelativeToParent;
            PropertyMap textVisual = new PropertyMap();
            textVisual.Add( Visual.Property.Type, new PropertyValue( (int)Visual.Type.Text ))
                      .Add( TextVisualProperty.Text, new PropertyValue("I am text visual"))
                      .Add( TextVisualProperty.TextColor, new PropertyValue(Color.Blue))
                      .Add( TextVisualProperty.PointSize, new PropertyValue(20));
            textView.Background = textVisual;
            contentLayout.Add(textView);
        }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void _Main(string[] args)
        {
            VisualExample example = new VisualExample("/home/owner/apps_rw/NUISamples.TizenTV/res/json/style-example-theme-one.json");
            example.Run(args);
        }
    }
}
