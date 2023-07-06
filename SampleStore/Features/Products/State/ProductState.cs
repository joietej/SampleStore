using SampleStore.Features.Products.Models;

namespace SampleStore.Features.Products.State;

public readonly record struct ProductState(Product[] Products, bool Loading, string Error);
