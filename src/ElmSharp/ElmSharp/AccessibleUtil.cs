/*
 * Copyright (c) 2019 Samsung Electronics Co., Ltd All Rights Reserved
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
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace ElmSharp.Accessible
{
    /// <summary>
    /// Enumeration for the ReadingStatus.
    /// </summary>
    /// <since_tizen> preview </since_tizen>
    public enum ReadingStatus
    {
        /// <summary>
        /// Unknown status.
        /// </summary>
        Unknown,
        /// <summary>
        /// Cancelled status.
        /// </summary>
        Cancelled,
        /// <summary>
        /// Stopped status.
        /// </summary>
        Stoppped,
        /// <summary>
        /// Skipped status.
        /// </summary>
        Skipped
    }

    /// <summary>
    /// AccessibleUtil provides a method to set the reading information.
    /// </summary>
    /// <since_tizen> preview </since_tizen>
    public static class AccessibleUtil
    {

        static void AtspiSignalCallback(IntPtr data, string say_signal)
        {
            GCHandle gch = GCHandle.FromIntPtr(data);
            TaskCompletionSource<ReadingStatus> tcs = (TaskCompletionSource<ReadingStatus>) gch.Target;
            if (say_signal.Equals("ReadingCancelled"))
            {
                tcs.SetResult(ReadingStatus.Cancelled);
            }
            else if (say_signal.Equals("ReadingStopped"))
            {
                tcs.SetResult(ReadingStatus.Stoppped);
            }
            else if (say_signal.Equals("ReadingSkipped"))
            {
                tcs.SetResult(ReadingStatus.Skipped);
            }
            else
            {
                tcs.SetException(new InvalidOperationException("unknown signal : " + say_signal));
            }

            gch.Free();
        }

        /// <summary>
        /// Reads the given text by a screen reader.
        /// </summary>
        /// <param name="text">The reading text.</param>
        /// <param name="discardable">If true, reading can be discarded by subsequent reading requests. If false, reading must be finished before the next reading request can be started.</param>
        /// <returns>Return a task with the reading status.</returns>
        /// <since_tizen> preview </since_tizen>
        public static Task<ReadingStatus> Say(string text, bool discardable)
        {
            var tcs = new TaskCompletionSource<ReadingStatus>();
            GCHandle gch = GCHandle.Alloc(tcs);
            Interop.Elementary.elm_atspi_bridge_utils_say(text, discardable, AtspiSignalCallback, GCHandle.ToIntPtr(gch));
            return tcs.Task;
        }
    }
}
