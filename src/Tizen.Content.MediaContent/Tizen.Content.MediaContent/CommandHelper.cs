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

using System;
using System.Collections.Generic;
using FilterHandle = Interop.FilterHandle;

namespace Tizen.Content.MediaContent
{
    internal static class CommandHelper
    {
        internal delegate MediaContentError CountFunc(FilterHandle filter, out int count);

        internal delegate MediaContentError CountFunc<T>(T param, FilterHandle filter,
            out int count);

        internal static int Count(CountFunc countFunc, CountArguments arguments)
        {
            using (var filter = QueryArguments.ToNativeHandle(arguments))
            {
                countFunc(filter, out var count).ThrowIfError("Failed to query count");
                return count;
            }
        }

        internal static int Count(CountFunc countFunc, string filter)
        {
            return Count(countFunc, new CountArguments { FilterExpression = filter });
        }

        internal static int Count<T>(CountFunc<T> countFunc, T param, CountArguments arguments)
        {
            using (var filter = QueryArguments.ToNativeHandle(arguments))
            {
                countFunc(param, filter, out var count).ThrowIfError("Failed to query count");
                return count;
            }
        }

        internal static void Delete<T>(Func<T, MediaContentError> func, T param)
        {
            func(param).ThrowIfError("Failed to execute the command");
        }

        internal delegate MediaContentError ForeachFunc<T>(T param, FilterHandle filter,
            Interop.Common.ItemCallback callback, IntPtr data = default(IntPtr));

        internal static MediaDataReader<MediaInfo> SelectMedia<T>(ForeachFunc<T> func, T param,
            SelectArguments arguments)
        {
            using (var filter = QueryArguments.ToNativeHandle(arguments))
            {
                var items = new List<MediaInfo>();
                Exception exception = null;

                func(param, filter, (mediaInfoHandle, _) =>
                {
                    try
                    {
                        items.Add(MediaInfo.FromHandle(mediaInfoHandle));
                        return true;
                    }
                    catch (Exception e)
                    {
                        exception = e;
                        return false;
                    }
                }).ThrowIfError("Failed to query");

                if (exception != null)
                {
                    throw exception;
                }

                return new MediaDataReader<MediaInfo>(items);
            }
        }

        internal delegate MediaContentError ForeachFunc(FilterHandle filter,
            Interop.Common.ItemCallback callback, IntPtr data = default(IntPtr));

        internal static MediaDataReader<TRecord> Select<TRecord>(SelectArguments arguments,
            ForeachFunc foreachFunc,
            Func<IntPtr, TRecord> factoryFunc)
        {
            using (var filter = QueryArguments.ToNativeHandle(arguments))
            {
                Exception caught = null;
                var items = new List<TRecord>();

                foreachFunc(filter, (itemHandle, _) =>
                {
                    try
                    {
                        items.Add(factoryFunc(itemHandle));
                        return true;
                    }
                    catch (Exception e)
                    {
                        caught = e;
                        return false;
                    }
                }).ThrowIfError("Failed to execute query");

                if (caught != null)
                {
                    throw caught;
                }

                return new MediaDataReader<TRecord>(items);
            }
        }


        internal delegate MediaContentError CloneFunc(out IntPtr output, IntPtr input);

        internal static IntPtr SelectScalar(ForeachFunc foreachFunc, string filterExpression,
            CloneFunc cloneFunc)
        {
            using (var filter = QueryArguments.CreateNativeHandle(filterExpression))
            {
                IntPtr handle = IntPtr.Zero;

                foreachFunc(filter, (itemHandle, _) =>
                {
                    cloneFunc(out handle, itemHandle);
                    return false;
                }).ThrowIfError("Failed to execute query");

                return handle;
            }
        }

        internal delegate MediaContentError ForeachMemberFunc<TParam>(TParam param,
            FilterHandle filter, Interop.Common.ItemCallback callback, IntPtr data = default(IntPtr));

        internal static MediaDataReader<TRecord> SelectMembers<TParam, TRecord>(TParam param,
            SelectArguments arguments, ForeachMemberFunc<TParam> foreachFunc,
            Func<IntPtr, TRecord> factoryFunc)
        {
            using (var filter = QueryArguments.ToNativeHandle(arguments))
            {
                Exception caught = null;
                var items = new List<TRecord>();

                foreachFunc(param, filter, (itemHandle, _) =>
                {
                    try
                    {
                        items.Add(factoryFunc(itemHandle));

                        return true;
                    }
                    catch (Exception e)
                    {
                        caught = e;
                        return false;
                    }
                }).ThrowIfError("Failed to execute query");

                if (caught != null)
                {
                    throw caught;
                }

                return new MediaDataReader<TRecord>(items);
            }
        }
    }
}
