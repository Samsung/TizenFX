/*
 * DLOG
 * Copyright (c) 2005-2008, The Android Open Source Project
 * Copyright (c) 2017-2013 Samsung Electronics Co., Ltd.
 *
 * Licensed under the Apache License, Version 2.0 (the License);
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *     http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */


/**
 * @file dlog.h
 * @version   0.4
 * @brief This file is the header file of interface of dlog.
 */


#ifndef   _DLOG_H_
#define   _DLOG_H_


#include <stdarg.h>
#include <string.h>
#include <tizen_error.h>
//#include "dlog-internal.h"

#ifdef __cplusplus
extern "C" {
#endif /* __cplusplus */


/*
 * This is the local tag used for the following simplified
 * logging macros. You can change this preprocessor definition
 * before using the other macros to change the tag.
 */
#ifndef LOG_TAG
#define LOG_TAG NULL
#endif


/**
 * @addtogroup CAPI_SYSTEM_DLOG
 * @{
 *
 */


/**
 * @brief Enumeration for Dlog Error.
 * @if MOBILE @since_tizen 2.3 @elseif WEARABLE @since_tizen 2.3.1 @endif
 */
typedef enum {
  DLOG_ERROR_NONE = TIZEN_ERROR_NONE, /**< Successful */
  DLOG_ERROR_INVALID_PARAMETER = TIZEN_ERROR_INVALID_PARAMETER, /**< Invalid parameter */
  DLOG_ERROR_NOT_PERMITTED = TIZEN_ERROR_NOT_PERMITTED /**< Operation not permitted */
} dlog_error_e;


/**
 * @}
 */


/**
 * @addtogroup CAPI_SYSTEM_DLOG
 * @{
 */


/**
 * @brief Enumeration for log priority values in ascending priority order.
 * @if MOBILE @since_tizen 2.3 @elseif WEARABLE @since_tizen 2.3.1 @endif
 */
typedef enum {
  DLOG_UNKNOWN = 0, /**< Keep this always at the start */
  DLOG_DEFAULT, /**< Default */
  DLOG_VERBOSE, /**< Verbose */
  DLOG_DEBUG, /**< Debug */
  DLOG_INFO, /**< Info */
  DLOG_WARN, /**< Warning */
  DLOG_ERROR, /**< Error */
  DLOG_FATAL, /**< Fatal */
  DLOG_SILENT, /**< Silent */
  DLOG_PRIO_MAX /**< Keep this always at the end. */
} log_priority;


/**
 * @}
 */


/**
 * @addtogroup CAPI_SYSTEM_DLOG
 * @{
 */


/**
 * @brief Sends log with priority and tag.
 * @details for application.
 * @if MOBILE @since_tizen 2.3 @elseif WEARABLE @since_tizen 2.3.1 @endif
 * @param[in] prio priority level of type #log_priority
 * @param[in] tag tag - a null-terminated string
 * @param[in] fmt format string - same as printf
 * @return On success, the function returns the number of bytes written.
 *         On error, a negative errno-style error code
 * @retval #DLOG_ERROR_INVALID_PARAMETER Invalid parameter
 * @retval #DLOG_ERROR_NOT_PERMITTED Operation not permitted
 * @pre none
 * @post none
 * @see dlog_vprint
 *
 * @code
#include<dlog.h>
int main(void)
{
    int integer = 21;
    char string[] = "test dlog";

  dlog_print(DLOG_INFO, "USR_TAG", "test dlog");
  dlog_print(DLOG_INFO, "USR_TAG", "%s, %d", string, integer);
    return 0;
}
 * @endcode
 */
int dlog_print(log_priority prio, const char *tag, const char *fmt, ...);


/**
 * @brief Sends log with priority, tag, and va_list.
 * @details for application.
 * @if MOBILE @since_tizen 2.3 @elseif WEARABLE @since_tizen 2.3.1 @endif
 * @param[in] prio priority level of type #log_priority
 * @param[in] tag tag - a null-terminated string
 * @param[in] fmt format string - same as printf
 * @param[in] ap va_list
 * @return On success, the function returns the number of bytes written.
 *         On error, a negative errno-style error code
 * @retval #DLOG_ERROR_INVALID_PARAMETER Invalid parameter
 * @retval #DLOG_ERROR_NOT_PERMITTED Operation not permitted
 * @pre none
 * @post none
 * @see dlog_print
 *
 * @code
#include<dlog.h>
void my_debug_print(char *format, ...)
{
    va_list ap;

    va_start(ap, format);
    dlog_vprint(DLOG_INFO, "USR_TAG", format, ap);
    va_end(ap);
}

int main(void)
{
    my_debug_print("%s", "test dlog");
    my_debug_print("%s, %d", "test dlog", 21);
    return 0;
}
 * @endcode
 */
int dlog_vprint(log_priority prio, const char *tag, const char *fmt, va_list ap);


/**
 * @}
 */


#ifdef __cplusplus
}
#endif /* __cplusplus */
#endif /* _DLOG_H_*/
