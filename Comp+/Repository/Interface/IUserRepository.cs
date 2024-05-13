using COMP_.Entities;

namespace COMP_.Repository.Interface
{
    public interface IUserRepository : IBaseRespository<User>
    {
        Task<IEnumerable<User>> GetCompostersAsync();
        Task<IEnumerable<User>> GetWannaCompostAsync();
        Task<IEnumerable<User>> GetByZIP(string zip);
    }
}
