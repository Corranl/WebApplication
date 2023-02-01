using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using WebApplication.Model;

namespace WebApplication.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Fournisseur> Fournisseurs { get; set; }
        public DbSet<Produit> Produits { get; set; }
        public DbSet<Utilisateur> Utilisateurs{ get; set; }
        public DbSet<CmdFournisseur> CmdFournisseurs { get; set; }
        public DbSet<CmdClient> CmdClient { get; set; }
    }
}
