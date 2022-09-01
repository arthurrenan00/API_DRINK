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

        //AQUI abaixo foi adicionado pelo Guilherme Matheus (25/08)
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

        public void Fechar()
        {
            conexao.Close();
        }
    }
}