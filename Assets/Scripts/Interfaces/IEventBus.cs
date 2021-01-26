public interface IEventBus : IGlobalSubscriber
{
    void Call();
}