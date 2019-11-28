using System;
using System.Collections.Generic;
using System.Text;
using WebAppAPI.Models;

namespace WebAppAPI
{
    public interface IProductsRepository
    {
        IEnumerable<Product> Get();
        Product GetById(int id);

        void Insert(Product product);

        void Update(Product product);

        void Delete(int id);
    }
}
