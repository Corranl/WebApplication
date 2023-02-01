using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication;


namespace WebApplication
{
    public class Utilisateur 
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        [Display(Name = "Prénom")]
        public string Prenom { get; set; }
        [Display(Name = "Téléphone")]
        public string Telephone { get; set; }
        [Display(Name = "E-Mail")]
        public string Email { get; set; }
        public string Password { get; set; }


        public Utilisateur()
        {

        }
    
}
}
