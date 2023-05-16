using CoachPlan.Domain.Services;
using CoachPlan.Core.Dtos;
using CoachPlan.Domain.Repositories;
using CoachPlan.Domain.Extensions;

namespace CoachPlan.Service.Services;

public class ExerciseService : IExerciseService<ExerciseDto>
{
    private readonly IExerciseRepository _exerciseRepository;

    public ExerciseService(IExerciseRepository exerciseRepository)
    {
        _exerciseRepository = exerciseRepository;
    }
    public async Task<ExerciseDto> Create(ExerciseDto exerciseDto)
    {
        return (await _exerciseRepository.Create(exerciseDto.ToModel())).ToDto();
    }

    public async Task<int> Delete(ExerciseDto exerciseDto)
    {
        return await _exerciseRepository.Delete(exerciseDto.ToModel());
    }

    public IEnumerable<ExerciseDto> GetAll()
    {
        return _exerciseRepository.GetAll().ToDto();
    }

    public async Task<ExerciseDto> GetById(int id)
    {
        return (await _exerciseRepository.GetById(id)).ToDto();
    }

    public async Task<ExerciseDto> Update(ExerciseDto exerciseDto)
    {
        return (await _exerciseRepository.Update(exerciseDto.ToModel())).ToDto();
    }

    public async Task<IEnumerable<ExerciseDto>> GetByMuscleId(int muscleId)
    {
        return (await _exerciseRepository.GetByMuscleId(muscleId)).ToDto();
    }
}
