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
    /// <summary>Interface used by widgets which can display scrollbars, enabling them to hold more content than actually visible through the viewport. A scrollbar contains a draggable part (thumb) which allows the user to move the viewport around the content. The size of the thumb relates to the size of the viewport compared to the whole content.</summary>
    /// <since_tizen> 6 </since_tizen>
    [CoreUI.UI.IScrollBarNativeMethods]
    [CoreUI.Wrapper.BindingEntity]
    public interface IScrollBar : 
        CoreUI.Wrapper.IWrapper, IDisposable
    {
        /// <summary>ScrollBar visibility mode, for each of the scrollbars.</summary>
        /// <param name="hbar">Horizontal scrollbar mode.<br/>The default value is <see cref="CoreUI.UI.ScrollBarMode.Auto"/>.</param>
        /// <param name="vbar">Vertical scrollbar mode.<br/>The default value is <see cref="CoreUI.UI.ScrollBarMode.Auto"/>.</param>
        /// <since_tizen> 6 </since_tizen>
        void GetBarMode(out CoreUI.UI.ScrollBarMode hbar, out CoreUI.UI.ScrollBarMode vbar);

        /// <summary>ScrollBar visibility mode, for each of the scrollbars.</summary>
        /// <param name="hbar">Horizontal scrollbar mode.<br/>The default value is <see cref="CoreUI.UI.ScrollBarMode.Auto"/>.</param>
        /// <param name="vbar">Vertical scrollbar mode.<br/>The default value is <see cref="CoreUI.UI.ScrollBarMode.Auto"/>.</param>
        /// <since_tizen> 6 </since_tizen>
        void SetBarMode(CoreUI.UI.ScrollBarMode hbar, CoreUI.UI.ScrollBarMode vbar);

        /// <summary>This returns the relative size the thumb should have, given the current size of the viewport and the content. <c>0.0</c> means the viewport is much smaller than the content: the thumb will have its minimum size. <c>1.0</c> means the viewport has the same size as the content (or bigger): the thumb will have the same size as the scrollbar and cannot move.</summary>
        /// <param name="width">Value between <c>0.0</c> and <c>1.0</c>.</param>
        /// <param name="height">Value between <c>0.0</c> and <c>1.0</c>.</param>
        /// <since_tizen> 6 </since_tizen>
        void GetBarSize(out double width, out double height);

        /// <summary>Position of the thumb (the draggable zone) inside the scrollbar. It is calculated based on current position of the viewport inside the total content.</summary>
        /// <param name="posx">Value between <c>0.0</c> (the left side of the thumb is touching the left edge of the widget) and <c>1.0</c> (the right side of the thumb is touching the right edge of the widget).</param>
        /// <param name="posy">Value between <c>0.0</c> (the top side of the thumb is touching the top edge of the widget) and <c>1.0</c> (the bottom side of the thumb is touching the bottom edge of the widget).</param>
        /// <since_tizen> 6 </since_tizen>
        void GetBarPosition(out double posx, out double posy);

        /// <summary>Position of the thumb (the draggable zone) inside the scrollbar. It is calculated based on current position of the viewport inside the total content.</summary>
        /// <param name="posx">Value between <c>0.0</c> (the left side of the thumb is touching the left edge of the widget) and <c>1.0</c> (the right side of the thumb is touching the right edge of the widget).</param>
        /// <param name="posy">Value between <c>0.0</c> (the top side of the thumb is touching the top edge of the widget) and <c>1.0</c> (the bottom side of the thumb is touching the bottom edge of the widget).</param>
        /// <since_tizen> 6 </since_tizen>
        void SetBarPosition(double posx, double posy);

        /// <summary>Current visibility state of the scrollbars. This is useful in <see cref="CoreUI.UI.ScrollBarMode.Auto"/> mode where EFL decides if the scrollbars are shown or hidden. See also the @[.bar,show] and @[.bar,hide] events.</summary>
        /// <param name="hbar">Whether the horizontal scrollbar is currently visible.</param>
        /// <param name="vbar">Whether the vertical scrollbar is currently visible.</param>
        /// <since_tizen> 6 </since_tizen>
        void GetBarVisibility(out bool hbar, out bool vbar);

        /// <summary>Emitted when thumb is pressed.</summary>
        /// <since_tizen> 6 </since_tizen>
        /// <value><see cref="CoreUI.UI.ScrollBarBarPressedEventArgs"/></value>
        event EventHandler<CoreUI.UI.ScrollBarBarPressedEventArgs> BarPressed;
        /// <summary>Emitted when thumb is unpressed.</summary>
        /// <since_tizen> 6 </since_tizen>
        /// <value><see cref="CoreUI.UI.ScrollBarBarUnpressedEventArgs"/></value>
        event EventHandler<CoreUI.UI.ScrollBarBarUnpressedEventArgs> BarUnpressed;
        /// <summary>Emitted when thumb is dragged.</summary>
        /// <since_tizen> 6 </since_tizen>
        /// <value><see cref="CoreUI.UI.ScrollBarBarDraggedEventArgs"/></value>
        event EventHandler<CoreUI.UI.ScrollBarBarDraggedEventArgs> BarDragged;
        /// <summary>Emitted when thumb size has changed.</summary>
        /// <since_tizen> 6 </since_tizen>
        event EventHandler BarSizeChanged;
        /// <summary>Emitted when thumb position has changed.</summary>
        /// <since_tizen> 6 </since_tizen>
        event EventHandler BarPosChanged;
        /// <summary>Emitted when scrollbar is shown.</summary>
        /// <since_tizen> 6 </since_tizen>
        /// <value><see cref="CoreUI.UI.ScrollBarBarShowEventArgs"/></value>
        event EventHandler<CoreUI.UI.ScrollBarBarShowEventArgs> BarShow;
        /// <summary>Emitted when scrollbar is hidden.</summary>
        /// <since_tizen> 6 </since_tizen>
        /// <value><see cref="CoreUI.UI.ScrollBarBarHideEventArgs"/></value>
        event EventHandler<CoreUI.UI.ScrollBarBarHideEventArgs> BarHide;
        /// <summary>ScrollBar visibility mode, for each of the scrollbars.</summary>
        /// <value>Horizontal scrollbar mode.</value>
        /// <since_tizen> 6 </since_tizen>
        (CoreUI.UI.ScrollBarMode, CoreUI.UI.ScrollBarMode) BarMode {
            get;
            set;
        }

        /// <summary>This returns the relative size the thumb should have, given the current size of the viewport and the content. <c>0.0</c> means the viewport is much smaller than the content: the thumb will have its minimum size. <c>1.0</c> means the viewport has the same size as the content (or bigger): the thumb will have the same size as the scrollbar and cannot move.</summary>
        /// <since_tizen> 6 </since_tizen>
        (double, double) BarSize {
            get;
        }

        /// <summary>Position of the thumb (the draggable zone) inside the scrollbar. It is calculated based on current position of the viewport inside the total content.</summary>
        /// <value>Value between <c>0.0</c> (the left side of the thumb is touching the left edge of the widget) and <c>1.0</c> (the right side of the thumb is touching the right edge of the widget).</value>
        /// <since_tizen> 6 </since_tizen>
        (double, double) BarPosition {
            get;
            set;
        }

        /// <summary>Current visibility state of the scrollbars. This is useful in <see cref="CoreUI.UI.ScrollBarMode.Auto"/> mode where EFL decides if the scrollbars are shown or hidden. See also the @[.bar,show] and @[.bar,hide] events.</summary>
        /// <since_tizen> 6 </since_tizen>
        (bool, bool) BarVisibility {
            get;
        }

    }

    /// <summary>Event argument wrapper for event <see cref="CoreUI.UI.IScrollBar.BarPressed"/>.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    [CoreUI.Wrapper.BindingEntity]
    public class ScrollBarBarPressedEventArgs : EventArgs {
        /// <summary>Actual event payload.
        /// </summary>
        /// <value>Emitted when thumb is pressed.</value>
        /// <since_tizen> 6 </since_tizen>
        public CoreUI.UI.LayoutOrientation Arg { get; set; }
    }

    /// <summary>Event argument wrapper for event <see cref="CoreUI.UI.IScrollBar.BarUnpressed"/>.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    [CoreUI.Wrapper.BindingEntity]
    public class ScrollBarBarUnpressedEventArgs : EventArgs {
        /// <summary>Actual event payload.
        /// </summary>
        /// <value>Emitted when thumb is unpressed.</value>
        /// <since_tizen> 6 </since_tizen>
        public CoreUI.UI.LayoutOrientation Arg { get; set; }
    }

    /// <summary>Event argument wrapper for event <see cref="CoreUI.UI.IScrollBar.BarDragged"/>.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    [CoreUI.Wrapper.BindingEntity]
    public class ScrollBarBarDraggedEventArgs : EventArgs {
        /// <summary>Actual event payload.
        /// </summary>
        /// <value>Emitted when thumb is dragged.</value>
        /// <since_tizen> 6 </since_tizen>
        public CoreUI.UI.LayoutOrientation Arg { get; set; }
    }

    /// <summary>Event argument wrapper for event <see cref="CoreUI.UI.IScrollBar.BarShow"/>.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    [CoreUI.Wrapper.BindingEntity]
    public class ScrollBarBarShowEventArgs : EventArgs {
        /// <summary>Actual event payload.
        /// </summary>
        /// <value>Emitted when scrollbar is shown.</value>
        /// <since_tizen> 6 </since_tizen>
        public CoreUI.UI.LayoutOrientation Arg { get; set; }
    }

    /// <summary>Event argument wrapper for event <see cref="CoreUI.UI.IScrollBar.BarHide"/>.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    [CoreUI.Wrapper.BindingEntity]
    public class ScrollBarBarHideEventArgs : EventArgs {
        /// <summary>Actual event payload.
        /// </summary>
        /// <value>Emitted when scrollbar is hidden.</value>
        /// <since_tizen> 6 </since_tizen>
        public CoreUI.UI.LayoutOrientation Arg { get; set; }
    }

    /// <summary>Wrapper for native methods and virtual method delegates.
    /// For internal use by generated code only.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    internal class IScrollBarNativeMethods : CoreUI.Wrapper.ObjectWrapper.NativeMethods
    {
        [System.Runtime.InteropServices.DllImport("libefl.so.1")] internal static extern System.IntPtr
            efl_ui_scrollbar_interface_get();
        private static CoreUI.Wrapper.NativeModule Module = new CoreUI.Wrapper.NativeModule(CoreUI.Libs.CoreUI);

        /// <summary>Gets the list of Eo operations to override.
    /// </summary>
        /// <returns>The list of Eo operations to be overload.</returns>
        internal override System.Collections.Generic.List<CoreUIOpDescription> GetEoOps(System.Type type, bool includeInherited)
        {
            var descs = new System.Collections.Generic.List<CoreUIOpDescription>();
            var methods = CoreUI.Wrapper.Globals.GetUserMethods(type);

            if (efl_ui_scrollbar_bar_mode_get_static_delegate == null)
            {
                efl_ui_scrollbar_bar_mode_get_static_delegate = new efl_ui_scrollbar_bar_mode_get_delegate(bar_mode_get);
            }

            if (methods.Contains("GetBarMode"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_scrollbar_bar_mode_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_scrollbar_bar_mode_get_static_delegate) });
            }

            if (efl_ui_scrollbar_bar_mode_set_static_delegate == null)
            {
                efl_ui_scrollbar_bar_mode_set_static_delegate = new efl_ui_scrollbar_bar_mode_set_delegate(bar_mode_set);
            }

            if (methods.Contains("SetBarMode"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_scrollbar_bar_mode_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_scrollbar_bar_mode_set_static_delegate) });
            }

            if (efl_ui_scrollbar_bar_size_get_static_delegate == null)
            {
                efl_ui_scrollbar_bar_size_get_static_delegate = new efl_ui_scrollbar_bar_size_get_delegate(bar_size_get);
            }

            if (methods.Contains("GetBarSize"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_scrollbar_bar_size_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_scrollbar_bar_size_get_static_delegate) });
            }

            if (efl_ui_scrollbar_bar_position_get_static_delegate == null)
            {
                efl_ui_scrollbar_bar_position_get_static_delegate = new efl_ui_scrollbar_bar_position_get_delegate(bar_position_get);
            }

            if (methods.Contains("GetBarPosition"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_scrollbar_bar_position_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_scrollbar_bar_position_get_static_delegate) });
            }

            if (efl_ui_scrollbar_bar_position_set_static_delegate == null)
            {
                efl_ui_scrollbar_bar_position_set_static_delegate = new efl_ui_scrollbar_bar_position_set_delegate(bar_position_set);
            }

            if (methods.Contains("SetBarPosition"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_scrollbar_bar_position_set"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_scrollbar_bar_position_set_static_delegate) });
            }

            if (efl_ui_scrollbar_bar_visibility_get_static_delegate == null)
            {
                efl_ui_scrollbar_bar_visibility_get_static_delegate = new efl_ui_scrollbar_bar_visibility_get_delegate(bar_visibility_get);
            }

            if (methods.Contains("GetBarVisibility"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_ui_scrollbar_bar_visibility_get"), func = Marshal.GetFunctionPointerForDelegate(efl_ui_scrollbar_bar_visibility_get_static_delegate) });
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
            return descs;
        }

        /// <summary>Returns the Eo class for the native methods of this class.
        /// </summary>
        /// <returns>The native class pointer.</returns>
        internal override IntPtr GetCoreUIClass()
        {
            return efl_ui_scrollbar_interface_get();
        }

        #pragma warning disable CA1707, CS1591, SA1300, SA1600

        
        private delegate void efl_ui_scrollbar_bar_mode_get_delegate(System.IntPtr obj, System.IntPtr pd,  out CoreUI.UI.ScrollBarMode hbar,  out CoreUI.UI.ScrollBarMode vbar);

        
        internal delegate void efl_ui_scrollbar_bar_mode_get_api_delegate(System.IntPtr obj,  out CoreUI.UI.ScrollBarMode hbar,  out CoreUI.UI.ScrollBarMode vbar);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_ui_scrollbar_bar_mode_get_api_delegate> efl_ui_scrollbar_bar_mode_get_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_ui_scrollbar_bar_mode_get_api_delegate>(Module, "efl_ui_scrollbar_bar_mode_get");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static void bar_mode_get(System.IntPtr obj, System.IntPtr pd, out CoreUI.UI.ScrollBarMode hbar, out CoreUI.UI.ScrollBarMode vbar)
        {
            CoreUI.DataTypes.Log.Debug("function efl_ui_scrollbar_bar_mode_get was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                hbar = default(CoreUI.UI.ScrollBarMode);vbar = default(CoreUI.UI.ScrollBarMode);
                try
                {
                    ((IScrollBar)ws.Target).GetBarMode(out hbar, out vbar);
                }
                catch (Exception e)
                {
                    CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                    CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                }

                
            }
            else
            {
                efl_ui_scrollbar_bar_mode_get_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), out hbar, out vbar);
            }
        }

        private static efl_ui_scrollbar_bar_mode_get_delegate efl_ui_scrollbar_bar_mode_get_static_delegate;

        
        private delegate void efl_ui_scrollbar_bar_mode_set_delegate(System.IntPtr obj, System.IntPtr pd,  CoreUI.UI.ScrollBarMode hbar,  CoreUI.UI.ScrollBarMode vbar);

        
        internal delegate void efl_ui_scrollbar_bar_mode_set_api_delegate(System.IntPtr obj,  CoreUI.UI.ScrollBarMode hbar,  CoreUI.UI.ScrollBarMode vbar);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_ui_scrollbar_bar_mode_set_api_delegate> efl_ui_scrollbar_bar_mode_set_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_ui_scrollbar_bar_mode_set_api_delegate>(Module, "efl_ui_scrollbar_bar_mode_set");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static void bar_mode_set(System.IntPtr obj, System.IntPtr pd, CoreUI.UI.ScrollBarMode hbar, CoreUI.UI.ScrollBarMode vbar)
        {
            CoreUI.DataTypes.Log.Debug("function efl_ui_scrollbar_bar_mode_set was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                
                try
                {
                    ((IScrollBar)ws.Target).SetBarMode(hbar, vbar);
                }
                catch (Exception e)
                {
                    CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                    CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                }

                
            }
            else
            {
                efl_ui_scrollbar_bar_mode_set_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), hbar, vbar);
            }
        }

        private static efl_ui_scrollbar_bar_mode_set_delegate efl_ui_scrollbar_bar_mode_set_static_delegate;

        
        private delegate void efl_ui_scrollbar_bar_size_get_delegate(System.IntPtr obj, System.IntPtr pd,  out double width,  out double height);

        
        internal delegate void efl_ui_scrollbar_bar_size_get_api_delegate(System.IntPtr obj,  out double width,  out double height);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_ui_scrollbar_bar_size_get_api_delegate> efl_ui_scrollbar_bar_size_get_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_ui_scrollbar_bar_size_get_api_delegate>(Module, "efl_ui_scrollbar_bar_size_get");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static void bar_size_get(System.IntPtr obj, System.IntPtr pd, out double width, out double height)
        {
            CoreUI.DataTypes.Log.Debug("function efl_ui_scrollbar_bar_size_get was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                width = default(double);height = default(double);
                try
                {
                    ((IScrollBar)ws.Target).GetBarSize(out width, out height);
                }
                catch (Exception e)
                {
                    CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                    CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                }

                
            }
            else
            {
                efl_ui_scrollbar_bar_size_get_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), out width, out height);
            }
        }

        private static efl_ui_scrollbar_bar_size_get_delegate efl_ui_scrollbar_bar_size_get_static_delegate;

        
        private delegate void efl_ui_scrollbar_bar_position_get_delegate(System.IntPtr obj, System.IntPtr pd,  out double posx,  out double posy);

        
        internal delegate void efl_ui_scrollbar_bar_position_get_api_delegate(System.IntPtr obj,  out double posx,  out double posy);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_ui_scrollbar_bar_position_get_api_delegate> efl_ui_scrollbar_bar_position_get_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_ui_scrollbar_bar_position_get_api_delegate>(Module, "efl_ui_scrollbar_bar_position_get");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static void bar_position_get(System.IntPtr obj, System.IntPtr pd, out double posx, out double posy)
        {
            CoreUI.DataTypes.Log.Debug("function efl_ui_scrollbar_bar_position_get was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                posx = default(double);posy = default(double);
                try
                {
                    ((IScrollBar)ws.Target).GetBarPosition(out posx, out posy);
                }
                catch (Exception e)
                {
                    CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                    CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                }

                
            }
            else
            {
                efl_ui_scrollbar_bar_position_get_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), out posx, out posy);
            }
        }

        private static efl_ui_scrollbar_bar_position_get_delegate efl_ui_scrollbar_bar_position_get_static_delegate;

        
        private delegate void efl_ui_scrollbar_bar_position_set_delegate(System.IntPtr obj, System.IntPtr pd,  double posx,  double posy);

        
        internal delegate void efl_ui_scrollbar_bar_position_set_api_delegate(System.IntPtr obj,  double posx,  double posy);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_ui_scrollbar_bar_position_set_api_delegate> efl_ui_scrollbar_bar_position_set_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_ui_scrollbar_bar_position_set_api_delegate>(Module, "efl_ui_scrollbar_bar_position_set");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static void bar_position_set(System.IntPtr obj, System.IntPtr pd, double posx, double posy)
        {
            CoreUI.DataTypes.Log.Debug("function efl_ui_scrollbar_bar_position_set was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                
                try
                {
                    ((IScrollBar)ws.Target).SetBarPosition(posx, posy);
                }
                catch (Exception e)
                {
                    CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                    CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                }

                
            }
            else
            {
                efl_ui_scrollbar_bar_position_set_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), posx, posy);
            }
        }

        private static efl_ui_scrollbar_bar_position_set_delegate efl_ui_scrollbar_bar_position_set_static_delegate;

        
        private delegate void efl_ui_scrollbar_bar_visibility_get_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.U1)] out bool hbar, [MarshalAs(UnmanagedType.U1)] out bool vbar);

        
        internal delegate void efl_ui_scrollbar_bar_visibility_get_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.U1)] out bool hbar, [MarshalAs(UnmanagedType.U1)] out bool vbar);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_ui_scrollbar_bar_visibility_get_api_delegate> efl_ui_scrollbar_bar_visibility_get_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_ui_scrollbar_bar_visibility_get_api_delegate>(Module, "efl_ui_scrollbar_bar_visibility_get");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static void bar_visibility_get(System.IntPtr obj, System.IntPtr pd, out bool hbar, out bool vbar)
        {
            CoreUI.DataTypes.Log.Debug("function efl_ui_scrollbar_bar_visibility_get was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                hbar = default(bool);vbar = default(bool);
                try
                {
                    ((IScrollBar)ws.Target).GetBarVisibility(out hbar, out vbar);
                }
                catch (Exception e)
                {
                    CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                    CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                }

                
            }
            else
            {
                efl_ui_scrollbar_bar_visibility_get_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), out hbar, out vbar);
            }
        }

        private static efl_ui_scrollbar_bar_visibility_get_delegate efl_ui_scrollbar_bar_visibility_get_static_delegate;

        #pragma warning restore CA1707, CS1591, SA1300, SA1600

    }
}

namespace CoreUI.UI {
    /// <summary>When should the scrollbar be shown.</summary>
    /// <since_tizen> 6 </since_tizen>
    
    [CoreUI.Wrapper.BindingEntity]
    public enum ScrollBarMode
    {
        /// <summary>Visible if necessary.</summary>
        /// <since_tizen> 6 </since_tizen>
        Auto = 0,
        /// <summary>Always visible.</summary>
        /// <since_tizen> 6 </since_tizen>
        On = 1,
        /// <summary>Always invisible.</summary>
        /// <since_tizen> 6 </since_tizen>
        Off = 2,
        /// <summary>For internal use only.</summary>
        /// <since_tizen> 6 </since_tizen>
        Last = 3,
    }
}

