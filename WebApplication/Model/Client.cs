using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication;

namespace WebApplication
{
    public class Client
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Telephone { get; set; }
        public string Email { get; set; }  
        public string Password { get; set; }
        public List<Produit> Produits { get; set; }
            public Client()
        {

        }
    }
}
