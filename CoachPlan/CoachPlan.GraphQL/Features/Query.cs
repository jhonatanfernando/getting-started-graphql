using CoachPlan.Core.Dtos;
using CoachPlan.Service.Services;

namespace CoachPlan.GraphQL.Features;

public class Query
{
    [UseFiltering]
    [UseSorting]
    public IEnumerable<MuscleDto> GetMuscles(MuscleService service)
    {
        return service.GetAll();
    }
    
    [UseFiltering]
    [UseSorting]
    public IEnumerable<ExerciseDto> GetExercises(ExerciseService service)
    {
        return service.GetAll();
    }
}