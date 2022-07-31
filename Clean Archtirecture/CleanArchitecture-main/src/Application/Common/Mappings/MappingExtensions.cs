using AutoMapper;
using AutoMapper.QueryableExtensions;
using CleanArchitecture.Application.Common.Models;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Application.Common.Mappings;

//this extension is used to Projection data into the target DTO , this is used for Query Operation 
public static class MappingExtensions
{
    public static Task<PaginatedList<TDestination>> PaginatedListAsync<TDestination>(this IQueryable<TDestination> queryable, int pageNumber, int pageSize) where TDestination : class
        => PaginatedList<TDestination>.CreateAsync(queryable.AsNoTracking(), pageNumber, pageSize);

    public static Task<List<TDestination>> ProjectToListAsync<TDestination>(this IQueryable queryable, IConfigurationProvider configuration) where TDestination : class
        => queryable.ProjectTo<TDestination>(configuration).AsNoTracking().ToListAsync();
}
