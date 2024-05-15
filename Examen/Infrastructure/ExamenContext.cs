using ApplicationCore.Domain;
using Infrastructure.Configurations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class ExamenContext:DbContext
    {
        public DbSet<Client> Clients { get; set; }
        public DbSet<Conseiller> Conseillers { get; set; }
        public DbSet<Pack> Packs { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Activite> Activites { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer
                (@"Data Source=(localdb)\mssqllocaldb;
                   Initial Catalog=AgencerevisionArctic2;
                   Integrated Security=true;
                   MultipleActiveResultSets=true");
            //Activer LazyLoading
            optionsBuilder.UseLazyLoadingProxies();
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //hedhi teb3a type detenu Zone (question 3)
            modelBuilder.Entity<Activite>().OwnsOne(a => a.Zone);
            modelBuilder.Entity<Reservation>().HasKey(r => new { r.packFK, r.clientFK, r.DateReservation });
            modelBuilder.ApplyConfiguration(new ClientConfig());
            base.OnModelCreating(modelBuilder);



        }
        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            configurationBuilder.Properties<String>().HaveMaxLength(15);
            base.ConfigureConventions(configurationBuilder);
        }


    }
}
