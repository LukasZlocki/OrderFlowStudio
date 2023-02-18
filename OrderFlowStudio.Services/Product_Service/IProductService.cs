using System.Collections.Generic;
using OrderFlowStudio.Data.Models;

namespace OrderFlowStudio.Services.Product_Service
{
    public interface IProductService
    {
        // CREATE
        public ServiceResponse<Product> AddProduct(Product product);

        // READ
        public List<Product> GetAllProducts();
        public Product GetProductByid(int id);
        public int GetProductIdByProductNumber(string productNb);

        // U PDATE
        public ServiceResponse<bool> UpdateProduct(Product product);

        // DELETE
        public ServiceResponse<bool> DeleteProduct(int id);

    }
}