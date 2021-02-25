/*
 * Copyright(c) 2021 Samsung Electronics Co., Ltd.
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
using System.ComponentModel;
using System.Threading.Tasks;

namespace Tizen.NUI.Binding
{
    [EditorBrowsable(EditorBrowsableState.Never)]
    internal class AlertArguments
    {
        public AlertArguments(string title, string message, string accept, string cancel)
        {
            Title = title;
            Message = message;
            Accept = accept;
            Cancel = cancel;
            Result = new TaskCompletionSource<bool>();
        }

        /// <summary>
        ///     Gets the text for the accept button. Can be null.
        /// </summary>
        public string Accept { get; private set; }

        /// <summary>
        ///     Gets the text of the cancel button.
        /// </summary>
        public string Cancel { get; private set; }

        /// <summary>
        ///     Gets the message for the alert. Can be null.
        /// </summary>
        public string Message { get; private set; }

        public TaskCompletionSource<bool> Result { get; }

        /// <summary>
        ///     Gets the title for the alert. Can be null.
        /// </summary>
        public string Title { get; private set; }

        public void SetResult(bool result)
        {
            Result.TrySetResult(result);
        }
    }
}
