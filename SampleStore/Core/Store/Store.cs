using System.Linq.Expressions;
using System.Reflection;

namespace SampleStore.Core.Store;

public class Store<TState> : IDisposable where TState : struct
{
    private TState _initialState;
    private TState _state;
    private readonly IReducer<TState> _reducer;
    private event EventHandler<IAction> ActionEvent;
    private event EventHandler<TState> StateChanged;
    private IEffect[] _effects;

    public Store(TState initialState, IReducer<TState> reducer, params IEffect[] effects)
    {
        _initialState = initialState;
        _state = initialState;
        _effects = effects;
        _reducer = reducer;
        ActionEvent += OnAction;
    }

    public TState InitialState => _initialState;

    public void SubscribeStateChanged(EventHandler<TState> callback)
    {
        StateChanged += callback;
    }

    public void UnsubscribeStateChanged(EventHandler<TState> callback)
    {
        StateChanged -= callback;
    }

    public void OnAction(object? sender, IAction action)
    {
        _state = _reducer.Execute(_state, action);
        OnStateChanged(_state);
        var effect = _effects.FirstOrDefault(e => e.Action == action.Type);
        var newAction = effect?.Execute(action);
        if (newAction != null) Dispatch(newAction);
    }

    public void Dispatch(IAction action)
    {
        ActionEvent.Invoke(this, action);
    }

    public TResult? Select<TResult>(Expression<Func<TState, TResult>> selector)
    {
        if (selector.Body is not MemberExpression me) return default;
        var prop = me.Member as PropertyInfo;
        var value = prop?.GetValue(this._state);
        return value != null ? (TResult) value : default;
    }

    public void Dispose()
    {
        ActionEvent -= OnAction;
    }

    protected virtual void OnStateChanged(TState e)
    {
        StateChanged?.Invoke(this, e);
    }
}