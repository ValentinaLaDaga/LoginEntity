using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LoginEntity.Models.InputModels;
using LoginEntity.Models.ViewModels;

namespace LoginEntity.Models.Services.Application
{
    public interface ILoginService
    {
        Task<List<UtentiViewModel>> GetUtentiAsync(SearchListInputModel model);
        //Task<bool> RegistraUtenteAsync(string nome, string email, string nazione, string password);
        Task<bool> RegistraUtenteAsync(UtentiListInputModel model);

        Task<int> EliminaUtenteAsync(int id);

        Task<bool> LoginUtente(UtentiListInputModel model);

        Task<bool> UpdateUtenteAsync(UtentiListInputModel model);
        Task<UtentiViewModel> RecuperaUtente(int id);
        
    }
}