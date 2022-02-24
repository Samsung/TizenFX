/*
 * Copyright(c) 2022 Samsung Electronics Co., Ltd.
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
using System.Collections.Generic;
using System.ComponentModel;
using Tizen.NUI.Binding.Internals;

namespace Tizen.NUI.Binding
{
    /// <summary>
    /// Base class for DataTemplate and ControlTemplate classes.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    internal class ElementTemplate : IElement, IDataTemplate
    {
        List<Action<object, ResourcesChangedEventArgs>> _changeHandlers;
        Element _parent;
        bool _canRecycle; // aka IsDeclarative

        internal ElementTemplate()
        {
        }

        internal ElementTemplate(Type type) : this()
        {
            if (type == null)
                throw new ArgumentNullException("type");

            _canRecycle = true;

            LoadTemplate = () => Activator.CreateInstance(type);
        }

        internal ElementTemplate(Func<object> loadTemplate) : this()
        {
            if (loadTemplate == null)
                throw new ArgumentNullException("loadTemplate");

            LoadTemplate = loadTemplate;
        }

        Func<object> LoadTemplate { get; set; }

#pragma warning disable 0612
        Func<object> IDataTemplate.LoadTemplate
        {
            get { return LoadTemplate; }
            set { LoadTemplate = value; }
        }
#pragma warning restore 0612

        void IElement.AddResourcesChangedListener(Action<object, ResourcesChangedEventArgs> onchanged)
        {
            _changeHandlers = _changeHandlers ?? new List<Action<object, ResourcesChangedEventArgs>>(1);
            _changeHandlers.Add(onchanged);
        }

        internal bool CanRecycle => _canRecycle;
        Element IElement.Parent
        {
            get { return _parent; }
            set
            {
                if (_parent == value)
                    return;
                if (_parent != null)
                    ((IElement)_parent).RemoveResourcesChangedListener(OnResourcesChanged);
                _parent = value;
                if (_parent != null)
                    ((IElement)_parent).AddResourcesChangedListener(OnResourcesChanged);
            }
        }

        void IElement.RemoveResourcesChangedListener(Action<object, ResourcesChangedEventArgs> onchanged)
        {
            if (_changeHandlers == null)
                return;
            _changeHandlers.Remove(onchanged);
        }

        /// <summary>
        /// Used by the XAML infrastructure to load data templates and set up the content of the resulting UI.
        /// </summary>
        /// <returns></returns>
        public object CreateContent()
        {
            if (LoadTemplate == null)
                throw new InvalidOperationException("LoadTemplate should not be null");
            if (this is DataTemplateSelector)
                throw new InvalidOperationException("Cannot call CreateContent directly on a DataTemplateSelector");

            object item = LoadTemplate();
            SetupContent(item);

            return item;
        }

        internal virtual void SetupContent(object item)
        {
        }

        void OnResourcesChanged(object sender, ResourcesChangedEventArgs e)
        {
            if (_changeHandlers == null)
                return;
            foreach (Action<object, ResourcesChangedEventArgs> handler in _changeHandlers)
                handler(this, e);
        }
    }
}
 
