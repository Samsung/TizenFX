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
using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;

namespace NUITizenGallery
{
    using tlog = Tizen.Log;

    public partial class AnimatedVectorImageViewTestPage : ContentPage
    {
        private const string tag = "NUITEST";
        private int toggle, toggle2, toggle3;

        public AnimatedVectorImageViewTestPage()
        {
            InitializeComponent();
            tlog.Error(tag, $"aviv TotalFrame={aviv.TotalFrame}");
            ChangeCurrFrameBtn.Clicked += ChangeCurrFrameBtnClicked;
            PlayBtn.Clicked += PlayBtnClicked;
            StopBtn.Clicked += StopBtnClicked;
            GetCurrFrameBtn.Clicked += GetCurrFrameBtnClicked;
            SetMinMaxBtn.Clicked += SetMinMaxBtnClicked;
        }

        private void SetMinMaxBtnClicked(object sender, ClickedEventArgs e)
        {
            string tmpText = "SetMinAndMaxFrame";
            switch (++toggle3 % 3)
            {
                case 0:
                    aviv.SetMinAndMaxFrame(-1, 1000);
                    tmpText += $"(-1, 1000)";
                    break;
                case 1:
                    aviv.SetMinAndMaxFrame(10, 50);
                    tmpText += $"(10, 50)";
                    break;
                case 2:
                    aviv.SetMinAndMaxFrame(51, 52);
                    tmpText += $"(51, 52)";
                    break;
                default:
                    break;
            }
            SetMinMaxBtn.Text = tmpText + $" CurrentFrame={aviv.CurrentFrame}";
            tlog.Error(tag, $"case {toggle3}: aviv AnimationState={aviv.AnimationState} CurrentFrame={aviv.CurrentFrame}");
        }

        private void GetCurrFrameBtnClicked(object sender, ClickedEventArgs e)
        {
            GetCurrFrameBtn.Text = $"get current frame ({aviv.CurrentFrame})";
            tlog.Error(tag, $"aviv AnimationState={aviv.AnimationState} CurrentFrame={aviv.CurrentFrame}");
        }

        private void PlayBtnClicked(object sender, ClickedEventArgs e)
        {
            aviv.Play();
            PlayBtn.Text = $"play ({aviv.AnimationState}) curr frame={aviv.CurrentFrame}";
        }

        private void StopBtnClicked(object sender, ClickedEventArgs e)
        {
            string tmpText = "stop";
            switch (++toggle2 % 3)
            {
                case 0:
                    aviv.Stop(AnimatedVectorImageView.EndActions.Cancel);
                    tmpText = $"stop ({aviv.AnimationState}) EndAction(Cancel)";
                    break;
                case 1:
                    aviv.Stop(AnimatedVectorImageView.EndActions.Discard);
                    tmpText = $"play/stop ({aviv.AnimationState}) EndAction(Discard)";
                    break;
                case 2:
                    aviv.Stop(AnimatedVectorImageView.EndActions.StopFinal);
                    tmpText = $"play/stop ({aviv.AnimationState}) EndAction(StopFinal)";
                    break;
                default:
                    break;
            }
            StopBtn.Text = tmpText + $" curr frame={aviv.CurrentFrame}";
            tlog.Error(tag, $"case {toggle2}: aviv AnimationState={aviv.AnimationState} CurrentFrame={aviv.CurrentFrame}");
        }

        private void ChangeCurrFrameBtnClicked(object sender, ClickedEventArgs e)
        {
            switch (++toggle % 3)
            {
                case 0:
                    aviv.CurrentFrame = 0;
                    tlog.Error(tag, $"case 0: aviv CurrentFrame={aviv.CurrentFrame}");
                    break;
                case 1:
                    aviv.CurrentFrame = 5;
                    tlog.Error(tag, $"case 1: aviv CurrentFrame={aviv.CurrentFrame}");
                    break;
                case 2:
                    aviv.CurrentFrame = aviv.TotalFrame;
                    tlog.Error(tag, $"case 2: aviv CurrentFrame={aviv.CurrentFrame}");
                    break;
                default:
                    break;
            }
            ChangeCurrFrameBtn.Text = $"change current({aviv.CurrentFrame}) frame";
        }
    }
}
