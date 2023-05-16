using CoachPlan.Domain.Entities;

namespace CoachPlan.Domain.Repositories;

public interface IExerciseRepository
{
    IEnumerable<Exercise> GetAll();
    Task<Exercise> GetById(int id);
    Task<Exercise> Create(Exercise exercise);
    Task<Exercise> Update(Exercise exercise);
    Task<int> Delete(Exercise exercise);
    Task<List<Exercise>> GetByMuscleId(int muscleId);
}
