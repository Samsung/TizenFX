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
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI
{
    /// <summary>
    /// Default FrameBroker of NUI Application.
    /// </summary>
    internal class DefaultFrameBroker : FrameBrokerBase
    {
        private const int DefaultTransitionDuration = 500;

        private Window window;
        private ImageView providerImage;
        private bool isAnimating;
        private bool direction;
        private AnimationType animationType;

        private TransitionSet transitionSet;
        private Transition defaultTransition = new Transition()
        {
            TimePeriod = new TimePeriod(DefaultTransitionDuration),
            AlphaFunction = new AlphaFunction(AlphaFunction.BuiltinFunctions.Default),
        };

        internal DefaultFrameBroker(Window window) : base(window)
        {
            this.window = window;
            isAnimating = false;
        }

        /// <summary>
        /// AnimationEvent Handler for broker animation
        /// </summary>
        internal delegate void AnimationEventHandler(bool direction);

        /// <summary>
        /// Emits the event when the animation is started.
        /// </summary>
        internal event AnimationEventHandler AnimationInitialized;

        /// <summary>
        /// Emits the event when the animation is finished.
        /// </summary>
        internal event AnimationEventHandler AnimationFinished;

        /// <summary>
        /// Transition properties for the transition of Window during this application call new application.
        /// </summary>
        internal TransitionBase AppearingTransition { get; set; }

        /// <summary>
        /// Transition properties for the transition of Window during new application is exited.
        /// </summary>
        internal TransitionBase DisappearingTransition { get; set; }

        private void SetAnimationType()
        {
            if (ApplicationTransitionManager.Instance.SourceView != null)
            {
                animationType = direction ? AnimationType.SeamlessAnimationAppearing : AnimationType.SeamlessAnimationDisappearing;
            }
            else if (AppearingTransition != null || DisappearingTransition != null)
            {
                animationType = direction ? AnimationType.TransitionBaseAppearing : AnimationType.TransitionBaseDisappearing;
            }
            else
            {
                animationType = AnimationType.None;
            }
        }

        private void CreateProviderImage(FrameData frame)
        {
            providerImage = new ImageView();
            providerImage.Size = new Size(window.WindowSize);
            providerImage.ParentOrigin = ParentOrigin.Center;
            providerImage.PivotPoint = PivotPoint.Center;
            providerImage.PositionUsesPivotPoint = true;
            providerImage.AddRenderer(GetRenderer(frame));
        }

        private void PlayTransitionAnimation()
        {
            transitionSet = CreateTransitionSet();

            window.Add(providerImage);
            transitionSet.Play();
            // Notifies that the animation is started to provider.
            StartAnimation();
        }

        private TransitionSet CreateTransitionSet()
        {
            TransitionSet transitionSet = new TransitionSet();

            if (animationType != AnimationType.None)
            {
                TransitionItemBase transitionItem = null;
                switch (animationType)
                {
                    case AnimationType.SeamlessAnimationAppearing:
                        transitionItem = defaultTransition.CreateTransition(ApplicationTransitionManager.Instance.SourceView, providerImage, true);
                        break;
                    case AnimationType.SeamlessAnimationDisappearing:
                        transitionItem = defaultTransition.CreateTransition(providerImage, ApplicationTransitionManager.Instance.SourceView, false);
                        break;
                    case AnimationType.TransitionBaseAppearing:
                        transitionItem = AppearingTransition.CreateTransition(providerImage, true);
                        break;
                    case AnimationType.TransitionBaseDisappearing:
                        transitionItem = DisappearingTransition.CreateTransition(providerImage, false);
                        break;
                }
                if (transitionItem != null)
                {
                    transitionSet.AddTransition(transitionItem);
                    transitionSet.Finished += TransitionSetFinished;
                    transitionItem.Dispose();
                    transitionItem = null;
                }
            }
            return transitionSet;
        }

        private void TransitionSetFinished(object sender, EventArgs e)
        {
            (sender as TransitionSet).Finished -= TransitionSetFinished;
            providerImage.Unparent();
            providerImage.Dispose();
            providerImage = null;

            FinishAnimation();
            AnimationFinished?.Invoke(direction);
            isAnimating = false;
        }

        /// <summary>
        /// Occurs Whenever the frame is resumed.
        /// </summary>
        /// <param name="frame">The frame data.</param>
        /// <remarks>
        /// When the frame has been prepared, this function is called.
        /// The caller can start animations, To notify that the animation is started, the caller should call StartAnimation().
        /// After the animation is finished, the caller should call FinishAnimation() to notify.
        /// </remarks>
        protected override void OnFrameResumed(FrameData frame)
        {
            Log.Info("NUI", "OnFrameResumed : " + frame.DirectionForward);
            direction = frame.DirectionForward;

            if (isAnimating)
            {
                Log.Warn("NUI", "The OnFrameResumed() : Playing...");
                return;
            }
            Log.Info("NUI", "The OnFrameResumed() : Play Application Transition Animation");
            isAnimating = true;
            AnimationInitialized?.Invoke(direction);

            SetAnimationType();
            CreateProviderImage(frame);
            PlayTransitionAnimation();
        }

        private enum AnimationType
        {
            None = 0,
            SeamlessAnimationAppearing = 1,
            SeamlessAnimationDisappearing = 2,
            TransitionBaseAppearing = 3,
            TransitionBaseDisappearing = 4,
        }
    }
}
