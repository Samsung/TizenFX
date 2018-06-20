using System;
using System.Collections.Generic;

namespace Tizen.Applications.WatchfaceComplication
{
    public abstract class DesignElement : IEditable
    {

        private IEnumerable<Bundle> _candidates;
        private int _curDataIdx;
        private Geometry _geometry;
        private string _editableName;
        private int _editableId;

        public DesignElement(IEnumerable<Bundle> candidates, int curDataIdx, Geometry geometry, string editableName)
        {
            _candidates = candidates;
            _curDataIdx = curDataIdx;
            _geometry = geometry;
            _editableName = editableName;
        }        

        int IEditable.EditableId
        {
            get
            {
                return 0;
            }
            set
            {
                _editableId = value;
            }
        }

        public IEnumerable<Bundle> Candidates
        {
            get
            {
                return _candidates;
            }
        }

        string IEditable.Name
        {
            get
            {
                return null;
            }
        }
       
        Geometry IEditable.Geometry { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        int IEditable.CurrentDataIndex
        {
            get
            {
                return _curDataIdx;
            }
        }

        State IEditable.State => throw new NotImplementedException();

        Bundle IEditable.GetNthData(int index)
        {
            throw new NotImplementedException();
        }
    }
}
