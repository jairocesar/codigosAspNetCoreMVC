using System;
using System.Collections.Generic;
using MySqlConnector;


namespace ATV2UC04_JairoCesar.Models
{

    public class ClienteRepository:Repository
    {
       
            // para conexão estou usando erança de Repository
         //protected const string DadosConexao = "Database = AgV_DestCerto; Data Source = localhost; User id = root"; 
           // protected MySqlConnection conexao = new MySqlConnection(DadosConexao);
        
         
        public void cadastrar(Cliente c){ //create
           
            conexao.Open();
            
            string query ="INSERT INTO Usuario(Nome ,Login,Senha,DataNascimento)VALUES(@Nome,@Login,@Senha,@DataNascimento)";
            MySqlCommand comando = new MySqlCommand(query,conexao);
            comando.Parameters.AddWithValue("@Nome",c.Nome);           
            comando.Parameters.AddWithValue("@Login",c.Login);
            comando.Parameters.AddWithValue("@Senha",c.Senha);
             comando.Parameters.AddWithValue("@DataNascimento",c.DataNascimento);
            
            comando.ExecuteNonQuery();

            conexao.Close();

        }

      



        public Cliente Login(Cliente c){//validar o login do usuario cadastrado

            
            conexao.Open();
            string login = "SELECT * FROM Usuario WHERE Login = @Login AND Senha=@Senha;";
           
            MySqlCommand comando= new MySqlCommand(login,conexao);
                comando.Parameters.AddWithValue("@Nome",c.Nome);
                comando.Parameters.AddWithValue("@Login",c.Login);
                comando.Parameters.AddWithValue("@Senha",c.Senha);
// até aqui foi feito a inserção de dado do usuario para  carregar as variaveis cujo dados serã usados para comparar com os dados cadastrados no BD, 

                MySqlDataReader resultado = comando.ExecuteReader(); // apartir de agora é feito o retorno do BD, e saberemos então se os dados comparados ja existem no BD ou não
                Cliente clie = null; // criamos uma instancia da classe Cliente, e definimos esse objeto como null,pois caso os dados pesquisados no BD não exista, essse metodo retornara nulo, 
                                     // é importante incrementar essa instancia dessa forma para que possa ter esse retorno como nulo, caso nenhum dados seja encontrado   
                                    // e caso não seja encontrado nenhum usuario, o if abaixo não sera execultado, e oretorno definido no final do metodo sera nulo
               
                if(resultado.Read()){ // percorreremos nosso objeto que armazenou, o retrono da nossa pesquisa
                    clie = new Cliente();


                    clie.IdUsuario=resultado.GetInt32("IdUsuario");

                    if(!resultado.IsDBNull(resultado.GetOrdinal("Nome"))){
                        clie.Login= resultado.GetString("Nome");
                    }

                    if(!resultado.IsDBNull(resultado.GetOrdinal("Login"))){
                            clie.Login = resultado.GetString("Login");
                    }

                    if(!resultado.IsDBNull(resultado.GetOrdinal("Senha"))){
                        clie.Senha=resultado.GetString("Senha");
                    }
                    
                }
                 conexao.Close();
                return clie;
        }



        public List<Cliente> ListarCliente(){ //Read

            conexao.Open();
            string query="SELECT * FROM Usuario;";
            MySqlCommand comando = new MySqlCommand(query,conexao);

            MySqlDataReader reader = comando.ExecuteReader();

            List<Cliente> lista = new List<Cliente>();

            while(reader.Read()){
                Cliente clie = new Cliente(); //clie = clientes
                clie.IdUsuario = reader.GetInt32("IdUsuario");

                if(!reader.IsDBNull(reader.GetOrdinal("Nome"))){
                    clie.Nome=reader.GetString("Nome");
                }
                 if(!reader.IsDBNull(reader.GetOrdinal("Login"))){
                    clie.Login=reader.GetString("Login");
                }
                 if(!reader.IsDBNull(reader.GetOrdinal("Senha"))){
                    clie.Senha=reader.GetString("Senha");
                }
                 if(!reader.IsDBNull(reader.GetOrdinal("DataNascimento"))){
                   clie.DataNascimento=reader.GetDateTime("DataNascimento");
                }
                 
                            lista.Add(clie);           
                }
               
                        conexao.Close();
                    return lista;   
            }
            

               public void  Atualizar(Cliente clie_ID){ //Update
            conexao.Open();
            string query = "UPDATE Usuario SET  Nome=@Nome,Login=@Login,Senha=@Senha,DataNascimento=@DataNascimento WHERE IdUsuario=@IdUsuario;";
            MySqlCommand  comando=new MySqlCommand(query,conexao);

            comando.Parameters.AddWithValue("@IdUsuario",clie_ID.IdUsuario );
            comando.Parameters.AddWithValue("@Nome",clie_ID.Nome);
            comando.Parameters.AddWithValue("@Login",clie_ID.Login);
            comando.Parameters.AddWithValue("@Senha",clie_ID.Senha);
            comando.Parameters.AddWithValue("@DataNascimento",clie_ID.DataNascimento);
           

            comando.ExecuteNonQuery();
            conexao.Close();


            }

             public void Delete(Cliente clie_del){  // Delete

                           
                            conexao.Open();
                            string queryDelete = "DELETE FROM Usuario WHERE IdUsuario =@IdUsuario";
                            MySqlCommand  comando = new MySqlCommand(queryDelete,conexao);
                            comando.Parameters.AddWithValue("@IdUsuario",clie_del.IdUsuario); // vai carregar o id pra selecionar a linha a ser excluida
                            comando.ExecuteNonQuery();
                            conexao.Close();


                        }




           
            public Cliente BuscarPorId(int up_clie){ // Buscar por ID
                conexao.Open();
                Cliente clieEncontrado = new Cliente();
                string queryID = "SELECT * FROM Usuario WHERE IdUsuario=@IdUsuario;";
                MySqlCommand comando = new MySqlCommand(queryID,conexao);

                comando.Parameters.AddWithValue("@IdUsuario",up_clie);

                MySqlDataReader reader = comando.ExecuteReader();

                if(reader.Read()){
                    clieEncontrado.IdUsuario = reader.GetInt32("IdUsuario");

                    if(reader.IsDBNull(reader.GetOrdinal("Nome"))){
                        clieEncontrado.Nome = reader.GetString("Nome");
                    }
                    if(reader.IsDBNull(reader.GetOrdinal("Login"))){
                        clieEncontrado.Login=reader.GetString("Login");
                    }
                    if(reader.IsDBNull(reader.GetOrdinal("Senha"))){
                            clieEncontrado.Senha=reader.GetString("Senha");
                    }
                    if(reader.IsDBNull(reader.GetOrdinal("DataNascimento"))){
                          clieEncontrado.DataNascimento=reader.GetDateTime("DataNascimento");
                    }
                       
                   
                }

                conexao.Close();

                return clieEncontrado;
            }
            
                
        
     
      

        
    }
}