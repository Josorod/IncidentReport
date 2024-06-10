namespace IncidentReport.Interfaces
{
    public interface IUnitOfWork
    {
        IAccountRepository AccountRepository { get; }
        IContactRepository ContactRepository { get; }
        IIncidentRepository IncidentRepository { get; }
        Task<bool> SaveAsync();

    }
}
