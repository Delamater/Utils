using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.StorageClient;
using System.IO;

namespace AzureStorage
{
    //The GetState and SaveState routines set and retrieve all of the MAS 500 configuration files in the AppData folder
    //(i.e., C:\Users\[User Name]\AppData\Roaming\Sage Software\Sage MAS 500).  These two processes seem to take around
    //15 seconds to run.  The GetConfig and SaveConfig do the same thing but only with the Application.config file.  These
    //routines seem to run in under a second.

    //The GetState and GetConfig routines only run if a dummy test file does not exist in the AppData folder.  File name is CheckState.
    //These routines will create this file after loading the saved files from the blob storage when it doesn't exist.

    public class ManageState
    {
        private CloudBlobClient _BlobClient = null;
        private CloudBlobContainer _BlobContainer = null;

        //Get app data folder path
        private string _AppDataFolderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Sage Software\\Sage MAS 500");

        //ConfigFileName
        private string _ConfigFile = "Application.Config";
        private string _TestFile = "StateCheck";

        //Set blob storage connection string
        //TO DO:  This storage location needs to be changed.  It's currently connecting to a free MSDN Azure subscription.
        private string _BlobConn = "DefaultEndpointsProtocol=https;AccountName=rptlist;AccountKey=z+QTpJkega1OGslhMbLk/J1UtM4du5aPibtia7+HzEuv7KgsKMZ3gPutohKsyW2DYOVR7o32APsoCZxuFv+0Fg==";

        public bool SaveState()
        {
            try
            {
                if (OpenBlobContainer() == false)
                {
                    return false;
                }

                _BlobContainer.CreateIfNotExist();

                //Loop through MAS 500 app data folder
                string[] fileEntries = Directory.GetFiles(_AppDataFolderPath);
                foreach (string fileName in fileEntries)
                {
                    //Open the stream and read it back.
                    using (FileStream fs = File.OpenRead(fileName))
                    {
                        string filename = System.IO.Path.GetFileName(fileName);

                        // Create the Blob and upload the file
                        var blob = _BlobContainer.GetBlobReference(filename);

                        //Delete in case already exists
                        try
                        {
                            blob.Delete();
                        }
                        catch
                        {
                        }

                        blob.UploadFromStream(fs);
                        fs.Close();
                    }
                }

                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool GetState()
        {
            try
            {
                //If test file does not exist, load saved config files.
                if (File.Exists(_AppDataFolderPath + "\\" + _TestFile) == false)
                {
                    if (OpenBlobContainer() == false)
                    {
                        return false;
                    }

                    //If the container does not exist, this is the first time it is being accessed and nothing has been saved.
                    if (BlobContainerExist())
                    {

                        IEnumerable<IListBlobItem> blobs = _BlobContainer.ListBlobs();

                        if (blobs != null)
                        {
                            //Iterate through the blob storage files in this container and save to disk.
                            foreach (var blobItem in blobs)
                            {
                                string sRef = blobItem.Uri.ToString().Substring(blobItem.Uri.ToString().LastIndexOf("/") + 1);
                                if (sRef != "")
                                {
                                    var fileBlob = _BlobContainer.GetBlobReference(sRef);
                                    fileBlob.DownloadToFile(_AppDataFolderPath + "\\" + sRef);
                                }
                            }
                        }
                    }
                }

                //Create check file
                File.Create(_AppDataFolderPath + "\\" + _TestFile);

                return true;

            }
            catch
            {
                return false;
            }
        }

        public bool GetConfig()
        {
            try
            {
                //If test file does not exist, load saved config file.
                if (File.Exists(_AppDataFolderPath + "\\" + _TestFile) == false)
                {
                    if (OpenBlobContainer() == false)
                    {
                        return false;
                    }

                    //If the container does not exist, this is the first time it is being accessed and nothing has been saved.
                    if (BlobContainerExist())
                    {
                        var fileBlob = _BlobContainer.GetBlobReference(_ConfigFile);
                        fileBlob.DownloadToFile(_AppDataFolderPath + "\\" + _ConfigFile);
                    }

                    //Create check file
                    File.Create(_AppDataFolderPath + "\\" + _TestFile);
                }

                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool SaveConfig()
        {
            try
            {
                if (OpenBlobContainer() == false)
                {
                    return false;
                }

                _BlobContainer.CreateIfNotExist();

                FileStream fs = File.OpenRead(_AppDataFolderPath + "\\" + _ConfigFile);

                var blob = _BlobContainer.GetBlobReference(_ConfigFile);

                //Delete in case already exists
                try
                {
                    blob.Delete();
                }
                catch
                {
                }

                blob.UploadFromStream(fs);

                fs.Close();
                fs.Dispose();

                return true;
            }
            catch
            {
                return false;
            }
        }

        private bool OpenBlobContainer()
        {
            try
            {
                //Get Windows Login ID to identify unique blob container.
                //TO DO: This may not provide enough uniqueness for many users.  Maybe add computer name?
                string userID = Environment.UserName;

                // Setup the connection to Windows Azure Storage
                var storageAccount = CloudStorageAccount.Parse(_BlobConn);
                _BlobClient = storageAccount.CreateCloudBlobClient();

                // Get and create the container.  Doesn't work with upper case.
                _BlobContainer = _BlobClient.GetContainerReference(userID);
                return true;
            }
            catch
            {
                return false;
            }
        }

        //There used to be a routine in an older version of the Azure SDK for this but it was removed.
        //This is a suggested alternative.
        private bool BlobContainerExist()
        {
            //Check if this is the first time by checking if attributes can be retrieved
            try
            {
                _BlobContainer.FetchAttributes();
                // the container exists if no exception is thrown  
                return true;
            }
            catch
            {
                // the container does not exist.
                return false;
            }
            
        }
    }
}
