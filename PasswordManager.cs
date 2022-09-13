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
            databaseManager = new DatabaseManager();
            licenseKeyManager = new LicenseKeyManager();
            argsManager = new ArgsManager(args);

            foreach (string s in databaseManager.listLicense()) {
                Logger.info("licenseKey valid: " + s);
            }
            if(args.Length != 0) { argsManager.setup(); }

            Thread clientListeningThread = new Thread(ClientListener.init);
            Logger.info("Thread Started for ClientListener.init");
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