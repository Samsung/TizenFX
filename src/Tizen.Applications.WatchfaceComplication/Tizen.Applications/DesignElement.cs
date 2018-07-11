using System;
using System.Collections.Generic;
using Tizen.Applications.WatchfaceComplication;

namespace Tizen.Applications.WatchfaceComplication
{
    /// <summary>
    /// Represents the DesignElement class for the watch application.
    /// </summary>
    /// <since_tizen> 5 </since_tizen>
    public abstract class DesignElement : IEditable
    {

        private IEnumerable<Bundle> _candidates;
        private int _currentDataIndex;
        private Geometry _geometry;
        private string _editableName;
        private int _editableId;

        /// <summary>
        /// Initializes the DesignElement class.
        /// </summary>
        /// <param name="candidates">The candidates list.</param>
        /// <param name="currentDataIndex">The current selected candidate index.</param>
        /// <param name="editableName">The design element name.</param>
        /// <exception cref="ArgumentException">Thrown when some parameter are invalid.</exception>
        /// <example>
        /// <code>
        ///
        /// </code>
        /// </example>
        /// <since_tizen> 5 </since_tizen>
        public DesignElement(IEnumerable<Bundle> candidates, int currentDataIndex, string editableName)
        {
            if (candidates == null || currentDataIndex < 0)
                ErrorFactory.ThrowException(ComplicationError.InvalidParam);
            IList<Bundle> candidatesList = (IList<Bundle>)candidates.GetEnumerator();

            if (candidatesList.Count < currentDataIndex)
                ErrorFactory.ThrowException(ComplicationError.InvalidParam);

            _candidates = candidates;
            _currentDataIndex = currentDataIndex;
            _editableName = editableName;
        }

        /// <summary>
        /// The information of Editable ID.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        int IEditable.EditableId
        {
            get
            {
                return _editableId;
            }
            set
            {
                _editableId = value;
            }
        }

        /// <summary>
        /// The information of Editable candidates.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        public IEnumerable<Bundle> Candidates
        {
            get
            {
                return _candidates;
            }
        }

        /// <summary>
        /// The information of Editable name.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        string IEditable.Name
        {
            get
            {
                return _editableName;
            }
        }

        /// <summary>
        /// The information of Editable geometry.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
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

        /// <summary>
        /// The information of Editable's current data index.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
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

        /// <summary>
        /// Gets the current selected data.
        /// </summary>
        /// <returns>Current data</returns>
        /// <since_tizen> 5 </since_tizen>
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

        internal void NotifyUpdate(int candidateIdx, State state)
        {
            OnDesignUpdated(candidateIdx, state);
        }

        /// <summary>
        /// Overrides this method to handle the behavior when the design element is updated.
        /// </summary>
        /// <param name="selectedIdx">The selected candidate index.</param>
        /// <param name="state">The update state.</param>
        /// <since_tizen> 5 </since_tizen>
        protected virtual void OnDesignUpdated(int selectedIdx, State state)
        {
        }
    }
}
