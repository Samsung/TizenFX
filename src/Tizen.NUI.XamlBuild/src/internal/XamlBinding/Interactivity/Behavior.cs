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
using System.Reflection;

namespace Tizen.NUI.Binding
{
    internal abstract class Behavior : BindableObject, IAttachedObject
    {
        internal Behavior(Type associatedType)
        {
            if (associatedType == null)
                throw new ArgumentNullException("associatedType");
            AssociatedType = associatedType;
        }

        protected Type AssociatedType { get; }

        void IAttachedObject.AttachTo(BindableObject bindable)
        {
            if (bindable == null)
                throw new ArgumentNullException("bindable");
            if (!AssociatedType.IsInstanceOfType(bindable))
                throw new InvalidOperationException("bindable not an instance of AssociatedType");
            OnAttachedTo(bindable);
        }

        void IAttachedObject.DetachFrom(BindableObject bindable)
        {
            OnDetachingFrom(bindable);
        }

        protected virtual void OnAttachedTo(BindableObject bindable)
        {
        }

        protected virtual void OnDetachingFrom(BindableObject bindable)
        {
        }
    }

    internal abstract class Behavior<T> : Behavior where T : BindableObject
    {
        protected Behavior() : base(typeof(T))
        {
        }

        protected override void OnAttachedTo(BindableObject bindable)
        {
            base.OnAttachedTo(bindable);
            OnAttachedTo((T)bindable);
        }

        protected virtual void OnAttachedTo(T bindable)
        {
        }

        protected override void OnDetachingFrom(BindableObject bindable)
        {
            OnDetachingFrom((T)bindable);
            base.OnDetachingFrom(bindable);
        }

        protected virtual void OnDetachingFrom(T bindable)
        {
        }
    }
}
 
