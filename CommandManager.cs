using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;

namespace PasswordManagerServer
{
    public class CommandManager
    {

        public CommandManager()
        {

        }

        public static String Redirect(String s)
        {
            switch (s)
            {
                case "LIST":
                    String list = "";
                    foreach(String str in PasswordManager.databaseManager.listPassword())
                    {
                        list = list + str;
                    }
                    return list;
                case "UPDATE":
                    return "";
                case "ADD":
                    return "";
                case "REMOVE":
                    return "";
                default:
                    return "ERROR default";
                    break;
            }

            return "ERROR";
        }

        internal static void ManageFor(string data, TcpClient client, NetworkStream networkStream, byte[] bytes, int i)
        {
            switch (data)
            {
                case "UPDATE":
                    Logger.debug("Looking for update");
                    forUpdate(data, client,networkStream, bytes, i) ;
                    break;
            }
        }
        public static void forUpdate(string data, TcpClient client, NetworkStream networkStream, byte[] bytes, int i)
        {
            String receivedUpdate = System.Text.Encoding.ASCII.GetString(bytes,0,i);
            //PasswordManager.databaseManager.updatePassword()
            Logger.error(receivedUpdate);
        }
    }
}
