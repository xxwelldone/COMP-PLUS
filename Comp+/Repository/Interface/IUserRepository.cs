using COMP_.Entities;

namespace COMP_.Repository.Interface
{
    public interface IUserRepository : IBaseRespository<User>
    {
        Task<IEnumerable<User>> GetComposters();
        Task<IEnumerable<User>> GetWannaCompost();
    }
}
