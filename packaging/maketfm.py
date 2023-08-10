import os
import xml.etree.ElementTree as ET

scrpit_dir = os.path.dirname(os.path.abspath(__file__))
spec_dir = os.path.join(scrpit_dir, "csapi-tizenfx.spec")
nuspec_file = os.path.join(scrpit_dir, "../pkg/Tizen.NET/Tizen.NET.nuspec")
tree = ET.parse(nuspec_file)
root = tree.getroot()

tfm_list1 = []
tfm_list2 = []
for meta_child in root.iter():
    if meta_child.tag == "{http://schemas.microsoft.com/packaging/2012/06/nuspec.xsd}metadata":
        for depen_child in meta_child:
            if depen_child.tag == "{http://schemas.microsoft.com/packaging/2012/06/nuspec.xsd}dependencies":
                for group in depen_child:
                    tfm = group.attrib["targetFramework"].lower()
                    if tfm.startswith("tizen"):
                        if len(tfm) == 8:
                            tfm_list1.append(tfm.replace(".", "").strip())
                        else:
                            tfm_list2.append(tfm.strip())

tfm_list1 = list(set(tfm_list1))
tfm_list1.sort(reverse=True)
tfm_list2 = list(set(tfm_list2))
tfm_list2.sort(reverse=True)
tfm_list = tfm_list2 + tfm_list1

f = open(spec_dir,'r')
origin_data = f.read()
f.close()

new_data = origin_data.replace("@tfm_support@", ':'.join(tfm_list))

f = open(spec_dir, 'w')
f.write(new_data)
f.close()
