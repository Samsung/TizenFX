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
using System.Threading;
using System.Threading.Tasks;
using Native = Interop.TonePlayer;

namespace Tizen.Multimedia
{
    /// <summary>
    /// Provides the ability to play a tone.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    [Obsolete("Deprecated since API14. Will be removed in API16.")]
    public static class TonePlayer
    {
        /// <summary>
        /// Plays a tone, asynchronously.
        /// </summary>
        /// <param name="tone">A <see cref="ToneType"/> to play.</param>
        /// <param name="streamPolicy">A <see cref="AudioStreamPolicy"/>.</param>
        /// <param name="durationMilliseconds">The tone duration in milliseconds. -1 indicates an infinite duration.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        /// <exception cref="ArgumentException"><paramref name="tone"/> is invalid.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="streamPolicy"/> is null.</exception>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="durationMilliseconds"/> is less than -1.</exception>
        /// <exception cref="InvalidOperationException">Any invalid operations occurred.</exception>
        /// <exception cref="NotSupportedException"><paramref name="tone"/> is not a supported type.</exception>
        /// <exception cref="ObjectDisposedException"><paramref name="streamPolicy"/> has already been disposed of.</exception>
        /// <since_tizen> 3 </since_tizen>
        [Obsolete("Deprecated since API14. Will be removed in API16.")]
        public static Task StartAsync(ToneType tone, AudioStreamPolicy streamPolicy,
            int durationMilliseconds)
        {
            return StartAsync(tone, streamPolicy, durationMilliseconds, CancellationToken.None);
        }

        /// <summary>
        /// Plays a tone, asynchronously.
        /// </summary>
        /// <param name="tone">A <see cref="ToneType"/> to play.</param>
        /// <param name="streamPolicy">A <see cref="AudioStreamPolicy"/>.</param>
        /// <param name="durationMilliseconds">The tone duration in milliseconds. -1 indicates an infinite duration.</param>
        /// <param name="cancellationToken">The cancellation token which can be used to stop playing the tone.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        /// <exception cref="ArgumentException"><paramref name="tone"/> is invalid.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="streamPolicy"/> is null.</exception>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="durationMilliseconds"/> is less than -1.</exception>
        /// <exception cref="InvalidOperationException">Any invalid operations occurred.</exception>
        /// <exception cref="NotSupportedException"><paramref name="tone"/> is not a supported type.</exception>
        /// <exception cref="ObjectDisposedException"><paramref name="streamPolicy"/> has already been disposed of.</exception>
        /// <since_tizen> 3 </since_tizen>
        [Obsolete("Deprecated since API14. Will be removed in API16.")]
        public static Task StartAsync(ToneType tone, AudioStreamPolicy streamPolicy,
            int durationMilliseconds, CancellationToken cancellationToken)
        {
            if (durationMilliseconds < -1)
            {
                throw new ArgumentOutOfRangeException(nameof(durationMilliseconds), durationMilliseconds,
                    $"{nameof(durationMilliseconds)} can't be less than -1.");
            }

            if (streamPolicy == null)
            {
                throw new ArgumentNullException(nameof(streamPolicy));
            }

            ValidationUtil.ValidateEnum(typeof(ToneType), tone, nameof(tone));

            if (cancellationToken.IsCancellationRequested)
            {
                return Task.FromCanceled(cancellationToken);
            }

            return StartAsyncCore(tone, streamPolicy, durationMilliseconds, cancellationToken);
        }

        private static async Task StartAsyncCore(ToneType tone, AudioStreamPolicy streamPolicy,
            int durationMilliseconds, CancellationToken cancellationToken)
        {

            var tcs = new TaskCompletionSource<bool>();

            Native.Start(tone, streamPolicy.Handle, durationMilliseconds, out var id).
                Validate("Failed to play tone.");

            using (RegisterCancellationAction(tcs, cancellationToken, id))
            {
                await WaitForDuration(tcs, cancellationToken, durationMilliseconds);

                await tcs.Task;
            }
        }

        private static async Task WaitForDuration(TaskCompletionSource<bool> tcs,
            CancellationToken cancellationToken, int durationMilliseconds)
        {
            if (durationMilliseconds == -1)
            {
                return;
            }

            try
            {
                await Task.Delay(durationMilliseconds, cancellationToken);
                tcs.TrySetResult(true);
            }
            catch (TaskCanceledException)
            {
            }
        }

        private static IDisposable RegisterCancellationAction(TaskCompletionSource<bool> tcs,
            CancellationToken cancellationToken, int id)
        {
            if (cancellationToken.CanBeCanceled == false)
            {
                return null;
            }

            return cancellationToken.Register(() =>
            {
                Native.Stop(id).Validate("Failed to cancel");
                tcs.TrySetCanceled();
            });
        }
    }
}

