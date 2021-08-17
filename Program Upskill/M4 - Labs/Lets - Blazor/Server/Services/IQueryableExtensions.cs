using BlazorLets.Shared.Models;
using System.Linq;

namespace BlazorLets.Server.Services
{
    public static class IQueryableExtensions
    {
        // retorna a quantidade de elementos definida por página e o seu respectivo índice
        public static IQueryable<T> Paginate<T>(this IQueryable<T> queryable, PaginationDTO pagination)
        {
            return queryable
                .Skip((pagination.Page - 1) * pagination.QuantityPerPage) // salta x elementos (inicia no index zero)
                .Take(pagination.QuantityPerPage); // traz x elementos
        }
    }
}
