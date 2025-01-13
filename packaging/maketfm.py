import os, re
import xml.etree.ElementTree as ET

scrpit_dir = os.path.dirname(os.path.abspath(__file__))
spec_dir = os.path.join(scrpit_dir, "csapi-tizenfx.spec")
nuspec_file = os.path.join(scrpit_dir, "../pkg/Tizen.NET/Tizen.NET.nuspec")
tree = ET.parse(nuspec_file)
root = tree.getroot()

tfm_list1 = [] #tizen90, tizen80, tizen70, tizen60, tizen50, tizen40
tfm_list2 = [] #tizen10.0
tfm_list3 = [] #net8.0-tizen10.0, net8.0-tizen, net8.0, net6.0-tizen9.0, net6.0-tizen8.0, net6.0-tizen, net6.0

def sort_tfm(tfm):
    tfm = list(set(tfm))
    return sorted(tfm, reverse=True)

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
                    elif tfm.startswith("net"):
                        if len(tfm) < 8:
                            tfm_list3.append(tfm.strip() + "-tizen")
                        tfm_list3.append(tfm.strip())

tfm_list = sort_tfm(tfm_list3) + sort_tfm(tfm_list2) + sort_tfm(tfm_list1)

f = open(spec_dir,'r')
origin_data = f.read()
f.close()

new_data = origin_data.replace("@tfm_support@", ':'.join(tfm_list))

f = open(spec_dir, 'w')
f.write(new_data)
f.close()
