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
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.Loader;
using Tizen.NUI.BaseComponents;

namespace Tizen.Applications
{
    internal class TeamAssemblyLoadContext : AssemblyLoadContext
    {
        public TeamAssemblyLoadContext() : base(isCollectible: true) { }

        protected override Assembly Load(AssemblyName name) => null;
    }

    internal class AssemblyInfo
    {
        public Assembly Assembly { get; }
        public string Path { get; }
        public WeakReference LoadContextRef { get; }

        public AssemblyInfo(Assembly assembly, string path, WeakReference contextRef)
        {
            Assembly = assembly;
            Path = path;
            LoadContextRef = contextRef;
        }
    }

    internal class ViewInfo
    {
        public View View { get; set; }
        public string Appid { get; set; }
        public bool Owned { get; set; }
    }

    public static class TeamManager
    {
        private const string LogTag = "DN_TAM";
        private static readonly Dictionary<IntPtr, AssemblyInfo> _assemblies = new Dictionary<IntPtr, AssemblyInfo>();
        private static readonly Dictionary<string, IntPtr> _assembliesByPath = new Dictionary<string, IntPtr>();
        private static readonly Dictionary<IntPtr, IntPtr> _argHandles = new Dictionary<IntPtr, IntPtr>();
        private static readonly HashSet<TeamApplication> _runningApps = new HashSet<TeamApplication>();
        private static readonly object _lock = new object();
        private static int _assemblyId = 1;

        private static readonly Dictionary<int, ViewInfo> _viewInfos = new Dictionary<int, ViewInfo>();
        private static readonly Dictionary<string, int> _viewByAppId = new Dictionary<string, int>();
        private static int _viewIdCounter = 1;

        internal static IntPtr RegisterAssemblyInfo(AssemblyInfo info)
        {
            lock (_lock)
            {
                IntPtr id = new IntPtr(_assemblyId);
                _assemblies[id] = info;
                _assembliesByPath[info.Path] = id;

                Log.Info(LogTag, $"Assembly registered - ID: {_assemblyId}, Path: {info.Path}");

                _assemblyId++;
                return id;
            }
        }

        internal static void UnregisterAssembly(IntPtr id)
        {
            lock (_lock)
            {
                if (_assemblies.TryGetValue(id, out var info))
                {
                    _assembliesByPath.Remove(info.Path);
                }
                _assemblies.Remove(id);
            }
        }

        internal static AssemblyInfo GetAssembly(IntPtr id)
        {
            lock (_lock)
            {
                if (_assemblies.TryGetValue(id, out var info))
                {
                    return info;
                }
            }
            return null;
        }

        public static void Init(string[] args)
        {
            TeamLoop.Run(args);
        }

        public static bool IsInit()
        {
            return TeamLoop.IsRunning();
        }

        internal static IntPtr GetAssemblyIdByPath(string path)
        {
            lock (_lock)
            {
                if (_assembliesByPath.TryGetValue(path, out var id))
                {
                    return id;
                }
            }
            return IntPtr.Zero;
        }

        internal static void RegisterArgHandle(IntPtr id, IntPtr argHandle)
        {
            lock (_lock)
            {
                _argHandles[id] = argHandle;
                Log.Info(LogTag, $"ArgHandle registered - ID: {id}, ArgHandle: {argHandle}");
            }
        }

        internal static void UnregisterArgHandle(IntPtr id)
        {
            lock (_lock)
            {
                _argHandles.Remove(id);
                Log.Info(LogTag, $"ArgHandle unregistered - ID: {id}");
            }
        }

        internal static IntPtr GetArgHandle(IntPtr id)
        {
            lock (_lock)
            {
                if (_argHandles.TryGetValue(id, out var argHandle))
                {
                    return argHandle;
                }
            }
            return IntPtr.Zero;
        }

        internal static void RegisterRunningTeamApp(TeamApplication app)
        {
            lock (_lock)
            {
                if (_runningApps.Add(app))
                {
                    Log.Info(LogTag, $"TeamApplication registered");
                }
            }
        }

        internal static void UnRegisterRunningTeamApp(TeamApplication app)
        {
            lock (_lock)
            {
                if (_runningApps.Remove(app))
                {
                    Log.Info(LogTag, $"TeamApplication unregistered");
                }
            }
        }

        public static int AddView(View view, string appid)
        {
            if (view == null)
                throw new ArgumentNullException(nameof(view));
            if (string.IsNullOrEmpty(appid))
                throw new ArgumentNullException(nameof(appid));

            lock (_lock)
            {
                if (_viewByAppId.ContainsKey(appid))
                {
                    throw new ArgumentException($"AppId '{appid}' already exists.", nameof(appid));
                }

                int id = _viewIdCounter++;
                _viewInfos[id] = new ViewInfo { View = view, Appid = appid, Owned = false };
                _viewByAppId[appid] = id;

                Log.Info(LogTag, $"View added - ID: {id}, AppId: {appid}");
                return id;
            }
        }

        public static bool RemoveView(int id)
        {
            lock (_lock)
            {
                if (_viewInfos.TryGetValue(id, out var info))
                {
                    _viewInfos.Remove(id);
                    _viewByAppId.Remove(info.Appid);
                    Log.Info(LogTag, $"View removed - ID: {id}, Appid: {info.Appid}");
                    return true;
                }
                return false;
            }
        }

        public static View OwnViewApp(string appid)
        {
            if (string.IsNullOrEmpty(appid))
                throw new ArgumentNullException(nameof(appid));

            lock (_lock)
            {
                if (_viewByAppId.TryGetValue(appid, out var id))
                {
                    if (_viewInfos.TryGetValue(id, out var info))
                    {
                        if (info.Owned)
                        {
                            Log.Error(LogTag, $"View already owned - AppId: {appid}");
                            return null;
                        }
                        info.Owned = true;
                        Log.Info(LogTag, $"View owned - AppId: {appid}");
                        return info.View;
                    }
                }
                Log.Warn(LogTag, $"View not found for own - AppId: {appid}");
                return null;
            }
        }

        public static void DisownViewApp(string appid)
        {
            if (string.IsNullOrEmpty(appid))
                throw new ArgumentNullException(nameof(appid));

            lock (_lock)
            {
                if (_viewByAppId.TryGetValue(appid, out var id))
                {
                    if (_viewInfos.TryGetValue(id, out var info))
                    {
                        if (!info.Owned)
                        {
                            Log.Error(LogTag, $"View already disowned - AppId: {appid}");
                            return;
                        }
                        info.Owned = false;
                        Log.Info(LogTag, $"View disowned - AppId: {appid}");
                    }
                }
                else
                {
                    Log.Warn(LogTag, $"View not found for disown - AppId: {appid}");
                }
            }
        }

    }
}
