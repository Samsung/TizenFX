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
    [RuntimeNameProperty(nameof(Name))]
    [ContentProperty(nameof(States))]
    internal sealed class VisualStateGroup
    {
        public VisualStateGroup()
        {
            States = new WatchAddList<VisualState>(OnStatesChanged);
        }

        public Type TargetType { get; set; }
        public string Name { get; set; }
        public IList<VisualState> States { get; }
        public VisualState CurrentState { get; internal set; }

        internal VisualState GetState(string name)
        {
            foreach (VisualState state in States)
            {
                if (string.CompareOrdinal(state.Name, name) == 0)
                {
                    return state;
                }
            }

            return null;
        }

        internal VisualStateGroup Clone()
        {
            var clone = new VisualStateGroup { TargetType = TargetType, Name = Name, CurrentState = CurrentState };
            foreach (VisualState state in States)
            {
                clone.States.Add(state.Clone());
            }

            return clone;
        }

        internal event EventHandler StatesChanged;

        void OnStatesChanged(IList<VisualState> list)
        {
            if (list.Any(state => string.IsNullOrEmpty(state.Name)))
            {
                throw new InvalidOperationException("State names may not be null or empty");
            }

            StatesChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}
