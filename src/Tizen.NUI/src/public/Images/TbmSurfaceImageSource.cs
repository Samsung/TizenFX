using System;
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

using System.ComponentModel;

namespace Tizen.NUI
{
    using global::System;

    /// <summary>
    /// NativeImageSource with external tbm_surface_h handle, which comes from Native.
    /// </summary>
    /// <remarks>
    /// This class could be used on for Tizen platform.
    /// This class only be used for advanced Tizen developer.
    /// </remarks>
    /// <example>
    /// <code>
    /// IntPtr dangerousTbmSurfaceHandle = SomeDangerousFunction(); // It will return tbm_surface_h, convert as IntPtr.
    ///
    /// TbmSurfaceImageSource surface = new TbmSurfaceImageSource(dangerousTbmSurfaceHandle);
    ///
    /// ImageUrl imageUrl = surface.GenerateUrl();
    /// ImageView view = new ImageView(imageUrl.ToString());
    /// </code>
    /// </example>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class TbmSurfaceImageSource : NativeImageSource
    {
        [EditorBrowsable(EditorBrowsableState.Never)]
        public TbmSurfaceImageSource(IntPtr dangerousTbmSurfaceHandle) : base(Interop.NativeImageSource.NewHandleWithTbmSurface(dangerousTbmSurfaceHandle), true)
        {
            NDalicPINVOKE.ThrowExceptionIfExists();
        }

        /// <summary>
        /// Sets the TBM surface for the native image source.
        /// </summary>
        /// <param name="tbmSurface">The TBM surface to set.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SetTbmSurface(IntPtr tbmSurface)
        {
            Interop.NativeImageSource.SetSource(this.SwigCPtr.Handle, tbmSurface);
            NDalicPINVOKE.ThrowExceptionIfExists();
        }
    }
}
