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
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace ElmSharp.Accessible
{
    public enum ReadingStatus
    {
        Unknown,
        Cancelled,
        Stoppped,
        Skipped
    }

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

        /*
         * ReadingCancelled is never appear if discardable is true.
         * ReadingStoppped is appear on end of normal operation.
         * I don't know when the ReadingSkipped is appeared.
         */
        public static Task<ReadingStatus> Say(string text, bool discardable)
        {
            var tcs = new TaskCompletionSource<ReadingStatus>();
            GCHandle gch = GCHandle.Alloc(tcs);
            Interop.Elementary.elm_atspi_bridge_utils_say(text, discardable, AtspiSignalCallback, GCHandle.ToIntPtr(gch));
            return tcs.Task;
        }
    }
}
