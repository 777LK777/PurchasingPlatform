namespace EventManagement
{
    public interface IEventPublisher
    {
         Task PublishAsync<T>(T @event);
    }
}