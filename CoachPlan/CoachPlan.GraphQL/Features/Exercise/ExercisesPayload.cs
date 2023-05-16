using CoachPlan.Core.Dtos;

namespace CoachPlan.GraphQL.Features.Exercise;

public record ExercisesPayload(IEnumerable<ExerciseDto> exercises);