using CoachPlan.Core.Dtos;
using CoachPlan.Domain.Entities;

namespace CoachPlan.Domain.Extensions;

public static class MuscleDtoExtension
{
    public static Muscle ToModel(this MuscleDto muscleDto)
    {
        return muscleDto == null ? null : new()
        {
             Id= muscleDto.Id,
             Name= muscleDto.Name
        };
    }

    public static MuscleDto ToDto(this Muscle muscle)
    {
        return muscle == null ?  null : new()
        {
            Id = muscle.Id,
            Name = muscle.Name,
            Exercises = muscle.Exercises?.Select(c => new ExerciseDto() {
               Id = c.Id,
               Name = c.Name   
            }).ToList()
        };
    }

    public static IEnumerable<MuscleDto> ToDto(this IEnumerable<Muscle> muscles)
    {
        return muscles.Select(m => m.ToDto());
    }

    public static IEnumerable<Muscle> ToModel(this IEnumerable<MuscleDto> muscleDtos)
    {
        return muscleDtos.Select(m => m.ToModel());
    }
}
