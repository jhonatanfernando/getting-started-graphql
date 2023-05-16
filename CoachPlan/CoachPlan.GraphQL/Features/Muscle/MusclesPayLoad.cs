using CoachPlan.Core.Dtos;

namespace CoachPlan.GraphQL.Features.Muscle;

public record MusclesPayload(IEnumerable<MuscleDto> muscle);