
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ATV2UC04_JairoCesar.Models;
namespace ATV2UC04_JairoCesar.Controllers
{
    public class PacotesTuristicosController:Controller
    {

         public IActionResult cadastrarPacote(){ 

            return View();
        }

            [HttpPost]
         public IActionResult cadastrarPacote(PacotesTuristicos pc){ // tem controle de acesso
         // validando se o usuario esta logado, caso não esteja sera redirecionado para login
              // o incremento if abaixo serve para fazer a validação e recuperar dados da sessão
              if(HttpContext.Session.GetInt32("IdUsuario")==null){ // IdUsuario aqui passa a ser nossa variavel de sessão
                 return RedirectToAction("login","Usuario");
                }
             PacotesTuristicosRepository pcr = new PacotesTuristicosRepository();
             ClienteRepository cr = new ClienteRepository();
            
             pcr.cadastrarPacote(pc);
             ViewData["cadastrado"] = " pacote cadastrado com sucesso";

            return RedirectToAction("listarPacote");
        }



          public IActionResult listarPacote(){// tem controle de acesso
              // validando se o usuario esta logado, caso não esteja sera redirecionado para login
              // o incremento if abaixo serve para fazer a validação e recuperar dados da sessão
              if(HttpContext.Session.GetInt32("IdUsuario")==null){ // IdUsuario aqui passa a ser nossa variavel de sessão
                 return RedirectToAction("login","Usuario");
                }
              PacotesTuristicosRepository pr = new PacotesTuristicosRepository();
              List<PacotesTuristicos> pctencontrado =  pr.ListarPacotes();


            return View(pctencontrado);
        }
 

        public IActionResult AtualizarPacotes(int updPacote){
             // validando se o usuario esta logado, caso não esteja sera redirecionado para login
              // o incremento if abaixo serve para fazer a validação e recuperar dados da sessão
              if(HttpContext.Session.GetInt32("IdUsuario")==null){ // IdUsuario aqui passa a ser nossa variavel de sessão
                 return RedirectToAction("login","Usuario");
                }
            PacotesTuristicosRepository pr = new PacotesTuristicosRepository();
            PacotesTuristicos pctencontrado = pr.BuscarPorId(updPacote);
            return View(pctencontrado);
        }

        [HttpPost]
         public IActionResult AtualizarPacotes(PacotesTuristicos pctId){
            PacotesTuristicosRepository pr = new PacotesTuristicosRepository();
            pr.Atualizar(pctId);
            
            return RedirectToAction("listarPacote");
            
        }

       
 public IActionResult Excluir(int IdPacotes){ //Delete
           PacotesTuristicosRepository pr = new PacotesTuristicosRepository();
            PacotesTuristicos excluirPct =  pr.BuscarPorId(IdPacotes);

            if(excluirPct.IdPacotes > 0){
            pr.Delete(excluirPct);
            }
            
            else
            {
              ViewData["excluir"] = "usuario não encontrado";   
            }

            return RedirectToAction("listarPacote");

        }
        public IActionResult vitrine(){

            return View();
        }   

      

        public IActionResult cananeia(){

            return View();
        }
         public IActionResult ilhacomprida(){

            return View();
        }
         public IActionResult ilhadocardoso(){

            return View();
        }
        
    }
}