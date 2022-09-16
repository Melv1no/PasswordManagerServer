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
            test(); 
	    Console.ReadKey();
	    Logger.log("[ + ] - PasswordManager.MAIN() - [ + ] "); 
	    databaseManager = new DatabaseManager();
            licenseKeyManager = new LicenseKeyManager();
            argsManager = new ArgsManager(args);
	    Logger.log(" * databaseManager licenseKeyManager argsManager instance ready");
	    Logger.log(" * Read database for valid license key :");
            foreach (string s in databaseManager.listLicense()) {
                Logger.log("> " + s);
            }
	    Logger.log(" * checking for args");
            if(args.Length != 0) {Logger.log("args detected !"); argsManager.setup(); }else{Logger.log("> No args detected");}
	    Logger.log("[ - ] + _____________________ + [ - ] ");
	    Logger.log("[ + ] - New Thread started for tcp server - [ + ]");
            Thread clientListeningThread = new Thread(ClientListener.init);
            
            clientListeningThread.Start();

        }

	public static void test(){
	Client client = new Client("7zezer","127.0.0.1");
	Client client = new Client("6zezer","127.0.0.1");
	Client client = new Client("5zezer","127.0.0.1");
	Client client = new Client("4zezer","127.0.0.1");
	Client client = new Client("3zezer","127.0.0.1");
	Client client = new Client("2zezer","127.0.0.1");
	Client client = new Client("1zezer","127.0.0.1");
	ClientManager cm = new ClientManager();
	cm.registerClient(client);
	
	foreach(String s in cm.getClientsAsString()){
	Logger.log(s);
	}
	
	return;
	//cm.listClient();
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
