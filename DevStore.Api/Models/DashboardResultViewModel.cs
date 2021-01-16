using DevStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DevStore.Api.Models
{
    public class DashboardResultViewModel
    {
        public string User{ get; set; }
        public List<Product> Products { get; set; }
        public List<Product> ProductsUserLiked { get; set; }

    }
}