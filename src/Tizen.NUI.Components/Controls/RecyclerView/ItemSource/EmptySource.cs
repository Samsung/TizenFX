/* Copyright (c) 2021 Samsung Electronics Co., Ltd.
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

namespace Tizen.NUI.Components
{
    internal sealed class EmptySource : IItemSource
    {
        public int Count => 0;

        public bool HasHeader { get; set; }
        public bool HasFooter { get; set; }

        public void Dispose()
        {

        }

        public bool IsHeader(int index)
        {
            return HasHeader && index == 0;
        }

        public bool IsFooter(int index)
        {
            if (!HasFooter)
            {
                return false;
            }

            if (HasHeader)
            {
                return index == 1;
            }

            return index == 0;
        }

        public int GetPosition(object item)
        {
            return -1;
        }

        public object GetItem(int position)
        {
            throw new IndexOutOfRangeException("IItemSource is empty");
        }
    }
}
