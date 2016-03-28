/// Copyright 2016 by Samsung Electronics, Inc.,
///
/// This software is the confidential and proprietary information
/// of Samsung Electronics, Inc. ("Confidential Information"). You
/// shall not disclose such Confidential Information and shall use
/// it only in accordance with the terms of the license agreement
/// you entered into with Samsung.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Tizen.Applications.Manager
{
    /// <summary>
    /// ApplicationManager class. This class has the methods and events of the ApplicationManager.
    /// </summary>
    public static class ApplicationManager
    {
        /// <summary>
        /// ApplicationLaunched event. This event is occurred when the application is launched.
        /// </summary>
        static public event EventHandler<ApplicationChangedEventArgs> ApplicationLaunched
        {
            add
            {
                ApplicationManagerImpl.Instance.ApplicationLaunched += value;
            }
            remove
            {
                ApplicationManagerImpl.Instance.ApplicationLaunched -= value;
            }
        }

        /// <summary>
        /// ApplicationTerminated event. This event is occurred when the application is terminated.
        /// </summary>
        static public event EventHandler<ApplicationChangedEventArgs> ApplicationTerminated
        {
            add
            {
                ApplicationManagerImpl.Instance.ApplicationTerminated += value;
            }
            remove
            {
                ApplicationManagerImpl.Instance.ApplicationTerminated -= value;
            }
        }

        /// <summary>
        /// GetInstalledAppsAsync asynchronous method.
        /// </summary>
        /// <returns>It returns the InstalledApplication informations asynchronously.</returns>
        static public Task<IEnumerable<InstalledApplication>> GetInstalledAppsAsync()
        {
            return ApplicationManagerImpl.Instance.GetInstalledAppsAsync();
        }

        /// <summary>
        /// GetInstalledAppsAsync asynchronous method.
        /// </summary>
        /// <param name="filter">Filter is a InstalledApplicationFilter type. It consisting of a key and value pairs.</param>
        /// <returns>It returns the filtered InstalledApplication informations asynchronously.</returns>
        static public Task<IEnumerable<InstalledApplication>> GetInstalledAppsAsync(InstalledApplicationFilter filter)
        {
            return ApplicationManagerImpl.Instance.GetInstalledAppsAsync(filter);
        }

        /// <summary>
        /// GetInstalledAppsAsync asynchronous method.
        /// </summary>
        /// <param name="filter">Filter is a InstalledApplicationMetadataFilter type. It consisting of a key and value pairs.</param>
        /// <returns>It returns the filtered InstalledApplication informations asynchronously.</returns>
        static public Task<IEnumerable<InstalledApplication>> GetInstalledAppsAsync(InstalledApplicationMetadataFilter filter)
        {
            return ApplicationManagerImpl.Instance.GetInstalledAppsAsync(filter);
        }

        /// <summary>
        /// GetRunningAppsAsync asynchronous method.
        /// </summary>
        /// <returns>It returns the RunningApplication informations asynchronously.</returns>
        static public Task<IEnumerable<RunningApplication>> GetRunningAppsAsync()
        {
            return ApplicationManagerImpl.Instance.GetRunningAppsAsync();
        }

        /// <summary>
        /// GetInstalledApp synchronous method.
        /// </summary>
        /// <param name="applicationId"> string application id.</param>
        /// <returns>It returns the InstalledApplication information synchronously.</returns>
        static public InstalledApplication GetInstalledApp(string applicationId)
        {
            return ApplicationManagerImpl.Instance.GetInstalledApp(applicationId);
        }

        /// <summary>
        /// GetRunningApp synchronous method.
        /// </summary>
        /// <param name="applicationId">string application id.</param>
        /// <returns>It returns the RunningApplication information synchronously.</returns>
        static public RunningApplication GetRunningApp(string applicationId)
        {
            return ApplicationManagerImpl.Instance.GetRunningApp(applicationId);
        }

        /// <summary>
        /// GetRunningApp synchronous method.
        /// </summary>
        /// <param name="processId">int process id.</param>
        /// <returns>It returns the RunningApplication information synchronously.</returns>
        static public RunningApplication GetRunningApp(int processId)
        {
            return ApplicationManagerImpl.Instance.GetRunningApp(processId);
        }

        /// <summary>
        /// IsRunningApp synchronous method.
        /// </summary>
        /// <param name="applicationId">string application id.</param>
        /// <returns>bool. If the application is running, true; otherwise, false.</returns>
        static public bool IsRunningApp(string applicationId)
        {
            return ApplicationManagerImpl.Instance.IsRunningApp(applicationId);
        }

        /// <summary>
        /// IsRunningApp synchronous method.
        /// </summary>
        /// <param name="processId">int process id.</param>
        /// <returns>bool. If the application is running, true; otherwise, false.</returns>
        static public bool IsRunningApp(int processId)
        {
            return ApplicationManagerImpl.Instance.IsRunningApp(processId);
        }
    }
}
