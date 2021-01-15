using DevStore.Data.Repositories;
using DevStore.Domain.Entities;
using DevStore.Domain.Repositories;
using DevStore.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevStore.Service.Services
{
    public class ProductService : IProductService
    {
        private IProductRepository _repository;

        public ProductService()
        {
            _repository = new ProductRepository();
        }
        public void CreateNewProduct(string name)
        {
            var product = new Product();
            product.Name = name;
            product.Id = 0;
            _repository.Create(product);
        }

        public void Dispose()
        {
            _repository.Dispose();
        }
    }
}
