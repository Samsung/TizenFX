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

namespace Tizen.NUI.Components
{
    internal class UngroupedItemSource : IGroupableItemSource
    {
        readonly IItemSource source;

        public UngroupedItemSource(IItemSource itemSource)
        {
            source = itemSource;
        }

        public int Count => source.Count;

        public bool HasHeader { get => source.HasHeader; set => source.HasHeader = value; }
        public bool HasFooter { get => source.HasFooter; set => source.HasFooter = value; }

        public void Dispose()
        {
            source.Dispose();
        }

        public object GetItem(int position)
        {
            return source.GetItem(position);
        }

        public int GetPosition(object item)
        {
            return source.GetPosition(item);
        }

        public bool IsFooter(int position)
        {
            return source.IsFooter(position);
        }

        public bool IsGroupFooter(int position)
        {
            return false;
        }

        public bool IsGroupHeader(int position)
        {
            return false;
        }

        public bool IsHeader(int position)
        {
            return source.IsHeader(position);
        }

        public object GetGroupParent(int position)
        {
            return null;
        }
    }
}
