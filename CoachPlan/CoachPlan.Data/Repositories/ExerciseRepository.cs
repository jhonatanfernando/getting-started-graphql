using CoachPlan.Data.Context;
using CoachPlan.Domain.Entities;
using CoachPlan.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CoachPlan.Data.Repositories;

public class ExerciseRepository : IExerciseRepository, IAsyncDisposable
{
    private readonly CoachPlanContext _coachPlanContext;

    public ExerciseRepository(IDbContextFactory<CoachPlanContext> dbContextFactory)
    {
        _coachPlanContext = dbContextFactory.CreateDbContext();;
    }

    public async Task<Exercise> Create(Exercise exercise)
    {
        _coachPlanContext.Exercises.Add(exercise);

        await _coachPlanContext.SaveChangesAsync();

        return exercise;         
    }

    public async Task<int> Delete(Exercise exercise)
    {
        _coachPlanContext.Remove(exercise);

        return await _coachPlanContext.SaveChangesAsync();
    }

    public IEnumerable<Exercise> GetAll()
    {
        return _coachPlanContext.Exercises;
    }

    public async Task<Exercise> GetById(int id)
    {
        return await _coachPlanContext.Exercises.Where(m => m.Id == id).SingleOrDefaultAsync();
    }

    public async Task<Exercise> Update(Exercise exercise)
    {
        _coachPlanContext.Exercises.Update(exercise);

        await _coachPlanContext.SaveChangesAsync();

        return exercise;
    }

    public ValueTask DisposeAsync()
    {
        return _coachPlanContext.DisposeAsync();
    }

    public async Task<List<Exercise>> GetByMuscleId(int muscleId)
    {
        return await _coachPlanContext
                .Exercises
                .Where(c=> c.MuscleId == muscleId)
                .ToListAsync();
    }
}
