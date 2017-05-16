/*
* Copyright (c) 2016 Samsung Electronics Co., Ltd All Rights Reserved
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
using static Interop.Contacts;

namespace Tizen.Pims.Contacts
{
    /// <summary>
    /// A filter includes the conditions for the search
    /// </summary>
    public class ContactsFilter:IDisposable
    {
        internal IntPtr _filterHandle;

        /// <summary>
        /// Creates a filter with a condition for a string type property.
        /// </summary>
        /// <param name="viewUri">The view URI of a filter</param>
        /// <param name="propertyId">The property ID to add a condition</param>
        /// <param name="matchType">The match flag</param>
        /// <param name="matchValue">The match value</param>
        /// <exception cref="NotSupportedException">Thrown when an invoked method is not supported</exception>
        /// <exception cref="ArgumentException">Thrown when one of the arguments provided to a method is not valid</exception>
        /// <exception cref="OutOfMemoryException">Thrown when failed due to out of memory</exception>
        public ContactsFilter(string viewUri, uint propertyId, StringMatchType matchType, string matchValue)
        {
            int error = Interop.Filter.ContactsFilterCreate(viewUri, out _filterHandle);
            if ((int)ContactsError.None != error)
            {
                Log.Error(Globals.LogTag, "ContactsFilter Failed with error " + error);
                throw ContactsErrorFactory.CheckAndCreateException(error);
            }

            error = Interop.Filter.ContactsFilterAddStr(_filterHandle, propertyId, matchType, matchValue);
            if ((int)ContactsError.None != error)
            {
                Log.Error(Globals.LogTag, "ContactsFilter Failed with error " + error);
                throw ContactsErrorFactory.CheckAndCreateException(error);
            }
        }

        /// <summary>
        /// Creates a filter with a condition for an integer type property.
        /// </summary>
        /// <param name="viewUri">The view URI of a filter</param>
        /// <param name="propertyId">The property ID to add a condition</param>
        /// <param name="matchType">The match flag</param>
        /// <param name="matchValue">The match value</param>
        /// <exception cref="NotSupportedException">Thrown when an invoked method is not supported</exception>
        /// <exception cref="ArgumentException">Thrown when one of the arguments provided to a method is not valid</exception>
        /// <exception cref="OutOfMemoryException">Thrown when failed due to out of memory</exception>
        public ContactsFilter(string viewUri, uint propertyId, IntegerMatchType matchType, int matchValue)
        {
            int error = Interop.Filter.ContactsFilterCreate(viewUri, out _filterHandle);
            if ((int)ContactsError.None != error)
            {
                Log.Error(Globals.LogTag, "ContactsFilter Failed with error " + error);
                throw ContactsErrorFactory.CheckAndCreateException(error);
            }

            error = Interop.Filter.ContactsFilterAddInt(_filterHandle, propertyId, matchType, matchValue);
            if ((int)ContactsError.None != error)
            {
                Log.Error(Globals.LogTag, "ContactsFilter Failed with error " + error);
                throw ContactsErrorFactory.CheckAndCreateException(error);
            }
        }

        /// <summary>
        /// Creates a filter with a condition for a long type property.
        /// </summary>
        /// <param name="viewUri">The view URI of a filter</param>
        /// <param name="propertyId">The property ID to add a condition</param>
        /// <param name="matchType">The match flag</param>
        /// <param name="matchValue">The match value</param>
        /// <exception cref="NotSupportedException">Thrown when an invoked method is not supported</exception>
        /// <exception cref="ArgumentException">Thrown when one of the arguments provided to a method is not valid</exception>
        /// <exception cref="OutOfMemoryException">Thrown when failed due to out of memory</exception>
        public ContactsFilter(string viewUri, uint propertyId, IntegerMatchType matchType, long matchValue)
        {
            int error = Interop.Filter.ContactsFilterCreate(viewUri, out _filterHandle);
            if ((int)ContactsError.None != error)
            {
                Log.Error(Globals.LogTag, "ContactsFilter Failed with error " + error);
                throw ContactsErrorFactory.CheckAndCreateException(error);
            }

            error = Interop.Filter.ContactsFilterAddLli(_filterHandle, propertyId, matchType, matchValue);
            if ((int)ContactsError.None != error)
            {
                Log.Error(Globals.LogTag, "ContactsFilter Failed with error " + error);
                throw ContactsErrorFactory.CheckAndCreateException(error);
            }
        }

        /// <summary>
        /// Creates a filter with a condition for a double type property.
        /// </summary>
        /// <param name="viewUri">The view URI of a filter</param>
        /// <param name="propertyId">The property ID to add a condition</param>
        /// <param name="matchType">The match flag</param>
        /// <param name="matchValue">The match value</param>
        /// <exception cref="NotSupportedException">Thrown when an invoked method is not supported</exception>
        /// <exception cref="ArgumentException">Thrown when one of the arguments provided to a method is not valid</exception>
        /// <exception cref="OutOfMemoryException">Thrown when failed due to out of memory</exception>
        public ContactsFilter(string viewUri, uint propertyId, IntegerMatchType matchType, double matchValue)
        {
            int error = Interop.Filter.ContactsFilterCreate(viewUri, out _filterHandle);
            if ((int)ContactsError.None != error)
            {
                Log.Error(Globals.LogTag, "ContactsFilter Failed with error " + error);
                throw ContactsErrorFactory.CheckAndCreateException(error);
            }

            error = Interop.Filter.ContactsFilterAddDouble(_filterHandle, propertyId, matchType, matchValue);
            if ((int)ContactsError.None != error)
            {
                Log.Error(Globals.LogTag, "ContactsFilter Failed with error " + error);
                throw ContactsErrorFactory.CheckAndCreateException(error);
            }
        }

        /// <summary>
        /// Creates a filter with a condition for a boolean type property.
        /// </summary>
        /// <param name="viewUri">The view URI of a filter</param>
        /// <param name="propertyId">The property ID to add a condition</param>
        /// <param name="matchType">The match flag</param>
        /// <param name="matchValue">The match value</param>
        /// <exception cref="NotSupportedException">Thrown when an invoked method is not supported</exception>
        /// <exception cref="ArgumentException">Thrown when one of the arguments provided to a method is not valid</exception>
        /// <exception cref="OutOfMemoryException">Thrown when failed due to out of memory</exception>
        public ContactsFilter(string viewUri, uint propertyId, bool matchValue)
        {
            int error = Interop.Filter.ContactsFilterCreate(viewUri, out _filterHandle);
            if ((int)ContactsError.None != error)
            {
                Log.Error(Globals.LogTag, "ContactsFilter Failed with error " + error);
                throw ContactsErrorFactory.CheckAndCreateException(error);
            }

            error = Interop.Filter.ContactsFilterAddBool(_filterHandle, propertyId, matchValue);
            if ((int)ContactsError.None != error)
            {
                Log.Error(Globals.LogTag, "ContactsFilter Failed with error " + error);
                throw ContactsErrorFactory.CheckAndCreateException(error);
            }
        }

        ~ContactsFilter()
        {
            Dispose(false);
        }

        /// <summary>
        /// Enumeration for the filter match type of a string.
        /// </summary>
        public enum StringMatchType
        {
            /// <summary>
            /// Full string, case-sensitive
            /// </summary>
            Exactly,
            /// <summary>
            /// Full string, case-insensitive
            /// </summary>
            FullString,
            /// <summary>
            /// Sub string, case-insensitive
            /// </summary>
            Contains,
            /// <summary>
            /// Start with, case-insensitive
            /// </summary>
            StartsWith,
            /// <summary>
            /// End with, case-insensitive
            /// </summary>
            EndsWith,
            /// <summary>
            /// IS NOT NUL
            /// </summary>
            Exists,
        }

        /// <summary>
        /// Enumeration for the filter match type of an integer.
        /// </summary>
        public enum IntegerMatchType
        {
            /// <summary>
            /// '='
            /// </summary>
            Equal,
            /// <summary>
            /// '>'
            /// </summary>
            GreaterThan,
            /// <summary>
            /// '>='
            /// </summary>
            GreaterThanOrEqual,
            /// <summary>
            /// <
            /// </summary>
            LessThan,
            /// <summary>
            /// <=
            /// </summary>
            LessThanOrEqual,
            /// <summary>
            /// <>, this flag can yield poor performance
            /// </summary>
            NotEqual,
            /// <summary>
            /// IS NULL
            /// </summary>
            None,
        }

        /// <summary>
        /// Enumeration for a filter operator.
        /// </summary>
        public enum LogicalOperator
        {
            And,
            Or,
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                int error = Interop.Filter.ContactsFilterDestroy(_filterHandle);
                if ((int)ContactsError.None != error)
                {
                    Log.Error(Globals.LogTag, "ContactsFilterDestroy Failed with error " + error);
                }

                disposedValue = true;
            }
        }

        /// <summary>
        /// Releases all resources used by the ContactsFilter.
        /// It should be called after finished using of the object.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
        }
        #endregion

        /// <summary>
        /// Adds a condition for a string type property.
        /// </summary>
        /// <param name="logicalOperator">The operator type</param>
        /// <param name="propertyId">The property ID to add a condition</param>
        /// <param name="matchType">The match flag</param>
        /// <param name="matchValue">The match value</param>
        /// <exception cref="NotSupportedException">Thrown when an invoked method is not supported</exception>
        /// <exception cref="ArgumentException">Thrown when one of the arguments provided to a method is not valid</exception>
        public void AddCondition(LogicalOperator logicalOperator, uint propertyId, StringMatchType matchType, string matchValue)
        {
            int error = Interop.Filter.ContactsFilterAddOperator(_filterHandle, logicalOperator);
            if ((int)ContactsError.None != error)
            {
                Log.Error(Globals.LogTag, "AddCondition Failed with error " + error);
                throw ContactsErrorFactory.CheckAndCreateException(error);
            }

            error = Interop.Filter.ContactsFilterAddStr(_filterHandle, propertyId, matchType, matchValue);
            if ((int)ContactsError.None != error)
            {
                Log.Error(Globals.LogTag, "AddCondition Failed with error " + error);
                throw ContactsErrorFactory.CheckAndCreateException(error);
            }
        }

        /// <summary>
        /// Adds a condition for a integer type property.
        /// </summary>
        /// <param name="logicalOperator">The operator type</param>
        /// <param name="propertyId">The property ID to add a condition</param>
        /// <param name="matchType">The match flag</param>
        /// <param name="matchValue">The match value</param>
        /// <exception cref="NotSupportedException">Thrown when an invoked method is not supported</exception>
        /// <exception cref="ArgumentException">Thrown when one of the arguments provided to a method is not valid</exception>
        public void AddCondition(LogicalOperator logicalOperator, uint propertyId, IntegerMatchType matchType, int matchValue)
        {
            int error = Interop.Filter.ContactsFilterAddOperator(_filterHandle, logicalOperator);
            if ((int)ContactsError.None != error)
            {
                Log.Error(Globals.LogTag, "AddCondition Failed with error " + error);
                throw ContactsErrorFactory.CheckAndCreateException(error);
            }

            error = Interop.Filter.ContactsFilterAddInt(_filterHandle, propertyId, matchType, matchValue);
            if ((int)ContactsError.None != error)
            {
                Log.Error(Globals.LogTag, "AddCondition Failed with error " + error);
                throw ContactsErrorFactory.CheckAndCreateException(error);
            }
        }

        /// <summary>
        /// Adds a condition for a long type property.
        /// </summary>
        /// <param name="logicalOperator">The operator type</param>
        /// <param name="propertyId">The property ID to add a condition</param>
        /// <param name="matchType">The match flag</param>
        /// <param name="matchValue">The match value</param>
        /// <exception cref="NotSupportedException">Thrown when an invoked method is not supported</exception>
        /// <exception cref="ArgumentException">Thrown when one of the arguments provided to a method is not valid</exception>
        public void AddCondition(LogicalOperator logicalOperator, uint propertyId, IntegerMatchType matchType, long matchValue)
        {
            int error = Interop.Filter.ContactsFilterAddOperator(_filterHandle, logicalOperator);
            if ((int)ContactsError.None != error)
            {
                Log.Error(Globals.LogTag, "AddCondition Failed with error " + error);
                throw ContactsErrorFactory.CheckAndCreateException(error);
            }

            error = Interop.Filter.ContactsFilterAddLli(_filterHandle, propertyId, matchType, matchValue);
            if ((int)ContactsError.None != error)
            {
                Log.Error(Globals.LogTag, "AddCondition Failed with error " + error);
                throw ContactsErrorFactory.CheckAndCreateException(error);
            }
        }

        /// <summary>
        /// Adds a condition for a double type property.
        /// </summary>
        /// <param name="logicalOperator">The operator type</param>
        /// <param name="propertyId">The property ID to add a condition</param>
        /// <param name="matchType">The match flag</param>
        /// <param name="matchValue">The match value</param>
        /// <exception cref="NotSupportedException">Thrown when an invoked method is not supported</exception>
        /// <exception cref="ArgumentException">Thrown when one of the arguments provided to a method is not valid</exception>
        public void AddCondition(LogicalOperator logicalOperator, uint propertyId, IntegerMatchType matchType, double matchValue)
        {
            int error = Interop.Filter.ContactsFilterAddOperator(_filterHandle, logicalOperator);
            if ((int)ContactsError.None != error)
            {
                Log.Error(Globals.LogTag, "AddCondition Failed with error " + error);
                throw ContactsErrorFactory.CheckAndCreateException(error);
            }

            error = Interop.Filter.ContactsFilterAddDouble(_filterHandle, propertyId, matchType, matchValue);
            if ((int)ContactsError.None != error)
            {
                Log.Error(Globals.LogTag, "AddCondition Failed with error " + error);
                throw ContactsErrorFactory.CheckAndCreateException(error);
            }
        }

        /// <summary>
        /// Adds a condition for a boolean type property.
        /// </summary>
        /// <param name="logicalOperator">The operator type</param>
        /// <param name="propertyId">The property ID to add a condition</param>
        /// <param name="matchType">The match flag</param>
        /// <param name="matchValue">The match value</param>
        /// <exception cref="NotSupportedException">Thrown when an invoked method is not supported</exception>
        /// <exception cref="ArgumentException">Thrown when one of the arguments provided to a method is not valid</exception>
        public void AddCondition(LogicalOperator logicalOperator, uint propertyId, bool matchValue)
        {
            int error = Interop.Filter.ContactsFilterAddOperator(_filterHandle, logicalOperator);
            if ((int)ContactsError.None != error)
            {
                Log.Error(Globals.LogTag, "AddCondition Failed with error " + error);
                throw ContactsErrorFactory.CheckAndCreateException(error);
            }

            error = Interop.Filter.ContactsFilterAddBool(_filterHandle, propertyId, matchValue);
            if ((int)ContactsError.None != error)
            {
                Log.Error(Globals.LogTag, "AddCondition Failed with error " + error);
                throw ContactsErrorFactory.CheckAndCreateException(error);
            }
        }

        /// <summary>
        /// Adds a child filter to a parent filter.
        /// </summary>
        /// <param name="logicalOperator">The operator type</param>
        /// <param name="filter">The child filter</param>
        /// <exception cref="NotSupportedException">Thrown when an invoked method is not supported</exception>
        /// <exception cref="ArgumentException">Thrown when one of the arguments provided to a method is not valid</exception>
        public void AddFilter(LogicalOperator logicalOperator, ContactsFilter filter)
        {
            int error = Interop.Filter.ContactsFilterAddOperator(_filterHandle, logicalOperator);
            if ((int)ContactsError.None != error)
            {
                Log.Error(Globals.LogTag, "AddFilter Failed with error " + error);
                throw ContactsErrorFactory.CheckAndCreateException(error);
            }

            error = Interop.Filter.ContactsFilterAddFilter(_filterHandle, filter._filterHandle);
            if ((int)ContactsError.None != error)
            {
                Log.Error(Globals.LogTag, "AddFilter Failed with error " + error);
                throw ContactsErrorFactory.CheckAndCreateException(error);
            }
        }
    }
}
