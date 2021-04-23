/*
 * Copyright (c) 2016 Samsung Electronics Co., Ltd.
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
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;

namespace Tizen.NUI
{
    /// <summary>
    /// [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    [SuppressMessage("Microsoft.Naming",
                     "CA1715:IdentifiersShouldHaveCorrectPrefix",
                     Justification = "T, U, R are commonly used as generic type parameter names.")]
    public delegate R DaliEventHandlerWithReturnType<T, U, R>(T source, U e);

    /// <summary>
    /// [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate void EventCallbackDelegateType0();

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate void EventCallbackDelegateType1(IntPtr arg1);

    /// <summary>
    /// [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    /// this should be removed with EventHandler from .NET
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    [SuppressMessage("Microsoft.Naming",
                     "CA1715:IdentifiersShouldHaveCorrectPrefix",
                     Justification = "T, U are commonly used as generic type parameter names.")]
    public delegate void DaliEventHandler<T, U>(T source, U e);

    /// <summary>
    /// [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    [SuppressMessage("Microsoft.Naming",
                     "CA1715:IdentifiersShouldHaveCorrectPrefix",
                     Justification = "T, U, R are commonly used as generic type parameter names.")]
    public delegate R EventHandlerWithReturnType<T, U, R>(T source, U e);

    /// <summary>
    /// [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    /// </summary>
    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public delegate TReturn ReturnTypeEventHandler<TSource, TEvent, TReturn>(TSource source, TEvent e);
}
