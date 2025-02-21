using Microsoft.AspNetCore.Mvc;
using WebApplication1.Features.Model;
using WebApplication1.Features.Repository;

namespace WebApplication1.Features.Controller;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    private readonly IProductRepository _productRepository;

    public ProductsController(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    [HttpGet]
    public async Task<IActionResult> GetProducts()
    {
        try
        {
            return Ok(_productRepository.GetProducts());
        }
        catch (System.Exception)
        {
            return base.Problem($"{nameof(ProductsController)}: An error occurred while GET products request", statusCode: 500);            
        }

    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetProducts(int id)
    {
        try
        {
            var result = _productRepository.GetProducts(id);
            if (result is null){
                return NotFound();
            }
            return Ok(_productRepository.GetProducts(id));
        }
        catch (System.Exception)
        {
            return base.Problem($"{nameof(ProductsController)}: An error occurred while GET product by id request", statusCode: 500);            
        }
    }

    [HttpPost]
    public async Task<IActionResult> PostProduct([FromBody] Product product)
    {
        try
        {            
            _productRepository.AddProduct(product);
            return NoContent();
        }
        catch (System.Exception)
        {
            return base.Problem($"{nameof(ProductsController)}: An error occurred while POST request", statusCode: 500);            
        }
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateProduct([FromRoute] int id, [FromBody] Product product)
    {
        try
        {                        
            var result = _productRepository.UpdateProduct(id, product);
            if (!result){
                return NoContent();
            }
            return Ok(true);
        }
        catch (System.Exception)
        {
            return base.Problem($"{nameof(ProductsController)}: An error occurred while PUT request", statusCode: 500);            
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteProduct(int id)
    {
        try
        {  
            var result = _productRepository.DeleteProduct(id);
            if (!result){
                return NoContent();
            }
            return Ok(true);
        }
        catch (System.Exception)
        {
            return base.Problem($"{nameof(ProductsController)}: An error occurred while DELETE request", statusCode: 500);            
        }
    }
}