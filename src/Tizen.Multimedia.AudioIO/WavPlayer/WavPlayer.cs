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
using System.ComponentModel;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Native = Interop.WavPlayer;

namespace Tizen.Multimedia
{
    /// <summary>
    /// Provides the ability to play a wav file.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public static class WavPlayer
    {
        /// <summary>
        /// Plays a wav file based on the specified <see cref="AudioStreamPolicy"/>.
        /// </summary>
        /// <returns>A task that represents the asynchronous operation.</returns>
        /// <param name="path">A file path to play.</param>
        /// <param name="streamPolicy">A <see cref="AudioStreamPolicy"/>.</param>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="path"/> is null.
        ///     <para>-or-</para>
        ///     <paramref name="streamPolicy"/> is null.
        /// </exception>
        /// <exception cref="InvalidOperationException">An internal error occurs.</exception>
        /// <exception cref="FileNotFoundException"><paramref name="path"/> does not exists.</exception>
        /// <exception cref="FileFormatException">The format of <paramref name="path"/> is not supported.</exception>
        /// <exception cref="ObjectDisposedException"><paramref name="streamPolicy"/> has already been disposed of.</exception>
        /// <since_tizen> 3 </since_tizen>
        public static Task StartAsync(string path, AudioStreamPolicy streamPolicy)
        {
            return StartAsync(path, streamPolicy, CancellationToken.None);
        }

        /// <summary>
        /// Plays a wav file based on the specified <see cref="AudioStreamPolicy"/>.
        /// </summary>
        /// <returns>A task that represents the asynchronous operation.</returns>
        /// <param name="path">A file path to play.</param>
        /// <param name="streamPolicy">A <see cref="AudioStreamPolicy"/>.</param>
        /// <param name="cancellationToken">A cancellation token which can be used to stop.</param>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="path"/> is null.
        ///     <para>-or-</para>
        ///     <paramref name="streamPolicy"/> is null.
        /// </exception>
        /// <exception cref="InvalidOperationException">An internal error occurs.</exception>
        /// <exception cref="FileNotFoundException"><paramref name="path"/> does not exists.</exception>
        /// <exception cref="FileFormatException">The format of <paramref name="path"/> is not supported.</exception>
        /// <exception cref="ObjectDisposedException"><paramref name="streamPolicy"/> has already been disposed of.</exception>
        /// <since_tizen> 3 </since_tizen>
        public static Task StartAsync(string path, AudioStreamPolicy streamPolicy,
            CancellationToken cancellationToken)
        {
            if (path == null)
            {
                throw new ArgumentNullException(nameof(path));
            }

            if (streamPolicy == null)
            {
                throw new ArgumentNullException(nameof(streamPolicy));
            }

            if (File.Exists(path) == false)
            {
                throw new FileNotFoundException("File does not exists.", path);
            }

            return cancellationToken.IsCancellationRequested ? Task.FromCanceled(cancellationToken) :
                StartAsyncCore(path, streamPolicy, 1, cancellationToken);
        }

        /// <summary>
        /// Plays a wav file based on the specified <see cref="AudioStreamPolicy"/> with given repetition number.
        /// </summary>
        /// <remarks>If loopCount is 0, it means infinite loops</remarks>
        /// <returns>A task that represents the asynchronous operation.</returns>
        /// <param name="path">A file path to play.</param>
        /// <param name="streamPolicy">A <see cref="AudioStreamPolicy"/>.</param>
        /// <param name="loopCount">A number of repetitions.</param>
        /// <param name="cancellationToken">A cancellation token which can be used to stop.</param>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="path"/> is null.
        ///     <para>-or-</para>
        ///     <paramref name="streamPolicy"/> is null.
        /// </exception>
        /// <exception cref="InvalidOperationException">An internal error occurs.</exception>
        /// <exception cref="FileNotFoundException"><paramref name="path"/> does not exists.</exception>
        /// <exception cref="FileFormatException">The format of <paramref name="path"/> is not supported.</exception>
        /// <exception cref="ObjectDisposedException"><paramref name="streamPolicy"/> has already been disposed of.</exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Task StartAsync(string path, AudioStreamPolicy streamPolicy, uint loopCount,
            CancellationToken cancellationToken)
        {
            if (path == null)
            {
                throw new ArgumentNullException(nameof(path));
            }

            if (streamPolicy == null)
            {
                throw new ArgumentNullException(nameof(streamPolicy));
            }

            if (File.Exists(path) == false)
            {
                throw new FileNotFoundException("File does not exists.", path);
            }

            return cancellationToken.IsCancellationRequested ? Task.FromCanceled(cancellationToken) :
                StartAsyncCore(path, streamPolicy, loopCount, cancellationToken);
        }

        private static async Task StartAsyncCore(string path, AudioStreamPolicy streamPolicy, uint loopCount,
            CancellationToken cancellationToken)
        {
            int id = 0;
            var tcs = new TaskCompletionSource<bool>();

            Native.WavPlayerCompletedCallback cb = (id_, _) => tcs.TrySetResult(true);

            using (var cbKeeper = ObjectKeeper.Get(cb))
            {
                Native.StartLoop(path, streamPolicy.Handle, loopCount, cb, IntPtr.Zero, out id).
                    Validate("Failed to play with loop.");

                using (RegisterCancellationAction(tcs, cancellationToken, id))
                {
                    await tcs.Task.ConfigureAwait(false);
                }
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

