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
    /// The AnimationView is designed to show and play animation of vector graphics based content.
    /// Currently ElmSharp AnimationView is supporting only json format (known for Lottie file as well).
    /// </summary>
    /// <since_tizen> preview </since_tizen>
    public class AnimationView : EvasObject
    {
        private SmartEvent _started;
        private SmartEvent _repeated;
        private SmartEvent _finished;
        private SmartEvent _paused;
        private SmartEvent _resumed;
        private SmartEvent _stopped;
        private SmartEvent _updated;

        /// <summary>
        /// Creates and initializes a new instance of the AnimationView class.
        /// </summary>
        /// <param name="parent">The parent is a given container, which will be attached by AnimationView as a child. It's <see cref="EvasObject"/> type.</param>
        /// <since_tizen> preview </since_tizen>
        public AnimationView(EvasObject parent) : base(parent)
        {
            _started = new SmartEvent(this, this.Handle, "play,start");
            _repeated = new SmartEvent(this, this.Handle, "play,repeat");
            _finished = new SmartEvent(this, this.Handle, "play,done");
            _paused = new SmartEvent(this, this.Handle, "play,pause");
            _resumed = new SmartEvent(this, this.Handle, "play,resume");
            _stopped = new SmartEvent(this, this.Handle, "play,stop");
            _updated = new SmartEvent(this, this.Handle, "play,update");

            _started.On += (sender, e) =>
            {
                Started?.Invoke(this, EventArgs.Empty);
            };

            _repeated.On += (sender, e) =>
            {
                Repeated?.Invoke(this, EventArgs.Empty);
            };

            _finished.On += (sender, e) =>
            {
                Finished?.Invoke(this, EventArgs.Empty);
            };

            _paused.On += (sender, e) =>
            {
                Paused?.Invoke(this, EventArgs.Empty);
            };

            _resumed.On += (sender, e) =>
            {
                Resumed?.Invoke(this, EventArgs.Empty);
            };

            _stopped.On += (sender, e) =>
            {
                Stopped?.Invoke(this, EventArgs.Empty);
            };

            _updated.On += (sender, e) =>
            {
                Updated?.Invoke(this, EventArgs.Empty);
            };
        }

        /// <summary>
        /// It occurs when the animation is just started.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public event EventHandler Started;

        /// <summary>
        /// It occurs when the animation is just repeated.
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
        /// It occurs when the animation is updated to the next frame.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public event EventHandler Updated;

        /// <summary>
        /// Sets or gets whether to play animation automatically.
        /// <remarks>
        /// If AutoPlay is true, animation will be started when it's readied.
        /// The condition of AutoPlay is when AnimationView opened file successfully, yet to play it plus when the object is visible.
        /// If AnimationView is disabled, invisible, it turns to pause state then resume animation when it's visible again.
        /// This AutoPlay will be only affected to the next animation source. So must be called before SetAnimation()
        /// </remarks>
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public bool AutoPlay
        {
            get
            {
                return Interop.Elementary.elm_animation_view_auto_play_get(Handle);
            }
            set
            {
                Interop.Elementary.elm_animation_view_auto_play_set(Handle, value);
            }
        }

        /// <summary>
        /// Sets or gets whether to turn on/off animation looping.
        /// <remarks>
        /// If AutoRepeat is true, it repeats animation when animation frame is reached to end.
        /// This AutoRepeat mode is valid to both Play and ReversePlay cases.
        /// </remarks>
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public bool AutoRepeat
        {
            get
            {
                return Interop.Elementary.elm_animation_view_auto_repeat_get(Handle);
            }
            set
            {
                Interop.Elementary.elm_animation_view_auto_repeat_set(Handle, value);
            }
        }

        /// <summary>
        /// Sets or gets the animation speed.
        /// <remarks>
        /// Control animation speed by multiplying Speed value.
        /// If you want to play animation double-time faster, you can give Speed 2.
        /// If you want to play animation double-time slower, you can give Speed 0.5.
        /// Speed must be greater than zero.
        /// </remarks>
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public double Speed
        {
            get
            {
                return Interop.Elementary.elm_animation_view_speed_get(Handle);
            }
            set
            {
                Interop.Elementary.elm_animation_view_speed_set(Handle, value);
            }
        }

        /// <summary>
        /// Get the duration of animation in seconds.
        /// </summary>
        /// <remarks>
        /// Returns total duration time of current animation in the seconds.
        /// If current animation source isn't animatable, it returns zero.
        /// </remarks>
        /// <since_tizen> preview </since_tizen>
        public double DurationTime
        {
            get
            {
                return Interop.Elementary.elm_animation_view_duration_time_get(Handle);
            }
        }

        /// <summary>
        /// Sets or gets current keyframe position of animation view.
        /// <remarks>
        /// When you required to jump on a certain frame instantly,
        /// you can change current keyframe by using this property
        /// The range of keyframe is 0 ~ 1.
        /// </remarks>
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public double KeyFrame
        {
            get
            {
                return Interop.Elementary.elm_animation_view_keyframe_get(Handle);
            }
            set
            {
                Interop.Elementary.elm_animation_view_keyframe_set(Handle, value);
            }
        }

        /// <summary>
        /// Sets the animation source file.
        /// </summary>
        /// <param name="file">The animation file path.</param>
        /// <since_tizen> preview </since_tizen>
        public void SetAnimation(string file)
        {
            Interop.Elementary.elm_animation_view_file_set(Handle, file, null);
        }

        /// <summary>
        /// Play animation one time instantly when it's available.
        /// <remarks>
        /// If current keyframe is on a certain position by playing reverse, this will play forward from there.
        /// Play request will be ignored if animation source is not set yet or animation is paused state or it's already on playing.
        /// </remarks>
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public void Play()
        {
            Interop.Elementary.elm_animation_view_play(Handle);
        }

        /// <summary>
        /// Play animation one time instantly when it's available.
        /// <remarks>
        /// If current keyframe is on a certain position by playing reverse and isReverse is ture, this will play forward from there.
        /// And if current keyframe is on a certain position by playing and isReverse is false, this will play backward from there.
        /// Play request will be ignored if animation source is not set yet or animation is paused state or it's already on playing.
        /// </remarks>
        /// </summary>
        /// <param name="isReverse">Whether the animation play or reverse play.</param>
        /// <since_tizen> preview </since_tizen>
        public void Play(bool isReverse)
        {
            if (!isReverse)
            {
                Interop.Elementary.elm_animation_view_play(Handle);
            }
            else
            {
                Interop.Elementary.elm_animation_view_play_back(Handle);
            }
        }

        /// <summary>
        /// Pause current animation instantly.
        /// <remarks>
        /// Once animation is paused, animation view must get resume to play continue again.
        /// Animation must be on playing or playing back status.
        /// </remarks>
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public void Pause()
        {
            Interop.Elementary.elm_animation_view_pause(Handle);
        }

        /// <summary>
        /// Resume paused animation to continue animation.
        /// </summary>
        /// <remarks>
        /// This resume must be called on animation paused status.
        /// </remarks>
        /// <since_tizen> preview </since_tizen>
        public void Resume()
        {
            Interop.Elementary.elm_animation_view_resume(Handle);
        }

        /// <summary>
        /// Stop playing animation.
        /// <remarks>
        /// Stop animation instatly regardless of it's status and reset to
        /// show first frame of animation.Even though current animation is paused,
        /// the animation status will be stopped.
        /// </remarks>
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public void Stop()
        {
            Interop.Elementary.elm_animation_view_stop(Handle);
        }

        /// <summary>
        /// Creates a AnimationView handle.
        /// </summary>
        /// <param name="parent">Parent EvasObject.</param>
        /// <returns>Handle IntPtr.</returns>
        /// <since_tizen> preview </since_tizen>
        protected override IntPtr CreateHandle(EvasObject parent)
        {
            return Interop.Elementary.elm_animation_view_add(parent.Handle);
        }
    }
}
