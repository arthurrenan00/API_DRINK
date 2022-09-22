using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MySql.Data.MySqlClient;
using API_DRINK.Models;

namespace API_DRINK.Controllers
{
    public class DBConnection 
    {
        //Início da conexão do banco

        MySqlConnection conexao;

        static string host = "localhost";
        static string database = "db_bebida";
        static string userDB = "root";
        static string password = "12345678";
        public static string strConexao = "server=" + host +
                                            ";Database=" + database +
                                            ";User ID=" + userDB +
                                            ";Password=" + password;


        
        //utilização de uma variável para reduzir o tamanho do comando
        public String sql_query;

        //Serve como abertura da conexão ao autenticar com o mysql
        public DBConnection()
        {


            
            //instância a conexão
            conexao = new MySqlConnection(strConexao);
            
            conexao.Open();
        }

        //Pega todos os itens da bebida por uma view crida no mysql
        public List<Bebida> MostraTodos()
        {
                MySqlDataReader reader;

                sql_query = "Select * from vm_Bebida;";

                MySqlCommand cmd = new MySqlCommand(sql_query, conexao);

                reader = cmd.ExecuteReader();

                List < Bebida > registro = new List<Bebida>();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    registro.Add(new Bebida(int.Parse(reader["IdDrink"].ToString()), reader["StrDrink"].ToString(), reader["StrCategory"].ToString() ,reader["StrIngredient"].ToString(), reader["StrInstructions"].ToString(), reader["StrDrinkThumb"].ToString()));
                }
            }
            return registro;

                 
        }

        //Método para adicionar uma bebida
        public void AddBebida(Bebida bebida)
        {
            MySqlCommand cmd = new MySqlCommand("call spInsertBebida(@vStrIngredient, @vStrCategory, @vIdDrink, @vStrDrink, @vStrInstructions, @vStrDrinkThumb)", conexao);
            cmd.Parameters.AddWithValue("@vStrIngredient", bebida.StrIngredient); 
            cmd.Parameters.AddWithValue("@vStrCategory", bebida.StrCategory);
            cmd.Parameters.AddWithValue("@vIdDrink", bebida.IdDrink);
            cmd.Parameters.AddWithValue("@vStrDrink", bebida.StrDrink);
            cmd.Parameters.AddWithValue("@vStrInstructions", bebida.StrInstructions);
            cmd.Parameters.AddWithValue("@vStrDrinkThumb", bebida.StrDrinkThumb);
            cmd.ExecuteNonQuery();
        }
        //Método para alterar uma bebida

        public void UpdateBebida(Bebida bebida)
        {
            MySqlCommand cmd = new MySqlCommand("update tbBebida set StrDrink=@StrDrink, StrInstructions=@StrInstructions, StrDrinkThumb=@StrDrinkThumb where IdDrink=@IdDrink)", conexao);
            cmd.Parameters.AddWithValue("@StrDrink", bebida.StrInstructions);
            cmd.Parameters.AddWithValue("@StrInstructions", bebida.StrInstructions);
            cmd.Parameters.AddWithValue("@StrDrinkThumb", bebida.StrDrinkThumb);
            cmd.Parameters.AddWithValue("@IdDrink", bebida.IdDrink);
            cmd.ExecuteNonQuery();
        }

        //Método para deletar uma bebida

        public void DeleteBebida(int idDrink)
        {
            MySqlCommand cmd = new MySqlCommand("delete from tbBebida where IdDrink=@IdDrink", conexao);
            cmd.Parameters.AddWithValue("@IdDrink", idDrink);
            cmd.ExecuteNonQuery();
        }


        //Fechamento da conexão

        public void Fechar()
        {
            conexao.Close();
        }
    }
}