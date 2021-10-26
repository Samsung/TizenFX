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

using Tizen.Applications;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;

namespace BrokerSample
{

    public class BrokerView : View
    {
        public BrokerView()
        {
            Size = new Size(100, 100);
            CornerRadius = new Vector4(0.5f, 0.5f, 0.5f, 0.5f);
            CornerRadiusPolicy = VisualTransformPolicyType.Relative;

            TouchEvent += targetView_TouchEvent;
        }

        private bool targetView_TouchEvent(object source, View.TouchEventArgs e)
        {
            //앱 런칭
            if (e.Touch.GetState(0) == PointStateType.Up)
            {
                SetApplicationTransition();

                AppControl control = new AppControl()
                {
                    ApplicationId = "org.tizen.example.ProviderSample",
                };
                control.ExtraData.Add("Color", Name);
                //AppControl.SendLaunchRequest(control);
                ApplicationTransitionManager.Instance.LaunchRequestWithTransition(control);
            }
            return false;
        }

        private void SetApplicationTransition()
        {
            var transitionManager = ApplicationTransitionManager.Instance;
            //reset value
            transitionManager.SourceView = null;
            transitionManager.AppearingTransition = null;
            transitionManager.DisappearingTransition = null;
            transitionManager.SourceView = this;
        }
    }
}
