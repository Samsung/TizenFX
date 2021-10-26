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
    /// This ApplicationTransitionManager class is a class to control transition motion of application.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class ApplicationTransitionManager : IDisposable
    {
        private bool disposed = false;
        private FrameProvider frameProvider;
        private DefaultFrameBroker frameBroker;
        private Window mainWindow;
        private FrameType? frameType;
        private View sourceView;

        private static ApplicationTransitionManager instance;

        /// <summary>
        /// ApplicationTransitionManager Instance for singleton
        /// </summary>
        public static ApplicationTransitionManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ApplicationTransitionManager();
                }
                return instance;
            }
        }

        /// <summary>
        /// Initializes the ApplicationTransitionManager class.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        private ApplicationTransitionManager()
        {
            mainWindow = Window.Instance;
        }

        /// <summary>
        /// Gets or sets SourceView, it is a view for seamless transition of application.
        /// If you set SourceView, SourceView is changed to a screen of the application executing.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public View SourceView
        {
            get
            {
                return sourceView;
            }
            set
            {
                sourceView = value;
            }
        }

        /// <summary>
        /// Configures the transition window.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Window TransitionWindow
        {
            get
            {
                return mainWindow;
            }
            set
            {
                if (mainWindow == value)
                {
                    Tizen.Log.Info("NUI", "mainWindow has already same window");
                    return;
                }

                if (value == null)
                {
                    Tizen.Log.Info("NUI", "value is null");
                    return;
                }

                mainWindow = value;

                //Reset FrmaeBroker or FrameProvider
                if (frameBroker != null)
                {
                    frameBroker.Dispose();
                    frameBroker = null;
                    frameBroker = new DefaultFrameBroker(mainWindow);
                }

                if (frameProvider != null)
                {
                    frameProvider.Dispose();
                    frameProvider = null;
                    frameProvider = new FrameProvider(mainWindow);
                }
            }
        }

        /// <summary>
        /// Enable FrameBroker(Caller) or FrameProvider(Callee)
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public FrameType? ApplicationFrameType
        {
            get
            {
                return frameType;
            }
            set
            {
                if (frameType != null)
                {
                    Tizen.Log.Info("NUI", "FrameType is already set");
                    return;
                }

                if (frameType == value)
                {
                    Tizen.Log.Info("NUI", "FameType has already same type");
                    return;
                }

                if (value == null)
                {
                    Tizen.Log.Info("NUI", "value is null");
                    return;
                }

                frameType = value;
                switch (frameType)
                {
                    case FrameType.FrameBroker:
                        EnableFrameBroker();
                        break;

                    case FrameType.FrameProvider:
                        EnableFrameProvider();
                        break;
                }
            }
        }

        /// <summary>
        /// Transition properties for the transition of Window during this application call new application.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public TransitionBase AppearingTransition
        {
            get
            {
                return frameBroker?.AppearingTransition;
            }
            set
            {
                if (frameBroker != null)
                {
                    frameBroker.AppearingTransition = value;
                }
            }
        }

        /// <summary>
        /// Transition properties for the transition of Window during new application is exited.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public TransitionBase DisappearingTransition
        {
            get
            {
                return frameBroker?.DisappearingTransition;
            }
            set
            {
                if (frameBroker != null)
                {
                    frameBroker.DisappearingTransition = value;
                }
            }
        }

        /// <summary>
        /// AnimationEventHandler for FrameBroker animation
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public delegate void AnimationEventHandler(bool direction);

        /// <summary>
        /// Emits the event when the animation is started.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public event AnimationEventHandler FrameBrokerAnimationInitialized;

        /// <summary>
        /// Emits the event when the animation is finished.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public event AnimationEventHandler FrameBrokerAnimationFinished;

        /// <summary>
        /// Occurs whenever the window is shown on caller application.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public event EventHandler FrameProviderShown;

        /// <summary>
        /// Occurs whenever the window is hidden on caller application.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public event EventHandler FrameProviderHidden;

        private void FrameBroker_TransitionAnimationInitialized(bool direction)
        {
            FrameBrokerAnimationInitialized?.Invoke(direction);
        }

        private void FrameBroker_TransitionAnimationFinished(bool direction)
        {
            FrameBrokerAnimationFinished?.Invoke(direction);
        }

        private void FrameProvider_Shown(object sender, EventArgs e)
        {
            FrameProviderShown?.Invoke(this, e);

            //Set information of shared object
            Bundle bundle = new Bundle();
            frameProvider?.NotifyShowStatus(bundle);

            bundle.Dispose();
            bundle = null;
        }

        private void FrameProvider_Hidden(object sender, EventArgs e)
        {
            FrameProviderHidden?.Invoke(this, e);

            //Set information of shared object
            Bundle bundle = new Bundle();
            frameProvider?.NotifyHideStatus(bundle);

            bundle.Dispose();
            bundle = null;
        }

        private void EnableFrameBroker()
        {
            if (frameBroker == null)
            {
                frameBroker = new DefaultFrameBroker(mainWindow);
                frameBroker.AnimationInitialized += FrameBroker_TransitionAnimationInitialized;
                frameBroker.AnimationFinished += FrameBroker_TransitionAnimationFinished;
            }
        }

        private void EnableFrameProvider()
        {
            if (frameProvider == null)
            {
                frameProvider = new FrameProvider(mainWindow);
                frameProvider.Shown += FrameProvider_Shown;
                frameProvider.Hidden += FrameProvider_Hidden;
            }
        }

        /// <summary>
        /// Launch an application using transition animation.
        /// </summary>
        /// <param name="appControl"></param>
        /// <privilege>http://tizen.org/privilege/appmanager.launch</privilege>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void LaunchRequestWithTransition(AppControl appControl)
        {
            frameBroker.SendLaunchRequest(appControl);
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
            GC.SuppressFinalize(this);
        }

    }

    /// <summary>
    /// Enable FrameBroker(Caller) or FrameProvider(Callee)
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public enum FrameType
    {
        /// <summary>
        /// FrameBroker type - Caller application.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        FrameBroker,
        /// <summary>
        /// FrameProvider type - Callee application.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        FrameProvider,
    }
}
