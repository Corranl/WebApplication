using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using WebApplication;

namespace WebApplication
{
    public class Produit  
    {
        [JsonIgnore]
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Reference { get; set; }
        public string Quantite { get; set; }
        public string PrixUnitaire { get; set; }
        public string PrixCarton { get; set; }
        public string Millesime { get; set; }
        public string Famille { get; set; }
        public string Volume { get; set; }
        


    }
}
