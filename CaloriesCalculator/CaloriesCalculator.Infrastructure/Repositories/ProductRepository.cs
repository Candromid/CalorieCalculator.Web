using CaloriesCalculator.Core.Entities;
using Microsoft.EntityFrameworkCore;
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

        public List<Product> Search(string name)
        {
            return databaseContext.Products.Where(p => p.Name.Contains(name)).ToList();
        }

        public Product Search(int id)
        {
            var product = databaseContext.Products.Where(p => p.Id == id);

            if (product.Count() > 1)
            {
                throw new Exception("Количество найденных продуктов по уникальному идентификатору больше 1");
            }

            if (product.Count() == 0) return null;

            return product.Single();
        }

        public List<Product> GetAll()
        {
            return databaseContext.Products.ToList();
        }

        public void Add(Product product)
        {
            databaseContext.Products.Add(product);
            databaseContext.SaveChanges();
        }

        public void Update(int id, Product updatableProduct)
        {
            var product = Search(id);
            if (product ==null)
            {
                throw new Exception("Попытка обновить несуществующий продукт!!!"); 
            }
            product.Name = updatableProduct.Name ;
            product.Proteins = updatableProduct.Proteins;
            product.Fats = updatableProduct.Fats;
            product.Carbohydrates = updatableProduct.Carbohydrates;

            databaseContext.SaveChanges();
        }

        public void Delete(Product product)
        {
            databaseContext.Products.Remove(product);
            databaseContext.SaveChanges();
        }


    }
}
