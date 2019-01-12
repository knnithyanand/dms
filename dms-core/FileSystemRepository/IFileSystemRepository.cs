using Dms.Core.Repository;

namespace Dms.Core.FileSystemRepository
{
    public interface IFileSystemRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        string BaseDir { get; set; }
    }
}