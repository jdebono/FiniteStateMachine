using System;
public abstract class FSMState<T, U>
{
    abstract public U StateID { get; }
    abstract public void Enter(T entity);
    abstract public void Execute(T entity);
    abstract public void Exit(T entity);
}
