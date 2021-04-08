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
using System.ComponentModel;
using System.Globalization;

namespace Tizen.NUI.Binding
{
    //Internal used, will never open
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class RotationTypeConverter : TypeConverter
    {
        //Internal used, will never open
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override object ConvertFromInvariantString(string value)
        {
            // public Rotation(Radian radian(float), Vector3 vector3)
            // Default: <View Orientation="45.0,12,13,0" />
            // Orientation="D:23, 0, 0, 1"
            // Orientation="R:23, 0, 0, 1"
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
                            // Orientation="D:23, 0, 0, 1"
                            var degree = new Degree(Single.Parse(head[1].Trim(), CultureInfo.InvariantCulture));
                            radian = new Radian(degree);
                            degree.Dispose();
                        }
                        else if (radianOrDegree == "R" || radianOrDegree == "RADIAN")
                        {
                            // Orientation="R:23, 0, 0, 1"
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
                    var ret = new Rotation(radian, vector3);
                    radian?.Dispose();
                    vector3.Dispose();
                    return ret;
                }
            }

            throw new InvalidOperationException($"Cannot convert \"{value}\" into {typeof(Rotation)}");
        }

        //Internal used, will never open
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override string ConvertToString(object value)
        {
            Rotation rotation = value as Rotation;
            return rotation?.ToString();
        }
    }
}
