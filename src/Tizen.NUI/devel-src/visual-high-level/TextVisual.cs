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
using System.Collections.Generic;
using System.Linq;
using Tizen.NUI;

namespace Tizen.NUI
{
    public class TextVisual : VisualCommon
    {
        private VisualBase _textVisual;
        private Property.Map _textProperty;
        private string _text;
        private string _fontFamily;
        //private Property.Map _fontStyle;
        private string _fontStyle;
        private float _pointSize;
        private bool _multiLine;
        private string _horizontalAlignment;
        private string _verticalAlignment;
        private Vector4 _textColor;
        private bool _enableMarkup;

        private Vector2 _imageVisualSize;
        private Vector2 _imageVisualPosition;
        private Vector4 _offsetSizeMode;
        private Vector2 _parentSize;
        private Tizen.NUI.AlignType _origin;
        private Tizen.NUI.AlignType _anchorPoint;

        public TextVisual() : base()
        {
            //Initial the default transform map.
            _offsetSizeMode = new Vector4(1.0f, 1.0f, 1.0f, 1.0f); //absolute
            _origin = AlignType.TOP_BEGIN;
            _anchorPoint = AlignType.TOP_BEGIN;

            //Initial the image property map.
            _textProperty = new Property.Map();
            _textProperty.Insert(NDalic.VISUAL_PROPERTY_TYPE, new Property.Value((int)VisualType.TEXT));
        }

        public TextVisual(string text)
        {
            //Initial the default transform map.
            _offsetSizeMode = new Vector4(1.0f, 1.0f, 1.0f, 1.0f); //absolute
            _origin = AlignType.TOP_BEGIN;
            _anchorPoint = AlignType.TOP_BEGIN;

            //Initial the image property map.
            _text = text;
            _textProperty = new Property.Map();
            _textProperty.Insert(NDalic.VISUAL_PROPERTY_TYPE, new Property.Value((int)VisualType.TEXT));
            _textProperty.Insert(NDalic.TEXT_VISUAL_TEXT, new Property.Value(_text));
        }

        public string Text
        {
            get
            {
                return _text;
            }
            set
            {
                _text = value;
                _textProperty.Insert(NDalic.TEXT_VISUAL_TEXT, new Property.Value(_text));
            }
        }

        public string FontFamily
        {
            get
            {
                return _fontFamily;
            }
            set
            {
                _fontFamily = value;
                _textProperty.Insert(NDalic.IMAGE_VISUAL_FITTING_MODE, new Property.Value(_fontFamily));
            }
        }

        public string FontStyle
        {
            get
            {
                return _fontStyle;
            }
            set
            {
                _fontStyle = value;
                _textProperty.Insert(NDalic.IMAGE_VISUAL_SAMPLING_MODE, new Property.Value(_fontStyle));
            }
        }

        public float PointSize
        {
            get
            {
                return _pointSize;
            }
            set
            {
                _pointSize = value;
                _textProperty.Insert(NDalic.IMAGE_VISUAL_DESIRED_WIDTH, new Property.Value(_pointSize));
            }
        }

        public bool MultiLine
        {
            get
            {
                return _multiLine;
            }
            set
            {
                _multiLine = value;
                _textProperty.Insert(NDalic.IMAGE_VISUAL_DESIRED_HEIGHT, new Property.Value(_multiLine));
            }
        }

        public string HorizontalAlignment
        {
            get
            {
                return _horizontalAlignment;
            }
            set
            {
                _horizontalAlignment = value;
                _textProperty.Insert(NDalic.IMAGE_VISUAL_SYNCHRONOUS_LOADING, new Property.Value(_horizontalAlignment));
            }
        }

        public string VerticalAlignment
        {
            get
            {
                return _verticalAlignment;
            }
            set
            {
                _verticalAlignment = value;
                _textProperty.Insert(NDalic.IMAGE_VISUAL_BORDER_ONLY, new Property.Value(_verticalAlignment));
            }
        }

        public Vector4 TextColor
        {
            get
            {
                return _textColor;
            }
            set
            {
                _textColor = value;
                _textProperty.Insert(NDalic.IMAGE_VISUAL_PIXEL_AREA, new Property.Value(_textColor));
            }
        }

        public bool EnableMarkup
        {
            get
            {
                return _enableMarkup;
            }
            set
            {
                _enableMarkup = value;
                _textProperty.Insert(NDalic.IMAGE_VISUAL_WRAP_MODE_U, new Property.Value(_enableMarkup));
            }
        }



        public void Instantiate()
        {
            //
            _textVisual = VisualFactory.Get().CreateVisual(_textProperty);

            Property.Map imageVisualTransform = new Property.Map();
            imageVisualTransform.Add((int)VisualTransformPropertyType.SIZE, new Property.Value(_imageVisualSize));
            imageVisualTransform.Add((int)VisualTransformPropertyType.OFFSET, new Property.Value(_imageVisualPosition));
            imageVisualTransform.Add((int)VisualTransformPropertyType.OFFSET_SIZE_MODE, new Property.Value(_offsetSizeMode));
            imageVisualTransform.Add((int)VisualTransformPropertyType.ORIGIN, new Property.Value((int)_origin));
            imageVisualTransform.Add((int)VisualTransformPropertyType.ANCHOR_POINT, new Property.Value((int)_anchorPoint));
            _textVisual.SetTransformAndSize(imageVisualTransform, _parentSize);
        }
    }
}