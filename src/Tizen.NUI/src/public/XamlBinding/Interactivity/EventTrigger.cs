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
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;

namespace Tizen.NUI.Binding
{
    /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
    [EditorBrowsable(EditorBrowsableState.Never)]
    [ContentProperty("Actions")]
    public sealed class EventTrigger : TriggerBase
    {
        static readonly MethodInfo s_handlerinfo = typeof(EventTrigger).GetRuntimeMethods().Single(mi => mi.Name == "OnEventTriggered" && mi.IsPublic == false);
        readonly List<BindableObject> associatedObjects = new List<BindableObject>();

        EventInfo eventinfo;

        string eventname;
        Delegate handlerdelegate;

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public EventTrigger() : base(typeof(BindableObject))
        {
            Actions = new SealedList<TriggerAction>();
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public IList<TriggerAction> Actions { get; }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string Event
        {
            get { return eventname; }
            set
            {
                if (eventname == value)
                    return;
                if (IsSealed)
                    throw new InvalidOperationException("Event cannot be changed once the Trigger has been applied");
                OnPropertyChanging();
                eventname = value;
                OnPropertyChanged();
            }
        }

        internal override void OnAttachedTo(BindableObject bindable)
        {
            base.OnAttachedTo(bindable);
            if (!string.IsNullOrEmpty(Event))
                AttachHandlerTo(bindable);
            associatedObjects.Add(bindable);
        }

        internal override void OnDetachingFrom(BindableObject bindable)
        {
            associatedObjects.Remove(bindable);
            DetachHandlerFrom(bindable);
            base.OnDetachingFrom(bindable);
        }

        internal override void OnSeal()
        {
            base.OnSeal();
            ((SealedList<TriggerAction>)Actions).IsReadOnly = true;
        }

        void AttachHandlerTo(BindableObject bindable)
        {
            try
            {
                eventinfo = bindable.GetType().GetRuntimeEvent(Event);
                handlerdelegate = s_handlerinfo.CreateDelegate(eventinfo?.EventHandlerType, this);
            }
            catch (Exception)
            {
                Console.WriteLine($"EventTrigger", "Can not attach EventTrigger to {binding.GetType()}.{Event}. Check if the handler exists and if the signature is right.");
            }
            if (eventinfo != null && handlerdelegate != null)
                eventinfo.AddEventHandler(bindable, handlerdelegate);
        }

        void DetachHandlerFrom(BindableObject bindable)
        {
            if (eventinfo != null && handlerdelegate != null)
                eventinfo.RemoveEventHandler(bindable, handlerdelegate);
        }

        // [Preserve]
        void OnEventTriggered(object sender, EventArgs e)
        {
            var bindable = (BindableObject)sender;
            foreach (TriggerAction action in Actions)
                action.DoInvoke(bindable);
        }
    }
}
