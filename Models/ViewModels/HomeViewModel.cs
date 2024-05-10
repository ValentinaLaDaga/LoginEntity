using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoginEntity.Models.ViewModels
{
    public class HomeViewModel
    {
         public HomeViewModel(string nome, string email, string nazione, int id, string password) 
        {
            this.Nome = nome;
            this.Email = email;
            this.Nazione = nazione;
            this.Id = id;
            this.Password = password;
   
        }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Nazione { get; set; }
        public int Id { get; set; }
        public string Password { get; set; }
    }
}