using System;
using System.Collections.Generic;

namespace Tizen.Location
{
    /// <summary>
    /// Enumeration for the state of the location service.
    /// </summary>
    public enum ServiceState
    {
        Disabled = 0, /**<Service is disabled.*/
        Enabled /**<Service is enabled.*/
    }

    /// <summary>
    /// Enumeration for the type of connection used in acquiring Location data.
    /// </summary>
    public enum LocationType
    {
        None = -1, /**<Undefined method.*/
        Hybrid, /**<This method selects the best method available at the moment.*/
        Gps, /**<This method uses Global Positioning System.*/
        Wps, /**<This method uses WiFi Positioning System.*/
        Mock /**<This method uses Mock location for testing.*/
    }

    /// <summary>
    /// Enumeration for Approximate accuracy level of given information.
    /// </summary>
    public enum LocationAccuracy
    {
        None = 0, /**< Invalid Data */
        Country, /**< Country accuracy level */
        Region, /**< Regional accuracy level */
        Locality, /**< Local accuracy level*/
        PostalCode, /**< Postal accuracy level */
        Street, /**< Street accuracy level */
        Detailed /**< Detailed accuracy level*/
    }

    /// <summary>
    /// Enumeration for the location service accessibility state.
    /// </summary>
    public enum AccessibilityState
    {
        None = 0, /**< Access state is not determined */
        Denied, /**< Access denied */
        Allowed /**< Access authorized */
    }

    /// <summary>
    /// Enumeration for the created boundary type.
    /// </summary>
    public enum BoundaryType
    {
        Rectangle = 0, /**<Rectangular geographical area type. */
        Circle, /**<Rectangular geographical area type. */
        Polygon /**<Rectangular geographical area type. */
    }

    /// <summary>
    /// Enumeration for error code for Location manager.
    /// </summary>
    public enum BoundaryState
    {
        In = 0, /**< Boundary In (Zone In) */
        Out /**< Boundary Out (Zone Out) */
    }
}