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
    /// <summary>
    /// Address represents an unique object address on accessibility bus.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class Address
    {
        /// <summary>
        /// Creates an initialized Address.
        /// </summary>
        /// <param name="bus">Accessibility bus</param>
        /// <param name="path">Accessibility path</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Address(string bus, string path)
        {
            Bus = bus;
            Path = path;
        }

        /// <summary>
        /// Gets or sets accessibility bus.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string Bus { get; set; }

        /// <summary>
        /// Gets or sets accessibility path.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string Path { get; set; }
    }

    /// <summary>
    /// AddressCollection.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class AddressCollection : SafeHandle
    {
        /// <summary>
        /// Creates an initialized AddressCollection.
        /// </summary>
        /// <param name="collection">Initialized AddressCollection</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public AddressCollection(IntPtr collection) : base(collection, true)
        {
        }

        /// <summary>
        /// Checks whether this handle is invalid or not.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool IsInvalid
        {
            get
            {
                return this.handle == IntPtr.Zero;
            }
        }

        /// <summary>
        /// Gets the size of accessibility relation.
        /// </summary>
        /// <param name="relation">Accessibility relation</param>
        /// <returns>The size of relation, which means the number of elements</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint GetRelationSize(AccessibilityRelationType relation)
        {
            uint result = Interop.ControlDevel.DaliToolkitDevelControlAccessibilityRelationsRelationSize(this, Convert.ToInt32(relation));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return result;
        }

        /// <summary>
        /// Gets Address object using contained bus and path.
        /// </summary>
        /// <param name="relation">Accessibility relation</param>
        /// <param name="position">Position</param>
        /// <returns>Accessibility Adress</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Address GetAddressAt(AccessibilityRelationType relation, int position)
        {
            var bus = Interop.ControlDevel.DaliToolkitDevelControlAccessibilityRelationsAt(this, Convert.ToInt32(relation), position, 0);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();

            var path = Interop.ControlDevel.DaliToolkitDevelControlAccessibilityRelationsAt(this, Convert.ToInt32(relation), position, 1);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();

            return new Address(bus, path);
        }

        /// <summary>
        /// Releases handle itself.
        /// </summary>
        /// <returns>true when released successfully.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override bool ReleaseHandle()
        {
            Interop.ControlDevel.DaliToolkitDevelControlDeleteAccessibilityRelations(handle);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            this.SetHandle(IntPtr.Zero);
            return true;
        }
    }

    /// <summary>
    /// AccessibilityRange is used to store data related with Text.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class AccessibilityRange
    {
        /// <summary>
        /// Start position in stored text.
        /// </summary>
        public int StartOffset { get; set; } = 0;

        /// <summary>
        /// End position in stored text.
        /// </summary>
        public int EndOffset { get; set; } = 0;

        /// <summary>
        /// Text content in stored text.
        /// </summary>
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

        /// <summary>
        /// Adds or modifies the value matched with given key.
        /// </summary>
        /// <remarks>
        /// Modification takes place if key was previously set.
        /// </remarks>
        /// <param name="key">The key to insert</param>
        /// <param name="value">The value to insert</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void AppendAccessibilityAttribute(string key, string value)
        {
            Interop.ControlDevel.DaliToolkitDevelControlAppendAccessibilityAttribute(SwigCPtr, key, value);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Erases a key with its value from accessibility attributes.
        /// </summary>
        /// <param name="key">The key to remove</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void RemoveAccessibilityAttribute(string key)
        {
            Interop.ControlDevel.DaliToolkitDevelControlRemoveAccessibilityAttribute(SwigCPtr, key);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Clears accessibility attributes.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void ClearAccessibilityAttributes()
        {
            Interop.ControlDevel.DaliToolkitDevelControlClearAccessibilityAttributes(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        ///////////////////////////////////////////////////////////////////
        // ************************** Highlight ************************ //
        ///////////////////////////////////////////////////////////////////

        /// <summary>
        /// Clears accessibility highlight.
        /// </summary>
        /// <returns>True if cleared, otherwise false when it is not possible</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool ClearAccessibilityHighlight()
        {
            bool result = Interop.ControlDevel.DaliToolkitDevelControlClearAccessibilityHighlight(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return result;
        }

        /// <summary>
        /// Grabs accessibility highlight.
        /// </summary>
        /// <returns>True if cleared, otherwise false when it is not possible</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool GrabAccessibilityHighlight()
        {
            bool result = Interop.ControlDevel.DaliToolkitDevelControlGrabAccessibilityHighlight(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return result;
        }

        /// <summary>
        /// Flag to check whether this view is highlighted or not.
        /// </summary>
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
        public void AppendAccessibilityRelation(View second, AccessibilityRelationType relation)
        {
            if (second is null)
            {
                throw new ArgumentNullException(nameof(second));
            }

            Interop.ControlDevel.DaliToolkitDevelControlAppendAccessibilityRelation(SwigCPtr, second.SwigCPtr, (int)relation);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Removes accessibility relation.
        /// </summary>
        /// <param name="second">Object which will be removed in relation</param>
        /// <param name="relation">Relation type</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void RemoveAccessibilityRelation(View second, AccessibilityRelationType relation)
        {
            if (second is null)
            {
                throw new ArgumentNullException(nameof(second));
            }

            Interop.ControlDevel.DaliToolkitDevelControlRemoveAccessibilityRelation(SwigCPtr, second.SwigCPtr, (int)relation);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Removes all previously appended relations.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void ClearAccessibilityRelations()
        {
            Interop.ControlDevel.DaliToolkitDevelControlClearAccessibilityRelations(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Gets accessibility collection connected with the current object.
        /// </summary>
        /// <returns>AddressCollection</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public AddressCollection GetAccessibilityRelations()
        {
            var result = new AddressCollection(Interop.ControlDevel.DaliToolkitDevelControlNewGetAccessibilityRelations(SwigCPtr));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return result;
        }

        ///////////////////////////////////////////////////////////////////
        // ********************* ReadingInfoType *********************** //
        ///////////////////////////////////////////////////////////////////

        /// <summary>
        /// Sets accessibility reading information.
        /// </summary>
        /// <param name="type">Reading information type</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SetAccessibilityReadingInfoTypes(AccessibilityReadingInfoTypes type)
        {
            Interop.ControlDevel.DaliToolkitDevelControlSetAccessibilityReadingInfoTypes(SwigCPtr, (int)type);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Gets accessibility reading information.
        /// </summary>
        /// <returns>Reading information type</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public AccessibilityReadingInfoTypes GetAccessibilityReadingInfoTypes()
        {
            AccessibilityReadingInfoTypes result = (AccessibilityReadingInfoTypes)Interop.ControlDevel.DaliToolkitDevelControlGetAccessibilityReadingInfoTypes(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return result;
        }

        ///////////////////////////////////////////////////////////////////
        // ******************** Accessibility States ******************* //
        ///////////////////////////////////////////////////////////////////

        /// <summary>
        /// Notifies sending notifications about the current states to accessibility clients.
        /// </summary>
        /// <remarks>
        /// If recursive is true, all children of the Accessibility object will also re-emit the states.
        /// </remarks>
        /// <param name="states">Accessibility States</param>
        /// <param name="recursive">Flag to point if notifications of children's state would be sent</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void NotifyAccessibilityStatesChange(AccessibilityStates states, bool recursive)
        {
            Interop.ControlDevel.DaliToolkitDevelControlNotifyAccessibilityStatesChange(SwigCPtr, (ulong)states, Convert.ToInt32(recursive));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Gets Accessibility States.
        /// </summary>
        /// <returns>Accessibility States</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public AccessibilityStates GetAccessibilityStates()
        {
            AccessibilityStates result = (AccessibilityStates) Interop.ControlDevel.DaliToolkitDevelControlGetAccessibilityStates(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return result;
        }

        ///////////////////////////////////////////////////////////////////
        // ************************ Accessible ************************* //
        ///////////////////////////////////////////////////////////////////

        /// <summary>
        /// Emits accessibility property changed event.
        /// </summary>
        /// <param name="changeEvent">Property changed event</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void EmitAccessibilityEvent(AccessibilityPropertyChangeEvent changeEvent)
        {
            Interop.ControlDevel.DaliAccessibilityEmitAccessibilityEvent(SwigCPtr, Convert.ToInt32(changeEvent));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Emits accessibility states changed event.
        /// </summary>
        /// <param name="state">Accessibility state</param>
        /// <param name="equal">True if the state is set or enabled, otherwise false</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void EmitAccessibilityStatesChangedEvent(AccessibilityStates state, bool equal)
        {
            Interop.ControlDevel.DaliAccessibilityEmitAccessibilityStatesChangedEvent(SwigCPtr, (ulong)state, Convert.ToInt32(equal));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Emits accessibility text inserted event.
        /// </summary>
        /// <param name="cursorPosition">Text cursor position</param>
        /// <param name="length">Text length</param>
        /// <param name="content">Inserted text content</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void EmitTextInsertedEvent(int cursorPosition, int length, string content)
        {
            Interop.ControlDevel.DaliAccessibilityEmitTextInsertedEvent(SwigCPtr, cursorPosition, length, content);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Emits accessibility text deleted event.
        /// </summary>
        /// <param name="cursorPosition">Text cursor position</param>
        /// <param name="length">Text length</param>
        /// <param name="content">Inserted text content</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void EmitTextDeletedEvent(int cursorPosition, int length, string content)
        {
            Interop.ControlDevel.DaliAccessibilityEmitTextDeletedEvent(SwigCPtr, cursorPosition, length, content);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Emits accessibility text cursor moved event.
        /// </summary>
        /// <param name="cursorPosition">The new cursor position</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void EmitTextCursorMovedEvent(int cursorPosition)
        {
            Interop.ControlDevel.DaliAccessibilityEmitTextCursorMovedEvent(SwigCPtr, cursorPosition);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        ///////////////////////////////////////////////////////////////////
        // ************************** Bridge *************************** //
        ///////////////////////////////////////////////////////////////////

        /// <summary>
        /// Registers popup component to accessibility tree.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void RegisterPopup()
        {
            Interop.ControlDevel.DaliAccessibilityBridgeRegisterPopup(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Removes the previously added popup to accessibility tree.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void RemovePopup()
        {
            Interop.ControlDevel.DaliAccessibilityBridgeRemovePopup(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        private IntPtr DuplicateString(string value)
        {
            return Interop.ControlDevel.DaliToolkitDevelControlAccessibleImplNUIDuplicateString(value ?? "");
        }

        private IntPtr DuplicateStates(AccessibilityStates states)
        {
            return Interop.ControlDevel.DaliToolkitDevelControlConvertState((ulong)states);
        }

        private IntPtr DuplicateRange(AccessibilityRange range)
        {
            return Interop.ControlDevel.DaliAccessibilityNewRange(range.StartOffset, range.EndOffset, range.Content);
        }

        private Interop.ControlDevel.AccessibilityDelegate accessibilityDelegate = null;
        private IntPtr accessibilityDelegatePtr;

        /// <summary>
        /// Sets the specific constructor for creating accessibility structure with its role and interface.
        /// </summary>
        /// <remarks>
        /// The method should be called inside OnInitialize method of all classes inheriting from View.
        /// </remarks>
        /// <param name="role">Accessibility role</param>
        /// <param name="accessibilityInterface">Accessibility interface</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SetAccessibilityConstructor(Role role, AccessibilityInterface accessibilityInterface = AccessibilityInterface.None)
        {
            var size = Marshal.SizeOf<Interop.ControlDevel.AccessibilityDelegate>();

            if (accessibilityDelegate == null)
            {
                accessibilityDelegate = new Interop.ControlDevel.AccessibilityDelegate()
                {
                    GetName = () => DuplicateString(AccessibilityGetName()),
                    GetDescription = () => DuplicateString(AccessibilityGetDescription()),
                    DoAction = (name) => AccessibilityDoAction(Marshal.PtrToStringAnsi(name)),
                    CalculateStates = () => DuplicateStates(AccessibilityCalculateStates()),
                    GetActionCount = () => AccessibilityGetActionCount(),
                    GetActionName = (index) => DuplicateString(AccessibilityGetActionName(index)),
                    ShouldReportZeroChildren = () => AccessibilityShouldReportZeroChildren(),
                    GetMinimum = () => AccessibilityGetMinimum(),
                    GetCurrent = () => AccessibilityGetCurrent(),
                    GetMaximum = () => AccessibilityGetMaximum(),
                    SetCurrent = (value) => AccessibilitySetCurrent(value),
                    GetMinimumIncrement = () => AccessibilityGetMinimumIncrement(),
                    IsScrollable = () => AccessibilityIsScrollable(),
                    GetText = (startOffset, endOffset) => DuplicateString(AccessibilityGetText(startOffset, endOffset)),
                    GetCharacterCount = () => AccessibilityGetCharacterCount(),
                    GetCursorOffset = () => AccessibilityGetCursorOffset(),
                    SetCursorOffset = (offset) => AccessibilitySetCursorOffset(offset),
                    GetTextAtOffset = (offset, boundary) => DuplicateRange(AccessibilityGetTextAtOffset(offset, (AccessibilityTextBoundary)boundary)),
                    GetSelection = (selectionNumber) => DuplicateRange(AccessibilityGetSelection(selectionNumber)),
                    RemoveSelection = (selectionNumber) => AccessibilityRemoveSelection(selectionNumber),
                    SetSelection = (selectionNumber, startOffset, endOffset) => AccessibilitySetSelection(selectionNumber, startOffset, endOffset),
                    CopyText = (startPosition, endPosition) => AccessibilityCopyText(startPosition, endPosition),
                    CutText = (startPosition, endPosition) => AccessibilityCutText(startPosition, endPosition),
                };

                accessibilityDelegatePtr = Marshal.AllocHGlobal(size);
                Marshal.StructureToPtr(accessibilityDelegate, accessibilityDelegatePtr, false);
            }

            Interop.ControlDevel.DaliToolkitDevelControlSetAccessibilityConstructor(SwigCPtr, (int)role, (int)accessibilityInterface, accessibilityDelegatePtr, size);

            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// A helper method to manipulate individual bit flags (e.g. turn them on or off)
        /// </summary>
        /// <param name="obj">An object that accumulates combination of bit flags</param>
        /// <param name="bit">A bit flag to be operated</param>
        /// <param name="state">A state of the bit flag to be set (0 == off, 1 == on)</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        static public void FlagSetter<T>(ref T obj ,T bit, bool state)
        {
            dynamic result = obj;
            dynamic param = bit;
            if (state)
            {
                result |= param;
            }
            else
            {
                result &= (~param);
            }
            obj = result;
        }

        /// <summary>
        /// A helper method to manipulate individual bit flags (e.g. turn them on or off)
        /// </summary>
        /// <param name="obj">An object that accumulates combination of bit flags</param>
        /// <param name="bit">A bit flag to be operated</param>
        /// <param name="state">A state of the bit flag to be set (0 == off, 1 == on)</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        static public void FlagSetter<T>(ref T obj ,T bit, bool state)
        {
            dynamic result = obj;
            dynamic param = bit;
            if (state)
            {
                result |= param;
            }
            else
            {
                result &= (~param);
            }
            obj = result;
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);

            if (accessibilityDelegate != null)
            {
                Marshal.DestroyStructure<Interop.ControlDevel.AccessibilityDelegate>(accessibilityDelegatePtr);
                Marshal.FreeHGlobal(accessibilityDelegatePtr);
                accessibilityDelegate = null;
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
            {
                return AccessibilityActions[index];
            }
            else
            {
                return "";
            }
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
        protected virtual int AccessibilityGetCursorOffset()
        {
            return 0;
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        protected virtual bool AccessibilitySetCursorOffset(int offset)
        {
            return false;
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        protected virtual AccessibilityRange AccessibilityGetTextAtOffset(int offset, AccessibilityTextBoundary boundary)
        {
            return new AccessibilityRange();
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        protected virtual AccessibilityRange AccessibilityGetSelection(int selectionNumber)
        {
            return new AccessibilityRange();
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        protected virtual bool AccessibilityRemoveSelection(int selectionNumber)
        {
            return false;
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        protected virtual bool AccessibilitySetSelection(int selectionNumber, int startOffset, int endOffset)
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
