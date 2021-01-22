using lab67_VisaCenterDAL.Entities;
using lab67_VisaCenterDAL.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace lab67_VisaCenterDAL.Repositories
{
    class ClientRepository : IRepository<Client>
    {
        private VisaCenterContext db;

        public ClientRepository(VisaCenterContext context)
        {
            this.db = context;
        }

        public IEnumerable<Client> GetAll()
        {
            List<Client> clients = new List<Client>();

            var connection = new SqlConnection(db.Database.GetDbConnection().ConnectionString);
            connection.Open();

            var command = new SqlCommand($"SELECT * FROM Clients", connection);
            var reader = command.ExecuteReader();

            while (reader.Read())
            {
                int id = (int)reader["Id"];
                string name = (string)reader["Name"];
                string email = (string)reader["Email"];

                clients.Add(new Client() { Id = id, Name = name, Email = email });
            }
            connection.Close();

            return clients;
        }

        public Client Get(int id)
        {
            return db.Clients.Find(id);
        }

        public void Create(Client client)
        {
            var connection = new SqlConnection(db.Database.GetDbConnection().ConnectionString);
            connection.Open();

            var command = new SqlCommand($"INSERT INTO Clients (Name, Email) " +
                $"VALUES ({client.Name}, {client.Email})", connection);
            command.ExecuteNonQuery();

            connection.Close();
        }

        public void Update(Client client)
        {
            var connection = new SqlConnection(db.Database.GetDbConnection().ConnectionString);
            connection.Open();

            var command = new SqlCommand($"UPDATE Clients SET Name = {client.Name}, Email = {client.Email}" +
                $"WHERE Id = {client.Id}", connection);
            command.ExecuteNonQuery();

            connection.Close();
        }

        public IEnumerable<Client> Find(Func<Client, Boolean> predicate)
        {
            return db.Clients.Where(predicate).ToList();
        }

        public void Delete(int id)
        {
            var connection = new SqlConnection(db.Database.GetDbConnection().ConnectionString);
            connection.Open();

            var command = new SqlCommand("DELETE FROM Clients WHERE Id = " + id, connection);
            //command.Parameters.AddWithValue()

            command.ExecuteNonQuery();

            connection.Close();
        }
    }
}
