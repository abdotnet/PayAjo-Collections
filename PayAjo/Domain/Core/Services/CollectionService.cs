using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using PayAjo.Data;
using PayAjo.Data.Entities;
using PayAjo.Data.Repository;
using PayAjo.Domain.Core.Interfaces;
using PayAjo.Domain.Core.Models;
using PayAjo.Domain.Infrastucture;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PayAjo.Domain.Core.Services
{
    public class CollectionService : Service, ICollectionService
    {
        private readonly ILogger<CollectionService> _logger;
        private readonly PayAjoContext _repo;
        private readonly IConfiguration _config;
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepo;

        public CollectionService(ILogger<CollectionService> logger, PayAjoContext repo, IConfiguration config,
            IMapper mapper, IUserRepository userRepo)
            : base(repo)
        {
            _logger = logger;
            _repo = repo;
            _config = config;
            _mapper = mapper;
            _userRepo = userRepo;
        }

        #region Customer api

        public Operation<Pagination<CollectionModel>> GetCollections(string search, int pageIndex, int pageSize = 100)
        {
            return Operation.Create(() =>
            {
                _logger.LogInformation("I am currently @ the get customer collection ");

                var query = _repo.Collection.Where(s => !s.IsCancelled).ToList();

                if (!string.IsNullOrEmpty(search))
                    query = query.Where(c => c.CollectionCode.Contains(search)).ToList();

                long totalCount = query.LongCount();
                if (pageIndex > 0) query = query.Skip(pageSize).Take(pageIndex * pageSize).ToList();

                var collection = _mapper.Map<IEnumerable<Collection>, IEnumerable<CollectionModel>>(query).ToArray();

                return new Pagination<CollectionModel>(collection, totalCount, pageSize, pageIndex);

            });
        }

        public Operation<CollectionModel[]> GetCollections()
        {
            return Operation.Create(() =>
            {
                _logger.LogInformation("I am currently @ the get collection function");

                var query = _repo.Collection.Include(cus => cus.Customer).Include(mer => mer.Merchant)
                .Where(c => !c.IsCancelled).ToList();

                var lstCustomers = new List<CollectionModel>();

                foreach (var item in query)
                {
                    lstCustomers.Add(new CollectionModel()
                    {
                        CustomerId = item.CustomerId,
                        Amount = item.Amount,
                        IsApproved = item.IsApproved,
                        CreatedDate = item.CreatedDate,
                        MerchantId = item.MerchantId,
                        Merchant = new MerchantModel()
                        {
                            Address = item.Merchant.Address,
                            BusinessMobile = item.Merchant.BusinessMobile,
                            MerchantNo = item.Merchant.MerchantNo,
                            Name = item.Merchant.Name
                        },
                        Customer = new CustomerModel()
                        {
                            Mobile = item.Customer.Mobile,
                            FirstName = item.Customer.FirstName,
                            LastName = item.Customer.LastName,
                            NokMobile = item.Customer.NokMobile
                        },
                        Id = item.Id
                    });
                }


                return lstCustomers.ToArray();
            });
        }
        public Operation<CollectionModel> GetCollection(long id)
        {
            return Operation.Create(() =>
            {
                _logger.LogInformation($"I am currently @ the get collection by Id {id}");

                var query = _repo.Collection.Include(c => c.Customer).Include(m => m.Merchant).
                Select(item => new CollectionModel()
                {
                    Amount = item.Amount,
                    CustomerId = item.CustomerId,
                    Customer = new CustomerModel()
                    {
                        Mobile = item.Customer.Mobile,
                        FirstName = item.Customer.FirstName,
                        LastName = item.Customer.LastName,
                        NokMobile = item.Customer.NokMobile
                    },
                    Merchant = new MerchantModel()
                    {
                        Address = item.Merchant.Address,
                        BusinessMobile = item.Merchant.BusinessMobile,
                        MerchantNo = item.Merchant.MerchantNo,
                        Name = item.Merchant.Name
                    },
                    IsCancelled = item.IsCancelled,
                    CreatedDate = item.CreatedDate,
                    CollectionCode = item.CollectionCode,
                    Id = item.Id

                }).FirstOrDefault(c => c.CustomerId == id);

                return query;
            });
        }

        public Operation<CollectionModel[]> GetCollections(long customerId)
        {
            return Operation.Create(() =>
            {
                _logger.LogInformation($"I am currently @ the get collection by customer Id {customerId}");

                var query = _repo.Collection.Include(c => c.Customer).Include(m => m.Merchant).Select(item => new CollectionModel()
                {
                    Amount = item.Amount,
                    CustomerId = item.CustomerId,
                    Customer = new CustomerModel()
                    {
                        Mobile = item.Customer.Mobile,
                        FirstName = item.Customer.FirstName,
                        LastName = item.Customer.LastName,
                        NokMobile = item.Customer.NokMobile,
                        CustomerId = item.Customer.CustomerId
                    },
                    Merchant = new MerchantModel()
                    {
                        Address = item.Merchant.Address,
                        BusinessMobile = item.Merchant.BusinessMobile,
                        MerchantNo = item.Merchant.MerchantNo,
                        Name = item.Merchant.Name,
                        Id = item.Merchant.MerchantId
                    },
                    IsCancelled = item.IsCancelled,
                    CreatedDate = item.CreatedDate,
                    CollectionCode = item.CollectionCode,
                    Id = item.Id

                }).Where(c => c.CustomerId == customerId).ToArray();

                return query;
            });
        }

        public Operation<CollectionModel> AddOrUpdateCollection(CollectionModel model)
        {
            return Operation.Create(() =>
            {
                if (model == null)
                {
                    _logger.LogError("Collection cannot be empty");
                    throw new Exception("Collection cannot be empty");
                }

                model.Validate().Catch(c=> throw new Exception("Error: " + c.Message));

                var query = _repo.Collection.FirstOrDefault(c => c.Id == model.Id && !c.IsCancelled);

                if (query == null)
                {
                    query = new Collection()
                    {
                        CustomerId = model.CustomerId,
                        Amount = model.Amount,
                        IsApproved = model.IsApproved,
                        CreatedDate = model.CreatedDate,
                        MerchantId = model.MerchantId,
                        CollectionCode = model.CollectionCode,
                        Id = model.Id
                    };

                    _repo.Add<Collection>(query);
                    _repo.SaveChanges();
                }
                else
                {
                    query.CustomerId = model.CustomerId;
                    query.Amount = model.Amount;
                    query.IsApproved = model.IsApproved;
                    query.CreatedDate = model.CreatedDate;
                    //query.MerchantId = model.MerchantId;

                    query.ModifiedBy = model.ModifiedBy.HasValue ? model.ModifiedBy.Value : 0;
                    query.ModifiedDate = DateTime.Now;

                    _repo.Update<Collection>(query);
                    _repo.SaveChanges();
                }

                return new CollectionModel()
                {
                    Id = query.Id,
                    Amount = query.Amount,
                    MerchantId = query.MerchantId,
                    CustomerId = query.CustomerId,
                    CollectionCode = query.CollectionCode
                };
            });
        }
        public Operation DeleteCollection(long id)
        {
            return Operation.Create(() =>
            {
                var query = _repo.Collection.SingleOrDefault(c => c.Id == id);
                query.IsCancelled = true;

                _repo.Update<Collection>(query);
                _repo.SaveChanges();
                _logger.LogInformation($"Collection has been deleted with Id= {id} ");
            });
        }

        #endregion

    }
}
