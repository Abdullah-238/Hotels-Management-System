using HMS_BusinessLogic;
using Microsoft.SqlServer.Server;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media.Animation;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using System.Security.Cryptography;


namespace HMS
{
    public class clsGlobal
    {
        public static clsUsers CurrentUser ;

        public static bool GetStoredCredential(ref string Username, ref string Password)
        {
            try
            {
                string keyPath = @"HKEY_CURRENT_USER\SOFTWARE\YourSoftware";
                string ValueName = "User_Name_Password";


                string line = Registry.GetValue(keyPath, ValueName, null) as string;

                if (line != null)
                {
                    string[] result = line.Split(new string[] { "#||#" }, StringSplitOptions.None);

                    Username = result[0];
                    Password = result[1];
                    return true;
                }
                else
                {
                    Console.WriteLine($"User name or password not found.");
                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                return false; 
            }
        }

        public static bool RememberUsernameAndPassword(string Username, string Password)
        {
            string keyPath = @"HKEY_CURRENT_USER\SOFTWARE\YourSoftware";
            string Value = Username + "#||#" + Password;
            string ValueName = "User_Name_Password";

            try
            {
                // Write the value to the Registry
                Registry.SetValue(keyPath, ValueName, Value, RegistryValueKind.String);
                return true;

            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                return false; 
            }

        }

        public static bool RemoveStoredCredential()
        {
            string keyPath = @"SOFTWARE\YourSoftware";

            string ValueName = "User_Name_Password";

            try
            {
                // Open the registry key in read/write mode with explicit registry view
                using (RegistryKey key = Registry.CurrentUser.OpenSubKey(keyPath))
                {
                    if (key != null)
                    {
                        key.DeleteValue(ValueName);
                        return true; 
                    }
                    else
                    {
                        return false; 
                    }
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }


    }
}
