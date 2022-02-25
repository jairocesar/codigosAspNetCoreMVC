using System;
using System.Data;

namespace ATV2UC04_JairoCesar.Models
{
    public class Cliente // Model que espelha minha tabela Usuario, no Bd
    {

        public int IdUsuario{get; set;}    
        public string Nome{get; set;}
        
        public DateTime DataNascimento{get; set;}
        public string Login{get; set;}
        public string Senha{get; set;}

        
       
        


        
    }
}