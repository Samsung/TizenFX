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
#pragma warning disable 1591

namespace CoreUI {

/// <summary>
/// Define the name of the libraries to be passed to DllImport statements.
/// </summary>
internal class Libs {
    internal const string CoreUI = "libefl.so.1";
    internal const string Ecore = "libecore.so.1";
    internal const string Eina = "libeina.so.1";
    internal const string Eo = "libeo.so.1";
    internal const string Evas = "libevas.so.1";
    internal const string Evil = "libdl.so.2";
    internal const string Edje = "libedje.so.1";
    internal const string Elementary = "libelementary.so.1";
    internal const string Eldbus = "libeldbus.so.1";

    internal const string CustomExports = "libeflcustomexportsmono.so.1";

    internal const string Libdl = "libdl.so.2";
    internal const string Kernel32 = "kernel32.dll";
    internal const string Eext = "libefl-extension.so.0";

    internal static readonly CoreUI.Wrapper.NativeModule CoreUIModule = new CoreUI.Wrapper.NativeModule(CoreUI);
    internal static readonly CoreUI.Wrapper.NativeModule CoreModule = new CoreUI.Wrapper.NativeModule(Ecore);
    internal static readonly CoreUI.Wrapper.NativeModule EinaModule = new CoreUI.Wrapper.NativeModule(Eina);
    internal static readonly CoreUI.Wrapper.NativeModule EoModule = new CoreUI.Wrapper.NativeModule(Eo);
    internal static readonly CoreUI.Wrapper.NativeModule EvasModule = new CoreUI.Wrapper.NativeModule(Evas);
    internal static readonly CoreUI.Wrapper.NativeModule EvilModule = new CoreUI.Wrapper.NativeModule(Evil);
    internal static readonly CoreUI.Wrapper.NativeModule EdjeModule = new CoreUI.Wrapper.NativeModule(Edje);
    internal static readonly CoreUI.Wrapper.NativeModule ElementaryModule = new CoreUI.Wrapper.NativeModule(Elementary);
    internal static readonly CoreUI.Wrapper.NativeModule EldbusModule = new CoreUI.Wrapper.NativeModule(Eldbus);
    internal static readonly CoreUI.Wrapper.NativeModule CustomExportsModule = new CoreUI.Wrapper.NativeModule(CustomExports);
    internal static readonly CoreUI.Wrapper.NativeModule LibdlModule = new CoreUI.Wrapper.NativeModule(Libdl);
    internal static readonly CoreUI.Wrapper.NativeModule Kernel32Module = new CoreUI.Wrapper.NativeModule(Kernel32);
}

}
