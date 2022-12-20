import os
import cv2
import sys
import argparse
import numpy as np

import mmcv
from mmcv.runner import load_checkpoint
from mmcv.image import imread, imwrite

from mmdet.apis import init_detector, inference_detector, show_result_pyplot
from mmdet.models import build_detector
from mmdet import core

import xml.etree.cElementTree as ET
import xml.dom.minidom
import datetime





# Capture every frame
#vidcap = cv2.VideoCapture('Input\\videoplayback.mp4')
#success,image = vidcap.read()
#count = 0
#while success:
#  cv2.imwrite(pathOut + "\\frame%d.jpg" % count, image)     
#  success,image = vidcap.read()
#  print('Read a new frame: ', success)
#  count += 1



# Capture frames every second
def extractImages(pathIn, pathOut):
    count = 0
    vidcap = cv2.VideoCapture(pathIn)
    success,image = vidcap.read()
    success = True
    while success:
        vidcap.set(cv2.CAP_PROP_POS_MSEC,(count*1000))
        success,image = vidcap.read()
        print('Read a new frame: ', success)
        cv2.imwrite(pathOut + "\\frame%d.jpg" % count, image)   
        count = count + 1

# Capture frames from videos        
# pathIn = 'Input\\videoplayback.mp4'
# pathOut = 'C:\Users\allen\Desktop\Output\\frames'
# extractImages(pathIn, pathOut)


# path for py to run individually, add MMDet\\bin\\Debug\\ at the beginning

config_file = 'C:\\Users\\litch\\OneDrive\\デスクトップ\\enshu\\wang\\ADLTaggerObjectDetection\\bin\\Debug\\net7.0-windows\\Configs\\yolov3_mobilenetv2_320_300e_coco.py'
checkpoint_file = 'C:\\Users\\litch\\OneDrive\\デスクトップ\\enshu\\wang\\ADLTaggerObjectDetection\\bin\Debug\\net7.0-windows\\Configs\\yolov3_mobilenetv2_320_300e_coco_20210719_215349-d18dff72.pth'
model = init_detector(config_file, checkpoint_file, device='cpu')




# Input folder path
input_path = sys.argv[1]
# C:\allen\desktop\input\2019\...\56
# C:\mmde\output
# C:\mmde\output\2019\...\56
# yyyy\mm\dd\hh\m

# Output image folder path
output_path = sys.argv[2]

# Output xml file path
xml_name = sys.argv[3]

# xml_path = r"C:\\Users\\allen\\Desktop"
xml_path = sys.argv[4]

# Output xml file name
label_file = os.path.join(xml_path, xml_name)

# Split the input_path into a list of its components
input_path_components = input_path.split(os.sep)

# Concatenate the output_path with the last 6 components of the input_path
output_path = os.path.join(output_path, *input_path_components[-5:])

# get the root path for input
root_path = os.path.join(*input_path_components[:-5])

# Check if the output directory exists
if not os.path.exists(output_path):
    # Create the output directory if necessary
    os.makedirs(output_path)


# Check if the file already exists
if os.path.exists(label_file):
    # If the file exists, open it and parse the XML tree
    tree = ET.parse(label_file)
    # Get the root element of the tree
    root = tree.getroot()
else:
    # If the file does not exist, create a new root element
    root = ET.Element("DataContainer")


#dilist = ET.SubElement(root, "dilist")
#ET.SubElement(dilist, "datapath").text = root_path


# Iterate over the images for xml output
fileBefore = "YamashitaTakuma"
for files in os.listdir(input_path):
    if fileBefore[-9] == files[-9]:
        continue
    img = os.path.join(input_path, files)
    result = inference_detector(model, img)

    # Output images first
    show_result_pyplot(model, img, result, score_thr=0.4, out_file = os.path.join(output_path, files))

    


    # Get label class and score
    bbox_result = result
    labels = [
        np.full(bbox.shape[0], i, dtype=np.int32)\
        for i, bbox in enumerate(bbox_result)
    ]
    labels = np.concatenate(labels)
    bboxes = np.vstack(bbox_result)
    labels_impt = np.where(bboxes[:, -1] > 0.4)[0]

    classes = core.get_classes("coco")
    labels_impt_list = [labels[i] for i in labels_impt]
    labels_class = [classes[i] for i in labels_impt_list]
    #labels_score = [bboxes[:, -1][i] for i in labels_impt]
    #box_dim = [bboxes[:, 0:4][i] for i in labels_impt]
    
    
    # Create a subelement for each image
    

    doc = ET.SubElement(root, "labellist")

    starttime = files[0:4] + "-" + files[4:6] + "-" + files[6:8] + "T" + files[9:11] + ":" + files[11:13] + ":" + files[13:15] + ".000"
    endtime = files[0:4] + "-" + files[4:6] + "-" + files[6:8] + "T" + files[9:11] + ":" + files[11:13] + ":" + files[13:15] + ".999"
    
    # current time
    now = datetime.datetime.now()

    labeltime = now.strftime('%Y-%m-%dT%H:%M:%S')


    cl = ','.join(map(str, labels_class))
    #sc = ','.join(map(str, labels_score))
    #bd = ','.join(map(str, box_dim))


    ET.SubElement(doc, "eventtype").text = cl

    ET.SubElement(doc, "start").text = starttime
    ET.SubElement(doc, "end").text = endtime
    ET.SubElement(doc, "labeldtime").text = labeltime

    # In case we want to output object_score and box_coordinates
    #ET.SubElement(doc, "object_score").text = sc
    #ET.SubElement(doc, "box_coordinate").text = bd
    fileBefore = files


# Create an ElementTree object
#tree = ET.ElementTree(root)
# Convert the ElementTree to a string
xml_string = ET.tostring(root, encoding='utf-8', method='xml')
# Parse the XML string into a DOM object
dom = xml.dom.minidom.parseString(xml_string)
# Pretty-print DOM object
xml_string = dom.toprettyxml()

# Write the XML string to the file
#mode = "a" if os.path.exists(label_file) else "w"


with open(label_file, "w") as f:
    f.write(xml_string) 






