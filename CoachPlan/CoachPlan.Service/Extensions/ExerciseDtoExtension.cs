using CoachPlan.Core.Dtos;
using CoachPlan.Domain.Entities;

namespace CoachPlan.Domain.Extensions;

public static class ExerciseDtoExtension
{
    public static Exercise ToModel(this ExerciseDto exerciseDto)
    {
        return exerciseDto == null ? null : new()
        {
            Id = exerciseDto.Id,
            Name = exerciseDto.Name,
            MuscleId = exerciseDto.Muscle == null ? 0 : exerciseDto.Muscle.Id
        };
    }

    public static ExerciseDto ToDto(this Exercise exercise)
    {
        return exercise == null ? null : new()
        {
            Id = exercise.Id,
            Name = exercise.Name,
            Muscle = exercise.Muscle.ToDto()
        };
    }

    public static IEnumerable<ExerciseDto> ToDto(this IEnumerable<Exercise> exercises)
    {
        return exercises.Select(m => m.ToDto());
    }

    public static IEnumerable<Exercise> ToModel(this IEnumerable<ExerciseDto> exerciseDtos)
    {
        return exerciseDtos.Select(m => m.ToModel());
    }
}
