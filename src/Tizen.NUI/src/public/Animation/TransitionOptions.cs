/*
 * Copyright (c) 2021 Samsung Electronics Co., Ltd All Rights Reserved
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 * http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

using System;
using System.ComponentModel;
using Tizen.Applications;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI
{
    /// <summary>
    /// This TransitionOptions class is a class to control Transition motion.
    /// This class includes multiple options for the Transition.
    /// NUI supports various kinds of Transitions such as App transition, Page transition, and so on.
    /// </summary>
    /// <seealso cref="NUIApplication.TransitionOptions" />
    /// <since_tizen> 9 </since_tizen>
    public class TransitionOptions : IDisposable
    {
        private bool disposed = false;
        private FrameProvider frameProvider;
        private DefaultFrameBroker frameBroker;
        private bool enableTransition = false;
        private Window mainWindow;
        private View animatedTarget;

        /// <summary>
        /// Initializes the TransitionOptions class.
        /// </summary>
        /// <param name="window">The window instance of NUI Window</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public TransitionOptions(Window window)
        {
            mainWindow = window;
        }

        /// <summary>
        /// Initializes the TransitionOptions class.
        /// </summary>
        /// <since_tizen> 9 </since_tizen>
        public TransitionOptions()
        {
        }

        /// <summary>
        /// Set animated view of seamless animation.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public View AnimatedTarget
        {
            get
            {
                return animatedTarget;
            }
            set
            {
                animatedTarget = value;
            }
        }

        /// <summary>
        /// Gets or sets transition enable
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool EnableTransition
        {
            get
            {
                return enableTransition;
            }

            set
            {
                if (value)
                {
                    frameBroker = new DefaultFrameBroker(mainWindow);
                    frameBroker.mainView = animatedTarget;
                    frameBroker.AnimationInitialized += FrameBroker_TransitionAnimationInitialized;
                    frameBroker.AnimationFinished += FrameBroker_TransitionAnimationFinished;
                    EnableProvider();
                }
                enableTransition = value;
            }
        }

        private void EnableProvider()
        {
            frameProvider = new FrameProvider(mainWindow);
            frameProvider.Shown += FrameProvider_Shown;
            frameProvider.Hidden += FrameProvider_Hidden;
        }

        /// <summary>
        /// String tag to find View pair to be used in Page transition.
        /// If there is a View have same TransitionTag in a next or previous Page.
        /// The View will be pair for transition.
        /// This is property for Page Transition.
        /// </summary>
        /// <since_tizen> 9 </since_tizen>
        public string TransitionTag { set; get; } = null;

        /// <summary>
        /// Property for Page transition.
        /// A View could be transition with its child Views or without them.
        /// Default value is false
        /// </summary>
        /// <since_tizen> 9 </since_tizen>
        public bool TransitionWithChild { set; get; } = false;

        /// <summary>
        /// Gets or sets the forward animation of launching
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public TransitionAnimation ForwardAnimation
        {
            get
            {
                return frameBroker?.ForwardAnimation;
            }
            set
            {
                if (frameBroker != null)
                {
                    frameBroker.ForwardAnimation = value;
                }
            }
        }

        /// <summary>
        /// Gets or sets the backward animation of launching
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public TransitionAnimation BackwardAnimation

        {
            get
            {
                return frameBroker?.BackwardAnimation;
            }
            set
            {
                if (frameBroker != null)
                {
                    frameBroker.BackwardAnimation = value;
                }
            }
        }

        /// <summary>
        /// Emits the event when the animation is started.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public delegate void AnimationEventHandler(bool direction);

        /// <summary>
        /// Emits the event when the animation is started.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public event AnimationEventHandler AnimationInitialized;

        /// <summary>
        /// Emits the event when the animation is finished.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public event AnimationEventHandler AnimationFinished;

        private void FrameBroker_TransitionAnimationFinished(bool direction)
        {
            AnimationFinished?.Invoke(direction);
        }

        private void FrameBroker_TransitionAnimationInitialized(bool direction)
        {
            AnimationInitialized?.Invoke(direction);
        }

        /// <summary>
        /// Occurs whenever the window is shown on caller application.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public event EventHandler CallerScreenShown;

        /// <summary>
        /// Occurs whenever the window is hidden on caller application.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public event EventHandler CallerScreenHidden;

        private void FrameProvider_Shown(object sender, EventArgs e)
        {
            Bundle bundle = new Bundle();
            //Set information of shared object
            frameProvider?.NotifyShowStatus(bundle);

            CallerScreenShown?.Invoke(this, e);
            bundle.Dispose();
            bundle = null;
        }

        private void FrameProvider_Hidden(object sender, EventArgs e)
        {
            Bundle bundle = new Bundle();
            //Set information of shared object
            frameProvider?.NotifyHideStatus(bundle);

            CallerScreenHidden?.Invoke(this, e);
            bundle.Dispose();
            bundle = null;
        }

        internal void SendLaunchRequest(AppControl appControl)
        {
            this.frameBroker.SendLaunchRequest(appControl, true);
        }

        /// <summary>
        /// Hidden API (Inhouse API).
        /// Dispose.
        /// </summary>
        /// <param name="disposing"></param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (frameBroker != null)
                {
                    frameBroker.Dispose();
                }

                if (frameProvider != null)
                {
                    frameProvider.Dispose();
                }
                disposed = true;
            }
        }

        /// <summary>
        /// Dispose for IDisposable pattern
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void Dispose()
        {
            Dispose(true);
            System.GC.SuppressFinalize(this);
        }
    }
}
