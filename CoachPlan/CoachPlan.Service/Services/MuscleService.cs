using CoachPlan.Domain.Services;
using CoachPlan.Core.Dtos;
using CoachPlan.Domain.Repositories;
using CoachPlan.Domain.Extensions;

namespace CoachPlan.Service.Services;

public class MuscleService : IMuscleService<MuscleDto>
{
    private readonly IMuscleRepository _muscleRepository;

    public MuscleService(IMuscleRepository muscleRepository)
    {
        _muscleRepository = muscleRepository;
    }   

    public async Task<MuscleDto> Create(MuscleDto muscleDto)
    {
        return (await _muscleRepository.Create(muscleDto.ToModel())).ToDto();
    }

    public async Task<int> Delete(MuscleDto muscleDto)
    {
        return await _muscleRepository.Delete(muscleDto.ToModel());
    }

    public IEnumerable<MuscleDto> GetAll()
    {
        return _muscleRepository.GetAll().ToDto();
    }

    public async Task<MuscleDto> GetById(int id)
    {
        var muscle = await _muscleRepository.GetById(id);

        return muscle.ToDto();
    }

    public async Task<MuscleDto> Update(MuscleDto muscleDto)
    {
        return (await _muscleRepository.Update(muscleDto.ToModel())).ToDto();
    }

    public async Task<MuscleDto> GetByServiceId(int serviceId)
    {
        return (await _muscleRepository.GetByServiceId(serviceId)).ToDto();
    }
}
