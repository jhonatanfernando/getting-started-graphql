namespace CoachPlan.Domain.Services;

public interface IExerciseService<T>
{
    IEnumerable<T> GetAll();
    Task<T> GetById(int id);
    Task<T> Create(T exerciseDto);
    Task<T> Update(T exerciseDto);
    Task<int> Delete(T exerciseDto);
    Task<IEnumerable<T>> GetByMuscleId(int muscleId);
}