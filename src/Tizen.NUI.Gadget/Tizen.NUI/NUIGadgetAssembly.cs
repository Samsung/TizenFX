/*
* Copyright (c) 2024 Samsung Electronics Co., Ltd All Rights Reserved
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
using System.IO;
using System.Reflection;
using System.Runtime.Loader;

using SystemIO = System.IO;

namespace Tizen.NUI
{
    internal class NUIGadgetAssemblyLoadContext : AssemblyLoadContext
    {
        public NUIGadgetAssemblyLoadContext() : base(isCollectible: true)
        {
        }

        protected override Assembly Load(AssemblyName name)
        {
            return null;
        }
    }

    internal class NUIGadgetAssembly
    {
        private static readonly object _assemblyLock = new object();
        private readonly string _assemblyPath;
        private WeakReference _assemblyRef;
        private Assembly _assembly = null;

        public NUIGadgetAssembly(string assemblyPath) { _assemblyPath = assemblyPath; }

        public void Load()
        {
            lock (_assemblyLock)
            {
                if (_assembly != null)
                {
                    return;
                }

                Log.Warn("Load(): " + _assemblyPath + " ++");
                NUIGadgetAssemblyLoadContext context = new NUIGadgetAssemblyLoadContext();
                _assemblyRef = new WeakReference(context);
                string directoryPath = SystemIO.Path.GetDirectoryName(_assemblyPath);
                string fileName = SystemIO.Path.GetFileNameWithoutExtension(_assemblyPath);
                string nativeImagePath = directoryPath + "/" + fileName + ".ni.dll";
                Log.Debug("NativeImagePath=" + nativeImagePath + ", AssemblyPath=" + _assemblyPath);
                _assembly = context.LoadFromNativeImagePath(nativeImagePath, _assemblyPath);
                Log.Warn("Load(): " + _assemblyPath + " --");
            }
        }

        public bool IsLoaded { get { return _assembly != null; } }

        public NUIGadget CreateInstance(string className)
        {
            lock (_assemblyLock)
            {
                return (NUIGadget)_assembly?.CreateInstance(className);
            }
        }

        public void Unload()
        {
            lock (_assemblyLock)
            {
                if (_assembly == null)
                {
                    return;
                }

                Log.Warn("Unload(): " + _assemblyPath + " ++");
                if (_assemblyRef.IsAlive)
                {
                    (_assemblyRef.Target as NUIGadgetAssemblyLoadContext).Unload();
                }

                _assembly = null;
                Log.Warn("Unload(): " + _assemblyPath + " --");
            }
        }
    }
}