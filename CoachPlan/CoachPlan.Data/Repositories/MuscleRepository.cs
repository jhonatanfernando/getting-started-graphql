using CoachPlan.Data.Context;
using CoachPlan.Domain.Entities;
using CoachPlan.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CoachPlan.Data.Repositories;

public class MuscleRepository : IMuscleRepository, IAsyncDisposable
{
    private readonly CoachPlanContext _coachPlanContext;

    public MuscleRepository(IDbContextFactory<CoachPlanContext> dbContextFactory)
    {
        _coachPlanContext = dbContextFactory.CreateDbContext();
    }

    public async Task<Muscle> Create(Muscle muscle)
    {
        _coachPlanContext.Muscles.Add(muscle);

        await _coachPlanContext.SaveChangesAsync();

        return muscle;
    }

    public async Task<int> Delete(Muscle muscle)
    {
        _coachPlanContext.Remove(muscle);

        return await _coachPlanContext.SaveChangesAsync();
    }

    public  IEnumerable<Muscle> GetAll()
    {
        return _coachPlanContext.Muscles;
    }

    public async Task<Muscle> GetById(int id)
    {
        return await _coachPlanContext.Muscles.Include(d => d.Exercises).Where(m => m.Id == id).SingleOrDefaultAsync();
    }

    public async Task<Muscle> Update(Muscle muscle)
    {
        _coachPlanContext.Muscles.Update(muscle);
        
        await _coachPlanContext.SaveChangesAsync();

        return muscle; 
    }

    public async Task<Muscle> GetByServiceId(int serviceId)
    {
        return await _coachPlanContext
                .Muscles
                .FirstOrDefaultAsync(c=> c.Exercises.Any(e=> e.Id == serviceId));
    }

    public ValueTask DisposeAsync()
    {
        return _coachPlanContext.DisposeAsync();
    }
}
