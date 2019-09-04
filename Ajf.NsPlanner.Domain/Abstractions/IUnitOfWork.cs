namespace Ajf.NsPlanner.Domain.Abstractions
{
    public interface IUnitOfWork
    {
        int SaveChanges();
    }
}