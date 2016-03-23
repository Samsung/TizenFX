/// Copyright 2016 by Samsung Electronics, Inc.,
///
/// This software is the confidential and proprietary information
/// of Samsung Electronics, Inc. ("Confidential Information"). You
/// shall not disclose such Confidential Information and shall use
/// it only in accordance with the terms of the license agreement
/// you entered into with Samsung.


using System;

namespace Tizen.Applications
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class Application
    {
        private static Application s_CurrentApplication = null;

        private Interop.AppEvent.SafeAppEventHandle _lowMemoryNativeHandle;
        private Interop.AppEvent.SafeAppEventHandle _localeChangedNativeHandle;

        /// <summary>
        /// 
        /// </summary>
        public event EventHandler<LowMemoryEventArgs> LowMemory;

        /// <summary>
        /// 
        /// </summary>
        public event EventHandler<LocaleChangedEventArgs> LocaleChanged;

        /// <summary>
        /// 
        /// </summary>
        public static Application Current { get { return s_CurrentApplication; } }

        /// <summary>
        /// 
        /// </summary>
        public ApplicationInfo ApplicationInfo { get; internal set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        public virtual void Run(string[] args)
        {
            s_CurrentApplication = this;

            Interop.AppEvent.AddEventHandler(Interop.AppEvent.EventNames.LowMemory, HandleAppEvent, IntPtr.Zero, out _lowMemoryNativeHandle);
            Interop.AppEvent.AddEventHandler(Interop.AppEvent.EventNames.LowMemory, HandleAppEvent, IntPtr.Zero, out _localeChangedNativeHandle);
        }

        /// <summary>
        /// 
        /// </summary>
        public abstract void Exit();

        internal void SendCreate()
        {
            ApplicationInfo = new ApplicationInfo();
            OnCreate();
        }
        protected virtual void OnCreate()
        {
        }

        protected virtual void OnTerminate()
        {
        }

        protected virtual void OnStart(AppControl control)
        {
        }

        protected virtual void OnLowMemory(LowMemoryEventArgs e)
        {
            EventHandler<LowMemoryEventArgs> eh = LowMemory;
            if (eh != null)
            {
                eh(this, e);
            }
        }

        protected virtual void OnLocaleChanged(LocaleChangedEventArgs e)
        {
            EventHandler<LocaleChangedEventArgs> eh = LocaleChanged;
            if (eh != null)
            {
                eh(this, e);
            }
        }

        private void HandleAppEvent(string eventName, IntPtr eventData, IntPtr data)
        {
            Bundle b = new Bundle(eventData);
            if (eventName == Interop.AppEvent.EventNames.LowMemory)
            {
                string value = b.GetItem<string>(Interop.AppEvent.EventKeys.LowMemory);
                LowMemoryStatus status = LowMemoryStatus.Normal;
                if (value == Interop.AppEvent.EventValues.MemorySoftWarning)
                {
                    status = LowMemoryStatus.SoftWarning;
                }
                else if (value == Interop.AppEvent.EventValues.MemoryHardWarning)
                {
                    status = LowMemoryStatus.HardWarning;
                }
                OnLowMemory(new LowMemoryEventArgs { LowMemoryStatus = status });
            }
            else if (eventName == Interop.AppEvent.EventNames.LanguageSet)
            {
                string value = b.GetItem<string>(Interop.AppEvent.EventKeys.LanguageSet);
                OnLocaleChanged(new LocaleChangedEventArgs { Locale = value });
            }
        }
    }
}
