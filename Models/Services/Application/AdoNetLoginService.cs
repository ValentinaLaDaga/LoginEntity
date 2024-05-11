using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LoginEntity.Models.Services.Infrastructure;
using System.Data;
using LoginEntity.Models.ViewModels;
using LoginEntity.Models.InputModels;

namespace LoginEntity.Models.Services.Application
{
    public class AdoNetLoginService : ILoginService
    {
        private readonly IDatabaseAccessor db; // proprieta che deve essere iniettata nel servizio applicativo

        public AdoNetLoginService(IDatabaseAccessor db) // dipendenza debole
        {
            this.db = db;
        }


        public async Task<List<UtentiViewModel>> GetUtentiAsync(SearchListInputModel model)
        {

            FormattableString query = $"SELECT *  FROM iscritto WHERE nome LIKE {"%" + model.Search + "%"}";
            DataSet dataSet = await db.QueryAsync(query);
            var dataTable = dataSet.Tables[0]; //recupera la prima tabella del dataset
            var utentiList = new List<UtentiViewModel>(); //crea la lista di corsi che deve eseere passata all view
            // per ogni riga presente nalla datatable deve creare un oggetto di tipo CourseViewModel 
            foreach (DataRow utenteRow in dataTable.Rows)
            {
                UtentiViewModel utente = UtentiViewModel.FromDataRow(utenteRow);
                utentiList.Add(utente);
            }
            return utentiList;
        }

        public async Task<int> EliminaUtenteAsync(int id)
        {
            try
            {
                FormattableString query = $"DELETE FROM iscritto WHERE id = {id}";

                // Eseguire la query
                await db.QueryAsync(query);
                return 1; // Ritorna un valore int per indicare l'avvenuta eliminazione
            }
            catch
            {
                return 0; // Ritorna 0 se si verifica un errore durante l'eliminazione
            }


        }

        // public async Task<bool> RegistraUtenteAsync(string nome, string email, string nazione, string password)
        public async Task<bool> RegistraUtenteAsync(UtentiListInputModel model)
        {
            FormattableString query = $"INSERT INTO iscritto (nome, email, nazione, password) VALUES ({model.Nome}, {model.Email}, {model.Nazione}, {model.Password})";


            try
            {
                await db.QueryAsync(query);
                return true; // Ritorna true se la registrazione ha avuto successo
            }
            catch (Exception ex)
            {
                // Gestisci eventuali eccezioni, ad esempio registrando un errore o lanciando un'eccezione personalizzata
                Console.WriteLine($"Errore durante la registrazione dell'utente: {ex.Message}");
                return false; // Ritorna false se la registrazione ha fallito
            }
        }


        public async Task<bool> LoginUtente(UtentiListInputModel model)
        {
            FormattableString query = $"SELECT COUNT(*) FROM iscritto WHERE email = {model.Email} AND password = {model.Password}";

            try
            {
                DataSet dataSet = await db.QueryAsync(query);

                // Ottieni il risultato della query
                int count = Convert.ToInt32(dataSet.Tables[0].Rows[0][0]);

                // Verifica se il risultato contiene almeno una riga
                // Se sì, significa che le credenziali sono corrette e l'utente può accedere
                return count > 0;


            }
            catch (Exception ex)
            {

                Console.WriteLine($"Errore durante la registrazione dell'utente: {ex.Message}");
                return false;
            }
        }

        public async Task<bool> UpdateUtenteAsync(UtentiListInputModel model)

        {
            FormattableString query = $@"UPDATE iscritto SET 
            nome = {model.Nome}, email= {model.Email}, nazione = {model.Nazione}, password = {model.Password}
            WHERE id = {model.Id}";



            try
            {
                await db.QueryAsync(query);
                return true; // Ritorna true se la registrazione ha avuto successo
            }
            catch (Exception ex)
            {
                // Gestisci eventuali eccezioni, ad esempio registrando un errore o lanciando un'eccezione personalizzata
                Console.WriteLine($"Errore durante l'aggiornamento dell'utente: {ex.Message}");
                return false; // Ritorna false se la registrazione ha fallito
            }


        }

        public async Task<UtentiViewModel> RecuperaUtente(int id)
        {
            FormattableString query = $"SELECT *  FROM iscritto WHERE id = {id}";

            DataSet dataSet = await db.QueryAsync(query);
            var dataTable = dataSet.Tables[0];
            UtentiViewModel utente = new UtentiViewModel();

            foreach (DataRow utenteRow in dataTable.Rows)
            {
                utente = UtentiViewModel.FromDataRow(utenteRow);

            }

            return utente;
        }
    }
}