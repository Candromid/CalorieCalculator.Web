using CaloriesCalculator.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaloriesCalculator.Infrastructure.Repositories
{
    public class ProductRepository
    {
        private readonly DatabaseContext databaseContext;

        public ProductRepository(DatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }

        public List<Product> Search(string term)
        {
            return databaseContext.Products.Where(p => p.Name.Contains(term)).ToList();
        }
    }
}
