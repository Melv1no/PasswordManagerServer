using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace PasswordManagerServer
{
    /*application.exe --add licenseKey*/
    public class ArgsManager
    {
        private String[] args;
        public ArgsManager(String[] args)
        {
            this.args = args;
        }
        public void setup()
        {
            if(args.Length != 2)
            {
                Logger.error("");
                return;
            }

            List<String> arg = new List<string>();
            arg.Add("--add");
            arg.Add("--remove");
            arg.Add("--list");
            arg.Add("--gen");

            if (arg.Contains(args[0]))
            {
                switch (args[0])
                {
                    case "--add":
                        PasswordManager.databaseManager.addLicense(args[1]);
                        break;
                    case "--remove":
                        remove(args[1]);
                        break;
                    case "--list":
                        foreach (String s in PasswordManager.databaseManager.listLicense())
                        {
                            Logger.log(s);
                        }
                        break;
                    case "--gen":
                        Logger.log(PasswordManager.licenseKeyManager.generate(args[1]));
                        break;

                }
            }
            else
            {
                Logger.error("");
                return;
            }
            
        }
        public void add(String v)
        {

        }
        public void remove(String v)
        {

        }
       
    }
}
