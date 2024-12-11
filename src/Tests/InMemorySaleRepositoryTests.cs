using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Repositories;

namespace Tests
{
    public class InMemorySaleRepositoryTests
    {
        private readonly ISaleRepository _saleRepository;

        public InMemorySaleRepositoryTests()
        {
            _saleRepository = new InMemorySaleRepository();
        }

        [Fact]
        public async Task CreateSale_ShouldAddSale()
        {
            var sale = new Sale { SaleDate = DateTime.Now, SaleAmount = 100.00m };
            await _saleRepository.CreateAsync(sale);

            var createdSale = await _saleRepository.GetByIdAsync(sale.Id);
            Assert.NotNull(createdSale);
            Assert.Equal(sale.SaleAmount, createdSale.SaleAmount);
        }
    }
}