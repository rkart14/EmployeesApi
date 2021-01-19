using Abp.Domain.Entities;
using Abp.EntityFrameworkCore;
using Abp.EntityFrameworkCore.Repositories;
using EmployeesApi.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeesApi.Repositories
{
    public class EmployeesApiRepositoryBase<TEntity, TPrimaryKey> : EfCoreRepositoryBase<EmployeesApiDbContext, TEntity, TPrimaryKey>
    where TEntity : class, IEntity<TPrimaryKey>
    {
        public EmployeesApiRepositoryBase(IDbContextProvider<EmployeesApiDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
        }
        //common methods for all repositories
    }

    public class EmployeesApiRepositoryBase<TEntity> : EmployeesApiRepositoryBase<TEntity, int>
    where TEntity : class, IEntity<int>
    {
        public EmployeesApiRepositoryBase(IDbContextProvider<EmployeesApiDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
        }

        //do not add any method here, add to the class above (because this class inherits it)
    }
}
