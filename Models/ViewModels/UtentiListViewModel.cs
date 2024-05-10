using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LoginEntity.Models.InputModels;

namespace LoginEntity.Models.ViewModels
{
    public class UtentiListViewModel
    {
        public List<UtentiViewModel> Utenti {get;set;}

        public UtentiListInputModel Input {get;set;}

        public SearchListInputModel Ricerca {get;set;}
    }
}