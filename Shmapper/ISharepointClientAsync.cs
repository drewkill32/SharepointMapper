using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace Shmapper
{
    public interface ISharepointClientAsync : IDisposable
    {
        /// <summary>
        /// Get items of type <T> by lambda expression - filter
        /// </summary>
        Task<List<T>> Query<T>(Expression<Func<T, bool>> filter,CancellationToken token) where T : ISharepointItem, new();

        /// <summary>
        /// Get items of type <T> by caml query string. Empty query returns all items.
        /// </summary>
        Task<List<T>> Query<T>(string camlQueryString, CancellationToken token) where T : ISharepointItem, new();

        /// <summary>
        /// Get all items of type <T>.
        /// </summary>
        Task<List<T>> GetAll<T>(CancellationToken token) where T : ISharepointItem, new();

        /// <summary>
        /// Get item by ID of type <T>.
        /// </summary>
        Task<T> GetById<T>(int Id,CancellationToken token) where T : ISharepointItem, new();

        /// <summary>
        /// Update corresponding changed item in Sharepoint.
        /// </summary>
        Task Update<T>(T Entity,CancellationToken token) where T : ISharepointItem;

        /// <summary>
        /// Update corresponding items in Sharepoint.
        /// </summary>
        Task Update<T>(IEnumerable<T> Entities,CancellationToken token) where T : ISharepointItem;

        /// <summary>
        /// Remove corresponding item from Sharepoint.
        /// </summary>
        Task Delete<T>(T Entity,CancellationToken token) where T : ISharepointItem;

        /// <summary>
        /// Remove corresponding items from Sharepoint.
        /// </summary>
        Task Delete<T>(IEnumerable<T> Entities,CancellationToken token) where T : ISharepointItem;

        /// <summary>
        /// Create new item in Sharepoint.
        /// </summary>
        Task Insert<T>(T Entitiy,CancellationToken token) where T : ISharepointItem;

        /// <summary>
        /// Create new items in Sharepoint.
        /// </summary>
        Task Insert<T>(IEnumerable<T> Entity,CancellationToken token) where T : ISharepointItem;
    }
}