namespace CoachPlan.Domain.Services;

public interface IMuscleService<T>
{
    IEnumerable<T> GetAll();
    Task<T> GetById(int id);
    Task<T> Create(T exerciseDto);
    Task<T> Update(T exerciseDto);
    Task<int> Delete(T exerciseDto);
    Task<T> GetByServiceId(int serviceId);
}