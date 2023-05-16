using CoachPlan.Core.Dtos;
using CoachPlan.GraphQL.Features.Muscle;
using CoachPlan.Service.Services;

namespace CoachPlan.GraphQL.Features;
public partial class Mutation
{
    public async Task<MusclePayload> AddMuscle(AddMuscleInput input, MuscleService service)
    {
        var muscle = new MuscleDto
        {
            Name = input.Name
        };

        var savedMuscle = await service.Create(muscle);

        return new MusclePayload(savedMuscle);
    }

    public async Task<MusclePayload> UpdateMuscle(UpdateMuscleInput input, MuscleService service)
    {
        var muscle = new MuscleDto
        {
            Id = input.Id,
            Name = input.Name            
        };

        var updateMuscle = await service.Update(muscle);

        return new MusclePayload(updateMuscle);
    }

    public async Task<MusclesPayload> DeleteMuscle(DeleteMuscleInput input, MuscleService service)
    {
        var muscle = new MuscleDto
        {
            Id = input.Id          
        };

        await service.Delete(muscle);

        var muscles = service.GetAll();

        return new MusclesPayload(muscles);
    }
}