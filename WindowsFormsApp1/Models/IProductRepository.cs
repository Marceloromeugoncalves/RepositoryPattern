using System.Collections.Generic;

namespace WindowsFormsApp1.Models
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetProducts();
        bool Insert(Product product);
        bool Update(Product product);
        bool Delete(string productId);
    }
}
