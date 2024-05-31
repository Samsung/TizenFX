/*
 * Copyright(c) 2024 Samsung Electronics Co., Ltd.
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

namespace Tizen.AIAvatar
{
    internal interface ISingleShotModel
    {

        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SetTensorData(int index, byte[] buffer);
        [EditorBrowsable(EditorBrowsableState.Never)]
        public byte[] GetTensorData(int index);
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void Invoke();
    }
}
