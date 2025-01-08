/*
 * Copyright(c) 2019-2022 Samsung Electronics Co., Ltd.
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

namespace Tizen.NUI.BaseComponents
{
    public partial class View
    {
        /// NOTE This can replace SetBackgroundColor(NUI.Color) after sufficient verification
        internal void SetBackgroundColor(L.Color color)
        {
            themeData?.selectorData?.ClearBackground(this);

            // Background property will be Color after now. Remove background image url information.
            backgroundImageUrl = null;

            if (backgroundExtraData == null)
            {
                Object.InternalSetPropertyColor(SwigCPtr, Property.BACKGROUND, color);
            }
            else
            {
                using var map = new PropertyMap()
                    .Append(Visual.Property.Type, (int)Visual.Type.Color)
                    .Append(ColorVisualProperty.MixColor, color)
                    .Append(Visual.Property.CornerRadius, backgroundExtraData.CornerRadius)
                    .Append(Visual.Property.CornerSquareness, backgroundExtraData.CornerSquareness)
                    .Append(Visual.Property.CornerRadiusPolicy, (int)backgroundExtraData.CornerRadiusPolicy)
                    .Append(Visual.Property.BorderlineWidth, backgroundExtraData.BorderlineWidth)
                    .Append(Visual.Property.BorderlineColor, backgroundExtraData.BorderlineColor ?? Color.Black)
                    .Append(Visual.Property.BorderlineOffset, backgroundExtraData.BorderlineOffset);

                backgroundExtraDataUpdatedFlag &= ~BackgroundExtraDataUpdatedFlag.Background;

                Object.InternalSetPropertyMap(SwigCPtr, Property.BACKGROUND, map.SwigCPtr);
            }
        }

        /// NOTE This can replace SetInternalBoxShadowProperty() after sufficient verification
        internal void SetBoxShadow(L.Shadow shadow)
        {
            themeData?.selectorData?.ClearShadow(this);

            backgroundExtraDataUpdatedFlag &= ~BackgroundExtraDataUpdatedFlag.Shadow;

            using var map = shadow.BuildMap(this);

            Object.InternalSetPropertyMap(SwigCPtr, Property.SHADOW, map.SwigCPtr);
        }
    }
}
