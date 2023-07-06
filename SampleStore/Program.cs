// See https://aka.ms/new-console-template for more information

using SampleStore.Core.Store;
using SampleStore.Features.Products.Models;
using SampleStore.Features.Products.State;
using SampleStore.Features.Products.Views;

var initialState = new ProductState(Array.Empty<Product>(), false, string.Empty);
using var store = new Store<ProductState>(initialState,
    new ProductReducer(),
    new LoadProductsEffect(),
    new LoadProductsSuccessEffect());

var view = new ProductList(store);

Console.ReadLine();