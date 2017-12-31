using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.SharePoint.Client;
using Shmapper.Extensions;

namespace Shmapper
{
    public partial class SharepointClient:ISharepointClientAsync
    {
        public Task<List<T>> QueryAsync<T>(Expression<Func<T, bool>> filter, CancellationToken token) where T : ISharepointItem, new()
        {
            throw new NotImplementedException();
        }


        public Task<List<T>> QueryAsync<T>(string camlQueryString, CancellationToken token) where T : ISharepointItem, new()
        {
            CamlQuery query = new CamlQuery { ViewXml = camlQueryString };
            return QueryAsync<T>(query,token);
        }


        private async Task<List<T>> QueryAsync<T>(CamlQuery query, CancellationToken token) where T : ISharepointItem, new()
        {
            ListItemCollection items = LoadListItems<T>(query);

            await context.ExecuteQueryAsync(token);


            List<T> result = MappListItems<T>(items);

            return result;
        }



   

        public Task<List<T>> GetAllAsync<T>(CancellationToken token) where T : ISharepointItem, new()
        {
            throw new NotImplementedException();
        }

        public Task<T> GetByIdAsync<T>(int Id, CancellationToken token) where T : ISharepointItem, new()
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync<T>(T Entity, CancellationToken token) where T : ISharepointItem
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync<T>(IEnumerable<T> Entities, CancellationToken token) where T : ISharepointItem
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync<T>(T Entity, CancellationToken token) where T : ISharepointItem
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync<T>(IEnumerable<T> Entities, CancellationToken token) where T : ISharepointItem
        {
            throw new NotImplementedException();
        }

        public Task InsertAsync<T>(T Entitiy, CancellationToken token) where T : ISharepointItem
        {
            throw new NotImplementedException();
        }

        public Task InsertAsync<T>(IEnumerable<T> Entity, CancellationToken token) where T : ISharepointItem
        {
            throw new NotImplementedException();
        }
    }
}