/*
 * Copyright(c) 2020 Samsung Electronics Co., Ltd.
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
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI
{
    /// <summary>
    /// The class storing Background extra properties such as CornerRadius, ImageBorder.
    /// </summary>
    internal class BackgroundExtraData : IDisposable
    {
        private bool disposed = false;
        internal BackgroundExtraData()
        {
        }

        internal BackgroundExtraData(BackgroundExtraData other)
        {
            BackgroundImageBorder = other.BackgroundImageBorder;
            CornerRadius = other.CornerRadius;
        }

        private Rectangle backgroundImageBorder;

        internal bool Outdated { get; set; } = false;

        /// <summary></summary>
        internal Rectangle BackgroundImageBorder
        {
            get => backgroundImageBorder;
            set => backgroundImageBorder = new Rectangle(value);
        }

        /// <summary></summary>
        internal float CornerRadius { get; set; }

        /// <summary>
        /// Whether the CornerRadius value is relative (percentage [0.0f to 1.0f] of the view size) or absolute (in world units).
        /// </summary>
        internal VisualTransformPolicyType CornerRadiusPolicy { get; set; } = VisualTransformPolicyType.Absolute;

        internal bool Empty()
        {
            return CornerRadius == 0 && Rectangle.IsNullOrZero(BackgroundImageBorder);
        }

        internal void UpdateIfNeeds(View view)
        {
            if (!Outdated) return;

            PropertyMap backgroundMap = new PropertyMap();
            Tizen.NUI.Object.GetProperty((System.Runtime.InteropServices.HandleRef)view.SwigCPtr, View.Property.BACKGROUND).Get(backgroundMap);

            Update(backgroundMap);

            backgroundMap.Dispose();
        }

        internal void UpdateIfNeeds(PropertyMap backgroundMap)
        {
            if (!Outdated) return;

            Update(backgroundMap);
        }

        private void Update(PropertyMap backgroundMap)
        {
            float cornerRadius = 0;
            backgroundMap.Find(Visual.Property.CornerRadius)?.Get(out cornerRadius);
            CornerRadius = cornerRadius;

            int cornerRadiusPolicy = (int)VisualTransformPolicyType.Absolute;
            backgroundMap.Find(Visual.Property.CornerRadiusPolicy)?.Get(out cornerRadiusPolicy);
            CornerRadiusPolicy = (VisualTransformPolicyType)cornerRadiusPolicy;

            int visualType = 0;
            backgroundMap.Find(Visual.Property.Type)?.Get(out visualType);
            if (visualType == (int)Visual.Type.Image || visualType == (int)Visual.Type.NPatch)
            {
                backgroundMap.Find(NpatchImageVisualProperty.Border)?.Get(backgroundImageBorder);
            }

            Outdated = false;
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
            {
                return;
            }
            if (disposing)
            {
                backgroundImageBorder?.Dispose();
            }
            disposed = true;
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public void Dispose()
        {
            Dispose(true);
            global::System.GC.SuppressFinalize(this);
        }
    }
}


