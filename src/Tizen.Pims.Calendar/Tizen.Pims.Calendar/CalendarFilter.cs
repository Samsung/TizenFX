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

namespace Tizen.Pims.Calendar
{
    /// <summary>
    /// A filter includes the conditions for the search.
    /// </summary>
    /// <since_tizen> 4 </since_tizen>
    public class CalendarFilter:IDisposable
    {
        internal IntPtr _filterHandle;

        /// <summary>
        /// Creates a filter with a condition for a string type.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        /// <feature>http://tizen.org/feature/calendar</feature>
        /// <param name="viewUri">The view URI of a filter.</param>
        /// <param name="propertyId">The property ID to add a condition.</param>
        /// <param name="matchType">The match flag.</param>
        /// <param name="matchValue">The match value.</param>
        /// <exception cref="NotSupportedException">Thrown when the feature is not supported.</exception>
        /// <exception cref="ArgumentException">Thrown when one of the arguments provided to a method is not valid.</exception>
        /// <exception cref="OutOfMemoryException">Thrown when failed due to out of memory.</exception>
        [SuppressMessage("Microsoft.Design", "CA1054:UriParametersShouldNotBeStrings")]
        public CalendarFilter(string viewUri, uint propertyId, StringMatchType matchType, string matchValue)
        {
            int error = 0;
            error = Interop.Filter.Create(viewUri, out _filterHandle);
            if (CalendarError.None != (CalendarError)error)
            {
                Log.Error(Globals.LogTag, "CalendarFilter Failed with error " + error);
                throw CalendarErrorFactory.GetException(error);
            }

            error = Interop.Filter.AddString(_filterHandle, propertyId, matchType, matchValue);
            if (CalendarError.None != (CalendarError)error)
            {
                Interop.Filter.Destroy(_filterHandle);
                Log.Error(Globals.LogTag, "CalendarFilter Failed with error " + error);
                throw CalendarErrorFactory.GetException(error);
            }
        }

        /// <summary>
        /// Creates a filter with a condition for an integer type.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        /// <feature>http://tizen.org/feature/calendar</feature>
        /// <param name="viewUri">The view URI of a filter.</param>
        /// <param name="propertyId">The property ID to add a condition.</param>
        /// <param name="matchType">The match flag.</param>
        /// <param name="matchValue">The match value.</param>
        /// <exception cref="NotSupportedException">Thrown when the feature is not supported.</exception>
        /// <exception cref="ArgumentException">Thrown when one of the arguments provided to a method is not valid.</exception>
        /// <exception cref="OutOfMemoryException">Thrown when failed due to out of memory.</exception>
        [SuppressMessage("Microsoft.Design", "CA1054:UriParametersShouldNotBeStrings")]
        public CalendarFilter(string viewUri, uint propertyId, IntegerMatchType matchType, int matchValue)
        {
            int error = 0;
            error = Interop.Filter.Create(viewUri, out _filterHandle);
            if (CalendarError.None != (CalendarError)error)
            {
                Log.Error(Globals.LogTag, "CalendarFilter Failed with error " + error);
                throw CalendarErrorFactory.GetException(error);
            }

            error = Interop.Filter.AddInteger(_filterHandle, propertyId, matchType, matchValue);
            if (CalendarError.None != (CalendarError)error)
            {
                Interop.Filter.Destroy(_filterHandle);
                Log.Error(Globals.LogTag, "CalendarFilter Failed with error " + error);
                throw CalendarErrorFactory.GetException(error);
            }
        }

        /// <summary>
        /// Creates a filter with a condition for a long type.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        /// <feature>http://tizen.org/feature/calendar</feature>
        /// <param name="viewUri">The view URI of a filter.</param>
        /// <param name="propertyId">The property ID to add a condition.</param>
        /// <param name="matchType">The match flag.</param>
        /// <param name="matchValue">The match value.</param>
        /// <exception cref="NotSupportedException">Thrown when the feature is not supported.</exception>
        /// <exception cref="ArgumentException">Thrown when one of the arguments provided to a method is not valid.</exception>
        /// <exception cref="OutOfMemoryException">Thrown when failed due to out of memory.</exception>
        [SuppressMessage("Microsoft.Design", "CA1054:UriParametersShouldNotBeStrings")]
        public CalendarFilter(string viewUri, uint propertyId, IntegerMatchType matchType, long matchValue)
        {
            int error = 0;
            error = Interop.Filter.Create(viewUri, out _filterHandle);
            if (CalendarError.None != (CalendarError)error)
            {
                Log.Error(Globals.LogTag, "CalendarFilter Failed with error " + error);
                throw CalendarErrorFactory.GetException(error);
            }

            error = Interop.Filter.AddLong(_filterHandle, propertyId, matchType, matchValue);
            if (CalendarError.None != (CalendarError)error)
            {
                Interop.Filter.Destroy(_filterHandle);
                Log.Error(Globals.LogTag, "CalendarFilter Failed with error " + error);
                throw CalendarErrorFactory.GetException(error);
            }
        }

        /// <summary>
        /// Creates a filter with a condition for a double type.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        /// <feature>http://tizen.org/feature/calendar</feature>
        /// <param name="viewUri">The view URI of a filter.</param>
        /// <param name="propertyId">The property ID to add a condition.</param>
        /// <param name="matchType">The match flag.</param>
        /// <param name="matchValue">The match value.</param>
        /// <exception cref="NotSupportedException">Thrown when the feature is not supported.</exception>
        /// <exception cref="ArgumentException">Thrown when one of the arguments provided to a method is not valid.</exception>
        /// <exception cref="OutOfMemoryException">Thrown when failed due to out of memory.</exception>
        [SuppressMessage("Microsoft.Design", "CA1054:UriParametersShouldNotBeStrings")]
        public CalendarFilter(string viewUri, uint propertyId, IntegerMatchType matchType, double matchValue)
        {
            int error = 0;
            error = Interop.Filter.Create(viewUri, out _filterHandle);
            if (CalendarError.None != (CalendarError)error)
            {
                Log.Error(Globals.LogTag, "CalendarFilter Failed with error " + error);
                throw CalendarErrorFactory.GetException(error);
            }

            error = Interop.Filter.AddDouble(_filterHandle, propertyId, matchType, matchValue);
            if (CalendarError.None != (CalendarError)error)
            {
                Interop.Filter.Destroy(_filterHandle);
                Log.Error(Globals.LogTag, "CalendarFilter Failed with error " + error);
                throw CalendarErrorFactory.GetException(error);
            }
        }

        /// <summary>
        /// Creates a filter with a condition for the CalendarTime type.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        /// <feature>http://tizen.org/feature/calendar</feature>
        /// <param name="viewUri">The view URI of a filter.</param>
        /// <param name="propertyId">The property ID to add a condition.</param>
        /// <param name="matchType">The match flag.</param>
        /// <param name="matchValue">The match value.</param>
        /// <exception cref="NotSupportedException">Thrown when the feature is not supported.</exception>
        /// <exception cref="ArgumentException">Thrown when one of the arguments provided to a method is not valid.</exception>
        /// <exception cref="OutOfMemoryException">Thrown when failed due to out of memory.</exception>
        [SuppressMessage("Microsoft.Design", "CA1054:UriParametersShouldNotBeStrings")]
        public CalendarFilter(string viewUri, uint propertyId, IntegerMatchType matchType, CalendarTime matchValue)
        {
            int error = 0;
            error = Interop.Filter.Create(viewUri, out _filterHandle);
            if (CalendarError.None != (CalendarError)error)
            {
                Log.Error(Globals.LogTag, "CalendarFilter Failed with error " + error);
                throw CalendarErrorFactory.GetException(error);
            }

            IntPtr time = CalendarRecord.ConvertCalendarTimeToStruct(matchValue);
            error = Interop.Filter.AddCalendarTime(_filterHandle, propertyId, matchType, time);
            if (CalendarError.None != (CalendarError)error)
            {
                Interop.Filter.Destroy(_filterHandle);
                Log.Error(Globals.LogTag, "CalendarFilter Failed with error " + error);
                throw CalendarErrorFactory.GetException(error);
            }
        }

        /// <summary>
        /// Destroys the filter.
        /// </summary>
        ~CalendarFilter()
        {
            Dispose(false);
        }

        /// <summary>
        /// Enumeration for the filter match type of a string.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public enum StringMatchType
        {
            /// <summary>
            /// Full string, case-sensitive.
            /// </summary>
            Exactly,
            /// <summary>
            /// Full string, case-insensitive.
            /// </summary>
            FullString,
            /// <summary>
            /// Sub-string, case-insensitive.
            /// </summary>
            Contains,
            /// <summary>
            /// Starts with, case-insensitive.
            /// </summary>
            StartsWith,
            /// <summary>
            /// Ends with, case-insensitive.
            /// </summary>
            EndsWith,
            /// <summary>
            /// IS NOT NULL.
            /// </summary>
            Exists,
        }

        /// <summary>
        /// Enumeration for the filter match type of an integer.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
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
            /// &lt;
            /// </summary>
            LessThan,
            /// <summary>
            /// &lt;=
            /// </summary>
            LessThanOrEqual,
            /// <summary>
            /// &lt;>, this flag can yield poor performance.
            /// </summary>
            NotEqual,
            /// <summary>
            /// IS NULL.
            /// </summary>
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
            And,
            /// <summary>
            /// Or.
            /// </summary>
            Or,
        }

#region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        /// <summary>
        /// Dispose.
        /// </summary>
        /// <param name="disposing">true to release both managed and unmanaged resources, false to release only unmanaged resources.</param>
        /// <since_tizen> 4 </since_tizen>
        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                Log.Debug(Globals.LogTag, "Dispose :" + disposing);

                int error = Interop.Filter.Destroy(_filterHandle);
                if (CalendarError.None != (CalendarError)error)
                {
                    Log.Error(Globals.LogTag, "Destroy Failed with error " + error);
                }
                disposedValue = true;
            }
        }

        /// <summary>
        /// Releases all the resources used by the CalendarFilter.
        /// It should be called after having finished using the object.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
#endregion

        /// <summary>
        /// Adds a condition for the string type.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        /// <feature>http://tizen.org/feature/calendar</feature>
        /// <param name="logicalOperator">The operator type.</param>
        /// <param name="propertyId">The property ID to add a condition.</param>
        /// <param name="matchType">The match flag.</param>
        /// <param name="matchValue">The match value.</param>
        /// <exception cref="NotSupportedException">Thrown when the feature is not supported.</exception>
        /// <exception cref="ArgumentException">Thrown when one of the arguments provided to a method is not valid.</exception>
        public void AddCondition(LogicalOperator logicalOperator, uint propertyId, StringMatchType matchType, string matchValue)
        {
            int error = Interop.Filter.AddOperator(_filterHandle, logicalOperator);
            if (CalendarError.None != (CalendarError)error)
            {
                Log.Error(Globals.LogTag, "AddCondition Failed with error " + error);
                throw CalendarErrorFactory.GetException(error);
            }

            error = Interop.Filter.AddString(_filterHandle, propertyId, matchType, matchValue);
            if (CalendarError.None != (CalendarError)error)
            {
                Log.Error(Globals.LogTag, "AddCondition Failed with error " + error);
                throw CalendarErrorFactory.GetException(error);
            }
        }

        /// <summary>
        /// Adds a condition for the integer type.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        /// <feature>http://tizen.org/feature/calendar</feature>
        /// <param name="logicalOperator">The operator type.</param>
        /// <param name="propertyId">The property ID to add a condition.</param>
        /// <param name="matchType">The match flag.</param>
        /// <param name="matchValue">The match value.</param>
        /// <exception cref="NotSupportedException">Thrown when the feature is not supported.</exception>
        /// <exception cref="ArgumentException">Thrown when one of the arguments provided to a method is not valid.</exception>
        public void AddCondition(LogicalOperator logicalOperator, uint propertyId, IntegerMatchType matchType, int matchValue)
        {
            int error = Interop.Filter.AddOperator(_filterHandle, logicalOperator);
            if (CalendarError.None != (CalendarError)error)
            {
                Log.Error(Globals.LogTag, "AddCondition Failed with error " + error);
                throw CalendarErrorFactory.GetException(error);
            }

            error = Interop.Filter.AddInteger(_filterHandle, propertyId, matchType, matchValue);
            if (CalendarError.None != (CalendarError)error)
            {
                Log.Error(Globals.LogTag, "AddCondition Failed with error " + error);
                throw CalendarErrorFactory.GetException(error);
            }
        }

        /// <summary>
        /// Adds a condition for the long type.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        /// <feature>http://tizen.org/feature/calendar</feature>
        /// <param name="logicalOperator">The operator type.</param>
        /// <param name="propertyId">The property ID to add a condition.</param>
        /// <param name="matchType">The match flag.</param>
        /// <param name="matchValue">The match value.</param>
        /// <exception cref="NotSupportedException">Thrown when the feature is not supported.</exception>
        /// <exception cref="ArgumentException">Thrown when one of the arguments provided to a method is not valid.</exception>
        public void AddCondition(LogicalOperator logicalOperator, uint propertyId, IntegerMatchType matchType, long matchValue)
        {
            int error = Interop.Filter.AddOperator(_filterHandle, logicalOperator);
            if (CalendarError.None != (CalendarError)error)
            {
                Log.Error(Globals.LogTag, "AddCondition Failed with error " + error);
                throw CalendarErrorFactory.GetException(error);
            }

            error = Interop.Filter.AddLong(_filterHandle, propertyId, matchType, matchValue);
            if (CalendarError.None != (CalendarError)error)
            {
                Log.Error(Globals.LogTag, "AddCondition Failed with error " + error);
                throw CalendarErrorFactory.GetException(error);
            }
        }

        /// <summary>
        /// Adds a condition for the double type.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        /// <feature>http://tizen.org/feature/calendar</feature>
        /// <param name="logicalOperator">The operator type.</param>
        /// <param name="propertyId">The property ID to add a condition.</param>
        /// <param name="matchType">The match flag.</param>
        /// <param name="matchValue">The match value.</param>
        /// <exception cref="NotSupportedException">Thrown when the feature is not supported.</exception>
        /// <exception cref="ArgumentException">Thrown when one of the arguments provided to a method is not valid.</exception>
        public void AddCondition(LogicalOperator logicalOperator, uint propertyId, IntegerMatchType matchType, double matchValue)
        {
            int error = Interop.Filter.AddOperator(_filterHandle, logicalOperator);
            if (CalendarError.None != (CalendarError)error)
            {
                Log.Error(Globals.LogTag, "AddCondition Failed with error " + error);
                throw CalendarErrorFactory.GetException(error);
            }

            error = Interop.Filter.AddDouble(_filterHandle, propertyId, matchType, matchValue);
            if (CalendarError.None != (CalendarError)error)
            {
                Log.Error(Globals.LogTag, "AddCondition Failed with error " + error);
                throw CalendarErrorFactory.GetException(error);
            }
        }

        /// <summary>
        /// Adds a condition for the CalendarTime type.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        /// <feature>http://tizen.org/feature/calendar</feature>
        /// <param name="logicalOperator">The operator type.</param>
        /// <param name="propertyId">The property ID to add a condition.</param>
        /// <param name="matchType">The match flag.</param>
        /// <param name="matchValue">The match value.</param>
        /// <exception cref="NotSupportedException">Thrown when the feature is not supported.</exception>
        /// <exception cref="ArgumentException">Thrown when one of the arguments provided to a method is not valid.</exception>
        public void AddCondition(LogicalOperator logicalOperator, uint propertyId, IntegerMatchType matchType, CalendarTime matchValue)
        {
            int error = Interop.Filter.AddOperator(_filterHandle, logicalOperator);
            if (CalendarError.None != (CalendarError)error)
            {
                Log.Error(Globals.LogTag, "AddCondition Failed with error " + error);
                throw CalendarErrorFactory.GetException(error);
            }

            IntPtr time = CalendarRecord.ConvertCalendarTimeToStruct(matchValue);
            error = Interop.Filter.AddCalendarTime(_filterHandle, propertyId, matchType, time);
            if (CalendarError.None != (CalendarError)error)
            {
                Log.Error(Globals.LogTag, "AddCondition Failed with error " + error);
                throw CalendarErrorFactory.GetException(error);
            }
        }

        /// <summary>
        /// Adds a child filter to a parent filter.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        /// <feature>http://tizen.org/feature/calendar</feature>
        /// <param name="logicalOperator">The operator type.</param>
        /// <param name="filter">The child filter.</param>
        /// <exception cref="NotSupportedException">Thrown when the feature is not supported.</exception>
        /// <exception cref="ArgumentException">Thrown when one of the arguments provided to a method is not valid.</exception>
        public void AddFilter(LogicalOperator logicalOperator, CalendarFilter filter)
        {
            int error = Interop.Filter.AddOperator(_filterHandle, logicalOperator);
            if (CalendarError.None != (CalendarError)error)
            {
                Log.Error(Globals.LogTag, "AddCondition Failed with error " + error);
                throw CalendarErrorFactory.GetException(error);
            }

            error = Interop.Filter.AddFilter(_filterHandle, filter._filterHandle);
            if (CalendarError.None != (CalendarError)error)
            {
                Log.Error(Globals.LogTag, "AddFilter Failed with error " + error);
                throw CalendarErrorFactory.GetException(error);
            }
        }
    }
}
