# ADLTagger-Object-Detection
This is the object detection part of ADLTagger

The FormMain.cs should be the main ADLTagger application's main form (Right now it's almost empty but a button that calls out the object detection function). To concatenate, maybe we can add the button somewhere on the main ADLTagger app.

The FormObject.cs is the new window for object detection

In bin/Debug/net7.0-windows/MMD.py is where the python code for the object detection actually takes place using the MMDetection library of python.

The sample output of xml file and labeled images can be found in bin/Debug/net7.0-windows/Output
