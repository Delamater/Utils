using System;
using Microsoft.Win32;

namespace Sage.US.SBS.ERP.Sage500
{
    /// <summary>
    /// Registry Reader Class
    /// 
    ///  As you have probably already discovered a 32 bit App has a 
    ///  hard time reading values in the 64 bit registry area and the 
    ///  other way around is also true.
    ///
    ///  This class attempts to make that chore a little bit easier.
    ///  
    ///  I would recommend encapsulating the function ReadRegistryValue
    ///  for your purposes, since it reutrns an object and you will need to 
    ///  translate that object into the appropriate data type.
    ///  
    ///  The function RegRead provides an example of the type
    ///  of encapsulation I am talking about.
    /// 
    /// Good Luck,  Good Coding, and Unit Test Everything!
    /// </summary>

    class RegistryReader
    {
        public static String RegRead(RegistryHive reghive, String subkey, string value, string defaultvalue = null)
        {
            return (String)ReadRegistryValue(reghive, subkey, value, defaultvalue);
        }

        public static object ReadRegistryValue(RegistryHive reghive, String subkey, string value, object defaultvalue = null)
        {
            object strRetValue = defaultvalue;
            RegistryKey theKey = GetRegistryKey(reghive, subkey);

            if (theKey != null)
                strRetValue = theKey.GetValue(value, defaultvalue);

            return strRetValue;
        }

        public static RegistryKey GetRegistryKey(RegistryHive reghive, string strsubkey)
        {
            if (Environment.Is64BitOperatingSystem == true)
            {
                RegistryKey basekey = RegistryKey.OpenBaseKey(reghive, RegistryView.Registry64);
                if (null != basekey)
                {
                    RegistryKey subkey = basekey.OpenSubKey(strsubkey);
                    if (null != subkey)
                        return subkey;
                    else
                    {
                        basekey.Close();
                        basekey = RegistryKey.OpenBaseKey(reghive, RegistryView.Registry32);
                        if (null != basekey)
                        {
                            subkey = basekey.OpenSubKey(strsubkey);
                            if (null != subkey)
                                return subkey;
                        }
                    }
                }
            }
            else
            {
                RegistryKey basekey = RegistryKey.OpenBaseKey(reghive, RegistryView.Registry32);
                if (null != basekey)
                {
                    RegistryKey subkey = basekey.OpenSubKey(strsubkey);
                    if (null != subkey)
                        return subkey;
                }
            }

            return null;
        }
    }
}
