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
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Tizen.NUI;
using Tizen.NUI.Binding;

namespace Tizen.NUI.Xaml
{
    internal class VisualStateGroupList : IList<VisualStateGroup>
    {
        readonly IList<VisualStateGroup> _internalList;

        void Validate(IList<VisualStateGroup> groups)
        {
            // If we have 1 group, no need to worry about duplicate group names
            if (groups.Count > 1)
            {
                if (groups.GroupBy(vsg => vsg.Name).Any(g => g.Count() > 1))
                {
                    throw new InvalidOperationException("VisualStateGroup Names must be unique");
                }
            }

            // State names must be unique within this group list, so pull in all 
            // the states in all the groups, group them by name, and see if we have
            // and duplicates
            if (groups.SelectMany(group => group.States).GroupBy(state => state.Name).Any(g => g.Count() > 1))
            {
                throw new InvalidOperationException("VisualState Names must be unique");
            }
        }

        public VisualStateGroupList()
        {
            _internalList = new WatchAddList<VisualStateGroup>(Validate);
        }

        void ValidateOnStatesChanged(object sender, EventArgs eventArgs)
        {
            Validate(_internalList);
        }

        public IEnumerator<VisualStateGroup> GetEnumerator()
        {
            return _internalList.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)_internalList).GetEnumerator();
        }

        public void Add(VisualStateGroup item)
        {
            _internalList.Add(item);
            item.StatesChanged += ValidateOnStatesChanged;
        }

        public void Clear()
        {
            foreach (var group in _internalList)
            {
                group.StatesChanged -= ValidateOnStatesChanged;
            }

            _internalList.Clear();
        }

        public bool Contains(VisualStateGroup item)
        {
            return _internalList.Contains(item);
        }

        public void CopyTo(VisualStateGroup[] array, int arrayIndex)
        {
            _internalList.CopyTo(array, arrayIndex);
        }

        public bool Remove(VisualStateGroup item)
        {
            item.StatesChanged -= ValidateOnStatesChanged;
            return _internalList.Remove(item);
        }

        public int Count => _internalList.Count;

        public bool IsReadOnly => false;

        public int IndexOf(VisualStateGroup item)
        {
            return _internalList.IndexOf(item);
        }

        public void Insert(int index, VisualStateGroup item)
        {
            item.StatesChanged += ValidateOnStatesChanged;
            _internalList.Insert(index, item);
        }

        public void RemoveAt(int index)
        {
            _internalList[index].StatesChanged -= ValidateOnStatesChanged;
            _internalList.RemoveAt(index);
        }

        public VisualStateGroup this[int index]
        {
            get => _internalList[index];
            set => _internalList[index] = value;
        }
    }
}
