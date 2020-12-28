using System;
using System.Globalization;

namespace Tizen.NUI.Binding
{
    internal class RotationTypeConverter : TypeConverter
    {
        public override object ConvertFromInvariantString(string value)
        {
            // public Rotation(Radian radian(float), Vector3 vector3)
            // Default: <View Orientation="45.0,12,13,0" />
            // Oritation="D:23, 0, 0, 1"
            // Oritation="R:23, 0, 0, 1"
            if (value != null)
            {
                string[] parts = value.Split(',');
                if (parts.Length == 4)
                {
                    bool useDefault = true;
                    Radian radian = null;
                    string[] head = parts[0].Trim().Split(':');
                    if (head.Length == 2)
                    {
                        useDefault = false;
                        string radianOrDegree = head[0].Trim().ToUpperInvariant();
                        if (radianOrDegree == "D" || radianOrDegree == "DEGREE")
                        {
                            // Oritation="D:23, 0, 0, 1"
                            radian = new Radian(new Degree(Single.Parse(head[1].Trim(), CultureInfo.InvariantCulture)));
                        }
                        else if (radianOrDegree == "R" || radianOrDegree == "RADIAN")
                        {
                            // Oritation="R:23, 0, 0, 1"
                            radian = new Radian(Single.Parse(head[1].Trim(), CultureInfo.InvariantCulture));
                        }
                        else
                        {
                            throw new InvalidOperationException($"Cannot convert the first parameter \"{value}\" into Radian of {typeof(Rotation)}");
                        }
                    }

                    if (useDefault)
                    {
                        // Default: <View Orientation="45.0,12,13,0" />
                        radian = new Radian(Single.Parse(parts[0].Trim(), CultureInfo.InvariantCulture));
                    }

                    Vector3 vector3 = new Vector3(Single.Parse(parts[1].Trim(), CultureInfo.InvariantCulture),
                                                  Single.Parse(parts[2].Trim(), CultureInfo.InvariantCulture),
                                                  Single.Parse(parts[3].Trim(), CultureInfo.InvariantCulture));
                    return new Rotation(radian, vector3);
                }
            }

            throw new InvalidOperationException($"Cannot convert \"{value}\" into {typeof(Rotation)}");
        }

        public override string ConvertToString(object value)
        {
            Rotation rotation = (Rotation)value;
            return rotation.ToString();
        }
    }
}
