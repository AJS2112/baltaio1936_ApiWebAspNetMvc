using DevStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevStore.Domain.Repositories
{
    public interface IProductRepository : IDisposable
    {
        List<Product> Get(int skip=0, int take=25);
        Product Get(int id);
        void Create(Product product);
        void Update(Product product);
        void Delete(int id);

    }
}
