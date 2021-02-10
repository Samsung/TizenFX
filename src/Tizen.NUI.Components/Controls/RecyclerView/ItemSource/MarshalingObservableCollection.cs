﻿/* Copyright (c) 2021 Samsung Electronics Co., Ltd.
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
using System.Collections.Specialized;

namespace Tizen.NUI.Components
{
    // Wraps a List which implements INotifyCollectionChanged (usually an ObservableCollection)
    // and marshals all of the list modifications to the main thread. Modifications to the underlying 
    // collection which are made off of the main thread remain invisible to consumers on the main thread
    // until they have been processed by the main thread.

    internal class MarshalingObservableCollection : List<object>, INotifyCollectionChanged
    {
        readonly IList internalCollection;

        public MarshalingObservableCollection(IList list)
        {
            if (!(list is INotifyCollectionChanged incc))
            {
                throw new ArgumentException($"{nameof(list)} must implement {nameof(INotifyCollectionChanged)}");
            }

            internalCollection = list;
            incc.CollectionChanged += InternalCollectionChanged;

            foreach (var item in internalCollection)
            {
                Add(item);
            }
        }

        class ResetNotifyCollectionChangedEventArgs : NotifyCollectionChangedEventArgs
        {
            public IList Items { get; }
            public ResetNotifyCollectionChangedEventArgs(IList items)
                : base(NotifyCollectionChangedAction.Reset) => Items = items;
        }

        public event NotifyCollectionChangedEventHandler CollectionChanged;

        void OnCollectionChanged(NotifyCollectionChangedEventArgs args)
        {
            CollectionChanged?.Invoke(this, args);
        }

        void InternalCollectionChanged(object sender, NotifyCollectionChangedEventArgs args)
        {
            if (args.Action == NotifyCollectionChangedAction.Reset)
            {
                var items = new List<object>();
                for (int n = 0; n < internalCollection.Count; n++)
                {
                    items.Add(internalCollection[n]);
                }

                args = new ResetNotifyCollectionChangedEventArgs(items);
            }
/*
            if (Device.IsInvokeRequired)
            {
                Device.BeginInvokeOnMainThread(() => HandleCollectionChange(args));
            }
            else
            {
                HandleCollectionChange(args);
            }
*/

            HandleCollectionChange(args);
        }

        void HandleCollectionChange(NotifyCollectionChangedEventArgs args)
        {
            switch (args.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    Add(args);
                    break;
                case NotifyCollectionChangedAction.Move:
                    Move(args);
                    break;
                case NotifyCollectionChangedAction.Remove:
                    Remove(args);
                    break;
                case NotifyCollectionChangedAction.Replace:
                    Replace(args);
                    break;
                case NotifyCollectionChangedAction.Reset:
                    Reset(args);
                    break;
            }
        }

        void Move(NotifyCollectionChangedEventArgs args)
        {
            var count = args.OldItems.Count;

            for (int n = 0; n < count; n++)
            {
                var toMove = this[args.OldStartingIndex];
                RemoveAt(args.OldStartingIndex);
                Insert(args.NewStartingIndex, toMove);
            }

            OnCollectionChanged(args);
        }

        void Remove(NotifyCollectionChangedEventArgs args)
        {
            var startIndex = args.OldStartingIndex + args.OldItems.Count - 1;
            for (int n = startIndex; n >= args.OldStartingIndex; n--)
            {
                RemoveAt(n);
            }

            OnCollectionChanged(args);
        }

        void Replace(NotifyCollectionChangedEventArgs args)
        {
            var startIndex = args.NewStartingIndex;
            foreach (var item in args.NewItems)
            {
                this[startIndex] = item;
                startIndex += 1;
            }

            OnCollectionChanged(args);
        }

        void Add(NotifyCollectionChangedEventArgs args)
        {
            var startIndex = args.NewStartingIndex;
            foreach (var item in args.NewItems)
            {
                Insert(startIndex, item);
                startIndex += 1;
            }

            OnCollectionChanged(args);
        }

        void Reset(NotifyCollectionChangedEventArgs args)
        {
            if (!(args is ResetNotifyCollectionChangedEventArgs resetArgs))
            {
                throw new InvalidOperationException($"Cannot guarantee collection accuracy for Resets which do not use {nameof(ResetNotifyCollectionChangedEventArgs)}");
            }

            Clear();
            foreach (var item in resetArgs.Items)
            {
                Add(item);
            }

            OnCollectionChanged(args);
        }
    }
}
