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

        //SqlConnection conn;
        MySqlConnection conexao;

        //servidor de banco de dados
        static string host = "localhost";
        //nome do banco de dados
        static string database = "db_bebida";
        //usuário de conexão do banco de dados
        static string userDB = "root";
        //senha de conexão do banco de dados
        static string password = "guiguiba";
        //string de conexão ao BD
        public static string strConexao = "server=" + host +
                                            ";Database=" + database +
                                            ";User ID=" + userDB +
                                            ";Password=" + password;


       
        public String sql_query;

        public DBConnection()
        {

            //sql = "SELECT * FROM tb_empregado WHERE pk_empregado = 7";
            //instância a conexão
            conexao = new MySqlConnection(strConexao);
            //Abre uma conexão de banco de dados com as configurações de
            //propriedade especificadas pelo ConnectionString
            conexao.Open();
        }

      
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

        public void AddBebida(Bebida bebida)
        {
            MySqlCommand cmd = new MySqlCommand("call spInsertBebida(@vStrIngredient, @vStrCategory, @vIdDrink, @vStrDrink, @vStrInstructions, @vStrDrinkThumb);", conexao);
            cmd.Parameters.AddWithValue("@vStrIngredient", bebida.StrIngredient); 
            cmd.Parameters.AddWithValue("@vStrCategory", bebida.StrCategory);
            cmd.Parameters.AddWithValue("@vIdDrink", bebida.IdDrink);
            cmd.Parameters.AddWithValue("@vStrDrink", bebida.StrDrink);
            cmd.Parameters.AddWithValue("@vStrInstructions", bebida.StrInstructions);
            cmd.Parameters.AddWithValue("@vStrDrinkThumb", bebida.StrDrinkThumb);
            cmd.ExecuteNonQuery();
        }

        public void UpdateBebida(Bebida bebida)
        {
            MySqlCommand cmd = new MySqlCommand("update tbBebida set StrDrink=@StrDrink, StrInstructions=@StrInstructions, StrDrinkThumb=@StrDrinkThumb where IdDrink=@IdDrink)", conexao);
            cmd.Parameters.AddWithValue("@StrDrink", bebida.StrInstructions);
            cmd.Parameters.AddWithValue("@StrInstructions", bebida.StrInstructions);
            cmd.Parameters.AddWithValue("@StrDrinkThumb", bebida.StrDrinkThumb);
            cmd.Parameters.AddWithValue("@IdDrink", bebida.IdDrink);
            cmd.ExecuteNonQuery();
        }

        public void DeleteBebida(int idDrink)
        {
            MySqlCommand cmd = new MySqlCommand("delete from tbBebida where IdDrink=@IdDrink", conexao);
            cmd.Parameters.AddWithValue("@IdDrink", idDrink);
            cmd.ExecuteNonQuery();
        }
        
            

        public void Fechar()
        {
            conexao.Close();
        }
    }
}