/*
 * Copyright (c) 2018 Samsung Electronics Co., Ltd All Rights Reserved
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
using System.Collections.Generic;

namespace Tizen.Applications.WatchfaceComplication
{
    /// <summary>
    /// Represents the EditablesContainer class for the watch application.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    public abstract class EditablesContainer : IDisposable
    {
        internal IList<DesignElement> _deList = new List<DesignElement>();
        internal IList<Complication> _compList = new List<Complication>();
        internal IntPtr _container = IntPtr.Zero;
        private Interop.WatchfaceComplication.EditableUpdateRequestedCallback _editableUpdatedCallback;
        private readonly Interop.WatchfaceComplication.EditReadyCallback _editReadyCallback;
        private bool _disposed = false;
        private static string _logTag = "WatchfaceComplication";

        /// <summary>
        /// Initializes the EditablesContainer class.
        /// </summary>
        /// <exception cref="ArgumentException">Thrown when some parameter are invalid.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the method failed due to invalid operation.</exception>
        /// <exception cref="NotSupportedException">Thrown when the watchface complication is not supported.</exception>
        /// <since_tizen> 6 </since_tizen>
        protected EditablesContainer()
        {
            _editReadyCallback = new Interop.WatchfaceComplication.EditReadyCallback(EditReady);
            ComplicationError err = Interop.WatchfaceComplication.AddEditReadyCallback(_editReadyCallback, IntPtr.Zero);
            if (err != ComplicationError.None)
                ErrorFactory.ThrowException(err, "Fail to add edit ready callback");
            Log.Debug(_logTag, "Edit container ready");
        }

        /// <summary>
        /// Destructor of the EditablesContainer class.
        /// </summary>
        ~EditablesContainer()
        {
            Dispose(false);
        }

        /// <summary>
        /// Adds the DesignElement to edit list.
        /// </summary>
        /// <param name="de">The DesignElement object.</param>
        /// <param name="editableId">The editable id.</param>
        /// <exception cref="ArgumentException">Thrown when the invalid parameter is passed.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the method failed due to invalid operation.</exception>
        /// <since_tizen> 6 </since_tizen>
        public void Add(DesignElement de, int editableId)
        {
            if (de == null)
                ErrorFactory.ThrowException(ComplicationError.InvalidParam);
            if (IsExist(editableId))
                ErrorFactory.ThrowException(ComplicationError.ExistID);

            IEditable e = de;
            e.EditableId = editableId;
            _deList.Add(de);
        }

        /// <summary>
        /// Adds the Complication to edit list.
        /// </summary>
        /// <param name="comp">The Complication object.</param>
        /// <param name="editableId">The editable id.</param>
        /// <exception cref="ArgumentException">Thrown when the invalid parameter is passed.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the method failed due to invalid operation.</exception>
        /// <since_tizen> 6 </since_tizen>
        public void Add(Complication comp, int editableId)
        {
            if (comp == null)
                ErrorFactory.ThrowException(ComplicationError.InvalidParam);
            if (IsExist(editableId))
                ErrorFactory.ThrowException(ComplicationError.ExistID);

            IEditable e = comp;
            e.EditableId = editableId;
            _compList.Add(comp);
        }

        /// <summary>
        /// Removes the editable from edit list.
        /// </summary>
        /// <param name="editableId">The editable id.</param>
        /// <exception cref="ArgumentException">Thrown when the invalid parameter is passed.</exception>
        /// <example>
        /// <code>
        /// if (myContainer.IsExist(_colorEditId)
        ///     myContainer.Remove(_colorEditId);
        /// </code>
        /// </example>
        /// <since_tizen> 6 </since_tizen>
        public void Remove(int editableId)
        {
            foreach (DesignElement de in _deList)
            {
                if (((IEditable)de).EditableId == editableId)
                {
                    _deList.Remove(de);
                    return;
                }
            }

            foreach (Complication comp in _compList)
            {
                if (((IEditable)comp).EditableId == editableId)
                {
                    _compList.Remove(comp);
                    return;
                }
            }

            ErrorFactory.ThrowException(ComplicationError.InvalidParam, "invalid editable ID");
        }

        internal IEditable GetEditable(int editableId)
        {
            foreach (IEditable ed in _deList)
            {
                if (ed.EditableId == editableId)
                    return ed;
            }

            foreach (IEditable ed in _compList)
            {
                if (ed.EditableId == editableId)
                    return ed;
            }

            return null;
        }

        internal DesignElement GetDesignElement(int editableId)
        {
            foreach (DesignElement de in _deList)
            {
                IEditable ed = de;
                if (ed.EditableId == editableId)
                    return de;
            }

            return null;
        }

        /// <summary>
        /// Checks the editable with editableId is already exists in edit list.
        /// </summary>
        /// <param name="editableId">The target editable Id.</param>
        /// <returns>true if the editable is already exists in edit list, otherwise false</returns>
        /// <since_tizen> 6 </since_tizen>
        public bool IsExist(int editableId)
        {
            return (GetEditable(editableId) != null);
        }

        private void EditReady(IntPtr container, string editorAppid, IntPtr userData)
        {
            OnEditReady(editorAppid);
        }


        private void EditableUpdatedCallback(IntPtr handle, int selectedIdx,
            int state, IntPtr userData)
        {
            int editableId;
            ComplicationError err = Interop.WatchfaceComplication.GetEditableId(handle, out editableId);
            if (err != ComplicationError.None)
                ErrorFactory.ThrowException(err, "fail to get current index");

            int currentIdx;
            err = Interop.WatchfaceComplication.GetCurrentIdx(handle, out currentIdx);
            if (err != ComplicationError.None)
                ErrorFactory.ThrowException(err, "fail to get current index");

            DesignElement de = GetDesignElement(editableId);
            if (de != null)
            {
                de.SetCurrentDataIndex(currentIdx);
                de.NotifyUpdate(currentIdx, (State)state);
            }
        }

        /// <summary>
        /// Requests edit to editor application.
        /// </summary>
        /// <privilege>http://tizen.org/privilege/datasharing</privilege>
        /// <exception cref="InvalidOperationException">Thrown when the method failed due to invalid operation.</exception>
        /// <exception cref="NotSupportedException">Thrown when the watchface complication is not supported.</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when the application does not have privilege to access this method.</exception>
        /// <example>
        /// <code>
        /// public class MyContainer : EditablesContainer {
        ///     public MyContainer() : base()
        ///     {
        ///     }
        ///     protected override void OnEditReady(string editorId)
        ///     {
        ///         this.RequestEdit();
        ///     }
        /// }
        /// </code>
        /// </example>
        /// <since_tizen> 6 </since_tizen>
        public void RequestEdit()
        {
            Log.Debug(_logTag, "request edit");
            ComplicationError ret;

            Interop.WatchfaceComplication.GetEditableContainer(out _container);
            if (_container == IntPtr.Zero)
            {
                ErrorFactory.ThrowException(ComplicationError.EditNotReady, "Editor not ready");
            }

            if (_editableUpdatedCallback == null)
                _editableUpdatedCallback = new Interop.WatchfaceComplication.EditableUpdateRequestedCallback(EditableUpdatedCallback);

            foreach (Complication comp in _compList)
            {
                IEditable e = comp;
                IntPtr hi = IntPtr.Zero;
                if (e.Highlight != null && e.Highlight.Raw != IntPtr.Zero)
                    hi = e.Highlight.Raw;
                Interop.WatchfaceComplication.AddComplication(_container, e.EditableId, comp._handle, hi);
            }

            foreach (DesignElement de in _deList)
            {
                IEditable e = de;
                IntPtr candidates;
                Interop.WatchfaceComplication.CreateCandidatesList(out candidates);
                foreach (Bundle b in de.Candidates)
                {
                    Interop.WatchfaceComplication.AddCandidatesListItem(candidates, b.SafeBundleHandle);
                }

                IntPtr hi = IntPtr.Zero;
                if (e.Highlight != null && e.Highlight.Raw != IntPtr.Zero)
                    hi = e.Highlight.Raw;
                Interop.WatchfaceComplication.AddDesignElement(_container, e.EditableId, e.GetCurrentDataIndex(), candidates, hi, e.Name);
                Log.Debug(_logTag, "Add design element done :" + e.Name);
            }

            ret = Interop.WatchfaceComplication.RequestEdit(_container, _editableUpdatedCallback, IntPtr.Zero);
            if (ret != ComplicationError.None)
            {
                ErrorFactory.ThrowException(ret, "Request edit fail");
            }
        }

        /// <summary>
        /// Overrides this method if you want to handle the behavior when the editor is ready to edit.
        /// </summary>
        /// <param name="editorId">The appid of ready to edit editor.</param>
        /// <since_tizen> 6 </since_tizen>
        protected abstract void OnEditReady(string editorId);

        /// <summary>
        /// Loads the editable's current data.
        /// </summary>
        /// <returns>The editable's latest data that selected by editor.</returns>
        /// <exception cref="ArgumentException">Thrown when some parameter are invalid.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the method failed due to invalid operation.</exception>
        /// <exception cref="NotSupportedException">Thrown when the watchface complication is not supported.</exception>
        /// <remarks>
        /// This API loads editable's last current data which is updated by editor application.
        /// </remarks>
        /// <param name="editableId">The id of the editable.</param>
        /// <example>
        /// <code>
        /// internal void InitEditables()
        /// {
        ///     _container = new MyContainer();
        ///     Bundle curData = EditablesContainer.LoadCurrentData(_colorEditId);
        ///     List&lt;Bundle&gt; candidatesList = new List&lt;Bundle&gt;();
        ///     int curIdx = 0;
        ///     int i = 0;
        ///     foreach (string str in _colorArr)
        ///     {
        ///         Bundle data = new Bundle();
        ///         data.AddItem(_colorKey, str);
        ///         candidatesList.Add(data);
        ///         if (curData != null &amp;&amp; curData.GetItem(_colorKey) != null
        ///             &amp;&amp; curData.GetItem(_colorKey).Equals(str))
        ///         {
        ///             curIdx = i;
        ///         }
        ///         i++;
        ///    }
        ///    ColorDesign colorEdit = new ColorDesign(candidatesList, curIdx, "COLOR", _complicationBtn);
        ///    colorEdit.Highlight = new Highlight(ShapeType.Circle, 0, 40, 10, 10);
        ///    _container.Add(colorEdit, _colorEditId);
        /// }
        /// </code>
        /// </example>
        /// <since_tizen> 6 </since_tizen>
        public static Bundle LoadCurrentData(int editableId)
        {
            SafeBundleHandle handle;
            ComplicationError err = Interop.WatchfaceComplication.LoadCurrentData(editableId, out handle);
            if (err == ComplicationError.None)
                return new Bundle(handle);

            return null;
        }

        /// <summary>
        /// Releases the unmanaged resources used by the EditablesContainer class specifying whether to perform a normal dispose operation.
        /// </summary>
        /// <param name="disposing">true for a normal dispose operation; false to finalize the handle.</param>
        /// <since_tizen> 3 </since_tizen>
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                Interop.WatchfaceComplication.RemoveEditReadyCallback(_editReadyCallback);
                _disposed = true;
            }
        }

        /// <summary>
        /// Releases all resources used by the EditablesContainer class.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    };
}