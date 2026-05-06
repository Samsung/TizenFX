/*
 * Copyright (c) 2026 Samsung Electronics Co., Ltd All Rights Reserved
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
using Tizen.Internals;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.Applications.CoreBackend;

namespace Tizen.Applications
{
    /// <summary>
    /// Backend implementation for Team view applications that render into a shared host-provided <see cref="View"/>.
    /// </summary>
    internal class TeamViewCoreBackend : TeamCoreBackend
    {
        internal new static string LogTag = "DN_TAM";
        private Interop.TeamMember.ViewMemberLifecycleCallbacks _callbacks;
        private bool _disposedValue = false;
        private int DefaultViewId = 0;
        internal View DefaultView;
        internal override IntPtr MemberHandle => _memberHandle;
        internal override IntPtr LoadObjId => _loadObjId;
        internal override IntPtr ArgHandle => _argHandle;

        private Interop.TeamMember.ViewAppCreateCallback _onCreateNative;
        private Interop.TeamMember.AppTerminateCallback _onTerminateNative;
        private Interop.TeamMember.AppControlCallback _onAppControlNative;
        private Interop.TeamMember.AppResumeCallback _onResumeNative;
        private Interop.TeamMember.AppPauseCallback _onPauseNative;
        private Interop.TeamMember.AppLowMemoryCallback _onLowMemoryNative;
        private Interop.TeamMember.AppLowBatteryCallback _onLowBatteryNative;
        private Interop.TeamMember.AppLanguageChangedCallback _onLanguageChangedNative;
        private Interop.TeamMember.AppDeviceOrientationChangedCallback _onDeviceOrientationChangedNative;
        private Interop.TeamMember.AppRegionFormatChangedCallback _onRegionFormatChangedNative;
        private Interop.TeamMember.AppSuspendStateChangedCallback _onSuspendStateChangedNative;
        private Interop.TeamMember.AppTimeZoneChangedCallback _onTimeZoneChangedNative;

        public TeamViewCoreBackend()
        {
            _onCreateNative = new Interop.TeamMember.ViewAppCreateCallback(OnCreateNative);
            _onTerminateNative = new Interop.TeamMember.AppTerminateCallback(OnTerminateNative);
            _onAppControlNative = new Interop.TeamMember.AppControlCallback(OnAppControlNative);
            _onResumeNative = new Interop.TeamMember.AppResumeCallback(OnResumeNative);
            _onPauseNative = new Interop.TeamMember.AppPauseCallback(OnPauseNative);
            _onLowMemoryNative = new Interop.TeamMember.AppLowMemoryCallback(OnLowMemoryNative);
            _onLowBatteryNative = new Interop.TeamMember.AppLowBatteryCallback(OnLowBatteryNative);
            _onLanguageChangedNative = new Interop.TeamMember.AppLanguageChangedCallback(OnLanguageChangedNative);
            _onDeviceOrientationChangedNative = new Interop.TeamMember.AppDeviceOrientationChangedCallback(OnDeviceOrientationChangedNative);
            _onRegionFormatChangedNative = new Interop.TeamMember.AppRegionFormatChangedCallback(OnRegionFormatChangedNative);
            _onSuspendStateChangedNative = new Interop.TeamMember.AppSuspendStateChangedCallback(OnSuspendStateChangedNative);
            _onTimeZoneChangedNative = new Interop.TeamMember.AppTimeZoneChangedCallback(OnTimeZoneChangedNative);

            _callbacks.Create = _onCreateNative;
            _callbacks.Terminate = _onTerminateNative;
            _callbacks.Control = _onAppControlNative;
            _callbacks.Resume = _onResumeNative;
            _callbacks.Pause = _onPauseNative;
            _callbacks.LowMemory = _onLowMemoryNative;
            _callbacks.LowBattery = _onLowBatteryNative;
            _callbacks.LanguageChanged = _onLanguageChangedNative;
            _callbacks.DeviceOrientationChanged = _onDeviceOrientationChangedNative;
            _callbacks.RegionFormatChanged = _onRegionFormatChangedNative;
            _callbacks.SuspendStateChanged = _onSuspendStateChangedNative;
            _callbacks.TimezoneChanged = _onTimeZoneChangedNative;
        }
        public View GetDefaultView()
        {
            return DefaultView;
        }

        public int GetDefaultViewId()
        {
            return DefaultViewId;
        }
        internal void SetDefaultView(View view, string memberInstId)
        {
            DefaultView = view;
            DefaultViewId = TeamManager.AddView(view, memberInstId);
        }
        internal void UnsetDefaultView()
        {
            TeamManager.RemoveView(DefaultViewId);
        }
        public override void Exit()
        {
            if (_memberHandle != IntPtr.Zero)
            {
                Interop.TeamMember.ViewMemberQuit(_memberHandle);
                _memberHandle = IntPtr.Zero;
            }
        }

        public override void Run(string[] args)
        {
            // base.Run() is not required.
            if (!TeamManager.IsInit())
            {
              Log.Error("DN_TAM", $"Team Loop is not running!. Launch app via launcher.");
              return;
            }

            if (args == null || args.Length == 0)
            {
                Log.Error(LogTag, "args is null or empty");
                return;
            }

            _loadObjId = TeamManager.GetAssemblyIdByPath(args[0]);
            _argHandle = Interop.TeamMember.ViewMemberTeamup(_callbacks, IntPtr.Zero);
            TeamManager.RegisterArgHandle(_loadObjId, _argHandle);
            Log.Info(LogTag, $"path: {args[0]}, id: {_loadObjId}, arg_h: {_argHandle}");
        }

        protected override void Dispose(bool disposing)
        {
            if (!_disposedValue)
            {
                if (disposing)
                {
                    // Release disposable objects
                }

                if (_memberHandle != IntPtr.Zero)
                {
                    Interop.TeamMember.ViewMemberQuit(_memberHandle);
                    _memberHandle = IntPtr.Zero;
                }

                _disposedValue = true;
            }
        }

        private IntPtr OnCreateNative(IntPtr context, IntPtr userdata)
        {
            if (_memberHandle != IntPtr.Zero)
            {
                Log.Warn(LogTag, "OnCreate called twice!");
            }
            _memberHandle = context;

            if (Handlers.ContainsKey(EventType.Created))
            {
                var handler = Handlers[EventType.Created] as Action;
                if (handler != null)
                {
                    // This function will set default window
                    try
                    {
                        var view = new View();
                        Interop.TeamManager.TeamAppGetAppInstanceId(_memberHandle, out string appInstId);
                        SetDefaultView(view, appInstId);

                        try {
                          handler?.Invoke();
                        }
                        catch (Exception ex)
                        {
                          Log.Error(LogTag, $"Error in User Created handler: {ex.Message}");
                          Log.Error(LogTag, $"{ex.StackTrace}");
                        }

                        IntPtr view_h = Interop.TeamManager.CreateViewByViewId(GetDefaultViewId());

                        if (view_h != IntPtr.Zero)
                        {
                            view.AggregatedVisibilityChanged += (sender, e) =>
                            {
                                Log.Info(LogTag, $"View Visibility Changed: {e.Visibility}");
                                Interop.TeamManager.InvokeViewVisibilityEvent(DefaultViewId, e.Visibility);
                            };
                        }

                        return view_h;
                    }
                    catch (Exception ex)
                    {
                        Log.Error(LogTag, $"Error in Internal Created handler: {ex.Message}");
                        Log.Error(LogTag, $"{ex.StackTrace}");
                        return IntPtr.Zero;
                    }
                }
                else
                {
                    Log.Error(LogTag, "Invalid OnCreate Callback type");
                    return IntPtr.Zero;
                }
            }

            Log.Error(LogTag, "No OnCreate Callback");
            return IntPtr.Zero;
        }

        private void OnTerminateNative(IntPtr context, IntPtr userdata)
        {
            if (Handlers.ContainsKey(EventType.Terminated))
            {
                var handler = Handlers[EventType.Terminated] as Action;
                try
                {
                    handler?.Invoke();
                }
                catch (Exception ex)
                {
                    Log.Error(LogTag, $"Error in Terminated handler: {ex.Message}");
                    Log.Error(LogTag, $"{ex.StackTrace}");
                }
            }

            UnsetDefaultView();
            Interop.TeamManager.DestroyViewByViewId(GetDefaultViewId());
        }

        private void OnAppControlNative(IntPtr context, IntPtr appControl, IntPtr userdata)
        {
            if (Handlers.ContainsKey(EventType.AppControlReceived))
            {
                using (SafeAppControlHandle safeHandle = new SafeAppControlHandle(appControl, false))
                {
                    var handler = Handlers[EventType.AppControlReceived] as Action<AppControlReceivedEventArgs>;
                    try
                    {
                        handler?.Invoke(new AppControlReceivedEventArgs(new ReceivedAppControl(safeHandle)));
                    }
                    catch (Exception ex)
                    {
                        Log.Error(LogTag, $"Error in AppControlReceived handler: {ex.Message}");
                        Log.Error(LogTag, $"{ex.StackTrace}");
                    }
                }
            }
        }

        private void OnResumeNative(IntPtr context, IntPtr userdata)
        {
            if (Handlers.ContainsKey(EventType.Resumed))
            {
                var handler = Handlers[EventType.Resumed] as Action;
                try
                {
                    handler?.Invoke();
                }
                catch (Exception ex)
                {
                    Log.Error(LogTag, $"Error in Resumed handler: {ex.Message}");
                    Log.Error(LogTag, $"{ex.StackTrace}");
                }
            }
        }

        private void OnPauseNative(IntPtr context, IntPtr userdata)
        {
            if (Handlers.ContainsKey(EventType.Paused))
            {
                var handler = Handlers[EventType.Paused] as Action;
                try
                {
                    handler?.Invoke();
                }
                catch (Exception ex)
                {
                    Log.Error(LogTag, $"Error in Paused handler: {ex.Message}");
                    Log.Error(LogTag, $"{ex.StackTrace}");
                }
            }
        }

        private void OnLowMemoryNative(IntPtr context, int status, IntPtr userdata)
        {
            LowMemoryStatus lowMemoryStatus = (LowMemoryStatus)status;
            if (Handlers.ContainsKey(EventType.LowMemory))
            {
                var handler = Handlers[EventType.LowMemory] as Action<LowMemoryEventArgs>;
                try
                {
                    handler?.Invoke(new LowMemoryEventArgs(lowMemoryStatus));
                }
                catch (Exception ex)
                {
                    Log.Error(LogTag, $"Error in LowMemory handler: {ex.Message}");
                    Log.Error(LogTag, $"{ex.StackTrace}");
                }
            }
        }

        private void OnLowBatteryNative(IntPtr context, int status, IntPtr userdata)
        {
            LowBatteryStatus lowBatteryStatus = (LowBatteryStatus)status;
            if (Handlers.ContainsKey(EventType.LowBattery))
            {
                var handler = Handlers[EventType.LowBattery] as Action<LowBatteryEventArgs>;
                try
                {
                    handler?.Invoke(new LowBatteryEventArgs(lowBatteryStatus));
                }
                catch (Exception ex)
                {
                    Log.Error(LogTag, $"Error in LowBattery handler: {ex.Message}");
                    Log.Error(LogTag, $"{ex.StackTrace}");
                }
            }
        }

        private void OnLanguageChangedNative(IntPtr context, string language, IntPtr userdata)
        {
            if (Handlers.ContainsKey(EventType.LocaleChanged))
            {
                var handler = Handlers[EventType.LocaleChanged] as Action<LocaleChangedEventArgs>;
                try
                {
                    handler?.Invoke(new LocaleChangedEventArgs(language));
                }
                catch (Exception ex)
                {
                    Log.Error(LogTag, $"Error in LocaleChanged handler: {ex.Message}");
                    Log.Error(LogTag, $"{ex.StackTrace}");
                }
            }
        }

        private void OnDeviceOrientationChangedNative(IntPtr context, int status, IntPtr userdata)
        {
            DeviceOrientation orientation = (DeviceOrientation)status;
            if (Handlers.ContainsKey(EventType.DeviceOrientationChanged))
            {
                var handler = Handlers[EventType.DeviceOrientationChanged] as Action<DeviceOrientationEventArgs>;
                try
                {
                    handler?.Invoke(new DeviceOrientationEventArgs(orientation));
                }
                catch (Exception ex)
                {
                    Log.Error(LogTag, $"Error in DeviceOrientationChanged handler: {ex.Message}");
                    Log.Error(LogTag, $"{ex.StackTrace}");
                }
            }
        }

        private void OnRegionFormatChangedNative(IntPtr context, string region, IntPtr userdata)
        {
            if (Handlers.ContainsKey(EventType.RegionFormatChanged))
            {
                var handler = Handlers[EventType.RegionFormatChanged] as Action<RegionFormatChangedEventArgs>;
                try
                {
                    handler?.Invoke(new RegionFormatChangedEventArgs(region));
                }
                catch (Exception ex)
                {
                    Log.Error(LogTag, $"Error in RegionFormatChanged handler: {ex.Message}");
                    Log.Error(LogTag, $"{ex.StackTrace}");
                }
            }
        }

        private void OnSuspendStateChangedNative(IntPtr context, int status, IntPtr userdata)
        {
            SuspendedState state = (SuspendedState)status;
            if (Handlers.ContainsKey(EventType.SuspendedStateChanged))
            {
                var handler = Handlers[EventType.SuspendedStateChanged] as Action<SuspendedStateEventArgs>;
                try
                {
                    handler?.Invoke(new SuspendedStateEventArgs(state));
                }
                catch (Exception ex)
                {
                    Log.Error(LogTag, $"Error in SuspendedStateChanged handler: {ex.Message}");
                    Log.Error(LogTag, $"{ex.StackTrace}");
                }
            }
        }

        private void OnTimeZoneChangedNative(IntPtr context, string timeZone, string timeZoneId, IntPtr userdata)
        {
            if (Handlers.ContainsKey(EventType.TimeZoneChanged))
            {
                var handler = Handlers[EventType.TimeZoneChanged] as Action<TimeZoneChangedEventArgs>;
                try
                {
                    handler?.Invoke(new TimeZoneChangedEventArgs(timeZone, timeZoneId));
                }
                catch (Exception ex)
                {
                    Log.Error(LogTag, $"Error in TimeZoneChanged handler: {ex.Message}");
                    Log.Error(LogTag, $"{ex.StackTrace}");
                }
            }
        }
    }
}