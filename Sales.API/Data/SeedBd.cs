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
            await CheckCategoriesAsync();
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

        private async Task CheckCategoriesAsync()
        {
            if (!_context.Categories.Any())
            {
                _context.Categories.Add(new Category { Name = "RicarditoPro", LName= "Espejel", Address="Calpulalpan,Tlaxcala, Mexico" });
                _context.Categories.Add(new Category { Name = "❤Dania Angelita❤", LName = "❤Millan Lopez❤", Address = "Almoloya,Hidalgo, Mexico" });
                _context.Categories.Add(new Category { Name = "Francisco", LName = "Espejel", Address = "Nuevo Leon, Monterrey, Mexico" });
                _context.Categories.Add(new Category { Name = "Bradon", LName = "Rivera", Address = "Texcoco, Estado de Mexico, Mexico" });
                _context.Categories.Add(new Category { Name = "Josue", LName = "De la Riva", Address = "Tijuana, Baja California, Mexico" });

                await _context.SaveChangesAsync();
            }
        }
    }
}
