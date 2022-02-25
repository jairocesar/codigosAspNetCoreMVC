using System;
using MySqlConnector;
namespace ATV2UC04_JairoCesar.Models
{
    public class Repository// classe mãe
    {
        // string de conexão

        protected const string DadosConexao = "Database =AGV_destinocerto; Data Source = localhost; User id = root";

        protected MySqlConnection conexao = new MySqlConnection(DadosConexao);
         public void TestarConexao(){ // conectar com o BD
            MySqlConnection conexao = new MySqlConnection(DadosConexao);
            conexao.Open(); // chamando o metodo que abre a conexao
                Console.WriteLine("BD funcionando");
            conexao.Close(); // metodo que fecha a conexão
    
    }  

        
    }
}