using WebApplication1.Features.Model;

namespace WebApplication1.Features.Repository;

public interface IProductRepository
{
    void AddProduct(Product product);
    bool DeleteProduct(int id);
    IList<Product> GetProducts();
    Product? GetProducts(int id);
    bool UpdateProduct(int id, Product product);
}

public class ProductRepository : IProductRepository
{
    private readonly List<Product> _products = new List<Product>
    {        
    };

    public IList<Product> GetProducts()
    {
        return _products;
    }

    public Product? GetProducts(int id)
    {
        return _products.FirstOrDefault(x => x.Id == id);
    }

    public void AddProduct(Product product)
    {
        _products.Add(product);
    }

    public bool DeleteProduct(int id)
    {
        var product = _products.FirstOrDefault(x => x.Id == id);
        if (product == null)
        {
            return false;
        }
        _products.Remove(product);
        return true;
    }

    public bool UpdateProduct(int id, Product product)
    {
        var productToUpdate = _products.FirstOrDefault(x => x.Id == id);
        if (productToUpdate == null)
        {
            return false;
        }

        productToUpdate.Name = product.Name;
        productToUpdate.Price = product.Price;
        productToUpdate.Desciption = product.Desciption;

        return true;
    }
}