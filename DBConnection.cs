using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABMMascotas
{
    internal class DBConnection
    {
        private string connectionString = @"Data Source=172.16.10.196;Initial Catalog=Veterinaria404850;User ID=alumno1w1;Password=alumno1w1";

        SqlConnection connection;

        SqlCommand command;

        // constructor
        public DBConnection()
        {
            connection = new SqlConnection(connectionString);
        }


        // metodos
        private void Conectar()
        {
            connection.Open();
        }
        public void Desconectar()
        {
            connection.Close();
        }

        public DataTable ConsultarBD(string SQLquery)
        {
            DataTable table = new DataTable(); // creo el dataTable

            Conectar();
            command = new SqlCommand(SQLquery, connection); // creo el comando con la consulta y la conexion

            table.Load(command.ExecuteReader());  // cargo los datos en el dataTable

            Desconectar();

            return table;
        }


        // Insert Update Delete
        public void IUD(string SQLquery)
        {
            Conectar();
            command = new SqlCommand(SQLquery, connection);
            command.ExecuteNonQuery();
            Desconectar();
        }

        
    }
}
