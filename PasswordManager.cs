using System;
using System.Threading;

namespace PasswordManagerServer
{
    static class PasswordManager
    {
        public static DatabaseManager databaseManager;
        public static LicenseKeyManager licenseKeyManager;
        public static ArgsManager argsManager;
        
        static void Main(string[] args)
        {
           
	    Logger.log("[ + ] - PasswordManager.MAIN() - [ + ] "); 
	    databaseManager = new DatabaseManager();
            licenseKeyManager = new LicenseKeyManager();
            argsManager = new ArgsManager(args);
	    Logger.log(" * databaseManager licenseKeyManager argsManager instance ready");
	    Logger.log(" * Read database for valid license key :");
            foreach (string s in databaseManager.listLicense()) {
                Logger.info("> " + s);
            }
	    Logger.log(" * checking for args");
            if(args.Length != 0) {Logger.log("args detected !"); argsManager.setup(); }else{Logger.log("> No args detected");}
	    Logger.log("[ - ] + _____________________ + [ - ] ");
	    Logger.log("[ + ] - New Thread started for tcp server - [ + ]");
            Thread clientListeningThread = new Thread(ClientListener.init);
            
            clientListeningThread.Start();

        }
    }
}
/* DATABASE MANAGER*/
/*
 *          databaseManager.addLicense();
            databaseManager.removeLicense();
            databaseManager.listLicense();
            databaseManager.addPassword();
            databaseManager.removePassword();
            databaseManager.updatePassword();
            databaseManager.removePassword();
            databaseManager.listPassword();
*/
/* ARGS MANAGER*/
/*
 * argsManager.setup();
 */
