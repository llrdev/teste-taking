using Domain.Entities;
using Domain.Interfaces;

namespace Infrastructure.Repositories
{
    public class InMemorySaleRepository : ISaleRepository
    {
        private readonly List<Sale> _sales = new();
        private int _nextId = 1;

        public Task<IEnumerable<Sale>> GetAllAsync() => Task.FromResult(_sales.AsEnumerable());

        public Task<Sale> GetByIdAsync(int id) => Task.FromResult(_sales.FirstOrDefault(s => s.Id == id));

        public Task CreateAsync(Sale sale)
        {
            sale.Id = _nextId++;
            _sales.Add(sale);
            return Task.CompletedTask;
        }

        public Task UpdateAsync(Sale sale)
        {
            var existingSale = _sales.FirstOrDefault(s => s.Id == sale.Id);
            if (existingSale != null)
            {
                existingSale.SaleDate = sale.SaleDate;
                existingSale.SaleAmount = sale.SaleAmount;
            }
            return Task.CompletedTask;
        }

        public Task DeleteAsync(int id)
        {
            var sale = _sales.FirstOrDefault(s => s.Id == id);
            if (sale != null)
            {
                _sales.Remove(sale);
            }
            return Task.CompletedTask;
        }
    }
}
