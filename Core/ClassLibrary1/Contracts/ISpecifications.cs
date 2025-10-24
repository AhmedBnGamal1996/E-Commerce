using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Contracts
{
    public interface ISpecifications<TEntitiy,TKey> where TEntitiy : BaseEntity<TKey>
    {

        public  Expression<Func<TEntitiy, bool>>? Criteria { get; }



        public List<Expression<Func<TEntitiy, object>>> IncludeExpressions { get; }



        public Expression<Func<TEntitiy, object>> OrderBy { get; }

        public Expression<Func<TEntitiy, object>> OrderByDescending { get;







        }
}
