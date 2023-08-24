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
using System.ComponentModel;

namespace Tizen.NUI.Binding
{
    /// <since_tizen> 6 </since_tizen>
    /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
    [EditorBrowsable(EditorBrowsableState.Never)]
    public abstract class TriggerAction
    {
        internal TriggerAction(Type associatedType)
        {
            if (associatedType == null)
                throw new ArgumentNullException(nameof(associatedType));
            AssociatedType = associatedType;
        }

        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected Type AssociatedType { get; private set; }

        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected abstract void Invoke(object sender);

        internal virtual void DoInvoke(object sender)
        {
            Invoke(sender);
        }
    }

    internal abstract class TriggerAction<T> : TriggerAction where T : BindableObject
    {
        protected TriggerAction() : base(typeof(T))
        {
        }

        protected override void Invoke(object sender)
        {
            Invoke((T)sender);
        }

        protected abstract void Invoke(T sender);
    }
}
