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
using Tizen.NUI.Binding;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI
{
    /// <summary>
    /// The ContentPage class.
    /// </summary>
    [ContentProperty("Content")]
    public class ContentPage : TemplatedPage
    {
        private View _content;

		// public static readonly BindableProperty ContentProperty = BindableProperty.Create(nameof(Content), typeof(View), typeof(ContentPage), null, propertyChanged: TemplateUtilities.OnContentChanged);

		// public View Content
		// {
		// 	get { return (View)GetValue(ContentProperty); }
		// 	set { SetValue(ContentProperty, value); }
		// }

        /// <summary>
        /// Method that is called when the binding content changes.
        /// </summary>
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
        public ContentPage(Window win)
        {
            _content = new View();
            _content.WidthResizePolicy = ResizePolicyType.FillToParent;
            _content.HeightResizePolicy = ResizePolicyType.FillToParent;
            win.Add(_content);
        }

        /// <summary>
        /// To make the ContentPage instance be disposed.
        /// </summary>
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
            Window.Instance.Remove(_content);
            _content?.Dispose();
            _content = null;

            base.Dispose(type);
        }

        /// <summary>
        /// The contents of ContentPage can be added into it.
        /// </summary>
        public View Content
        {
            get
            {
                return _content;
            }
            set
            {
                if (value != null)
                {
                    _content.Add(value);
                }
            }
        }

        /// <summary>
        /// Check whether the content is empty.
        /// </summary>
        public bool IsEmpty
        {
            get
            {
                return ( _content.ChildCount == 0 ) ? true : false;
            }
        }

        /// <summary>
        /// Clear all contents from this ContentPage.
        /// </summary>
        public void ClearContent()
        {
            if ( _content != null )
            {
                //Remove it from the window
                Window.Instance.Remove(_content);
                _content.Dispose();
                _content = null;

                //Readd to window
                _content = new View();
                _content.WidthResizePolicy = ResizePolicyType.FillToParent;
                _content.HeightResizePolicy = ResizePolicyType.FillToParent;
                Window.Instance.Add(_content);

                ClearHandler();
            }
        }

        private EventHandler _clearEventHandler;

        /// <summary>
        /// Clear event.
        /// </summary>
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
        public virtual void SetFocus() { }

    }
}