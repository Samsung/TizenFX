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

#ifndef __TIZEN_APPFW_APP_MANAGER_EXTENSION_H
#define __TIZEN_APPFW_APP_MANAGER_EXTENSION_H

#include <stdbool.h>

#include "app_manager.h"

#ifdef __cplusplus
extern "C" {
#endif

/**
 * @file app_manager_extension.h
 */

/**
 * @addtogroup CAPI_APPLICATION_MANAGER_MODULE
 * @{
 */

/**
 * @brief Enumeration for Application Context Status Event.
 * @since_tizen 3.0
 */
typedef enum {
  APP_CONTEXT_STATUS_LAUNCHED,  /**< The application is launched */
  APP_CONTEXT_STATUS_TERMINATED,  /**< The application is terminated */
} app_context_status_e;

/**
 * @brief Called when an application is launched or terminated.
 * @since_tizen 3.0
 * @param[in]   app_context     The application context of the application launched or terminated
 * @param[in]   status          The application context status
 * @param[in]   user_data       The user data passed from app_manager_set_app_context_status_cb()
 * @pre This function is called when an application gets launched or terminated, after you register this callback using app_manager_set_app_context_status_cb().
 * @see app_manager_set_app_context_status_cb()
 */
typedef void (*app_manager_app_context_status_cb)(app_context_h app_context, app_context_status_e status, void *user_data);

/**
 * @brief  Terminates the application.
 * @since_tizen @if MOBILE 2.3 @elseif WEARABLE 2.3.1 @endif
 * @privlevel platform
 * @privilege %http://tizen.org/privilege/appmanager.kill
 * @param[in]   app_context  The application context
 * @return  @c 0 on success,
 *              otherwise a negative error value
 * @retval  #APP_MANAGER_ERROR_NONE       Successful
 * @retval  #APP_MANAGER_ERROR_INVALID_PARAMETER  Invalid parameter
 * @retval  #APP_MANAGER_ERROR_REQUEST_FAILED   Internal terminate error
 * @retval  #APP_MANAGER_ERROR_PERMISSION_DENIED  Permission denied
 */
int app_manager_terminate_app(app_context_h app_context);

/**
 * @brief Sets the display flag to enable/disable the splash screen.
 * @since_tizen 3.0
 * @privlevel platform
 * @privilege %http://tizen.org/privilege/packagemanager.admin
 * @param[in]     app_id  The ID of the application
 * @param[in]     display The display flag to enable/disable the splash screen
 *
 * @return  @c 0 on success,
 *    otherwise a negative error value
 * @retval  #APP_MANAGER_ERROR_NONE       Successful
 * @retval  #APP_MANAGER_ERROR_INVALID_PARAMETER  Invalid parameter
 * @retval  #APP_MANAGER_ERROR_OUT_OF_MEMORY  Out of memory
 * @retval  #APP_MANAGER_ERROR_PERMISSION_DENIED  Permission denied
 * @retval  #APP_MANAGER_ERROR_IO_ERROR     Internal I/O error
 */
int app_manager_set_splash_screen_display(const char *app_id, bool display);

/*
 * @brief Registers a callback function to be invoked when the application change status.
 * @since_tizen 3.0
 * @param[in]   callback        The callback function to register
 * @param[in]   appid           The appid to get status
 * @param[in]   user_data       The user data to be passed to the callback function
 * @return  @c 0 on success,
 *    otherwise a negative error value
 * @retval  #APP_MANAGER_ERROR_NONE       Successful
 * @retval  #APP_MANAGER_ERROR_INVALID_PARAMETER  Invalid parameter
 * @retval  #APP_MANAGER_ERROR_IO_ERROR     Internal I/O error
 * @retval      #APP_MANAGER_ERROR_OUT_OF_MEMORY        Out of memory
 * @post It will invoke app_manager_app_context_event_cb() when the application is launched or terminated.
 * @see app_manager_app_context_status_cb()
 */
int app_manager_set_app_context_status_cb(app_manager_app_context_status_cb callback, const char *appid, void *user_data);

/**
 * @brief  Gets the application context for the given IDs of the application.
 * @since_tizen 3.0
 * @remarks  This function returns #APP_MANAGER_ERROR_NO_SUCH_APP if the application with the given application IDs is not running. \n
 *           You must release @a app_context using app_context_destroy().
 * @param[in]   app_id       The ID of the application
 * @param[in]   instance_id  The Instance ID of the application
 * @param[out]  app_context  The application context of the given application IDs
 * @return      @c 0 on success,
 *              otherwise a negative error value
 * @retval  #APP_MANAGER_ERROR_NONE               Successful
 * @retval  #APP_MANAGER_ERROR_INVALID_PARAMETER  Invalid parameter
 * @retval  #APP_MANAGER_ERROR_OUT_OF_MEMORY      Out of memory
 * @retval  #APP_MANAGER_ERROR_NO_SUCH_APP        No such application
 */
int app_manager_get_app_context_by_instance_id(const char *app_id, const char *instance_id, app_context_h *app_context);

/**
 * @brief  Gets the focused application context.
 * @since_tizen 3.0
 * @remarks  This function returns #APP_MANAGER_ERROR_NO_SUCH_APP if all applications don't have focus. \n
 *           You must release @a app_context using app_context_destroy().
 *
 * @param[out]  app_context  The focused application context
 * @return      @c 0 on success,
 *              otherwise a negative error value
 * @retval  #APP_MANAGER_ERROR_NONE               Successful
 * @retval  #APP_MANAGER_ERROR_INVALID_PARAMETER  Invalid parameter
 * @retval  #APP_MANAGER_ERROR_IO_ERROR           Internal I/O error
 * @retval  #APP_MANAGER_ERROR_OUT_OF_MEMORY      Out of memory
 * @retval  #APP_MANAGER_ERROR_NO_SUCH_APP        No such application
 */
int app_manager_get_focused_app_context(app_context_h *app_context);

/**
 * @brief  Attaches the window of the child application to the window of the parent application.
 * @since_tizen 3.0
 * @remarks This function is only available for platform level signed applications.
 * @param[in]   parent_app_id The ID of the parent application
 * @param[in]   child_app_id  The ID of the child applicatio
 * @return      @c 0 on success,
 *              otherwise a negative error value
 * @retval  #APP_MANAGER_ERROR_NONE               Successful
 * @retval  #APP_MANAGER_ERROR_INVALID_PARAMETER  Invalid parameter
 * @retval  #APP_MANAGER_ERROR_IO_ERROR           Internal I/O error
 */
int app_manager_attach_window(const char *parent_app_id, const char *child_app_id);

/**
 * @brief  Detaches the window of the application from its parent window.
 * @since_tizen 3.0
 * @param[in]  app_id  The ID of the application
 * @remarks This function is only available for platform level signed applications.
 * @return      @c 0 on success,
 *              otherwise a negative error value
 * @retval  #APP_MANAGER_ERROR_NONE               Successful
 * @retval  #APP_MANAGER_ERROR_INVALID_PARAMETER  Invalid parameter
 * @retval  #APP_MANAGER_ERROR_IO_ERROR           Internal I/O error
 */
int app_manager_detach_window(const char *app_id);

/*
 * @brief Unregisters the callback function.
 * @since_tizen 3.0
 * @param[in]   callback        The registered callback function
 * @param[in]   appid           The registered appid
 * @return  @c 0 on success,
 *    otherwise a negative error value
 * @retval  #APP_MANAGER_ERROR_NONE       Successful
 * @retval  #APP_MANAGER_ERROR_INVALID_PARAMETER  Invalid parameter
 * @see app_manager_app_context_status_cb()
 */
int app_manager_unset_app_context_status_cb(app_manager_app_context_status_cb callback, const char *appid);

/**
 * @brief  Retrieves all application contexts of visible applications.
 * @since_tizen 3.0
 * @param[in]   callback   The callback function to invoke
 * @param[in]   user_data  The user data to be passed to the callback function
 * @return      @c 0 on success,
 *              otherwise a negative error value
 * @retval  #APP_MANAGER_ERROR_NONE               Successful
 * @retval  #APP_MANAGER_ERROR_INVALID_PARAMETER  Invalid parameter
 * @retval  #APP_MANAGER_ERROR_IO_ERROR           Internal I/O error
 * @retval  #APP_MANAGER_ERROR_OUT_OF_MEMORY      Out of memory
 * @post   This function invokes app_manager_app_context_cb() for each application context.
 * @see app_manager_app_context_cb()
 */
int app_manager_foreach_visible_app_context(app_manager_app_context_cb callback, void *user_data);

/**
 * @}
 */

#ifdef __cplusplus
}
#endif

#endif /* __TIZEN_APPFW_APP_MANAGER_EXTENSION_H */
