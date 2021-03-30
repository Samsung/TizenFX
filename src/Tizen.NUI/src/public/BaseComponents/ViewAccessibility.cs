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

using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using Tizen.NUI;

namespace Tizen.NUI.BaseComponents
{
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class Address
    {
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Address(string xbus, string xpath)
        {
            bus = xbus;
            path = xpath;
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public string bus { get; set; }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string path { get; set; }
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
    public class AddressCollection : SafeHandle
    {
        [EditorBrowsable(EditorBrowsableState.Never)]
        public AddressCollection(IntPtr collection) : base(collection, true) { }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool IsInvalid { get { return this.handle == IntPtr.Zero; } }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint RelationSize(View.RelationType relation)
        {
            uint result = Interop.ControlDevel.DaliToolkitDevelControlAccessibilityRelationsRelationSize(this, Convert.ToInt32(relation));
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return result;
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public Address At(View.RelationType relation, int position)
        {
            var bus = Interop.ControlDevel.DaliToolkitDevelControlAccessibilityRelationsAt(this, Convert.ToInt32(relation), position, 0);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();

            var path = Interop.ControlDevel.DaliToolkitDevelControlAccessibilityRelationsAt(this, Convert.ToInt32(relation), position, 1);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();

            return new Address(bus, path);
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override bool ReleaseHandle()
        {
            Interop.ControlDevel.DaliToolkitDevelControlDeleteAccessibilityRelations(handle);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            this.SetHandle(IntPtr.Zero);
            return true;
        }
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class AccessibilityStates : SafeHandle
    {
        [EditorBrowsable(EditorBrowsableState.Never)]
        public AccessibilityStates() : base(IntPtr.Zero, true)
        {
            var obj = Interop.ControlDevel.DaliToolkitDevelControlNewStates();
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            this.SetHandle(obj);
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public AccessibilityStates(IntPtr states) : base(states, true) { }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool IsInvalid { get { return this.handle == IntPtr.Zero; } }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public void Set(AccessibilityState type, bool v)
        {
            Interop.ControlDevel.DaliToolkitDevelControlStatesSet(this, (int)type, Convert.ToInt32(v));
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool Get(AccessibilityState type)
        {
            bool result = Interop.ControlDevel.DaliToolkitDevelControlStatesGet(this, (int)type);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return result;
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override bool ReleaseHandle()
        {
            Interop.ControlDevel.DaliToolkitDevelControlDeleteStates(handle);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            this.SetHandle(IntPtr.Zero);
            return true;
        }
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
    public class AccessibilityRange
    {
        public int StartOffset { get; set; } = 0;
        public int EndOffset { get; set; } = 0;
        public string Content { get; set; } = "";
    }

    /// <summary>
    /// View is the base class for all views.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public partial class View
    {
        ///////////////////////////////////////////////////////////////////
        // ****************** Accessibility Attributes ****************** //
        ///////////////////////////////////////////////////////////////////

        [EditorBrowsable(EditorBrowsableState.Never)]
        public void AppendAccessibilityAttribute(string key, string val)
        {
            Interop.ControlDevel.DaliToolkitDevelControlAppendAccessibilityAttribute(SwigCPtr, key, val);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public void RemoveAccessibilityAttribute(string key)
        {
            Interop.ControlDevel.DaliToolkitDevelControlRemoveAccessibilityAttribute(SwigCPtr, key);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public void ClearAccessibilityAttributes()
        {
            Interop.ControlDevel.DaliToolkitDevelControlClearAccessibilityAttributes(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        ///////////////////////////////////////////////////////////////////
        // ************************** Highlight ************************ //
        ///////////////////////////////////////////////////////////////////

        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool ClearAccessibilityHighlight()
        {
            bool result = Interop.ControlDevel.DaliToolkitDevelControlClearAccessibilityHighlight(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return result;
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool GrabAccessibilityHighlight()
        {
            bool result = Interop.ControlDevel.DaliToolkitDevelControlGrabAccessibilityHighlight(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return result;
        }

        ///////////////////////////////////////////////////////////////////
        // ****************** Accessibility Relations ******************* //
        ///////////////////////////////////////////////////////////////////

        /// <summary>
        /// Creates relation between objects.
        /// </summary>
        /// <param name="second">Object which will be in relation.</param>
        /// <param name="relation">Relation type.</param>
        /// <exception cref="ArgumentNullException">You must pass valid object. NULL could not be in relation.</exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void AppendAccessibilityRelation(View second, RelationType relation)
        {
            if (second is null)
                throw new ArgumentNullException(nameof(second));

            Interop.ControlDevel.DaliToolkitDevelControlAppendAccessibilityRelation(SwigCPtr, second.SwigCPtr, (int)relation);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public void RemoveAccessibilityRelation(View second, RelationType relation)
        {
            if (second is null)
                throw new ArgumentNullException(nameof(second));

            Interop.ControlDevel.DaliToolkitDevelControlRemoveAccessibilityRelation(SwigCPtr, second.SwigCPtr, (int)relation);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public void ClearAccessibilityRelations()
        {
            Interop.ControlDevel.DaliToolkitDevelControlClearAccessibilityRelations(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public AddressCollection GetAccessibilityRelations()
        {
            var result = new AddressCollection(Interop.ControlDevel.DaliToolkitDevelControlNewGetAccessibilityRelations(SwigCPtr));
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return result;
        }

        ///////////////////////////////////////////////////////////////////
        // ********************* ReadingInfoType *********************** //
        ///////////////////////////////////////////////////////////////////

        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SetAccessibilityReadingInfoTypes(AccessibilityReadingInfoTypes info)
        {
            Interop.ControlDevel.DaliToolkitDevelControlSetAccessibilityReadingInfoTypes(SwigCPtr, (int)info);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public AccessibilityReadingInfoTypes GetAccessibilityReadingInfoTypes()
        {
            AccessibilityReadingInfoTypes result = (AccessibilityReadingInfoTypes)Interop.ControlDevel.DaliToolkitDevelControlGetAccessibilityReadingInfoTypes(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return result;
        }

        ///////////////////////////////////////////////////////////////////
        // ****************** Accessibility Relations ******************* //
        ///////////////////////////////////////////////////////////////////

        [EditorBrowsable(EditorBrowsableState.Never)]
        public void NotifyAccessibilityStateChange(AccessibilityStates states, bool recursive)
        {
            Interop.ControlDevel.DaliToolkitDevelControlNotifyAccessibilityStateChange(SwigCPtr, states, Convert.ToInt32(recursive));
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public AccessibilityStates GetAccessibilityStates()
        {
            var result = new AccessibilityStates(Interop.ControlDevel.DaliToolkitDevelControlNewGetAccessibilityStates(SwigCPtr));
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return result;
        }

        ///////////////////////////////////////////////////////////////////
        // ************************ Accessible ************************* //
        ///////////////////////////////////////////////////////////////////

        [EditorBrowsable(EditorBrowsableState.Never)]
        public void EmitAccessibilityEvent(ObjectPropertyChangeEvent e)
        {
            Interop.ControlDevel.DaliAccessibilityEmitAccessibilityEvent(SwigCPtr, Convert.ToInt32(e));
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public void EmitAccessibilityStateChangedEvent(AccessibilityState e, bool b)
        {
            Interop.ControlDevel.DaliAccessibilityEmitAccessibilityStateChangedEvent(SwigCPtr, Convert.ToInt32(e), Convert.ToInt32(b));
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public void EmitTextInsertedEvent(int position, int length, string content)
        {
            Interop.ControlDevel.DaliAccessibilityEmitTextInsertedEvent(SwigCPtr, position, length, content);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public void EmitTextDeletedEvent(int position, int length, string content)
        {
            Interop.ControlDevel.DaliAccessibilityEmitTextDeletedEvent(SwigCPtr, position, length, content);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public void EmitTextCaretMovedEvent(int position)
        {
            Interop.ControlDevel.DaliAccessibilityEmitTextCaretMovedEvent(SwigCPtr, position);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        ///////////////////////////////////////////////////////////////////
        // ************************** Bridge *************************** //
        ///////////////////////////////////////////////////////////////////

        [EditorBrowsable(EditorBrowsableState.Never)]
        public void AddPopup()
        {
            Interop.ControlDevel.DaliAccessibilityBridgeAddPopup(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public void RemovePopup()
        {
            Interop.ControlDevel.DaliAccessibilityBridgeRemovePopup(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        private IntPtr strdup(string arg)
        {
            return Interop.ControlDevel.DaliToolkitDevelControlAccessibleImplNUIDuplicateString(arg ?? "");
        }

        private IntPtr statesdup(AccessibilityStates states)
        {
            return Interop.ControlDevel.DaliToolkitDevelControlStatesCopy(states);
        }

        private IntPtr rangedup(AccessibilityRange range)
        {
            return Interop.ControlDevel.DaliAccessibilityNewRange(range.StartOffset, range.EndOffset, range.Content);
        }

        private Interop.ControlDevel.AccessibilityDelegate _accessibilityDelegate = null;
        private IntPtr _accessibilityDelegatePtr;

        [EditorBrowsable(EditorBrowsableState.Never)]
        public enum AccessibilityInterface
        {
            None = 0,
            Value = 1,
            EditableText = 2,
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SetAccessibilityConstructor(Role role, AccessibilityInterface iface = AccessibilityInterface.None)
        {
            var size = Marshal.SizeOf<Interop.ControlDevel.AccessibilityDelegate>();

            if (_accessibilityDelegate == null)
            {
                _accessibilityDelegate = new Interop.ControlDevel.AccessibilityDelegate()
                {
                    GetName = () => strdup(AccessibilityGetName()),
                    GetDescription = () => strdup(AccessibilityGetDescription()),
                    DoAction = (name) => AccessibilityDoAction(Marshal.PtrToStringAnsi(name)),
                    CalculateStates = () => statesdup(AccessibilityCalculateStates()),
                    GetActionCount = () => AccessibilityGetActionCount(),
                    GetActionName = (index) => strdup(AccessibilityGetActionName(index)),
                    ShouldReportZeroChildren = () => AccessibilityShouldReportZeroChildren(),
                    GetMinimum = () => AccessibilityGetMinimum(),
                    GetCurrent = () => AccessibilityGetCurrent(),
                    GetMaximum = () => AccessibilityGetMaximum(),
                    SetCurrent = (value) => AccessibilitySetCurrent(value),
                    GetMinimumIncrement = () => AccessibilityGetMinimumIncrement(),
                    IsScrollable = () => AccessibilityIsScrollable(),
                    GetText = (startOffset, endOffset) => strdup(AccessibilityGetText(startOffset, endOffset)),
                    GetCharacterCount = () => AccessibilityGetCharacterCount(),
                    GetCaretOffset = () => AccessibilityGetCaretOffset(),
                    SetCaretOffset = (offset) => AccessibilitySetCaretOffset(offset),
                    GetTextAtOffset = (offset, boundary) => rangedup(AccessibilityGetTextAtOffset(offset, (TextBoundary)boundary)),
                    GetSelection = (selectionNum) => rangedup(AccessibilityGetSelection(selectionNum)),
                    RemoveSelection = (selectionNum) => AccessibilityRemoveSelection(selectionNum),
                    SetSelection = (selectionNum, startOffset, endOffset) => AccessibilitySetSelection(selectionNum, startOffset, endOffset),
                    CopyText = (startPosition, endPosition) => AccessibilityCopyText(startPosition, endPosition),
                    CutText = (startPosition, endPosition) => AccessibilityCutText(startPosition, endPosition),
                };

                _accessibilityDelegatePtr = Marshal.AllocHGlobal(size);
                Marshal.StructureToPtr(_accessibilityDelegate, _accessibilityDelegatePtr, false);
            }

            Interop.ControlDevel.DaliToolkitDevelControlSetAccessibilityConstructor(SwigCPtr, (int)role, (int)iface, _accessibilityDelegatePtr, size);


            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);

            if (_accessibilityDelegate != null)
            {
                Marshal.DestroyStructure<Interop.ControlDevel.AccessibilityDelegate>(_accessibilityDelegatePtr);
                Marshal.FreeHGlobal(_accessibilityDelegatePtr);
                _accessibilityDelegate = null;
            }
        }
    }
}
