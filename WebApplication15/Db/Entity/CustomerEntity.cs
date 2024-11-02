﻿using SqlSugar;

namespace WebApplication15.Db.Entity
{
    [SugarTable("customers")]
    public class CustomerEntity
    {
        [SugarColumn(IsPrimaryKey = true)]
        public virtual string CustomerID { get; set; } = string.Empty;

        public virtual string CompanyName { get; set; } = string.Empty;

        public virtual string ContactName { get; set; } = string.Empty;

        public virtual string ContactTitle { get; set; } = string.Empty;

        public virtual string Address { get; set; } = string.Empty;

        public virtual string City { get; set; } = string.Empty;

        public virtual string Region { get; set; } = string.Empty;

        public virtual string PostalCode { get; set; } = string.Empty;

        public virtual string Country { get; set; } = string.Empty;

        public virtual string Phone { get; set; } = string.Empty;

        public virtual string Fax { get; set; } = string.Empty;
    }
}
