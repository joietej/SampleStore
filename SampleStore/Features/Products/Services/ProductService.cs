using SampleStore.Features.Products.Models;

namespace SampleStore.Features.Products.Services;

public class ProductService
{
    public IEnumerable<Product> GetAll()
    {
        return new Product[]
        {
            new(1, "Sony A7 MK3", 1500F, "Camera"),
            new(1, "Sony A1 MK1", 3000F, "Camera"),
            new(1, "Sony A6000", 999.99F, "Camera")
        };
    }
}