@ECHO OFF

SET myPhysicalPath="E:\MyNewX3Folder\PRODUCTION"
SET myVirtualPath="C:\SAGE\SAGEX3V6\X3V6\Folders\PRODUCTION"
mklink /D %myVirtualPath% %myPhysicalPath% 

ECHO mklink /D %myPhysicalPath% %myVirtualPath%
pause
