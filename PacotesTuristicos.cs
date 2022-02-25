using System;
namespace ATV2UC04_JairoCesar.Models
{
    public class PacotesTuristicos
    {
        public int IdPacotes {get; set;}
        public string Nome{get; set;}
        public string Origem{get; set;}
        public string Destino{get; set;}
        public string Atrativos{get; set;}
        public DateTime Saida{get; set;}
        public DateTime Retorno{get; set;}
         public int Usuario{get; set;}
       
       
       

       public PacotesTuristicos(){
           
       }
    }
}