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
using LoginEntity.Models.InputModels;

namespace LoginEntity.Controllers
{
    public class UtentiController : Controller
    {
        private readonly ILoginService LoginService;
        public UtentiController(ILoginService loginService)
        {
            //verrà iniettato automaticamente un oggetto di una classe che implementa l'interfaccia ICourseService
            this.LoginService = loginService;
        }


        public async Task<IActionResult> Accesso(SearchListInputModel model)
        {

            List<UtentiViewModel> utenti = await LoginService.GetUtentiAsync(model);

            UtentiListViewModel viewModel = new UtentiListViewModel
            {
                Utenti = utenti,
                Ricerca = model
            };

            return View(viewModel);
        }

        public async Task<IActionResult> DeleteRecord(int id)

        {
            try
            {
                // Chiamata al metodo del servizio applicativo per eliminare il record
                int rowsAffected = await LoginService.EliminaUtenteAsync(id);

                // Verifica se il record è stato eliminato correttamente
                if (rowsAffected > 0)
                {
                    // Il record è stato eliminato con successo, esegui un'azione appropriata (reindirizzamento, messaggio, ecc.)
                    return RedirectToAction("Accesso");
                }
                else
                {

                    return RedirectToAction("Accesso");
                }
            }
            catch (Exception ex)
            {
                // Gestisci eventuali eccezioni durante l'eliminazione del record
                ModelState.AddModelError(string.Empty, "Si è verificato un errore durante l'eliminazione del record.");
                return View("Accesso"); // Esempio: reindirizza alla pagina di errore
            }
        }


        public async Task<IActionResult> Update(int id)
        {

            UtentiViewModel utente = await LoginService.RecuperaUtente(id);

            // Carica la vista del modulo di iscrizione
            return View(utente);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateRecord(UtentiListInputModel model)
        {
            try
            {
                // Chiamata al metodo del servizio applicativo per eliminare il record
                bool rowsAffected = await LoginService.UpdateUtenteAsync(model);

                // Verifica se il record è stato eliminato correttamente
                if (rowsAffected)
                {
                    // Il record è stato eliminato con successo, esegui un'azione appropriata (reindirizzamento, messaggio, ecc.)
                    return RedirectToAction("Accesso");
                }
                else
                {

                    return RedirectToAction("Accesso");
                }
            }
            catch (Exception ex)
            {
                // Gestisci eventuali eccezioni durante l'eliminazione del record
                ModelState.AddModelError(string.Empty, "Si è verificato un errore durante l'aggiornamento del record.");
                return View("Accesso"); // Esempio: reindirizza alla pagina di errore
            }


        }



    }
}
