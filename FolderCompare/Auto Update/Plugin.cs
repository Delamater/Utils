using System;
using System.Diagnostics;
using System.Reflection;
//using Microsoft.Win32;  // needed for reading the Registry
using Sage.NA.AT_AU.Util;

namespace Sage.US.SBS.ERP.Sage500
{
    /// <summary>
    /// A sample ManagedProduct plugin.
    /// </summary>
    public class UpdatePlugin : IManagedProduct2
    {
        #region IManagedProduct Members
        /// <summary>
        /// The flexData Class started out as a mechanism to create an XML file that 
        /// is stored in the Environment.SpecialFolder.CommonApplicationData\SageAdvisorUpdate folder.
        /// 
        /// It was great for testing values via the modification of the XML file
        /// rather than having to recomplie a plugin for each and every test.
        /// 
        /// You can continue to use it in this manner.
        /// 
        /// Further experimentation has shown that loading all of the data in one fell swoop
        /// into the data structure at the time of construction has been very efficient. So
        /// feel free to use it in that manner.
        /// 
        /// You will find notes about each data type and in some cases some sample implementation
        /// code for things like the CloseProduct routine.  Feel free to use it or replace the 
        /// implemenations, please don't add any public members or functions to the UpdatePlugin class
        /// it has the potential to cause you some significant grief.
        /// 
        /// When you first compile you may run into some errors about the sagecertificate.pfx
        /// To resolve this open a Visual Studio Command prompt and run the following command
        /// 
        /// sn -i sagecertificate.pfx  VS_KEY_5A5193945877E2CD
        /// 
        /// you may have to replace VS_KEY_5A5193945877E2CD with the value from that it shows
        /// in the error, you will also need to get the password from Eteams
        /// https://eteam.sage.com/default.aspx?entity=Folder&view=Default&id=5279&tab=Documents
        /// 
        /// 
        /// </summary>        
        private Data flexData = new Data(true);

        /// <summary>
        /// Gets the name of the product, as it is indentified on the Update Servers
        /// Samples
        /// get {return "Sage.US.SBS.NPS.FR50.Server";}
        /// get {return "Sage.US.SBS.NPS.FundAccouting.Server";}
        /// </summary>
        public String ProductId
        {
            get { return flexData.ProductId; }
        }

        /// <summary>
        /// Gets a User Friendly Name for the Product Line
        /// This is the value that will show up in drop downs in 
        /// the utility
        /// 
        /// Samples
        /// get { return "Sage Fundraising 50";}
        /// get { return "Sage Fund Accounting";}
        /// 
        /// </summary>
        public String ProductLineName
        {
            get { return flexData.ProductLineName; }
        }

        /// <summary>
        /// Gets the currently installed version.
        /// </summary>
        public String VersionId
        {
            get { return flexData.VersionId; }
        }

        /// <summary>
        /// Get the Serial Number associated with this installation
        /// 
        /// Recommend that in the final implementaiton this value is not
        /// hardcoded,  this function should obtain this value from the 
        /// system in some way shape or form
        /// </summary>
        public String SerialNumber
        {
            get { return flexData.SerialNumber; }
        }

        /// <summary>
        /// Get the ClientId associated with this installation
        /// 
        /// Recommend that in the final implementaiton this value is not
        /// hardcoded,  this function should obtain this value from the 
        /// system in some way shape or form
        /// </summary>
        public String ClientId
        {
            get { return flexData.ClientId; }
        }

        /// <summary>
        /// Get the local associated with this installation
        /// 
        /// Recommend that in the final implementaiton this value is not
        /// hardcoded,  this function should obtain this value from the 
        /// system in some way shape or form
        /// 
        /// Leaving this String empty will cause the system to auto identify
        /// </summary>
        public String Locale
        {
            //get { return String.Empty; }
            //get { return System.Threading.Thread.CurrentThread.CurrentCulture.Name; }
            get { return flexData.Locale; }
        }

        /// <summary>
        /// Gets the name of the product, for display in the update grid
        /// It may be the same as ProductLineName
        /// </summary>
        public String DisplayName
        {
            get { return flexData.DisplayName; }
        }

        /// <summary>
        /// gets the value to be used when calculating when to report
        /// a product is getting close to expring on M&S in days
        /// when building this sample 90 days was considered a good gap
        /// </summary>
        public long ExpiryGap
        {
            get
            {
                return flexData.ExpriyGap;
                //return 90;
            }
        }

        /// <summary>
        /// Gets a value indicating whether the product is installed on 
        /// the local workstation.
        /// 
        /// There are many ways to check to see if the product is installed
        /// on the local machine.  I like checking to see if a specific MSI
        /// is installed
        /// </summary>
        public bool IsInstalled
        {
            get { return flexData.IsInstalled; }
        }

        /// <summary>
        /// This is a value specified by the product manufacturer that allows them to 
        /// specify that when updates are detected for this product, the user should
        /// only be notified about the update, nothing else should be done as a result
        /// of the availablity.
        /// 
        /// This is to facilitate the situation where a product managages its own updates
        /// once the server has been installed.  Suppose that a server install sets up the
        /// appropriate directories for the workstations to be installed from and the 
        /// workstations are already instrumented to work with this.  In which case the only
        /// place the product should be updated from is at the server, and updates are then
        /// cascaded down to the individual workstations.  However we may want the user at the 
        /// workstation to know that updates are available at the server, and so we set the
        /// IsNotifyOnly flag to be true.
        /// </summary>
        public bool IsNotifyOnly
        {
            get { return flexData.IsNotifyOnly; }
        }

        /// <summary>
        /// Gets the names of the executables - used so SimClient can
        /// determine when any of the applications that make up the
        /// the product are running.
        /// </summary>
        public String[] Executables
        {
            get { return flexData.Executables; }
            //Uncomment followoing line and replace values as apppropriate
            //get { return new String[] { "Executable Name 1", "Executable Name 2" };
        }

        /// <summary>
        /// A request that the product close.
        /// </summary>
        /// <returns>
        /// An empty String if the product was successfully closed, otherwise
        /// the reason the product could not be closed.</returns>
        public String CloseProduct()
        {
            // The following is a  pretty brute force technique for closing applications
            if (flexData.Executables.Length == 0)
                return String.Empty;	// report success
            else
            {
                String retString = String.Empty;
                for (int i = 0; i < flexData.Executables.Length; i++)
                {
                    try
                    {
                        Process[] process = Process.GetProcessesByName(flexData.Executables[i]);
                        foreach (Process proc in process)
                        {
                            Process.GetProcessById(proc.Id).Kill();
                        }
                    }
                    catch (Exception ex)
                    {
                        if (String.IsNullOrEmpty(retString))
                            retString = String.Format("{0}: {1}", flexData.Executables[i], ex.Message);
                        else
                        {
                            String str = String.Format("{0}\n{1}: {2}", retString, flexData.Executables[i], ex.Message);
                            retString = str;
                        }
                    }
                }
                return retString;
            }
        }
        /// <summary>
        /// Performs actions BEFORE the instalation of a product has completed
        /// This action is not automatic, it is triggered with parameters in
        /// the description field.
        /// </summary>
        /// <returns>
        /// An empty String if the action was successfully completed, otherwise
        /// the reason the action could not be completed.
        /// </returns>
        public String PreInstallActions()
        {
            return String.Empty;
        }

        /// <summary>
        /// Performs actions AFTER the instalation of a product has completed
        /// This action is not automatic, it is triggered with parameters in
        /// the description field.
        /// </summary>
        /// <returns>
        /// An empty String if the action was successfully completed, otherwise
        /// the reason the action could not be completed.
        /// </returns>
        public String PostInstallActions()
        {
            return String.Empty;
        }
        /// <summary>
        /// Contains key value pairs that will passed directly to the service
        /// 
        /// Suppose you had a scenario where you have a single product that has multiple modules
        /// associated with it and you would like to be able to filter the updates that are available
        /// to the end user by the various modules.  
        /// 
        /// To accomplish this you would contact the UK service folks and have them set up a 
        /// filter that you can add to an update that will differentiate based on Key/Value pairs.
        /// 
        /// Then you would populate the Attribure Array with the appropriate Key/Value pairs
        /// 
        /// </summary>
        public Sage.NA.AT_AU.Util.Attribute[] Attributes
        {
            get { return flexData.Attributes; }
        }

        #endregion IManagedProduct Members
    }
}