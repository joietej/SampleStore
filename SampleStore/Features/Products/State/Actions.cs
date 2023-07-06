using SampleStore.Core.Store;
using SampleStore.Features.Products.Models;

namespace SampleStore.Features.Products.State;

public static class ProductActionType
{
    public const string PRODUCTS_LOAD = nameof(PRODUCTS_LOAD);
    public const string PRODUCTS_LOADED_SUCCESS = nameof(PRODUCTS_LOADED_SUCCESS);
    public const string PRODUCTS_LOADED_ERROR = nameof(PRODUCTS_LOADED_ERROR);
}

public readonly record struct LoadProducts() : IAction
{
    public string Type => ProductActionType.PRODUCTS_LOAD;
}
public readonly record struct LoadProductsSuccess( Product[] Products) : IAction
{
    public string Type => ProductActionType.PRODUCTS_LOADED_SUCCESS;
}
public readonly record struct LoadProductsError( string Error) : IAction
{
    public string Type => ProductActionType.PRODUCTS_LOADED_ERROR;
}