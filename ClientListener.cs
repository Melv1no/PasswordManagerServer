using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace PasswordManagerServer
{
    public class ClientListener
    {
        public ClientListener()
        {

        }
        private static TcpListener server = null;
        private static TcpClient client = null;
	private static ClientManager softClient = null;
        private static NetworkStream networkStream;
        public static void init()
        {
            try
            {
                Int32 port = 13000;
                IPAddress localAddr = IPAddress.Parse("127.0.0.1");

                server = new TcpListener(localAddr, port);
                server.Start();

                Byte[] bytes = new byte[256];
                String data = null;

                while (true)
                {
                    Logger.debug("Waiting for a connection...");
		
                    client = server.AcceptTcpClient();
		    //IPEndPoint ipep = (IPEndPoint)client.RemoteEndPoint;
                    //IPAddress ipa = ipep.Address;
                    Logger.debug("Client connected");

                    data = null;

                    networkStream = client.GetStream();

                    int i;
                    Boolean licenseVerificationState = false;
                    Boolean requestState = false ;
                    Boolean finishState = false;
                    String cmd = String.Empty;
                    while((i = networkStream.Read(bytes,0,bytes.Length)) != 0)
                    {
                        
                        data = System.Text.Encoding.ASCII.GetString(bytes, 0,i);
                        String[] sData = data.Split(':');
                        byte[] toClient = System.Text.Encoding.ASCII.GetBytes(Logger.VALID_LICENSE) ;
                        if (requestState)
                        {
                            CommandManager.ManageFor(cmd, client, networkStream, bytes, i);
                            finishState = true;
                        }
                        if (finishState)
                        {
                            Logger.info("finished ");
                            break;
                        }
                        if (!licenseVerificationState)
                        {
                            if (!LicenseKeyManager.check(sData[0])) {

                                toClient = System.Text.Encoding.ASCII.GetBytes(Logger.NOT_VALID_LICENSE);
                                networkStream.Write(toClient, 0, toClient.Length);
                                break; 
                            }
                            licenseVerificationState = true;
		            //softClient = new ClientManager().registerClient(new Client(sData[0],ipa.ToString()));
                        }
                        networkStream.Write(toClient, 0, toClient.Length);
                        cmd = sData[1];
                        requestState = true;
                    }
                     
                    client.Close();
                }
            }
            catch (SocketException e)
            {

                throw;
            }
            finally
            {
                server.Stop();
            }
        }

    }
}
/*  [LICENSE_KEY_HASH=____________________][COMMAND=UPDATE] */
