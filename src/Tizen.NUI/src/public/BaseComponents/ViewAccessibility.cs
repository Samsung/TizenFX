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
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.InteropServices;
using Tizen.NUI;

namespace Tizen.NUI.BaseComponents
{
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
        /// Dictionary of accessibility attributes (key-value pairs of strings).
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Dictionary<string, string> AccessibilityAttributes { get; } = new Dictionary<string, string>();

        /// <summary>
        /// Dictionary of dynamically-evaluated accessibility attributes (key-value pairs of strings).
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Dictionary<string, Func<string>> AccessibilityDynamicAttributes { get; } = new Dictionary<string, Func<string>>();

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
                return (this == Accessibility.Accessibility.GetCurrentlyHighlightedView());
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
        /// <returns>A dictionary mapping a relation type to a set of objects in that relation</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Dictionary<AccessibilityRelationType, List<View>> GetAccessibilityRelations()
        {
            var list = new List<KeyValuePair<int, IntPtr>>();
            var listHandle = GCHandle.Alloc(list);
            var callback = new Interop.ControlDevel.GetAccessibilityRelationsCallback(GetAccessibilityRelationsCallback);

            Interop.ControlDevel.DaliToolkitDevelControlGetAccessibilityRelations(SwigCPtr, callback, GCHandle.ToIntPtr(listHandle));
            listHandle.Free();
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();

            var result = new Dictionary<AccessibilityRelationType, List<View>>();

            foreach (var pair in list)
            {
                var key = (AccessibilityRelationType)pair.Key;
                var value = this.GetInstanceSafely<View>(pair.Value);

                if (!result.ContainsKey(key))
                {
                    result[key] = new List<View>();
                }

                result[key].Add(value);
            }

            return result;
        }

        private static void GetAccessibilityRelationsCallback(int relationType, IntPtr relationTarget, IntPtr userData)
        {
            var handle = GCHandle.FromIntPtr(userData);
            var list = (List<KeyValuePair<int, IntPtr>>)handle.Target;

            list.Add(new KeyValuePair<int, IntPtr>(relationType, relationTarget));
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
        /// In essence, this is equivalent to calling EmitAccessibilityStateChangedEvent in a loop for all specified states.
        /// If recursive mode is specified, all children of the Accessibility object will also re-emit the states.
        /// </remarks>
        /// <param name="states">Accessibility States</param>
        /// <param name="notifyMode">Controls the notification strategy</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void NotifyAccessibilityStatesChange(AccessibilityStates states, AccessibilityStatesNotifyMode notifyMode)
        {
            if (states is null)
            {
                throw new ArgumentNullException(nameof(states));
            }

            Interop.ControlDevel.DaliToolkitDevelControlNotifyAccessibilityStateChange(SwigCPtr, states.BitMask, (int)notifyMode);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Gets Accessibility States.
        /// </summary>
        /// <returns>Accessibility States</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public AccessibilityStates GetAccessibilityStates()
        {
            var result = new AccessibilityStates {BitMask = Interop.ControlDevel.DaliToolkitDevelControlGetAccessibilityStates(SwigCPtr)};
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
        public void EmitAccessibilityStateChangedEvent(AccessibilityState state, bool equal)
        {
            Interop.ControlDevel.DaliAccessibilityEmitAccessibilityStateChangedEvent(SwigCPtr, (int)state, Convert.ToInt32(equal));
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

        /// <summary>
        /// Emits accessibility scroll started event.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void EmitScrollStartedEvent()
        {
            Interop.ControlDevel.DaliAccessibilityEmitScrollStartedEvent(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Emits accessibility scroll finished event.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void EmitScrollFinishedEvent()
        {
            Interop.ControlDevel.DaliAccessibilityEmitScrollFinishedEvent(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Modifiable collection of suppressed AT-SPI events (D-Bus signals).
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public AccessibilityEvents AccessibilitySuppressedEvents
        {
            get
            {
                return new AccessibilityEvents {Owner = this};
            }
        }

        ///////////////////////////////////////////////////////////////////
        // ************************** Bridge *************************** //
        ///////////////////////////////////////////////////////////////////

        /// <summary>
        /// Registers component as a source of an accessibility "default label".
        /// The "Default label" is a text that could be read by screen-reader immediately
        /// after the navigation context has changed (window activates, popup shows up, tab changes)
        /// and before first UI element is highlighted.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void RegisterDefaultLabel()
        {
            Interop.ControlDevel.DaliAccessibilityBridgeRegisterDefaultLabel(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Unregisters component that has been registered previously as a source of an accessibility "default label".
        /// The "Default label" is a text that could be read by screen-reader immediately
        /// after the navigation context has changed (window activates, popup shows up, tab changes)
        /// and before first UI element is highlighted.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void UnregisterDefaultLabel()
        {
            Interop.ControlDevel.DaliAccessibilityBridgeUnregisterDefaultLabel(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void Dispose(bool disposing)
        {
            if (disposed)
            {
                return;
            }

            internalName = null;

            if (disposing == false)
            {
                if (IsNativeHandleInvalid() || SwigCMemOwn == false)
                {
                    // at this case, implicit nor explicit dispose is not required. No native object is made.
                    disposed = true;
                    return;
                }
            }

            if (disposing)
            {
                Unparent();
            }

            base.Dispose(disposing);
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
            if (name == AccessibilityActivateAction)
            {
                if (ActivateSignal?.Empty() == false)
                {
                    ActivateSignal?.Emit();
                    return true;
                }
                else
                {
                    return OnAccessibilityActivated();
                }
            }
            else if (name == AccessibilityReadingSkippedAction)
            {
                if (ReadingSkippedSignal?.Empty() == false)
                {
                    ReadingSkippedSignal?.Emit();
                    return true;
                }
                else
                {
                    return OnAccessibilityReadingSkipped();
                }
            }
            else if (name == AccessibilityReadingCancelledAction)
            {
                if (ReadingCancelledSignal?.Empty() == false)
                {
                    ReadingCancelledSignal?.Emit();
                    return true;
                }
                else
                {
                    return OnAccessibilityReadingCancelled();
                }
            }
            else if (name == AccessibilityReadingStoppedAction)
            {
                if (ReadingStoppedSignal?.Empty() == false)
                {
                    ReadingStoppedSignal?.Emit();
                    return true;
                }
                else
                {
                    return OnAccessibilityReadingStopped();
                }
            }
            else if (name == AccessibilityReadingPausedAction)
            {
                if (ReadingPausedSignal?.Empty() == false)
                {
                    ReadingPausedSignal?.Emit();
                    return true;
                }
                else
                {
                    return OnAccessibilityReadingPaused();
                }
            }
            else if (name == AccessibilityReadingResumedAction)
            {
                if (ReadingResumedSignal?.Empty() == false)
                {
                    ReadingResumedSignal?.Emit();
                    return true;
                }
                else
                {
                    return OnAccessibilityReadingResumed();
                }
            }
            else
            {
                return false;
            }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        protected virtual AccessibilityStates AccessibilityCalculateStates()
        {
            var states = AccessibilityInitialStates;

            states[AccessibilityState.Focused] = this.State == States.Focused;
            states[AccessibilityState.Enabled] = this.State != States.Disabled;
            states[AccessibilityState.Sensitive] = this.Sensitive;

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
        protected virtual bool AccessibilityIsScrollable()
        {
            return false;
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        protected virtual bool AccessibilityScrollToChild(View child)
        {
            return false;
        }

        /// <summary>
        /// This method is called when the control accessibility is activated.<br />
        /// Derived classes should override this to perform custom accessibility activation.<br />
        /// </summary>
        /// <returns>True if this control can perform accessibility activation.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected virtual bool OnAccessibilityActivated()
        {
            return false;
        }

        /// <summary>
        /// This method is called when reading is skipped.
        /// </summary>
        /// <returns>True if information was served.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected virtual bool OnAccessibilityReadingSkipped()
        {
            return false;
        }

        /// <summary>
        /// This method is called when reading is cancelled.
        /// </summary>
        /// <returns>True if information was served.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected virtual bool OnAccessibilityReadingCancelled()
        {
            return false;
        }

        /// <summary>
        /// This method is called when reading is stopped.
        /// </summary>
        /// <returns>True if information was served.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected virtual bool OnAccessibilityReadingStopped()
        {
            return false;
        }

        /// <summary>
        /// This method is called when reading was paused.
        /// </summary>
        /// <returns>True if information was served.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected virtual bool OnAccessibilityReadingPaused()
        {
            return false;
        }

        /// <summary>
        /// This method is called when reading is resumed.
        /// </summary>
        /// <returns>True if information was served.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected virtual bool OnAccessibilityReadingResumed()
        {
            return false;
        }
    }
}
