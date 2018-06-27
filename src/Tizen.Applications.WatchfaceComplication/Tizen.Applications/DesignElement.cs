using System;
using System.Collections.Generic;

namespace Tizen.Applications.WatchfaceComplication
{
    public abstract class DesignElement : IEditable
    {

        private IEnumerable<Bundle> _candidates;
        private int _currentDataIndex;
        private Geometry _geometry;
        private string _editableName;
        private int _editableId;


        public DesignElement(IEnumerable<Bundle> candidates, int currentDataIndex, Geometry geometry, string editableName)
        {
            _candidates = candidates;
            _currentDataIndex = currentDataIndex;
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
                return _editableName;
            }
        }

        Geometry IEditable.Geometry
        {
            get
            {
                return _geometry;
            }
            set
            {
                _geometry = value;
            }
        }

        int IEditable.CurrentDataIndex
        {
            get
            {
                return _currentDataIndex;
            }
            set
            {
                _currentDataIndex = value;
            }
        }

        Bundle IEditable.GetCurrentData()
        {
            int idx = 0;
            foreach (Bundle data in _candidates)
            {
                if (idx == _currentDataIndex)
                    return data;
                idx++;
            }
            return null;
        }

        void IEditable.OnUpdate(int selectedIdx, State state)
        {
            OnDesignUpdate(selectedIdx, state);
        }

        protected virtual void OnDesignUpdate(int selectedIdx, State state)
        {
        }
    }
}
