namespace HealthyApp.Domain.Interfaces
{
	public interface IGenericRepository<T> where T : class
	{
		Task<T> GetById(int id, CancellationToken cancellationToken);
	}
}