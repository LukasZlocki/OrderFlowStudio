using OrderFlowStudio.Models;
using OrderFlowStudio.Models.Models;

namespace OrderFlowStudio.Services.Product_Service
{
    public class ProductService : IProductService
    {
        private readonly OrderDbContext _db;

        public ProductService(OrderDbContext db)
        {
            _db = db;
        }

        // CREATE
        /// <summary>
        /// Add product object to data base
        /// </summary>
        /// <param name="product"></param>
        /// <returns><ServiceResponse<Product></returns>
        public ServiceResponse<Product> AddProduct(Product product)
        {
            try
            {
                _db.Products.Add(product);
                _db.SaveChanges();
                return new ServiceResponse<Product>
                {
                    IsSucess = true,
                    Message = "Product added.",
                    Time = DateTime.UtcNow,
                    Data = product
                };
            }
            catch(Exception e)
            {
                 return new ServiceResponse<Product>
                {
                    IsSucess = false,
                    Message = e.StackTrace,
                    Time = DateTime.UtcNow,
                    Data = product
                };
            }
        }

        // READ
        /// <summary>
        /// Read products list from database
        /// </summary>
        /// <returns><List<Product></returns>
        public List<Product> GetAllProducts()
        {
            var service = _db.Products.ToList();
            return service;
        }

        // READ
        public Product GetProductByid(int id)
        {
            var service = _db.Products.Find(id);
            return service;
        }

        // READ
        public int GetProductIdByProductNumber(string productNb)
        {
            var service = _db.Products.Where(nb => nb.PartNumber == productNb).FirstOrDefault();
            int productId = service.Id;
            return productId;
        }

        // UPDATE
        /// <summary>
        /// Update product list by product object
        /// </summary>
        /// <param name="product"></param>
        /// <returns><serviceResponse<bool></returns>
        public ServiceResponse<bool> UpdateProduct(Product product)
        {
            try
            {
                _db.Products.Update(product);
                _db.SaveChanges();
                return new ServiceResponse<bool>
                {
                    IsSucess = true,
                    Message = "Product added.",
                    Time = DateTime.UtcNow,
                    Data = true
                };
            }
            catch(Exception e)
            {
                return new ServiceResponse<bool>
                {
                    IsSucess = false,
                    Message = e.StackTrace,
                    Time = DateTime.UtcNow,
                    Data = false
                };
            }
        }

        // DELETE
        /// <summary>
        /// Delete product object by primary key
        /// </summary>
        /// <param name="id"></param>
        /// <returns><ServiceResponse<bool></returns>
        public ServiceResponse<bool> DeleteProduct(int id)
        {
            var product = _db.Products.Find(id);
            if (product == null)
            {
                 return new ServiceResponse<bool>
                {
                    IsSucess = false,
                    Message = "No product found.",
                    Time = DateTime.UtcNow,
                    Data = false
                };
            }

            try
            {
                _db.Products.Remove(product);
                _db.SaveChanges();
                return new ServiceResponse<bool>
                {
                    IsSucess = false,
                    Message = "Product removed",
                    Time = DateTime.UtcNow,
                    Data = false
                };

            }
            catch(Exception e)
            {
                return new ServiceResponse<bool>
                {
                    IsSucess = false,
                    Message = e.StackTrace,
                    Time = DateTime.UtcNow,
                    Data = false
                };
            }
        }
    }
}