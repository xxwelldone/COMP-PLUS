using COMP_.Repository.Interface;

namespace COMP_.UOW.Interface
{
    public interface IUnitOfWork
    {
        IUserRepository UserRepository { get; }
        Task CommitAsync();
        void Dispose();

    }
}
