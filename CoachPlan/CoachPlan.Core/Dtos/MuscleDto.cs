namespace CoachPlan.Core.Dtos;

public class MuscleDto
{    public int Id { get; set; }
    public string Name { get; set; }
    public virtual List<ExerciseDto> Exercises { get; set; }
}