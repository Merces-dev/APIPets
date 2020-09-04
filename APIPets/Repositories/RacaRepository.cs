using APIPets.Context;
using APIPets.Domains;
using APIPets.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace APIPets.Repositories
{
    public class RacaRepository : IRaca
    {
        //Chamamos a classe de conexao do banco
        PetsContext conexao = new PetsContext();

        //Chamamos o objeto que poderá receber e executar os comandos do banco
        SqlCommand cmd = new SqlCommand();
        public Raca Cadastrar(Raca r)
        {
            //Abrir conexao 
            cmd.Connection = conexao.Conectar();
            //Preparar a query
            cmd.CommandText = "INSERT INTO Raca (IdTipoPet, Descricao)" +
                              "VALUES" +
                              "(@idtipopet, @descricao)";

            cmd.Parameters.AddWithValue("@idtipopet", r.IdTipoPet);
            cmd.Parameters.AddWithValue("@descricao", r.Descricao);

            cmd.ExecuteNonQuery();
            //Fechar conexao 
            conexao.Desconectar();
            return r;
        }
        public List<Raca> LerTodos()
        {
            //Abrir conexao
            cmd.Connection = conexao.Conectar();

            // Preparar a query
            cmd.CommandText = "SELECT * FROM Raca";

            SqlDataReader dados = cmd.ExecuteReader();

            //Criamos a lista para guardar
            List<Raca> racas = new List<Raca>();
            while (dados.Read())
            {
                racas.Add(
                    new Raca()
                    {
                        IdRaca      = Convert.ToInt32(dados.GetValue(0)),
                        IdTipoPet   = Convert.ToInt32(dados.GetValue(1)),
                        Descricao   = dados.GetValue(2).ToString(),
                    }
                );
            }

            //Fechar conexao
            conexao.Desconectar();
            return racas;
        }
        public Raca Alterar(int id, Raca r)
        {
            //Abrir conexao
            cmd.Connection = conexao.Conectar();

            // Preparar a query 
            cmd.CommandText =
               "UPDATE Raca SET " +
               "IdTipoPet = @idtipopet," +
               "Descricao = @descricao WHERE IdRaca = @id";
            cmd.Parameters.AddWithValue("@idtipopet", r.IdTipoPet);
            cmd.Parameters.AddWithValue("@descricao", r.Descricao);
            cmd.Parameters.AddWithValue("@id", id);


            //Comando responsável por injetar dados no banco
            cmd.ExecuteNonQuery();
            //Fechar conexao
            conexao.Desconectar();
            return r;

        }

        public Raca BuscarPorId(int Id)
        {
            //Abrir conexao
            cmd.Connection = conexao.Conectar();


            // Preparar a query 
            cmd.CommandText = "SELECT * FROM Raca WHERE IdRaca = @id";
            // Atribuímos as variaveis que vêm como argumento
            cmd.Parameters.AddWithValue("@id", Id);

            SqlDataReader dados = cmd.ExecuteReader();
            Raca r = new Raca();

            while (dados.Read())
            {
                r.IdRaca = Convert.ToInt32(dados.GetValue(0));
                r.IdTipoPet = Convert.ToInt32(dados.GetValue(1));
                r.Descricao = dados.GetValue(2).ToString();

            }

            //Fechar conexao
            conexao.Desconectar();
            return r;
        }



        public void Excluir(int id)
        {
            //Abrir conexao
            cmd.Connection = conexao.Conectar();

            // Preparar a query 
            cmd.CommandText = ("DELETE FROM Raca WHERE IdRaca = @id");
            cmd.Parameters.AddWithValue("@id", id);

            cmd.ExecuteNonQuery();

            //Fechar conexao
            conexao.Desconectar();
        }


    }
}
