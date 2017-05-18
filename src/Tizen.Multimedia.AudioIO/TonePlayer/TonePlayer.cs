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
using System.Threading;
using System.Threading.Tasks;

namespace Tizen.Multimedia
{
    static internal class TonePlayerLog
    {
        internal const string LogTag = "Tizen.Multimedia.TonePlayer";
    }

    /// <summary>
    /// The TonePlayer class allows you to play and stop playing the tone. To play a particular
    /// type of tone <see cref="Tizen.Multimedia.ToneType"/>,
    /// use <see cref="Tizen.Multimedia.TonePlayer.StartAsync"/>.
    /// </summary>
    public static class TonePlayer
    {
        /// <summary>
        /// Plays a tone, asynchronously.
        /// </summary>
        /// <param name="tone">The tone type to play.</param>
        /// <param name="streamPolicy">The Audiostream policy object.</param>
        /// <param name="durationMs">The tone duration in milliseconds. -1 indicates an infinite duration.</param>
        /// <param name="cancellationToken">The cancellation token which can be used to stop playing the tone.</param>
        /// <exception cref="ArgumentException">In case of invalid parameters</exception>
        /// <exception cref="ArgumentNullException">In case of null parameters</exception>
        /// <exception cref="ArgumentOutOfRangeException">In case of play duration less than -1.</exception>
        /// <exception cref="InvalidOperationException">In case of any invalid operations</exception>
        /// <exception cref="NotSupportedException">In case of tone type not supported.</exception>
        public static async Task StartAsync(ToneType tone, AudioStreamPolicy streamPolicy, int durationMs, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (durationMs < -1)
            {
                throw new ArgumentOutOfRangeException(nameof(durationMs));
            }

            if (streamPolicy == null)
            {
                throw new ArgumentNullException(nameof(streamPolicy));

            }

            if (Enum.IsDefined(typeof(ToneType), tone) == false)
            {
                throw new ArgumentException("Invalid ToneType provided : " + tone);
            }

            int id;
            var task = new TaskCompletionSource<int>();
            int ret = Interop.TonePlayer.Start(tone, streamPolicy.Handle, durationMs, out id);
            if (ret != (int)TonePlayerError.None)
            {
                Log.Error(TonePlayerLog.LogTag, "Error Occured with error code: " + (TonePlayerError)ret);
                throw TonePlayerErrorFactory.CreateException(ret, "Failed to play tone.");
            }

            if (cancellationToken != CancellationToken.None)
            {
                cancellationToken.Register((playerId) =>
                {
                    int resultCancel = Interop.TonePlayer.Stop((int)playerId);
                    if ((TonePlayerError)resultCancel != TonePlayerError.None)
                    {
                        Log.Error(TonePlayerLog.LogTag, "Failed to stop tone Player with error code: " + (TonePlayerError)resultCancel);
                    }
                    task.TrySetCanceled();
                }, id);
            }

            if (durationMs != -1)
            {
                Task delayTask = Task.Delay(durationMs, cancellationToken);
                await delayTask;
                if (delayTask.IsCompleted)
                {
                    task.TrySetResult(id);
                }
            }
            await task.Task;
        }
    }
}

