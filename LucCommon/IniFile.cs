using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.IO;

namespace Luc.Common
{
    public class IniFile
    {
        [DllImport("kernel32.dll")]
        private static extern int GetPrivateProfileString(
            String section, String key, String def, StringBuilder retVal, int Size, String filePat);

        [DllImport("Kernel32.dll")]
        private static extern long WritePrivateProfileString(
            String Section, String Key, String val, String filePath);

        public void IniWriteValue(String Section, String Key, String Value, string avaPath)
        {
            try
            {
                WritePrivateProfileString(Section, Key, Value, avaPath);
            }
            catch (Exception E)
            {
                throw E;
            }
        }

        public String IniReadValue(String Section, String Key, string avsPath)
        {
            try
            {
                FileInfo file = new FileInfo(avsPath);
                if (file.Exists)
                {
                    StringBuilder temp = new StringBuilder(2000);
                    int i = GetPrivateProfileString(Section, Key, "", temp, 2000, avsPath);
                    if (i == 0)
                        return "";

                    return temp.ToString();
                }
                else
                {
                    return "";
                }
                
            }
            catch (Exception E)
            {
                throw E;
            }
            
        }

        public void DeleteSection(String strSection, string path)
        {
            try
            {
                WritePrivateProfileString(strSection, null, null, path);
            }
            catch (Exception E)
            {
                throw E;
            }
        }
    }
}
