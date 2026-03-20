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
using System.Threading;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Runtime.Loader;
using System.Text;
using Tizen.NUI;

namespace Tizen.Applications
{
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
            _ops.CreateLibPath = new Interop.TeamLoop.TeamLoopOpsCreateLibPath(DoCreateLibPath);
            _ops.OnLoopCreate = new Interop.TeamLoop.TeamLoopOpsOnLoopCreate(DoOnLoopCreate);
            _ops.OnLoopTerminate = new Interop.TeamLoop.TeamLoopOpsOnLoopTerminate(DoOnLoopTerminate);
        }
        public static void Run(string[] args)
        {
            Log.Info(LogTag, $"Run() called - Already Running: {_isRunning}");
            if(_isRunning)
            {
              return;
            }

            _isRunning = true;
            _systemArgs = args;

            Log.Info("NUI", "[NUI] NUIApplicationInitializer: StaticInitialize");
            Registry.Instance.SavedApplicationThread = Thread.CurrentThread;
            PropertyBridge.RegisterStringGetter();
            Log.Info("NUI", "[NUI] NUIApplicationInitializer: StaticInitialize done");

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
                Log.Info(LogTag, $"Main method {mainMethod.Name}");

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

        internal static void DoCreateLibPath(string path, ref IntPtr output)
        {
            if (string.IsNullOrEmpty(path))
            {
                Log.Error(LogTag, "Invalid path: null or empty");
                output = IntPtr.Zero;
                return;
            }

            int lastDotIndex = path.LastIndexOf('.');
            if (lastDotIndex < 0)
            {
                Log.Error(LogTag, $"Invalid path format: {path}. Expected format: org.appfw.csteam.{{member_id}}");
                output = IntPtr.Zero;
                return;
            }

            string memberId = path.Substring(lastDotIndex + 1);
            if (string.IsNullOrEmpty(memberId))
            {
                Log.Error(LogTag, $"Empty member_id extracted from: {path}");
                output = IntPtr.Zero;
                return;
            }

            string libPath = $"/usr/share/csteam/dll/{memberId}.dll";
            Log.Info(LogTag, $"Created lib path: {libPath} from {path}");

            output = Marshal.StringToHGlobalAnsi(libPath);

            if (output == IntPtr.Zero) {
                Log.Error(LogTag, "Failed to allocate memory for lib path");
            }
        }

        public static string[] GetSystemArgs()
        {
            Log.Info(LogTag, $"GetSystemArgs() called - Count: {_systemArgs?.Length ?? 0}");
            return _systemArgs;
        }

        internal static void DoOnLoopCreate()
        {
            Log.Info(LogTag, "DoOnLoopCreate() called");

            Log.Info("NUI", "[NUI] NUIApplicationInitializer: ProcessorController Initialize");
            Tracer.Begin("[NUI] NUIApplicationInitializer: ProcessorController Initialize");
            ProcessorController.Instance.Initialize();
            Tracer.End();

            // Initialize DisposeQueue Singleton class. This is also required to create DisposeQueue on main thread.
            Log.Info("NUI", "[NUI] NUIApplicationInitializer: DisposeQueue Initialize");
            Tracer.Begin("[NUI] NUIApplicationInitializer: DisposeQueue Initialize");
            DisposeQueue.Instance.Initialize();
            Tracer.End();

            // Empty implementation for C# launcher
        }

        internal static void DoOnLoopTerminate()
        {
            Log.Info(LogTag, "DoOnLoopTerminate() called");
            // Empty implementation for C# launcher
        }

    }
}
