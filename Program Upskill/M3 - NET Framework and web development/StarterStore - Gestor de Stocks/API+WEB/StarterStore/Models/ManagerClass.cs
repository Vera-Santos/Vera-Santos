using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;


namespace StarterStore.Models
{
    public abstract class ManagerClass<TEntity, TKey>
    where TEntity : class
    {
        protected string connectionString { get; }  = "Server=.;Database=Northwind2016;User Id=sa; Password=upskills2021;";


        public abstract List<TEntity> ReadAll();
        public abstract TEntity GetById(TKey id);
        public abstract void Save(TEntity entity);
        public abstract void Update(TEntity entity);
        //public abstract void Delete(TEntity entity);
        public abstract void DeleteById(TKey id);
    }
}