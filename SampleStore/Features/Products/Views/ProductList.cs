using SampleStore.Core;
using SampleStore.Core.Store;
using SampleStore.Features.Products.Models;
using SampleStore.Features.Products.State;

namespace SampleStore.Features.Products.Views;

public class ProductList: StatefulView<ProductState>
{
   
    private Product[] _products;
    private bool _isLoading;

    public ProductList(Store<ProductState> store): base(store)
    {
        Disptach(new LoadProducts());
    }
    

    protected override void SelectFromState(ProductState state)
    {
        _products = state.Products;
        _isLoading = state.Loading;
    }

    protected override void Render()
    {
        Console.WriteLine("Products List");
        
        if (_isLoading)
        {
            Console.WriteLine("Loading...");
            return;
        }

        if (_products.Length == 0)
        {
            Console.WriteLine("No Products");
        }
        else
        {
            foreach (var product in _products)
            {
                Console.WriteLine($"{product.Name}: {product.Price} ");
            }
        }
    }
}