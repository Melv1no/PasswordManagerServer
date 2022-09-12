using System;
using System.Collections.Generic;
using System.Text;

namespace PasswordManagerServer
{
    public class PasswordModel
    {
        public String ServiceName { get; set; }
        public String Username { get; set; }
        public String Password { get; set; }
        public String Email { get; set; }
        public String NumberPhone { get; set; }
        public String id;
        public PasswordModel(String id, String serviceName, string username, string email, string password, String numberPhone)
        {
            this.id = id;
            ServiceName = serviceName;
            Username = username;
            Email = email;
            Password = password;
            NumberPhone = numberPhone;
        }
    }
    public class Password
    {
        private PasswordModel passwordModel = new PasswordModel(null, null, null, null, null, null);
        public Password()
        {
        }
        public static Password Init()
        {
            return new Password();
        }
        public PasswordModel Build() => passwordModel;
        public Password setID(String id)
        {
            passwordModel.ServiceName = id;
            return this;
        }
        public Password setServiceName(String serviceName)
        {
            passwordModel.ServiceName = serviceName;
            return this;
        }
        public Password setUsername(String username)
        {
            passwordModel.Username = username;
            return this;
        }
        public Password setEmail(String email)
        {
            passwordModel.Email = email;
            return this;
        }
        public Password setPassword(String password)
        {
            passwordModel.Password = password;
            return this;
        }
        public Password setNumberPhone(String numberPhone)
        {
            passwordModel.NumberPhone = numberPhone;
            return this;
        }
        public String getID()
        {
            return passwordModel.id;
        }
        public String getPassword()
        {
            return passwordModel.Password;
        }
        public String getUsername()
        {
            return passwordModel.Username;
        }
        public String getEmail()
        {
            return passwordModel.Email;
        }
        public String getNumberPhone()
        {
            return passwordModel.NumberPhone;
        }
        public String getServiceName()
        {
            return passwordModel.ServiceName;
        }
    }
}
