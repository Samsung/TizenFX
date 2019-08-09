/*
 * Copyright (c) 2018 Samsung Electronics Co., Ltd.
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
using Tizen.NUI.Binding;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Xaml;
using System.Collections.Generic;
using System.IO;

namespace Tizen.NUI
{
    /// <summary>
    /// The ContentPage class.
    /// </summary>
    [ContentProperty("Content")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class ContentPage : TemplatedPage
    {
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public View Root {get; internal set;}

        /// <summary>
        /// The contents of ContentPage can be added into it.
        /// </summary>
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ContentProperty = BindableProperty.Create(nameof(Content), typeof(View), typeof(ContentPage), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var self = (ContentPage)bindable;
            if (newValue != null)
            {
                self.Root.Add((View)newValue);
            }
            var newElement = (Element)newValue;
            if (newElement != null)
            {
                BindableObject.SetInheritedBindingContext(newElement, bindable.BindingContext);
            }
        });

        /// <summary>
        /// The contents of ContentPage can be added into it.
        /// </summary>
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public View Content
        {
            get { return (View)GetValue(ContentProperty); }
            set { SetValue(ContentProperty, value); }
        }

        /// <summary>
        /// Method that is called when the binding content changes.
        /// </summary>
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
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
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ContentPage(Window win)
        {
            IsCreateByXaml = true;

            Root = new View();
            Root.WidthResizePolicy = ResizePolicyType.FillToParent;
            Root.HeightResizePolicy = ResizePolicyType.FillToParent;

            win.Add(Root);
        }

        /// <summary>
        /// The Resources property.
        /// </summary>
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ResourceDictionary XamlResources
        {
            get
            {
                return Application.Current.XamlResources;
            }

            set
            {
                Application.Current.XamlResources = value;
            }
        }

        /// <summary>
        /// To make the ContentPage instance be disposed.
        /// </summary>
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void Dispose(DisposeTypes type)
        {
            if (disposed)
            {
                return;
            }

            if (type == DisposeTypes.Explicit)
            {
                //Called by User
                //Release your own managed resources here.
                //You should release all of your own disposable objects here.
            }

            //Release your own unmanaged resources here.
            //You should not access any managed member here except static instance.
            //because the execution order of Finalizes is non-deterministic.
            if(Root != null) 
            {
                Window.Instance.Remove(Root);
                Root.Dispose();
                Root = null;
            }
            base.Dispose(type);
        }

        /// <summary>
        /// Check whether the content is empty.
        /// </summary>
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
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
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void ClearContent()
        {
            if ( Root != null )
            {
                //Remove it from the window
                Window.Instance.Remove(Root);
                Root.Dispose();
                Root = null;

                //Readd to window
                Root = new View();
                Root.WidthResizePolicy = ResizePolicyType.FillToParent;
                Root.HeightResizePolicy = ResizePolicyType.FillToParent;
                Window.Instance.Add(Root);

                ClearHandler();
            }
        }

        private EventHandler _clearEventHandler;

        /// <summary>
        /// Clear event.
        /// </summary>
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
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
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual void SetFocus() { }

        private Dictionary<string, Transition> transDictionary = new Dictionary<string, Transition>();

        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Transition GetTransition(string transitionName)
        {
            Transition trans = null;
            transDictionary.TryGetValue(transitionName, out trans);
            return trans;
        }

        private void LoadTransitions()
        {
            foreach (string str in transitionNames)
            {
                string resourceName = str + ".xaml";
                Transition trans = null;

                string resource = Tizen.Applications.Application.Current.DirectoryInfo.Resource;

                string likelyResourcePath = resource + "animation/" + resourceName;

                if (File.Exists(likelyResourcePath))
                {
                    trans = Extensions.LoadObject<Transition>(likelyResourcePath);
                }
                if (trans)
                {
                    transDictionary.Add(trans.Name, trans);
                }
            }
        }

        private string[] transitionNames;

        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string[] TransitionNames
        {
            get
            {
                return transitionNames;
            }
            set
            {
                transitionNames = value;
                LoadTransitions();
            }
        }
    }
}
