/*
 * Copyright (c) 2020 Samsung Electronics Co., Ltd All Rights Reserved
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
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI
{
    internal class DefaultFrameBroker : FrameBrokerBase
    {
        private Window window;
        private ImageView providerImage;

        public delegate void AnimationEventHandler();
        internal event AnimationEventHandler AnimationInitialized;
        internal event AnimationEventHandler AnimationFinished;

        internal DefaultFrameBroker(Window window) : base(window)
        {
            this.window = window;
        }

        protected override void OnFrameResumed(FrameData frame)
        {
            base.OnFrameResumed(frame);
            if (AnimationInitialized != null)
            {
                AnimationInitialized();
            }

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

        private void PlayAnimateTo(FrameData frame, TransitionAnimation animation)
        {
            if (animation)
            {
                providerImage = frame.Image;
                providerImage.Size = window.Size;
                window.Add(providerImage);

                providerImage.PositionX = animation.GetDefaultInitValue();

                animation.PlayAnimateTo(providerImage);
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
                forwardAnimation.Finished += Ani_Finished;
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
                backwardAnimation.Finished += Ani_Finished;
            }
        }

        private void Ani_Finished(object sender, EventArgs e)
        {
            if (AnimationFinished != null)
            {
                AnimationFinished();
            }

            if (providerImage != null)
            {
                providerImage.Unparent();
                providerImage.Dispose();
                providerImage = null;
            }
            FinishAnimation();
        }
    }
}
