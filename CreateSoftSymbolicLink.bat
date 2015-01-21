@ECHO OFF

SET myPhysicalPath="E:\MyNewX3Folder\ECCPROD"
SET myVirtualPath="C:\SAGE\SAGEX3V6\X3V6\Folders\ECCPROD"
mklink /D %myVirtualPath% %myPhysicalPath% 

ECHO mklink /D %myPhysicalPath% %myVirtualPath%


SET myPhysicalPath="E:\MyNewX3Folder\X3PUB\ECCPROD"
SET myVirtualPath="C:\SAGE\SAGEX3V6\X3V6\Folders\X3_PUB\ECCPROD"
mklink /D %myVirtualPath% %myPhysicalPath% 
ECHO mklink /D %myPhysicalPath% %myVirtualPath%

pause
