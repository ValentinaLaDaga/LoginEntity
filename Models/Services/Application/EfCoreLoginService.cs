using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LoginEntity.Models.Entities;
using LoginEntity.Models.ViewModels;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using LoginEntity.Models.InputModels;
using LoginEntity.Models.Services.Infrastructure;

namespace LoginEntity.Models.Services.Application
{
    public class EfCoreLoginService : ILoginService
    {
        private readonly LoginDbContext dbContext;

        public EfCoreLoginService(LoginDbContext dbContext)
        {
            this.dbContext=dbContext;
        }

/*
        public async Task<List<UtentiViewModel>> GetUtentiAsync(SearchListInputModel model)
        {
            IQueryable<Iscritto> baseQuery =  dbContext.Utenti;

            IQueryable<UtentiViewModel> queryLinq = baseQuery
            .AsNoTracking()
            .Where(iscritto => iscritto.Nome.Contains(model.Search))
            .Select(course => UtentiViewModel.FromEntity(iscritto));

            List<UtentiViewModel> utenti = await queryLinq.ToListAsync();//Viene aperta una connessione con il db e inviata la query al database 

            return utenti; 
        }
*/

        public async Task<List<UtentiViewModel>> GetUtentiAsync(SearchListInputModel model)
        {
            IQueryable<UtentiViewModel> queryLinq = dbContext.Iscritto
                .AsNoTracking()
                .Where(iscritto => iscritto.Nome.Contains(model.Search))
                .Select(iscritto => new UtentiViewModel
                {
                    Id = iscritto.Id,
                    Nome = iscritto.Nome,
                    Email = iscritto.Email,
                    Nazione = iscritto.Nazione,
                    Password = iscritto.Password
                });

            List<UtentiViewModel> utenti = await queryLinq.ToListAsync();

            return utenti;
        }

        public async Task<int> EliminaUtenteAsync(int id)
        {
            var utente = await dbContext.Iscritto.FindAsync(id);
            if (utente != null)
            {
                dbContext.Iscritto.Remove(utente);
                await dbContext.SaveChangesAsync();
                return 1;
            }
            return 0;
        }

        public async Task<bool> RegistraUtenteAsync(UtentiListInputModel model)
        {
            try
            {
                var utente = new Iscritto
                {                   
                    Nome = model.Nome,
                    Email = model.Email,
                    Nazione = model.Nazione,
                    Password = model.Password,
                    
                };
                dbContext.Iscritto.Add(utente);
                await dbContext.SaveChangesAsync();
                //Recuperato l'ltlimo Id inserito
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Errore durante la registrazione dell'utente: {ex.Message}");
                return false;
            }
        }


        public async Task<bool> LoginUtente(UtentiListInputModel model)
        {
            var count = await dbContext.Iscritto
                .Where(iscritto => iscritto.Email == model.Email && iscritto.Password == model.Password)
                .CountAsync();

            return count > 0;
        }

        public async Task<bool> UpdateUtenteAsync(UtentiListInputModel model)
        {
            try
            {
                var utente = await dbContext.Iscritto.FindAsync(model.Id);
                if (utente != null)
                {
                    utente.Nome = model.Nome;
                    utente.Email = model.Email;
                    utente.Nazione = model.Nazione;
                    utente.Password = model.Password;
                    await dbContext.SaveChangesAsync();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Errore durante l'aggiornamento dell'utente: {ex.Message}");
                return false;
            }
        }

/*
        public async Task<UtentiViewModel> RecuperaUtente(int id)
        {
            IQueryable<UtentiViewModel> queryLinq = dbContext.Utenti
                .AsNoTracking()
                .Where(iscritto => iscritto.Id == id)
                .Select(iscritto => UtentiViewModel.FromEntity(iscritto));
            UtentiViewModel viewModel = await queryLinq.SingleAsync();//qui avviene la connessione con in db e l'esecuzione della query

            return viewModel;
        } */

        public async Task<UtentiViewModel> RecuperaUtente(int id)
        {
            var utente = await dbContext.Iscritto.FindAsync(id);
            if (utente != null)
            {
                return new UtentiViewModel
                {
                    Id = utente.Id,
                    Nome = utente.Nome,
                    Email = utente.Email,
                    Nazione = utente.Nazione,
                    //Password = utente.Password,
                
                };
            }
            return null;
        }
        
    }
}