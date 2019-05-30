using System;
using System.Globalization;
using Tizen.NUI;

namespace Tizen.NUI.XamlBinding
{
    internal class RotationTypeConverter : TypeConverter
    {
        public override object ConvertFromInvariantString(string value)
        {
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
                        string radianOrDegree = head[0].Trim().ToLowerInvariant();
                        if(radianOrDegree == "d" || radianOrDegree == "degree")
                        {
                            radian = new Radian( new Degree( Single.Parse( head[1].Trim(), CultureInfo.InvariantCulture ) ) );
                        }
                        else if (radianOrDegree == "r" || radianOrDegree == "radian")
                        {
                            radian = new Radian( Single.Parse( head[1].Trim(), CultureInfo.InvariantCulture ) );
                        }
                        else
                        {
                            throw new InvalidOperationException($"Cannot convert the first parameter \"{value}\" into Radian of {typeof(Rotation)}");
                        }
                    }

                    if (useDefault)
                    {
                        radian = new Radian( Single.Parse( parts[0].Trim(), CultureInfo.InvariantCulture ) );
                    }

                    Vector3 vector3 = new Vector3(Single.Parse(parts[1].Trim(), CultureInfo.InvariantCulture),
                                                  Single.Parse(parts[2].Trim(), CultureInfo.InvariantCulture),
                                                  Single.Parse(parts[3].Trim(), CultureInfo.InvariantCulture));
                    return new Rotation(radian, vector3);
                }
            }

            throw new InvalidOperationException($"Cannot convert \"{value}\" into {typeof(Rotation)}");
        }
    }
}
