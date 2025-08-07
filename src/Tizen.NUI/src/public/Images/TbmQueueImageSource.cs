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
    /// NativeImageQueue with external tbm_queue_h handle, which comes from Native.
    /// </summary>
    /// <remarks>
    /// This class could be used on for Tizen platform.
    /// This class only be used for advanced Tizen developer.
    /// </remarks>
    /// <example>
    /// <code>
    /// IntPtr dangerousTbmQueueHandle = SomeDangerousFunction(); // It will return tbm_queue_h, convert as IntPtr.
    ///
    /// TbmQueueImageSource queue = new TbmQueueImageSource(dangerousTbmQueueHandle);
    /// if(queue.CanDequeueBuffer())
    /// {
    ///   var buffer = queue.DequeueBuffer(ref bufferWidth,ref bufferHeight,ref bufferStride);
    ///
    ///   /* Use buffer */
    ///
    ///   queue.EnqueueBuffer(buffer);
    /// }
    /// </code>
    /// </example>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class TbmQueueImageSource : NativeImageQueue
    {
        [EditorBrowsable(EditorBrowsableState.Never)]
        public TbmQueueImageSource(IntPtr dangerousTbmQueueHandle) : base(Interop.NativeImageQueue.NewHandleWithTbmQueue(dangerousTbmQueueHandle), true)
        {
            NDalicPINVOKE.ThrowExceptionIfExists();
        }
    }
}
