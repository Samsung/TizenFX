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

// A ContactView is a Custom View which consists of four visuals (Image, Primitive, Text and Color).
// All of these visuals can be configured via properties - ImageURL (Image), Shape (Primitive), Name (Text) and Color.
// Tap gesture is also enabled on the ContactView which changes the color visual to some random color when ContactView is tapped.

namespace VisualsUsingCustomView
{
    public class ContactView : CustomView
    {
        private const int ColorVisualPropertyIndex = 0;
        private const int PrimitiveVisualPropertyIndex = 1;
        private const int ImageVisualPropertyIndex = 2;
        private const int TextVisualPropertyIndex = 3;
        private VisualBase _imageVisual;
        private VisualBase _colorVisual;
        private VisualBase _primitiveVisual;
        private VisualBase _textVisual;
        private int _shape;
        private string _imageURL;
        private string _name;
        private Color _color;

        public ContactView() : base(typeof(ContactView).Name, ViewWrapperImpl.CustomViewBehaviour.REQUIRES_KEYBOARD_NAVIGATION_SUPPORT)
        {
        }

        public string ImageURL
        {
            get
            {
                return _imageURL;
            }
            set
            {
                _imageURL = value;

                // Create and Register Image Visual
                Dali.Property.Map imageVisual = new Dali.Property.Map();
                imageVisual.Add( Visual.Property.Type, new Dali.Property.Value( (int)Visual.Type.Image ))
                    .Add( ImageVisualProperty.URL, new Dali.Property.Value( _imageURL ));
                _imageVisual =  VisualFactory.Get().CreateVisual( imageVisual );
                RegisterVisual( ImageVisualPropertyIndex, _imageVisual );

                // Set the depth index for Image visual
                _imageVisual.SetDepthIndex(ImageVisualPropertyIndex);
            }
        }

        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;

                // Create and Register Text Visual
                Dali.Property.Map textVisual = new Dali.Property.Map();
                textVisual.Add(Visual.Property.Type, new Dali.Property.Value((int)Visual.Type.Text))
                    .Add(TextVisualProperty.Text, new Dali.Property.Value(_name))
                    .Add(TextVisualProperty.TextColor, new Dali.Property.Value(Dali.Color.White))
                    .Add(TextVisualProperty.PointSize, new Dali.Property.Value(15))
                    .Add( TextVisualProperty.HorizontalAlignment, new Dali.Property.Value("CENTER"))
                    .Add( TextVisualProperty.VerticalAlignment, new Dali.Property.Value("CENTER"));
                _textVisual =  VisualFactory.Get().CreateVisual( textVisual );
                RegisterVisual( TextVisualPropertyIndex, _textVisual );

                // Set the depth index for Text visual
                _textVisual.SetDepthIndex(TextVisualPropertyIndex);
            }
        }

        public Color Color
        {
            get
            {
                return _color;
            }
            set
            {
                _color = value;

                // Create and Register Color Visual
                Dali.Property.Map colorVisual = new Dali.Property.Map();
                colorVisual.Add( Visual.Property.Type, new Dali.Property.Value( (int)Visual.Type.Color ))
                    .Add( ColorVisualProperty.MixColor, new Dali.Property.Value( _color ));
                _colorVisual =  VisualFactory.Get().CreateVisual( colorVisual );
                RegisterVisual( ColorVisualPropertyIndex, _colorVisual );

                // Set the depth index for Color visual
                _colorVisual.SetDepthIndex(ColorVisualPropertyIndex);
            }
        }

        public int Shape
        {
            get
            {
                return _shape;
            }
            set
            {
                _shape = value;

                // Create and Register Primitive Visual
                Dali.Property.Map primitiveVisual = new Dali.Property.Map();
                primitiveVisual.Add( Visual.Property.Type, new Dali.Property.Value( (int)Visual.Type.Primitive ))
                    .Add( PrimitiveVisualProperty.Shape, new Dali.Property.Value(_shape))
                    .Add( PrimitiveVisualProperty.BevelPercentage, new Dali.Property.Value(0.3f))
                    .Add( PrimitiveVisualProperty.BevelSmoothness, new Dali.Property.Value(0.0f))
                    .Add( PrimitiveVisualProperty.ScaleDimensions, new Dali.Property.Value(new Vector3(1.0f,1.0f,0.3f)))
                    .Add( PrimitiveVisualProperty.MixColor, new Dali.Property.Value(new Vector4((245.0f/255.0f), (188.0f/255.0f), (73.0f/255.0f), 1.0f)));
                _primitiveVisual =  VisualFactory.Get().CreateVisual( primitiveVisual );
                RegisterVisual( PrimitiveVisualPropertyIndex, _primitiveVisual );

                // Set the depth index for Primitive visual
                _primitiveVisual.SetDepthIndex(PrimitiveVisualPropertyIndex);
            }
        }

        public override void OnInitialize()
        {
            // Enable Tap gesture on ContactView
            EnableGestureDetection(Gesture.GestureType.Tap);
        }

        public override void OnTap(TapGesture tap)
        {
            // Change the Color visual of ContactView with some random color
            Random random = new Random();
            Color = new Color((random.Next(0, 256) / 255.0f), (random.Next(0, 256) / 255.0f), (random.Next(0, 256) / 255.0f), 1.0f);
        }

        public override void OnRelayout(Vector2 size, RelayoutContainer container)
        {
            // Configure the transform and size of Image visual.
            Dali.Property.Map imageVisualTransform = new Dali.Property.Map();
            imageVisualTransform.Add((int)VisualTransformPropertyType.OFFSET, new Dali.Property.Value(new Vector2(10.0f, 0.0f)))
                .Add((int)VisualTransformPropertyType.OFFSET_POLICY, new Dali.Property.Value(new Vector2((int)VisualTransformPolicyType.ABSOLUTE, (int)VisualTransformPolicyType.ABSOLUTE)))
                .Add((int)VisualTransformPropertyType.SIZE_POLICY, new Dali.Property.Value(new Vector2((int)VisualTransformPolicyType.ABSOLUTE, (int)VisualTransformPolicyType.ABSOLUTE)))
                .Add((int)VisualTransformPropertyType.SIZE, new Dali.Property.Value(new Vector2(40.0f, 40.0f)))
                .Add((int)VisualTransformPropertyType.ORIGIN, new Dali.Property.Value((int)AlignType.CENTER_BEGIN))
                .Add((int)VisualTransformPropertyType.ANCHOR_POINT, new Dali.Property.Value((int)AlignType.CENTER_BEGIN));
            _imageVisual.SetTransformAndSize(imageVisualTransform, size);

            // Configure the transform and size of Text visual.
            Dali.Property.Map textVisualTransform = new Dali.Property.Map();
            textVisualTransform.Add((int)VisualTransformPropertyType.OFFSET, new Dali.Property.Value(new Vector2(0.0f, 0.0f)))
                .Add((int)VisualTransformPropertyType.OFFSET_POLICY, new Dali.Property.Value(new Vector2((int)VisualTransformPolicyType.RELATIVE, (int)VisualTransformPolicyType.RELATIVE)))
                .Add((int)VisualTransformPropertyType.SIZE_POLICY, new Dali.Property.Value(new Vector2((int)VisualTransformPolicyType.ABSOLUTE, (int)VisualTransformPolicyType.ABSOLUTE)))
                .Add((int)VisualTransformPropertyType.SIZE, new Dali.Property.Value(new Vector2(size.X - 100.0f, 50.0f)))
                .Add((int)VisualTransformPropertyType.ORIGIN, new Dali.Property.Value((int)Align.Type.Center))
                .Add((int)VisualTransformPropertyType.ANCHOR_POINT, new Dali.Property.Value((int)Align.Type.Center));
            _textVisual.SetTransformAndSize(textVisualTransform, size);

            // Configure the transform and size of Primitive visual.
            Dali.Property.Map primitiveVisualTransform = new Dali.Property.Map();
            primitiveVisualTransform.Add((int)VisualTransformPropertyType.OFFSET, new Dali.Property.Value(new Vector2(size.X - 60.0f, 0.0f)))
                .Add((int)VisualTransformPropertyType.OFFSET_POLICY, new Dali.Property.Value(new Vector2((int)VisualTransformPolicyType.ABSOLUTE, (int)VisualTransformPolicyType.ABSOLUTE)))
                .Add((int)VisualTransformPropertyType.SIZE_POLICY, new Dali.Property.Value(new Vector2((int)VisualTransformPolicyType.ABSOLUTE, (int)VisualTransformPolicyType.ABSOLUTE)))
                .Add((int)VisualTransformPropertyType.SIZE, new Dali.Property.Value(new Vector2(40.0f, 40.0f)))
                .Add((int)VisualTransformPropertyType.ORIGIN, new Dali.Property.Value((int)AlignType.CENTER_BEGIN))
                .Add((int)VisualTransformPropertyType.ANCHOR_POINT, new Dali.Property.Value((int)AlignType.CENTER_BEGIN));
            _primitiveVisual.SetTransformAndSize(primitiveVisualTransform, size);

            // Configure the transform and size of Color visual. This is also the default value.
            Dali.Property.Map colorVisualTransform = new Dali.Property.Map();
            colorVisualTransform.Add( (int)VisualTransformPropertyType.OFFSET, new Dali.Property.Value(new Vector2(0.0f,0.0f)))
                .Add((int)VisualTransformPropertyType.OFFSET_POLICY, new Dali.Property.Value(new Vector2((int)VisualTransformPolicyType.RELATIVE, (int)VisualTransformPolicyType.RELATIVE)))
                .Add((int)VisualTransformPropertyType.SIZE_POLICY, new Dali.Property.Value(new Vector2((int)VisualTransformPolicyType.RELATIVE, (int)VisualTransformPolicyType.RELATIVE)))
                .Add( (int)VisualTransformPropertyType.SIZE, new Dali.Property.Value(new Vector2(1.0f, 1.0f)) )
                .Add( (int)VisualTransformPropertyType.ORIGIN, new Dali.Property.Value((int)AlignType.TOP_BEGIN) )
                .Add( (int)VisualTransformPropertyType.ANCHOR_POINT, new Dali.Property.Value((int)AlignType.TOP_BEGIN) );
            _colorVisual.SetTransformAndSize(colorVisualTransform, size);
        }
    }
}