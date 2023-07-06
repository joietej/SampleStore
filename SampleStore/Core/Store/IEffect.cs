namespace SampleStore.Core.Store;

public interface IEffect
{
    string Action { get; }
    IAction? Execute(IAction action);
}