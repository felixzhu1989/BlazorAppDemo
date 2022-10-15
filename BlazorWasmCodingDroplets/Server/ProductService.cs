using BlazorWasmCodingDroplets.Shared;

namespace BlazorWasmCodingDroplets.Server
{
    public class ProductService
    {
        //硬编码，实际项目请使用数据
        private List<Product> _products;
        public ProductService()
        {
            _products = new List<Product>()
            {
                new Product(){Code = "0001",Name = "productA",Price = 4.8m},
                new Product(){Code = "0002",Name = "productB",Price = 5.6m},
                new Product(){Code = "0003",Name = "productC",Price = 2.4m},
                new Product(){Code = "0004",Name = "productD",Price = 1.2m},
            };
        }
        public List<Product> GetProducts()
        {
            return _products;
        }
        public Product GetProduct(string productCode)
        {
            return _products.Single(x => x.Code.Equals(productCode));
        }
        public void AddProduct(Product product)
        {
            _products.Add(product);
        }
        public void DeleteProduct(string productCode)
        {
            _products.RemoveAll(x => x.Code.Equals(productCode));
        }
        public void UpdateProduct(Product product)
        {
            var oldProduct = GetProduct(product.Code);
            oldProduct.Name = product.Name;
            oldProduct.Price=product.Price;
        }
    }
}
