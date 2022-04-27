using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Ders1.Application
{
    public class LoginDal
    {
        SqlConnection connection = new SqlConnection(@"Server = (localdb)\MSSQLLocalDB; Database=Web; Trusted_Connection=true");

        private void ConnectionController()
        {
            if(connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }
        }

        public void Add(User user)
        {
            ConnectionController();
            SqlCommand command = new SqlCommand("insert into Users values(@name, @surname, @email, @phone, @description, @password)", connection);
            command.Parameters.AddWithValue("@name", user.Name);
            command.Parameters.AddWithValue("@surname", user.Surname);
            command.Parameters.AddWithValue("@email", user.Email);
            command.Parameters.AddWithValue("@phone", user.Phone);
            command.Parameters.AddWithValue("@description", user.Description);
            command.Parameters.AddWithValue("@password", user.Password);
            command.ExecuteNonQuery();
            connection.Close();
        }

        public List<User> GetAll()
        {
            ConnectionController();
            SqlCommand command = new SqlCommand("Select * from Users", connection);
            SqlDataReader reader = command.ExecuteReader();
            List<User> users = new List<User>();
            while (reader.Read())
            {
                User user = new User
                {
                    Id = Convert.ToInt32(reader["Id"]),
                    Name = reader["Name"].ToString(),
                    Surname = reader["Surname"].ToString(),
                    Phone = reader["Phone"].ToString(),
                    Email = reader["Email"].ToString(),
                    Description = reader["Description"].ToString(),
                    Password = reader["Password"].ToString()
                };
                users.Add(user);
            }
            reader.Close();
            connection.Close();
            return users;
        }
    }
}
