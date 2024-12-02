/*
 * Copyright(c) 2024 Samsung Electronics Co., Ltd.
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

namespace Tizen.NUI.AIAvatar
{
    /// <summary>   
    /// This class provides arguments for handling avatar motion change events.
    /// <member name = "Previous" > The previous state of the avatar's motion.</member>  
    /// <member name = "Current" > The current state of the avatar's motion.</member>  
    /// </summary>  
    public class AnimatorChangedEventArgs : EventArgs
    {
        /// <summary>  
        /// Initializes a new instance of the AvatarMotionChangedEventArgs class with the specified previous and current states.  
        /// </summary>  
        /// <param name="previous">The previous state of the avatar's motion.</param>  
        /// <param name="current">The current state of the avatar's motion.</param>  
        /// <param name="message">The current Animation of the Animation name.</param>  
        public AnimatorChangedEventArgs(AnimatorState previous, AnimatorState current, string message = "")
        {
            Previous = previous;
            Current = current;
            Message = message;
        }

        /// <summary>
        /// The previous state.
        /// </summary>
        public AnimatorState Previous
        {
            get;
            internal set;
        }

        /// <summary>
        /// The current state.
        /// </summary>
        public AnimatorState Current
        {
            get;
            internal set;
        }

        /// <summary>
        /// The Message string.
        /// </summary>
        public string Message
        {
            get;
            internal set;
        }
    }
}
