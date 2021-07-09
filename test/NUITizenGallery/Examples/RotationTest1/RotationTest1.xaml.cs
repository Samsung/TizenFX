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
using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;

namespace NUITizenGallery
{
    public partial class RotationTest1Page : View
    {
        private readonly string ResourcePath = Tizen.Applications.Application.Current.DirectoryInfo.Resource + "/images/";
        public RotationTest1Page()
        {
            InitializeComponent();
            img.SetImage(ResourcePath + "a.jpg");

            int count = 0;
            btn.Clicked += (o, e) =>
            {
                count++;
                if (count == 1)
                {
                    btn.Orientation = new Rotation(new Radian(new Degree(45.0f)), Vector3.ZAxis);
                }
                else if (count == 2)
                {
                    btn.Orientation = new Rotation(new Radian(new Degree(-45.0f)), Vector3.ZAxis);
                    btn.Orientation = new Rotation(new Radian(new Degree(45.0f)), Vector3.XAxis);
                }
                else if (count == 3)
                {
                    btn.Orientation = new Rotation(new Radian(new Degree(0.0f)), Vector3.ZAxis);
                    btn.Orientation = new Rotation(new Radian(new Degree(-45.0f)), Vector3.XAxis);
                    btn.Orientation = new Rotation(new Radian(new Degree(45.0f)), Vector3.YAxis);
                }
                else if (count == 4)
                {
                    btn.Orientation = new Rotation(new Radian(new Degree(45.0f)), Vector3.ZAxis);
                    btn.Orientation = new Rotation(new Radian(new Degree(45.0f)), Vector3.XAxis);
                    btn.Orientation = new Rotation(new Radian(new Degree(0.0f)), Vector3.YAxis);
                }
                else
                {
                    btn.Orientation = new Rotation(new Radian(new Degree(-45.0f)), Vector3.ZAxis);
                    btn.Orientation = new Rotation(new Radian(new Degree(-45.0f)), Vector3.XAxis);
                    btn.Orientation = new Rotation(new Radian(new Degree(-45.0f)), Vector3.YAxis);
                    count = 0;
                }
            };
            sliderX.ValueChanged += (s, e) =>
            {
                btn.Orientation = new Rotation(new Radian(new Degree(sliderX.CurrentValue)), Vector3.XAxis);
                rect.Orientation = new Rotation(new Radian(new Degree(sliderX.CurrentValue)), Vector3.XAxis);
                img.Orientation = new Rotation(new Radian(new Degree(sliderX.CurrentValue)), Vector3.XAxis);
                label.Orientation = new Rotation(new Radian(new Degree(sliderX.CurrentValue)), Vector3.XAxis);
            };
            sliderY.ValueChanged += (s, e) =>
            {
                btn.Orientation = new Rotation(new Radian(new Degree(sliderY.CurrentValue)), Vector3.YAxis);
                rect.Orientation = new Rotation(new Radian(new Degree(sliderY.CurrentValue)), Vector3.YAxis);
                img.Orientation = new Rotation(new Radian(new Degree(sliderY.CurrentValue)), Vector3.YAxis);
                label.Orientation = new Rotation(new Radian(new Degree(sliderY.CurrentValue)), Vector3.YAxis);
            };
            sliderZ.ValueChanged += (s, e) =>
            {
                btn.Orientation = new Rotation(new Radian(new Degree(sliderZ.CurrentValue)), Vector3.ZAxis);
                rect.Orientation = new Rotation(new Radian(new Degree(sliderZ.CurrentValue)), Vector3.ZAxis);
                img.Orientation = new Rotation(new Radian(new Degree(sliderZ.CurrentValue)), Vector3.ZAxis);
                label.Orientation = new Rotation(new Radian(new Degree(sliderZ.CurrentValue)), Vector3.ZAxis);
            };
        }
    }
}