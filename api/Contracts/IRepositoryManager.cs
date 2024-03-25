namespace api.Contracts
{
    public interface IRepositoryManager
    {
        IPostRepository Post { get; }
        void Save();
    }
}
