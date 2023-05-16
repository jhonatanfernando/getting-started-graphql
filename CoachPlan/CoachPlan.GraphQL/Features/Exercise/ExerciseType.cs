using CoachPlan.Core.Dtos;
using CoachPlan.Service.Services;

namespace CoachPlan.GraphQL.Features.Exercise;

public class ExerciseType : ObjectType<ExerciseDto>
{
   protected override void Configure(IObjectTypeDescriptor<ExerciseDto> descriptor)
    {
        descriptor.Description("Represents the exercises.");

        descriptor
            .Field(c=> c.Muscle)
            .ResolveWith<Resolvers>(p=> p.GetMuscle(default!, default!));
    }
}

public class Resolvers
{
    public async Task<MuscleDto> GetMuscle([Parent] ExerciseDto exercise, MuscleService service)
    {
        return await service.GetByServiceId(exercise.Id);
    }
}