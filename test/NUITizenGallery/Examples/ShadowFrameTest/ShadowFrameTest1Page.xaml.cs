/*
 * Copyright(c) 2025 Samsung Electronics Co., Ltd.
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

namespace NUITizenGallery
{
    public partial class ShadowFrameTest1Page : ContentPage
    {
        private bool shadowToggleShow; // true if we show shadow

        private ColorVisualCutoutPolicyType shadowCutoutPolicy; // The policy of cutout shadow as view

        private Shadow CreateShadowFromeSliders()
        {
            return new Shadow
            (
                ShadowBlurRadius.CurrentValue,
                shadowCutoutPolicy,
                new Color(
                    ShadowColorRed.CurrentValue / 255.0f,
                    ShadowColorGreen.CurrentValue / 255.0f,
                    ShadowColorBlue.CurrentValue / 255.0f,
                    ShadowOpacity.CurrentValue / 255.0f),
                new Vector2(
                    ShadowOffsetX.CurrentValue,
                    ShadowOffsetY.CurrentValue)
            );
        }
        public ShadowFrameTest1Page()
        {
            InitializeComponent();
            shadowToggleShow = true;
            shadowCutoutPolicy = ColorVisualCutoutPolicyType.None;

            // CornerRadius
            CornerTopLeft.ValueChanged += (o, e) =>
            {
                Vector4 currentCornerRadius = target.CornerRadius;
                target.CornerRadius = new Vector4(CornerTopLeft.CurrentValue, currentCornerRadius.Y, currentCornerRadius.Z, currentCornerRadius.W);
            };
            CornerTopRight.ValueChanged += (o, e) =>
            {
                Vector4 currentCornerRadius = target.CornerRadius;
                target.CornerRadius = new Vector4(currentCornerRadius.X, CornerTopRight.CurrentValue, currentCornerRadius.Z, currentCornerRadius.W);
            };
            CornerBottomRight.ValueChanged += (o, e) =>
            {
                Vector4 currentCornerRadius = target.CornerRadius;
                target.CornerRadius = new Vector4(currentCornerRadius.X, currentCornerRadius.Y, CornerBottomRight.CurrentValue, currentCornerRadius.W);
            };
            CornerBottomLeft.ValueChanged += (o, e) =>
            {
                Vector4 currentCornerRadius = target.CornerRadius;
                target.CornerRadius = new Vector4(currentCornerRadius.X, currentCornerRadius.Y, currentCornerRadius.Z, CornerBottomLeft.CurrentValue);
            };

            CornerSquareness.ValueChanged += (o, e) =>
            {
                float cornerSquareness = CornerSquareness.CurrentValue;
                target.CornerSquareness = new Vector4(cornerSquareness, cornerSquareness, cornerSquareness, cornerSquareness);
            };

            // Borderline Width/Offset
            BorderlineWidthSlider.ValueChanged += (o, e) =>
            {
                target.BorderlineWidth = BorderlineWidthSlider.CurrentValue;
            };
            BorderlineOffsetSlider.ValueChanged += (o, e) =>
            {
                target.BorderlineOffset = BorderlineOffsetSlider.CurrentValue;
            };

            // Borderline Color
            BorderlineRed.ValueChanged += (o, e) =>
            {
                Color currentColor = target.BorderlineColor;
                target.BorderlineColor = new Color(BorderlineRed.CurrentValue / 255.0f, currentColor.G, currentColor.B, currentColor.A);
            };
            BorderlineGreen.ValueChanged += (o, e) =>
            {
                Color currentColor = target.BorderlineColor;
                target.BorderlineColor = new Color(currentColor.R, BorderlineGreen.CurrentValue / 255.0f, currentColor.B, currentColor.A);
            };
            BorderlineBlue.ValueChanged += (o, e) =>
            {
                Color currentColor = target.BorderlineColor;
                target.BorderlineColor = new Color(currentColor.R, currentColor.G, BorderlineBlue.CurrentValue / 255.0f, currentColor.A);
            };
            BorderlineAlpha.ValueChanged += (o, e) =>
            {
                Color currentColor = target.BorderlineColor;
                target.BorderlineColor = new Color(currentColor.R, currentColor.G, currentColor.B, BorderlineAlpha.CurrentValue / 255.0f);
            };

            // Background Color
            ViewRed.ValueChanged += (o, e) =>
            {
                Color currentColor = target.BackgroundColor;
                target.BackgroundColor = new Color(ViewRed.CurrentValue / 255.0f, currentColor.G, currentColor.B, currentColor.A);
            };
            ViewGreen.ValueChanged += (o, e) =>
            {
                Color currentColor = target.BackgroundColor;
                target.BackgroundColor = new Color(currentColor.R, ViewGreen.CurrentValue / 255.0f, currentColor.B, currentColor.A);
            };
            ViewBlue.ValueChanged += (o, e) =>
            {
                Color currentColor = target.BackgroundColor;
                target.BackgroundColor = new Color(currentColor.R, currentColor.G, ViewBlue.CurrentValue / 255.0f, currentColor.A);
            };
            ViewAlpha.ValueChanged += (o, e) =>
            {
                Color currentColor = target.BackgroundColor;
                target.BackgroundColor = new Color(currentColor.R, currentColor.G, currentColor.B, ViewAlpha.CurrentValue / 255.0f);
            };

            // Shadow Toggle
            ShadowToggleButton.Clicked += (o, e) =>
            {
                if(ShadowToggleButton.IsSelected)
                {
                    shadowToggleShow = true;
                }
                else
                {
                    shadowToggleShow = false;
                }

                if(shadowToggleShow)
                {
                    if(target.BoxShadow == null)
                    {
                        target.BoxShadow = CreateShadowFromeSliders();
                    }
                }
                else
                {
                    if(target.BoxShadow != null)
                    {
                        target.BoxShadow = null;
                    }
                }
            };
            // Shadow Cutout Toggle
            ShadowCutoutButton.Clicked += (o, e) =>
            {
                if(ShadowCutoutButton.IsSelected)
                {
                    shadowCutoutPolicy = ColorVisualCutoutPolicyType.CutoutViewWithCornerRadius;
                }
                else
                {
                    shadowCutoutPolicy = ColorVisualCutoutPolicyType.None;
                }

                target.BoxShadow = CreateShadowFromeSliders();
            };

            // Shadow Offset
            ShadowOffsetX.ValueChanged += (o, e) =>
            {
                if(!shadowToggleShow) return;
                Shadow currentShadow = target.BoxShadow;
                if(currentShadow == null)
                {
                    target.BoxShadow = CreateShadowFromeSliders();
                    return;
                }
                Vector2 currentOffset = currentShadow.Offset;
                target.BoxShadow = new Shadow(currentShadow.BlurRadius, shadowCutoutPolicy, currentShadow.Color, new Vector2(ShadowOffsetX.CurrentValue, currentOffset.Y));
            };
            ShadowOffsetY.ValueChanged += (o, e) =>
            {
                if(!shadowToggleShow) return;
                Shadow currentShadow = target.BoxShadow;
                if(currentShadow == null)
                {
                    target.BoxShadow = CreateShadowFromeSliders();
                    return;
                }
                Vector2 currentOffset = currentShadow.Offset;
                target.BoxShadow = new Shadow(currentShadow.BlurRadius, shadowCutoutPolicy, currentShadow.Color, new Vector2(currentOffset.X, ShadowOffsetY.CurrentValue));
            };

            // Shadow Color
            ShadowColorRed.ValueChanged += (o, e) =>
            {
                if(!shadowToggleShow) return;
                Shadow currentShadow = target.BoxShadow;
                if(currentShadow == null)
                {
                    target.BoxShadow = CreateShadowFromeSliders();
                    return;
                }
                Color currentColor = currentShadow.Color;
                target.BoxShadow = new Shadow(currentShadow.BlurRadius, shadowCutoutPolicy, new Color(ShadowColorRed.CurrentValue / 255.0f, currentColor.G, currentColor.B, currentColor.A), currentShadow.Offset);
            };
            ShadowColorGreen.ValueChanged += (o, e) =>
            {
                if(!shadowToggleShow) return;
                Shadow currentShadow = target.BoxShadow;
                if(currentShadow == null)
                {
                    target.BoxShadow = CreateShadowFromeSliders();
                    return;
                }
                Color currentColor = currentShadow.Color;
                target.BoxShadow = new Shadow(currentShadow.BlurRadius, shadowCutoutPolicy, new Color(currentColor.R, ShadowColorGreen.CurrentValue / 255.0f, currentColor.B, currentColor.A), currentShadow.Offset);
            };
            ShadowColorBlue.ValueChanged += (o, e) =>
            {
                if(!shadowToggleShow) return;
                Shadow currentShadow = target.BoxShadow;
                if(currentShadow == null)
                {
                    target.BoxShadow = CreateShadowFromeSliders();
                    return;
                }
                Color currentColor = currentShadow.Color;
                target.BoxShadow = new Shadow(currentShadow.BlurRadius, shadowCutoutPolicy, new Color(currentColor.R, currentColor.G, ShadowColorBlue.CurrentValue / 255.0f, currentColor.A), currentShadow.Offset);
            };
            ShadowOpacity.ValueChanged += (o, e) =>
            {
                if(!shadowToggleShow) return;
                Shadow currentShadow = target.BoxShadow;
                if(currentShadow == null)
                {
                    target.BoxShadow = CreateShadowFromeSliders();
                    return;
                }
                Color currentColor = currentShadow.Color;
                target.BoxShadow = new Shadow(currentShadow.BlurRadius, shadowCutoutPolicy, new Color(currentColor.R, currentColor.G, currentColor.B, ShadowOpacity.CurrentValue / 255.0f), currentShadow.Offset);
            };
            // Shadow Radius
            ShadowBlurRadius.ValueChanged += (o, e) =>
            {
                if(!shadowToggleShow) return;
                Shadow currentShadow = target.BoxShadow;
                if(currentShadow == null)
                {
                    target.BoxShadow = CreateShadowFromeSliders();
                    return;
                }
                float currentRadius = ShadowBlurRadius.CurrentValue;
                target.BoxShadow = new Shadow(currentRadius, shadowCutoutPolicy, currentShadow.Color, currentShadow.Offset);
            };
        }
    }
}