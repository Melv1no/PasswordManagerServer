using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Text;

namespace PasswordManagerServer
{
    internal class DatabaseManager
    {

        public DatabaseManager()
        {
        }

	public void setupDatabase(){

		using(var connection = new SqliteConnection("Data Source=Password.db"))
		{
		connection.Open();
		var command = connection.CreateCommand();
		command.CommandText = @"CREATE TABLE password (id INTEGER PRIMARY KEY AUTOINCREMENT,  ServiceName Text, username Text, password Text, email Text, phoneNumber Text)";
		command.ExecuteNonQuery();
		var command2 = connection.CreateCommand();
		command2.CommandText = @"CREATE TABLE license (id INTEGER PRIMARY KEY AUTOINCREMENT, license Text)";
		
		command2.ExecuteNonQuery();
		}
	}

        public void addLicense(String license)
        {
            using (var connection = new SqliteConnection("Data Source=Password.db"))
            {
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandText = @"INSERT INTO license (license) VALUES ('"+license+"')";
                command.ExecuteNonQuery();

                connection.Close();
            }
        }
        public void removeLicense(String license)
        {
            using (var connection = new SqliteConnection("Data Source=Password.db"))
            {
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandText = @"INSERT INTO password(ServiceName,username,password,email,phoneNumber) VALUES('@serviceName','@username','@password','@email','@phone')";


                command.ExecuteNonQuery();

                connection.Close();
            }
        }
        public List<String> listLicense()
        {
            List<String> list = new List<String>();
            using (var connection = new SqliteConnection("Data Source=Password.db"))
            {
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandText = @"SELECT * FROM license";

                using (var dataReader = command.ExecuteReader())
                {
                    while (dataReader.Read())
                    {
                        list.Add(dataReader[1].ToString());
                    }
                }

                connection.Close();
                return list;
            }
        }
        public void addPassword(Password passwd)
        {
            String ServiceName, password, username, email, numberPhone;
            
            password = passwd.getPassword();
            ServiceName = passwd.getServiceName();
            username = passwd.getUsername();
            email = passwd.getEmail();
            numberPhone = passwd.getNumberPhone();

            using (var connection = new SqliteConnection("Data Source=Password.db"))
            {
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandText = @"INSERT INTO password(ServiceName,username,password,email,phoneNumber) VALUES('@serviceName','@username','@password','@email','@phone')";

                command.Parameters.AddWithValue("@ServiceName", ServiceName);
                command.Parameters.AddWithValue("@username", username);
                command.Parameters.AddWithValue("@password", password);
                command.Parameters.AddWithValue("@email", email);
                command.Parameters.AddWithValue("@phone", numberPhone);

                command.Prepare();
                command.ExecuteNonQuery();

                connection.Close();
            }
        }
        public void removePassword(int id)
        {
            using (var connection = new SqliteConnection("Data Source=Password.db"))
            {
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandText = @"DELETE FROM password WHERE id = @id";
                command.Parameters.AddWithValue("@id", id);

                command.ExecuteNonQuery();
                connection.Close();
            }
            }
            public void updatePassword(int id, Password passwd)
        {
            String ServiceName, password, username, email, numberPhone;

            password = passwd.getPassword();
            ServiceName = passwd.getServiceName();
            username = passwd.getUsername();
            email = passwd.getEmail();
            numberPhone = passwd.getNumberPhone();

            using (var connection = new SqliteConnection("Data Source=Password.db"))
            {
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandText = @"UPDATE password SET serviceName = @serviceName, username = @username, password = @password, email = @email, phoneNumber = @phone WHERE id = @id";

                command.Parameters.AddWithValue("@ServiceName", ServiceName);
                command.Parameters.AddWithValue("@username", username);
                command.Parameters.AddWithValue("@password", password);
                command.Parameters.AddWithValue("@email", email);
                command.Parameters.AddWithValue("@phone", numberPhone);
                command.Parameters.AddWithValue("@id", id);


                command.ExecuteNonQuery();
                connection.Close();
            }


                //UPDATE password SET username = 'SEXEEEEEEEEEEEEEEEEEEEEEE' WHERE id = 2
            }
        public List<String> listPassword()
        {
            List<String> list = new List<String>();
            using (var connection = new SqliteConnection("Data Source=Password.db"))
            { 
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandText = @"SELECT * FROM password";
                using (var dataReader = command.ExecuteReader())
                {
                    while (dataReader.Read())
                    {
                        list.Add(dataReader[0].ToString()+ ";" +
                            dataReader[1].ToString()+ ";" +
                            dataReader[2].ToString()+ ";" +
                            dataReader[3].ToString()+ ";" +
                            dataReader[4].ToString()+ ";" +
                            dataReader[5].ToString());
                        return list;
                    }
                    connection.Close();
                    return list;
                }

                 
            }

        }
    }
}
