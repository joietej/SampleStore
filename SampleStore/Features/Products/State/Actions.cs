using SampleStore.Core.Store;
using SampleStore.Features.Products.Models;

namespace SampleStore.Features.Products.State;

public static class ProductActionType
{
    public const string ProductsLoad = nameof(ProductsLoad);
    public const string ProductsLoadedSuccess = nameof(ProductsLoadedSuccess);
    public const string ProductsLoadedError = nameof(ProductsLoadedError);
}

public readonly record struct LoadProducts : IAction
{
    public string Type => ProductActionType.ProductsLoad;
}

public readonly record struct LoadProductsSuccess(Product[] Products) : IAction
{
    public string Type => ProductActionType.ProductsLoadedSuccess;
}

public readonly record struct LoadProductsError(string Error) : IAction
{
    public string Type => ProductActionType.ProductsLoadedError;
}