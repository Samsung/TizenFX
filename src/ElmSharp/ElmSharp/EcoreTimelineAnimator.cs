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
    /// EcoreTimelineAnimator is a helper class, it provides functions to manager animations.
    /// </summary>
    /// <since_tizen> preview </since_tizen>
    public class EcoreTimelineAnimator
    {
        double _runtime;
        IntPtr _animator;
        Action _timelineCallback;
        Interop.Ecore.EcoreTimelineCallback _nativeCallback;
        double _position;

        /// <summary>
        /// It occurs when the animator is complete.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public event EventHandler Finished;

        /// <summary>
        /// Creates and initializes a new instance of the EcoreTimelineAnimator class.
        /// </summary>
        /// <param name="runtime">The time to run in seconds</param>
        /// <param name="timelineCallback">Functions called at each time line</param>
        /// <since_tizen> preview </since_tizen>
        public EcoreTimelineAnimator(double runtime, Action timelineCallback)
        {
            _runtime = runtime;
            _nativeCallback = NativeCallback;
            _timelineCallback = timelineCallback;
            _position = 0;
        }

        /// <summary>
        /// Gets whether the animation is running.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public bool IsRunning { get; private set; }

        /// <summary>
        /// Gets the current position of the animation.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public double Position => _position;

        /// <summary>
        /// Starts an animator that runs for a limited time.for a limited time.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public void Start()
        {
            IsRunning = true;
            _animator = Interop.Ecore.ecore_animator_timeline_add(_runtime, _nativeCallback, IntPtr.Zero);
        }

        /// <summary>
        /// Stops an animator that running.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public void Stop()
        {
            IsRunning = false;
            _animator = IntPtr.Zero;
        }

        /// <summary>
        /// Suspends the specified animator.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public void Freeze()
        {
            Interop.Ecore.ecore_animator_freeze(_animator);
        }

        /// <summary>
        /// Restores execution of the specified animator.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public void Thaw()
        {
            Interop.Ecore.ecore_animator_thaw(_animator);
        }

        /// <summary>
        /// Callback that is called when ticks off
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        protected void OnTimeline()
        {
            _timelineCallback();
        }

        bool NativeCallback(IntPtr data, double pos)
        {
            _position = pos;
            if (!IsRunning) return false;
            OnTimeline();
            if (pos == 1.0)
            {
                IsRunning = false;
                _animator = IntPtr.Zero;
                Finished?.Invoke(this, EventArgs.Empty);
            }
            return true;
        }
    }
}
