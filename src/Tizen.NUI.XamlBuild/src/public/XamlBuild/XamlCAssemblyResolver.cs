/*
 * Copyright(c) 2022 Samsung Electronics Co., Ltd.
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
using Mono.Cecil;

namespace Tizen.NUI.Xaml.Build.Tasks
{
    class XamlCAssemblyResolver : DefaultAssemblyResolver
    {
        public void AddAssembly(string p)
        {
            RegisterAssembly(AssemblyDefinition.ReadAssembly(p, new ReaderParameters
            {
                AssemblyResolver = this
            }));
        }

        public override AssemblyDefinition Resolve(AssemblyNameReference name)
        {
            if (TryResolve(name, out AssemblyDefinition assembly))
                return assembly;
            if (   IsMscorlib(name)
                && (  TryResolve(AssemblyNameReference.Parse("mscorlib"), out assembly)
                   || TryResolve(AssemblyNameReference.Parse("netstandard"), out assembly)
                   || TryResolve(AssemblyNameReference.Parse("System.Runtime"), out assembly)))
                return assembly;
            throw new AssemblyResolutionException(name);
        }

        bool TryResolve(AssemblyNameReference assemblyNameReference, out AssemblyDefinition assembly)
        {
            try {
                assembly = base.Resolve(assemblyNameReference);
                return true;
            }
            catch (AssemblyResolutionException e) {
                assembly = null;
                return false;
            }
        }

        static bool IsMscorlib(AssemblyNameReference name)
        {
            return    name.Name == "mscorlib"
                   || name.Name == "System.Runtime"
                   || name.Name == "netstandard";
        }
    }
}
 
