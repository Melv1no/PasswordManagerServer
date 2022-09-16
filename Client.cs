using System;
using System.Collections.Generic;
using System.Text;

namespace PasswordManagerServer
{
    public class Client
    {
        public Client(String license_key, String ip)
        {
	this.license_key = license_key;
	this.ip = ip;
        }

        private String license_key;
	private String ip;

	public String getLicense_key() { return license_key; }
        public void setLicense_key(String license_key) { this.license_key = license_key; }
	public String getIp(){ return ip;}
	public void setIp(String ip){ this.ip = ip;}
    }
}
