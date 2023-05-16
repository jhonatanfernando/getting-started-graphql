namespace CoachPlan.Core.Dtos;

public class ExerciseDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public MuscleDto Muscle { get; set; }
}