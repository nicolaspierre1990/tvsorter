using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace TVSorter;

internal static class DbContextExtensions
{
    /// <summary>
    /// Inserts or updates the given <typeparamref name="TEntity"/>.
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    /// <param name="context">The context.</param>
    /// <param name="entity">The entity.</param>
    internal static void InsertOrUpdate<TEntity>(this DbContext context, TEntity entity) where TEntity : class
    {
        var dbSet = context.Set<TEntity>();

        if (dbSet.Contains(entity))
        {
            dbSet.Entry(entity).State = EntityState.Modified;
        }
        else
        {
            dbSet.Add(entity);
        }

        context.SaveChanges();
    }
}
