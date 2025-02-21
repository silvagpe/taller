using Microsoft.AspNetCore.Mvc;
using Moq;
using WebApplication1.Features.Controller;
using WebApplication1.Features.Model;
using WebApplication1.Features.Repository;

namespace TestProject1;

public class UnitTest1
{
    [Fact]
    public async Task UpdateProductWithOkResultTest()
    {
        var repository = new Mock<IProductRepository>();
        repository.Setup(x => x.UpdateProduct(It.IsAny<int>(), It.IsAny<Product>())).Returns(true);            

        ProductsController productsController = new ProductsController(repository.Object);

        var result = await productsController.UpdateProduct(1, new Product() { Id = 1, Name = "Product 1 - update", Price = 200, Desciption = "Description 1 update" });

        Assert.True(result is OkObjectResult);
    }

     [Fact]
    public async Task UpdateProductWithNoContentTest()
    {
        var repository = new Mock<IProductRepository>();
        repository.Setup(x => x.UpdateProduct(It.IsAny<int>(), It.IsAny<Product>())).Returns(false);  

        ProductsController productsController = new ProductsController(repository.Object);

        var result = await productsController.UpdateProduct(2, new Product() { Id = 1, Name = "Product 1 - update", Price = 200, Desciption = "Description 1 update" });

        Assert.True(result is NoContentResult);    
    }

        [Fact]
    public async Task DeleteProductWithOkResultTest()
    {
        var repository = new Mock<IProductRepository>();
        repository.Setup(x => x.DeleteProduct(It.IsAny<int>())).Returns(true);            

        ProductsController productsController = new ProductsController(repository.Object);

        var result = await productsController.DeleteProduct(1);

        Assert.True(result is OkObjectResult);
    }

     [Fact]
    public async Task DeleteProductWithNoContentTest()
    {
        var repository = new Mock<IProductRepository>();
        repository.Setup(x => x.DeleteProduct(It.IsAny<int>())).Returns(false);  

        ProductsController productsController = new ProductsController(repository.Object);

        var result = await productsController.DeleteProduct(2);

        Assert.True(result is NoContentResult);    
    }
}