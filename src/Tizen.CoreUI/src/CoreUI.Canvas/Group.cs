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
namespace CoreUI.Canvas {
    /// <summary>Event argument wrapper for event <see cref="CoreUI.Canvas.Group.MemberAdded"/>.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    [CoreUI.Wrapper.BindingEntity]
    public class GroupMemberAddedEventArgs : EventArgs {
        /// <summary>Actual event payload.
        /// </summary>
        /// <value>Called when a member is added to the group.</value>
        /// <since_tizen> 6 </since_tizen>
        public CoreUI.Gfx.IEntity Arg { get; set; }
    }

    /// <summary>Event argument wrapper for event <see cref="CoreUI.Canvas.Group.MemberRemoved"/>.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    [CoreUI.Wrapper.BindingEntity]
    public class GroupMemberRemovedEventArgs : EventArgs {
        /// <summary>Actual event payload.
        /// </summary>
        /// <value>Called when a member is removed from the group.</value>
        /// <since_tizen> 6 </since_tizen>
        public CoreUI.Gfx.IEntity Arg { get; set; }
    }

    /// <summary>A group object is a container for other canvas objects. Its children move along their parent and are often clipped with a common clipper. This is part of the legacy smart object concept.
    /// 
    /// A group is not necessarily a container (see <see cref="CoreUI.IContainer"/>) in the sense that a standard widget may not have any empty slots for content. However it&apos;s still a group of low-level canvas objects (clipper, raw objects, etc.).</summary>
    /// <since_tizen> 6 </since_tizen>
    [CoreUI.Canvas.Group.NativeMethods]
    [CoreUI.Wrapper.BindingEntity]
    [SuppressMessage("Microsoft.Naming", "CA1724:TypeNamesShouldNotMatchNamespaces")]
    public class Group : CoreUI.Canvas.Object
    {
        /// <summary>Pointer to the native class description.</summary>
        public override System.IntPtr NativeClass
        {
            get
            {
                if (((object)this).GetType() == typeof(Group))
                {
                    return GetCoreUIClassStatic();
                }
                else
                {
                    return CoreUI.Wrapper.ClassRegister.klassFromType[((object)this).GetType()];
                }
            }
        }

        [System.Runtime.InteropServices.DllImport(CoreUI.Libs.Evas)] internal static extern System.IntPtr
            efl_canvas_group_class_get();

        /// <summary>Initializes a new instance of the <see cref="Group"/> class.
        /// </summary>
        /// <param name="parent">Parent instance.</param>
        public Group(CoreUI.Object parent= null) : base(efl_canvas_group_class_get(), parent)
        {
            FinishInstantiation();
        }

        /// <summary>Subclasses should override this constructor if they are expected to be instantiated from native code.
        /// Do not call this constructor directly.
        /// </summary>
        /// <param name="ch">Tag struct storing the native handle of the object being constructed.</param>
        protected Group(ConstructingHandle ch) : base(ch)
        {
        }

        /// <summary>Initializes a new instance of the <see cref="Group"/> class.
        /// Internal usage: Constructs an instance from a native pointer. This is used when interacting with C code and should not be used directly.
        /// </summary>
        /// <param name="wh">The native pointer to be wrapped.</param>
        internal Group(CoreUI.Wrapper.WrappingHandle wh) : base(wh)
        {
        }

        /// <summary>Initializes a new instance of the <see cref="Group"/> class.
        /// Internal usage: Constructor to forward the wrapper initialization to the root class that interfaces with native code. Should not be used directly.
        /// </summary>
        /// <param name="baseKlass">The pointer to the base native Eo class.</param>
        /// <param name="parent">The CoreUI.Object parent of this instance.</param>
        protected Group(IntPtr baseKlass, CoreUI.Object parent) : base(baseKlass, parent)
        {
        }

        /// <summary>Called when a member is added to the group.</summary>
        /// <since_tizen> 6 </since_tizen>
        /// <value><see cref="CoreUI.Canvas.GroupMemberAddedEventArgs"/></value>
        public event EventHandler<CoreUI.Canvas.GroupMemberAddedEventArgs> MemberAdded
        {
            add
            {
                CoreUI.EventCb callerCb = GetInternalEventCallback(value, info => new CoreUI.Canvas.GroupMemberAddedEventArgs{ Arg = (CoreUI.Wrapper.Globals.CreateWrapperFor(info) as CoreUI.Gfx.IEntity) });
                string key = "_EFL_CANVAS_GROUP_EVENT_MEMBER_ADDED";
                AddNativeEventHandler(CoreUI.Libs.Evas, key, callerCb, value);
            }

            remove
            {
                string key = "_EFL_CANVAS_GROUP_EVENT_MEMBER_ADDED";
                RemoveNativeEventHandler(CoreUI.Libs.Evas, key, value);
            }
        }

        /// <summary>Method to raise event MemberAdded.
        /// </summary>
        /// <param name="e">Event to raise.</param>
        /// <since_tizen> 6 </since_tizen>
        protected virtual void OnMemberAdded(CoreUI.Canvas.GroupMemberAddedEventArgs e)
        {
            Contract.Requires(e != null, nameof(e));
            IntPtr info = e.Arg.NativeHandle;
            CallNativeEventCallback(CoreUI.Libs.Evas, "_EFL_CANVAS_GROUP_EVENT_MEMBER_ADDED", info, null);
        }

        /// <summary>Called when a member is removed from the group.</summary>
        /// <since_tizen> 6 </since_tizen>
        /// <value><see cref="CoreUI.Canvas.GroupMemberRemovedEventArgs"/></value>
        public event EventHandler<CoreUI.Canvas.GroupMemberRemovedEventArgs> MemberRemoved
        {
            add
            {
                CoreUI.EventCb callerCb = GetInternalEventCallback(value, info => new CoreUI.Canvas.GroupMemberRemovedEventArgs{ Arg = (CoreUI.Wrapper.Globals.CreateWrapperFor(info) as CoreUI.Gfx.IEntity) });
                string key = "_EFL_CANVAS_GROUP_EVENT_MEMBER_REMOVED";
                AddNativeEventHandler(CoreUI.Libs.Evas, key, callerCb, value);
            }

            remove
            {
                string key = "_EFL_CANVAS_GROUP_EVENT_MEMBER_REMOVED";
                RemoveNativeEventHandler(CoreUI.Libs.Evas, key, value);
            }
        }

        /// <summary>Method to raise event MemberRemoved.
        /// </summary>
        /// <param name="e">Event to raise.</param>
        /// <since_tizen> 6 </since_tizen>
        protected virtual void OnMemberRemoved(CoreUI.Canvas.GroupMemberRemovedEventArgs e)
        {
            Contract.Requires(e != null, nameof(e));
            IntPtr info = e.Arg.NativeHandle;
            CallNativeEventCallback(CoreUI.Libs.Evas, "_EFL_CANVAS_GROUP_EVENT_MEMBER_REMOVED", info, null);
        }


        /// <summary>Indicates that the group&apos;s layout needs to be recalculated.
        /// 
        /// If this flag is set, then the <see cref="CoreUI.Canvas.Group.CalculateGroup"/> function will be called, during rendering phase of the canvas. After that, this flag will be automatically unset.
        /// 
        /// <b>NOTE: </b>setting this flag alone will not make the canvas&apos; whole scene dirty. Using evas_render() will have no effect. To force this, use <see cref="CoreUI.Canvas.Group.GroupChange"/>, which will also call this function automatically, with the parameter set to <c>true</c>.
        /// 
        /// See also <see cref="CoreUI.Canvas.Group.CalculateGroup"/>.</summary>
        /// <returns><c>true</c> if the group layout needs to be recalculated, <c>false</c> otherwise</returns>
        /// <since_tizen> 6 </since_tizen>
        public virtual bool GetGroupNeedRecalculate() {
            var _ret_var = CoreUI.Canvas.Group.NativeMethods.efl_canvas_group_need_recalculate_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)));
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
        }

        /// <summary>Indicates that the group&apos;s layout needs to be recalculated.
        /// 
        /// If this flag is set, then the <see cref="CoreUI.Canvas.Group.CalculateGroup"/> function will be called, during rendering phase of the canvas. After that, this flag will be automatically unset.
        /// 
        /// <b>NOTE: </b>setting this flag alone will not make the canvas&apos; whole scene dirty. Using evas_render() will have no effect. To force this, use <see cref="CoreUI.Canvas.Group.GroupChange"/>, which will also call this function automatically, with the parameter set to <c>true</c>.
        /// 
        /// See also <see cref="CoreUI.Canvas.Group.CalculateGroup"/>.</summary>
        /// <param name="value"><c>true</c> if the group layout needs to be recalculated, <c>false</c> otherwise</param>
        /// <since_tizen> 6 </since_tizen>
        public virtual void SetGroupNeedRecalculate(bool value) {
            CoreUI.Canvas.Group.NativeMethods.efl_canvas_group_need_recalculate_set_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), value);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            
        }

        /// <summary>The internal clipper object used by this group.
        /// 
        /// This is the object clipping all the child objects. Do not delete or otherwise modify this clipper!</summary>
        /// <returns>A clipper rectangle.</returns>
        /// <since_tizen> 6 </since_tizen>
        protected virtual CoreUI.Canvas.Object GetGroupClipper() {
            var _ret_var = CoreUI.Canvas.Group.NativeMethods.efl_canvas_group_clipper_get_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)));
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
        }

        /// <summary>Marks the object as dirty.
        /// 
        /// This also forcefully marks the given object as needing recalculation. As an effect, on the next rendering cycle its <see cref="CoreUI.Canvas.Group.CalculateGroup"/> method will be called.</summary>
        /// <since_tizen> 6 </since_tizen>
        public virtual void GroupChange() {
            CoreUI.Canvas.Group.NativeMethods.efl_canvas_group_change_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)));
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            
        }

        /// <summary>Triggers an immediate recalculation of this object&apos;s geometry.
        /// 
        /// This will also reset the flag <see cref="CoreUI.Canvas.Group.GroupNeedRecalculate"/>.</summary>
        /// <since_tizen> 6 </since_tizen>
        public virtual void CalculateGroup() {
            CoreUI.Canvas.Group.NativeMethods.efl_canvas_group_calculate_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)));
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            
        }

        /// <summary>Returns an iterator over the children of this object, which are canvas objects.
        /// 
        /// This returns the list of &quot;smart&quot; children. This might be different from both the <see cref="CoreUI.Object"/> children list as well as the <see cref="CoreUI.IContainer"/> content list.</summary>
        /// <since_tizen> 6 </since_tizen>
        /// <returns>Iterator to object children</returns>
        public virtual IEnumerable<CoreUI.Canvas.Object> IterateGroupMembers() {
            var _ret_var = CoreUI.Canvas.Group.NativeMethods.efl_canvas_group_members_iterate_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)));
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return CoreUI.Wrapper.Globals.IteratorToIEnumerable<CoreUI.Canvas.Object>(_ret_var);
        }

        /// <summary>Set a canvas object as a member of a given group (or smart object).
        /// 
        /// Members will automatically be stacked and layered together with the smart object. The various stacking functions will operate on members relative to the other members instead of the entire canvas, since they now live on an exclusive layer (see <see cref="CoreUI.Gfx.IStack.StackAbove"/>, for more details).
        /// 
        /// Subclasses inheriting from this one may override this function to ensure the proper stacking of special objects, such as clippers, event rectangles, etc...
        /// 
        /// See also <see cref="CoreUI.Canvas.Group.RemoveGroupMember"/>. See also <see cref="CoreUI.Canvas.Group.IsGroupMember"/>.</summary>
        /// <since_tizen> 6 </since_tizen>
        /// <param name="sub_obj">The member object.</param>
        public virtual void AddGroupMember(CoreUI.Canvas.Object sub_obj) {
            CoreUI.Canvas.Group.NativeMethods.efl_canvas_group_member_add_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), sub_obj);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            
        }

        /// <summary>Removes a member object from a given smart object.
        /// 
        /// This removes a member object from a smart object, if it was added to any. The object will still be on the canvas, but no longer associated with whichever smart object it was associated with.
        /// 
        /// See also <see cref="CoreUI.Canvas.Group.AddGroupMember"/>. See also <see cref="CoreUI.Canvas.Group.IsGroupMember"/>.</summary>
        /// <since_tizen> 6 </since_tizen>
        /// <param name="sub_obj">The member object to remove.</param>
        public virtual void RemoveGroupMember(CoreUI.Canvas.Object sub_obj) {
            CoreUI.Canvas.Group.NativeMethods.efl_canvas_group_member_remove_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), sub_obj);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            
        }

        /// <summary>Finds out if a given object is a member of this group.</summary>
        /// <since_tizen> 6 </since_tizen>
        /// <param name="sub_obj">A potential sub object.</param>
        /// <returns><c>true</c> if <c>sub_obj</c> is a member of this group.</returns>
        public virtual bool IsGroupMember(CoreUI.Canvas.Object sub_obj) {
            var _ret_var = CoreUI.Canvas.Group.NativeMethods.efl_canvas_group_member_is_ptr.Value.Delegate((IsGeneratedBindingClass ? this.NativeHandle : CoreUI.Wrapper.Globals.Super(this.NativeHandle, this.NativeClass)), sub_obj);
            CoreUI.DataTypes.Error.RaiseIfUnhandledException();
            return _ret_var;
        }

        /// <summary>Indicates that the group&apos;s layout needs to be recalculated.
        /// 
        /// If this flag is set, then the <see cref="CoreUI.Canvas.Group.CalculateGroup"/> function will be called, during rendering phase of the canvas. After that, this flag will be automatically unset.
        /// 
        /// <b>NOTE: </b>setting this flag alone will not make the canvas&apos; whole scene dirty. Using evas_render() will have no effect. To force this, use <see cref="CoreUI.Canvas.Group.GroupChange"/>, which will also call this function automatically, with the parameter set to <c>true</c>.
        /// 
        /// See also <see cref="CoreUI.Canvas.Group.CalculateGroup"/>.</summary>
        /// <value><c>true</c> if the group layout needs to be recalculated, <c>false</c> otherwise</value>
        /// <since_tizen> 6 </since_tizen>
        public bool GroupNeedRecalculate {
            get { return GetGroupNeedRecalculate(); }
            set { SetGroupNeedRecalculate(value); }
        }

        /// <summary>The internal clipper object used by this group.
        /// 
        /// This is the object clipping all the child objects. Do not delete or otherwise modify this clipper!</summary>
        /// <value>A clipper rectangle.</value>
        /// <since_tizen> 6 </since_tizen>
        protected CoreUI.Canvas.Object GroupClipper {
            get { return GetGroupClipper(); }
        }

        private static IntPtr GetCoreUIClassStatic()
        {
            return CoreUI.Canvas.Group.efl_canvas_group_class_get();
        }

        /// <summary>Wrapper for native methods and virtual method delegates.
        /// For internal use by generated code only.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        internal new class NativeMethods : CoreUI.Canvas.Object.NativeMethods
        {
            private static CoreUI.Wrapper.NativeModule Module = new CoreUI.Wrapper.NativeModule(CoreUI.Libs.Evas);

            /// <summary>Gets the list of Eo operations to override.
        /// </summary>
            /// <returns>The list of Eo operations to be overload.</returns>
            internal override System.Collections.Generic.List<CoreUIOpDescription> GetEoOps(System.Type type, bool includeInherited)
            {
                var descs = new System.Collections.Generic.List<CoreUIOpDescription>();
                var methods = CoreUI.Wrapper.Globals.GetUserMethods(type);

                if (efl_canvas_group_need_recalculate_get_static_delegate == null)
                {
                    efl_canvas_group_need_recalculate_get_static_delegate = new efl_canvas_group_need_recalculate_get_delegate(group_need_recalculate_get);
                }

                if (methods.Contains("GetGroupNeedRecalculate"))
                {
                    descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_canvas_group_need_recalculate_get"), func = Marshal.GetFunctionPointerForDelegate(efl_canvas_group_need_recalculate_get_static_delegate) });
                }

                if (efl_canvas_group_need_recalculate_set_static_delegate == null)
                {
                    efl_canvas_group_need_recalculate_set_static_delegate = new efl_canvas_group_need_recalculate_set_delegate(group_need_recalculate_set);
                }

                if (methods.Contains("SetGroupNeedRecalculate"))
                {
                    descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_canvas_group_need_recalculate_set"), func = Marshal.GetFunctionPointerForDelegate(efl_canvas_group_need_recalculate_set_static_delegate) });
                }

                if (efl_canvas_group_clipper_get_static_delegate == null)
                {
                    efl_canvas_group_clipper_get_static_delegate = new efl_canvas_group_clipper_get_delegate(group_clipper_get);
                }

                if (methods.Contains("GetGroupClipper"))
                {
                    descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_canvas_group_clipper_get"), func = Marshal.GetFunctionPointerForDelegate(efl_canvas_group_clipper_get_static_delegate) });
                }

                if (efl_canvas_group_change_static_delegate == null)
                {
                    efl_canvas_group_change_static_delegate = new efl_canvas_group_change_delegate(group_change);
                }

                if (methods.Contains("GroupChange"))
                {
                    descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_canvas_group_change"), func = Marshal.GetFunctionPointerForDelegate(efl_canvas_group_change_static_delegate) });
                }

                if (efl_canvas_group_calculate_static_delegate == null)
                {
                    efl_canvas_group_calculate_static_delegate = new efl_canvas_group_calculate_delegate(group_calculate);
                }

                if (methods.Contains("CalculateGroup"))
                {
                    descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_canvas_group_calculate"), func = Marshal.GetFunctionPointerForDelegate(efl_canvas_group_calculate_static_delegate) });
                }

                if (efl_canvas_group_members_iterate_static_delegate == null)
                {
                    efl_canvas_group_members_iterate_static_delegate = new efl_canvas_group_members_iterate_delegate(group_members_iterate);
                }

                if (methods.Contains("IterateGroupMembers"))
                {
                    descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_canvas_group_members_iterate"), func = Marshal.GetFunctionPointerForDelegate(efl_canvas_group_members_iterate_static_delegate) });
                }

                if (efl_canvas_group_member_add_static_delegate == null)
                {
                    efl_canvas_group_member_add_static_delegate = new efl_canvas_group_member_add_delegate(group_member_add);
                }

                if (methods.Contains("AddGroupMember"))
                {
                    descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_canvas_group_member_add"), func = Marshal.GetFunctionPointerForDelegate(efl_canvas_group_member_add_static_delegate) });
                }

                if (efl_canvas_group_member_remove_static_delegate == null)
                {
                    efl_canvas_group_member_remove_static_delegate = new efl_canvas_group_member_remove_delegate(group_member_remove);
                }

                if (methods.Contains("RemoveGroupMember"))
                {
                    descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_canvas_group_member_remove"), func = Marshal.GetFunctionPointerForDelegate(efl_canvas_group_member_remove_static_delegate) });
                }

                if (efl_canvas_group_member_is_static_delegate == null)
                {
                    efl_canvas_group_member_is_static_delegate = new efl_canvas_group_member_is_delegate(group_member_is);
                }

                if (methods.Contains("IsGroupMember"))
                {
                    descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_canvas_group_member_is"), func = Marshal.GetFunctionPointerForDelegate(efl_canvas_group_member_is_static_delegate) });
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
                return CoreUI.Canvas.Group.efl_canvas_group_class_get();
            }

            #pragma warning disable CA1707, CS1591, SA1300, SA1600

            [return: MarshalAs(UnmanagedType.U1)]
            private delegate bool efl_canvas_group_need_recalculate_get_delegate(System.IntPtr obj, System.IntPtr pd);

            [return: MarshalAs(UnmanagedType.U1)]
            internal delegate bool efl_canvas_group_need_recalculate_get_api_delegate(System.IntPtr obj);

            internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_canvas_group_need_recalculate_get_api_delegate> efl_canvas_group_need_recalculate_get_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_canvas_group_need_recalculate_get_api_delegate>(Module, "efl_canvas_group_need_recalculate_get");

            [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
            private static bool group_need_recalculate_get(System.IntPtr obj, System.IntPtr pd)
            {
                CoreUI.DataTypes.Log.Debug("function efl_canvas_group_need_recalculate_get was called");
                var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
                if (ws != null)
                {
                    bool _ret_var = default(bool);
                    try
                    {
                        _ret_var = ((Group)ws.Target).GetGroupNeedRecalculate();
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
                    return efl_canvas_group_need_recalculate_get_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)));
                }
            }

            private static efl_canvas_group_need_recalculate_get_delegate efl_canvas_group_need_recalculate_get_static_delegate;

            
            private delegate void efl_canvas_group_need_recalculate_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.U1)] bool value);

            
            internal delegate void efl_canvas_group_need_recalculate_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.U1)] bool value);

            internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_canvas_group_need_recalculate_set_api_delegate> efl_canvas_group_need_recalculate_set_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_canvas_group_need_recalculate_set_api_delegate>(Module, "efl_canvas_group_need_recalculate_set");

            [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
            private static void group_need_recalculate_set(System.IntPtr obj, System.IntPtr pd, bool value)
            {
                CoreUI.DataTypes.Log.Debug("function efl_canvas_group_need_recalculate_set was called");
                var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
                if (ws != null)
                {
                    
                    try
                    {
                        ((Group)ws.Target).SetGroupNeedRecalculate(value);
                    }
                    catch (Exception e)
                    {
                        CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                        CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                    }

                    
                }
                else
                {
                    efl_canvas_group_need_recalculate_set_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), value);
                }
            }

            private static efl_canvas_group_need_recalculate_set_delegate efl_canvas_group_need_recalculate_set_static_delegate;

            [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.MarshalEoNoMove))]
            private delegate CoreUI.Canvas.Object efl_canvas_group_clipper_get_delegate(System.IntPtr obj, System.IntPtr pd);

            [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.MarshalEoNoMove))]
            internal delegate CoreUI.Canvas.Object efl_canvas_group_clipper_get_api_delegate(System.IntPtr obj);

            internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_canvas_group_clipper_get_api_delegate> efl_canvas_group_clipper_get_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_canvas_group_clipper_get_api_delegate>(Module, "efl_canvas_group_clipper_get");

            [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
            private static CoreUI.Canvas.Object group_clipper_get(System.IntPtr obj, System.IntPtr pd)
            {
                CoreUI.DataTypes.Log.Debug("function efl_canvas_group_clipper_get was called");
                var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
                if (ws != null)
                {
                    CoreUI.Canvas.Object _ret_var = default(CoreUI.Canvas.Object);
                    try
                    {
                        _ret_var = ((Group)ws.Target).GetGroupClipper();
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
                    return efl_canvas_group_clipper_get_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)));
                }
            }

            private static efl_canvas_group_clipper_get_delegate efl_canvas_group_clipper_get_static_delegate;

            
            private delegate void efl_canvas_group_change_delegate(System.IntPtr obj, System.IntPtr pd);

            
            internal delegate void efl_canvas_group_change_api_delegate(System.IntPtr obj);

            internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_canvas_group_change_api_delegate> efl_canvas_group_change_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_canvas_group_change_api_delegate>(Module, "efl_canvas_group_change");

            [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
            private static void group_change(System.IntPtr obj, System.IntPtr pd)
            {
                CoreUI.DataTypes.Log.Debug("function efl_canvas_group_change was called");
                var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
                if (ws != null)
                {
                    
                    try
                    {
                        ((Group)ws.Target).GroupChange();
                    }
                    catch (Exception e)
                    {
                        CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                        CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                    }

                    
                }
                else
                {
                    efl_canvas_group_change_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)));
                }
            }

            private static efl_canvas_group_change_delegate efl_canvas_group_change_static_delegate;

            
            private delegate void efl_canvas_group_calculate_delegate(System.IntPtr obj, System.IntPtr pd);

            
            internal delegate void efl_canvas_group_calculate_api_delegate(System.IntPtr obj);

            internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_canvas_group_calculate_api_delegate> efl_canvas_group_calculate_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_canvas_group_calculate_api_delegate>(Module, "efl_canvas_group_calculate");

            [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
            private static void group_calculate(System.IntPtr obj, System.IntPtr pd)
            {
                CoreUI.DataTypes.Log.Debug("function efl_canvas_group_calculate was called");
                var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
                if (ws != null)
                {
                    
                    try
                    {
                        ((Group)ws.Target).CalculateGroup();
                    }
                    catch (Exception e)
                    {
                        CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                        CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                    }

                    
                }
                else
                {
                    efl_canvas_group_calculate_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)));
                }
            }

            private static efl_canvas_group_calculate_delegate efl_canvas_group_calculate_static_delegate;

            
            private delegate System.IntPtr efl_canvas_group_members_iterate_delegate(System.IntPtr obj, System.IntPtr pd);

            
            internal delegate System.IntPtr efl_canvas_group_members_iterate_api_delegate(System.IntPtr obj);

            internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_canvas_group_members_iterate_api_delegate> efl_canvas_group_members_iterate_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_canvas_group_members_iterate_api_delegate>(Module, "efl_canvas_group_members_iterate");

            [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
            private static System.IntPtr group_members_iterate(System.IntPtr obj, System.IntPtr pd)
            {
                CoreUI.DataTypes.Log.Debug("function efl_canvas_group_members_iterate was called");
                var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
                if (ws != null)
                {
                    IEnumerable<CoreUI.Canvas.Object> _ret_var = null;
                    try
                    {
                        _ret_var = ((Group)ws.Target).IterateGroupMembers();
                    }
                    catch (Exception e)
                    {
                        CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                        CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                    }

                    return CoreUI.Wrapper.Globals.IEnumerableToIterator(_ret_var, true);
                }
                else
                {
                    return efl_canvas_group_members_iterate_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)));
                }
            }

            private static efl_canvas_group_members_iterate_delegate efl_canvas_group_members_iterate_static_delegate;

            
            private delegate void efl_canvas_group_member_add_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.MarshalEoNoMove))] CoreUI.Canvas.Object sub_obj);

            
            internal delegate void efl_canvas_group_member_add_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.MarshalEoNoMove))] CoreUI.Canvas.Object sub_obj);

            internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_canvas_group_member_add_api_delegate> efl_canvas_group_member_add_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_canvas_group_member_add_api_delegate>(Module, "efl_canvas_group_member_add");

            [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
            private static void group_member_add(System.IntPtr obj, System.IntPtr pd, CoreUI.Canvas.Object sub_obj)
            {
                CoreUI.DataTypes.Log.Debug("function efl_canvas_group_member_add was called");
                var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
                if (ws != null)
                {
                    
                    try
                    {
                        ((Group)ws.Target).AddGroupMember(sub_obj);
                    }
                    catch (Exception e)
                    {
                        CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                        CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                    }

                    
                }
                else
                {
                    efl_canvas_group_member_add_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), sub_obj);
                }
            }

            private static efl_canvas_group_member_add_delegate efl_canvas_group_member_add_static_delegate;

            
            private delegate void efl_canvas_group_member_remove_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.MarshalEoNoMove))] CoreUI.Canvas.Object sub_obj);

            
            internal delegate void efl_canvas_group_member_remove_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.MarshalEoNoMove))] CoreUI.Canvas.Object sub_obj);

            internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_canvas_group_member_remove_api_delegate> efl_canvas_group_member_remove_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_canvas_group_member_remove_api_delegate>(Module, "efl_canvas_group_member_remove");

            [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
            private static void group_member_remove(System.IntPtr obj, System.IntPtr pd, CoreUI.Canvas.Object sub_obj)
            {
                CoreUI.DataTypes.Log.Debug("function efl_canvas_group_member_remove was called");
                var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
                if (ws != null)
                {
                    
                    try
                    {
                        ((Group)ws.Target).RemoveGroupMember(sub_obj);
                    }
                    catch (Exception e)
                    {
                        CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                        CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                    }

                    
                }
                else
                {
                    efl_canvas_group_member_remove_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), sub_obj);
                }
            }

            private static efl_canvas_group_member_remove_delegate efl_canvas_group_member_remove_static_delegate;

            [return: MarshalAs(UnmanagedType.U1)]
            private delegate bool efl_canvas_group_member_is_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.MarshalEoNoMove))] CoreUI.Canvas.Object sub_obj);

            [return: MarshalAs(UnmanagedType.U1)]
            internal delegate bool efl_canvas_group_member_is_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.MarshalEoNoMove))] CoreUI.Canvas.Object sub_obj);

            internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_canvas_group_member_is_api_delegate> efl_canvas_group_member_is_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_canvas_group_member_is_api_delegate>(Module, "efl_canvas_group_member_is");

            [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
            private static bool group_member_is(System.IntPtr obj, System.IntPtr pd, CoreUI.Canvas.Object sub_obj)
            {
                CoreUI.DataTypes.Log.Debug("function efl_canvas_group_member_is was called");
                var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
                if (ws != null)
                {
                    bool _ret_var = default(bool);
                    try
                    {
                        _ret_var = ((Group)ws.Target).IsGroupMember(sub_obj);
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
                    return efl_canvas_group_member_is_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), sub_obj);
                }
            }

            private static efl_canvas_group_member_is_delegate efl_canvas_group_member_is_static_delegate;

            #pragma warning restore CA1707, CS1591, SA1300, SA1600

        }
    }
}

namespace CoreUI.Canvas {
#pragma warning disable CS1591
    /// <since_tizen> 6 </since_tizen>
    public static class GroupExtensions {
        /// <since_tizen> 6 </since_tizen>
        public static CoreUI.BindableProperty<bool> GroupNeedRecalculate<T>(this CoreUI.UI.IGenericFactoryExtended<T> fac, CoreUI.Csharp.ExtensionTag<CoreUI.Canvas.Group, T>magic = null) where T : CoreUI.Canvas.Group {
            return new CoreUI.BindableProperty<bool>("group_need_recalculate", fac.GetPropBind());
        }

    }
#pragma warning restore CS1591
}

