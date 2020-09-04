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
    public class TipoPetRepository : ITipoPet
    {
        //Chamamos a classe de conexao do banco
        PetsContext conexao = new PetsContext();

        //Chamamos o objeto que poderá receber e executar os comandos do banco
        SqlCommand cmd = new SqlCommand();

        public TipoPet Cadastrar(TipoPet t)
        {
            //Abrir conexao 
            cmd.Connection = conexao.Conectar();
            //Preparar a query
            cmd.CommandText = "INSERT INTO TipoPet (Descricao)" +
                              "VALUES" +
                              "(@descricao)";
            cmd.Parameters.AddWithValue("@descricao", t.Descricao);

            cmd.ExecuteNonQuery();
            //Fechar conexao 
            conexao.Desconectar();
            return t;
        }

        public List<TipoPet> LerTodos()
        {
            //Abrir conexao 
            cmd.Connection = conexao.Conectar();
            //Preparar a query

            cmd.CommandText = "SELECT * FROM TipoPet";
            SqlDataReader dados = cmd.ExecuteReader();

            List<TipoPet> tipospet = new List<TipoPet>();
            while (dados.Read())
            {
                tipospet.Add(
                    new TipoPet()
                    {
                        IdTipoPet = Convert.ToInt32(dados.GetValue(0)),
                        Descricao = dados.GetValue(1).ToString(),
                    }
                ) ;
            }


            //Fechar conexao 
            conexao.Desconectar();
            return tipospet;
        }


        public TipoPet BuscarPorId(int Id)
        {
            //Abrir conexao 
            cmd.Connection = conexao.Conectar();
            //Preparar a query
            cmd.CommandText = "SELECT * FROM TipoPet WHERE IdTipoPet = @id";
            cmd.Parameters.AddWithValue("@id", Id);

            SqlDataReader dados = cmd.ExecuteReader();
            TipoPet t = new TipoPet();

            while (dados.Read())
            {
                t.IdTipoPet = Convert.ToInt32(dados.GetValue(0));
                t.Descricao = dados.GetValue(1).ToString();
            }

            //Fechar conexao 
            conexao.Desconectar();
            return t;
        }



        public void Excluir(int id)
        {
            //Abrir conexao
            cmd.Connection = conexao.Conectar();

            // Preparar a query 
            cmd.CommandText = ("DELETE FROM TipoPet WHERE IdTipoPet = @id");
            cmd.Parameters.AddWithValue("@id", id);

            cmd.ExecuteNonQuery();

            //Fechar conexao
            conexao.Desconectar();
        }

        public TipoPet Alterar(int id, TipoPet t)
        {
            //Abrir conexao
            cmd.Connection = conexao.Conectar();
            // Preparar a query 
            cmd.CommandText =
                           "UPDATE TipoPet SET " +
                           "Descricao = @descricao WHERE IdTipoPet = @id";

            cmd.Parameters.AddWithValue("@descricao", t.Descricao);
            cmd.Parameters.AddWithValue("@id", id);


            //Comando responsável por injetar dados no banco
            cmd.ExecuteNonQuery();

            //Fechar conexao
            conexao.Desconectar();
            return t;
        }


    }
}
