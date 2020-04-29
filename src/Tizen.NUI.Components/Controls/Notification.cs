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
using System.ComponentModel;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Components
{
    /// <summary>
    /// Notification helps to raise a notification window with a content View.
    /// </summary>
    /// <privilege>http://tizen.org/privilege/window.priority.set</privilege>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class Notification
    {
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
        /// <exception cref="ArgumentException">Thrown when a given contentView is invalid.</exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Notification(View contentView)
        {
            if (contentView == null)
            {
                throw (new ArgumentException("Input contentView should not be null."));
            }

            ContentView = contentView;
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
        [EditorBrowsable(EditorBrowsableState.Never)]
        public View ContentView { get; private set; }

        private Window NotificationWindow
        {
            get
            {
                if (notificationWindow == null)
                {
                    notificationWindow = new Window(null, true);
                    notificationWindow.Type = WindowType.Notification;
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
                if (timer != null && timer.IsRunning())
                {
                    timer.Stop();
                }

                timer = value;
            }
        }

        /// <summary>
        /// Post a notification window with the content view.
        /// </summary>
        /// <param name="duration">Dismiss the notification window after given time. The value 0 won't dismiss the notification.</param>
        /// <returns>The current Notification instance.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void Post(uint duration = 0)
        {
            if (state != NotificationState.Ready)
            {
                return;
            }

            var window = NotificationWindow;

            ApplyLevel(level);

            ApplyPositionSize(positionSize);

            ApplyDismissOnTouch(dismissOnTouch);

            NotificationWindow.Add(ContentView);

            if (duration > 0)
            {
                Timer.Interval = duration;
            }

            state = NotificationState.Post;

            onPostAnimation.Play();
        }

        /// <summary>
        /// Sets a priority level for the specified notification window.
        /// </summary>
        /// <param name="level">The notification window level.</param>
        /// <returns>The current Notification instance.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Notification SetLevel(NotificationLevel level)
        {
            this.level = level;

            if (state == NotificationState.Post)
            {
                ApplyLevel(level);
            }

            return this;
        }

        /// <summary>
        /// Sets position and size of the notification window.
        /// </summary>
        /// <param name="positionSize">The position and size information in rectangle.</param>
        /// <returns>The current Notification instance.</returns>
        /// <exception cref="ArgumentException">Thrown when a given positionSize is invalid.</exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Notification SetPositionSize(Rectangle positionSize)
        {
            if (positionSize == null)
            {
                throw (new ArgumentException("Input positionSize should not be null."));
            }

            this.positionSize = positionSize;

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
        [EditorBrowsable(EditorBrowsableState.Never)]
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
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Notification SetAnimationOnDismiss(Animation animation)
        {
            this.onDismissAnimation = animation;

            return this;
        }

        /// <summary>
        /// Dismiss the notification window.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
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
        /// Dismiss the notification window directly without calling OnDismissDelegate.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void ForceQuit()
        {
            if (state != NotificationState.Post && state != NotificationState.Dismiss)
            {
                return;
            }

            ClearAll();
        }

        private void DestroyNotificationWindow()
        {
            notificationWindow.Hide();

            notificationWindow.Dispose();

            notificationWindow = null;
        }

        private void ApplyLevel(NotificationLevel level)
        {
            NotificationWindow.SetNotificationLevel(level);
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
            notificationWindow.Remove(ContentView);

            Timer = null;

            DestroyNotificationWindow();

            state = NotificationState.Ready;
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
            onDismissAnimation.Finished -= OnAnimationEnd;

            ClearAll();
        }
    }
}