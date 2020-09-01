/*
 * Copyright(c) 2020 Samsung Electronics Co., Ltd.
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
 *
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Components
{
    /// <summary>
    /// Notification helps to raise a notification window with a content View.
    /// </summary>
    /// <since_tizen> 8 </since_tizen>
    public class Notification : Disposable
    {
        private static HashSet<Notification> instanceSet;

        private Window notificationWindow;

        private Timer timer;

        private NotificationLevel level = NotificationLevel.Base;

        private Rectangle positionSize;

        private bool dismissOnTouch = false;

        private Animation onPostAnimation;

        private Animation onDismissAnimation;

        private NotificationState state = NotificationState.Ready;

        /// <summary>
        /// Create a notification with a content View.
        /// </summary>
        /// <param name="contentView">The content view instance to display in the notification window.</param>
        /// <exception cref="ArgumentException">Thrown when a given contentView is invalid.</exception>
        /// <since_tizen> 8 </since_tizen>
        public Notification(View contentView) : base()
        {
            ContentView = contentView ?? throw new ArgumentException("Input contentView should not be null.");
        }

        private enum NotificationState
        {
            Ready,
            Post,
            Dismiss,
        }

        /// <summary>
        /// The content view received in a constructor.
        /// </summary>
        /// <since_tizen> 8 </since_tizen>
        public View ContentView { get; private set; }

        private Window NotificationWindow
        {
            get
            {
                if (notificationWindow == null)
                {
                    notificationWindow = new Window(null, true)
                    {
                        Type = WindowType.Notification,
                    };
                    notificationWindow.Show();
                }

                return notificationWindow;
            }
            set => notificationWindow = value;
        }

        private Timer Timer
        {
            get
            {
                if (timer == null)
                {
                    timer = new Timer(0);
                    timer.Tick += OnTimeOut;
                }

                return timer;
            }
            set
            {
                if (timer != null)
                {
                    timer.Stop();
                    timer.Tick -= OnTimeOut;

                    if (value == null)
                    {
                        timer.Dispose();
                    }
                }

                timer = value;
            }
        }

        /// <summary>
        /// Post a notification window with the content view.
        /// </summary>
        /// <param name="duration">Dismiss the notification window after given time. The value 0 won't dismiss the notification.</param>
        /// <returns>The current Notification instance.</returns>
        /// <privilege>http://tizen.org/privilege/window.priority.set</privilege>
        /// <exception cref="UnauthorizedAccessException">Thrown when the application does not have proper privilege.</exception>
        /// <since_tizen> 8 </since_tizen>
        public void Post(uint duration = 0)
        {
            if (state != NotificationState.Ready)
            {
                return;
            }

            if (!ApplyLevel(level))
            {
                throw new UnauthorizedAccessException("Cannot post a Notification: Permission Denied");
            }

            ApplyPositionSize(positionSize);

            ApplyDismissOnTouch(dismissOnTouch);

            NotificationWindow.Add(ContentView);

            if (duration > 0)
            {
                Timer.Interval = duration;
            }

            state = NotificationState.Post;

            onPostAnimation?.Play();

            RegisterInstance(this);
        }

        /// <summary>
        /// Sets a priority level for the specified notification window.
        /// The default level is NotificationLevel.Base.
        /// </summary>
        /// <param name="level">The notification window level.</param>
        /// <returns>The current Notification instance.</returns>
        /// <privilege>http://tizen.org/privilege/window.priority.set</privilege>
        /// <exception cref="UnauthorizedAccessException">Thrown when the application does not have proper privilege.</exception>
        /// <since_tizen> 8 </since_tizen>
        public Notification SetLevel(NotificationLevel level)
        {
            this.level = level;

            if (state == NotificationState.Post && !ApplyLevel(level))
            {
                throw new UnauthorizedAccessException("Cannot set notification level: Permission Denied");
            }

            return this;
        }

        /// <summary>
        /// Sets position and size of the notification window.
        /// </summary>
        /// <param name="positionSize">The position and size information in rectangle.</param>
        /// <returns>The current Notification instance.</returns>
        /// <exception cref="ArgumentException">Thrown when a given positionSize is invalid.</exception>
        /// <since_tizen> 8 </since_tizen>
        public Notification SetPositionSize(Rectangle positionSize)
        {
            this.positionSize = positionSize ?? throw (new ArgumentException("Input positionSize should not be null."));

            if (state == NotificationState.Post || state == NotificationState.Dismiss)
            {
                ApplyPositionSize(positionSize);
            }

            return this;
        }

        /// <summary>
        /// Sets whether listen to touch event to dismiss notification window.
        /// </summary>
        /// <param name="dismissOnTouch">Dismiss notification window on touch if the value is true.</param>
        /// <returns>The current Notification instance.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Notification SetDismissOnTouch(bool dismissOnTouch)
        {
            if (this.dismissOnTouch == dismissOnTouch)
            {
                return this;
            }

            this.dismissOnTouch = dismissOnTouch;

            if (state == NotificationState.Post)
            {
                ApplyDismissOnTouch(dismissOnTouch);
            }

            return this;
        }

        /// <summary>
        /// Sets a user-defined animation to play when posting the notification.
        /// The Notification will play the given animation right after the notification window pops up.
        /// </summary>
        /// <param name="animation">The animation to play.</param>
        /// <since_tizen> 8 </since_tizen>
        public Notification SetAnimationOnPost(Animation animation)
        {
            this.onPostAnimation = animation;

            return this;
        }

        /// <summary>
        /// Sets a user-defined animation to play when dismiss the notification.
        /// On dismiss, the given animation is played, and after the playback is completed the notification window is undisplayed.
        /// </summary>
        /// <param name="animation">The animation to play.</param>
        /// <since_tizen> 8 </since_tizen>
        public Notification SetAnimationOnDismiss(Animation animation)
        {
            this.onDismissAnimation = animation;

            return this;
        }

        /// <summary>
        /// Dismiss the notification window.
        /// </summary>
        /// <since_tizen> 8 </since_tizen>
        public void Dismiss()
        {
            if (state != NotificationState.Post)
            {
                return;
            }

            state = NotificationState.Dismiss;

            if (onDismissAnimation != null)
            {
                onDismissAnimation.Finished += OnAnimationEnd;

                onDismissAnimation.Play();

                Timer = null;

                ApplyDismissOnTouch(false);

                return;
            }

            ClearAll();
        }

        /// <summary>
        /// Dismiss the notification window directly without waiting the onDismissAnimation finished.
        /// </summary>
        /// <since_tizen> 8 </since_tizen>
        public void ForceQuit()
        {
            if (state != NotificationState.Post && state != NotificationState.Dismiss)
            {
                return;
            }

            ClearAll();
        }

        /// <inheritdoc/>
        /// <since_tizen> 8 </since_tizen>
        protected override void Dispose(DisposeTypes type)
        {
            if (disposed)
            {
                return;
            }

            if (type == DisposeTypes.Explicit)
            {
                ClearAll();

                positionSize?.Dispose();
                onPostAnimation?.Dispose();
                onDismissAnimation?.Dispose();
            }

            base.Dispose(type);
        }

        private static void RegisterInstance(Notification instance)
        {
            if (instanceSet == null)
            {
                instanceSet = new HashSet<Notification>();
            }

            instanceSet.Add(instance);
        }

        private static void UnregisterInstance(Notification instance)
        {
            if (instanceSet == null)
            {
                return;
            }

            instanceSet.Remove(instance);

            if (instanceSet.Count == 0)
            {
                instanceSet = null;
            }
        }

        private void DestroyNotificationWindow()
        {
            notificationWindow.Hide();

            notificationWindow.Dispose();

            notificationWindow = null;
        }

        private bool ApplyLevel(NotificationLevel level)
        {
            return NotificationWindow.SetNotificationLevel(level);
        }

        private void ApplyPositionSize(Rectangle positionSize)
        {
            if (positionSize != null)
            {
                NotificationWindow.SetPositionSize(positionSize);
            }
        }

        private void ApplyDismissOnTouch(bool dismissOnTouch)
        {
            if (dismissOnTouch)
            {
                NotificationWindow.TouchEvent += OnWindowTouch;
            }
            else
            {
                NotificationWindow.TouchEvent -= OnWindowTouch;
            }
        }

        private void ClearAll()
        {
            if (onDismissAnimation != null)
            {
                onDismissAnimation.Finished -= OnAnimationEnd;

                onDismissAnimation.Stop();
            }

            notificationWindow.Remove(ContentView);

            notificationWindow.TouchEvent -= OnWindowTouch;

            Timer = null;

            DestroyNotificationWindow();

            state = NotificationState.Ready;

            UnregisterInstance(this);
        }

        private void OnWindowTouch(object target, Window.TouchEventArgs args)
        {
            Dismiss();
        }

        private bool OnTimeOut(object target, Timer.TickEventArgs args)
        {
            Dismiss();

            return false;
        }

        private void OnAnimationEnd(object target, EventArgs args)
        {
            ClearAll();
        }
    }
}