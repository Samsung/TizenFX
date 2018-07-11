using System;
using System.Collections.Generic;

namespace Tizen.Applications.WatchfaceComplication
{
    /// <summary>
    /// Represents the EditablesContainer class for the watch application.
    /// </summary>
    /// <since_tizen> 5 </since_tizen>
    public abstract class EditablesContainer
    {
        internal IList<DesignElement> _deList = new List<DesignElement>();
        internal IList<Complication> _compList = new List<Complication>();
        internal IntPtr _container = IntPtr.Zero;
        private Interop.WatchfaceComplication.EditableUpdatedCallback _editableUpdatedCallback;
        private static string _logTag = "WatchfaceComplication";

        /// <summary>
        /// Initializes the EditablesContainer class.
        /// </summary>
        /// <exception cref="ArgumentException">Thrown when some parameter are invalid.</exception>
        /// <example>
        /// <code>
        ///
        /// </code>
        /// </example>
        /// <since_tizen> 5 </since_tizen>
        public EditablesContainer()
        {
            ComplicationError err = Interop.WatchfaceComplication.AddEditReadyCallback(EditReady, IntPtr.Zero);
            if (err != ComplicationError.None)
                ErrorFactory.ThrowException(err, "Fail to add edit ready callback");
            Log.Debug(_logTag, "Edit container ready");
        }

        /// <summary>
        /// Destructor of the EditablesContainer class.
        /// </summary>
        ~EditablesContainer()
        {
            Interop.WatchfaceComplication.RemoveEditReadyCallback(EditReady);
        }

        /// <summary>
        /// Adds the DesignElement to edit list.
        /// </summary>
        /// <exception cref="ArgumentException">Thrown when some parameter are invalid.</exception>
        /// <example>
        /// <code>
        ///
        /// </code>
        /// </example>
        /// <since_tizen> 5 </since_tizen>
        public void Add(DesignElement de, int editableId, Geometry geo)
        {
            if (IsExist(editableId))
                ErrorFactory.ThrowException(ComplicationError.ExistID);

            IEditable e = de;
            e.EditableId = editableId;
            e.Geometry = geo;
            _deList.Add(de);
        }

        /// <summary>
        /// Adds the Complication to edit list.
        /// </summary>
        /// <exception cref="ArgumentException">Thrown when some parameter are invalid.</exception>
        /// <example>
        /// <code>
        ///
        /// </code>
        /// </example>
        /// <since_tizen> 5 </since_tizen>
        public void Add(Complication comp, int editableId, Geometry geo)
        {
            if (IsExist(editableId))
                ErrorFactory.ThrowException(ComplicationError.ExistID);

            IEditable e = comp;
            e.EditableId = editableId;
            e.Geometry = geo;
            _compList.Add(comp);
        }

        /// <summary>
        /// Removes the editable from edit list.
        /// </summary>
        /// <exception cref="ArgumentException">Thrown when some parameter are invalid.</exception>
        /// <example>
        /// <code>
        ///
        /// </code>
        /// </example>
        /// <since_tizen> 5 </since_tizen>
        public void Remove(int editableId)
        {
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
        /// <example>
        /// <code>
        ///
        /// </code>
        /// </example>
        /// <returns>true if the editable is already exists in edit list, ortherwise false</returns>
        /// <since_tizen> 5 </since_tizen>
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
            IEditable ed = GetEditable(editableId);

            int currentIdx;
            err = Interop.WatchfaceComplication.GetCurrentIdx(handle, out currentIdx);
            ed.CurrentDataIndex = currentIdx;

            DesignElement de = GetDesignElement(editableId);
            if (de != null)
                de.NotifyUpdate(selectedIdx, (State)state);
        }

        /// <summary>
        /// Requests edit to editor appliation.
        /// </summary>
        /// <exception cref="ArgumentException">Thrown when some parameter are invalid.</exception>
        /// <example>
        /// <code>
        ///
        /// </code>
        /// </example>
        /// <since_tizen> 5 </since_tizen>
        public void RequestEdit(string editorId)
        {
            Log.Debug(_logTag, "request edit");
            ComplicationError ret;

            Interop.WatchfaceComplication.GetEditableContainer(out _container);
            if (_container == IntPtr.Zero)
            {
                ErrorFactory.ThrowException(ComplicationError.EditNotReady, "Editor not ready");
            }

            if (_editableUpdatedCallback == null)
                _editableUpdatedCallback = new Interop.WatchfaceComplication.EditableUpdatedCallback(EditableUpdatedCallback);

            foreach (Complication comp in _compList)
            {
                IEditable e = comp;
                if (e.Geometry == null || e.Geometry.Raw == IntPtr.Zero)
                {
                    Log.Warn(_logTag, "geometry is null");
                    continue;
                }
                Interop.WatchfaceComplication.AddComplication(_container, e.EditableId, comp.Raw, e.Geometry.Raw);
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
                Interop.WatchfaceComplication.AddDesignElement(_container, e.EditableId, e.CurrentDataIndex, candidates, e.Geometry.Raw, e.Name);
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
        /// <since_tizen> 5 </since_tizen>
        protected virtual void OnEditReady(string editorId)
        {

        }

        /// <summary>
        /// Loads the editable's current data.
        /// </summary>
        /// <remarks>
        /// This API loads editable's last current data which is updated by editor application.
        /// </remarks>
        /// <param name="editableId">The id of the editable.</param>
        /// <exception cref="System.ArgumentException">Thrown when editableId is invalid.</exception>
        /// <example>
        /// <code>
        ///
        /// </code>
        /// </example>
        /// <since_tizen> 5 </since_tizen>
        public Bundle LoadCurrentData(int editableId)
        {
            SafeBundleHandle handle;
            ComplicationError err = Interop.WatchfaceComplication.LoadCurrentData(editableId, out handle);
            if (err == ComplicationError.None)
                return new Bundle(handle);

            return null;
        }
    };
}