---
# Copyright (c) 2016 Samsung Electronics Co., Ltd All Rights Reserved
#
# Licensed under the Apache License, Version 2.0 (the License);
# you may not use this file except in compliance with the License.
# You may obtain a copy of the License at
#
# http://www.apache.org/licenses/LICENSE-2.0
#
# Unless required by applicable law or agreed to in writing, software
# distributed under the License is distributed on an AS IS BASIS,
# WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
# See the License for the specific language governing permissions and
# limitations under the License.

uid: Tizen.Content.MediaContent
summary: *content
remarks: The media content service does not manage hidden files.
In addition, if "http://tizen.org/feature/content.scanning.others" feature is not supported,
other-type files which are not included in the media content types such as image, video, sound or music, are ignored.
---
The Tizen.Content.MediaContent namespace provides types used in the entire content service.
The information about media items (i.e. image, audio, and video) are managed in the content database
and operations that involve database require an active connection with the media content service.
During media scanning, the media content service extracts the media information automatically. The media information
includes basic file information like path, size, modified time, etc. and some metadata like ID3 tag, EXIF,
thumbnail, etc. (thumbnail extracted only in the internal and the SD card storage.
