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
    internal sealed class VisualState
    {
        public VisualState()
        {
            Setters = new ObservableCollection<Setter>();
        }

        public string Name { get; set; }
        public IList<Setter> Setters { get; }
        public Type TargetType { get; set; }

        internal VisualState Clone()
        {
            var clone = new VisualState { Name = Name, TargetType = TargetType };
            foreach (var setter in Setters)
            {
                clone.Setters.Add(setter);
            }

            return clone;
        }
    }
}
