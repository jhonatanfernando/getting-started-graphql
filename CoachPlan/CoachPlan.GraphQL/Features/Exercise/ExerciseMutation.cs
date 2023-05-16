using CoachPlan.Core.Dtos;
using CoachPlan.GraphQL.Features.Exercise;
using CoachPlan.Service.Services;

namespace CoachPlan.GraphQL.Features;

public partial class Mutation
{
    public async Task<ExercisePayload> AddExercise(AddExerciseInput input, ExerciseService service)
    {
        var exercise = new ExerciseDto
        {
            Name = input.Name,
            Muscle = new MuscleDto
            {
                Id = input.MuscleId
            }
        };

        var savedExercise = await service.Create(exercise);

        return new ExercisePayload(savedExercise);
    }

    public async Task<ExercisePayload> UpdateExercise(UpdateExerciseInput input, ExerciseService service)
    {
        var exercise = new ExerciseDto
        {
            Id = input.Id,
            Name = input.Name,
            Muscle = new MuscleDto
            {
                Id = input.MuscleId
            }            
        };

        var updatedExercise = await service.Update(exercise);

        return new ExercisePayload(updatedExercise);
    }

    public async Task<ExercisesPayload> DeleteExercise(DeleteExerciseInput input, ExerciseService service)
    {
        var exercise = new ExerciseDto
        {
            Id = input.Id          
        };

        await service.Delete(exercise);

        var exercises = service.GetAll();

        return new ExercisesPayload(exercises);
    }
}