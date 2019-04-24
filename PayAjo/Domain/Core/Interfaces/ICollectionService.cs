using PayAjo.Domain.Core.Models;
using PayAjo.Domain.Infrastucture;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PayAjo.Domain.Core.Interfaces
{
    public interface ICollectionService
    {
        Operation<Pagination<CollectionModel>> GetCollections(string search, int pageIndex, int pageSize = 100);
        Operation<CollectionModel[]> GetCollections();
        Operation<CollectionModel> GetCollection(long id);
        Operation<CollectionModel> AddOrUpdateCollection(CollectionModel model);
        Operation DeleteCollection(long id);
        Operation<CollectionModel[]> GetCollections(long userId);
    }
}
