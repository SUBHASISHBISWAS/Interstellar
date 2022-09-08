namespace Cards.API.HostedService
{
    public interface IWorker
    {
        Task DoWork(CancellationToken cancellationToken);
    }
}
