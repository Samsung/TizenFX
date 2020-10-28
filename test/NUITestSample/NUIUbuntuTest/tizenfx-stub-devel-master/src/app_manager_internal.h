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

#ifndef __TIZEN_APPFW_APP_MANAGER_INTERNAL_H
#define __TIZEN_APPFW_APP_MANAGER_INTERNAL_H

#include <package-manager.h>

#include "app_manager.h"
#include "app_context.h"
#include "app_manager_extension.h"

#ifndef API
#define API __attribute__ ((visibility("default")))
#endif

#define PRIVILEGE_PACKAGE_MANAGER_ADMIN "http://tizen.org/privilege/packagemanager.admin"

int app_manager_error(app_manager_error_e error, const char *function, const char *description);

int app_context_foreach_app_context(app_manager_app_context_cb callback, void *user_data);

int app_context_foreach_running_app_context(app_manager_app_context_cb callback, void *user_data);

int app_context_get_app_context(const char *app_id, app_context_h *app_context);

int app_context_set_event_cb(app_manager_app_context_event_cb callback, void *user_data);

int app_context_set_status_cb(app_manager_app_context_status_cb callback, const char *appid, void *user_data);

void app_context_unset_event_cb(void);

int app_info_foreach_app_info(app_manager_app_info_cb callback, void *user_data);

int app_info_get_app_info(const char *app_id, app_info_h *app_info);

int app_context_get_app_context_by_instance_id(const char *app_id, const char *instance_id, app_context_h *app_context);

int app_context_get_instance_id(app_context_h app_context, char **instance_id);

int app_context_get_app_context_by_pid(pid_t pid, app_context_h *app_context);

typedef struct app_manager_event_info_s {
  int req_id;
  app_manager_event_type_e event_type;
  app_manager_event_state_e event_state;
  struct app_manager_event_info_s *next;
} app_manager_event_info;

typedef struct app_manager_event_s {
  int req_id;
  pkgmgr_client *pc;
  app_manager_event_cb event_cb;
  void *user_data;
  app_manager_event_info *head;
} app_manager_event;

int app_event_handler(uid_t target_uid, int req_id,
        const char *pkg_type, const char *pkgid, const char *appid,
        const char *key, const char *val, const void *pmsg, void *data);

int convert_status_type(int status_type);

void remove_app_manager_event_info_list(app_manager_event_info *head);

int app_context_unset_status_cb(app_manager_app_context_status_cb callback, const char *appid);

int app_context_foreach_visible_app_context(app_manager_app_context_cb callback, void *user_data);

#endif /* __TIZEN_APPFW_APP_MANAGER_INTERNAL_H */
