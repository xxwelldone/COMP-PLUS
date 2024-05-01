using System.Linq.Expressions;
using COMP_.Context;
using COMP_.Entities;
using COMP_.Entities.Enum;
using COMP_.Repository.Interface;

namespace COMP_.Repository
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(PostgreeContext context) : base(context)
        {
        }

        public async Task<IEnumerable<User>> GetComposters()
        {
            var Composters = await GetAllAsync();
            var filtered = Composters.Where(x => x.Profile == Enum.Parse<Profile>("Composter")).ToList();
            return filtered;
        }

        public async Task<IEnumerable<User>> GetWannaCompost()
        {
            var WannaCompost = await GetAllAsync();
            var filtered = WannaCompost.Where(x => x.Profile == Enum.Parse<Profile>("WannaCompost")).ToList();
            return filtered;

        }
    }
}
