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
        /// Get items of type <T> by lambda expression - filter asynchronously
        /// </summary>
        Task<List<T>> QueryAsync<T>(Expression<Func<T, bool>> filter,CancellationToken token) where T : ISharepointItem, new();

        /// <summary>
        /// Get items of type <T> by caml query string. Empty query returns all items asynchronously.
        /// </summary>
        Task<List<T>> QueryAsync<T>(string camlQueryString, CancellationToken token) where T : ISharepointItem, new();

        /// <summary>
        /// Get all items of type <T> asynchronously.
        /// </summary>
        Task<List<T>> GetAllAsync<T>(CancellationToken token) where T : ISharepointItem, new();

        /// <summary>
        /// Get item by ID of type <T> asynchronously.
        /// </summary>
        Task<T> GetByIdAsync<T>(int Id,CancellationToken token) where T : ISharepointItem, new();

        /// <summary>
        /// Update corresponding changed item in SharePoint asynchronously.
        /// </summary>
        Task UpdateAsync<T>(T Entity,CancellationToken token) where T : ISharepointItem;

        /// <summary>
        /// Update corresponding items in SharePoint asynchronously.
        /// </summary>
        Task UpdateAsync<T>(IEnumerable<T> Entities,CancellationToken token) where T : ISharepointItem;

        /// <summary>
        /// Remove corresponding item from SharePoint asynchronously.
        /// </summary>
        Task DeleteAsync<T>(T Entity,CancellationToken token) where T : ISharepointItem;

        /// <summary>
        /// Remove corresponding items from SharePoint asynchronously.
        /// </summary>
        Task DeleteAsync<T>(IEnumerable<T> Entities,CancellationToken token) where T : ISharepointItem;

        /// <summary>
        /// Create new item in SharePoint asynchronously.
        /// </summary>
        Task InsertAsync<T>(T Entitiy,CancellationToken token) where T : ISharepointItem;

        /// <summary>
        /// Create new items in SharePoint asynchronously.
        /// </summary>
        Task InsertAsync<T>(IEnumerable<T> Entity,CancellationToken token) where T : ISharepointItem;
    }
}