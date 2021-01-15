using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevStore.Domain.Services
{
    public interface IProductService : IDisposable
    {
        void CreateNewProduct(string name);
    }
}
