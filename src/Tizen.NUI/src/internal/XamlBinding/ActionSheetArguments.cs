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
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;

namespace Tizen.NUI.Binding
{
    [EditorBrowsable(EditorBrowsableState.Never)]
    internal class ActionSheetArguments
    {
        public ActionSheetArguments(string title, string cancel, string destruction, IEnumerable<string> buttons)
        {
            Title = title;
            Cancel = cancel;
            Destruction = destruction;
            Buttons = buttons;
            Result = new TaskCompletionSource<string>();
        }

        /// <summary>
        ///     Gets titles of any buttons on the action sheet that aren't <see cref="Cancel" /> or <see cref="Destruction" />. Can
        ///     be <c>null</c>.
        /// </summary>
        public IEnumerable<string> Buttons { get; private set; }

        /// <summary>
        ///     Gets the text for a cancel button. Can be null.
        /// </summary>
        public string Cancel { get; private set; }

        /// <summary>
        ///     Gets the text for a destructive button. Can be null.
        /// </summary>
        public string Destruction { get; private set; }

        public TaskCompletionSource<string> Result { get; }

        /// <summary>
        ///     Gets the title for the action sheet. Can be null.
        /// </summary>
        public string Title { get; private set; }

        public void SetResult(string result)
        {
            Result.TrySetResult(result);
        }
    }
}
