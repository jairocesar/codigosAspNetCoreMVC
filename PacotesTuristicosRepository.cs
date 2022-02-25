using System;
using System.Collections.Generic;
using MySqlConnector;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ATV2UC04_JairoCesar.Models;
namespace ATV2UC04_JairoCesar.Models
{
    public class PacotesTuristicosRepository:Repository
    {   
        // para conexão estou usando erança de Repository
       // protected const  string DDdeConexao = "Database =AgV_DestCerto;Data Source=localhost;User id=root; ";
       //protected MySqlConnection conexao= new MySqlConnection(DDdeConexao);
         public void cadastrarPacote(PacotesTuristicos c){ //create
           
            
            conexao.Open();
            
            string query ="INSERT INTO PacotesTuristicos(Nome,Origem,Atrativos,Destino,Saida,Retorno)VALUES(@Nome,@Origem,@Atrativos,@Destino,@Saida,@Retorno)";
            
            MySqlCommand comando = new MySqlCommand(query,conexao);
            
            comando.Parameters.AddWithValue("@Nome",c.Nome);
            comando.Parameters.AddWithValue("@Origem",c.Origem);
            comando.Parameters.AddWithValue("@Destino",c.Destino);
            comando.Parameters.AddWithValue("@Atrativos",c.Atrativos);
            comando.Parameters.AddWithValue("@Saida",c.Saida);
            comando.Parameters.AddWithValue("@Retorno",c.Retorno);

           

            
            
            comando.ExecuteNonQuery();

            conexao.Close();

        }



         public List<PacotesTuristicos> ListarPacotes(){ //Read

            conexao.Open();
            string query="SELECT * FROM PacotesTuristicos;";
            MySqlCommand comando = new MySqlCommand(query,conexao);

            MySqlDataReader reader = comando.ExecuteReader();

            List<PacotesTuristicos> lista = new List<PacotesTuristicos>();

            while(reader.Read()){
                PacotesTuristicos pC = new PacotesTuristicos(); //pC = pacotesCadastrados
                pC.IdPacotes = reader.GetInt32("IdPacotes");

                if(!reader.IsDBNull(reader.GetOrdinal("Nome"))){
                    pC.Nome=reader.GetString("Nome");
                }
                 if(!reader.IsDBNull(reader.GetOrdinal("Origem"))){
                    pC.Origem=reader.GetString("Origem");
                }
                 if(!reader.IsDBNull(reader.GetOrdinal("Destino"))){
                    pC.Destino=reader.GetString("Destino");
                }
                 if(!reader.IsDBNull(reader.GetOrdinal("Atrativos"))){
                    pC.Atrativos=reader.GetString("Atrativos");
                }
                 
                    pC.Saida=reader.GetDateTime("Saida");
                
                 
                    pC.Retorno=reader.GetDateTime("Retorno");
                
                
                lista.Add(pC);

            }
            
           
           conexao.Close();
           return lista;     
                
        }

            public void  Atualizar(PacotesTuristicos Pupdate){ //Update
            conexao.Open();
            string query = "UPDATE PacotesTuristicos SET  Nome=@Nome,Origem=@Origem,Atrativos=@Atrativos,Destino=@Destino,Saida=@Saida,Retorno=@Retorno WHERE IdPacotes=@IdPacotes;";
            MySqlCommand  comando=new MySqlCommand(query,conexao);

            comando.Parameters.AddWithValue("@IdPacotes",Pupdate.IdPacotes);
            comando.Parameters.AddWithValue("@Nome",Pupdate.Nome);
            comando.Parameters.AddWithValue("@Origem",Pupdate.Origem);
            comando.Parameters.AddWithValue("@Atrativos",Pupdate.Atrativos);
            comando.Parameters.AddWithValue("@Destino",Pupdate.Destino);
            comando.Parameters.AddWithValue("@Saida",Pupdate.Saida);
            comando.Parameters.AddWithValue("@Retorno",Pupdate.Retorno);

            comando.ExecuteNonQuery();
            conexao.Close();


            }

             public void Delete(PacotesTuristicos del){  // Delete

                           
                            conexao.Open();
                            string queryDelete = "DELETE FROM PacotesTuristicos WHERE IdPacotes=@IdPacotes";
                            MySqlCommand  comando = new MySqlCommand(queryDelete,conexao);
                            comando.Parameters.AddWithValue("@IdPacotes",del.IdPacotes); // vai carregar o id pra selecionar a linha a ser excluida
                            comando.ExecuteNonQuery();
                            conexao.Close();


                        }





            // o metodo abaixo faz uma busca tendo como referencia o id da tabela
            // esse metodo auxilia outros metodos em buscas especificas e alteraçoes que precisan ser feito em uma tabela no BD
            // de forma que não deixa por exemplo que uma alteração em uma linha, modifique a tabela enteira

            public PacotesTuristicos BuscarPorId(int updPacote){ // Buscar por ID
                conexao.Open();
                PacotesTuristicos pctEncontrado = new PacotesTuristicos();
                string queryID = "SELECT * FROM PacotesTuristicos WHERE IdPacotes=@IdPacotes;";
                MySqlCommand comando = new MySqlCommand(queryID,conexao);

                comando.Parameters.AddWithValue("@IdPacotes",updPacote);

                MySqlDataReader reader = comando.ExecuteReader();

                if(reader.Read()){
                    pctEncontrado.IdPacotes = reader.GetInt32("IdPacotes");

                    if(reader.IsDBNull(reader.GetOrdinal("Nome"))){
                        pctEncontrado.Nome = reader.GetString("Nome");
                    }
                    if(reader.IsDBNull(reader.GetOrdinal("Origem"))){
                        pctEncontrado.Origem=reader.GetString("Origem");
                    }
                    if(reader.IsDBNull(reader.GetOrdinal("Atrativos"))){
                            pctEncontrado.Atrativos=reader.GetString("Atrativos");
                    }
                    if(reader.IsDBNull(reader.GetOrdinal("Saida"))){
                            pctEncontrado.Saida=reader.GetDateTime("Saida");
                    }
                    if(reader.IsDBNull(reader.GetOrdinal("Retorno"))){
                        pctEncontrado.Retorno=reader.GetDateTime("Retorno");

                    }
                    
                   
                }

                conexao.Close();

                return pctEncontrado;
            }

        
    }
}