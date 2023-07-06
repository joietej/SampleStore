using SampleStore.Core.Store;

namespace SampleStore.Core;

public abstract class StatefulView<TState> where TState: struct
{
    private readonly Store<TState> _store;

    public StatefulView(Store<TState> store)
    {
        _store = store;
        store.SubscribeStateChanged((_, state) =>
        {
            Init(state);
        });
        Init(store.InitialState);
    }

    private void Init(TState state)
    {
        SelectFromState(state);
        Render();
    }

    protected void Disptach(IAction action)
    {
        _store.Dispatch(action);
    }
    protected abstract void SelectFromState(TState state);
    protected abstract void Render();

}