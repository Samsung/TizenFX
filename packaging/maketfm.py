import os
import xml.etree.ElementTree as ET

scrpit_dir = os.path.dirname(os.path.abspath(__file__))
spec_dir = os.path.join(scrpit_dir, "csapi-tizenfx.spec")
nuspec_file = os.path.join(scrpit_dir, "../pkg/Tizen.NET/Tizen.NET.nuspec")
tree = ET.parse(nuspec_file)
root = tree.getroot()

tfm_list = []
for meta_child in root.iter():
    if meta_child.tag == "{http://schemas.microsoft.com/packaging/2012/06/nuspec.xsd}metadata":
        for depen_child in meta_child:
            if depen_child.tag == "{http://schemas.microsoft.com/packaging/2012/06/nuspec.xsd}dependencies":
                for group in depen_child:
                    tfm = group.attrib["targetFramework"].lower()
                    tfm = tfm.replace(".", "")
                    tfm = tfm.replace("20", "2.0")
                    if tfm.strip():
                        tfm_list.append(tfm)

tfm_list = list(set(tfm_list))
tfm_list.sort(reverse=True)

f = open(spec_dir,'r')
origin_data = f.read()
f.close()

new_data = origin_data.replace("@tfm_support@", ':'.join(tfm_list))

f = open(spec_dir, 'w')
f.write(new_data)
f.close()
