/*
 * Copyright(c) 2021 Samsung Electronics Co., Ltd.
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
using System.Linq;
using System.Reflection;
using System.Globalization;

using Tizen.NUI;
using System.ComponentModel;

namespace Tizen.NUI.Binding
{
    //Internal used, will never open
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class PositionTypeConverter : TypeConverter
    {
        //Internal used, will never open
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override object ConvertFromInvariantString(string value)
        {
            if (value != null)
            {
                string[] parts = value.Split('.');
                if (parts.Length == 1 || (parts.Length == 2 && (parts[0].Trim() == "ParentOrigin" || parts[0].Trim() == "PivotPoint")))
                {
                    string position = parts[parts.Length - 1].Trim();

                    switch (position)
                    {
                        case "Top":
                            return ParentOrigin.Top;
                        case "Bottom":
                            return ParentOrigin.Bottom;
                        case "Left":
                            return ParentOrigin.Left;
                        case "Right":
                            return ParentOrigin.Right;
                        case "Middle":
                            return ParentOrigin.Middle;
                        case "TopLeft":
                            return ParentOrigin.TopLeft;
                        case "TopCenter":
                            return ParentOrigin.TopCenter;
                        case "TopRight":
                            return ParentOrigin.TopRight;
                        case "CenterLeft":
                            return ParentOrigin.CenterLeft;
                        case "Center":
                            return ParentOrigin.Center;
                        case "CenterRight":
                            return ParentOrigin.CenterRight;
                        case "BottomLeft":
                            return ParentOrigin.BottomLeft;
                        case "BottomCenter":
                            return ParentOrigin.BottomCenter;
                        case "BottomRight":
                            return ParentOrigin.BottomRight;
                    }
                }

                parts = value.Split(',');
                if (parts.Length == 3)
                {
                    int x = (int)GraphicsTypeManager.Instance.ConvertScriptToPixel(parts[0].Trim());
                    int y = (int)GraphicsTypeManager.Instance.ConvertScriptToPixel(parts[1].Trim());
                    int z = (int)GraphicsTypeManager.Instance.ConvertScriptToPixel(parts[2].Trim());
                    return new Position(x, y, z);
                }
                else if (parts.Length == 2)
                {
                    int x = (int)GraphicsTypeManager.Instance.ConvertScriptToPixel(parts[0].Trim());
                    int y = (int)GraphicsTypeManager.Instance.ConvertScriptToPixel(parts[1].Trim());
                    return new Position(x, y);
                }
            }

            throw new InvalidOperationException($"Cannot convert \"{value}\" into {typeof(Position)}");
        }

        //Internal used, will never open
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override string ConvertToString(object value)
        {
            Position position = value as Position;
            if (null != position)
            {
                return position.X.ToString() + " " + position.Y.ToString() + " " + position.Z.ToString();
            }
            else
            {
                return null;
            }
        }
    }

    //Internal used, will never open
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class Position2DTypeConverter : TypeConverter
    {
        //Internal used, will never open
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override object ConvertFromInvariantString(string value)
        {
            return Position2D.ConvertFromString(value);
        }

        //Internal used, will never open
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override string ConvertToString(object value)
        {
            Position2D position = value as Position2D;
            if (null != position)
            {
                return position.X.ToString() + " " + position.Y.ToString();
            }
            else
            {
                return null;
            }
        }
    }
}
