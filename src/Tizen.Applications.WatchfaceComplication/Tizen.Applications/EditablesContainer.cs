using System;
using System.Collections.Generic;
using System.Text;

namespace Tizen.Applications.WatchfaceComplication
{
    public abstract class EditablesContainer
    {
        internal IList<DesignElement> _deList = new List<DesignElement>();
        internal IList<Complication> _compList = new List<Complication>();
        internal IntPtr _container = IntPtr.Zero;
        private Interop.WatchfaceComplication.EditableUpdatedCallback _editableUpdatedCallback;
        private static string _logTag = "WatchfaceComplication";

        public EditablesContainer()
        {
            ComplicationError err = Interop.WatchfaceComplication.AddEditReadyCallback(EditReady, IntPtr.Zero);
            if (err != ComplicationError.None)
                ErrorFactory.ThrowException(err, "Fail to add edit ready callback");
            Log.Debug(_logTag, "Edit container ready");
        }

        ~EditablesContainer()
        {
            Interop.WatchfaceComplication.RemoveEditReadyCallback(EditReady);
        }

        public ComplicationError Add(DesignElement de, int editableId, Geometry geo)
        {
            if (IsExist(editableId))
                return ComplicationError.ExistID;

            IEditable e = de;
            e.EditableId = editableId;
            e.Geometry = geo;
            _deList.Add(de);
            return ComplicationError.None;
        }

        public ComplicationError Add(Complication comp, int editableId, Geometry geo)
        {
            if (IsExist(editableId))
                return ComplicationError.ExistID;

            IEditable e = comp;
            e.EditableId = editableId;
            e.Geometry = geo;
            _compList.Add(comp);
            return ComplicationError.None;
        }

        public int Remove(int editableId)
        {
            return 0;
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

        public bool IsExist(int editableId)
        {
            return (GetEditable(editableId) != null);
        }

        private void EditReady(IntPtr container, string editorAppid, IntPtr userData)
        {
            OnEditReady(editorAppid);
        }

        protected virtual void OnUpdate(IEditable ed, int selectedIdx, State state)
        {

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

            OnUpdate(ed, selectedIdx, (State)state);
        }

        public ComplicationError RequestEdit(string editorId)
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

            return ComplicationError.None;
        }

        protected virtual void OnEditReady(string editorId)
        {

        }
    };
}