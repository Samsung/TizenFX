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
    static internal class WavPlayerLog
    {
        internal const string LogTag = "Tizen.Multimedia.WavPlayer";
    }

    /// <summary>
    /// The WavPlayer class allows you to simply play and stop a wav file. To play a certain
    /// wav file, call <see cref="Tizen.Multimedia.WavPlayer.StartAsync"/> with
    /// a path to the .wav file.
    /// </summary>
    public static class WavPlayer
    {
        /// <summary>
        /// Plays a WAV file with the stream information of AudioManager, asynchronously.
        /// </summary>
        /// <param name="inputFilePath">The file path to play.</param>
        /// <param name="streamPolicy">The Audiostream policy object.</param>
        /// <param name="cancellationToken">The cancellation token which can be used to stop the Wav Player.</param>
        /// <returns>The WAV player ID.</returns>
        /// <exception cref="ArgumentException">In case of invalid parameters</exception>
        /// <exception cref="ArgumentNullException">In case of null parameters</exception>
        /// <exception cref="InvalidOperationException">In case of any invalid operations</exception>
        /// <exception cref="NotSupportedException">In case of format not supported.</exception>
        public static async Task StartAsync(string inputFilePath, AudioStreamPolicy streamPolicy, CancellationToken cancellationToken = default(CancellationToken))
        {
            int id;
            var task = new TaskCompletionSource<int>();

            if (String.IsNullOrEmpty(inputFilePath))
            {
                throw new ArgumentNullException(nameof(inputFilePath));
            }

            if (streamPolicy == null)
            {
                throw new ArgumentNullException(nameof(streamPolicy));
            }

            Interop.WavPlayer.WavPlayerCompletedCallback _playerCompletedCallback = (int playerId, IntPtr userData) =>
            {
                task.TrySetResult(playerId);
            };
            GCHandle callbackHandle = GCHandle.Alloc(_playerCompletedCallback);

            int ret = Interop.WavPlayer.WavPlayerStart(inputFilePath, streamPolicy.Handle, _playerCompletedCallback, IntPtr.Zero, out id);
            if (ret != (int)WavPlayerError.None)
            {
                Log.Error(WavPlayerLog.LogTag, "Error Occured with error code: " + (WavPlayerError)ret);
                task.TrySetException(WavPlayerErrorFactory.CreateException(ret, "Failed to play Wav file."));
            }

            if (cancellationToken != CancellationToken.None)
            {
                cancellationToken.Register((playerId) =>
                {
                    int resultCancel = Interop.WavPlayer.WavPlayerStop((int)playerId);
                    if ((WavPlayerError)resultCancel != WavPlayerError.None)
                    {
                        Log.Error(WavPlayerLog.LogTag, "Failed to stop Wav Player with error code: " + (WavPlayerError)resultCancel);
                    }
                    task.TrySetCanceled();
                }, id);
            }

            await task.Task;
            callbackHandle.Free();
        }
    }
}

