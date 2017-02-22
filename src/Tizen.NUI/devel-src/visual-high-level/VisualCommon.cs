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
public class VisualCommon : VisualBase
{
    private Vector2 _visualSize;
    private Vector2 _visualPosition;
    private Vector4 _visualOffsetSizeMode;
    private Vector2 _visualParentSize;
    private AlignType _visualOrigin;
    private AlignType _visualAnchorPoint;

    public VisualCommon()
    {
        //
    }

    public Vector2 Size
    {
        get
        {
            return _visualSize;
        }
        set
        {
            _visualSize = value;
        }
    }

    public Vector2 Position
    {
        get
        {
            return _visualPosition;
        }
        set
        {
            _visualPosition = value;
        }
    }

    public Vector4 OffsetSizeMode
    {
        get
        {
            return _visualOffsetSizeMode;
        }
        set
        {
            _visualOffsetSizeMode = value;
        }
    }

    public Vector2 ParentSize
    {
        get
        {
            return _visualParentSize;
        }
        set
        {
            _visualParentSize = value;
        }
    }

    public AlignType Origin
    {
        get
        {
            return _visualOrigin;
        }
        set
        {
            _visualOrigin = value;
        }
    }

    public AlignType AnchorPoint
    {
        get
        {
            return _visualAnchorPoint;
        }
        set
        {
            _visualAnchorPoint = value;
        }
    }

}

    public enum AlignType
    {
            TOP_BEGIN = 0,
            TOP_CENTER,
            TOP_END,
            CENTER_BEGIN,
            CENTER,
            CENTER_END,
            BOTTOM_BEGIN,
            BOTTOM_CENTER,
            BOTTOM_END
        }

}