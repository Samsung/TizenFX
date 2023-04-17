/*
 * Copyright (c) 2023 Samsung Electronics Co., Ltd All Rights Reserved
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
using System.ComponentModel;
using Tizen.Applications;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI
{
    /// <summary>
    /// This class represents a NUIGadget controlled lifecycles.
    /// </summary>
    /// <since_tizen> 10 </since_tizen>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public abstract class NUIGadget
    {
        /// <summary>
        /// Initializes the gadget.
        /// </summary>
        /// /// <param name="type">The type of the NUIGadget.</param>
        /// <since_tizen> 10 </since_tizen>
        public NUIGadget(NUIGadgetType type)
        {
            Type = type;
            State = NUIGadgetLifecycleState.Initialized;
        }

        internal event EventHandler<NUIGadgetLifecycleChangedEventArgs> LifecycleChanged;

        /// <summary>
        /// Gets the class representing information of the current gadget.
        /// </summary>
        /// <remarks> This property is set before the OnCreate() is called, after the instance has been created. </remarks>
        /// <since_tizen> 10 </since_tizen>
        public NUIGadgetInfo NUIGadgetInfo
        {
            internal set;
            get;
        }

        /// <summary>
        /// Gets the type.
        /// </summary>
        /// <since_tizen> 10 </since_tizen>
        public NUIGadgetType Type
        {
            internal set;
            get;
        }

        /// <summary>
        /// Gets the class name.
        /// </summary>
        /// <remarks> This property is set before the OnCreate() is called, after the instance has been created. </remarks>
        /// <since_tizen> 10 </since_tizen>
        public string ClassName
        {
            internal set;
            get;
        }

        /// <summary>
        /// Gets the main view.
        /// </summary>
        /// <since_tizen> 10 </since_tizen>
        public View MainView
        {
            internal set;
            get;
        }

        /// <summary>
        /// Gets the lifecycle state.
        /// </summary>
        /// <since_tizen> 10 </since_tizen>
        public NUIGadgetLifecycleState State
        {
            internal set;
            get;
        }

        /// <summary>
        /// Gets the resource manager.
        /// </summary>
        /// <remarks> This property is set before the OnCreate() is called, after the instance has been created. </remarks>
        /// <since_tizen> 10 </since_tizen>
        public NUIGadgetResourceManager NUIGadgetResourceManager
        {
            internal set;
            get;
        }

        internal bool Create()
        {
            MainView = OnCreate();
            if (MainView == null)
            {
                return false;
            }

            return true;
        }

        internal void Resume()
        {
            if (State == NUIGadgetLifecycleState.Created || State == NUIGadgetLifecycleState.Paused)
                OnResume();
        }

        internal void Pause()
        {
            if (State == NUIGadgetLifecycleState.Resumed)
                OnPause();
        }

        internal void Destroy()
        {
            if (State == NUIGadgetLifecycleState.Created || State == NUIGadgetLifecycleState.Paused)
                OnDestroy();
        }

        internal void HandleAppControlReceivedEvent(AppControlReceivedEventArgs args)
        {
            OnAppControlReceived(args);
        }

        internal void HandleEvents(NUIGadgetEventType eventType, EventArgs args)
        {
            switch (eventType)
            {
                case NUIGadgetEventType.LocaleChanged:
                    OnLocaleChanged((LocaleChangedEventArgs)args);
                    break;
                case NUIGadgetEventType.LowMemory:
                    OnLowMemory((LowMemoryEventArgs)args);
                    break;
                case NUIGadgetEventType.LowBattery:
                    OnLowBattery((LowBatteryEventArgs)args);
                    break;
                case NUIGadgetEventType.RegionFormatChanged:
                    OnRegionFormatChanged((RegionFormatChangedEventArgs)args);
                    break;
                case NUIGadgetEventType.DeviceORientationChanged:
                    OnDeviceOrientationChanged((DeviceOrientationEventArgs)args);
                    break;
                default:
                    Log.Warn("Unknown Event Type: " + eventType);
                    break;
            }
        }

        private void NotifyLifecycleChanged()
        {
            var args = new NUIGadgetLifecycleChangedEventArgs();
            args.State = State;
            args.Gadget = this;
            LifecycleChanged?.Invoke(null, args);
        }

        /// <summary>
        /// Overrides this method if want to handle behavior when the gedget is started.
        /// If 'base.OnCreate()' is not called, the event 'NUIGadgetLifecycleChanged' with  the 'NUIGadgetLifecycleState.Created' state will not be emitted.
        /// </summary>
        /// <returns>The main view object.</returns>
        /// <since_tizen> 10 </since_tizen>
        protected virtual Tizen.NUI.BaseComponents.View OnCreate()
        {
            State = NUIGadgetLifecycleState.Created;
            NotifyLifecycleChanged();
            return null;
        }

        /// <summary>
        /// Overrides this method if want to handle behavior when the gadget receives the appcontrol message.
        /// </summary>
        /// <param name="e">The appcontrol received event argument.</param>
        /// <since_tizen> 10 </since_tizen>
        protected virtual void OnAppControlReceived(AppControlReceivedEventArgs e)
        {
        }

        /// <summary>
        /// Overrides this method if want to handle behavior when the gadget is destroyed.
        /// If 'base.OnDestroy()' is not called. the event 'NUIGadgetLifecycleChanged' with the 'NUIGadgetLifecycleState.Destroyed' state will not be emitted.
        /// </summary>
        /// <since_tizen> 10 </since_tizen>
        protected virtual void OnDestroy()
        {
            State = NUIGadgetLifecycleState.Destroyed;
            NotifyLifecycleChanged();
        }

        /// <summary>
        /// Overrides this method if want to handle behavior when the gadget is paused.
        /// If 'base.OnPause()' is not called. the event 'NUIGadgetLifecycleChanged' with the 'NUIGadgetLifecycleState.Paused' state will not be emitted.
        /// </summary>
        /// <since_tizen> 10 </since_tizen>
        protected virtual void OnPause()
        {
            State = NUIGadgetLifecycleState.Paused;
            NotifyLifecycleChanged();
        }

        /// <summary>
        /// Overrides this method if want to handle behavior when the gadget is resumed.
        /// If 'base.OnResume()' is not called. the event 'NUIGadgetLifecycleChanged' with the 'NUIGadgetLifecycleState.Resumed' state will not be emitted.
        /// </summary>
        /// <since_tizen> 10 </since_tizen>
        protected virtual void OnResume()
        {
            State = NUIGadgetLifecycleState.Resumed;
            NotifyLifecycleChanged();
        }

        /// <summary>
        /// Overrides this method if want to handle behavior when the system language is changed.
        /// </summary>
        /// <param name="e">The locale changed event argument.</param>
        /// <since_tizen> 10 </since_tizen>
        protected virtual void OnLocaleChanged(LocaleChangedEventArgs e)
        {
        }

        /// <summary>
        /// Overrides this method if want to handle behavior when the system battery is low.
        /// </summary>
        /// <param name="e">The low batter event argument.</param>
        /// <since_tizen> 10 </since_tizen>
        protected virtual void OnLowBattery(LowBatteryEventArgs e)
        {
        }

        /// <summary>
        /// Overrides this method if want to handle behavior when the system memory is low.
        /// </summary>
        /// <param name="e">The low memory event argument.</param>
        /// <since_tizen> 10 </since_tizen>
        protected virtual void OnLowMemory(LowMemoryEventArgs e)
        {
        }

        /// <summary>
        /// Overrides this method if want to handle behavior when the region format is changed.
        /// </summary>
        /// <param name="e">The region format changed event argument.</param>
        /// <since_tizen> 10 </since_tizen>
        protected virtual void OnRegionFormatChanged(RegionFormatChangedEventArgs e)
        {
        }

        /// <summary>
        /// Overrides this method if want to handle behavior when the device orientation is changed.
        /// </summary>
        /// <param name="e">The device orientation changed event argument.</param>
        /// <since_tizen> 10 </since_tizen>
        protected virtual void OnDeviceOrientationChanged(DeviceOrientationEventArgs e)
        {
        }

        /// <summary>
        /// Finishes the gadget.
        /// </summary>
        /// <since_tizen> 10 </since_tizen>
        public void Finish()
        {
            Pause();
            Destroy();
        }
    }
}
