using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LoginEntity.Customizations.ModelBinders;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace LoginEntity.Models.InputModels
{
    [ModelBinder(BinderType = typeof(UtentiListInputModelBinder))]
    public class UtentiListInputModel
    {

  
        public int Id { get; }

        public string Email { get; }

        public string Nazione { get; }

        public string Password { get; }

        public string Nome { get; }



        public UtentiListInputModel(int id, string nome, string email, string nazione, string password)
        {
            this.Nome = nome;
            this.Email = email;
            this.Nazione = nazione;
            this.Password = password;
            this.Id = id;
        }
    }

}