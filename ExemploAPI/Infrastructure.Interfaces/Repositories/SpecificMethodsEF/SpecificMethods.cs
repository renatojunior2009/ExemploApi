using Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Infrastructure.Interfaces.Repositories.SpecificMethodsEF
{
    public abstract class SpecificMethods<T> where T: class, IEntityBase
    {
        protected abstract IQueryable<T> GenerateQuery(Expression<Func<T, bool>> conditions = null, Func<IQueryable<T>, IOrderedQueryable<T>> hasOrdination = null, params string[] parameters);        
    }
}
