using System.Drawing;
using System.Threading;
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

using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents.VectorGraphics;

namespace NUITizenGallery
{
    public partial class VectorGraphicsCanvasViewTest6Page : ContentPage
    {
        
        public const int NumberOfPictures = 6;
        private readonly string ResourcePath = Tizen.Applications.Application.Current.DirectoryInfo.Resource + "/images/";
        public static readonly string[] Files = { "cartman.svg", "duke.svg", "test.tvg", "b.jpg", "Boston.png", "tiger.svg" };


        Picture[] mPicture = new Picture[NumberOfPictures];
        DrawableGroup mDrawableGroup;
        public int mPictureCount = NumberOfPictures;
        
        public VectorGraphicsCanvasViewTest6Page()
        {
            InitializeComponent();
            mDrawableGroup = new DrawableGroup();
            canvasView.AddDrawable(mDrawableGroup);

            for(int i = 0; i < NumberOfPictures; i++)
            {
                mPicture[i] = new Picture();
                mPicture[i].Load(ResourcePath + Files[i]);
                mPicture[i].SetSize(new Size2D(200, 150));
                mPicture[i].Translate(20 + (i % 2) * 220, 20 + (i / 2) * 170);

                mDrawableGroup.AddDrawable(mPicture[i]);
            }

            addButton.Clicked += (s, e) =>
            {
                if (mPictureCount < NumberOfPictures)
                {
                    mPicture[mPictureCount] = new Picture();
                    mPicture[mPictureCount].Load(ResourcePath + Files[mPictureCount]);
                    mPicture[mPictureCount].SetSize(new Size2D(200, 120));
                    mPicture[mPictureCount].Translate(20 + (mPictureCount % 2) * 220, 20 + (mPictureCount / 2) * 170);

                    mDrawableGroup.AddDrawable(mPicture[mPictureCount]);
                    mPictureCount++;
                }
            };
            delButton.Clicked += (s, e) =>
            {
                if (mPictureCount > 0)
                {
                    mDrawableGroup.RemoveDrawable(mPicture[mPictureCount - 1]);
                    mPictureCount--;
                }
            };
            opacityIncreaseButton.Clicked += (s, e) =>
            {
                if (mDrawableGroup.Opacity + 0.1f > 1.0f)
                {
                    mDrawableGroup.Opacity = 1.0f;
                }
                else
                {
                    mDrawableGroup.Opacity += 0.1f;
                }
            };
            opacityDecreaseButton.Clicked += (s, e) =>
            {
                if (mDrawableGroup.Opacity - 0.1f < 0.0f)
                {
                    mDrawableGroup.Opacity = 0.0f;
                }
                else
                {
                    mDrawableGroup.Opacity -= 0.1f;
                }
            };
        }
    }
}
