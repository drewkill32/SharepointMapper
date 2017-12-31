using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Shmapper
{
    public interface ISharepointClient : IDisposable
    {
        /// <summary>
        /// Get items of type <T> by lambda expression - filter
        /// </summary>
        List<T> Query<T>(Expression<Func<T, bool>> filter) where T : ISharepointItem, new();

        /// <summary>
        /// Get items of type <T> by caml query string. Empty query returns all items.
        /// </summary>
        List<T> Query<T>(string camlQueryString) where T : ISharepointItem, new();

        /// <summary>
        /// Get all items of type <T>.
        /// </summary>
        List<T> GetAll<T>() where T : ISharepointItem, new();

        /// <summary>
        /// Get item by ID of type <T>.
        /// </summary>
        T GetById<T>(int Id) where T : ISharepointItem, new();

        /// <summary>
        /// Update corresponding changed item in Sharepoint.
        /// </summary>
        void Update<T>(T Entity) where T : ISharepointItem;

        /// <summary>
        /// Update corresponding items in Sharepoint.
        /// </summary>
        void Update<T>(IEnumerable<T> Entities) where T : ISharepointItem;

        /// <summary>
        /// Remove corresponding item from Sharepoint.
        /// </summary>
        void Delete<T>(T Entity) where T : ISharepointItem;

        /// <summary>
        /// Remove corresponding items from Sharepoint.
        /// </summary>
        void Delete<T>(IEnumerable<T> Entities) where T : ISharepointItem;

        /// <summary>
        /// Create new item in Sharepoint.
        /// </summary>
        void Insert<T>(T Entitiy) where T : ISharepointItem;

        /// <summary>
        /// Create new items in Sharepoint.
        /// </summary>
        void Insert<T>(IEnumerable<T> Entity) where T : ISharepointItem;
    }
}