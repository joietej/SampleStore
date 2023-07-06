namespace SampleStore.Core.Store;

public interface IAction
{
    public string Type { get; }
}