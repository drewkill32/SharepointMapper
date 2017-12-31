using Microsoft.SharePoint.Client;
using System;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace Shmapper
{
    public static class ClientContextExtensions
    {
        private static readonly SemaphoreSlim mutex = new SemaphoreSlim(1);

        public static async Task ExecuteQueryAsync(this ClientContext clientContext, CancellationToken token)
        {
            token.ThrowIfCancellationRequested();
            //only allow one context to execute at a time
            await mutex.WaitAsync(token);
            try
            {
                await RunAsync(clientContext.ExecuteQuery, token);
            }
            finally
            {
                mutex.Release();
            }
        }



        public static async Task LoadAync<T>(this ClientContext clientContext, CancellationToken token, T clientObject, params Expression<Func<T, object>>[] retievals) where T : ClientObject
        {
            clientContext.Load(clientObject, retievals);
            await clientContext.ExecuteQueryAsync(token);
        }


        private static Task RunAsync(Action action, CancellationToken token)
        {
            var tcs = new TaskCompletionSource<object>();
            token.Register(() => tcs.SetCanceled());
            ThreadPool.QueueUserWorkItem(_ =>
            {
                try
                {
                    action();
                    tcs.SetResult(null);
                }
                catch (Exception exc) { tcs.SetException(exc); }
            });
            return tcs.Task;
        }


    }
}
