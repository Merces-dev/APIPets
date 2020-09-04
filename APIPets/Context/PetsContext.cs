using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace APIPets.Context
{
    public class PetsContext
    {
        SqlConnection con = new SqlConnection();
        public  PetsContext()
        {
            con.ConnectionString = @"Data Source = TeJotaPC\SQLEXPRESS;Initial Catalog = atendimentosPet;User ID = sa; Password=sa132";
        }

        /// <summary>
        /// Abre a conexão com o banco
        /// </summary>
        /// <returns>retorna a conexão aberta</returns>
        public SqlConnection Conectar()
        {
            if(con.State == System.Data.ConnectionState.Closed)
            {
                con.Open();
            }
            return con;
        }
        /// <summary>
        /// Fecha a conexão com o banco
        /// </summary>
        public void Desconectar()
        {
            if (con.State == System.Data.ConnectionState.Open)
            {
                con.Close();
            }
        }
    }
}
