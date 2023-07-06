using SampleStore.Core.Store;

namespace SampleStore.Features.Products.State;

public class ProductReducer: IReducer<ProductState>
{
    public ProductState Execute(ProductState state, IAction action)
    {
        return action switch
        {
            LoadProducts => state with {Loading = true},
            LoadProductsSuccess act => state with {Loading = false, Products = act.Products},
            LoadProductsError act => state with {Loading = false, Error = act.Error},
            _ => state
        };
    }
}