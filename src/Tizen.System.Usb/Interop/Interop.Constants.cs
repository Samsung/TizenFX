/*
 * Copyright (c) 2016 Samsung Electronics Co., Ltd All Rights Reserved
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
    internal const int MaxStringDescriptorSize = 255;
    internal const int MaxPortNumberCount = 8; // As per the USB 3.0 specs, the current maximum limit for the depth is 7
    internal static partial class Libraries
    {
        public const string Usb = "libcapi-system-usbhost.so.0";
    }
}