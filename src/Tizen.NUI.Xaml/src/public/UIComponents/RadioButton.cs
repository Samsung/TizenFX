/*
 * Copyright(c) 2017 Samsung Electronics Co., Ltd.
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

namespace Tizen.NUI.Xaml.UIComponents
{

    /// <summary>
    /// A RadioButton provides a radio button with two states, \e selected or \e unselected.<br />
    /// Radio buttons are designed to select one of the many options at the same time.<br />
    /// A RadioButton can change its current state using the selected.<br />
    /// <br />
    /// RadioButtons can be grouped.<br />
    /// Two or more RadioButtons are in one group when they have this same parent.<br />
    /// In each groups only one RadioButton can be \e selected at a given time.<br />
    /// So when a RadioButton is set to \e selected, other RadioButtons in its group are set to \e unselected.<br />
    /// When \e selected RadioButton is set to \e unselected, no other RadioButtons in this group are set to \e selected.<br />
    /// <br />
    /// The StateChanged event is emitted when the RadioButton change its state to \e selected or \e unselected.<br />
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public class RadioButton : Button
    {
        private Tizen.NUI.UIComponents.RadioButton _radioButton;
        internal Tizen.NUI.UIComponents.RadioButton radioButton
        {
            get
            {
                if (null == _radioButton)
                {
                    _radioButton = handleInstance as Tizen.NUI.UIComponents.RadioButton;
                }

                return _radioButton;
            }
        }

        /// <summary>
        /// Creates an uninitialized RadioButton.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public RadioButton() : this(new Tizen.NUI.UIComponents.RadioButton())
        {
        }

        internal RadioButton(Tizen.NUI.UIComponents.RadioButton nuiInstance) : base(nuiInstance)
        {
            SetNUIInstance(nuiInstance);
        }
    }
}