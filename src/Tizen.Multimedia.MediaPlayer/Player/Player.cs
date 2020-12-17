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

using static Interop;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;

namespace Tizen.Multimedia
{
    internal static class PlayerLog
    {
        internal const string Tag = "Tizen.Multimedia.Player";
    }

    /// <summary>
    /// Provides the ability to control media playback.
    /// </summary>
    /// <remarks>
    /// The player provides functions to play a media content.
    /// It also provides functions to adjust the configurations of the player such as playback rate, volume, looping etc.
    /// Note that only one video player can be played at one time.
    /// </remarks>
    public partial class Player : IDisposable, IDisplayable<PlayerErrorCode>
    {
        private readonly PlayerHandle _handle;

        /// <summary>
        /// Initializes a new instance of the <see cref="Player"/> class.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public Player()
        {
            NativePlayer.Create(out _handle).ThrowIfFailed(null, "Failed to create player");

            Debug.Assert(_handle != null);

            Initialize();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Player"/> class with a native handle.
        /// The class takes care of the life cycle of the handle.
        /// Thus, it should not be closed/destroyed in another location.
        /// </summary>
        /// <param name="handle">The handle for the media player.</param>
        /// <param name="errorHandler">The handle for occuring error.</param>
        /// <remarks>
        /// This supports the product infrastructure and is not intended to be used directly from application code.
        /// </remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected Player(IntPtr handle, Action<int, string> errorHandler)
        {
            // This constructor is to support TV product player.
            // Be careful with 'handle'. It must be wrapped in safe handle, first.
            _handle = handle != IntPtr.Zero ? new PlayerHandle(handle) :
                throw new ArgumentException("Handle is invalid.", nameof(handle));

            _errorHandler = errorHandler;
        }

        private bool _initialized;

        /// <summary>
        /// This supports the product infrastructure and is not intended to be used directly from application code.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected void Initialize()
        {
            if (_initialized)
            {
                throw new InvalidOperationException("It has already been initialized.");
            }

            if (Features.IsSupported(PlayerFeatures.AudioEffect))
            {
                _audioEffect = new AudioEffect(this);
            }

            RegisterEvents();

            _displaySettings = PlayerDisplaySettings.Create(this);

            _initialized = true;
        }

        internal void ValidatePlayerState(params PlayerState[] desiredStates)
        {
            Debug.Assert(desiredStates.Length > 0);

            ValidateNotDisposed();

            var curState = State;
            if (curState.IsAnyOf(desiredStates))
            {
                return;
            }

            throw new InvalidOperationException($"The player is not in a valid state. " +
                $"Current State : { curState }, Valid State : { string.Join(", ", desiredStates) }.");
        }

        #region Dispose support
        private bool _disposed;

        /// <summary>
        /// Releases all resources used by the current instance.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Releases the unmanaged resources used by the <see cref="Player"/>.
        /// </summary>
        /// <param name="disposing">
        /// true to release both managed and unmanaged resources; false to release only unmanaged resources.
        /// </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
            {
                return;
            }

            if (disposing)
            {
                ReplaceDisplay(null);

                if (_source != null)
                {
                    try
                    {
                        _source.DetachFrom(this);
                        _source = null;
                    }
                    catch (Exception e)
                    {
                        Log.Error(PlayerLog.Tag, e.ToString());
                    }
                }

                if (_handle != null)
                {
                    _handle.Dispose();
                    _disposed = true;
                }
            }
        }

        internal void ValidateNotDisposed()
        {
            if (_disposed)
            {
                Log.Warn(PlayerLog.Tag, "player was disposed");
                throw new ObjectDisposedException(nameof(Player));
            }
        }

        internal bool IsDisposed => _disposed;
        #endregion

        #region Methods

        /// <summary>
        /// Gets the streaming download progress.
        /// </summary>
        /// <returns>The <see cref="DownloadProgress"/> containing current download progress.</returns>
        /// <remarks>The player must be in the <see cref="PlayerState.Ready"/>, <see cref="PlayerState.Playing"/>,
        /// or <see cref="PlayerState.Paused"/> state.</remarks>
        /// <exception cref="InvalidOperationException">
        ///     The player is not streaming.<br/>
        ///     -or-<br/>
        ///     The player is not in the valid state.
        ///     </exception>
        /// <exception cref="ObjectDisposedException">The player has already been disposed of.</exception>
        /// <since_tizen> 3 </since_tizen>
        public DownloadProgress GetDownloadProgress()
        {
            ValidatePlayerState(PlayerState.Ready, PlayerState.Playing, PlayerState.Paused);

            int start = 0;
            int current = 0;
            NativePlayer.GetStreamingDownloadProgress(Handle, out start, out current).
                ThrowIfFailed(this, "Failed to get download progress");

            Log.Info(PlayerLog.Tag, $"get download progress : {start}, {current}");

            return new DownloadProgress(start, current);
        }

        /// <summary>
        /// Sets the subtitle path for playback.
        /// </summary>
        /// <param name="path">The absolute path of the subtitle file, it can be NULL in the <see cref="PlayerState.Idle"/> state.</param>
        /// <remarks>Only MicroDVD/SubViewer(*.sub), SAMI(*.smi), and SubRip(*.srt) subtitle formats are supported.
        ///     <para>The mediastorage privilege(http://tizen.org/privilege/mediastorage) must be added if any files are used to play located in the internal storage.
        ///     The externalstorage privilege(http://tizen.org/privilege/externalstorage) must be added if any files are used to play located in the external storage.</para>
        /// </remarks>
        /// <exception cref="ObjectDisposedException">The player has already been disposed of.</exception>
        /// <exception cref="ArgumentException"><paramref name="path"/> is an empty string.</exception>
        /// <exception cref="FileNotFoundException">The specified path does not exist.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="path"/> is null.</exception>
        /// <since_tizen> 3 </since_tizen>
        public void SetSubtitle(string path)
        {
            ValidateNotDisposed();

            if (path == null)
            {
                throw new ArgumentNullException(nameof(path));
            }

            if (path.Length == 0)
            {
                throw new ArgumentException("The path is empty.", nameof(path));
            }

            if (!File.Exists(path))
            {
                throw new FileNotFoundException($"The specified file does not exist.", path);
            }

            NativePlayer.SetSubtitlePath(Handle, path).
                ThrowIfFailed(this, "Failed to set the subtitle path to the player");
        }

        /// <summary>
        /// Removes the subtitle path.
        /// </summary>
        /// <remarks>The player must be in the <see cref="PlayerState.Idle"/> state.</remarks>
        /// <exception cref="ObjectDisposedException">The player has already been disposed of.</exception>
        /// <exception cref="InvalidOperationException">The player is not in the valid state.</exception>
        /// <since_tizen> 3 </since_tizen>
        public void ClearSubtitle()
        {
            ValidatePlayerState(PlayerState.Idle);

            NativePlayer.SetSubtitlePath(Handle, null).
                ThrowIfFailed(this, "Failed to clear the subtitle of the player");
        }

        /// <summary>
        /// Sets the offset for the subtitle.
        /// </summary>
        /// <param name="offset">The value indicating a desired offset in milliseconds.</param>
        /// <remarks>The player must be in the <see cref="PlayerState.Playing"/> or <see cref="PlayerState.Paused"/> state.</remarks>
        /// <exception cref="ObjectDisposedException">The player has already been disposed of.</exception>
        /// <exception cref="InvalidOperationException">
        ///     The player is not in the valid state.<br/>
        ///     -or-<br/>
        ///     No subtitle is set.
        /// </exception>
        /// <seealso cref="SetSubtitle(string)"/>
        /// <since_tizen> 3 </since_tizen>
        public void SetSubtitleOffset(int offset)
        {
            ValidatePlayerState(PlayerState.Playing, PlayerState.Paused);

            var err = NativePlayer.SetSubtitlePositionOffset(Handle, offset);

            if (err == PlayerErrorCode.FeatureNotSupported)
            {
                throw new InvalidOperationException("No subtitle set");
            }

            err.ThrowIfFailed(this, "Failed to the subtitle offset of the player");
        }

        private void Prepare()
        {
            NativePlayer.Prepare(Handle).ThrowIfFailed(this, "Failed to prepare the player");
        }

        /// <summary>
        /// Called when the <see cref="Prepare"/> is invoked.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        protected virtual void OnPreparing()
        {
        }

        /// <summary>
        /// Prepares the media player for playback, asynchronously.
        /// </summary>
        /// <returns>A task that represents the asynchronous prepare operation.</returns>
        /// <remarks>To prepare the player, the player must be in the <see cref="PlayerState.Idle"/> state,
        ///     and a source must be set.</remarks>
        /// <exception cref="InvalidOperationException">No source is set.</exception>
        /// <exception cref="ObjectDisposedException">The player has already been disposed of.</exception>
        /// <exception cref="InvalidOperationException">The player is not in the valid state.</exception>
        /// <seealso cref="PlayerState.Preparing"/>
        /// <since_tizen> 3 </since_tizen>
        public virtual Task PrepareAsync()
        {
            if (_source == null)
            {
                throw new InvalidOperationException("No source is set.");
            }

            ValidatePlayerState(PlayerState.Idle);

            OnPreparing();

            SetPreparing();

            return Task.Factory.StartNew(() =>
            {
                try
                {
                    Prepare();
                }
                finally
                {
                    ClearPreparing();
                }
            }, CancellationToken.None,
                TaskCreationOptions.DenyChildAttach | TaskCreationOptions.LongRunning,
                TaskScheduler.Default);
        }

        /// <summary>
        /// Prepares the cancelable media player for playback, asynchronously.
        /// </summary>
        /// <param name="cancellationToken">The cancellation token to cancel preparing.</param>
        /// <seealso cref="CancellationToken"/>
        /// <returns>The task that represents the asynchronous prepare operation.</returns>
        /// <remarks>To prepare the player, the player must be in the <see cref="PlayerState.Idle"/> state,
        /// and a source must be set.
        /// The state must be <see cref="PlayerState.Preparing"/> to cancel preparing.
        /// When preparing is cancelled, a state will be changed to <see cref="PlayerState.Idle"/> from <see cref="PlayerState.Preparing"/>.</remarks>
        /// <exception cref="ObjectDisposedException">The player has already been disposed.</exception>
        /// <exception cref="InvalidOperationException">
        ///     Operation failed; internal error.
        ///     -or-<br/>
        ///     The player is not in the valid state.
        ///     </exception>
        /// <seealso cref="PrepareAsync()"/>
        /// <seealso cref="Unprepare()"/>
        /// <since_tizen> 6 </since_tizen>
        public virtual async Task PrepareAsync(CancellationToken cancellationToken)
        {
            ValidateNotDisposed();

            var taskCompletionSource = new TaskCompletionSource<bool>();

            if (_source == null)
            {
                throw new InvalidOperationException("No source is set.");
            }

            ValidatePlayerState(PlayerState.Idle);

            OnPreparing();

            SetPreparing();

            // register a callback to handle cancellation token anytime it occurs
            cancellationToken.Register(() =>
            {
                ValidatePlayerState(PlayerState.Preparing);

                // a user can get the state before finally block is called.
                ClearPreparing();

                Log.Warn(PlayerLog.Tag, $"preparing will be cancelled.");
                NativePlayer.Unprepare(Handle).ThrowIfFailed(this, "Failed to unprepare the player");

                taskCompletionSource.TrySetCanceled();
            });

            _prepareCallback = _ =>
            {
                Log.Warn(PlayerLog.Tag, $"prepared callback is called.");
                taskCompletionSource.TrySetResult(true);
            };

            try
            {
                NativePlayer.PrepareAsync(Handle, _prepareCallback, IntPtr.Zero).
                    ThrowIfFailed(this, "Failed to prepare the player");

                await taskCompletionSource.Task.ConfigureAwait(false);
            }
            finally
            {
                ClearPreparing();
            }
        }

        /// <summary>
        /// Unprepares the player.
        /// </summary>
        /// <remarks>
        ///     The most recently used source is reset and is no longer associated with the player. Playback is no longer possible.
        ///     If you want to use the player again, you have to set a source and call <see cref="PrepareAsync()"/> or
        ///     <see cref="PrepareAsync(CancellationToken)"/> again.
        ///     <para>
        ///     The player must be in the <see cref="PlayerState.Ready"/>, <see cref="PlayerState.Playing"/>, or <see cref="PlayerState.Paused"/> state.
        ///     It has no effect if the player is already in the <see cref="PlayerState.Idle"/> state.
        ///     </para>
        /// </remarks>
        /// <exception cref="ObjectDisposedException">The player has already been disposed of.</exception>
        /// <exception cref="InvalidOperationException">The player is not in the valid state.</exception>
        /// <since_tizen> 3 </since_tizen>
        public virtual void Unprepare()
        {
            if (State == PlayerState.Idle)
            {
                Log.Warn(PlayerLog.Tag, "idle state already");
                return;
            }
            ValidatePlayerState(PlayerState.Ready, PlayerState.Paused, PlayerState.Playing);

            NativePlayer.Unprepare(Handle).ThrowIfFailed(this, "Failed to unprepare the player");

            OnUnprepared();
        }

        /// <summary>
        /// Called after the <see cref="Player"/> is unprepared.
        /// </summary>
        /// <seealso cref="Unprepare"/>
        /// <since_tizen> 3 </since_tizen>
        protected virtual void OnUnprepared()
        {
            _source?.DetachFrom(this);
            _source = null;
        }

        /// <summary>
        /// Starts or resumes playback.
        /// </summary>
        /// <remarks>
        /// Sound can be mixed with other sounds if you don't control the stream focus using <see cref="ApplyAudioStreamPolicy"/>.<br/>
        ///      <para>Before Tizen 5.0, The player must be in the <see cref="PlayerState.Ready"/> or <see cref="PlayerState.Paused"/> state.
        ///      It has no effect if the player is already in the <see cref="PlayerState.Playing"/> state.</para>
        ///      <para>Since Tizen 5.0, The player must be in the <see cref="PlayerState.Ready"/>, <see cref="PlayerState.Playing"/>,
        ///      or <see cref="PlayerState.Paused"/> state.<br/>
        ///      In case of HTTP streaming playback, the player could be internally paused for buffering.
        ///      If the application calls this function during the buffering, the playback will be resumed by force
        ///      and the buffering message posting by <see cref="BufferingProgressChanged"/> will be stopped.<br/>
        ///      In other cases, the player will keep playing without returning error.</para>
        /// </remarks>
        /// <exception cref="ObjectDisposedException">The player has already been disposed of.</exception>
        /// <exception cref="InvalidOperationException">The player is not in the valid state.</exception>
        /// <seealso cref="PrepareAsync()"/>
        /// <seealso cref="PrepareAsync(CancellationToken)"/>
        /// <seealso cref="Stop"/>
        /// <seealso cref="Pause"/>
        /// <seealso cref="PlaybackCompleted"/>
        /// <seealso cref="ApplyAudioStreamPolicy"/>
        /// <seealso cref="BufferingProgressChanged"/>
        /// <since_tizen> 3 </since_tizen>
        public virtual void Start()
        {
            ValidatePlayerState(PlayerState.Ready, PlayerState.Paused, PlayerState.Playing);

            NativePlayer.Start(Handle).ThrowIfFailed(this, "Failed to start the player");
        }

        /// <summary>
        /// Stops playing the media content.
        /// </summary>
        /// <remarks>
        /// The player must be in the <see cref="PlayerState.Playing"/> or <see cref="PlayerState.Paused"/> state.
        /// It has no effect if the player is already in the <see cref="PlayerState.Ready"/> state.
        /// </remarks>
        /// <exception cref="ObjectDisposedException">The player has already been disposed of.</exception>
        /// <exception cref="InvalidOperationException">The player is not in the valid state.</exception>
        /// <seealso cref="Start"/>
        /// <seealso cref="Pause"/>
        /// <since_tizen> 3 </since_tizen>
        public virtual void Stop()
        {
            if (State == PlayerState.Ready)
            {
                Log.Warn(PlayerLog.Tag, "ready state already");
                return;
            }
            ValidatePlayerState(PlayerState.Paused, PlayerState.Playing);

            NativePlayer.Stop(Handle).ThrowIfFailed(this, "Failed to stop the player");
        }

        /// <summary>
        /// Pauses the player.
        /// </summary>
        /// <remarks>
        /// The player must be in the <see cref="PlayerState.Playing"/> state.
        /// It has no effect if the player is already in the <see cref="PlayerState.Paused"/> state.
        /// </remarks>
        /// <exception cref="ObjectDisposedException">The player has already been disposed of.</exception>
        /// <exception cref="InvalidOperationException">The player is not in the valid state.</exception>
        /// <seealso cref="Start"/>
        /// <since_tizen> 3 </since_tizen>
        public virtual void Pause()
        {
            if (State == PlayerState.Paused)
            {
                Log.Warn(PlayerLog.Tag, "pause state already");
                return;
            }

            ValidatePlayerState(PlayerState.Playing);

            NativePlayer.Pause(Handle).ThrowIfFailed(this, "Failed to pause the player");
        }

        private MediaSource _source;

        /// <summary>
        /// Determines whether MediaSource has set.
        /// This supports the product infrastructure and is not intended to be used directly from application code.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected bool HasSource => _source != null;

        /// <summary>
        /// Sets a media source for the player.
        /// </summary>
        /// <param name="source">A <see cref="MediaSource"/> that specifies the source for playback.</param>
        /// <remarks>The player must be in the <see cref="PlayerState.Idle"/> state.</remarks>
        /// <exception cref="ObjectDisposedException">The player has already been disposed of.</exception>
        /// <exception cref="InvalidOperationException">
        ///     The player is not in the valid state.<br/>
        ///     -or-<br/>
        ///     It is not able to assign the source to the player.
        ///     </exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when the permission is denied.</exception>
        /// <seealso cref="PrepareAsync()"/>
        /// <seealso cref="PrepareAsync(CancellationToken)"/>
        /// <since_tizen> 3 </since_tizen>
        public void SetSource(MediaSource source)
        {
            ValidatePlayerState(PlayerState.Idle);

            if (source != null)
            {
                source.AttachTo(this);
            }

            if (_source != null)
            {
                _source.DetachFrom(this);
            }

            _source = source;
        }

        /// <summary>
        /// Captures a video frame, asynchronously.
        /// </summary>
        /// <returns>A task that represents the asynchronous capture operation.</returns>
        /// <feature>http://tizen.org/feature/multimedia.raw_video</feature>
        /// <remarks>The player must be in the <see cref="PlayerState.Playing"/> or <see cref="PlayerState.Paused"/> state.</remarks>
        /// <exception cref="ObjectDisposedException">The player has already been disposed of.</exception>
        /// <exception cref="InvalidOperationException">The player is not in the valid state.</exception>
        /// <exception cref="NotSupportedException">The required feature is not supported.</exception>
        /// <since_tizen> 3 </since_tizen>
        public async Task<CapturedFrame> CaptureVideoAsync()
        {
            ValidationUtil.ValidateFeatureSupported(PlayerFeatures.RawVideo);

            ValidatePlayerState(PlayerState.Playing, PlayerState.Paused);

            TaskCompletionSource<CapturedFrame> t = new TaskCompletionSource<CapturedFrame>();

            NativePlayer.VideoCaptureCallback cb = (data, width, height, size, _) =>
            {
                Debug.Assert(size <= int.MaxValue);

                byte[] buf = new byte[size];
                Marshal.Copy(data, buf, 0, (int)size);

                t.TrySetResult(new CapturedFrame(buf, width, height));
            };

            using (var cbKeeper = ObjectKeeper.Get(cb))
            {
                NativePlayer.CaptureVideo(Handle, cb)
                    .ThrowIfFailed(this, "Failed to capture the video");

                return await t.Task;
            }
        }

        /// <summary>
        /// Gets the play position in milliseconds.
        /// </summary>
        /// <returns>The current position in milliseconds.</returns>
        /// <remarks>The player must be in the <see cref="PlayerState.Ready"/>, <see cref="PlayerState.Playing"/>,
        /// or <see cref="PlayerState.Paused"/> state.</remarks>
        /// <exception cref="ObjectDisposedException">The player has already been disposed of.</exception>
        /// <exception cref="InvalidOperationException">The player is not in the valid state.</exception>
        /// <seealso cref="SetPlayPositionAsync(int, bool)"/>
        /// <seealso cref="SetPlayPositionNanosecondsAsync(long, bool)"/>
        /// <seealso cref="GetPlayPositionNanoseconds"/>
        /// <since_tizen> 3 </since_tizen>
        public int GetPlayPosition()
        {
            ValidatePlayerState(PlayerState.Ready, PlayerState.Paused, PlayerState.Playing);

            int playPosition = 0;

            NativePlayer.GetPlayPosition(Handle, out playPosition).
                ThrowIfFailed(this, "Failed to get the play position of the player");

            Log.Info(PlayerLog.Tag, $"get play position : {playPosition}");

            return playPosition;
        }

        private void NativeSetPlayPosition(long position, bool accurate, bool nanoseconds,
            NativePlayer.SeekCompletedCallback cb)
        {
            //Check if it is nanoseconds or milliseconds.
            var ret = !nanoseconds ? NativePlayer.SetPlayPosition(Handle, (int)position, accurate, cb, IntPtr.Zero) :
                NativePlayer.SetPlayPositionNanoseconds(Handle, position, accurate, cb, IntPtr.Zero);

            //Note that we assume invalid param error is returned only when the position value is invalid.
            if (ret == PlayerErrorCode.InvalidArgument)
            {
                throw new ArgumentOutOfRangeException(nameof(position), position,
                    "The position is not valid.");
            }
            if (ret != PlayerErrorCode.None)
            {
                Log.Error(PlayerLog.Tag, "Failed to set play position, " + (PlayerError)ret);
            }
            ret.ThrowIfFailed(this, "Failed to set play position");
        }

        private async Task SetPlayPosition(long position, bool accurate, bool nanoseconds)
        {
            var taskCompletionSource = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);

            bool immediateResult = _source is MediaStreamSource;

            NativePlayer.SeekCompletedCallback cb = _ => taskCompletionSource.TrySetResult(true);

            using (var cbKeeper = ObjectKeeper.Get(cb))
            {
                NativeSetPlayPosition(position, accurate, nanoseconds, immediateResult ? null : cb);

                if (immediateResult)
                {
                    taskCompletionSource.TrySetResult(true);
                }
                await taskCompletionSource.Task;
            }
        }

        /// <summary>
        /// Sets the seek position for playback, asynchronously.
        /// </summary>
        /// <param name="position">The value indicating a desired position in milliseconds.</param>
        /// <param name="accurate">The value indicating whether the operation performs with accuracy.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        /// <remarks>
        ///     <para>The player must be in the <see cref="PlayerState.Ready"/>, <see cref="PlayerState.Playing"/>,
        ///     or <see cref="PlayerState.Paused"/> state.</para>
        ///     <para>If the <paramref name="accurate"/> is true, the play position will be adjusted as the specified <paramref name="position"/> value,
        ///     but this might be considerably slow. If false, the play position will be a nearest keyframe position.</para>
        ///     </remarks>
        /// <exception cref="ObjectDisposedException">The player has already been disposed of.</exception>
        /// <exception cref="InvalidOperationException">The player is not in the valid state.<br/>
        ///     -or-<br/>
        ///     In case of non-seekable content, the player will return error and keep playing without changing the play position.</exception>
        /// <exception cref="ArgumentOutOfRangeException">The specified position is not valid.</exception>
        /// <seealso cref="SetPlayPositionNanosecondsAsync(long, bool)"/>
        /// <seealso cref="GetPlayPosition"/>
        /// <seealso cref="GetPlayPositionNanoseconds"/>
        /// <since_tizen> 3 </since_tizen>
        public async Task SetPlayPositionAsync(int position, bool accurate)
        {
            ValidatePlayerState(PlayerState.Ready, PlayerState.Playing, PlayerState.Paused);

            await SetPlayPosition(position, accurate, false);
        }

        /// <summary>
        /// Gets the play position in nanoseconds.
        /// </summary>
        /// <returns>The current position in nanoseconds.</returns>
        /// <remarks>The player must be in the <see cref="PlayerState.Ready"/>, <see cref="PlayerState.Playing"/>,
        /// or <see cref="PlayerState.Paused"/> state.</remarks>
        /// <exception cref="ObjectDisposedException">The player has already been disposed of.</exception>
        /// <exception cref="InvalidOperationException">The player is not in the valid state.</exception>
        /// <seealso cref="SetPlayPositionAsync(int, bool)"/>
        /// <seealso cref="SetPlayPositionNanosecondsAsync(long, bool)"/>
        /// <seealso cref="GetPlayPosition"/>
        /// <since_tizen> 5 </since_tizen>
        public long GetPlayPositionNanoseconds()
        {
            ValidatePlayerState(PlayerState.Ready, PlayerState.Paused, PlayerState.Playing);

            NativePlayer.GetPlayPositionNanoseconds(Handle, out long playPosition).
                ThrowIfFailed(this, "Failed to get the play position(nsec) of the player");

            Log.Info(PlayerLog.Tag, $"get play position(nsec) : {playPosition}");

            return playPosition;
        }

        /// <summary>
        /// Sets the seek position in nanoseconds for playback, asynchronously.
        /// </summary>
        /// <param name="position">The value indicating a desired position in nanoseconds.</param>
        /// <param name="accurate">The value indicating whether the operation performs with accuracy.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        /// <remarks>
        ///     <para>The player must be in the <see cref="PlayerState.Ready"/>, <see cref="PlayerState.Playing"/>,
        ///     or <see cref="PlayerState.Paused"/> state.</para>
        ///     <para>If the <paramref name="accurate"/> is true, the play position will be adjusted as the specified <paramref name="position"/> value,
        ///     but this might be considerably slow. If false, the play position will be a nearest keyframe position.</para>
        ///     </remarks>
        /// <exception cref="ObjectDisposedException">The player has already been disposed of.</exception>
        /// <exception cref="InvalidOperationException">The player is not in the valid state.<br/>
        ///     -or-<br/>
        ///     In case of non-seekable content, the player will return error and keep playing without changing the play position.</exception>
        /// <exception cref="ArgumentOutOfRangeException">The specified position is not valid.</exception>
        /// <seealso cref="SetPlayPositionAsync(int, bool)"/>
        /// <seealso cref="GetPlayPosition"/>
        /// <seealso cref="GetPlayPositionNanoseconds"/>
        /// <since_tizen> 5 </since_tizen>
        public async Task SetPlayPositionNanosecondsAsync(long position, bool accurate)
        {
            ValidatePlayerState(PlayerState.Ready, PlayerState.Playing, PlayerState.Paused);

            await SetPlayPosition(position, accurate, true);
        }

        /// <summary>
        /// Sets the playback rate.
        /// </summary>
        /// <param name="rate">The value for the playback rate. Valid range is -5.0 to 5.0, inclusive.</param>
        /// <remarks>
        ///     <para>The player must be in the <see cref="PlayerState.Ready"/>, <see cref="PlayerState.Playing"/>,
        ///     or <see cref="PlayerState.Paused"/> state.</para>
        ///     <para>The sound will be muted, when the playback rate is under 0.0 or over 2.0.</para>
        /// </remarks>
        /// <exception cref="ObjectDisposedException">The player has already been disposed of.</exception>
        /// <exception cref="InvalidOperationException">
        ///     The player is not in the valid state.<br/>
        ///     -or-<br/>
        ///     Streaming playback.
        /// </exception>
        /// <exception cref="ArgumentOutOfRangeException">
        ///     <paramref name="rate"/> is less than -5.0.<br/>
        ///     -or-<br/>
        ///     <paramref name="rate"/> is greater than 5.0.<br/>
        ///     -or-<br/>
        ///     <paramref name="rate"/> is zero.
        /// </exception>
        /// <exception cref="NotAvailableException">
        ///     If audio offload is enabled by calling <see cref="AudioOffload.IsEnabled"/>. (Since tizen 6.0)
        /// </exception>
        /// <seealso cref="AudioOffload"/>
        /// <since_tizen> 3 </since_tizen>
        public void SetPlaybackRate(float rate)
        {
            if (rate < -5.0F || 5.0F < rate || rate == 0.0F)
            {
                throw new ArgumentOutOfRangeException(nameof(rate), rate, "Valid range is -5.0 to 5.0 (except 0.0)");
            }

            AudioOffload.CheckDisabled();
            ValidatePlayerState(PlayerState.Ready, PlayerState.Playing, PlayerState.Paused);

            NativePlayer.SetPlaybackRate(Handle, rate).ThrowIfFailed(this, "Failed to set the playback rate.");
        }

        /// <summary>
        /// Applies the audio stream policy.
        /// </summary>
        /// <param name="policy">The <see cref="AudioStreamPolicy"/> to apply.</param>
        /// <remarks>
        /// The player must be in the <see cref="PlayerState.Idle"/> state.<br/>
        /// <br/>
        /// <see cref="Player"/> does not support all <see cref="AudioStreamType"/>.<br/>
        /// Supported types are <see cref="AudioStreamType.Media"/>, <see cref="AudioStreamType.System"/>,
        /// <see cref="AudioStreamType.Alarm"/>, <see cref="AudioStreamType.Notification"/>,
        /// <see cref="AudioStreamType.Emergency"/>, <see cref="AudioStreamType.VoiceInformation"/>,
        /// <see cref="AudioStreamType.RingtoneVoip"/> and <see cref="AudioStreamType.MediaExternalOnly"/>.
        /// </remarks>
        /// <exception cref="ObjectDisposedException">
        ///     The player has already been disposed of.<br/>
        ///     -or-<br/>
        ///     <paramref name="policy"/> has already been disposed of.
        /// </exception>
        /// <exception cref="InvalidOperationException">The player is not in the valid state.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="policy"/> is null.</exception>
        /// <exception cref="NotSupportedException">
        ///     The required feature is not supported.<br/>
        ///     -or-<br/>
        ///     <see cref="AudioStreamType"/> of <paramref name="policy"/> is not supported on the current platform.
        /// </exception>
        /// <seealso cref="AudioStreamPolicy"/>
        /// <feature>http://tizen.org/feature/multimedia.player.stream_info</feature>
        /// <since_tizen> 3 </since_tizen>
        public void ApplyAudioStreamPolicy(AudioStreamPolicy policy)
        {
            ValidationUtil.ValidateFeatureSupported("http://tizen.org/feature/multimedia.player.stream_info");

            if (policy == null)
            {
                throw new ArgumentNullException(nameof(policy));
            }

            ValidatePlayerState(PlayerState.Idle);

            var ret = NativePlayer.SetAudioPolicyInfo(Handle, policy.Handle);

            if (ret == PlayerErrorCode.InvalidArgument)
            {
                throw new NotSupportedException("The specified policy is not supported on the current system.");
            }

            ret.ThrowIfFailed(this, "Failed to set the audio stream policy to the player");
        }

        /// <summary>
        /// Set the relative ROI (Region Of Interest) area as a decimal fraction based on the video source.
        /// It can be regarded as zooming operation because the specified video area will be rendered to fit to the display.
        /// </summary>
        /// <param name="scaleRectangle">The containing the ROI area information.</param>
        /// <remarks>
        /// This function requires the ratio of the each coordinate and size to the video resolution size
        /// to guarantee of showing the same area for the dynamic resolution video content.
        /// This function have to be called after setting <see cref="Display"/>
        /// </remarks>
        /// <exception cref="ObjectDisposedException">The player has already been disposed of.</exception>
        /// <exception cref="InvalidOperationException">
        ///     Operation failed; internal error.
        ///     -or-<br/>
        ///     The <see cref="PlayerDisplayType"/> is not set to <see cref="PlayerDisplayType.Overlay"/>.
        ///     </exception>
        /// <exception cref="ArgumentOutOfRangeException">
        ///     <paramref name="scaleRectangle.ScaleX"/> is less than 0.0 or greater than 1.0.<br/>
        ///     -or-<br/>
        ///     <paramref name="scaleRectangle.ScaleY"/> is less than 0.0 or greater than 1.0.<br/>
        ///     -or-<br/>
        ///     <paramref name="scaleRectangle.ScaleWidth"/> is less than or equal to 0.0 or greater than 1.0.<br/>
        ///     -or-<br/>
        ///     <paramref name="scaleRectangle.ScaleHeight"/> is less than or equal to 0.0 or greater than 1.0.
        /// </exception>
        /// <seealso cref="ScaleRectangle"/>
        /// <seealso cref="Display"/>
        /// <seealso cref="StreamInfo.GetVideoProperties"/>
        /// <seealso cref="GetVideoRoi"/>
        /// <since_tizen> 5 </since_tizen>
        public void SetVideoRoi(ScaleRectangle scaleRectangle)
        {
            ValidateNotDisposed();

            if (scaleRectangle.ScaleX < 0 || scaleRectangle.ScaleX > 1)
            {
                throw new ArgumentOutOfRangeException(nameof(scaleRectangle.ScaleX), scaleRectangle.ScaleX, "Valid range is 0 to 1.0");
            }
            if (scaleRectangle.ScaleY < 0 || scaleRectangle.ScaleY > 1)
            {
                throw new ArgumentOutOfRangeException(nameof(scaleRectangle.ScaleY), scaleRectangle.ScaleY, "Valid range is 0 to 1.0");
            }
            if (scaleRectangle.ScaleWidth <= 0 || scaleRectangle.ScaleWidth > 1)
            {
                throw new ArgumentOutOfRangeException(nameof(scaleRectangle.ScaleWidth), scaleRectangle.ScaleWidth, "Valid range is 0 to 1.0 (except 0.0)");
            }
            if (scaleRectangle.ScaleHeight <= 0 || scaleRectangle.ScaleHeight > 1)
            {
                throw new ArgumentOutOfRangeException(nameof(scaleRectangle.ScaleHeight), scaleRectangle.ScaleHeight, "Valid range is 0 to 1.0 (except 0.0)");
            }

            NativePlayer.SetVideoRoi(Handle, scaleRectangle.ScaleX, scaleRectangle.ScaleY, scaleRectangle.ScaleWidth, scaleRectangle.ScaleHeight).ThrowIfFailed(this, "Failed to set the video roi area.");
        }

        /// <summary>
        /// Get the relative ROI (Region Of Interest) area as a decimal fraction based on the video source.
        /// </summary>
        /// <returns>The <see cref="ScaleRectangle"/> containing the ROI area information.</returns>
        /// <remarks>The specified ROI area is valid only in <see cref="PlayerDisplayType.Overlay"/>.</remarks>
        /// <exception cref="ObjectDisposedException">The player has already been disposed of.</exception>
        /// <exception cref="InvalidOperationException">
        ///     Operation failed; internal error.
        ///     </exception>
        /// <seealso cref="Display"/>
        /// <seealso cref="StreamInfo.GetVideoProperties"/>
        /// <seealso cref="SetVideoRoi"/>
        /// <since_tizen> 5 </since_tizen>
        public ScaleRectangle GetVideoRoi()
        {
            ValidateNotDisposed();

            NativePlayer.GetVideoRoi(Handle, out var scaleX, out var scaleY,
                out var scaleWidth, out var scaleHeight).ThrowIfFailed(this, "Failed to get the video roi area");

            return new ScaleRectangle(scaleX, scaleY, scaleWidth, scaleHeight);
        }

        /// <summary>
        /// This supports the product infrastructure and is not intended to be used directly from application code.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected MediaPacket GetMediaPacket(IntPtr handle)
        {
            MediaPacket mediaPacket = handle != IntPtr.Zero ? MediaPacket.From(handle) :
                throw new ArgumentException("MediaPacket handle is invalid.", nameof(handle));

            return mediaPacket;
        }
        #endregion

        #region Preparing state

        private int _isPreparing;

        private bool IsPreparing()
        {
            return Interlocked.CompareExchange(ref _isPreparing, 1, 1) == 1;
        }

        /// <summary>
        /// This supports the product infrastructure and is not intended to be used directly from application code.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected void SetPreparing()
        {
            Interlocked.Exchange(ref _isPreparing, 1);
        }

        /// <summary>
        /// This supports the product infrastructure and is not intended to be used directly from application code.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected void ClearPreparing()
        {
            Interlocked.Exchange(ref _isPreparing, 0);
        }
        #endregion

        /// <summary>
        /// Enable to decode an audio data for exporting PCM from a data.
        /// </summary>
        /// <param name="format">The media format handle required to audio PCM specification.
        /// The format has to include <see cref="AudioMediaFormat.MimeType"/>,
        /// <see cref="AudioMediaFormat.Channel"/> and <see cref="AudioMediaFormat.SampleRate"/>.
        /// If the format is NULL, the original PCM format or platform default PCM format will be applied.</param>
        /// <param name="option">The audio extract option.</param>
        /// <remarks><para>The player must be in the <see cref="PlayerState.Idle"/> state.</para>
        /// <para>A <see cref="AudioDataDecoded"/> event is called in a separate thread(not in the main loop).</para>
        /// <para>The audio PCM data can be retrieved using a <see cref="AudioDataDecoded"/> event as a media packet
        /// and it is available until it's destroyed by <see cref="MediaPacket.Dispose()"/>.
        /// The packet has to be destroyed as quickly as possible after rendering the data
        /// and all the packets have to be destroyed before <see cref="Unprepare"/> is called.</para>
        /// <para>This function could be unavailable depending on the audio codec type.</para></remarks>
        /// <exception cref="ObjectDisposedException">The player has already been disposed of.</exception>
        /// <exception cref="ArgumentException">The value is not valid.</exception>
        /// <exception cref="InvalidOperationException">
        ///     Operation failed; internal error.
        ///     -or-<br/>
        ///     The player is not in the valid state.
        ///     </exception>
        /// <exception cref="NotAvailableException">If audio offload is enabled by calling <see cref="AudioOffload.IsEnabled"/>. (Since tizen 6.0)
        ///     -or-<br/>
        ///     The function is not available depending on the audio codec type. (Since tizen 6.0)
        /// </exception>
        /// <seealso cref="PlayerAudioExtractOption"/>
        /// <seealso cref="DisableExportingAudioData"/>
        /// <seealso cref="AudioOffload"/>
        /// <seealso cref="AudioCodecType"/>
        /// <since_tizen> 6 </since_tizen>
        public void EnableExportingAudioData(AudioMediaFormat format, PlayerAudioExtractOption option)
        {
            ValidationUtil.ValidateEnum(typeof(PlayerAudioExtractOption), option, nameof(option));
            AudioOffload.CheckDisabled();
            ValidatePlayerState(PlayerState.Idle);

            _audioFrameDecodedCallback = (IntPtr packetHandle, IntPtr userData) =>
            {
                var handler = AudioDataDecoded;
                if (handler != null)
                {
                    Log.Debug(PlayerLog.Tag, "packet : " + packetHandle.ToString());
                    handler.Invoke(this,
                        new AudioDataDecodedEventArgs(MediaPacket.From(packetHandle)));
                }
                else
                {
                    MediaPacket.From(packetHandle).Dispose();
                }
            };

            NativePlayer.SetAudioFrameDecodedCb(Handle, format == null ? IntPtr.Zero : format.AsNativeHandle(), option,
                _audioFrameDecodedCallback, IntPtr.Zero).ThrowIfFailed(this, "Failed to register the _audioFrameDecoded");
        }

        /// <summary>
        /// Disable to decode an audio data.
        /// </summary>
        /// <remarks>The player must be in the <see cref="PlayerState.Idle"/> or <see cref="PlayerState.Ready"/>
        /// state.
        /// This function could be unavailable depending on the audio codec type.</remarks>
        /// <exception cref="ObjectDisposedException">The player has already been disposed of.</exception>
        /// <exception cref="InvalidOperationException">The player is not in the valid state.</exception>
        /// <exception cref="NotAvailableException">The function is not available depending on the audio codec type. (Since tizen 6.0)</exception>
        /// <seealso cref="EnableExportingAudioData"/>
        /// <seealso cref="AudioCodecType"/>
        /// <since_tizen> 6 </since_tizen>
        public void DisableExportingAudioData()
        {
            ValidatePlayerState(PlayerState.Idle, PlayerState.Ready);

            NativePlayer.UnsetAudioFrameDecodedCb(Handle).
                ThrowIfFailed(this, "Failed to unset the AudioFrameDecoded");

            _audioFrameDecodedCallback = null;
        }

        /// <summary>
        /// Enables to decode a video data for every frame.
        /// </summary>
        /// <remarks><para>The player must be in the <see cref="PlayerState.Idle"/> state,
        /// but <see cref="Multimedia.Display"/> must not be set.</para>
        /// <para>A <see cref="VideoFrameDecoded"/> event is called in a separate thread, not called in the main loop.</para>
        /// <para>The video frame can be retrieved using a <see cref="VideoFrameDecoded"/> event with a media packet parameter.
        /// If you change the media packet in the <see cref="VideoFrameDecoded"/> event, it will be displayed on the device.
        /// The callback function holds the same buffer that is drawn on the display device.
        /// and the <see cref="MediaPacket"/> is available until it is destroyed by <see cref="MediaPacket.Dispose()"/>.
        /// It is recommended to destroy the packet as quickly as possible after the decoded data is rendered on the display.
        /// All the packets have to be destroyed before <see cref="Unprepare"/> is called.</para></remarks>
        /// <feature>http://tizen.org/feature/multimedia.raw_video</feature>
        /// <exception cref="NotSupportedException">The required feature is not supported.</exception>
        /// <exception cref="ObjectDisposedException">The player has already been disposed of.</exception>
        /// <exception cref="InvalidOperationException">
        ///     Operation failed; internal error.
        ///     -or-<br/>
        ///     The player is not in the valid state.
        ///     </exception>
        /// <seealso cref="DisableExportingVideoFrame"/>
        /// <since_tizen> 6 </since_tizen>
        public void EnableExportingVideoFrame()
        {
            ValidationUtil.ValidateFeatureSupported(PlayerFeatures.RawVideo);
            ValidatePlayerState(PlayerState.Idle);

            if (Display != null)
            {
                throw new InvalidOperationException("Display must be none.");
            }

            _videoFrameDecodedCallback = (packetHandle, _) =>
            {
                var handler = VideoFrameDecoded;
                if (handler != null)
                {
                    Log.Debug(PlayerLog.Tag, "packet : " + packetHandle);
                    handler.Invoke(this,
                        new VideoFrameDecodedEventArgs(MediaPacket.From(packetHandle)));
                }
                else
                {
                    MediaPacket.From(packetHandle).Dispose();
                }
            };

            NativePlayer.SetVideoFrameDecodedCb(Handle, _videoFrameDecodedCallback).
                ThrowIfFailed(this, "Failed to register the VideoFrameDecoded");
        }

        /// <summary>
        /// Disables to decode a video data.
        /// </summary>
        /// <remarks>The player must be in the <see cref="PlayerState.Idle"/> or <see cref="PlayerState.Ready"/>
        /// state.</remarks>
        /// <feature>http://tizen.org/feature/multimedia.raw_video</feature>
        /// <exception cref="NotSupportedException">The required feature is not supported.</exception>
        /// <exception cref="ObjectDisposedException">The player has already been disposed of.</exception>
        /// <exception cref="InvalidOperationException">The player is not in the valid state.</exception>
        /// <seealso cref="EnableExportingVideoFrame"/>
        /// <since_tizen> 6 </since_tizen>
        public void DisableExportingVideoFrame()
        {
            ValidationUtil.ValidateFeatureSupported(PlayerFeatures.RawVideo);
            ValidatePlayerState(PlayerState.Idle, PlayerState.Ready);

            NativePlayer.UnsetVideoFrameDecodedCb(Handle).
                ThrowIfFailed(this, "Failed to unset the VideoFrameDecoded");

            _videoFrameDecodedCallback = null;
        }
    }
}
