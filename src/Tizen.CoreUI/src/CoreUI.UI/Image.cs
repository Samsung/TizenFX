/*
 * Copyright 2019 by its authors. See AUTHORS.
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *     http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Diagnostics.Contracts;
namespace CoreUI.UI {
    /// <summary>CoreUI UI image class
    /// 
    /// When loading images from a file, the <see cref="CoreUI.IFile.Key"/> property can be used to access different streams. For example, when accessing Evas image caches.</summary>
    /// <since_tizen> 6 </since_tizen>
    [CoreUI.UI.Image.NativeMethods]
    [CoreUI.Wrapper.BindingEntity]
    [SuppressMessage("Microsoft.Naming", "CA1724:TypeNamesShouldNotMatchNamespaces")]
    public class Image : CoreUI.UI.Widget, CoreUI.IFile, CoreUI.IPlayer, CoreUI.Gfx.IArrangement, CoreUI.Gfx.IImage, CoreUI.Gfx.IImageLoadController, CoreUI.Gfx.IImageOrientable, CoreUI.Input.IClickable, CoreUI.Layout.ICalc, CoreUI.Layout.IGroup, CoreUI.Layout.ISignal
    {
        /// <summary>Pointer to the native class description.</summary>
        public override System.IntPtr NativeClass
        {
            get
            {
                if (((object)this).GetType() == typeof(Image))
                {
                    return GetCoreUIClassStatic();
                }
                else
                {
                    return CoreUI.Wrapper.ClassRegister.klassFromType[((object)this).GetType()];
                }
            }
        }

        [System.Runtime.InteropServices.DllImport(CoreUI.Libs.Elementary)] internal static extern System.IntPtr
            efl_ui_image_class_get();

        /// <summary>Initializes a new instance of the <see cref="Image"/> class.
        /// </summary>
        /// <param name="parent">Parent instance.</param>
    /// <param name="style">The widget style to use. See <see cref="CoreUI.UI.Widget.SetStyle" /></param>
        public Image(CoreUI.Object parent, System.String style = null) : base(efl_ui_image_class_get(), parent)
        {
            if (CoreUI.Wrapper.Globals.ParamHelperCheck(style))
            {
                SetStyle(CoreUI.Wrapper.Globals.GetParamHelper(style));
            }

            FinishInstantiation();
        }

        /// <summary>Subclasses should override this constructor if they are expected to be instantiated from native code.
        /// Do not call this constructor directly.
        /// </summary>
        /// <param name="ch">Tag struct storing the native handle of the object being constructed.</param>
        protected Image(ConstructingHandle ch) : base(ch)
        {
        }

        /// <summary>Initializes a new instance of the <see cref="Image"/> class.
        /// Internal usage: Constructs an instance from a native pointer. This is used when interacting with C code and should not be used directly.
        /// </summary>
        /// <param name="wh">The native pointer to be wrapped.</param>
        internal Image(CoreUI.Wrapper.WrappingHandle wh) : base(wh)
        {
        }

        /// <summary>Initializes a new instance of the <see cref="Image"/> class.
        /// Internal usage: Constructor to forward the wrapper initialization to the root class that interfaces with native code. Should not be used directly.
        /// </summary>
        /// <param name="baseKlass">The pointer to the base native Eo class.</param>
        /// <param name="parent">The CoreUI.Object parent of this instance.</param>
        protected Image(IntPtr baseKlass, CoreUI.Object parent) : base(baseKlass, parent)
        {
        }


        /// <summary>Called when the playing state has changed. The event value reflects the current state.</summary>
        /// <since_tizen> 6 </since_tizen>
        /// <value><see cref="CoreUI.PlayerPlayingChangedEventArgs"/></value>
        public event EventHandler<CoreUI.PlayerPlayingChangedEventArgs> PlayingChanged
        {
            add
            {
                CoreUI.EventCb callerCb = GetInternalEventCallback(value, info => new CoreUI.PlayerPlayingChangedEventArgs{ Arg = Marshal.ReadByte(info) != 0 });
                string key = "_EFL_PLAYER_EVENT_PLAYING_CHANGED";
                AddNativeEventHandler(CoreUI.Libs.Elementary, key, callerCb, value);
            }

            remove
            {
                string key = "_EFL_PLAYER_EVENT_PLAYING_CHANGED";
                RemoveNativeEventHandler(CoreUI.Libs.Elementary, key, value);
            }
        }

        /// <summary>Method to raise event PlayingChanged.
        /// </summary>
        /// <param name="e">Event to raise.</param>
        /// <since_tizen> 6 </since_tizen>
        protected virtual void OnPlayingChanged(CoreUI.PlayerPlayingChangedEventArgs e)
        {
            Contract.Requires(e != null, nameof(e));
            IntPtr info = CoreUI.DataTypes.PrimitiveConversion.ManagedToPointerAlloc(e.Arg ? (byte) 1 : (byte) 0);
            CallNativeEventCallback(CoreUI.Libs.Elementary, "_EFL_PLAYER_EVENT_PLAYING_CHANGED", info, (p) => Marshal.FreeHGlobal(p));
        }

        /// <summary>Called when the paused state has changed. The event value reflects the current state.</summary>
        /// <since_tizen> 6 </since_tizen>
        /// <value><see cref="CoreUI.PlayerPausedChangedEventArgs"/></value>
        public event EventHandler<CoreUI.PlayerPausedChangedEventArgs> PausedChanged
        {
            add
            {
                CoreUI.EventCb callerCb = GetInternalEventCallback(value, info => new CoreUI.PlayerPausedChangedEventArgs{ Arg = Marshal.ReadByte(info) != 0 });
                string key = "_EFL_PLAYER_EVENT_PAUSED_CHANGED";
                AddNativeEventHandler(CoreUI.Libs.Elementary, key, callerCb, value);
            }

            remove
            {
                string key = "_EFL_PLAYER_EVENT_PAUSED_CHANGED";
                RemoveNativeEventHandler(CoreUI.Libs.Elementary, key, value);
            }
        }

        /// <summary>Method to raise event PausedChanged.
        /// </summary>
        /// <param name="e">Event to raise.</param>
        /// <since_tizen> 6 </since_tizen>
        protected virtual void OnPausedChanged(CoreUI.PlayerPausedChangedEventArgs e)
        {
            Contract.Requires(e != null, nameof(e));
            IntPtr info = CoreUI.DataTypes.PrimitiveConversion.ManagedToPointerAlloc(e.Arg ? (byte) 1 : (byte) 0);
            CallNativeEventCallback(CoreUI.Libs.Elementary, "_EFL_PLAYER_EVENT_PAUSED_CHANGED", info, (p) => Marshal.FreeHGlobal(p));
        }

        /// <summary>Called when the playback_progress state has changed. The event value reflects the current state.</summary>
        /// <since_tizen> 6 </since_tizen>
        /// <value><see cref="CoreUI.PlayerPlaybackProgressChangedEventArgs"/></value>
        public event EventHandler<CoreUI.PlayerPlaybackProgressChangedEventArgs> PlaybackProgressChanged
        {
            add
            {
                CoreUI.EventCb callerCb = GetInternalEventCallback(value, info => new CoreUI.PlayerPlaybackProgressChangedEventArgs{ Arg = CoreUI.DataTypes.PrimitiveConversion.PointerToManaged<double>(info) });
                string key = "_EFL_PLAYER_EVENT_PLAYBACK_PROGRESS_CHANGED";
                AddNativeEventHandler(CoreUI.Libs.Elementary, key, callerCb, value);
            }

            remove
            {
                string key = "_EFL_PLAYER_EVENT_PLAYBACK_PROGRESS_CHANGED";
                RemoveNativeEventHandler(CoreUI.Libs.Elementary, key, value);
            }
        }

        /// <summary>Method to raise event PlaybackProgressChanged.
        /// </summary>
        /// <param name="e">Event to raise.</param>
        /// <since_tizen> 6 </since_tizen>
        protected virtual void OnPlaybackProgressChanged(CoreUI.PlayerPlaybackProgressChangedEventArgs e)
        {
            Contract.Requires(e != null, nameof(e));
            IntPtr info = CoreUI.DataTypes.PrimitiveConversion.ManagedToPointerAlloc(e.Arg);
            CallNativeEventCallback(CoreUI.Libs.Elementary, "_EFL_PLAYER_EVENT_PLAYBACK_PROGRESS_CHANGED", info, (p) => Marshal.FreeHGlobal(p));
        }

        /// <summary>Called when the playback_position state has changed. The event value reflects the current state.</summary>
        /// <since_tizen> 6 </since_tizen>
        /// <value><see cref="CoreUI.PlayerPlaybackPositionChangedEventArgs"/></value>
        public event EventHandler<CoreUI.PlayerPlaybackPositionChangedEventArgs> PlaybackPositionChanged
        {
            add
            {
                CoreUI.EventCb callerCb = GetInternalEventCallback(value, info => new CoreUI.PlayerPlaybackPositionChangedEventArgs{ Arg = CoreUI.DataTypes.PrimitiveConversion.PointerToManaged<double>(info) });
                string key = "_EFL_PLAYER_EVENT_PLAYBACK_POSITION_CHANGED";
                AddNativeEventHandler(CoreUI.Libs.Elementary, key, callerCb, value);
            }

            remove
            {
                string key = "_EFL_PLAYER_EVENT_PLAYBACK_POSITION_CHANGED";
                RemoveNativeEventHandler(CoreUI.Libs.Elementary, key, value);
            }
        }

        /// <summary>Method to raise event PlaybackPositionChanged.
        /// </summary>
        /// <param name="e">Event to raise.</param>
        /// <since_tizen> 6 </since_tizen>
        protected virtual void OnPlaybackPositionChanged(CoreUI.PlayerPlaybackPositionChangedEventArgs e)
        {
            Contract.Requires(e != null, nameof(e));
            IntPtr info = CoreUI.DataTypes.PrimitiveConversion.ManagedToPointerAlloc(e.Arg);
            CallNativeEventCallback(CoreUI.Libs.Elementary, "_EFL_PLAYER_EVENT_PLAYBACK_POSITION_CHANGED", info, (p) => Marshal.FreeHGlobal(p));
        }

        /// <summary>Called when the player has begun to repeat its data stream. The event value is the current number of repeats.</summary>
        /// <since_tizen> 6 </since_tizen>
        /// <value><see cref="CoreUI.PlayerPlaybackRepeatedEventArgs"/></value>
        public event EventHandler<CoreUI.PlayerPlaybackRepeatedEventArgs> PlaybackRepeated
        {
            add
            {
                CoreUI.EventCb callerCb = GetInternalEventCallback(value, info => new CoreUI.PlayerPlaybackRepeatedEventArgs{ Arg = Marshal.ReadInt32(info) });
                string key = "_EFL_PLAYER_EVENT_PLAYBACK_REPEATED";
                AddNativeEventHandler(CoreUI.Libs.Elementary, key, callerCb, value);
            }

            remove
            {
                string key = "_EFL_PLAYER_EVENT_PLAYBACK_REPEATED";
                RemoveNativeEventHandler(CoreUI.Libs.Elementary, key, value);
            }
        }

        /// <summary>Method to raise event PlaybackRepeated.
        /// </summary>
        /// <param name="e">Event to raise.</param>
        /// <since_tizen> 6 </since_tizen>
        protected virtual void OnPlaybackRepeated(CoreUI.PlayerPlaybackRepeatedEventArgs e)
        {
            Contract.Requires(e != null, nameof(e));
            IntPtr info = CoreUI.DataTypes.PrimitiveConversion.ManagedToPointerAlloc(e.Arg);
            CallNativeEventCallback(CoreUI.Libs.Elementary, "_EFL_PLAYER_EVENT_PLAYBACK_REPEATED", info, (p) => Marshal.FreeHGlobal(p));
        }

        /// <summary>Called when the player has completed playing its data stream.</summary>
        /// <since_tizen> 6 </since_tizen>
        public event EventHandler PlaybackFinished
        {
            add
            {
                CoreUI.EventCb callerCb = GetInternalEventCallback(value);
                string key = "_EFL_PLAYER_EVENT_PLAYBACK_FINISHED";
                AddNativeEventHandler(CoreUI.Libs.Elementary, key, callerCb, value);
            }

            remove
            {
                string key = "_EFL_PLAYER_EVENT_PLAYBACK_FINISHED";
                RemoveNativeEventHandler(CoreUI.Libs.Elementary, key, value);
            }
        }

        /// <summary>Method to raise event PlaybackFinished.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        protected virtual void OnPlaybackFinished()
        {
            CallNativeEventCallback(CoreUI.Libs.Elementary, "_EFL_PLAYER_EVENT_PLAYBACK_FINISHED", IntPtr.Zero, null);
        }

        /// <summary>If <c>true</c>, image data has been preloaded and can be displayed. If <c>false</c>, the image data has been unloaded and can no longer be displayed.</summary>
        /// <since_tizen> 6 </since_tizen>
        /// <value><see cref="CoreUI.Gfx.ImageImagePreloadStateChangedEventArgs"/></value>
        public event EventHandler<CoreUI.Gfx.ImageImagePreloadStateChangedEventArgs> ImagePreloadStateChanged
        {
            add
            {
                CoreUI.EventCb callerCb = GetInternalEventCallback(value, info => new CoreUI.Gfx.ImageImagePreloadStateChangedEventArgs{ Arg = Marshal.ReadByte(info) != 0 });
                string key = "_EFL_GFX_IMAGE_EVENT_IMAGE_PRELOAD_STATE_CHANGED";
                AddNativeEventHandler(CoreUI.Libs.Elementary, key, callerCb, value);
            }

            remove
            {
                string key = "_EFL_GFX_IMAGE_EVENT_IMAGE_PRELOAD_STATE_CHANGED";
                RemoveNativeEventHandler(CoreUI.Libs.Elementary, key, value);
            }
        }

        /// <summary>Method to raise event ImagePreloadStateChanged.
        /// </summary>
        /// <param name="e">Event to raise.</param>
        /// <since_tizen> 6 </since_tizen>
        protected virtual void OnImagePreloadStateChanged(CoreUI.Gfx.ImageImagePreloadStateChangedEventArgs e)
        {
            Contract.Requires(e != null, nameof(e));
            IntPtr info = CoreUI.DataTypes.PrimitiveConversion.ManagedToPointerAlloc(e.Arg ? (byte) 1 : (byte) 0);
            CallNativeEventCallback(CoreUI.Libs.Elementary, "_EFL_GFX_IMAGE_EVENT_IMAGE_PRELOAD_STATE_CHANGED", info, (p) => Marshal.FreeHGlobal(p));
        }

        /// <summary>Image was resized (its pixel data). The event data is the image&apos;s new size.</summary>
        /// <since_tizen> 6 </since_tizen>
        /// <value><see cref="CoreUI.Gfx.ImageImageResizedEventArgs"/></value>
        public event EventHandler<CoreUI.Gfx.ImageImageResizedEventArgs> ImageResized
        {
            add
            {
                CoreUI.EventCb callerCb = GetInternalEventCallback(value, info => new CoreUI.Gfx.ImageImageResizedEventArgs{ Arg =  info });
                string key = "_EFL_GFX_IMAGE_EVENT_IMAGE_RESIZED";
                AddNativeEventHandler(CoreUI.Libs.Elementary, key, callerCb, value);
            }

            remove
            {
                string key = "_EFL_GFX_IMAGE_EVENT_IMAGE_RESIZED";
                RemoveNativeEventHandler(CoreUI.Libs.Elementary, key, value);
            }
        }

        /// <summary>Method to raise event ImageResized.
        /// </summary>
        /// <param name="e">Event to raise.</param>
        /// <since_tizen> 6 </since_tizen>
        protected virtual void OnImageResized(CoreUI.Gfx.ImageImageResizedEventArgs e)
        {
            Contract.Requires(e != null, nameof(e));
            IntPtr info = Marshal.AllocHGlobal(Marshal.SizeOf(e.Arg));
            CallNativeEventCallback(CoreUI.Libs.Elementary, "_EFL_GFX_IMAGE_EVENT_IMAGE_RESIZED", info, (p) => Marshal.FreeHGlobal(p));
        }

        /// <summary>Called when object is in sequence pressed and unpressed by the primary button</summary>
        /// <since_tizen> 6 </since_tizen>
        /// <value><see cref="CoreUI.Input.ClickableClickedEventArgs"/></value>
        public event EventHandler<CoreUI.Input.ClickableClickedEventArgs> Clicked
        {
            add
            {
                CoreUI.EventCb callerCb = GetInternalEventCallback(value, info => new CoreUI.Input.ClickableClickedEventArgs{ Arg =  info });
                string key = "_EFL_INPUT_EVENT_CLICKED";
                AddNativeEventHandler(CoreUI.Libs.Elementary, key, callerCb, value);
            }

            remove
            {
                string key = "_EFL_INPUT_EVENT_CLICKED";
                RemoveNativeEventHandler(CoreUI.Libs.Elementary, key, value);
            }
        }

        /// <summary>Method to raise event Clicked.
        /// </summary>
        /// <param name="e">Event to raise.</param>
        /// <since_tizen> 6 </since_tizen>
        protected virtual void OnClicked(CoreUI.Input.ClickableClickedEventArgs e)
        {
            Contract.Requires(e != null, nameof(e));
            IntPtr info = Marshal.AllocHGlobal(Marshal.SizeOf(e.Arg));
            CallNativeEventCallback(CoreUI.Libs.Elementary, "_EFL_INPUT_EVENT_CLICKED", info, (p) => Marshal.FreeHGlobal(p));
        }

        /// <summary>Called when object is in sequence pressed and unpressed by any button. The button that triggered the event can be found in the event information.</summary>
        /// <since_tizen> 6 </since_tizen>
        /// <value><see cref="CoreUI.Input.ClickableClickedAnyEventArgs"/></value>
        public event EventHandler<CoreUI.Input.ClickableClickedAnyEventArgs> ClickedAny
        {
            add
            {
                CoreUI.EventCb callerCb = GetInternalEventCallback(value, info => new CoreUI.Input.ClickableClickedAnyEventArgs{ Arg =  info });
                string key = "_EFL_INPUT_EVENT_CLICKED_ANY";
                AddNativeEventHandler(CoreUI.Libs.Elementary, key, callerCb, value);
            }

            remove
            {
                string key = "_EFL_INPUT_EVENT_CLICKED_ANY";
                RemoveNativeEventHandler(CoreUI.Libs.Elementary, key, value);
            }
        }

        /// <summary>Method to raise event ClickedAny.
        /// </summary>
        /// <param name="e">Event to raise.</param>
        /// <since_tizen> 6 </since_tizen>
        protected virtual void OnClickedAny(CoreUI.Input.ClickableClickedAnyEventArgs e)
        {
            Contract.Requires(e != null, nameof(e));
            IntPtr info = Marshal.AllocHGlobal(Marshal.SizeOf(e.Arg));
            CallNativeEventCallback(CoreUI.Libs.Elementary, "_EFL_INPUT_EVENT_CLICKED_ANY", info, (p) => Marshal.FreeHGlobal(p));
        }

        /// <summary>Called when the object is pressed, event_info is the button that got pressed</summary>
        /// <since_tizen> 6 </since_tizen>
        /// <value><see cref="CoreUI.Input.ClickablePressedEventArgs"/></value>
        public event EventHandler<CoreUI.Input.ClickablePressedEventArgs> Pressed
        {
            add
            {
                CoreUI.EventCb callerCb = GetInternalEventCallback(value, info => new CoreUI.Input.ClickablePressedEventArgs{ Arg = Marshal.ReadInt32(info) });
                string key = "_EFL_INPUT_EVENT_PRESSED";
                AddNativeEventHandler(CoreUI.Libs.Elementary, key, callerCb, value);
            }

            remove
            {
                string key = "_EFL_INPUT_EVENT_PRESSED";
                RemoveNativeEventHandler(CoreUI.Libs.Elementary, key, value);
            }
        }

        /// <summary>Method to raise event Pressed.
        /// </summary>
        /// <param name="e">Event to raise.</param>
        /// <since_tizen> 6 </since_tizen>
        protected virtual void OnPressed(CoreUI.Input.ClickablePressedEventArgs e)
        {
            Contract.Requires(e != null, nameof(e));
            IntPtr info = CoreUI.DataTypes.PrimitiveConversion.ManagedToPointerAlloc(e.Arg);
            CallNativeEventCallback(CoreUI.Libs.Elementary, "_EFL_INPUT_EVENT_PRESSED", info, (p) => Marshal.FreeHGlobal(p));
        }

        /// <summary>Called when the object is no longer pressed, event_info is the button that got pressed</summary>
        /// <since_tizen> 6 </since_tizen>
        /// <value><see cref="CoreUI.Input.ClickableUnpressedEventArgs"/></value>
        public event EventHandler<CoreUI.Input.ClickableUnpressedEventArgs> Unpressed
        {
            add
            {
                CoreUI.EventCb callerCb = GetInternalEventCallback(value, info => new CoreUI.Input.ClickableUnpressedEventArgs{ Arg = Marshal.ReadInt32(info) });
                string key = "_EFL_INPUT_EVENT_UNPRESSED";
                AddNativeEventHandler(CoreUI.Libs.Elementary, key, callerCb, value);
            }

            remove
            {
                string key = "_EFL_INPUT_EVENT_UNPRESSED";
                RemoveNativeEventHandler(CoreUI.Libs.Elementary, key, value);
            }
        }

        /// <summary>Method to raise event Unpressed.
        /// </summary>
        /// <param name="e">Event to raise.</param>
        /// <since_tizen> 6 </since_tizen>
        protected virtual void OnUnpressed(CoreUI.Input.ClickableUnpressedEventArgs e)
        {
            Contract.Requires(e != null, nameof(e));
            IntPtr info = CoreUI.DataTypes.PrimitiveConversion.ManagedToPointerAlloc(e.Arg);
            CallNativeEventCallback(CoreUI.Libs.Elementary, "_EFL_INPUT_EVENT_UNPRESSED", info, (p) => Marshal.FreeHGlobal(p));
        }

        /// <summary>Called when the object receives a long press, event_info is the button that got pressed</summary>
        /// <since_tizen> 6 </since_tizen>
        /// <value><see cref="CoreUI.Input.ClickableLongpressedEventArgs"/></value>
        public event EventHandler<CoreUI.Input.ClickableLongpressedEventArgs> Longpressed
        {
            add
            {
                CoreUI.EventCb callerCb = GetInternalEventCallback(value, info => new CoreUI.Input.ClickableLongpressedEventArgs{ Arg = Marshal.ReadInt32(info) });
                string key = "_EFL_INPUT_EVENT_LONGPRESSED";
                AddNativeEventHandler(CoreUI.Libs.Elementary, key, callerCb, value);
            }

            remove
            {
                string key = "_EFL_INPUT_EVENT_LONGPRESSED";
                RemoveNativeEventHandler(CoreUI.Libs.Elementary, key, value);
            }
        }

        /// <summary>Method to raise event Longpressed.
        /// </summary>
        /// <param name="e">Event to raise.</param>
        /// <since_tizen> 6 </since_tizen>
        protected virtual void OnLongpressed(CoreUI.Input.ClickableLongpressedEventArgs e)
        {
            Contract.Requires(e != null, nameof(e));
            IntPtr info = CoreUI.DataTypes.PrimitiveConversion.ManagedToPointerAlloc(e.Arg);
            CallNativeEventCallback(CoreUI.Libs.Elementary, "_EFL_INPUT_EVENT_LONGPRESSED", info, (p) => Marshal.FreeHGlobal(p));
        }

        /// <summary>The layout was recalculated.</summary>
        /// <since_tizen> 6 </since_tizen>
        public event EventHandler Recalc
        {
            add
            {
                CoreUI.EventCb callerCb = GetInternalEventCallback(value);
                string key = "_EFL_LAYOUT_EVENT_RECALC";
                AddNativeEventHandler(CoreUI.Libs.Elementary, key, callerCb, value);
            }

            remove
            {
                string key = "_EFL_LAYOUT_EVENT_RECALC";
                RemoveNativeEventHandler(CoreUI.Libs.Elementary, key, value);
            }
        }

        /// <summary>Method to raise event Recalc.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        protected virtual void OnRecalc()
        {
            CallNativeEventCallback(CoreUI.Libs.Elementary, "_EFL_LAYOUT_EVENT_RECALC", IntPtr.Zero, null);
        }

        /// <summary>A circular dependency between parts of the object was found.</summary>
        /// <since_tizen> 6 </since_tizen>
        /// <value><see cref="CoreUI.Layout.CalcCircularDependencyEventArgs"/></value>
        public event EventHandler<CoreUI.Layout.CalcCircularDependencyEventArgs> CircularDependency
        {
            add
            {
                CoreUI.EventCb callerCb = GetInternalEventCallback(value, info => new CoreUI.Layout.CalcCircularDependencyEventArgs{ Arg = CoreUI.Wrapper.Globals.NativeArrayToIList<System.String>(info) });
                string key = "_EFL_LAYOUT_EVENT_CIRCULAR_DEPENDENCY";
                AddNativeEventHandler(CoreUI.Libs.Elementary, key, callerCb, value);
            }

            remove
            {
                string key = "_EFL_LAYOUT_EVENT_CIRCULAR_DEPENDENCY";
                RemoveNativeEventHandler(CoreUI.Libs.Elementary, key, value);
            }
        }

        /// <summary>Method to raise event CircularDependency.
        /// </summary>
        /// <param name="e">Event to raise.</param>
        /// <since_tizen> 6 </since_tizen>
        protected virtual void OnCircularDependency(CoreUI.Layout.CalcCircularDependencyEventArgs e)
        {
            Contract.Requires(e != null, nameof(e));
            IntPtr info = CoreUI.Wrapper.Globals.IListToNativeArray(e.Arg, false);
            CallNativeEventCallback(CoreUI.Libs.Elementary, "_EFL_LAYOUT_EVENT_CIRCULAR_DEPENDENCY", info, null);
        }

        /// <summary>The image name, using icon standards names.
        /// 
        /// For example, freedesktop.org defines standard icon names such as &quot;home&quot; and &quot;network&quot;. There can be different icon sets to match those icon keys. The &quot;name&quot; given as parameter is one of these &quot;keys&quot; and will be used to look in the freedesktop.org paths and elementary theme.
        /// 
        /// If the name is not found in any of the expected locations and is the absolute path of an image file, this image will be used. Lookup order used by <see cref="CoreUI.UI.Image.SetIcon"/> can be set using &quot;icon_theme&quot; in config.
        /// 
        /// If the image was set using <see cref="CoreUI.IFile.File"/> instead of <see cref="CoreUI.UI.Image.SetIcon"/>, then reading this property will return null.
        /// 
        /// <b>NOTE: </b>The image set by this function is changed when <see cref="CoreUI.IFile.Load"/> is called.
        /// 
        /// <b>NOTE: </b>This function does not accept relative icon paths.
        /// 
        /// See also <see cref="CoreUI.UI.Image.GetIcon"/>.</summary>
        /// <returns>The icon name</returns>
        /// <since_tizen> 6 </since_tizen>
        public virtual System.String GetIcon() {
            var _ret_var = CoreUI.UI.Image.NativeMethods.efl_ui_image_icon_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)));
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
        }

        /// <summary>The image name, using icon standards names.
        /// 
        /// For example, freedesktop.org defines standard icon names such as &quot;home&quot; and &quot;network&quot;. There can be different icon sets to match those icon keys. The &quot;name&quot; given as parameter is one of these &quot;keys&quot; and will be used to look in the freedesktop.org paths and elementary theme.
        /// 
        /// If the name is not found in any of the expected locations and is the absolute path of an image file, this image will be used. Lookup order used by <see cref="CoreUI.UI.Image.SetIcon"/> can be set using &quot;icon_theme&quot; in config.
        /// 
        /// If the image was set using <see cref="CoreUI.IFile.File"/> instead of <see cref="CoreUI.UI.Image.SetIcon"/>, then reading this property will return null.
        /// 
        /// <b>NOTE: </b>The image set by this function is changed when <see cref="CoreUI.IFile.Load"/> is called.
        /// 
        /// <b>NOTE: </b>This function does not accept relative icon paths.
        /// 
        /// See also <see cref="CoreUI.UI.Image.GetIcon"/>.</summary>
        /// <param name="name">The icon name</param>
        /// <returns><c>true</c> on success, <c>false</c> on error</returns>
        /// <since_tizen> 6 </since_tizen>
        public virtual bool SetIcon(System.String name) {
            var _ret_var = CoreUI.UI.Image.NativeMethods.efl_ui_image_icon_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), name);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
        }

        /// <summary>The mmaped file from where an object will fetch the real data (it must be an <see cref="CoreUI.DataTypes.File"/>).
        /// 
        /// If mmap is set during object construction, the object will automatically call <see cref="CoreUI.IFile.Load"/> during the finalize phase of construction.</summary>
        /// <returns>The handle to the <see cref="CoreUI.DataTypes.File"/> that will be used</returns>
        /// <since_tizen> 6 </since_tizen>
        public virtual CoreUI.DataTypes.File GetMmap() {
            var _ret_var = CoreUI.IFileNativeMethods.efl_file_mmap_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)));
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
        }

        /// <summary>The mmaped file from where an object will fetch the real data (it must be an <see cref="CoreUI.DataTypes.File"/>).
        /// 
        /// If mmap is set during object construction, the object will automatically call <see cref="CoreUI.IFile.Load"/> during the finalize phase of construction.</summary>
        /// <param name="f">The handle to the <see cref="CoreUI.DataTypes.File"/> that will be used</param>
        /// <returns>0 on success, error code otherwise</returns>
        /// <since_tizen> 6 </since_tizen>
        public virtual CoreUI.DataTypes.Error SetMmap(CoreUI.DataTypes.File f) {
            var _ret_var = CoreUI.IFileNativeMethods.efl_file_mmap_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), f);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
        }

        /// <summary>The file path from where an object will fetch the data.
        /// 
        /// If file is set during object construction, the object will automatically call <see cref="CoreUI.IFile.Load"/> during the finalize phase of construction.
        /// 
        /// You must not modify the strings on the returned pointers.</summary>
        /// <returns>The file path.</returns>
        /// <since_tizen> 6 </since_tizen>
        public virtual System.String GetFile() {
            var _ret_var = CoreUI.IFileNativeMethods.efl_file_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)));
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
        }

        /// <summary>The file path from where an object will fetch the data.
        /// 
        /// If file is set during object construction, the object will automatically call <see cref="CoreUI.IFile.Load"/> during the finalize phase of construction.
        /// 
        /// You must not modify the strings on the returned pointers.</summary>
        /// <param name="file">The file path.</param>
        /// <returns>0 on success, error code otherwise</returns>
        /// <since_tizen> 6 </since_tizen>
        public virtual CoreUI.DataTypes.Error SetFile(System.String file) {
            var _ret_var = CoreUI.IFileNativeMethods.efl_file_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), file);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
        }

        /// <summary>The key which corresponds to the target data within a file.
        /// 
        /// Some file types can contain multiple data streams which are indexed by a key. Use this property for such cases (See for example <see cref="CoreUI.UI.Image"/> or <see cref="CoreUI.UI.Layout"/>).
        /// 
        /// You must not modify the strings on the returned pointers.</summary>
        /// <returns>The group that the data belongs to. See the class documentation for particular implementations of this interface to see how this property is used.</returns>
        /// <since_tizen> 6 </since_tizen>
        public virtual System.String GetKey() {
            var _ret_var = CoreUI.IFileNativeMethods.efl_file_key_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)));
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
        }

        /// <summary>The key which corresponds to the target data within a file.
        /// 
        /// Some file types can contain multiple data streams which are indexed by a key. Use this property for such cases (See for example <see cref="CoreUI.UI.Image"/> or <see cref="CoreUI.UI.Layout"/>).
        /// 
        /// You must not modify the strings on the returned pointers.</summary>
        /// <param name="key">The group that the data belongs to. See the class documentation for particular implementations of this interface to see how this property is used.</param>
        /// <since_tizen> 6 </since_tizen>
        public virtual void SetKey(System.String key) {
            CoreUI.IFileNativeMethods.efl_file_key_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), key);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            
        }

        /// <summary>The load state of the object.</summary>
        /// <returns><c>true</c> if the object is loaded, <c>false</c> otherwise.</returns>
        /// <since_tizen> 6 </since_tizen>
        public virtual bool GetLoaded() {
            var _ret_var = CoreUI.IFileNativeMethods.efl_file_loaded_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)));
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
        }

        /// <summary>Perform all necessary operations to open and load file data into the object using the <see cref="CoreUI.IFile.File"/> (or <see cref="CoreUI.IFile.Mmap"/>) and <see cref="CoreUI.IFile.Key"/> properties.
        /// 
        /// In the case where <see cref="CoreUI.IFile.SetFile"/> has been called on an object, this will internally open the file and call <see cref="CoreUI.IFile.SetMmap"/> on the object using the opened file handle.
        /// 
        /// Calling <see cref="CoreUI.IFile.Load"/> on an object which has already performed file operations based on the currently set properties will have no effect.</summary>
        /// <since_tizen> 6 </since_tizen>
        /// <returns>0 on success, error code otherwise</returns>
        public virtual CoreUI.DataTypes.Error Load() {
            var _ret_var = CoreUI.IFileNativeMethods.efl_file_load_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)));
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
        }

        /// <summary>Perform all necessary operations to unload file data from the object.
        /// 
        /// In the case where <see cref="CoreUI.IFile.SetMmap"/> has been externally called on an object, the file handle stored in the object will be preserved.
        /// 
        /// Calling <see cref="CoreUI.IFile.Unload"/> on an object which is not currently loaded will have no effect.</summary>
        /// <since_tizen> 6 </since_tizen>
        public virtual void Unload() {
            CoreUI.IFileNativeMethods.efl_file_unload_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)));
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            
        }

        /// <summary>Playback state of the media file.
        /// 
        /// This property sets the playback state of the object. Re-setting the current playback state has no effect.
        /// 
        /// If set to <c>false</c>, the object&apos;s <see cref="CoreUI.IPlayer.PlaybackProgress"/> property is, by default, reset to <c>0.0</c>. A class may alter this behavior, and it will be stated in the documentation for a class if such behavior changes should be expected.
        /// 
        /// Applying the <c>false</c> playing state also has the same effect as the player object reaching the end of its playback, which may invoke additional behavior based on a class&apos;s implementation.</summary>
        /// <returns><c>true</c> if playing, <c>false</c> otherwise.</returns>
        /// <since_tizen> 6 </since_tizen>
        public virtual bool GetPlaying() {
            var _ret_var = CoreUI.IPlayerNativeMethods.efl_player_playing_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)));
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
        }

        /// <summary>Playback state of the media file.
        /// 
        /// This property sets the playback state of the object. Re-setting the current playback state has no effect.
        /// 
        /// If set to <c>false</c>, the object&apos;s <see cref="CoreUI.IPlayer.PlaybackProgress"/> property is, by default, reset to <c>0.0</c>. A class may alter this behavior, and it will be stated in the documentation for a class if such behavior changes should be expected.
        /// 
        /// Applying the <c>false</c> playing state also has the same effect as the player object reaching the end of its playback, which may invoke additional behavior based on a class&apos;s implementation.</summary>
        /// <param name="playing"><c>true</c> if playing, <c>false</c> otherwise.</param>
        /// <returns>If <c>true</c>, the property change has succeeded.</returns>
        /// <since_tizen> 6 </since_tizen>
        public virtual bool SetPlaying(bool playing) {
            var _ret_var = CoreUI.IPlayerNativeMethods.efl_player_playing_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), playing);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
        }

        /// <summary>Pause state of the media file.
        /// 
        /// This property sets the pause state of the media.  Re-setting the current pause state has no effect.
        /// 
        /// If <see cref="CoreUI.IPlayer.Playing"/> is set to <c>true</c>, this property can be used to pause and resume playback of the media without changing its <see cref="CoreUI.IPlayer.PlaybackProgress"/> property. This property cannot be changed if <see cref="CoreUI.IPlayer.Playing"/> is <c>false</c>.</summary>
        /// <returns><c>true</c> if paused, <c>false</c> otherwise.</returns>
        /// <since_tizen> 6 </since_tizen>
        public virtual bool GetPaused() {
            var _ret_var = CoreUI.IPlayerNativeMethods.efl_player_paused_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)));
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
        }

        /// <summary>Pause state of the media file.
        /// 
        /// This property sets the pause state of the media.  Re-setting the current pause state has no effect.
        /// 
        /// If <see cref="CoreUI.IPlayer.Playing"/> is set to <c>true</c>, this property can be used to pause and resume playback of the media without changing its <see cref="CoreUI.IPlayer.PlaybackProgress"/> property. This property cannot be changed if <see cref="CoreUI.IPlayer.Playing"/> is <c>false</c>.</summary>
        /// <param name="paused"><c>true</c> if paused, <c>false</c> otherwise.</param>
        /// <returns>If <c>true</c>, the property change has succeeded.</returns>
        /// <since_tizen> 6 </since_tizen>
        public virtual bool SetPaused(bool paused) {
            var _ret_var = CoreUI.IPlayerNativeMethods.efl_player_paused_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), paused);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
        }

        /// <summary>Position in the media file.
        /// 
        /// This property sets the current position of the media file to <c>sec</c> seconds since the beginning of the media file. This only works on seekable streams. Setting the position doesn&apos;t change the <see cref="CoreUI.IPlayer.Playing"/> or <see cref="CoreUI.IPlayer.Paused"/> states of the media file.</summary>
        /// <returns>The position (in seconds).</returns>
        /// <since_tizen> 6 </since_tizen>
        public virtual double GetPlaybackPosition() {
            var _ret_var = CoreUI.IPlayerNativeMethods.efl_player_playback_position_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)));
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
        }

        /// <summary>Position in the media file.
        /// 
        /// This property sets the current position of the media file to <c>sec</c> seconds since the beginning of the media file. This only works on seekable streams. Setting the position doesn&apos;t change the <see cref="CoreUI.IPlayer.Playing"/> or <see cref="CoreUI.IPlayer.Paused"/> states of the media file.</summary>
        /// <param name="sec">The position (in seconds).</param>
        /// <since_tizen> 6 </since_tizen>
        public virtual void SetPlaybackPosition(double sec) {
            CoreUI.IPlayerNativeMethods.efl_player_playback_position_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), sec);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            
        }

        /// <summary>How much of the file has been played.
        /// 
        /// This function sets or gets the progress in playing the file, the value is in the [0, 1] range.</summary>
        /// <returns>The progress within the [0, 1] range.</returns>
        /// <since_tizen> 6 </since_tizen>
        public virtual double GetPlaybackProgress() {
            var _ret_var = CoreUI.IPlayerNativeMethods.efl_player_playback_progress_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)));
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
        }

        /// <summary>How much of the file has been played.
        /// 
        /// This function sets or gets the progress in playing the file, the value is in the [0, 1] range.</summary>
        /// <param name="progress">The progress within the [0, 1] range.</param>
        /// <since_tizen> 6 </since_tizen>
        public virtual void SetPlaybackProgress(double progress) {
            CoreUI.IPlayerNativeMethods.efl_player_playback_progress_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), progress);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            
        }

        /// <summary>Control the playback speed of the media file.
        /// 
        /// This function control the speed with which the media file will be played. 1.0 represents the normal speed, 2 double speed, 0.5 half speed and so on.</summary>
        /// <returns>The play speed in the [0, infinity) range.</returns>
        /// <since_tizen> 6 </since_tizen>
        public virtual double GetPlaybackSpeed() {
            var _ret_var = CoreUI.IPlayerNativeMethods.efl_player_playback_speed_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)));
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
        }

        /// <summary>Control the playback speed of the media file.
        /// 
        /// This function control the speed with which the media file will be played. 1.0 represents the normal speed, 2 double speed, 0.5 half speed and so on.</summary>
        /// <param name="speed">The play speed in the [0, infinity) range.</param>
        /// <since_tizen> 6 </since_tizen>
        public virtual void SetPlaybackSpeed(double speed) {
            CoreUI.IPlayerNativeMethods.efl_player_playback_speed_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), speed);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            
        }

        /// <summary>When <c>true</c>, playback will start as soon as the media is ready.
        /// 
        /// This means that the media file has been successfully loaded and the object is visible.
        /// 
        /// If the object becomes invisible later on the playback is paused, resuming when it is visible again.
        /// 
        /// Changing this property affects the next media being loaded, so set it before setting the media file.</summary>
        /// <returns>Auto play mode, Default is <c>false</c>.</returns>
        /// <since_tizen> 6 </since_tizen>
        public virtual bool GetAutoplay() {
            var _ret_var = CoreUI.IPlayerNativeMethods.efl_player_autoplay_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)));
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
        }

        /// <summary>When <c>true</c>, playback will start as soon as the media is ready.
        /// 
        /// This means that the media file has been successfully loaded and the object is visible.
        /// 
        /// If the object becomes invisible later on the playback is paused, resuming when it is visible again.
        /// 
        /// Changing this property affects the next media being loaded, so set it before setting the media file.</summary>
        /// <param name="autoplay">Auto play mode, Default is <c>false</c>.</param>
        /// <since_tizen> 6 </since_tizen>
        public virtual void SetAutoplay(bool autoplay) {
            CoreUI.IPlayerNativeMethods.efl_player_autoplay_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), autoplay);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            
        }

        /// <summary>Enable playback looping.
        /// 
        /// When <c>true</c>, playback continues from the beginning when it reaches the last frame. Otherwise, playback stops. This works both when playing forward and backward.</summary>
        /// <returns>Loop mode, Default is <c>false</c>.</returns>
        /// <since_tizen> 6 </since_tizen>
        public virtual bool GetPlaybackLoop() {
            var _ret_var = CoreUI.IPlayerNativeMethods.efl_player_playback_loop_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)));
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
        }

        /// <summary>Enable playback looping.
        /// 
        /// When <c>true</c>, playback continues from the beginning when it reaches the last frame. Otherwise, playback stops. This works both when playing forward and backward.</summary>
        /// <param name="looping">Loop mode, Default is <c>false</c>.</param>
        /// <since_tizen> 6 </since_tizen>
        public virtual void SetPlaybackLoop(bool looping) {
            CoreUI.IPlayerNativeMethods.efl_player_playback_loop_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), looping);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            
        }

        /// <summary>This property determines how contents will be aligned within a container if there is unused space.
        /// 
        /// It is different than the <see cref="CoreUI.Gfx.IHint.HintAlign"/> property in that it affects the position of all the contents within the container instead of the container itself. For example, if a box widget has extra space on the horizontal axis, this property can be used to align the box&apos;s contents to the left or the right side.
        /// 
        /// See also <see cref="CoreUI.Gfx.IHint.HintAlign"/>.</summary>
        /// <param name="align_horiz">Controls the horizontal alignment.<br/>The default value is <c>0.500000</c>.</param>
        /// <param name="align_vert">Controls the vertical alignment.<br/>The default value is <c>0.500000</c>.</param>
        /// <since_tizen> 6 </since_tizen>
        public virtual void GetContentAlign(out CoreUI.Gfx.Align align_horiz, out CoreUI.Gfx.Align align_vert) {
            CoreUI.Gfx.IArrangementNativeMethods.efl_gfx_arrangement_content_align_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), out align_horiz, out align_vert);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            
        }

        /// <summary>This property determines how contents will be aligned within a container if there is unused space.
        /// 
        /// It is different than the <see cref="CoreUI.Gfx.IHint.HintAlign"/> property in that it affects the position of all the contents within the container instead of the container itself. For example, if a box widget has extra space on the horizontal axis, this property can be used to align the box&apos;s contents to the left or the right side.
        /// 
        /// See also <see cref="CoreUI.Gfx.IHint.HintAlign"/>.</summary>
        /// <param name="align_horiz">Controls the horizontal alignment.<br/>The default value is <c>0.500000</c>.</param>
        /// <param name="align_vert">Controls the vertical alignment.<br/>The default value is <c>0.500000</c>.</param>
        /// <since_tizen> 6 </since_tizen>
        public virtual void SetContentAlign(CoreUI.Gfx.Align align_horiz, CoreUI.Gfx.Align align_vert) {
            CoreUI.Gfx.IArrangementNativeMethods.efl_gfx_arrangement_content_align_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), align_horiz, align_vert);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            
        }

        /// <summary>This property determines the space between a container&apos;s content items.
        /// 
        /// It is different than the <see cref="CoreUI.Gfx.IHint.HintMargin"/> property in that it is applied to each content item within the container instead of a single item. The calculation for these two properties is cumulative.
        /// 
        /// See also <see cref="CoreUI.Gfx.IHint.HintMargin"/>.</summary>
        /// <param name="pad_horiz">Horizontal padding.<br/>The default value is <c>0U</c>.</param>
        /// <param name="pad_vert">Vertical padding.<br/>The default value is <c>0U</c>.</param>
        /// <since_tizen> 6 </since_tizen>
        public virtual void GetContentPadding(out uint pad_horiz, out uint pad_vert) {
            CoreUI.Gfx.IArrangementNativeMethods.efl_gfx_arrangement_content_padding_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), out pad_horiz, out pad_vert);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            
        }

        /// <summary>This property determines the space between a container&apos;s content items.
        /// 
        /// It is different than the <see cref="CoreUI.Gfx.IHint.HintMargin"/> property in that it is applied to each content item within the container instead of a single item. The calculation for these two properties is cumulative.
        /// 
        /// See also <see cref="CoreUI.Gfx.IHint.HintMargin"/>.</summary>
        /// <param name="pad_horiz">Horizontal padding.<br/>The default value is <c>0U</c>.</param>
        /// <param name="pad_vert">Vertical padding.<br/>The default value is <c>0U</c>.</param>
        /// <since_tizen> 6 </since_tizen>
        public virtual void SetContentPadding(uint pad_horiz, uint pad_vert) {
            CoreUI.Gfx.IArrangementNativeMethods.efl_gfx_arrangement_content_padding_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), pad_horiz, pad_vert);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            
        }

        /// <summary>Whether to use high-quality image scaling algorithm for this image.
        /// 
        /// When enabled, a higher quality image scaling algorithm is used when scaling images to sizes other than the source image&apos;s original one. This gives better results but is more computationally expensive.</summary>
        /// <returns>Whether to use smooth scale or not.</returns>
        /// <since_tizen> 6 </since_tizen>
        public virtual bool GetSmoothScale() {
            var _ret_var = CoreUI.Gfx.IImageNativeMethods.efl_gfx_image_smooth_scale_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)));
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
        }

        /// <summary>Whether to use high-quality image scaling algorithm for this image.
        /// 
        /// When enabled, a higher quality image scaling algorithm is used when scaling images to sizes other than the source image&apos;s original one. This gives better results but is more computationally expensive.</summary>
        /// <param name="smooth_scale">Whether to use smooth scale or not.<br/>The default value is <c>true</c>.</param>
        /// <since_tizen> 6 </since_tizen>
        public virtual void SetSmoothScale(bool smooth_scale) {
            CoreUI.Gfx.IImageNativeMethods.efl_gfx_image_smooth_scale_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), smooth_scale);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            
        }

        /// <summary>Determine how the image is scaled at render time.
        /// 
        /// This allows more granular controls for how an image object should display its internal buffer. The underlying image data will not be modified.</summary>
        /// <returns>Image scale type to use.</returns>
        /// <since_tizen> 6 </since_tizen>
        public virtual CoreUI.Gfx.ImageScaleMethod GetScaleMethod() {
            var _ret_var = CoreUI.Gfx.IImageNativeMethods.efl_gfx_image_scale_method_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)));
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
        }

        /// <summary>Determine how the image is scaled at render time.
        /// 
        /// This allows more granular controls for how an image object should display its internal buffer. The underlying image data will not be modified.</summary>
        /// <param name="scale_method">Image scale type to use.<br/>The default value is <see cref="CoreUI.Gfx.ImageScaleMethod.None"/>.</param>
        /// <since_tizen> 6 </since_tizen>
        public virtual void SetScaleMethod(CoreUI.Gfx.ImageScaleMethod scale_method) {
            CoreUI.Gfx.IImageNativeMethods.efl_gfx_image_scale_method_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), scale_method);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            
        }

        /// <summary>If <c>true</c>, the image may be scaled to a larger size. If <c>false</c>, the image will never be resized larger than its native size.</summary>
        /// <returns>Whether to allow image upscaling.</returns>
        /// <since_tizen> 6 </since_tizen>
        public virtual bool GetCanUpscale() {
            var _ret_var = CoreUI.Gfx.IImageNativeMethods.efl_gfx_image_can_upscale_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)));
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
        }

        /// <summary>If <c>true</c>, the image may be scaled to a larger size. If <c>false</c>, the image will never be resized larger than its native size.</summary>
        /// <param name="upscale">Whether to allow image upscaling.<br/>The default value is <c>true</c>.</param>
        /// <since_tizen> 6 </since_tizen>
        public virtual void SetCanUpscale(bool upscale) {
            CoreUI.Gfx.IImageNativeMethods.efl_gfx_image_can_upscale_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), upscale);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            
        }

        /// <summary>If <c>true</c>, the image may be scaled to a smaller size. If <c>false</c>, the image will never be resized smaller than its native size.</summary>
        /// <returns>Whether to allow image downscaling.</returns>
        /// <since_tizen> 6 </since_tizen>
        public virtual bool GetCanDownscale() {
            var _ret_var = CoreUI.Gfx.IImageNativeMethods.efl_gfx_image_can_downscale_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)));
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
        }

        /// <summary>If <c>true</c>, the image may be scaled to a smaller size. If <c>false</c>, the image will never be resized smaller than its native size.</summary>
        /// <param name="downscale">Whether to allow image downscaling.<br/>The default value is <c>true</c>.</param>
        /// <since_tizen> 6 </since_tizen>
        public virtual void SetCanDownscale(bool downscale) {
            CoreUI.Gfx.IImageNativeMethods.efl_gfx_image_can_downscale_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), downscale);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            
        }

        /// <summary>The native width/height ratio of the image.
        /// 
        /// The ratio will be 1.0 if it cannot be calculated (e.g. height = 0).</summary>
        /// <returns>The image&apos;s ratio.</returns>
        /// <since_tizen> 6 </since_tizen>
        public virtual double GetRatio() {
            var _ret_var = CoreUI.Gfx.IImageNativeMethods.efl_gfx_image_ratio_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)));
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
        }

        /// <summary>Return the relative area enclosed inside the image where content is expected.
        /// 
        /// We do expect content to be inside the limit defined by the border or inside the stretch region. If a stretch region is provided, the content region will encompass the non-stretchable area that are surrounded by stretchable area. If no border and no stretch region is set, they are assumed to be zero and the full object geometry is where content can be layout on top. The area size change with the object size.
        /// 
        /// The geometry of the area is expressed relative to the geometry of the object.</summary>
        /// <returns>A rectangle inside the object boundary where content is expected. The default value is the image object&apos;s geometry with the <see cref="CoreUI.Gfx.IImage.BorderInsets"/> values subtracted.</returns>
        /// <since_tizen> 6 </since_tizen>
        public virtual CoreUI.DataTypes.Rect GetContentRegion() {
            var _ret_var = CoreUI.Gfx.IImageNativeMethods.efl_gfx_image_content_region_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)));
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
        }

        /// <summary>Dimensions of this image&apos;s border, a region that does not scale with the center area.
        /// 
        /// When EFL renders an image, its source may be scaled to fit the size of the object. This function sets an area from the borders of the image inwards which is not to be scaled. This function is useful for making frames and for widget theming, where, for example, buttons may be of varying sizes, but their border size must remain constant.
        /// 
        /// The units used for <c>l</c>, <c>r</c>, <c>t</c> and <c>b</c> are canvas units (pixels).
        /// 
        /// <b>NOTE: </b>The border region itself may be scaled by the <see cref="CoreUI.Gfx.IImage.SetBorderInsetsScale"/> function.
        /// 
        /// <b>NOTE: </b>By default, image objects have no borders set, i.e. <c>l</c>, <c>r</c>, <c>t</c> and <c>b</c> start as 0.
        /// 
        /// <b>NOTE: </b>Similar to the concepts of 9-patch images or cap insets.</summary>
        /// <param name="l">The border&apos;s left width.<br/>The default value is <c>0</c>.</param>
        /// <param name="r">The border&apos;s right width.<br/>The default value is <c>0</c>.</param>
        /// <param name="t">The border&apos;s top height.<br/>The default value is <c>0</c>.</param>
        /// <param name="b">The border&apos;s bottom height.<br/>The default value is <c>0</c>.</param>
        /// <since_tizen> 6 </since_tizen>
        public virtual void GetBorderInsets(out int l, out int r, out int t, out int b) {
            CoreUI.Gfx.IImageNativeMethods.efl_gfx_image_border_insets_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), out l, out r, out t, out b);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            
        }

        /// <summary>Dimensions of this image&apos;s border, a region that does not scale with the center area.
        /// 
        /// When EFL renders an image, its source may be scaled to fit the size of the object. This function sets an area from the borders of the image inwards which is not to be scaled. This function is useful for making frames and for widget theming, where, for example, buttons may be of varying sizes, but their border size must remain constant.
        /// 
        /// The units used for <c>l</c>, <c>r</c>, <c>t</c> and <c>b</c> are canvas units (pixels).
        /// 
        /// <b>NOTE: </b>The border region itself may be scaled by the <see cref="CoreUI.Gfx.IImage.SetBorderInsetsScale"/> function.
        /// 
        /// <b>NOTE: </b>By default, image objects have no borders set, i.e. <c>l</c>, <c>r</c>, <c>t</c> and <c>b</c> start as 0.
        /// 
        /// <b>NOTE: </b>Similar to the concepts of 9-patch images or cap insets.</summary>
        /// <param name="l">The border&apos;s left width.<br/>The default value is <c>0</c>.</param>
        /// <param name="r">The border&apos;s right width.<br/>The default value is <c>0</c>.</param>
        /// <param name="t">The border&apos;s top height.<br/>The default value is <c>0</c>.</param>
        /// <param name="b">The border&apos;s bottom height.<br/>The default value is <c>0</c>.</param>
        /// <since_tizen> 6 </since_tizen>
        public virtual void SetBorderInsets(int l, int r, int t, int b) {
            CoreUI.Gfx.IImageNativeMethods.efl_gfx_image_border_insets_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), l, r, t, b);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            
        }

        /// <summary>Scaling factor applied to the image borders.
        /// 
        /// This value multiplies the size of the <see cref="CoreUI.Gfx.IImage.BorderInsets"/> when scaling an object.</summary>
        /// <returns>The scale factor.</returns>
        /// <since_tizen> 6 </since_tizen>
        public virtual double GetBorderInsetsScale() {
            var _ret_var = CoreUI.Gfx.IImageNativeMethods.efl_gfx_image_border_insets_scale_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)));
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
        }

        /// <summary>Scaling factor applied to the image borders.
        /// 
        /// This value multiplies the size of the <see cref="CoreUI.Gfx.IImage.BorderInsets"/> when scaling an object.</summary>
        /// <param name="scale">The scale factor.<br/>The default value is <c>1.000000</c>.</param>
        /// <since_tizen> 6 </since_tizen>
        public virtual void SetBorderInsetsScale(double scale) {
            CoreUI.Gfx.IImageNativeMethods.efl_gfx_image_border_insets_scale_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), scale);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            
        }

        /// <summary>Specifies how the center part of the object (not the borders) should be drawn when EFL is rendering it.
        /// 
        /// This function sets how the center part of the image object&apos;s source image is to be drawn, which must be one of the values in <see cref="CoreUI.Gfx.CenterFillMode"/>. By center we mean the complementary part of that defined by <see cref="CoreUI.Gfx.IImage.SetBorderInsets"/>. This is very useful for making frames and decorations. You would most probably also be using a filled image (as in <span class="text-muted">CoreUI.Gfx.IFill.FillAuto (object still in beta stage)</span>) to use as a frame.</summary>
        /// <returns>Fill mode of the center region. The default behavior is to render and scale the center area, respecting its transparency.</returns>
        /// <since_tizen> 6 </since_tizen>
        public virtual CoreUI.Gfx.CenterFillMode GetCenterFillMode() {
            var _ret_var = CoreUI.Gfx.IImageNativeMethods.efl_gfx_image_center_fill_mode_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)));
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
        }

        /// <summary>Specifies how the center part of the object (not the borders) should be drawn when EFL is rendering it.
        /// 
        /// This function sets how the center part of the image object&apos;s source image is to be drawn, which must be one of the values in <see cref="CoreUI.Gfx.CenterFillMode"/>. By center we mean the complementary part of that defined by <see cref="CoreUI.Gfx.IImage.SetBorderInsets"/>. This is very useful for making frames and decorations. You would most probably also be using a filled image (as in <span class="text-muted">CoreUI.Gfx.IFill.FillAuto (object still in beta stage)</span>) to use as a frame.</summary>
        /// <param name="fill">Fill mode of the center region. The default behavior is to render and scale the center area, respecting its transparency.<br/>The default value is <see cref="CoreUI.Gfx.CenterFillMode.Default"/>.</param>
        /// <since_tizen> 6 </since_tizen>
        public virtual void SetCenterFillMode(CoreUI.Gfx.CenterFillMode fill) {
            CoreUI.Gfx.IImageNativeMethods.efl_gfx_image_center_fill_mode_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), fill);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            
        }

        /// <summary>This property defines the stretchable pixels region of an image.
        /// 
        /// When the regions are set by the user, the method will walk the iterators once and then destroy them. When the regions are retrieved by the user, it is his responsibility to destroy the iterators.. It will remember the information for the lifetime of the object. It will ignore all value of <see cref="CoreUI.Gfx.IImage.BorderInsets"/>, <see cref="CoreUI.Gfx.IImage.BorderInsetsScale"/> and <see cref="CoreUI.Gfx.IImage.CenterFillMode"/> . To reset the object you can just pass <c>null</c> to both horizontal and vertical at the same time.</summary>
        /// <param name="horizontal">Representation of areas that are stretchable in the image horizontal space.<br/>The default value is <c>null</c>.</param>
        /// <param name="vertical">Representation of areas that are stretchable in the image vertical space.<br/>The default value is <c>null</c>.</param>
        /// <since_tizen> 6 </since_tizen>
        public virtual void GetStretchRegion(out IEnumerable<CoreUI.Gfx.ImageStretchRegion> horizontal, out IEnumerable<CoreUI.Gfx.ImageStretchRegion> vertical) {
            System.IntPtr _out_horizontal = System.IntPtr.Zero;
System.IntPtr _out_vertical = System.IntPtr.Zero;
CoreUI.Gfx.IImageNativeMethods.efl_gfx_image_stretch_region_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), out _out_horizontal, out _out_vertical);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
horizontal = CoreUI.Wrapper.Globals.IteratorToIEnumerable<CoreUI.Gfx.ImageStretchRegion>(_out_horizontal);
vertical = CoreUI.Wrapper.Globals.IteratorToIEnumerable<CoreUI.Gfx.ImageStretchRegion>(_out_vertical);
            
        }

        /// <summary>This property defines the stretchable pixels region of an image.
        /// 
        /// When the regions are set by the user, the method will walk the iterators once and then destroy them. When the regions are retrieved by the user, it is his responsibility to destroy the iterators.. It will remember the information for the lifetime of the object. It will ignore all value of <see cref="CoreUI.Gfx.IImage.BorderInsets"/>, <see cref="CoreUI.Gfx.IImage.BorderInsetsScale"/> and <see cref="CoreUI.Gfx.IImage.CenterFillMode"/> . To reset the object you can just pass <c>null</c> to both horizontal and vertical at the same time.</summary>
        /// <param name="horizontal">Representation of areas that are stretchable in the image horizontal space.<br/>The default value is <c>null</c>.</param>
        /// <param name="vertical">Representation of areas that are stretchable in the image vertical space.<br/>The default value is <c>null</c>.</param>
        /// <returns>Return an error code if the provided values are incorrect.</returns>
        /// <since_tizen> 6 </since_tizen>
        public virtual CoreUI.DataTypes.Error SetStretchRegion(IEnumerable<CoreUI.Gfx.ImageStretchRegion> horizontal, IEnumerable<CoreUI.Gfx.ImageStretchRegion> vertical) {
            var _in_horizontal = CoreUI.Wrapper.Globals.IEnumerableToIterator(horizontal, true);
var _in_vertical = CoreUI.Wrapper.Globals.IEnumerableToIterator(vertical, true);
var _ret_var = CoreUI.Gfx.IImageNativeMethods.efl_gfx_image_stretch_region_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), _in_horizontal, _in_vertical);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
        }

        /// <summary>This represents the size of the original image in pixels.
        /// 
        /// This may be different from the actual geometry on screen or even the size of the loaded pixel buffer. This is the size of the image as stored in the original file.
        /// 
        /// This is a read-only property and may return 0x0.</summary>
        /// <returns>The size in pixels. The default value is the size of the image&apos;s internal buffer.</returns>
        /// <since_tizen> 6 </since_tizen>
        public virtual CoreUI.DataTypes.Size2D GetImageSize() {
            var _ret_var = CoreUI.Gfx.IImageNativeMethods.efl_gfx_image_size_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)));
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
        }

        /// <summary>Content hint setting for the image. These hints might be used by EFL to enable optimizations.
        /// 
        /// For example, if you&apos;re on the GL engine and your driver implementation supports it, setting this hint to <see cref="CoreUI.Gfx.ImageContentHint.Dynamic"/> will make it need zero copies at texture upload time, which is an &quot;expensive&quot; operation.</summary>
        /// <returns>Dynamic or static content hint.</returns>
        /// <since_tizen> 6 </since_tizen>
        public virtual CoreUI.Gfx.ImageContentHint GetContentHint() {
            var _ret_var = CoreUI.Gfx.IImageNativeMethods.efl_gfx_image_content_hint_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)));
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
        }

        /// <summary>Content hint setting for the image. These hints might be used by EFL to enable optimizations.
        /// 
        /// For example, if you&apos;re on the GL engine and your driver implementation supports it, setting this hint to <see cref="CoreUI.Gfx.ImageContentHint.Dynamic"/> will make it need zero copies at texture upload time, which is an &quot;expensive&quot; operation.</summary>
        /// <param name="hint">Dynamic or static content hint.<br/>The default value is <see cref="CoreUI.Gfx.ImageContentHint.None"/>.</param>
        /// <since_tizen> 6 </since_tizen>
        public virtual void SetContentHint(CoreUI.Gfx.ImageContentHint hint) {
            CoreUI.Gfx.IImageNativeMethods.efl_gfx_image_content_hint_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), hint);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            
        }

        /// <summary>The scale hint of a given image of the canvas.
        /// 
        /// The scale hint affects how EFL is to cache scaled versions of its original source image.</summary>
        /// <returns>Scalable or static size hint.</returns>
        /// <since_tizen> 6 </since_tizen>
        public virtual CoreUI.Gfx.ImageScaleHint GetScaleHint() {
            var _ret_var = CoreUI.Gfx.IImageNativeMethods.efl_gfx_image_scale_hint_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)));
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
        }

        /// <summary>The scale hint of a given image of the canvas.
        /// 
        /// The scale hint affects how EFL is to cache scaled versions of its original source image.</summary>
        /// <param name="hint">Scalable or static size hint.<br/>The default value is <see cref="CoreUI.Gfx.ImageScaleHint.None"/>.</param>
        /// <since_tizen> 6 </since_tizen>
        public virtual void SetScaleHint(CoreUI.Gfx.ImageScaleHint hint) {
            CoreUI.Gfx.IImageNativeMethods.efl_gfx_image_scale_hint_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), hint);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            
        }

        /// <summary>The (last) file loading error for a given object. This value is set to a nonzero value if an error has occurred.</summary>
        /// <returns>The load error code. A value of $0 indicates no error.</returns>
        /// <since_tizen> 6 </since_tizen>
        public virtual CoreUI.DataTypes.Error GetImageLoadError() {
            var _ret_var = CoreUI.Gfx.IImageNativeMethods.efl_gfx_image_load_error_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)));
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
        }

        /// <summary>The load size of an image.
        /// 
        /// The image will be loaded into memory as if it was the specified size instead of its original size. This can save a lot of memory and is important for scalable types like SVG.
        /// 
        /// EFL will try to load an image of the requested size but does not guarantee an exact match between the request and the loaded image dimensions.
        /// 
        /// By default, the load size is not specified, so it is <c>0x0</c>.</summary>
        /// <returns>The image load size.</returns>
        /// <since_tizen> 6 </since_tizen>
        public virtual CoreUI.DataTypes.Size2D GetLoadSize() {
            var _ret_var = CoreUI.Gfx.IImageLoadControllerNativeMethods.efl_gfx_image_load_controller_load_size_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)));
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
        }

        /// <summary>The load size of an image.
        /// 
        /// The image will be loaded into memory as if it was the specified size instead of its original size. This can save a lot of memory and is important for scalable types like SVG.
        /// 
        /// EFL will try to load an image of the requested size but does not guarantee an exact match between the request and the loaded image dimensions.
        /// 
        /// By default, the load size is not specified, so it is <c>0x0</c>.</summary>
        /// <param name="size">The image load size.</param>
        /// <since_tizen> 6 </since_tizen>
        public virtual void SetLoadSize(CoreUI.DataTypes.Size2D size) {
            CoreUI.DataTypes.Size2D _in_size = size;
CoreUI.Gfx.IImageLoadControllerNativeMethods.efl_gfx_image_load_controller_load_size_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), _in_size);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            
        }

        /// <summary>The DPI resolution of an image object&apos;s source image.
        /// 
        /// Most useful for the SVG image loader.</summary>
        /// <returns>The DPI resolution.</returns>
        /// <since_tizen> 6 </since_tizen>
        public virtual double GetLoadDpi() {
            var _ret_var = CoreUI.Gfx.IImageLoadControllerNativeMethods.efl_gfx_image_load_controller_load_dpi_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)));
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
        }

        /// <summary>The DPI resolution of an image object&apos;s source image.
        /// 
        /// Most useful for the SVG image loader.</summary>
        /// <param name="dpi">The DPI resolution.</param>
        /// <since_tizen> 6 </since_tizen>
        public virtual void SetLoadDpi(double dpi) {
            CoreUI.Gfx.IImageLoadControllerNativeMethods.efl_gfx_image_load_controller_load_dpi_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), dpi);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            
        }

        /// <summary>Indicates whether the <see cref="CoreUI.Gfx.IImageLoadController.LoadRegion"/> property is supported for the current file.</summary>
        /// <returns><c>true</c> if region load of the image is supported, <c>false</c> otherwise.</returns>
        /// <since_tizen> 6 </since_tizen>
        public virtual bool GetLoadRegionSupport() {
            var _ret_var = CoreUI.Gfx.IImageLoadControllerNativeMethods.efl_gfx_image_load_controller_load_region_support_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)));
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
        }

        /// <summary>Inform a given image object to load a selective region of its source image.
        /// 
        /// This property is useful when one is not showing all of an image&apos;s area on its image object.
        /// 
        /// <b>NOTE: </b>The image loader for the image format in question has to support selective region loading in order for this function to work (see <see cref="CoreUI.Gfx.IImageLoadController.GetLoadRegionSupport"/>).</summary>
        /// <returns>A region of the image.</returns>
        /// <since_tizen> 6 </since_tizen>
        public virtual CoreUI.DataTypes.Rect GetLoadRegion() {
            var _ret_var = CoreUI.Gfx.IImageLoadControllerNativeMethods.efl_gfx_image_load_controller_load_region_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)));
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
        }

        /// <summary>Inform a given image object to load a selective region of its source image.
        /// 
        /// This property is useful when one is not showing all of an image&apos;s area on its image object.
        /// 
        /// <b>NOTE: </b>The image loader for the image format in question has to support selective region loading in order for this function to work (see <see cref="CoreUI.Gfx.IImageLoadController.GetLoadRegionSupport"/>).</summary>
        /// <param name="region">A region of the image.</param>
        /// <since_tizen> 6 </since_tizen>
        public virtual void SetLoadRegion(CoreUI.DataTypes.Rect region) {
            CoreUI.DataTypes.Rect _in_region = region;
CoreUI.Gfx.IImageLoadControllerNativeMethods.efl_gfx_image_load_controller_load_region_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), _in_region);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            
        }

        /// <summary>Defines whether the orientation information in the image file should be honored.
        /// 
        /// The orientation can for instance be set in the EXIF tags of a JPEG image. If this flag is <c>false</c>, then the orientation will be ignored at load time, otherwise the image will be loaded with the proper orientation.</summary>
        /// <returns><c>true</c> means that it should honor the orientation information.</returns>
        /// <since_tizen> 6 </since_tizen>
        public virtual bool GetLoadOrientation() {
            var _ret_var = CoreUI.Gfx.IImageLoadControllerNativeMethods.efl_gfx_image_load_controller_load_orientation_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)));
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
        }

        /// <summary>Defines whether the orientation information in the image file should be honored.
        /// 
        /// The orientation can for instance be set in the EXIF tags of a JPEG image. If this flag is <c>false</c>, then the orientation will be ignored at load time, otherwise the image will be loaded with the proper orientation.</summary>
        /// <param name="enable"><c>true</c> means that it should honor the orientation information.</param>
        /// <since_tizen> 6 </since_tizen>
        public virtual void SetLoadOrientation(bool enable) {
            CoreUI.Gfx.IImageLoadControllerNativeMethods.efl_gfx_image_load_controller_load_orientation_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), enable);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            
        }

        /// <summary>The scale down factor is a divider on the original image size.
        /// 
        /// Setting the scale down factor can reduce load time and memory usage at the cost of having a scaled down image in memory.
        /// 
        /// This function sets the scale down factor of a given canvas image. Most useful for the SVG image loader but also applies to JPEG, PNG and BMP.
        /// 
        /// Powers of two (2, 4, 8, ...) are best supported (especially with JPEG).</summary>
        /// <returns>The scale down dividing factor.</returns>
        /// <since_tizen> 6 </since_tizen>
        public virtual int GetLoadScaleDown() {
            var _ret_var = CoreUI.Gfx.IImageLoadControllerNativeMethods.efl_gfx_image_load_controller_load_scale_down_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)));
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
        }

        /// <summary>The scale down factor is a divider on the original image size.
        /// 
        /// Setting the scale down factor can reduce load time and memory usage at the cost of having a scaled down image in memory.
        /// 
        /// This function sets the scale down factor of a given canvas image. Most useful for the SVG image loader but also applies to JPEG, PNG and BMP.
        /// 
        /// Powers of two (2, 4, 8, ...) are best supported (especially with JPEG).</summary>
        /// <param name="div">The scale down dividing factor.</param>
        /// <since_tizen> 6 </since_tizen>
        public virtual void SetLoadScaleDown(int div) {
            CoreUI.Gfx.IImageLoadControllerNativeMethods.efl_gfx_image_load_controller_load_scale_down_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), div);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            
        }

        /// <summary>Initial load should skip header check and leave it all to data load.
        /// 
        /// If this is <c>true</c>, then future loads of images will defer header loading to a preload stage and/or data load later on rather than at the start when the load begins (e.g. when file is set).</summary>
        /// <returns><c>true</c> if header is to be skipped.</returns>
        /// <since_tizen> 6 </since_tizen>
        public virtual bool GetLoadSkipHeader() {
            var _ret_var = CoreUI.Gfx.IImageLoadControllerNativeMethods.efl_gfx_image_load_controller_load_skip_header_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)));
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
        }

        /// <summary>Initial load should skip header check and leave it all to data load.
        /// 
        /// If this is <c>true</c>, then future loads of images will defer header loading to a preload stage and/or data load later on rather than at the start when the load begins (e.g. when file is set).</summary>
        /// <param name="skip"><c>true</c> if header is to be skipped.</param>
        /// <since_tizen> 6 </since_tizen>
        public virtual void SetLoadSkipHeader(bool skip) {
            CoreUI.Gfx.IImageLoadControllerNativeMethods.efl_gfx_image_load_controller_load_skip_header_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), skip);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            
        }

        /// <summary>Begin preloading an image object&apos;s image data in the background.
        /// 
        /// Once the background task is complete the event @[.load,done] will be emitted if loading succeeded, @[.load,error] otherwise.</summary>
        /// <since_tizen> 6 </since_tizen>
        public virtual void LoadAsyncStart() {
            CoreUI.Gfx.IImageLoadControllerNativeMethods.efl_gfx_image_load_controller_load_async_start_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)));
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            
        }

        /// <summary>Cancel preloading an image object&apos;s image data in the background.
        /// 
        /// The object should be left in a state where it has no image data. If cancel is called too late, the image will be kept in memory.</summary>
        /// <since_tizen> 6 </since_tizen>
        public virtual void CancelLoadAsync() {
            CoreUI.Gfx.IImageLoadControllerNativeMethods.efl_gfx_image_load_controller_load_async_cancel_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)));
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            
        }

        /// <summary>Control the orientation (rotation and flipping) of a visual object.
        /// 
        /// This can be used to set the rotation on an image or a window, for instance.</summary>
        /// <returns>The final orientation of the object.</returns>
        /// <since_tizen> 6 </since_tizen>
        public virtual CoreUI.Gfx.ImageOrientation GetImageOrientation() {
            var _ret_var = CoreUI.Gfx.IImageOrientableNativeMethods.efl_gfx_image_orientation_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)));
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
        }

        /// <summary>Control the orientation (rotation and flipping) of a visual object.
        /// 
        /// This can be used to set the rotation on an image or a window, for instance.</summary>
        /// <param name="dir">The final orientation of the object.<br/>The default value is <see cref="CoreUI.Gfx.ImageOrientation.None"/>.</param>
        /// <since_tizen> 6 </since_tizen>
        public virtual void SetImageOrientation(CoreUI.Gfx.ImageOrientation dir) {
            CoreUI.Gfx.IImageOrientableNativeMethods.efl_gfx_image_orientation_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), dir);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            
        }

        /// <summary>This returns true if the given object is currently in event emission</summary>
        /// <since_tizen> 6 </since_tizen>
        public virtual bool GetInteraction() {
            var _ret_var = CoreUI.Input.IClickableNativeMethods.efl_input_clickable_interaction_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)));
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
        }

        /// <summary>Change internal states that a button got pressed.
        /// 
        /// When the button is already pressed, this is silently ignored.</summary>
        /// <since_tizen> 6 </since_tizen>
        /// <param name="button">The number of the button. FIXME ensure to have the right interval of possible input</param>
        protected virtual void Press(uint button) {
            CoreUI.Input.IClickableNativeMethods.efl_input_clickable_press_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), button);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            
        }

        /// <summary>Change internal states that a button got unpressed.
        /// 
        /// When the button is not pressed, this is silently ignored.</summary>
        /// <since_tizen> 6 </since_tizen>
        /// <param name="button">The number of the button. FIXME ensure to have the right interval of possible input</param>
        protected virtual void Unpress(uint button) {
            CoreUI.Input.IClickableNativeMethods.efl_input_clickable_unpress_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), button);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            
        }

        /// <summary>This aborts the internal state after a press call.
        /// 
        /// This will stop the timer for longpress and set the state of the clickable mixin back into the unpressed state.</summary>
        /// <since_tizen> 6 </since_tizen>
        protected virtual void ResetButtonState(uint button) {
            CoreUI.Input.IClickableNativeMethods.efl_input_clickable_button_state_reset_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), button);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            
        }

        /// <summary>This aborts ongoing longpress event.
        /// 
        /// That is, this will stop the timer for longpress.</summary>
        /// <since_tizen> 6 </since_tizen>
        protected virtual void LongpressAbort(uint button) {
            CoreUI.Input.IClickableNativeMethods.efl_input_clickable_longpress_abort_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), button);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            
        }

        /// <summary>Whether this object updates its size hints automatically.
        /// 
        /// By default edje doesn&apos;t set size hints on itself. If this property is set to <c>true</c>, size hints will be updated after recalculation. Be careful, as recalculation may happen often, enabling this property may have a considerable performance impact as other widgets will be notified of the size hints changes.
        /// 
        /// A layout recalculation can be triggered by <see cref="CoreUI.Layout.ICalc.CalcSizeMin"/>, <see cref="CoreUI.Layout.ICalc.CalcSizeMin"/>, <see cref="CoreUI.Layout.ICalc.CalcPartsExtends"/> or even any other internal event.</summary>
        /// <returns>Whether or not update the size hints.</returns>
        /// <since_tizen> 6 </since_tizen>
        public virtual bool GetCalcAutoUpdateHints() {
            var _ret_var = CoreUI.Layout.ICalcNativeMethods.efl_layout_calc_auto_update_hints_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)));
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
        }

        /// <summary>Whether this object updates its size hints automatically.
        /// 
        /// By default edje doesn&apos;t set size hints on itself. If this property is set to <c>true</c>, size hints will be updated after recalculation. Be careful, as recalculation may happen often, enabling this property may have a considerable performance impact as other widgets will be notified of the size hints changes.
        /// 
        /// A layout recalculation can be triggered by <see cref="CoreUI.Layout.ICalc.CalcSizeMin"/>, <see cref="CoreUI.Layout.ICalc.CalcSizeMin"/>, <see cref="CoreUI.Layout.ICalc.CalcPartsExtends"/> or even any other internal event.</summary>
        /// <param name="update">Whether or not update the size hints.<br/>The default value is <c>false</c>.</param>
        /// <since_tizen> 6 </since_tizen>
        public virtual void SetCalcAutoUpdateHints(bool update) {
            CoreUI.Layout.ICalcNativeMethods.efl_layout_calc_auto_update_hints_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), update);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            
        }

        /// <summary>Calculates the minimum required size for a given layout object.
        /// 
        /// This call will trigger an internal recalculation of all parts of the object, in order to return its minimum required dimensions for width and height. The user might choose to impose those minimum sizes, making the resulting calculation to get to values greater or equal than <c>restricted</c> in both directions.
        /// 
        /// <b>NOTE: </b>At the end of this call, the object won&apos;t be automatically resized to the new dimensions, but just return the calculated sizes. The caller is the one up to change its geometry or not.
        /// 
        /// <b>WARNING: </b>Be advised that invisible parts in the object will be taken into account in this calculation.</summary>
        /// <since_tizen> 6 </since_tizen>
        /// <param name="restricted">The minimum size constraint as input, the returned size can not be lower than this (in both directions).</param>
        /// <returns>The minimum required size.</returns>
        public virtual CoreUI.DataTypes.Size2D CalcSizeMin(CoreUI.DataTypes.Size2D restricted) {
            CoreUI.DataTypes.Size2D _in_restricted = restricted;
var _ret_var = CoreUI.Layout.ICalcNativeMethods.efl_layout_calc_size_min_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), _in_restricted);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
        }

        /// <summary>Calculates the geometry of the region, relative to a given layout object&apos;s area, occupied by all parts in the object.
        /// 
        /// This function gets the geometry of the rectangle equal to the area required to group all parts in obj&apos;s group/collection. The x and y coordinates are relative to the top left corner of the whole obj object&apos;s area. Parts placed out of the group&apos;s boundaries will also be taken in account, so that x and y may be negative.
        /// 
        /// <b>NOTE: </b>On failure, this function will make all non-<c>null</c> geometry pointers&apos; pointed variables be set to zero.</summary>
        /// <since_tizen> 6 </since_tizen>
        /// <returns>The calculated region.</returns>
        public virtual CoreUI.DataTypes.Rect CalcPartsExtends() {
            var _ret_var = CoreUI.Layout.ICalcNativeMethods.efl_layout_calc_parts_extends_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)));
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
        }

        /// <summary>Freezes the layout object.
        /// 
        /// This function puts all changes on hold. Successive freezes will nest, requiring an equal number of thaws.
        /// 
        /// See also <see cref="CoreUI.Layout.ICalc.ThawCalc"/>.</summary>
        /// <since_tizen> 6 </since_tizen>
        /// <returns>The frozen state or 0 on error</returns>
        public virtual int FreezeCalc() {
            var _ret_var = CoreUI.Layout.ICalcNativeMethods.efl_layout_calc_freeze_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)));
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
        }

        /// <summary>Thaws the layout object.
        /// 
        /// This function thaws (in other words &quot;unfreezes&quot;) the given layout object.
        /// 
        /// <b>NOTE: </b>If successive freezes were done, an equal number of thaws will be required.
        /// 
        /// See also <see cref="CoreUI.Layout.ICalc.FreezeCalc"/>.</summary>
        /// <since_tizen> 6 </since_tizen>
        /// <returns>The frozen state or 0 if the object is not frozen or on error.</returns>
        public virtual int ThawCalc() {
            var _ret_var = CoreUI.Layout.ICalcNativeMethods.efl_layout_calc_thaw_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)));
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
        }

        /// <summary>Forces a Size/Geometry calculation.
        /// 
        /// Forces the object to recalculate its layout regardless of freeze/thaw. This API should be used carefully.
        /// 
        /// See also <see cref="CoreUI.Layout.ICalc.FreezeCalc"/> and <see cref="CoreUI.Layout.ICalc.ThawCalc"/>.</summary>
        /// <since_tizen> 6 </since_tizen>
        protected virtual void CalcForce() {
            CoreUI.Layout.ICalcNativeMethods.efl_layout_calc_force_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)));
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            
        }

        /// <summary>The minimum size specified -- as an EDC property -- for a given Edje object
        /// 
        /// This property retrieves the obj object&apos;s minimum size values, as declared in its EDC group definition. For instance, for an Edje object of minimum size 100x100 pixels: collections { group { name: &quot;a_group&quot;; min: 100 100; } }
        /// 
        /// <b>NOTE: </b>If the <c>min</c> EDC property was not declared for this object, this call will return 0x0.
        /// 
        /// <b>NOTE: </b>On failure, this function also return 0x0.
        /// 
        /// See also <see cref="CoreUI.Layout.IGroup.GetGroupSizeMax"/>.</summary>
        /// <returns>The minimum size as set in EDC.</returns>
        /// <since_tizen> 6 </since_tizen>
        public virtual CoreUI.DataTypes.Size2D GetGroupSizeMin() {
            var _ret_var = CoreUI.Layout.IGroupNativeMethods.efl_layout_group_size_min_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)));
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
        }

        /// <summary>The maximum size specified -- as an EDC property -- for a given Edje object
        /// 
        /// This property retrieves the object&apos;s maximum size values, as declared in its EDC group definition. For instance, for an Edje object of maximum size 100x100 pixels: collections { group { name: &quot;a_group&quot;; max: 100 100; } }
        /// 
        /// <b>NOTE: </b>If the <c>max</c> EDC property was not declared for the object, this call will return the maximum size a given Edje object may have, for each axis.
        /// 
        /// <b>NOTE: </b>On failure, this function will return 0x0.
        /// 
        /// See also <see cref="CoreUI.Layout.IGroup.GetGroupSizeMin"/>.</summary>
        /// <returns>The maximum size as set in EDC.</returns>
        /// <since_tizen> 6 </since_tizen>
        public virtual CoreUI.DataTypes.Size2D GetGroupSizeMax() {
            var _ret_var = CoreUI.Layout.IGroupNativeMethods.efl_layout_group_size_max_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)));
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
        }

        /// <summary>The EDC data field&apos;s value from a given Edje object&apos;s group.
        /// 
        /// This property represents an EDC data field&apos;s value, which is declared on the objects building EDC file, under its group. EDC data blocks are most commonly used to pass arbitrary parameters from an application&apos;s theme to its code.
        /// 
        /// EDC data fields always hold  strings as values, hence the return type of this function. Check the complete &quot;syntax reference&quot; for EDC files.
        /// 
        /// This is how a data item is defined in EDC: collections { group { name: &quot;a_group&quot;; data { item: &quot;key1&quot; &quot;value1&quot;; item: &quot;key2&quot; &quot;value2&quot;; } } }
        /// 
        /// <b>WARNING: </b>Do not confuse this call with edje_file_data_get(), which queries for a global EDC data field on an EDC declaration file.</summary>
        /// <param name="key">The data field&apos;s key string</param>
        /// <returns>The data&apos;s value string.</returns>
        /// <since_tizen> 6 </since_tizen>
        public virtual System.String GetGroupData(System.String key) {
            var _ret_var = CoreUI.Layout.IGroupNativeMethods.efl_layout_group_data_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), key);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
        }

        /// <summary>Whether the given part exists in this group.
        /// 
        /// This is mostly equivalent to verifying the part type on the object as would be done in C as follows: (efl_canvas_layout_part_type_get(efl_part(obj, &quot;partname&quot;)) != EFL_CANVAS_LAYOUT_PART_TYPE_NONE)
        /// 
        /// The differences are that will silently return <c>false</c> if the part does not exist, and this will return <c>true</c> if the part is of type <c>SPACER</c> in the EDC file (<c>SPACER</c> parts have type <c>NONE</c>).
        /// 
        /// See also <span class="text-muted">CoreUI.Canvas.LayoutPart.GetPartType (object still in beta stage)</span>.</summary>
        /// <param name="part">The part name to check.</param>
        /// <returns><c>true</c> if the part exists, <c>false</c> otherwise.</returns>
        /// <since_tizen> 6 </since_tizen>
        public virtual bool GetPartExist(System.String part) {
            var _ret_var = CoreUI.Layout.IGroupNativeMethods.efl_layout_group_part_exist_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), part);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
        }

        /// <summary>Sends an (Edje) message to a given Edje object
        /// 
        /// This function sends an Edje message to obj and to all of its child objects, if it has any (swallowed objects are one kind of child object). Only a few types are supported: - int, - float/double, - string/stringshare, - arrays of int, float, double or strings.
        /// 
        /// Messages can go both ways, from code to theme, or theme to code.
        /// 
        /// The id argument as a form of code and theme defining a common interface on message communication. One should define the same IDs on both code and EDC declaration, to individualize messages (binding them to a given context).</summary>
        /// <since_tizen> 6 </since_tizen>
        /// <param name="id">A identification number for the message to be sent</param>
        /// <param name="msg">The message&apos;s payload</param>
        public virtual void SendMessage(int id, CoreUI.DataTypes.Value msg) {
            CoreUI.Layout.ISignalNativeMethods.efl_layout_signal_message_send_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), id, msg);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            
        }

        /// <summary>Adds a callback for an arriving Edje signal, emitted by a given Edje object.
        /// 
        /// Edje signals are one of the communication interfaces between code and a given Edje object&apos;s theme. With signals, one can communicate two string values at a time, which are: - &quot;emission&quot; value: the name of the signal, in general - &quot;source&quot; value: a name for the signal&apos;s context, in general
        /// 
        /// Signals can go both ways, from code to theme, or theme to code.
        /// 
        /// Though there are those common uses for the two strings, one is free to use them however they like.
        /// 
        /// Signal callback registration is powerful, in the way that blobs may be used to match multiple signals at once. All the &quot;*?[" set of <c>fnmatch</c>() operators can be used, both for emission and source.
        /// 
        /// Edje has internal signals it will emit, automatically, on various actions taking place on group parts. For example, the mouse cursor being moved, pressed, released, etc., over a given part&apos;s area, all generate individual signals.
        /// 
        /// With something like emission = &quot;mouse,down,*&quot;, source = &quot;button.*&quot; where &quot;button.*&quot; is the pattern for the names of parts implementing buttons on an interface, you&apos;d be registering for notifications on events of mouse buttons being pressed down on either of those parts (those events all have the &quot;mouse,down,&quot; common prefix on their names, with a suffix giving the button number). The actual emission and source strings of an event will be passed in as the emission and source parameters of the callback function (e.g. &quot;mouse,down,2&quot; and &quot;button.close&quot;), for each of those events.
        /// 
        /// See also the Edje Data Collection Reference for EDC files.
        /// 
        /// See <see cref="CoreUI.Layout.ISignal.EmitSignal"/> on how to emit signals from code to a an object See <see cref="CoreUI.Layout.ISignal.DelSignalCallback"/>.</summary>
        /// <since_tizen> 6 </since_tizen>
        /// <param name="emission">The signal&apos;s &quot;emission&quot; string</param>
        /// <param name="source">The signal&apos;s &quot;source&quot; string</param>
        /// <param name="func">The callback function to be executed when the signal is emitted.</param>
        /// <returns><c>true</c> in case of success, <c>false</c> in case of error.</returns>
        public virtual bool AddSignalCallback(System.String emission, System.String source, CoreUILayoutSignalCb func) {
            GCHandle func_handle = GCHandle.Alloc(func);
var _ret_var = CoreUI.Layout.ISignalNativeMethods.efl_layout_signal_callback_add_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), emission, source, GCHandle.ToIntPtr(func_handle), CoreUILayoutSignalCbWrapper.Cb, CoreUI.Wrapper.Globals.free_gchandle);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
        }

        /// <summary>Removes a signal-triggered callback from an object.
        /// 
        /// This function removes a callback, previously attached to the emission of a signal, from the object  obj. The parameters emission, source and func must match exactly those passed to a previous call to <see cref="CoreUI.Layout.ISignal.AddSignalCallback"/>.
        /// 
        /// See <see cref="CoreUI.Layout.ISignal.AddSignalCallback"/>.</summary>
        /// <since_tizen> 6 </since_tizen>
        /// <param name="emission">The signal&apos;s &quot;emission&quot; string</param>
        /// <param name="source">The signal&apos;s &quot;source&quot; string</param>
        /// <param name="func">The callback function to be executed when the signal is emitted.</param>
        /// <returns><c>true</c> in case of success, <c>false</c> in case of error.</returns>
        public virtual bool DelSignalCallback(System.String emission, System.String source, CoreUILayoutSignalCb func) {
            GCHandle func_handle = GCHandle.Alloc(func);
var _ret_var = CoreUI.Layout.ISignalNativeMethods.efl_layout_signal_callback_del_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), emission, source, GCHandle.ToIntPtr(func_handle), CoreUILayoutSignalCbWrapper.Cb, CoreUI.Wrapper.Globals.free_gchandle);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
        }

        /// <summary>Sends/emits an Edje signal to this layout.
        /// 
        /// This function sends a signal to the object. An Edje program, at the EDC specification level, can respond to a signal by having declared matching &quot;signal&quot; and &quot;source&quot; fields on its block.
        /// 
        /// See also the Edje Data Collection Reference for EDC files.
        /// 
        /// See <see cref="CoreUI.Layout.ISignal.AddSignalCallback"/> for more on Edje signals.</summary>
        /// <since_tizen> 6 </since_tizen>
        /// <param name="emission">The signal&apos;s &quot;emission&quot; string</param>
        /// <param name="source">The signal&apos;s &quot;source&quot; string</param>
        public virtual void EmitSignal(System.String emission, System.String source) {
            CoreUI.Layout.ISignalNativeMethods.efl_layout_signal_emit_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), emission, source);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            
        }

        /// <summary>Processes an object&apos;s messages and signals queue.
        /// 
        /// This function goes through the object message queue processing the pending messages for this specific Edje object. Normally they&apos;d be processed only at idle time.
        /// 
        /// If <c>recurse</c> is <c>true</c>, this function will be called recursively on all subobjects.</summary>
        /// <since_tizen> 6 </since_tizen>
        /// <param name="recurse">Whether to process messages on children objects.</param>
        public virtual void ProcessSignal(bool recurse) {
            CoreUI.Layout.ISignalNativeMethods.efl_layout_signal_process_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), recurse);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            
        }

        /// <summary>The image name, using icon standards names.
        /// 
        /// For example, freedesktop.org defines standard icon names such as &quot;home&quot; and &quot;network&quot;. There can be different icon sets to match those icon keys. The &quot;name&quot; given as parameter is one of these &quot;keys&quot; and will be used to look in the freedesktop.org paths and elementary theme.
        /// 
        /// If the name is not found in any of the expected locations and is the absolute path of an image file, this image will be used. Lookup order used by <see cref="CoreUI.UI.Image.SetIcon"/> can be set using &quot;icon_theme&quot; in config.
        /// 
        /// If the image was set using <see cref="CoreUI.IFile.File"/> instead of <see cref="CoreUI.UI.Image.SetIcon"/>, then reading this property will return null.
        /// 
        /// <b>NOTE: </b>The image set by this function is changed when <see cref="CoreUI.IFile.Load"/> is called.
        /// 
        /// <b>NOTE: </b>This function does not accept relative icon paths.
        /// 
        /// See also <see cref="CoreUI.UI.Image.GetIcon"/>.</summary>
        /// <value>The icon name</value>
        /// <since_tizen> 6 </since_tizen>
        public System.String Icon {
            get { return GetIcon(); }
            set { SetIcon(value); }
        }

        /// <summary>The mmaped file from where an object will fetch the real data (it must be an <see cref="CoreUI.DataTypes.File"/>).
        /// 
        /// If mmap is set during object construction, the object will automatically call <see cref="CoreUI.IFile.Load"/> during the finalize phase of construction.</summary>
        /// <value>The handle to the <see cref="CoreUI.DataTypes.File"/> that will be used</value>
        /// <since_tizen> 6 </since_tizen>
        public CoreUI.DataTypes.File Mmap {
            get { return GetMmap(); }
            set { SetMmap(value); }
        }

        /// <summary>The file path from where an object will fetch the data.
        /// 
        /// If file is set during object construction, the object will automatically call <see cref="CoreUI.IFile.Load"/> during the finalize phase of construction.
        /// 
        /// You must not modify the strings on the returned pointers.</summary>
        /// <value>The file path.</value>
        /// <since_tizen> 6 </since_tizen>
        public System.String File {
            get { return GetFile(); }
            set { SetFile(value); }
        }

        /// <summary>The key which corresponds to the target data within a file.
        /// 
        /// Some file types can contain multiple data streams which are indexed by a key. Use this property for such cases (See for example <see cref="CoreUI.UI.Image"/> or <see cref="CoreUI.UI.Layout"/>).
        /// 
        /// You must not modify the strings on the returned pointers.</summary>
        /// <value>The group that the data belongs to. See the class documentation for particular implementations of this interface to see how this property is used.</value>
        /// <since_tizen> 6 </since_tizen>
        public System.String Key {
            get { return GetKey(); }
            set { SetKey(value); }
        }

        /// <summary>The load state of the object.</summary>
        /// <value><c>true</c> if the object is loaded, <c>false</c> otherwise.</value>
        /// <since_tizen> 6 </since_tizen>
        public bool Loaded {
            get { return GetLoaded(); }
        }

        /// <summary>Playback state of the media file.
        /// 
        /// This property sets the playback state of the object. Re-setting the current playback state has no effect.
        /// 
        /// If set to <c>false</c>, the object&apos;s <see cref="CoreUI.IPlayer.PlaybackProgress"/> property is, by default, reset to <c>0.0</c>. A class may alter this behavior, and it will be stated in the documentation for a class if such behavior changes should be expected.
        /// 
        /// Applying the <c>false</c> playing state also has the same effect as the player object reaching the end of its playback, which may invoke additional behavior based on a class&apos;s implementation.</summary>
        /// <value><c>true</c> if playing, <c>false</c> otherwise.</value>
        /// <since_tizen> 6 </since_tizen>
        public bool Playing {
            get { return GetPlaying(); }
            set { SetPlaying(value); }
        }

        /// <summary>Pause state of the media file.
        /// 
        /// This property sets the pause state of the media.  Re-setting the current pause state has no effect.
        /// 
        /// If <see cref="CoreUI.IPlayer.Playing"/> is set to <c>true</c>, this property can be used to pause and resume playback of the media without changing its <see cref="CoreUI.IPlayer.PlaybackProgress"/> property. This property cannot be changed if <see cref="CoreUI.IPlayer.Playing"/> is <c>false</c>.</summary>
        /// <value><c>true</c> if paused, <c>false</c> otherwise.</value>
        /// <since_tizen> 6 </since_tizen>
        public bool Paused {
            get { return GetPaused(); }
            set { SetPaused(value); }
        }

        /// <summary>Position in the media file.
        /// 
        /// This property sets the current position of the media file to <c>sec</c> seconds since the beginning of the media file. This only works on seekable streams. Setting the position doesn&apos;t change the <see cref="CoreUI.IPlayer.Playing"/> or <see cref="CoreUI.IPlayer.Paused"/> states of the media file.</summary>
        /// <value>The position (in seconds).</value>
        /// <since_tizen> 6 </since_tizen>
        public double PlaybackPosition {
            get { return GetPlaybackPosition(); }
            set { SetPlaybackPosition(value); }
        }

        /// <summary>How much of the file has been played.
        /// 
        /// This function sets or gets the progress in playing the file, the value is in the [0, 1] range.</summary>
        /// <value>The progress within the [0, 1] range.</value>
        /// <since_tizen> 6 </since_tizen>
        public double PlaybackProgress {
            get { return GetPlaybackProgress(); }
            set { SetPlaybackProgress(value); }
        }

        /// <summary>Control the playback speed of the media file.
        /// 
        /// This function control the speed with which the media file will be played. 1.0 represents the normal speed, 2 double speed, 0.5 half speed and so on.</summary>
        /// <value>The play speed in the [0, infinity) range.</value>
        /// <since_tizen> 6 </since_tizen>
        public double PlaybackSpeed {
            get { return GetPlaybackSpeed(); }
            set { SetPlaybackSpeed(value); }
        }

        /// <summary>When <c>true</c>, playback will start as soon as the media is ready.
        /// 
        /// This means that the media file has been successfully loaded and the object is visible.
        /// 
        /// If the object becomes invisible later on the playback is paused, resuming when it is visible again.
        /// 
        /// Changing this property affects the next media being loaded, so set it before setting the media file.</summary>
        /// <value>Auto play mode, Default is <c>false</c>.</value>
        /// <since_tizen> 6 </since_tizen>
        public bool Autoplay {
            get { return GetAutoplay(); }
            set { SetAutoplay(value); }
        }

        /// <summary>Enable playback looping.
        /// 
        /// When <c>true</c>, playback continues from the beginning when it reaches the last frame. Otherwise, playback stops. This works both when playing forward and backward.</summary>
        /// <value>Loop mode, Default is <c>false</c>.</value>
        /// <since_tizen> 6 </since_tizen>
        public bool PlaybackLoop {
            get { return GetPlaybackLoop(); }
            set { SetPlaybackLoop(value); }
        }

        /// <summary>This property determines how contents will be aligned within a container if there is unused space.
        /// 
        /// It is different than the <see cref="CoreUI.Gfx.IHint.HintAlign"/> property in that it affects the position of all the contents within the container instead of the container itself. For example, if a box widget has extra space on the horizontal axis, this property can be used to align the box&apos;s contents to the left or the right side.
        /// 
        /// See also <see cref="CoreUI.Gfx.IHint.HintAlign"/>.</summary>
        /// <value>Controls the horizontal alignment.</value>
        /// <since_tizen> 6 </since_tizen>
        public (CoreUI.Gfx.Align, CoreUI.Gfx.Align) ContentAlign {
            get {
                CoreUI.Gfx.Align _out_align_horiz = default(CoreUI.Gfx.Align);
                CoreUI.Gfx.Align _out_align_vert = default(CoreUI.Gfx.Align);
                GetContentAlign(out _out_align_horiz, out _out_align_vert);
                return (_out_align_horiz, _out_align_vert);
            }
            set { SetContentAlign( value.Item1,  value.Item2); }
        }

        /// <summary>This property determines the space between a container&apos;s content items.
        /// 
        /// It is different than the <see cref="CoreUI.Gfx.IHint.HintMargin"/> property in that it is applied to each content item within the container instead of a single item. The calculation for these two properties is cumulative.
        /// 
        /// See also <see cref="CoreUI.Gfx.IHint.HintMargin"/>.</summary>
        /// <value>Horizontal padding.</value>
        /// <since_tizen> 6 </since_tizen>
        public (uint, uint) ContentPadding {
            get {
                uint _out_pad_horiz = default(uint);
                uint _out_pad_vert = default(uint);
                GetContentPadding(out _out_pad_horiz, out _out_pad_vert);
                return (_out_pad_horiz, _out_pad_vert);
            }
            set { SetContentPadding( value.Item1,  value.Item2); }
        }

        /// <summary>Whether to use high-quality image scaling algorithm for this image.
        /// 
        /// When enabled, a higher quality image scaling algorithm is used when scaling images to sizes other than the source image&apos;s original one. This gives better results but is more computationally expensive.</summary>
        /// <value>Whether to use smooth scale or not.</value>
        /// <since_tizen> 6 </since_tizen>
        public bool SmoothScale {
            get { return GetSmoothScale(); }
            set { SetSmoothScale(value); }
        }

        /// <summary>Determine how the image is scaled at render time.
        /// 
        /// This allows more granular controls for how an image object should display its internal buffer. The underlying image data will not be modified.</summary>
        /// <value>Image scale type to use.</value>
        /// <since_tizen> 6 </since_tizen>
        public CoreUI.Gfx.ImageScaleMethod ScaleMethod {
            get { return GetScaleMethod(); }
            set { SetScaleMethod(value); }
        }

        /// <summary>If <c>true</c>, the image may be scaled to a larger size. If <c>false</c>, the image will never be resized larger than its native size.</summary>
        /// <value>Whether to allow image upscaling.</value>
        /// <since_tizen> 6 </since_tizen>
        public bool CanUpscale {
            get { return GetCanUpscale(); }
            set { SetCanUpscale(value); }
        }

        /// <summary>If <c>true</c>, the image may be scaled to a smaller size. If <c>false</c>, the image will never be resized smaller than its native size.</summary>
        /// <value>Whether to allow image downscaling.</value>
        /// <since_tizen> 6 </since_tizen>
        public bool CanDownscale {
            get { return GetCanDownscale(); }
            set { SetCanDownscale(value); }
        }

        /// <summary>The native width/height ratio of the image.
        /// 
        /// The ratio will be 1.0 if it cannot be calculated (e.g. height = 0).</summary>
        /// <value>The image&apos;s ratio.</value>
        /// <since_tizen> 6 </since_tizen>
        public double Ratio {
            get { return GetRatio(); }
        }

        /// <summary>Return the relative area enclosed inside the image where content is expected.
        /// 
        /// We do expect content to be inside the limit defined by the border or inside the stretch region. If a stretch region is provided, the content region will encompass the non-stretchable area that are surrounded by stretchable area. If no border and no stretch region is set, they are assumed to be zero and the full object geometry is where content can be layout on top. The area size change with the object size.
        /// 
        /// The geometry of the area is expressed relative to the geometry of the object.</summary>
        /// <value>A rectangle inside the object boundary where content is expected. The default value is the image object&apos;s geometry with the <see cref="CoreUI.Gfx.IImage.BorderInsets"/> values subtracted.</value>
        /// <since_tizen> 6 </since_tizen>
        public CoreUI.DataTypes.Rect ContentRegion {
            get { return GetContentRegion(); }
        }

        /// <summary>Dimensions of this image&apos;s border, a region that does not scale with the center area.
        /// 
        /// When EFL renders an image, its source may be scaled to fit the size of the object. This function sets an area from the borders of the image inwards which is not to be scaled. This function is useful for making frames and for widget theming, where, for example, buttons may be of varying sizes, but their border size must remain constant.
        /// 
        /// The units used for <c>l</c>, <c>r</c>, <c>t</c> and <c>b</c> are canvas units (pixels).
        /// 
        /// <b>NOTE: </b>The border region itself may be scaled by the <see cref="CoreUI.Gfx.IImage.SetBorderInsetsScale"/> function.
        /// 
        /// <b>NOTE: </b>By default, image objects have no borders set, i.e. <c>l</c>, <c>r</c>, <c>t</c> and <c>b</c> start as 0.
        /// 
        /// <b>NOTE: </b>Similar to the concepts of 9-patch images or cap insets.</summary>
        /// <value>The border&apos;s left width.</value>
        /// <since_tizen> 6 </since_tizen>
        public (int, int, int, int) BorderInsets {
            get {
                int _out_l = default(int);
                int _out_r = default(int);
                int _out_t = default(int);
                int _out_b = default(int);
                GetBorderInsets(out _out_l, out _out_r, out _out_t, out _out_b);
                return (_out_l, _out_r, _out_t, _out_b);
            }
            set { SetBorderInsets( value.Item1,  value.Item2,  value.Item3,  value.Item4); }
        }

        /// <summary>Scaling factor applied to the image borders.
        /// 
        /// This value multiplies the size of the <see cref="CoreUI.Gfx.IImage.BorderInsets"/> when scaling an object.</summary>
        /// <value>The scale factor.</value>
        /// <since_tizen> 6 </since_tizen>
        public double BorderInsetsScale {
            get { return GetBorderInsetsScale(); }
            set { SetBorderInsetsScale(value); }
        }

        /// <summary>Specifies how the center part of the object (not the borders) should be drawn when EFL is rendering it.
        /// 
        /// This function sets how the center part of the image object&apos;s source image is to be drawn, which must be one of the values in <see cref="CoreUI.Gfx.CenterFillMode"/>. By center we mean the complementary part of that defined by <see cref="CoreUI.Gfx.IImage.SetBorderInsets"/>. This is very useful for making frames and decorations. You would most probably also be using a filled image (as in <span class="text-muted">CoreUI.Gfx.IFill.FillAuto (object still in beta stage)</span>) to use as a frame.</summary>
        /// <value>Fill mode of the center region. The default behavior is to render and scale the center area, respecting its transparency.</value>
        /// <since_tizen> 6 </since_tizen>
        public CoreUI.Gfx.CenterFillMode CenterFillMode {
            get { return GetCenterFillMode(); }
            set { SetCenterFillMode(value); }
        }

        /// <summary>This property defines the stretchable pixels region of an image.
        /// 
        /// When the regions are set by the user, the method will walk the iterators once and then destroy them. When the regions are retrieved by the user, it is his responsibility to destroy the iterators.. It will remember the information for the lifetime of the object. It will ignore all value of <see cref="CoreUI.Gfx.IImage.BorderInsets"/>, <see cref="CoreUI.Gfx.IImage.BorderInsetsScale"/> and <see cref="CoreUI.Gfx.IImage.CenterFillMode"/> . To reset the object you can just pass <c>null</c> to both horizontal and vertical at the same time.</summary>
        /// <value>Representation of areas that are stretchable in the image horizontal space.</value>
        /// <since_tizen> 6 </since_tizen>
        public (IEnumerable<CoreUI.Gfx.ImageStretchRegion>, IEnumerable<CoreUI.Gfx.ImageStretchRegion>) StretchRegion {
            get {
                IEnumerable<CoreUI.Gfx.ImageStretchRegion> _out_horizontal = default(IEnumerable<CoreUI.Gfx.ImageStretchRegion>);
                IEnumerable<CoreUI.Gfx.ImageStretchRegion> _out_vertical = default(IEnumerable<CoreUI.Gfx.ImageStretchRegion>);
                GetStretchRegion(out _out_horizontal, out _out_vertical);
                return (_out_horizontal, _out_vertical);
            }
            set { SetStretchRegion( value.Item1,  value.Item2); }
        }

        /// <summary>This represents the size of the original image in pixels.
        /// 
        /// This may be different from the actual geometry on screen or even the size of the loaded pixel buffer. This is the size of the image as stored in the original file.
        /// 
        /// This is a read-only property and may return 0x0.</summary>
        /// <value>The size in pixels. The default value is the size of the image&apos;s internal buffer.</value>
        /// <since_tizen> 6 </since_tizen>
        public CoreUI.DataTypes.Size2D ImageSize {
            get { return GetImageSize(); }
        }

        /// <summary>Content hint setting for the image. These hints might be used by EFL to enable optimizations.
        /// 
        /// For example, if you&apos;re on the GL engine and your driver implementation supports it, setting this hint to <see cref="CoreUI.Gfx.ImageContentHint.Dynamic"/> will make it need zero copies at texture upload time, which is an &quot;expensive&quot; operation.</summary>
        /// <value>Dynamic or static content hint.</value>
        /// <since_tizen> 6 </since_tizen>
        public CoreUI.Gfx.ImageContentHint ContentHint {
            get { return GetContentHint(); }
            set { SetContentHint(value); }
        }

        /// <summary>The scale hint of a given image of the canvas.
        /// 
        /// The scale hint affects how EFL is to cache scaled versions of its original source image.</summary>
        /// <value>Scalable or static size hint.</value>
        /// <since_tizen> 6 </since_tizen>
        public CoreUI.Gfx.ImageScaleHint ScaleHint {
            get { return GetScaleHint(); }
            set { SetScaleHint(value); }
        }

        /// <summary>The (last) file loading error for a given object. This value is set to a nonzero value if an error has occurred.</summary>
        /// <value>The load error code. A value of $0 indicates no error.</value>
        /// <since_tizen> 6 </since_tizen>
        public CoreUI.DataTypes.Error ImageLoadError {
            get { return GetImageLoadError(); }
        }

        /// <summary>The load size of an image.
        /// 
        /// The image will be loaded into memory as if it was the specified size instead of its original size. This can save a lot of memory and is important for scalable types like SVG.
        /// 
        /// EFL will try to load an image of the requested size but does not guarantee an exact match between the request and the loaded image dimensions.
        /// 
        /// By default, the load size is not specified, so it is <c>0x0</c>.</summary>
        /// <value>The image load size.</value>
        /// <since_tizen> 6 </since_tizen>
        public CoreUI.DataTypes.Size2D LoadSize {
            get { return GetLoadSize(); }
            set { SetLoadSize(value); }
        }

        /// <summary>The DPI resolution of an image object&apos;s source image.
        /// 
        /// Most useful for the SVG image loader.</summary>
        /// <value>The DPI resolution.</value>
        /// <since_tizen> 6 </since_tizen>
        public double LoadDpi {
            get { return GetLoadDpi(); }
            set { SetLoadDpi(value); }
        }

        /// <summary>Indicates whether the <see cref="CoreUI.Gfx.IImageLoadController.LoadRegion"/> property is supported for the current file.</summary>
        /// <value><c>true</c> if region load of the image is supported, <c>false</c> otherwise.</value>
        /// <since_tizen> 6 </since_tizen>
        public bool LoadRegionSupport {
            get { return GetLoadRegionSupport(); }
        }

        /// <summary>Inform a given image object to load a selective region of its source image.
        /// 
        /// This property is useful when one is not showing all of an image&apos;s area on its image object.
        /// 
        /// <b>NOTE: </b>The image loader for the image format in question has to support selective region loading in order for this function to work (see <see cref="CoreUI.Gfx.IImageLoadController.GetLoadRegionSupport"/>).</summary>
        /// <value>A region of the image.</value>
        /// <since_tizen> 6 </since_tizen>
        public CoreUI.DataTypes.Rect LoadRegion {
            get { return GetLoadRegion(); }
            set { SetLoadRegion(value); }
        }

        /// <summary>Defines whether the orientation information in the image file should be honored.
        /// 
        /// The orientation can for instance be set in the EXIF tags of a JPEG image. If this flag is <c>false</c>, then the orientation will be ignored at load time, otherwise the image will be loaded with the proper orientation.</summary>
        /// <value><c>true</c> means that it should honor the orientation information.</value>
        /// <since_tizen> 6 </since_tizen>
        public bool LoadOrientation {
            get { return GetLoadOrientation(); }
            set { SetLoadOrientation(value); }
        }

        /// <summary>The scale down factor is a divider on the original image size.
        /// 
        /// Setting the scale down factor can reduce load time and memory usage at the cost of having a scaled down image in memory.
        /// 
        /// This function sets the scale down factor of a given canvas image. Most useful for the SVG image loader but also applies to JPEG, PNG and BMP.
        /// 
        /// Powers of two (2, 4, 8, ...) are best supported (especially with JPEG).</summary>
        /// <value>The scale down dividing factor.</value>
        /// <since_tizen> 6 </since_tizen>
        public int LoadScaleDown {
            get { return GetLoadScaleDown(); }
            set { SetLoadScaleDown(value); }
        }

        /// <summary>Initial load should skip header check and leave it all to data load.
        /// 
        /// If this is <c>true</c>, then future loads of images will defer header loading to a preload stage and/or data load later on rather than at the start when the load begins (e.g. when file is set).</summary>
        /// <value><c>true</c> if header is to be skipped.</value>
        /// <since_tizen> 6 </since_tizen>
        public bool LoadSkipHeader {
            get { return GetLoadSkipHeader(); }
            set { SetLoadSkipHeader(value); }
        }

        /// <summary>Control the orientation (rotation and flipping) of a visual object.
        /// 
        /// This can be used to set the rotation on an image or a window, for instance.</summary>
        /// <value>The final orientation of the object.</value>
        /// <since_tizen> 6 </since_tizen>
        public CoreUI.Gfx.ImageOrientation ImageOrientation {
            get { return GetImageOrientation(); }
            set { SetImageOrientation(value); }
        }

        /// <summary>This returns true if the given object is currently in event emission</summary>
        /// <since_tizen> 6 </since_tizen>
        public bool Interaction {
            get { return GetInteraction(); }
        }

        /// <summary>Whether this object updates its size hints automatically.
        /// 
        /// By default edje doesn&apos;t set size hints on itself. If this property is set to <c>true</c>, size hints will be updated after recalculation. Be careful, as recalculation may happen often, enabling this property may have a considerable performance impact as other widgets will be notified of the size hints changes.
        /// 
        /// A layout recalculation can be triggered by <see cref="CoreUI.Layout.ICalc.CalcSizeMin"/>, <see cref="CoreUI.Layout.ICalc.CalcSizeMin"/>, <see cref="CoreUI.Layout.ICalc.CalcPartsExtends"/> or even any other internal event.</summary>
        /// <value>Whether or not update the size hints.</value>
        /// <since_tizen> 6 </since_tizen>
        public bool CalcAutoUpdateHints {
            get { return GetCalcAutoUpdateHints(); }
            set { SetCalcAutoUpdateHints(value); }
        }

        /// <summary>The minimum size specified -- as an EDC property -- for a given Edje object
        /// 
        /// This property retrieves the obj object&apos;s minimum size values, as declared in its EDC group definition. For instance, for an Edje object of minimum size 100x100 pixels: collections { group { name: &quot;a_group&quot;; min: 100 100; } }
        /// 
        /// <b>NOTE: </b>If the <c>min</c> EDC property was not declared for this object, this call will return 0x0.
        /// 
        /// <b>NOTE: </b>On failure, this function also return 0x0.
        /// 
        /// See also <see cref="CoreUI.Layout.IGroup.GetGroupSizeMax"/>.</summary>
        /// <value>The minimum size as set in EDC.</value>
        /// <since_tizen> 6 </since_tizen>
        public CoreUI.DataTypes.Size2D GroupSizeMin {
            get { return GetGroupSizeMin(); }
        }

        /// <summary>The maximum size specified -- as an EDC property -- for a given Edje object
        /// 
        /// This property retrieves the object&apos;s maximum size values, as declared in its EDC group definition. For instance, for an Edje object of maximum size 100x100 pixels: collections { group { name: &quot;a_group&quot;; max: 100 100; } }
        /// 
        /// <b>NOTE: </b>If the <c>max</c> EDC property was not declared for the object, this call will return the maximum size a given Edje object may have, for each axis.
        /// 
        /// <b>NOTE: </b>On failure, this function will return 0x0.
        /// 
        /// See also <see cref="CoreUI.Layout.IGroup.GetGroupSizeMin"/>.</summary>
        /// <value>The maximum size as set in EDC.</value>
        /// <since_tizen> 6 </since_tizen>
        public CoreUI.DataTypes.Size2D GroupSizeMax {
            get { return GetGroupSizeMax(); }
        }

        private static IntPtr GetCoreUIClassStatic()
        {
            return CoreUI.UI.Image.efl_ui_image_class_get();
        }

        /// <summary>Wrapper for native methods and virtual method delegates.
        /// For internal use by generated code only.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        internal new class NativeMethods : CoreUI.UI.Widget.NativeMethods
        {
            private static CoreUI.Wrapper.NativeModule Module = new CoreUI.Wrapper.NativeModule(CoreUI.Libs.Elementary);

            /// <summary>Gets the list of Eo operations to override.
        /// </summary>
            /// <returns>The list of Eo operations to be overload.</returns>
            internal override System.Collections.Generic.List<CoreUIOpDescription> GetEoOps(System.Type type, bool includeInherited)
            {
                var descs = new System.Collections.Generic.List<CoreUIOpDescription>();
                var methods = CoreUI.Wrapper.Globals.GetUserMethods(type);

                if (efl_ui_image_icon_get_static_delegate == null)
                {
                    efl_ui_image_icon_get_static_delegate = new efl_ui_image_icon_get_delegate(icon_get);
                }

                if (methods.Contains("GetIcon"))
                {
                    descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_image_icon_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_image_icon_get_static_delegate) });
                }

                if (efl_ui_image_icon_set_static_delegate == null)
                {
                    efl_ui_image_icon_set_static_delegate = new efl_ui_image_icon_set_delegate(icon_set);
                }

                if (methods.Contains("SetIcon"))
                {
                    descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_image_icon_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_image_icon_set_static_delegate) });
                }

                if (efl_input_clickable_press_static_delegate == null)
                {
                    efl_input_clickable_press_static_delegate = new efl_input_clickable_press_delegate(press);
                }

                if (methods.Contains("Press"))
                {
                    descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_input_clickable_press"), func = Marshal.GetFunctionPointerForDelegate(efl_input_clickable_press_static_delegate) });
                }

                if (efl_input_clickable_unpress_static_delegate == null)
                {
                    efl_input_clickable_unpress_static_delegate = new efl_input_clickable_unpress_delegate(unpress);
                }

                if (methods.Contains("Unpress"))
                {
                    descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_input_clickable_unpress"), func = Marshal.GetFunctionPointerForDelegate(efl_input_clickable_unpress_static_delegate) });
                }

                if (efl_input_clickable_button_state_reset_static_delegate == null)
                {
                    efl_input_clickable_button_state_reset_static_delegate = new efl_input_clickable_button_state_reset_delegate(button_state_reset);
                }

                if (methods.Contains("ResetButtonState"))
                {
                    descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_input_clickable_button_state_reset"), func = Marshal.GetFunctionPointerForDelegate(efl_input_clickable_button_state_reset_static_delegate) });
                }

                if (efl_input_clickable_longpress_abort_static_delegate == null)
                {
                    efl_input_clickable_longpress_abort_static_delegate = new efl_input_clickable_longpress_abort_delegate(longpress_abort);
                }

                if (methods.Contains("LongpressAbort"))
                {
                    descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_input_clickable_longpress_abort"), func = Marshal.GetFunctionPointerForDelegate(efl_input_clickable_longpress_abort_static_delegate) });
                }

                if (efl_layout_calc_force_static_delegate == null)
                {
                    efl_layout_calc_force_static_delegate = new efl_layout_calc_force_delegate(calc_force);
                }

                if (methods.Contains("CalcForce"))
                {
                    descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_layout_calc_force"), func = Marshal.GetFunctionPointerForDelegate(efl_layout_calc_force_static_delegate) });
                }

                if (includeInherited)
                {
                    var all_interfaces = type.GetInterfaces();
                    foreach (var iface in all_interfaces)
                    {
                        var moredescs = ((CoreUI.Wrapper.NativeClass)iface.GetCustomAttributes(false)?.FirstOrDefault(attr => attr is CoreUI.Wrapper.NativeClass))?.GetEoOps(type, false);
                        if (moredescs != null)
                            descs.AddRange(moredescs);
                    }
                }
                descs.AddRange(base.GetEoOps(type, false));
                return descs;
            }

            /// <summary>Returns the Eo class for the native methods of this class.
            /// </summary>
            /// <returns>The native class pointer.</returns>
            internal override IntPtr GetCoreUIClass()
            {
                return CoreUI.UI.Image.efl_ui_image_class_get();
            }

            #pragma warning disable CA1707, CS1591, SA1300, SA1600

            [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.StringKeepOwnershipMarshaler))]
            private delegate System.String efl_ui_image_icon_get_delegate(System.IntPtr obj, System.IntPtr pd);

            [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.StringKeepOwnershipMarshaler))]
            internal delegate System.String efl_ui_image_icon_get_api_delegate(System.IntPtr obj);

            internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_ui_image_icon_get_api_delegate> efl_ui_image_icon_get_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_ui_image_icon_get_api_delegate>(Module, "efl_ui_image_icon_get");

            [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
            private static System.String icon_get(System.IntPtr obj, System.IntPtr pd)
            {
                CoreUI.DataTypes.Log.Debug("function efl_ui_image_icon_get was called");
                var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
                if (ws != null)
                {
                    System.String _ret_var = default(System.String);
                    try
                    {
                        _ret_var = ((Image)ws.Target).GetIcon();
                    }
                    catch (Exception e)
                    {
                        CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                        CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                    }

                    return _ret_var;
                }
                else
                {
                    return efl_ui_image_icon_get_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)));
                }
            }

            private static efl_ui_image_icon_get_delegate efl_ui_image_icon_get_static_delegate;

            [return: MarshalAs(UnmanagedType.U1)]
            private delegate bool efl_ui_image_icon_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.StringKeepOwnershipMarshaler))] System.String name);

            [return: MarshalAs(UnmanagedType.U1)]
            internal delegate bool efl_ui_image_icon_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.StringKeepOwnershipMarshaler))] System.String name);

            internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_ui_image_icon_set_api_delegate> efl_ui_image_icon_set_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_ui_image_icon_set_api_delegate>(Module, "efl_ui_image_icon_set");

            [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
            private static bool icon_set(System.IntPtr obj, System.IntPtr pd, System.String name)
            {
                CoreUI.DataTypes.Log.Debug("function efl_ui_image_icon_set was called");
                var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
                if (ws != null)
                {
                    bool _ret_var = default(bool);
                    try
                    {
                        _ret_var = ((Image)ws.Target).SetIcon(name);
                    }
                    catch (Exception e)
                    {
                        CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                        CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                    }

                    return _ret_var;
                }
                else
                {
                    return efl_ui_image_icon_set_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), name);
                }
            }

            private static efl_ui_image_icon_set_delegate efl_ui_image_icon_set_static_delegate;

            
            private delegate void efl_input_clickable_press_delegate(System.IntPtr obj, System.IntPtr pd,  uint button);

            
            internal delegate void efl_input_clickable_press_api_delegate(System.IntPtr obj,  uint button);

            internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_input_clickable_press_api_delegate> efl_input_clickable_press_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_input_clickable_press_api_delegate>(Module, "efl_input_clickable_press");

            [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
            private static void press(System.IntPtr obj, System.IntPtr pd, uint button)
            {
                CoreUI.DataTypes.Log.Debug("function efl_input_clickable_press was called");
                var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
                if (ws != null)
                {
                    
                    try
                    {
                        ((Image)ws.Target).Press(button);
                    }
                    catch (Exception e)
                    {
                        CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                        CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                    }

                    
                }
                else
                {
                    efl_input_clickable_press_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), button);
                }
            }

            private static efl_input_clickable_press_delegate efl_input_clickable_press_static_delegate;

            
            private delegate void efl_input_clickable_unpress_delegate(System.IntPtr obj, System.IntPtr pd,  uint button);

            
            internal delegate void efl_input_clickable_unpress_api_delegate(System.IntPtr obj,  uint button);

            internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_input_clickable_unpress_api_delegate> efl_input_clickable_unpress_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_input_clickable_unpress_api_delegate>(Module, "efl_input_clickable_unpress");

            [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
            private static void unpress(System.IntPtr obj, System.IntPtr pd, uint button)
            {
                CoreUI.DataTypes.Log.Debug("function efl_input_clickable_unpress was called");
                var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
                if (ws != null)
                {
                    
                    try
                    {
                        ((Image)ws.Target).Unpress(button);
                    }
                    catch (Exception e)
                    {
                        CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                        CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                    }

                    
                }
                else
                {
                    efl_input_clickable_unpress_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), button);
                }
            }

            private static efl_input_clickable_unpress_delegate efl_input_clickable_unpress_static_delegate;

            
            private delegate void efl_input_clickable_button_state_reset_delegate(System.IntPtr obj, System.IntPtr pd,  uint button);

            
            internal delegate void efl_input_clickable_button_state_reset_api_delegate(System.IntPtr obj,  uint button);

            internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_input_clickable_button_state_reset_api_delegate> efl_input_clickable_button_state_reset_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_input_clickable_button_state_reset_api_delegate>(Module, "efl_input_clickable_button_state_reset");

            [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
            private static void button_state_reset(System.IntPtr obj, System.IntPtr pd, uint button)
            {
                CoreUI.DataTypes.Log.Debug("function efl_input_clickable_button_state_reset was called");
                var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
                if (ws != null)
                {
                    
                    try
                    {
                        ((Image)ws.Target).ResetButtonState(button);
                    }
                    catch (Exception e)
                    {
                        CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                        CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                    }

                    
                }
                else
                {
                    efl_input_clickable_button_state_reset_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), button);
                }
            }

            private static efl_input_clickable_button_state_reset_delegate efl_input_clickable_button_state_reset_static_delegate;

            
            private delegate void efl_input_clickable_longpress_abort_delegate(System.IntPtr obj, System.IntPtr pd,  uint button);

            
            internal delegate void efl_input_clickable_longpress_abort_api_delegate(System.IntPtr obj,  uint button);

            internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_input_clickable_longpress_abort_api_delegate> efl_input_clickable_longpress_abort_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_input_clickable_longpress_abort_api_delegate>(Module, "efl_input_clickable_longpress_abort");

            [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
            private static void longpress_abort(System.IntPtr obj, System.IntPtr pd, uint button)
            {
                CoreUI.DataTypes.Log.Debug("function efl_input_clickable_longpress_abort was called");
                var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
                if (ws != null)
                {
                    
                    try
                    {
                        ((Image)ws.Target).LongpressAbort(button);
                    }
                    catch (Exception e)
                    {
                        CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                        CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                    }

                    
                }
                else
                {
                    efl_input_clickable_longpress_abort_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), button);
                }
            }

            private static efl_input_clickable_longpress_abort_delegate efl_input_clickable_longpress_abort_static_delegate;

            
            private delegate void efl_layout_calc_force_delegate(System.IntPtr obj, System.IntPtr pd);

            
            internal delegate void efl_layout_calc_force_api_delegate(System.IntPtr obj);

            internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_layout_calc_force_api_delegate> efl_layout_calc_force_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_layout_calc_force_api_delegate>(Module, "efl_layout_calc_force");

            [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
            private static void calc_force(System.IntPtr obj, System.IntPtr pd)
            {
                CoreUI.DataTypes.Log.Debug("function efl_layout_calc_force was called");
                var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
                if (ws != null)
                {
                    
                    try
                    {
                        ((Image)ws.Target).CalcForce();
                    }
                    catch (Exception e)
                    {
                        CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                        CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                    }

                    
                }
                else
                {
                    efl_layout_calc_force_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)));
                }
            }

            private static efl_layout_calc_force_delegate efl_layout_calc_force_static_delegate;

            #pragma warning restore CA1707, CS1591, SA1300, SA1600

        }
    }
}

namespace CoreUI.UI {
#pragma warning disable CS1591
    /// <since_tizen> 6 </since_tizen>
    public static class ImageExtensions {
        /// <since_tizen> 6 </since_tizen>
        public static CoreUI.BindableProperty<System.String> Icon<T>(this CoreUI.UI.IGenericFactoryExtended<T> fac, CoreUI.Csharp.ExtensionTag<CoreUI.UI.Image, T>magic = null) where T : CoreUI.UI.Image {
            return new CoreUI.BindableProperty<System.String>("icon", fac.GetPropBind());
        }

        /// <since_tizen> 6 </since_tizen>
        public static CoreUI.BindableProperty<CoreUI.DataTypes.File> Mmap<T>(this CoreUI.UI.IGenericFactoryExtended<T> fac, CoreUI.Csharp.ExtensionTag<CoreUI.UI.Image, T>magic = null) where T : CoreUI.UI.Image {
            return new CoreUI.BindableProperty<CoreUI.DataTypes.File>("mmap", fac.GetPropBind());
        }

        /// <since_tizen> 6 </since_tizen>
        public static CoreUI.BindableProperty<System.String> File<T>(this CoreUI.UI.IGenericFactoryExtended<T> fac, CoreUI.Csharp.ExtensionTag<CoreUI.UI.Image, T>magic = null) where T : CoreUI.UI.Image {
            return new CoreUI.BindableProperty<System.String>("file", fac.GetPropBind());
        }

        /// <since_tizen> 6 </since_tizen>
        public static CoreUI.BindableProperty<System.String> Key<T>(this CoreUI.UI.IGenericFactoryExtended<T> fac, CoreUI.Csharp.ExtensionTag<CoreUI.UI.Image, T>magic = null) where T : CoreUI.UI.Image {
            return new CoreUI.BindableProperty<System.String>("key", fac.GetPropBind());
        }

        /// <since_tizen> 6 </since_tizen>
        public static CoreUI.BindableProperty<bool> Playing<T>(this CoreUI.UI.IGenericFactoryExtended<T> fac, CoreUI.Csharp.ExtensionTag<CoreUI.UI.Image, T>magic = null) where T : CoreUI.UI.Image {
            return new CoreUI.BindableProperty<bool>("playing", fac.GetPropBind());
        }

        /// <since_tizen> 6 </since_tizen>
        public static CoreUI.BindableProperty<bool> Paused<T>(this CoreUI.UI.IGenericFactoryExtended<T> fac, CoreUI.Csharp.ExtensionTag<CoreUI.UI.Image, T>magic = null) where T : CoreUI.UI.Image {
            return new CoreUI.BindableProperty<bool>("paused", fac.GetPropBind());
        }

        /// <since_tizen> 6 </since_tizen>
        public static CoreUI.BindableProperty<double> PlaybackPosition<T>(this CoreUI.UI.IGenericFactoryExtended<T> fac, CoreUI.Csharp.ExtensionTag<CoreUI.UI.Image, T>magic = null) where T : CoreUI.UI.Image {
            return new CoreUI.BindableProperty<double>("playback_position", fac.GetPropBind());
        }

        /// <since_tizen> 6 </since_tizen>
        public static CoreUI.BindableProperty<double> PlaybackProgress<T>(this CoreUI.UI.IGenericFactoryExtended<T> fac, CoreUI.Csharp.ExtensionTag<CoreUI.UI.Image, T>magic = null) where T : CoreUI.UI.Image {
            return new CoreUI.BindableProperty<double>("playback_progress", fac.GetPropBind());
        }

        /// <since_tizen> 6 </since_tizen>
        public static CoreUI.BindableProperty<double> PlaybackSpeed<T>(this CoreUI.UI.IGenericFactoryExtended<T> fac, CoreUI.Csharp.ExtensionTag<CoreUI.UI.Image, T>magic = null) where T : CoreUI.UI.Image {
            return new CoreUI.BindableProperty<double>("playback_speed", fac.GetPropBind());
        }

        /// <since_tizen> 6 </since_tizen>
        public static CoreUI.BindableProperty<bool> Autoplay<T>(this CoreUI.UI.IGenericFactoryExtended<T> fac, CoreUI.Csharp.ExtensionTag<CoreUI.UI.Image, T>magic = null) where T : CoreUI.UI.Image {
            return new CoreUI.BindableProperty<bool>("autoplay", fac.GetPropBind());
        }

        /// <since_tizen> 6 </since_tizen>
        public static CoreUI.BindableProperty<bool> PlaybackLoop<T>(this CoreUI.UI.IGenericFactoryExtended<T> fac, CoreUI.Csharp.ExtensionTag<CoreUI.UI.Image, T>magic = null) where T : CoreUI.UI.Image {
            return new CoreUI.BindableProperty<bool>("playback_loop", fac.GetPropBind());
        }

        /// <since_tizen> 6 </since_tizen>
        public static CoreUI.BindableProperty<bool> SmoothScale<T>(this CoreUI.UI.IGenericFactoryExtended<T> fac, CoreUI.Csharp.ExtensionTag<CoreUI.UI.Image, T>magic = null) where T : CoreUI.UI.Image {
            return new CoreUI.BindableProperty<bool>("smooth_scale", fac.GetPropBind());
        }

        /// <since_tizen> 6 </since_tizen>
        public static CoreUI.BindableProperty<CoreUI.Gfx.ImageScaleMethod> ScaleMethod<T>(this CoreUI.UI.IGenericFactoryExtended<T> fac, CoreUI.Csharp.ExtensionTag<CoreUI.UI.Image, T>magic = null) where T : CoreUI.UI.Image {
            return new CoreUI.BindableProperty<CoreUI.Gfx.ImageScaleMethod>("scale_method", fac.GetPropBind());
        }

        /// <since_tizen> 6 </since_tizen>
        public static CoreUI.BindableProperty<bool> CanUpscale<T>(this CoreUI.UI.IGenericFactoryExtended<T> fac, CoreUI.Csharp.ExtensionTag<CoreUI.UI.Image, T>magic = null) where T : CoreUI.UI.Image {
            return new CoreUI.BindableProperty<bool>("can_upscale", fac.GetPropBind());
        }

        /// <since_tizen> 6 </since_tizen>
        public static CoreUI.BindableProperty<bool> CanDownscale<T>(this CoreUI.UI.IGenericFactoryExtended<T> fac, CoreUI.Csharp.ExtensionTag<CoreUI.UI.Image, T>magic = null) where T : CoreUI.UI.Image {
            return new CoreUI.BindableProperty<bool>("can_downscale", fac.GetPropBind());
        }

        /// <since_tizen> 6 </since_tizen>
        public static CoreUI.BindableProperty<double> BorderInsetsScale<T>(this CoreUI.UI.IGenericFactoryExtended<T> fac, CoreUI.Csharp.ExtensionTag<CoreUI.UI.Image, T>magic = null) where T : CoreUI.UI.Image {
            return new CoreUI.BindableProperty<double>("border_insets_scale", fac.GetPropBind());
        }

        /// <since_tizen> 6 </since_tizen>
        public static CoreUI.BindableProperty<CoreUI.Gfx.CenterFillMode> CenterFillMode<T>(this CoreUI.UI.IGenericFactoryExtended<T> fac, CoreUI.Csharp.ExtensionTag<CoreUI.UI.Image, T>magic = null) where T : CoreUI.UI.Image {
            return new CoreUI.BindableProperty<CoreUI.Gfx.CenterFillMode>("center_fill_mode", fac.GetPropBind());
        }

        /// <since_tizen> 6 </since_tizen>
        public static CoreUI.BindableProperty<CoreUI.Gfx.ImageContentHint> ContentHint<T>(this CoreUI.UI.IGenericFactoryExtended<T> fac, CoreUI.Csharp.ExtensionTag<CoreUI.UI.Image, T>magic = null) where T : CoreUI.UI.Image {
            return new CoreUI.BindableProperty<CoreUI.Gfx.ImageContentHint>("content_hint", fac.GetPropBind());
        }

        /// <since_tizen> 6 </since_tizen>
        public static CoreUI.BindableProperty<CoreUI.Gfx.ImageScaleHint> ScaleHint<T>(this CoreUI.UI.IGenericFactoryExtended<T> fac, CoreUI.Csharp.ExtensionTag<CoreUI.UI.Image, T>magic = null) where T : CoreUI.UI.Image {
            return new CoreUI.BindableProperty<CoreUI.Gfx.ImageScaleHint>("scale_hint", fac.GetPropBind());
        }

        /// <since_tizen> 6 </since_tizen>
        public static CoreUI.BindableProperty<CoreUI.DataTypes.Size2D> LoadSize<T>(this CoreUI.UI.IGenericFactoryExtended<T> fac, CoreUI.Csharp.ExtensionTag<CoreUI.UI.Image, T>magic = null) where T : CoreUI.UI.Image {
            return new CoreUI.BindableProperty<CoreUI.DataTypes.Size2D>("load_size", fac.GetPropBind());
        }

        /// <since_tizen> 6 </since_tizen>
        public static CoreUI.BindableProperty<double> LoadDpi<T>(this CoreUI.UI.IGenericFactoryExtended<T> fac, CoreUI.Csharp.ExtensionTag<CoreUI.UI.Image, T>magic = null) where T : CoreUI.UI.Image {
            return new CoreUI.BindableProperty<double>("load_dpi", fac.GetPropBind());
        }

        /// <since_tizen> 6 </since_tizen>
        public static CoreUI.BindableProperty<CoreUI.DataTypes.Rect> LoadRegion<T>(this CoreUI.UI.IGenericFactoryExtended<T> fac, CoreUI.Csharp.ExtensionTag<CoreUI.UI.Image, T>magic = null) where T : CoreUI.UI.Image {
            return new CoreUI.BindableProperty<CoreUI.DataTypes.Rect>("load_region", fac.GetPropBind());
        }

        /// <since_tizen> 6 </since_tizen>
        public static CoreUI.BindableProperty<bool> LoadOrientation<T>(this CoreUI.UI.IGenericFactoryExtended<T> fac, CoreUI.Csharp.ExtensionTag<CoreUI.UI.Image, T>magic = null) where T : CoreUI.UI.Image {
            return new CoreUI.BindableProperty<bool>("load_orientation", fac.GetPropBind());
        }

        /// <since_tizen> 6 </since_tizen>
        public static CoreUI.BindableProperty<int> LoadScaleDown<T>(this CoreUI.UI.IGenericFactoryExtended<T> fac, CoreUI.Csharp.ExtensionTag<CoreUI.UI.Image, T>magic = null) where T : CoreUI.UI.Image {
            return new CoreUI.BindableProperty<int>("load_scale_down", fac.GetPropBind());
        }

        /// <since_tizen> 6 </since_tizen>
        public static CoreUI.BindableProperty<bool> LoadSkipHeader<T>(this CoreUI.UI.IGenericFactoryExtended<T> fac, CoreUI.Csharp.ExtensionTag<CoreUI.UI.Image, T>magic = null) where T : CoreUI.UI.Image {
            return new CoreUI.BindableProperty<bool>("load_skip_header", fac.GetPropBind());
        }

        /// <since_tizen> 6 </since_tizen>
        public static CoreUI.BindableProperty<CoreUI.Gfx.ImageOrientation> ImageOrientation<T>(this CoreUI.UI.IGenericFactoryExtended<T> fac, CoreUI.Csharp.ExtensionTag<CoreUI.UI.Image, T>magic = null) where T : CoreUI.UI.Image {
            return new CoreUI.BindableProperty<CoreUI.Gfx.ImageOrientation>("image_orientation", fac.GetPropBind());
        }

        /// <since_tizen> 6 </since_tizen>
        public static CoreUI.BindableProperty<bool> CalcAutoUpdateHints<T>(this CoreUI.UI.IGenericFactoryExtended<T> fac, CoreUI.Csharp.ExtensionTag<CoreUI.UI.Image, T>magic = null) where T : CoreUI.UI.Image {
            return new CoreUI.BindableProperty<bool>("calc_auto_update_hints", fac.GetPropBind());
        }

    }
#pragma warning restore CS1591
}

