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
using Dali;
using Dali.Constants;

namespace MyCSharpExample
{
    class Example
    {
        private Application _application;
        private TextLabel _title;

        public Example(Application application)
        {
            _application = application;
            _application.Initialized += Initialize;
        }

        public void Initialize(object source, NUIApplicationInitEventArgs e)
        {
            Window window = Window.Instance;
            window.BackgroundColor = Color.White;

            TableView contentLayout = new TableView(4, 1);
            contentLayout.Name = ("ContentLayout");
            contentLayout.WidthResizePolicy = "FILL_TO_PARENT";
            contentLayout.HeightResizePolicy = "FILL_TO_PARENT";
            contentLayout.SetCellPadding(new Size2D(0, 5));
            contentLayout.BackgroundColor = new Color(0.949f, 0.949f, 0.949f, 1.0f);

            window.GetDefaultLayer().Add(contentLayout);

            _title = new TextLabel("Visuals Example");
            _title.Name = "Title";
            _title.StyleName = "Title";
            _title.WidthResizePolicy = "FILL_TO_PARENT";
            _title.HeightResizePolicy = "USE_NATURAL_SIZE";
            _title.HorizontalAlignment = "CENTER";
            _title.BackgroundColor = Color.Yellow;
            contentLayout.Add(_title);
            contentLayout.SetFitHeight(0);

            // Color Visual example
            View colorView = new View();
            colorView.WidthResizePolicy = "SIZE_RELATIVE_TO_PARENT";
            colorView.HeightResizePolicy = "SIZE_RELATIVE_TO_PARENT";
            Property.Map colorVisual = new Property.Map();
            colorVisual.Add( Visual.Property.Type, new Property.Value( (int)Visual.Type.Color ))
                       .Add( ColorVisualProperty.MixColor, new Property.Value( Color.Green ));
            colorView.Background = colorVisual;
            contentLayout.Add(colorView);

            // Image Visual example
            View imageView = new View();
            imageView.WidthResizePolicy = "USE_NATURAL_SIZE";
            imageView.HeightResizePolicy = "USE_NATURAL_SIZE";
            Property.Map imageVisual = new Property.Map();
            imageVisual.Add( Visual.Property.Type, new Property.Value( (int)Visual.Type.Image ))
                       .Add( ImageVisualProperty.URL, new Property.Value( "./images/gallery-0.jpg" ));
            imageView.Background = imageVisual;
            contentLayout.SetCellAlignment(new TableView.CellPosition(2, 0), HorizontalAlignmentType.CENTER, VerticalAlignmentType.CENTER);
            contentLayout.Add(imageView);

            // Primitive Visual example
            View primitiveView = new View();
            primitiveView.WidthResizePolicy = "SIZE_RELATIVE_TO_PARENT";
            primitiveView.HeightResizePolicy = "SIZE_RELATIVE_TO_PARENT";
            Property.Map primitiveVisual = new Property.Map();
            primitiveVisual.Add( Visual.Property.Type, new Property.Value( (int)Visual.Type.Primitive ))
                           .Add( PrimitiveVisualProperty.Shape, new Property.Value((int)PrimitiveVisualShapeType.BEVELLED_CUBE))
                           .Add( PrimitiveVisualProperty.BevelPercentage, new Property.Value(0.3f))
                           .Add( PrimitiveVisualProperty.BevelSmoothness, new Property.Value(0.0f))
                           .Add( PrimitiveVisualProperty.ScaleDimensions, new Property.Value(new Vector3(1.0f,1.0f,0.3f)))
                           .Add( PrimitiveVisualProperty.MixColor, new Property.Value(new Vector4(0.7f, 0.5f, 0.05f, 1.0f)));
            primitiveView.Background = primitiveVisual;
            Radian rad = new Radian(new Degree(45.0f));
            primitiveView.Orientation = new Rotation(rad, Vector3.YAXIS);
            contentLayout.Add(primitiveView);

            // Text Visual example
            View textView = new View();
            textView.WidthResizePolicy = "SIZE_RELATIVE_TO_PARENT";
            textView.HeightResizePolicy = "SIZE_RELATIVE_TO_PARENT";
            Property.Map textVisual = new Property.Map();
            textVisual.Add( Visual.Property.Type, new Property.Value( (int)Visual.Type.Text ))
                      .Add( TextVisualProperty.Text, new Property.Value("I am text visual"))
                      .Add( TextVisualProperty.TextColor, new Property.Value(Color.Blue))
                      .Add( TextVisualProperty.PointSize, new Property.Value(20));
            textView.Background = textVisual;
            contentLayout.Add(textView);
        }

        public void MainLoop()
        {
            _application.MainLoop();
        }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Example example = new Example(Application.NewApplication());
            example.MainLoop();
        }
    }
}