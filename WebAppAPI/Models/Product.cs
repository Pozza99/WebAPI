using System;
using System.Collections.Generic;
using System.Text;

namespace WebAppAPI.Models
{
    public class Product //public altrimenti non la vedo fuori 
    {
        public int Id { get; set; }

        public string Code { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public decimal? Price { get; set; }
    }
}
