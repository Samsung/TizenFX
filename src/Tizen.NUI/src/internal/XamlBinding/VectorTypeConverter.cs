using System;
using System.Linq;
using System.Reflection;

using Tizen.NUI;

namespace Tizen.NUI.Binding
{
    internal class Vector2TypeConverter : TypeConverter
    {
        public override object ConvertFromInvariantString(string value)
        {
            if (value != null)
            {
                string[] parts = value.Split(',');
                if (parts.Length == 2 )
                {
                    return new Vector2(float.Parse(parts[0].Trim()), float.Parse(parts[1].Trim()));
                }
            }

            throw new InvalidOperationException($"Cannot convert \"{value}\" into {typeof(Vector2)}");
        }
    }

    internal class Vector3TypeConverter : TypeConverter
    {
        public override object ConvertFromInvariantString(string value)
        {
            if (value != null)
            {
                string[] parts = value.Split(',');
                if (parts.Length == 3 )
                {
                    return new Vector3(float.Parse(parts[0].Trim()), float.Parse(parts[1].Trim()), float.Parse(parts[2].Trim()));
                }
            }

            throw new InvalidOperationException($"Cannot convert \"{value}\" into {typeof(Vector3)}");
        }
    }

    internal class Vector4TypeConverter : TypeConverter
    {
        public override object ConvertFromInvariantString(string value)
        {
            if (value != null)
            {
                string[] parts = value.Split(',');
                if (parts.Length == 4 )
                {
                    return new Vector4(float.Parse(parts[0].Trim()), float.Parse(parts[1].Trim()), float.Parse(parts[2].Trim()), float.Parse(parts[3].Trim()));
                }
            }

            throw new InvalidOperationException($"Cannot convert \"{value}\" into {typeof(Vector4)}");
        }
    }

    internal class RelativeVector2TypeConverter : TypeConverter
    {
        public override object ConvertFromInvariantString(string value)
        {
            if (value != null)
            {
                string[] parts = value.Split(',');
                if (parts.Length == 2 )
                {
                    return new RelativeVector2(float.Parse(parts[0].Trim()), float.Parse(parts[1].Trim()));
                }
            }

            throw new InvalidOperationException("Cannot convert \"{value}\" into {typeof(RelativeVector2)}");
        }
    }

    internal class RelativeVector3TypeConverter : TypeConverter
    {
        public override object ConvertFromInvariantString(string value)
        {
            if (value != null)
            {
                string[] parts = value.Split(',');
                if (parts.Length == 3 )
                {
                    return new RelativeVector3(float.Parse(parts[0].Trim()), float.Parse(parts[1].Trim()), float.Parse(parts[2].Trim()));
                }
            }

            throw new InvalidOperationException($"Cannot convert \"{value}\" into {typeof(RelativeVector3)}");
        }
    }

    internal class RelativeVector4TypeConverter : TypeConverter
    {
        public override object ConvertFromInvariantString(string value)
        {
            if (value != null)
            {
                string[] parts = value.Split(',');
                if (parts.Length == 4 )
                {
                    return new RelativeVector4(float.Parse(parts[0].Trim()), float.Parse(parts[1].Trim()), float.Parse(parts[2].Trim()), float.Parse(parts[3].Trim()));
                }
            }

            throw new InvalidOperationException($"Cannot convert \"{value}\" into {typeof(RelativeVector4)}");
        }
    }
}
