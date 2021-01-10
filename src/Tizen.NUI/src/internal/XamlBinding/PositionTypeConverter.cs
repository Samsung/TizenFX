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

        public override string ConvertToString(object value)
        {
            Position position = (Position)value;
            return position.X.ToString() + " " + position.Y.ToString() + " " + position.Z.ToString();
        }
    }

    internal class Position2DTypeConverter : TypeConverter
    {
        public override object ConvertFromInvariantString(string value)
        {
            return Position2D.ConvertFromString(value);
        }

        public override string ConvertToString(object value)
        {
            Position2D position = (Position2D)value;
            return position.X.ToString() + " " + position.Y.ToString();
        }
    }
}
