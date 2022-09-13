using System;
using System.Collections.Generic;
using System.Text;

namespace PasswordManagerServer
{
    public class LicenseKeyManager
    {
        DatabaseManager databaseManager;
        private Boolean validLicense;
        private String licenseKey;
        public LicenseKeyManager()
        {
            databaseManager = new DatabaseManager();
            
        }

        public Boolean isValidLicense(String licenseKey)
        {
            this.licenseKey = licenseKey;
            licenseChecker();
            return validLicense;
        }
        private void licenseChecker()
        {
            foreach (String s in PasswordManager.databaseManager.listLicense())
            {
                validLicense = false;
                if (s.Equals(licenseKey))
                {
                    validLicense = true;
                    break;
                }
            }
        }

        public string generate(string s)
        {
            try
            {
                int length = int.Parse(s);

                const string valid = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
                StringBuilder res = new StringBuilder();
                Random rnd = new Random();
                while (0 < length--)
                {
                    res.Append(valid[rnd.Next(valid.Length)]);
                }

                return(res.ToString());

            }
            catch (Exception e)
            {
                return ("");
            }
        }

        internal static bool check(string data)
        {
            foreach (String s in PasswordManager.databaseManager.listLicense())
            {
                if (s.Equals(data))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
