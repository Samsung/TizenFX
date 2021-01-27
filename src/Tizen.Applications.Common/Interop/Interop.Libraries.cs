/*
 * Copyright (c) 2018 Samsung Electronics Co., Ltd All Rights Reserved
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

internal static partial class Interop
{
    internal static partial class Libraries
    {
        #if NOTIZEN
            public const string AppCommon = "capi-appfw-app-common";
            public const string AppManager = "capi-appfw-app-manager";
        #else
            public const string AppCommon = "libcapi-appfw-app-common.so.0";
            public const string AppManager = "libcapi-appfw-app-manager.so.0";
        #endif
        public const string AppControl = "libcapi-appfw-app-control.so.0";
        public const string AppEvent = "libcapi-appfw-event.so.0";
        public const string Bundle = "libbundle.so.0";
        public const string Rua = "librua.so.0";
        public const string Glib = "libglib-2.0.so.0";
        public const string Libc = "libc.so.6";
        public const string Application = "libcapi-appfw-application.so.0";
        public const string BaseUtilsi18n = "libbase-utils-i18n.so.0";
        public const string RpcPort = "librpc-port.so.1";
    }
}
