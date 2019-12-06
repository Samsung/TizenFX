/*
 * Copyright(c) 2019 Samsung Electronics Co., Ltd.
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
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Binding;

namespace Tizen.NUI.Components
{
    /// <summary>
    /// ButtonAttributes is a class which saves Button's ux data.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class ControlStyle : ViewStyle
    {
        /// <summary>
        /// Creates a new instance of a ButtonStyle.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ControlStyle() : base()
        {
            InitSubAttributes();
        }
        /// <summary>
        /// Creates a new instance of a ButtonStyle with style.
        /// </summary>
        /// <param name="style">Create ButtonStyle by style customized by user.</param>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ControlStyle(ControlStyle style) : base(style)
        {
            if(style == null)
            {
                return;
            }

            InitSubAttributes();

            Shadow.CopyFrom(style.Shadow);
            Background.CopyFrom(style.Background);
        }

        /// <summary>
        /// Shadow image's Style.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen__6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ImageViewStyle Shadow
        {
            get;
            set;
        }
        /// <summary>
        /// Background image's Style.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ImageViewStyle Background
        {
            get;
            set;
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override void CopyFrom(BindableObject bindableObject)
        {
            base.CopyFrom(bindableObject);

            ControlStyle controlStyle = bindableObject as ControlStyle;

            if (null != controlStyle)
            {
                if (null != controlStyle.Shadow)
                {
                    Shadow.CopyFrom(controlStyle.Shadow);
                }

                if (null != controlStyle.Background)
                {
                    Background.CopyFrom(controlStyle.Background);
                }
            }
        }

        private void InitSubAttributes()
        {
            Shadow = new ImageViewStyle()
            {
                PositionUsesPivotPoint = true,
                ParentOrigin = Tizen.NUI.ParentOrigin.Center,
                PivotPoint = Tizen.NUI.PivotPoint.Center,
                WidthResizePolicy = ResizePolicyType.FillToParent,
                HeightResizePolicy = ResizePolicyType.FillToParent
            };
            Shadow.PropertyChanged += SubStyleCalledEvent;

            Background = new ImageViewStyle()
            {
                PositionUsesPivotPoint = true,
                ParentOrigin = Tizen.NUI.ParentOrigin.Center,
                PivotPoint = Tizen.NUI.PivotPoint.Center,
                WidthResizePolicy = ResizePolicyType.FillToParent,
                HeightResizePolicy = ResizePolicyType.FillToParent
            };
            Background.PropertyChanged += SubStyleCalledEvent;
        }

        private void SubStyleCalledEvent(object sender, global::System.EventArgs e)
        {
            OnPropertyChanged();
        }
    }
}
