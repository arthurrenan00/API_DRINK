using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MySql.Data.MySqlClient;

namespace API_DRINK.Controllers
{
    public class DBConnection 
    {

        //SqlConnection conn;
        MySqlConnection conexao;

        //servidor de banco de dados
        static string host = "localhost";
        //nome do banco de dados
        static string database = "db_drink";
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
    }
}