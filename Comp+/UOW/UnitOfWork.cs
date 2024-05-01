using COMP_.Context;
using COMP_.Repository;
using COMP_.Repository.Interface;
using COMP_.UOW.Interface;

namespace COMP_.UOW
{
    public class UnitOfWork : IUnitOfWork
    {
        private IUserRepository? _userRepository;
        private PostgreeContext _context;
        public UnitOfWork(PostgreeContext context)
        {
            _context = context;
        }
        public IUserRepository UserRepository
        {
            get
            {
                return _userRepository ?? new UserRepository(_context);
            }
        }
        public async Task CommitAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
