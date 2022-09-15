using System;
using System.Text;
using System.Collections.Generic;

namespace PasswordManagerServer{

    public class ClientManager
    {

	private List<Client> clients;
        public ClientManager()
	{
	 clients = new List<Client>();
	}
	
	public List<Client> getClient(){ return clients;}

	public void registerClient(Client client)
	{
	clients.Add(client);
	Logger.log("New client > " + client.getIp() );
	}
	public void unregisterClient(Client client)
	{
	clients.Remove(client);
	Logger.log("unregister client > " + client.getIp() );
	}
	public List<String> getClientsAsString(){
	List<String> tmp = new List<String>();
	foreach(Client c in getClient()){
	
		tmp.Add(c.getLicense_key() + ":" + c.getIp());


	}

	return tmp;
	}	
    }


}
