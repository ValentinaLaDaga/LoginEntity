using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;

namespace LoginEntity.Models.ViewModels
{
    public class UtentiViewModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Nazione { get; set; }
        public string Password { get; set; }

        public static UtentiViewModel FromDataRow(DataRow utentiRow)
        {
            var utentiViewModel = new UtentiViewModel
            {
                Id = Convert.ToInt32(utentiRow["id"]),
                Nome = Convert.ToString(utentiRow["nome"]),
                Email = Convert.ToString(utentiRow["email"]),
                Nazione = Convert.ToString(utentiRow["nazione"]),
                Password = Convert.ToString(utentiRow["password"]),
            };
            return utentiViewModel;
        }

    }
}