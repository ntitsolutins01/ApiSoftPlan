using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Common.Models;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Application.Common.Mapping
{
    public static class MappingExtensions
    {
        public static Task<List<TDestination>> ProjectToListAsync<TDestination>(this IQueryable queryable, TypeAdapterConfig configuration)
            => queryable.ProjectToType<TDestination>(configuration).ToListAsync();
    }
}
