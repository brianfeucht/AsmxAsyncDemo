using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace AsmxAsync
{
    public static class TaskExtensions
    {
        public static Task<TResult> ToApm<TResult>(this Task<TResult> task, AsyncCallback callback, object state)
        {
            var tcs = new TaskCompletionSource<TResult>(state);

            task.ContinueWith(delegate
            {
                if (task.IsFaulted) tcs.TrySetException(task.Exception.InnerExceptions);
                else if (task.IsCanceled) tcs.TrySetCanceled();
                else tcs.TrySetResult(task.Result);

                if (callback != null) callback(tcs.Task);

            }, CancellationToken.None, TaskContinuationOptions.None, TaskScheduler.Default);

            return tcs.Task;
        }
    }
}