/*
 * Copyright (c) 2017 Samsung Electronics Co., Ltd.
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
using Tizen.NUI.XamlBinding;
using Tizen.NUI.Xaml.Forms.BaseComponents;
using Tizen.NUI;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace Tizen.NUI.Xaml
{
    /// <summary>
    /// The ContentPage class.
    /// </summary>
    [ContentProperty("Content")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class ContentPage : TemplatedPage, Tizen.NUI.Binding.IResourcesProvider
    {
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public View Root {get; internal set;}

        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ContentProperty = BindableProperty.Create(nameof(Content), typeof(View), typeof(ContentPage), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var self = (ContentPage)bindable;
            if (newValue != null)
            {
                self.Root.Add((View)newValue);
            }
        });

        /// <summary>
        /// The contents of ContentPage can be added into it.
        /// </summary>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public View Content
        {
            get { return (View)GetValue(ContentProperty); }
            set { SetValue(ContentProperty, value); }
        }

        ResourceDictionary _resources;
        bool Tizen.NUI.Binding.IResourcesProvider.IsResourcesCreated => _resources != null;

        /// <summary>
        /// Method that is called when the binding content changes.
        /// </summary>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ResourceDictionary XamlResources
        {
            get
            {
                if (_resources != null)
                    return _resources;

                _resources = new ResourceDictionary();
                ((IResourceDictionary)_resources).ValuesChanged += OnResourcesChanged;
                return _resources;
            }
            set
            {
                if (_resources == value)
                    return;
                OnPropertyChanging();
                if (_resources != null)
                    ((IResourceDictionary)_resources).ValuesChanged -= OnResourcesChanged;
                _resources = value;
                OnResourcesChanged(value);
                if (_resources != null)
                    ((IResourceDictionary)_resources).ValuesChanged += OnResourcesChanged;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Method that is called when the binding content changes.
        /// </summary>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();

            View content = Content;
            ControlTemplate controlTemplate = ControlTemplate;
            if (content != null && controlTemplate != null)
            {
                SetInheritedBindingContext(content, BindingContext);
            }
        }

        internal override void OnControlTemplateChanged(ControlTemplate oldValue, ControlTemplate newValue)
        {
            if (oldValue == null)
                return;

            base.OnControlTemplateChanged(oldValue, newValue);
            View content = Content;
            ControlTemplate controlTemplate = ControlTemplate;
            if (content != null && controlTemplate != null)
            {
                SetInheritedBindingContext(content, BindingContext);
            }
        }

        /// <summary>
        /// The constructor.
        /// </summary>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ContentPage(Window win)
        {
            Root = new View();
            Root.WidthResizePolicy = ResizePolicyType.FillToParent;
            Root.HeightResizePolicy = ResizePolicyType.FillToParent;
            (Root as IElement).Parent = this;

            win.Add(Root.view);
        }

        /// <summary>
        /// Check whether the content is empty.
        /// </summary>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool IsEmpty
        {
            get
            {
                return ( Root.ChildCount == 0 ) ? true : false;
            }
        }

        /// <summary>
        /// Clear all contents from this ContentPage.
        /// </summary>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void ClearContent()
        {
            if ( Root != null )
            {
                //Remove it from the window
                Window.Instance.Remove(Root.view);
                Root.Dispose();
                Root = null;

                //Readd to window
                Root = new View();
                Root.WidthResizePolicy = ResizePolicyType.FillToParent;
                Root.HeightResizePolicy = ResizePolicyType.FillToParent;
                Window.Instance.Add(Root.view);

                ClearHandler();
            }
        }

        private EventHandler _clearEventHandler;

        /// <summary>
        /// Clear event.
        /// </summary>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public event EventHandler ClearEvent
        {
            add
            {
                _clearEventHandler += value;
            }
            remove
            {
                _clearEventHandler -= value;
            }
        }

        private void ClearHandler()
        {
            if (_clearEventHandler != null)
            {
                _clearEventHandler(this, null);
            }
        }

        /// <summary>
        /// Users can set focus logic codes here.
        /// </summary>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual void SetFocus() { }
    }
}
