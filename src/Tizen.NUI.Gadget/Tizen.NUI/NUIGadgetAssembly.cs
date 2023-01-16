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
using System.IO;
using System.Reflection;
using System.Runtime.Loader;

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
        private readonly string _assemblyPath;
        public WeakReference _assemblyRef;
        public Assembly _assembly = null;

        public NUIGadgetAssembly(string assemblyPath)
        {
            _assemblyPath = assemblyPath;
        }

        public void Load()
        {
            if (_assembly != null)
            {
                return;
            }

            NUIGadgetAssemblyLoadContext context = new NUIGadgetAssemblyLoadContext();
            _assemblyRef = new WeakReference(context);
            using (FileStream stream = new FileStream(_assemblyPath, FileMode.Open, FileAccess.Read))
            {
                _assembly = context.LoadFromStream(stream);
            }
        }

        public NUIGadget CreateInstance(string className)
        {
            return (NUIGadget)_assembly?.CreateInstance(className);
        }

        public void Unload()
        {
            if (_assemblyRef.IsAlive)
            {
                (_assemblyRef.Target as NUIGadgetAssemblyLoadContext).Unload();
            }

            _assembly = null;
        }
    }
}
