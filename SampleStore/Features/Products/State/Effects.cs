using SampleStore.Core.Store;
using SampleStore.Features.Products.Services;

namespace SampleStore.Features.Products.State;

public class LoadProductsEffect: IEffect
{
    public string Action => ProductActionType.PRODUCTS_LOAD;
    public IAction? Execute(IAction action)
    {
        try
        {
            if (action is not LoadProducts act) return null;
            var products = new ProductService().GetAll();
            return new LoadProductsSuccess(products.ToArray());
        }
        catch (Exception e)
        {
            return new LoadProductsError(e.Message);
        }
    }
}

public class LoadProductsSuccessEffect : IEffect
{
    public string Action => ProductActionType.PRODUCTS_LOADED_SUCCESS;
    public IAction? Execute(IAction action)
    {
        if (action is not LoadProductsSuccess act) return null;
        var products = act.Products;
        Console.WriteLine($"Fetched {products.Length} products");
        return null;
    }
}