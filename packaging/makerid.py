import json
import os

scrpit_dir = os.path.dirname(os.path.abspath(__file__))
runtime_dir = os.path.join(scrpit_dir, "../pkg/Tizen.NET/runtime.json")
spec_dir = os.path.join(scrpit_dir, "csapi-tizenfx.spec")

with open(runtime_dir) as json_file:
    json_data = json.load(json_file)
    json_string = json_data["runtimes"]

    key_list = json_string.keys()
    rid_list1 = []
    rid_list2 = []

    for key in key_list:
        key = key.replace("-armel", "")
        key = key.replace("-arm64", "")
        key = key.replace("-x86", "")
        key = key.replace("-x64", "")
        key = key.replace("tizen.", "")
        key = key.replace("tizen", "")
        if key.strip():
            if len(key) == 5:
                rid_list1.append(key)
            else:
                rid_list2.append(key)

    rid_list1 = list(set(rid_list1))
    rid_list1.sort(reverse=True)
    rid_list2 = list(set(rid_list2))
    rid_list2.sort(reverse=True)
    rid_list = rid_list2 + rid_list1

    f = open(spec_dir,'r')
    origin_data = f.read()
    f.close()

    new_data = origin_data.replace("@rid_version@", ':'.join(rid_list))

    f = open(spec_dir, 'w')
    f.write(new_data)
    f.close()
