using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWorkshop.Infrastructure.Persistence
{
    public class CarWorkshopDbContext : DbContext
    {
        public DbSet<Domain.Entities.CarWorkshop> CarWorkshops { get; set; } //zdefiniowanie wlasciwosci, ktora bedzie reprezentacja tabeli jaka zostanie utworzona w naszej bazie danych

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=CarWorkshopDb;Trusted_Connection=True;"); //konfiguracja polaczenia do konkretnej instancji baz danych
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) //metoda ktora pozwala na definicje typow czy tez relacji pomiedzy naszymi encjami
        {
            modelBuilder.Entity<Domain.Entities.CarWorkshop>()
                .OwnsOne(c => c.ContactDetails);    //entity framework wie, ze contactdetails nie jest dodatkowa tabela a jest to wlasciwosc ktora nalezy umiescic w ramach tabeli ktora jest reprezentacja typu carworkshop
        }
    }
}
//aby stworzyc baze danych nalezy skonfigurowac entity framework jak powyzej, w package manager console (tools -> nuget package manager -> console) zrobic migracje (add-migration @{nazwa}) a na koniec zaktualizowc poprzed (update-database)