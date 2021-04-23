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

        /// <summary></summary>
        internal Rectangle BackgroundImageBorder
        {
            get => backgroundImageBorder;
            set => backgroundImageBorder = new Rectangle(value);
        }

        /// <summary></summary>
        internal Vector4 CornerRadius { get; set; }

        /// <summary>
        /// Whether the CornerRadius value is relative (percentage [0.0f to 1.0f] of the view size) or absolute (in world units).
        /// </summary>
        internal VisualTransformPolicyType CornerRadiusPolicy { get; set; } = VisualTransformPolicyType.Absolute;

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


