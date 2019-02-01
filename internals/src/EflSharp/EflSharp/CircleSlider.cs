/*
 * Copyright (c) 2016 Samsung Electronics Co., Ltd All Rights Reserved
 *
 * Licensed under the Apache License, Version 2.0 (the License);
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 * http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an AS IS BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

using System;
using System.ComponentModel;
using System.Diagnostics;

namespace Efl
{
    namespace Ui
    {
        namespace Wearable
        {
            /// <summary>
            /// Circle slider is a circular designed widget used to select a value in a range by the Rotary event.
            /// </summary>
            /// <since_tizen> preview </since_tizen>
            public class CircleSlider : Efl.Ui.Layout, ICircleWidget
            {
                CircleSurface _surface;
                IntPtr _handle;

                public string key = "value,changed";
                
                private static object ChangedEvtKey = new object();
                
                protected bool add_native_event_handler(Efl.EventCb evt_delegate)
                {
                    int event_count = 0;
                    if (!event_cb_count.TryGetValue(key, out event_count))
                        event_cb_count[key] = event_count;
                    if (event_count == 0)
                    {
                        IntPtr desc = Efl.Eo.Globals.efl_object_legacy_only_event_description_get(key);
                        if (desc == IntPtr.Zero)
                        {
                            Eina.Log.Error($"Failed to get native event {key}");
                            return false;
                        }
                        
                        bool result = Efl.Eo.Globals.efl_event_callback_priority_add(_handle, desc, 0, evt_delegate, System.IntPtr.Zero);
                        if (!result)
                        {
                            Eina.Log.Error($"Failed to add event proxy for event {key}");
                            return false;
                        }
                        Eina.Error.RaiseIfUnhandledException();
                    }
                    event_cb_count[key]++;
                    return true;
                }
                protected bool remove_native_event_handler(Efl.EventCb evt_delegate)
                {
                    int event_count = 0;
                    if (!event_cb_count.TryGetValue(key, out event_count))
                        event_cb_count[key] = event_count;
                    if (event_count == 1)
                    {
                        IntPtr desc = Efl.Eo.Globals.efl_object_legacy_only_event_description_get(key);
                        if (desc == IntPtr.Zero)
                        {
                            Eina.Log.Error($"Failed to get native event {key}");
                            return false;
                        }
                        bool result = Efl.Eo.Globals.efl_event_callback_del(_handle, desc, evt_delegate, System.IntPtr.Zero);
                        if (!result)
                        {
                            Eina.Log.Error($"Failed to remove event proxy for event {key}");
                            return false;
                        }
                        Eina.Error.RaiseIfUnhandledException();
                    }
                    else if (event_count == 0)
                    {
                        Eina.Log.Error($"Trying to remove proxy for event {key} when there is nothing registered.");
                        return false;
                    }
                    event_cb_count[key]--;
                    return true;
                }

                /// <summary>Called when slider changed</summary>
                public event EventHandler ChangedEvt
                {
                    add
                    {
                        lock (eventLock)
                        {
                            if (add_native_event_handler(this.evt_ChangedEvt_delegate))
                            {
                                eventHandlers.AddHandler(ChangedEvtKey, value);
                            }
                            else
                                Eina.Log.Error($"Error adding proxy for event {key}");
                        }
                    }
                    remove
                    {
                        lock (eventLock)
                        {
                            if (remove_native_event_handler(this.evt_ChangedEvt_delegate))
                            {
                                eventHandlers.RemoveHandler(ChangedEvtKey, value);
                            }
                            else
                                Eina.Log.Error($"Error removing proxy for event {key}");
                        }
                    }
                }

                ///<summary>Method to raise event ChangedEvt.</summary>
                public void On_ChangedEvt(EventArgs e)
                {
                    EventHandler evt;
                    lock (eventLock)
                    {
                        evt = (EventHandler)eventHandlers[ChangedEvtKey];
                    }
                    evt?.Invoke(this, e);
                }
                Efl.EventCb evt_ChangedEvt_delegate;
                private void on_ChangedEvt_NativeCallback(System.IntPtr data, ref Efl.Event_StructInternal evt)
                {
                    EventArgs args = EventArgs.Empty;
                    try
                    {
                        On_ChangedEvt(args);
                    }
                    catch (Exception e)
                    {
                        Eina.Log.Error(e.ToString());
                        Eina.Error.Set(Eina.Error.UNHANDLED_EXCEPTION);
                    }
                }

                public CircleSlider(Efl.Ui.Win parent, CircleSurface surface = null) : base(parent)
                {
                    _surface = surface;
                    if (surface == null)
                    {
                        _handle = Interop.Eext.eext_circle_object_slider_add(parent.NativeHandle, IntPtr.Zero);
                    }
                    else
                    {
                        _handle = Interop.Eext.eext_circle_object_slider_add(parent.NativeHandle, CircleSurface.Handle);
                    }

                    EnrollCircleContent();
                    evt_ChangedEvt_delegate = new Efl.EventCb(on_ChangedEvt_NativeCallback);
                    //Realize(parent);
                }

                public void EnrollCircleContent()
                {
                    elm_layout_content_set(this.NativeHandle, "efl.content", CircleHandle);
                }

                public override Efl.Object FinalizeAdd()
                {
                    this.SetTheme("circle_slider", null, null);
                    return this;
                }

                [System.Runtime.InteropServices.DllImport(efl.Libs.Efl)]
                internal static extern bool efl_content_set(IntPtr obj, IntPtr content);

                [System.Runtime.InteropServices.DllImport(efl.Libs.Elementary)]
                internal static extern bool elm_layout_content_set(IntPtr obj, string swallow, IntPtr content);

                /*  (JWH) I'm not sure whether to support this.
                /// <summary>
                /// Creates and initializes a new instance of the Circle Slider class.
                /// </summary>
                /// <param name="parent">The parent of the new Circle CircleSlider instance.</param>
                /// <since_tizen> preview </since_tizen>
                [Obsolete("It is not safe for guess circle surface from parent and create new surface by every new widget")]
                [EditorBrowsable(EditorBrowsableState.Never)]
                public CircleSlider(EvasObject parent) : this(parent, CircleSurface.CreateCircleSurface(parent))
                {
                    ((IRotaryActionWidget)this).Activate();
                }
                */

                /// <summary>
                /// Gets the handle for the Circle widget.
                /// </summary>
                /// <since_tizen> preview </since_tizen>                             
                //public virtual IntPtr CircleHandle => RealHandle;   (JWH) what is this ?
                public virtual IntPtr CircleHandle => _handle;
                
                /// <summary>
                /// Gets the handle for the circle surface used in this widget.
                /// </summary>
                /// <since_tizen> preview </since_tizen>
                public virtual CircleSurface CircleSurface => _surface;

                /// <summary>
                /// Sets or gets the step by which the circle slider bar moves.
                /// </summary>
                /// <remarks>
                /// This value is used when the circle slider value is changed by a drag or the Rotary event.
                /// The value of the slider is increased/decreased by the step value.
                /// </remarks>
                /// <since_tizen> preview </since_tizen>
                public double Step
                {
                    get
                    {
                        return Interop.Eext.eext_circle_object_slider_step_get(CircleHandle);
                    }
                    set
                    {
                        Interop.Eext.eext_circle_object_slider_step_set(CircleHandle, (double)value);
                    }
                }

                public bool Disable
                {
                    get => !Enable;
                    set => Enable = !value;
                }

                /// <summary>
                /// Sets or gets the state of the widget, which might be enabled or disabled.
                /// </summary>
                /// <since_tizen> preview </since_tizen>
                public bool Enable
                {
                    get
                    {
                        return !Interop.Eext.eext_circle_object_disabled_get(CircleHandle);
                    }
                    set
                    {
                        Interop.Eext.eext_circle_object_disabled_set(CircleHandle, !value);
                    }
                }

                /// <summary>
                /// Sets or gets the color of the circle slider bar.
                /// </summary>
                /// <since_tizen> preview </since_tizen>
                public Color BarColor
                {
                    get
                    {
                        int r = 0;
                        int g = 0;
                        int b = 0;
                        int a = 0;
                        Interop.Eext.eext_circle_object_color_get(CircleHandle, out r, out g, out b, out a);
                        return Color.FromRgba(r, g, b, a);
                    }
                    set
                    {
                        Interop.Eext.eext_circle_object_color_set(CircleHandle, value.R, value.G, value.B, value.A);
                    }
                }

                /// <summary>
                /// Sets or gets the color of the circle slider background.
                /// </summary>
                /// <since_tizen> preview </since_tizen>
                public Color BackgroundColor
                {
                    get
                    {
                        int r = 0;
                        int g = 0;
                        int b = 0;
                        int a = 0;
                        Interop.Eext.eext_circle_object_item_color_get(CircleHandle, "bg", out r, out g, out b, out a);
                        return Color.FromRgba(r, g, b, a);
                    }
                    set
                    {
                        Interop.Eext.eext_circle_object_item_color_set(CircleHandle, "bg", value.R, value.G, value.B, value.A);
                    }
                }

                /// <summary>
                /// Sets or gets the line width of the circle slider bar.
                /// </summary>
                /// <since_tizen> preview </since_tizen>
                public int BarLineWidth
                {
                    get
                    {
                        return Interop.Eext.eext_circle_object_line_width_get(CircleHandle);
                    }
                    set
                    {
                        Interop.Eext.eext_circle_object_line_width_set(CircleHandle, value);
                    }
                }

                /// <summary>
                /// Sets or gets the line width of the circle slider background.
                /// </summary>
                /// <since_tizen> preview </since_tizen>
                public int BackgroundLineWidth
                {
                    get
                    {
                        return Interop.Eext.eext_circle_object_item_line_width_get(CircleHandle, "bg");
                    }
                    set
                    {
                        Interop.Eext.eext_circle_object_item_line_width_set(CircleHandle, "bg", value);
                    }
                }

                /// <summary>
                /// Sets or gets the angle in degree of the circle slider bar.
                /// </summary>
                /// <since_tizen> preview </since_tizen>
                public double BarAngle
                {
                    get
                    {
                        return Interop.Eext.eext_circle_object_angle_get(CircleHandle);
                    }
                    set
                    {
                        Interop.Eext.eext_circle_object_angle_set(CircleHandle, value);
                    }
                }

                /// <summary>
                /// Sets or gets the angle in degree of the circle slider background.
                /// </summary>
                /// <since_tizen> preview </since_tizen>
                public double BackgroundAngle
                {
                    get
                    {
                        return Interop.Eext.eext_circle_object_item_angle_get(CircleHandle, "bg");
                    }
                    set
                    {
                        Interop.Eext.eext_circle_object_item_angle_set(CircleHandle, "bg", value);
                    }
                }

                /// <summary>
                /// Sets or gets the angle offset for the slider bar.
                /// Offset value means start position of the slider bar.
                /// </summary>
                /// <since_tizen> preview </since_tizen>
                public double BarAngleOffset
                {
                    get
                    {
                        return Interop.Eext.eext_circle_object_angle_offset_get(CircleHandle);
                    }
                    set
                    {
                        Interop.Eext.eext_circle_object_angle_offset_set(CircleHandle, value);
                    }
                }

                /// <summary>
                /// Sets or gets the angle offset for the circle slider background.
                /// Offset value means start position of the slider background.
                /// </summary>
                /// <since_tizen> preview </since_tizen>
                public double BackgroundAngleOffset
                {
                    get
                    {
                        return Interop.Eext.eext_circle_object_item_angle_offset_get(CircleHandle, "bg");
                    }
                    set
                    {
                        Interop.Eext.eext_circle_object_item_angle_offset_set(CircleHandle, "bg", value);
                    }
                }

                /// <summary>
                /// Sets or gets the minimum angle of the circle slider bar.
                /// </summary>
                /// <since_tizen> preview </since_tizen>
                public double BarAngleMinimum
                {
                    get
                    {
                        double min;
                        double max;
                        Interop.Eext.eext_circle_object_angle_min_max_get(CircleHandle, out min, out max);
                        return min;
                    }
                    set
                    {
                        double max = BarAngleMaximum;
                        Interop.Eext.eext_circle_object_angle_min_max_set(CircleHandle, (double)value, max);
                    }
                }

                /// <summary>
                /// Sets or gets the maximum angle of the circle slider bar.
                /// </summary>
                /// <since_tizen> preview </since_tizen>
                public double BarAngleMaximum
                {
                    get
                    {
                        double min;
                        double max;
                        Interop.Eext.eext_circle_object_angle_min_max_get(CircleHandle, out min, out max);
                        return max;
                    }
                    set
                    {
                        double min = BarAngleMinimum;
                        Interop.Eext.eext_circle_object_angle_min_max_set(CircleHandle, min, (double)value);
                    }
                }

                /// <summary>
                /// Sets or gets the minimum values for the circle slider.
                /// </summary>
                /// <remarks>
                /// This defines the allowed minimum values to be selected by the user.
                /// If the actual value is less than the minimum value, it is updated to the minimum value.
                /// Actual value can be obtained with Value. By default, minimum value is equal to 0.0.
                /// </remarks>
                /// <since_tizen> preview </since_tizen>
                public double Minimum
                {
                    get
                    {
                        double min;
                        double max;
                        Interop.Eext.eext_circle_object_value_min_max_get(CircleHandle, out min, out max);
                        return min;
                    }
                    set
                    {
                        double max = Maximum;
                        Interop.Eext.eext_circle_object_value_min_max_set(CircleHandle, (double)value, max);
                    }
                }

                /// <summary>
                /// Sets or gets the maximum values for the circle slider.
                /// </summary>
                /// <remarks>
                /// This defines the allowed maximum values to be selected by the user.
                /// If the actual value is bigger than the maximum value, it is updated to the maximum value.
                /// Actual value can be obtained with Value. By default, the minimum value is equal to 0.0, and the maximum value is equal to 1.0.
                /// Maximum must be greater than minimum, otherwise the behavior is undefined.
                /// </remarks>
                /// <since_tizen> preview </since_tizen>
                public double Maximum
                {
                    get
                    {
                        double min;
                        double max;
                        Interop.Eext.eext_circle_object_value_min_max_get(CircleHandle, out min, out max);
                        return max;
                    }
                    set
                    {
                        double min = Minimum;
                        Interop.Eext.eext_circle_object_value_min_max_set(CircleHandle, min, (double)value);
                    }
                }

                /// <summary>
                /// Gets or sets the value displayed by the circle slider.
                /// </summary>
                /// <remarks>
                /// The value must be between minimum and maximum.
                /// </remarks>
                /// <since_tizen> preview </since_tizen>
                public double Value
                {
                    get
                    {
                        return Interop.Eext.eext_circle_object_value_get(CircleHandle);
                    }
                    set
                    {
                        Interop.Eext.eext_circle_object_value_set(CircleHandle, (double)value);
                    }
                }

                /// <summary>
                /// Gets or sets the radius value for the circle slider bar.
                /// </summary>
                /// <since_tizen> preview </since_tizen>
                public double BarRadius
                {
                    get
                    {
                        return Interop.Eext.eext_circle_object_radius_get(CircleHandle);
                    }
                    set
                    {
                        Interop.Eext.eext_circle_object_radius_set(CircleHandle, (double)value);
                    }
                }

                /// <summary>
                /// Gets or sets the radius value for the circle slider background.
                /// </summary>
                /// <since_tizen> preview </since_tizen>
                public double BackgroundRadius
                {
                    get
                    {
                        return Interop.Eext.eext_circle_object_item_radius_get(CircleHandle, "bg");
                    }
                    set
                    {
                        Interop.Eext.eext_circle_object_item_radius_set(CircleHandle, "bg", value);
                    }
                }
            }
        }
    }
}