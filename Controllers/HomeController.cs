using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LoginEntity.Models;
using Microsoft.Extensions.Logging;
using LoginEntity.Models.Services.Application;
using Microsoft.AspNetCore.Http;
using Microsoft.Data.Sqlite;
using LoginEntity.Models.ViewModels;
using LoginEntity.Models.InputModels;

namespace LoginEntity.Controllers
{
    public class HomeController : Controller
    {       

  
         private readonly ILoginService LoginService;
          public HomeController(ILoginService loginService)
        {
            //verrà iniettato automaticamente un oggetto di una classe che implementa l'interfaccia ICourseService
            this.LoginService = loginService;
        }


        
      public IActionResult Index(UtentiListInputModel model)
    {
         UtentiListViewModel viewModel = new UtentiListViewModel{
                
                Input = model
            };
        // Carica la vista del modulo di iscrizione
        return View(viewModel);
    }
[HttpPost] public async Task<IActionResult> Iscrizione(UtentiListInputModel model)
        {
                try
                {
                    // Eseguiamo l'inserimento dell'utente nel database
                    //bool registrationResult = await LoginService.RegistraUtenteAsync(model.Nome, model.Email, model.Nazione,model.Password);
                    Console.WriteLine(model.Nome);
                    bool registrationResult = await LoginService.RegistraUtenteAsync(model);
                    
                    if (registrationResult)
                    {
                        // La registrazione è avvenuta con successo, reindirizziamo l'utente alla pagina di successo
                        return RedirectToAction("Accesso", "Utenti");
                    }
                    else
                    {
                        // Gestisci il fallimento dell'inserimento
                        ModelState.AddModelError(string.Empty, "Inserimento utente non riuscito.");
                    }
                }
                catch (Exception ex)
                {
                    // Gestisci eventuali eccezioni durante l'inserimento nell'utente nel database
                    ModelState.AddModelError(string.Empty, "Si è verificato un errore durante l'inserimento dell'utente.");
                }
            
          return View("Index");
        }

    }
}