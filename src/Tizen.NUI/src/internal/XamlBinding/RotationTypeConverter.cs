using System;
using System.Linq;
using System.Reflection;

using Tizen.NUI;

namespace Tizen.NUI.Binding
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
                    Radian radian = new Radian(float.Parse(parts[0].Trim()));
                    Vector3 vector3 = new Vector3( float.Parse(parts[1].Trim()), float.Parse(parts[2].Trim()), float.Parse(parts[3].Trim()) );
                    //Ex: <View Orientation="45.0,12,13,0" />
                    // public Rotation(Radian radian(float), Vector3 vector3)
                    return new Rotation( radian, vector3 );
                }
            }

            throw new InvalidOperationException($"Cannot convert \"{value}\" into {typeof(Rotation)}");
        }
    }
}
