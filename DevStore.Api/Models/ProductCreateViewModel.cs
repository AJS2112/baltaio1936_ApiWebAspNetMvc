using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DevStore.Api.Models
{
    public class ProductCreateViewModel
    {
        [Required]
        public string Name { get; set; }
    }
}