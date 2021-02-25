using System.Collections.Generic;
using OrderFlowStudio.Data.Models;

namespace OrderFlowStudio.Services.Product_Service
{
    public interface IProductService
    {
         // GET
         public List<Product> GetAllProducts();
         public Product GetProductByid(int id);

         // CREATE
         public ServiceResponse<Product> AddProduct(Product product);

         // DELETE
         public ServiceResponse<Product> DeleteProduct(Product product);

    }
}