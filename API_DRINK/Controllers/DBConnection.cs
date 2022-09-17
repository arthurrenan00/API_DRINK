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
        static string password = "12345678";
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
                    registro.Add(new Bebida(int.Parse(reader["IdDrink"].ToString()), int.Parse(reader["IdCat"].ToString()), int.Parse(reader["IdIngredient"].ToString()), reader["StrDrink"].ToString(), reader["StrInstructions"].ToString(), reader["StrDrinkThumb"].ToString()));
                }
            }
            return registro;

                 
        }

        public void AddBebida(Bebida bebida)
        {
            MySqlCommand cmd = new MySqlCommand("insert into tbBebida values (@IdDrink, @IdCat, @IdIngredient, @StrDrink. @StrInstructions, @StrDrinkThumb)", conexao);
            cmd.Parameters.AddWithValue("@IdDrink", bebida.IdDrink);
            cmd.Parameters.AddWithValue("IdCat", bebida.IdCat);
            cmd.Parameters.AddWithValue("@IdIngredient", bebida.IdIngredient);
            cmd.Parameters.AddWithValue("@StrDrink", bebida.StrInstructions);
            cmd.Parameters.AddWithValue("@StrInstructions", bebida.StrInstructions);
            cmd.Parameters.AddWithValue("@StrDrinkThumb", bebida.StrDrinkThumb);
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