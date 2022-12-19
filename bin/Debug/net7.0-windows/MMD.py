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

config_file = 'Configs\\yolov3_mobilenetv2_320_300e_coco.py'
checkpoint_file = 'Configs\\yolov3_mobilenetv2_320_300e_coco_20210719_215349-d18dff72.pth'
model = init_detector(config_file, checkpoint_file, device='cuda:0')




# Input image folder path
image_in = "Input\\data50"

# C:\Users\allen\Desktop\Output folder path
output_path = "Output"

# C:\Users\allen\Desktop\Output labeled image folder path
image_out = os.path.join(output_path, "labeled_image")

# C:\Users\allen\Desktop\Output labels and scores
label_path = os.path.join(output_path, "label_output")

# C:\Users\allen\Desktop\Output file
label_file = os.path.join(label_path, "Objects.xml")


# Create root element
root = ET.Element("DataContainer")
dilist = ET.SubElement(root, "dilist")
ET.SubElement(dilist, "datapath").text = image_in


# Iterate over the images for xml output
for files in os.listdir(image_in):
    img = os.path.join(image_in, files)
    result = inference_detector(model, img)

    show_result_pyplot(model, img, result, score_thr=0.4, out_file = os.path.join(image_out, files))

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
    labels_score = [bboxes[:, -1][i] for i in labels_impt]
    box_dim = [bboxes[:, 0:4][i] for i in labels_impt]
    
    
    # Create a subelement for each image
    

    doc = ET.SubElement(root, "objectlist")

    starttime = files[0:4] + "-" + files[4:6] + "-" + files[6:8] + "T" + files[9:11] + ":" + files[11:13] + ":" + files[13:15] + ".000"
    endtime = files[0:4] + "-" + files[4:6] + "-" + files[6:8] + "T" + files[9:11] + ":" + files[11:13] + ":" + files[13:15] + ".999"
    labeltime = files[0:4] + "-" + files[4:6] + "-" + files[6:8] + "T" + files[9:11] + ":" + files[11:13] + ":" + files[13:15]

    cl = ','.join(map(str, labels_class))
    sc = ','.join(map(str, labels_score))
    bd = ','.join(map(str, box_dim))


    ET.SubElement(doc, "object_class").text = cl

    ET.SubElement(doc, "start").text = starttime
    ET.SubElement(doc, "end").text = endtime
    ET.SubElement(doc, "labeldtime").text = labeltime

    ET.SubElement(doc, "object_score").text = sc
    ET.SubElement(doc, "box_coordinate").text = bd

    dom = xml.dom.minidom.parseString(ET.tostring(root))
    xml_string = dom.toprettyxml()
    part1, part2 = xml_string.split('?>')

    with open(label_file, 'w') as xfile:
        #xfile.write(part1 + 'encoding=\"{}\"?>\n'.format(m_encoding) + part2)
        xfile.write(part1+'?>\n' + part2)
        xfile.close()    



#print("Object Detection Finished!")





