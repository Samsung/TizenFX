/*
 * Copyright 2019 by its authors. See AUTHORS.
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *     http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */
using System;

namespace CoreUI.Wrapper
{

///<summary>Wraps a native module that was opened with dlopen/LoadLibrary.</summary>
/// <since_tizen> 6 </since_tizen>
internal partial class NativeModule : IDisposable
{
    private Lazy<IntPtr> module;
    private bool disposed = false;

    ///<summary>Lazily tries to load the module with the given name.</summary>
    /// <since_tizen> 6 </since_tizen>
    ///<param name="libName">The name of the module to load.</param>
    internal NativeModule(string libName)
    {
        module = new Lazy<IntPtr>
            (() =>
             {
                 return LoadLibrary(libName);
             });
    }

    ///<summary>The module that was loaded.</summary>
    /// <since_tizen> 6 </since_tizen>
    internal IntPtr Module
    {
        get
        {
            return module.Value;
        }
    }

    /// <summary>Finalizer to be called from the Garbage Collector.</summary>
    /// <since_tizen> 6 </since_tizen>
    ~NativeModule()
    {
        Dispose(false);
    }

    /// <summary>Unload and released the handle to the wrapped module.</summary>
    /// <since_tizen> 6 </since_tizen>
    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    /// <summary>Unload and released the handle to the wrapped module.</summary>
    /// <since_tizen> 6 </since_tizen>
    protected virtual void Dispose(bool disposing)
    {
        if (disposed)
        {
            return;
        }

        if (disposing)
        {
           module = null;
        }

        if (module.IsValueCreated)
        {
           UnloadLibrary(module.Value);
        }

        disposed = true;
   }
}

}
