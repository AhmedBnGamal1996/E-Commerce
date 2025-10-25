using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presistence
{
    internal static class SpecificaitionsEvluator
    {

        public static IQueryable<TEntity> CreateQuery<TEntity , TKey>(IQueryable<TEntity> inputQuery 
            , ISpecifications<TEntity, TKey> specifications) where TEntity : BaseEntity<TKey>

        {
            var query = inputQuery;
            if (specifications.Criteria is not null)
                query = query.Where(specifications.Criteria); 


            if(specifications.OrderBy is not null)
            {
                query = query.OrderBy(specifications.OrderBy);
            }
            else if (specifications.OrderByDescending is not null)
            {
                query = query.OrderByDescending(specifications.OrderByDescending);
            }






            if (specifications.Criteria is not null && specifications.IncludeExpressions.Count > 0)


            {


                query = specifications.IncludeExpressions
                    .Aggregate(query, (currentQuery, expression) 
                    => currentQuery.Include(expression));


                  

            }

            if(specifications.IsPaginated)
            {
                query = query.Skip(specifications.Skip).Take(specifications.Take);
            }



            return query;
        }














    }
}
