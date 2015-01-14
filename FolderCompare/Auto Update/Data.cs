using System;
using Accounting.Framework;

namespace Sage.US.SBS.ERP.Sage500
{
    public class Data
    {
        const string FILENAME = "Sage.US.SBS.ERP.Sage500.xml";
        const string ASSIGNEDPRODUCTID = "Sage.US.SBS.ERP.Sage500";
        const long CONSEXPIRYGAP = 30;
        const string PROCESSIDATTRIB = "ProcessID";
        const string STARTTIMEATTRIB = "StartTime";

        #region DataToStore
        // if properties are added to this make sure 
        // to add them to the CopyMe Fuction
        public string ProductId { get; set; }
        public string ProductLineName { get; set; }
        public string VersionId { get; set; }
        public string Locale { get; set; }
        public string DisplayName { get; set; }
        public string SerialNumber { get; set; }
        public string ClientId { get; set; }
        public long ExpriyGap { get; set; }
        public bool IsNotifyOnly { get; set; }
        public bool IsInstalled { get; set; }
        public string[] Executables { get; set; }
        public Sage.NA.AT_AU.Util.Attribute[] Attributes { get; set; }


        #endregion

        #region Constructors
        public Data() { }
        public Data(bool bload)
        {
            string serialNum = "";
            string customerNum = "";
            Session _session = null;
            Boolean RefreshValues = false;  //Flag used to determine if we need to reacquire the serial/client info from a new database connection.
            string lastProcID = "";
            string lastTime = "";
            Boolean attribsNeeded = true;
            System.Diagnostics.Process currentProccess = System.Diagnostics.Process.GetCurrentProcess ();

            try
            {
                //
                //For descriptions about what these various settings do
                // read through the Plugin.cs
                //
                if (ReadMe())
                {
                    //System.Windows.Forms.MessageBox.Show("after successful Readme");
                    // For each is to step through the attributes looking for processid and start time of last check (decide wether to start a new sessiong with Sage 500)
                    foreach (Sage.NA.AT_AU.Util.Attribute WorkAttrib in Attributes)
                    {
                        if (WorkAttrib != null)
                        {
                            if (WorkAttrib.Key.ToString().Equals(PROCESSIDATTRIB, StringComparison.CurrentCultureIgnoreCase)) 
                            {
                                lastProcID = WorkAttrib.Value.ToString();
                                attribsNeeded = false;  //This is a flag to determine wether to update or add Attribute values later
                            }
                            if (WorkAttrib.Key.ToString().Equals(STARTTIMEATTRIB, StringComparison.CurrentCultureIgnoreCase))
                            {
                                lastTime = WorkAttrib.Value.ToString();
                            }
                        }
                        else
                        {
                         //System.Windows.Forms.MessageBox.Show("Attribute is null");
                         RefreshValues = true;
                        }
                    }
                    if ((lastProcID.ToString().Equals(currentProccess.Id.ToString(), StringComparison.CurrentCultureIgnoreCase)) && (lastTime.ToString().Equals(currentProccess.StartTime.ToString(), StringComparison.CurrentCultureIgnoreCase)))
                    { // Use Existing information that was retrieved from the ReadME
                         //System.Windows.Forms.MessageBox.Show("setting refresh to use old");
                        RefreshValues = false;
                    }
                    else
                    {
                        //System.Windows.Forms.MessageBox.Show("setting refresh to new");
                        RefreshValues = true;
                    }
                }
                else
                {
                    //System.Windows.Forms.MessageBox.Show("setting refresh to new2");
                    RefreshValues = true;
                }

                if (RefreshValues == true)
                {
                    System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo(System.Globalization.CultureInfo.InstalledUICulture.Name.ToString());
                    Locale = System.Threading.Thread.CurrentThread.CurrentCulture.Name;

                    ProductId = ASSIGNEDPRODUCTID;
                    ProductLineName = Constants.ProductFullName; //"US Sage 500 ERP";
                    DisplayName = Constants.ProductFullName; //  "Sage 500 ERP";
                    _session = new Session();
                    if (_session.Login())
                    {
                        customerNum = _session.RegReqMsgInfo.CustomerNo.Trim();
                        serialNum = _session.RegReqMsgInfo.SMSerialNo.Trim();
                        VersionId = _session.RegReqMsgInfo.DBVersion.Trim();

                        _session.CloseSQLConnection();
                        _session = null;

                        //Attributes = new Sage.NA.AT_AU.Util.Attribute[0];  // This should be the setting if you aren't passing any attributes.
                        //Utilze the function addAttribute to add attributes
                        if (attribsNeeded == true)
                        {
                            addAttribute(PROCESSIDATTRIB, currentProccess.Id.ToString()); // Store the ProcessID and StartTime to check on next refresh to see if it is a second or later refresh.
                            addAttribute(STARTTIMEATTRIB, currentProccess.StartTime.ToString()); // Stop and Start the console to get a new connection defined.
                        }
                        else 
                        {
                            foreach (Sage.NA.AT_AU.Util.Attribute WorkAttrib in Attributes)
                            {
                                if (WorkAttrib != null)
                                {
                                    if (WorkAttrib.Key.ToString() == PROCESSIDATTRIB)
                                    {
                                        WorkAttrib.Value = currentProccess.Id.ToString();
                                    }
                                    if (WorkAttrib.Key.ToString() == STARTTIMEATTRIB)
                                    {
                                        WorkAttrib.Value = currentProccess.StartTime.ToString();
                                    }
                                }
                            }

                        }
                    }
                    else
                    {
                        customerNum = "X";  //Set to invalid information if failed login ???
                        serialNum =  "1";
                        VersionId = "0.0.0.0";

                        //Attributes = new Sage.NA.AT_AU.Util.Attribute[0];  // This should be the setting if you aren't passing any attributes.
                        //Utilze the function addAttribute to add attributes
                        addAttribute(PROCESSIDATTRIB, ""); // Add Blank Attrib Values if failed login to keep from trying to use old values on next refresh
                        addAttribute(STARTTIMEATTRIB, "");

                    }

                    SerialNumber = serialNum;
                    ClientId = customerNum;

                    //SerialNumber = "AFWSLSSB242";
                    //ClientId = "4000223024";
                    //VersionId = "7.50.0";
                    ExpriyGap = CONSEXPIRYGAP; // 90;
                    IsNotifyOnly = false;
                    IsInstalled = true;
                    //System.Windows.Forms.MessageBox.Show("ClientId = " + ClientId  + "; SerialNumber = " + SerialNumber + "; VersionId = " + VersionId);
                    Executables = new string[0]; // use this if you don't have any executables to test for as part of product deployment
                    //Executables = new string[] { "Executable Name 1", "Executable Name 2" }; // use this to define an executable to test for and close at install time
                    StoreMe();
                    //
                    //  This is here just for testing purposes it will check for
                    //  C:\ProgramData\SageAdvisorUpdate\Sage.US.SBS.ERP.Sage500.xml
                    //  A.K.A.
                    //  Environment.SpecialFolder.CommonApplicationData\SageAdvisorUpdate\Sage.US.SBS.ERP.Sage500.xml
                    //
                    //  In the event that it is not found it will create the file.  This give you the ability
                    //  to run the template to create the project and immediately start working with the plugin
                    //

                }
                else
                {
                    //System.Windows.Forms.MessageBox.Show("Use previous values");                    
                }
#if DEBUG
                if (!ReadMe())
                    StoreMe();
#endif
            }
            catch (Exception e)
            {
                //
                //These are default values that could be used to indicate and check for availablity of product update
                // Sage Fund Accounting and Sage Fundraising 50 will be using serial number 1 as a deployment mechanism
                // we will be able to deploy SAU and the associated plugin, serail number 1 will be configured with an
                // expiration date of two days ago.  This will allow the sytem to check for and verify the existence of 
                // and update,  when used with an override code they will be able to download and install the product.
                //
                IsNotifyOnly = false;
                IsInstalled = false;
                VersionId = "0.0.0.0";
                SerialNumber = "1";
                System.Windows.Forms.MessageBox.Show(e.Message ,"Error");
                //
                // This is a simple logging mechanism that will allow real time tracking of what might be going on in your
                // plugin.  To use it, make all calls to load data within the try block, and raise all errors in sub functions
                // using exceptions.  It's not very fancy, but it does work.
                //
                System.Reflection.Module mod = System.Reflection.Assembly.GetExecutingAssembly().GetModules()[0];
                String path = System.IO.Path.ChangeExtension(mod.FullyQualifiedName, "log");
                System.IO.File.AppendAllText(path, String.Format("{0}   {1}\r\n", DateTime.Now.ToString(), e.Message));
            }
        }
        #endregion

        #region DataStorage
        private void CopyMe(Data obj)
        {
            ProductId = obj.ProductId;
            ProductLineName = obj.ProductLineName;
            VersionId = obj.VersionId;
            Locale = obj.Locale;
            DisplayName = obj.DisplayName;
            SerialNumber = obj.SerialNumber;
            ClientId = obj.ClientId;
            ExpriyGap = obj.ExpriyGap;
            IsNotifyOnly = obj.IsNotifyOnly;
            IsInstalled = obj.IsInstalled;
            Executables = obj.Executables;
            Attributes = obj.Attributes; 
        }      
        public bool StoreMe()
        {
            System.Xml.Serialization.XmlSerializer writer;
            System.IO.StreamWriter file = null;
            bool saved = false;

            try
            {
                string fileName = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "SageAdvisorUpdate", FILENAME);
                writer = new System.Xml.Serialization.XmlSerializer(typeof(Data));
                file = new System.IO.StreamWriter(fileName, false);
                writer.Serialize(file, this);
                saved = true;
            }
            catch (Exception ex)
            {
                // Eat the exception.
                throw new Exception("Plugin.StoreMe() failed: " + ex.Message, ex);
            }
            finally
            {
                if (file != null)
                    file.Close();
            }
            return saved;
        }
        public bool ReadMe()
        {
            System.Xml.Serialization.XmlSerializer reader;
            System.IO.StreamReader file = null;
            bool read = false;

            try
            {
                string fileName = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "SageAdvisorUpdate", FILENAME);
                if (System.IO.File.Exists(fileName))
                {

                    reader = new System.Xml.Serialization.XmlSerializer(typeof(Data));
                    file = new System.IO.StreamReader(fileName);
                    CopyMe((Data)reader.Deserialize(file));

                    read = true;
                }
            }
            catch (Exception ex)
            {
                // Eat the exception.
                throw new Exception("Plugin.ReadMe() failed: " + ex.Message, ex);
            }
            finally
            {
                if (file != null)
                    file.Close();
            }

            return read;
        }
        #endregion

        #region AttributeUtilities

        public void addAttribute(string key, string value)
        {
            Sage.NA.AT_AU.Util.Attribute[] attrs = this.Attributes;
            if (attrs == null)
            {
                attrs = new Sage.NA.AT_AU.Util.Attribute[0];
            }
            Sage.NA.AT_AU.Util.Attribute[] newattrs = new Sage.NA.AT_AU.Util.Attribute[attrs.Length + 1];
            for (int i = 0; i < attrs.Length; i++)
            {
                newattrs[i] = attrs[i];
            }
            Sage.NA.AT_AU.Util.Attribute reqattr = new Sage.NA.AT_AU.Util.Attribute
            {
                Key = key,
                Value = value
            };
            newattrs[attrs.Length] = reqattr;
            this.Attributes = newattrs;
        }
        #endregion
    }
}
