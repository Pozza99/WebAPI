using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models
{
    public class ProductModel
    {
        public ProductModel()
        {

        }

        public ProductModel(int id, string code, string name)
        {
            Id = id;
            Code = code;
            Name = name;
        }

        public int Id { get; set; }
        [Required]
        [StringLength(5, MinimumLength = 3)]
        public  string Code { get; set; }
        [Required]
        [StringLength(50)]
        public string  Name { get; set; }

    }
}
