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
using System.Runtime.CompilerServices;
using System.ComponentModel;

namespace Tizen.NUI.Binding
{
    /// <summary>
    /// An abstract class that provides a BindingMode and a formatting option.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public abstract class BindingBase
    {
        static readonly ConditionalWeakTable<IEnumerable, CollectionSynchronizationContext> SynchronizedCollections = new ConditionalWeakTable<IEnumerable, CollectionSynchronizationContext>();

        BindingMode mode = BindingMode.Default;
        string stringFormat;
        object targetNullValue;
        object fallbackValue;

        internal BindingBase()
        {
        }

        /// <summary>
        /// Gets or sets the mode for this binding.
        /// </summary>
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public BindingMode Mode
        {
            get { return mode; }
            set
            {
                if (value != BindingMode.Default
                    && value != BindingMode.OneWay
                    && value != BindingMode.OneWayToSource
                    && value != BindingMode.TwoWay
                    && value != BindingMode.OneTime)
                    throw new ArgumentException("mode is not a valid BindingMode", nameof(Mode));

                ThrowIfApplied();

                mode = value;
            }
        }

        /// <summary>
        /// Gets or sets the string format for this binding.
        /// </summary>
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string StringFormat
        {
            get { return stringFormat; }
            set
            {
                ThrowIfApplied();

                stringFormat = value;
            }
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public object TargetNullValue
        {
            get { return targetNullValue; }
            set
            {
                ThrowIfApplied();
                targetNullValue = value;
            }
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public object FallbackValue
        {
            get => fallbackValue;
            set
            {
                ThrowIfApplied();
                fallbackValue = value;
            }
        }

        internal bool AllowChaining { get; set; }

        internal object Context { get; set; }

        internal bool IsApplied { get; private set; }

        /// <summary>
        /// Stops synchronization on the collection.
        /// </summary>
        /// <param name="collection">The collection on which to stop synchronization.</param>
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static void DisableCollectionSynchronization(IEnumerable collection)
        {
            if (collection == null)
                throw new ArgumentNullException(nameof(collection));

            SynchronizedCollections.Remove(collection);
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static void EnableCollectionSynchronization(IEnumerable collection, object context, CollectionSynchronizationCallback callback)
        {
            if (collection == null)
                throw new ArgumentNullException(nameof(collection));
            if (callback == null)
                throw new ArgumentNullException(nameof(callback));

            SynchronizedCollections.Add(collection, new CollectionSynchronizationContext(context, callback));
        }

        /// <summary>
        /// Throws an InvalidOperationException if the binding has been applied.
        /// </summary>
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected void ThrowIfApplied()
        {
            if (IsApplied)
                throw new InvalidOperationException("Can not change a binding while it's applied");
        }

        internal virtual void Apply(bool fromTarget)
        {
            IsApplied = true;
        }

        internal virtual void Apply(object context, BindableObject bindObj, BindableProperty targetProperty, bool fromBindingContextChanged = false)
        {
            IsApplied = true;
        }

        internal abstract BindingBase Clone();

        internal virtual object GetSourceValue(object value, Type targetPropertyType)
        {
            if (value == null && TargetNullValue != null)
                return TargetNullValue;
            if (StringFormat != null)
                return string.Format(StringFormat, value);

            return value;
        }

        internal virtual object GetTargetValue(object value, Type sourcePropertyType)
        {
            return value;
        }

        internal static bool TryGetSynchronizedCollection(IEnumerable collection, out CollectionSynchronizationContext synchronizationContext)
        {
            if (collection == null)
                throw new ArgumentNullException(nameof(collection));

            return SynchronizedCollections.TryGetValue(collection, out synchronizationContext);
        }

        internal virtual void Unapply(bool fromBindingContextChanged = false)
        {
            IsApplied = false;
        }
    }
}
