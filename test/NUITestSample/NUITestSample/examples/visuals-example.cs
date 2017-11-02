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
using Tizen.NUI.BaseComponents;

namespace VisualsExampleTest
{
    class Example : NUIApplication
    {
        private TextLabel _title;
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
            Window window = Window.Instance;
            window.BackgroundColor = Color.White;

            TableView contentLayout = new TableView(4, 1);
            contentLayout.Name = ("ContentLayout");
            contentLayout.WidthResizePolicy = ResizePolicyType.FillToParent;
            contentLayout.HeightResizePolicy = ResizePolicyType.FillToParent;

            contentLayout.SetCellPadding(new Size2D(0, 5));
            contentLayout.BackgroundColor = Color.Red;//new Color(0.949f, 0.949f, 0.949f, 1.0f);

            window.Add(contentLayout);

            _title = new TextLabel("Visuals Example");
            _title.Name = "Title";
            _title.StyleName = "Title";
            _title.WidthResizePolicy = ResizePolicyType.FillToParent;
            _title.HeightResizePolicy = ResizePolicyType.UseNaturalSize;
            _title.HorizontalAlignment = HorizontalAlignment.Center;
            _title.BackgroundColor = Color.Yellow;
            contentLayout.Add(_title);
            contentLayout.SetFitHeight(0);

            // Color Visual example
            ImageView colorView = new ImageView();
            //colorView.WidthResizePolicy = ResizePolicyType.SizeRelativeToParent;
            //colorView.HeightResizePolicy = ResizePolicyType.SizeRelativeToParent;
            // PropertyMap colorVisual = new PropertyMap();
            // colorVisual.Add( Visual.Property.Type, new PropertyValue( (int)Visual.Type.Color ))
            //            .Add( ColorVisualProperty.MixColor, new PropertyValue( Color.Green ));
            //colorView.Background = colorVisual;
            colorView.Size2D = new Size2D(500, 200);
            colorView.ResourceUrl = resources+"/images/00_popup_bg.9.png";
            colorView.Border = new Rectangle(100, 100, 100, 100);
           // colorView.
            // PropertyMap _map = new PropertyMap();
            // _map.Add(Visual.Property.Type, new PropertyValue((int)Visual.Type.NPatch));
            // _map.Add(NpatchImageVisualProperty.URL, new PropertyValue(resources+"/images/00_popup_bg.9.png"));
            // _map.Add(NpatchImageVisualProperty.Border, new PropertyValue(new Rectangle(100, 100, 100, 100)));
             //_map.Add(NpatchImageVisualProperty.BorderOnly, new PropertyValue(true));
            //colorView.Background = _map;
            contentLayout.Add(colorView);

            // Image Visual example
            View imageView = new View();
            imageView.WidthResizePolicy = ResizePolicyType.UseNaturalSize;
            imageView.HeightResizePolicy = ResizePolicyType.UseNaturalSize;
            PropertyMap imageVisual = new PropertyMap();
            imageVisual.Add( Visual.Property.Type, new PropertyValue( (int)Visual.Type.Image ));
            imageVisual.Add(ImageVisualProperty.URL,  new PropertyValue( resources + "/images/gallery-0.jpg" ));
            imageView.Background = imageVisual;
            contentLayout.SetCellAlignment(new TableView.CellPosition(2, 0), HorizontalAlignmentType.Center, VerticalAlignmentType.Center);
            contentLayout.Add(imageView);
            for(int i =1; i<=5; i++)
            {
                PropertyMap imageVisual1 = new PropertyMap();
                imageVisual1.Add( Visual.Property.Type, new PropertyValue( (int)Visual.Type.Image ));
                imageVisual1.Add(ImageVisualProperty.URL,  new PropertyValue( resources + "/images/gallery-"+i+".jpg" ));
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
            Example example = new Example( resources + "/json/style-example-theme-one.json");
            example.Run(args);
        }
    }
}
