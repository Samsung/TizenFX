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
public class ImageVisual : VisualBase
{
    private VisualBase _imageVisual;
    private Property.Map _imageProperty;
    private string _imageUrl;
    private string _fittingMode;
    private string _samplingMode;
    private int _desiredWidth;
    private int _desiredHeight;
    private bool _synchronousLoading;
    private bool _borderOnly;
    private Vector4 _pixelArea;
    private string _wrapModeU;
    private string _wrapModeV;

    private Vector2 _imageVisualSize;
    private Vector2 _imageVisualPosition;
    private Vector4 _offsetSizeMode;
    private Vector2 _parentSize;
    private Tizen.NUI.AlignType _origin;
    private Tizen.NUI.AlignType _anchorPoint;

    public ImageVisual() : base()
    {
        //Initial the default transform map.
        _offsetSizeMode = new Vector4( 1.0f, 1.0f, 1.0f, 1.0f ); //absolute
        _origin = AlignType.TOP_BEGIN;
        _anchorPoint = AlignType.TOP_BEGIN;

        //Initial the image property map.
        _imageProperty = new Property.Map();
        _imageProperty.Insert( NDalic.VISUAL_PROPERTY_TYPE, new Property.Value( (int)VisualType.IMAGE ) );
    }

    public ImageVisual(string imageUrl)
    {
        //Initial the default transform map.
        _offsetSizeMode = new Vector4( 1.0f, 1.0f, 1.0f, 1.0f ); //absolute
        _origin = AlignType.TOP_BEGIN;
        _anchorPoint = AlignType.TOP_BEGIN;

        //Initial the image property map.
        _imageUrl = imageUrl;
        _imageProperty = new Property.Map();
        _imageProperty.Insert( NDalic.VISUAL_PROPERTY_TYPE, new Property.Value( (int)VisualType.IMAGE ) );
        _imageProperty.Insert( NDalic.IMAGE_VISUAL_URL, new Property.Value( _imageUrl ) );
    }

    public string Url
    {
        get
        {
            return _imageUrl;
        }
        set
        {
            _imageUrl = value;
            _imageProperty.Insert( NDalic.IMAGE_VISUAL_URL, new Property.Value( _imageUrl ) );
        }
    }

    public string FittingMode
    {
        get
        {
            return _fittingMode;
        }
        set
        {
            _fittingMode = value;
            _imageProperty.Insert( NDalic.IMAGE_VISUAL_FITTING_MODE, new Property.Value( _fittingMode ) );
        }
    }

    public string SamplingMode
    {
        get
        {
            return _samplingMode;
        }
        set
        {
            _samplingMode = value;
            _imageProperty.Insert( NDalic.IMAGE_VISUAL_SAMPLING_MODE, new Property.Value( _samplingMode ) );
        }
    }

    public int DesiredWidth
    {
        get
        {
            return _desiredWidth;
        }
        set
        {
            _desiredWidth = value;
            _imageProperty.Insert( NDalic.IMAGE_VISUAL_DESIRED_WIDTH, new Property.Value( _desiredWidth ) );
        }
    }

    public int DesiredHeight
    {
        get
        {
            return _desiredHeight;
        }
        set
        {
            _desiredHeight = value;
            _imageProperty.Insert( NDalic.IMAGE_VISUAL_DESIRED_HEIGHT, new Property.Value( _desiredHeight ) );
        }
    }

    public bool SynchronousLoading
    {
        get
        {
            return _synchronousLoading;
        }
        set
        {
            _synchronousLoading = value;
            _imageProperty.Insert( NDalic.IMAGE_VISUAL_SYNCHRONOUS_LOADING, new Property.Value( _synchronousLoading ) );
        }
    }

    public bool BorderOnly
    {
        get
        {
            return _borderOnly;
        }
        set
        {
            _borderOnly = value;
             _imageProperty.Insert( NDalic.IMAGE_VISUAL_BORDER_ONLY, new Property.Value( _borderOnly ) );
        }
    }

    public Vector4 PixelArea
    {
        get
        {
            return _pixelArea;
        }
        set
        {
            _pixelArea = value;
             _imageProperty.Insert( NDalic.IMAGE_VISUAL_PIXEL_AREA, new Property.Value( _pixelArea ) );
        }
    }

    public string WrapModeU
    {
        get
        {
            return _wrapModeU;
        }
        set
        {
            _wrapModeU = value;
             _imageProperty.Insert( NDalic.IMAGE_VISUAL_WRAP_MODE_U, new Property.Value( _wrapModeU ) );
        }
    }

    public string WrapModeV
    {
        get
        {
            return _wrapModeV;
        }
        set
        {
            _wrapModeV = value;
             _imageProperty.Insert( NDalic.IMAGE_VISUAL_WRAP_MODE_V, new Property.Value( _wrapModeV ) );
        }
    }

    public Vector2 Size
    {
        get
        {
            return _imageVisualSize;
        }
        set
        {
            _imageVisualSize = value;
        }
    }

    public Vector2 Position
    {
        get
        {
            return _imageVisualPosition;
        }
        set
        {
            _imageVisualPosition = value;
        }
    }

    public Vector4 OffsetSizeMode
    {
        get
        {
            return _offsetSizeMode;
        }
        set
        {
            _offsetSizeMode = value;
        }
    }

    public Vector2 ParentSize
    {
        get
        {
            return _parentSize;
        }
        set
        {
            _parentSize = value;
        }
    }

    public AlignType Origin
    {
        get
        {
            return _origin;
        }
        set
        {
            _origin = value;
        }
    }

    public AlignType AnchorPoint
    {
        get
        {
            return _anchorPoint;
        }
        set
        {
            _anchorPoint = value;
        }
    }

    public void Instantiate()
    {
        //
        _imageVisual = VisualFactory.Get().CreateVisual( _imageProperty );

        Property.Map imageVisualTransform = new Property.Map();
        imageVisualTransform.Add( (int)VisualTransformPropertyType.SIZE, new Property.Value(_imageVisualSize) );
        imageVisualTransform.Add( (int)VisualTransformPropertyType.OFFSET, new Property.Value(_imageVisualPosition) );
        imageVisualTransform.Add( (int)VisualTransformPropertyType.OFFSET_SIZE_MODE, new Property.Value(_offsetSizeMode) );
        imageVisualTransform.Add( (int)VisualTransformPropertyType.ORIGIN, new Property.Value((int)_origin) );
        imageVisualTransform.Add( (int)VisualTransformPropertyType.ANCHOR_POINT, new Property.Value((int)_anchorPoint) );
        _imageVisual.SetTransformAndSize( imageVisualTransform, _parentSize );
    }
}
}