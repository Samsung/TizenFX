using System;
using System.Linq;
using System.Reflection;
using System.Globalization;

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
                    return new Vector2(Single.Parse(parts[0].Trim(), CultureInfo.InvariantCulture),
                                       Single.Parse(parts[1].Trim(), CultureInfo.InvariantCulture));
                }
            }

            throw new InvalidOperationException($"Cannot convert \"{value}\" into {typeof(Vector2)}");
        }

        public override string ConvertToString(object value)
        {
            Vector2 vector = (Vector2)value;
            return vector.X.ToString() + " " + vector.Y.ToString();
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
                    return new Vector3(Single.Parse(parts[0].Trim(), CultureInfo.InvariantCulture),
                                       Single.Parse(parts[1].Trim(), CultureInfo.InvariantCulture),
                                       Single.Parse(parts[2].Trim(), CultureInfo.InvariantCulture));
                }
            }

            throw new InvalidOperationException($"Cannot convert \"{value}\" into {typeof(Vector3)}");
        }

        public override string ConvertToString(object value)
        {
            Vector3 vector = (Vector3)value;
            return vector.X.ToString() + " " + vector.Y.ToString() + " " + vector.Z.ToString();
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
                    return new Vector4(Single.Parse(parts[0].Trim(), CultureInfo.InvariantCulture),
                                       Single.Parse(parts[1].Trim(), CultureInfo.InvariantCulture),
                                       Single.Parse(parts[2].Trim(), CultureInfo.InvariantCulture),
                                       Single.Parse(parts[3].Trim(), CultureInfo.InvariantCulture));
                }
            }

            throw new InvalidOperationException($"Cannot convert \"{value}\" into {typeof(Vector4)}");
        }

        public override string ConvertToString(object value)
        {
            Vector4 vector = (Vector4)value;
            return vector.X.ToString() + " " + vector.Y.ToString() + " " + vector.Z.ToString() + " " + vector.W.ToString();
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
                    return new RelativeVector2(Single.Parse(parts[0].Trim(), CultureInfo.InvariantCulture),
                                               Single.Parse(parts[1].Trim(), CultureInfo.InvariantCulture));
                }
            }

            throw new InvalidOperationException($"Cannot convert \"{value}\" into {typeof(RelativeVector2)}");
        }

        public override string ConvertToString(object value)
        {
            RelativeVector2 vector = (RelativeVector2)value;
            return vector.X.ToString() + " " + vector.Y.ToString();
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
                    return new RelativeVector3(Single.Parse(parts[0].Trim(), CultureInfo.InvariantCulture),
                                               Single.Parse(parts[1].Trim(), CultureInfo.InvariantCulture),
                                               Single.Parse(parts[2].Trim(), CultureInfo.InvariantCulture));
                }
            }

            throw new InvalidOperationException($"Cannot convert \"{value}\" into {typeof(RelativeVector3)}");
        }

        public override string ConvertToString(object value)
        {
            RelativeVector3 vector = (RelativeVector3)value;
            return vector.X.ToString() + " " + vector.Y.ToString() + " " + vector.Z.ToString();
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
                    return new RelativeVector4(Single.Parse(parts[0].Trim(), CultureInfo.InvariantCulture),
                                               Single.Parse(parts[1].Trim(), CultureInfo.InvariantCulture),
                                               Single.Parse(parts[2].Trim(), CultureInfo.InvariantCulture),
                                               Single.Parse(parts[3].Trim(), CultureInfo.InvariantCulture));
                }
            }

            throw new InvalidOperationException($"Cannot convert \"{value}\" into {typeof(RelativeVector4)}");
        }

        public override string ConvertToString(object value)
        {
            RelativeVector4 vector = (RelativeVector4)value;
            return vector.X.ToString() + " " + vector.Y.ToString() + " " + vector.Z.ToString() + " " + vector.W.ToString(); ;
        }
    }
}
