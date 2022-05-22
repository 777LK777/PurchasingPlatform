namespace EventManagement.DI.Configurators;

public interface IServiceCollectionConfigurator
{
    void AddEventPublisher();
    IServiceCollectionConfigurator AddEventConsumer<TEventHandler, TEventArgs>()
        where TEventHandler : EventHandler; 
}