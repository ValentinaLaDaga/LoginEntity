using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using LoginEntity.Models.Services.Application;
using Microsoft.Data.Sqlite;
using LoginEntity.Models.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.Data.Sqlite;
using LoginEntity.Models.InputModels;

namespace LoginEntity.Controllers
{
    
public class LoginController : Controller
    {
        private readonly ILoginService LoginService;

        public LoginController(ILoginService loginService)
        {
            //verrà iniettato automaticamente un oggetto di una classe che implementa l'interfaccia ICourseService
            this.LoginService = loginService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> LoginUtente(UtentiListInputModel model)
        {
            try
            {
                // Eseguiamo l'inserimento dell'utente nel database
                bool registrationResult = await LoginService.LoginUtente(model);
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

            return RedirectToAction("Index", "Home");

        }
    }


}