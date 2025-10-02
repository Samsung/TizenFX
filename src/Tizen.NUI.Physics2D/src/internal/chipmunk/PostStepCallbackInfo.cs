/*
 * Copyright (c) 2023 Codefoco (codefoco@codefoco.com)
 *
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 *
 * The above copyright notice and this permission notice shall be included in all
 * copies or substantial portions of the Software.
 *
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
 * SOFTWARE.
 */

using System;
using System.Collections.Generic;
using System.Text;

namespace Tizen.NUI.Physics2D.Chipmunk
{
    /// <summary>
    /// This class stores the data for the post-step callback.
    /// </summary>
    internal class PostStepCallbackInfo
    {
        Action<Space, object, object> callback;
        object data;

        /// <summary>
        /// Creates an instance of the PostStepCallbackInfo class.
        /// </summary>
        /// <param name="c">The post-step callback.</param>
        /// <param name="d">The data for the callback.</param>
        public PostStepCallbackInfo(Action<Space, object, object> c, object d)
        {
            callback = c;
            data = d;
        }

        /// <summary>
        /// The post-step callback.
        /// </summary>
        public Action<Space, object, object> Callback => callback;

        /// <summary>
        /// The data for the callback.
        /// </summary>
        public object Data => data;
    }
}
