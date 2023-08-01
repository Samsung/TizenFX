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
using System.Globalization;

namespace Tizen.NUI.BaseComponents
{
    /// <summary>
    /// LottieAnimationView renders an animated vector image (Lottie file).
    /// </summary>
    /// <since_tizen> 7 </since_tizen>
    public partial class LottieAnimationView : ImageView
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
            NUILog.Debug($"< constructor GetId={GetId()} >");
            currentStates.url = "";
            currentStates.loopCount = 1;
            currentStates.loopMode = LoopingModeType.Restart;
            currentStates.stopEndAction = StopBehaviorType.CurrentFrame;
            currentStates.framePlayRangeMin = -1;
            currentStates.framePlayRangeMax = -1;
            currentStates.totalFrame = -1;
            currentStates.scale = scale;
            currentStates.redrawInScalingDown = true;

            // Set changed flag as true when initalized state.
            // After some properties change, LottieAnimationView.UpdateImage will apply these inital values.
            currentStates.changed = true;
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

            CleanCallbackDictionaries();

            //Release your own unmanaged resources here.
            //You should not access any managed member here except static instance.
            //because the execution order of Finalizes is non-deterministic.

            //disconnect event signal
            if (finishedEventHandler != null && visualEventSignalCallback != null)
            {
                using VisualEventSignal visualEvent = VisualEventSignal();
                visualEvent.Disconnect(visualEventSignalCallback);
                finishedEventHandler = null;
                NUILog.Debug($"disconnect event signal");
            }

            base.Dispose(type);
        }

        // This is used for internal purpose. hidden API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void Dispose(bool disposing)
        {
            CleanCallbackDictionaries();
            base.Dispose(disposing);
        }
        #endregion Constructor, Destructor, Dispose


        #region Property
        /// <summary>
        /// Set or Get resource URL of Lottie file.
        /// </summary>
        /// <since_tizen> 7 </since_tizen>
        public string URL
        {
            get
            {
                return GetValue(URLProperty) as string;
            }
            set
            {
                SetValue(URLProperty, value);
                NotifyPropertyChanged();
            }
        }

        private string InternalURL
        {
            set
            {
                // Reset cached infomations.
                currentStates.contentInfo = null;
                currentStates.mark1 = null;
                currentStates.mark2 = null;
                currentStates.framePlayRangeMin = -1;
                currentStates.framePlayRangeMax = -1;
                currentStates.totalFrame = -1;

                string ret = (value == null ? "" : value);
                currentStates.url = ret;

                NUILog.Debug($"<[{GetId()}]SET url={currentStates.url}");

                // TODO : Could create new Image without additional creation?
                using PropertyMap map = new PropertyMap();
                using PropertyValue type = new PropertyValue((int)Visual.Type.AnimatedVectorImage);
                using PropertyValue url = new PropertyValue(currentStates.url);
                using PropertyValue loopCnt = new PropertyValue(currentStates.loopCount);
                using PropertyValue stopAction = new PropertyValue((int)currentStates.stopEndAction);
                using PropertyValue loopMode = new PropertyValue((int)currentStates.loopMode);
                using PropertyValue redrawInScalingDown = new PropertyValue(currentStates.redrawInScalingDown);

                map.Add(Visual.Property.Type, type)
                    .Add(ImageVisualProperty.URL, url)
                    .Add(ImageVisualProperty.LoopCount, loopCnt)
                    .Add(ImageVisualProperty.StopBehavior, stopAction)
                    .Add(ImageVisualProperty.LoopingMode, loopMode)
                    .Add(ImageVisualProperty.RedrawInScalingDown, redrawInScalingDown);
                Image = map;

                // All states applied well.
                currentStates.changed = false;

                if (currentStates.scale != 1.0f)
                {
                    Scale = new Vector3(currentStates.scale, currentStates.scale, currentStates.scale);
                }
                NUILog.Debug($"<[{GetId()}]>");
            }
            get
            {
                string ret = currentStates.url;
                NUILog.Debug($"<[{GetId()}] GET");
                NUILog.Debug($"gotten url={ret} >");
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
                NUILog.Debug($"< Get!");

                int ret = 0;
                Interop.View.InternalRetrievingVisualPropertyInt(this.SwigCPtr, ImageView.Property.IMAGE, ImageVisualProperty.PlayState, out ret);

                currentStates.playState = (PlayStateType)ret;
                NUILog.Debug($"gotten play state={currentStates.playState} >");

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
                int ret = currentStates.totalFrame;
                if (ret == -1)
                {
                    Interop.View.InternalRetrievingVisualPropertyInt(this.SwigCPtr, ImageView.Property.IMAGE, ImageVisualProperty.TotalFrameNumber, out ret);

                    currentStates.totalFrame = ret;
                    NUILog.Debug($"TotalFrameNumber get! ret={ret}");
                }
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
            get
            {
                return (int)GetValue(CurrentFrameProperty);
            }
            set
            {
                SetValue(CurrentFrameProperty, value);
                NotifyPropertyChanged();
            }
        }

        private int InternalCurrentFrame
        {
            set
            {
                NUILog.Debug($"<[{GetId()}]SET frame={value}>");

                Interop.View.DoActionWithSingleIntAttributes(this.SwigCPtr, ImageView.Property.IMAGE, ActionJumpTo, value);
            }
            get
            {
                int ret = 0;

                Interop.View.InternalRetrievingVisualPropertyInt(this.SwigCPtr, ImageView.Property.IMAGE, ImageVisualProperty.CurrentFrameNumber, out ret);

                NUILog.Debug($"CurrentFrameNumber get! val={ret}");
                return ret;
            }
        }

        /// <summary>
        /// Sets or gets the looping mode of Lottie animation.
        /// </summary>
        /// <since_tizen> 7 </since_tizen>
        public LoopingModeType LoopingMode
        {
            get
            {
                return (LoopingModeType)GetValue(LoopingModeProperty);
            }
            set
            {
                SetValue(LoopingModeProperty, value);
                NotifyPropertyChanged();
            }
        }

        private LoopingModeType InternalLoopingMode
        {
            set
            {
                if (currentStates.loopMode != (LoopingModeType)value)
                {
                    currentStates.changed = true;
                    currentStates.loopMode = (LoopingModeType)value;

                    NUILog.Debug($"<[{GetId()}] SET loopMode={currentStates.loopMode}>");

                    Interop.View.InternalUpdateVisualPropertyInt(this.SwigCPtr, ImageView.Property.IMAGE, ImageVisualProperty.LoopingMode, (int)currentStates.loopMode);
                }
            }
            get
            {
                NUILog.Debug($"LoopMode get! {currentStates.loopMode}");
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
            get
            {
                return (int)GetValue(LoopCountProperty);
            }
            set
            {
                SetValue(LoopCountProperty, value);
                NotifyPropertyChanged();
            }
        }

        private int InternalLoopCount
        {
            set
            {
                if (currentStates.loopCount != value)
                {
                    currentStates.changed = true;
                    currentStates.loopCount = value;

                    NUILog.Debug($"<[{GetId()}]SET currentStates.loopCount={currentStates.loopCount}>");

                    Interop.View.InternalUpdateVisualPropertyInt(this.SwigCPtr, ImageView.Property.IMAGE, ImageVisualProperty.LoopCount, currentStates.loopCount);
                }
            }
            get
            {
                NUILog.Debug($"LoopCount get! {currentStates.loopCount}");
                return currentStates.loopCount;
            }
        }

        /// <summary>
        /// Sets or gets the stop behavior.
        /// </summary>
        /// <since_tizen> 7 </since_tizen>
        public StopBehaviorType StopBehavior
        {
            get
            {
                return (StopBehaviorType)GetValue(StopBehaviorProperty);
            }
            set
            {
                SetValue(StopBehaviorProperty, value);
                NotifyPropertyChanged();
            }
        }

        private StopBehaviorType InternalStopBehavior
        {
            set
            {
                if (currentStates.stopEndAction != (StopBehaviorType)value)
                {
                    currentStates.changed = true;
                    currentStates.stopEndAction = (StopBehaviorType)value;

                    NUILog.Debug($"<[{GetId()}]SET val={currentStates.stopEndAction}>");

                    Interop.View.InternalUpdateVisualPropertyInt(this.SwigCPtr, ImageView.Property.IMAGE, ImageVisualProperty.StopBehavior, (int)currentStates.stopEndAction);
                }
            }
            get
            {
                NUILog.Debug($"StopBehavior get! {currentStates.stopEndAction}");
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
            get
            {
                return (bool)GetValue(RedrawInScalingDownProperty);
            }
            set
            {
                SetValue(RedrawInScalingDownProperty, value);
                NotifyPropertyChanged();
            }
        }

        private bool InternalRedrawInScalingDown
        {
            set
            {
                if (currentStates.redrawInScalingDown != value)
                {
                    currentStates.changed = true;
                    currentStates.redrawInScalingDown = value;

                    NUILog.Debug($"<[{GetId()}]SET currentStates.redrawInScalingDown={currentStates.redrawInScalingDown}>");

                    Interop.View.InternalUpdateVisualPropertyBool(this.SwigCPtr, ImageView.Property.IMAGE, ImageVisualProperty.RedrawInScalingDown, currentStates.redrawInScalingDown);
                }
            }
            get
            {
                NUILog.Debug($"RedrawInScalingDown get! {currentStates.redrawInScalingDown}");
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
            if (currentStates.framePlayRangeMin != minFrame || currentStates.framePlayRangeMax != maxFrame)
            {
                NUILog.Debug($"< [{GetId()}] SetPlayRange({minFrame}, {maxFrame})");
                currentStates.changed = true;
                currentStates.framePlayRangeMin = minFrame;
                currentStates.framePlayRangeMax = maxFrame;

                Interop.View.InternalUpdateVisualPropertyIntPair(this.SwigCPtr, ImageView.Property.IMAGE, ImageVisualProperty.PlayRange, currentStates.framePlayRangeMin, currentStates.framePlayRangeMax);

                NUILog.Debug($"  [{GetId()}] currentStates.min:({currentStates.framePlayRangeMin}, max:{currentStates.framePlayRangeMax})>");
            }
        }

        /// <summary>
        /// Play Animation.
        /// </summary>
        /// <since_tizen> 7 </since_tizen>
        public new void Play()
        {
            NUILog.Debug($"<[{GetId()}] Play()");
            debugPrint();
            base.Play();
            NUILog.Debug($"[{GetId()}]>");
        }

        /// <summary>
        /// Pause Animation.
        /// </summary>
        /// <since_tizen> 7 </since_tizen>
        public new void Pause()
        {
            NUILog.Debug($"<[{GetId()}] Pause()>");
            debugPrint();
            base.Pause();
            NUILog.Debug($"[{GetId()}]>");
        }

        /// <summary>
        /// Stop Animation.
        /// </summary>
        /// <since_tizen> 7 </since_tizen>
        public new void Stop()
        {
            NUILog.Debug($"<[{GetId()}] Stop()");
            debugPrint();
            base.Stop();
            NUILog.Debug($"[{GetId()}]>");
        }

        /// <summary>
        /// Get the list of layers' information such as the start frame and the end frame in the Lottie file.
        /// </summary>
        /// <returns>List of Tuple (string of layer name, integer of start frame, integer of end frame)</returns>
        /// <since_tizen> 7 </since_tizen>
        public List<Tuple<string, int, int>> GetContentInfo()
        {
            if (currentStates.contentInfo != null)
            {
                return currentStates.contentInfo;
            }

            NUILog.Debug($"<");

            PropertyMap imageMap = base.Image;
            if (imageMap != null)
            {
                PropertyValue val = imageMap.Find(ImageVisualProperty.ContentInfo);
                PropertyMap contentMap = new PropertyMap();
                if (val?.Get(ref contentMap) == true)
                {
                    currentStates.contentInfo = new List<Tuple<string, int, int>>();
                    for (uint i = 0; i < contentMap.Count(); i++)
                    {
                        using PropertyKey propertyKey = contentMap.GetKeyAt(i);
                        string key = propertyKey.StringKey;

                        using PropertyValue arrVal = contentMap.GetValue(i);
                        using PropertyArray arr = new PropertyArray();
                        if (arrVal.Get(arr))
                        {
                            int startFrame = -1;
                            using PropertyValue start = arr.GetElementAt(0);
                            start?.Get(out startFrame);

                            int endFrame = -1;
                            using PropertyValue end = arr.GetElementAt(1);
                            end?.Get(out endFrame);

                            NUILog.Debug($"[{i}] layer name={key}, startFrame={startFrame}, endFrame={endFrame}");

                            Tuple<string, int, int> item = new Tuple<string, int, int>(key, startFrame, endFrame);

                            currentStates.contentInfo?.Add(item);
                        }
                    }
                }
                contentMap.Dispose();
                val?.Dispose();
            }
            NUILog.Debug($">");

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
            if (currentStates.mark1 != marker1 || currentStates.mark2 != marker2)
            {
                NUILog.Debug($"< [{GetId()}] SetMinMaxFrameByMarker({marker1}, {marker2})");

                currentStates.changed = true;
                currentStates.mark1 = marker1;
                currentStates.mark2 = marker2;

                if (string.IsNullOrEmpty(currentStates.mark2))
                {
                    Interop.View.InternalUpdateVisualPropertyString(this.SwigCPtr, ImageView.Property.IMAGE, ImageVisualProperty.PlayRange, currentStates.mark1);
                }
                else
                {
                    Interop.View.InternalUpdateVisualPropertyStringPair(this.SwigCPtr, ImageView.Property.IMAGE, ImageVisualProperty.PlayRange, currentStates.mark1, currentStates.mark2);
                }

                NUILog.Debug($"  [{GetId()}] currentStates.mark1:{currentStates.mark1}, mark2:{currentStates.mark2} >");
            }
        }

        /// <summary>
        /// Get MinMax Frame
        /// </summary>
        /// <returns>Tuple of Min and Max frames</returns>
        // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Tuple<int, int> GetMinMaxFrame()
        {
            NUILog.Debug($"< [{GetId()}] GetMinMaxFrame()! total frame={currentStates.totalFrame}");

            using PropertyMap map = Image;
            if (map != null)
            {
                using PropertyValue val = map.Find(ImageVisualProperty.PlayRange);
                if (val != null)
                {
                    using PropertyArray array = new PropertyArray();
                    if (val.Get(array))
                    {
                        uint cnt = array.Count();
                        int item1 = -1, item2 = -1;
                        for (uint i = 0; i < cnt; i++)
                        {
                            using PropertyValue v = array.GetElementAt(i);
                            int intRet;
                            if (v.Get(out intRet))
                            {
                                NUILog.Debug($"Got play range of string [{i}]: {intRet}");
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
                        NUILog.Debug($"  [{GetId()}] GetMinMaxFrame(min:{item1}, max:{item2})! >");
                        return new Tuple<int, int>(item1, item2);
                    }
                }
            }
            Tizen.Log.Error("NUI", $"[ERR] fail to get play range from dali! case#2");
            return new Tuple<int, int>(-1, -1);
        }

        // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void DoActionExtension(LottieAnimationViewDynamicProperty info)
        {
            dynamicPropertyCallbackId++;

            weakReferencesOfLottie?.Add(dynamicPropertyCallbackId, new WeakReference<LottieAnimationView>(this));
            InternalSavedDynamicPropertyCallbacks?.Add(dynamicPropertyCallbackId, info.Callback);

            Interop.View.DoActionExtension(SwigCPtr, ImageView.Property.IMAGE, ActionSetDynamicProperty, dynamicPropertyCallbackId, info.KeyPath, (int)info.Property, Marshal.GetFunctionPointerForDelegate<System.Delegate>(rootCallback));

            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        private void CleanCallbackDictionaries()
        {
            if (weakReferencesOfLottie?.Count > 0 && InternalSavedDynamicPropertyCallbacks != null)
            {
                foreach (var key in InternalSavedDynamicPropertyCallbacks?.Keys)
                {
                    if (weakReferencesOfLottie.ContainsKey(key))
                    {
                        weakReferencesOfLottie.Remove(key);
                    }
                }
            }
            InternalSavedDynamicPropertyCallbacks?.Clear();
            InternalSavedDynamicPropertyCallbacks = null;
        }

        /// <summary>
        /// Update lottie-image-relative properties synchronously.
        /// After call this API, All image properties updated.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void UpdateImage()
        {
            if (!imagePropertyUpdatedFlag) return;

            // Update currentStates properties to cachedImagePropertyMap
            if(currentStates.changed)
            {
                UpdateImage(ImageVisualProperty.LoopCount, new PropertyValue(currentStates.loopCount), false);
                UpdateImage(ImageVisualProperty.StopBehavior, new PropertyValue((int)currentStates.stopEndAction), false);
                UpdateImage(ImageVisualProperty.LoopingMode, new PropertyValue((int)currentStates.loopMode), false);
                UpdateImage(ImageVisualProperty.RedrawInScalingDown, new PropertyValue(currentStates.redrawInScalingDown), false);

                // Do not cache PlayRange and TotalFrameNumber into cachedImagePropertyMap.
                // (To keep legacy implements behaviour)
                currentStates.changed = false;
            }

            base.UpdateImage();
        }

        /// <summary>
        /// Update NUI cached animated image visual property map by inputed property map.
        /// And call base.MergeCachedImageVisualProperty()
        /// </summary>
        /// <remarks>
        /// For performance issue, we will collect only "cachedLottieAnimationPropertyKeyList" hold in this class.
        /// </remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void MergeCachedImageVisualProperty(PropertyMap map)
        {
            if (map == null) return;
            if (cachedImagePropertyMap == null)
            {
                cachedImagePropertyMap = new PropertyMap();
            }
            foreach (var key in cachedLottieAnimationPropertyKeyList)
            {
                PropertyValue value = map.Find(key);
                if (value != null)
                {
                    // Update-or-Insert new value
                    cachedImagePropertyMap[key] = value;
                }
            }
            base.MergeCachedImageVisualProperty(map);
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
                    NUILog.Debug($"<[{GetId()}] Finished eventhandler added>");
                    visualEventSignalCallback = onVisualEventSignal;
                    using VisualEventSignal visualEvent = VisualEventSignal();
                    visualEvent.Connect(visualEventSignalCallback);
                }
                finishedEventHandler += value;
            }
            remove
            {
                NUILog.Debug($"<[{GetId()}] Finished eventhandler removed>");
                finishedEventHandler -= value;
                if (finishedEventHandler == null && visualEventSignalCallback != null)
                {
                    using VisualEventSignal visualEvent = VisualEventSignal();
                    visualEvent.Disconnect(visualEventSignalCallback);
                    if (visualEvent?.Empty() == true)
                    {
                        visualEventSignalCallback = null;
                    }
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

        /// <summary>
        /// Vector Property
        /// </summary>
        // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public enum VectorProperty
        {
            /// <summary>
            /// Fill color of the object, Type of <see cref="Vector3"/>
            /// </summary>
            [EditorBrowsable(EditorBrowsableState.Never)]
            FillColor,

            /// <summary>
            /// Fill opacity of the object, Type of float
            /// </summary>
            [EditorBrowsable(EditorBrowsableState.Never)]
            FillOpacity,

            /// <summary>
            /// Stroke color of the object, Type of <see cref="Vector3"/>
            /// </summary>
            [EditorBrowsable(EditorBrowsableState.Never)]
            StrokeColor,

            /// <summary>
            /// Stroke opacity of the object, Type of float
            /// </summary>
            [EditorBrowsable(EditorBrowsableState.Never)]
            StrokeOpacity,

            /// <summary>
            /// Stroke width of the object, Type of float
            /// </summary>
            [EditorBrowsable(EditorBrowsableState.Never)]
            StrokeWidth,

            /// <summary>
            /// Transform anchor of the Layer and Group object, Type of <see cref="Vector2"/>
            /// </summary>
            [EditorBrowsable(EditorBrowsableState.Never)]
            TransformAnchor,

            /// <summary>
            /// Transform position of the Layer and Group object, Type of <see cref="Vector2"/>
            /// </summary>
            [EditorBrowsable(EditorBrowsableState.Never)]
            TransformPosition,

            /// <summary>
            /// Transform scale of the Layer and Group object, Type of <see cref="Vector2"/>, Value range of [0..100]
            /// </summary>
            [EditorBrowsable(EditorBrowsableState.Never)]
            TransformScale,

            /// <summary>
            /// Transform rotation of the Layer and Group object, Type of float, Value range of [0..360] in degrees
            /// </summary>
            [EditorBrowsable(EditorBrowsableState.Never)]
            TransformRotation,

            /// <summary>
            /// Transform opacity of the Layer and Group object, Type of float
            /// </summary>
            [EditorBrowsable(EditorBrowsableState.Never)]
            TransformOpacity
        };

        // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate PropertyValue DynamicPropertyCallbackType(int returnType, uint frameNumber);
        #endregion Event, Enum, Struct, ETC


        #region Internal
        /// <summary>
        /// Actions property value to Jump to the specified frame.
        /// </summary>
        internal static readonly int ActionJumpTo = Interop.LottieAnimationView.AnimatedVectorImageVisualActionJumpToGet();

        // This is used for internal purpose.
        internal static readonly int ActionSetDynamicProperty = Interop.LottieAnimationView.AnimatedVectorImageVisualActionSetDynamicProperty();

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
                    using VisualEventSignal visualEvent = VisualEventSignal();
                    visualEvent?.Connect(visualEventSignalCallback);
                }
                visualEventSignalHandler += value;
            }
            remove
            {
                visualEventSignalHandler -= value;
                if (visualEventSignalHandler == null && visualEventSignalCallback != null)
                {
                    using VisualEventSignal visualEvent = VisualEventSignal();
                    visualEvent?.Disconnect(visualEventSignalCallback);
                    if (visualEvent?.Empty() == true)
                    {
                        visualEventSignalCallback = null;
                    }
                }
            }
        }

        internal void EmitVisualEventSignal(int visualIndex, int signalId)
        {
            using VisualEventSignal visualEvent = VisualEventSignal();
            visualEvent?.Emit(this, visualIndex, signalId);
        }

        internal VisualEventSignal VisualEventSignal()
        {
            VisualEventSignal ret = new VisualEventSignal(Interop.VisualEventSignal.NewWithView(View.getCPtr(this)), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal Dictionary<int, DynamicPropertyCallbackType> InternalSavedDynamicPropertyCallbacks = new Dictionary<int, DynamicPropertyCallbackType>();

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void RootCallbackType(int id, int returnType, uint frameNumber, ref float val1, ref float val2, ref float val3);

        internal RootCallbackType rootCallback = RootCallback;

        static internal void RootCallback(int id, int returnType, uint frameNumber, ref float val1, ref float val2, ref float val3)
        {
            WeakReference<LottieAnimationView> current = null;
            LottieAnimationView currentView = null;
            DynamicPropertyCallbackType currentCallback = null;
            PropertyValue ret = null;

            if (weakReferencesOfLottie.TryGetValue(id, out current))
            {
                if (current.TryGetTarget(out currentView))
                {
                    if (currentView != null && currentView.InternalSavedDynamicPropertyCallbacks != null &&
                        currentView.InternalSavedDynamicPropertyCallbacks.TryGetValue(id, out currentCallback))
                    {
                        ret = currentCallback?.Invoke(returnType, frameNumber);
                    }
                    else
                    {
                        Tizen.Log.Error("NUI", "can't find the callback in LottieAnimationView, just return here!");
                        return;
                    }
                }
                else
                {
                    Tizen.Log.Error("NUI", "can't find the callback in LottieAnimationView, just return here!");
                    return;
                }
            }
            else
            {
                Tizen.Log.Error("NUI", "can't find LottieAnimationView by id, just return here!");
                return;
            }

            switch (returnType)
            {
                case (int)(VectorProperty.FillColor):
                case (int)(VectorProperty.StrokeColor):
                    Vector3 tmpVector3 = new Vector3(-1, -1, -1);
                    if ((ret != null) && ret.Get(tmpVector3))
                    {
                        val1 = tmpVector3.X;
                        val2 = tmpVector3.Y;
                        val3 = tmpVector3.Z;
                    }
                    tmpVector3.Dispose();
                    break;

                case (int)(VectorProperty.TransformAnchor):
                case (int)(VectorProperty.TransformPosition):
                case (int)(VectorProperty.TransformScale):
                    Vector2 tmpVector2 = new Vector2(-1, -1);
                    if ((ret != null) && ret.Get(tmpVector2))
                    {
                        val1 = tmpVector2.X;
                        val2 = tmpVector2.Y;
                    }
                    tmpVector2.Dispose();
                    break;

                case (int)(VectorProperty.FillOpacity):
                case (int)(VectorProperty.StrokeOpacity):
                case (int)(VectorProperty.StrokeWidth):
                case (int)(VectorProperty.TransformRotation):
                case (int)(VectorProperty.TransformOpacity):
                    float tmpFloat = -1;
                    if ((ret != null) && ret.Get(out tmpFloat))
                    {
                        val1 = tmpFloat;
                    }
                    break;
                default:
                    //do nothing
                    break;
            }
            ret?.Dispose();
        }
        #endregion Internal


        #region Private

        // Collection of lottie-image-sensitive properties.
        private static readonly List<int> cachedLottieAnimationPropertyKeyList = new List<int> {
            ImageVisualProperty.LoopCount,
            ImageVisualProperty.StopBehavior,
            ImageVisualProperty.LoopingMode,
            ImageVisualProperty.RedrawInScalingDown,
        };

        private struct states
        {
            internal string url;
            internal int loopCount;
            internal LoopingModeType loopMode;
            internal StopBehaviorType stopEndAction;
            internal int framePlayRangeMin;
            internal int framePlayRangeMax;
            internal int totalFrame;
            internal float scale;
            internal PlayStateType playState;
            internal List<Tuple<string, int, int>> contentInfo;
            internal string mark1, mark2;
            internal bool redrawInScalingDown;
            internal bool changed;
        };
        private states currentStates;

        private const string tag = "NUITEST";
        private event EventHandler finishedEventHandler;

        private void OnFinished()
        {
            NUILog.Debug($"<[{GetId()}] OnFinished()>");
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
                    NUILog.Debug($"targetView is not null! name={v.Name}");
                }
                else
                {
                    NUILog.Debug($"target is something created from dali");
                }
            }
            VisualEventSignalArgs e = new VisualEventSignalArgs();
            e.VisualIndex = visualIndex;
            e.SignalId = signalId;
            visualEventSignalHandler?.Invoke(this, e);

            NUILog.Debug($"<[{GetId()}] onVisualEventSignal()! visualIndex={visualIndex}, signalId={signalId}>");
        }

        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate void VisualEventSignalCallbackType(IntPtr targetView, int visualIndex, int signalId);

        private VisualEventSignalCallbackType visualEventSignalCallback;
        private EventHandler<VisualEventSignalArgs> visualEventSignalHandler;

        static private int dynamicPropertyCallbackId = 0;
        //static private Dictionary<int, DynamicPropertyCallbackType> dynamicPropertyCallbacks = new Dictionary<int, DynamicPropertyCallbackType>();
        static private Dictionary<int, WeakReference<LottieAnimationView>> weakReferencesOfLottie = new Dictionary<int, WeakReference<LottieAnimationView>>();

        private void debugPrint()
        {
            NUILog.Debug($"===================================");
            NUILog.Debug($"<[{GetId()}] get currentStates : url={currentStates.url}, loopCount={currentStates.loopCount}, \nframePlayRangeMin/Max({currentStates.framePlayRangeMin},{currentStates.framePlayRangeMax}) ");
            NUILog.Debug($"  get from Property : StopBehavior={StopBehavior}, LoopMode={LoopingMode}, LoopCount={LoopCount}, PlayState={PlayState}");
            NUILog.Debug($"  RedrawInScalingDown={RedrawInScalingDown} >");
            NUILog.Debug($"===================================");
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
                return new LottieFrameInfo(Int32.Parse(parts[0].Trim(), CultureInfo.InvariantCulture));
            }
            else if (parts.Length == 2)
            {
                return new LottieFrameInfo(Int32.Parse(parts[0].Trim(), CultureInfo.InvariantCulture), Int32.Parse(parts[1].Trim(), CultureInfo.InvariantCulture));
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
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1062: Validate arguments of public methods", Justification = "The null checking is done by BeReadyToShow()")]
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

    // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
    [EditorBrowsable(EditorBrowsableState.Never)]
    public struct LottieAnimationViewDynamicProperty : IEquatable<LottieAnimationViewDynamicProperty>
    {
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string KeyPath { get; set; }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public LottieAnimationView.VectorProperty Property { get; set; }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public LottieAnimationView.DynamicPropertyCallbackType Callback { get; set; }

        public override bool Equals(object obj)
        {
            if (obj is LottieAnimationViewDynamicProperty target)
            {
                if (KeyPath == target.KeyPath && Property == target.Property && Callback == target.Callback)
                {
                    return true;
                }
            }
            return false;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public static bool operator ==(LottieAnimationViewDynamicProperty left, LottieAnimationViewDynamicProperty right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(LottieAnimationViewDynamicProperty left, LottieAnimationViewDynamicProperty right)
        {
            return !(left == right);
        }

        public bool Equals(LottieAnimationViewDynamicProperty other)
        {
            if (other != null)
            {
                if (KeyPath == other.KeyPath && Property == other.Property && Callback == other.Callback)
                {
                    return true;
                }
            }
            return false;
        }
    }

}
