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
                    Logger.debug("Waiting for connection");

                    client = server.AcceptTcpClient();

                    Logger.debug("Client connected");

                    data = null;

                    networkStream = client.GetStream();

                    int i;

                    while((i = networkStream.Read(bytes,0,bytes.Length)) != 0)
                    {
                        data = System.Text.Encoding.ASCII.GetString(bytes, 0,i);
                        byte[] toClient = System.Text.Encoding.ASCII.GetBytes(CommandManager.Redirect(data));

                        networkStream.Write(toClient, 0, toClient.Length); 
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