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

namespace ElmSharp
{
    /// <summary>
    /// Enumeration for the AnimationView state.
    /// </summary>
    /// <since_tizen> preview </since_tizen>
    public enum AnimationState
    {
        /// <summary>
        /// Animation is not ready to play.
        /// </summary>
        NotReady,

        /// <summary>
        /// Animation is on playing.
        /// </summary>
        Play,

        /// <summary>
        /// Animation is on playing back (rewinding).
        /// </summary>
        PlayBack,

        /// <summary>
        /// Animation has been paused. To continue animation, call Resume().
        /// </summary>
        Pause,

        /// <summary>
        /// Animation view successfully loaded a file then readied for playing. Otherwise after finished animation or stopped forcely by request.
        /// </summary>
        Stop,
    }

    /// <summary>
    /// The AnimationView is designed to show and play animation of vector graphics based content.
    /// Currently ElmSharp AnimationView is supporting only json format (known for Lottie file as well).
    /// </summary>
    /// <since_tizen> preview </since_tizen>
    public class AnimationView : EvasObject
    {
        private IntPtr _animation = IntPtr.Zero;
        private IntPtr _animator = IntPtr.Zero;
        private long _totalFrame;
        private long _curFrame = -1;
        private double _startPos;
        private double _curPos;
        private bool _isPlayBack;

        /// <summary>
        /// Creates and initializes a new instance of the AnimationView class.
        /// </summary>
        /// <param name="parent">The parent is a given container, which will be attached by EvasImage as a child. It's <see cref="EvasObject"/> type.</param>
        /// <since_tizen> preview </since_tizen>
        public AnimationView(EvasObject parent) : base(parent)
        {
            Interop.Evas.evas_object_image_filled_set(Handle, true);
            Interop.Evas.evas_object_image_alpha_set(Handle, true);
            State = AnimationState.NotReady;
            Speed = 1.0;

            Showed += _Showed;
            Hid += _Hid;
        }

        /// <summary>
        /// It occurs when the animation is just started.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public event EventHandler Started;

        /// <summary>
        /// It occurs when the animation is just repeated
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public event EventHandler Repeated;

        /// <summary>
        /// It occurs when the animation is just finished.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public event EventHandler Finished;

        /// <summary>
        /// It occurs when the animation is just paused.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public event EventHandler Paused;

        /// <summary>
        /// It occurs when the animation is just resumed.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public event EventHandler Resumed;

        /// <summary>
        /// It occurs when the animation is just stopped.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public event EventHandler Stopped;

        /// <summary>
        /// Sets or gets whether to play animation automatically.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public bool AutoPlay { get; set; }

        /// <summary>
        /// Sets or gets whether to turn on/off animation looping.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public bool AutoRepeat { get; set; }

        /// <summary>
        /// Sets or gets the animation speed.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public double Speed { get; set; }

        /// <summary>
        /// Get the duration of animation in seconds.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public double DurationTime { get; private set; }

        /// <summary>
        /// Gets current animation state.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public AnimationState State { get; private set; }

        /// <summary>
        /// Sets or gets the size of the given object.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public Size Size
        {
            get
            {
                int w, h;
                Interop.Evas.evas_object_image_size_get(RealHandle, out w, out h);
                return new Size(w, h);
            }
            set
            {
                Interop.Evas.evas_object_image_size_set(RealHandle, value.Width, value.Height);
            }
        }

        /// <summary>
        /// Sets the source file from where an animation object must fetch the real image data.
        /// </summary>
        /// <param name="file">The animation file path.</param>
        /// <since_tizen> preview </since_tizen>
        public void SetFile(string file)
        {
            if (_animator != IntPtr.Zero)
            {
                Interop.Ecore.ecore_animator_del(_animator);
                _animator = IntPtr.Zero;
            }

            if (_animation != IntPtr.Zero)
            {
                Interop.LottiePlayer.lottie_animation_destroy(_animation);
                _animation = IntPtr.Zero;
            }

            _animation = Interop.LottiePlayer.lottie_animation_from_file(file);
            if (_animation != IntPtr.Zero)
            {
                _totalFrame = Interop.LottiePlayer.lottie_animation_get_totalframe(_animation);
                DurationTime = Interop.LottiePlayer.lottie_animation_get_duration(_animation);
                State = AnimationState.Stop;
                Seek(0.0);
            }
        }

        /// <summary>
        /// Play animation one time instantly when it's available.
        /// If current keyframe is on a certain position by playing back, this will play forward from there.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public void Play()
        {
            if (_animation == IntPtr.Zero) return;

            if (State == AnimationState.PlayBack || State == AnimationState.Stop)
            {
                if (_animator != IntPtr.Zero) Interop.Ecore.ecore_animator_del(_animator);

                if (State == AnimationState.Stop)
                    _startPos = 0.0;
                else
                    _startPos = _curPos;

                State = AnimationState.Play;
                _isPlayBack = false;

                _animator = Interop.Ecore.ecore_animator_timeline_add(DurationTime / Speed, AnimatorCallback, IntPtr.Zero);

                Started?.Invoke(this, EventArgs.Empty);
            }
        }

        /// <summary>
        /// Play back animation one time instantly when it's available.
        /// If current keyframe is on a certain position by playing, this will play backward from there.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public void PlayBack()
        {
            if (_animation == IntPtr.Zero) return;

            if (State == AnimationState.Play || State == AnimationState.Stop)
            {
                if (_animator != IntPtr.Zero) Interop.Ecore.ecore_animator_del(_animator);

                if (State == AnimationState.Stop)
                    _startPos = 1.0;
                else
                    _startPos = _curPos;

                State = AnimationState.PlayBack;
                _isPlayBack = true;
                
                _animator = Interop.Ecore.ecore_animator_timeline_add(DurationTime / Speed, AnimatorCallback, IntPtr.Zero);
                
                Started?.Invoke(this, EventArgs.Empty);
            }
        }

        /// <summary>
        /// Stop playing animation.
        /// Stop animation instatly regardless of it's status and reset to
        /// show first frame of animation.Even though current animation is paused,
        /// the animation status will be stopped.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public void Stop()
        {
            if (_animation == IntPtr.Zero) return;
            if (State == AnimationState.NotReady || State == AnimationState.Stop) return;
            
            if (_animator != IntPtr.Zero)
            {
                Interop.Ecore.ecore_animator_del(_animator);
                _animator = IntPtr.Zero;
            }

            State = AnimationState.Stop;
            Stopped?.Invoke(this, EventArgs.Empty);

            Seek(0.0);
        }

        /// <summary>
        /// Pause current animation instantly.
        /// Once animation is paused, animation view must get resume to play continue again.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public void Pause()
        {
            if (_animation == IntPtr.Zero) return;

            if (State == AnimationState.Play || State == AnimationState.PlayBack)
            {
                if (_animator != IntPtr.Zero)
                {
                    Interop.Ecore.ecore_animator_del(_animator);
                    _animator = IntPtr.Zero;
                }
                State = AnimationState.Pause;
                Paused?.Invoke(this, EventArgs.Empty);
            }
        }

        /// <summary>
        /// Resume paused animation to continue animation.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public void Resume()
        {
            if (_animation == IntPtr.Zero) return;
            if (State != AnimationState.Pause) return;

            if (_animator != IntPtr.Zero) Interop.Ecore.ecore_animator_del(_animator);

            _startPos = _curPos;

            if (_isPlayBack)
                State = AnimationState.PlayBack;
            else
                State = AnimationState.Play;
            
            _animator = Interop.Ecore.ecore_animator_timeline_add(DurationTime / Speed, AnimatorCallback, IntPtr.Zero);
            
            Resumed?.Invoke(this, EventArgs.Empty);
        }

        private void Seek(double pos)
        {
            if (_animation == IntPtr.Zero) return;

            if (pos < 0) pos = 0;
            else if (pos > 1) pos = 1;

            _curPos = pos;

            long frame = (long)(pos * _totalFrame);
            if (_curFrame == frame) return;
            _curFrame = frame;

            int w, h;
            Interop.Evas.evas_object_image_size_get(RealHandle, out w, out h);

            IntPtr buffer = Interop.Evas.evas_object_image_data_get(RealHandle, true);
            int bytePerLine = Interop.Evas.evas_object_image_stride_get(RealHandle);

            Interop.LottiePlayer.lottie_animation_render_async(_animation, (int)_curFrame, buffer, w, h, bytePerLine);
            Interop.LottiePlayer.lottie_animation_render_flush(_animation);

            Interop.Evas.evas_object_image_data_set(RealHandle, buffer);
            Interop.Evas.evas_object_image_data_update_add(RealHandle, 0, 0, w, h);
        }

        private bool AnimatorCallback(IntPtr data, double pos)
        {
            double nextPos = 0.0;
            if (_isPlayBack)
                nextPos = _startPos - pos;
            else
                nextPos = _startPos + pos;

            if (nextPos > 1.0) nextPos = 1.0;
            else if (nextPos < 0.0) nextPos = 0.0;

            Seek(nextPos);

            if ((!_isPlayBack && nextPos == 1.0) || (_isPlayBack && nextPos == 0.0))
            {
                _animator = IntPtr.Zero;
                _curPos = 0;
                State = AnimationState.Stop;

                if (AutoRepeat)
                {
                    if (!_isPlayBack)
                        Play();
                    else
                        PlayBack();

                    Repeated?.Invoke(this, EventArgs.Empty);
                }
                else
                    Finished?.Invoke(this, EventArgs.Empty);

                return false;
            }

            return true;
        }

        private void _Showed(object sender, EventArgs e)
        {
            if (AutoPlay) Play();
        }

        private void _Hid(object sender, EventArgs e)
        {
            Stop();
        }

        /// <summary>
        /// Creates a widget handle.
        /// </summary>
        /// <param name="parent">Parent EvasObject.</param>
        /// <returns>Handle IntPtr.</returns>
        /// <since_tizen> preview </since_tizen>
        protected override IntPtr CreateHandle(EvasObject parent)
        {
            IntPtr evas = Interop.Evas.evas_object_evas_get(parent.Handle);
            return Interop.Evas.evas_object_image_add(evas);
        }
    }
}
