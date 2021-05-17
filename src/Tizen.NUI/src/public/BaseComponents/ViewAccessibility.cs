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

        [EditorBrowsable(EditorBrowsableState.Never)]
        protected bool IsHighlighted
        {
            get
            {
                using (View view = Accessibility.Accessibility.Instance.GetCurrentlyHighlightedView())
                {
                    return view == this;
                }
            }
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
        // ******************** Accessibility States ******************* //
        ///////////////////////////////////////////////////////////////////

        [EditorBrowsable(EditorBrowsableState.Never)]
        public void NotifyAccessibilityStatesChange(AccessibilityStates state, bool recursive)
        {
            Interop.ControlDevel.DaliToolkitDevelControlNotifyAccessibilityStatesChange(SwigCPtr, (ulong)state, Convert.ToInt32(recursive));
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public AccessibilityStates GetAccessibilityStates()
        {
            AccessibilityStates result = (AccessibilityStates) Interop.ControlDevel.DaliToolkitDevelControlGetAccessibilityStates(SwigCPtr);
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
        public void EmitAccessibilityStatesChangedEvent(AccessibilityStates e, bool b)
        {
            Interop.ControlDevel.DaliAccessibilityEmitAccessibilityStatesChangedEvent(SwigCPtr, (ulong)e, Convert.ToInt32(b));
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
            return Interop.ControlDevel.DaliToolkitDevelControlConvertState((ulong)states);
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

        [EditorBrowsable(EditorBrowsableState.Never)]
        protected static readonly string AccessibilityActivateAction = "activate";
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected static readonly string AccessibilityReadingSkippedAction = "ReadingSkipped";
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected static readonly string AccessibilityReadingCancelledAction = "ReadingCancelled";
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected static readonly string AccessibilityReadingStoppedAction = "ReadingStopped";
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected static readonly string AccessibilityReadingPausedAction = "ReadingPaused";
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected static readonly string AccessibilityReadingResumedAction = "ReadingResumed";

        [EditorBrowsable(EditorBrowsableState.Never)]
        private static readonly string[] AccessibilityActions = {
            AccessibilityActivateAction,
            AccessibilityReadingSkippedAction,
            AccessibilityReadingCancelledAction,
            AccessibilityReadingStoppedAction,
            AccessibilityReadingPausedAction,
            AccessibilityReadingResumedAction,
        };

        [EditorBrowsable(EditorBrowsableState.Never)]
        protected virtual string AccessibilityGetName()
        {
            return "";
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        protected virtual string AccessibilityGetDescription()
        {
            return "";
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        protected virtual bool AccessibilityDoAction(string name)
        {
            return false;
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        protected virtual AccessibilityStates AccessibilityCalculateStates()
        {
            AccessibilityStates states = 0;

            FlagSetter(ref states, AccessibilityStates.Highlightable, this.AccessibilityHighlightable);
            FlagSetter(ref states, AccessibilityStates.Focusable, this.Focusable);
            FlagSetter(ref states, AccessibilityStates.Focused, this.State == States.Focused);
            FlagSetter(ref states, AccessibilityStates.Highlighted, this.IsHighlighted);
            FlagSetter(ref states, AccessibilityStates.Enabled, this.State != States.Disabled);
            FlagSetter(ref states, AccessibilityStates.Sensitive, this.Sensitive);
            FlagSetter(ref states, AccessibilityStates.Animated, this.AccessibilityAnimated);
            FlagSetter(ref states, AccessibilityStates.Visible, true);
            FlagSetter(ref states, AccessibilityStates.Showing, this.Visibility);
            FlagSetter(ref states, AccessibilityStates.Defunct, !this.IsOnWindow);

            return states;
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        protected virtual int AccessibilityGetActionCount()
        {
            return AccessibilityActions.Length;
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        protected virtual string AccessibilityGetActionName(int index)
        {
            if (index >= 0 && index < AccessibilityActions.Length)
                return AccessibilityActions[index];
            else
                return "";
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        protected virtual bool AccessibilityShouldReportZeroChildren()
        {
            return false;
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        protected virtual double AccessibilityGetMinimum()
        {
            return 0.0;
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        protected virtual double AccessibilityGetCurrent()
        {
            return 0.0;
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        protected virtual double AccessibilityGetMaximum()
        {
            return 0.0;
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        protected virtual bool AccessibilitySetCurrent(double value)
        {
            return false;
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        protected virtual double AccessibilityGetMinimumIncrement()
        {
            return 0.0;
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        protected virtual bool AccessibilityIsScrollable()
        {
            return false;
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        protected virtual string AccessibilityGetText(int startOffset, int endOffset)
        {
            return "";
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        protected virtual int AccessibilityGetCharacterCount()
        {
            return 0;
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        protected virtual int AccessibilityGetCaretOffset()
        {
            return 0;
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        protected virtual bool AccessibilitySetCaretOffset(int offset)
        {
            return false;
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        protected virtual AccessibilityRange AccessibilityGetTextAtOffset(int offset, TextBoundary boundary)
        {
            return new AccessibilityRange();
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        protected virtual AccessibilityRange AccessibilityGetSelection(int selectionNum)
        {
            return new AccessibilityRange();
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        protected virtual bool AccessibilityRemoveSelection(int selectionNum)
        {
            return false;
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        protected virtual bool AccessibilitySetSelection(int selectionNum, int startOffset, int endOffset)
        {
            return false;
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        protected virtual bool AccessibilityCopyText(int startPosition, int endPosition)
        {
            return false;
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        protected virtual bool AccessibilityCutText(int startPosition, int endPosition)
        {
            return false;
        }
    }
}
