using System;
using System.Collections.Generic;

namespace LoginEntity.Models.Entities
{

    public partial class Iscritto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Nazione { get; set; }
        public string Password { get; set; }
        

    }
}
