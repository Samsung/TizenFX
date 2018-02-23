/*
 * Copyright (c) 2011 - 2017 Samsung Electronics Co., Ltd All Rights Reserved
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


#ifndef __TIZEN_APPFW_APP_CONTEXT_H
#define __TIZEN_APPFW_APP_CONTEXT_H

#include <sys/types.h>
#include <tizen.h>

#define TIZEN_DEPRECATED_API

#ifdef __cplusplus
extern "C" {
#endif

/**
 * @file  app_context.h
 */

/**
 * @addtogroup  CAPI_APP_CONTEXT_MODULE
 * @{
 */


/**
 * @brief  Application context handle.
 * @since_tizen  @if MOBILE 2.3 @elseif WEARABLE 2.3.1 @endif
 */
typedef struct app_context_s *app_context_h;


/**
 * @brief  Enumeration for Application Context Event.
 * @since_tizen @if MOBILE 2.4 @elseif WEARABLE 3.0 @endif
 */
typedef enum {
  APP_CONTEXT_EVENT_LAUNCHED, /**< The application is launched */
  APP_CONTEXT_EVENT_TERMINATED, /**< The application is terminated */
} app_context_event_e;


/**
 * @brief Enumeration for the application state
 * @since_tizen 3.0
 */
typedef enum {
  APP_STATE_UNDEFINED, /**< The undefined state */
  APP_STATE_FOREGROUND, /**< The UI application is running in the foreground. */
  APP_STATE_BACKGROUND, /**< The UI application is running in the background. */
  APP_STATE_SERVICE, /**< The Service application is running. */
  APP_STATE_TERMINATED, /**< The application is terminated. */
} app_state_e;


/**
 * @brief  Destroys the application context handle and releases all its resources.
 * @since_tizen @if MOBILE 2.3 @elseif WEARABLE 2.3.1 @endif
 * @param[in]   app_context  The application context handle
 * @return      @c 0 on success,
 *              otherwise a negative error value
 * @retval  #APP_MANAGER_ERROR_NONE               Successful
 * @retval  #APP_MANAGER_ERROR_INVALID_PARAMETER  Invalid parameter
 * @see app_manager_foreach_app_context()
 * @see app_manager_get_app_context()
 */
int app_context_destroy(app_context_h app_context);


/**
 * @deprecated Deprecated since 2.3.1. Use app_context_get_app_id() instead.
 * @brief    Gets the application ID with the given application context.
 * @since_tizen @if MOBILE 2.3 @elseif WEARABLE 2.3.1 @endif
 * @remarks You must release @a package using free().
 * @param[in]   app_context  The application context
 * @param[out]  package      The application ID of the given application context
 * @return      @c 0 on success,
 *              otherwise a negative error value
 * @retval  #APP_MANAGER_ERROR_NONE               Successful
 * @retval  #APP_MANAGER_ERROR_INVALID_PARAMETER  Invalid parameter
 * @retval  #APP_MANAGER_ERROR_OUT_OF_MEMORY      Out of memory
 */
int app_context_get_package(app_context_h app_context, char **package) TIZEN_DEPRECATED_API;


/**
 * @brief    Gets the application ID with the given application context.
 * @since_tizen @if MOBILE 2.3 @elseif WEARABLE 2.3.1 @endif
 * @remarks     You must release @a app_id using free().
 * @param[in]   app_context  The application context
 * @param[out]  app_id       The application ID of the given application context
 * @return      @c 0 on success,
 *              otherwise a negative error value
 * @retval  #APP_MANAGER_ERROR_NONE               Successful
 * @retval  #APP_MANAGER_ERROR_INVALID_PARAMETER  Invalid parameter
 * @retval  #APP_MANAGER_ERROR_OUT_OF_MEMORY      Out of memory
 */
int app_context_get_app_id(app_context_h app_context, char **app_id);


/**
 * @brief  Gets the process ID with the given application context.
 * @since_tizen @if MOBILE 2.3 @elseif WEARABLE 2.3.1 @endif
 * @param[in]   app_context  The application context
 * @param[out]  pid          The process ID of the given application context
 * @return      @c 0 on success,
 *              otherwise a negative error value
 * @retval  #APP_MANAGER_ERROR_NONE               Successful
 * @retval  #APP_MANAGER_ERROR_INVALID_PARAMETER  Invalid parameter
 */
int app_context_get_pid(app_context_h app_context, pid_t *pid);


/**
 * @brief  Gets the package id with the given application context.
 * @since_tizen 3.0
 * @remarks     You must release @a pkg_id using free().
 * @param[in]   app_context  The application context
 * @param[out]  pkg_id   The package ID of the given application context
 * @return      @c 0 on success,
 *              otherwise a negative error value
 * @retval  #APP_MANAGER_ERROR_NONE               Successful
 * @retval  #APP_MANAGER_ERROR_INVALID_PARAMETER  Invalid parameter
 * @retval  #APP_MANAGER_ERROR_OUT_OF_MEMORY      Out of memory
 */
int app_context_get_package_id(app_context_h app_context, char **pkg_id);


/**
 * @brief  Gets the application state with the given application context.
 * @since_tizen 3.0
 * @remarks Note that application's state might be changed after you get app_context.
 *          This API just returns the state of application when you get the app_context.
 * @param[in]   app_context  The application context
 * @param[out]  state        The application state of the given application context
 * @return      @c 0 on success,
 *              otherwise a negative error value
 * @retval  #APP_MANAGER_ERROR_NONE               Successful
 * @retval  #APP_MANAGER_ERROR_INVALID_PARAMETER  Invalid parameter
 */
int app_context_get_app_state(app_context_h app_context, app_state_e *state);


/**
 * @brief  Checks whether the application with the given application context is terminated.
 * @since_tizen @if MOBILE 2.3 @elseif WEARABLE 2.3.1 @endif
 * @param[in]   app_context  The application context
 * @param[out]  terminated   @c true if the application is terminated, \n
 *                           otherwise @c false if the application is running
 * @return      @c 0 on success,
 *              otherwise a negative error value
 * @retval  #APP_MANAGER_ERROR_NONE               Successful
 * @retval  #APP_MANAGER_ERROR_INVALID_PARAMETER  Invalid parameter
 */
int app_context_is_terminated(app_context_h app_context, bool *terminated);


/**
 * @brief  Checks whether two application contexts are equal.
 * @since_tizen @if MOBILE 2.3 @elseif WEARABLE 2.3.1 @endif
 * @param[in]   lhs    The first application context to compare
 * @param[in]   rhs    The second application context to compare
 * @param[out]  equal  @c true if the application contexts are equal, \n
 *                     otherwise @c false if they are not equal
 * @return      @c 0 on success,
 *              otherwise a negative error value
 * @retval  #APP_MANAGER_ERROR_NONE               Successful
 * @retval  #APP_MANAGER_ERROR_INVALID_PARAMETER  Invalid parameter
 */
int app_context_is_equal(app_context_h lhs, app_context_h rhs, bool *equal);


/**
 * @brief  Checks whether the application is running as a sub application of the application group.
 * @since_tizen 3.0
 * @param[in]   app_context  The application context
 * @param[out]  is_sub_app @c true if the sub application of the group, \n
 *                    otherwise @c false if the main application of the group
 * @return      @c 0 on success,
 *              otherwise a negative error value
 * @retval  #APP_MANAGER_ERROR_NONE               Successful
 * @retval  #APP_MANAGER_ERROR_INVALID_PARAMETER  Invalid parameter
 */
int app_context_is_sub_app(app_context_h app_context, bool *is_sub_app);

/**
 * @brief  Clones the application context handle.
 * @since_tizen @if MOBILE 2.3 @elseif WEARABLE 2.3.1 @endif
 * @param[out]  clone        The newly created application context handle, if cloning is successful
 * @param[in]   app_context  The application context
 * @return      @c 0 on success,
 *              otherwise a negative error value
 * @retval  #APP_MANAGER_ERROR_NONE               Successful
 * @retval  #APP_MANAGER_ERROR_INVALID_PARAMETER  Invalid parameter
 * @retval  #APP_MANAGER_ERROR_OUT_OF_MEMORY      Out of memory
 */
int app_context_clone(app_context_h *clone, app_context_h app_context);


/**
 * @}
 */

#ifdef __cplusplus
}
#endif

#endif /* __TIZEN_APPFW_APP_CONTEXT_H */
