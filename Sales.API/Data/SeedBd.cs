using Sales.Shared.Entities;

namespace Sales.API.Data
{
    public class SeedBd
    {
        private readonly DataContext _context;

        public SeedBd(DataContext context)
        {
            _context = context;
        }

        public async Task SeedAsync()
        {
            await _context.Database.EnsureCreatedAsync();

            await CheckCountriesAsync();
        }

        private async Task CheckCountriesAsync()
        {
            if(!_context.Countries.Any())
            {
                _context.Countries.Add(new Country { Name = "México" });
                _context.Countries.Add(new Country { Name = "Rusia" });
                _context.Countries.Add(new Country { Name = "China" });
                _context.Countries.Add(new Country { Name = "Taiwán" });
                _context.Countries.Add(new Country { Name = "India" });
                _context.Countries.Add(new Country { Name = "Canada" });
                _context.Countries.Add(new Country { Name = "Corea del Sur" });
                _context.Countries.Add(new Country { Name = "Guatemala" });
                _context.Countries.Add(new Country { Name = "Ricardito island" });

                await _context.SaveChangesAsync();
            }
        }
    }
}
