using CoachPlan.Domain.Entities;

namespace CoachPlan.Domain.Repositories;

public interface IMuscleRepository
{
    IEnumerable<Muscle> GetAll();
    Task<Muscle> GetById(int id);
    Task<Muscle> Create(Muscle muscle);
    Task<Muscle> Update(Muscle muscle);
    Task<int> Delete(Muscle muscle);
    Task<Muscle> GetByServiceId(int serviceId);
}
