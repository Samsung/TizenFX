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
using System.Diagnostics.CodeAnalysis;

namespace Tizen.Pims.Contacts
{
    /// <summary>
    /// A filter includes the conditions for the search.
    /// </summary>
    /// <since_tizen> 4 </since_tizen>
    public class ContactsFilter:IDisposable
    {
        internal IntPtr _filterHandle;

        /// <summary>
        /// Creates a filter with a condition for a string type property.
        /// </summary>
        /// <param name="viewUri">The view URI of a filter.</param>
        /// <param name="propertyId">The property ID to add a condition.</param>
        /// <param name="matchType">The match flag.</param>
        /// <param name="matchValue">The match value.</param>
        /// <feature>http://tizen.org/feature/contact</feature>
        /// <exception cref="NotSupportedException">Thrown when the feature is not supported.</exception>
        /// <exception cref="ArgumentException">Thrown when one of the arguments provided to a method is not valid.</exception>
        /// <exception cref="OutOfMemoryException">Thrown when failed due to out of memory.</exception>
        /// <since_tizen> 4 </since_tizen>
        [SuppressMessage("Microsoft.Design", "CA1054:UriParametersShouldNotBeStrings")]
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
                Interop.Filter.ContactsFilterDestroy(_filterHandle);
                Log.Error(Globals.LogTag, "ContactsFilter Failed with error " + error);
                throw ContactsErrorFactory.CheckAndCreateException(error);
            }
        }

        /// <summary>
        /// Creates a filter with a condition for an integer type property.
        /// </summary>
        /// <param name="viewUri">The view URI of a filter.</param>
        /// <param name="propertyId">The property ID to add a condition.</param>
        /// <param name="matchType">The match flag.</param>
        /// <param name="matchValue">The match value.</param>
        /// <feature>http://tizen.org/feature/contact</feature>
        /// <exception cref="NotSupportedException">Thrown when the feature is not supported.</exception>
        /// <exception cref="ArgumentException">Thrown when one of the arguments provided to a method is not valid.</exception>
        /// <exception cref="OutOfMemoryException">Thrown when failed due to out of memory.</exception>
        /// <since_tizen> 4 </since_tizen>
        [SuppressMessage("Microsoft.Design", "CA1054:UriParametersShouldNotBeStrings")]
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
                Interop.Filter.ContactsFilterDestroy(_filterHandle);
                Log.Error(Globals.LogTag, "ContactsFilter Failed with error " + error);
                throw ContactsErrorFactory.CheckAndCreateException(error);
            }
        }

        /// <summary>
        /// Creates a filter with a condition for a long type property.
        /// </summary>
        /// <param name="viewUri">The view URI of a filter.</param>
        /// <param name="propertyId">The property ID to add a condition.</param>
        /// <param name="matchType">The match flag.</param>
        /// <param name="matchValue">The match value.</param>
        /// <feature>http://tizen.org/feature/contact</feature>
        /// <exception cref="NotSupportedException">Thrown when the feature is not supported.</exception>
        /// <exception cref="ArgumentException">Thrown when one of the arguments provided to a method is not valid.</exception>
        /// <exception cref="OutOfMemoryException">Thrown when failed due to out of memory.</exception>
        /// <since_tizen> 4 </since_tizen>
        [SuppressMessage("Microsoft.Design", "CA1054:UriParametersShouldNotBeStrings")]
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
                Interop.Filter.ContactsFilterDestroy(_filterHandle);
                Log.Error(Globals.LogTag, "ContactsFilter Failed with error " + error);
                throw ContactsErrorFactory.CheckAndCreateException(error);
            }
        }

        /// <summary>
        /// Creates a filter with a condition for a double type property.
        /// </summary>
        /// <param name="viewUri">The view URI of a filter.</param>
        /// <param name="propertyId">The property ID to add a condition.</param>
        /// <param name="matchType">The match flag.</param>
        /// <param name="matchValue">The match value.</param>
        /// <feature>http://tizen.org/feature/contact</feature>
        /// <exception cref="NotSupportedException">Thrown when the feature is not supported.</exception>
        /// <exception cref="ArgumentException">Thrown when one of the arguments provided to a method is not valid.</exception>
        /// <exception cref="OutOfMemoryException">Thrown when failed due to out of memory.</exception>
        /// <since_tizen> 4 </since_tizen>
        [SuppressMessage("Microsoft.Design", "CA1054:UriParametersShouldNotBeStrings")]
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
                Interop.Filter.ContactsFilterDestroy(_filterHandle);
                Log.Error(Globals.LogTag, "ContactsFilter Failed with error " + error);
                throw ContactsErrorFactory.CheckAndCreateException(error);
            }
        }

        /// <summary>
        /// Creates a filter with a condition for a boolean type property.
        /// </summary>
        /// <param name="viewUri">The view URI of a filter.</param>
        /// <param name="propertyId">The property ID to add a condition.</param>
        /// <param name="matchValue">The match value.</param>
        /// <feature>http://tizen.org/feature/contact</feature>
        /// <exception cref="NotSupportedException">Thrown when the feature is not supported.</exception>
        /// <exception cref="ArgumentException">Thrown when one of the arguments provided to a method is not valid.</exception>
        /// <exception cref="OutOfMemoryException">Thrown when failed due to out of memory.</exception>
        /// <since_tizen> 4 </since_tizen>
        [SuppressMessage("Microsoft.Design", "CA1054:UriParametersShouldNotBeStrings")]
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
                Interop.Filter.ContactsFilterDestroy(_filterHandle);
                Log.Error(Globals.LogTag, "ContactsFilter Failed with error " + error);
                throw ContactsErrorFactory.CheckAndCreateException(error);
            }
        }

        /// <summary>
        /// The destructor.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        ~ContactsFilter()
        {
            Dispose(false);
        }

        /// <summary>
        /// Enumeration for the filter match types of a string.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public enum StringMatchType
        {
            /// <summary>
            /// Full string, case-sensitive.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            Exactly,
            /// <summary>
            /// Full string, case-insensitive.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            FullString,
            /// <summary>
            /// Sub string, case-insensitive.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            Contains,
            /// <summary>
            /// Start with, case-insensitive.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            StartsWith,
            /// <summary>
            /// End with, case-insensitive.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            EndsWith,
            /// <summary>
            /// Is not null.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            Exists,
        }

        /// <summary>
        /// Enumeration for the filter match types of an integer.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public enum IntegerMatchType
        {
            /// <summary>
            /// =
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            Equal,
            /// <summary>
            /// &gt;
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            GreaterThan,
            /// <summary>
            /// &gt;=
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            GreaterThanOrEqual,
            /// <summary>
            /// &lt;
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            LessThan,
            /// <summary>
            /// &lt;=
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            LessThanOrEqual,
            /// <summary>
            /// &lt;&gt;, this flag can yield poor performance.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            NotEqual,
            /// <summary>
            /// Is null.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            None,
        }

        /// <summary>
        /// Enumeration for a filter operator.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public enum LogicalOperator
        {
            /// <summary>
            /// And.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            And,
            /// <summary>
            /// Or.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            Or,
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        /// <summary>
        /// Releases all the resources used by the ContactsFilter.
        /// </summary>
        /// <param name="disposing">Disposing by the user.</param>
        /// <since_tizen> 4 </since_tizen>
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                //Called by User
                //Release your own managed resources here.
                //You should release all of your own disposable objects here
            }

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
        /// Releases all the resources used by the ContactsFilter.
        /// It should be called after it has finished using the object.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion

        /// <summary>
        /// Adds a condition for a string type property.
        /// </summary>
        /// <param name="logicalOperator">The operator type.</param>
        /// <param name="propertyId">The property ID to add a condition.</param>
        /// <param name="matchType">The match flag.</param>
        /// <param name="matchValue">The match value.</param>
        /// <feature>http://tizen.org/feature/contact</feature>
        /// <exception cref="NotSupportedException">Thrown when the feature is not supported.</exception>
        /// <exception cref="ArgumentException">Thrown when one of the arguments provided to a method is not valid.</exception>
        /// <since_tizen> 4 </since_tizen>
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
        /// Adds a condition for an integer type property.
        /// </summary>
        /// <param name="logicalOperator">The operator type.</param>
        /// <param name="propertyId">The property ID to add a condition.</param>
        /// <param name="matchType">The match flag.</param>
        /// <param name="matchValue">The match value.</param>
        /// <feature>http://tizen.org/feature/contact</feature>
        /// <exception cref="NotSupportedException">Thrown when the feature is not supported.</exception>
        /// <exception cref="ArgumentException">Thrown when one of the arguments provided to a method is not valid.</exception>
        /// <since_tizen> 4 </since_tizen>
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
        /// <param name="logicalOperator">The operator type.</param>
        /// <param name="propertyId">The property ID to add a condition.</param>
        /// <param name="matchType">The match flag.</param>
        /// <param name="matchValue">The match value.</param>
        /// <feature>http://tizen.org/feature/contact</feature>
        /// <exception cref="NotSupportedException">Thrown when the feature is not supported.</exception>
        /// <exception cref="ArgumentException">Thrown when one of the arguments provided to a method is not valid.</exception>
        /// <since_tizen> 4 </since_tizen>
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
        /// <param name="logicalOperator">The operator type.</param>
        /// <param name="propertyId">The property ID to add a condition.</param>
        /// <param name="matchType">The match flag.</param>
        /// <param name="matchValue">The match value.</param>
        /// <feature>http://tizen.org/feature/contact</feature>
        /// <exception cref="NotSupportedException">Thrown when the feature is not supported.</exception>
        /// <exception cref="ArgumentException">Thrown when one of the arguments provided to a method is not valid.</exception>
        /// <since_tizen> 4 </since_tizen>
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
        /// <param name="logicalOperator">The operator type.</param>
        /// <param name="propertyId">The property ID to add a condition.</param>
        /// <param name="matchValue">The match value.</param>
        /// <feature>http://tizen.org/feature/contact</feature>
        /// <exception cref="NotSupportedException">Thrown when the feature is not supported.</exception>
        /// <exception cref="ArgumentException">Thrown when one of the arguments provided to a method is not valid.</exception>
        /// <since_tizen> 4 </since_tizen>
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
        /// <param name="logicalOperator">The operator type.</param>
        /// <param name="filter">The child filter.</param>
        /// <feature>http://tizen.org/feature/contact</feature>
        /// <exception cref="NotSupportedException">Thrown when the feature is not supported.</exception>
        /// <exception cref="ArgumentException">Thrown when one of the arguments provided to a method is not valid.</exception>
        /// <since_tizen> 4 </since_tizen>
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
