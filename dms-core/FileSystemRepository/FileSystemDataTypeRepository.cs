using System;
using System.Collections.Generic;
using System.IO;
using System.Linq.Expressions;
using Dms.Core.Repository;
using Manatee.Json;
using Manatee.Json.Schema;

namespace Dms.Core.FileSystemRepository
{
    public class FileSystemDataTypeRepository<TEntity> : IFileSystemRepository<TEntity> where TEntity : DataType
    {
        public string BaseDir { get; set; } = "store";

        public void Add(TEntity entity)
        {
            var dirInfo = Directory.CreateDirectory($"{BaseDir}/{entity.GetType().Name}");
            var stream = File.CreateText($"{dirInfo.FullName}/{entity.GetType().Name}.json");
            stream.Write(DataType._serializer.Serialize(entity.Schema));
            stream.Close();
        }

        public void AddRange(IEnumerable<TEntity> entities)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public TEntity Get(string id)
        {
            var jsonText = File.ReadAllText($"{BaseDir}/{id}/{id}.json");
            var retObj = new DataType(jsonText);
            return retObj as TEntity;
        }

        public IEnumerable<TEntity> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Remove(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            throw new NotImplementedException();
        }

        public TEntity SingleOrDefault(Expression<Func<TEntity, bool>> predicate)
        {
            throw new NotImplementedException();
        }
    }
}