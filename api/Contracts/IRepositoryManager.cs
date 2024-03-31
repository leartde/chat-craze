namespace api.Contracts
{
    public interface IRepositoryManager
    {
        IPostRepository Post { get; }
        IUserRepository User { get; }
        void Save();
    }
}
