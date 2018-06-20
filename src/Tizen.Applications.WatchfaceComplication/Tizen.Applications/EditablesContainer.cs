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
        private Interop.WatchfaceComplication.EditableUpdatedCallback _updatedCallback;

        public int Add(DesignElement de, int editableId, Geometry geo)
        {
            IEditable e = de;
            e.EditableId = editableId;
            e.Geometry = geo;
            _deList.Add(de);
            return 0;
        }

        public int Add(Complication comp, int editableId, Geometry geo)
        {
            IEditable e = comp;
            e.EditableId = editableId;
            e.Geometry = geo;
            _compList.Add(comp);
            return 0;
        }

        public int Remove(IEditable ed)
        {
            return 0;
        }        
        public bool IsExist(int editableId)
        {
            return false;
        }

        private void EditReady(IntPtr container, string editorAppid, IntPtr userData)
        {
            _container = container;
            OnEditReady(editorAppid);
        }

        protected virtual void OnUpdate(IEditable ed, int selectedIdx, State state)
        {            

        }

        private void EditableUpdatedCallback(IntPtr handle, int selectedIdx,
            int state, IntPtr userData)
        {

        }

        public int RequestEdit(string editorId)
        {
            ComplicationError ret;
            if (_container == IntPtr.Zero)
            {
                ErrorFactory.ThrowException(ComplicationError.EditNotReady, "Editor not ready");
            }

            if (_updatedCallback == null)
                _updatedCallback = new Interop.WatchfaceComplication.EditableUpdatedCallback(EditableUpdatedCallback);

            foreach (Complication comp in _compList) 
            {
                IEditable e = comp;
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
            }

            ret = Interop.WatchfaceComplication.RequestEdit(_container, _updatedCallback, IntPtr.Zero);
            if (ret != ComplicationError.None)
            {
                ErrorFactory.ThrowException(ret, "Request edit fail");
            }

            return 0;
        }        

        protected virtual void OnEditReady(string editorId)
        {

        }
    };
}