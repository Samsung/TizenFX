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
using System.ComponentModel;
using System.Threading;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Runtime.Loader;
using System.Text;
using Tizen.NUI;

namespace Tizen.Applications
{
    /// <summary>
    /// Provides the entry point to the native Team main loop and the dynamic assembly load/unload callbacks.
    /// </summary>
    /// This will be public opened in next tizen after ACR done. (Before ACR, need to be hidden as inhouse API)
    [EditorBrowsable(EditorBrowsableState.Never)]
    public static class TeamLoop
    {
        private const string LogTag = "DN_TAM";
        private static Interop.TeamLoop.TeamLoopOperations _ops;
        private static bool _isRunning = false;
        private static string[] _systemArgs = null;

        static TeamLoop()
        {
            Log.Info(LogTag, "TeamLoop static constructor called");
            _ops.Load = new Interop.TeamLoop.TeamLoopOpsLoad(DoLoad);
            _ops.Unload = new Interop.TeamLoop.TeamLoopOpsUnload(DoUnload);
            _ops.CreateArgs = new Interop.TeamLoop.TeamLoopOpsCreateArgs(DoCreateArgs);
            _ops.OnLoopCreate = new Interop.TeamLoop.TeamLoopOpsOnLoopCreate(DoOnLoopCreate);
            _ops.OnLoopTerminate = new Interop.TeamLoop.TeamLoopOpsOnLoopTerminate(DoOnLoopTerminate);
        }
        /// <summary>
        /// Starts the Team main loop. Subsequent calls while the loop is running are no-ops.
        /// </summary>
        /// <param name="args">Arguments passed to the native Team loop.</param>
        /// This will be public opened in next tizen after ACR done. (Before ACR, need to be hidden as inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static void Run(string[] args)
        {
            Log.Info(LogTag, $"Run() called - Already Running: {_isRunning}");
            if(_isRunning)
            {
              return;
            }

            _isRunning = true;
            _systemArgs = args;

            NUIApplicationInitializer.StaticInitialize();

            var err = Interop.TeamLoop.Main(args.Length, args, _ops);
            if (err != 0)
            {
              Log.Error(LogTag, "Failed to Initialize TeamLoop");
            }
            else
            {
              Log.Info(LogTag, "TeamLoop Run");
            }
        }

        /// <summary>
        /// Gets a value indicating whether the Team main loop is currently running.
        /// </summary>
        /// <returns><c>true</c> if the main loop is running; otherwise, <c>false</c>.</returns>
        /// This will be public opened in next tizen after ACR done. (Before ACR, need to be hidden as inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static bool IsRunning()
        {
          Log.Info(LogTag, $"IsRunning() called - Result: {_isRunning}");
          return _isRunning;
        }

        internal static IntPtr DoLoad(string path)
        {
            if (string.IsNullOrEmpty(path))
            {
                Log.Error(LogTag, "Invalid path: null or empty");
                return IntPtr.Zero;
            }

            try
            {
                Log.Info(LogTag, $"Loading assembly: {path}");

                TeamAssemblyLoadContext context = new TeamAssemblyLoadContext();
                WeakReference contextRef = new WeakReference(context);

                Assembly assembly = context.LoadFromAssemblyPath(path);

                var info = new AssemblyInfo(assembly, path, contextRef);
                IntPtr id = TeamManager.RegisterAssemblyInfo(info);

                Log.Info(LogTag, $"Assembly loaded successfully: {path}, ID: {id}");
                return id;
            }
            catch (Exception e)
            {
                Log.Error(LogTag, $"Failed to load assembly: {path}, Error: {e.Message}");
                return IntPtr.Zero;
            }
        }

        internal static void DoUnload(IntPtr loadObj)
        {
            if (loadObj == IntPtr.Zero)
            {
                Log.Error(LogTag, "Invalid loadObj: IntPtr.Zero");
                return;
            }

            var assemblyInfo = TeamManager.GetAssembly(loadObj);
            if (assemblyInfo == null)
            {
                Log.Error(LogTag, $"Assembly not found for id: {loadObj}");
                return;
            }

            Log.Info(LogTag, $"Unloading assembly - ID: {loadObj}, Path: {assemblyInfo.Path}");

            if (assemblyInfo.LoadContextRef.IsAlive)
            {
                var context = assemblyInfo.LoadContextRef.Target as TeamAssemblyLoadContext;
                context.Unload();
                Log.Info(LogTag, $"AssemblyLoadContext unloaded - ID: {loadObj}");
            }
            else
            {
                Log.Warn(LogTag, $"AssemblyLoadContext already collected - ID: {loadObj}");
            }

            TeamManager.UnregisterAssembly(loadObj);

            GC.Collect();
            GC.WaitForPendingFinalizers();

            Log.Info(LogTag, $"Assembly unloaded - ID: {loadObj}, Path: {assemblyInfo.Path}");
        }

        internal static IntPtr DoCreateArgs(IntPtr loadObj)
        {
            if (loadObj == IntPtr.Zero)
            {
                Log.Error(LogTag, "Invalid loadObj id: IntPtr.Zero");
                return IntPtr.Zero;
            }

            var assemblyInfo = TeamManager.GetAssembly(loadObj);
            if (assemblyInfo == null)
            {
                Log.Error(LogTag, $"Assembly not found for id: {loadObj}");
                return IntPtr.Zero;
            }

            try
            {
                var mainMethod = assemblyInfo.Assembly.EntryPoint;
                Log.Info(LogTag, $"Main method {mainMethod?.Name}");

                if (mainMethod == null)
                {
                    Log.Error(LogTag, $"Entry point not found in assembly: {assemblyInfo.Path}");
                    return IntPtr.Zero;
                }

                string[] args = (string[])GetSystemArgs().Clone();
                args[0] = TeamManager.GetAssembly(loadObj).Path;
                Log.Info(LogTag, $"args count: {args.Length}");
                for (int i = 0; i < args.Length; i++)
                {
                    Log.Info(LogTag, $" args[{i}] = {args[i]}");
                }

                mainMethod.Invoke(null, new object[] { args });

                var argHandle = TeamManager.GetArgHandle(loadObj);
                Log.Info(LogTag, $"Main method invoked successfully - ID: {loadObj}, Result: {argHandle}");
                return argHandle;
            }
            catch (Exception e)
            {
                Log.Error(LogTag, $"Failed to invoke Main method - ID: {loadObj}, Error: {e.Message}");
                return IntPtr.Zero;
            }
        }

        /// <summary>
        /// Gets the command line arguments that were passed to <see cref="Run(string[])"/>.
        /// </summary>
        /// <returns>The arguments array, or <c>null</c> if <see cref="Run(string[])"/> has not been invoked.</returns>
        /// This will be public opened in next tizen after ACR done. (Before ACR, need to be hidden as inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static string[] GetSystemArgs()
        {
            Log.Info(LogTag, $"GetSystemArgs() called - Count: {_systemArgs?.Length ?? 0}");
            return _systemArgs;
        }

        internal static void DoOnLoopCreate()
        {
            Log.Info(LogTag, "DoOnLoopCreate() called");
            NUIApplicationInitializer.Initialize();

            // Empty implementation for C# launcher
        }

        internal static void DoOnLoopTerminate()
        {
            Log.Info(LogTag, "DoOnLoopTerminate() called");
            // Empty implementation for C# launcher
        }

    }
}
