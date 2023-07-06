namespace SampleStore.Core.Store;

public interface IReducer<TState>
{
    public TState Execute(TState state, IAction action);
}