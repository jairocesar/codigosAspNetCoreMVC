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
    public class UsuarioController:Controller
    {
 


//____________________LOGIN_________________________________________
        public IActionResult login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult login(Cliente c){
            ClienteRepository lg = new ClienteRepository();
             Cliente UserSesseion= lg.Login(c);

                if(UserSesseion==null){
                     ViewBag.msg="falha de login: cadastre-se";
                    return RedirectToAction("Cadastro","Usuario");
                }else{                      
                     
                     // registrar na sessão os dados do usuario
                      HttpContext.Session.SetInt32("IdUsuario",UserSesseion.IdUsuario);    // IdUsuario aqui passa a ser nossa variavel de sessão
                    HttpContext.Session.SetString("Login",UserSesseion.Login);           // NomeUsuario aqui passa a ser nossa variavel de sessão

                    }
                    ViewBag.msg="cliente logado com sucesso";
                     return RedirectToAction("Index","Home");     
            }


 //_____________________FIM_LOGIN_______________________________________

  public IActionResult Logout()
        {
            HttpContext.Session.Clear(); // limpar os dados da sessaão
            

            // redirecionamento login 
            return View("login");
        }

//_____________________FIM_LOGOUT_____________________________________        
        
       

            public IActionResult Cadastro(){

                return View();
            }
            
        [HttpPost]
        public IActionResult Cadastro(Cliente c){
            ClienteRepository cr = new ClienteRepository();
            cr.cadastrar(c);

            return RedirectToAction("login");
        }


         public IActionResult ListarUsuario (){// tem controle de acesso
              // validando se o usuario esta logado, caso não esteja sera redirecionado para login
              // o incremento if abaixo serve para fazer a validação e recuperar dados da sessão
              //if(HttpContext.Session.GetInt32("IdUsuario")==null){ // IdUsuario aqui passa a ser nossa variavel de sessão
                // return RedirectToAction("login","Usuario");
                //}
              ClienteRepository clie = new ClienteRepository();
              List<Cliente> clieEncontrado = clie.ListarCliente();


            return View(clieEncontrado);
        }
 
    public IActionResult AtualizarUsuario(int up_clie){
             // validando se o usuario esta logado, caso não esteja sera redirecionado para login
              // o incremento if abaixo serve para fazer a validação e recuperar dados da sessão
              if(HttpContext.Session.GetInt32("IdUsuario")==null){ // IdUsuario aqui passa a ser nossa variavel de sessão
                 return RedirectToAction("login","Usuario");
                }
            ClienteRepository cr = new ClienteRepository();
            Cliente clieEncontrado = cr.BuscarPorId(up_clie);
            return View(clieEncontrado);
        }

        [HttpPost]
         public IActionResult AtualizarUsuario (Cliente clie_ID){
            ClienteRepository cr = new ClienteRepository();
            cr.Atualizar(clie_ID);
            
            return RedirectToAction("ListarUsuario");
            
        }

        public IActionResult Delete(int clie_del){
            ClienteRepository cr = new ClienteRepository();
            Cliente c_del = cr.BuscarPorId(clie_del);
            if(c_del.IdUsuario > 0){
                cr.Delete(c_del);
            }else
            {
              ViewData["excluir"] = "usuario não encontrado";   
            }


            return RedirectToAction("ListarUsuario");
        }

       




          


        




        
        
        
    }
}