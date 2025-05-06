public interface IState
{
    void Enter();
    void Tick(); // 相当于Update
    void Exit();
}
