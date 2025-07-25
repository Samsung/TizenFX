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
using System.Collections.Concurrent;
using System.Globalization;
using Tizen.NUI;
using Tizen.NUI.Binding;

namespace Tizen.NUI.BaseComponents
{
    /// <summary>
    /// LottieAnimationView renders an animated vector image (Lottie file).
    /// </summary>
    /// <since_tizen> 7 </since_tizen>
    public partial class LottieAnimationView : ImageView
    {
        static LottieAnimationView()
        {
            if(NUIApplication.IsUsingXaml)
            {
                URLProperty = BindableProperty.Create(nameof(URL), typeof(string), typeof(Tizen.NUI.BaseComponents.LottieAnimationView), string.Empty, propertyChanged: SetInternalURLProperty, defaultValueCreator: GetInternalURLProperty);

                CurrentFrameProperty = BindableProperty.Create(nameof(CurrentFrame), typeof(int), typeof(Tizen.NUI.BaseComponents.LottieAnimationView), 0, propertyChanged: SetInternalCurrentFrameProperty, defaultValueCreator: GetInternalCurrentFrameProperty);

                LoopingModeProperty = BindableProperty.Create(nameof(LoopingMode), typeof(LoopingModeType), typeof(LottieAnimationView), default(LoopingModeType), propertyChanged: SetInternalLoopingModeProperty, defaultValueCreator: GetInternalLoopingModeProperty);

                LoopCountProperty = BindableProperty.Create(nameof(LoopCount), typeof(int), typeof(Tizen.NUI.BaseComponents.LottieAnimationView), 0, propertyChanged: SetInternalLoopCountProperty, defaultValueCreator: GetInternalLoopCountProperty);

                StopBehaviorProperty = BindableProperty.Create(nameof(StopBehavior), typeof(StopBehaviorType), typeof(LottieAnimationView), default(StopBehaviorType), propertyChanged: SetInternalStopBehaviorProperty, defaultValueCreator: GetInternalStopBehaviorProperty);

                RedrawInScalingDownProperty = BindableProperty.Create(nameof(RedrawInScalingDown), typeof(bool), typeof(Tizen.NUI.BaseComponents.LottieAnimationView), false, propertyChanged: SetInternalRedrawInScalingDownProperty, defaultValueCreator: GetInternalRedrawInScalingDownProperty);

                EnableFrameCacheProperty = BindableProperty.Create(nameof(EnableFrameCache), typeof(bool), typeof(Tizen.NUI.BaseComponents.LottieAnimationView), false, propertyChanged: SetInternalEnableFrameCacheProperty, defaultValueCreator: GetInternalEnableFrameCacheProperty);

                NotifyAfterRasterizationProperty = BindableProperty.Create(nameof(NotifyAfterRasterization), typeof(bool), typeof(Tizen.NUI.BaseComponents.LottieAnimationView), false, propertyChanged: SetInternalNotifyAfterRasterizationProperty, defaultValueCreator: GetInternalNotifyAfterRasterizationProperty);
            }
        }

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
            currentStates.frameSpeedFactor = 1.0f;
            currentStates.framePlayRangeMin = -1;
            currentStates.framePlayRangeMax = -1;
            currentStates.totalFrame = -1;
            currentStates.scale = scale;
            currentStates.redrawInScalingDown = true;
            currentStates.redrawInScalingUp = true;
            currentStates.desiredWidth = 0;
            currentStates.desiredHeight = 0;
            currentStates.synchronousLoading = true;
            currentStates.enableFrameCache = false;
            currentStates.notifyAfterRasterization = false;
            currentStates.renderScale = 1.0f;

            // Notify to base ImageView cache that default synchronousLoading for lottie file is true.
            base.SynchronousLoading = currentStates.synchronousLoading;

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

            if (type == DisposeTypes.Explicit)
            {
                //Release your own unmanaged resources here.
                //You should not access any managed member here except static instance.
                //because the execution order of Finalizes is non-deterministic.
                CleanCallbackDictionaries(true);
            }

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
            if (!disposing)
            {
                // Note : We can clean dictionaries even this API called from GC Thread.
                CleanCallbackDictionaries(true);
            }
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
                if (NUIApplication.IsUsingXaml)
                {
                    return GetValue(URLProperty) as string;
                }
                else
                {
                    return InternalURL;
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(URLProperty, value);
                }
                else
                {
                    InternalURL = value;
                }
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// Set or Get resource URL of Lottie file.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new string ResourceUrl
        {
            get
            {
                return URL;
            }
            set
            {
                URL = value;
            }
        }

        private string InternalURL
        {
            set
            {
                // Invalidate previous dynamic property callbacks.
                CleanCallbackDictionaries(false);

                // Reset cached infomations.
                currentStates.contentInfo = null;
                currentStates.markerInfo = null;
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

                map.Add(Visual.Property.Type, (int)Visual.Type.AnimatedVectorImage)
                    .Add(ImageVisualProperty.URL, currentStates.url)
                    .Add(ImageVisualProperty.LoopCount, currentStates.loopCount)
                    .Add(ImageVisualProperty.StopBehavior, (int)currentStates.stopEndAction)
                    .Add(ImageVisualProperty.LoopingMode, (int)currentStates.loopMode)
                    .Add(ImageVisualProperty.RedrawInScalingDown, currentStates.redrawInScalingDown)
                    .Add(ImageVisualProperty.RedrawInScalingUp, currentStates.redrawInScalingUp)
                    .Add(ImageVisualProperty.SynchronousLoading, currentStates.synchronousLoading)
                    .Add(ImageVisualProperty.EnableFrameCache, currentStates.enableFrameCache)
                    .Add(ImageVisualProperty.NotifyAfterRasterization, currentStates.notifyAfterRasterization)
                    .Add(ImageVisualProperty.FrameSpeedFactor, currentStates.frameSpeedFactor)
                    .Add(ImageVisualProperty.RenderScale, currentStates.renderScale);

                if (currentStates.desiredWidth > 0)
                {
                    map.Add(ImageVisualProperty.DesiredWidth, currentStates.desiredWidth);
                }
                if (currentStates.desiredHeight > 0)
                {
                    map.Add(ImageVisualProperty.DesiredHeight, currentStates.desiredHeight);
                }

                Image = map;

                if (backgroundExtraData != null)
                {
                    if (backgroundExtraData.CornerRadius != null || backgroundExtraData.CornerSquareness != null)
                    {
                        UpdateBackgroundExtraData(BackgroundExtraDataUpdatedFlag.ContentsCornerRadius);
                    }
                }

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
        /// Gets or sets the desired image width for LottieAnimationView<br />
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new int DesiredWidth
        {
            get
            {
                return currentStates.desiredWidth;
            }
            set
            {
                currentStates.desiredWidth = value;
                base.DesiredWidth = currentStates.desiredWidth;
            }
        }

        /// <summary>
        /// Gets or sets the desired image height for LottieAnimationView<br />
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new int DesiredHeight
        {
            get
            {
                return currentStates.desiredHeight;
            }
            set
            {
                currentStates.desiredHeight = value;
                base.DesiredHeight = currentStates.desiredHeight;
            }
        }

        /// <summary>
        /// Gets or sets the SynchronousLoading for LottieAnimationView<br />
        /// We should set it before setup ResourceUrl, URL property.<br />
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new bool SynchronousLoading
        {
            get
            {
                return currentStates.synchronousLoading;
            }
            set
            {
                currentStates.synchronousLoading = value;
                base.SynchronousLoading = currentStates.synchronousLoading;
            }
        }

        /// <summary>
        /// Gets the playing state of the LottieAnimationView.
        /// This property returns the current play state of the LottieAnimationView.
        /// </summary>
        /// <since_tizen> 7 </since_tizen>
        public PlayStateType PlayState
        {
            get
            {
                NUILog.Debug($"< Get!");

                int ret = 0;
                _ = Interop.View.InternalRetrievingVisualPropertyInt(this.SwigCPtr, ImageView.Property.IMAGE, ImageVisualProperty.PlayState, out ret);

                currentStates.playState = (PlayStateType)ret;
                NUILog.Debug($"gotten play state={currentStates.playState} >");

                return currentStates.playState;
            }
        }

        /// <summary>
        /// Get the number of total frames.
        /// If resouce is still not be loaded, or invalid resource, the value is 0.
        /// </summary>
        /// <since_tizen> 7 </since_tizen>
        public int TotalFrame
        {
            get
            {
                int ret = currentStates.totalFrame;
                if (ret <= 0)
                {
                    _ = Interop.View.InternalRetrievingVisualPropertyInt(this.SwigCPtr, ImageView.Property.IMAGE, ImageVisualProperty.TotalFrameNumber, out ret);

                    currentStates.totalFrame = ret;
                    NUILog.Debug($"TotalFrameNumber get! ret={ret}");

                    if (ret <= 0)
                    {
                        Tizen.Log.Error("NUI", $"Fail to get TotalFrame. Maybe file is not loaded yet, or invalid url used. url : {currentStates.url}\n");
                    }
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
                if (NUIApplication.IsUsingXaml)
                {
                    return (int)GetValue(CurrentFrameProperty);
                }
                else
                {
                    return InternalCurrentFrame;
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(CurrentFrameProperty, value);
                }
                else
                {
                    InternalCurrentFrame = value;
                }
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

                _ = Interop.View.InternalRetrievingVisualPropertyInt(this.SwigCPtr, ImageView.Property.IMAGE, ImageVisualProperty.CurrentFrameNumber, out ret);

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
                if (NUIApplication.IsUsingXaml)
                {
                    return (LoopingModeType)GetValue(LoopingModeProperty);
                }
                else
                {
                    return InternalLoopingMode;
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(LoopingModeProperty, value);
                }
                else
                {
                    InternalLoopingMode = value;
                }
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

                    _ = Interop.View.InternalUpdateVisualPropertyInt(this.SwigCPtr, ImageView.Property.IMAGE, ImageVisualProperty.LoopingMode, (int)currentStates.loopMode);
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
                if (NUIApplication.IsUsingXaml)
                {
                    return (int)GetValue(LoopCountProperty);
                }
                else
                {
                    return InternalLoopCount;
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(LoopCountProperty, value);
                }
                else
                {
                    InternalLoopCount = value;
                }
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

                    _ = Interop.View.InternalUpdateVisualPropertyInt(this.SwigCPtr, ImageView.Property.IMAGE, ImageVisualProperty.LoopCount, currentStates.loopCount);
                }
            }
            get
            {
                NUILog.Debug($"LoopCount get! {currentStates.loopCount}");
                return currentStates.loopCount;
            }
        }

        /// <summary>
        /// Sets or gets the stop behavior of the LottieAnimationView.
        /// This property determines how the animation behaves when it stops.
        /// </summary>
        /// <since_tizen> 7 </since_tizen>
        public StopBehaviorType StopBehavior
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return (StopBehaviorType)GetValue(StopBehaviorProperty);
                }
                else
                {
                    return InternalStopBehavior;
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(StopBehaviorProperty, value);
                }
                else
                {
                    InternalStopBehavior = value;
                }
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

                    _ = Interop.View.InternalUpdateVisualPropertyInt(this.SwigCPtr, ImageView.Property.IMAGE, ImageVisualProperty.StopBehavior, (int)currentStates.stopEndAction);
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
                if (NUIApplication.IsUsingXaml)
                {
                    return (bool)GetValue(RedrawInScalingDownProperty);
                }
                else
                {
                    return InternalRedrawInScalingDown;
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(RedrawInScalingDownProperty, value);
                }
                else
                {
                    InternalRedrawInScalingDown = value;
                }
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

                    _ = Interop.View.InternalUpdateVisualPropertyBool(this.SwigCPtr, ImageView.Property.IMAGE, ImageVisualProperty.RedrawInScalingDown, currentStates.redrawInScalingDown);
                }
            }
            get
            {
                NUILog.Debug($"RedrawInScalingDown get! {currentStates.redrawInScalingDown}");
                return currentStates.redrawInScalingDown;
            }
        }

        /// <summary>
        /// Whether to redraw the image when the visual is scaled up.
        /// </summary>
        /// <remarks>
        /// Inhouse API.
        /// It is used in the AnimatedVectorImageVisual.The default is true.
        /// </remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool RedrawInScalingUp
        {
            get
            {
                return InternalRedrawInScalingUp;
            }
            set
            {
                InternalRedrawInScalingUp = value;
                NotifyPropertyChanged();
            }
        }

        private bool InternalRedrawInScalingUp
        {
            set
            {
                if (currentStates.redrawInScalingUp != value)
                {
                    currentStates.changed = true;
                    currentStates.redrawInScalingUp = value;

                    NUILog.Debug($"<[{GetId()}]SET currentStates.redrawInScalingUp={currentStates.redrawInScalingUp}>");

                    _ = Interop.View.InternalUpdateVisualPropertyBool(this.SwigCPtr, ImageView.Property.IMAGE, ImageVisualProperty.RedrawInScalingUp, currentStates.redrawInScalingUp);
                }
            }
            get
            {
                NUILog.Debug($"RedrawInScalingUp get! {currentStates.redrawInScalingUp}");
                return currentStates.redrawInScalingUp;
            }
        }

        /// <summary>
        /// Whether to AnimatedVectorImageVisual fixed cache or not.
        /// </summary>
        /// <remarks>
        /// If this property is true, AnimatedVectorImageVisual enable frame cache for loading and keeps loaded frame
        /// until the visual is removed. It reduces CPU cost when the animated image will be looping.
        /// But it can spend a lot of memory if the resource has high resolution image or many frame count.
        ///
        /// Inhouse API.
        /// It is used in the AnimatedVectorImageVisual.The default is false.
        /// </remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool EnableFrameCache
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return (bool)GetValue(EnableFrameCacheProperty);
                }
                else
                {
                    return InternalEnableFrameCache;
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(EnableFrameCacheProperty, value);
                }
                else
                {
                    InternalEnableFrameCache = value;
                }
                NotifyPropertyChanged();
            }
        }

        private bool InternalEnableFrameCache
        {
            set
            {
                if (currentStates.enableFrameCache != value)
                {
                    currentStates.changed = true;
                    currentStates.enableFrameCache = value;

                    NUILog.Debug($"<[{GetId()}]SET currentStates.EnableFrameCache={currentStates.enableFrameCache}>");

                    _ = Interop.View.InternalUpdateVisualPropertyBool(this.SwigCPtr, ImageView.Property.IMAGE, ImageVisualProperty.EnableFrameCache, currentStates.enableFrameCache);
                }
            }
            get
            {
                NUILog.Debug($"EnableFrameCache get! {currentStates.enableFrameCache}");
                return currentStates.enableFrameCache;
            }
        }

        /// <summary>
        /// Whether notify AnimatedVectorImageVisual to render thread after every rasterization or not.
        /// </summary>
        /// <remarks>
        /// If this property is true, AnimatedVectorImageVisual send notify to render thread after every rasterization.
        /// If false, AnimatedVectorImageVisual set Renderer's Behaviour as Continouly (mean, always update the render thread.)
        /// This flag is useful if given resource has low fps, so we don't need to render every frame.
        ///
        /// Inhouse API.
        /// It is used in the AnimatedVectorImageVisual.The default is false.
        /// </remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool NotifyAfterRasterization
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return (bool)GetValue(NotifyAfterRasterizationProperty);
                }
                else
                {
                    return InternalNotifyAfterRasterization;
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(NotifyAfterRasterizationProperty, value);
                }
                else
                {
                    InternalNotifyAfterRasterization = value;
                }
                NotifyPropertyChanged();
            }
        }

        private bool InternalNotifyAfterRasterization
        {
            set
            {
                if (currentStates.notifyAfterRasterization != value)
                {
                    currentStates.changed = true;
                    currentStates.notifyAfterRasterization = value;

                    NUILog.Debug($"<[{GetId()}]SET currentStates.NotifyAfterRasterization={currentStates.notifyAfterRasterization}>");

                    _ = Interop.View.InternalUpdateVisualPropertyBool(this.SwigCPtr, ImageView.Property.IMAGE, ImageVisualProperty.NotifyAfterRasterization, currentStates.notifyAfterRasterization);
                }
            }
            get
            {
                NUILog.Debug($"NotifyAfterRasterization get! {currentStates.notifyAfterRasterization}");
                return currentStates.notifyAfterRasterization;
            }
        }

        /// <summary>
        /// Specifies a speed factor for the animated image frame.
        /// </summary>
        /// <remarks>
        /// The speed factor is a multiplier of the normal velocity of the animation. Values between [0,1] will
        /// slow down the animation and values above one will speed up the animation.
        ///
        /// The range of this value is clamped between [0.01f ~ 100.0f].
        ///
        /// Inhouse API.
        /// The default is 1.0f.
        /// </remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float FrameSpeedFactor
        {
            get
            {
                return InternalFrameSpeedFactor;
            }
            set
            {
                InternalFrameSpeedFactor = value;
                NotifyPropertyChanged();
            }
        }

        private float InternalFrameSpeedFactor
        {
            set
            {
                if (currentStates.frameSpeedFactor != value)
                {
                    currentStates.changed = true;
                    currentStates.frameSpeedFactor = value;

                    NUILog.Debug($"<[{GetId()}]SET currentStates.FrameSpeedFactor={currentStates.frameSpeedFactor}>");

                    _ = Interop.View.InternalUpdateVisualPropertyFloat(this.SwigCPtr, ImageView.Property.IMAGE, ImageVisualProperty.FrameSpeedFactor, currentStates.frameSpeedFactor);
                }
            }
            get
            {
                NUILog.Debug($"FrameSpeedFactor get! {currentStates.frameSpeedFactor}");
                return currentStates.frameSpeedFactor;
            }
        }

        /// <summary>
        /// Renders a texture at a given scale.
        /// </summary>
        /// <remarks>
        /// Inhouse API.
        /// The default is 1.0f.
        /// </remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float RenderScale
        {
            get
            {
                return InternalRenderScale;
            }
            set
            {
                InternalRenderScale = value;
                NotifyPropertyChanged();
            }
        }

        private float InternalRenderScale
        {
            set
            {
                if (currentStates.renderScale != value)
                {
                    currentStates.changed = true;
                    currentStates.renderScale = value;

                    NUILog.Debug($"<[{GetId()}]SET currentStates.RenderScale={currentStates.renderScale}>");

                    _ = Interop.View.InternalUpdateVisualPropertyFloat(this.SwigCPtr, ImageView.Property.IMAGE, ImageVisualProperty.RenderScale, currentStates.renderScale);
                }
            }
            get
            {
                NUILog.Debug($"RenderScale get! {currentStates.renderScale}");
                return currentStates.renderScale;
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

                // Remove marker information.
                currentStates.mark1 = null;
                currentStates.mark2 = null;

                _ = Interop.View.InternalUpdateVisualPropertyIntPair(this.SwigCPtr, ImageView.Property.IMAGE, ImageVisualProperty.PlayRange, currentStates.framePlayRangeMin, currentStates.framePlayRangeMax);

                NUILog.Debug($"  [{GetId()}] currentStates.min:({currentStates.framePlayRangeMin}, max:{currentStates.framePlayRangeMax})>");
            }
        }

        /// <summary>
        /// Plays the Lottie animation.
        /// This method starts the playback of the Lottie animation.
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
        /// Pauses the Lottie animation.
        /// This method pauses the animation without resetting its progress.
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
        /// Stops the Lottie animation.
        /// This method stops the currently playing Lottie animation.
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
                if (TotalFrame > 0) // Check whether image file loaded successfuly.
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
            }
            NUILog.Debug($">");

            return currentStates.contentInfo;
        }

        /// <summary>
        /// Get the list of markers' information such as the start frame and the end frame in the Lottie file.
        /// </summary>
        /// <returns>List of Tuple (string of marker name, integer of start frame, integer of end frame)</returns>
        // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public List<Tuple<string, int, int>> GetMarkerInfo()
        {
            if (currentStates.markerInfo != null)
            {
                return currentStates.markerInfo;
            }

            NUILog.Debug($"<");

            PropertyMap imageMap = base.Image;
            if (imageMap != null)
            {
                if (TotalFrame > 0) // Check whether image file loaded successfuly.
                {
                    PropertyValue val = imageMap.Find(ImageVisualProperty.MarkerInfo);
                    PropertyMap markerMap = new PropertyMap();
                    if (val?.Get(ref markerMap) == true)
                    {
                        currentStates.markerInfo = new List<Tuple<string, int, int>>();
                        for (uint i = 0; i < markerMap.Count(); i++)
                        {
                            using PropertyKey propertyKey = markerMap.GetKeyAt(i);
                            string key = propertyKey.StringKey;

                            using PropertyValue arrVal = markerMap.GetValue(i);
                            using PropertyArray arr = new PropertyArray();
                            if (arrVal.Get(arr))
                            {
                                int startFrame = -1;
                                using PropertyValue start = arr.GetElementAt(0);
                                start?.Get(out startFrame);

                                int endFrame = -1;
                                using PropertyValue end = arr.GetElementAt(1);
                                end?.Get(out endFrame);

                                NUILog.Debug($"[{i}] marker name={key}, startFrame={startFrame}, endFrame={endFrame}");

                                Tuple<string, int, int> item = new Tuple<string, int, int>(key, startFrame, endFrame);

                                currentStates.markerInfo?.Add(item);
                            }
                        }
                    }
                    markerMap.Dispose();
                    val?.Dispose();
                }
            }
            NUILog.Debug($">");

            return currentStates.markerInfo;
        }

        /// <summary>
        /// A marker has its start frame and end frame.
        /// Animation will play between the start frame and the end frame of the marker if one marker is specified.
        /// Or animation will play between the start frame of the first marker and the end frame of the second marker if two markers are specified.
        /// </summary>
        /// <param name="marker1">First marker</param>
        /// <param name="marker2">Second marker</param>
        // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SetMinMaxFrameByMarker(string marker1, string marker2 = null)
        {
            string marker1OrEmpty = marker1 ?? ""; // mark1 should not be null
            if (currentStates.mark1 != marker1OrEmpty || currentStates.mark2 != marker2)
            {
                NUILog.Debug($"< [{GetId()}] SetMinMaxFrameByMarker({marker1OrEmpty}, {marker2})");

                currentStates.changed = true;
                currentStates.mark1 = marker1OrEmpty;
                currentStates.mark2 = marker2;

                // Remove frame information.
                currentStates.framePlayRangeMin = -1;
                currentStates.framePlayRangeMax = -1;

                if (string.IsNullOrEmpty(currentStates.mark2))
                {
                    _ = Interop.View.InternalUpdateVisualPropertyString(this.SwigCPtr, ImageView.Property.IMAGE, ImageVisualProperty.PlayRange, currentStates.mark1);
                }
                else
                {
                    _ = Interop.View.InternalUpdateVisualPropertyStringPair(this.SwigCPtr, ImageView.Property.IMAGE, ImageVisualProperty.PlayRange, currentStates.mark1, currentStates.mark2);
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
            // Called from main thread
            dynamicPropertyCallbackId++;

            lock (InternalPropertyCallbacksLock)
            {
                // Add to dictionary only if we can assume that this view is not in disposing state.
                if (InternalSavedDynamicPropertyCallbacks != null)
                {
                    weakReferencesOfLottie?.TryAdd(dynamicPropertyCallbackId, new WeakReference<LottieAnimationView>(this));

                    InternalSavedDynamicPropertyCallbacks.Add(dynamicPropertyCallbackId, info.Callback);
                    NUILog.Debug($"<[{GetId()}] added extension actions for {dynamicPropertyCallbackId} (total : {weakReferencesOfLottie?.Count} my : {InternalSavedDynamicPropertyCallbacks?.Count})>");
                }
            }

            Interop.View.DoActionExtension(SwigCPtr, ImageView.Property.IMAGE, ActionSetDynamicProperty, dynamicPropertyCallbackId, info.KeyPath, (int)info.Property, Marshal.GetFunctionPointerForDelegate<System.Delegate>(rootCallback));

            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        private void CleanCallbackDictionaries(bool disposing)
        {
            // Called from main, or GC threads
            lock (InternalPropertyCallbacksLock)
            {
                NUILog.Debug($"<[{GetId()}] remove extension actions with disposing:{disposing} (total : {weakReferencesOfLottie?.Count} my : {InternalSavedDynamicPropertyCallbacks?.Count})>");
                if (weakReferencesOfLottie?.Count > 0 && InternalSavedDynamicPropertyCallbacks != null)
                {
                    foreach (var key in InternalSavedDynamicPropertyCallbacks.Keys)
                    {
                        // Note : We can assume that key is unique.
                        if (weakReferencesOfLottie.ContainsKey(key))
                        {
                            NUILog.Debug($"<[{GetId()}] remove extension actions for {key}>");
                            weakReferencesOfLottie.TryRemove(key, out var _);
                        }
                    }
                }
                InternalSavedDynamicPropertyCallbacks?.Clear();
                NUILog.Debug($"<[{GetId()}] remove extension actions finished (total : {weakReferencesOfLottie?.Count})>");

                if (disposing)
                {
                    // Ensure to make it as null if we want to dispose current view now.
                    InternalSavedDynamicPropertyCallbacks = null;
                }
            }
        }

        /// <summary>
        /// Update lottie-image-relative properties synchronously.
        /// After call this API, All image properties updated.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void UpdateImage()
        {
            if (Disposed)
            {
                return;
            }

            if (!imagePropertyUpdatedFlag) return;

            // Update currentStates properties to cachedImagePropertyMap
            if (currentStates.changed)
            {
                using (var pv = new PropertyValue(currentStates.loopCount))
                    UpdateImage(ImageVisualProperty.LoopCount, pv, false);
                using (var pv = new PropertyValue((int)currentStates.stopEndAction))
                    UpdateImage(ImageVisualProperty.StopBehavior, pv, false);
                using (var pv = new PropertyValue((int)currentStates.loopMode))
                    UpdateImage(ImageVisualProperty.LoopingMode, pv, false);
                using (var pv = new PropertyValue(currentStates.redrawInScalingDown))
                    UpdateImage(ImageVisualProperty.RedrawInScalingDown, pv, false);
                using (var pv = new PropertyValue(currentStates.redrawInScalingUp))
                    UpdateImage(ImageVisualProperty.RedrawInScalingUp, pv, false);
                using (var pv = new PropertyValue(currentStates.synchronousLoading))
                    UpdateImage(ImageVisualProperty.SynchronousLoading, pv, false);
                using (var pv = new PropertyValue(currentStates.enableFrameCache))
                    UpdateImage(ImageVisualProperty.EnableFrameCache, pv, false);
                using (var pv = new PropertyValue(currentStates.notifyAfterRasterization))
                    UpdateImage(ImageVisualProperty.NotifyAfterRasterization, pv, false);
                using (var pv = new PropertyValue(currentStates.frameSpeedFactor))
                    UpdateImage(ImageVisualProperty.FrameSpeedFactor, pv, false);
                using (var pv = new PropertyValue(currentStates.renderScale))
                    UpdateImage(ImageVisualProperty.RenderScale, pv, false);

                // Do not cache PlayRange and TotalFrameNumber into cachedImagePropertyMap.
                // (To keep legacy implements behaviour)
                currentStates.changed = false;
            }

            base.UpdateImage();

            // TODO : It is necessary to relocate `InternalSavedDynamicPropertyCallbacks` as the visuals have been altered, while the URL remains unchaged.
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
        /// The event handler for the animation finished event.
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
                    visualEvent?.Disconnect(visualEventSignalCallback);
                    visualEventSignalCallback = null;
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
            TransformOpacity,

            /// <summary>
            /// Trim Start property of Shape object, Type of float, Value range of [0..100]
            /// </summary>
            [EditorBrowsable(EditorBrowsableState.Never)]
            TrimStart,

            /// <summary>
            /// Trim End property of Shape object, Type of float, Type of <see cref="Vector2"/>, Value range of [0..100]
            /// </summary>
            [EditorBrowsable(EditorBrowsableState.Never)]
            TrimEnd
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
        internal static readonly int ActionSetDynamicProperty = Interop.LottieAnimationView.AnimatedVectorImageVisualActionSetDynamicPropertyGet();
        internal static readonly int ActionFlush = Interop.LottieAnimationView.AnimatedVectorImageVisualActionFlushGet();

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

        internal object InternalPropertyCallbacksLock = new object();
        internal Dictionary<int, DynamicPropertyCallbackType> InternalSavedDynamicPropertyCallbacks = new Dictionary<int, DynamicPropertyCallbackType>();

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void RootCallbackType(int id, int returnType, uint frameNumber, ref float val1, ref float val2, ref float val3);

        static internal RootCallbackType rootCallback = RootCallback;

        static internal void RootCallback(int id, int returnType, uint frameNumber, ref float val1, ref float val2, ref float val3)
        {
            // Called from various worker threads.
            // Be careful about thread safety!

            WeakReference<LottieAnimationView> current = null;
            LottieAnimationView currentView = null;
            DynamicPropertyCallbackType currentCallback = null;
            PropertyValue ret = null;

            if (weakReferencesOfLottie.TryGetValue(id, out current))
            {
                if (current.TryGetTarget(out currentView) && (currentView != null) && !currentView.IsDisposedOrQueued)
                {
                    lock (currentView.InternalPropertyCallbacksLock)
                    {
                        currentView.InternalSavedDynamicPropertyCallbacks?.TryGetValue(id, out currentCallback);
                    }

                    if (currentCallback != null)
                    {
                        ret = currentCallback.Invoke(returnType, frameNumber);
                    }
                    else
                    {
                        Tizen.Log.Debug("NUI", "can't find the callback in LottieAnimationView (Maybe disposed). just return here!");
                        return;
                    }
                }
                else
                {
                    Tizen.Log.Debug("NUI", "LottieAnimationView already disposed. just return here!");
                    return;
                }
            }
            else
            {
                Tizen.Log.Debug("NUI", "can't find LottieAnimationView by id (Maybe disposed). just return here!");
                return;
            }

            switch (returnType)
            {
                case (int)(VectorProperty.FillColor):
                case (int)(VectorProperty.StrokeColor):
                {
                    float tmpVal1 = -1;
                    float tmpVal2 = -1;
                    float tmpVal3 = -1;
                    if ((ret != null) && ret.GetVector3Component(out tmpVal1, out tmpVal2, out tmpVal3))
                    {
                        val1 = tmpVal1;
                        val2 = tmpVal2;
                        val3 = tmpVal3;
                    }
                    break;
                }

                case (int)(VectorProperty.TransformAnchor):
                case (int)(VectorProperty.TransformPosition):
                case (int)(VectorProperty.TransformScale):
                case (int)(VectorProperty.TrimEnd):
                {
                    float tmpVal1 = -1;
                    float tmpVal2 = -1;
                    if ((ret != null) && ret.GetVector2Component(out tmpVal1, out tmpVal2))
                    {
                        val1 = tmpVal1;
                        val2 = tmpVal2;
                    }
                    break;
                }

                case (int)(VectorProperty.FillOpacity):
                case (int)(VectorProperty.StrokeOpacity):
                case (int)(VectorProperty.StrokeWidth):
                case (int)(VectorProperty.TransformRotation):
                case (int)(VectorProperty.TransformOpacity):
                case (int)(VectorProperty.TrimStart):
                {
                    float tmpVal1 = -1;
                    if ((ret != null) && ret.Get(out tmpVal1))
                    {
                        val1 = tmpVal1;
                    }
                    break;
                }
                default:
                    //do nothing
                    break;
            }
        }

        internal void FlushLottieMessages()
        {
            NUILog.Debug($"<[{GetId()}]FLUSH>");

            Interop.View.DoActionWithEmptyAttributes(this.SwigCPtr, ImageView.Property.IMAGE, ActionFlush);
        }
        #endregion Internal


        #region Private

        // Collection of lottie-image-sensitive properties.
        private static readonly List<int> cachedLottieAnimationPropertyKeyList = new List<int> {
            ImageVisualProperty.LoopCount,
            ImageVisualProperty.StopBehavior,
            ImageVisualProperty.LoopingMode,
            ImageVisualProperty.RedrawInScalingDown,
            ImageVisualProperty.RedrawInScalingUp,
            ImageVisualProperty.EnableFrameCache,
            ImageVisualProperty.NotifyAfterRasterization,
            ImageVisualProperty.FrameSpeedFactor,
            ImageVisualProperty.RenderScale,
        };

        private struct states
        {
            internal string url;
            internal int loopCount;
            internal LoopingModeType loopMode;
            internal StopBehaviorType stopEndAction;
            internal float frameSpeedFactor;
            internal float renderScale;
            internal int framePlayRangeMin;
            internal int framePlayRangeMax;
            internal int totalFrame;
            internal float scale;
            internal PlayStateType playState;
            internal List<Tuple<string, int, int>> contentInfo;
            internal List<Tuple<string, int, int>> markerInfo;
            internal string mark1, mark2;
            internal bool redrawInScalingDown, redrawInScalingUp;
            internal int desiredWidth, desiredHeight;
            internal bool synchronousLoading;
            internal bool enableFrameCache;
            internal bool notifyAfterRasterization;
            internal bool changed;
        };
        private states currentStates;

        private event EventHandler finishedEventHandler;

        private void OnFinished()
        {
            NUILog.Debug($"<[{GetId()}] OnFinished()>");
            finishedEventHandler?.Invoke(this, null);
        }

        private void onVisualEventSignal(IntPtr targetView, int visualIndex, int signalId)
        {
            if (IsDisposedOrQueued)
            {
                return;
            }

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

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void VisualEventSignalCallbackType(IntPtr targetView, int visualIndex, int signalId);

        private VisualEventSignalCallbackType visualEventSignalCallback;
        private EventHandler<VisualEventSignalArgs> visualEventSignalHandler;

        static private int dynamicPropertyCallbackId;
        //static private Dictionary<int, DynamicPropertyCallbackType> dynamicPropertyCallbacks = new Dictionary<int, DynamicPropertyCallbackType>();
        static private ConcurrentDictionary<int, WeakReference<LottieAnimationView>> weakReferencesOfLottie = new ConcurrentDictionary<int, WeakReference<LottieAnimationView>>();

        private void debugPrint()
        {
            NUILog.Debug($"===================================");
            NUILog.Debug($"<[{GetId()}] get currentStates : url={currentStates.url}, loopCount={currentStates.loopCount}, \nframePlayRangeMin/Max({currentStates.framePlayRangeMin},{currentStates.framePlayRangeMax}) ");
            NUILog.Debug($"  get from Property : StopBehavior={StopBehavior}, LoopMode={LoopingMode}, LoopCount={LoopCount}, PlayState={PlayState}");
            NUILog.Debug($"  RedrawInScalingDown={RedrawInScalingDown} RedrawInScalingUp={RedrawInScalingUp} RenderScale={RenderScale} >");
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
            if (KeyPath == other.KeyPath && Property == other.Property && Callback == other.Callback)
            {
                return true;
            }
            return false;
        }
    }

}
