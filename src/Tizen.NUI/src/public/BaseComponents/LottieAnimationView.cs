/*
 * Copyright(c) 2020 Samsung Electronics Co., Ltd.
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

using global::System;
using global::System.Runtime.InteropServices;
using System.ComponentModel;
using System.Collections.Generic;

namespace Tizen.NUI.BaseComponents
{
#if (NUI_DEBUG_ON)
    using tlog = Tizen.Log;
#endif

    /// <summary>
    /// LottieAnimationView renders an animated vector image (Lottie file).
    /// </summary>
    /// <since_tizen> 7 </since_tizen>
    public class LottieAnimationView : ImageView
    {
        #region Constructor, Destructor, Dispose
        /// <summary>
        /// LottieAnimationView constructor
        /// </summary>
        /// <param name="scale">The factor of scaling image, default : 1.0f</param>
        /// <param name="shown">false : not displayed (hidden), true : displayed (shown), default : true</param>
        /// <remarks>
        /// If the shown parameter is false, the animation is not visible even if the LottieAnimationView instance is created.
        /// </remarks>
        /// <example>
        /// <code>
        /// LottieAnimationView myLottie = new LottieAnimationView();
        /// LottieAnimationView myLottie2 = new LottieAnimationView(2.0f);
        /// LottieAnimationView myLottie3 = new LottieAnimationView(1.0f, false);
        /// </code>
        /// </example>
        /// <since_tizen> 7 </since_tizen>
        public LottieAnimationView(float scale = 1.0f, bool shown = true) : base()
        {
            tlog.Fatal(tag, $"< constructor GetId={GetId()} >");
            currentStates.url = "";
            currentStates.frame = -1;
            currentStates.loopCount = 1;
            currentStates.loopMode = LoopingModeType.Restart;
            currentStates.stopEndAction = StopBehaviorType.CurrentFrame;
            currentStates.framePlayRangeMin = -1;
            currentStates.framePlayRangeMax = -1;
            currentStates.changed = false;
            currentStates.totalFrame = -1;
            currentStates.scale = scale;
            currentStates.redrawInScalingDown = true;
            SetVisible(shown);
        }

        /// <summary>
        /// Dispose(DisposeTypes type)
        /// </summary>
        /// <param name="type"></param>
        // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void Dispose(DisposeTypes type)
        {
            if (disposed)
            {
                return;
            }

            tlog.Fatal(tag, $"<[{GetId()}] type={type}");

            //Release your own unmanaged resources here.
            //You should not access any managed member here except static instance.
            //because the execution order of Finalizes is non-deterministic.

            //disconnect event signal
            if (finishedEventHandler != null && visualEventSignalCallback != null)
            {
                VisualEventSignal().Disconnect(visualEventSignalCallback);
                finishedEventHandler = null;
                tlog.Fatal(tag, $"disconnect event signal");
            }

            base.Dispose(type);
            tlog.Fatal(tag, $"[{GetId()}]>");
        }
        #endregion Constructor, Destructor, Dispose


        #region Property
        /// <summary>
        /// Set or Get resource URL of Lottie file.
        /// </summary>
        /// <since_tizen> 7 </since_tizen>
        public string URL
        {
            set
            {
                string ret = (value == null ? "" : value);
                currentStates.url = ret;
                currentStates.changed = true;

                tlog.Fatal(tag, $"<[{GetId()}]SET url={currentStates.url}");

                PropertyMap map = new PropertyMap();
                map.Add(Visual.Property.Type, new PropertyValue((int)DevelVisual.Type.AnimatedVectorImage))
                    .Add(ImageVisualProperty.URL, new PropertyValue(currentStates.url))
                    .Add(ImageVisualProperty.LoopCount, new PropertyValue(currentStates.loopCount))
                    .Add(ImageVisualProperty.StopBehavior, new PropertyValue((int)currentStates.stopEndAction))
                    .Add(ImageVisualProperty.LoopingMode, new PropertyValue((int)currentStates.loopMode));
                Image = map;

                currentStates.contentInfo = null;

                if (currentStates.scale != 1.0f)
                {
                    Scale = new Vector3(currentStates.scale, currentStates.scale, 0.0f);
                }
                tlog.Fatal(tag, $"<[{GetId()}]>");
            }
            get
            {
                string ret = currentStates.url;
                tlog.Fatal(tag, $"<[{GetId()}] GET");

                PropertyMap map = Image;
                if (map != null)
                {
                    PropertyValue val = map.Find(ImageVisualProperty.URL);
                    if (val != null)
                    {
                        if (val.Get(out ret))
                        {
                            tlog.Fatal(tag, $"gotten url={ret} >");
                            return ret;
                        }
                    }
                }
                Tizen.Log.Error(tag, $"  [ERROR][{GetId()}](LottieAnimationView) Fail to get URL from dali >");
                return ret;
            }
        }

        /// <summary>
        /// Gets the playing state
        /// </summary>
        /// <since_tizen> 7 </since_tizen>
        public PlayStateType PlayState
        {
            get
            {
                tlog.Fatal(tag, $"< Get!");
                PropertyMap map = base.Image;
                var ret = 0;
                if (map != null)
                {
                    PropertyValue val = map.Find(ImageVisualProperty.PlayState);
                    if (val != null)
                    {
                        if (val.Get(out ret))
                        {
                            currentStates.playState = (PlayStateType)ret;
                            tlog.Fatal(tag, $"gotten play state={ret} >");
                        }
                    }
                }
                else
                {
                    Tizen.Log.Error(tag, $"<[ERROR][{GetId()}]Fail to get PlayState from dali currentStates.playState={currentStates.playState}>");
                }
                return currentStates.playState;
            }
        }

        /// <summary>
        /// Get the number of total frames
        /// </summary>
        /// <since_tizen> 7 </since_tizen>
        public int TotalFrame
        {
            get
            {
                int ret = -1;
                PropertyMap map = Image;
                if (map != null)
                {
                    PropertyValue val = map.Find(ImageVisualProperty.TotalFrameNumber);
                    if (val != null)
                    {
                        if (val.Get(out ret))
                        {
                            //tlog.Fatal(tag,  $"TotalFrameNumber get! ret={ret}");
                            currentStates.totalFrame = ret;
                            return ret;
                        }
                    }
                }
                Tizen.Log.Error(tag, $"<[ERROR][{GetId()}](LottieAnimationView) Fail to get TotalFrameNumber from dali>");
                return ret;
            }
        }

        /// <summary>
        /// Set or get the current frame. When setting a specific frame, it is displayed as a still image.
        /// </summary>
        /// <remarks>
        /// Gets the value set by a user. If the setting value is out-ranged, it is reset as a minimum frame or a maximum frame.
        /// </remarks>
        /// <example>
        /// We assume that the animation in myLottie.json file has 100 frames originally. If so, its frame index will be 0 - 99.
        /// <code>
        /// LottieAnimationView myLottie = new LottieAnimationView();
        /// myLottie.URL = Tizen.Applications.Application.Current.DirectoryInfo.Resource + "myLottie.json"; //myLottie.json's total frame is 100 (frame: 0~99)
        /// NUIApplication.GetDefaultWindow().GetDefaultLayer().Add(myLottie);
        /// myLottie.CurrentFrame = 200; //display 99 frame
        /// myLottie.SetMinMaxFrame(10, 20);
        /// myLottie.CurrentFrame = 15; //display 15 frame
        /// myLottie.CurrentFrame = 50; //display 20 frame, because the MinMax is set (10,20) above
        /// </code>
        /// </example>
        /// <since_tizen> 7 </since_tizen>
        public int CurrentFrame
        {
            set
            {
                currentStates.frame = value;
                tlog.Fatal(tag, $"<[{GetId()}]SET frame={currentStates.frame}>");
                DoAction(ImageView.Property.IMAGE, (int)actionType.jumpTo, new PropertyValue(currentStates.frame));
            }
            get
            {
                int ret = 0;
                PropertyMap map = Image;
                if (map != null)
                {
                    PropertyValue val = map.Find(ImageVisualProperty.CurrentFrameNumber);
                    if (val != null)
                    {
                        if (val.Get(out ret))
                        {
                            //tlog.Fatal(tag,  $"CurrentFrameNumber get! val={ret}");
                            return ret;
                        }
                    }
                }
                Tizen.Log.Error(tag, $"<[ERROR][{GetId()}](LottieAnimationView) Fail to get CurrentFrameNumber from dali!! ret={ret}>");
                return ret;
            }
        }

        /// <summary>
        /// Sets or gets the looping mode of Lottie animation.
        /// </summary>
        /// <since_tizen> 7 </since_tizen>
        public LoopingModeType LoopingMode
        {
            set
            {
                currentStates.loopMode = (LoopingModeType)value;
                currentStates.changed = true;

                tlog.Fatal(tag, $"<[{GetId()}] SET loopMode={currentStates.loopMode}>");
                PropertyMap map = new PropertyMap();
                map.Add(ImageVisualProperty.LoopingMode, new PropertyValue((int)currentStates.loopMode));
                DoAction(ImageView.Property.IMAGE, (int)actionType.updateProperty, new PropertyValue(map));
            }
            get
            {
                //tlog.Fatal(tag,  $"LoopMode get!");
                PropertyMap map = base.Image;
                var ret = 0;
                if (map != null)
                {
                    PropertyValue val = map.Find(ImageVisualProperty.LoopingMode);
                    if (val != null)
                    {
                        if (val.Get(out ret))
                        {
                            //tlog.Fatal(tag,  $"gotten LoopMode={ret}");
                            if (ret != (int)currentStates.loopMode && ret > 0)
                            {
                                tlog.Fatal(tag, $" [ERROR][{GetId()}](LottieAnimationView) different LoopMode! gotten={ret}, loopMode={currentStates.loopMode}");
                            }
                            currentStates.loopMode = (LoopingModeType)ret;
                            return (LoopingModeType)ret;
                        }
                    }
                }
                Tizen.Log.Error(tag, $"<[ERROR][{GetId()}](LottieAnimationView) Fail to get loopMode from dali>");
                return currentStates.loopMode;
            }
        }

        /// <summary>
        /// Sets or gets the loop count.
        /// </summary>
        /// <remarks>
        /// The minus value means the infinite loop count.
        /// </remarks>
        /// <example>
        /// <code>
        /// LottieAnimationView myLottie = new LottieAnimationView();
        /// myLottie.URL = Tizen.Applications.Application.Current.DirectoryInfo.Resource + "myLottie.json"; //myLottie.json's total frame is 100 (frame: 0~99)
        /// NUIApplication.GetDefaultWindow().GetDefaultLayer().Add(myLottie);
        /// myLottie.LoopCount = -1; //infinite loop
        /// myLottie.Play();
        /// myLottie.Stop(); //it plays continuously unless Stop() is called
        /// myLottie.LoopCount = 2;
        /// myLottie.Play(); //it plays only 2 times and stops automatically
        /// </code>
        /// </example>
        /// <since_tizen> 7 </since_tizen>
        public int LoopCount
        {
            set
            {
                currentStates.changed = true;
                currentStates.loopCount = value;
                tlog.Fatal(tag, $"<[{GetId()}]SET currentStates.loopCount={currentStates.loopCount}>");
                PropertyMap map = new PropertyMap();
                map.Add(ImageVisualProperty.LoopCount, new PropertyValue(currentStates.loopCount));
                DoAction(ImageView.Property.IMAGE, (int)actionType.updateProperty, new PropertyValue(map));
            }
            get
            {
                //tlog.Fatal(tag,  $"LoopCount get!");
                PropertyMap map = base.Image;
                var ret = 0;
                if (map != null)
                {
                    PropertyValue val = map.Find(ImageVisualProperty.LoopCount);
                    if (val != null)
                    {
                        if (val.Get(out ret))
                        {
                            //tlog.Fatal(tag,  $"gotten loop count={ret}");
                            if (ret != currentStates.loopCount && ret > 0)
                            {
                                tlog.Fatal(tag, $"<[ERROR][{GetId()}](LottieAnimationView) different loop count! gotten={ret}, loopCount={currentStates.loopCount}>");
                            }
                            currentStates.loopCount = ret;
                            return currentStates.loopCount;
                        }
                    }
                }
                Tizen.Log.Error(tag, $"<[ERROR][{GetId()}](LottieAnimationView) Fail to get LoopCount from dali  currentStates.loopCount={currentStates.loopCount}>");
                return currentStates.loopCount;
            }
        }

        /// <summary>
        /// Sets or gets the stop behavior.
        /// </summary>
        /// <since_tizen> 7 </since_tizen>
        public StopBehaviorType StopBehavior
        {
            set
            {
                currentStates.stopEndAction = (StopBehaviorType)value;
                currentStates.changed = true;

                tlog.Fatal(tag, $"<[{GetId()}]SET val={currentStates.stopEndAction}>");
                PropertyMap map = new PropertyMap();
                map.Add(ImageVisualProperty.StopBehavior, new PropertyValue((int)currentStates.stopEndAction));
                DoAction(ImageView.Property.IMAGE, (int)actionType.updateProperty, new PropertyValue(map));
            }
            get
            {
                //tlog.Fatal(tag,  $"StopBehavior get!");
                PropertyMap map = base.Image;
                var ret = 0;
                if (map != null)
                {
                    PropertyValue val = map.Find(ImageVisualProperty.StopBehavior);
                    if (val != null)
                    {
                        if (val.Get(out ret))
                        {
                            //tlog.Fatal(tag,  $"gotten StopBehavior={ret}");
                            if (ret != (int)currentStates.stopEndAction)
                            {
                                tlog.Fatal(tag, $"<[ERROR][{GetId()}](LottieAnimationView) different StopBehavior! gotten={ret}, StopBehavior={currentStates.stopEndAction}>");
                            }
                            currentStates.stopEndAction = (StopBehaviorType)ret;
                            return (StopBehaviorType)ret;
                        }
                    }
                }
                Tizen.Log.Error(tag, $"<[ERROR][{GetId()}](LottieAnimationView) Fail to get StopBehavior from dali>");
                return currentStates.stopEndAction;
            }
        }

        /// <summary>
        /// Whether to redraw the image when the visual is scaled down.
        /// </summary>
        /// <remarks>
        /// Inhouse API.
        /// It is used in the AnimatedVectorImageVisual.The default is true.
        /// </remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool RedrawInScalingDown
        {
            set
            {
                currentStates.changed = true;
                currentStates.redrawInScalingDown = value;
                tlog.Fatal(tag, $"<[{GetId()}]SET currentStates.redrawInScalingDown={currentStates.redrawInScalingDown}>");
                PropertyMap map = new PropertyMap();
                map.Add(ImageVisualProperty.RedrawInScalingDown, new PropertyValue(currentStates.redrawInScalingDown));
                DoAction(ImageView.Property.IMAGE, (int)actionType.updateProperty, new PropertyValue(map));
            }
            get
            {
                PropertyMap map = base.Image;
                var ret = true;
                if (map != null)
                {
                    PropertyValue val = map.Find(ImageVisualProperty.RedrawInScalingDown);
                    if (val != null)
                    {
                        if (val.Get(out ret))
                        {
                            if (ret != currentStates.redrawInScalingDown)
                            {
                                tlog.Fatal(tag, $"<[ERROR][{GetId()}](LottieAnimationView) different redrawInScalingDown! gotten={ret}, redrawInScalingDown={currentStates.redrawInScalingDown}>");
                            }
                            currentStates.redrawInScalingDown = ret;
                            return currentStates.redrawInScalingDown;
                        }
                    }
                }
                Tizen.Log.Error(tag, $"<[ERROR][{GetId()}](LottieAnimationView) Fail to get redrawInScalingDown from dali currentStates.redrawInScalingDown={currentStates.redrawInScalingDown}>");
                return currentStates.redrawInScalingDown;
            }
        }
        #endregion Property


        #region Method
        /// <summary>
        /// Set the minimum and the maximum frame.
        /// </summary>
        /// <param name="minFrame">minimum frame</param>
        /// <param name="maxFrame">maximum frame</param>
        /// <since_tizen> 7 </since_tizen>
        public void SetMinMaxFrame(int minFrame, int maxFrame)
        {
            tlog.Fatal(tag, $"< [{GetId()}] SetPlayRange({minFrame}, {maxFrame})");

            currentStates.changed = true;
            currentStates.framePlayRangeMin = minFrame;
            currentStates.framePlayRangeMax = maxFrame;

            PropertyArray array = new PropertyArray();
            array.PushBack(new PropertyValue(currentStates.framePlayRangeMin));
            array.PushBack(new PropertyValue(currentStates.framePlayRangeMax));

            PropertyMap map = new PropertyMap();
            map.Add(ImageVisualProperty.PlayRange, new PropertyValue(array));
            DoAction(ImageView.Property.IMAGE, (int)actionType.updateProperty, new PropertyValue(map));
            tlog.Fatal(tag, $"  [{GetId()}] currentStates.min:({currentStates.framePlayRangeMin}, max:{currentStates.framePlayRangeMax})>");
        }

        /// <summary>
        /// Play Animation.
        /// </summary>
        /// <since_tizen> 7 </since_tizen>
        public new void Play()
        {
            tlog.Fatal(tag, $"<[{GetId()}] Play()");
            debugPrint();
            base.Play();
            tlog.Fatal(tag, $"[{GetId()}]>");
        }

        /// <summary>
        /// Pause Animation.
        /// </summary>
        /// <since_tizen> 7 </since_tizen>
        public new void Pause()
        {
            tlog.Fatal(tag, $"<[{GetId()}] Pause()>");
            debugPrint();
            base.Pause();
            tlog.Fatal(tag, $"[{GetId()}]>");
        }

        /// <summary>
        /// Stop Animation.
        /// </summary>
        /// <since_tizen> 7 </since_tizen>
        public new void Stop()
        {
            tlog.Fatal(tag, $"<[{GetId()}] Stop()");
            debugPrint();
            base.Stop();
            tlog.Fatal(tag, $"[{GetId()}]>");
        }

        /// <summary>
        /// Get the list of layers' information such as the start frame and the end frame in the Lottie file.
        /// </summary>
        /// <returns>List of Tuple (string of layer name, integer of start frame, integer of end frame)</returns>
        /// <since_tizen> 7 </since_tizen>
        public List<Tuple<string, int, int>> GetContentInfo()
        {
            tlog.Fatal(tag, $"<");
            if (currentStates.contentInfo != null)
            {
                return currentStates.contentInfo;
            }

            PropertyMap imageMap = base.Image;
            PropertyMap contentMap = new PropertyMap();
            if (imageMap != null)
            {
                PropertyValue val = imageMap.Find(ImageVisualProperty.ContentInfo);
                if (val != null)
                {
                    if (val.Get(contentMap))
                    {
                        currentStates.contentInfo = new List<Tuple<string, int, int>>();
                        for (uint i = 0; i < contentMap.Count(); i++)
                        {
                            string key = contentMap.GetKeyAt(i).StringKey;
                            PropertyArray arr = new PropertyArray();
                            contentMap.GetValue(i).Get(arr);
                            if (arr != null)
                            {
                                int startFrame, endFrame;
                                arr.GetElementAt(0).Get(out startFrame);
                                arr.GetElementAt(1).Get(out endFrame);

                                tlog.Fatal(tag, $"[{i}] layer name={key}, startFrame={startFrame}, endFrame={endFrame}");

                                Tuple<string, int, int> item = new Tuple<string, int, int>(key, startFrame, endFrame);

                                currentStates.contentInfo?.Add(item);
                            }
                        }
                    }
                }
            }
            tlog.Fatal(tag, $">");
            return currentStates.contentInfo;
        }

        /// <summary>
        /// A marker has its start frame and end frame.
        /// Animation will play between the start frame and the end frame of the marker if one marker is specified.
        /// Or animation will play between the start frame of the first marker and the end frame of the second marker if two markers are specified.   *
        /// </summary>
        /// <param name="marker1">First marker</param>
        /// <param name="marker2">Second marker</param>
        // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SetMinMaxFrameByMarker(string marker1, string marker2 = null)
        {
            tlog.Fatal(tag, $"< [{GetId()}] SetMinMaxFrameByMarker({marker1}, {marker2})");

            currentStates.changed = true;
            currentStates.mark1 = marker1;
            currentStates.mark2 = marker2;

            PropertyArray array = new PropertyArray();
            array.PushBack(new PropertyValue(currentStates.mark1));
            if (marker2 != null)
            {
                array.PushBack(new PropertyValue(currentStates.mark2));
            }

            PropertyMap map = new PropertyMap();
            map.Add(ImageVisualProperty.PlayRange, new PropertyValue(array));
            DoAction(ImageView.Property.IMAGE, (int)actionType.updateProperty, new PropertyValue(map));
            tlog.Fatal(tag, $"  [{GetId()}] currentStates.mark1:{currentStates.mark1}, mark2:{currentStates.mark2} >");
        }

        /// <summary>
        /// Get MinMax Frame
        /// </summary>
        /// <returns>Tuple of Min and Max frames</returns>
        // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Tuple<int, int> GetMinMaxFrame()
        {
            tlog.Fatal(tag, $"< [{GetId()}] GetMinMaxFrame()! total frame={currentStates.totalFrame}");

            PropertyMap map = Image;
            if (map != null)
            {
                PropertyValue val = map.Find(ImageVisualProperty.PlayRange);
                if (val != null)
                {
                    PropertyArray array = new PropertyArray();
                    if (val.Get(array))
                    {
                        uint cnt = array.Count();
                        int item1 = -1, item2 = -1;
                        for (uint i = 0; i < cnt; i++)
                        {
                            PropertyValue v = array.GetElementAt(i);
                            int intRet;
                            if (v.Get(out intRet))
                            {
                                tlog.Fatal(tag, $"Got play range of string [{i}]: {intRet}");
                                if (i == 0)
                                {
                                    item1 = intRet;
                                }
                                else if (i == 1)
                                {
                                    item2 = intRet;
                                }
                            }
                            else
                            {
                                Tizen.Log.Error("NUI", $"[ERR] fail to get play range from dali! case#1");
                            }
                        }
                        tlog.Fatal(tag, $"  [{GetId()}] GetMinMaxFrame(min:{item1}, max:{item2})! >");
                        return new Tuple<int, int>(item1, item2);
                    }
                }
            }
            Tizen.Log.Error("NUI", $"[ERR] fail to get play range from dali! case#2");
            return new Tuple<int, int>(-1, -1);
        }
        #endregion Method


        #region Event, Enum, Struct, ETC
        /// <summary>
        /// Animation finished event.
        /// </summary>
        /// <since_tizen> 7 </since_tizen>
        public event EventHandler Finished
        {
            add
            {
                if (finishedEventHandler == null)
                {
                    tlog.Fatal(tag, $"<[{GetId()}] Finished eventhandler added>");
                    visualEventSignalCallback = onVisualEventSignal;
                    VisualEventSignal().Connect(visualEventSignalCallback);
                }
                finishedEventHandler += value;
            }
            remove
            {
                tlog.Fatal(tag, $"<[{GetId()}] Finished eventhandler removed>");
                finishedEventHandler -= value;
                if (finishedEventHandler == null && visualEventSignalCallback != null)
                {
                    VisualEventSignal().Disconnect(visualEventSignalCallback);
                }
            }
        }

        /// <summary>
        /// Enumeration for what state the vector animation is in
        /// </summary>
        /// <since_tizen> 7 </since_tizen>
        public enum PlayStateType
        {
            /// <summary>
            /// Invalid
            /// </summary>
            /// <since_tizen> 7 </since_tizen>
            Invalid = -1,
            /// <summary>
            /// Vector Animation has stopped
            /// </summary>
            /// <since_tizen> 7 </since_tizen>
            Stopped = 0,
            /// <summary>
            /// The vector animation is playing
            /// </summary>
            /// <since_tizen> 7 </since_tizen>
            Playing = 1,
            /// <summary>
            /// The vector animation is paused
            /// </summary>
            /// <since_tizen> 7 </since_tizen>
            Paused = 2
        }

        /// <summary>
        /// Enumeration for what to do when the animation is stopped.
        /// </summary>
        /// <since_tizen> 7 </since_tizen>
        public enum StopBehaviorType
        {
            /// <summary>
            /// When the animation is stopped, the current frame is shown.
            /// </summary>
            /// <since_tizen> 7 </since_tizen>
            CurrentFrame,
            /// <summary>
            /// When the animation is stopped, the min frame (first frame) is shown.
            /// </summary>
            /// <since_tizen> 7 </since_tizen>
            MinimumFrame,
            /// <summary>
            /// When the animation is stopped, the max frame (last frame) is shown.
            /// </summary>
            /// <since_tizen> 7 </since_tizen>
            MaximumFrame
        }

        /// <summary>
        /// Enumeration for what looping mode is in.
        /// </summary>
        /// <since_tizen> 7 </since_tizen>
        public enum LoopingModeType
        {
            /// <summary>
            /// When the animation arrives at the end in looping mode, the animation restarts from the beginning.
            /// </summary>
            /// <since_tizen> 7 </since_tizen>
            Restart,
            /// <summary>
            /// When the animation arrives at the end in looping mode, the animation reverses direction and runs backwards again.
            /// </summary>
            /// <since_tizen> 7 </since_tizen>
            AutoReverse
        }
        #endregion Event, Enum, Struct, ETC


        #region Internal
        internal class VisualEventSignalArgs : EventArgs
        {
            public int VisualIndex
            {
                set;
                get;
            }
            public int SignalId
            {
                set;
                get;
            }
        }

        internal event EventHandler<VisualEventSignalArgs> VisualEvent
        {
            add
            {
                if (visualEventSignalHandler == null)
                {
                    visualEventSignalCallback = onVisualEventSignal;
                    VisualEventSignal().Connect(visualEventSignalCallback);
                }
                visualEventSignalHandler += value;
            }
            remove
            {
                visualEventSignalHandler -= value;
                if (visualEventSignalHandler == null && VisualEventSignal().Empty() == false)
                {
                    VisualEventSignal().Disconnect(visualEventSignalCallback);
                }
            }
        }

        internal void EmitVisualEventSignal(int visualIndex, int signalId)
        {
            VisualEventSignal().Emit(this, visualIndex, signalId);
        }

        internal VisualEventSignal VisualEventSignal()
        {
            VisualEventSignal ret = new VisualEventSignal(Interop.VisualEventSignal.NewWithView(View.getCPtr(this)), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }
        #endregion Internal


        #region Private
        private struct states
        {
            internal string url;
            internal int frame;
            internal int loopCount;
            internal LoopingModeType loopMode;
            internal StopBehaviorType stopEndAction;
            internal int framePlayRangeMin;
            internal int framePlayRangeMax;
            internal bool changed;
            internal int totalFrame;
            internal float scale;
            internal PlayStateType playState;
            internal List<Tuple<string, int, int>> contentInfo;
            internal string mark1, mark2;
            internal bool redrawInScalingDown;
        };
        private states currentStates;

        private enum actionType
        {
            play,
            pause,
            stop,
            jumpTo,
            updateProperty,
        };

        private struct DevelVisual
        {
            internal enum Type
            {
                AnimatedGradient = Visual.Type.AnimatedImage + 1,
                AnimatedVectorImage = Visual.Type.AnimatedImage + 2,
            }
        }

        private const string tag = "NUITEST";
        private event EventHandler finishedEventHandler;

        private void OnFinished()
        {
            tlog.Fatal(tag, $"<[{GetId()}] OnFinished()>");
            finishedEventHandler?.Invoke(this, null);
        }

        private void onVisualEventSignal(IntPtr targetView, int visualIndex, int signalId)
        {
            OnFinished();

            if (targetView != IntPtr.Zero)
            {
                View v = Registry.GetManagedBaseHandleFromNativePtr(targetView) as View;
                if (v != null)
                {
                    tlog.Fatal(tag, $"targetView is not null! name={v.Name}");
                }
                else
                {
                    tlog.Fatal(tag, $"target is something created from dali");
                }
            }
            VisualEventSignalArgs e = new VisualEventSignalArgs();
            e.VisualIndex = visualIndex;
            e.SignalId = signalId;
            visualEventSignalHandler?.Invoke(this, e);

            tlog.Fatal(tag, $"<[{GetId()}] onVisualEventSignal()! visualIndex={visualIndex}, signalId={signalId}>");
        }

        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate void VisualEventSignalCallbackType(IntPtr targetView, int visualIndex, int signalId);

        private VisualEventSignalCallbackType visualEventSignalCallback;
        private EventHandler<VisualEventSignalArgs> visualEventSignalHandler;

        private void debugPrint()
        {
            tlog.Fatal(tag, $"===================================");
            tlog.Fatal(tag, $"<[{GetId()}] get currentStates : url={currentStates.url}, loopCount={currentStates.loopCount}, \nframePlayRangeMin/Max({currentStates.framePlayRangeMin},{currentStates.framePlayRangeMax}) ");
            tlog.Fatal(tag, $"  get from Property : StopBehavior={StopBehavior}, LoopMode={LoopingMode}, LoopCount={LoopCount}, PlayState={PlayState}");
            tlog.Fatal(tag, $"  RedrawInScalingDown={RedrawInScalingDown} >");
            tlog.Fatal(tag, $"===================================");
        }
        #endregion Private
    }

    /// <summary>
    /// A class containing frame informations for a LottieAnimationView.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class LottieFrameInfo : ICloneable
    {
        /// <summary>
        /// Creates a new instance with a playing range.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public LottieFrameInfo(int startFrame, int endFrame)
        {
            StartFrame = startFrame;
            EndFrame = endFrame;
        }

        /// <summary>
        /// Creates a new instance with a still image frame.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public LottieFrameInfo(int stillImageFrame) : this(stillImageFrame, stillImageFrame)
        {
        }

        /// <summary>
        /// Create a new instance from a pair notation.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static implicit operator LottieFrameInfo((int, int) pair)
        {
            return new LottieFrameInfo(pair.Item1, pair.Item2);
        }

        /// <summary>
        /// Create a new instance from an int value.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static implicit operator LottieFrameInfo(int stillImageFrame)
        {
            return new LottieFrameInfo(stillImageFrame);
        }

        /// <summary>
        /// Create a new instance from string.
        /// Possible input : "0, 10", "10"
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static implicit operator LottieFrameInfo(string pair)
        {
            if (pair == null)
            {
                return null;
            }

            string[] parts = pair.Split(',');
            if (parts.Length == 1)
            {
                return new LottieFrameInfo(Int32.Parse(parts[0].Trim()));
            }
            else if (parts.Length == 2)
            {
                return new LottieFrameInfo(Int32.Parse(parts[0].Trim()), Int32.Parse(parts[1].Trim()));
            }

            Tizen.Log.Error("NUI", $"Can not convert string {pair} to LottieFrameInfo");
            return null;
        }

        /// <summary>
        /// The start frame of the lottie animation.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int StartFrame { get; }

        /// <summary>
        /// The end frame of the lottie animation.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int EndFrame { get; }

        /// <summary>
        /// Create LottieFrameInfo struct with animation range information
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static LottieFrameInfo CreateAnimationRange(int startFrame, int endFrame)
        {
            return new LottieFrameInfo(startFrame, endFrame);
        }

        /// <summary>
        /// Create LottieFrameInfo struct with still image information
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static LottieFrameInfo CreateStillImage(int stillImageFrame)
        {
            return new LottieFrameInfo(stillImageFrame, stillImageFrame);
        }

        /// <summary>
        /// Inhouse API.
        /// Whether this LottieFrameInfo represents one frame or more.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool IsStillImage()
        {
            return StartFrame == EndFrame;
        }

        /// <summary>
        /// Inhouse API.
        /// Play specified LottieAnimationView with this frame information.
        /// </summary>
        /// <param name="lottieView">The target LottieAnimationView to play.</param>
        /// <param name="noPlay">Whether go direct to the EndFrame. It is false by default.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void Show(LottieAnimationView lottieView, bool noPlay = false)
        {
            if (!BeReadyToShow(lottieView))
            {
                return;
            }

            lottieView.SetMinMaxFrame(StartFrame, Math.Min(EndFrame, lottieView.TotalFrame - 1));

            if (IsStillImage() || noPlay)
            {
                lottieView.CurrentFrame = EndFrame;
            }
            else
            {
                lottieView.CurrentFrame = StartFrame;
                lottieView.Play();
            }
        }

        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public object Clone() => new LottieFrameInfo(StartFrame, EndFrame);

        private bool BeReadyToShow(LottieAnimationView lottieView)
        {
            // Validate input lottieView
            if (null == lottieView || lottieView.PlayState == LottieAnimationView.PlayStateType.Invalid)
            {
                return false;
            }

            // Stop if it was playing
            if (lottieView.PlayState == LottieAnimationView.PlayStateType.Playing)
            {
                lottieView.Stop();
            }

            return true;
        }
    }
}
