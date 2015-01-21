@ECHO OFF

SET myPhysicalPath="E:\MyNewX3Folder\DEMO"
SET myVirtualPath="C:\SAGE\SAGEX3V6\X3V6\Folders\DEMO"
mklink /D %myVirtualPath% %myPhysicalPath% 

ECHO mklink /D %myPhysicalPath% %myVirtualPath%


SET myPhysicalPath="E:\MyNewX3Folder\X3PUB\DEMO"
SET myVirtualPath="C:\SAGE\SAGEX3V6\X3V6\Folders\X3_PUB\DEMO"
mklink /D %myVirtualPath% %myPhysicalPath% 
ECHO mklink /D %myPhysicalPath% %myVirtualPath%

pause
