/*
 * Copyright (c) 2017 Samsung Electronics Co., Ltd All Rights Reserved
 *
 * Licensed under the Apache License, Version 2.0 (the License);
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 * http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an AS IS BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using static Interop.Elementary;

namespace ElmSharp
{
    /// <summary>
    /// Transit is designed to apply various animated transition effects, such as translation, rotation, etc.
    /// For using these effects, create a transit and add the desired transition effects.
    /// </summary>
    /// <remarks>Transit is not reusable. If the effect ends, the transit is destroyed automatically.</remarks>
    /// <since_tizen> preview </since_tizen>
    public class Transit : IDisposable
    {
        IntPtr _handle = IntPtr.Zero;
        bool _isDisposed = false;
        ObservableCollection<EvasObject> _objects = new ObservableCollection<EvasObject>();
        ObservableCollection<Transit> _chains = new ObservableCollection<Transit>();
        HashSet<object> _checker = new HashSet<object>();
        Elm_Transit_Del_Cb DeletedCallback;
        Elm_Transit_Effect_End_Cb EffectEndCallback;
        Elm_Transit_Effect_Transition_Cb EffectTransitionCallback;

        /// <summary>
        /// A callback is called when the transit is deleted.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public event EventHandler Deleted;

        /// <summary>
        /// Creates and initializes a new instance of the Transit class.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public Transit()
        {
            _handle = Interop.Elementary.elm_transit_add();
            DeletedCallback = (ptr1, ptr2) =>
            {
                Deleted?.Invoke(this, EventArgs.Empty);
                Dispose(true);
            };
            Interop.Elementary.elm_transit_del_cb_set(_handle, DeletedCallback, IntPtr.Zero);
            ((INotifyCollectionChanged)_objects).CollectionChanged += OnObjectCollectionChanged;
            ((INotifyCollectionChanged)_chains).CollectionChanged += OnChaninCollectionChanged;
        }

        /// <summary>
        /// Destroys the transit object.
        /// </summary>
        ~Transit()
        {
            Dispose(false);
        }

        /// <summary>
        /// Gets or sets the transit animation time.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public double Duration
        {
            get
            {
                return Interop.Elementary.elm_transit_duration_get(_handle);
            }
            set
            {
                Interop.Elementary.elm_transit_duration_set(_handle, value);
            }
        }

        /// <summary>
        /// Gets or sets a value whether the objects states will be kept or not.
        /// If it is not kept, the objects states will be reset when the transition ends.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public bool ObjectStateKeep
        {
            get
            {
                return Interop.Elementary.elm_transit_objects_final_state_keep_get(_handle);
            }
            set
            {
                Interop.Elementary.elm_transit_objects_final_state_keep_set(_handle, value);
            }
        }

        /// <summary>
        /// Gets or sets the transit animation acceleration type.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public TweenMode TweenMode
        {
            get
            {
                return (TweenMode)Interop.Elementary.elm_transit_tween_mode_get(_handle);
            }
            set
            {
                Interop.Elementary.elm_transit_tween_mode_set(_handle, (int)value);
            }
        }

        /// <summary>
        /// Gets or sets the transit repeat count.
        /// If the repeat is a negative number, it will repeat infinite times.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public int Repeat
        {
            get
            {
                return Interop.Elementary.elm_transit_repeat_times_get(_handle);
            }
            set
            {
                Interop.Elementary.elm_transit_repeat_times_set(_handle, value);
            }
        }

        /// <summary>
        /// Gets or sets if auto reverse is on.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public bool AutoReverse
        {
            get
            {
                return Interop.Elementary.elm_transit_auto_reverse_get(_handle);
            }
            set
            {
                Interop.Elementary.elm_transit_auto_reverse_set(_handle, value);
            }
        }

        /// <summary>
        /// Gets or sets the event enabled when transit is operating.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public bool EventEnabled
        {
            get
            {
                return Interop.Elementary.elm_transit_event_enabled_get(_handle);
            }
            set
            {
                Interop.Elementary.elm_transit_event_enabled_set(_handle, value);
            }
        }

        /// <summary>
        /// Gets or sets the smooth scaling for transit map rendering.
        /// This gets the smooth scaling for transit map rendering.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public bool Smooth
        {
            get
            {
                return Interop.Elementary.elm_transit_smooth_get(_handle);
            }
            set
            {
                Interop.Elementary.elm_transit_smooth_set(_handle, value);
            }
        }

        /// <summary>
        /// Gets the time progression of the animation (a double value between 0.0 and 1.0).
        /// The value returned is a fraction (current time/total time).
        /// It represents the progression position relative to the total.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public double Progress
        {
            get
            {
                return Interop.Elementary.elm_transit_progress_value_get(_handle);
            }
        }

        /// <summary>
        /// Gets or sets the transit animation tween mode acceleration factor.
        /// </summary>
        /// <returns>A factor value from 0.0 to 1.0.</returns>
        /// <since_tizen> preview </since_tizen>
        public double BeginAccelerationFactor
        {
            get
            {
                double begin = 1.0, end = 0.0;
                Interop.Elementary.elm_transit_tween_mode_factor_get(_handle, out begin, out end);
                return begin;
            }
            set
            {
                Interop.Elementary.elm_transit_tween_mode_factor_set(_handle, value, EndAccelerationFactor);
            }
        }

        /// <summary>
        /// Gets or sets the transit animation tween mode acceleration factor.
        /// </summary>
        /// <returns>A factor value from 0.0 to 1.0.</returns>
        /// <since_tizen> preview </since_tizen>
        public double EndAccelerationFactor
        {
            get
            {
                double begin = 1.0, end = 0.0;
                Interop.Elementary.elm_transit_tween_mode_factor_get(_handle, out begin, out end);
                return end;
            }
            set
            {
                Interop.Elementary.elm_transit_tween_mode_factor_set(_handle, BeginAccelerationFactor, value);
            }
        }

        /// <summary>
        /// Starts the transition in given seconds.
        /// Once this API is called, the transit begins to measure the time.
        /// </summary>
        /// <param name="interval">The interval value in seconds.</param>
        /// <since_tizen> preview </since_tizen>
        public void Go(double interval = 0)
        {
            if (interval == 0)
            {
                // To start transition immediately, elm_transit_go() is called.
                Interop.Elementary.elm_transit_go(_handle);
            }
            else
            {
                // elm_transit_go_in() uses timer so it does not start transition immediately although interval is 0.
                Interop.Elementary.elm_transit_go_in(_handle, interval);
            }
        }

        /// <summary>
        /// Pauses the transition.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public void Pause()
        {
            if (Interop.Elementary.elm_transit_paused_get(_handle) == false)
                Interop.Elementary.elm_transit_paused_set(_handle, true);
        }

        /// <summary>
        /// Resumes the transition.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public void Resume()
        {
            if (Interop.Elementary.elm_transit_paused_get(_handle) == true)
                Interop.Elementary.elm_transit_paused_set(_handle, false);
        }

        /// <summary>
        /// Gets the current chained transit list.
        /// </summary>
        /// <remarks>Cannot add the duplicate transit.</remarks>
        /// <since_tizen> preview </since_tizen>
        public IList<Transit> Chains
        {
            get { return _chains; }
        }

        /// <summary>
        /// Gets the objects list of the transit.
        /// </summary>
        /// <remarks>Cannot add the duplicate object.</remarks>
        /// <since_tizen> preview </since_tizen>
        public IList<EvasObject> Objects
        {
            get { return _objects; }
        }

        /// <summary>
        /// Adds the effect.
        /// </summary>
        /// <param name="effect">EffectBase object.</param>
        /// <since_tizen> preview </since_tizen>
        public void AddEffect(EffectBase effect)
        {
            IntPtr _effect = effect.CreateEffect(_handle);
            EffectEndCallback = (effectPtr, transitPtr) => { effect.SendEffectEnd(); };
            EffectTransitionCallback = (effectPtr, transitPtr, progress) => { };
            Interop.Elementary.elm_transit_effect_add(_handle, EffectTransitionCallback, _effect, EffectEndCallback);
        }

        /// <summary>
        /// Destroys the current object.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Releases all the resources currently used by this instance.
        /// </summary>
        /// <param name="disposing">
        /// true if the managed resources should be disposed,
        /// otherwise false.
        /// </param>
        /// <since_tizen> preview </since_tizen>
        protected virtual void Dispose(bool disposing)
        {
            if (_isDisposed)
                return;

            if (disposing)
            {
                ((INotifyCollectionChanged)_chains).CollectionChanged -= OnChaninCollectionChanged;
                _chains.Clear();
                ((INotifyCollectionChanged)_objects).CollectionChanged -= OnObjectCollectionChanged;
                _objects.Clear();
                _checker.Clear();
            }

            _isDisposed = true;
        }

        void OnObjectCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Add)
            {
                foreach (EvasObject item in e.NewItems)
                    AddObject(item);
            }
            else if (e.Action == NotifyCollectionChangedAction.Remove)
            {
                foreach (EvasObject item in e.OldItems)
                    RemoveObject(item);
            }
        }

        void OnChaninCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Add)
            {
                foreach (Transit item in e.NewItems)
                    AddChainedTransit(item);
            }
            else if (e.Action == NotifyCollectionChangedAction.Remove)
            {
                foreach (Transit item in e.OldItems)
                    DeleteChainedTransit(item);
            }
        }

        /// <summary>
        /// Adds a new object to apply the effects.
        /// After the first addition of an object to transit, if its object list becomes empty again, the transit will be killed.
        /// If the object belongs to another transit, the object will be removed from it and it will only belong to the other transit.
        /// </summary>
        /// <remarks>It is not allowed to add a new object after the transit begins.</remarks>
        /// <param name="obj">Object to be animated.</param>
        void AddObject(EvasObject obj)
        {
            if (_checker.Contains(obj))
                throw new InvalidOperationException("Cannot add the duplicate object.");

            _checker.Add(obj);
            Interop.Elementary.elm_transit_object_add(_handle, obj);
        }

        /// <summary>
        /// Removes an added object from the transit.
        /// </summary>
        /// <param name="obj">Object to be removed from transit.</param>
        void RemoveObject(EvasObject obj)
        {
            if (_checker.Contains(obj))
                _checker.Remove(obj);

            Interop.Elementary.elm_transit_object_remove(_handle, obj);
        }

        /// <summary>
        /// Makes the chain relationship between two transits.
        /// </summary>
        /// <param name="transit">The chain transit object. This transit will be operated after the transit is done.</param>
        void AddChainedTransit(Transit transit)
        {
            if (_checker.Contains(transit))
                throw new InvalidOperationException("Cannot add the duplicate transit.");

            _checker.Add(transit);
            Interop.Elementary.elm_transit_chain_transit_add(_handle, transit._handle);
        }

        /// <summary>
        /// Cuts off the chain relationship between two transits.
        /// </summary>
        /// <param name="transit">The chain transit object.</param>
        void DeleteChainedTransit(Transit transit)
        {
            if (_checker.Contains(transit))
                _checker.Remove(transit);

            Interop.Elementary.elm_transit_chain_transit_del(_handle, transit._handle);
        }
    }
}