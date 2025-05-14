using log4net.Util;
using Microsoft.AspNetCore.Mvc;
using SqlSugar;
using WebApplication72.Autofac;
using WebApplication72.Common;
using WebApplication72.Db;
using WebApplication72.Db.Entity;
using WebApplication72.Db.Repository;
using WebApplication72.Db.Repository.Implement;
using WebApplication72.Def;

namespace WebApplication72.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        [CustomPropertySelector]
        private ILogger<CustomerController> Logger { get; set; }

        [CustomPropertySelector]
        private IConfiguration Configuration { get; set; }

        [CustomPropertySelector]
        private ISqlSugarClient Db { get; set; }

        [CustomPropertySelector]
        private ICustomerRepository CustomerRepository { get; set; }

        [CustomPropertySelector]
        private ICategoryRepository CategoryRepository { get; set; }

        [HttpGet]
        public IEnumerable<CustomerEntity> GetAll()
        {
            Logger.LogInformation("Get All Customers");
            var ls = Db.Queryable<CustomerEntity>().ToList();
            return ls;
        }

        [HttpGet]
        public CustomerEntity GetById(string id)
        {
            Logger.LogInformation(string.Format("Get Customer By Id: {0}", id));
            var entity = CustomerRepository.QueryById(id);
            return entity;
        }

        [HttpGet]
        [Route("/api/[controller]/GetByIdAsync")]
        public async Task<CustomerEntity> GetByIdAsync(string id)
        {
            Logger.LogInformation(string.Format("Get Customer Async By Id: {0}", id));
            return await CustomerRepository.QueryByIdAsync(id);
        }

        #region Add
        [HttpGet]
        public ApiResultData Add(string customerId)
        {
            if (CustomerRepository.Exist(x => x.CustomerID == customerId))
            {
                return CommonTool.CreateApiResult(false, "重复的CustomerId");
            }
            else
            {
                var entity = new CustomerEntity();
                entity.CustomerID = customerId;
                bool b = CustomerRepository.Add(entity);
                return CommonTool.CreateApiResult(b);
            }
        }

        [HttpGet]
        [Route("/api/[controller]/AddAsync")]
        public async Task<ApiResultData> AddAsync(string customerId)
        {
            if (await CustomerRepository.ExistAsync(x => x.CustomerID == customerId))
            {
                return CommonTool.CreateApiResult(false, "重复的CustomerId");
            }
            else
            {
                var entity = new CustomerEntity();
                entity.CustomerID = customerId;
                bool b = await CustomerRepository.AddAsync(entity);
                return CommonTool.CreateApiResult(b);
            }
        }

        [HttpGet]
        public ApiResultData AddRange()
        {
            var ls = new CustomerEntity[] {
                new CustomerEntity{ CustomerID = CommonTool.CreateCustomerId() }
                , new CustomerEntity{ CustomerID = CommonTool.CreateCustomerId() }
            };
            bool b = CustomerRepository.AddRange(ls);
            return CommonTool.CreateApiResult(b);
        }

        [HttpGet]
        [Route("/api/[controller]/AddRangeAsync")]
        public async Task<ApiResultData> AddRangeAsync()
        {
            var ls = new CustomerEntity[] {
                new CustomerEntity{ CustomerID = CommonTool.CreateCustomerId() }
                , new CustomerEntity{ CustomerID = CommonTool.CreateCustomerId() }
            };
            bool b = await CustomerRepository.AddRangeAsync(ls);
            return CommonTool.CreateApiResult(b);
        }

        [HttpGet]
        public ApiResultData AddByColumns()
        {
            var entity = new CustomerEntity();
            entity.CustomerID = CommonTool.CreateCustomerId();
            entity.CompanyName2 = "Company Name";
            entity.ContactName = "Contact Name";
            entity.ContactTitle = "Contact Title";
            var columns = new string[] {
                EntityTool.GetFieldName<CustomerEntity,string>(x => x.CustomerID)
                , EntityTool.GetFieldName<CustomerEntity, string>(x => x.CompanyName2)
                , EntityTool.GetFieldName<CustomerEntity, string>(x => x.ContactName)
            };
            bool b = CustomerRepository.AddByColumns(entity, columns);
            return CommonTool.CreateApiResult(b);
        }

        [HttpGet]
        public ApiResultData AddByIgnoreColumns()
        {
            var entity = new CustomerEntity();
            entity.CustomerID = CommonTool.CreateCustomerId();
            entity.CompanyName2 = "Company Name 2";
            entity.ContactName = "Contact Name 2";
            entity.ContactTitle = "Contact Title 2";
            var columns = new string[] {
                EntityTool.GetFieldName<CustomerEntity, string>(x => x.ContactTitle)
            };
            bool b = CustomerRepository.AddByIgnoreColumns(entity, columns);
            return CommonTool.CreateApiResult(b);
        }
        #endregion

        #region Delete
        [HttpGet]
        public ApiResultData DeleteById()
        {
            bool b = CustomerRepository.DeleteById<string>("VINET");
            return CommonTool.CreateApiResult(b);
        }

        [HttpGet]
        public ApiResultData DeleteByIds()
        {
            var sql = "';delete from customers;";
            var sql2 = "';";
            var ids = new string[] { sql, sql2 };
            var n = CustomerRepository.DeleteByIds<string>(ids);
            return CommonTool.CreateApiResult(success: n > 0);
        }
        #endregion
    }
}
