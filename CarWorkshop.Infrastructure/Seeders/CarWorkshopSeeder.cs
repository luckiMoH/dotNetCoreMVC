using CarWorkshop.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWorkshop.Infrastructure.Seeders
{
    public class CarWorkshopSeeder
    {
        private readonly CarWorkshopDbContext _dbContext;
        public CarWorkshopSeeder(CarWorkshopDbContext dbContext) // zależność do naszego DbContextu
        {
            _dbContext = dbContext;
        }

        public async Task Seed() //inizjalizacja naszego seedera
        {
            if(await _dbContext.Database.CanConnectAsync()) // sprawdzenie czy jest polaczenie z bazą danych
            {
                if(!_dbContext.CarWorkshops.Any()) // sprawdzenie czy tabela jest pusta
                {
                    var mazdaAso = new Domain.Entities.CarWorkshop()
                    {
                        Name = "Mazda ASO",
                        Description = "Autoryzowany serwis Mazda",
                        ContactDetails = new()
                        {
                            City = "Toruń",
                            Street = "Poznańska 12",
                            PostalCode = "87-100",
                            PhoneNumber = "+48111222333"
                        }
                    };
                    mazdaAso.EncodeName();
                    _dbContext.CarWorkshops.Add(mazdaAso); // dodanie obiektu mazdaAso do pustej tabeli
                    await _dbContext.SaveChangesAsync(); // zapisanie zmian
                }
            }
        }
    }
}
