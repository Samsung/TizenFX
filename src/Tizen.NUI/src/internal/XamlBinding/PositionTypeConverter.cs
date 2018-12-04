using System;
using System.Linq;
using System.Reflection;
using System.Globalization;

using Tizen.NUI;

namespace Tizen.NUI.Binding
{
    internal class PositionTypeConverter : TypeConverter
    {
        public override object ConvertFromInvariantString(string value)
        {
            if (value != null)
            {
                string[] parts = value.Split('.');
                if (parts.Length == 1 || ( parts.Length == 2 && (parts[0].Trim() == "ParentOrigin" || parts[0].Trim() == "PivotPoint") ))
                {
                    string position = parts[parts.Length - 1].Trim();

                    switch(position)
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
                    return new Position(Single.Parse(parts[0].Trim(), CultureInfo.InvariantCulture),
                                    Single.Parse(parts[1].Trim(), CultureInfo.InvariantCulture),
                                    Single.Parse(parts[2].Trim(), CultureInfo.InvariantCulture));
                }
            }

            throw new InvalidOperationException($"Cannot convert \"{value}\" into {typeof(Position)}");
        }
    }

    internal class Position2DTypeConverter : TypeConverter
    {
        public override object ConvertFromInvariantString(string value)
        {
            return Position2D.ConvertFromString(value);
        }
    }
}
