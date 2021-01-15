using DevStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevStore.Data.Contexts
{
    public class AppDataContext:DbContext
    {
        public AppDataContext() : base("AppCnnStr")
        {}

        public DbSet<Product> Products { get; set; }
    }
}
