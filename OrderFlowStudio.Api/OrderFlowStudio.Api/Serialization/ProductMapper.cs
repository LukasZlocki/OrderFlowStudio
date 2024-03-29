using OrderFlowStudio.Api.Dtos;
using OrderFlowStudio.Models.Models;

namespace OrderFlowStudio.Api.Serialization
{
    public static class ProductMapper
    {
        public static ProductReadDto SerializeProductToProductReadDto (Product product)
        {
            return new ProductReadDto
            {
                Id = product.Id,
                PartNumber = product.PartNumber,
                ProductDescription = product.ProductDescription,
            };
        }

        public static Product SerializeProductReadDtoToProduct(ProductReadDto productDto)
        {
            return new Product
            {
                Id = productDto.Id,
                PartNumber = productDto.PartNumber,
                ProductDescription = productDto.ProductDescription
            };
        }

        public static Product SerializeProductCreateDtoToProduct(ProductCreateDto product)
        {
            return new Product
            {
                PartNumber = product.PartNumber,
                ProductDescription = product.ProductDescription
                
            };
        }

        public static List<ProductReadDto> SerializeProductListToProductReadDtoList(IEnumerable<Product> products)
        {
            return products.Select(product => new ProductReadDto
            {
                Id = product.Id, 
                PartNumber = product.PartNumber,
                ProductDescription = product.ProductDescription
            }).ToList();
        }
    }
}