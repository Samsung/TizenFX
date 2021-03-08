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
    internal class DefaultFrameBroker : FrameBrokerBase
    {
        private Window window;
        private ImageView providerImage;
        private bool isAnimating;

        public delegate void AnimationEventHandler(bool direction);
        internal event AnimationEventHandler AnimationInitialized;
        internal event AnimationEventHandler AnimationFinished;

        internal View mainView;
        private bool direction;

        internal Animation animation;

        internal DefaultFrameBroker(Window window) : base(window)
        {
            this.window = window;
            isAnimating = false;
        }

        protected override void OnFrameResumed(FrameData frame)
        {
            base.OnFrameResumed(frame);

            direction = frame.DirectionForward;

            if (isAnimating)
            {
                return;
            }
            isAnimating = true;

            AnimationInitialized?.Invoke(frame.DirectionForward);

            if (frame.DirectionForward)
            {
                PlayAnimateTo(frame, ForwardAnimation);
            }
            else
            {
                PlayAnimateTo(frame, BackwardAnimation);
            }

            StartAnimation();
        }

        protected override void OnFramePaused()
        {
            base.OnFramePaused();
            animation?.Stop();

            ResetImage();

            isAnimating = false;
        }

        private void PlayAnimateTo(FrameData frame, TransitionAnimation transition)
        {
            if (transition != null)
            {
                //ResetImage();
                if (!providerImage)
                {
                    providerImage = new ImageView(transition.DefaultImageStyle);
                    providerImage.ParentOrigin = transition.DefaultImageStyle.ParentOrigin;
                    providerImage.PivotPoint = transition.DefaultImageStyle.PivotPoint;
                    providerImage.PositionUsesPivotPoint = true;
                    providerImage.AddRenderer(GetRenderer(frame));
                    if (mainView)
                    {
                        mainView.Add(providerImage);
                        providerImage.LowerToBottom();
                    }
                    else
                    {
                        window.Add(providerImage);
                    }
                }
                else
                {
                    providerImage.ApplyStyle(transition.DefaultImageStyle.Clone());
                }

                providerImage.Show();
                int propertyCount = transition.AnimationDataList.Count;
                animation = new Animation(transition.DurationMilliSeconds + 80);

                for (int i = 0; i < propertyCount; i++)
                {
                    animation.PropertyList.Add(transition.AnimationDataList[i].Property);
                    animation.DestValueList.Add(transition.AnimationDataList[i].DestinationValue);
                    animation.StartTimeList.Add(80 + transition.AnimationDataList[i].StartTime);
                    animation.EndTimeList.Add(80 + transition.AnimationDataList[i].EndTime);
                }
                animation.PlayAnimateTo(providerImage);
                animation.Finished += Ani_Finished;
            }
            else
            {
                FinishAnimation();
            }
        }


        private TransitionAnimation forwardAnimation;
        internal TransitionAnimation ForwardAnimation
        {
            get
            {
                return forwardAnimation;
            }
            set
            {
                forwardAnimation = value;
            }
        }

        private TransitionAnimation backwardAnimation;
        internal TransitionAnimation BackwardAnimation
        {
            get
            {
                return backwardAnimation;
            }
            set
            {
                backwardAnimation = value;
            }
        }

        private void Ani_Finished(object sender, EventArgs e)
        {
            FinishAnimation();

            AnimationFinished?.Invoke(direction);
        }

        private void ResetImage()
        {
            if (providerImage != null)
            {
                providerImage.Hide();
                //providerImage.Unparent();
                //providerImage.Dispose();
                //providerImage = null;
            }
        }
    }
}
