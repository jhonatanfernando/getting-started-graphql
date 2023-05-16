using CoachPlan.Core.Dtos;
using CoachPlan.Service.Services;

namespace CoachPlan.GraphQL.Features.Muscle;

public class MuscleType : ObjectType<MuscleDto>
{
   protected override void Configure(IObjectTypeDescriptor<MuscleDto> descriptor)
    {
        descriptor.Description("Represents the muscles of the body.");

        descriptor
            .Field(c=> c.Id)
            .Description("Represents the Id of the entry in the table");

        descriptor
            .Field(c=> c.Name)
            .Description("Represents the name of the muscle");    


        descriptor
            .Field(c=> c.Exercises)
            .Description("Represents the exercises for the muscle")
            .ResolveWith<Resolvers>(p=> p.GetExercises(default!, default!));
    }
}

public class Resolvers
{
    public async Task<IEnumerable<ExerciseDto>> GetExercises([Parent] MuscleDto muscle, ExerciseService service)
    {
        return await service.GetByMuscleId(muscle.Id);
    }
}