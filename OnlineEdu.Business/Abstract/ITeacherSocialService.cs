using OnlineEdu.Dto.Dtos.TeacherSocialDtos;

namespace OnlineEdu.Business.Abstract
{
    public interface ITeacherSocialService
    {
        Task<List<ResultTeacherSocialDto>> GetTeacherSocialList();
        Task<List<GetTeacherSocialsWithSocialMediasDto>> GetTeacherSocialsByTeacherId(int id);
        Task<GetTeacherSocialByIdDto> GetTeacherSocialById(int id);
        Task CreateTeacherSocial(CreateTeacherSocialDto dto);
        Task UpdateTeacherSocial(UpdateTeacherSocialDto dto);
        Task DeleteTeacherSocial(int id);
    }
}
